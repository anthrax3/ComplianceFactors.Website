using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Instructor
{
    public partial class samic_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Instructor/samir-01.aspx>" + LocalResources.GetLabel("app_manage_instructors_text") + "</a>&nbsp;>&nbsp;" + LocalResources.GetLabel("app_manage_instructors_courses_text");

                try
                {
                    //set user id
                    hdId.Value = SecurityCenter.DecryptText(Request.QueryString["uid"]);
                    User userList = new User();
                    userList = UserBLL.GetUserInfo(hdId.Value);
                    lblFirstName.Text = userList.Firstname;
                    lblLastName.Text = userList.Lastname;
                    lblMiddleName.Text = userList.Middlename;
                    lblUserStatus.Text = userList.Active_status_flag;
                    lblUserTypes.Text = userList.Usertype;
                    lblUserDomain.Text = userList.DomainId;
                }
                catch (Exception ex)
                {
                    //Log
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samic-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samic-01", ex.Message);
                        }
                    }
                }
            }

            //bind course
            try
            {
                gvCourse.DataSource = SystemInstructorBLL.GetInstructorCourse(SecurityCenter.DecryptText(Request.QueryString["uid"]));
                gvCourse.DataBind();
            }
            catch (Exception ex)
            {
                //Log
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samic-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samic-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Delete instructor course
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteCourse(string args)
        {

            try
            {
                SystemInstructorBLL.DeleteInstructorCourse(args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samic-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samic-01", ex.Message);
                    }
                }
            }


        }

        protected void btnHeaderClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/samcmp-01.aspx");
        }

        protected void btnFooterClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/samcmp-01.aspx");
        }
    }
}