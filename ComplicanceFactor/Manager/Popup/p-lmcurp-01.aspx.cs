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
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.Manager.Popup
{
    public partial class p_lmcurp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllEmployee();
            }
        }
        private void GetAllEmployee()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(Request.QueryString["id"]);
            //bind curriculum
            gvCurriculum.DataSource = dsEmployee.Tables[1];
            gvCurriculum.DataBind();
            if (gvCurriculum.Rows.Count > 0)
            {
                gvCurriculum.UseAccessibleHeader = true;
                if (gvCurriculum.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvCurriculum.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        protected void btnPrintPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsCurricula = new DataSet();
            try
            {
                dsCurricula = EnrollmentBLL.GetCurriculaPdf(Request.QueryString["id"], SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx", ex.Message);
                    }
                }

            }
            if (dsCurricula.Tables[1].Rows.Count > 0)
            {
                exportDataTableToCsv(dsCurricula.Tables[0], dsCurricula.Tables[2]);
            }
        }
        private void exportDataTableToCsv(DataTable dt, DataTable dtCurriculaColumnName)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyCurricula.csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dtCurriculaColumnName.Rows.Count; k++)
            {
                //add separator
                sb.Append(dtCurriculaColumnName.Rows[k]["curriculaColumnName"].ToString() + ',');
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
        private void PrintPdf()
        {
            rvCurricula.LocalReport.DataSources.Clear();
            DataSet dsCurricula = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
            try
            {
                dsCurricula = EnrollmentBLL.GetCurriculaPdf(Request.QueryString["id"], SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("lmcurp-01.aspx", ex.Message);
                    }
                }

            }
            if (dsCurricula.Tables[0].Rows.Count > 0)
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                rvCurricula.ProcessingMode = ProcessingMode.Local;
                rvCurricula.LocalReport.EnableExternalImages = true;
                rvCurricula.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Employee.Curricula.PdfTemplate.MyCurricula.rdlc";

                SystemThemes userTheme = new SystemThemes();
                userTheme = GetthemeforEmailandPdf();


                string protocol = Request.Url.AbsoluteUri;
                int len = protocol.IndexOf(':');
                protocol = protocol.Substring(0, len);

                rvCurricula.LocalReport.DataSources.Add(new ReportDataSource("MyCurricula", dsCurricula.Tables[0]));
                rvCurricula.LocalReport.DataSources.Add(new ReportDataSource("HeaderFooter", dsCurricula.Tables[1]));

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
                this.rvCurricula.LocalReport.SetParameters(param);

                byte[] bytes = rvCurricula.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=\"" + "MyCurricula" + ".pdf" + "\"");
                Response.BinaryWrite(bytes); // create the file     
                Response.Flush(); // send it to the client to download  
                Response.End();
                Response.Close();
            }
        }

        // For Theme for email and pdf
        private static SystemThemes GetthemeforEmailandPdf()
        {
            SystemThemes userTheme = new SystemThemes();
            userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);
            return userTheme;
        }

    }
}