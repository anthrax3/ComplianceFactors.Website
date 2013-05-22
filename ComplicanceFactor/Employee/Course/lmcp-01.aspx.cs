﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Text;
namespace ComplicanceFactor.Employee.Course
{
    public partial class lmcp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>"+LocalResources.GetGlobalLabel("app_nav_employee") +"</a>"+ " >&nbsp;" + "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_my_courses_text");
                GetAllCourse();
            }

            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);
        }
        private void GetAllCourse()
        {
            DataSet dsEmployee = EmployeeBLL.GetAllEmployee(SessionWrapper.u_userid);
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
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Employee/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/ascp-01.aspx", false);
        }
        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Catalog/bchp-01.aspx", false);
        }
        private void PrintPdf()
        {

            rvCourses.LocalReport.DataSources.Clear();
            DataSet dsEmployee = new DataSet();
            DataSet dsHeaderFooter = new DataSet();
            try
            {
                dsEmployee = EmployeeBLL.GetCoursePDFExcel(SessionWrapper.u_userid,SessionWrapper.CultureName);
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
                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("MyCourses", dsEmployee.Tables[0]));
                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("HeaderFooter", dsEmployee.Tables[1]));
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
                dsEmployee = EmployeeBLL.GetCoursePDFExcel(SessionWrapper.u_userid, SessionWrapper.CultureName);
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
                exportDataTableToCsv(dsEmployee.Tables[0],dsEmployee.Tables[2]);
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
        protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnEnroll = (Button)e.Row.FindControl("btnEnroll");
                Button btnLaunch = (Button)e.Row.FindControl("btnLaunch");
                Button btnDrop = (Button)e.Row.FindControl("btnDrop");
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString().Trim();
                string deliveryType = DataBinder.Eval(e.Row.DataItem, "deliveryType").ToString().Trim();
                if (status == "Assigned")
                {
                    btnEnroll.Style.Add("display", "inline");
                }
                else if (status == "Enrolled" && deliveryType == "OLT")
                {
                    btnLaunch.Style.Add("display", "inline");
                }
                else if (status == "Enrolled")
                {
                    btnDrop.Style.Add("display", "inline");
                }
                else if (status == "Pending")
                {
                    btnDrop.Style.Add("display", "inline");
                }
                else if (status == "Denied")
                {
                    btnDrop.Style.Add("display", "inline");
                }
                else if (status == "Approved")
                {
                    btnEnroll.Style.Add("display", "inline");
                }

            }
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Enroll"))
            {
                Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);

            }
            else if (e.CommandName.Equals("Launch"))
            {
                //insert enrollment
                string url = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    if (!url.Contains("http"))
                        url = "http://" + url;
                    ClientScript.RegisterStartupScript(GetType(), "Navigate", "window.open( '" + url + "', '_blank' );", true);
                }
                else
                {
                    string str = "<script>alert(\"Could not find the ScromURl....\");</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
                }
            }
            else if (e.CommandName.Equals("Details"))
            {
                //Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Drop"))
            {
                BusinessComponent.DataAccessObject.Enrollment UpdateEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                UpdateEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
                UpdateEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                EnrollmentBLL.UpdateEnrollmentStatus(UpdateEnrollmentStatus);
                Response.Redirect("~/Employee/Course/lmcp-01.aspx", false);
            }
        }
    }
}