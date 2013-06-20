using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using System.Net.Mail;
using System.Configuration;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text;

namespace ComplicanceFactor.Instructor
{
    public partial class timtdp_01 : System.Web.UI.Page
    {
        DataSet dsSearch = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_instructor") + "</a>" + " >&nbsp;" + "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_to_do_text") + "</a>";


                BindToDo();
            }
        }

        private void BindToDo()
        {
            try
            {
                dsSearch = InstructorBLL.GetTodoRoasterReport(SessionWrapper.u_userid);

                gvMyToDo.DataSource = dsSearch.Tables[0];
                gvMyToDo.DataBind();

                if (gvMyToDo.Rows.Count > 0)
                {
                    gvMyToDo.UseAccessibleHeader = true;
                    if (gvMyToDo.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvMyToDo.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvMyToDo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string e_enroll_system_id_pk, todo_system_id_pk, delivery_id, e_enroll_user_id_fk;
            if (e.CommandName.Equals("Approve"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_system_id_pk = gvMyToDo.DataKeys[index].Values[1].ToString();
                todo_system_id_pk = gvMyToDo.DataKeys[index].Values[2].ToString();
                delivery_id = gvMyToDo.DataKeys[index].Values[4].ToString();
                e_enroll_user_id_fk = gvMyToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.UpdateApprovalsTodos(e_enroll_system_id_pk, todo_system_id_pk);
                ApproveEmailConfirmation(delivery_id, e_enroll_user_id_fk);
            }
            else if (e.CommandName.Equals("Deny"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_system_id_pk = gvMyToDo.DataKeys[index].Values[1].ToString();
                todo_system_id_pk = gvMyToDo.DataKeys[index].Values[2].ToString();
                delivery_id = gvMyToDo.DataKeys[index].Values[4].ToString();
                e_enroll_user_id_fk = gvMyToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.DenyEnrollment(e_enroll_system_id_pk, todo_system_id_pk);
                //send Enrollment denial Email and Sms 
                denyEmailConfirmation(delivery_id, e_enroll_user_id_fk);
            }
            BindToDo();

        }

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
               // if (type == "OLT")
               // {
               //     SystemNotification notification = new SystemNotification();
               //     notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT", SessionWrapper.CultureName);
               //     //if (notification.s_notification_on_off_flag == true)
               //     //{
               //     //Enroll OLT
               //     string confirmOLTSubject = string.Empty;
               //     confirmOLTSubject = notificationApproval.s_notification_email_subject;
               //     confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

               //     string sbConfirmOLT = string.Empty;
               //     sbConfirmOLT = notification.s_notification_email_text;

               //     sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", user.Firstname);
               //     sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
               //     sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);

               //     string toEmailid = user.EmailId;
               //     string[] toaddress = toEmailid.Split(',');
               //     List<MailAddress> mailAddresses = new List<MailAddress>();
               //     foreach (string recipient in toaddress)
               //     {
               //         if (recipient.Trim() != string.Empty)
               //         {
               //             mailAddresses.Add(new MailAddress(recipient));
               //         }
               //     }
               //     string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
               //     sbConfirmEnrollment.Append(sbConfirmOLT);

               //     if (mailAddresses.Count > 0)
               //     {
               //         Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
               //     }
               //     else
               //     {
               //         if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
               //         {
               //             StringBuilder smsText = new StringBuilder();
               //             string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
               //             string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
               //             string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

               //             string messagetext = notification.s_notification_SMS_text;
               //             messagetext = messagetext.Replace("", "");
               //             messagetext = messagetext.Replace("", "");

               //             if (messagetext.Length > 180)
               //             {
               //                 messagetext = messagetext.Substring(0, 179);
               //             }
               //             messagetext = messagetext.Replace("@$&Status&$@", "Approved");
               //             messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
               //             Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
               //         }
               //     }
               //     //Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
               //     // }
               // }

               ////Enroll ILT/VLT
               // else if ((type == "ILT" || type == "VLT"))
               // {
               //     SystemNotification notificationILT = new SystemNotification();
               //     notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON", SessionWrapper.CultureName);
               //     //if (notificationILT.s_notification_on_off_flag == true)
               //     //{
               //     string confirmILTSubject = string.Empty;
               //     confirmILTSubject = notificationILT.s_notification_email_subject;
               //     confirmILTSubject = confirmILTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

               //     string confirmILT = string.Empty;
               //     confirmILT = notificationILT.s_notification_email_text;

               //     confirmILT = confirmILT.Replace("@$&User First Name&$@", user.Firstname);
               //     confirmILT = confirmILT.Replace("@$&Course Name&$@", Course.c_course_title);
               //     confirmILT = confirmILT.Replace("@$&Course ID&$@", Course.c_course_id_pk);
               //     confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
               //     confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
               //     confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
               //     confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
               //     confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
               //     confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);

               //     string toEmailid = user.EmailId;
               //     if (!string.IsNullOrEmpty(toEmailid))
               //     {
               //         string[] toaddress = toEmailid.Split(',');
               //         List<MailAddress> mailAddresses = new List<MailAddress>();
               //         foreach (string recipient in toaddress)
               //         {
               //             if (recipient.Trim() != string.Empty)
               //             {
               //                 mailAddresses.Add(new MailAddress(recipient));
               //             }
               //         }
               //         string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
               //         sbConfirmEnrollment.Append(confirmILT);
               //         Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
               //     }
               //     else
               //     {
               //         if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
               //         {
               //             StringBuilder smsText = new StringBuilder();
               //             string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
               //             string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
               //             string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

               //             string messagetext = notificationILT.s_notification_SMS_text;
               //             messagetext = messagetext.Replace("", "");
               //             messagetext = messagetext.Replace("", "");

               //             if (messagetext.Length > 180)
               //             {
               //                 messagetext = messagetext.Substring(0, 179);
               //             }
               //             messagetext = messagetext.Replace("@$&Status&$@", "Approved");
               //             messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
               //             Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
               //         }
               //     }
               //     //Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
               //     // }
               // }
            }

        }

    }
}