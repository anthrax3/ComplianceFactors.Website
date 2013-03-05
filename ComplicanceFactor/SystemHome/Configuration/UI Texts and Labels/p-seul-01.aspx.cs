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

    public partial class Edit_Ui_Label : System.Web.UI.Page
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

                    PopulateUiLabel();



                }
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-saeul-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-saeul-01.aspx", ex.Message);
                    }
                }
            }


        }
        private void PopulateUiLabel()
        {
            SystemUI_Texts_Labels_Dropdown uiLabel = new SystemUI_Texts_Labels_Dropdown();
            if (!string.IsNullOrEmpty(Request.QueryString["appname"]))
            {
                uiLabel = SystemUI_Texts_Labels_DropdownBLL.GetUILabel(id, app_name);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                uiLabel = SystemUI_Texts_Labels_DropdownBLL.GetUILabel(id, app_name);
            }
            //Native
            lblNative.Text = uiLabel.s_ui_label_native;
            //English (US)
            txtEnglishUs.Text = uiLabel.s_ui_label_us_english;
            //English (UK)
            txEnglishUk.Text = uiLabel.s_ui_label_uk_english;
            //French (CA)
            txtFrenchCa.Text = uiLabel.s_ui_label_ca_french;
            //French (FR)
            txtFrenchFr.Text = uiLabel.s_ui_label_fr_french;
            //Spanish (MX)
            txtSpanishMx.Text = uiLabel.s_ui_label_mx_spanish;
            //Spanish (SP)
            txtSpanishSp.Text = uiLabel.s_ui_label_sp_spanish;
            //Portuguese
            txtPortuguese.Text = uiLabel.s_ui_label_portuguese;
            //Chinese (Simplified)
            txtChineseSimplified.Text = uiLabel.s_ui_label_simp_chinese;
            //German
            txtGerman.Text = uiLabel.s_ui_label_german;
            //Japanese
            txtJapanese.Text = uiLabel.s_ui_label_japanese;
            //Russian
            txtRussian.Text = uiLabel.s_ui_label_russian;
            //Danish
            txtDanish.Text = uiLabel.s_ui_label_danish;
            // Polish
            txtPolish.Text = uiLabel.s_ui_label_polish;
            //Swedish
            txtSwedish.Text = uiLabel.s_ui_label_swedish;
            //Finnish
            txtFinish.Text = uiLabel.s_ui_label_finnish;
            //Korean
            txtKorean.Text = uiLabel.s_ui_label_korean;
            //Italian
            txtItalian.Text = uiLabel.s_ui_label_italian;
            // Dutch
            txtDutch.Text = uiLabel.s_ui_label_dutch;
            //Indonesian
            txtIndonesian.Text = uiLabel.s_ui_label_indonesian;
            //Greek
            txtGreek.Text = uiLabel.s_ui_label_greek;
            //Hungarian
            txtHungarian.Text = uiLabel.s_ui_label_hungarian;
            //Norwegian
            txtNorwegian.Text = uiLabel.s_ui_label_norwegian;
            // Turkish
            txtTurkish.Text = uiLabel.s_ui_label_turkish;
            // Arabic
            txtArabic.Text = uiLabel.s_ui_label_arabic_rtl;
            // Custom 01
            txtCustom01.Text = uiLabel.s_ui_label_custom_01;
            // Custom 02
            txtCustom02.Text = uiLabel.s_ui_label_custom_02;
            // Custom 03
            txtCustom03.Text = uiLabel.s_ui_label_custom_03;
            // Custom 04
            txtCustom04.Text = uiLabel.s_ui_label_custom_04;
            // Custom 05
            txtCustom05.Text = uiLabel.s_ui_label_custom_05;
            // Custom 06
            txtCustom06.Text = uiLabel.s_ui_label_custom_06;
            // Custom 07
            txtCustom07.Text = uiLabel.s_ui_label_custom_07;
            // Custom 08
            txtCustom08.Text = uiLabel.s_ui_label_custom_08;
            // Custom 09
            txtCustom09.Text = uiLabel.s_ui_label_custom_09;
            // Custom 10
            txtCustom10.Text = uiLabel.s_ui_label_custom_10;
            // Custom 11
            txtCustom11.Text = uiLabel.s_ui_label_custom_11;
            // Custom 12
            txtCustom12.Text = uiLabel.s_ui_label_custom_12;
            // Custom 13
            txtCustom13.Text = uiLabel.s_ui_label_custom_13;

        }
        protected void btnSaveUiLabel_Click(object sender, EventArgs e)
        {
            try
            {
                SystemUI_Texts_Labels_Dropdown uiLabel = new SystemUI_Texts_Labels_Dropdown();
                uiLabel.s_ui_label_id_pk = id;
                uiLabel.s_ui_label_name = app_name;
                //English (US)
                uiLabel.s_ui_label_us_english = txtEnglishUs.Text;
                //English (UK)
                uiLabel.s_ui_label_uk_english = txEnglishUk.Text;
                //French (CA)
                uiLabel.s_ui_label_ca_french = txtFrenchCa.Text;
                //French (FR)
                uiLabel.s_ui_label_fr_french = txtFrenchFr.Text;
                //Spanish (MX)
                uiLabel.s_ui_label_mx_spanish = txtSpanishMx.Text;
                //Spanish (SP)
                uiLabel.s_ui_label_sp_spanish = txtSpanishSp.Text;
                //Chinese (Simplified)
                uiLabel.s_ui_label_simp_chinese = txtChineseSimplified.Text;
                //Portuguese
                uiLabel.s_ui_label_portuguese = txtPortuguese.Text;
                //German
                uiLabel.s_ui_label_german = txtGerman.Text;
                //Japanese
                uiLabel.s_ui_label_japanese = txtJapanese.Text;
                //Russian
                uiLabel.s_ui_label_russian = txtRussian.Text;
                //Danish
                uiLabel.s_ui_label_danish = txtDanish.Text;
                // Polish
                uiLabel.s_ui_label_polish = txtPolish.Text;
                //Swedish
                uiLabel.s_ui_label_swedish = txtSwedish.Text;
                //Finnish
                uiLabel.s_ui_label_finnish = txtFinish.Text;
                //Korean
                uiLabel.s_ui_label_korean = txtKorean.Text;
                //Italian
                uiLabel.s_ui_label_italian = txtItalian.Text;
                // Dutch
                uiLabel.s_ui_label_dutch = txtDutch.Text;
                //Indonesian
                uiLabel.s_ui_label_indonesian = txtIndonesian.Text;
                //Greek
                uiLabel.s_ui_label_greek = txtGreek.Text;
                //Hungarian
                uiLabel.s_ui_label_hungarian = txtHungarian.Text;
                //Norwegian
                uiLabel.s_ui_label_norwegian = txtNorwegian.Text;
                // Turkish
                uiLabel.s_ui_label_turkish = txtTurkish.Text;
                // Arabic
                uiLabel.s_ui_label_arabic_rtl = txtArabic.Text;
                // Custom 01
                uiLabel.s_ui_label_custom_01 = txtCustom01.Text;
                // Custom 02
                uiLabel.s_ui_label_custom_02 = txtCustom02.Text;
                // Custom 03
                uiLabel.s_ui_label_custom_03 = txtCustom03.Text;
                // Custom 04
                uiLabel.s_ui_label_custom_04 = txtCustom04.Text;
                // Custom 05
                uiLabel.s_ui_label_custom_05 = txtCustom05.Text;
                // Custom 06
                uiLabel.s_ui_label_custom_06 = txtCustom06.Text;
                // Custom 07
                uiLabel.s_ui_label_custom_07 = txtCustom07.Text;
                // Custom 08
                uiLabel.s_ui_label_custom_08 = txtCustom08.Text;
                // Custom 09
                uiLabel.s_ui_label_custom_09 = txtCustom09.Text;
                // Custom 10
                uiLabel.s_ui_label_custom_10 = txtCustom10.Text;
                // Custom 11
                uiLabel.s_ui_label_custom_11 = txtCustom11.Text;
                // Custom 12
                uiLabel.s_ui_label_custom_12 = txtCustom12.Text;
                // Custom 13
                uiLabel.s_ui_label_custom_13 = txtCustom13.Text;
                //update into database
                SystemUI_Texts_Labels_DropdownBLL.UpdateUILabel(uiLabel);
                //set active
                SessionWrapper.Active_Popup = "true";
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
                        Logger.WriteToErrorLog("p-saeul-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-saeul-01.aspx", ex.Message);
                    }
                }
            }


        }
    }
}