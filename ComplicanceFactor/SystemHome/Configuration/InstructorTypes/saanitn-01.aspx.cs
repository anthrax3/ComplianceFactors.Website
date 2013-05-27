using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.InstructorTypes
{
    public partial class saanitn_01 : BasePage
    {
        private static string copyInstructorId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Bind instructor type status
                    ddlStatus.DataSource = SystemInstructorTypeBLL.GetStatus(SessionWrapper.CultureName, "saanitn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                    {
                        copyInstructorId = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                        PoulateInstructor(copyInstructorId);
                    }

                    //label BreadCrumb
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/InstructorTypes/samitmp-01.aspx>" + LocalResources.GetLabel("app_manage_instructor_type_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_create_new_instructor_type_text");
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
                        Logger.WriteToErrorLog("saanitn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanitn-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/InstructorTypes/samitmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/InstructorTypes/samitmp-01.aspx");
        }

        protected void btnHeaderSaveNewInstructorType_Click(object sender, EventArgs e)
        {
            SaveInstructorType();
        }

        protected void btnFooterSaveNewInstructorType_Click(object sender, EventArgs e)
        {
            SaveInstructorType();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>
        /// save instructor type
        /// </summary>
        private void SaveInstructorType()
        {
            SystemInstructorType instructorType = new SystemInstructorType();
            instructorType.s_instructor_type_system_id_pk = Guid.NewGuid().ToString();
            instructorType.s_instructor_type_id = txtInstructorTypeId.Text;
            instructorType.s_instructor_type_status_id_fk = ddlStatus.SelectedValue;

            instructorType.s_instructor_type_name_us_english = txtInstructorTypeName.Text;
            instructorType.s_instructor_type_desc_us_english = txtDescriptionUS.Value;
            instructorType.s_instructor_type_name_uk_english = txtInstructorTypeNameUK.Text;
            instructorType.s_instructor_type_desc_uk_english = txtDescriptionUK.Value;
            instructorType.s_instructor_type_name_ca_french = txtInstructorTypeNameCA.Text;
            instructorType.s_instructor_type_desc_ca_french = txtDescriptionCA.Value;
            instructorType.s_instructor_type_name_fr_french = txtInstructorTypeNameFR.Text;
            instructorType.s_instructor_type_desc_fr_french = txtDescriptionFR.Value;
            instructorType.s_instructor_type_name_mx_spanish = txtInstructorTypeNameMX.Text;
            instructorType.s_instructor_type_desc_mx_spanish = txtDescriptionMX.Value;
            instructorType.s_instructor_type_name_sp_spanish = txtInstructorTypeNameSP.Text;
            instructorType.s_instructor_type_desc_sp_spanish = txtDescriptionSP.Value;
            instructorType.s_instructor_type_name_portuguese = txtInstructorTypeNamePortuguse.Text;
            instructorType.s_instructor_type_desc_portuguese = txtDescriptionPortuguese.Value;
            instructorType.s_instructor_type_name_german = txtInstructorTypeNameGerman.Text;
            instructorType.s_instructor_type_desc_german = txtDescriptionGerman.Value;
            instructorType.s_instructor_type_name_japanese = txtInstructorTypeNameJapanese.Text;
            instructorType.s_instructor_type_desc_japanese = txtDescriptionJapanese.Value;
            instructorType.s_instructor_type_name_russian = txtInstructorTypeNameRussian.Text;
            instructorType.s_instructor_type_desc_russian = txtDescriptionRussian.Value;
            instructorType.s_instructor_type_name_danish = txtInstructorTypeNameDanish.Text;
            instructorType.s_instructor_type_desc_danish = txtDescriptionDanish.Value;
            instructorType.s_instructor_type_name_polish = txtInstructorTypeNamePolish.Text;
            instructorType.s_instructor_type_desc_polish = txtDescriptionPolish.Value;
            instructorType.s_instructor_type_name_swedish = txtInstructorTypeNameSwedish.Text;
            instructorType.s_instructor_type_desc_swedish = txtDescriptionSwedish.Value;
            instructorType.s_instructor_type_name_finnish = txtInstructorTypeNameFinnish.Text;
            instructorType.s_instructor_type_desc_finnish = txtDescriptionFinnish.Value;
            instructorType.s_instructor_type_name_korean = txtInstructorTypeNameKorean.Text;
            instructorType.s_instructor_type_desc_korean = txtDescriptionKorean.Value;
            instructorType.s_instructor_type_name_italian = txtInstructorTypeNameItalian.Text;
            instructorType.s_instructor_type_desc_italian = txtDescriptionItalian.Value;
            instructorType.s_instructor_type_name_dutch = txtInstructorTypeNameDutch.Text;
            instructorType.s_instructor_type_desc_dutch = txtDescriptionDutch.Value;
            instructorType.s_instructor_type_name_indonesian = txtInstructorTypeNameIndonesian.Text;
            instructorType.s_instructor_type_desc_indonesian = txtDescriptionIndonesian.Value;
            instructorType.s_instructor_type_name_greek = txtInstructorTypeNameGreek.Text;
            instructorType.s_instructor_type_desc_greek = txtDescriptionGreek.Value;
            instructorType.s_instructor_type_name_hungarian = txtInstructorTypeNameHungarian.Text;
            instructorType.s_instructor_type_desc_hungarian = txtDescriptionHungarian.Value;
            instructorType.s_instructor_type_name_norwegian = txtInstructorTypeNameNorwegian.Text;
            instructorType.s_instructor_type_desc_norwegian = txtDescriptionNorwegian.Value;
            instructorType.s_instructor_type_name_turkish = txtInstructorTypeNameTurkish.Text;
            instructorType.s_instructor_type_desc_turkish = txtDescriptionTurkish.Value;
            instructorType.s_instructor_type_name_arabic_rtl = txtInstructorTypeNameArabic.Text;
            instructorType.s_instructor_type_desc_arabic_rtl = txtDescriptionArabic.Value;
            instructorType.s_instructor_type_name_custom_01 = txtInstructorTypeNameCustom01.Text;
            instructorType.s_instructor_type_desc_custom_01 = txtDescriptionCustom01.Value;
            instructorType.s_instructor_type_name_custom_02 = txtInstructorTypeNameCustom02.Text;
            instructorType.s_instructor_type_desc_custom_02 = txtDescriptionCustom02.Value;
            instructorType.s_instructor_type_name_custom_03 = txtInstructorTypeNameCustom03.Text;
            instructorType.s_instructor_type_desc_custom_03 = txtDescriptionCustom03.Value;
            instructorType.s_instructor_type_name_custom_04 = txtInstructorTypeNameCustom04.Text;
            instructorType.s_instructor_type_desc_custom_04 = txtDescriptionCustom04.Value;
            instructorType.s_instructor_type_name_custom_05 = txtInstructorTypeNameCustom05.Text;
            instructorType.s_instructor_type_desc_custom_05 = txtDescriptionCustom05.Value;
            instructorType.s_instructor_type_name_custom_06 = txtInstructorTypeNameCustom06.Text;
            instructorType.s_instructor_type_desc_custom_06 = txtDescriptionCustom06.Value;
            instructorType.s_instructor_type_name_custom_07 = txtInstructorTypeNameCustom07.Text;
            instructorType.s_instructor_type_desc_custom_07 = txtDescriptionCustom07.Value;
            instructorType.s_instructor_type_name_custom_08 = txtInstructorTypeNameCustom08.Text;
            instructorType.s_instructor_type_desc_custom_08 = txtDescriptionCustom08.Value;
            instructorType.s_instructor_type_name_custom_09 = txtInstructorTypeNameCustom09.Text;
            instructorType.s_instructor_type_desc_custom_09 = txtDescriptionCustom09.Value;
            instructorType.s_instructor_type_name_custom_10 = txtInstructorTypeNameCustom10.Text;
            instructorType.s_instructor_type_desc_custom_10 = txtDescriptionCustom10.Value;
            instructorType.s_instructor_type_name_custom_11 = txtInstructorTypeNameCustom11.Text;
            instructorType.s_instructor_type_desc_custom_11 = txtDescriptionCustom11.Value;
            instructorType.s_instructor_type_name_custom_12 = txtInstructorTypeNameCustom12.Text;
            instructorType.s_instructor_type_desc_custom_12 = txtDescriptionCustom12.Value;
            instructorType.s_instructor_type_name_custom_13 = txtInstructorTypeNameCustom13.Text;
            instructorType.s_instructor_type_desc_custom_13 = txtDescriptionCustom13.Value;
            instructorType.s_instructor_type_name_simp_chinese = txtInstructorTypeNameChinese.Text;
            instructorType.s_instructor_type_desc_simp_chinese = txtDescriptionChinese.Value;            

            try
            {

                int result = SystemInstructorTypeBLL.CreateInstructorType(instructorType);

                if (result != -2)
                {
                    Response.Redirect("~/SystemHome/Configuration/InstructorTypes/saeitn-01.aspx?id=" + SecurityCenter.EncryptText(instructorType.s_instructor_type_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
                else
                {
                    ///<summary>
                    ///Show error message 
                    ///</summary>
                    divError.Style.Add("display", "block");
                    divError.InnerText = "Instructor Type Id already exists";
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
                        Logger.WriteToErrorLog("sannitn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sannitn-01", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Populate the Instructor values
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
                        Logger.WriteToErrorLog("saanitn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanitn-01", ex.Message);
                    }
                }
            }
        }
    }
}