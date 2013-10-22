﻿using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Configuration.Reports.Locale
{
    public partial class savloc_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //bind locale
                ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                ddlLocale.DataBind();
            }
            DataTable dtLocale = new DataTable();
            //bind locales
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                if (SessionWrapper.Locale.Rows.Count > 0)
                {
                    gvLocale.DataSource = SessionWrapper.Locale;
                    gvLocale.DataBind();
                    dtLocale = SessionWrapper.Locale;
                    foreach (DataRow dtrow in dtLocale.Rows)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_pk"], "RemoveLocale('" + dtrow["s_locale_id_pk"] + "');", true);
                    }

                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                
                SessionWrapper.Locale.Clear();
                dtLocale = SystemReportBLL.GetReportLocale(Request.QueryString["id"]);
                gvLocale.DataSource = dtLocale;
                gvLocale.DataBind();
                foreach (DataRow dtrow in dtLocale.Rows)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_pk"], "RemoveLocale('" + dtrow["s_locale_id_pk"] + "');", true);
                }
            }
            //set first item
            ddlLocale.SelectedIndex = 0;

        }
        /// <summary>
        /// DeleteLocale
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string args, string args1)
        {
            try
            {
                if (SessionWrapper.Locale.Rows.Count > 0)
                {
                    var rows = SessionWrapper.Locale.Select("s_locale_system_id_pk= '" + args.Trim() + "'");
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Locale.AcceptChanges();
                }
                //Locale.s_facility_locale_system_id_pk = args.Trim();
                SystemReportBLL.DeleteReportLocale(string.Empty, string.Empty, args.Trim());

            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx", ex.Message);
                    }
                }
            }


        }
    }
}