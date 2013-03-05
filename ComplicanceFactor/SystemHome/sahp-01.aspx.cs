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
using System.Net;
namespace ComplicanceFactor.SystemHome
{
    public partial class sahp_01 :  BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SessionWrapper.u_userid))
                {
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");

                    lblBreadCrumb.Text = LocalResources.GetGlobalLabel("app_nav_system") + " > ...";
                    User userSplash = new User();
                    try
                    {
                        userSplash = UserBLL.GetUserSplash(SessionWrapper.u_userid);
                        bool result = userSplash.u_splash_display_flag;
                        SystemSplashPage splashContent = new SystemSplashPage();
                        //Here we can get the splash content based on the domain Id
                        splashContent = SystemSplashPageBLL.GetSplashContent(SessionWrapper.u_domain);
                        spalsh.InnerHtml =  WebUtility.HtmlDecode(splashContent.u_splash_content);
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
                                Logger.WriteToErrorLog("sahp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("sahp-01.aspx", ex.Message);
                            }
                        }
                    }
                }

            }


        }
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
                        Logger.WriteToErrorLog("sahp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sahp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnCloseSplashPage_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }

    }
}