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

namespace ComplicanceFactor.SystemHome.Configuration.MaterialTypes
{

    public partial class saemtn_01 : BasePage
    {
        private static string editMaterialId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Bind material type status
                ddlStatus.DataSource = SystemMaterialTypeBLL.GetStatus(SessionWrapper.CultureName, "saemtn-01");
                ddlStatus.DataBind();
                 

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editMaterialId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    PoulateMaterial(editMaterialId);
                }
                //label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system")+ "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/MaterialTypes/sammtmp-01.aspx>" +LocalResources.GetLabel("app_manage_Material_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_material_type_text");

                

                ///Show success message
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
            }
        }
        /// <summary>
        /// Populate value from Material type (table)
        /// </summary>
        /// <param name="editMaterialId"></param>
        void PoulateMaterial(string editMaterialId)
        {
            SystemMaterialType materialTypes = new SystemMaterialType();
            materialTypes = SystemMaterialTypeBLL.GetMaterialType(editMaterialId);
            txtMaterialTypeId.Text = materialTypes.s_material_type_id;
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

        protected void btnHeaderSaveNewMaterialType_Click(object sender, EventArgs e)
        {
            UpdateMaterial();
        }

        protected void btnFooterSaveNewMaterialType_Click(object sender, EventArgs e)
        {
            UpdateMaterial();
        }

        void UpdateMaterial()
        {
            SystemMaterialType materialType = new SystemMaterialType();
            materialType.s_material_type_system_id_pk = editMaterialId;
            materialType.s_material_type_id = txtMaterialTypeId.Text;
            materialType.s_material_type_status_id_fk = ddlStatus.SelectedValue;
            materialType.s_material_type_name_us_english = txtMaterialTypeName.Text;
            materialType.s_material_type_desc_us_english = txtDescriptionUS.Value;
            materialType.s_material_type_name_uk_english = txtMaterialTypeNameUK.Text;
            materialType.s_material_type_desc_uk_english = txtDescriptionUK.Value;
            materialType.s_material_type_name_ca_french = txtMaterialTypeNameCA.Text;
            materialType.s_material_type_desc_ca_french = txtDescriptionCA.Value;
            materialType.s_material_type_name_fr_french = txtMaterialTypeNameFR.Text;
            materialType.s_material_type_desc_fr_french = txtDescriptionFR.Value;
            materialType.s_material_type_name_mx_spanish = txtMaterialTypeNameMX.Text;
            materialType.s_material_type_desc_mx_spanish = txtDescriptionMX.Value;
            materialType.s_material_type_name_sp_spanish = txtMaterialTypeNameSP.Text;
            materialType.s_material_type_desc_sp_spanish = txtDescriptionSP.Value;
            materialType.s_material_type_name_portuguese = txtMaterialTypeNamePortuguse.Text;
            materialType.s_material_type_desc_portuguese = txtDescriptionPortuguese.Value;
            materialType.s_material_type_name_german = txtMaterialTypeNameGerman.Text;
            materialType.s_material_type_desc_german = txtDescriptionGerman.Value;
            materialType.s_material_type_name_japanese = txtMaterialTypeNameJapanese.Text;
            materialType.s_material_type_desc_japanese = txtDescriptionJapanese.Value;
            materialType.s_material_type_name_russian = txtMaterialTypeNameRussian.Text;
            materialType.s_material_type_desc_russian = txtDescriptionRussian.Value;
            materialType.s_material_type_name_danish = txtMaterialTypeNameDanish.Text;
            materialType.s_material_type_desc_danish = txtDescriptionDanish.Value;
            materialType.s_material_type_name_polish = txtMaterialTypeNamePolish.Text;
            materialType.s_material_type_desc_polish = txtDescriptionPolish.Value;
            materialType.s_material_type_name_swedish = txtMaterialTypeNameSwedish.Text;
            materialType.s_material_type_desc_swedish = txtDescriptionSwedish.Value;
            materialType.s_material_type_name_finnish = txtMaterialTypeNameFinnish.Text;
            materialType.s_material_type_desc_finnish = txtDescriptionFinnish.Value;
            materialType.s_material_type_name_korean = txtMaterialTypeNameKorean.Text;
            materialType.s_material_type_desc_korean = txtDescriptionKorean.Value;
            materialType.s_material_type_name_italian = txtMaterialTypeNameItalian.Text;
            materialType.s_material_type_desc_italian = txtDescriptionItalian.Value;
            materialType.s_material_type_name_dutch = txtMaterialTypeNameDutch.Text;
            materialType.s_material_type_desc_dutch = txtDescriptionDutch.Value;
            materialType.s_material_type_name_indonesian = txtMaterialTypeNameIndonesian.Text;
            materialType.s_material_type_desc_indonesian = txtDescriptionIndonesian.Value;
            materialType.s_material_type_name_greek = txtMaterialTypeNameGreek.Text;
            materialType.s_material_type_desc_greek = txtDescriptionGreek.Value;
            materialType.s_material_type_name_hungarian = txtMaterialTypeNameHungarian.Text;
            materialType.s_material_type_desc_hungarian = txtDescriptionHungarian.Value;
            materialType.s_material_type_name_norwegian = txtMaterialTypeNameNorwegian.Text;
            materialType.s_material_type_desc_norwegian = txtDescriptionNorwegian.Value;
            materialType.s_material_type_name_turkish = txtMaterialTypeNameTurkish.Text;
            materialType.s_material_type_desc_turkish = txtDescriptionTurkish.Value;
            materialType.s_material_type_name_arabic_rtl = txtMaterialTypeNameArabic.Text;
            materialType.s_material_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            materialType.s_material_type_name_custom_01 = txtMaterialTypeNameCustom01.Text;
            materialType.s_material_type_desc_custom_01 = txtDescriptionCustom01.Value;
            materialType.s_material_type_name_custom_02 = txtMaterialTypeNameCustom02.Text;
            materialType.s_material_type_desc_custom_02 = txtDescriptionCustom02.Value;
            materialType.s_material_type_name_custom_03 = txtMaterialTypeNameCustom03.Text;
            materialType.s_material_type_desc_custom_03 = txtDescriptionCustom03.Value;
            materialType.s_material_type_name_custom_04 = txtMaterialTypeNameCustom04.Text;
            materialType.s_material_type_desc_custom_04 = txtDescriptionCustom04.Value;
            materialType.s_material_type_name_custom_05 = txtMaterialTypeNameCustom05.Text;
            materialType.s_material_type_desc_custom_05 = txtDescriptionCustom05.Value;
            materialType.s_material_type_name_custom_06 = txtMaterialTypeNameCustom06.Text;
            materialType.s_material_type_desc_custom_06 = txtDescriptionCustom06.Value;
            materialType.s_material_type_name_custom_07 = txtMaterialTypeNameCustom07.Text;
            materialType.s_material_type_desc_custom_07 = txtDescriptionCustom07.Value;
            materialType.s_material_type_name_custom_08 = txtMaterialTypeNameCustom08.Text;
            materialType.s_material_type_desc_custom_08 = txtDescriptionCustom08.Value;
            materialType.s_material_type_name_custom_09 = txtMaterialTypeNameCustom09.Text;
            materialType.s_material_type_desc_custom_09 = txtDescriptionCustom09.Value;
            materialType.s_material_type_name_custom_10 = txtMaterialTypeNameCustom10.Text;
            materialType.s_material_type_desc_custom_10 = txtDescriptionCustom10.Value;
            materialType.s_material_type_name_custom_11 = txtMaterialTypeNameCustom11.Text;
            materialType.s_material_type_desc_custom_11 = txtDescriptionCustom11.Value;
            materialType.s_material_type_name_custom_12 = txtMaterialTypeNameCustom12.Text;
            materialType.s_material_type_desc_custom_12 = txtDescriptionCustom12.Value;
            materialType.s_material_type_name_custom_13 = txtMaterialTypeNameCustom13.Text;
            materialType.s_material_type_desc_custom_13 = txtDescriptionCustom13.Value;
            materialType.s_material_type_name_simp_chinese = txtMaterialTypeNameChinese.Text;
            materialType.s_material_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int result = SystemMaterialTypeBLL.UpdateMaterialType(materialType);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
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
                        Logger.WriteToErrorLog("saemtn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saemtn-01", ex.Message);
                    }
                }

            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/MaterialTypes/sammtmp-01.aspx");
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/MaterialTypes/sammtmp-01.aspx");
        }
    }
}