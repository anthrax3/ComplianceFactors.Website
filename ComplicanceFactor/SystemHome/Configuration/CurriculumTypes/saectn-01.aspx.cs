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

namespace ComplicanceFactor.SystemHome.Configuration.CurriculumTypes
{
    public partial class saectn_01 : System.Web.UI.Page
    {
        private static string editCurriculumTypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Edit Curriculum Type Id
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                editCurriculumTypeId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
            }
            if (!IsPostBack)
            {
                //Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/CurriculumTypes/samctmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_curriculum_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_edit_curriculum_type_text") + "</a>";

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                //Bind Status
                ddlStatus.DataSource = SystemCurriculumTypeBLL.GetStatus(SessionWrapper.CultureName, "saectn-01");
                ddlStatus.DataBind();                 

                PopulateCurriculumType(editCurriculumTypeId);
            }
        }
        /// <summary>
        /// Populate the values for Edit
        /// </summary>
        /// <param name="CurriculumTypesId"></param>
        private void PopulateCurriculumType(string CurriculumTypesId)
        {
            SystemCurriculumType curriculumType = new SystemCurriculumType();
            try
            {
                curriculumType = SystemCurriculumTypeBLL.GetCurriculumType(CurriculumTypesId);
                txtCurriculumTypeId.Text = curriculumType.s_curriculum_type_id;
                ddlStatus.SelectedValue = curriculumType.s_curriculum_type_status_id_fk;

                txtCurriculumTypeName.Text = curriculumType.s_curriculum_type_name_us_english;
                txtDescriptionUS.Value = curriculumType.s_curriculum_type_desc_us_english;
                txtCurriculumTypeNameUK.Text = curriculumType.s_curriculum_type_name_uk_english;
                txtDescriptionUK.Value = curriculumType.s_curriculum_type_desc_uk_english;
                txtCurriculumTypeNameCA.Text = curriculumType.s_curriculum_type_name_ca_french;
                txtDescriptionCA.Value = curriculumType.s_curriculum_type_desc_ca_french;
                txtCurriculumTypeNameFR.Text = curriculumType.s_curriculum_type_name_fr_french;
                txtDescriptionFR.Value = curriculumType.s_curriculum_type_desc_fr_french;
                txtCurriculumTypeNameMX.Text = curriculumType.s_curriculum_type_name_mx_spanish;
                txtDescriptionMX.Value = curriculumType.s_curriculum_type_desc_mx_spanish;
                txtCurriculumTypeNameSP.Text = curriculumType.s_curriculum_type_name_sp_spanish;
                txtDescriptionSP.Value = curriculumType.s_curriculum_type_desc_sp_spanish;
                txtCurriculumTypeNamePortuguse.Text = curriculumType.s_curriculum_type_name_portuguese;
                txtDescriptionPortuguese.Value = curriculumType.s_curriculum_type_desc_portuguese;
                txtCurriculumTypeNameGerman.Text = curriculumType.s_curriculum_type_name_german;
                txtDescriptionGerman.Value = curriculumType.s_curriculum_type_desc_german;
                txtCurriculumTypeNameJapanese.Text = curriculumType.s_curriculum_type_name_japanese;
                txtDescriptionJapanese.Value = curriculumType.s_curriculum_type_desc_japanese;
                txtCurriculumTypeNameRussian.Text = curriculumType.s_curriculum_type_name_russian;
                txtDescriptionRussian.Value = curriculumType.s_curriculum_type_desc_russian;
                txtCurriculumTypeNameDanish.Text = curriculumType.s_curriculum_type_name_danish;
                txtDescriptionDanish.Value = curriculumType.s_curriculum_type_desc_danish;
                txtCurriculumTypeNamePolish.Text = curriculumType.s_curriculum_type_name_polish;
                txtDescriptionPolish.Value = curriculumType.s_curriculum_type_desc_polish;
                txtCurriculumTypeNameSwedish.Text = curriculumType.s_curriculum_type_name_swedish;
                txtDescriptionSwedish.Value = curriculumType.s_curriculum_type_desc_swedish;
                txtCurriculumTypeNameFinnish.Text = curriculumType.s_curriculum_type_name_finnish;
                txtDescriptionFinnish.Value = curriculumType.s_curriculum_type_desc_finnish;
                txtCurriculumTypeNameKorean.Text = curriculumType.s_curriculum_type_name_korean;
                txtDescriptionKorean.Value = curriculumType.s_curriculum_type_desc_korean;
                txtCurriculumTypeNameItalian.Text = curriculumType.s_curriculum_type_name_italian;
                txtDescriptionItalian.Value = curriculumType.s_curriculum_type_desc_italian;
                txtCurriculumTypeNameDutch.Text = curriculumType.s_curriculum_type_name_dutch;
                txtDescriptionDutch.Value = curriculumType.s_curriculum_type_desc_dutch;
                txtCurriculumTypeNameIndonesian.Text = curriculumType.s_curriculum_type_name_indonesian;
                txtDescriptionIndonesian.Value = curriculumType.s_curriculum_type_desc_indonesian;
                txtCurriculumTypeNameGreek.Text = curriculumType.s_curriculum_type_name_greek;
                txtDescriptionGreek.Value = curriculumType.s_curriculum_type_desc_greek;
                txtCurriculumTypeNameHungarian.Text = curriculumType.s_curriculum_type_name_hungarian;
                txtDescriptionHungarian.Value = curriculumType.s_curriculum_type_desc_hungarian;
                txtCurriculumTypeNameNorwegian.Text = curriculumType.s_curriculum_type_name_norwegian;
                txtDescriptionNorwegian.Value = curriculumType.s_curriculum_type_desc_norwegian;
                txtCurriculumTypeNameTurkish.Text = curriculumType.s_curriculum_type_name_turkish;
                txtDescriptionTurkish.Value = curriculumType.s_curriculum_type_desc_turkish;
                txtCurriculumTypeNameArabic.Text = curriculumType.s_curriculum_type_name_arabic_rtl;
                txtDescriptionArabic.Value = curriculumType.s_curriculum_type_desc_arabic_rtl;
                txtCurriculumTypeNameCustom01.Text = curriculumType.s_curriculum_type_name_custom_01;
                txtDescriptionCustom01.Value = curriculumType.s_curriculum_type_desc_custom_01;
                txtCurriculumTypeNameCustom02.Text = curriculumType.s_curriculum_type_name_custom_01;
                txtDescriptionCustom02.Value = curriculumType.s_curriculum_type_desc_custom_02;
                txtCurriculumTypeNameCustom03.Text = curriculumType.s_curriculum_type_name_custom_03;
                txtDescriptionCustom03.Value = curriculumType.s_curriculum_type_desc_custom_03;
                txtCurriculumTypeNameCustom04.Text = curriculumType.s_curriculum_type_name_custom_04;
                txtDescriptionCustom04.Value = curriculumType.s_curriculum_type_desc_custom_04;
                txtCurriculumTypeNameCustom05.Text = curriculumType.s_curriculum_type_name_custom_05;
                txtDescriptionCustom05.Value = curriculumType.s_curriculum_type_desc_custom_05;
                txtCurriculumTypeNameCustom06.Text = curriculumType.s_curriculum_type_name_custom_06;
                txtDescriptionCustom06.Value = curriculumType.s_curriculum_type_desc_custom_06;
                txtCurriculumTypeNameCustom07.Text = curriculumType.s_curriculum_type_name_custom_07;
                txtDescriptionCustom07.Value = curriculumType.s_curriculum_type_desc_custom_07;
                txtCurriculumTypeNameCustom08.Text = curriculumType.s_curriculum_type_name_custom_08;
                txtDescriptionCustom08.Value = curriculumType.s_curriculum_type_name_custom_08;
                txtCurriculumTypeNameCustom09.Text = curriculumType.s_curriculum_type_name_custom_09;
                txtDescriptionCustom09.Value = curriculumType.s_curriculum_type_desc_custom_09;
                txtCurriculumTypeNameCustom10.Text = curriculumType.s_curriculum_type_name_custom_10;
                txtDescriptionCustom10.Value = curriculumType.s_curriculum_type_desc_custom_10;
                txtCurriculumTypeNameCustom11.Text = curriculumType.s_curriculum_type_name_custom_11;
                txtDescriptionCustom11.Value = curriculumType.s_curriculum_type_name_custom_11;
                txtCurriculumTypeNameCustom12.Text = curriculumType.s_curriculum_type_name_custom_12;
                txtDescriptionCustom12.Value = curriculumType.s_curriculum_type_desc_custom_12;
                txtCurriculumTypeNameCustom13.Text = curriculumType.s_curriculum_type_name_custom_13;
                txtDescriptionCustom13.Value = curriculumType.s_curriculum_type_desc_custom_13;
                txtCurriculumTypeNameChinese.Text = curriculumType.s_curriculum_type_name_simp_chinese;
                txtDescriptionChinese.Value = curriculumType.s_curriculum_type_desc_simp_chinese;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saectn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saectn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveCurriculumType_Click(object sender, EventArgs e)
        {
            UpdateCurriculumTypes();
        }

        protected void btnFooterSaveCurriculumType_Click(object sender, EventArgs e)
        {
            UpdateCurriculumTypes();
        }

        /// <summary>
        /// Update the Curriculum Type
        /// </summary>        

        private void UpdateCurriculumTypes()
        {
            SystemCurriculumType updateCurriculum = new SystemCurriculumType();

            updateCurriculum.s_curriculum_type_system_id_pk = editCurriculumTypeId;
            updateCurriculum.s_curriculum_type_id = txtCurriculumTypeId.Text;
            updateCurriculum.s_curriculum_type_status_id_fk = ddlStatus.SelectedValue;

            updateCurriculum.s_curriculum_type_name_us_english = txtCurriculumTypeName.Text;
            updateCurriculum.s_curriculum_type_desc_us_english = txtDescriptionUS.Value;
            updateCurriculum.s_curriculum_type_name_uk_english = txtCurriculumTypeNameUK.Text;
            updateCurriculum.s_curriculum_type_desc_uk_english = txtDescriptionUK.Value;
            updateCurriculum.s_curriculum_type_name_ca_french = txtCurriculumTypeNameCA.Text;
            updateCurriculum.s_curriculum_type_desc_ca_french = txtDescriptionCA.Value;
            updateCurriculum.s_curriculum_type_name_fr_french = txtCurriculumTypeNameFR.Text;
            updateCurriculum.s_curriculum_type_desc_fr_french = txtDescriptionFR.Value;
            updateCurriculum.s_curriculum_type_name_mx_spanish = txtCurriculumTypeNameMX.Text;
            updateCurriculum.s_curriculum_type_desc_mx_spanish = txtDescriptionMX.Value;
            updateCurriculum.s_curriculum_type_name_sp_spanish = txtCurriculumTypeNameSP.Text;
            updateCurriculum.s_curriculum_type_desc_sp_spanish = txtDescriptionSP.Value;
            updateCurriculum.s_curriculum_type_name_portuguese = txtCurriculumTypeNamePortuguse.Text;
            updateCurriculum.s_curriculum_type_desc_portuguese = txtDescriptionPortuguese.Value;
            updateCurriculum.s_curriculum_type_name_german = txtCurriculumTypeNameGerman.Text;
            updateCurriculum.s_curriculum_type_desc_german = txtDescriptionGerman.Value;
            updateCurriculum.s_curriculum_type_name_japanese = txtCurriculumTypeNameJapanese.Text;
            updateCurriculum.s_curriculum_type_desc_japanese = txtDescriptionJapanese.Value;
            updateCurriculum.s_curriculum_type_name_russian = txtCurriculumTypeNameRussian.Text;
            updateCurriculum.s_curriculum_type_desc_russian = txtDescriptionRussian.Value;
            updateCurriculum.s_curriculum_type_name_danish = txtCurriculumTypeNameDanish.Text;
            updateCurriculum.s_curriculum_type_desc_danish = txtDescriptionDanish.Value;
            updateCurriculum.s_curriculum_type_name_polish = txtCurriculumTypeNamePolish.Text;
            updateCurriculum.s_curriculum_type_desc_polish = txtDescriptionPolish.Value;
            updateCurriculum.s_curriculum_type_name_swedish = txtCurriculumTypeNameSwedish.Text;
            updateCurriculum.s_curriculum_type_desc_swedish = txtDescriptionSwedish.Value;
            updateCurriculum.s_curriculum_type_name_finnish = txtCurriculumTypeNameFinnish.Text;
            updateCurriculum.s_curriculum_type_desc_finnish = txtDescriptionFinnish.Value;
            updateCurriculum.s_curriculum_type_name_korean = txtCurriculumTypeNameKorean.Text;
            updateCurriculum.s_curriculum_type_desc_korean = txtDescriptionKorean.Value;
            updateCurriculum.s_curriculum_type_name_italian = txtCurriculumTypeNameItalian.Text;
            updateCurriculum.s_curriculum_type_desc_italian = txtDescriptionItalian.Value;
            updateCurriculum.s_curriculum_type_name_dutch = txtCurriculumTypeNameDutch.Text;
            updateCurriculum.s_curriculum_type_desc_dutch = txtDescriptionDutch.Value;
            updateCurriculum.s_curriculum_type_name_indonesian = txtCurriculumTypeNameIndonesian.Text;
            updateCurriculum.s_curriculum_type_desc_indonesian = txtDescriptionIndonesian.Value;
            updateCurriculum.s_curriculum_type_name_greek = txtCurriculumTypeNameGreek.Text;
            updateCurriculum.s_curriculum_type_desc_greek = txtDescriptionGreek.Value;
            updateCurriculum.s_curriculum_type_name_hungarian = txtCurriculumTypeNameHungarian.Text;
            updateCurriculum.s_curriculum_type_desc_hungarian = txtDescriptionHungarian.Value;
            updateCurriculum.s_curriculum_type_name_norwegian = txtCurriculumTypeNameNorwegian.Text;
            updateCurriculum.s_curriculum_type_desc_norwegian = txtDescriptionNorwegian.Value;
            updateCurriculum.s_curriculum_type_name_turkish = txtCurriculumTypeNameTurkish.Text;
            updateCurriculum.s_curriculum_type_desc_turkish = txtDescriptionTurkish.Value;
            updateCurriculum.s_curriculum_type_name_arabic_rtl = txtCurriculumTypeNameArabic.Text;
            updateCurriculum.s_curriculum_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateCurriculum.s_curriculum_type_name_custom_01 = txtCurriculumTypeNameCustom01.Text;
            updateCurriculum.s_curriculum_type_desc_custom_01 = txtDescriptionCustom01.Value;
            updateCurriculum.s_curriculum_type_name_custom_02 = txtCurriculumTypeNameCustom02.Text;
            updateCurriculum.s_curriculum_type_desc_custom_02 = txtDescriptionCustom02.Value;
            updateCurriculum.s_curriculum_type_name_custom_03 = txtCurriculumTypeNameCustom03.Text;
            updateCurriculum.s_curriculum_type_desc_custom_03 = txtDescriptionCustom03.Value;
            updateCurriculum.s_curriculum_type_name_custom_04 = txtCurriculumTypeNameCustom04.Text;
            updateCurriculum.s_curriculum_type_desc_custom_04 = txtDescriptionCustom04.Value;
            updateCurriculum.s_curriculum_type_name_custom_05 = txtCurriculumTypeNameCustom05.Text;
            updateCurriculum.s_curriculum_type_desc_custom_05 = txtDescriptionCustom05.Value;
            updateCurriculum.s_curriculum_type_name_custom_06 = txtCurriculumTypeNameCustom06.Text;
            updateCurriculum.s_curriculum_type_desc_custom_06 = txtDescriptionCustom06.Value;
            updateCurriculum.s_curriculum_type_name_custom_07 = txtCurriculumTypeNameCustom07.Text;
            updateCurriculum.s_curriculum_type_desc_custom_07 = txtDescriptionCustom07.Value;
            updateCurriculum.s_curriculum_type_name_custom_08 = txtCurriculumTypeNameCustom08.Text;
            updateCurriculum.s_curriculum_type_desc_custom_08 = txtDescriptionCustom08.Value;
            updateCurriculum.s_curriculum_type_name_custom_09 = txtCurriculumTypeNameCustom09.Text;
            updateCurriculum.s_curriculum_type_desc_custom_09 = txtDescriptionCustom09.Value;
            updateCurriculum.s_curriculum_type_name_custom_10 = txtCurriculumTypeNameCustom10.Text;
            updateCurriculum.s_curriculum_type_desc_custom_10 = txtDescriptionCustom10.Value;
            updateCurriculum.s_curriculum_type_name_custom_11 = txtCurriculumTypeNameCustom11.Text;
            updateCurriculum.s_curriculum_type_desc_custom_11 = txtDescriptionCustom11.Value;
            updateCurriculum.s_curriculum_type_name_custom_12 = txtCurriculumTypeNameCustom12.Text;
            updateCurriculum.s_curriculum_type_desc_custom_12 = txtDescriptionCustom12.Value;
            updateCurriculum.s_curriculum_type_name_custom_13 = txtCurriculumTypeNameCustom13.Text;
            updateCurriculum.s_curriculum_type_desc_custom_13 = txtDescriptionCustom13.Value;
            updateCurriculum.s_curriculum_type_name_simp_chinese = txtCurriculumTypeNameChinese.Text;
            updateCurriculum.s_curriculum_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int error = SystemCurriculumTypeBLL.UpdateCurriculumTypes(updateCurriculum);
                if (error == 0)
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
                        Logger.WriteToErrorLog("saectn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saectn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/CurriculumTypes/samctmp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/CurriculumTypes/samctmp-01.aspx");
        }
    }
}