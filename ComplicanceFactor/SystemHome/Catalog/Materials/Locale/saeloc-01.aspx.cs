using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Materials.Locale
{
    public partial class saeloc_01 : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide validation summary
            vssaeloc.Style.Add("display", "none");
            if (!IsPostBack)
            {
                //clear attachment session
                SessionWrapper.file_name = string.Empty;
                SessionWrapper.file_guid = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
                {
                    DataView dvLocale = new DataView(SessionWrapper.Locale);
                    dvLocale.RowFilter = "s_locale_system_id_pk= '" + Request.QueryString["id"] + "'";
                    //Get Temp locale
                    TempGetLocale(Request.QueryString["id"], dvLocale.ToTable());
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemMaterial Locale = new SystemMaterial();
                    Locale = SystemMaterialBLL.GetSingleMaterialLocale(Request.QueryString["id"]);
                    txtName.Text = Locale.s_material_locale_name;
                    txtDescriptoin.Value = Locale.s_material_locale_description;
                    lblLocaleHeading.Text = LocalResources.GetLocalizationResourceLabelText("app_material_information_text") + " (" + Locale.s_locale_text + ")";
                    SessionWrapper.file_guid = Locale.s_material_locale_file_guid;
                    SessionWrapper.file_name = Locale.s_material_locale_file_name;
                }
            }
            Attachment();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                UpdateLocale();

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemMaterial updatematerial = new SystemMaterial();
                updatematerial.s_material_locale_system_id_pk = Request.QueryString["id"];
                updatematerial.s_material_locale_name = txtName.Text;
                updatematerial.s_material_locale_description = txtDescriptoin.Value;
                updatematerial.s_material_locale_file_guid = SessionWrapper.file_guid;
                updatematerial.s_material_locale_file_name = SessionWrapper.file_name;
               
                try
                {
                    SystemMaterialBLL.UpdateMaterialLocale(updatematerial);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(material)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saeloc-01.aspx(material)", ex.Message);
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
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_file_guid"] = SessionWrapper.file_guid;
            SessionWrapper.Locale.Rows[indexOfRow]["s_locale_file_name"] = SessionWrapper.file_name;
            SessionWrapper.Locale.AcceptChanges();
        }
        /// <summary>
        /// get locale from session
        /// </summary>
        /// <param name="str_s_locale_system_id_pk"></param>
        /// <param name="dtLocale"></param>
        private void TempGetLocale(string str_s_locale_system_id_pk, DataTable dtLocale)
        {
            SystemMaterial Locale = new SystemMaterial();
            Locale = SystemMaterialBLL.TempGetOneLocale(str_s_locale_system_id_pk, dtLocale);
            txtName.Text = Locale.s_material_locale_name;
            txtDescriptoin.Value = Locale.s_material_locale_description;
            lblLocaleHeading.Text = LocalResources.GetLocalizationResourceLabelText("app_material_information_text") + " (" + Locale.s_locale_text + ")";
            SessionWrapper.file_guid = Locale.s_material_locale_file_guid;
            SessionWrapper.file_name = Locale.s_material_locale_file_name;
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.file_name = string.Empty;
            SessionWrapper.file_guid = string.Empty;
            Attachment();
        }
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.file_name))
            {
                divAttachment.Style.Add("display", "inline");
                btnAttachment.Style.Add("display", "none");
                lnkDownload.Text = SessionWrapper.file_name;
            }
            else
            {
                //show and hide view,edit,attchment and remove button
                divAttachment.Style.Add("display", "none");
                btnAttachment.Style.Add("display", "inline");
                lnkDownload.Text = string.Empty;
            }
        }
      
      

    }
}