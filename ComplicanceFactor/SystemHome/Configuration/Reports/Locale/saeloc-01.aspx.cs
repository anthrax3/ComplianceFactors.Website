using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Reports.Locale
{
    public partial class saeloc_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
                {
                    DataView dvLocale = new DataView(SessionWrapper.Locale);
                    dvLocale.RowFilter = "s_locale_system_id_pk= '" + Request.QueryString["lsid"] + "'";
                    //Get Temp locale
                    TempGetLocale(Request.QueryString["lsid"], dvLocale.ToTable());
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemReportLocale Locale = new SystemReportLocale();
                    Locale = SystemReportBLL.GetSingleReportLocale(Request.QueryString["lsid"].ToString());
                    txtName.Text = Locale.s_locale_title;
                    txtDescriptoin.Value = Locale.s_locale_description;
                
                    lblLocaleHeading.Text = LocalResources.GetLabel("app_location_information_text") + " (" + Locale.s_locale_text + ")";
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
                SystemReportLocale updatereportlocale = new SystemReportLocale();
                updatereportlocale.s_locale_system_id_pk = Request.QueryString["lsid"];
                updatereportlocale.s_locale_title = txtName.Text;
                updatereportlocale.s_locale_description = txtDescriptoin.Value;
             
                try
                {
                    SystemReportBLL.UpdateReportLocale(updatereportlocale);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx", ex.Message);
                        }
                    }
                }
            }
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);


        }
        private void UpdateLocale()
        {
            var rows = SessionWrapper.Locale.Select("s_locale_system_id_pk= '" + Request.QueryString["lsid"] + "'");
            var indexOfRow = SessionWrapper.Locale.Rows.IndexOf(rows[0]);
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_title"] = txtName.Text;
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_description"] = txtDescriptoin.Value;
         
            SessionWrapper.Locale.AcceptChanges();
        }
        /// <summary>
        /// get locale from session
        /// </summary>
        /// <param name="str_s_locale_system_id_pk"></param>
        /// <param name="dtLocale"></param>
        private void TempGetLocale(string str_s_locale_system_id_pk, DataTable dtLocale)
        {
            SystemReportLocale Locale = new SystemReportLocale();
            Locale = SystemReportBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtName.Text = Locale.s_locale_title;
            txtDescriptoin.Value = Locale.s_locale_description;
        
            lblLocaleHeading.Text = LocalResources.GetLabel("app_location_information_text") + " (" + Locale.s_locale_text + ")";
        }
    }
}