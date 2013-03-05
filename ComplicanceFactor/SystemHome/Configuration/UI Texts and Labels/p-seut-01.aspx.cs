using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels
{
    public partial class Edit_Ui_Text : System.Web.UI.Page
    {
     
        private string app_name;
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["appname"]))
            {
                app_name = Request.QueryString["appname"];
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"];
            }
            if (!IsPostBack)
            {
                //bind locale
                ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                ddlLocale.DataBind();
                PopulateUiText();
            }
            DataTable dtLocale = new DataTable();
            dtLocale = SystemUI_Texts_Labels_DropdownBLL.GetUiTextLocale(id, app_name);
            gvLocale.DataSource = dtLocale;
            gvLocale.DataBind();
            foreach (DataRow dtrow in dtLocale.Rows)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_fk"], "RemoveLocale('" + dtrow["s_locale_id_fk"] + "');", true);
            }

            //set first item
            ddlLocale.SelectedIndex = 0;
        }
        /// <summary>
        /// DeleteLocale
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string args, string args1,string args2)
        {
            try
            {
                SystemUI_Texts_Labels_DropdownBLL.DeleteUiText(args2.Trim(),args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-saeut-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-saeut-01.aspx", ex.Message);
                    }
                }
            }


        }
        private void PopulateUiText()
        {
            SystemUI_Texts_Labels_Dropdown uiText = new SystemUI_Texts_Labels_Dropdown();
            if (!string.IsNullOrEmpty(Request.QueryString["appname"]))
            {
                uiText = SystemUI_Texts_Labels_DropdownBLL.GetUIText(id, app_name);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                uiText = SystemUI_Texts_Labels_DropdownBLL.GetUIText(id, app_name);
            }
            //English (US)
            txtUiText.Value = uiText.s_ui_text_us_english;

        }

        protected void btnSaveUiText_Click(object sender, EventArgs e)
        {
            try
            {
                SystemUI_Texts_Labels_DropdownBLL.UpdateUiTextDefault(id, txtUiText.Value,app_name);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-saeut-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-saeut-01.aspx", ex.Message);
                    }
                }
            }
            

        }
    }
}