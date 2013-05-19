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

namespace ComplicanceFactor.SystemHome.Configuration.Curriculum_Statuses
{
    public partial class saecs_01 : System.Web.UI.Page
    {
        private static string editCurriculumStatusId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Edit Curriculum Status Id
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                editCurriculumStatusId = SecurityCenter.DecryptText(Request.QueryString["edit"]);
            }
            if (!IsPostBack)
            {
                //Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/CurriculumStatuses/samcsmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_curriculum_status_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_curriculum_status_text");

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                //Bind Status
                ddlStatus.DataSource = SystemCurriculumStatusBLL.GetStatus(SessionWrapper.CultureName, "saectn-01");
                ddlStatus.DataBind();

                PopulateCurriculumStatus(editCurriculumStatusId);
            }
        }
        /// <summary>
        /// Populate the values for Edit
        /// </summary>
        /// <param name="CurriculumStatusId"></param>
        private void PopulateCurriculumStatus(string CurriculumStatusId)
        {
            SystemCurriculumStatus curriculumStatus = new SystemCurriculumStatus();
            try
            {
                curriculumStatus = SystemCurriculumStatusBLL.GetCurriculumStatus(CurriculumStatusId);
                txtCurriculumStatusId.Text = curriculumStatus.s_curr_status_id;
                ddlStatus.SelectedValue = curriculumStatus.s_curr_status_status_id_fk;

                txtCurriculumStatusName.Text = curriculumStatus.s_curr_status_name_us_english;
                txtDescriptionUS.Value = curriculumStatus.s_curr_status_desc_us_english;
                txtCurriculumStatusNameUK.Text = curriculumStatus.s_curr_status_name_uk_english;
                txtDescriptionUK.Value = curriculumStatus.s_curr_status_desc_uk_english;
                txtCurriculumStatusNameCA.Text = curriculumStatus.s_curr_status_name_ca_french;
                txtDescriptionCA.Value = curriculumStatus.s_curr_status_desc_ca_french;
                txtCurriculumStatusNameFR.Text = curriculumStatus.s_curr_status_name_fr_french;
                txtDescriptionFR.Value = curriculumStatus.s_curr_status_desc_fr_french;
                txtCurriculumStatusNameMX.Text = curriculumStatus.s_curr_status_name_mx_spanish;
                txtDescriptionMX.Value = curriculumStatus.s_curr_status_desc_mx_spanish;
                txtCurriculumStatusNameSP.Text = curriculumStatus.s_curr_status_name_sp_spanish;
                txtDescriptionSP.Value = curriculumStatus.s_curr_status_desc_sp_spanish;
                txtCurriculumStatusNamePortuguse.Text = curriculumStatus.s_curr_status_name_portuguese;
                txtDescriptionPortuguese.Value = curriculumStatus.s_curr_status_desc_portuguese;
                txtCurriculumStatusNameGerman.Text = curriculumStatus.s_curr_status_name_german;
                txtDescriptionGerman.Value = curriculumStatus.s_curr_status_desc_german;
                txtCurriculumStatusNameJapanese.Text = curriculumStatus.s_curr_status_name_japanese;
                txtDescriptionJapanese.Value = curriculumStatus.s_curr_status_desc_japanese;
                txtCurriculumStatusNameRussian.Text = curriculumStatus.s_curr_status_name_russian;
                txtDescriptionRussian.Value = curriculumStatus.s_curr_status_desc_russian;
                txtCurriculumStatusNameDanish.Text = curriculumStatus.s_curr_status_name_danish;
                txtDescriptionDanish.Value = curriculumStatus.s_curr_status_desc_danish;
                txtCurriculumStatusNamePolish.Text = curriculumStatus.s_curr_status_name_polish;
                txtDescriptionPolish.Value = curriculumStatus.s_curr_status_desc_polish;
                txtCurriculumStatusNameSwedish.Text = curriculumStatus.s_curr_status_name_swedish;
                txtDescriptionSwedish.Value = curriculumStatus.s_curr_status_desc_swedish;
                txtCurriculumStatusNameFinnish.Text = curriculumStatus.s_curr_status_name_finnish;
                txtDescriptionFinnish.Value = curriculumStatus.s_curr_status_desc_finnish;
                txtCurriculumStatusNameKorean.Text = curriculumStatus.s_curr_status_name_korean;
                txtDescriptionKorean.Value = curriculumStatus.s_curr_status_desc_korean;
                txtCurriculumStatusNameItalian.Text = curriculumStatus.s_curr_status_name_italian;
                txtDescriptionItalian.Value = curriculumStatus.s_curr_status_desc_italian;
                txtCurriculumStatusNameDutch.Text = curriculumStatus.s_curr_status_name_dutch;
                txtDescriptionDutch.Value = curriculumStatus.s_curr_status_desc_dutch;
                txtCurriculumStatusNameIndonesian.Text = curriculumStatus.s_curr_status_name_indonesian;
                txtDescriptionIndonesian.Value = curriculumStatus.s_curr_status_desc_indonesian;
                txtCurriculumStatusNameGreek.Text = curriculumStatus.s_curr_status_name_greek;
                txtDescriptionGreek.Value = curriculumStatus.s_curr_status_desc_greek;
                txtCurriculumStatusNameHungarian.Text = curriculumStatus.s_curr_status_name_hungarian;
                txtDescriptionHungarian.Value = curriculumStatus.s_curr_status_desc_hungarian;
                txtCurriculumStatusNameNorwegian.Text = curriculumStatus.s_curr_status_name_norwegian;
                txtDescriptionNorwegian.Value = curriculumStatus.s_curr_status_desc_norwegian;
                txtCurriculumStatusNameTurkish.Text = curriculumStatus.s_curr_status_name_turkish;
                txtDescriptionTurkish.Value = curriculumStatus.s_curr_status_desc_turkish;
                txtCurriculumStatusNameArabic.Text = curriculumStatus.s_curr_status_name_arabic_rtl;
                txtDescriptionArabic.Value = curriculumStatus.s_curr_status_desc_arabic_rtl;
                txtCurriculumStatusNameCustom01.Text = curriculumStatus.s_curr_status_name_custom_01;
                txtDescriptionCustom01.Value = curriculumStatus.s_curr_status_desc_custom_01;
                txtCurriculumStatusNameCustom02.Text = curriculumStatus.s_curr_status_name_custom_01;
                txtDescriptionCustom02.Value = curriculumStatus.s_curr_status_desc_custom_02;
                txtCurriculumStatusNameCustom03.Text = curriculumStatus.s_curr_status_name_custom_03;
                txtDescriptionCustom03.Value = curriculumStatus.s_curr_status_desc_custom_03;
                txtCurriculumStatusNameCustom04.Text = curriculumStatus.s_curr_status_name_custom_04;
                txtDescriptionCustom04.Value = curriculumStatus.s_curr_status_desc_custom_04;
                txtCurriculumStatusNameCustom05.Text = curriculumStatus.s_curr_status_name_custom_05;
                txtDescriptionCustom05.Value = curriculumStatus.s_curr_status_desc_custom_05;
                txtCurriculumStatusNameCustom06.Text = curriculumStatus.s_curr_status_name_custom_06;
                txtDescriptionCustom06.Value = curriculumStatus.s_curr_status_desc_custom_06;
                txtCurriculumStatusNameCustom07.Text = curriculumStatus.s_curr_status_name_custom_07;
                txtDescriptionCustom07.Value = curriculumStatus.s_curr_status_desc_custom_07;
                txtCurriculumStatusNameCustom08.Text = curriculumStatus.s_curr_status_name_custom_08;
                txtDescriptionCustom08.Value = curriculumStatus.s_curr_status_name_custom_08;
                txtCurriculumStatusNameCustom09.Text = curriculumStatus.s_curr_status_name_custom_09;
                txtDescriptionCustom09.Value = curriculumStatus.s_curr_status_desc_custom_09;
                txtCurriculumStatusNameCustom10.Text = curriculumStatus.s_curr_status_name_custom_10;
                txtDescriptionCustom10.Value = curriculumStatus.s_curr_status_desc_custom_10;
                txtCurriculumStatusNameCustom11.Text = curriculumStatus.s_curr_status_name_custom_11;
                txtDescriptionCustom11.Value = curriculumStatus.s_curr_status_name_custom_11;
                txtCurriculumStatusNameCustom12.Text = curriculumStatus.s_curr_status_name_custom_12;
                txtDescriptionCustom12.Value = curriculumStatus.s_curr_status_desc_custom_12;
                txtCurriculumStatusNameCustom13.Text = curriculumStatus.s_curr_status_name_custom_13;
                txtDescriptionCustom13.Value = curriculumStatus.s_curr_status_desc_custom_13;
                txtCurriculumStatusNameChinese.Text = curriculumStatus.s_curr_status_name_simp_chinese;
                txtDescriptionChinese.Value = curriculumStatus.s_curr_status_desc_simp_chinese;
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

        protected void btnHeaderSaveCurriculumStatus_Click(object sender, EventArgs e)
        {
            UpdateCurriculumStatus();
        }

        protected void btnFooterSaveCurriculumStatus_Click(object sender, EventArgs e)
        {
            UpdateCurriculumStatus();
        }

        /// <summary>
        /// Update the Curriculum Status
        /// </summary>        

        private void UpdateCurriculumStatus()
        {
            SystemCurriculumStatus updateCurriculum = new SystemCurriculumStatus();

            updateCurriculum.s_curr_status_system_id_pk = editCurriculumStatusId;
            updateCurriculum.s_curr_status_id = txtCurriculumStatusId.Text;
            updateCurriculum.s_curr_status_status_id_fk = ddlStatus.SelectedValue;

            updateCurriculum.s_curr_status_name_us_english = txtCurriculumStatusName.Text;
            updateCurriculum.s_curr_status_desc_us_english = txtDescriptionUS.Value;
            updateCurriculum.s_curr_status_name_uk_english = txtCurriculumStatusNameUK.Text;
            updateCurriculum.s_curr_status_desc_uk_english = txtDescriptionUK.Value;
            updateCurriculum.s_curr_status_name_ca_french = txtCurriculumStatusNameCA.Text;
            updateCurriculum.s_curr_status_desc_ca_french = txtDescriptionCA.Value;
            updateCurriculum.s_curr_status_name_fr_french = txtCurriculumStatusNameFR.Text;
            updateCurriculum.s_curr_status_desc_fr_french = txtDescriptionFR.Value;
            updateCurriculum.s_curr_status_name_mx_spanish = txtCurriculumStatusNameMX.Text;
            updateCurriculum.s_curr_status_desc_mx_spanish = txtDescriptionMX.Value;
            updateCurriculum.s_curr_status_name_sp_spanish = txtCurriculumStatusNameSP.Text;
            updateCurriculum.s_curr_status_desc_sp_spanish = txtDescriptionSP.Value;
            updateCurriculum.s_curr_status_name_portuguese = txtCurriculumStatusNamePortuguse.Text;
            updateCurriculum.s_curr_status_desc_portuguese = txtDescriptionPortuguese.Value;
            updateCurriculum.s_curr_status_name_german = txtCurriculumStatusNameGerman.Text;
            updateCurriculum.s_curr_status_desc_german = txtDescriptionGerman.Value;
            updateCurriculum.s_curr_status_name_japanese = txtCurriculumStatusNameJapanese.Text;
            updateCurriculum.s_curr_status_desc_japanese = txtDescriptionJapanese.Value;
            updateCurriculum.s_curr_status_name_russian = txtCurriculumStatusNameRussian.Text;
            updateCurriculum.s_curr_status_desc_russian = txtDescriptionRussian.Value;
            updateCurriculum.s_curr_status_name_danish = txtCurriculumStatusNameDanish.Text;
            updateCurriculum.s_curr_status_desc_danish = txtDescriptionDanish.Value;
            updateCurriculum.s_curr_status_name_polish = txtCurriculumStatusNamePolish.Text;
            updateCurriculum.s_curr_status_desc_polish = txtDescriptionPolish.Value;
            updateCurriculum.s_curr_status_name_swedish = txtCurriculumStatusNameSwedish.Text;
            updateCurriculum.s_curr_status_desc_swedish = txtDescriptionSwedish.Value;
            updateCurriculum.s_curr_status_name_finnish = txtCurriculumStatusNameFinnish.Text;
            updateCurriculum.s_curr_status_desc_finnish = txtDescriptionFinnish.Value;
            updateCurriculum.s_curr_status_name_korean = txtCurriculumStatusNameKorean.Text;
            updateCurriculum.s_curr_status_desc_korean = txtDescriptionKorean.Value;
            updateCurriculum.s_curr_status_name_italian = txtCurriculumStatusNameItalian.Text;
            updateCurriculum.s_curr_status_desc_italian = txtDescriptionItalian.Value;
            updateCurriculum.s_curr_status_name_dutch = txtCurriculumStatusNameDutch.Text;
            updateCurriculum.s_curr_status_desc_dutch = txtDescriptionDutch.Value;
            updateCurriculum.s_curr_status_name_indonesian = txtCurriculumStatusNameIndonesian.Text;
            updateCurriculum.s_curr_status_desc_indonesian = txtDescriptionIndonesian.Value;
            updateCurriculum.s_curr_status_name_greek = txtCurriculumStatusNameGreek.Text;
            updateCurriculum.s_curr_status_desc_greek = txtDescriptionGreek.Value;
            updateCurriculum.s_curr_status_name_hungarian = txtCurriculumStatusNameHungarian.Text;
            updateCurriculum.s_curr_status_desc_hungarian = txtDescriptionHungarian.Value;
            updateCurriculum.s_curr_status_name_norwegian = txtCurriculumStatusNameNorwegian.Text;
            updateCurriculum.s_curr_status_desc_norwegian = txtDescriptionNorwegian.Value;
            updateCurriculum.s_curr_status_name_turkish = txtCurriculumStatusNameTurkish.Text;
            updateCurriculum.s_curr_status_desc_turkish = txtDescriptionTurkish.Value;
            updateCurriculum.s_curr_status_name_arabic_rtl = txtCurriculumStatusNameArabic.Text;
            updateCurriculum.s_curr_status_desc_arabic_rtl = txtDescriptionArabic.Value;
            updateCurriculum.s_curr_status_name_custom_01 = txtCurriculumStatusNameCustom01.Text;
            updateCurriculum.s_curr_status_desc_custom_01 = txtDescriptionCustom01.Value;
            updateCurriculum.s_curr_status_name_custom_02 = txtCurriculumStatusNameCustom02.Text;
            updateCurriculum.s_curr_status_desc_custom_02 = txtDescriptionCustom02.Value;
            updateCurriculum.s_curr_status_name_custom_03 = txtCurriculumStatusNameCustom03.Text;
            updateCurriculum.s_curr_status_desc_custom_03 = txtDescriptionCustom03.Value;
            updateCurriculum.s_curr_status_name_custom_04 = txtCurriculumStatusNameCustom04.Text;
            updateCurriculum.s_curr_status_desc_custom_04 = txtDescriptionCustom04.Value;
            updateCurriculum.s_curr_status_name_custom_05 = txtCurriculumStatusNameCustom05.Text;
            updateCurriculum.s_curr_status_desc_custom_05 = txtDescriptionCustom05.Value;
            updateCurriculum.s_curr_status_name_custom_06 = txtCurriculumStatusNameCustom06.Text;
            updateCurriculum.s_curr_status_desc_custom_06 = txtDescriptionCustom06.Value;
            updateCurriculum.s_curr_status_name_custom_07 = txtCurriculumStatusNameCustom07.Text;
            updateCurriculum.s_curr_status_desc_custom_07 = txtDescriptionCustom07.Value;
            updateCurriculum.s_curr_status_name_custom_08 = txtCurriculumStatusNameCustom08.Text;
            updateCurriculum.s_curr_status_desc_custom_08 = txtDescriptionCustom08.Value;
            updateCurriculum.s_curr_status_name_custom_09 = txtCurriculumStatusNameCustom09.Text;
            updateCurriculum.s_curr_status_desc_custom_09 = txtDescriptionCustom09.Value;
            updateCurriculum.s_curr_status_name_custom_10 = txtCurriculumStatusNameCustom10.Text;
            updateCurriculum.s_curr_status_desc_custom_10 = txtDescriptionCustom10.Value;
            updateCurriculum.s_curr_status_name_custom_11 = txtCurriculumStatusNameCustom11.Text;
            updateCurriculum.s_curr_status_desc_custom_11 = txtDescriptionCustom11.Value;
            updateCurriculum.s_curr_status_name_custom_12 = txtCurriculumStatusNameCustom12.Text;
            updateCurriculum.s_curr_status_desc_custom_12 = txtDescriptionCustom12.Value;
            updateCurriculum.s_curr_status_name_custom_13 = txtCurriculumStatusNameCustom13.Text;
            updateCurriculum.s_curr_status_desc_custom_13 = txtDescriptionCustom13.Value;
            updateCurriculum.s_curr_status_name_simp_chinese = txtCurriculumStatusNameChinese.Text;
            updateCurriculum.s_curr_status_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                

                int error = SystemCurriculumStatusBLL.UpdateCurriculumStatus(updateCurriculum);
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
                    divError.InnerText = LocalResources.GetText("app_curr_statuses_id_already_exists_error_text");

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
                        Logger.WriteToErrorLog("saecs-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saecs-01.aspx", ex.Message);
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
            Response.Redirect("~/SystemHome/Configuration/CurriculumStatuses/samcsmp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/CurriculumStatuses/samcsmp-01.aspx");
        }

       
    }
}