using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;
using System.IO;
using ComplicanceFactor.Common.Languages;
using System.Net;
namespace ComplicanceFactor
{
    public partial class EmployeeHome : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(SessionWrapper.u_userid)) && (!string.IsNullOrEmpty(SessionWrapper.sessionid)))
            {
                bool isAccess = SessioninfoBLL.ManageSession(SessionWrapper.u_userid, SessionWrapper.sessionid);

                if (isAccess == true)
                {
                    Session.Abandon();
                    SessionWrapper.clearsession();
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {


            ///<summary>
            ///Store the last visited tab in database
            ///</Summary>
            if (!string.IsNullOrEmpty(SessionWrapper.u_username))
            {              

                try
                {
                    User hmeLastVisisted = new User();

                    if (Path.GetDirectoryName(Request.FilePath) == "\\Employee"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Catalog"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Profile"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Course"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Curricula"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Home"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\LearningHistory")
                    {
                        hmeLastVisisted.lastvisited = "/Employee/Home/lhp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Manager"
                             || Path.GetDirectoryName(Request.FilePath) == "\\Manager\\Profile"
                             || Path.GetDirectoryName(Request.FilePath) == "\\Manager\\Home"
                             || Path.GetDirectoryName(Request.FilePath) == "\\Manager\\Catalog")
                    {
                        hmeLastVisisted.lastvisited = "/Manager/Home/mhp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Compliance"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\HARM"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MIRIS"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\IRIS"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MyDashboard"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MyLicenses"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MySurveys"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MyToDo"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\SiteView"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\SiteView\\FieldNotes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\SiteView\\Ojt")
                    {
                        hmeLastVisisted.lastvisited = "/Compliance/cchp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Instructor")
                    {
                        hmeLastVisisted.lastvisited = "/Instructor/tihp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Training")
                    {
                        hmeLastVisisted.lastvisited = "/Training/tchp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Administrator")
                    {
                        hmeLastVisisted.lastvisited = "/Administrator/tahp-01.aspx";
                    }

                    else if (Path.GetDirectoryName(Request.FilePath) == "\\SystemHome"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\AuditLog"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\BaseConfiguration"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Domains"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\ECommerce"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\ManageUI"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\MyDashboard"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\MyToDo"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Navigation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Notifications"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Reports"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\SecurityRoles"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\SplashPages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\SystemInformation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Users"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\VLS"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Domains"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\EmployeeTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DeliveryTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\FacilityTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\InstructorTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\MaterialTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\ResourceTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\RoomTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Facilities"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Locations"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Materials"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Resources"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Rooms"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Instructor"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Category"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Course"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Completion"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\UpdateCurriculumStatuses"


                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Approvals"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Documents"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\MassCompletions"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\MassEnrollment"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Waitlist"
                       

                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Languages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Navigation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Curriculum"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\ApprovalWorkflows"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\CompletionStatuses"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\CurriculumStatuses"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\CurriculumTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Data Exports"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Data Imports"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DeliveryTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Domains"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\EmployeeTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\FacilityTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\GradingSchemes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Holiday Schedules"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\HRIS Integration"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\InstructorTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Languages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\MaterialTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Navigation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\ResourceTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\RoomTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\UI Texts and Labels"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Weekday Schedules"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Splash Pages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DocumentTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Profile")
                    {
                        hmeLastVisisted.lastvisited = "/SystemHome/sahp-01.aspx";
                    }


                    hmeLastVisisted.Userid = SessionWrapper.u_userid;
                    hmeLastVisisted.currentSessionGuid = SessionWrapper.u_sessionguid;
                    UserBLL.InsertLastVisited(hmeLastVisisted);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("EemployeeHome.Master", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("EemployeeHome.Master", ex.Message);
                        }
                    }
                }


                //btnGo.Text = LocalResources.GetLocaleResourceString("wp_login_button_text");
                // btnLanguages.Text = LocalResources.GetLocaleResourceString("wp_login_button_text");
                // hplHelp.Text = LocalResources.GetLocaleResourceString("app_welcome_text_help");
                ///insert visited tab

                ///access home page/tab based on the security role
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_employee) == true)
                {
                    app_nav_employee.Style.Add("display", "block");

                }
                else
                {
                    app_nav_employee.Style.Add("display", "none");

                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_manager) == true)
                {
                    app_nav_manager.Style.Add("display", "block");

                }
                else
                {
                    app_nav_manager.Style.Add("display", "none");

                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance) == true || Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                {
                    app_nav_compliance.Style.Add("display", "block");
                }
                else
                {
                    app_nav_compliance.Style.Add("display", "none");

                }

                if (Convert.ToBoolean(SessionWrapper.u_sr_is_instructor) == true)
                {
                    app_nav_instructor.Style.Add("display", "block");

                }
                else
                {
                    app_nav_instructor.Style.Add("display", "none");

                }

                if (Convert.ToBoolean(SessionWrapper.u_sr_is_training) == true)
                {
                    app_nav_training.Style.Add("display", "block");
                }
                else
                {

                    app_nav_training.Style.Add("display", "none");

                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_administrator) == true)
                {
                    app_nav_admin.Style.Add("display", "block");

                }
                else
                {
                    app_nav_admin.Style.Add("display", "none");


                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_system_admin) == true)
                {
                    app_nav_system.Style.Add("display", "block");

                }
                else
                {
                    app_nav_system.Style.Add("display", "none");

                }

                lblUsername.Text = " " + SessionWrapper.u_firstname + "!";
                if (!IsPostBack)
                {

                    try
                    {
                        //splash page content
                        SystemSplashPage splashContent = new SystemSplashPage();
                        //Here we can get the splash content based on the domain Id
                        splashContent = SystemSplashPageBLL.GetSplashContent(SessionWrapper.u_domain,SessionWrapper.CultureName);
                        spalsh.InnerHtml = WebUtility.HtmlDecode(splashContent.u_splash_content);
                        //update last selected language
                        User hmelanguage = new User();
                        hmelanguage.selectedlanguage = SessionWrapper.language;
                        hmelanguage.Userid = SessionWrapper.u_userid;
                        UserBLL.Updatelanguage(hmelanguage);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("Main.master", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("Main.master", ex.Message);
                            }
                        }

                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["in"]) && SecurityCenter.DecryptText(Request.QueryString["in"]) == "success")
                    {
                        success_login.Style.Add("display", "block");

                    }

                    DateTime currentDt = DateTime.Now.ToUniversalTime();//Current Converted to UTC
                    currentDt = DateTime.SpecifyKind(currentDt, DateTimeKind.Utc);//Say to runtime that this date is UTC date.

                    /*
                    we can convert between timezones with referance to UTC(GMT) time.
                    .Net Provides TimeZoneInfo class which provides Statis functions to make easy conversion between Time Zones.

                    Though It Takes many arguments ,Key point is ConvertTime method and TimeSpan
                    we can specify TimeSpan as diferance between GMT to EST,GMT to PST etc.
                    */
                    // string strDateTime = TimeZoneInfo.ConvertTime(currentDt, TimeZoneInfo.CreateCustomTimeZone("1", new TimeSpan(-4, 0, 0), "EST", "EST", "EDT", new TimeZoneInfo.AdjustmentRule[] { })).ToString("MM/dd/yyyy - hh:mm:tt");
                    lblDateTime.Text = SessionWrapper.converted_datetime;
                    //foreach (CultureInfo culture in LanguageManager.AvailableCultures)
                    //{
                    //    ddlLanguages.Items.Add(new System.Web.UI.WebControls.ListItem(culture.TextInfo.ToTitleCase(culture.NativeName), culture.Name));
                    //}
                    ddlLanguages.DataSource = SystemLocaleBLL.GetLocaleList();
                    ddlLanguages.DataBind();
                    //ddlLanguages.Items.Add(new System.Web.UI.WebControls.ListItem("English (United States)", "en-US"));
                    // ddlLanguages.Items.Add(new System.Web.UI.WebControls.ListItem("Français (France)", "fr-FR"));
                    if (SessionWrapper.CultureName != null)
                    {
                        ddlLanguages.SelectedValue = SessionWrapper.CultureName;
                        if (ddlLanguages.Items.Count > 0) //make sure there is a SelectedValue
                        {
                            //BasePage bp = new BasePage();

                            //bp.ApplyNewLanguageAndRefreshPage(new CultureInfo(ddlLanguages.SelectedValue));
                            SessionWrapper.language = ddlLanguages.SelectedValue;
                            SessionWrapper.CultureName = ddlLanguages.SelectedValue;
                            //Response.Redirect(Request.Url.AbsoluteUri);

                        }

                    }
                    else
                    {
                        ddlLanguages.SelectedValue = "us_english";
                        SessionWrapper.CultureName = "us_english";
                    }

                }

            }
            else
            {
                Response.Redirect("~/session_out.aspx");

                //Response.Redirect("~/glp-01.aspx");
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Get IP address
            string strIPAddress = string.Empty;
            strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIPAddress == "" || strIPAddress == null)
                strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            try
            {
                Sessioninfo sessioninfo = new Sessioninfo();
                // sessioninfo.sessionend_time = DateTime.Now;
                sessioninfo.sessionguid = SessionWrapper.u_sessionguid;
                SessioninfoBLL.InsertSessionEndTime(sessioninfo);

                //insert audio log on logout
                Auditlog auditlog = new Auditlog();
                auditlog.Guid = Guid.NewGuid().ToString();
                auditlog.Auditid = Guid.NewGuid().ToString();
                auditlog.Userid = SessionWrapper.u_userid;
                auditlog.user_type = SessionWrapper.u_user_type;
                auditlog.user_detail = SessionWrapper.u_lastname + ' ' + SessionWrapper.u_firstname + ' ' + SessionWrapper.u_middlename;
                auditlog.action_desc = "Logout";
                //auditlog.u_datetime = DateTime.Now;
                auditlog.ipaddress = strIPAddress;
                auditlog.device = Request.UserAgent;


                AuditlogBLL.InsertAudit(auditlog);


                User userinfo = new User();
                userinfo.u_is_active = false;
                userinfo.Userid = Session["u_userid"].ToString();
                UserBLL.UpdateLock(userinfo);


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("EmployeeHome.master", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("EmployeeHome.master", ex.Message);
                    }
                }
            }

            Session.Abandon();
            SessionWrapper.clearsession();
            SessionWrapper.CultureName = ddlLanguages.SelectedValue;
            Response.Redirect("~/Default2.aspx?out=" + SecurityCenter.EncryptText("success") + "&locale=" + SecurityCenter.EncryptText(ddlLanguages.SelectedValue));

        }
        protected void btnLanguages_Click(object sender, EventArgs e)
        {
            if (ddlLanguages.Items.Count > 0) //make sure there is a SelectedValue
            {
                BasePage bp = new BasePage();

                //bp.ApplyNewLanguageAndRefreshPage(new CultureInfo(ddlLanguages.SelectedValue));
                SessionWrapper.language = ddlLanguages.SelectedValue;
                SessionWrapper.CultureName = ddlLanguages.SelectedValue;
                //try
                //{
                //    User hmelanguage = new User();
                //    hmelanguage.selectedlanguage = SessionWrapper.language;
                //    hmelanguage.Userid = SessionWrapper.u_userid;
                //    UserBLL.Updatelanguage(hmelanguage);
                //}
                //catch (Exception ex)
                //{
                //    if (ConfigurationWrapper.LogErrors == true)
                //    {
                //        if (ex.InnerException != null)
                //        {
                //            Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                //        }
                //        else
                //        {
                //            Logger.WriteToErrorLog("CFHome.master", ex.Message);
                //        }
                //    }

                //}


                Response.Redirect(Request.Url.ToString());
            }
        }


    }
}