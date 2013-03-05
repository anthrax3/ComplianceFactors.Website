using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;

namespace ComplicanceFactor
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // look if any security information exists for this request
            if (HttpContext.Current.User != null)
            {
                // see if this user is authenticated, any authenticated cookie (ticket) exists for this user
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // see if the authentication is done using FormsAuthentication
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        // Get the roles stored for this request from the ticket
                        // get the identity of the user
                        FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                        // get the forms authetication ticket of the user
                        FormsAuthenticationTicket ticket = identity.Ticket;
                        // get the roles stored as UserData into the ticket 
                        string[] roles = ticket.UserData.Split(',');
                        // create generic principal and assign it to the current request
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
                    }
                }
            }
        }
        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

            try
            {



                if (Session["u_userid"] != null && (string)Session["u_userid"] != string.Empty)
                {
                    Sessioninfo sessioninfo = new Sessioninfo();

                    sessioninfo.sessionguid = Session["sessionguid"].ToString();
                    SessioninfoBLL.InsertSessionEndTime(sessioninfo);

                    User userinfo = new User();
                    userinfo.u_is_active = false;
                    userinfo.Userid = Session["u_userid"].ToString();
                    UserBLL.UpdateLock(userinfo);
                    Session.Abandon();
                }


            }

            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("global.asax", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("global.asax", ex.Message);
                    }
                }
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}