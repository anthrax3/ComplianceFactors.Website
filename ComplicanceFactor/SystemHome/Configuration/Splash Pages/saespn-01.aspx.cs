using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Splash_Pages
{
    public partial class saespn_02 : System.Web.UI.Page
    {
        private static string splashPageId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Label Bread                     
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Splash%20Pages/samspmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_splash_pages_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_splash_pages");
                    //Bind Status
                    ddlStatus.DataSource = SystemSplashPageBLL.GetStatus(SessionWrapper.CultureName,"saespn-01");
                    ddlStatus.DataBind();

                    
                    //bind locale
                    ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                    ddlLocale.DataBind();
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                    }

                    //Get Edit  Splash page  Id
                    if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                    {
                        splashPageId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
                        hdSplashId.Value = splashPageId;
                        //Bind Domain
                        ddlDomain.DataSource = SystemSplashPageBLL.GetSplashDomain(splashPageId);
                        ddlDomain.DataBind();
                    }                   
                    //Get Edit  Splash page  Id
                    if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                    {
                        splashPageId = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                        hdSplashId.Value = splashPageId;
                        ddlDomain.DataSource = SystemSplashPageBLL.GetNotCreatedDomain();
                        ddlDomain.DataBind();


                    }

                    PopulateSplash(splashPageId);

                    RevertBack(splashPageId);
                }

                BindLocale(splashPageId);

                if (!string.IsNullOrEmpty(SessionWrapper.s_splash_owner_name))
                {
                    lblOwner.Text = SessionWrapper.s_splash_owner_name;
                }
                if (!string.IsNullOrEmpty(SessionWrapper.s_splash_coordinator_name))
                {
                    lblCoordinator.Text = SessionWrapper.s_splash_coordinator_name;
                }


                ddlLocale.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// For Bind the Locale and ddlLocale 
        /// </summary>
        /// <param name="splashPageId"></param>
        private void BindLocale(string splashPageId)
        {
            DataTable dtLocale = SystemSplashPageBLL.GetSplashLocale(splashPageId);
            gvSplashLocales.DataSource = dtLocale;
            gvSplashLocales.DataBind();

            foreach (DataRow dtrow in dtLocale.Rows)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["u_splash_locale_id_fk"], "RemoveLocale('" + dtrow["u_splash_locale_id_fk"] + "');", true);
            }

            ddlLocale.SelectedIndex = 0;
        }
        /// <summary>
        /// Populate Splash Page
        /// </summary>
        /// <param name="editSplashPageId"></param>
        private void PopulateSplash(string editSplashPageId)
        {
            SystemSplashPage splashPage = new SystemSplashPage();

            try
            {
                splashPage = SystemSplashPageBLL.GetSingleSplashPage(editSplashPageId);
                txtContent.InnerText = splashPage.u_splash_content;
                txtSplashPageId.Text = splashPage.u_splash_id_pk;
                txtSplashPageName.Text = splashPage.u_splash_name;
                ddlStatus.SelectedValue = splashPage.u_splash_status_id_fk;
                ddlDomain.SelectedValue = splashPage.u_splash_domain_id_fk;
                SessionWrapper.s_splash_coordinator_id_fk = splashPage.u_splash_coordinator_id_fk;
                SessionWrapper.s_splash_owner_id_fk = splashPage.u_splash_owner_id_fk;
                SessionWrapper.s_splash_coordinator_name = splashPage.u_splash_coordinator_name;
                SessionWrapper.s_splash_owner_name = splashPage.u_splash_owner_name;
                lblCoordinator.Text = SessionWrapper.s_splash_coordinator_name;
                lblOwner.Text = SessionWrapper.s_splash_owner_name;

                //Bind Locale
                gvSplashLocales.DataSource = SystemSplashPageBLL.GetSplashLocale(editSplashPageId);
                gvSplashLocales.DataBind();
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message);
                    }
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string args, string args1)
        {
            try
            {
                SystemSplashPageBLL.DeleteSplashLocale(args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterSaveSplashPage_Click(object sender, EventArgs e)
        {
            SaveSplashPage();
        }

        protected void btnHeaderSaveSplashPage_Click(object sender, EventArgs e)
        {
            SaveSplashPage();
        }
        /// <summary>
        /// Save Splash Page
        /// </summary>

        private void SaveSplashPage()
        {
                //update
                SystemSplashPage updateSplash = new SystemSplashPage();
                updateSplash.u_splash_system_id_pk = splashPageId;
                updateSplash.u_splash_id_pk = txtSplashPageId.Text;
                updateSplash.u_splash_name = txtSplashPageName.Text;
                updateSplash.u_splash_content = txtContent.InnerText;
                updateSplash.u_splash_status_id_fk = ddlStatus.SelectedValue;
                updateSplash.u_splash_coordinator_id_fk = SessionWrapper.s_splash_coordinator_id_fk;
                updateSplash.u_splash_domain_id_fk = ddlDomain.SelectedValue;
                updateSplash.u_splash_owner_id_fk = SessionWrapper.s_splash_owner_id_fk;

                try
                {
                    int result = SystemSplashPageBLL.UpdateSplashPage(updateSplash);
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                    }
                    else
                    {
                        divSuccess.Style.Add("display", "none");
                        divError.Style.Add("display", "block");
                        divError.InnerHtml = LocalResources.GetText("app_date_not_updated_error_wrong");
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saespn-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saespn-01.aspx", ex.Message);
                        }
                    }
                }
            
        }

        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetLocale();
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Splash Pages/samspmp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetLocale();
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Splash Pages/samspmp-01.aspx");
        }
        /// <summary>
        /// Revert Back For Reset
        /// </summary>
        /// <param name="localeId"></param>
        private void RevertBack(string localeId)
        {
            try
            {
                SessionWrapper.session_splash_locales = SystemSplashPageBLL.GetSplashLocale(localeId);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message);
                    }
                }
            }
        }

        private void ResetLocale()
        {
            SystemSplashPage resetLocale = new SystemSplashPage();

            resetLocale.u_splash_system_id_pk = splashPageId;
            resetLocale.u_splash_locales_xml = ConvertDataTableToXml(SessionWrapper.session_splash_locales);

            try
            {
                int result = SystemSplashPageBLL.ResetLocale(resetLocale);
                if (result == 0)
                {
                    BindLocale(splashPageId);
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saespn-01.aspx", ex.Message);
                    }
                }
            }
        }
    }
}