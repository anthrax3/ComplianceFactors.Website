using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Data;

namespace ComplicanceFactor.Manager.Enroll
{
    public partial class mesc_01 : System.Web.UI.Page
    {
        private string courseid;
        private string deliveryid;
        private string deliveryType;
        private bool c_course_approval;
        private bool c_delivery_approval;
        private bool check_course_or_curriculum;
        private string waitList;
        private int approvalCount;
        private int max_enroll;
        private int enrolled_delivery_count;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region
            courseid = Request.QueryString["courseid"];
            deliveryid = Request.QueryString["deliveryid"];
            deliveryType = Request.QueryString["deliveryType"];
            c_course_approval = Convert.ToBoolean(Request.QueryString["ca"]);
            c_delivery_approval = Convert.ToBoolean(Request.QueryString["da"]);
            check_course_or_curriculum = Convert.ToBoolean(Request.QueryString["check"]);
            #endregion
            if (!IsPostBack)
            {
                try
                {
                    GetEmployee();
                    PopulateCourse(courseid);
                    if (!string.IsNullOrEmpty(deliveryType) && deliveryType == "OLT")
                    {
                        btnAssignOnly.Style.Add("display", "none");
                    }
                    if (c_course_approval == true)
                    {
                        approvalCount = EnrollmentBLL.ApprovalCount(courseid);
                    }
                    else if (c_delivery_approval == true)
                    {
                        approvalCount = EnrollmentBLL.ApprovalCount(deliveryid);
                    }
                    if (c_course_approval == true || c_delivery_approval == true)
                    {
                        if (approvalCount > 1)
                        {
                            btnRequestAssign.Style.Add("display", "block");
                            btnRequestEnrollment.Style.Add("display", "block");
                            btnConfirmEnrollment.Style.Add("display", "none");
                            btnAssignOnly.Style.Add("display", "none");
                        }
                    }

                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("mesc-01.aspx (PopulateCourse)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("mesc-01.aspx (PopulateCourse)", ex.Message);
                        }
                    }
                }

            }

        }
        private void PopulateCourse(string courseId)
        {
            SystemCatalog Course = new SystemCatalog();
            Course = SystemCatalogBLL.GetCourse(courseId, SessionWrapper.CultureName);
            lblCourseTitle.Text = Course.c_course_title + "(" + Course.c_course_id_pk + ")";
            lblRevision.Text = Course.c_course_version;
            lblDescription.Text = Course.c_course_desc;
            lblOwner.Text = Course.c_course_owner_name;
            lblCoordinator.Text = Course.c_course_coordinator_name;
            lblCost.Text = Convert.ToString(Course.cost_text);
            lblApproval.Text = Course.c_course_approval_req_text;
            lblCEU.Text = Convert.ToString(Course.c_course_credit_hours);
            lblDeliveryType.Text = Course.c_delivery_type_id;
            //
            DataSet dsDeliveries = SystemCatalogBLL.GetDeliveries(deliveryid);
            //get delivery
            SystemCatalog delivery = new SystemCatalog();
            delivery = SystemCatalogBLL.GetDelivery(deliveryid, dsDeliveries.Tables[0]);
            hdnMe.Value = Convert.ToString(delivery.c_delivery_max_enroll);
            hdEd.Value = delivery.c_enroll_delivery_count;

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Enroll/mese-01.aspx?courseid=" + courseid + "&id=" + deliveryid + "&type=" + deliveryType + "&ca=" + c_course_approval + "&approval=" + c_delivery_approval + "&search=" + txtEmployeeName.Text);
        }

        protected void btnAssignOnly_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertDataTables dataTableToXml = new ConvertDataTables();
                DataTable dtEmployees = new DataTable();
                TempDataTables dtTables = new TempDataTables();
                dtEmployees = dtTables.TempEmployee();
                Enrollment assign = new Enrollment();
                assign.e_assign_course = dataTableToXml.ConvertDataTableToXml(AddEmployee(dtEmployees));
                assign.e_course_assign_by_id_fk = SessionWrapper.u_userid;
                assign.e_course_assign_required_flag = chkRequired.Checked;
                DateTime? targetDueDate = null;
                DateTime tempTargetDueDate;
                if (DateTime.TryParse(txtTargetDueDate.Text, out tempTargetDueDate))
                {
                    targetDueDate = Convert.ToDateTime(txtTargetDueDate.Text);
                }
                DateTime? recertDueDate = null;
                assign.e_course_assign_target_due_date = targetDueDate;
                assign.e_course_assign_recert_due_date = recertDueDate;
                assign.e_course_assign_percent_complete = 0;
                assign.e_course_assign_active_flag = true;
                EnrollmentBLL.AssignCourse(assign);
                //close popup
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Catalog/ctdp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx (Assign Only)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx (Assign Only)", ex.Message);
                    }
                }
            }
        }

        protected void btnConfirmEnrollment_Click(object sender, EventArgs e)
        {
            confirmEnrollment();
        }
        private void confirmEnrollment()
        {
            DataTable dtEmployees = new DataTable();
            TempDataTables dtTables = new TempDataTables();
            dtEmployees = dtTables.TempEmployee();
            DataTable dtEmployeeSelecteList = AddEmployee(dtEmployees);
            for (int i = 0; i < dtEmployeeSelecteList.Rows.Count; i++)
            {

                if (c_course_approval == true || c_delivery_approval == true)
                {
                    //Enrollment with approval
                    EnrollmentApprovals(true, c_course_approval, c_delivery_approval, dtEmployeeSelecteList.Rows[i]["u_user_id_fk"].ToString(), SessionWrapper.u_userid);
                }
                else
                {
                    //Enrollment without approval
                    Enrollment(false, c_course_approval, c_delivery_approval, dtEmployeeSelecteList.Rows[i]["u_user_id_fk"].ToString(), string.Empty);
                }
                SendConfirmationEmail(dtEmployeeSelecteList.Rows[i]["u_user_id_fk"].ToString());
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "add", "window.top.location.href ='" + "../Home/mhp-01.aspx" + "'; parent.jQuery.fancybox.close();", true);

        }
        protected void btnRequestAssignment_Click(object sender, EventArgs e)
        {

        }
        protected void btnRequestEnrollment_Click(object sender, EventArgs e)
        {

            confirmEnrollment();
        }
        private void Enrollment(bool check_enroll, bool course_approval, bool delivery_approval, string u_user_id_fk, string manager_id_fk)
        {
            try
            {
                //insert enrollment
                BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                enrollOLT.e_check_course_approval = course_approval;
                enrollOLT.e_check_delivery_approval = delivery_approval;
                enrollOLT.e_enroll_user_id_fk = u_user_id_fk;
                enrollOLT.e_enroll_delivery_id_fk = deliveryid;
                enrollOLT.e_enroll_course_id_fk = courseid;
                enrollOLT.e_enroll_required_flag = chkRequired.Checked;
                enrollOLT.e_enroll_approval_required_flag = false;
                enrollOLT.e_enroll_type_name = "Manager Enroll";
                enrollOLT.e_enroll_approval_status_name = "Pending";
                enrollOLT.e_enroll_status_name = "Enrolled";
                DateTime? target_due_date = null;
                DateTime temp_target_due_date;
                if (DateTime.TryParse(txtTargetDueDate.Text, out temp_target_due_date))
                {
                    target_due_date = Convert.ToDateTime(txtTargetDueDate.Text);
                }
                enrollOLT.e_enroll_target_due_date = target_due_date;
                //for approval
                enrollOLT.e_enroll_level_1_req_flag = false;
                enrollOLT.e_enroll_approver_1_type = true;
                enrollOLT.e_enroll_approver_1_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_approver_1_decision_flag = false;
                enrollOLT.e_enroll_approver_1_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_2_req_flag = false;
                enrollOLT.e_enroll_approver_2_type = false;
                enrollOLT.e_enroll_approver_2_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_2_decision_flag = false;
                enrollOLT.e_enroll_approver_2_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_3_req_flag = false;
                enrollOLT.e_enroll_approver_3_type = false;
                enrollOLT.e_enroll_approver_3_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_3_decision_flag = false;
                enrollOLT.e_enroll_approver_3_decision_date = DateTime.Now;
                enrollOLT.e_enroll_enroll_approval_status_id_fk = string.Empty;
                enrollOLT.e_enroll_approval_final_decision_date = DateTime.Now;
                enrollOLT.e_enroll_manger_id_fk = manager_id_fk;
                EnrollmentBLL.SingleEnroll(enrollOLT, check_enroll);

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx (Enrollment)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx (Enrollment)", ex.Message);
                    }
                }
            }
        }
        private void EnrollmentApprovals(bool check_enroll, bool course_approval, bool delivery_approval, string u_user_id_fk, string manager_id_fk)
        {
            try
            {
                //insert enrollment
                BusinessComponent.DataAccessObject.Enrollment enrollOLT = new BusinessComponent.DataAccessObject.Enrollment();
                enrollOLT.e_check_course_approval = course_approval;
                enrollOLT.e_check_delivery_approval = delivery_approval;
                enrollOLT.e_enroll_user_id_fk = u_user_id_fk;
                enrollOLT.e_enroll_delivery_id_fk = deliveryid;
                enrollOLT.e_enroll_course_id_fk = courseid;
                enrollOLT.e_enroll_required_flag = chkRequired.Checked;
                enrollOLT.e_enroll_approval_required_flag = false;
                enrollOLT.e_enroll_type_name = "Manager Enroll";
                enrollOLT.e_enroll_approval_status_name = "Pending";
                enrollOLT.e_enroll_status_name = "Assigned";
                DateTime? target_due_date = null;
                DateTime temp_target_due_date;
                if (DateTime.TryParse(txtTargetDueDate.Text, out temp_target_due_date))
                {
                    target_due_date = Convert.ToDateTime(txtTargetDueDate.Text);
                }
                enrollOLT.e_enroll_target_due_date = target_due_date;
                //for approval
                enrollOLT.e_enroll_level_1_req_flag = false;
                enrollOLT.e_enroll_approver_1_type = true;
                enrollOLT.e_enroll_approver_1_id_fk = SessionWrapper.u_userid;
                enrollOLT.e_enroll_approver_1_decision_flag = true; //it must be true because it does not create todo for this
                enrollOLT.e_enroll_approver_1_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_2_req_flag = false;
                enrollOLT.e_enroll_approver_2_type = false;
                enrollOLT.e_enroll_approver_2_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_2_decision_flag = false;
                enrollOLT.e_enroll_approver_2_decision_date = DateTime.Now;
                enrollOLT.e_enroll_level_3_req_flag = false;
                enrollOLT.e_enroll_approver_3_type = false;
                enrollOLT.e_enroll_approver_3_id_fk = string.Empty;
                enrollOLT.e_enroll_approver_3_decision_flag = false;
                enrollOLT.e_enroll_approver_3_decision_date = DateTime.Now;
                enrollOLT.e_enroll_enroll_approval_status_id_fk = string.Empty;
                enrollOLT.e_enroll_approval_final_decision_date = DateTime.Now;
                enrollOLT.e_enroll_manger_id_fk = manager_id_fk;
                EnrollmentBLL.EnrollmentApproval(enrollOLT, check_enroll);

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx (Enrollment Approvels)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx (Enrollment Approvels)", ex.Message);
                    }
                }
            }
        }
        private void SendConfirmationEmail(string userid)
        {
            try
            {
                User user = new User();
                user = UserBLL.GetUserInfo_by_id(userid);

                SystemCatalog Course = new SystemCatalog();
                Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryid);
                StringBuilder sbConfirmEnrollment = new StringBuilder();

                //For Couese Title and Course Id
                SystemCatalog courseDetails = new SystemCatalog();
                courseDetails = EnrollmentBLL.GetCourseDetails(deliveryid);

                if (deliveryType == "OLT")
                {
                    if (string.IsNullOrEmpty(waitList))
                    {
                        SystemNotification notification = new SystemNotification();
                        notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT",SessionWrapper.CultureName);
                        if (notification.s_notification_on_off_flag == true)
                        {
                            //Enroll OLT
                            string confirmOLTSubject = string.Empty;
                            confirmOLTSubject = notification.s_notification_email_subject;
                            confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                            string sbConfirmOLT = string.Empty;
                            sbConfirmOLT = notification.s_notification_email_text;

                            sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", user.Firstname);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", courseDetails.c_course_title);
                            sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", courseDetails.c_course_id_pk);

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
                                string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                                sbConfirmEnrollment.Append(sbConfirmOLT);
                                Utility.SendEMailMessages(mailAddresses, fromAddress, confirmOLTSubject, sbConfirmEnrollment.ToString());
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
                                    messagetext = messagetext.Replace("@$&Status&$@", "Enroll Confirm");
                                    messagetext = messagetext.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                                    Utility.SendSms(toPhoneNumber, username, passwd, messagetext);
                                }
                            }
                        }
                    }
                }

                //Enroll ILT/VLT
                else if ((deliveryType == "ILT" || deliveryType == "VLT") && (waitList == "False"))
                {
                    if (string.IsNullOrEmpty(waitList))
                    {
                        SystemNotification notificationILT = new SystemNotification();
                        notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON",SessionWrapper.CultureName);
                        if (notificationILT.s_notification_on_off_flag == true)
                        {
                            string confirmILTSubject = string.Empty;
                            confirmILTSubject = notificationILT.s_notification_email_subject;
                            confirmILTSubject = confirmILTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

                            string confirmILT = string.Empty;
                            confirmILT = notificationILT.s_notification_email_text;

                            confirmILT = confirmILT.Replace("@$&User First Name&$@", user.Firstname);
                            confirmILT = confirmILT.Replace("@$&Course Name&$@", courseDetails.c_course_title);
                            confirmILT = confirmILT.Replace("@$&Course ID&$@", courseDetails.c_course_id_pk);
                            confirmILT = confirmILT.Replace("@$&delivery_location&$@", Course.c_session_location_names);
                            confirmILT = confirmILT.Replace("@$&delivery_facility&$@", Course.c_session_facility_names);
                            confirmILT = confirmILT.Replace("@$&delivery_room&$@", Course.c_session_room_names);
                            confirmILT = confirmILT.Replace("@$&delivery_intructors&$@", Course.c_instructor_list);
                            confirmILT = confirmILT.Replace("@$&session_start_date&$@", Course.c_session_start_date_time);
                            confirmILT = confirmILT.Replace("@$&session_start_time&$@", Course.c_session_end_date_time);

                            string toEmailid = user.EmailId;//Course.c_to_address;
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
                                string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
                                sbConfirmEnrollment.Append(confirmILT);
                                Utility.SendEMailMessages(mailAddresses, fromAddress, confirmILTSubject, sbConfirmEnrollment.ToString());
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notificationILT.s_notification_SMS_text;
                                    messagetext = messagetext.Replace("", "");
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
                    else if ((deliveryType == "ILT" || deliveryType == "VLT") && !string.IsNullOrEmpty(waitList))
                    {
                        SystemNotification notificationWaitList = new SystemNotification();
                        notificationWaitList = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-WAITLIST",SessionWrapper.CultureName);
                        if (notificationWaitList.s_notification_on_off_flag == true)
                        {
                            string confirmWaitListSubject = string.Empty;
                            confirmWaitListSubject = notificationWaitList.s_notification_email_subject;
                            confirmWaitListSubject = confirmWaitListSubject.Replace("@$&Course Name&$@({Course ID&$@)", Course.c_course_list);
                            confirmWaitListSubject = confirmWaitListSubject.Replace("@$&User First Name&$@", SessionWrapper.u_firstname);
                            confirmWaitListSubject = confirmWaitListSubject.Replace("@$&User Last Name&$@", SessionWrapper.u_lastname);

                            string confirmWaitlist = string.Empty;
                            confirmWaitlist = notificationWaitList.s_notification_email_text;

                            confirmWaitlist = confirmWaitlist.Replace("@$&User First Name&$@", SessionWrapper.u_firstname);
                            confirmWaitlist = confirmWaitlist.Replace("@$&User Last Name&$@", SessionWrapper.u_lastname);
                            confirmWaitlist = confirmWaitlist.Replace("@$&Course Name&$@(@$&Course ID&$@)", Course.c_course_list);
                            confirmWaitlist = confirmWaitlist.Replace("@$&Delivery Title&$@(@$&Delivery ID&$@)", Course.c_delivery_list);
                            confirmWaitlist = confirmWaitlist.Replace("@$&Session ID(s)&$@", Course.c_session_list);

                            sbConfirmEnrollment.Append(confirmWaitlist);

                            string toEmailid = Course.c_to_address;
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
                                string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// for submite Request from: employeeemailId to admin@compliancefactors.com,owneremailId,coordinatoremailId 
                                //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                                Utility.SendEMailMessages(mailAddresses, fromAddress, confirmWaitListSubject, sbConfirmEnrollment.ToString());
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                                {
                                    StringBuilder smsText = new StringBuilder();
                                    string[] toPhoneNumber = SessionWrapper.u_mobile_number.Split(',');
                                    string username = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                                    string passwd = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);

                                    string messagetext = notificationWaitList.s_notification_SMS_text;
                                    messagetext = messagetext.Replace("", "");
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
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) mesc-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) mesc-01.aspx", ex.Message);
                    }
                }
            }
        }
        private void AddEmployeeRow(string u_user_id_fk, string c_course_id_fk, string c_delivery_id_fk, string u_employee_number, DataTable dtEmployee)
        {
            // Add Category functiong
            DataRow row;
            row = dtEmployee.NewRow();
            row["u_user_id_fk"] = u_user_id_fk;
            row["id"] = c_course_id_fk;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            row["u_employee_number"] = u_employee_number;
            dtEmployee.Rows.Add(row);
        }
        private DataTable AddEmployee(DataTable dtEmployee)
        {

            foreach (GridViewRow grdCategoryRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdCategoryRow.Cells[1].FindControl("chkSelect"));
                //if (chkSelect.Checked == true)
                //{
                AddEmployeeRow(gvsearchDetails.DataKeys[grdCategoryRow.RowIndex].Values[0].ToString(), courseid, deliveryid, string.Empty, dtEmployee);
                //}
            }
            //Remove duplicate employee
            ConvertDataTables removeDuplicateRows = new ConvertDataTables();
            dtEmployee = removeDuplicateRows.RemoveDuplicateRows(dtEmployee, "u_user_id_fk");
            return dtEmployee;

        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < gvsearchDetails.Rows.Count; i++)
            {
                CheckBox chkSelect = (CheckBox)gvsearchDetails.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked == true)
                {
                    string u_user_id_fk = gvsearchDetails.DataKeys[i]["u_user_id_fk"].ToString();
                    var rows = SessionWrapper.Employee.Select("u_user_id_fk= '" + u_user_id_fk.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Employee.AcceptChanges();
                    GetEmployee();
                }
            }


        }

        private void GetEmployee()
        {
            gvsearchDetails.DataSource = SessionWrapper.Employee;
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

    }
}