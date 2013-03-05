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

namespace ComplicanceFactor.SystemHome.Catalog.Locations.Locale
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
                AddDataToLocale(Request.QueryString["localeid"], txtName.Text, txtDescriptoin.Value, Request.QueryString["localeText"], txtAirPortCode.Text, SessionWrapper.Locale);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemLocation InsertLocale = new SystemLocation();
                InsertLocale.s_location_locale_name = txtName.Text;
                InsertLocale.s_location_locale_description = txtDescriptoin.Value;
                InsertLocale.s_locale_id_fk = Request.QueryString["localeid"];
                InsertLocale.s_location_system_id_fk = Request.QueryString["editLocationId"];
                InsertLocale.s_location_airport_code = txtAirPortCode.Text;
                try
                {
                    SystemLocationBLL.InsertLocationLocale(InsertLocale);
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
        private void AddDataToLocale(string s_locale_id_fk, string s_locale_name, string s_locale_description, string s_locale_text,string s_locale_airport_code, DataTable dtTempLocale)
        {
            DataRow row;
            row = dtTempLocale.NewRow();
            row["s_locale_system_id_pk"] = Guid.NewGuid().ToString();
            row["s_locale_id_fk"] = s_locale_id_fk;
            row["s_locale_name"] = s_locale_name;
            row["s_locale_description"] = s_locale_description;
            row["s_locale_text"] = s_locale_text;
            row["s_locale_airport_code"] = s_locale_airport_code;
            dtTempLocale.Rows.Add(row);
        }

    }
}