using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using Microsoft.Reporting.WebForms;
namespace ComplicanceFactor.Training
{
    public partial class tchp_01 : BasePage
    {
        DataSet dsTraining = new DataSet();
        private static string currentdeliveryId;
        #region
        private string e_enroll_system_id_pk;
        private string todo_system_id_pk;
        private string delivery_id;
        private string e_enroll_user_id_fk;
        private string e_enroll_course_id_fk;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_training";

                gvMyDeliveries.AllowPaging = true;
                gvMyDeliveries.PageSize = 5;

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_training") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_home_text");
                if (SessionWrapper.u_profile_my_train_todos_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyToDo.Style.Add("display", "none");
                    imgMyToDo.ImageUrl = "~/Images/addplus-sm.gif";
                    imgMyToDo.AlternateText = "plus";
                }
                else
                {
                    div_MyToDo.Style.Add("display", "block");
                    imgMyToDo.ImageUrl = "~/Images/addminus-sm.gif";
                    imgMyToDo.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_train_deliveries_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyDeliveries.Style.Add("display", "none");
                    imgMyDeliveries.ImageUrl = "~/Images/addplus-sm.gif";
                    imgMyDeliveries.AlternateText = "plus";

                }
                else
                {
                    div_MyDeliveries.Style.Add("display", "block");
                    imgMyDeliveries.ImageUrl = "~/Images/addminus-sm.gif";
                    imgMyDeliveries.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_train_reports_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyReports.Style.Add("display", "none");
                    imgMyReports.ImageUrl = "~/Images/addplus-sm.gif";
                    imgMyReports.AlternateText = "plus";

                }
                else
                {
                    div_MyReports.Style.Add("display", "block");
                    imgMyReports.ImageUrl = "~/Images/addminus-sm.gif";
                    imgMyReports.AlternateText = "minus";
                }
                BindTodo_Deliveries_Report();

            }
        }
        private void BindTodo_Deliveries_Report()
        {
            try
            {
                dsTraining = TrainingBLL.GetTodoDeliveriesReport(SessionWrapper.u_userid);

                gvToDo.DataSource = dsTraining.Tables[0];
                gvToDo.DataBind();
                if (gvToDo.Rows.Count > 0)
                {
                    gvToDo.UseAccessibleHeader = true;
                    if (gvToDo.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvToDo.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }

                gvMyDeliveries.DataSource = dsTraining.Tables[1];
                gvMyDeliveries.DataBind();

                if (gvMyDeliveries.Rows.Count > 0)
                {
                    gvMyDeliveries.UseAccessibleHeader = true;
                    if (gvMyDeliveries.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvMyDeliveries.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }

        protected void gvMyDeliveries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("ManageRoster"))
            {
                Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=" + SecurityCenter.EncryptText(gvMyDeliveries.DataKeys[rowIndex][0].ToString()) + "&deliveryId=" + SecurityCenter.EncryptText(gvMyDeliveries.DataKeys[rowIndex][1].ToString()) + "&deliveryType=" + SecurityCenter.EncryptText(gvMyDeliveries.DataKeys[rowIndex][2].ToString()));
            }

            else if (e.CommandName == "Print")
            {
                //int rowIndex = int.Parse(e.CommandArgument.ToString());
                string courseId = gvMyDeliveries.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyDeliveries.DataKeys[rowIndex][1].ToString();
                currentdeliveryId = deliveryId;
                string deliveryType = gvMyDeliveries.DataKeys[rowIndex][2].ToString();

                rvMySignUpSheet.LocalReport.DataSources.Clear();
                DataTable dtMySession = new DataTable();
                try
                {
                    dtMySession = InstructorBLL.GetSessionForPdf(deliveryId, SessionWrapper.CultureName);

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message);
                        }
                    }

                }
                if (dtMySession.Rows.Count > 0)
                {
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    rvMySignUpSheet.ProcessingMode = ProcessingMode.Local;
                    rvMySignUpSheet.LocalReport.EnableExternalImages = true;
                    rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpSheet.rdlc";
                    rvMySignUpSheet.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);
                    rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsSessionDetails", dtMySession));
                    //rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
                    byte[] bytes = rvMySignUpSheet.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=\"" + "MySignUpSheet" + ".pdf" + "\"");
                    Response.BinaryWrite(bytes); // create the file     
                    Response.Flush(); // send it to the client to download  
                    Response.End();
                    Response.Close();
                }

                //Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?Copy=" + SecurityCenter.EncryptText(harmId));
            }
        }
        void MySubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dtEnrolledUser = new DataTable();
            try
            {
                dtEnrolledUser = InstructorBLL.GetEnrolledUserForPdf(currentdeliveryId, SessionWrapper.CultureName);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tcmddp-01.aspx (PDF)", ex.Message);
                    }
                }

            }
            //rvMySignUpSheet.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Instructor.PdfTemplate.SignUpEmployeeList.rdlc";
            e.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
        }
        private void ApproveEmailConfirmation(string delivery_id, string e_enroll_user_id_fk)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetSingleDeliveryList(delivery_id);
            StringBuilder sbConfirmEnrollment = new StringBuilder();
            //SystemNotification notification = new SystemNotification();
            //notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT");

            //Get emplyee first name
            User user = new User();
            user = UserBLL.GetUserInfo_by_id(e_enroll_user_id_fk);
            string type = Course.c_delivery_type_id;

            SystemNotification notificationApproval = new SystemNotification();
            notificationApproval = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL- APPROVAL-APPROVED", SessionWrapper.CultureName);
            if (notificationApproval.s_notification_on_off_flag == true)
            {
                string ApproveSubject = string.Empty;
                ApproveSubject = notificationApproval.s_notification_email_subject;
                ApproveSubject = ApproveSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                string ApproveText = string.Empty;
                ApproveText = notificationApproval.s_notification_email_text;
                ApproveText = ApproveText.Replace("@$&user_name&$@", user.Firstname);
                ApproveText = ApproveText.Replace("@$&Course Title&$@", Course.c_course_title);
                ApproveText = ApproveText.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                ApproveText = ApproveText.Replace("@$&manager_name&$@", SessionWrapper.u_username);

                sbConfirmEnrollment.Append(ApproveText);

                string toEmailid = user.EmailId;
                if (!string.IsNullOrEmpty(toEmailid))
                {
                    string[] toaddress = toEmailid.Split(',');
                    List<MailAddress> mailAddresses = new List<MailAddress>();
                    foreach (string recipient in toaddress)
                    {
                        if (recipient.Trim() != string.Empty)
                        {
                            mailAddresses.Add(new MailAddress(recipient));
                        }
                    }
                    string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                    Utility.SendEMailMessages(mailAddresses, fromaddress, ApproveSubject, sbConfirmEnrollment.ToString());
                }
                else
                {
                    if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                    {
                        StringBuilder smsText = new StringBuilder();
                        string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                        string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                        string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                        string messagetext = notificationApproval.s_notification_SMS_text;
                        messagetext = messagetext.Replace("", "");
                        messagetext = messagetext.Replace("", "");

                        if (messagetext.Length > 180)
                        {
                            messagetext = messagetext.Substring(0, 179);
                        }
                        messagetext = messagetext.Replace("@$&Status&$@", "Approved");
                        messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                        Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                    }
                }
            }
        }
        //        if (type == "OLT")
        //        {
        //            SystemNotification notification = new SystemNotification();
        //            notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT",SessionWrapper.CultureName);
        //            //if (notification.s_notification_on_off_flag == true)
        //            //{
        //            //Enroll OLT
        //            string confirmOLTSubject = string.Empty;
        //            confirmOLTSubject = notification.s_notification_email_subject;
        //            confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

        //            string sbConfirmOLT = string.Empty;
        //            sbConfirmOLT = notification.s_notification_email_text;

        //            sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", user.Firstname);
        //            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
        //            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);

        //            string toEmailid = user.EmailId;
        //            if (!string.IsNullOrEmpty(toEmailid))
        //            {
        //                string[] toaddress = toEmailid.Split(',');
        //                List<MailAddress> mailAddresses = new List<MailAddress>();
        //                foreach (string recipient in toaddress)
        //                {
        //                    if (recipient.Trim() != string.Empty)
        //                    {
        //                        mailAddresses.Add(new MailAddress(recipient));
        //                    }
        //                }
        //                string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
        //                sbConfirmEnrollment.Append(sbConfirmOLT);
        //                Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
        //            }
        //            else
        //            {
        //                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
        //                {
        //                    StringBuilder smsText = new StringBuilder();
        //                    string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
        //                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
        //                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

        //                    string messagetext = notification.s_notification_SMS_text;
        //                    messagetext = messagetext.Replace("", "");
        //                    messagetext = messagetext.Replace("", "");

        //                    if (messagetext.Length > 180)
        //                    {
        //                        messagetext = messagetext.Substring(0, 179);
        //                    }
        //                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
        //                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
        //                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
        //                }
        //            }
        //            // }
        //        }

        //       //Enroll ILT/VLT
        //        else if ((type == "ILT" || type == "VLT"))
        //        {
        //            SystemNotification notificationILT = new SystemNotification();
        //            notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON",SessionWrapper.CultureName);
        //            //if (notificationILT.s_notification_on_off_flag == true)
        //            //{
        //            string confirmILTSubject = string.Empty;
        //            confirmILTSubject = notificationILT.s_notification_email_subject;
        //            confirmILTSubject = confirmILTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

        //            string confirmILT = string.Empty;
        //            confirmILT = notificationILT.s_notification_email_text;

        //            confirmILT = confirmILT.Replace("@$&User First Name&$@", user.Firstname);
        //            confirmILT = confirmILT.Replace("@$&Course Name&$@", Course.c_course_title);
        //            confirmILT = confirmILT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
        //            confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
        //            confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
        //            confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
        //            confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
        //            confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
        //            confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);

        //            string toEmailid = user.EmailId;
        //            if (!string.IsNullOrEmpty(toEmailid))
        //            {
        //                string[] toaddress = toEmailid.Split(',');
        //                List<MailAddress> mailAddresses = new List<MailAddress>();
        //                foreach (string recipient in toaddress)
        //                {
        //                    if (recipient.Trim() != string.Empty)
        //                    {
        //                        mailAddresses.Add(new MailAddress(recipient));
        //                    }
        //                }
        //                string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
        //                sbConfirmEnrollment.Append(confirmILT);
        //                Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
        //            }
        //            else
        //            {
        //                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
        //                {
        //                    StringBuilder smsText = new StringBuilder();
        //                    string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
        //                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
        //                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

        //                    string messagetext = notificationILT.s_notification_SMS_text;
        //                    messagetext = messagetext.Replace("", "");
        //                    messagetext = messagetext.Replace("", "");

        //                    if (messagetext.Length > 180)
        //                    {
        //                        messagetext = messagetext.Substring(0, 179);
        //                    }
        //                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
        //                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
        //                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
        //                }
        //            }
        //            // }
        //        }
        //    }
        //    //sbConfirmEnrollment.Append("Hello " + user.Firstname + ",");
        //    //sbConfirmEnrollment.Append("<br>");
        //    //sbConfirmEnrollment.Append("This email is to confirm that you are enrolled in the {" + Course.c_course_title + "} + (" + Course.c_course_id_pk + ")).");
        //    //sbConfirmEnrollment.Append("<br>");
        //    //if ((type == "ILT" || type == "VLT"))
        //    //{
        //    //      sbConfirmEnrollment.Append("Location:" + Course.c_session_location_names + ", " + Course.c_session_facility_names + ", " + Course.c_session_room_names + "");
        //    //      sbConfirmEnrollment.Append("<br>");
        //    //      sbConfirmEnrollment.Append("Instructor(S):" + Course.c_instructor_list);
        //    //      sbConfirmEnrollment.Append("<br>");
        //    //      sbConfirmEnrollment.Append("Starting on:" + Course.c_session_start_date_time);
        //    //      sbConfirmEnrollment.Append("<br>");
        //    //      sbConfirmEnrollment.Append("Ending on:" + Course.c_session_end_date_time);
        //    //      sbConfirmEnrollment.Append("<br>");
        //    //      sbConfirmEnrollment.Append("Please login to the system and go to your 'My Course' section to access the details for this training or launch the course for eLearning Training or simply click on the link below:");
        //    //      sbConfirmEnrollment.Append("<br>");
        //    //      sbConfirmEnrollment.Append("www.compliancefactors.com/login_redirect/?url=lmcp-01.aspx");
        //    //      sbConfirmEnrollment.Append("<br>");
        //    //      sbConfirmEnrollment.Append("We are looking forward to seeing you!");
        //    //}
        //    //sbConfirmEnrollment.Append("Thanks!");
        //    //sbConfirmEnrollment.Append("<br><br>");
        //    //sbConfirmEnrollment.Append("The Training Department");
        //    //List<MailAddress> mailAddresses = new List<MailAddress>();
        //    //mailAddresses.Add(new MailAddress(user.EmailId));
        //    //string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
        //    ////mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
        //    //Utility.SendEMailMessages(mailAddresses, fromAddress, "*** Enrollment Confirmation Approved in " + Course.c_course_title + " ***", sbConfirmEnrollment.ToString());

        //}
        private void denyEmailConfirmation(string delivery_id, string e_enroll_user_id_fk)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = EnrollmentBLL.GetCourseDetails(delivery_id);

            User user = new User();
            user = UserBLL.GetUserInfo_by_id(e_enroll_user_id_fk);


            StringBuilder sbConfirmEnrollment = new StringBuilder();

            SystemNotification notification = new SystemNotification();
            notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL- APPROVAL-DENIED", SessionWrapper.CultureName);//Enroll-Approval-Denied
            if (notification.s_notification_on_off_flag == true)
            {
                string denySubject = string.Empty;
                denySubject = notification.s_notification_email_subject;
                denySubject = denySubject.Replace("@$&Course Title&$@", Course.c_course_title);

                string denyText = string.Empty;
                denyText = notification.s_notification_email_text;
                denyText = denyText.Replace("@$&user_name&$@", user.Firstname);
                denyText = denyText.Replace("@$&Course Title&$@", Course.c_course_title);
                denyText = denyText.Replace("@$&Course ID&$@", Course.c_course_id_pk);
                denyText = denyText.Replace("@$&manager_name&$@", SessionWrapper.u_username);

                sbConfirmEnrollment.Append(denyText);

                string toEmailid = user.EmailId;
                if (!string.IsNullOrEmpty(toEmailid))
                {
                    string[] toaddress = toEmailid.Split(',');
                    List<MailAddress> mailAddresses = new List<MailAddress>();
                    foreach (string recipient in toaddress)
                    {
                        if (recipient.Trim() != string.Empty)
                        {
                            mailAddresses.Add(new MailAddress(recipient));
                        }
                    }
                    string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                    Utility.SendEMailMessages(mailAddresses, fromaddress, denySubject, sbConfirmEnrollment.ToString());
                }
                else
                {
                    if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                    {
                        StringBuilder smsText = new StringBuilder();
                        string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                        string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                        string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                        string messagetext = notification.s_notification_SMS_text;
                        messagetext = messagetext.Replace("", "");
                        messagetext = messagetext.Replace("", "");

                        if (messagetext.Length > 180)
                        {
                            messagetext = messagetext.Substring(0, 179);
                        }
                        messagetext = messagetext.Replace("@$&Status&$@", "Denied");
                        messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                        Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                    }
                }
            }
        }

        protected void gvToDo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Approve"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_system_id_pk = gvToDo.DataKeys[index].Values[1].ToString();
                todo_system_id_pk = gvToDo.DataKeys[index].Values[2].ToString();
                delivery_id = gvToDo.DataKeys[index].Values[4].ToString();
                e_enroll_user_id_fk = gvToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.UpdateApprovalsTodos(e_enroll_system_id_pk, todo_system_id_pk);
                ApproveEmailConfirmation(delivery_id, e_enroll_user_id_fk);
            }
            else if (e.CommandName.Equals("Deny"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_system_id_pk = gvToDo.DataKeys[index].Values[1].ToString();
                todo_system_id_pk = gvToDo.DataKeys[index].Values[2].ToString();
                delivery_id = gvToDo.DataKeys[index].Values[4].ToString();
                e_enroll_user_id_fk = gvToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.DenyEnrollment(e_enroll_system_id_pk, todo_system_id_pk);
                //send Enrollment denial Email and Sms 
                denyEmailConfirmation(delivery_id, e_enroll_user_id_fk);

            }

            BindTodo_Deliveries_Report();
        }

        protected void lnkViewAllToDos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Training/tcmtdp-01.aspx");
        }

        protected void lnkViewAllMyRosters_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Training/tcmddp-01.aspx");
        }

        protected void lnkViewAllMyReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Training/tcmrp-01.aspx");
        }
    }
}