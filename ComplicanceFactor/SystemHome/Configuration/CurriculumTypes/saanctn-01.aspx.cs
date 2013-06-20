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

namespace ComplicanceFactor.SystemHome.Configuration.CurriculumTypes
{
    public partial class saanctn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/CurriculumTypes/samctmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_curriculum_type_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_create_new_curriculum_type_text") + "</a>";

                //Status Bind
                ddlStatus.DataSource = SystemCurriculumTypeBLL.GetStatus(SessionWrapper.CultureName, "saanctn-01");
                ddlStatus.DataBind();

                ddlStatus.SelectedValue = "app_ddl_active_text";

                //copy
                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    PopulateCurriculumType(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                }
            }
        }

        protected void btnFooterSaveNewCurriculamType_Click(object sender, EventArgs e)
        {
            SaveCurriculumTypes();
        }
        /// <summary>
        /// Save Curriculum Types
        /// </summary>
        private void SaveCurriculumTypes()
        {
            SystemCurriculumType createCurriculum = new SystemCurriculumType();

            createCurriculum.s_curriculum_type_system_id_pk = Guid.NewGuid().ToString();
            createCurriculum.s_curriculum_type_id = txtCurriculumTypeId.Text;
            createCurriculum.s_curriculum_type_status_id_fk = ddlStatus.SelectedValue;
            createCurriculum.s_curriculum_type_name_us_english = txtCurriculumTypeName.Text;
            createCurriculum.s_curriculum_type_desc_us_english = txtDescriptionUS.Value;
            createCurriculum.s_curriculum_type_name_uk_english = txtCurriculumTypeNameUK.Text;
            createCurriculum.s_curriculum_type_desc_uk_english = txtDescriptionUK.Value;
            createCurriculum.s_curriculum_type_name_ca_french = txtCurriculumTypeNameCA.Text;
            createCurriculum.s_curriculum_type_desc_ca_french = txtDescriptionCA.Value;
            createCurriculum.s_curriculum_type_name_fr_french = txtCurriculumTypeNameFR.Text;
            createCurriculum.s_curriculum_type_desc_fr_french = txtDescriptionFR.Value;
            createCurriculum.s_curriculum_type_name_mx_spanish = txtCurriculumTypeNameMX.Text;
            createCurriculum.s_curriculum_type_desc_mx_spanish = txtDescriptionMX.Value;
            createCurriculum.s_curriculum_type_name_sp_spanish = txtCurriculumTypeNameSP.Text;
            createCurriculum.s_curriculum_type_desc_sp_spanish = txtDescriptionSP.Value;
            createCurriculum.s_curriculum_type_name_portuguese = txtCurriculumTypeNamePortuguse.Text;
            createCurriculum.s_curriculum_type_desc_portuguese = txtDescriptionPortuguese.Value;
            createCurriculum.s_curriculum_type_name_german = txtCurriculumTypeNameGerman.Text;
            createCurriculum.s_curriculum_type_desc_german = txtDescriptionGerman.Value;
            createCurriculum.s_curriculum_type_name_japanese = txtCurriculumTypeNameJapanese.Text;
            createCurriculum.s_curriculum_type_desc_japanese = txtDescriptionJapanese.Value;
            createCurriculum.s_curriculum_type_name_russian = txtCurriculumTypeNameRussian.Text;
            createCurriculum.s_curriculum_type_desc_russian = txtDescriptionRussian.Value;
            createCurriculum.s_curriculum_type_name_danish = txtCurriculumTypeNameDanish.Text;
            createCurriculum.s_curriculum_type_desc_danish = txtDescriptionDanish.Value;
            createCurriculum.s_curriculum_type_name_polish = txtCurriculumTypeNamePolish.Text;
            createCurriculum.s_curriculum_type_desc_polish = txtDescriptionPolish.Value;
            createCurriculum.s_curriculum_type_name_swedish = txtCurriculumTypeNameSwedish.Text;
            createCurriculum.s_curriculum_type_desc_swedish = txtDescriptionSwedish.Value;
            createCurriculum.s_curriculum_type_name_finnish = txtCurriculumTypeNameFinnish.Text;
            createCurriculum.s_curriculum_type_desc_finnish = txtDescriptionFinnish.Value;
            createCurriculum.s_curriculum_type_name_korean = txtCurriculumTypeNameKorean.Text;
            createCurriculum.s_curriculum_type_desc_korean = txtDescriptionKorean.Value;
            createCurriculum.s_curriculum_type_name_italian = txtCurriculumTypeNameItalian.Text;
            createCurriculum.s_curriculum_type_desc_italian = txtDescriptionItalian.Value;
            createCurriculum.s_curriculum_type_name_dutch = txtCurriculumTypeNameDutch.Text;
            createCurriculum.s_curriculum_type_desc_dutch = txtDescriptionDutch.Value;
            createCurriculum.s_curriculum_type_name_indonesian = txtCurriculumTypeNameIndonesian.Text;
            createCurriculum.s_curriculum_type_desc_indonesian = txtDescriptionIndonesian.Value;
            createCurriculum.s_curriculum_type_name_greek = txtCurriculumTypeNameGreek.Text;
            createCurriculum.s_curriculum_type_desc_greek = txtDescriptionGreek.Value;
            createCurriculum.s_curriculum_type_name_hungarian = txtCurriculumTypeNameHungarian.Text;
            createCurriculum.s_curriculum_type_desc_hungarian = txtDescriptionHungarian.Value;
            createCurriculum.s_curriculum_type_name_norwegian = txtCurriculumTypeNameNorwegian.Text;
            createCurriculum.s_curriculum_type_desc_norwegian = txtDescriptionNorwegian.Value;
            createCurriculum.s_curriculum_type_name_turkish = txtCurriculumTypeNameTurkish.Text;
            createCurriculum.s_curriculum_type_desc_turkish = txtDescriptionTurkish.Value;
            createCurriculum.s_curriculum_type_name_arabic_rtl = txtCurriculumTypeNameArabic.Text;
            createCurriculum.s_curriculum_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            createCurriculum.s_curriculum_type_name_custom_01 = txtCurriculumTypeNameCustom01.Text;
            createCurriculum.s_curriculum_type_desc_custom_01 = txtDescriptionCustom01.Value;
            createCurriculum.s_curriculum_type_name_custom_02 = txtCurriculumTypeNameCustom02.Text;
            createCurriculum.s_curriculum_type_desc_custom_02 = txtDescriptionCustom02.Value;
            createCurriculum.s_curriculum_type_name_custom_03 = txtCurriculumTypeNameCustom03.Text;
            createCurriculum.s_curriculum_type_desc_custom_03 = txtDescriptionCustom03.Value;
            createCurriculum.s_curriculum_type_name_custom_04 = txtCurriculumTypeNameCustom04.Text;
            createCurriculum.s_curriculum_type_desc_custom_04 = txtDescriptionCustom04.Value;
            createCurriculum.s_curriculum_type_name_custom_05 = txtCurriculumTypeNameCustom05.Text;
            createCurriculum.s_curriculum_type_desc_custom_05 = txtDescriptionCustom05.Value;
            createCurriculum.s_curriculum_type_name_custom_06 = txtCurriculumTypeNameCustom06.Text;
            createCurriculum.s_curriculum_type_desc_custom_06 = txtDescriptionCustom06.Value;
            createCurriculum.s_curriculum_type_name_custom_07 = txtCurriculumTypeNameCustom07.Text;
            createCurriculum.s_curriculum_type_desc_custom_07 = txtDescriptionCustom07.Value;
            createCurriculum.s_curriculum_type_name_custom_08 = txtCurriculumTypeNameCustom08.Text;
            createCurriculum.s_curriculum_type_desc_custom_08 = txtDescriptionCustom08.Value;
            createCurriculum.s_curriculum_type_name_custom_09 = txtCurriculumTypeNameCustom09.Text;
            createCurriculum.s_curriculum_type_desc_custom_09 = txtDescriptionCustom09.Value;
            createCurriculum.s_curriculum_type_name_custom_10 = txtCurriculumTypeNameCustom10.Text;
            createCurriculum.s_curriculum_type_desc_custom_10 = txtDescriptionCustom10.Value;
            createCurriculum.s_curriculum_type_name_custom_11 = txtCurriculumTypeNameCustom11.Text;
            createCurriculum.s_curriculum_type_desc_custom_11 = txtDescriptionCustom11.Value;
            createCurriculum.s_curriculum_type_name_custom_12 = txtCurriculumTypeNameCustom12.Text;
            createCurriculum.s_curriculum_type_desc_custom_12 = txtDescriptionCustom12.Value;
            createCurriculum.s_curriculum_type_name_custom_13 = txtCurriculumTypeNameCustom13.Text;
            createCurriculum.s_curriculum_type_desc_custom_13 = txtDescriptionCustom13.Value;
            createCurriculum.s_curriculum_type_name_simp_chinese = txtCurriculumTypeNameChinese.Text;
            createCurriculum.s_curriculum_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int error = SystemCurriculumTypeBLL.CreateCurriculumTypes(createCurriculum);
                if (error != -2)
                {
                    Response.Redirect("~/SystemHome/Configuration/CurriculumTypes/saectn-01.aspx?edit=" + SecurityCenter.EncryptText(createCurriculum.s_curriculum_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_curriculum_type_id_already_exist_error_wrong");
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
                        Logger.WriteToErrorLog("saanctn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanctn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveNewCurriculumType_Click1(object sender, EventArgs e)
        {
            SaveCurriculumTypes();
        }

        protected void btnFooterSaveNewCurriculumType_Click(object sender, EventArgs e)
        {
            SaveCurriculumTypes();
        }

        /// <summary>
        /// Populate the values for Copy
        /// </summary>
        /// <param name="CurriculumTypesId"></param>
        private void PopulateCurriculumType(string curriculumId)
        {
            SystemCurriculumType curriculumTypes = new SystemCurriculumType();

            try
            {
                curriculumTypes = SystemCurriculumTypeBLL.GetCurriculumType(curriculumId);

                txtCurriculumTypeId.Text = curriculumTypes.s_curriculum_type_id + "_Copy";
                ddlStatus.SelectedValue = curriculumTypes.s_curriculum_type_status_id_fk;

                txtCurriculumTypeName.Text = curriculumTypes.s_curriculum_type_name_us_english;
                txtDescriptionUS.Value = curriculumTypes.s_curriculum_type_desc_us_english;
                txtCurriculumTypeNameUK.Text = curriculumTypes.s_curriculum_type_name_uk_english;
                txtDescriptionUK.Value = curriculumTypes.s_curriculum_type_desc_uk_english;
                txtCurriculumTypeNameCA.Text = curriculumTypes.s_curriculum_type_name_ca_french;
                txtDescriptionCA.Value = curriculumTypes.s_curriculum_type_desc_ca_french;
                txtCurriculumTypeNameFR.Text = curriculumTypes.s_curriculum_type_name_fr_french;
                txtDescriptionFR.Value = curriculumTypes.s_curriculum_type_desc_fr_french;
                txtCurriculumTypeNameMX.Text = curriculumTypes.s_curriculum_type_name_mx_spanish;
                txtDescriptionMX.Value = curriculumTypes.s_curriculum_type_desc_mx_spanish;
                txtCurriculumTypeNameSP.Text = curriculumTypes.s_curriculum_type_name_sp_spanish;
                txtDescriptionSP.Value = curriculumTypes.s_curriculum_type_desc_sp_spanish;
                txtCurriculumTypeNamePortuguse.Text = curriculumTypes.s_curriculum_type_name_portuguese;
                txtDescriptionPortuguese.Value = curriculumTypes.s_curriculum_type_desc_portuguese;
                txtCurriculumTypeNameGerman.Text = curriculumTypes.s_curriculum_type_name_german;
                txtDescriptionGerman.Value = curriculumTypes.s_curriculum_type_desc_german;
                txtCurriculumTypeNameJapanese.Text = curriculumTypes.s_curriculum_type_name_japanese;
                txtDescriptionJapanese.Value = curriculumTypes.s_curriculum_type_desc_japanese;
                txtCurriculumTypeNameRussian.Text = curriculumTypes.s_curriculum_type_name_russian;
                txtDescriptionRussian.Value = curriculumTypes.s_curriculum_type_desc_russian;
                txtCurriculumTypeNameDanish.Text = curriculumTypes.s_curriculum_type_name_danish;
                txtDescriptionDanish.Value = curriculumTypes.s_curriculum_type_desc_danish;
                txtCurriculumTypeNamePolish.Text = curriculumTypes.s_curriculum_type_name_polish;
                txtDescriptionPolish.Value = curriculumTypes.s_curriculum_type_desc_polish;
                txtCurriculumTypeNameSwedish.Text = curriculumTypes.s_curriculum_type_name_swedish;
                txtDescriptionSwedish.Value = curriculumTypes.s_curriculum_type_desc_swedish;
                txtCurriculumTypeNameFinnish.Text = curriculumTypes.s_curriculum_type_name_finnish;
                txtDescriptionFinnish.Value = curriculumTypes.s_curriculum_type_desc_finnish;
                txtCurriculumTypeNameKorean.Text = curriculumTypes.s_curriculum_type_name_korean;
                txtDescriptionKorean.Value = curriculumTypes.s_curriculum_type_desc_korean;
                txtCurriculumTypeNameItalian.Text = curriculumTypes.s_curriculum_type_name_italian;
                txtDescriptionItalian.Value = curriculumTypes.s_curriculum_type_desc_italian;
                txtCurriculumTypeNameDutch.Text = curriculumTypes.s_curriculum_type_name_dutch;
                txtDescriptionDutch.Value = curriculumTypes.s_curriculum_type_desc_dutch;
                txtCurriculumTypeNameIndonesian.Text = curriculumTypes.s_curriculum_type_name_indonesian;
                txtDescriptionIndonesian.Value = curriculumTypes.s_curriculum_type_desc_indonesian;
                txtCurriculumTypeNameGreek.Text = curriculumTypes.s_curriculum_type_name_greek;
                txtDescriptionGreek.Value = curriculumTypes.s_curriculum_type_desc_greek;
                txtCurriculumTypeNameHungarian.Text = curriculumTypes.s_curriculum_type_name_hungarian;
                txtDescriptionHungarian.Value = curriculumTypes.s_curriculum_type_desc_hungarian;
                txtCurriculumTypeNameNorwegian.Text = curriculumTypes.s_curriculum_type_name_norwegian;
                txtDescriptionNorwegian.Value = curriculumTypes.s_curriculum_type_desc_norwegian;
                txtCurriculumTypeNameTurkish.Text = curriculumTypes.s_curriculum_type_name_turkish;
                txtDescriptionTurkish.Value = curriculumTypes.s_curriculum_type_desc_turkish;
                txtCurriculumTypeNameArabic.Text = curriculumTypes.s_curriculum_type_name_arabic_rtl;
                txtDescriptionArabic.Value = curriculumTypes.s_curriculum_type_desc_arabic_rtl;
                txtCurriculumTypeNameCustom01.Text = curriculumTypes.s_curriculum_type_name_custom_01;
                txtDescriptionCustom01.Value = curriculumTypes.s_curriculum_type_desc_custom_01;
                txtCurriculumTypeNameCustom02.Text = curriculumTypes.s_curriculum_type_name_custom_01;
                txtDescriptionCustom02.Value = curriculumTypes.s_curriculum_type_desc_custom_02;
                txtCurriculumTypeNameCustom03.Text = curriculumTypes.s_curriculum_type_name_custom_03;
                txtDescriptionCustom03.Value = curriculumTypes.s_curriculum_type_desc_custom_03;
                txtCurriculumTypeNameCustom04.Text = curriculumTypes.s_curriculum_type_name_custom_04;
                txtDescriptionCustom04.Value = curriculumTypes.s_curriculum_type_desc_custom_04;
                txtCurriculumTypeNameCustom05.Text = curriculumTypes.s_curriculum_type_name_custom_05;
                txtDescriptionCustom05.Value = curriculumTypes.s_curriculum_type_desc_custom_05;
                txtCurriculumTypeNameCustom06.Text = curriculumTypes.s_curriculum_type_name_custom_06;
                txtDescriptionCustom06.Value = curriculumTypes.s_curriculum_type_desc_custom_06;
                txtCurriculumTypeNameCustom07.Text = curriculumTypes.s_curriculum_type_name_custom_07;
                txtDescriptionCustom07.Value = curriculumTypes.s_curriculum_type_desc_custom_07;
                txtCurriculumTypeNameCustom08.Text = curriculumTypes.s_curriculum_type_name_custom_08;
                txtDescriptionCustom08.Value = curriculumTypes.s_curriculum_type_name_custom_08;
                txtCurriculumTypeNameCustom09.Text = curriculumTypes.s_curriculum_type_name_custom_09;
                txtDescriptionCustom09.Value = curriculumTypes.s_curriculum_type_desc_custom_09;
                txtCurriculumTypeNameCustom10.Text = curriculumTypes.s_curriculum_type_name_custom_10;
                txtDescriptionCustom10.Value = curriculumTypes.s_curriculum_type_desc_custom_10;
                txtCurriculumTypeNameCustom11.Text = curriculumTypes.s_curriculum_type_name_custom_11;
                txtDescriptionCustom11.Value = curriculumTypes.s_curriculum_type_name_custom_11;
                txtCurriculumTypeNameCustom12.Text = curriculumTypes.s_curriculum_type_name_custom_12;
                txtDescriptionCustom12.Value = curriculumTypes.s_curriculum_type_desc_custom_12;
                txtCurriculumTypeNameCustom13.Text = curriculumTypes.s_curriculum_type_name_custom_13;
                txtDescriptionCustom13.Value = curriculumTypes.s_curriculum_type_desc_custom_13;
                txtCurriculumTypeNameChinese.Text = curriculumTypes.s_curriculum_type_name_simp_chinese;
                txtDescriptionChinese.Value = curriculumTypes.s_curriculum_type_desc_simp_chinese;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanctn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanctn-01.aspx", ex.Message);
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