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
        private string waitList;
        private int approvalCount;
        private int max_enroll;
        private int enrolled_delivery_count;
        protected void Page_Load(object sender, EventArgs e)
        {
            courseid = Request.QueryString["courseid"];
            deliveryid = Request.QueryString["deliveryid"];
            deliveryType = Request.QueryString["deliveryType"];
            c_course_approval = Convert.ToBoolean(Request.QueryString["ca"]);
            c_delivery_approval = Convert.ToBoolean(Request.QueryString["da"]);
            if (!IsPostBack)
            {
                try
                {
                    gvsearchDetails.DataSource = SessionWrapper.Employee;
                    gvsearchDetails.DataBind();
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
                            Logger.WriteToErrorLog("mesc-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("mesc-01.aspx", ex.Message);
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

            //
            DataSet dsDeliveries = SystemCatalogBLL.GetDeliveries(deliveryid);
            //get delivery
            SystemCatalog delivery = new SystemCatalog();
            delivery = SystemCatalogBLL.GetDelivery(deliveryid, dsDeliveries.Tables[0]);
            hdnMe.Value = Convert.ToString(delivery.c_delivery_max_enroll);
            hdEd.Value =delivery.c_enroll_delivery_count;
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
                        Logger.WriteToErrorLog("mesc-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mesc-01.aspx", ex.Message);
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
                SendConfirmationEmail();
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
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message);
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
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ecolt-01.aspx", ex.Message);
                    }
                }
            }
        }
        private void SendConfirmationEmail()
        {
            try
            {

               
                SystemCatalog Course = new SystemCatalog();
                Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryid);
                StringBuilder sbConfirmEnrollment = new StringBuilder();

                //For Couese Title and Course Id
                SystemCatalog courseDetails = new SystemCatalog();
                courseDetails = EnrollmentBLL.GetCourseDetails(deliveryid);

                if (string.IsNullOrEmpty(waitList))
                {
                    SystemNotification notification = new SystemNotification();
                    notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT");
                    if (notification.s_notification_on_off_flag == true)
                    {
                        sbConfirmEnrollment.Append("Hello " + Course.c_created_name + ",");//Doubt which name need to use. Manager Id or User name
                        sbConfirmEnrollment.Append("<br>");
                        sbConfirmEnrollment.Append("This email is to confirm that you are enrolled in the {" + courseDetails.c_course_title + "} + (" + courseDetails.c_course_id_pk + ").)");
                        sbConfirmEnrollment.Append("<br>");
                        if ((deliveryType == "ILT" || deliveryType == "VLT") && string.IsNullOrEmpty(waitList))
                        {
                            sbConfirmEnrollment.Append("Location:" + Course.c_session_location_names + ", " + Course.c_session_facility_names + ", " + Course.c_session_room_names + "");
                            sbConfirmEnrollment.Append("<br>");
                            sbConfirmEnrollment.Append("Instructor(S):" + Course.c_instructor_list);
                            sbConfirmEnrollment.Append("<br>");
                            sbConfirmEnrollment.Append("Starting on:" + Course.c_session_start_date_time);
                            sbConfirmEnrollment.Append("<br>");
                            sbConfirmEnrollment.Append("Ending on:" + Course.c_session_end_date_time);
                            sbConfirmEnrollment.Append("<br>");
                            sbConfirmEnrollment.Append("Please login to the system and go to your 'My Course' section to access the details for this training or launch the course for eLearning Training or simply click on the link below:");
                            sbConfirmEnrollment.Append("<br>");
                            sbConfirmEnrollment.Append("www.compliancefactors.com/login_redirect/?url=lmcp-01.aspx");
                            sbConfirmEnrollment.Append("<br>");
                            sbConfirmEnrollment.Append("We are looking forward to seeing you!");
                        }
                        sbConfirmEnrollment.Append("Thanks!");
                        sbConfirmEnrollment.Append("<br><br>");
                        sbConfirmEnrollment.Append("The Training Department");
                        List<MailAddress> mailAddresses = new List<MailAddress>();
                        mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                        Utility.SendEMailMessage(mailAddresses, "*** Enrollment Confirmation in " + Course.c_course_title + " ***", sbConfirmEnrollment.ToString());
                    }
                }
                else if ((deliveryType == "ILT" || deliveryType == "VLT") && !string.IsNullOrEmpty(waitList))
                {
                    sbConfirmEnrollment.Append(SessionWrapper.u_firstname + ' ' + SessionWrapper.u_lastname + " has sent a request for the following training: ");
                    sbConfirmEnrollment.Append("<br>");
                    sbConfirmEnrollment.Append("Course: " + Course.c_course_list);
                    sbConfirmEnrollment.Append("<br>");
                    sbConfirmEnrollment.Append("Delivery: " + Course.c_delivery_list);
                    sbConfirmEnrollment.Append("<br>");
                    sbConfirmEnrollment.Append("Sessions: " + Course.c_session_list);
                    sbConfirmEnrollment.Append("<br>");
                    string toEmailid = Course.c_to_address;
                    string[] toaddress = toEmailid.Split(',');
                    List<MailAddress> mailAddresses = new List<MailAddress>();
                    foreach (string recipient in toaddress)
                    {
                        if (recipient.Trim() != string.Empty)
                        {
                            mailAddresses.Add(new MailAddress(recipient));
                        }
                    }
                    mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
                    Utility.SendEMailMessage(mailAddresses, "*** Request for " + Course.c_course_list + " from " + SessionWrapper.u_firstname + " " + SessionWrapper.u_lastname, sbConfirmEnrollment.ToString());

                }

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) mese-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("(confirm enroll email) mese-01.aspx", ex.Message);
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
                if (chkSelect.Checked == true)
                {
                    AddEmployeeRow(gvsearchDetails.DataKeys[grdCategoryRow.RowIndex].Values[0].ToString(), courseid, deliveryid, string.Empty, dtEmployee);
                }
            }
            //Remove duplicate employee
            ConvertDataTables removeDuplicateRows = new ConvertDataTables();
            dtEmployee = removeDuplicateRows.RemoveDuplicateRows(dtEmployee, "u_user_id_fk");
            return dtEmployee;

        }

    }
}