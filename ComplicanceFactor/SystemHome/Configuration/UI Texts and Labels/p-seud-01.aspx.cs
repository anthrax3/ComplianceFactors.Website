using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels
{
    public partial class Edit_Ui_Dropdown : System.Web.UI.Page
    {
        private string id;
        private string app_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(Request.QueryString["appname"]))
                {
                    app_name = Request.QueryString["appname"];
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    id = Request.QueryString["id"];
                }
                if (!IsPostBack)
                {

                    PopulateUiDropdown();

                }
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-saud-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-saud-01.aspx", ex.Message);
                    }
                }
            }


        }
        private void PopulateUiDropdown()
        {
            SystemUI_Texts_Labels_Dropdown uiDropdown = new SystemUI_Texts_Labels_Dropdown();
            if (!string.IsNullOrEmpty(Request.QueryString["appname"]))
            {
                uiDropdown = SystemUI_Texts_Labels_DropdownBLL.GetUIDropdown(id, app_name);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                uiDropdown = SystemUI_Texts_Labels_DropdownBLL.GetUIDropdown(id, app_name);
            }
            //Native
            lblNative.Text = uiDropdown.s_ui_dropdown_native;
            //English (US)
            txtEnglishUs.Text = uiDropdown.s_ui_dropdown_us_english;
            //English (UK)
            txEnglishUk.Text = uiDropdown.s_ui_dropdown_uk_english;
            //French (CA)
            txtFrenchCa.Text = uiDropdown.s_ui_dropdown_ca_french;
            //French (FR)
            txtFrenchFr.Text = uiDropdown.s_ui_dropdown_fr_french;
            //Spanish (MX)
            txtSpanishMx.Text = uiDropdown.s_ui_dropdown_mx_spanish;
            //Spanish (SP)
            txtSpanishSp.Text = uiDropdown.s_ui_dropdown_sp_spanish;
            //Portuguese
            txtPortuguese.Text = uiDropdown.s_ui_dropdown_portuguese;
            //Chinese (Simplified)
            txtChineseSimplified.Text = uiDropdown.s_ui_dropdown_simp_chinese;
            //German
            txtGerman.Text = uiDropdown.s_ui_dropdown_german;
            //Japanese
            txtJapanese.Text = uiDropdown.s_ui_dropdown_japanese;
            //Russian
            txtRussian.Text = uiDropdown.s_ui_dropdown_russian;
            //Danish
            txtDanish.Text = uiDropdown.s_ui_dropdown_danish;
            // Polish
            txtPolish.Text = uiDropdown.s_ui_dropdown_polish;
            //Swedish
            txtSwedish.Text = uiDropdown.s_ui_dropdown_swedish;
            //Finnish
            txtFinish.Text = uiDropdown.s_ui_dropdown_finnish;
            //Korean
            txtKorean.Text = uiDropdown.s_ui_dropdown_korean;
            //Italian
            txtItalian.Text = uiDropdown.s_ui_dropdown_italian;
            // Dutch
            txtDutch.Text = uiDropdown.s_ui_dropdown_dutch;
            //Indonesian
            txtIndonesian.Text = uiDropdown.s_ui_dropdown_indonesian;
            //Greek
            txtGreek.Text = uiDropdown.s_ui_dropdown_greek;
            //Hungarian
            txtHungarian.Text = uiDropdown.s_ui_dropdown_hungarian;
            //Norwegian
            txtNorwegian.Text = uiDropdown.s_ui_dropdown_norwegian;
            // Turkish
            txtTurkish.Text = uiDropdown.s_ui_dropdown_turkish;
            // Arabic
            txtArabic.Text = uiDropdown.s_ui_dropdown_arabic_rtl;
            // Custom 01
            txtCustom01.Text = uiDropdown.s_ui_dropdown_custom_01;
            // Custom 02
            txtCustom02.Text = uiDropdown.s_ui_dropdown_custom_02;
            // Custom 03
            txtCustom03.Text = uiDropdown.s_ui_dropdown_custom_03;
            // Custom 04
            txtCustom04.Text = uiDropdown.s_ui_dropdown_custom_04;
            // Custom 05
            txtCustom05.Text = uiDropdown.s_ui_dropdown_custom_05;
            // Custom 06
            txtCustom06.Text = uiDropdown.s_ui_dropdown_custom_06;
            // Custom 07
            txtCustom07.Text = uiDropdown.s_ui_dropdown_custom_07;
            // Custom 08
            txtCustom08.Text = uiDropdown.s_ui_dropdown_custom_08;
            // Custom 09
            txtCustom09.Text = uiDropdown.s_ui_dropdown_custom_09;
            // Custom 10
            txtCustom10.Text = uiDropdown.s_ui_dropdown_custom_10;
            // Custom 11
            txtCustom11.Text = uiDropdown.s_ui_dropdown_custom_11;
            // Custom 12
            txtCustom12.Text = uiDropdown.s_ui_dropdown_custom_12;
            // Custom 13
            txtCustom13.Text = uiDropdown.s_ui_dropdown_custom_13;

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            try
            {
                SystemUI_Texts_Labels_Dropdown ui_dropdown = new SystemUI_Texts_Labels_Dropdown();
                ui_dropdown.s_ui_dropdown_id_pk = id;
                ui_dropdown.s_ui_dropdown_name = app_name;
                //English (US)
                ui_dropdown.s_ui_dropdown_us_english = txtEnglishUs.Text;
                //English (UK)
                ui_dropdown.s_ui_dropdown_uk_english = txEnglishUk.Text;
                //French (CA)
                ui_dropdown.s_ui_dropdown_ca_french = txtFrenchCa.Text;
                //French (FR)
                ui_dropdown.s_ui_dropdown_fr_french = txtFrenchFr.Text;
                //Spanish (MX)
                ui_dropdown.s_ui_dropdown_mx_spanish = txtSpanishMx.Text;
                //Spanish (SP)
                ui_dropdown.s_ui_dropdown_sp_spanish = txtSpanishSp.Text;
                //Chinese (Simplified)
                ui_dropdown.s_ui_dropdown_simp_chinese = txtChineseSimplified.Text;
                //Portuguese
                ui_dropdown.s_ui_dropdown_portuguese = txtPortuguese.Text;
                //German
                ui_dropdown.s_ui_dropdown_german = txtGerman.Text;
                //Japanese
                ui_dropdown.s_ui_dropdown_japanese = txtJapanese.Text;
                //Russian
                ui_dropdown.s_ui_dropdown_russian = txtRussian.Text;
                //Danish
                ui_dropdown.s_ui_dropdown_danish = txtDanish.Text;
                // Polish
                ui_dropdown.s_ui_dropdown_polish = txtPolish.Text;
                //Swedish
                ui_dropdown.s_ui_dropdown_swedish = txtSwedish.Text;
                //Finnish
                ui_dropdown.s_ui_dropdown_finnish = txtFinish.Text;
                //Korean
                ui_dropdown.s_ui_dropdown_korean = txtKorean.Text;
                //Italian
                ui_dropdown.s_ui_dropdown_italian = txtItalian.Text;
                // Dutch
                ui_dropdown.s_ui_dropdown_dutch = txtDutch.Text;
                //Indonesian
                ui_dropdown.s_ui_dropdown_indonesian = txtIndonesian.Text;
                //Greek
                ui_dropdown.s_ui_dropdown_greek = txtGreek.Text;
                //Hungarian
                ui_dropdown.s_ui_dropdown_hungarian = txtHungarian.Text;
                //Norwegian
                ui_dropdown.s_ui_dropdown_norwegian = txtNorwegian.Text;
                // Turkish
                ui_dropdown.s_ui_dropdown_turkish = txtTurkish.Text;
                // Arabic
                ui_dropdown.s_ui_dropdown_arabic_rtl = txtArabic.Text;
                // Custom 01
                ui_dropdown.s_ui_dropdown_custom_01 = txtCustom01.Text;
                // Custom 02
                ui_dropdown.s_ui_dropdown_custom_02 = txtCustom02.Text;
                // Custom 03
                ui_dropdown.s_ui_dropdown_custom_03 = txtCustom03.Text;
                // Custom 04
                ui_dropdown.s_ui_dropdown_custom_04 = txtCustom04.Text;
                // Custom 05
                ui_dropdown.s_ui_dropdown_custom_05 = txtCustom05.Text;
                // Custom 06
                ui_dropdown.s_ui_dropdown_custom_06 = txtCustom06.Text;
                // Custom 07
                ui_dropdown.s_ui_dropdown_custom_07 = txtCustom07.Text;
                // Custom 08
                ui_dropdown.s_ui_dropdown_custom_08 = txtCustom08.Text;
                // Custom 09
                ui_dropdown.s_ui_dropdown_custom_09 = txtCustom09.Text;
                // Custom 10
                ui_dropdown.s_ui_dropdown_custom_10 = txtCustom10.Text;
                // Custom 11
                ui_dropdown.s_ui_dropdown_custom_11 = txtCustom11.Text;
                // Custom 12
                ui_dropdown.s_ui_dropdown_custom_12 = txtCustom12.Text;
                // Custom 13
                ui_dropdown.s_ui_dropdown_custom_13 = txtCustom13.Text;
                //update into database
                SystemUI_Texts_Labels_DropdownBLL.UpdateUIDropdown(ui_dropdown);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-seud-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-seud-01.aspx", ex.Message);
                    }
                }
            }

        }
    }
}