using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Splash_Pages
{
    public partial class saanspn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread                 
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Splash%20Pages/samspmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_splash_pages_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_splash_pages") + "</a>";
                //ddlStatus
                ddlStatus.DataSource = SystemSplashPageBLL.GetAllStatus(SessionWrapper.CultureName,"saanspn-01");
                ddlStatus.DataBind();

                ddlStatus.SelectedValue = "app_ddl_active_text";
                //ddlDomain                 
                ddlDomain.DataSource = SystemSplashPageBLL.GetNotCreatedDomain();
                ddlDomain.DataBind();
                //Clear the session value
                SessionWrapper.s_splash_owner_id_fk = string.Empty;
                SessionWrapper.s_splash_coordinator_id_fk = string.Empty;
                SessionWrapper.s_splash_coordinator_name = string.Empty;
                SessionWrapper.s_splash_owner_name = string.Empty;
            }

            lblCoordinator.Text = SessionWrapper.s_splash_coordinator_name;
            lblOwner.Text = SessionWrapper.s_splash_owner_name;
        }

        protected void btnFooterSaveNewSplashPage_Click(object sender, EventArgs e)
        {
            SaveNewSplashPage();
        }

        protected void btnHeaderSaveNewSplashPage_Click(object sender, EventArgs e)
        {
            SaveNewSplashPage();
        }
        /// <summary>
        /// Save New Splash Page
        /// </summary>
        private void SaveNewSplashPage()
        {
            SystemSplashPage createSplash = new SystemSplashPage();
            createSplash.u_splash_system_id_pk = Guid.NewGuid().ToString();
            createSplash.u_splash_id_pk = txtSplashPageId.Text;
            createSplash.u_splash_name = txtSplashPageName.Text;
            createSplash.u_splash_content = txtContent.InnerText;
            createSplash.u_splash_status_id_fk = ddlStatus.SelectedValue;
            createSplash.u_splash_coordinator_id_fk = SessionWrapper.s_splash_coordinator_id_fk;
            createSplash.u_splash_domain_id_fk = ddlDomain.SelectedValue;
            createSplash.u_splash_owner_id_fk = SessionWrapper.s_splash_owner_id_fk;

            try
            {
                int result = SystemSplashPageBLL.CreateSplashPage(createSplash);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/Splash Pages/saespn-01.aspx?edit=" + SecurityCenter.EncryptText(createSplash.u_splash_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    divError.Style.Add("display", "block");
                    divError.InnerHtml = LocalResources.GetText("app_splash_page_id_already_exists_error_wrong");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanspn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanspn-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Splash%20Pages/samspmp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Splash%20Pages/samspmp-01.aspx");
        }
    }
}