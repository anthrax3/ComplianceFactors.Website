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

namespace ComplicanceFactor.SystemHome.Configuration.FacilityTypes
{
    public partial class saeftn_01 : BasePage
    {
        private static string editFacilityTypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Edit facility Type Id
            if (!string.IsNullOrEmpty(Request.QueryString["edt"]))
            {
                editFacilityTypeId = SecurityCenter.DecryptText(Request.QueryString["edt"]);
            }
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/FacilityTypes/samftmp-01.aspx>" + LocalResources.GetLabel("app_manage_facility_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_new_facility_type_text") + "</a>";

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                ///<summary>
                //Get Facility type id
                /// </summary>
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editFacilityTypeId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdFacilityTypeId.Value = editFacilityTypeId;

                }
                //Bind status
                ddlStatus.DataSource = SystemFacilityTypesBLL.GetStatus(SessionWrapper.CultureName, "saeftn-01");
                ddlStatus.DataBind();
                 
                //Populate FacilityTypes
                PopulateFacilityType(editFacilityTypeId);
            }
        }
        private void PopulateFacilityType(string FacilityTypesId)
        {
            SystemFacilityType facilityTypes = new SystemFacilityType();
            facilityTypes = SystemFacilityTypesBLL.GetFacilityType(FacilityTypesId);

            txtFacilityTypeId.Text = facilityTypes.s_facility_type_id;
            ddlStatus.SelectedValue = facilityTypes.s_facility_type_status_id_fk;

            txtFacilityTypeName.Text = facilityTypes.s_facility_type_name_us_english;
            txtDescriptionUS.Value = facilityTypes.s_facility_type_desc_us_english;
            txtFacilitytypeNameUK.Text = facilityTypes.s_facility_type_name_uk_english;
            txtDecriptionUK.Value = facilityTypes.s_facility_type_desc_uk_english;
            txtFacilityTypeNameCA.Text = facilityTypes.s_facility_type_name_ca_french;
            txtDecriptionCA.Value = facilityTypes.s_facility_type_desc_ca_french;
            txtFacilityTypeNameFR.Text = facilityTypes.s_facility_type_name_fr_french;
            txtDescriptionFR.Value = facilityTypes.s_facility_type_desc_fr_french;
            txtFacilitytypeNameMX.Text = facilityTypes.s_facility_type_name_mx_spanish;
            txtDescriptionMX.Value = facilityTypes.s_facility_type_desc_mx_spanish;
            txtFacilitytypeNameSP.Text = facilityTypes.s_facility_type_name_sp_spanish;
            txtDescriptionSP.Value = facilityTypes.s_facility_type_desc_sp_spanish;
            txtFacilitytypeNamePortuguse.Text = facilityTypes.s_facility_type_name_portuguese;
            txtDescriptionPortuguese.Value = facilityTypes.s_facility_type_desc_portuguese;
            txtFacilitytypeNameGerman.Text = facilityTypes.s_facility_type_name_german;
            txtDescriptionGerman.Value = facilityTypes.s_facility_type_desc_german;
            txtFacilitytypeNameJapanese.Text = facilityTypes.s_facility_type_name_japanese;
            txtDescriptionJapanese.Value = facilityTypes.s_facility_type_desc_japanese;
            txtFacilitytypeNameRussian.Text = facilityTypes.s_facility_type_name_russian;
            txtDescriptionRussian.Value = facilityTypes.s_facility_type_desc_russian;
            txtFacilitytypeNameDanish.Text = facilityTypes.s_facility_type_name_danish;
            txtDescriptionDanish.Value = facilityTypes.s_facility_type_desc_danish;
            txtFacilitytypeNamePolish.Text = facilityTypes.s_facility_type_name_polish;
            txtDescriptionPolish.Value = facilityTypes.s_facility_type_desc_polish;
            txtFacilitytypeNameSwedish.Text = facilityTypes.s_facility_type_name_swedish;
            txtDescriptionSwedish.Value = facilityTypes.s_facility_type_desc_swedish;
            txtFacilitytypeNameFinnish.Text = facilityTypes.s_facility_type_name_finnish;
            txtDescriptionFinnish.Value = facilityTypes.s_facility_type_desc_finnish;
            txtFacilitytypeNameKorean.Text = facilityTypes.s_facility_type_name_korean;
            txtDescriptionKorian.Value = facilityTypes.s_facility_type_desc_korean;
            txtFacilitytypeNameItalian.Text = facilityTypes.s_facility_type_name_italian;
            txtDescriptionItalian.Value = facilityTypes.s_facility_type_desc_italian;
            txtFacilitytypeNameDutch.Text = facilityTypes.s_facility_type_name_dutch;
            txtDescriptionDutch.Value = facilityTypes.s_facility_type_desc_dutch;
            txtFacilitytypeNameIndonesian.Text = facilityTypes.s_facility_type_name_indonesian;
            txtDescriptionIndonesian.Value = facilityTypes.s_facility_type_desc_indonesian;
            txtFacilitytypeNameGreek.Text = facilityTypes.s_facility_type_name_greek;
            txtDescriptionGreek.Value = facilityTypes.s_facility_type_desc_greek;
            txtFacilitytypeNameHungarian.Text = facilityTypes.s_facility_type_name_hungarian;
            txtDescriptionHungarian.Value = facilityTypes.s_facility_type_desc_hungarian;
            txtFacilitytypeNameNorwegian.Text = facilityTypes.s_facility_type_name_norwegian;
            txtDescriptionNorwegian.Value = facilityTypes.s_facility_type_desc_norwegian;
            txtFacilitytypeNameTurkish.Text = facilityTypes.s_facility_type_name_turkish;
            txtDescriptionTurkish.Value = facilityTypes.s_facility_type_desc_turkish;
            txtFacilitytypeNameArabic.Text = facilityTypes.s_facility_type_name_arabic_rtl;
            txtDescriptionArabic.Value = facilityTypes.s_facility_type_desc_arabic_rtl;
            txtFacilitytypeNameCustom01.Text = facilityTypes.s_facility_type_name_custom_01;
            txtDescriptionCustom01.Value = facilityTypes.s_facility_type_desc_custom_01;
            txtFacilitytypeNameCustom02.Text = facilityTypes.s_facility_type_name_custom_01;
            txtDescriptionCustom02.Value = facilityTypes.s_facility_type_desc_custom_02;
            txtFacilitytypeNameCustom03.Text = facilityTypes.s_facility_type_name_custom_03;
            txtDescriptionCustom03.Value = facilityTypes.s_facility_type_desc_custom_03;
            txtFacilitytypeNameCustom04.Text = facilityTypes.s_facility_type_name_custom_04;
            txtDescriptionCustom04.Value = facilityTypes.s_facility_type_desc_custom_04;
            txtFacilitytypeNameCustom05.Text = facilityTypes.s_facility_type_name_custom_05;
            txtDescriptionCustom05.Value = facilityTypes.s_facility_type_desc_custom_05;
            txtFacilitytypeNameCustom06.Text = facilityTypes.s_facility_type_name_custom_06;
            txtDescriptionCustom06.Value = facilityTypes.s_facility_type_desc_custom_06;
            txtFacilitytypeNameCustom07.Text = facilityTypes.s_facility_type_name_custom_07;
            txtDescriptionCustom07.Value = facilityTypes.s_facility_type_desc_custom_07;
            txtFacilitytypeNameCustom08.Text = facilityTypes.s_facility_type_name_custom_08;
            txtDescriptionCustom08.Value = facilityTypes.s_facility_type_name_custom_08;
            txtFacilitytypeNameCustom09.Text = facilityTypes.s_facility_type_name_custom_09;
            txtDescriptionCustom09.Value = facilityTypes.s_facility_type_desc_custom_09;
            txtFacilitytypeNameCustom10.Text = facilityTypes.s_facility_type_name_custom_10;
            txtDescriptionCustom10.Value = facilityTypes.s_facility_type_desc_custom_10;
            txtFacilitytypeNameCustom11.Text = facilityTypes.s_facility_type_name_custom_11;
            txtDescriptionCustom11.Value = facilityTypes.s_facility_type_name_custom_11;
            txtFacilitytypeNameCustom12.Text = facilityTypes.s_facility_type_name_custom_12;
            txtDescriptionCustom12.Value = facilityTypes.s_facility_type_desc_custom_12;
            txtFacilitytypeNameCustom13.Text = facilityTypes.s_facility_type_name_custom_13;
            txtDescriptionCustom13.Value = facilityTypes.s_facility_type_desc_custom_13;
            txtFacilitytypeNameChinese.Text = facilityTypes.s_facility_type_name_simp_chinese;
            txtDescriptionChinese.Value = facilityTypes.s_facility_type_desc_simp_chinese;

        }

        private void UpdateFacilityTypes()
        {
            SystemFacilityType updateFacility = new SystemFacilityType();
            updateFacility.s_facility_type_system_id_pk = editFacilityTypeId;
            updateFacility.s_facility_type_id = txtFacilityTypeId.Text;
            updateFacility.s_facility_type_status_id_fk = ddlStatus.SelectedValue;

            updateFacility.s_facility_type_name_us_english = txtFacilityTypeName.Text;
            updateFacility.s_facility_type_desc_us_english = txtDescriptionUS.Value;
            updateFacility.s_facility_type_name_uk_english = txtFacilitytypeNameUK.Text;
            updateFacility.s_facility_type_desc_uk_english = txtDecriptionUK.Value;
            updateFacility.s_facility_type_name_ca_french = txtFacilityTypeNameCA.Text;
            updateFacility.s_facility_type_desc_ca_french = txtDecriptionCA.Value;
            updateFacility.s_facility_type_name_fr_french = txtFacilityTypeNameFR.Text;
            updateFacility.s_facility_type_desc_fr_french = txtDescriptionFR.Value;
            updateFacility.s_facility_type_name_mx_spanish = txtFacilitytypeNameMX.Text;
            updateFacility.s_facility_type_desc_mx_spanish = txtDescriptionMX.Value;
            updateFacility.s_facility_type_name_sp_spanish = txtFacilitytypeNameSP.Text;
            updateFacility.s_facility_type_desc_sp_spanish = txtDescriptionSP.Value;
            updateFacility.s_facility_type_name_portuguese = txtFacilitytypeNamePortuguse.Text;
            updateFacility.s_facility_type_desc_portuguese = txtDescriptionPortuguese.Value;
            updateFacility.s_facility_type_name_german = txtFacilitytypeNameGerman.Text;
            updateFacility.s_facility_type_desc_german = txtDescriptionGerman.Value;
            updateFacility.s_facility_type_name_japanese = txtFacilitytypeNameJapanese.Text;
            updateFacility.s_facility_type_desc_japanese = txtDescriptionJapanese.Value;
            updateFacility.s_facility_type_name_russian = txtFacilitytypeNameRussian.Text;
            updateFacility.s_facility_type_desc_russian = txtDescriptionRussian.Value;
            updateFacility.s_facility_type_name_danish = txtFacilitytypeNameDanish.Text;
            updateFacility.s_facility_type_desc_danish = txtDescriptionDanish.Value;
            updateFacility.s_facility_type_name_polish = txtFacilitytypeNamePolish.Text;
            updateFacility.s_facility_type_desc_polish = txtDescriptionPolish.Value;
            updateFacility.s_facility_type_name_swedish = txtFacilitytypeNameSwedish.Text;
            updateFacility.s_facility_type_desc_swedish = txtDescriptionSwedish.Value;
            updateFacility.s_facility_type_name_finnish = txtFacilitytypeNameFinnish.Text;
            updateFacility.s_facility_type_desc_finnish = txtDescriptionFinnish.Value;
            updateFacility.s_facility_type_name_korean = txtFacilitytypeNameKorean.Text;
            updateFacility.s_facility_type_desc_korean = txtDescriptionKorian.Value;
            updateFacility.s_facility_type_name_italian = txtFacilitytypeNameItalian.Text;
            updateFacility.s_facility_type_desc_italian = txtDescriptionItalian.Value;
            updateFacility.s_facility_type_name_dutch = txtFacilitytypeNameDutch.Text;
            updateFacility.s_facility_type_desc_dutch = txtDescriptionDutch.Value;
            updateFacility.s_facility_type_name_indonesian = txtFacilitytypeNameIndonesian.Text;
            updateFacility.s_facility_type_desc_indonesian = txtDescriptionIndonesian.Value;
            updateFacility.s_facility_type_name_greek = txtFacilitytypeNameGreek.Text;
            updateFacility.s_facility_type_desc_greek = txtDescriptionGreek.Value;
            updateFacility.s_facility_type_name_hungarian = txtFacilitytypeNameHungarian.Text;
            updateFacility.s_facility_type_desc_hungarian = txtDescriptionHungarian.Value;
            updateFacility.s_facility_type_name_norwegian = txtFacilitytypeNameNorwegian.Text;
            updateFacility.s_facility_type_desc_norwegian = txtDescriptionNorwegian.Value;
            updateFacility.s_facility_type_name_turkish = txtFacilitytypeNameTurkish.Text;
            updateFacility.s_facility_type_desc_turkish = txtDescriptionTurkish.Value;
            updateFacility.s_facility_type_name_arabic_rtl = txtFacilitytypeNameArabic.Text;
            updateFacility.s_facility_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateFacility.s_facility_type_name_custom_01 = txtFacilitytypeNameCustom01.Text;
            updateFacility.s_facility_type_desc_custom_01 = txtDescriptionCustom01.Value;
            updateFacility.s_facility_type_name_custom_02 = txtFacilitytypeNameCustom02.Text;
            updateFacility.s_facility_type_desc_custom_02 = txtDescriptionCustom02.Value;
            updateFacility.s_facility_type_name_custom_03 = txtFacilitytypeNameCustom03.Text;
            updateFacility.s_facility_type_desc_custom_03 = txtDescriptionCustom03.Value;
            updateFacility.s_facility_type_name_custom_04 = txtFacilitytypeNameCustom04.Text;
            updateFacility.s_facility_type_desc_custom_04 = txtDescriptionCustom04.Value;
            updateFacility.s_facility_type_name_custom_05 = txtFacilitytypeNameCustom05.Text;
            updateFacility.s_facility_type_desc_custom_05 = txtDescriptionCustom05.Value;
            updateFacility.s_facility_type_name_custom_06 = txtFacilitytypeNameCustom06.Text;
            updateFacility.s_facility_type_desc_custom_06 = txtDescriptionCustom06.Value;
            updateFacility.s_facility_type_name_custom_07 = txtFacilitytypeNameCustom07.Text;
            updateFacility.s_facility_type_desc_custom_07 = txtDescriptionCustom07.Value;
            updateFacility.s_facility_type_name_custom_08 = txtFacilitytypeNameCustom08.Text;
            updateFacility.s_facility_type_desc_custom_08 = txtDescriptionCustom08.Value;
            updateFacility.s_facility_type_name_custom_09 = txtFacilitytypeNameCustom09.Text;
            updateFacility.s_facility_type_desc_custom_09 = txtDescriptionCustom09.Value;
            updateFacility.s_facility_type_name_custom_10 = txtFacilitytypeNameCustom10.Text;
            updateFacility.s_facility_type_desc_custom_10 = txtDescriptionCustom10.Value;
            updateFacility.s_facility_type_name_custom_11 = txtFacilitytypeNameCustom11.Text;
            updateFacility.s_facility_type_desc_custom_11 = txtDescriptionCustom11.Value;
            updateFacility.s_facility_type_name_custom_12 = txtFacilitytypeNameCustom12.Text;
            updateFacility.s_facility_type_desc_custom_12 = txtDescriptionCustom12.Value;
            updateFacility.s_facility_type_name_custom_13 = txtFacilitytypeNameCustom13.Text;
            updateFacility.s_facility_type_desc_custom_13 = txtDescriptionCustom13.Value;
            updateFacility.s_facility_type_name_simp_chinese = txtFacilitytypeNameChinese.Text;
            updateFacility.s_facility_type_desc_simp_chinese = txtDescriptionChinese.Value;
            int error;
            error = SystemFacilityTypesBLL.UpdateFacilityTypes(updateFacility);
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
                divError.InnerText = LocalResources.GetText("app_facility_type_id_already_exists_error_text");

            }
        }

        protected void btnHeaderSaveNewFacilityType_Click(object sender, EventArgs e)
        {
            UpdateFacilityTypes();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/FacilityTypes/samftmp-01.aspx", false);
        }

        protected void btnFooterSaveNewFacilityType_Click(object sender, EventArgs e)
        {
            UpdateFacilityTypes();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/FacilityTypes/samftmp-01.aspx", false);
        }
    }
}