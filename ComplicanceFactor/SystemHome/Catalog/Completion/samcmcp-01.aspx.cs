using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Collections.Generic;
using System.Configuration;

namespace ComplicanceFactor.SystemHome.Catalog.Completion
{
    public partial class samcmcp_01 : System.Web.UI.Page
    {
        private static string deliveryId;
        private static string courseId;
        private static string deliveryType;
        private bool c_course_approval;
        private bool c_delivery_approval;
        private static DataTable dtselectedOLT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Completion/samcsp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_completion_search_result_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_course_details_page_text");

                //
                vs_samcmcp_employee.Style.Add("display", "Block");
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Completion/samcsp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_completion_search_result_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_course_details_page_text") + "</a>";

                btnSaveCompletion.Attributes.Add("OnClick", "return IsCheckBoxSelected(gvsearchSession)");
                SessionWrapper.TempEmployeelist_delivery = null;

                if (!string.IsNullOrEmpty(Request.QueryString["deliveryId"]))
                {
                    deliveryId = SecurityCenter.DecryptText(Request.QueryString["deliveryId"]);
                    hdnDeliveryId.Value = deliveryId;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["courseId"]))
                {
                    courseId = SecurityCenter.DecryptText(Request.QueryString["courseId"]);
                    hdCourseId.Value = courseId;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    if (deliveryType == "OLT")
                    {
                        string selectedUser = string.Empty;
                        //SessionWrapper.selecteduserId_OLT.Remove(SessionWrapper.selecteduserId_OLT.Length - 1, 1);
                        //selectedUser = selectedUser.Remove(selectedUser.Length - 1, 1);
                        gvsearchDetails.DataSource = dtselectedOLT;
                        gvsearchDetails.DataBind();
                        if (gvsearchDetails.Rows.Count > 0)
                        {
                            gvsearchDetails.UseAccessibleHeader = true;
                            if (gvsearchDetails.HeaderRow != null)
                            {
                                //This will tell ASP.NET to render the <thead> for the header row
                                //using instead of the simple <tr>
                                gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                            }
                        }
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                        hdnButtonName.Value = "Edit";
                    }
                    else
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                        //divSuccess.InnerHtml = "inserted successfully";
                    }
                }

                if (!string.IsNullOrEmpty(Request.QueryString["deliveryType"]))
                {
                    deliveryType = SecurityCenter.DecryptText(Request.QueryString["deliveryType"]);
                    if (deliveryType != "OLT")
                    {
                        btnSaveCompletion.OnClientClick = "ConfirmSave();javascript:return TestCheckBox();";
                        try
                        {
                            gvsearchDetails.DataSource = ManageCompletionBLL.GetDeliveryEmployeeOLT(deliveryId);
                            gvsearchDetails.DataBind();
                            if (gvsearchDetails.Rows.Count > 0)
                            {
                                gvsearchDetails.UseAccessibleHeader = true;
                                if (gvsearchDetails.HeaderRow != null)
                                {
                                    //This will tell ASP.NET to render the <thead> for the header row
                                    //using instead of the simple <tr>
                                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                }
                            }
                        }
                    }
                }
                PopulateCourseDelivery();
            }
            if (hdUpdateValue.Value != "0")
            {
                dtselectedOLT = TempDataTables.Employee();
                if (SessionWrapper.TempEmployeelist_delivery.Rows.Count > 0)
                {
                    gvsearchDetails.DataSource = SessionWrapper.TempEmployeelist_delivery;
                    gvsearchDetails.DataBind();
                }
            }
        }
        private void PopulateCourseDelivery()
        {
            SystemCatalog course = new SystemCatalog();

            try
            {
                course = ManageCompletionBLL.GetCourseDelivery(deliveryId);

                gvsearchSession.DataSource = ManageCompletionBLL.SearchDeliverySession(deliveryId);
                gvsearchSession.DataBind();

                foreach (GridViewRow row in gvsearchSession.Rows)
                {
                    CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                    chkSelect.Checked = true;
                }

                c_course_approval = course.c_course_approval_req;
                c_delivery_approval = course.c_delivery_approval_req;

                lblCourseTitle.Text = course.c_course_title + "(" + course.c_course_id_pk + ")";
                lblDescription.Text = course.c_course_desc;
                lblVersion.Text = course.c_course_version;
                lblCost.Text = course.c_course_cost.ToString();
                lblCEU.Text = course.c_course_credit_hours.ToString();
                lblDeliveryTitle.Text = course.c_delivery_id_pk + "(" + course.c_delivery_title + ")";
                lblDeliveryType.Text = course.c_delivery_type_id;
                lblDeliveryDescription.Text = course.c_delivery_desc;
                lblOwner.Text = course.c_course_owner_name;
                lblCoordinator.Text = course.c_course_coordinator_name;
                lblDeliveryOwner.Text = course.c_delivery_owner_name;
                lblDeliveryCoordinator.Text = course.c_delivery_coordinator_name;
                if (gvsearchDetails.Rows.Count > 0)
                {
                    gvsearchDetails.UseAccessibleHeader = true;
                    if (gvsearchDetails.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
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
                    if (deliveryType != "OLT")
                    {
                        DropDownList ddlAttendance = (DropDownList)e.Row.FindControl("ddlAttendanceStatus");
                        ddlAttendance.DataSource = ManageCompletionBLL.GetAttendanceStatus(SessionWrapper.CultureName, "samcsmp-01");
                        ddlAttendance.DataBind();

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string attendenceName = Convert.ToString(drv["t_transcript_attendance_id_fk"]);
                        ddlAttendance.SelectedValue = attendenceName;


                        DropDownList ddlPassingStatus = (DropDownList)e.Row.FindControl("ddlPassignStatus");
                        ddlPassingStatus.DataSource = ManageCompletionBLL.GetPassingStatus(SessionWrapper.CultureName, "samcsmp-01");
                        ddlPassingStatus.DataBind();
                        DataRowView drpassing = (DataRowView)e.Row.DataItem;
                        string passingStatus = Convert.ToString(drpassing["t_transcript_passing_status_id_fk"]);
                        ddlPassingStatus.SelectedValue = passingStatus;

                        DropDownList ddlGrade = (DropDownList)e.Row.FindControl("ddlGrade");
                        ddlGrade.DataSource = ManageCompletionBLL.GetGrade(deliveryId);
                        ddlGrade.DataBind();

                        DataRowView drgrade = (DataRowView)e.Row.DataItem;
                        string grade = Convert.ToString(drpassing["t_transcript_grade_id_fk"]);
                        if (grade != "00000000-0000-0000-0000-000000000000")
                        {
                            ddlGrade.SelectedValue = grade.ToString().Trim();
                        }

                        DataRowView drIssaved = (DataRowView)e.Row.DataItem;
                        bool issaved = Convert.ToBoolean(drIssaved["isSaved"]);
                        if (issaved)
                        {
                            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                            //chkSelect.Visible = false;
                            // e.Row.Cells[8].Visible = false;
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "javascript:rowno(" + e.Row.RowIndex + ");", true); 
                            //e.Row.Attributes.Add("onclick","javascript:rowno(" + e.Row.RowIndex + ")");

                        }
                        Literal ltlButton = (Literal)e.Row.FindControl("ltlButton");
                        if (issaved == true)
                        {
                            ltlButton.Text = "<input id=" + u_user_id_pk + " class='editCompletion cursor_hand' type='button' value='Edit'/>";
                        }
                        else
                        {

                            ltlButton.Text = "<input id=" + u_user_id_pk + " class='deleteUser cursor_hand' type='button' value='Remove' />";
                        }
                    }
                    else
                    {
                        DropDownList ddlAttendance = (DropDownList)e.Row.FindControl("ddlAttendanceStatus");
                        ddlAttendance.DataSource = ManageCompletionBLL.GetAttendanceStatus(SessionWrapper.CultureName, "samcsmp-01");
                        ddlAttendance.DataBind();

                        DropDownList ddlPassingStatus = (DropDownList)e.Row.FindControl("ddlPassignStatus");
                        ddlPassingStatus.DataSource = ManageCompletionBLL.GetPassingStatus(SessionWrapper.CultureName, "samcsmp-01");
                        ddlPassingStatus.DataBind();

                        DropDownList ddlGrade = (DropDownList)e.Row.FindControl("ddlGrade");
                        ddlGrade.DataSource = ManageCompletionBLL.GetGrade(deliveryId);
                        ddlGrade.DataBind();

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string attendenceName = Convert.ToString(drv["t_transcript_attendance_id_fk"]);
                        ddlAttendance.SelectedValue = attendenceName;

                        DataRowView drpassing = (DataRowView)e.Row.DataItem;
                        string passingStatus = Convert.ToString(drpassing["t_transcript_passing_status_id_fk"]);
                        ddlPassingStatus.SelectedValue = passingStatus;

                        DataRowView drgrade = (DataRowView)e.Row.DataItem;
                        string grade = Convert.ToString(drpassing["t_transcript_grade_id_fk"]);
                        if (grade != "00000000-0000-0000-0000-000000000000")
                        {
                            ddlGrade.SelectedValue = grade;
                        }

                        DataRowView drIssaved = (DataRowView)e.Row.DataItem;
                        bool issaved = Convert.ToBoolean(drIssaved["isSaved"]);
                        if (issaved)
                        {
                            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                            e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                            e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                        }

                        //e.Row.Cells[8].Visible = false;
                        //gvsearchDetails.Columns[8].ShowHeader = false;
                        gvsearchDetails.Columns[8].Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                        }
                    }
                }

            }
        }

        protected void btnSaveCompletion_Click(object sender, EventArgs e)
        {
            SessionWrapper.selecteduserId_OLT = null;
            foreach (GridViewRow row in gvsearchDetails.Rows)
            {
                SystemTranscripts transcripts = new SystemTranscripts();
                string u_user_id_pk = gvsearchDetails.DataKeys[row.RowIndex][0].ToString();
                string t_transcript_id_pk = gvsearchDetails.DataKeys[row.RowIndex][1].ToString();
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                string passingStatus = string.Empty;
                string grade = string.Empty;
                int score = 0;
                if (chkSelect.Checked == true)
                {
                    SessionWrapper.selecteduserId_OLT = SessionWrapper.selecteduserId_OLT + "'" + u_user_id_pk + "',";
                    DropDownList ddlAttendance = (DropDownList)row.FindControl("ddlAttendanceStatus");
                    DropDownList ddlPassingStatus = (DropDownList)row.FindControl("ddlPassignStatus");
                    DropDownList ddlGrade = (DropDownList)row.FindControl("ddlGrade");
                    TextBox txtscore = (TextBox)row.FindControl("txtScore");
                    if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                    {
                        //do calculation and change the Passing status Grading Scheme
                        Decimal scoreValue = Convert.ToDecimal(txtscore.Text);
                        score = Convert.ToInt32(scoreValue);
                        SystemGradingSchemes gradevalues = new SystemGradingSchemes();
                        gradevalues = ManageCompletionBLL.GetGradeByScore(deliveryId, score);
                        if (!string.IsNullOrEmpty(gradevalues.s_grading_scheme_value_pass_status_id_fk))
                        {
                            if (gradevalues.s_grading_scheme_value_pass_status_id_fk == "app_ddl_pass_text")
                            {
                                passingStatus = "app_ddl_passed_text";
                            }
                            else
                            {
                                passingStatus = "app_ddl_failed_text";
                            }
                            grade = gradevalues.s_grading_scheme_system_value_id_pk;
                        }
                        else
                        {
                            passingStatus = ddlPassingStatus.SelectedValue;
                            grade = ddlGrade.SelectedValue;
                        }
                    }
                    else
                    {
                        passingStatus = ddlPassingStatus.SelectedValue;
                        grade = ddlGrade.SelectedValue;
                    }

                    //update Active in Enrollment 

                    //to get the enroll id of the enrollment table
                    Enrollment enroll = new Enrollment();
                    enroll = ManageCompletionBLL.GetEnrollmentId(u_user_id_pk, courseId, deliveryId);

                    //check it is already inserted or not

                    DataTable dtInsertedRecords = ManageCompletionBLL.GetInsertedRecords(courseId, deliveryId, u_user_id_pk, t_transcript_id_pk);
                    if (dtInsertedRecords.Rows.Count > 0)
                    {
                        SystemTranscripts updateTranscripts = new SystemTranscripts();
                        //Add t_transcript_id_pk
                        updateTranscripts.t_transcript_user_id_fk = u_user_id_pk;
                        updateTranscripts.t_transcript_course_id_fk = courseId;
                        updateTranscripts.t_transcript_delivery_id_fk = deliveryId;
                        updateTranscripts.t_transcript_attendance_id_fk = ddlAttendance.SelectedValue;
                        updateTranscripts.t_transcript_passing_status_id_fk = passingStatus;
                        updateTranscripts.t_transcript_grade_id_fk = grade;
                        if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                        {
                            updateTranscripts.t_transcript_completion_score = score;
                        }
                        else
                        {
                            updateTranscripts.t_transcript_completion_score = 0;
                        }

                        try
                        {
                            int updateResult = ManageCompletionBLL.UpdateTranscriptsandSession(updateTranscripts);
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                }
                            }
                        }
                        UpdateCurriculumPercentage(courseId, u_user_id_pk);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(enroll.e_enroll_system_id_pk))
                        {
                            transcripts.t_transcript_id_pk = Guid.NewGuid().ToString();
                            transcripts.t_transcript_user_id_fk = u_user_id_pk;

                            transcripts.t_transcript_course_id_fk = courseId;
                            transcripts.t_transcript_delivery_id_fk = deliveryId;
                            transcripts.t_transcript_assign_id_fk = string.Empty;
                            transcripts.t_transcript_enroll_id_fk = string.Empty;

                            transcripts.t_transcript_attendance_id_fk = ddlAttendance.SelectedValue;
                            transcripts.t_transcript_passing_status_id_fk = passingStatus;
                            transcripts.t_transcript_grade_id_fk = grade;
                            if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                            {
                                transcripts.t_transcript_completion_score = score;
                            }
                            else
                            {
                                transcripts.t_transcript_completion_score = 0;
                            }
                            transcripts.t_transcript_completion_date_time = DateTime.UtcNow;
                            transcripts.t_transcript_completion_type_id_fk = "app_ddl_manual_user_mark_completion_text";//doubt
                            transcripts.t_transcript_marked_by_user_id_fk = SessionWrapper.u_userid;
                            transcripts.t_transcript_required_flag = true;
                            transcripts.t_transcript_target_due_date = DateTime.Now; //Target date
                            transcripts.t_transcript_actual_date = DateTime.Now; //Actual date  
                            transcripts.t_transcript_status_name = "Completed";//doubt //enroll.e_enroll_status_id_fk;
                            transcripts.t_transcript_time_spent = 0;
                            transcripts.t_transcript_score = score;
                            transcripts.t_transcript_credits = 0;
                            transcripts.t_transcript_hours = 0;
                            transcripts.t_transcript_active_flag = true;
                            try
                            {
                                int result = ManageCompletionBLL.InsertTranscripts(transcripts);
                                if (result == 0)
                                {
                                    DataTable dt = ManageCompletionBLL.GetWaitlistCourses(courseId, deliveryId, u_user_id_pk);
                                    if (dt.Rows.Count > 0)
                                    {
                                        SendClosedMailToUser(dt);
                                    }
                                }


                            }
                            catch (Exception ex)
                            {
                                if (ConfigurationWrapper.LogErrors == true)
                                {
                                    if (ex.InnerException != null)
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                    }
                                    else
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                    }
                                }
                            }

                            if (deliveryType != "OLT")
                            {
                                //insert the t_tb_session_transcripts table
                                InsertSessionTranscripts(u_user_id_pk, ddlAttendance.SelectedValue, passingStatus, grade, txtscore.Text);
                            }
                            UpdateCurriculumPercentage(courseId, u_user_id_pk);
                        }
                        else
                        {
                            //Insert Transcripts table
                            transcripts.t_transcript_id_pk = Guid.NewGuid().ToString();
                            transcripts.t_transcript_user_id_fk = u_user_id_pk;

                            transcripts.t_transcript_course_id_fk = courseId;
                            transcripts.t_transcript_delivery_id_fk = deliveryId;
                            transcripts.t_transcript_assign_id_fk = string.Empty;
                            transcripts.t_transcript_enroll_id_fk = enroll.e_enroll_system_id_pk;

                            transcripts.t_transcript_attendance_id_fk = ddlAttendance.SelectedValue;
                            transcripts.t_transcript_passing_status_id_fk = passingStatus;
                            transcripts.t_transcript_grade_id_fk = grade;
                            if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                            {
                                transcripts.t_transcript_completion_score = Convert.ToInt32(txtscore.Text);
                            }
                            else
                            {
                                transcripts.t_transcript_completion_score = 0;
                            }
                            transcripts.t_transcript_completion_date_time = DateTime.UtcNow;
                            transcripts.t_transcript_completion_type_id_fk = "app_ddl_manual_user_mark_completion_text";//doubt
                            transcripts.t_transcript_marked_by_user_id_fk = SessionWrapper.u_userid;
                            transcripts.t_transcript_required_flag = true;
                            transcripts.t_transcript_target_due_date = DateTime.Now; //Target date
                            transcripts.t_transcript_actual_date = DateTime.Now; //Actual date  
                            transcripts.t_transcript_status_name = "Completed";//doubt //enroll.e_enroll_status_id_fk;
                            transcripts.t_transcript_time_spent = 0;
                            transcripts.t_transcript_score = score;
                            transcripts.t_transcript_credits = 0;
                            transcripts.t_transcript_hours = 0;
                            transcripts.t_transcript_active_flag = true;
                            try
                            {
                                int result = ManageCompletionBLL.InsertTranscripts(transcripts);
                                if (result == 0)
                                {
                                    DataTable dt = ManageCompletionBLL.GetWaitlistCourses(courseId, deliveryId, u_user_id_pk);
                                    if (dt.Rows.Count > 0)
                                    {
                                        SendClosedMailToUser(dt);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ConfigurationWrapper.LogErrors == true)
                                {
                                    if (ex.InnerException != null)
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                    }
                                    else
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                    }
                                }
                            }
                            if (deliveryType != "OLT")
                            {
                                //insert the t_tb_session_transcripts table
                                InsertSessionTranscripts(u_user_id_pk, ddlAttendance.SelectedValue, passingStatus, grade, txtscore.Text);
                            }
                            //update enrollment table 
                            try
                            {
                                int updateresult = ManageCompletionBLL.UpdateEnrollment(u_user_id_pk, courseId, deliveryId, transcripts.t_transcript_id_pk);
                            }
                            catch (Exception ex)
                            {
                                if (ConfigurationWrapper.LogErrors == true)
                                {
                                    if (ex.InnerException != null)
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                    }
                                    else
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                    }
                                }
                            }

                            //insert audit log table

                            string strIPAddress = string.Empty;
                            strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (strIPAddress == "" || strIPAddress == null)
                                strIPAddress = Request.ServerVariables["REMOTE_ADDR"];

                            Auditlog auditlog = new Auditlog();
                            auditlog.Guid = Guid.NewGuid().ToString();
                            auditlog.Auditid = Guid.NewGuid().ToString();
                            auditlog.Userid = SessionWrapper.u_userid;
                            auditlog.user_type = SessionWrapper.u_user_type;
                            auditlog.user_detail = SessionWrapper.u_lastname + ' ' + SessionWrapper.u_firstname + ' ' + SessionWrapper.u_middlename;
                            auditlog.action_desc = "Marked Completion";
                            auditlog.a_values = "Completed," + ddlAttendance.SelectedItem.Text + ", " + ddlPassingStatus.SelectedItem.Text + ",";//ddlGrade
                            //auditlog.u_datetime = DateTime.Now;
                            auditlog.ipaddress = strIPAddress;
                            auditlog.device = Request.UserAgent;

                            try
                            {
                                ManageCompletionBLL.InsertAudit(auditlog);
                            }
                            catch (Exception ex)
                            {
                                if (ConfigurationWrapper.LogErrors == true)
                                {
                                    if (ex.InnerException != null)
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                    }
                                    else
                                    {
                                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                    }
                                }
                            }

                            //Due date calculation and insert values to enrollment and course assign table
                            //check if course have recurrence date then calculate the next due date and 
                            //insert new record in enrollment table as enrolled 
                            DateTime duedate = new DateTime();
                            duedate = CheckCourseHasRecurrence(courseId);
                            if (duedate != DateTime.MinValue)
                            {
                                if (deliveryType != "OLT")
                                {
                                    Enrollment assign = new Enrollment();
                                    assign.e_course_assign_user_id_fk = u_user_id_pk;
                                    assign.e_course_assign_course_id_fk = courseId;
                                    assign.e_course_assign_type_id_fk = "System Completion Assign";
                                    assign.e_course_assign_by_id_fk = SessionWrapper.u_userid;
                                    assign.e_course_assign_required_flag = true;
                                    DateTime? targetDueDate = null;
                                    //DateTime tempTargetDueDate;
                                    //if (DateTime.TryParse(txtTargetDueDate.Text, out tempTargetDueDate))
                                    //{
                                    targetDueDate = duedate;
                                    //}
                                    DateTime? recertDueDate = duedate;
                                    assign.e_course_assign_target_due_date = targetDueDate;
                                    assign.e_course_assign_recert_due_date = recertDueDate;
                                    //assign.e_course_assign_percent_complete = 0;
                                    assign.e_course_assign_active_flag = true;

                                    try
                                    {
                                        ManageCompletionBLL.AssignCourse(assign);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ConfigurationWrapper.LogErrors == true)
                                        {
                                            if (ex.InnerException != null)
                                            {
                                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                            }
                                            else
                                            {
                                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    Enrollment enrollOLT = new Enrollment();
                                    //enrollOLT.e_check_course_approval = true;//Check yhe current course id is approval required
                                    //enrollOLT.e_check_delivery_approval = true;//Check yhe current delivery id is approval required
                                    enrollOLT.e_enroll_user_id_fk = u_user_id_pk;
                                    enrollOLT.e_enroll_delivery_id_fk = deliveryId;
                                    enrollOLT.e_enroll_course_id_fk = courseId;
                                    enrollOLT.e_enroll_required_flag = enroll.e_enroll_required_flag;
                                    //enrollOLT.e_enroll_approval_required_flag = false;
                                    enrollOLT.e_enroll_type_name = "System Completion Assign";
                                    //enrollOLT.e_enroll_approval_status_name = "Pending";
                                    enrollOLT.e_enroll_status_name = "Enrolled";
                                    enrollOLT.e_enroll_target_due_date = duedate;
                                    try
                                    {
                                        ManageCompletionBLL.SingleEnroll(enrollOLT);//analyse the reason of false
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ConfigurationWrapper.LogErrors == true)
                                        {
                                            if (ex.InnerException != null)
                                            {
                                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                                            }
                                            else
                                            {
                                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                                            }
                                        }
                                    }
                                }
                            }

                            //Check the course is present in the curriculum master table if it present then 
                            //update the curriculum status.
                            // The Number of Completed Courses divided by
                            //Number of Required Courses (for each path if there are more than 1 and then take
                            //the lowest %).

                            //
                            //Update Curriculum Percentage
                            UpdateCurriculumPercentage(courseId, u_user_id_pk);
                        }
                    }
                    string employeeNumber;
                    string lastName;
                    if (string.IsNullOrWhiteSpace(row.Cells[3].Text) || row.Cells[3].Text.Contains("&nbsp;"))
                    {
                        employeeNumber = string.Empty;
                    }
                    else
                    {
                        employeeNumber = row.Cells[3].Text;
                    }
                    if (string.IsNullOrWhiteSpace(row.Cells[1].Text) || row.Cells[1].Text.Contains("&nbsp;"))
                    {
                        lastName = string.Empty;
                    }
                    else
                    {
                        lastName = row.Cells[1].Text;
                    }
                    AddDataToEmployee(u_user_id_pk, row.Cells[2].Text, lastName, employeeNumber, ddlAttendance.SelectedValue, passingStatus, grade, "true", transcripts.t_transcript_id_pk, dtselectedOLT);

                }
                Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryType=" + SecurityCenter.EncryptText(deliveryType) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
        }
        private void InsertSessionTranscripts(string u_user_id_pk, string attendence, string passingstatus, string grade, string score)
        {
            //string statustypeId = UpdateCurriculumStatusesBLL.GetStatusTypeId("User Manual Change");
            foreach (GridViewRow row in gvsearchSession.Rows)
            {
                string s_session_id_pk = gvsearchSession.DataKeys[row.RowIndex][0].ToString();
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {

                    //Insert to Session transcripts table
                    SystemTranscripts sessiontranscripts = new SystemTranscripts();
                    sessiontranscripts.t_transcript_session_id_fk = s_session_id_pk;
                    sessiontranscripts.t_transcript_id_pk = Guid.NewGuid().ToString();
                    sessiontranscripts.t_transcript_session_user_id_fk = u_user_id_pk;
                    sessiontranscripts.t_transcript_sessiont_course_id_fk = courseId;
                    sessiontranscripts.t_transcript_session_delivery_id_fk = deliveryId;
                    sessiontranscripts.t_transcript_session_roster_id_fk = string.Empty;
                    sessiontranscripts.t_transcript_session_attendance_id_fk = attendence;
                    sessiontranscripts.t_transcript_session_passing_status_id_fk = passingstatus;
                    sessiontranscripts.t_transcript_session_grade_id_fk = grade;
                    if (!string.IsNullOrEmpty(score))
                    {
                        sessiontranscripts.t_transcript_session_completion_score = Convert.ToInt32(score);
                    }
                    else
                    {
                        sessiontranscripts.t_transcript_session_completion_score = 0;
                    }
                    sessiontranscripts.t_transcript_session_completion_date_time = DateTime.UtcNow;
                    sessiontranscripts.t_transcript_session_completion_type_id_fk = "app_ddl_manual_user_mark_completion_text";//Doubt 
                    sessiontranscripts.t_transcript_session_marked_by_user_id_fk = SessionWrapper.u_userid;
                    sessiontranscripts.t_transcript_session_actual_date = DateTime.UtcNow;
                    sessiontranscripts.t_transcript_status_name = "Completed";//Doubt
                    sessiontranscripts.t_transcript_session_active_flag = true;

                    try
                    {
                        int result = ManageCompletionBLL.InsertSessionTranscripts(sessiontranscripts);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                            }
                        }
                    }

                }

            }
        }

        protected void gvsearchSession_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string c_session_system_id_pk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();

                if (deliveryType == "OLT")
                {
                    CheckBox chkselect = (CheckBox)e.Row.FindControl("chkSelect");
                    Label lblSessionStartDate = (Label)e.Row.FindControl("lblSessionStartDate");
                    Label lblSessionEndDate = (Label)e.Row.FindControl("lblSessionEndDate");
                    Label lblSessionLocation = (Label)e.Row.FindControl("lblSessionLocation");
                    Label lblRoomName = (Label)e.Row.FindControl("lblRoomName");

                    lblSessionStartDate.Visible = false;
                    lblSessionEndDate.Visible = false;
                    lblSessionLocation.Visible = false;
                    lblRoomName.Visible = false;
                    chkselect.Visible = false;
                }
            }

        }

        private DateTime CheckCourseHasRecurrence(string courseId)
        {
            string duedate = string.Empty;
            DateTime new_nextduedate = new DateTime();
            DateTime dtrecurancedate = new DateTime();
            int? every = 0;
            string period = string.Empty;
            string dateoption = string.Empty;
            int? graysdays = 0;

            try
            {
                SystemCatalog course = SystemCatalogBLL.GetCourse(courseId, SessionWrapper.CultureName);
                every = course.c_course_recurrence_every;
                period = course.c_course_recurrence_period;
                dateoption = course.c_course_recurrence_date_option;

                graysdays = course.c_course_recurrence_grace_days;
                if (course.c_course_recurrence_date != null)
                {
                    dtrecurancedate = Convert.ToDateTime(course.c_course_recurrence_date);
                }

                if (every > 0 && !string.IsNullOrEmpty(period) && !string.IsNullOrEmpty(dateoption) && dtrecurancedate != DateTime.MinValue)
                {
                    if (dateoption == "fixed")
                    {
                        if (period == "years")
                        {
                            new_nextduedate = dtrecurancedate.AddYears(Convert.ToInt16(every));
                        }
                        else if (period == "months")
                        {
                            new_nextduedate = dtrecurancedate.AddMonths(Convert.ToInt16(every));
                        }
                        else
                        {
                            new_nextduedate.AddDays(Convert.ToInt16(every));
                        }
                    }
                    else if (dateoption == "Hire Date")
                    {
                        new_nextduedate.AddYears(1);
                    }
                    else if (dateoption == "Assignment Date")
                    {
                        new_nextduedate.AddYears(1);
                    }
                    else
                    {
                        new_nextduedate.AddYears(1);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                    }
                }
            }

            return new_nextduedate;
        }

        private DataTable CheckCourseInCurriculum(string courseId, string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ManageCompletionBLL.GetCurriculumByCourse(courseId, userId);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                    }
                }
            }
            return dt;
        }

        [System.Web.Services.WebMethod]
        public static void DeleteUserDetails(string args, string args2, string args3)
        {
            //update the enrollment table to inactive= false
            try
            {
                int result = ManageCompletionBLL.UpdateEnrollmentActive(args, args2, args3);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                    }
                }
            }
        }

        private void UpdateCurriculumPercentage(string courseId, string UserId)
        {
            DataTable IsCuuriculum = CheckCourseInCurriculum(courseId, UserId);

            if (IsCuuriculum.Rows.Count > 0)
            {
                for (int i = 0; i < IsCuuriculum.Rows.Count; i++)
                {
                    string curriculumId = IsCuuriculum.Rows[i]["c_curricula_id_fk"].ToString();
                    try
                    {
                        int result = ManageCompletionBLL.UpdateCurriculumPercentage(curriculumId, UserId);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
                            }
                        }
                    }
                }
            }
        }

        //protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int rowIndex = int.Parse(e.CommandArgument.ToString());
        //    string user_id = gvsearchDetails.DataKeys[rowIndex].Values[0].ToString();
        //    if (e.CommandName.Equals("Edit"))
        //    {
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "javascript:EditandRemove(" + user_id + "," + "Edit" + " );", true);
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "javascript:rowno(" + rowIndex + " );", true); 
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "javascript:rowno(" + user_id + " );", true); 
        //    }
        //    else if (e.CommandName.Equals("Remove"))
        //    {
        //        try
        //        {
        //            int result = ManageCompletionBLL.UpdateEnrollmentActive(user_id, courseId, deliveryId);
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ConfigurationWrapper.LogErrors == true)
        //            {
        //                if (ex.InnerException != null)
        //                {
        //                    Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message, ex.InnerException.Message);
        //                }
        //                else
        //                {
        //                    Logger.WriteToErrorLog("samcmcp-01.aspx", ex.Message);
        //                }
        //            }
        //        }
        //    }
        //}

        //protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        //{

        //}
        //public string getButtonText()
        //{
        //    return "Edit";
        //}

        private void AddDataToEmployee(string u_user_id_pk, string firstName, string lastName, string employeeId, string attendence, string passingstatus, string grade, string issaved, string transcriptid, DataTable dtTempEmployee)
        {
            DataRow row;
            row = dtTempEmployee.NewRow();
            row["u_user_id_pk"] = u_user_id_pk;
            row["u_first_name"] = firstName;
            row["u_last_name"] = lastName;
            row["u_hris_employee_id"] = employeeId;
            row["t_transcript_attendance_id_fk"] = attendence;
            row["t_transcript_passing_status_id_fk"] = passingstatus;
            row["t_transcript_grade_id_fk"] = grade;
            row["isSaved"] = Convert.ToBoolean(issaved);
            row["t_transcript_id_pk"] = transcriptid;
            dtTempEmployee.Rows.Add(row);
        }

        private void SendClosedMailToUser(DataTable dtMail)
        {
            SystemNotification notificationWailtlist = new SystemNotification();
            notificationWailtlist = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-WAITLIST-DROPPED", SessionWrapper.CultureName);
            if (notificationWailtlist.s_notification_on_off_flag == true)
            {
                for (int i = 0; i < dtMail.Rows.Count; i++)
                {
                    try
                    {
                        StringBuilder sbEnrolledWarning = new StringBuilder();

                        string warningrSubjectMananger = string.Empty;
                        warningrSubjectMananger = notificationWailtlist.s_notification_email_subject;
                        warningrSubjectMananger = warningrSubjectMananger.Replace("@$&Course Name&$@", dtMail.Rows[i]["courseName"].ToString());
                        //warningrSubjectMananger = warningrSubjectMananger.Replace("@$&User First Name&$@", dtMail.Rows[i]["u_first_name"].ToString());

                        string EnrollTextManager = string.Empty;
                        EnrollTextManager = notificationWailtlist.s_notification_email_text;
                        EnrollTextManager = EnrollTextManager.Replace("@$&User First Name&$@", dtMail.Rows[i]["u_first_name"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&User Last Name&$@", dtMail.Rows[i]["u_last_name"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&Course Name&$@(@$&Course ID&$@)", dtMail.Rows[i]["courseName"].ToString());
                        EnrollTextManager = EnrollTextManager.Replace("@$&Delivery Title&$@(@$&Delivery ID&$@)", dtMail.Rows[i]["deliveryName"].ToString());
                        //EnrollTextManager = EnrollTextManager.Replace("@$&Target Due Date&$@", dtMail.Rows[i]["e_curriculum_assign_target_due_date"].ToString());
                        //e_enroll_target_due_date
                        sbEnrolledWarning.Append(EnrollTextManager);

                        string toEmailid = dtMail.Rows[i]["u_email_address"].ToString();
                        string[] toaddress = toEmailid.Split(',');
                        List<MailAddress> mailAddresses = new List<MailAddress>();
                        foreach (string recipient in toaddress)
                        {
                            if (recipient.Trim() != string.Empty)
                            {
                                mailAddresses.Add(new MailAddress(recipient));
                            }
                        }

                        string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                        //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                        if (mailAddresses.Count > 0)
                        {
                            Utility.SendEMailMessages(mailAddresses, fromAddress, warningrSubjectMananger, sbEnrolledWarning.ToString());
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dtMail.Rows[i]["u_mobile_number"].ToString()))
                            {
                                StringBuilder smsText = new StringBuilder();
                                string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                string messagetext = notificationWailtlist.s_notification_SMS_text;
                                //messagetext = messagetext.Replace("", "");
                                //messagetext = messagetext.Replace("", "");
                                if (messagetext.Length > 180)
                                {
                                    messagetext = messagetext.Substring(0, 179);
                                }
                                messagetext = messagetext.Replace("@$&Status&$@", "Waiting Closed");
                                messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", dtMail.Rows[i]["courseName"].ToString());
                                Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("samcmcp-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("samcmcp-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }

        //private void SendClosedMailToUser(DataTable dtMail)
        //{
        //    for (int i = 0; i <= dtMail.Rows.Count; i++)
        //    {
        //        String closeSubject = "***" + dtMail.Rows[i]["courseName"].ToString() + "is now closed";

        //        StringBuilder sbCloseCourse = new StringBuilder();
        //        sbCloseCourse.Append("Hello "+dtMail.Rows[i]["u_first_name"].ToString() + ' ' + dtMail.Rows[i]["u_last_name"].ToString());
        //        sbCloseCourse.Append("<br>");
        //        sbCloseCourse.Append("Course: " + dtMail.Rows[i]["courseName"].ToString());
        //        sbCloseCourse.Append("<br>");
        //        sbCloseCourse.Append("Delivery: " +  dtMail.Rows[i]["deliveryName"].ToString());
        //        sbCloseCourse.Append("<br>");
        //        sbCloseCourse.Append("has been closed.");
        //        sbCloseCourse.Append("<br>");

        //        sbCloseCourse.Append("<br>");
        //        string toEmailid = dtMail.Rows[i]["u_email_address"].ToString(); 
        //        string[] toaddress = toEmailid.Split(',');
        //        List<MailAddress> mailAddresses = new List<MailAddress>();
        //        foreach (string recipient in toaddress)
        //        {
        //            if (recipient.Trim() != string.Empty)
        //            {
        //                mailAddresses.Add(new MailAddress(recipient));
        //            }
        //        }
        //        string fromAddress = SessionWrapper.u_email_id;// for submite Request from: employeeemailId to admin@compliancefactors.com,owneremailId,coordinatoremailId 
        //        //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
        //        Utility.SendEMailMessages(mailAddresses, fromAddress, closeSubject, sbCloseCourse.ToString());
        //    }
        //}

    }
}