using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Text;
using System.Configuration;
using System.Net.Mail;

namespace ComplicanceFactor.SystemHome.Users.ManageCourse.Popup
{
    public partial class p_cmcp_01 : System.Web.UI.Page
    {
        private static string courseId;
        private static string deliveryId;
        private static string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                deliveryId = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["courseid"]))
                {
                    courseId = Request.QueryString["courseid"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["deliveryid"]))
                {
                    deliveryId = Request.QueryString["deliveryid"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    userId = Request.QueryString["userid"];
                }

                BindCourse();
            }
        }
        /// <summary>
        /// Bind Course
        /// </summary>
        private void BindCourse()
        {
            try
            {
                gvCatalog.DataSource = SystemMassCompletionBLL.GetCourseDetails(courseId);
                gvCatalog.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void gvCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string courseId = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                try
                {
                    if (string.IsNullOrEmpty(deliveryId))
                    {
                        DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                        ddlDelivery.Style.Add("display", "inline");
                        ddlDelivery.DataSource = SystemMassCompletionBLL.GetDelivery(courseId);
                        ddlDelivery.DataBind();
                        ListItem liFirstItem = new ListItem();
                        liFirstItem.Text = "Select a Delivery";
                        ///liFirstItem.Value = "0";
                        ddlDelivery.Items.Insert(0, liFirstItem);
                        ddlDelivery.SelectedIndex = 0;
                    }
                    else
                    {
                        BindCompletionDetails();
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }
        protected void ddlDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCurrentDropDownList = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCurrentDropDownList.Parent.Parent;
            deliveryId = ddlCurrentDropDownList.SelectedValue;

            BindCompletionDetails();
        }

        /// <summary>
        /// Bind Completion Details 
        /// </summary>
        private void BindCompletionDetails()
        {
            try
            {
                ddlGrade.DataSource = ManageCompletionBLL.GetGrade(deliveryId);
                ddlGrade.DataBind();

                ddlAttendanceStatus.DataSource = ManageCompletionBLL.GetAttendanceStatus(SessionWrapper.CultureName, "samcsmp-01");
                ddlAttendanceStatus.DataBind();

                ddlPassignStatus.DataSource = ManageCompletionBLL.GetPassingStatus(SessionWrapper.CultureName, "samcsmp-01");
                ddlPassignStatus.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnMarkCompletion_Click(object sender, EventArgs e)
        {
            DataTable dtCompletionStatus = TempCourseCompletionDatatable();
            string deliveryType = string.Empty;
            string passingStatus = string.Empty;
            string grade = string.Empty;
            int score = 0;
            if (!string.IsNullOrEmpty(txtScore.Text) && !string.IsNullOrWhiteSpace(txtScore.Text))
            {
                //do calculation and change the Passing status Grading Scheme
                Decimal scoreValue = Convert.ToDecimal(txtScore.Text);
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
                    passingStatus = ddlPassignStatus.SelectedValue;
                    grade = ddlGrade.SelectedValue;
                }
            }
            else
            {
                passingStatus = ddlPassignStatus.SelectedValue;
                grade = ddlGrade.SelectedValue;
            }
            deliveryType = SystemWaitListBLL.GetDeliveryType(deliveryId);

            DataRow courserow;
            courserow = dtCompletionStatus.NewRow();
            courserow["c_course_id_pk"] = courseId;
            courserow["c_delivery_id_pk"] = deliveryId;
            courserow["u_user_id_pk"] = userId;
            courserow["delivery_type"] = deliveryType;
            courserow["t_transcript_attendance_id_fk"] = ddlAttendanceStatus.SelectedValue;
            courserow["t_transcript_passing_status_id_fk"] = ddlPassignStatus.SelectedValue;
            courserow["t_transcript_grade_id_fk"] = ddlGrade.SelectedValue;
            courserow["t_transcript_completion_score"] = txtScore.Text;
            if (!string.IsNullOrEmpty(txtCompletionDate.Text))
            {
                courserow["t_transcript_completion_date_time"] = txtCompletionDate.Text;
            }
            else
            {
                courserow["t_transcript_completion_date_time"] = DateTime.Now;
            }
            courserow["attendance_value"] = ddlAttendanceStatus.SelectedItem.Text;
            courserow["passsingstatusValue"] = ddlPassignStatus.SelectedItem.Text;
            courserow["gradeValue"] = ddlGrade.SelectedItem.Text;
            dtCompletionStatus.Rows.Add(courserow);

            SystemTranscripts transcripts = new SystemTranscripts();
            transcripts.t_transcript_id_pk = Guid.NewGuid().ToString();
            transcripts.t_transcript_assign_id_fk = string.Empty;
            transcripts.t_transcript_enroll_id_fk = string.Empty;
            transcripts.t_transcript_completion_date_time = DateTime.UtcNow;
            transcripts.t_transcript_completion_type_id_fk = "app_ddl_manual_user_mark_completion_text";//doubt
            transcripts.t_transcript_marked_by_user_id_fk = SessionWrapper.u_userid;
            transcripts.t_transcript_required_flag = true;
            transcripts.t_transcript_target_due_date = DateTime.Now; //Target date
            transcripts.t_transcript_actual_date = DateTime.Now; //Actual date  
            transcripts.t_transcript_status_name = "Completed";
            transcripts.t_transcript_time_spent = 0;
            transcripts.t_transcript_score = 0;
            transcripts.t_transcript_credits = 0;
            transcripts.t_transcript_hours = 0;
            transcripts.t_transcript_active_flag = true;
            transcripts.mass_completion = ConvertDataTableToXml(dtCompletionStatus);
            //Audit Log
            string strIPAddress = string.Empty;
            strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIPAddress == "" || strIPAddress == null)
                strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            transcripts.Userid = SessionWrapper.u_userid;
            transcripts.user_type = SessionWrapper.u_user_type;
            transcripts.user_detail = SessionWrapper.u_lastname + ' ' + SessionWrapper.u_firstname + ' ' + SessionWrapper.u_middlename;
            transcripts.action_desc = "Marked Completion";
            transcripts.ipaddress = strIPAddress;
            transcripts.device = Request.UserAgent;

            try
            {
                DataSet ds = SystemMassCompletionBLL.MassCompletion(transcripts);
                if (ds.Tables.Count > 0)
                {
                    deliveryId = string.Empty;
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Courses Completed Successfully";
                }
                if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                {
                    deliveryId = string.Empty;
                    SendClosedMailToUser(ds.Tables[ds.Tables.Count - 1]);
                }
                
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-cmcp-01.aspx", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Convert DataTable to Xml
        /// </summary>
        /// <param name="dtBuildSql"></param>
        /// <returns></returns>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }


        /// <summary>
        /// Completion Status Temparory Datatable
        /// </summary>
        /// <returns></returns>
        private DataTable TempCourseCompletionDatatable()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "c_course_id_pk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "c_delivery_id_pk";
            dt.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "u_user_id_pk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "delivery_type";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_attendance_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_passing_status_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_grade_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_completion_score";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_completion_date_time";
            dt.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "attendance_value";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "passsingstatusValue";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "gradeValue";
            dt.Columns.Add(dtColumn);

            return dt;
        }
        /// <summary>
        /// Send Closed Mail to user
        /// </summary>
        /// <param name="dtMail"></param>
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
                                Logger.WriteToErrorLog("p-cmcp-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("p-cmcp-01", ex.Message);
                            }
                        }
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}