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
using System.Configuration;
using System.Net.Mail;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.Common.Languages;
using System.Net;

namespace ComplicanceFactor.Instructor
{
    public partial class tihp_01 : System.Web.UI.Page
    {
        DataSet dsSearch = new DataSet();
        private static string currentdeliveryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            mrp1.flag = ReportEnum.Instructor;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SessionWrapper.u_userid))
                {
                    User userSplash = new User();
                    try
                    {
                        userSplash = UserBLL.GetUserSplash(SessionWrapper.u_userid);
                        bool result = userSplash.u_splash_display_flag;
                        SystemSplashPage splashContent = new SystemSplashPage();
                        //Here we can get the splash content based on the domain Id
                        splashContent = SystemSplashPageBLL.GetSplashContent(SessionWrapper.u_domain, SessionWrapper.CultureName);
                        spalsh.InnerHtml = WebUtility.HtmlDecode(splashContent.u_splash_content);
                        if (result == false && (!string.IsNullOrEmpty(splashContent.u_splash_content)) && string.IsNullOrEmpty(SessionWrapper.IsClose))
                        {
                            mpSplashPage.Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("tihp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("tihp-01.aspx", ex.Message);
                            }
                        }
                    }
                }
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_instructor_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>";
              
                gvMyRosters.AllowPaging = true;
                gvMyToDo.AllowPaging = true;

               

                if (SessionWrapper.u_profile_my_inst_rosters_display_pref == 0)
                {
                    gvMyRosters.AllowPaging = false;
                }
                else
                {
                    gvMyRosters.PageSize = SessionWrapper.u_profile_my_inst_rosters_display_pref;
                }
                if (SessionWrapper.u_profile_my_inst_todos_display_pref == 0)
                {
                    gvMyToDo.AllowPaging = false;
                }
                else
                {
                    gvMyToDo.PageSize = SessionWrapper.u_profile_my_inst_todos_display_pref;
                }


                if (SessionWrapper.u_profile_my_inst_todos_collapse_pref == "app_ddl_collapsed")
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
                if (SessionWrapper.u_profile_my_inst_rosters_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyRosters.Style.Add("display", "none");
                    imgMyRosters.ImageUrl = "~/Images/addplus-sm.gif";
                    imgMyRosters.AlternateText = "plus";

                }
                else
                {
                    div_MyRosters.Style.Add("display", "block");
                    imgMyRosters.ImageUrl = "~/Images/addminus-sm.gif";
                    imgMyRosters.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_inst_reports_collapse_pref == "app_ddl_collapsed")
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

                BindTodo_Roaster_Report();
            }
        }
        private void BindTodo_Roaster_Report()
        {
            try
            {
                dsSearch = InstructorBLL.GetTodoRoasterReport(SessionWrapper.u_userid);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tihp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tihp-01.aspx", ex.Message);
                    }
                }
            }
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

            gvMyRosters.DataSource = dsSearch.Tables[1];
            gvMyRosters.DataBind();

            if (gvMyRosters.Rows.Count > 0)
            {
                gvMyRosters.UseAccessibleHeader = true;
                if (gvMyRosters.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvMyRosters.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
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
            BindTodo_Roaster_Report();
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
            }
        }
        //        if (type == "OLT")
        //        {
        //            SystemNotification notification = new SystemNotification();
        //            notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT", SessionWrapper.CultureName);
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
        //                    messagetext = messagetext.Replace("@$&Status&$@", "Approved");
        //                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
        //                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
        //                }
        //            }


        //            //Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
        //            // }
        //        }

        //       //Enroll ILT/VLT
        //        else if ((type == "ILT" || type == "VLT"))
        //        {
        //            SystemNotification notificationILT = new SystemNotification();
        //            notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON", SessionWrapper.CultureName);
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
        //                    messagetext = messagetext.Replace("@$&Status&$@", "Approved");
        //                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
        //                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
        //                }
        //            }



        //            //Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
        //            // }
        //        }
        //    }

        //}

        protected void gvMyRosters_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Completion"))
            {
                string courseId = gvMyRosters.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyRosters.DataKeys[rowIndex][1].ToString();
                string deliveryType = gvMyRosters.DataKeys[rowIndex][2].ToString();
                Response.Redirect("~/SystemHome/Catalog/Completion/samcmcp-01.aspx?courseId=" + SecurityCenter.EncryptText(courseId) + "&deliveryId=" + SecurityCenter.EncryptText(deliveryId) + "&deliveryType=" + SecurityCenter.EncryptText(deliveryType), false);
            }
            else if (e.CommandName.Equals("Print"))
            {
                string courseId = gvMyRosters.DataKeys[rowIndex][0].ToString();
                string deliveryId = gvMyRosters.DataKeys[rowIndex][1].ToString();
                currentdeliveryId = deliveryId;
                string deliveryType = gvMyRosters.DataKeys[rowIndex][2].ToString();

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
                            Logger.WriteToErrorLog("tihp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("tihp-01.aspx (PDF)", ex.Message);
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

                    SystemThemes userTheme = new SystemThemes();
                    userTheme = GetthemeforEmailandPdf();


                    string protocol = Request.Url.AbsoluteUri;
                    int len = protocol.IndexOf(':');
                    protocol = protocol.Substring(0, len);

                    rvMySignUpSheet.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportEventHandler);
                    rvMySignUpSheet.LocalReport.DataSources.Add(new ReportDataSource("dsSessionDetails", dtMySession));

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
                    this.rvMySignUpSheet.LocalReport.SetParameters(param);

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
                        Logger.WriteToErrorLog("tihp-01.aspx (PDF)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tihp-01.aspx (PDF)", ex.Message);
                    }
                }
            }

            e.DataSources.Add(new ReportDataSource("dsEmployeeList", dtEnrolledUser));
        }

        protected void lnkViewAllToDos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Instructor/timtdp-01.aspx");
        }

        protected void lnkViewAllMyRosters_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Instructor/timrostersp-01.aspx");
        }

        protected void lnkViewAllMyReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Instructor/timrp-01.aspx");
        }

        // For Theme for email and pdf
        private static SystemThemes GetthemeforEmailandPdf()
        {
            SystemThemes userTheme = new SystemThemes();
            userTheme = SystemThemeBLL.GetThemeForEmailPdf(SessionWrapper.u_userid);
            return userTheme;
        }

        //Splash page

        protected void btnDonotShow_Click(object sender, EventArgs e)
        {
            //Set the u_splash_display_flag as 1.
            User userSplash = new User();
            userSplash.Userid = SessionWrapper.u_userid;
            userSplash.u_splash_display_flag = true;

            try
            {
                int result = UserBLL.UpdateSplash(userSplash);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("tihp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("tihp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnCloseSplashPage_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }
        protected void ibtnCloseSplash_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }
    }
}