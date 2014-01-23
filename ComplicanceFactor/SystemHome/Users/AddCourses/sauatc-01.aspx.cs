using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Net.Mail;


namespace ComplicanceFactor.SystemHome.Users.AddCourses
{
    public partial class sauatc_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.Enrollment_courses_from_user = TempDataTables.TempEnrollmentCourseCurriculum();
            }
            if (SessionWrapper.Enrollment_courses_from_user.Rows.Count > 0 && (hdCheckdelivery.Value != "1" || string.IsNullOrEmpty(hdCheckdelivery.Value)))
            {
                gvCatalog.DataSource = SessionWrapper.Enrollment_courses_from_user;
                gvCatalog.DataBind();
                hdCheckdelivery.Value = "1";
            }
        }
        protected void gvCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sysId = DataBinder.Eval(e.Row.DataItem, "sysId").ToString();
                string type = DataBinder.Eval(e.Row.DataItem, "type").ToString();
                CheckBox chkSelectDelivery = (CheckBox)e.Row.FindControl("chkSelectDelivery");
                DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                //Button btnViewDetails = (Button)e.Row.FindControl("btnViewDetails");
                Literal ltlViewDetails = (Literal)e.Row.FindControl("ltlViewDetails");
                if (type == "Course")
                {
                    chkSelectDelivery.Style.Add("display", "inline");
                    ddlDelivery.Style.Add("display", "inline");
                    //btnViewDetails.Style.Add("display", "none");
                }
                try
                {
                    ddlDelivery.DataSource = SystemMassCompletionBLL.GetDelivery(sysId);
                    ddlDelivery.DataBind();
                    ListItem liFirstItem = new ListItem();
                    liFirstItem.Text = "Select a Delivery";
                    //liFirstItem.Text = LocalResources.GetGlobalLabel("app_select_a_delivery_text");

                    ///liFirstItem.Value = "0";
                    ddlDelivery.Items.Insert(0, liFirstItem);
                    ddlDelivery.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sauatc-01 (Remove Course)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sauatc-01 (Remove Course)", ex.Message);
                        }
                    }
                }
            }
        }

        //Delete courseCurriculum
        [System.Web.Services.WebMethod]
        public static void DeleteCourse(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.Enrollment_courses_from_user.Select("sysId= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Enrollment_courses_from_user.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sauatc-01 (Remove Course)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sauatc-01 (Remove Course)", ex.Message);
                    }
                }
            }
        }
        protected void btnProcessMassEnrollment_Click(object sender, EventArgs e)
        {

            EnrollCourse();
            if (SessionWrapper.Enrollment_courses_from_user.Rows.Count > 0)
            {//Enrollment_courses_curriculum
                divSuccess.Style.Add("display", "block");
                divSuccess.InnerText = LocalResources.GetText("app_succ_processed_text");
            }
        }

        private DataTable TempCourseEnrollDatatable()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "course_id";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "type";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "deliveryID";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "checked";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "employeeID";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "required";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "DueDate";
            dt.Columns.Add(dtColumn);

            return dt;
        }

        private DataTable TempCourseAssignDatatable()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "course_id";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "type";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "checked";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "employeeID";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "required";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "DueDate";
            dt.Columns.Add(dtColumn);

            return dt;
        }
        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }

        private void EnrollCourse()
        {
            DataTable dtCourseEnroll = TempCourseEnrollDatatable();
            DataTable dtCourseAssign = TempCourseAssignDatatable();

            for (int i = 0; i < SessionWrapper.Enrollment_courses_from_user.Rows.Count; i++)
            {
                CheckBox chkSelectDelivery = (CheckBox)gvCatalog.Rows[i].FindControl("chkSelectDelivery");
                DropDownList ddlDelivery = (DropDownList)gvCatalog.Rows[i].FindControl("ddlDelivery");


                if (SessionWrapper.Enrollment_courses_from_user.Rows[i]["type"].ToString() == "Course" && chkSelectDelivery.Checked == true)
                {
                    DataRow courserow;
                    courserow = dtCourseEnroll.NewRow();
                    courserow["course_id"] = SessionWrapper.Enrollment_courses_from_user.Rows[i]["sysId"].ToString();
                    courserow["deliveryID"] = ddlDelivery.SelectedValue;
                    courserow["checked"] = chkSelectDelivery.Checked;
                    courserow["employeeID"] = Request.QueryString["userId"];
                    courserow["required"] = chkRequired.Checked;
                    courserow["DueDate"] = TryParse(txtTargetDueDate.Text);
                    dtCourseEnroll.Rows.Add(courserow);
                }
                else if (SessionWrapper.Enrollment_courses_from_user.Rows[i]["type"].ToString() == "Course" && chkSelectDelivery.Checked == false)
                {
                    DataRow courserow;
                    courserow = dtCourseAssign.NewRow();
                    courserow["course_id"] = SessionWrapper.Enrollment_courses_from_user.Rows[i]["sysId"].ToString();
                    courserow["checked"] = chkSelectDelivery.Checked;
                    courserow["employeeID"] = Request.QueryString["userId"];
                    courserow["required"] = chkRequired.Checked;
                    courserow["DueDate"] = TryParse(txtTargetDueDate.Text);
                    dtCourseAssign.Rows.Add(courserow);
                }

            }
            ConvertDataTables ConvertToXml = new ConvertDataTables();

            DataTable dtSingleOLTCourseFromCurriculum = SystemMassEnrollmentBLL.Course_Enroll_Assign(ConvertToXml.ConvertDataTableToXml(dtCourseEnroll), ConvertToXml.ConvertDataTableToXml(dtCourseAssign), SessionWrapper.u_userid);
            SystemCatalog Course = new SystemCatalog();
            User edituser = new User();
            StringBuilder sbConfirmEnrollment = new StringBuilder();
            if (dtSingleOLTCourseFromCurriculum.Rows.Count > 0)
            {
                for (int i = 0; i <= dtSingleOLTCourseFromCurriculum.Rows.Count - 1; i++)
                {

                    string curr_deliveryId = dtSingleOLTCourseFromCurriculum.Rows[i]["c_delivery_system_id_pk"].ToString();
                    string curr_employeeId = dtSingleOLTCourseFromCurriculum.Rows[i]["employeeId"].ToString();

                    Course = SystemCatalogBLL.GetSingleDeliveryList(curr_deliveryId);
                    edituser = UserBLL.GetUserInfo_by_id(curr_employeeId);

                    if (Course.c_delivery_type_id == "OLT")
                    {
                        SystemNotification notification = new SystemNotification();
                        notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT", SessionWrapper.CultureName);
                        if (notification.s_notification_on_off_flag == true)
                        {
                            //Enroll OLT
                            string confirmOLTSubject = string.Empty;
                            confirmOLTSubject = notification.s_notification_email_subject;
                            confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                            string sbConfirmOLT = string.Empty;
                            sbConfirmOLT = notification.s_notification_email_text;

                            sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", Course.c_created_name);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                            sbConfirmEnrollment.Clear();


                            List<MailAddress> mailAddresses = new List<MailAddress>();


                            if (!string.IsNullOrEmpty(edituser.EmailId))
                            {
                                Thread threadSendMails;
                                threadSendMails = new Thread(delegate()
                                {
                                    mailAddresses.Add(new MailAddress(edituser.EmailId));
                                    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                                    sbConfirmEnrollment.Append(sbConfirmOLT);
                                    Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
                                });
                                threadSendMails.IsBackground = true;
                                threadSendMails.Start();

                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(edituser.MobileNumber))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = edituser.MobileNumber.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notification.s_notification_SMS_text;
                                    messagetext = messagetext.Replace("", "");


                                    if (messagetext.Length > 180)
                                    {
                                        messagetext = messagetext.Substring(0, 179);
                                    }
                                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
                                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                                }
                            }
                        }
                    }
                }
            }
            if (dtCourseEnroll.Rows.Count > 0)
            {
                for (int j = 0; j <= dtCourseEnroll.Rows.Count - 1; j++)
                {
                    string deliveryId = dtCourseEnroll.Rows[j]["deliveryID"].ToString();
                    string employeeId = dtCourseEnroll.Rows[j]["employeeID"].ToString();
                    Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryId);
                    edituser = UserBLL.GetUserInfo_by_id(employeeId);
                    if (Course.c_delivery_type_id == "OLT")
                    {
                        SystemNotification notification = new SystemNotification();
                        notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT", SessionWrapper.CultureName);
                        if (notification.s_notification_on_off_flag == true)
                        {
                            //Enroll OLT
                            string confirmOLTSubject = string.Empty;
                            confirmOLTSubject = notification.s_notification_email_subject;
                            confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                            string sbConfirmOLT = string.Empty;
                            sbConfirmOLT = notification.s_notification_email_text;

                            sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", Course.c_created_name);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                            sbConfirmEnrollment.Clear();

                            List<MailAddress> mailAddresses = new List<MailAddress>();


                            if (!string.IsNullOrEmpty(edituser.EmailId))
                            {
                                Thread threadSendMails;
                                threadSendMails = new Thread(delegate()
                                {
                                    mailAddresses.Add(new MailAddress(edituser.EmailId));
                                    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                                    sbConfirmEnrollment.Append(sbConfirmOLT);
                                    Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
                                });
                                threadSendMails.IsBackground = true;
                                threadSendMails.Start();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(edituser.MobileNumber))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = edituser.MobileNumber.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notification.s_notification_SMS_text;
                                    messagetext = messagetext.Replace("", "");


                                    if (messagetext.Length > 180)
                                    {
                                        messagetext = messagetext.Substring(0, 179);
                                    }
                                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
                                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                                }
                            }
                        }
                    }
                    else if ((Course.c_delivery_type_id == "ILT" || Course.c_delivery_type_id == "VLT"))
                    {

                        SystemNotification notificationILT = new SystemNotification();
                        notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON", SessionWrapper.CultureName);
                        if (notificationILT.s_notification_on_off_flag == true)
                        {
                            string confirmILTSubject = string.Empty;
                            confirmILTSubject = notificationILT.s_notification_email_subject;
                            confirmILTSubject = confirmILTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                            string confirmILT = string.Empty;
                            confirmILT = notificationILT.s_notification_email_text;

                            confirmILT = confirmILT.Replace("@$&User First Name&$@", Course.c_created_name);
                            confirmILT = confirmILT.Replace("@$&Course Name&$@", Course.c_course_title);
                            confirmILT = confirmILT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                            confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
                            confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
                            confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
                            confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
                            confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
                            confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);


                            List<MailAddress> mailAddresses = new List<MailAddress>();
                            if (!string.IsNullOrEmpty(edituser.EmailId))
                            {
                                Thread threadSendMails;
                                threadSendMails = new Thread(delegate()
                                {
                                    mailAddresses.Add(new MailAddress(edituser.EmailId));
                                    string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                                    sbConfirmEnrollment.Append(confirmILT);
                                    Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
                                });
                                threadSendMails.IsBackground = true;
                                threadSendMails.Start();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(edituser.MobileNumber))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = edituser.MobileNumber.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notificationILT.s_notification_SMS_text;
                                    messagetext = messagetext.Replace("", "");


                                    if (messagetext.Length > 180)
                                    {
                                        messagetext = messagetext.Substring(0, 179);
                                    }
                                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
                                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemHome/Catalog/samcmp-01.aspx");
        }
    }
}