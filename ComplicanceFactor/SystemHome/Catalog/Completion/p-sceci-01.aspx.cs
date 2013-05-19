using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.Completion
{
    public partial class p_sceci_01 : System.Web.UI.Page
    {
        private static string courseId;
        private static string deliveryId;
        private static string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["userId"]))
                {
                    userId = Request.QueryString["userId"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["courseId"]))
                {
                    courseId = Request.QueryString["courseId"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["deliveryId"]))
                {
                    deliveryId = Request.QueryString["deliveryId"].ToString();
                }
                PopulateSession(userId, courseId, deliveryId);
            }
        }

        private void PopulateSession(string userId, string courseId, string deliveryId)
        {
            User user = new User();
            try
            {
                user = UserBLL.GetUserInfo_by_id(userId);
                lblEmployeeName.Text = user.Firstname + user.Lastname;
                lblEmployeeNumber.Text = user.Hris_employeid;

                gvsearchDetails.DataSource = ManageCompletionBLL.GetSessionTranscripts(userId, courseId, deliveryId);
                gvsearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-sceci-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sceci-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string u_user_id_pk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();

                try
                {
                    DropDownList ddlAttendance = (DropDownList)e.Row.FindControl("ddlAttendanceStatus");
                    ddlAttendance.DataSource = ManageCompletionBLL.GetAttendanceStatus(SessionWrapper.CultureName, "samcsmp-01");
                    ddlAttendance.DataBind();

                    DataRowView drv = (DataRowView)e.Row.DataItem;

                    string attendenceName = Convert.ToString(drv["t_transcript_session_attendance_id_fk"]);
                    ddlAttendance.SelectedValue = attendenceName;

                    DropDownList ddlPassingStatus = (DropDownList)e.Row.FindControl("ddlPassignStatus");
                    ddlPassingStatus.DataSource = ManageCompletionBLL.GetPassingStatus(SessionWrapper.CultureName, "samcsmp-01");
                    ddlPassingStatus.DataBind();
                    DataRowView drpassing = (DataRowView)e.Row.DataItem;
                    string passingStatus = Convert.ToString(drpassing["t_transcript_session_passing_status_id_fk"]);
                    ddlPassingStatus.SelectedValue = passingStatus;

                    DropDownList ddlGrade = (DropDownList)e.Row.FindControl("ddlGrade");
                    ddlGrade.DataSource = ManageCompletionBLL.GetGrade(deliveryId);
                    ddlGrade.DataBind();
                    DataRowView drgrade = (DataRowView)e.Row.DataItem;
                    string grade = Convert.ToString(drgrade["t_transcript_session_grade_id_fk"]);
                    ddlGrade.SelectedValue = grade;
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("p-sceci-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("p-sceci-01.aspx", ex.Message);
                        }
                    }
                }

            }
        }

        protected void btnSaveCompletion_Click(object sender, EventArgs e)
        {
            //update session transcripts table 
            foreach (GridViewRow row in gvsearchDetails.Rows)
            {
                string session_id_pk = gvsearchDetails.DataKeys[row.RowIndex][0].ToString();
                string passingStatus = string.Empty;
                string grade = string.Empty;
                DropDownList ddlAttendance = (DropDownList)row.FindControl("ddlAttendanceStatus");
                DropDownList ddlPassingStatus = (DropDownList)row.FindControl("ddlPassignStatus");
                DropDownList ddlGrade = (DropDownList)row.FindControl("ddlGrade");

                TextBox txtscore = (TextBox)row.FindControl("txtScore");
                if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                {
                    SystemGradingSchemes gradevalues = new SystemGradingSchemes();
                    gradevalues = ManageCompletionBLL.GetGradeByScore(deliveryId, Convert.ToInt32(txtscore.Text));
                    if (gradevalues.s_grading_scheme_value_pass_status_id_fk == "app_ddl_pass_text")
                    {
                        passingStatus = "app_ddl_passed_text";
                    }
                    else
                    {
                        passingStatus = "app_ddl_failed_text"; // Need to change as Failed
                    }
                    grade = gradevalues.s_grading_scheme_value_grade;
                }
                else
                {
                    passingStatus = ddlPassingStatus.SelectedValue;
                    grade = ddlGrade.SelectedValue;
                }
                //update seesion transcripts table

                SystemTranscripts updatesessionTranscripts = new SystemTranscripts();
                updatesessionTranscripts.t_transcript_id_pk = session_id_pk;
                updatesessionTranscripts.t_transcript_session_attendance_id_fk = ddlAttendance.SelectedValue;
                updatesessionTranscripts.t_transcript_session_passing_status_id_fk = passingStatus;
                updatesessionTranscripts.t_transcript_session_grade_id_fk = grade;
                if (!string.IsNullOrEmpty(txtscore.Text))
                {
                    updatesessionTranscripts.t_transcript_session_completion_score = Convert.ToInt32(txtscore.Text);
                }
                else
                {
                    updatesessionTranscripts.t_transcript_session_completion_score = 0;
                }

                try
                {
                    int result = ManageCompletionBLL.UpdateSessionTranscripts(updatesessionTranscripts);
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("p-sceci-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("p-sceci-01.aspx", ex.Message);
                        }
                    }
                }
               
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            //Response.Redirect("../SystemHome/Catalog/ManageCompletion/samcmcp-01.aspx");
        }
    }
}