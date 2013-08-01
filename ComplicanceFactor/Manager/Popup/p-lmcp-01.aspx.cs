using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Text;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.Manager.Popup
{
    public partial class p_lmcp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCourse();
            }
        }
        private void GetAllCourse()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(Request.QueryString["id"]);
            //bind course
            gvCourses.DataSource = dsEmployee.Tables[0];
            gvCourses.DataBind();
            //bind curriculum

            if (gvCourses.Rows.Count > 0)
            {
                gvCourses.UseAccessibleHeader = true;
                if (gvCourses.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvCourses.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        private void PrintPdf()
        {
            rvCourses.LocalReport.DataSources.Clear();
            DataSet dsEmployee = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
            try
            {
                dsEmployee = EmployeeBLL.GetCoursePDFExcel(Request.QueryString["id"], SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmcp-01.aspx", ex.Message);
                    }
                }

            }
            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvCourses.ProcessingMode = ProcessingMode.Local;
                rvCourses.LocalReport.EnableExternalImages = true;
                rvCourses.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Employee.Course.PdfTemplate.MyCourses.rdlc";

                SystemThemes userTheme = new SystemThemes();
                userTheme = GetthemeforEmailandPdf();


                string protocol = Request.Url.AbsoluteUri;
                int len = protocol.IndexOf(':');
                protocol = protocol.Substring(0, len);

                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("MyCourses", dsEmployee.Tables[0]));
                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("HeaderFooter", dsEmployee.Tables[1]));

                List<ReportParameter> param = new List<ReportParameter>();
                param.Add(new ReportParameter("s_theme_report_logo_file_name", protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_report_logo_file_name));
                param.Add(new ReportParameter("s_theme_css_tag_main_background_hex_value", "#" + userTheme.s_theme_css_tag_main_background_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_foot_top_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_top_line_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_foot_bot_line_hex_value", "#" + userTheme.s_theme_css_tag_foot_bot_line_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_section_head_hex_value", "#" + userTheme.s_theme_css_tag_section_head_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_section_head_text_hex_value", "#" + userTheme.s_theme_css_tag_section_head_text_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_section_head_border_hex_value", "#" + userTheme.s_theme_css_tag_section_head_border_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_table_head_hex_value", "#" + userTheme.s_theme_css_tag_table_head_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_table_head_text_hex_value", "#" + userTheme.s_theme_css_tag_table_head_text_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_table_border_hex_value", "#" + userTheme.s_theme_css_tag_table_border_hex_value));
                param.Add(new ReportParameter("s_theme_css_tag_body_text_hex_value", "#" + userTheme.s_theme_css_tag_body_text_hex_value));
                this.rvCourses.LocalReport.SetParameters(param);

                byte[] bytes = rvCourses.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyCourses" + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
            }
        }
        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsEmployee = new DataSet();
            try
            {
                dsEmployee = EmployeeBLL.GetCoursePDFExcel(Request.QueryString["id"], SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmcp-01.aspx", ex.Message);
                    }
                }

            }
            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                exportDataTableToCsv(dsEmployee.Tables[0], dsEmployee.Tables[2]);
            }
        }
        private void exportDataTableToCsv(DataTable dt, DataTable dtCourseColumnName)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyCourses.csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtCourseColumnName.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtCourseColumnName.Rows[k]["courseColumnName"].ToString() + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Rows[i][k].ToString().Replace(",", ",") + ',');
                }

                //append new line
                sb.Append("\r\n");

            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();


        }

        // For Theme for email and pdf
        private static SystemThemes GetthemeforEmailandPdf()
        {
            SystemThemes userTheme = new SystemThemes();
            userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);
            return userTheme;
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Drop"))
            {
                BusinessComponent.DataAccessObject.Enrollment DropEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                DropEnrollmentStatus.e_enroll_user_id_fk = Request.QueryString["id"].ToString();//current employee id
                DropEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                EnrollmentBLL.DropEnrollmentStatus(DropEnrollmentStatus);
                GetAllCourse();
            }
        }

        protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDrop = (Button)e.Row.FindControl("btnDrop");
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString().Trim();
                if (status == "Enrolled")
                {
                    btnDrop.Style.Add("display", "Block");
                }
                
            }
        }
    }
}