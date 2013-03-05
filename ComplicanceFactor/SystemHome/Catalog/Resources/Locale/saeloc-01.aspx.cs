using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.LocalesPopup
{
    public partial class sacateml_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

               
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
                {
                    DataView dvLocale = new DataView(SessionWrapper.Locale);
                    dvLocale.RowFilter = "s_locale_system_id_pk= '" + Request.QueryString["id"] + "'";
                    //Get Temp locale
                    TempGetLocale(Request.QueryString["id"], dvLocale.ToTable());
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemResource resLocale = new SystemResource();
                    resLocale = SystemResourceBLL.GetSingleResourceLocale(Request.QueryString["id"]);
                    txtName.Text = resLocale.s_resource_locale_name;
                    txtDescriptoin.Value = resLocale.s_resource_locale_description;
                    lblLocaleHeading.Text = LocalResources.GetLocalizationResourceLabelText("app_resource_information_text") + " (" + resLocale.s_locale_text + ")";
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                UpdateLocale();

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemResource updateResource = new SystemResource();
                updateResource.s_resource_locale_system_id_pk = Request.QueryString["id"];
                updateResource.s_resource_locale_name = txtName.Text;
                updateResource.s_resource_locale_description = txtDescriptoin.Value;
                try
                {
                    SystemResourceBLL.UpdateResourceLocale(updateResource);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeresloc-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeresloc-01.aspx", ex.Message);
                        }
                    }
                }
            }
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);


        }
        private void UpdateLocale()
        {
            var rows = SessionWrapper.Locale.Select("s_locale_system_id_pk= '" + Request.QueryString["id"] + "'");
            var indexOfRow = SessionWrapper.Locale.Rows.IndexOf(rows[0]);
           // SessionWrapper.Locale.Rows[indexOfRow]["s_locale_id_fk"] = Request.QueryString["localeid"];
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_name"] = txtName.Text;
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_description"] = txtDescriptoin.Value;
            //SessionWrapper.Locale.Rows[indexOfRow]["s_locale_text"] = Request.QueryString["localeText"];
            SessionWrapper.Locale.AcceptChanges();
        }
        /// <summary>
        /// get locale from session
        /// </summary>
        /// <param name="str_s_locale_system_id_pk"></param>
        /// <param name="dtLocale"></param>
        private void TempGetLocale(string str_s_locale_system_id_pk, DataTable dtLocale)
        {
            SystemResource reslocale = new SystemResource();
            reslocale = SystemResourceBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtName.Text = reslocale.s_resource_locale_name;
            txtDescriptoin.Value = reslocale.s_resource_locale_description;
            lblLocaleHeading.Text = LocalResources.GetLocalizationResourceLabelText("app_resource_information_text") + " (" + reslocale.s_locale_text + ")";
        }
    }
}