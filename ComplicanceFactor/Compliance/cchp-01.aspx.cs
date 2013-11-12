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
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Net;
namespace ComplicanceFactor.Compliance
{
    public partial class cchp_01 : BasePage
    {
        DataSet dsSearch = new DataSet();
        private static string caseNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                                Logger.WriteToErrorLog("cchp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cchp-01.aspx", ex.Message);
                            }
                        }
                    }
                }

                SessionWrapper.navigationText = "app_nav_compliance";
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>" + " > " + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>";
                gvharmDetails.AllowPaging = true;
                gvMyGiris.AllowPaging = true;
                gvMyToDo.AllowPaging = true;
            

                if (SessionWrapper.u_profile_my_comp_todos_display_pref == 0)
                {
                    gvMyToDo.AllowPaging = false;
                }
                else
                {
                    gvMyToDo.PageSize = SessionWrapper.u_profile_my_comp_todos_display_pref;
                }

                if (SessionWrapper.u_profile_my_comp_harm_display_pref == 0)
                {
                    gvharmDetails.AllowPaging = false;
                }
                else
                {
                    gvharmDetails.PageSize = SessionWrapper.u_profile_my_comp_harm_display_pref;
                }

              

                if (SessionWrapper.u_profile_my_comp_giris_display_pref == 0)
                {
                    gvMyGiris.AllowPaging = false;
                }
                else
                {
                    gvMyGiris.PageSize = SessionWrapper.u_profile_my_comp_giris_display_pref;
                }

                if (SessionWrapper.u_profile_my_comp_todos_collapse_pref == "app_ddl_collapsed")
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
                if (SessionWrapper.u_profile_my_comp_harm_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyHarm.Style.Add("display", "none");
                    imgMyHarm.ImageUrl = "~/Images/addplus-sm.gif";
                    imgMyHarm.AlternateText = "plus";

                }
                else
                {
                    div_MyHarm.Style.Add("display", "block");
                    imgMyHarm.ImageUrl = "~/Images/addminus-sm.gif";
                    imgMyHarm.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_comp_giris_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyGiris.Style.Add("display", "none");
                    imgMyGiris.ImageUrl = "~/Images/addplus-sm.gif";
                    imgMyGiris.AlternateText = "plus";

                }
                else
                {
                    div_MyGiris.Style.Add("display", "block");
                    imgMyGiris.ImageUrl = "~/Images/addminus-sm.gif";
                    imgMyGiris.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_comp_reports_collapse_pref == "app_ddl_collapsed")
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
                BindDetails();
            }
        }
        private void BindDetails()
        {
            //Compliance Approver
            ddlComplianceApprover.DataSource = UserBLL.GetComplianceApproverList();
            ddlComplianceApprover.DataBind();

            dsSearch = ComplianceBLL.GetTodoHarmGirisReport(SessionWrapper.u_userid);
            gvMyToDo.DataSource = dsSearch.Tables[0];
            gvMyToDo.DataBind();
            gvMyToDo.UseAccessibleHeader = true;
            if (gvMyToDo.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvMyToDo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            gvharmDetails.DataSource = dsSearch.Tables[1];
            gvharmDetails.DataBind();
            gvharmDetails.UseAccessibleHeader = true;
            if (gvharmDetails.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvharmDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            gvMyGiris.DataSource = dsSearch.Tables[2];
            gvMyGiris.DataBind();
            gvMyGiris.UseAccessibleHeader = true;
            if (gvMyGiris.HeaderRow != null)
            {
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                gvMyGiris.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            BindReportGrid();
        }
        private void BindReportGrid()
        {

            SystemReport report = new SystemReport();
            report.s_report_id_pk = "";
            report.s_report_name = "";
            report.s_report_type_id_fk = "";
            try
            {
                DataTable dtReport = new DataTable();
                report.s_report_on_off_flag = true;
                dtReport = SystemReportBLL.SearchReport(report);
                dtReport.Columns.Add("s_report_name_id");
                foreach (DataRow row in dtReport.Rows)
                {
                    row["s_report_name_id"] = row["s_report_name"] + " (" + row["s_report_id_pk"] + ")";
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
                        Logger.WriteToErrorLog("cchp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cchp-01.aspx", ex.Message);
                    }
                }
            }
        }
       
        protected void gvharmDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmId = gvharmDetails.DataKeys[rowIndex][0].ToString();
                Response.Redirect("~/Compliance/HARM/cceharm-01.aspx?Edit=" + SecurityCenter.EncryptText(harmId));
            }
            else if (e.CommandName == "Copy")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmId = gvharmDetails.DataKeys[rowIndex][0].ToString();
                Response.Redirect("~/Compliance/HARM/cccharm-01.aspx?Copy=" + SecurityCenter.EncryptText(harmId));
            }

            else if (e.CommandName == "Approve")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string harmId = gvharmDetails.DataKeys[rowIndex][0].ToString();
                try
                {
                    ComplianceDAO harm = new ComplianceDAO();
                    harm.h_harm_id_pk = harmId;
                    ComplianceBLL.UpdateHarmStatus(harm);
                    BindDetails();
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("cchp-01", ex.Message);
                        }
                    }
                }
            }
        }

        protected void gvharmDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvMyGiris_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvMyGiris.DataKeys[rowIndex][0].ToString();
                string caseStatus = gvMyGiris.DataKeys[rowIndex][1].ToString();
                string caseCategory = gvMyGiris.DataKeys[rowIndex][2].ToString();
                caseCategory = caseCategory.Substring(0, 2);

                if (caseCategory == "OI")
                {
                    //code for closed and Redirect to Edit page
                    if (caseStatus == "Closed")
                    {
                        string strNewCaseId = Guid.NewGuid().ToString();
                        try
                        {
                            ComplianceBLL.CreateCaseOnCompleteOI(caseId, strNewCaseId);
                            Response.Redirect("~/Compliance/MIRIS/ceoi-01.aspx?Edit=" + SecurityCenter.EncryptText(strNewCaseId), false);
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("cchp-01", ex.Message);
                                }
                            }

                        }

                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ceoi-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId), false);
                    }

                }
                else if (caseCategory == "MV")
                {
                    //code for Motor Vehicle closed and Redirect to Edit page 
                    if (caseStatus == "Closed")
                    {
                        string strNewCaseId = Guid.NewGuid().ToString();
                        try
                        {
                            ComplianceBLL.CreateCaseOnCompleteMV(caseId, strNewCaseId);
                            Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(strNewCaseId), false);
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("cchp-01", ex.Message);
                                }
                            }

                        }

                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/cemv-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId), false);
                    }
                }
                else
                {
                    //int rowIndex = int.Parse(e.CommandArgument.ToString());
                    //string caseId = gvsearchDetails.DataKeys[rowIndex][0].ToString();
                    //string caseStatus = gvsearchDetails.DataKeys[rowIndex][1].ToString();
                    if (caseStatus == "Closed")
                    {
                        string strNewCaseId = Guid.NewGuid().ToString();
                        try
                        {
                            ComplianceBLL.CreateCaseOnComplete(caseId, strNewCaseId);
                            Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(strNewCaseId), false);
                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("cchp-01", ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Compliance/MIRIS/ccemiris-01.aspx?Edit=" + SecurityCenter.EncryptText(caseId), false);
                    }
                }

            }
            else if (e.CommandName == "Copy")
            {
                ComplianceDAO miris = new ComplianceDAO();
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string caseId = gvMyGiris.DataKeys[rowIndex][0].ToString();
                string caseStatus = gvMyGiris.DataKeys[rowIndex][1].ToString();
                string caseCategory = gvMyGiris.DataKeys[rowIndex][2].ToString();
                caseCategory = caseCategory.Substring(0, 2);
                if (caseCategory == "OI")
                {
                    try
                    {
                        miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message);
                            }
                        }
                    }
                    Response.Redirect("~/Compliance/MIRIS/coi-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                else if (caseCategory == "MV")
                {
                    try
                    {
                        miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message);
                            }
                        }
                    }
                    Response.Redirect("~/Compliance/MIRIS/cmv-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);

                }
                else
                {
                    try
                    {
                        miris = ComplianceBLL.GetCaseId(caseCategory, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message);
                            }
                        }
                    }
                    Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId) + "&id=" + SecurityCenter.EncryptText(miris.c_case_number), false);
                }
                //Response.Redirect("~/Compliance/MIRIS/ccamiris-01.aspx?Copy=" + SecurityCenter.EncryptText(caseId), false);
            }
            else if (e.CommandName == "Close")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                {

                    string caseId = gvMyGiris.DataKeys[rowIndex][0].ToString();
                    try
                    {
                        ComplianceDAO miris = new ComplianceDAO();
                        miris.c_case_id_pk = caseId;
                        miris.c_case_status = "close";
                        ComplianceBLL.UpdateCaseStatus(miris);
                        BindDetails();
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("cchp-01", ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    caseNumber = gvMyGiris.DataKeys[rowIndex][2].ToString();
                    mpCompleteCase.Show();
                }
            }
        }

        protected void gvMyGiris_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User approverInfo = new User();
            approverInfo = UserBLL.GetApprovalNameandEmail(ddlComplianceApprover.SelectedValue.ToString());

            string toEmailid = approverInfo.EmailId;
            toEmailid = "compliancefactor.project@gmail.com";
            //"compliancefactor.project@gmail.com";
            string[] toaddress = toEmailid.Split(',');
            List<MailAddress> mailAddresses = new List<MailAddress>();
            foreach (string recipient in toaddress)
            {
                if (recipient.Trim() != string.Empty)
                {
                    mailAddresses.Add(new MailAddress(recipient));
                }
            }
            try
            {
                StringBuilder sbCompleteCase = new StringBuilder();
                sbCompleteCase.Append("Hello " + approverInfo.Username + ",");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("This email is to change the case as completed case.");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append("I sent the request to you for change this " + caseNumber + " to Complete Case.");
                sbCompleteCase.Append("<br><br>");
                sbCompleteCase.Append("by");
                sbCompleteCase.Append("<br>");
                sbCompleteCase.Append(SessionWrapper.u_username);
                Utility.SendEMailMessage(mailAddresses, "***Request for Complete Case***", sbCompleteCase.ToString());
                success_msg.Style.Add("display", "block");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "Request Was Send Successfully to" + " " + approverInfo.Username;
                caseNumber = string.Empty;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cchp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cchp-01", ex.Message);
                    }
                }
            }
        }

        protected void gvMyGiris_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewCaseDescription = (Button)e.Row.FindControl("btnViewCaseDescription");
                string caseId = gvMyGiris.DataKeys[e.Row.RowIndex][0].ToString();
                string caseCategory = gvMyGiris.DataKeys[e.Row.RowIndex][2].ToString();
                caseCategory = caseCategory.Substring(0, 2);

                if (caseCategory == "OI")
                {
                    btnViewCaseDescription.OnClientClick = "window.open('MIRIS/cvoi-01.aspx?View=" + SecurityCenter.EncryptText(caseId) + "','',''); return true;";
                }
                else if (caseCategory == "MV")
                {
                    btnViewCaseDescription.OnClientClick = "window.open('MIRIS/cvmv-01.aspx?View=" + SecurityCenter.EncryptText(caseId) + "','',''); return true;";
                }
                else
                {
                    btnViewCaseDescription.OnClientClick = "window.open('MIRIS/ccvmiris-01.aspx?View=" + SecurityCenter.EncryptText(caseId) + "','',''); return true;";
                }
            }
        }

        protected void gvharmDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnViewCaseDescription = (Button)e.Row.FindControl("btnView");
                string harmId = gvharmDetails.DataKeys[e.Row.RowIndex][0].ToString();
                btnViewCaseDescription.OnClientClick = "window.open('HARM/ccvharm-01.aspx?View=" + SecurityCenter.EncryptText(harmId) + "','',''); return true;";
            }
        }

        protected void lnkViewAllHARM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/HARM/ccasharm-01.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MIRIS/cccmiris-01.aspx");
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
        // if (type == "OLT")
        // {
        //     SystemNotification notification = new SystemNotification();
        //     notification = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-OLT",SessionWrapper.CultureName);
        //     //if (notification.s_notification_on_off_flag == true)
        //     //{
        //     //Enroll OLT
        //     string confirmOLTSubject = string.Empty;
        //     confirmOLTSubject = notification.s_notification_email_subject;
        //     confirmOLTSubject = confirmOLTSubject.Replace("@$&Course Title&$@", Course.c_course_title);

        //     string sbConfirmOLT = string.Empty;
        //     sbConfirmOLT = notification.s_notification_email_text;

        //     sbConfirmOLT = sbConfirmOLT.Replace("@$&User First Name&$@", user.Firstname);
        //     sbConfirmOLT = sbConfirmOLT.Replace("@$&Course Name&$@", Course.c_course_title);
        //     sbConfirmOLT = sbConfirmOLT.Replace("@$&Course ID&$@", Course.c_course_id_pk);

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
        //         sbConfirmEnrollment.Append(sbConfirmOLT);
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
        //     // }
        // }

        ////Enroll ILT/VLT
        // else if ((type == "ILT" || type == "VLT"))
        // {
        //     SystemNotification notificationILT = new SystemNotification();
        //     notificationILT = SystemNotificationBLL.GetSingleNotificationbyId("ENROLL-CONFIRM-IN-PERSON",SessionWrapper.CultureName);
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
        //     // }
        // }
        //}

        //}

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
            BindDetails();
        }

        protected void lnkViewAllToDos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/MyToDo/ccmtdp-01.aspx", false);
        }

        protected void lnkViewAllMyReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Compliance/ccmrp-01.aspx", false);
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
                        Logger.WriteToErrorLog("cchp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cchp-01.aspx", ex.Message);
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