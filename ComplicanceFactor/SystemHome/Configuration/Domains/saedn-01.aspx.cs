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
    public partial class saedn_01 : BasePage
    {
        string editDomain;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //set edit domain id
                if (!string.IsNullOrEmpty(Request.QueryString["edt"]))
                {
                    editDomain = SecurityCenter.DecryptText(Request.QueryString["edt"]);
                }
                if (!IsPostBack)
                {
                    //clear domain related session
                    ClearSession();
                    //set breadcrumb
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Domains/samdmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_domain_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_domain_text");
                    //Bind domain status
                    ddlStatus.DataSource = SystemDomainBLL.GetDomainStatus(SessionWrapper.CultureName, "saedn-01");
                    ddlStatus.DataBind();                   
                    //Bind themes
                    ddlTheme.DataSource = SystemDomainBLL.GetDomainThemes();
                    ddlTheme.DataBind();
                    //populate domain
                    PopulateDomain(editDomain);
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerHtml = LocalResources.GetText("app_success_msg_text");
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
                        Logger.WriteToErrorLog("saedn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saedn-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void btnHeaderUpdateDomain_Click(object sender, EventArgs e)
        {
            UpdateDomain();
        }

        protected void btnFooterUpdateDomain_Click(object sender, EventArgs e)
        {
            UpdateDomain();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Domains/samdmp-01.aspx", false);
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
        private void UpdateDomain()
        {

            SystemDomain updateDomain = new SystemDomain();
            updateDomain.u_domain_id_pk = txtDomainId.Text;
            updateDomain.u_domain_name = txtDomainName.Text;
            updateDomain.u_domain_desc = txtDescription.Value;
            updateDomain.u_domain_status_id_fk = ddlStatus.SelectedValue;
            updateDomain.u_domain_theme_id_fk = ddlTheme.SelectedValue;
            updateDomain.u_domain_owner_id_fk = SessionWrapper.u_domain_owner_id_fk;
            updateDomain.u_domain_coordinator_id_fk = SessionWrapper.u_domain_coordinator_id_fk;
            updateDomain.u_domain_system_id_pk = editDomain;
            try
            {
                int error = SystemDomainBLL.UpdateDomain(updateDomain);
                if (error == -2)
                {
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divError.InnerHtml = LocalResources.GetLocalizationResourceLabelText("app_domain_id_already_exists_error_msg");

                }
                else
                {
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerHtml = LocalResources.GetLocalizationResourceLabelText("app_update_msg_text");
                }
            }
            catch (Exception ex)
            {
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
        /// <summary>
        /// Reset domain
        /// </summary>
        private void Reset()
        {
            //clear domain related session
            ClearSession();
            PopulateDomain(editDomain);
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
                txtDomainId.Text = getDomain.u_domain_id_pk;
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
                //Hide success and error message
                divSuccess.Style.Add("display", "none");
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

    }
}