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
    public partial class saandtn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/DeliveryTypes/sametmp-01.aspx>" + LocalResources.GetLabel("app_manage_delivery_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_delivery_type_text");
                try
                {
                    //Bind Status
                    ddlStatus.DataSource = SysemDeliveryTypesBLL.GetStatus(SessionWrapper.CultureName,"saandtn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //Bind delivery Mode
                    ddlDeliveryMode.DataSource = SysemDeliveryTypesBLL.GetDeliveryMode();
                    ddlDeliveryMode.DataBind();
                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateDeliveryType(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saandtn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saandtn-01", ex.Message);
                        }
                    }

                }
            }
        }
        private void SaveDeliveryTypes()
        {
            SystemDeliveryType createDelivery = new SystemDeliveryType();
            createDelivery.s_delivery_type_system_id_pk = Guid.NewGuid().ToString();
            createDelivery.s_delivery_type_id = txtDeliveryTypeId.Text;
            
            createDelivery.s_delivery_type_status_id_fk = ddlStatus.SelectedValue;
            createDelivery.s_delivery_type_mode_id_fk = ddlDeliveryMode.SelectedValue;


            createDelivery.s_delivery_type_name_us_english = txtDeliveryTypeName.Text;
            createDelivery.s_delivery_type_desc_us_english = txtDescriptionUS.Value;

            createDelivery.s_delivery_type_name_uk_english = txtDeliverytypeNameUK.Text;
            createDelivery.s_delivery_type_desc_uk_english = txtDecriptionUK.Value;
            createDelivery.s_delivery_type_name_ca_french = txtDeliveryTypeNameCA.Text;
            createDelivery.s_delivery_type_desc_ca_french = txtDecriptionCA.Value;
            createDelivery.s_delivery_type_name_fr_french = txtDeliveryTypeNameFR.Text;
            createDelivery.s_delivery_type_desc_fr_french = txtDescriptionFR.Value;
            createDelivery.s_delivery_type_name_mx_spanish = txtDeliverytypeNameMX.Text;
            createDelivery.s_delivery_type_desc_mx_spanish = txtDescriptionMX.Value;
            createDelivery.s_delivery_type_name_sp_spanish = txtDeliverytypeNameSP.Text;
            createDelivery.s_delivery_type_desc_sp_spanish = txtDescriptionSP.Value;
            createDelivery.s_delivery_type_name_portuguese = txtDeliverytypeNamePortuguse.Text;
            createDelivery.s_delivery_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createDelivery.s_delivery_type_name_german = txtDeliverytypeNameGerman.Text;
            createDelivery.s_delivery_type_desc_german = txtDescriptionGerman.Value;
            createDelivery.s_delivery_type_name_japanese = txtDeliverytypeNameJapanese.Text;
            createDelivery.s_delivery_type_desc_japanese = txtDescriptionJapanese.Value;
            createDelivery.s_delivery_type_name_russian = txtDeliverytypeNameRussian.Text;
            createDelivery.s_delivery_type_desc_russian = txtDescriptionRussian.Value;
            createDelivery.s_delivery_type_name_danish = txtDeliverytypeNameDanish.Text;
            createDelivery.s_delivery_type_desc_danish = txtDescriptionDanish.Value;
            createDelivery.s_delivery_type_name_polish = txtDeliverytypeNamePolish.Text;
            createDelivery.s_delivery_type_desc_polish = txtDescriptionPolish.Value;
            createDelivery.s_delivery_type_name_swedish = txtDeliverytypeNameSwedish.Text;
            createDelivery.s_delivery_type_desc_swedish = txtDescriptionSwedish.Value;
            createDelivery.s_delivery_type_name_finnish = txtDeliverytypeNameFinnish.Text;
            createDelivery.s_delivery_type_desc_finnish = txtDescriptionFinnish.Value;
            createDelivery.s_delivery_type_name_korean = txtDeliverytypeNameKorean.Text;
            createDelivery.s_delivery_type_desc_korean = txtDescriptionKorian.Value;
            createDelivery.s_delivery_type_name_italian = txtDeliverytypeNameItalian.Text;
            createDelivery.s_delivery_type_desc_italian = txtDescriptionItalian.Value;
            createDelivery.s_delivery_type_name_dutch = txtDeliverytypeNameDutch.Text;
            createDelivery.s_delivery_type_desc_dutch = txtDescriptionDutch.Value;
            createDelivery.s_delivery_type_name_indonesian = txtDeliverytypeNameIndonesian.Text;
            createDelivery.s_delivery_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createDelivery.s_delivery_type_name_greek = txtDeliverytypeNameGreek.Text;
            createDelivery.s_delivery_type_desc_greek = txtDescriptionGreek.Value;
            createDelivery.s_delivery_type_name_hungarian = txtDeliverytypeNameHungarian.Text;
            createDelivery.s_delivery_type_desc_hungarian = txtDescriptionHungarian.Value;
            createDelivery.s_delivery_type_name_norwegian = txtDeliverytypeNameNorwegian.Text;
            createDelivery.s_delivery_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createDelivery.s_delivery_type_name_turkish = txtDeliverytypeNameTurkish.Text;
            createDelivery.s_delivery_type_desc_turkish = txtDescriptionTurkish.Value;
            createDelivery.s_delivery_type_name_arabic_rtl = txtDeliverytypeNameArabic.Text;
            createDelivery.s_delivery_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createDelivery.s_delivery_type_name_custom_01 = txtDeliverytypeNameCustom01.Text;
            createDelivery.s_delivery_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createDelivery.s_delivery_type_name_custom_02 = txtDeliverytypeNameCustom02.Text;
            createDelivery.s_delivery_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createDelivery.s_delivery_type_name_custom_03 = txtDeliverytypeNameCustom03.Text;
            createDelivery.s_delivery_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createDelivery.s_delivery_type_name_custom_04 = txtDeliverytypeNameCustom04.Text;
            createDelivery.s_delivery_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createDelivery.s_delivery_type_name_custom_05 = txtDeliverytypeNameCustom05.Text;
            createDelivery.s_delivery_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createDelivery.s_delivery_type_name_custom_06 = txtDeliverytypeNameCustom06.Text;
            createDelivery.s_delivery_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createDelivery.s_delivery_type_name_custom_07 = txtDeliverytypeNameCustom07.Text;
            createDelivery.s_delivery_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createDelivery.s_delivery_type_name_custom_08 = txtDeliverytypeNameCustom08.Text;
            createDelivery.s_delivery_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createDelivery.s_delivery_type_name_custom_09 = txtDeliverytypeNameCustom09.Text;
            createDelivery.s_delivery_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createDelivery.s_delivery_type_name_custom_10 = txtDeliverytypeNameCustom10.Text;
            createDelivery.s_delivery_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createDelivery.s_delivery_type_name_custom_11 = txtDeliverytypeNameCustom11.Text;
            createDelivery.s_delivery_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createDelivery.s_delivery_type_name_custom_12 = txtDeliverytypeNameCustom12.Text;
            createDelivery.s_delivery_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createDelivery.s_delivery_type_name_custom_13 = txtDeliverytypeNameCustom13.Text;
            createDelivery.s_delivery_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createDelivery.s_delivery_type_name_simp_chinese = txtDeliverytypeNameChinese.Text;
            createDelivery.s_delivery_type_desc_simp_chinese = txtDescriptionChinese.Value;

            int error;
            error = SysemDeliveryTypesBLL.CreateDeliveryTypes(createDelivery);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Configuration/DeliveryTypes/saedtn-01.aspx?id=" + SecurityCenter.EncryptText(createDelivery.s_delivery_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
            else
            {
                ///<summary>
                ///Show error message 
                ///</summary>
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_delivery_id_alredy_exists_error_text");
            }


        }

        protected void btnHeaderSaveNewDeliveryType_Click(object sender, EventArgs e)
        {
            SaveDeliveryTypes();
        }

        private void PopulateDeliveryType(string DeliveryTypesId)
        {
            SystemDeliveryType deliveryTypes = new SystemDeliveryType();
            deliveryTypes = SysemDeliveryTypesBLL.GetDeliveryType(DeliveryTypesId);

            txtDeliveryTypeId.Text = deliveryTypes.s_delivery_type_id + "_Copy";
          
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
            SaveDeliveryTypes();
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