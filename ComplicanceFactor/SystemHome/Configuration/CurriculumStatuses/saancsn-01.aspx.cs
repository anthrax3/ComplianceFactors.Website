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

namespace ComplicanceFactor.SystemHome.Configuration.Curriculum_Statuses
{
    public partial class saancsn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label BreadCrumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/CurriculumStatuses/samcsmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_curriculum_status_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_create_new_curriculum_status_text") + "</a>";

                //Status Bind
                ddlStatus.DataSource = SystemCurriculumStatusBLL.GetStatus(SessionWrapper.CultureName, "saanctn-01");
                ddlStatus.DataBind();

                ddlStatus.SelectedValue = "app_ddl_active_text";

                //copy
                if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                {
                    PopulateCurriculumStatus(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                }
            }
        }


        protected void btnFooterSaveNewCurriculamStatus_Click(object sender, EventArgs e)
        {
            SaveCurriculumStatus();
        }
        /// <summary>
        /// Save Curriculum Statuss
        /// </summary>
        private void SaveCurriculumStatus()
        {
            SystemCurriculumStatus createCurriculum = new SystemCurriculumStatus();

            createCurriculum.s_curr_status_system_id_pk = Guid.NewGuid().ToString().Trim();
            createCurriculum.s_curr_status_id = txtCurriculumStatusId.Text;
            createCurriculum.s_curr_status_status_id_fk = ddlStatus.SelectedValue;
            createCurriculum.s_curr_status_name_us_english = txtCurriculumStatusName.Text;
            createCurriculum.s_curr_status_desc_us_english = txtDescriptionUS.Value;
            createCurriculum.s_curr_status_name_uk_english = txtCurriculumStatusNameUK.Text;
            createCurriculum.s_curr_status_desc_uk_english = txtDescriptionUK.Value;
            createCurriculum.s_curr_status_name_ca_french = txtCurriculumStatusNameCA.Text;
            createCurriculum.s_curr_status_desc_ca_french = txtDescriptionCA.Value;
            createCurriculum.s_curr_status_name_fr_french = txtCurriculumStatusNameFR.Text;
            createCurriculum.s_curr_status_desc_fr_french = txtDescriptionFR.Value;
            createCurriculum.s_curr_status_name_mx_spanish = txtCurriculumStatusNameMX.Text;
            createCurriculum.s_curr_status_desc_mx_spanish = txtDescriptionMX.Value;
            createCurriculum.s_curr_status_name_sp_spanish = txtCurriculumStatusNameSP.Text;
            createCurriculum.s_curr_status_desc_sp_spanish = txtDescriptionSP.Value;
            createCurriculum.s_curr_status_name_portuguese = txtCurriculumStatusNamePortuguse.Text;
            createCurriculum.s_curr_status_desc_portuguese = txtDescriptionPortuguese.Value;
            createCurriculum.s_curr_status_name_german = txtCurriculumStatusNameGerman.Text;
            createCurriculum.s_curr_status_desc_german = txtDescriptionGerman.Value;
            createCurriculum.s_curr_status_name_japanese = txtCurriculumStatusNameJapanese.Text;
            createCurriculum.s_curr_status_desc_japanese = txtDescriptionJapanese.Value;
            createCurriculum.s_curr_status_name_russian = txtCurriculumStatusNameRussian.Text;
            createCurriculum.s_curr_status_desc_russian = txtDescriptionRussian.Value;
            createCurriculum.s_curr_status_name_danish = txtCurriculumStatusNameDanish.Text;
            createCurriculum.s_curr_status_desc_danish = txtDescriptionDanish.Value;
            createCurriculum.s_curr_status_name_polish = txtCurriculumStatusNamePolish.Text;
            createCurriculum.s_curr_status_desc_polish = txtDescriptionPolish.Value;
            createCurriculum.s_curr_status_name_swedish = txtCurriculumStatusNameSwedish.Text;
            createCurriculum.s_curr_status_desc_swedish = txtDescriptionSwedish.Value;
            createCurriculum.s_curr_status_name_finnish = txtCurriculumStatusNameFinnish.Text;
            createCurriculum.s_curr_status_desc_finnish = txtDescriptionFinnish.Value;
            createCurriculum.s_curr_status_name_korean = txtCurriculumStatusNameKorean.Text;
            createCurriculum.s_curr_status_desc_korean = txtDescriptionKorean.Value;
            createCurriculum.s_curr_status_name_italian = txtCurriculumStatusNameItalian.Text;
            createCurriculum.s_curr_status_desc_italian = txtDescriptionItalian.Value;
            createCurriculum.s_curr_status_name_dutch = txtCurriculumStatusNameDutch.Text;
            createCurriculum.s_curr_status_desc_dutch = txtDescriptionDutch.Value;
            createCurriculum.s_curr_status_name_indonesian = txtCurriculumStatusNameIndonesian.Text;
            createCurriculum.s_curr_status_desc_indonesian = txtDescriptionIndonesian.Value;
            createCurriculum.s_curr_status_name_greek = txtCurriculumStatusNameGreek.Text;
            createCurriculum.s_curr_status_desc_greek = txtDescriptionGreek.Value;
            createCurriculum.s_curr_status_name_hungarian = txtCurriculumStatusNameHungarian.Text;
            createCurriculum.s_curr_status_desc_hungarian = txtDescriptionHungarian.Value;
            createCurriculum.s_curr_status_name_norwegian = txtCurriculumStatusNameNorwegian.Text;
            createCurriculum.s_curr_status_desc_norwegian = txtDescriptionNorwegian.Value;
            createCurriculum.s_curr_status_name_turkish = txtCurriculumStatusNameTurkish.Text;
            createCurriculum.s_curr_status_desc_turkish = txtDescriptionTurkish.Value;
            createCurriculum.s_curr_status_name_arabic_rtl = txtCurriculumStatusNameArabic.Text;
            createCurriculum.s_curr_status_desc_arabic_rtl = txtDescriptionArabic.Value;
            createCurriculum.s_curr_status_name_custom_01 = txtCurriculumStatusNameCustom01.Text;
            createCurriculum.s_curr_status_desc_custom_01 = txtDescriptionCustom01.Value;
            createCurriculum.s_curr_status_name_custom_02 = txtCurriculumStatusNameCustom02.Text;
            createCurriculum.s_curr_status_desc_custom_02 = txtDescriptionCustom02.Value;
            createCurriculum.s_curr_status_name_custom_03 = txtCurriculumStatusNameCustom03.Text;
            createCurriculum.s_curr_status_desc_custom_03 = txtDescriptionCustom03.Value;
            createCurriculum.s_curr_status_name_custom_04 = txtCurriculumStatusNameCustom04.Text;
            createCurriculum.s_curr_status_desc_custom_04 = txtDescriptionCustom04.Value;
            createCurriculum.s_curr_status_name_custom_05 = txtCurriculumStatusNameCustom05.Text;
            createCurriculum.s_curr_status_desc_custom_05 = txtDescriptionCustom05.Value;
            createCurriculum.s_curr_status_name_custom_06 = txtCurriculumStatusNameCustom06.Text;
            createCurriculum.s_curr_status_desc_custom_06 = txtDescriptionCustom06.Value;
            createCurriculum.s_curr_status_name_custom_07 = txtCurriculumStatusNameCustom07.Text;
            createCurriculum.s_curr_status_desc_custom_07 = txtDescriptionCustom07.Value;
            createCurriculum.s_curr_status_name_custom_08 = txtCurriculumStatusNameCustom08.Text;
            createCurriculum.s_curr_status_desc_custom_08 = txtDescriptionCustom08.Value;
            createCurriculum.s_curr_status_name_custom_09 = txtCurriculumStatusNameCustom09.Text;
            createCurriculum.s_curr_status_desc_custom_09 = txtDescriptionCustom09.Value;
            createCurriculum.s_curr_status_name_custom_10 = txtCurriculumStatusNameCustom10.Text;
            createCurriculum.s_curr_status_desc_custom_10 = txtDescriptionCustom10.Value;
            createCurriculum.s_curr_status_name_custom_11 = txtCurriculumStatusNameCustom11.Text;
            createCurriculum.s_curr_status_desc_custom_11 = txtDescriptionCustom11.Value;
            createCurriculum.s_curr_status_name_custom_12 = txtCurriculumStatusNameCustom12.Text;
            createCurriculum.s_curr_status_desc_custom_12 = txtDescriptionCustom12.Value;
            createCurriculum.s_curr_status_name_custom_13 = txtCurriculumStatusNameCustom13.Text;
            createCurriculum.s_curr_status_desc_custom_13 = txtDescriptionCustom13.Value;
            createCurriculum.s_curr_status_name_simp_chinese = txtCurriculumStatusNameChinese.Text;
            createCurriculum.s_curr_status_desc_simp_chinese = txtDescriptionChinese.Value;
            try
            {
                int error = SystemCurriculumStatusBLL.CreateCurriculumStatus(createCurriculum);
                if (error != -2)
                {
                    Response.Redirect("~/SystemHome/Configuration/CurriculumStatuses/saecs-01.aspx?edit=" + SecurityCenter.EncryptText(createCurriculum.s_curr_status_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    divError.Style.Add("display", "block");
                    divError.InnerText = LocalResources.GetText("app_curriculum_status_id_already_exist_error_wrong");
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
                        Logger.WriteToErrorLog("saancsn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saancsn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveNewCurriculumStatus_Click(object sender, EventArgs e)
        {
            SaveCurriculumStatus();
        }

        protected void btnFooterSaveNewCurriculumStatus_Click(object sender, EventArgs e)
        {
            SaveCurriculumStatus();
        }

        /// <summary>
        /// Populate the values for Copy
        /// </summary>
        /// <param name="CurriculumStatussId"></param>
        private void PopulateCurriculumStatus(string curriculumId)
        {
            SystemCurriculumStatus curriculumStatus = new SystemCurriculumStatus();

            try
            {
                curriculumStatus = SystemCurriculumStatusBLL.GetCurriculumStatus(curriculumId);

                txtCurriculumStatusId.Text = curriculumStatus.s_curr_status_id + "_Copy";
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
                        Logger.WriteToErrorLog("saancsn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saancsn-01.aspx", ex.Message);
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