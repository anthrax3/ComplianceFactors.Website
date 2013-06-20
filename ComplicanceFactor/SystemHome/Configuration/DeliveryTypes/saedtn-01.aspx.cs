using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.DeliveryTypes
{
    public partial class saedtn_01 : BasePage
    {
        private static string editDeliveryTypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Edit delivery Type Id
            if (!string.IsNullOrEmpty(Request.QueryString["edt"]))
            {
                editDeliveryTypeId = SecurityCenter.DecryptText(Request.QueryString["edt"]);
            }
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/DeliveryTypes/samdtmp-01.aspx>" + LocalResources.GetLabel("app_manage_delivery_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_delivery_type_text") + "</a>";

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                ///<summary>
                //Get Delivery type id
                /// </summary>
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editDeliveryTypeId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdDeliveryTypeId.Value = editDeliveryTypeId;

                }
                //Bind status
                ddlStatus.DataSource = SysemDeliveryTypesBLL.GetStatus(SessionWrapper.CultureName,"saedtn-01");
                ddlStatus.DataBind();                

                //Bind DeliveryMode
                ddlDeliveryMode.DataSource = SysemDeliveryTypesBLL.GetDeliveryMode();
                ddlDeliveryMode.DataBind();
                //Populate DeliveryTypes
                PopulateDeliveryType(editDeliveryTypeId);
            }
        }
        private void PopulateDeliveryType(string DeliveryTypesId)
        {
            SystemDeliveryType deliveryTypes = new SystemDeliveryType();
            deliveryTypes = SysemDeliveryTypesBLL.GetDeliveryType(DeliveryTypesId);

            txtDeliveryTypeId.Text = deliveryTypes.s_delivery_type_id;
            ddlStatus.SelectedValue = deliveryTypes.s_delivery_type_status_id_fk;
            ddlDeliveryMode.SelectedValue = deliveryTypes.s_delivery_type_mode_id_fk;


            txtDeliveryTypeName.Text = deliveryTypes.s_delivery_type_name_us_english;
            txtDescriptionUS.Value = deliveryTypes.s_delivery_type_desc_us_english;
            
            txtDeliverytypeNameUK.Text = deliveryTypes.s_delivery_type_name_uk_english;
            txtDecriptionUK.Value = deliveryTypes.s_delivery_type_desc_uk_english;
            txtDeliveryTypeNameCA.Text = deliveryTypes.s_delivery_type_name_ca_french;
            txtDecriptionCA.Value = deliveryTypes.s_delivery_type_desc_ca_french;
            txtDeliveryTypeNameFR.Text = deliveryTypes.s_delivery_type_name_fr_french;
            txtDescriptionFR.Value = deliveryTypes.s_delivery_type_desc_fr_french;
            txtDeliverytypeNameMX.Text = deliveryTypes.s_delivery_type_name_mx_spanish;
            txtDescriptionMX.Value = deliveryTypes.s_delivery_type_desc_mx_spanish;
            txtDeliverytypeNameSP.Text = deliveryTypes.s_delivery_type_name_sp_spanish;
            txtDescriptionSP.Value = deliveryTypes.s_delivery_type_desc_sp_spanish;
            txtDeliverytypeNamePortuguse.Text = deliveryTypes.s_delivery_type_name_portuguese;
            txtDescriptionPortuguese.Value = deliveryTypes.s_delivery_type_desc_portuguese;
            txtDeliverytypeNameGerman.Text = deliveryTypes.s_delivery_type_name_german;
            txtDescriptionGerman.Value = deliveryTypes.s_delivery_type_desc_german;
            txtDeliverytypeNameJapanese.Text = deliveryTypes.s_delivery_type_name_japanese;
            txtDescriptionJapanese.Value = deliveryTypes.s_delivery_type_desc_japanese;
            txtDeliverytypeNameRussian.Text = deliveryTypes.s_delivery_type_name_russian;
            txtDescriptionRussian.Value = deliveryTypes.s_delivery_type_desc_russian;
            txtDeliverytypeNameDanish.Text = deliveryTypes.s_delivery_type_name_danish;
            txtDescriptionDanish.Value = deliveryTypes.s_delivery_type_desc_danish;
            txtDeliverytypeNamePolish.Text = deliveryTypes.s_delivery_type_name_polish;
            txtDescriptionPolish.Value = deliveryTypes.s_delivery_type_desc_polish;
            txtDeliverytypeNameSwedish.Text = deliveryTypes.s_delivery_type_name_swedish;
            txtDescriptionSwedish.Value = deliveryTypes.s_delivery_type_desc_swedish;
            txtDeliverytypeNameFinnish.Text = deliveryTypes.s_delivery_type_name_finnish;
            txtDescriptionFinnish.Value = deliveryTypes.s_delivery_type_desc_finnish;
            txtDeliverytypeNameKorean.Text = deliveryTypes.s_delivery_type_name_korean;
            txtDescriptionKorian.Value = deliveryTypes.s_delivery_type_desc_korean;
            txtDeliverytypeNameItalian.Text = deliveryTypes.s_delivery_type_name_italian;
            txtDescriptionItalian.Value = deliveryTypes.s_delivery_type_desc_italian;
            txtDeliverytypeNameDutch.Text = deliveryTypes.s_delivery_type_name_dutch;
            txtDescriptionDutch.Value = deliveryTypes.s_delivery_type_desc_dutch;
            txtDeliverytypeNameIndonesian.Text = deliveryTypes.s_delivery_type_name_indonesian;
            txtDescriptionIndonesian.Value = deliveryTypes.s_delivery_type_desc_indonesian;
            txtDeliverytypeNameGreek.Text = deliveryTypes.s_delivery_type_name_greek;
            txtDescriptionGreek.Value = deliveryTypes.s_delivery_type_desc_greek;
            txtDeliverytypeNameHungarian.Text = deliveryTypes.s_delivery_type_name_hungarian;
            txtDescriptionHungarian.Value = deliveryTypes.s_delivery_type_desc_hungarian;
            txtDeliverytypeNameNorwegian.Text = deliveryTypes.s_delivery_type_name_norwegian;
            txtDescriptionNorwegian.Value = deliveryTypes.s_delivery_type_desc_norwegian;
            txtDeliverytypeNameTurkish.Text = deliveryTypes.s_delivery_type_name_turkish;
            txtDescriptionTurkish.Value = deliveryTypes.s_delivery_type_desc_turkish;
            txtDeliverytypeNameArabic.Text = deliveryTypes.s_delivery_type_name_arabic_rtl;
            txtDescriptionArabic.Value = deliveryTypes.s_delivery_type_desc_arabic_rtl;
            txtDeliverytypeNameCustom01.Text = deliveryTypes.s_delivery_type_name_custom_01;
            txtDescriptionCustom01.Value = deliveryTypes.s_delivery_type_desc_custom_01;
            txtDeliverytypeNameCustom02.Text = deliveryTypes.s_delivery_type_name_custom_01;
            txtDescriptionCustom02.Value = deliveryTypes.s_delivery_type_desc_custom_02;
            txtDeliverytypeNameCustom03.Text = deliveryTypes.s_delivery_type_name_custom_03;
            txtDescriptionCustom03.Value = deliveryTypes.s_delivery_type_desc_custom_03;
            txtDeliverytypeNameCustom04.Text = deliveryTypes.s_delivery_type_name_custom_04;
            txtDescriptionCustom04.Value = deliveryTypes.s_delivery_type_desc_custom_04;
            txtDeliverytypeNameCustom05.Text = deliveryTypes.s_delivery_type_name_custom_05;
            txtDescriptionCustom05.Value = deliveryTypes.s_delivery_type_desc_custom_05;
            txtDeliverytypeNameCustom06.Text = deliveryTypes.s_delivery_type_name_custom_06;
            txtDescriptionCustom06.Value = deliveryTypes.s_delivery_type_desc_custom_06;
            txtDeliverytypeNameCustom07.Text = deliveryTypes.s_delivery_type_name_custom_07;
            txtDescriptionCustom07.Value = deliveryTypes.s_delivery_type_desc_custom_07;
            txtDeliverytypeNameCustom08.Text = deliveryTypes.s_delivery_type_name_custom_08;
            txtDescriptionCustom08.Value = deliveryTypes.s_delivery_type_name_custom_08;
            txtDeliverytypeNameCustom09.Text = deliveryTypes.s_delivery_type_name_custom_09;
            txtDescriptionCustom09.Value = deliveryTypes.s_delivery_type_desc_custom_09;
            txtDeliverytypeNameCustom10.Text = deliveryTypes.s_delivery_type_name_custom_10;
            txtDescriptionCustom10.Value = deliveryTypes.s_delivery_type_desc_custom_10;
            txtDeliverytypeNameCustom11.Text = deliveryTypes.s_delivery_type_name_custom_11;
            txtDescriptionCustom11.Value = deliveryTypes.s_delivery_type_name_custom_11;
            txtDeliverytypeNameCustom12.Text = deliveryTypes.s_delivery_type_name_custom_12;
            txtDescriptionCustom12.Value = deliveryTypes.s_delivery_type_desc_custom_12;
            txtDeliverytypeNameCustom13.Text = deliveryTypes.s_delivery_type_name_custom_13;
            txtDescriptionCustom13.Value = deliveryTypes.s_delivery_type_desc_custom_13;
            txtDeliverytypeNameChinese.Text = deliveryTypes.s_delivery_type_name_simp_chinese;
            txtDescriptionChinese.Value = deliveryTypes.s_delivery_type_desc_simp_chinese;
        }
        private void UpdateDeliveryTypes()
        {
            SystemDeliveryType updateDelivery = new SystemDeliveryType();
            updateDelivery.s_delivery_type_system_id_pk = editDeliveryTypeId;
            updateDelivery.s_delivery_type_id = txtDeliveryTypeId.Text;
            updateDelivery.s_delivery_type_status_id_fk = ddlStatus.SelectedValue;
            updateDelivery.s_delivery_type_mode_id_fk = ddlDeliveryMode.SelectedValue;

            updateDelivery.s_delivery_type_name_us_english = txtDeliveryTypeName.Text;
            updateDelivery.s_delivery_type_desc_us_english = txtDescriptionUS.Value;
            
            updateDelivery.s_delivery_type_name_uk_english = txtDeliverytypeNameUK.Text;
            updateDelivery.s_delivery_type_desc_uk_english = txtDecriptionUK.Value;
            updateDelivery.s_delivery_type_name_ca_french = txtDeliveryTypeNameCA.Text;
            updateDelivery.s_delivery_type_desc_ca_french = txtDecriptionCA.Value;
            updateDelivery.s_delivery_type_name_fr_french = txtDeliveryTypeNameFR.Text;
            updateDelivery.s_delivery_type_desc_fr_french = txtDescriptionFR.Value;
            updateDelivery.s_delivery_type_name_mx_spanish = txtDeliverytypeNameMX.Text;
            updateDelivery.s_delivery_type_desc_mx_spanish = txtDescriptionMX.Value;
            updateDelivery.s_delivery_type_name_sp_spanish = txtDeliverytypeNameSP.Text;
            updateDelivery.s_delivery_type_desc_sp_spanish = txtDescriptionSP.Value;
            updateDelivery.s_delivery_type_name_portuguese = txtDeliverytypeNamePortuguse.Text;
            updateDelivery.s_delivery_type_desc_portuguese = txtDescriptionPortuguese.Value;
            updateDelivery.s_delivery_type_name_german = txtDeliverytypeNameGerman.Text;
            updateDelivery.s_delivery_type_desc_german = txtDescriptionGerman.Value;
            updateDelivery.s_delivery_type_name_japanese = txtDeliverytypeNameJapanese.Text;
            updateDelivery.s_delivery_type_desc_japanese = txtDescriptionJapanese.Value;
            updateDelivery.s_delivery_type_name_russian = txtDeliverytypeNameRussian.Text;
            updateDelivery.s_delivery_type_desc_russian = txtDescriptionRussian.Value;
            updateDelivery.s_delivery_type_name_danish = txtDeliverytypeNameDanish.Text;
            updateDelivery.s_delivery_type_desc_danish = txtDescriptionDanish.Value;
            updateDelivery.s_delivery_type_name_polish = txtDeliverytypeNamePolish.Text;
            updateDelivery.s_delivery_type_desc_polish = txtDescriptionPolish.Value;
            updateDelivery.s_delivery_type_name_swedish = txtDeliverytypeNameSwedish.Text;
            updateDelivery.s_delivery_type_desc_swedish = txtDescriptionSwedish.Value;
            updateDelivery.s_delivery_type_name_finnish = txtDeliverytypeNameFinnish.Text;
            updateDelivery.s_delivery_type_desc_finnish = txtDescriptionFinnish.Value;
            updateDelivery.s_delivery_type_name_korean = txtDeliverytypeNameKorean.Text;
            updateDelivery.s_delivery_type_desc_korean = txtDescriptionKorian.Value;
            updateDelivery.s_delivery_type_name_italian = txtDeliverytypeNameItalian.Text;
            updateDelivery.s_delivery_type_desc_italian = txtDescriptionItalian.Value;
            updateDelivery.s_delivery_type_name_dutch = txtDeliverytypeNameDutch.Text;
            updateDelivery.s_delivery_type_desc_dutch = txtDescriptionDutch.Value;
            updateDelivery.s_delivery_type_name_indonesian = txtDeliverytypeNameIndonesian.Text;
            updateDelivery.s_delivery_type_desc_indonesian = txtDescriptionIndonesian.Value;
            updateDelivery.s_delivery_type_name_greek = txtDeliverytypeNameGreek.Text;
            updateDelivery.s_delivery_type_desc_greek = txtDescriptionGreek.Value;
            updateDelivery.s_delivery_type_name_hungarian = txtDeliverytypeNameHungarian.Text;
            updateDelivery.s_delivery_type_desc_hungarian = txtDescriptionHungarian.Value;
            updateDelivery.s_delivery_type_name_norwegian = txtDeliverytypeNameNorwegian.Text;
            updateDelivery.s_delivery_type_desc_norwegian = txtDescriptionNorwegian.Value;
            updateDelivery.s_delivery_type_name_turkish = txtDeliverytypeNameTurkish.Text;
            updateDelivery.s_delivery_type_desc_turkish = txtDescriptionTurkish.Value;
            updateDelivery.s_delivery_type_name_arabic_rtl = txtDeliverytypeNameArabic.Text;
            updateDelivery.s_delivery_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateDelivery.s_delivery_type_name_custom_01 = txtDeliverytypeNameCustom01.Text;
            updateDelivery.s_delivery_type_desc_custom_01 = txtDescriptionCustom01.Value;
            updateDelivery.s_delivery_type_name_custom_02 = txtDeliverytypeNameCustom02.Text;
            updateDelivery.s_delivery_type_desc_custom_02 = txtDescriptionCustom02.Value;
            updateDelivery.s_delivery_type_name_custom_03 = txtDeliverytypeNameCustom03.Text;
            updateDelivery.s_delivery_type_desc_custom_03 = txtDescriptionCustom03.Value;
            updateDelivery.s_delivery_type_name_custom_04 = txtDeliverytypeNameCustom04.Text;
            updateDelivery.s_delivery_type_desc_custom_04 = txtDescriptionCustom04.Value;
            updateDelivery.s_delivery_type_name_custom_05 = txtDeliverytypeNameCustom05.Text;
            updateDelivery.s_delivery_type_desc_custom_05 = txtDescriptionCustom05.Value;
            updateDelivery.s_delivery_type_name_custom_06 = txtDeliverytypeNameCustom06.Text;
            updateDelivery.s_delivery_type_desc_custom_06 = txtDescriptionCustom06.Value;
            updateDelivery.s_delivery_type_name_custom_07 = txtDeliverytypeNameCustom07.Text;
            updateDelivery.s_delivery_type_desc_custom_07 = txtDescriptionCustom07.Value;
            updateDelivery.s_delivery_type_name_custom_08 = txtDeliverytypeNameCustom08.Text;
            updateDelivery.s_delivery_type_desc_custom_08 = txtDescriptionCustom08.Value;
            updateDelivery.s_delivery_type_name_custom_09 = txtDeliverytypeNameCustom09.Text;
            updateDelivery.s_delivery_type_desc_custom_09 = txtDescriptionCustom09.Value;
            updateDelivery.s_delivery_type_name_custom_10 = txtDeliverytypeNameCustom10.Text;
            updateDelivery.s_delivery_type_desc_custom_10 = txtDescriptionCustom10.Value;
            updateDelivery.s_delivery_type_name_custom_11 = txtDeliverytypeNameCustom11.Text;
            updateDelivery.s_delivery_type_desc_custom_11 = txtDescriptionCustom11.Value;
            updateDelivery.s_delivery_type_name_custom_12 = txtDeliverytypeNameCustom12.Text;
            updateDelivery.s_delivery_type_desc_custom_12 = txtDescriptionCustom12.Value;
            updateDelivery.s_delivery_type_name_custom_13 = txtDeliverytypeNameCustom13.Text;
            updateDelivery.s_delivery_type_desc_custom_13 = txtDescriptionCustom13.Value;
            updateDelivery.s_delivery_type_name_simp_chinese = txtDeliverytypeNameChinese.Text;
            updateDelivery.s_delivery_type_desc_simp_chinese = txtDescriptionChinese.Value;
            int error;
            error = SysemDeliveryTypesBLL.UpdateDeliveryTypes(updateDelivery);
            if (error != -2)
            {
                //Show success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");


            }
            else
            {
                //Show error message 
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_delivery_id_alredy_exists_error_text");

            }
        }

        protected void btnHeaderSaveNewDeliveryType_Click(object sender, EventArgs e)
        {
            UpdateDeliveryTypes();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DeliveryTypes/samdtmp-01.aspx", false);
        }

        protected void btnFooterSaveNewDeliveryType_Click(object sender, EventArgs e)
        {
            UpdateDeliveryTypes();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DeliveryTypes/samdtmp-01.aspx", false);
        }
    }
}