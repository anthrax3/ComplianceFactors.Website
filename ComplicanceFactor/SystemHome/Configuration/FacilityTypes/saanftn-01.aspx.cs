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
    public partial class saanftn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/FacilityTypes/samftmp-01.aspx>" + LocalResources.GetLabel("app_manage_facility_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_facility_type_text") + "</a>";
                try
                {
                    ddlStatus.DataSource = SystemFacilityTypesBLL.GetStatus(SessionWrapper.CultureName, "saanftn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateFacilityType(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
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
                            Logger.WriteToErrorLog("saanftn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saanftn-01", ex.Message);
                        }
                    }

                }
            }
        }

        private void SaveFacilityTypes()
        {
            SystemFacilityType createFacility = new SystemFacilityType();
            createFacility.s_facility_type_system_id_pk = Guid.NewGuid().ToString();
            createFacility.s_facility_type_id = txtFacilityTypeId.Text;
            createFacility.s_facility_type_status_id_fk = ddlStatus.SelectedValue;

            createFacility.s_facility_type_name_us_english = txtFacilityTypeName.Text;
            createFacility.s_facility_type_desc_us_english = txtDescriptionUS.Value;
            createFacility.s_facility_type_name_uk_english = txtFacilitytypeNameUK.Text;
            createFacility.s_facility_type_desc_uk_english = txtDecriptionUK.Value;
            createFacility.s_facility_type_name_ca_french = txtFacilityTypeNameCA.Text;
            createFacility.s_facility_type_desc_ca_french = txtDecriptionCA.Value;
            createFacility.s_facility_type_name_fr_french = txtFacilityTypeNameFR.Text;
            createFacility.s_facility_type_desc_fr_french = txtDescriptionFR.Value;
            createFacility.s_facility_type_name_mx_spanish = txtFacilitytypeNameMX.Text;
            createFacility.s_facility_type_desc_mx_spanish = txtDescriptionMX.Value;
            createFacility.s_facility_type_name_sp_spanish = txtFacilitytypeNameSP.Text;
            createFacility.s_facility_type_desc_sp_spanish = txtDescriptionSP.Value;
            createFacility.s_facility_type_name_portuguese = txtFacilitytypeNamePortuguse.Text;
            createFacility.s_facility_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createFacility.s_facility_type_name_german = txtFacilitytypeNameGerman.Text;
            createFacility.s_facility_type_desc_german = txtDescriptionGerman.Value;
            createFacility.s_facility_type_name_japanese = txtFacilitytypeNameJapanese.Text;
            createFacility.s_facility_type_desc_japanese = txtDescriptionJapanese.Value;
            createFacility.s_facility_type_name_russian = txtFacilitytypeNameRussian.Text;
            createFacility.s_facility_type_desc_russian = txtDescriptionRussian.Value;
            createFacility.s_facility_type_name_danish = txtFacilitytypeNameDanish.Text;
            createFacility.s_facility_type_desc_danish = txtDescriptionDanish.Value;
            createFacility.s_facility_type_name_polish = txtFacilitytypeNamePolish.Text;
            createFacility.s_facility_type_desc_polish = txtDescriptionPolish.Value;
            createFacility.s_facility_type_name_swedish = txtFacilitytypeNameSwedish.Text;
            createFacility.s_facility_type_desc_swedish = txtDescriptionSwedish.Value;
            createFacility.s_facility_type_name_finnish = txtFacilitytypeNameFinnish.Text;
            createFacility.s_facility_type_desc_finnish = txtDescriptionFinnish.Value;
            createFacility.s_facility_type_name_korean = txtFacilitytypeNameKorean.Text;
            createFacility.s_facility_type_desc_korean = txtDescriptionKorian.Value;
            createFacility.s_facility_type_name_italian = txtFacilitytypeNameItalian.Text;
            createFacility.s_facility_type_desc_italian = txtDescriptionItalian.Value;
            createFacility.s_facility_type_name_dutch = txtFacilitytypeNameDutch.Text;
            createFacility.s_facility_type_desc_dutch = txtDescriptionDutch.Value;
            createFacility.s_facility_type_name_indonesian = txtFacilitytypeNameIndonesian.Text;
            createFacility.s_facility_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createFacility.s_facility_type_name_greek = txtFacilitytypeNameGreek.Text;
            createFacility.s_facility_type_desc_greek = txtDescriptionGreek.Value;
            createFacility.s_facility_type_name_hungarian = txtFacilitytypeNameHungarian.Text;
            createFacility.s_facility_type_desc_hungarian = txtDescriptionHungarian.Value;
            createFacility.s_facility_type_name_norwegian = txtFacilitytypeNameNorwegian.Text;
            createFacility.s_facility_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createFacility.s_facility_type_name_turkish = txtFacilitytypeNameTurkish.Text;
            createFacility.s_facility_type_desc_turkish = txtDescriptionTurkish.Value;
            createFacility.s_facility_type_name_arabic_rtl = txtFacilitytypeNameArabic.Text;
            createFacility.s_facility_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createFacility.s_facility_type_name_custom_01 = txtFacilitytypeNameCustom01.Text;
            createFacility.s_facility_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createFacility.s_facility_type_name_custom_02 = txtFacilitytypeNameCustom02.Text;
            createFacility.s_facility_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createFacility.s_facility_type_name_custom_03 = txtFacilitytypeNameCustom03.Text;
            createFacility.s_facility_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createFacility.s_facility_type_name_custom_04 = txtFacilitytypeNameCustom04.Text;
            createFacility.s_facility_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createFacility.s_facility_type_name_custom_05 = txtFacilitytypeNameCustom05.Text;
            createFacility.s_facility_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createFacility.s_facility_type_name_custom_06 = txtFacilitytypeNameCustom06.Text;
            createFacility.s_facility_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createFacility.s_facility_type_name_custom_07 = txtFacilitytypeNameCustom07.Text;
            createFacility.s_facility_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createFacility.s_facility_type_name_custom_08 = txtFacilitytypeNameCustom08.Text;
            createFacility.s_facility_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createFacility.s_facility_type_name_custom_09 = txtFacilitytypeNameCustom09.Text;
            createFacility.s_facility_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createFacility.s_facility_type_name_custom_10 = txtFacilitytypeNameCustom10.Text;
            createFacility.s_facility_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createFacility.s_facility_type_name_custom_11 = txtFacilitytypeNameCustom11.Text;
            createFacility.s_facility_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createFacility.s_facility_type_name_custom_12 = txtFacilitytypeNameCustom12.Text;
            createFacility.s_facility_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createFacility.s_facility_type_name_custom_13 = txtFacilitytypeNameCustom13.Text;
            createFacility.s_facility_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createFacility.s_facility_type_name_simp_chinese = txtFacilitytypeNameChinese.Text;
            createFacility.s_facility_type_desc_simp_chinese = txtDescriptionChinese.Value;
            int error;
            error = SystemFacilityTypesBLL.CreateFacilityTypes(createFacility);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Configuration/FacilityTypes/saeftn-01.aspx?id=" + SecurityCenter.EncryptText(createFacility.s_facility_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
            else
            {
                ///<summary>
                ///Show error message 
                ///</summary>
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_facility_type_id_already_exists_error_text");
            }


        }

        protected void btnHeaderSaveNewFacilityType_Click(object sender, EventArgs e)
        {
            SaveFacilityTypes();
        }

        private void PopulateFacilityType(string FacilityTypesId)
        {
            SystemFacilityType facilityTypes = new SystemFacilityType();
            facilityTypes = SystemFacilityTypesBLL.GetFacilityType(FacilityTypesId);

            txtFacilityTypeId.Text = facilityTypes.s_facility_type_id + "_Copy";
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
            SaveFacilityTypes();
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