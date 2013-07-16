using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Rooms.Locale
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
                    dvLocale.RowFilter = "s_locale_system_id_pk= '" + Request.QueryString["id"] + "'";
                    //Get Temp locale
                    TempGetLocale(Request.QueryString["id"], dvLocale.ToTable());
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemRoom Locale = new SystemRoom();
                    Locale = SystemRoomBLL.GetSingleRoomLocale(Request.QueryString["id"]);
                    txtName.Text = Locale.s_room_locale_name;
                    txtDescriptoin.Value = Locale.s_room_locale_description;
                    lblLocaleHeading.Text = LocalResources.GetLabel("app_room_information_text") + " (" + Locale.s_locale_text + ")";
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
                SystemRoom updateRoom = new SystemRoom();
                updateRoom.s_room_locale_system_id_pk = Request.QueryString["id"];
                updateRoom.s_room_locale_name = txtName.Text;
                updateRoom.s_room_locale_description = txtDescriptoin.Value;
               
                try
                {
                    SystemRoomBLL.UpdateRoomLocale(updateRoom);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(room)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(room)", ex.Message);
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
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_name"] = txtName.Text;
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
            SystemRoom Locale = new SystemRoom();
            Locale = SystemRoomBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtName.Text = Locale.s_room_locale_name;
            txtDescriptoin.Value = Locale.s_room_locale_description;
            lblLocaleHeading.Text = LocalResources.GetLabel("app_room_information_text") + " (" + Locale.s_locale_text + ")";
        }
    }
}