using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Domains
{
    public partial class saandn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                //hide validation summary
                vs_saandn.Style.Add("display", "none");
                if (!IsPostBack)
                {
                    //Clear domain related session
                    ClearSession();
                    //set breadcrumb
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLocalizationResourceLabelText("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Domains/samdmp-01.aspx>" + LocalResources.GetLocalizationResourceLabelText("app_manage_domain_text") + "</a>" + " >&nbsp;" + LocalResources.GetLocalizationResourceLabelText("app_create_new_domain_text");

                    //Bind domain status
                    ddlStatus.DataSource = SystemDomainBLL.GetDomainStatus(SessionWrapper.CultureName,"saandn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind themes
                    ddlTheme.DataSource = SystemDomainBLL.GetDomainThemes();
                    ddlTheme.DataBind();

                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateDomain (SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
                }
                //set owner and coordiantor
                lblOwner.Text = SessionWrapper.u_domain_owner_text;
                lblcoordinator.Text = SessionWrapper.u_domain_coordinator_text;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saandn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saandn-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// clear domain related session
        /// </summary>
        private void ClearSession()
        {
            SessionWrapper.u_domain_coordinator_id_fk = string.Empty;
            SessionWrapper.u_domain_owner_id_fk = string.Empty;
            SessionWrapper.u_domain_owner_text = string.Empty;
            SessionWrapper.u_domain_coordinator_text = string.Empty;
        }
        protected void btnHeaderSaveNewDomain_Click(object sender, EventArgs e)
        {
            SaveDomain();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Domains/samdmp-01.aspx", false);
        }

        protected void btnFooterSaveNewDomain_Click(object sender, EventArgs e)
        {
            SaveDomain();
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Domains/samdmp-01.aspx", false);

        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Save domain
        /// </summary>
        private void SaveDomain()
        {

            SystemDomain createNewDomain = new SystemDomain();
            createNewDomain.u_domain_id_pk = txtDomainId.Text;
            createNewDomain.u_domain_name = txtDomainName.Text;
            createNewDomain.u_domain_desc = txtDescription.Value;
            createNewDomain.u_domain_status_id_fk = ddlStatus.SelectedValue;
            createNewDomain.u_domain_theme_id_fk = ddlTheme.SelectedValue;
            createNewDomain.u_domain_owner_id_fk = SessionWrapper.u_domain_owner_id_fk;
            createNewDomain.u_domain_coordinator_id_fk = SessionWrapper.u_domain_coordinator_id_fk;
            createNewDomain.u_domain_system_id_pk = Guid.NewGuid().ToString();
            try
            {
                int error = SystemDomainBLL.CreateNewDomain(createNewDomain);
                if (error == -2)
                {
                    divError.Style.Add("display", "block");
                    divError.InnerHtml = LocalResources.GetLocalizationResourceLabelText("app_domain_id_already_exists_error_msg");

                }
                else
                {
                    Response.Redirect("~/SystemHome/Configuration/Domains/saedn-01.aspx?edt="+ SecurityCenter.EncryptText(createNewDomain.u_domain_system_id_pk)+"&succ=" +SecurityCenter.EncryptText("create"), false);
                }
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saandn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saandn-01.aspx", ex.Message);
                    }
                }

            }

        }
        /// <summary>
        /// Reset domain
        /// </summary>
        private void Reset()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
            {
                ClearSession();
                PopulateDomain(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
            }
            else
            {
                txtDomainId.Text = string.Empty;
                txtDomainName.Text = string.Empty;
                txtDescription.Value = string.Empty;
                ddlStatus.SelectedIndex = 0;
                ddlTheme.SelectedIndex = 0;
                lblOwner.Text = string.Empty;
                lblcoordinator.Text = string.Empty;
                SessionWrapper.u_domain_coordinator_id_fk = string.Empty;
                SessionWrapper.u_domain_owner_id_fk = string.Empty;
                SessionWrapper.u_domain_owner_text = string.Empty;
                SessionWrapper.u_domain_coordinator_text = string.Empty;
            }

        }
        /// <summary>
        /// PopulateDomain
        /// </summary>
        /// <param name="domainId"></param>
        private void PopulateDomain(string domainId)
        {
            try
            {
                SystemDomain getDomain = new SystemDomain();
                getDomain = SystemDomainBLL.GetSingleDomain(domainId);
                txtDomainId.Text = getDomain.u_domain_id_pk +"_Copy";
                txtDomainName.Text = getDomain.u_domain_name;
                txtDescription.Value = getDomain.u_domain_desc;
                SessionWrapper.u_domain_owner_id_fk = getDomain.u_domain_owner_id_fk;
                SessionWrapper.u_domain_coordinator_id_fk = getDomain.u_domain_coordinator_id_fk;
                SessionWrapper.u_domain_owner_text = getDomain.u_domain_owner_text;
                SessionWrapper.u_domain_coordinator_text = getDomain.u_domain_coordinator_text;
                ddlStatus.SelectedValue = getDomain.u_domain_status_id_fk;
                ddlTheme.SelectedValue = getDomain.u_domain_theme_id_fk;
                //set owner and coordiantor
                lblOwner.Text = SessionWrapper.u_domain_owner_text;
                lblcoordinator.Text = SessionWrapper.u_domain_coordinator_text;
                //Hide error message
                divError.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saedn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedn-01.aspx", ex.Message);
                    }
                }
            }
        }
    }
}