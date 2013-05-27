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
            SystemInstructorType instructorTypes = new SystemInstructorType();
            try
            {
                instructorTypes = SystemInstructorTypeBLL.GetInstructorTypesbyId(editInstructorId);
                txtInstructorTypeId.Text = instructorTypes.s_instructor_type_id;
                ddlStatus.SelectedValue = instructorTypes.s_instructor_type_status_id_fk;

                txtInstructorTypeName.Text = instructorTypes.s_instructor_type_name_us_english;
                txtDescriptionUS.Value = instructorTypes.s_instructor_type_desc_us_english;
                txtInstructorTypeNameUK.Text = instructorTypes.s_instructor_type_name_uk_english;
                txtDescriptionUK.Value = instructorTypes.s_instructor_type_desc_uk_english;
                txtInstructorTypeNameCA.Text = instructorTypes.s_instructor_type_name_ca_french;
                txtDescriptionCA.Value = instructorTypes.s_instructor_type_desc_ca_french;
                txtInstructorTypeNameFR.Text = instructorTypes.s_instructor_type_name_fr_french;
                txtDescriptionFR.Value = instructorTypes.s_instructor_type_desc_fr_french;
                txtInstructorTypeNameMX.Text = instructorTypes.s_instructor_type_name_mx_spanish;
                txtDescriptionMX.Value = instructorTypes.s_instructor_type_desc_mx_spanish;
                txtInstructorTypeNameSP.Text = instructorTypes.s_instructor_type_name_sp_spanish;
                txtDescriptionSP.Value = instructorTypes.s_instructor_type_desc_sp_spanish;
                txtInstructorTypeNamePortuguse.Text = instructorTypes.s_instructor_type_name_portuguese;
                txtDescriptionPortuguese.Value = instructorTypes.s_instructor_type_desc_portuguese;
                txtInstructorTypeNameGerman.Text = instructorTypes.s_instructor_type_name_german;
                txtDescriptionGerman.Value = instructorTypes.s_instructor_type_desc_german;
                txtInstructorTypeNameJapanese.Text = instructorTypes.s_instructor_type_name_japanese;
                txtDescriptionJapanese.Value = instructorTypes.s_instructor_type_desc_japanese;
                txtInstructorTypeNameRussian.Text = instructorTypes.s_instructor_type_name_russian;
                txtDescriptionRussian.Value = instructorTypes.s_instructor_type_desc_russian;
                txtInstructorTypeNameDanish.Text = instructorTypes.s_instructor_type_name_danish;
                txtDescriptionDanish.Value = instructorTypes.s_instructor_type_desc_danish;
                txtInstructorTypeNamePolish.Text = instructorTypes.s_instructor_type_name_polish;
                txtDescriptionPolish.Value = instructorTypes.s_instructor_type_desc_polish;
                txtInstructorTypeNameSwedish.Text = instructorTypes.s_instructor_type_name_swedish;
                txtDescriptionSwedish.Value = instructorTypes.s_instructor_type_desc_swedish;
                txtInstructorTypeNameFinnish.Text = instructorTypes.s_instructor_type_name_finnish;
                txtDescriptionFinnish.Value = instructorTypes.s_instructor_type_desc_finnish;
                txtInstructorTypeNameKorean.Text = instructorTypes.s_instructor_type_name_korean;
                txtDescriptionKorean.Value = instructorTypes.s_instructor_type_desc_korean;
                txtInstructorTypeNameItalian.Text = instructorTypes.s_instructor_type_name_italian;
                txtDescriptionItalian.Value = instructorTypes.s_instructor_type_desc_italian;
                txtInstructorTypeNameDutch.Text = instructorTypes.s_instructor_type_name_dutch;
                txtDescriptionDutch.Value = instructorTypes.s_instructor_type_desc_dutch;
                txtInstructorTypeNameIndonesian.Text = instructorTypes.s_instructor_type_name_indonesian;
                txtDescriptionIndonesian.Value = instructorTypes.s_instructor_type_desc_indonesian;
                txtInstructorTypeNameGreek.Text = instructorTypes.s_instructor_type_name_greek;
                txtDescriptionGreek.Value = instructorTypes.s_instructor_type_desc_greek;
                txtInstructorTypeNameHungarian.Text = instructorTypes.s_instructor_type_name_hungarian;
                txtDescriptionHungarian.Value = instructorTypes.s_instructor_type_desc_hungarian;
                txtInstructorTypeNameNorwegian.Text = instructorTypes.s_instructor_type_name_norwegian;
                txtDescriptionNorwegian.Value = instructorTypes.s_instructor_type_desc_norwegian;
                txtInstructorTypeNameTurkish.Text = instructorTypes.s_instructor_type_name_turkish;
                txtDescriptionTurkish.Value = instructorTypes.s_instructor_type_desc_turkish;
                txtInstructorTypeNameArabic.Text = instructorTypes.s_instructor_type_name_arabic_rtl;
                txtDescriptionArabic.Value = instructorTypes.s_instructor_type_desc_arabic_rtl;
                txtInstructorTypeNameCustom01.Text = instructorTypes.s_instructor_type_name_custom_01;
                txtDescriptionCustom01.Value = instructorTypes.s_instructor_type_desc_custom_01;
                txtInstructorTypeNameCustom02.Text = instructorTypes.s_instructor_type_name_custom_01;
                txtDescriptionCustom02.Value = instructorTypes.s_instructor_type_desc_custom_02;
                txtInstructorTypeNameCustom03.Text = instructorTypes.s_instructor_type_name_custom_03;
                txtDescriptionCustom03.Value = instructorTypes.s_instructor_type_desc_custom_03;
                txtInstructorTypeNameCustom04.Text = instructorTypes.s_instructor_type_name_custom_04;
                txtDescriptionCustom04.Value = instructorTypes.s_instructor_type_desc_custom_04;
                txtInstructorTypeNameCustom05.Text = instructorTypes.s_instructor_type_name_custom_05;
                txtDescriptionCustom05.Value = instructorTypes.s_instructor_type_desc_custom_05;
                txtInstructorTypeNameCustom06.Text = instructorTypes.s_instructor_type_name_custom_06;
                txtDescriptionCustom06.Value = instructorTypes.s_instructor_type_desc_custom_06;
                txtInstructorTypeNameCustom07.Text = instructorTypes.s_instructor_type_name_custom_07;
                txtDescriptionCustom07.Value = instructorTypes.s_instructor_type_desc_custom_07;
                txtInstructorTypeNameCustom08.Text = instructorTypes.s_instructor_type_name_custom_08;
                txtDescriptionCustom08.Value = instructorTypes.s_instructor_type_name_custom_08;
                txtInstructorTypeNameCustom09.Text = instructorTypes.s_instructor_type_name_custom_09;
                txtDescriptionCustom09.Value = instructorTypes.s_instructor_type_desc_custom_09;
                txtInstructorTypeNameCustom10.Text = instructorTypes.s_instructor_type_name_custom_10;
                txtDescriptionCustom10.Value = instructorTypes.s_instructor_type_desc_custom_10;
                txtInstructorTypeNameCustom11.Text = instructorTypes.s_instructor_type_name_custom_11;
                txtDescriptionCustom11.Value = instructorTypes.s_instructor_type_name_custom_11;
                txtInstructorTypeNameCustom12.Text = instructorTypes.s_instructor_type_name_custom_12;
                txtDescriptionCustom12.Value = instructorTypes.s_instructor_type_desc_custom_12;
                txtInstructorTypeNameCustom13.Text = instructorTypes.s_instructor_type_name_custom_13;
                txtDescriptionCustom13.Value = instructorTypes.s_instructor_type_desc_custom_13;
                txtInstructorTypeNameChinese.Text = instructorTypes.s_instructor_type_name_simp_chinese;
                txtDescriptionChinese.Value = instructorTypes.s_instructor_type_desc_simp_chinese;
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
            SystemInstructorType updateInstructor = new SystemInstructorType();
            updateInstructor.s_instructor_type_system_id_pk = editInstructorId.ToString();
            updateInstructor.s_instructor_type_id = txtInstructorTypeId.Text;
            updateInstructor.s_instructor_type_status_id_fk = ddlStatus.SelectedValue;

            updateInstructor.s_instructor_type_name_us_english = txtInstructorTypeName.Text;
            updateInstructor.s_instructor_type_desc_us_english = txtDescriptionUS.Value;
            updateInstructor.s_instructor_type_name_uk_english = txtInstructorTypeNameUK.Text;
            updateInstructor.s_instructor_type_desc_uk_english = txtDescriptionUK.Value;
            updateInstructor.s_instructor_type_name_ca_french = txtInstructorTypeNameCA.Text;
            updateInstructor.s_instructor_type_desc_ca_french = txtDescriptionCA.Value;
            updateInstructor.s_instructor_type_name_fr_french = txtInstructorTypeNameFR.Text;
            updateInstructor.s_instructor_type_desc_fr_french = txtDescriptionFR.Value;
            updateInstructor.s_instructor_type_name_mx_spanish = txtInstructorTypeNameMX.Text;
            updateInstructor.s_instructor_type_desc_mx_spanish = txtDescriptionMX.Value;
            updateInstructor.s_instructor_type_name_sp_spanish = txtInstructorTypeNameSP.Text;
            updateInstructor.s_instructor_type_desc_sp_spanish = txtDescriptionSP.Value;
            updateInstructor.s_instructor_type_name_portuguese = txtInstructorTypeNamePortuguse.Text;
            updateInstructor.s_instructor_type_desc_portuguese = txtDescriptionPortuguese.Value;
            updateInstructor.s_instructor_type_name_german = txtInstructorTypeNameGerman.Text;
            updateInstructor.s_instructor_type_desc_german = txtDescriptionGerman.Value;
            updateInstructor.s_instructor_type_name_japanese = txtInstructorTypeNameJapanese.Text;
            updateInstructor.s_instructor_type_desc_japanese = txtDescriptionJapanese.Value;
            updateInstructor.s_instructor_type_name_russian = txtInstructorTypeNameRussian.Text;
            updateInstructor.s_instructor_type_desc_russian = txtDescriptionRussian.Value;
            updateInstructor.s_instructor_type_name_danish = txtInstructorTypeNameDanish.Text;
            updateInstructor.s_instructor_type_desc_danish = txtDescriptionDanish.Value;
            updateInstructor.s_instructor_type_name_polish = txtInstructorTypeNamePolish.Text;
            updateInstructor.s_instructor_type_desc_polish = txtDescriptionPolish.Value;
            updateInstructor.s_instructor_type_name_swedish = txtInstructorTypeNameSwedish.Text;
            updateInstructor.s_instructor_type_desc_swedish = txtDescriptionSwedish.Value;
            updateInstructor.s_instructor_type_name_finnish = txtInstructorTypeNameFinnish.Text;
            updateInstructor.s_instructor_type_desc_finnish = txtDescriptionFinnish.Value;
            updateInstructor.s_instructor_type_name_korean = txtInstructorTypeNameKorean.Text;
            updateInstructor.s_instructor_type_desc_korean = txtDescriptionKorean.Value;
            updateInstructor.s_instructor_type_name_italian = txtInstructorTypeNameItalian.Text;
            updateInstructor.s_instructor_type_desc_italian = txtDescriptionItalian.Value;
            updateInstructor.s_instructor_type_name_dutch = txtInstructorTypeNameDutch.Text;
            updateInstructor.s_instructor_type_desc_dutch = txtDescriptionDutch.Value;
            updateInstructor.s_instructor_type_name_indonesian = txtInstructorTypeNameIndonesian.Text;
            updateInstructor.s_instructor_type_desc_indonesian = txtDescriptionIndonesian.Value;
            updateInstructor.s_instructor_type_name_greek = txtInstructorTypeNameGreek.Text;
            updateInstructor.s_instructor_type_desc_greek = txtDescriptionGreek.Value;
            updateInstructor.s_instructor_type_name_hungarian = txtInstructorTypeNameHungarian.Text;
            updateInstructor.s_instructor_type_desc_hungarian = txtDescriptionHungarian.Value;
            updateInstructor.s_instructor_type_name_norwegian = txtInstructorTypeNameNorwegian.Text;
            updateInstructor.s_instructor_type_desc_norwegian = txtDescriptionNorwegian.Value;
            updateInstructor.s_instructor_type_name_turkish = txtInstructorTypeNameTurkish.Text;
            updateInstructor.s_instructor_type_desc_turkish = txtDescriptionTurkish.Value;
            updateInstructor.s_instructor_type_name_arabic_rtl = txtInstructorTypeNameArabic.Text;
            updateInstructor.s_instructor_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateInstructor.s_instructor_type_name_custom_01 = txtInstructorTypeNameCustom01.Text;
            updateInstructor.s_instructor_type_desc_custom_01 = txtDescriptionCustom01.Value;
            updateInstructor.s_instructor_type_name_custom_02 = txtInstructorTypeNameCustom02.Text;
            updateInstructor.s_instructor_type_desc_custom_02 = txtDescriptionCustom02.Value;
            updateInstructor.s_instructor_type_name_custom_03 = txtInstructorTypeNameCustom03.Text;
            updateInstructor.s_instructor_type_desc_custom_03 = txtDescriptionCustom03.Value;
            updateInstructor.s_instructor_type_name_custom_04 = txtInstructorTypeNameCustom04.Text;
            updateInstructor.s_instructor_type_desc_custom_04 = txtDescriptionCustom04.Value;
            updateInstructor.s_instructor_type_name_custom_05 = txtInstructorTypeNameCustom05.Text;
            updateInstructor.s_instructor_type_desc_custom_05 = txtDescriptionCustom05.Value;
            updateInstructor.s_instructor_type_name_custom_06 = txtInstructorTypeNameCustom06.Text;
            updateInstructor.s_instructor_type_desc_custom_06 = txtDescriptionCustom06.Value;
            updateInstructor.s_instructor_type_name_custom_07 = txtInstructorTypeNameCustom07.Text;
            updateInstructor.s_instructor_type_desc_custom_07 = txtDescriptionCustom07.Value;
            updateInstructor.s_instructor_type_name_custom_08 = txtInstructorTypeNameCustom08.Text;
            updateInstructor.s_instructor_type_desc_custom_08 = txtDescriptionCustom08.Value;
            updateInstructor.s_instructor_type_name_custom_09 = txtInstructorTypeNameCustom09.Text;
            updateInstructor.s_instructor_type_desc_custom_09 = txtDescriptionCustom09.Value;
            updateInstructor.s_instructor_type_name_custom_10 = txtInstructorTypeNameCustom10.Text;
            updateInstructor.s_instructor_type_desc_custom_10 = txtDescriptionCustom10.Value;
            updateInstructor.s_instructor_type_name_custom_11 = txtInstructorTypeNameCustom11.Text;
            updateInstructor.s_instructor_type_desc_custom_11 = txtDescriptionCustom11.Value;
            updateInstructor.s_instructor_type_name_custom_12 = txtInstructorTypeNameCustom12.Text;
            updateInstructor.s_instructor_type_desc_custom_12 = txtDescriptionCustom12.Value;
            updateInstructor.s_instructor_type_name_custom_13 = txtInstructorTypeNameCustom13.Text;
            updateInstructor.s_instructor_type_desc_custom_13 = txtDescriptionCustom13.Value;
            updateInstructor.s_instructor_type_name_simp_chinese = txtInstructorTypeNameChinese.Text;
            updateInstructor.s_instructor_type_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int result = SystemInstructorTypeBLL.UpdateInstructorType(updateInstructor);
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