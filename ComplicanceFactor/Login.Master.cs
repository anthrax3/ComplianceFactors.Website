using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Reflection;
using System.Security;
using System.Globalization;
using ComplicanceFactor.Common.Languages;
using System.Web.Security;



namespace ComplicanceFactor
{
    public partial class Main : System.Web.UI.MasterPage
    {
        #region Private member variable
        private string plainText = "";    // original plaintext
        private string cipherText = "";                 // encrypted text
        private string passPhrase = "Pas5pr@ej";      // can be any string
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now;
                //successfully logout message
                if (!string.IsNullOrEmpty(Request.QueryString["out"]) && SecurityCenter.DecryptText(Request.QueryString["out"]) == "success")
                {
                    success_logout.Style.Add("display", "block");

                }
                //session expire message
                if (!string.IsNullOrEmpty(Request.QueryString["expire"]) && SecurityCenter.DecryptText(Request.QueryString["expire"]) == "true")
                {
                    expire_message.Style.Add("display", "block");

                }
                //bind language dropdownlist

                ddlLanguages.DataSource = SystemLocaleBLL.GetLocaleList();
                ddlLanguages.DataBind();
                //foreach (CultureInfo culture in LanguageManager.AvailableCultures)
                //{
                //    ddlLanguages.Items.Add(new ListItem(culture.TextInfo.ToTitleCase (culture .NativeName ), culture.Name));
                //}
                //maintain last language selected by user
                if (!string.IsNullOrEmpty(Request.QueryString["locale"]) && string.IsNullOrEmpty(SessionWrapper.CultureName))
                {
                    ddlLanguages.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["locale"]);
                    //    ddlLanguages.SelectedValue = SecurityCenter.DecryptText(Request.QueryString["locale"]);
                    //    if (ddlLanguages.Items.Count > 0) //make sure there is a SelectedValue
                    //    {
                    //        BasePage bp = new BasePage();
                    //        //bp.ApplyNewLanguageAndRefreshPage(new CultureInfo(ddlLanguages.SelectedValue));
                    //        SessionWrapper.language = ddlLanguages.SelectedValue;
                    SessionWrapper.CultureName = ddlLanguages.SelectedValue;

                }
                else if (!string.IsNullOrEmpty(SessionWrapper.CultureName))
                {
                    ddlLanguages.SelectedValue = SessionWrapper.CultureName;
                }
                GetMenu(ddlLanguages.SelectedValue);
                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(SessionWrapper.CultureName))
                //    {
                //        ddlLanguages.SelectedValue = SessionWrapper.CultureName;
                //    }
                //    else
                //    {
                //        SessionWrapper.CultureName = "us_english";
                //    }

                //}

            }
            //if user closed browser without logging out and user can back to last access page.
            if (Session["u_userid"] != null)
            {
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_employee) == true)
                    Response.Redirect("~/Employee/lhp-01.aspx");

                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_manager) == true)
                    Response.Redirect("~/Manager/mhp-01.aspx", false);

                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance) == true || Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                    Response.Redirect("~/Compliance/cchp-01.aspx", false);

                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_instructor) == true)
                    Response.Redirect("~/Instructor/ihp-01.aspx", false);

                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_training) == true)
                    Response.Redirect("~/Training/tchp-01.aspx", false);

                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_administrator) == true)
                    Response.Redirect("~/Administrator/tahp-01.aspx", false);

                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_system_admin) == true)
                    Response.Redirect("~/SystemHome/sahp-01.aspx", false);
            }


        }

        private void GetMenu(string locale)
        {
            DataTable dtNavigation = NavigationBLL.GetWebNavigation(locale);
            DataRow[] drowpar = dtNavigation.Select("s_web_nav_parent_id IS NULL");
            foreach (DataRow dr in drowpar)
            {
                menuWeb.Items.Add(new MenuItem(dr["s_web_nav_label_name"].ToString(), dr["s_web_nav_system_id_pk"].ToString(),
                "", dr["s_web_nav_url"].ToString()));
            }
            foreach (DataRow dr in dtNavigation.Select("s_web_nav_parent_id <> '" + string.Empty + "'"))
            {
                MenuItem mnu = new MenuItem(dr["s_web_nav_label_name"].ToString(), dr["s_web_nav_system_id_pk"].ToString(),
                "", dr["s_web_nav_url"].ToString());
                menuWeb.FindItem(dr["s_web_nav_parent_id"].ToString()).ChildItems.Add(mnu);
            }
            //menuWeb.Items[0].Selected = true;

        }


        protected void btnGo_Click(object sender, EventArgs e)
        {

            // Generate hash password and username
            HashEncryption encHash = new HashEncryption();
            string encHashpwd = encHash.GenerateHashvalue(txtPassWord.Text, true);
            string encHasusername = encHash.GenerateHashvalue(txtUserName.Text, true);
            User home = new User();
            home.Username = encHasusername;
            home.Password_enc_ash = encHashpwd;
            User userLogin = new User();
            try
            {
                userLogin = UserBLL.GetUserLock(encHasusername);

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("CFHome.master", ex.Message);
                    }
                }
            }

            if (userLogin.Userid != null)
            {
                try
                {
                    SessioninfoBLL.UnlockTimeout(userLogin.Userid);
                    userLogin = UserBLL.GetUserLock(encHasusername);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("CFHome.master", ex.Message);
                        }
                    }
                }

                if (userLogin.u_is_active == false || !string.IsNullOrEmpty(SessionWrapper.u_username))
                {
                    try
                    {

                        userLogin = UserBLL.GetUserInfo_by_username(encHasusername);
                        //dtLogin = UserBLL.Getuser(home);
                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("CFHome.master", ex.Message);
                            }
                        }
                    }



                    if (userLogin.Username_enc_ash != "")
                    {

                        bool saltpass = false;
                        try
                        {
                            saltpass = Passwordvalidate(txtPassWord.Text, userLogin.Password_enc_salt);
                        }
                        catch (Exception ex)
                        {
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("CFHome.master", ex.Message);
                                }
                            }
                        }
                        if ((string)userLogin.Username_enc_ash == encHasusername && saltpass == true && (string)userLogin.Password_enc_ash == encHashpwd && Convert.ToBoolean(userLogin.Active_status_flag) == true)
                        {
                            if (string.IsNullOrEmpty(SessionWrapper.language))
                            {
                                SessionWrapper.language = userLogin.s_locale_culture;
                            }
                            SessionWrapper.u_userid = userLogin.Userid;
                            //This session is used to restrict the multiple user using same credentials
                            Session["u_userid"] = SessionWrapper.u_userid;
                            userLogin.Userid = Session["u_userid"].ToString();
                            userLogin.u_is_active = true;
                            UserBLL.UpdateLock(userLogin);
                            SessionWrapper.u_username = userLogin.Firstname + " " + userLogin.Lastname;
                            SessionWrapper.u_firstname = userLogin.Firstname;
                            SessionWrapper.u_middlename = userLogin.Middlename;
                            SessionWrapper.u_lastname = userLogin.Lastname;
                            SessionWrapper.sessionid = Session.SessionID;
                            SessionWrapper.u_domain = userLogin.DomainId;
                            SessionWrapper.u_locale = userLogin.LocaleId;
                            SessionWrapper.u_timezone = userLogin.TimezoneId;
                            SessionWrapper.TimeZoneLocatoin = userLogin.u_timezone_location;
                            SessionWrapper.u_user_type = userLogin.Usertype;
                            SessionWrapper.u_sr_is_employee = userLogin.sr_is_employee;
                            SessionWrapper.u_sr_is_manager = userLogin.sr_is_manager;
                            SessionWrapper.u_sr_is_compliance = userLogin.sr_is_compliance;
                            SessionWrapper.u_sr_is_instructor = userLogin.sr_is_instructor;
                            SessionWrapper.u_sr_is_training = userLogin.sr_is_training;
                            SessionWrapper.u_sr_is_administrator = userLogin.sr_is_administrator;
                            SessionWrapper.u_sr_is_system_admin = userLogin.sr_is_system_admin;
                            SessionWrapper.u_sr_is_compliance_approver = userLogin.sr_is_compliance_approver;
                            SessionWrapper.u_email_id = userLogin.EmailId;
                            SessionWrapper.u_mobile_number = userLogin.MobileNumber;
                            SessionWrapper.u_profile_my_courses_collapse_pref = userLogin.u_profile_my_courses_collapse_pref;
                            SessionWrapper.u_profile_my_curricula_collapse_pref = userLogin.u_profile_my_curricula_collapse_pref;
                            SessionWrapper.u_profile_my_learning_history_collapse_pref = userLogin.u_profile_my_learning_history_collapse_pref;
                            SessionWrapper.u_profile_my_courses_records_display_pref = userLogin.u_profile_my_courses_records_display_pref;
                            SessionWrapper.u_profile_my_curricula_records_display_pref = userLogin.u_profile_my_curricula_records_display_pref;
                            SessionWrapper.u_profile_my_learning_history_records_display_pref = userLogin.u_profile_my_learning_history_records_display_pref;
                            //SessionWrapper.CultureName = userLogin.CultureName;

                            home.lastvisited = userLogin.lastvisited;
                            string roles = userLogin.text_sr_is_employee + userLogin.text_sr_is_manager +
                              userLogin.text_sr_is_compliance + userLogin.text_sr_is_instructor + userLogin.text_sr_is_training +
                              userLogin.text_sr_is_administrator + userLogin.text_sr_is_system_admin;
                            try
                            {
                                //Get IP address
                                string strIPAddress = string.Empty;
                                strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                if (strIPAddress == "" || strIPAddress == null)
                                    strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
                                //insert audio log on login
                                Auditlog auditlog = new Auditlog();
                                auditlog.Guid = Guid.NewGuid().ToString();
                                auditlog.Auditid = Guid.NewGuid().ToString();
                                auditlog.Userid = SessionWrapper.u_userid;
                                auditlog.user_type = SessionWrapper.u_user_type;
                                auditlog.user_detail = SessionWrapper.u_lastname + ' ' + SessionWrapper.u_firstname + ' ' + SessionWrapper.u_middlename;
                                auditlog.action_desc = "Login";
                                //auditlog.u_datetime = DateTime.Now;
                                auditlog.ipaddress = strIPAddress;
                                auditlog.device = Request.UserAgent;
                                AuditlogBLL.InsertAudit(auditlog);
                                //insert session information
                                Sessioninfo sessioninfo = new Sessioninfo();
                                SessionWrapper.u_sessionguid = Guid.NewGuid().ToString();
                                Session["sessionguid"] = SessionWrapper.u_sessionguid;
                                sessioninfo.sessionguid = SessionWrapper.u_sessionguid;
                                sessioninfo.userid = SessionWrapper.u_userid;
                                sessioninfo.sessionid = SessionWrapper.sessionid;
                                // sessioninfo.sessionstart_time = DateTime.Now;
                                sessioninfo.securityroles = "Admin";
                                sessioninfo.IPaddress = strIPAddress;
                                sessioninfo.useragent = Request.UserAgent;
                                User userInfo = new User();
                                userInfo.utcdatetime = DateTime.UtcNow;
                                userInfo.localdatetime = DateTime.Now;
                                userInfo = UserBLL.GetDateTime(userInfo);
                                SessionWrapper.converted_datetime = userInfo.converted_date_time;
                                SessioninfoBLL.InsertSessionInfo(sessioninfo);

                            }
                            catch (Exception ex)
                            {
                                //TODO: Show user friendly error here
                                //Log here
                                if (ConfigurationWrapper.LogErrors == true)
                                {
                                    if (ex.InnerException != null)
                                    {
                                        Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                                    }
                                    else
                                    {
                                        Logger.WriteToErrorLog("CFHome.master", ex.Message);
                                    }
                                }
                            }
                            // Create forms authentication ticket
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1, // Ticket version
                            SessionWrapper.u_userid,// Userid to be associated with this ticket
                            DateTime.Now, // Date/time ticket was issued
                            DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
                            false, // if user has chcked rememebr me then create persistent cookie
                            roles, // store the user data, in this case roles of the user
                            FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.

                            // To give more security it is suggested to hash it
                            string hashCookies = FormsAuthentication.Encrypt(ticket);
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket

                            // Add the cookie to the response, user browser
                            Response.Cookies.Add(cookie);

                            if (!string.IsNullOrEmpty(userLogin.check_last_visited_tab_role))
                            {

                                Response.Redirect(userLogin.check_last_visited_tab_role + "?in=" + SecurityCenter.EncryptText("success"));


                            }
                            else
                            {
                                if (Convert.ToBoolean(SessionWrapper.u_sr_is_employee) == true)
                                {
                                    Response.Redirect("~/Employee/Home/lhp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);

                                }

                                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_manager) == true)
                                {
                                    Response.Redirect("~/Manager/mhp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);

                                }

                                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance) == true || Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                                {
                                    Response.Redirect("~/Compliance/cchp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);

                                }

                                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_instructor) == true)
                                {
                                    Response.Redirect("~/Instructor/ihp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);

                                }


                                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_training) == true)
                                {

                                    Response.Redirect("~/Training/tchp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);

                                }

                                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_administrator) == true)
                                {
                                    Response.Redirect("~/Administrator/tahp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);



                                }

                                else if (Convert.ToBoolean(SessionWrapper.u_sr_is_system_admin) == true)
                                {
                                    Response.Redirect("~/SystemHome/sahp-01.aspx?in=" + SecurityCenter.EncryptText("success"), false);

                                }

                                //Response.Redirect("~/Employee/lhp-01.aspx?in="+ SecurityCenter.EncryptText ("success"));
                            }
                        }
                        else
                        {

                            message.Style.Add("display", "block");
                            success_logout.Style.Add("display", "none");
                            expire_message.Style.Add("display", "none");
                            txtPassWord.Text = "";
                            txtUserName.Text = "";

                        }
                    }
                    else
                    {
                        message.Style.Add("display", "block");
                        success_logout.Style.Add("display", "none");
                        expire_message.Style.Add("display", "none");
                        txtPassWord.Text = "";
                        txtUserName.Text = "";

                    }
                }
                else
                {
                    message.Style.Add("display", "none");
                    success_logout.Style.Add("display", "none");
                    expire_message.Style.Add("display", "none");

                    alreadyLogged.Style.Add("display", "block");
                }
            }
            else
            {
                message.Style.Add("display", "block");
                success_logout.Style.Add("display", "none");
                expire_message.Style.Add("display", "none");

                alreadyLogged.Style.Add("display", "none");
            }







        }

        protected void btnLanguages_Click(object sender, EventArgs e)
        {
            if (ddlLanguages.Items.Count > 0) //make sure there is a SelectedValue
            {
                // BasePage bp = new BasePage();

                //bp.ApplyNewLanguageAndRefreshPage(new CultureInfo(ddlLanguages.SelectedValue));
                SessionWrapper.CultureName = ddlLanguages.SelectedValue;
                Session.Add(SessionWrapper.CultureName, ddlLanguages.SelectedValue);
                Response.Redirect(Request.Url.ToString());
            }
        }
        private bool Passwordvalidate(string enteredPwd, string dbpwd)
        {
            /// <summary>
            /// Encrypt password with salt and validation
            /// </summary>
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(passPhrase, initVector);

            cipherText = rijndaelKey.Encrypt(enteredPwd);

            plainText = rijndaelKey.Decrypt(cipherText);

            dbpwd = rijndaelKey.Decrypt(dbpwd);
            if (plainText == dbpwd)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}