using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Reports.Locale
{
    public partial class saaloc_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["localeText"]))
                {
                    lblLocaleHeading.Text = LocalResources.GetGlobalLabel("app_location_information_text") + " (" + Request.QueryString["localeText"] + ")";
                }

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                AddDataToLocale(Request.QueryString["localeid"], txtName.Text, txtDescriptoin.Value, Request.QueryString["localeText"],  SessionWrapper.Locale);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemReportLocale InsertLocale = new SystemReportLocale();
                InsertLocale.s_locale_title = txtName.Text;
                InsertLocale.s_locale_description = txtDescriptoin.Value;
                InsertLocale.s_locale_id_pk = Request.QueryString["localeid"];
                InsertLocale.s_report_system_id_fk = Request.QueryString["Id"];
              
                try
                {
                    SystemReportBLL.InsertReportLocale(InsertLocale);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saaloc-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saaloc-01.aspx", ex.Message);
                        }
                    }
                }

            }
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// add data to locale
        /// </summary>
        /// <param name="s_locale_id_fk"></param>
        /// <param name="s_locale_name"></param>
        /// <param name="s_locale_description"></param>
        /// <param name="s_locale_text"></param>
        /// <param name="dtTempLocale"></param>
        private void AddDataToLocale(string s_locale_id_pk, string s_locale_name, string s_locale_description, string s_locale_text, DataTable dtTempLocale)
        {
            DataRow row;
            row = dtTempLocale.NewRow();
            row["s_locale_system_id_pk"] = Guid.NewGuid().ToString();
            row["s_locale_id_pk"] = s_locale_id_pk;
            row["s_locale_title"] = s_locale_name;
            row["s_locale_description"] = s_locale_description;
            row["s_locale_text"] = s_locale_text;
         
            dtTempLocale.Rows.Add(row);
        }

    }
}