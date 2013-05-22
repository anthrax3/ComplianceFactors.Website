using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Catalog.Documents
{
    public partial class document_locales_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //gvLocale.DataSource = SessionWrapper.Locale;
            //gvLocale.DataBind();
            if (!IsPostBack)
            {
                ddlLocale.DataSource = SystemLocaleBLL.GetLocaleListExceptEnglish();
                ddlLocale.DataBind();
            }

            DataTable dtLocale = new DataTable();
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {

                if (SessionWrapper.Locale.Rows.Count > 0)
                {
                    gvLocale.DataSource = SessionWrapper.Locale;
                    gvLocale.DataBind();
                    dtLocale = SessionWrapper.Locale;
                    foreach (DataRow dtrow in dtLocale.Rows)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_fk"], "RemoveLocale('" + dtrow["s_locale_id_fk"] + "');", true);
                    }

                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["documentid"]))
            {
                SessionWrapper.Locale.Clear();
                dtLocale = SystemDocumentsBLL.GetDocumentLocale(Request.QueryString["documentid"]);
                gvLocale.DataSource = dtLocale;
                gvLocale.DataBind();
                foreach (DataRow dtrow in dtLocale.Rows)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_fk"], "RemoveLocale('" + dtrow["s_locale_id_fk"] + "');", true);
                }
            }
            //set first item
            ddlLocale.SelectedIndex = 0;
        }
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
                SystemDocumentsBLL.DeleteDocumentLocale(string.Empty, string.Empty, args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx(Documents)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx(Documents)", ex.Message);
                    }
                }
            }

            
        }
    }
}