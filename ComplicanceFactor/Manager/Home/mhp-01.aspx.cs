using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Configuration;
namespace ComplicanceFactor.Manager
{
    public partial class mhp_01 : BasePage
    {
        DataSet dsManager = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                HtmlGenericControl divsearch = (HtmlGenericControl)Master.FindControl("divsearch");
                divsearch.Style.Add("display", "block");
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = LocalResources.GetGlobalLabel("app_nav_manager") + " > ...";
                // GetAllCourse();
                //set todo recored display pref
                if (SessionWrapper.u_profile_my_todos_records_display_pref != 0)
                {
                    gvToDo.AllowPaging = true;
                    gvToDo.PageSize = SessionWrapper.u_profile_my_todos_records_display_pref;
                }
                //GetAllEmployee();
                //expand and collapsed based on user for todo
                if (SessionWrapper.u_profile_my_todos_collapse_pref == "app_ddl_collapsed")
                {
                    div_to_do.Style.Add("display", "none");
                    imgToDo.ImageUrl = "~/Images/addplus-sm.gif";
                    imgToDo.AlternateText = "plus";
                }
                else
                {
                    div_to_do.Style.Add("display", "block");
                    imgToDo.ImageUrl = "~/Images/addminus-sm.gif";
                    imgToDo.AlternateText = "minus";
                }
                //expand and collapsed based on user for team
                if (SessionWrapper.u_profile_my_team_collapse_pref == "app_ddl_collapsed")
                {
                    div_team.Style.Add("display", "none");
                    imgTeam.ImageUrl = "~/Images/addplus-sm.gif";
                    imgTeam.AlternateText = "plus";
                }
                else
                {
                    div_team.Style.Add("display", "block");
                    imgTeam.ImageUrl = "~/Images/addminus-sm.gif";
                    imgTeam.AlternateText = "minus";
                }
                //Bind all (Todo,Team and report)
                BindToDo_Team_Report();
            }

            //go button
            Button btnGo = (Button)Master.FindControl("btnGo");
            btnGo.Click += new EventHandler(btnGo_Click);
            //advanced search
            LinkButton lnkAdvancedSearch = (LinkButton)Master.FindControl("lnkAdvancedSearch");
            lnkAdvancedSearch.Click += new EventHandler(lnkAdvancedSearch_Click);
            //browse
            LinkButton lnkBrowse = (LinkButton)Master.FindControl("lnkBrowse");
            lnkBrowse.Click += new EventHandler(lnkBrowse_Click);

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            TextBox txtQuickSearch = (TextBox)Master.FindControl("txtQuickSearch");
            Response.Redirect("~/Manager/Catalog/qscr-01.aspx?Keyword=" + SecurityCenter.EncryptText(txtQuickSearch.Text), false);
        }
        protected void lnkAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/ascp-01.aspx", false);
        }

        protected void lnkBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Catalog/bchp-01.aspx", false);
        }
        private void BindToDo_Team_Report()
        {
            
            dsManager = EnrollmentBLL.GetToDos(SessionWrapper.u_userid);
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
        }

        protected void gvToDo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Approve"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string approvar_system_id = gvToDo.DataKeys[index].Values[1].ToString();
                string todo_id = gvToDo.DataKeys[index].Values[2].ToString();
                string deliveryId = gvToDo.DataKeys[index].Values[4].ToString();
                string e_enroll_user_id_fk = gvToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.UpdateApprovalsTodos(approvar_system_id,todo_id);

                SystemCatalog Course = new SystemCatalog();
                Course = SystemCatalogBLL.GetSingleDeliveryList(deliveryId);
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
                    
                //update the enrollment approval table(approval flag,approval date)                
                //if it's approve means delele the current todo and create the todo for the 3rd level.
                //Check its 3rd level approver means change the status of the enrollment and delete the todo.
            }
            else if (e.CommandName.Equals("Deny"))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string approval_id = gvToDo.DataKeys[index].Values[1].ToString();
                string todo_id = gvToDo.DataKeys[index].Values[2].ToString();
                string courseId = gvToDo.DataKeys[index].Values[0].ToString();
                string deliveryId = gvToDo.DataKeys[index].Values[4].ToString();
                string e_enroll_user_id_fk = gvToDo.DataKeys[index].Values[3].ToString();
                int result = EnrollmentBLL.DenyEnrollment(approval_id, todo_id);
                //send Enrollment denial Email and Sms

                SystemCatalog Course = new SystemCatalog();
                Course = EnrollmentBLL.GetCourseDetails(deliveryId);

                //user name
                User user = new User();
                user = UserBLL.GetUserInfo_by_id(e_enroll_user_id_fk);


                StringBuilder sbConfirmEnrollment = new StringBuilder();

                SystemNotification notification = new SystemNotification();
                notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CANCELED");//Enroll-Approval-Denied
                if (notification.s_notification_on_off_flag == true)
                {
                    sbConfirmEnrollment.Append("Hello " + user.Firstname + ",");
                    sbConfirmEnrollment.Append("<br>");
                    sbConfirmEnrollment.Append("This email is to confirm that you are denied in the {" + Course.c_course_title + "} + (" + Course.c_course_id_pk + ").) by "+SessionWrapper.u_username);
                    sbConfirmEnrollment.Append("<br>");
                    sbConfirmEnrollment.Append("Thanks!");
                    sbConfirmEnrollment.Append("<br><br>");
                    sbConfirmEnrollment.Append("The Training Department");
                    List<MailAddress> mailAddresses = new List<MailAddress>();
                    mailAddresses.Add(new MailAddress(user.EmailId));
                    string fromaddress = (ConfigurationManager.AppSettings["FROMMAIL"]);
                    Utility.SendEMailMessages(mailAddresses, fromaddress,"*** Enrollment denied in " + Course.c_course_title + " ***", sbConfirmEnrollment.ToString());
                }

            }
            else if (e.CommandName.Equals("DenyAll"))
            {
                //DataTable dtGetAllEnrolluserid = new DataTable();
                //DataView dvPathEnrollId = new DataView(dsManager.Tables[0]);
                //dvPathEnrollId.RowFilter = "e_enroll_user_id_fk";
                //dtGetAllEnrolluserid = dvPathEnrollId.ToTable();
                //ConvertDataTables convertDataToXml = new ConvertDataTables();
                //string allEnrollUserId = convertDataToXml.ConvertDataTableToXml(dsManager.Tables[0]);
            }

            BindToDo_Team_Report();
        }

        protected void gvToDo_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }



    }
}