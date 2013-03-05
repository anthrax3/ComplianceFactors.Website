using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.InstructorTypes
{
    public partial class saeitn_01 : BasePage
    {
        private static string editInstructorId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   
                    //label BreadCrumb
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/InstructorTypes/samitmp-01.aspx>" + LocalResources.GetLabel("app_manage_instructor_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_instructor_type_text");
                    ddlStatus.DataSource = SystemInstructorTypeBLL.GetStatus(SessionWrapper.CultureName, "saeitn-01");
                    ddlStatus.DataBind();
                     
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        editInstructorId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        PoulateInstructor(editInstructorId);
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                    }
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
                        Logger.WriteToErrorLog("saeitn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeitn-01.aspx", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Populate value from Instructor type (table)
        /// </summary>
        /// <param name="editInstructorId"></param>
        private void PoulateInstructor(string editInstructorId)
        {
            SystemInstructorType instructor = new SystemInstructorType();
            try
            {
                instructor = SystemInstructorTypeBLL.GetInstructorTypesbyId(editInstructorId);
                txtInstructorTypeId.Text = instructor.s_instructor_type_id;
                txtInstructorTypeName.Text = instructor.s_instructor_english_us_name;
                txtDescriptionUS.InnerText = instructor.s_instructor_english_us_description;
                ddlStatus.SelectedValue = instructor.s_instructor_english_us_status_id_fk;
                txtInstructorTypeNameUK.Text = instructor.s_instructor_english_uk_name;
                txtDescriptionUK.InnerText = instructor.s_instructor_english_uk_description;
                txtDescriptionUK.InnerText = instructor.s_instructor_english_uk_description;
                txtInstructorTypeNameCA.Text = instructor.s_instructor_france_ca_name;
                txtDescriptionCA.InnerText = instructor.s_instructor_france_ca_description;
                txtInstructorTypeNameFR.Text = instructor.s_instructor_french_fr_name;
                txtDescriptionFR.InnerText = instructor.s_instructor_french_fr_description;
                txtInstructorTypeNameMX.Text = instructor.s_instructor_spanish_mx_name;
                txtDescriptionMX.InnerText = instructor.s_instructor_spanish_mx_description;
                txtInstructorTypeNameSP.Text = instructor.s_instructor_sapnish_sp_name;
                txtDescriptionSP.InnerText = instructor.s_instructor_spanish_sp_description;
                txtInstructorTypeNamePortuguse.Text = instructor.s_instructor_portuguse_name;
                txtDescriptionPortuguese.InnerText = instructor.s_instructor_portuguse_description;
                txtInstructorTypeNameChinese.Text = instructor.s_instructor_chinese_name;
                txtDescriptionChinese.InnerText = instructor.s_instructor_chinese_description;
                txtInstructorTypeNameGerman.Text = instructor.s_instructor_german_name;
                txtDescriptionGerman.InnerText = instructor.s_instructor_german_description;
                txtInstructorTypeNameJapanese.Text = instructor.s_instructor_japanese_name;
                txtDescriptionJapanese.InnerText = instructor.s_instructor_japanese_description;
                txtInstructorTypeNameRussian.Text = instructor.s_instructor_russian_name;
                txtDescriptionRussian.InnerText = instructor.s_instructor_russian_description;
                txtInstructorTypeNameDanish.Text = instructor.s_instructor_danish_name;
                txtDescriptionDanish.InnerText = instructor.s_instructor_danish_description;
                txtInstructorTypeNamePolish.Text = instructor.s_instructor_polish_name;
                txtDescriptionPolish.InnerText = instructor.s_instructor_polish_description;
                txtInstructorTypeNameSwedish.Text = instructor.s_instructor_swedish_name;
                txtDescriptionSwedish.InnerText = instructor.s_instructor_swedish_description;
                txtInstructorTypeNameFinnish.Text = instructor.s_instructor_finnish_name;
                txtDescriptionFinnish.InnerText = instructor.s_instructor_finnish_description;
                txtInstructorTypeNameKorean.Text = instructor.s_instructor_korean_name;
                txtDescriptionKorean.InnerText = instructor.s_instructor_korean_description;
                txtInstructorTypeNameItalian.Text = instructor.s_instructor_italian_name;
                txtDescriptionItalian.InnerText = instructor.s_instructor_italian_description;
                txtInstructorTypeNameDutch.Text = instructor.s_instructor_dutch_name;
                txtDescriptionDutch.InnerText = instructor.s_instructor_dutch_description;
                txtInstructorTypeNameIndonesian.Text = instructor.s_instructor_indonesian_name;
                txtDescriptionIndonesian.InnerText = instructor.s_instructor_indonesian_description;
                txtInstructorTypeNameGreek.Text = instructor.s_instructor_greek_name;
                txtDescriptionGreek.InnerText = instructor.s_instructor_greek_description;
                txtInstructorTypeNameHungarian.Text = instructor.s_instructor_hungarian_name;
                txtDescriptionHungarian.InnerText = instructor.s_instructor_hungarian_description;
                txtInstructorTypeNameNorwegian.Text = instructor.s_instructor_norwegian_name;
                txtDescriptionNorwegian.InnerText = instructor.s_instructor_norwegian_description;
                txtInstructorTypeNameTurkish.Text = instructor.s_instructor_turkish_name;
                txtDescriptionTurkish.InnerText = instructor.s_instructor_turkish_description;
                txtInstructorTypeNameArabic.Text = instructor.s_instructor_arabic_name;
                txtDescriptionArabic.InnerText = instructor.s_instructor_arabic_description;
                txtInstructorTypeNameCustom01.Text = instructor.s_instructor_custom01_name;
                txtDescriptionCustom01.InnerText = instructor.s_instructor_custom01_description;
                txtInstructorTypeNameCustom02.Text = instructor.s_instructor_custom02_name;
                txtDescriptionCustom02.InnerText = instructor.s_instructor_custom02_description;
                txtInstructorTypeNameCustom03.Text = instructor.s_instructor_custom03_name;
                txtDescriptionCustom03.InnerText = instructor.s_instructor_custom03_description;
                txtInstructorTypeNameCustom04.Text = instructor.s_instructor_custom04_name;
                txtDescriptionCustom04.InnerText = instructor.s_instructor_custom04_description;
                txtInstructorTypeNameCustom05.Text = instructor.s_instructor_custom05_name;
                txtDescriptionCustom05.InnerText = instructor.s_instructor_custom05_description;
                txtInstructorTypeNameCustom06.Text = instructor.s_instructor_custom06_name;
                txtDescriptionCustom06.InnerText = instructor.s_instructor_custom06_description;
                txtInstructorTypeNameCustom07.Text = instructor.s_instructor_custom07_name;
                txtDescriptionCustom07.InnerText = instructor.s_instructor_custom07_description;
                txtInstructorTypeNameCustom08.Text = instructor.s_instructor_custom08_name;
                txtDescriptionCustom08.InnerText = instructor.s_instructor_custom08_description;
                txtInstructorTypeNameCustom09.Text = instructor.s_instructor_custom09_name;
                txtDescriptionCustom09.InnerText = instructor.s_instructor_custom09_description;
                txtInstructorTypeNameCustom10.Text = instructor.s_instructor_custom10_name;
                txtDescriptionCustom10.InnerText = instructor.s_instructor_custom10_description;
                txtInstructorTypeNameCustom11.Text = instructor.s_instructor_custom11_name;
                txtDescriptionCustom11.InnerText = instructor.s_instructor_custom11_description;
                txtInstructorTypeNameCustom12.Text = instructor.s_instructor_custom12_name;
                txtDescriptionCustom12.InnerText = instructor.s_instructor_custom12_description;
                txtInstructorTypeNameCustom13.Text = instructor.s_instructor_custom13_name;
                txtDescriptionCustom13.InnerText = instructor.s_instructor_custom13_description;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saeitn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeitn-01", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveNewInstructorType_Click(object sender, EventArgs e)
        {
            UpdateInstructor();
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/InstructorTypes/samitmp-01.aspx");
        }

        protected void btnFooterSaveNewInstructorType_Click(object sender, EventArgs e)
        {
            UpdateInstructor();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/InstructorTypes/samitmp-01.aspx");
        }
        /// <summary>
        /// Update the Instructor 
        /// </summary>
        private void UpdateInstructor()
        {
            SystemInstructorType instructor = new SystemInstructorType();
            instructor.s_instructor_type_system_id_pk = editInstructorId.ToString();
            instructor.s_instructor_type_id = txtInstructorTypeId.Text;
            instructor.s_instructor_english_us_name = txtInstructorTypeName.Text;
            instructor.s_instructor_english_us_description = txtDescriptionUS.InnerText;
            instructor.s_instructor_english_us_status_id_fk = ddlStatus.SelectedValue;
            instructor.s_instructor_english_uk_name = txtInstructorTypeNameUK.Text;
            instructor.s_instructor_english_uk_description = txtDescriptionUK.InnerText;
            instructor.s_instructor_france_ca_name = txtInstructorTypeNameCA.Text;
            instructor.s_instructor_france_ca_description = txtDescriptionCA.InnerText;
            instructor.s_instructor_french_fr_name = txtInstructorTypeNameFR.Text;
            instructor.s_instructor_french_fr_description = txtDescriptionFR.InnerText;
            instructor.s_instructor_spanish_mx_name = txtInstructorTypeNameMX.Text;
            instructor.s_instructor_spanish_mx_description = txtDescriptionMX.InnerText;
            instructor.s_instructor_sapnish_sp_name = txtInstructorTypeNameSP.Text;
            instructor.s_instructor_spanish_sp_description = txtDescriptionSP.InnerText;
            instructor.s_instructor_portuguse_name = txtInstructorTypeNamePortuguse.Text;
            instructor.s_instructor_portuguse_description = txtDescriptionPortuguese.InnerText;
            instructor.s_instructor_chinese_name = txtInstructorTypeNameChinese.Text;
            instructor.s_instructor_chinese_description = txtDescriptionChinese.InnerText;
            instructor.s_instructor_german_name = txtInstructorTypeNameGerman.Text;
            instructor.s_instructor_german_description = txtDescriptionGerman.InnerText;
            instructor.s_instructor_japanese_name = txtInstructorTypeNameJapanese.Text;
            instructor.s_instructor_japanese_description = txtDescriptionJapanese.InnerText;
            instructor.s_instructor_russian_name = txtInstructorTypeNameRussian.Text;
            instructor.s_instructor_russian_description = txtDescriptionRussian.InnerText;
            instructor.s_instructor_danish_name = txtInstructorTypeNameDanish.Text;
            instructor.s_instructor_danish_description = txtDescriptionDanish.InnerText;
            instructor.s_instructor_polish_name = txtInstructorTypeNamePolish.Text;
            instructor.s_instructor_polish_description = txtDescriptionPolish.InnerText;
            instructor.s_instructor_swedish_name = txtInstructorTypeNameSwedish.Text;
            instructor.s_instructor_swedish_description = txtDescriptionSwedish.InnerText;
            instructor.s_instructor_finnish_name = txtInstructorTypeNameFinnish.Text;
            instructor.s_instructor_finnish_description = txtDescriptionFinnish.InnerText;
            instructor.s_instructor_korean_name = txtInstructorTypeNameKorean.Text;
            instructor.s_instructor_korean_description = txtDescriptionKorean.InnerText;
            instructor.s_instructor_italian_name = txtInstructorTypeNameItalian.Text;
            instructor.s_instructor_italian_description = txtDescriptionItalian.InnerText;
            instructor.s_instructor_dutch_name = txtInstructorTypeNameDutch.Text;
            instructor.s_instructor_dutch_description = txtDescriptionDutch.InnerText;
            instructor.s_instructor_indonesian_name = txtInstructorTypeNameIndonesian.Text;
            instructor.s_instructor_indonesian_description = txtDescriptionIndonesian.InnerText;
            instructor.s_instructor_greek_name = txtInstructorTypeNameGreek.Text;
            instructor.s_instructor_greek_description = txtDescriptionGreek.InnerText;
            instructor.s_instructor_hungarian_name = txtInstructorTypeNameHungarian.Text;
            instructor.s_instructor_hungarian_description = txtDescriptionHungarian.InnerText;
            instructor.s_instructor_norwegian_name = txtInstructorTypeNameNorwegian.Text;
            instructor.s_instructor_norwegian_description = txtDescriptionNorwegian.InnerText;
            instructor.s_instructor_turkish_name = txtInstructorTypeNameTurkish.Text;
            instructor.s_instructor_turkish_description = txtDescriptionTurkish.InnerText;
            instructor.s_instructor_arabic_name = txtInstructorTypeNameArabic.Text;
            instructor.s_instructor_arabic_description = txtDescriptionArabic.InnerText;
            instructor.s_instructor_custom01_name = txtInstructorTypeNameCustom01.Text;
            instructor.s_instructor_custom01_description = txtDescriptionCustom01.InnerText;
            instructor.s_instructor_custom02_name = txtInstructorTypeNameCustom02.Text;
            instructor.s_instructor_custom02_description = txtDescriptionCustom02.InnerText;
            instructor.s_instructor_custom03_name = txtInstructorTypeNameCustom03.Text;
            instructor.s_instructor_custom03_description = txtDescriptionCustom03.InnerText;
            instructor.s_instructor_custom04_name = txtInstructorTypeNameCustom04.Text;
            instructor.s_instructor_custom04_description = txtDescriptionCustom04.InnerText;
            instructor.s_instructor_custom05_name = txtInstructorTypeNameCustom05.Text;
            instructor.s_instructor_custom05_description = txtDescriptionCustom05.InnerText;
            instructor.s_instructor_custom06_name = txtInstructorTypeNameCustom06.Text;
            instructor.s_instructor_custom06_description = txtDescriptionCustom06.InnerText;
            instructor.s_instructor_custom07_name = txtInstructorTypeNameCustom07.Text;
            instructor.s_instructor_custom07_description = txtDescriptionCustom07.InnerText;
            instructor.s_instructor_custom08_name = txtInstructorTypeNameCustom08.Text;
            instructor.s_instructor_custom08_description = txtDescriptionCustom08.InnerText;
            instructor.s_instructor_custom09_name = txtInstructorTypeNameCustom09.Text;
            instructor.s_instructor_custom09_description = txtDescriptionCustom09.InnerText;
            instructor.s_instructor_custom10_name = txtInstructorTypeNameCustom10.Text;
            instructor.s_instructor_custom10_description = txtDescriptionCustom10.InnerText;
            instructor.s_instructor_custom11_name = txtInstructorTypeNameCustom11.Text;
            instructor.s_instructor_custom11_description = txtDescriptionCustom11.InnerText;
            instructor.s_instructor_custom12_name = txtInstructorTypeNameCustom12.Text;
            instructor.s_instructor_custom12_description = txtDescriptionCustom12.InnerText;
            instructor.s_instructor_custom13_name = txtInstructorTypeNameCustom13.Text;
            instructor.s_instructor_custom13_description = txtDescriptionCustom13.InnerText;
            try
            {
                int result = SystemInstructorTypeBLL.UpdateInstructorType(instructor);
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
                        Logger.WriteToErrorLog("saeitn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saeitn-01", ex.Message);
                    }
                }
            }
        }
    }
}