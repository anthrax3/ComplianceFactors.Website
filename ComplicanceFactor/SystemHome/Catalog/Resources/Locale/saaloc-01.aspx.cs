﻿using System;
using System.Web.UI;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.LocalesPopup
{
    public partial class sacataml_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["localeText"]))
                {
                    lblLocaleHeading.Text = LocalResources.GetGlobalLabel("app_resource_information_text") + " (" + Request.QueryString["localeText"] + ")";
                }

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                AddDataToLocale(Request.QueryString["localeid"], txtName.Text, txtDescriptoin.Value, Request.QueryString["localeText"], SessionWrapper.Locale);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemResource insertResource = new SystemResource();
                insertResource.s_resource_locale_name = txtName.Text;
                insertResource.s_resource_locale_description = txtDescriptoin.Value;
                insertResource.s_locale_id_fk = Request.QueryString["localeid"];
                insertResource.s_resource_system_id_fk = Request.QueryString["editResourceId"];
                try
                {
                    SystemResourceBLL.InsertResourceLocale(insertResource);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saaresloc-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saaresloc-01.aspx", ex.Message);
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
        private void AddDataToLocale(string s_locale_id_fk, string s_locale_name, string s_locale_description, string s_locale_text, DataTable dtTempLocale)
        {
            DataRow row;
            row = dtTempLocale.NewRow();
            row["s_locale_system_id_pk"] = Guid.NewGuid().ToString();
            row["s_locale_id_fk"] = s_locale_id_fk;
            row["s_locale_name"] = s_locale_name;
            row["s_locale_description"] = s_locale_description;
            row["s_locale_text"] = s_locale_text;
            dtTempLocale.Rows.Add(row);
        }

    }
}