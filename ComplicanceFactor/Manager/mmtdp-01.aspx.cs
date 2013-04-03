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
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace ComplicanceFactor.Manager
{
    public partial class mmtdp_01 : System.Web.UI.Page
    {
        #region
        private string e_enroll_system_id_pk;
        private string todo_system_id_pk;
        private string delivery_id;
        private string e_enroll_user_id_fk;
        private string e_enroll_course_id_fk;
        #endregion

        DataSet dsManager = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>" + " >&nbsp;" + "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manager_pod_mtodo_title");
            if (!IsPostBack)
            {
                GetToDo();
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
                denyEmailConfirmation(delivery_id, e_enroll_user_id_fk);
            }
           

            
        }

        private void GetToDo()
        {
            if (!String.IsNullOrEmpty(SessionWrapper.u_userid))
            {
                DataSet dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
                //bind todos
                gvToDo.DataSource = dsManager.Tables[0];
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
                if (gvToDo.Rows.Count == 0 || gvToDo.Rows.Count == 1)
                {
                    btnApproveAll.Visible = false;
                    btnDenyAll.Visible = false;
                }
            }
        }

        protected void btnDenyAll_Click(object sender, EventArgs e)
        {
            try
            {

                dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
                DataTable dtTodo = dsManager.Tables[0];
                for (int i = 0; i <= dtTodo.Rows.Count - 1; i++)
                {
                    e_enroll_course_id_fk = dtTodo.Rows[i]["id"].ToString();
                    e_enroll_system_id_pk = dtTodo.Rows[i]["enroll_system_id_pk"].ToString();
                    todo_system_id_pk = dtTodo.Rows[i]["todo_system_id_pk"].ToString();
                    delivery_id = dtTodo.Rows[i]["delivery_id"].ToString();
                    e_enroll_user_id_fk = dtTodo.Rows[i]["e_enroll_user_id_fk"].ToString();
                    int result = EnrollmentBLL.DenyEnrollment(e_enroll_system_id_pk, todo_system_id_pk);
                    denyEmailConfirmation(delivery_id, e_enroll_user_id_fk);
                    GetToDo();
                    btnDenyAll.Visible = false;
                    btnApproveAll.Visible = false;
                }

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mhp-01 (Deny All)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mhp-01 (Deny All)", ex.Message);
                    }
                }
            }

        }

        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            try
            {

                dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
                DataTable dtTodo = dsManager.Tables[0];
                for (int i = 0; i <= dtTodo.Rows.Count - 1; i++)
                {
                    e_enroll_course_id_fk = dtTodo.Rows[i]["id"].ToString();
                    e_enroll_system_id_pk = dtTodo.Rows[i]["enroll_system_id_pk"].ToString();
                    todo_system_id_pk = dtTodo.Rows[i]["todo_system_id_pk"].ToString();
                    delivery_id = dtTodo.Rows[i]["delivery_id"].ToString();
                    e_enroll_user_id_fk = dtTodo.Rows[i]["e_enroll_user_id_fk"].ToString();
                    int result = EnrollmentBLL.UpdateApprovalsTodos(e_enroll_system_id_pk, todo_system_id_pk);
                    ApproveEmailConfirmation(delivery_id, e_enroll_user_id_fk);
                    GetToDo();
                    btnDenyAll.Visible = false;
                    btnApproveAll.Visible = false;
                }

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("mhp-01 (Approve All)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("mhp-01 (Approve All)", ex.Message);
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
            notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CANCELED");//Enroll-Approval-Denied
            if (notification.s_notification_on_off_flag == true)
            {
                sbConfirmEnrollment.Append("Hello " + user.Firstname + ",");
                sbConfirmEnrollment.Append("<br>");
                sbConfirmEnrollment.Append("This email is to confirm that you are denied in the {" + Course.c_course_title + "} + (" + Course.c_course_id_pk + ").) by " + SessionWrapper.u_username);
                sbConfirmEnrollment.Append("<br>");
                sbConfirmEnrollment.Append("Thanks!");
                sbConfirmEnrollment.Append("<br><br>");
                sbConfirmEnrollment.Append("The Training Department");
                List<MailAddress> mailAddresses = new List<MailAddress>();
                mailAddresses.Add(new MailAddress(user.EmailId));
                string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                Utility.SendEMailMessages(mailAddresses, fromaddress, "*** Enrollment denied in " + Course.c_course_title + " ***", sbConfirmEnrollment.ToString());
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


            sbConfirmEnrollment.Append("Hello " + user.Firstname + ",");
            sbConfirmEnrollment.Append("<br>");
            sbConfirmEnrollment.Append("This email is to confirm that you are enrolled in the {" + Course.c_course_title + "} + (" + Course.c_course_id_pk + ")).");
            sbConfirmEnrollment.Append("<br>");
            if ((type == "ILT" || type == "VLT"))
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
            mailAddresses.Add(new MailAddress(user.EmailId));
            string fromAddress = (ConfigurationManager.AppSettings["FROMMAIL"]);// For controlment from:admin@compliancefactors.com to:employee id
            //mailAddresses.Add(new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]));
            Utility.SendEMailMessages(mailAddresses, fromAddress, "*** Enrollment Confirmation Approved in " + Course.c_course_title + " ***", sbConfirmEnrollment.ToString());

        }
    }
}