using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Configuration;
namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class saeas_01 : System.Web.UI.Page
    {
        #region
        private static string e_enroll_approval_system_id_pk;
        private static string s_todo_system_id_pk;
        private static string e_enroll_delivery_id_fk;
        private static string e_enroll_user_id_fk;
        private static string deliveryID;
        private static string userId;
        #endregion
        DataSet dsApprovalsQueue = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "System" + "&nbsp;>&nbsp;" + "Manage Approval Workflow" + "&nbsp;>&nbsp;" + "Edit Approval Workflow Information";
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Course/sastcp-01.aspx>" + "Manage Training" + "</a>&nbsp;" + " >&nbsp;" + "Edit Approval Workflow Information"; 
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "Edit Approval Workflow Information";
                e_enroll_approval_system_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"].ToString());
                e_enroll_user_id_fk = SecurityCenter.DecryptText(Request.QueryString["uid"].ToString());
                //Popualte approvals
                PopulateApprovals(e_enroll_approval_system_id_pk, e_enroll_user_id_fk);
            }
        }
        //Populate Approvals Queue
        private void PopulateApprovals(string e_enroll_approval_system_id_pk,string e_enroll_user_id_fk)
        {

            dsApprovalsQueue = SystemApprovalBLL.GetApprovalsQueue(e_enroll_approval_system_id_pk, e_enroll_user_id_fk);
            lblApprovalID.Text = dsApprovalsQueue.Tables[0].Rows[0]["ApprovalID"].ToString();
            lblApprovalWorkFlowName.Text = dsApprovalsQueue.Tables[0].Rows[0]["ApprovalWorkflowName"].ToString();
            lblEmployeeId.Text = dsApprovalsQueue.Tables[0].Rows[0]["EmployeeId"].ToString();
            lblEmployeeName.Text = dsApprovalsQueue.Tables[0].Rows[0]["EmployeeName"].ToString();
            lblTrainingId.Text = dsApprovalsQueue.Tables[0].Rows[0]["TrainingId"].ToString();
            lblTrainingName.Text = dsApprovalsQueue.Tables[0].Rows[0]["TrainingTitle"].ToString();
            lblRequestDate.Text = dsApprovalsQueue.Tables[0].Rows[0]["RequestDate"].ToString();
            lblRequestType.Text = dsApprovalsQueue.Tables[0].Rows[0]["RequiredType"].ToString();
            deliveryID = dsApprovalsQueue.Tables[0].Rows[0]["e_enroll_delivery_id_fk"].ToString();
            userId = dsApprovalsQueue.Tables[0].Rows[0]["e_enroll_user_id_fk"].ToString();

            gvApprovalWorkflowDetails.DataSource = dsApprovalsQueue.Tables[1];
            gvApprovalWorkflowDetails.DataBind();
            //Bind ApprovalsQueue
            //BindApprovalsQueue();
           
        }
        //private void BindApprovalsQueue()
        //{
        //    gvApprovalWorkflowDetails.DataSource = dsApprovalsQueue.Tables[1];
        //    gvApprovalWorkflowDetails.DataBind();
        //}

        protected void gvApprovalWorkflowDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDeny = (Button)e.Row.FindControl("btnDeny");
                Button btnApprove = (Button)e.Row.FindControl("btnApprove");
                string ApprovalStatus = DataBinder.Eval(e.Row.DataItem, "ApprovalStatus").ToString();
                if (ApprovalStatus == "Status:Approved" || ApprovalStatus == "Status:Denied"  || ApprovalStatus == "")
                {
                    btnDeny.Style.Add("display", "none");
                    btnApprove.Style.Add("display", "none");
                }
                else
                {
                    btnDeny.Style.Add("display", "inline");
                    btnApprove.Style.Add("display", "inline");
                }
                
            }
        }

        protected void gvApprovalWorkflowDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName.Equals("Approve"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                e_enroll_approval_system_id_pk = gvApprovalWorkflowDetails.DataKeys[index].Values[0].ToString();
                s_todo_system_id_pk = gvApprovalWorkflowDetails.DataKeys[index].Values[1].ToString();
                e_enroll_delivery_id_fk = gvApprovalWorkflowDetails.DataKeys[index].Values[2].ToString();
                e_enroll_user_id_fk = gvApprovalWorkflowDetails.DataKeys[index].Values[3].ToString();
                ////send Enrollment Approve Email and Sms 
                int result = EnrollmentBLL.UpdateApprovalsTodos(e_enroll_approval_system_id_pk, s_todo_system_id_pk);
               
            }
            else if (e.CommandName.Equals("Deny"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                e_enroll_approval_system_id_pk = gvApprovalWorkflowDetails.DataKeys[index].Values[0].ToString();
                s_todo_system_id_pk = gvApprovalWorkflowDetails.DataKeys[index].Values[1].ToString();
                e_enroll_delivery_id_fk = gvApprovalWorkflowDetails.DataKeys[index].Values[2].ToString();
                e_enroll_user_id_fk = gvApprovalWorkflowDetails.DataKeys[index].Values[3].ToString();
                int result = SystemApprovalBLL.DenyEnrollment(e_enroll_approval_system_id_pk, s_todo_system_id_pk);
                ////send Enrollment denial Email and Sms 
                denyEmailConfirmation(e_enroll_delivery_id_fk, e_enroll_user_id_fk);

            }

            PopulateApprovals(e_enroll_approval_system_id_pk, e_enroll_user_id_fk);
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

        protected void btnSaveApprovalWorkFlow_Click(object sender, EventArgs e)
        {
            dsApprovalsQueue = SystemApprovalBLL.GetApprovalsQueue(e_enroll_approval_system_id_pk, e_enroll_user_id_fk);
           DataTable dtApprovalsQueue = dsApprovalsQueue.Tables[2];
           if (dtApprovalsQueue.Rows.Count > 0)
           {
               ApproveEmailConfirmation(deliveryID, userId);
           }
            
        }

        
    }
}