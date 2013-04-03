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

namespace ComplicanceFactor.Employee.Curricula
{
    public partial class lmcurp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee")+"</a>" + " >&nbsp;" + "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_my_curricula_text");
                GetAllEmployee();
            }
        }
        private void GetAllEmployee()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(SessionWrapper.u_userid);
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
            DataSet dsEmployee = new DataSet();
            try
            {
                dsEmployee = EnrollmentBLL.GetAllCurricula(SessionWrapper.u_userid);
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
            if (dsEmployee.Tables[1].Rows.Count > 0)
            {
                exportDataTableToCsv(dsEmployee.Tables[1]);
            }
        }
        private void exportDataTableToCsv(DataTable dt)
        {
            Response.Clear();
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyCurricula.csv");
            Response.ContentEncoding = Encoding.Unicode;
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                //add separator
                sb.Append(dt.Columns[k].ColumnName + ',');
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
                dsCurricula = EnrollmentBLL.GetAllCurricula(SessionWrapper.u_userid);
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
                rvCurricula.LocalReport.DataSources.Add(new ReportDataSource("MyCurricula", dsCurricula.Tables[0]));
                rvCurricula.LocalReport.DataSources.Add(new ReportDataSource("HeaderFooter", dsCurricula.Tables[2]));
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
        protected void gvCurriculum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnEnroll = (Button)e.Row.FindControl("btnEnroll");
                Button btnLaunch = (Button)e.Row.FindControl("btnLaunch");
                Button btnDrop = (Button)e.Row.FindControl("btnDrop");
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                if (status == "Enrolled")
                {
                    
                    e.Row.Cells[3].Text = "In Progress";
                }
                //string deliveryType = DataBinder.Eval(e.Row.DataItem, "deliveryType").ToString();
                //if (status == "Assigned")
                //{
                //    btnEnroll.Style.Add("display", "inline");
                //}
                ////else if (status == "Enrolled" && deliveryType == "OLT")
                ////{
                //    //btnLaunch.Style.Add("display", "inline");
                ////}
                //else if (status == "Enrolled")
                //{
                //    btnDrop.Style.Add("display", "inline");
                //}
                //else if (status == "Canceled")
                //{
                //    btnDrop.Style.Add("display", "inline");
                //}
                
               

            }
        }

        protected void gvCurriculum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Enroll"))
            {
                Response.Redirect("~/Employee/Curricula/lvcure-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);

            }
            //else if (e.CommandName.Equals("Launch"))
            //{
            //    //insert enrollment
            //    BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
            //    enrollOLT.e_enroll_user_id_fk = SessionWrapper.u_userid;
            //    enrollOLT.e_enroll_course_id_fk = e.CommandArgument.ToString();
            //    enrollOLT.e_enroll_required_flag = true;
            //    enrollOLT.e_enroll_approval_required_flag = true;
            //    enrollOLT.e_enroll_type_name = "Self-enroll";
            //    enrollOLT.e_enroll_approval_status_name = "Pending";
            //    enrollOLT.e_enroll_status_name = "Enrolled";
            //    EnrollmentBLL.QuickLaunchEnroll(enrollOLT);
            //    Response.Redirect("~/Employee/Course/lmcp-01.aspx", false);
            //}
            else if (e.CommandName.Equals("View"))
            {
                Response.Redirect("~/Employee/Curricula/lvcurd-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
            }
            //if (e.CommandName.Equals("Drop"))
            //{
            //    BusinessComponent.DataAccessObject.Enrollment UpdateEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
            //    UpdateEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
            //    UpdateEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
            //    EnrollmentBLL.UpdateEnrollmentStatus(UpdateEnrollmentStatus);
            //    Response.Redirect("~/Employee/Course/lmcp-01.aspx", false);
            //}
        }

    }
}