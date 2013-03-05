using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.MaterialTypes
{
    public partial class saanmtn_01 : BasePage
    {
        private static string copyMaterialId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlStatus.DataSource = SystemMaterialTypeBLL.GetStatus(SessionWrapper.CultureName, "samftmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";
                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    copyMaterialId = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PoulateMaterial(copyMaterialId);
                }

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/MaterialTypes/sammtmp-01.aspx>" + LocalResources.GetLabel("app_manage_Material_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_Material_type_text");
            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/MaterialTypes/sammtmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/MaterialTypes/sammtmp-01.aspx");
        }

        protected void btnHeaderSaveNewMaterialType_Click(object sender, EventArgs e)
        {
            SaveMaterialType();
        }

        protected void btnFooterSaveNewMaterialType_Click(object sender, EventArgs e)
        {
            SaveMaterialType();
        }

        void SaveMaterialType()
        {
            SystemMaterialType createMaterial = new SystemMaterialType();
            createMaterial.s_material_type_system_id_pk = Guid.NewGuid().ToString();
            createMaterial.s_material_type_id = txtMaterialTypeId.Text;
            createMaterial.s_material_type_status_id_fk = ddlStatus.SelectedValue;
            createMaterial.s_material_type_name_us_english = txtMaterialTypeName.Text;
            createMaterial.s_material_type_desc_us_english = txtDescriptionUS.Value;
            createMaterial.s_material_type_name_uk_english = txtMaterialTypeNameUK.Text;
            createMaterial.s_material_type_desc_uk_english = txtDescriptionUK.Value;
            createMaterial.s_material_type_name_ca_french = txtMaterialTypeNameCA.Text;
            createMaterial.s_material_type_desc_ca_french = txtDescriptionCA.Value;
            createMaterial.s_material_type_name_fr_french = txtMaterialTypeNameFR.Text;
            createMaterial.s_material_type_desc_fr_french = txtDescriptionFR.Value;
            createMaterial.s_material_type_name_mx_spanish = txtMaterialTypeNameMX.Text;
            createMaterial.s_material_type_desc_mx_spanish = txtDescriptionMX.Value;
            createMaterial.s_material_type_name_sp_spanish = txtMaterialTypeNameSP.Text;
            createMaterial.s_material_type_desc_sp_spanish = txtDescriptionSP.Value;
            createMaterial.s_material_type_name_portuguese = txtMaterialTypeNamePortuguse.Text;
            createMaterial.s_material_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createMaterial.s_material_type_name_german = txtMaterialTypeNameGerman.Text;
            createMaterial.s_material_type_desc_german = txtDescriptionGerman.Value;
            createMaterial.s_material_type_name_japanese = txtMaterialTypeNameJapanese.Text;
            createMaterial.s_material_type_desc_japanese = txtDescriptionJapanese.Value;
            createMaterial.s_material_type_name_russian = txtMaterialTypeNameRussian.Text;
            createMaterial.s_material_type_desc_russian = txtDescriptionRussian.Value;
            createMaterial.s_material_type_name_danish = txtMaterialTypeNameDanish.Text;
            createMaterial.s_material_type_desc_danish = txtDescriptionDanish.Value;
            createMaterial.s_material_type_name_polish = txtMaterialTypeNamePolish.Text;
            createMaterial.s_material_type_desc_polish = txtDescriptionPolish.Value;
            createMaterial.s_material_type_name_swedish = txtMaterialTypeNameSwedish.Text;
            createMaterial.s_material_type_desc_swedish = txtDescriptionSwedish.Value;
            createMaterial.s_material_type_name_finnish = txtMaterialTypeNameFinnish.Text;
            createMaterial.s_material_type_desc_finnish = txtDescriptionFinnish.Value;
            createMaterial.s_material_type_name_korean = txtMaterialTypeNameKorean.Text;
            createMaterial.s_material_type_desc_korean = txtDescriptionKorean.Value;
            createMaterial.s_material_type_name_italian = txtMaterialTypeNameItalian.Text;
            createMaterial.s_material_type_desc_italian = txtDescriptionItalian.Value;
            createMaterial.s_material_type_name_dutch = txtMaterialTypeNameDutch.Text;
            createMaterial.s_material_type_desc_dutch = txtDescriptionDutch.Value;
            createMaterial.s_material_type_name_indonesian = txtMaterialTypeNameIndonesian.Text;
            createMaterial.s_material_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createMaterial.s_material_type_name_greek = txtMaterialTypeNameGreek.Text;
            createMaterial.s_material_type_desc_greek = txtDescriptionGreek.Value;
            createMaterial.s_material_type_name_hungarian = txtMaterialTypeNameHungarian.Text;
            createMaterial.s_material_type_desc_hungarian = txtDescriptionHungarian.Value;
            createMaterial.s_material_type_name_norwegian = txtMaterialTypeNameNorwegian.Text;
            createMaterial.s_material_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createMaterial.s_material_type_name_turkish = txtMaterialTypeNameTurkish.Text;
            createMaterial.s_material_type_desc_turkish = txtDescriptionTurkish.Value;
            createMaterial.s_material_type_name_arabic_rtl = txtMaterialTypeNameArabic.Text;
            createMaterial.s_material_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createMaterial.s_material_type_name_custom_01 = txtMaterialTypeNameCustom01.Text;
            createMaterial.s_material_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createMaterial.s_material_type_name_custom_02 = txtMaterialTypeNameCustom02.Text;
            createMaterial.s_material_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createMaterial.s_material_type_name_custom_03 = txtMaterialTypeNameCustom03.Text;
            createMaterial.s_material_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createMaterial.s_material_type_name_custom_04 = txtMaterialTypeNameCustom04.Text;
            createMaterial.s_material_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createMaterial.s_material_type_name_custom_05 = txtMaterialTypeNameCustom05.Text;
            createMaterial.s_material_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createMaterial.s_material_type_name_custom_06 = txtMaterialTypeNameCustom06.Text;
            createMaterial.s_material_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createMaterial.s_material_type_name_custom_07 = txtMaterialTypeNameCustom07.Text;
            createMaterial.s_material_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createMaterial.s_material_type_name_custom_08 = txtMaterialTypeNameCustom08.Text;
            createMaterial.s_material_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createMaterial.s_material_type_name_custom_09 = txtMaterialTypeNameCustom09.Text;
            createMaterial.s_material_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createMaterial.s_material_type_name_custom_10 = txtMaterialTypeNameCustom10.Text;
            createMaterial.s_material_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createMaterial.s_material_type_name_custom_11 = txtMaterialTypeNameCustom11.Text;
            createMaterial.s_material_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createMaterial.s_material_type_name_custom_12 = txtMaterialTypeNameCustom12.Text;
            createMaterial.s_material_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createMaterial.s_material_type_name_custom_13 = txtMaterialTypeNameCustom13.Text;
            createMaterial.s_material_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createMaterial.s_material_type_name_simp_chinese = txtMaterialTypeNameChinese.Text;
            createMaterial.s_material_type_desc_simp_chinese = txtDescriptionChinese.Value;

            try
            {

                int result = SystemMaterialTypeBLL.CreateMaterialType(createMaterial);

                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/MaterialTypes/saemtn-01.aspx?id=" + SecurityCenter.EncryptText(createMaterial.s_material_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {

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
                        Logger.WriteToErrorLog("saanmtn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanmtn-01", ex.Message);
                    }
                }
            }

        }

        /// <summary>
        /// Populate the Material values
        /// </summary>
        /// <param name="editMaterialId"></param>
        void PoulateMaterial(string editMaterialId)
        {
            SystemMaterialType materialTypes = new SystemMaterialType();
            materialTypes = SystemMaterialTypeBLL.GetMaterialType(editMaterialId);
            txtMaterialTypeId.Text = materialTypes.s_material_type_id + "_Copy";
            ddlStatus.SelectedValue = materialTypes.s_material_type_status_id_fk;
            txtMaterialTypeName.Text = materialTypes.s_material_type_name_us_english;
            txtDescriptionUS.Value = materialTypes.s_material_type_desc_us_english;
            txtMaterialTypeNameUK.Text = materialTypes.s_material_type_name_uk_english;
            txtDescriptionUK.Value = materialTypes.s_material_type_desc_uk_english;
            txtMaterialTypeNameCA.Text = materialTypes.s_material_type_name_ca_french;
            txtDescriptionCA.Value = materialTypes.s_material_type_desc_ca_french;
            txtMaterialTypeNameFR.Text = materialTypes.s_material_type_name_fr_french;
            txtDescriptionFR.Value = materialTypes.s_material_type_desc_fr_french;
            txtMaterialTypeNameMX.Text = materialTypes.s_material_type_name_mx_spanish;
            txtDescriptionMX.Value = materialTypes.s_material_type_desc_mx_spanish;
            txtMaterialTypeNameSP.Text = materialTypes.s_material_type_name_sp_spanish;
            txtDescriptionSP.Value = materialTypes.s_material_type_desc_sp_spanish;
            txtMaterialTypeNamePortuguse.Text = materialTypes.s_material_type_name_portuguese;
            txtDescriptionPortuguese.Value = materialTypes.s_material_type_desc_portuguese;
            txtMaterialTypeNameGerman.Text = materialTypes.s_material_type_name_german;
            txtDescriptionGerman.Value = materialTypes.s_material_type_desc_german;
            txtMaterialTypeNameJapanese.Text = materialTypes.s_material_type_name_japanese;
            txtDescriptionJapanese.Value = materialTypes.s_material_type_desc_japanese;
            txtMaterialTypeNameRussian.Text = materialTypes.s_material_type_name_russian;
            txtDescriptionRussian.Value = materialTypes.s_material_type_desc_russian;
            txtMaterialTypeNameDanish.Text = materialTypes.s_material_type_name_danish;
            txtDescriptionDanish.Value = materialTypes.s_material_type_desc_danish;
            txtMaterialTypeNamePolish.Text = materialTypes.s_material_type_name_polish;
            txtDescriptionPolish.Value = materialTypes.s_material_type_desc_polish;
            txtMaterialTypeNameSwedish.Text = materialTypes.s_material_type_name_swedish;
            txtDescriptionSwedish.Value = materialTypes.s_material_type_desc_swedish;
            txtMaterialTypeNameFinnish.Text = materialTypes.s_material_type_name_finnish;
            txtDescriptionFinnish.Value = materialTypes.s_material_type_desc_finnish;
            txtMaterialTypeNameKorean.Text = materialTypes.s_material_type_name_korean;
            txtDescriptionKorean.Value = materialTypes.s_material_type_desc_korean;
            txtMaterialTypeNameItalian.Text = materialTypes.s_material_type_name_italian;
            txtDescriptionItalian.Value = materialTypes.s_material_type_desc_italian;
            txtMaterialTypeNameDutch.Text = materialTypes.s_material_type_name_dutch;
            txtDescriptionDutch.Value = materialTypes.s_material_type_desc_dutch;
            txtMaterialTypeNameIndonesian.Text = materialTypes.s_material_type_name_indonesian;
            txtDescriptionIndonesian.Value = materialTypes.s_material_type_desc_indonesian;
            txtMaterialTypeNameGreek.Text = materialTypes.s_material_type_name_greek;
            txtDescriptionGreek.Value = materialTypes.s_material_type_desc_greek;
            txtMaterialTypeNameHungarian.Text = materialTypes.s_material_type_name_hungarian;
            txtDescriptionHungarian.Value = materialTypes.s_material_type_desc_hungarian;
            txtMaterialTypeNameNorwegian.Text = materialTypes.s_material_type_name_norwegian;
            txtDescriptionNorwegian.Value = materialTypes.s_material_type_desc_norwegian;
            txtMaterialTypeNameTurkish.Text = materialTypes.s_material_type_name_turkish;
            txtDescriptionTurkish.Value = materialTypes.s_material_type_desc_turkish;
            txtMaterialTypeNameArabic.Text = materialTypes.s_material_type_name_arabic_rtl;
            txtDescriptionArabic.Value = materialTypes.s_material_type_desc_arabic_rtl;
            txtMaterialTypeNameCustom01.Text = materialTypes.s_material_type_name_custom_01;
            txtDescriptionCustom01.Value = materialTypes.s_material_type_desc_custom_01;
            txtMaterialTypeNameCustom02.Text = materialTypes.s_material_type_name_custom_01;
            txtDescriptionCustom02.Value = materialTypes.s_material_type_desc_custom_02;
            txtMaterialTypeNameCustom03.Text = materialTypes.s_material_type_name_custom_03;
            txtDescriptionCustom03.Value = materialTypes.s_material_type_desc_custom_03;
            txtMaterialTypeNameCustom04.Text = materialTypes.s_material_type_name_custom_04;
            txtDescriptionCustom04.Value = materialTypes.s_material_type_desc_custom_04;
            txtMaterialTypeNameCustom05.Text = materialTypes.s_material_type_name_custom_05;
            txtDescriptionCustom05.Value = materialTypes.s_material_type_desc_custom_05;
            txtMaterialTypeNameCustom06.Text = materialTypes.s_material_type_name_custom_06;
            txtDescriptionCustom06.Value = materialTypes.s_material_type_desc_custom_06;
            txtMaterialTypeNameCustom07.Text = materialTypes.s_material_type_name_custom_07;
            txtDescriptionCustom07.Value = materialTypes.s_material_type_desc_custom_07;
            txtMaterialTypeNameCustom08.Text = materialTypes.s_material_type_name_custom_08;
            txtDescriptionCustom08.Value = materialTypes.s_material_type_name_custom_08;
            txtMaterialTypeNameCustom09.Text = materialTypes.s_material_type_name_custom_09;
            txtDescriptionCustom09.Value = materialTypes.s_material_type_desc_custom_09;
            txtMaterialTypeNameCustom10.Text = materialTypes.s_material_type_name_custom_10;
            txtDescriptionCustom10.Value = materialTypes.s_material_type_desc_custom_10;
            txtMaterialTypeNameCustom11.Text = materialTypes.s_material_type_name_custom_11;
            txtDescriptionCustom11.Value = materialTypes.s_material_type_name_custom_11;
            txtMaterialTypeNameCustom12.Text = materialTypes.s_material_type_name_custom_12;
            txtDescriptionCustom12.Value = materialTypes.s_material_type_desc_custom_12;
            txtMaterialTypeNameCustom13.Text = materialTypes.s_material_type_name_custom_13;
            txtDescriptionCustom13.Value = materialTypes.s_material_type_desc_custom_13;
            txtMaterialTypeNameChinese.Text = materialTypes.s_material_type_name_simp_chinese;
            txtDescriptionChinese.Value = materialTypes.s_material_type_desc_simp_chinese;

        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}