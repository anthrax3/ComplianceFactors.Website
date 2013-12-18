using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplicanceFactor.SystemHome.Configuration.Establishment.Locale
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
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Locale" + dtrow["s_locale_id_fk"], "RemoveLocale('" + dtrow["s_locale_id_fk"] + "');", true);
                    }

                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["establishmentid"]))
            {
                SessionWrapper.Locale.Clear();
                dtLocale = SystemEstablishmentBLL.GetEstablishmentLocale(Request.QueryString["establishmentid"]);
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
        /// <summary>
        /// DeleteLocale
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteLocale(string args, string args1)
        {

            try
            {

                //SystemEstablishment Locale = new SystemEstablishment();
                if (SessionWrapper.Locale.Rows.Count > 0)
                {
                    var rows = SessionWrapper.Locale.Select("s_locale_system_id_pk= '" + args.Trim() + "'");
                    //var indexOfRow = SessionWrapper.Locale.Rows.IndexOf(rows[0]);
                    //SessionWrapper.Locale.Rows[indexOfRow]["s_locale_name"] = DBNull.Value;
                    // SessionWrapper.Locale.Rows[indexOfRow]["s_locale_description"] = DBNull.Value; ;
                    foreach (var row in rows)
                        row.Delete();
                    SessionWrapper.Locale.AcceptChanges();
                }
                //Locale.s_Establishment_locale_system_id_pk = args.Trim();
                SystemEstablishmentBLL.DeleteEstablishmentLocale(args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx(Establishment)", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("savloc-01.aspx(Establishment)", ex.Message);
                    }
                }
            }


        }

       
    }
}