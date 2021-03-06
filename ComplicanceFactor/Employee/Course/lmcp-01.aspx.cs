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
using ComplicanceFactor.BusinessComponent.DataAccessObject;
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
                lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " >&nbsp;" + "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_courses_text") + "</a>";
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

                SystemThemes userTheme = new SystemThemes();
                userTheme = GetthemeforEmailandPdf();


                string protocol = Request.Url.AbsoluteUri;
                int len = protocol.IndexOf(':');
                protocol = protocol.Substring(0, len);

                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("MyCourses", dsEmployee.Tables[0]));
                rvCourses.LocalReport.DataSources.Add(new ReportDataSource("HeaderFooter", dsEmployee.Tables[1]));

                List<ReportParameter> param = new List<ReportParameter>();
                param.Add(new ReportParameter("s_theme_report_logo_file_name",protocol+"://"+ Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_report_logo_file_name));
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
                string enrollType = DataBinder.Eval(e.Row.DataItem, "enrollmentType").ToString();
                string e_enroll_system_id_pk = DataBinder.Eval(e.Row.DataItem, "e_enroll_system_id_pk").ToString().Trim();
                if (status == "Assigned")
                {
                    btnEnroll.Style.Add("display", "inline");
                }
                else if ((status == "Enrolled" || status == "Incomplete" || status == "Completed") && deliveryType == "OLT")
                {
                    btnLaunch.Style.Add("display", "inline");
                    string host = HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString();
                    string url = "http://" + host + "/LMS/CoursePlayer.aspx?eid=" + e_enroll_system_id_pk + "&AICC_SID=" + e_enroll_system_id_pk + "&AICC_URL=" + host + "/LMS/HACP_Handler.aspx";
                    btnLaunch.OnClientClick = "window.open('" + url + "','_blank','height=' + screen.height + ',width=' + screen.width + ',location=0,menubar=0,status=0,toolbar=0,resizable=1');";
                }
                else if ((status == "Enrolled" || status == "Incomplete"))
                {
                    if (enrollType == "Self-enroll")
                    {
                        btnDrop.Style.Add("display", "inline");
                    }
                }
                else if (status == "Pending" && deliveryType == "OLT") // Note: If status is pending and delivery type is OLT then show drop button
                {
                    if (enrollType == "Self-enroll")
                    {
                        btnDrop.Style.Add("display", "inline");
                    }
                }
                else if (status == "Denied")
                {
                    if (enrollType == "Self-enroll")
                    {
                        btnDrop.Style.Add("display", "inline");
                    }
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
               
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                string e_enroll_system_id_pk = gvCourses.DataKeys[rowIndex][1].ToString();
                DataTable dtEnroll = EnrollmentBLL.GetEnrollmentbyId(e_enroll_system_id_pk);
                DateTime? first_attempt = null;
                DateTime? last_attempt = null;
                if (dtEnroll != null)
                {
                    if (dtEnroll.Rows.Count > 0)
                    {
                        if (dtEnroll.Rows[0]["e_enroll_first_attempt_date_time"] == null)
                        {
                            first_attempt = DateTime.Now;
                        }
                        else if (string.IsNullOrEmpty(dtEnroll.Rows[0]["e_enroll_first_attempt_date_time"].ToString()))
                        {
                            first_attempt = DateTime.Now;
                        }
                        else
                        {
                            first_attempt = (DateTime)dtEnroll.Rows[0]["e_enroll_first_attempt_date_time"];
                            last_attempt = DateTime.Now;
                        }
                        EnrollmentBLL.UpdateEnrollmentAttemptDate(e_enroll_system_id_pk, first_attempt, last_attempt);
                        if (dtEnroll.Rows[0]["c_delivery_complete_on_launch"] != null)
                        {
                            if (dtEnroll.Rows[0]["c_delivery_complete_on_launch"].ToString() == "True")
                            {
                                SystemTranscripts sessiontranscripts = new SystemTranscripts
                                {
                                    t_transcript_id_pk = Guid.NewGuid().ToString(),
                                    t_transcript_user_id_fk = dtEnroll.Rows[0]["e_enroll_user_id_fk"].ToString(),
                                    t_transcript_course_id_fk = dtEnroll.Rows[0]["e_enroll_course_id_fk"].ToString(),
                                    t_transcript_delivery_id_fk = dtEnroll.Rows[0]["e_enroll_delivery_id_fk"].ToString(),
                                    t_transcript_attendance_id_fk = "app_ddl_attended_text",
                                    t_transcript_passing_status_id_fk = "app_ddl_completed_text",
                                    t_transcript_completion_date_time = DateTime.Now,
                                    t_transcript_completion_type_id_fk = "app_ddl_manual_user_mark_completion_text",
                                    t_transcript_marked_by_user_id_fk = SessionWrapper.u_userid,// all zeroes
                                    t_transcript_actual_date = DateTime.Now,
                                    t_transcript_target_due_date = string.IsNullOrEmpty(dtEnroll.Rows[0]["e_enroll_target_due_date"].ToString()) ?
                                    DateTime.Now : (DateTime)dtEnroll.Rows[0]["e_enroll_target_due_date"],
                                    t_transcript_score = string.IsNullOrEmpty(dtEnroll.Rows[0]["e_enroll_score"].ToString()) ? 0 : int.Parse(dtEnroll.Rows[0]["e_enroll_score"].ToString()),
                                    t_transcript_credits = string.IsNullOrEmpty(dtEnroll.Rows[0]["c_delivery_credit_units"].ToString()) ? 0 : int.Parse(dtEnroll.Rows[0]["c_delivery_credit_units"].ToString()),

                                    t_transcript_hours = string.IsNullOrEmpty(dtEnroll.Rows[0]["c_delivery_credit_hours"].ToString()) ? 0 : int.Parse(dtEnroll.Rows[0]["c_delivery_credit_hours"].ToString()),

                                    t_transcript_time_spent = string.IsNullOrEmpty(dtEnroll.Rows[0]["e_enroll_time_spent"].ToString()) ? 0 : int.Parse(dtEnroll.Rows[0]["e_enroll_time_spent"].ToString()),

                                    t_transcript_completion_score = 100,
                                    //t_transcript_status_id_fk = tx_status_id_fk,
                                    t_transcript_active_flag = true,
                                    //t_transcript_grade_id_fk = tx_grade_id_fk
                                    t_transcript_status_name = "Completed"

                                };


                                int result = ManageCompletionBLL.InsertTranscripts(sessiontranscripts);


                                ManageCompletionBLL.UpdateEnrollment(dtEnroll.Rows[0]["e_enroll_user_id_fk"].ToString(),
                                    dtEnroll.Rows[0]["e_enroll_course_id_fk"].ToString(), dtEnroll.Rows[0]["e_enroll_delivery_id_fk"].ToString(),
                                    sessiontranscripts.t_transcript_id_pk);
                                Response.Redirect(Request.Url.ToString());
                            }
                        }
                    }
                }

            }
            else if (e.CommandName.Equals("Details"))
            {
                //Response.Redirect("~/Employee/Catalog/ctdp-01.aspx?id=" + SecurityCenter.EncryptText(e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Drop"))
            {
                BusinessComponent.DataAccessObject.Enrollment DropEnrollmentStatus = new BusinessComponent.DataAccessObject.Enrollment();
                DropEnrollmentStatus.e_enroll_user_id_fk = SessionWrapper.u_userid;
                DropEnrollmentStatus.e_enroll_course_id_fk = e.CommandArgument.ToString();
                //EnrollmentBLL.UpdateEnrollmentStatus(UpdateEnrollmentStatus);
                EnrollmentBLL.DropEnrollmentStatus(DropEnrollmentStatus);
                GetAllCourse();
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