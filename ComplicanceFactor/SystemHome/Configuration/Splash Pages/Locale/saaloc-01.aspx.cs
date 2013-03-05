using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Configuration.Splash_Pages.Locale
{
    public partial class saaloc_01 : System.Web.UI.Page
    {         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["editLocalepk"]) && !string.IsNullOrEmpty(Request.QueryString["editSplashId"]))
                    {
                        string s_splash_locale_system_id_pk = Request.QueryString["editLocalepk"].ToString();
                        PopulateLocale(s_splash_locale_system_id_pk);
                    }
                }
            }           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["editSplashId"]))
                {                     
                    SystemSplashPage createLocale = new SystemSplashPage();
                    createLocale.u_splash_locale_system_id_pk = Guid.NewGuid().ToString();
                    createLocale.u_splash_locale_id_fk = Request.QueryString["editLocaleId"].ToString();
                    createLocale.u_splash_system_id_fk = Request.QueryString["editSplashId"].ToString();
                    createLocale.u_splash_locale_content = txtSplashPage.InnerText;

                    try
                    {
                        int result = SystemSplashPageBLL.CreateSplashLocale(createLocale);
                        if (result == 0)
                        {
                            divSuccess.Style.Add("display", "block");
                            divSuccess.InnerHtml = "Splash Page Locales Inserted Successfully";                          
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Splash Page)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Splash Page)", ex.Message);
                            }
                        }
                    }                     
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["editLocalepk"]) && !string.IsNullOrEmpty(Request.QueryString["editSplashId"]))
                {
                    SystemSplashPage updateLocale = new SystemSplashPage();
                    updateLocale.u_splash_locale_content = txtSplashPage.InnerText;
                    updateLocale.u_splash_locale_system_id_pk = Request.QueryString["editLocalepk"].ToString();

                    try
                    {
                        int result = SystemSplashPageBLL.UpdateSplashLocale(updateLocale);
                        if (result == 0)
                        {
                            divSuccess.Style.Add("display", "block");
                            divSuccess.InnerHtml = "Splash Page Locale Updated Successfully";                             
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Splash Page)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("saaloc-01.aspx(Splash Page)", ex.Message);
                            }
                        }
                    }

                }
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:self.parent.location.href='SystemHome/Configuration/Splash%20Pages/saespn-02.aspx?edit='" + splashId, true); ;
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// Populate Locale
        /// </summary>
        /// <param name="s_splash_locale_system_id_pk"></param>
        private void PopulateLocale(string s_splash_locale_system_id_pk)
        {
            SystemSplashPage getSingleLocale = new SystemSplashPage();
            try
            {
                getSingleLocale = SystemSplashPageBLL.GetSingleLocale(s_splash_locale_system_id_pk);

                txtSplashPage.InnerText = getSingleLocale.u_splash_locale_content;

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Splash Page)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saaloc-01.aspx(Splash Page)", ex.Message);
                    }
                }
            }
        }
    }
}