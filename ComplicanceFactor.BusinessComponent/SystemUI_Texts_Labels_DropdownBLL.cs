using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemUI_Texts_Labels_DropdownBLL
    {
        /// <summary>
        /// Search ui label,text and dropdown
        /// </summary>
        /// <param name="ui_text_label_dropdown"></param>
        /// <returns></returns>
        public static DataTable GetUI_Label_Text_Dropdown(SystemUI_Texts_Labels_Dropdown ui_text_label_dropdown)
        {
            Hashtable ht_ui_text_label_dropdown = new Hashtable();
            ht_ui_text_label_dropdown.Add("@s_ui_label_text_dropdown_name", ui_text_label_dropdown.s_ui_label_text_dropdown_name);
            ht_ui_text_label_dropdown.Add("@s_ui_page_name", ui_text_label_dropdown.s_ui_page_name);
            ht_ui_text_label_dropdown.Add("@s_ui_keyword", ui_text_label_dropdown.s_ui_keyword);
            if (ui_text_label_dropdown.s_ui_type == "0")
            {
                ht_ui_text_label_dropdown.Add("@s_ui_type", DBNull.Value);
            }
            else
            {
                ht_ui_text_label_dropdown.Add("@s_ui_type", ui_text_label_dropdown.s_ui_type);
            }
            ht_ui_text_label_dropdown.Add("@s_ui_locale_name", ui_text_label_dropdown.s_ui_locale_name);
            ht_ui_text_label_dropdown.Add("@s_ui_native_label", ui_text_label_dropdown.s_ui_native_label);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_ui_label_text_dropdown", ht_ui_text_label_dropdown);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemUI_Texts_Labels_Dropdown GetUILabel(string s_ui_label_id_pk, string label_name)
        {

            try
            {
                Hashtable htUiLabel = new Hashtable();
                if (!string.IsNullOrEmpty(s_ui_label_id_pk))
                {
                    htUiLabel.Add("@s_ui_label_id_pk", s_ui_label_id_pk);
                }
                else
                {
                    htUiLabel.Add("@s_ui_label_id_pk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(label_name))
                {
                    htUiLabel.Add("@label_name", label_name);
                }
                else
                {
                    htUiLabel.Add("@label_name", DBNull.Value);
                }
                SystemUI_Texts_Labels_Dropdown uiLabel = new SystemUI_Texts_Labels_Dropdown();
                DataTable dtGetUiLabel = DataProxy.FetchDataTable("s_sp_get_ui_labels", htUiLabel);
                uiLabel.s_ui_label_name = dtGetUiLabel.Rows[0]["s_ui_label_name"].ToString();
                uiLabel.s_ui_page_name = dtGetUiLabel.Rows[0]["s_ui_page_name"].ToString();
                uiLabel.s_ui_label_native = dtGetUiLabel.Rows[0]["s_ui_label_native"].ToString();
                uiLabel.s_ui_label_us_english = dtGetUiLabel.Rows[0]["s_ui_label_us_english"].ToString();
                uiLabel.s_ui_label_uk_english = dtGetUiLabel.Rows[0]["s_ui_label_uk_english"].ToString();
                uiLabel.s_ui_label_ca_french = dtGetUiLabel.Rows[0]["s_ui_label_ca_french"].ToString();
                uiLabel.s_ui_label_fr_french = dtGetUiLabel.Rows[0]["s_ui_label_fr_french"].ToString();
                uiLabel.s_ui_label_mx_spanish = dtGetUiLabel.Rows[0]["s_ui_label_mx_spanish"].ToString();
                uiLabel.s_ui_label_sp_spanish = dtGetUiLabel.Rows[0]["s_ui_label_sp_spanish"].ToString();
                uiLabel.s_ui_label_portuguese = dtGetUiLabel.Rows[0]["s_ui_label_portuguese"].ToString();
                uiLabel.s_ui_label_simp_chinese = dtGetUiLabel.Rows[0]["s_ui_label_simp_chinese"].ToString();
                uiLabel.s_ui_label_german = dtGetUiLabel.Rows[0]["s_ui_label_german"].ToString();
                uiLabel.s_ui_label_japanese = dtGetUiLabel.Rows[0]["s_ui_label_japanese"].ToString();
                uiLabel.s_ui_label_russian = dtGetUiLabel.Rows[0]["s_ui_label_russian"].ToString();
                uiLabel.s_ui_label_danish = dtGetUiLabel.Rows[0]["s_ui_label_danish"].ToString();
                uiLabel.s_ui_label_polish = dtGetUiLabel.Rows[0]["s_ui_label_polish"].ToString();
                uiLabel.s_ui_label_swedish = dtGetUiLabel.Rows[0]["s_ui_label_swedish"].ToString();
                uiLabel.s_ui_label_finnish = dtGetUiLabel.Rows[0]["s_ui_label_finnish"].ToString();
                uiLabel.s_ui_label_korean = dtGetUiLabel.Rows[0]["s_ui_label_korean"].ToString();
                uiLabel.s_ui_label_italian = dtGetUiLabel.Rows[0]["s_ui_label_italian"].ToString();
                uiLabel.s_ui_label_dutch = dtGetUiLabel.Rows[0]["s_ui_label_dutch"].ToString();
                uiLabel.s_ui_label_indonesian = dtGetUiLabel.Rows[0]["s_ui_label_indonesian"].ToString();
                uiLabel.s_ui_label_greek = dtGetUiLabel.Rows[0]["s_ui_label_greek"].ToString();
                uiLabel.s_ui_label_hungarian = dtGetUiLabel.Rows[0]["s_ui_label_hungarian"].ToString();
                uiLabel.s_ui_label_norwegian = dtGetUiLabel.Rows[0]["s_ui_label_norwegian"].ToString();
                uiLabel.s_ui_label_turkish = dtGetUiLabel.Rows[0]["s_ui_label_turkish"].ToString();
                uiLabel.s_ui_label_arabic_rtl = dtGetUiLabel.Rows[0]["s_ui_label_arabic_rtl"].ToString();
                uiLabel.s_ui_label_custom_01 = dtGetUiLabel.Rows[0]["s_ui_label_custom_01"].ToString();
                uiLabel.s_ui_label_custom_02 = dtGetUiLabel.Rows[0]["s_ui_label_custom_02"].ToString();
                uiLabel.s_ui_label_custom_03 = dtGetUiLabel.Rows[0]["s_ui_label_custom_03"].ToString();
                uiLabel.s_ui_label_custom_04 = dtGetUiLabel.Rows[0]["s_ui_label_custom_04"].ToString();
                uiLabel.s_ui_label_custom_05 = dtGetUiLabel.Rows[0]["s_ui_label_custom_05"].ToString();
                uiLabel.s_ui_label_custom_06 = dtGetUiLabel.Rows[0]["s_ui_label_custom_06"].ToString();
                uiLabel.s_ui_label_custom_07 = dtGetUiLabel.Rows[0]["s_ui_label_custom_07"].ToString();
                uiLabel.s_ui_label_custom_08 = dtGetUiLabel.Rows[0]["s_ui_label_custom_08"].ToString();
                uiLabel.s_ui_label_custom_09 = dtGetUiLabel.Rows[0]["s_ui_label_custom_09"].ToString();
                uiLabel.s_ui_label_custom_10 = dtGetUiLabel.Rows[0]["s_ui_label_custom_10"].ToString();
                uiLabel.s_ui_label_custom_11 = dtGetUiLabel.Rows[0]["s_ui_label_custom_11"].ToString();
                uiLabel.s_ui_label_custom_12 = dtGetUiLabel.Rows[0]["s_ui_label_custom_12"].ToString();
                uiLabel.s_ui_label_custom_13 = dtGetUiLabel.Rows[0]["s_ui_label_custom_13"].ToString();
                return uiLabel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get UI Drop Down
        /// </summary>
        /// <param name="s_ui_dropdown_id_pk"></param>
        /// <param name="dropdown_name"></param>
        /// <returns></returns>
        public static SystemUI_Texts_Labels_Dropdown GetUIDropdown(string s_ui_dropdown_id_pk, string dropdown_name)
        {

            try
            {
                Hashtable htUiDropdown = new Hashtable();
                if (!string.IsNullOrEmpty(s_ui_dropdown_id_pk))
                {
                    htUiDropdown.Add("@s_ui_dropdown_id_pk", s_ui_dropdown_id_pk);
                }
                else
                {
                    htUiDropdown.Add("@s_ui_dropdown_id_pk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(dropdown_name))
                {
                    htUiDropdown.Add("@dropdown_name", dropdown_name);
                }
                else
                {
                    htUiDropdown.Add("@dropdown_name", DBNull.Value);
                }
                SystemUI_Texts_Labels_Dropdown uiDropdown = new SystemUI_Texts_Labels_Dropdown();
                DataTable dtGetuiDropdown = DataProxy.FetchDataTable("s_sp_get_ui_dropdown", htUiDropdown);
                uiDropdown.s_ui_dropdown_name = dtGetuiDropdown.Rows[0]["s_ui_dropdown_name"].ToString();
                uiDropdown.s_ui_dropdown_page_name = dtGetuiDropdown.Rows[0]["s_ui_page_name"].ToString();
                uiDropdown.s_ui_dropdown_native = dtGetuiDropdown.Rows[0]["s_ui_dropdown_native"].ToString();
                uiDropdown.s_ui_dropdown_us_english = dtGetuiDropdown.Rows[0]["s_ui_dropdown_us_english"].ToString();
                uiDropdown.s_ui_dropdown_uk_english = dtGetuiDropdown.Rows[0]["s_ui_dropdown_uk_english"].ToString();
                uiDropdown.s_ui_dropdown_ca_french = dtGetuiDropdown.Rows[0]["s_ui_dropdown_ca_french"].ToString();
                uiDropdown.s_ui_dropdown_fr_french = dtGetuiDropdown.Rows[0]["s_ui_dropdown_fr_french"].ToString();
                uiDropdown.s_ui_dropdown_mx_spanish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_mx_spanish"].ToString();
                uiDropdown.s_ui_dropdown_sp_spanish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_sp_spanish"].ToString();
                uiDropdown.s_ui_dropdown_portuguese = dtGetuiDropdown.Rows[0]["s_ui_dropdown_portuguese"].ToString();
                uiDropdown.s_ui_dropdown_simp_chinese = dtGetuiDropdown.Rows[0]["s_ui_dropdown_simp_chinese"].ToString();
                uiDropdown.s_ui_dropdown_german = dtGetuiDropdown.Rows[0]["s_ui_dropdown_german"].ToString();
                uiDropdown.s_ui_dropdown_japanese = dtGetuiDropdown.Rows[0]["s_ui_dropdown_japanese"].ToString();
                uiDropdown.s_ui_dropdown_russian = dtGetuiDropdown.Rows[0]["s_ui_dropdown_russian"].ToString();
                uiDropdown.s_ui_dropdown_danish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_danish"].ToString();
                uiDropdown.s_ui_dropdown_polish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_polish"].ToString();
                uiDropdown.s_ui_dropdown_swedish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_swedish"].ToString();
                uiDropdown.s_ui_dropdown_finnish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_finnish"].ToString();
                uiDropdown.s_ui_dropdown_korean = dtGetuiDropdown.Rows[0]["s_ui_dropdown_korean"].ToString();
                uiDropdown.s_ui_dropdown_italian = dtGetuiDropdown.Rows[0]["s_ui_dropdown_italian"].ToString();
                uiDropdown.s_ui_dropdown_dutch = dtGetuiDropdown.Rows[0]["s_ui_dropdown_dutch"].ToString();
                uiDropdown.s_ui_dropdown_indonesian = dtGetuiDropdown.Rows[0]["s_ui_dropdown_indonesian"].ToString();
                uiDropdown.s_ui_dropdown_greek = dtGetuiDropdown.Rows[0]["s_ui_dropdown_greek"].ToString();
                uiDropdown.s_ui_dropdown_hungarian = dtGetuiDropdown.Rows[0]["s_ui_dropdown_hungarian"].ToString();
                uiDropdown.s_ui_dropdown_norwegian = dtGetuiDropdown.Rows[0]["s_ui_dropdown_norwegian"].ToString();
                uiDropdown.s_ui_dropdown_turkish = dtGetuiDropdown.Rows[0]["s_ui_dropdown_turkish"].ToString();
                uiDropdown.s_ui_dropdown_arabic_rtl = dtGetuiDropdown.Rows[0]["s_ui_dropdown_arabic_rtl"].ToString();
                uiDropdown.s_ui_dropdown_custom_01 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_01"].ToString();
                uiDropdown.s_ui_dropdown_custom_02 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_02"].ToString();
                uiDropdown.s_ui_dropdown_custom_03 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_03"].ToString();
                uiDropdown.s_ui_dropdown_custom_04 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_04"].ToString();
                uiDropdown.s_ui_dropdown_custom_05 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_05"].ToString();
                uiDropdown.s_ui_dropdown_custom_06 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_06"].ToString();
                uiDropdown.s_ui_dropdown_custom_07 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_07"].ToString();
                uiDropdown.s_ui_dropdown_custom_08 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_08"].ToString();
                uiDropdown.s_ui_dropdown_custom_09 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_09"].ToString();
                uiDropdown.s_ui_dropdown_custom_10 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_10"].ToString();
                uiDropdown.s_ui_dropdown_custom_11 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_11"].ToString();
                uiDropdown.s_ui_dropdown_custom_12 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_12"].ToString();
                uiDropdown.s_ui_dropdown_custom_13 = dtGetuiDropdown.Rows[0]["s_ui_dropdown_custom_13"].ToString();
                return uiDropdown;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update ui label
        /// </summary>
        /// <param name="ui_text_label_dropdown"></param>
        /// <returns></returns>
        public static int UpdateUILabel(SystemUI_Texts_Labels_Dropdown ui_text_label_dropdown)
        {
            Hashtable htUpdateUiLabel = new Hashtable();
            if (!string.IsNullOrEmpty(ui_text_label_dropdown.s_ui_label_id_pk))
            {
                htUpdateUiLabel.Add("@s_ui_label_id_pk", ui_text_label_dropdown.s_ui_label_id_pk);
            }
            else
            {
                htUpdateUiLabel.Add("@s_ui_label_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ui_text_label_dropdown.s_ui_label_name))
            {
                htUpdateUiLabel.Add("@s_ui_label_name", ui_text_label_dropdown.s_ui_label_name);
            }
            else
            {
                htUpdateUiLabel.Add("@s_ui_label_name", DBNull.Value);
            }
            htUpdateUiLabel.Add("@s_ui_label_us_english", ui_text_label_dropdown.s_ui_label_us_english);
            htUpdateUiLabel.Add("@s_ui_label_uk_english", ui_text_label_dropdown.s_ui_label_uk_english);
            htUpdateUiLabel.Add("@s_ui_label_ca_french", ui_text_label_dropdown.s_ui_label_ca_french);
            htUpdateUiLabel.Add("@s_ui_label_fr_french", ui_text_label_dropdown.s_ui_label_fr_french);
            htUpdateUiLabel.Add("@s_ui_label_mx_spanish", ui_text_label_dropdown.s_ui_label_mx_spanish);
            htUpdateUiLabel.Add("@s_ui_label_sp_spanish", ui_text_label_dropdown.s_ui_label_sp_spanish);
            htUpdateUiLabel.Add("@s_ui_label_portuguese", ui_text_label_dropdown.s_ui_label_portuguese);
            htUpdateUiLabel.Add("@s_ui_label_simp_chinese", ui_text_label_dropdown.s_ui_label_simp_chinese);
            htUpdateUiLabel.Add("@s_ui_label_german", ui_text_label_dropdown.s_ui_label_german);
            htUpdateUiLabel.Add("@s_ui_label_japanese", ui_text_label_dropdown.s_ui_label_japanese);
            htUpdateUiLabel.Add("@s_ui_label_russian", ui_text_label_dropdown.s_ui_label_russian);
            htUpdateUiLabel.Add("@s_ui_label_danish", ui_text_label_dropdown.s_ui_label_danish);
            htUpdateUiLabel.Add("@s_ui_label_polish", ui_text_label_dropdown.s_ui_label_polish);
            htUpdateUiLabel.Add("@s_ui_label_swedish", ui_text_label_dropdown.s_ui_label_swedish);
            htUpdateUiLabel.Add("@s_ui_label_finnish", ui_text_label_dropdown.s_ui_label_finnish);
            htUpdateUiLabel.Add("@s_ui_label_korean", ui_text_label_dropdown.s_ui_label_korean);
            htUpdateUiLabel.Add("@s_ui_label_italian", ui_text_label_dropdown.s_ui_label_italian);
            htUpdateUiLabel.Add("@s_ui_label_dutch", ui_text_label_dropdown.s_ui_label_dutch);
            htUpdateUiLabel.Add("@s_ui_label_indonesian", ui_text_label_dropdown.s_ui_label_indonesian);
            htUpdateUiLabel.Add("@s_ui_label_greek", ui_text_label_dropdown.s_ui_label_greek);
            htUpdateUiLabel.Add("@s_ui_label_hungarian", ui_text_label_dropdown.s_ui_label_hungarian);
            htUpdateUiLabel.Add("@s_ui_label_norwegian", ui_text_label_dropdown.s_ui_label_norwegian);
            htUpdateUiLabel.Add("@s_ui_label_turkish", ui_text_label_dropdown.s_ui_label_turkish);
            htUpdateUiLabel.Add("@s_ui_label_arabic_rtl", ui_text_label_dropdown.s_ui_label_arabic_rtl);
            htUpdateUiLabel.Add("@s_ui_label_custom_01", ui_text_label_dropdown.s_ui_label_custom_01);
            htUpdateUiLabel.Add("@s_ui_label_custom_02", ui_text_label_dropdown.s_ui_label_custom_02);
            htUpdateUiLabel.Add("@s_ui_label_custom_03", ui_text_label_dropdown.s_ui_label_custom_03);
            htUpdateUiLabel.Add("@s_ui_label_custom_04", ui_text_label_dropdown.s_ui_label_custom_04);
            htUpdateUiLabel.Add("@s_ui_label_custom_05", ui_text_label_dropdown.s_ui_label_custom_05);
            htUpdateUiLabel.Add("@s_ui_label_custom_06", ui_text_label_dropdown.s_ui_label_custom_06);
            htUpdateUiLabel.Add("@s_ui_label_custom_07", ui_text_label_dropdown.s_ui_label_custom_07);
            htUpdateUiLabel.Add("@s_ui_label_custom_08", ui_text_label_dropdown.s_ui_label_custom_08);
            htUpdateUiLabel.Add("@s_ui_label_custom_09", ui_text_label_dropdown.s_ui_label_custom_09);
            htUpdateUiLabel.Add("@s_ui_label_custom_10", ui_text_label_dropdown.s_ui_label_custom_10);
            htUpdateUiLabel.Add("@s_ui_label_custom_11", ui_text_label_dropdown.s_ui_label_custom_11);
            htUpdateUiLabel.Add("@s_ui_label_custom_12", ui_text_label_dropdown.s_ui_label_custom_12);
            htUpdateUiLabel.Add("@s_ui_label_custom_13", ui_text_label_dropdown.s_ui_label_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_ui_label", htUpdateUiLabel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Dropdown
        /// </summary>
        /// <param name="ui_text_label_dropdown"></param>
        /// <returns></returns>
        public static int UpdateUIDropdown(SystemUI_Texts_Labels_Dropdown ui_text_label_dropdown)
        {
            Hashtable htUpdateUiDropdown = new Hashtable();
            if (!string.IsNullOrEmpty(ui_text_label_dropdown.s_ui_dropdown_id_pk))
            {
                htUpdateUiDropdown.Add("@s_ui_dropdown_id_pk", ui_text_label_dropdown.s_ui_dropdown_id_pk);
            }
            else
            {
                htUpdateUiDropdown.Add("@s_ui_dropdown_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ui_text_label_dropdown.s_ui_dropdown_name))
            {
                htUpdateUiDropdown.Add("@s_ui_dropdown_name", ui_text_label_dropdown.s_ui_dropdown_name);
            }
            else
            {
                htUpdateUiDropdown.Add("@s_ui_dropdown_name", DBNull.Value);
            }
            htUpdateUiDropdown.Add("@s_ui_dropdown_us_english", ui_text_label_dropdown.s_ui_dropdown_us_english);
            htUpdateUiDropdown.Add("@s_ui_dropdown_uk_english", ui_text_label_dropdown.s_ui_dropdown_uk_english);
            htUpdateUiDropdown.Add("@s_ui_dropdown_ca_french", ui_text_label_dropdown.s_ui_dropdown_ca_french);
            htUpdateUiDropdown.Add("@s_ui_dropdown_fr_french", ui_text_label_dropdown.s_ui_dropdown_fr_french);
            htUpdateUiDropdown.Add("@s_ui_dropdown_mx_spanish", ui_text_label_dropdown.s_ui_dropdown_mx_spanish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_sp_spanish", ui_text_label_dropdown.s_ui_dropdown_sp_spanish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_portuguese", ui_text_label_dropdown.s_ui_dropdown_portuguese);
            htUpdateUiDropdown.Add("@s_ui_dropdown_simp_chinese", ui_text_label_dropdown.s_ui_dropdown_simp_chinese);
            htUpdateUiDropdown.Add("@s_ui_dropdown_german", ui_text_label_dropdown.s_ui_dropdown_german);
            htUpdateUiDropdown.Add("@s_ui_dropdown_japanese", ui_text_label_dropdown.s_ui_dropdown_japanese);
            htUpdateUiDropdown.Add("@s_ui_dropdown_russian", ui_text_label_dropdown.s_ui_dropdown_russian);
            htUpdateUiDropdown.Add("@s_ui_dropdown_danish", ui_text_label_dropdown.s_ui_dropdown_danish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_polish", ui_text_label_dropdown.s_ui_dropdown_polish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_swedish", ui_text_label_dropdown.s_ui_dropdown_swedish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_finnish", ui_text_label_dropdown.s_ui_dropdown_finnish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_korean", ui_text_label_dropdown.s_ui_dropdown_korean);
            htUpdateUiDropdown.Add("@s_ui_dropdown_italian", ui_text_label_dropdown.s_ui_dropdown_italian);
            htUpdateUiDropdown.Add("@s_ui_dropdown_dutch", ui_text_label_dropdown.s_ui_dropdown_dutch);
            htUpdateUiDropdown.Add("@s_ui_dropdown_indonesian", ui_text_label_dropdown.s_ui_dropdown_indonesian);
            htUpdateUiDropdown.Add("@s_ui_dropdown_greek", ui_text_label_dropdown.s_ui_dropdown_greek);
            htUpdateUiDropdown.Add("@s_ui_dropdown_hungarian", ui_text_label_dropdown.s_ui_dropdown_hungarian);
            htUpdateUiDropdown.Add("@s_ui_dropdown_norwegian", ui_text_label_dropdown.s_ui_dropdown_norwegian);
            htUpdateUiDropdown.Add("@s_ui_dropdown_turkish", ui_text_label_dropdown.s_ui_dropdown_turkish);
            htUpdateUiDropdown.Add("@s_ui_dropdown_arabic_rtl", ui_text_label_dropdown.s_ui_dropdown_arabic_rtl);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_01", ui_text_label_dropdown.s_ui_dropdown_custom_01);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_02", ui_text_label_dropdown.s_ui_dropdown_custom_02);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_03", ui_text_label_dropdown.s_ui_dropdown_custom_03);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_04", ui_text_label_dropdown.s_ui_dropdown_custom_04);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_05", ui_text_label_dropdown.s_ui_dropdown_custom_05);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_06", ui_text_label_dropdown.s_ui_dropdown_custom_06);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_07", ui_text_label_dropdown.s_ui_dropdown_custom_07);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_08", ui_text_label_dropdown.s_ui_dropdown_custom_08);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_09", ui_text_label_dropdown.s_ui_dropdown_custom_09);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_10", ui_text_label_dropdown.s_ui_dropdown_custom_10);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_11", ui_text_label_dropdown.s_ui_dropdown_custom_11);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_12", ui_text_label_dropdown.s_ui_dropdown_custom_12);
            htUpdateUiDropdown.Add("@s_ui_dropdown_custom_13", ui_text_label_dropdown.s_ui_dropdown_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_ui_dropdown", htUpdateUiDropdown);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get ui text locale
        /// </summary>
        /// <param name="s_ui_text_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetUiTextLocale(string s_ui_text_id_pk, string s_app_name)
        {
            try
            {
                Hashtable htUiText = new Hashtable();
                if (!string.IsNullOrEmpty(s_ui_text_id_pk))
                {
                    htUiText.Add("@s_ui_text_id_pk", s_ui_text_id_pk);
                }
                else
                {
                    htUiText.Add("@s_ui_text_id_pk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_app_name))
                {
                    htUiText.Add("@s_app_name", s_app_name);
                }
                else
                {
                    htUiText.Add("@s_app_name", DBNull.Value);
                }
                return DataProxy.FetchDataTable("s_sp_get_ui_text_locale", htUiText);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemUI_Texts_Labels_Dropdown GetUIText(string s_ui_text_id_pk, string s_app_name)
        {

            try
            {
                Hashtable htUitext = new Hashtable();
                if (!string.IsNullOrEmpty(s_ui_text_id_pk))
                {
                    htUitext.Add("@s_ui_text_id_pk", s_ui_text_id_pk);
                }
                else
                {
                    htUitext.Add("@s_ui_text_id_pk", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(s_app_name))
                {
                    htUitext.Add("@s_app_name", s_app_name);
                }
                else
                {
                    htUitext.Add("@s_app_name", DBNull.Value);
                }
                SystemUI_Texts_Labels_Dropdown uitext = new SystemUI_Texts_Labels_Dropdown();
                DataTable dtGetUitext = DataProxy.FetchDataTable("s_sp_get_ui_texts", htUitext);
                uitext.s_ui_text_name = dtGetUitext.Rows[0]["s_ui_text_name"].ToString();
                uitext.s_ui_page_name = dtGetUitext.Rows[0]["s_ui_page_name"].ToString();
                uitext.s_ui_text_native = dtGetUitext.Rows[0]["s_ui_text_native"].ToString();
                uitext.s_ui_text_us_english = dtGetUitext.Rows[0]["s_ui_text_us_english"].ToString();
                uitext.s_ui_text_uk_english = dtGetUitext.Rows[0]["s_ui_text_uk_english"].ToString();
                uitext.s_ui_text_ca_french = dtGetUitext.Rows[0]["s_ui_text_ca_french"].ToString();
                uitext.s_ui_text_fr_french = dtGetUitext.Rows[0]["s_ui_text_fr_french"].ToString();
                uitext.s_ui_text_mx_spanish = dtGetUitext.Rows[0]["s_ui_text_mx_spanish"].ToString();
                uitext.s_ui_text_sp_spanish = dtGetUitext.Rows[0]["s_ui_text_sp_spanish"].ToString();
                uitext.s_ui_text_portuguese = dtGetUitext.Rows[0]["s_ui_text_portuguese"].ToString();
                uitext.s_ui_text_simp_chinese = dtGetUitext.Rows[0]["s_ui_text_simp_chinese"].ToString();
                uitext.s_ui_text_german = dtGetUitext.Rows[0]["s_ui_text_german"].ToString();
                uitext.s_ui_text_japanese = dtGetUitext.Rows[0]["s_ui_text_japanese"].ToString();
                uitext.s_ui_text_russian = dtGetUitext.Rows[0]["s_ui_text_russian"].ToString();
                uitext.s_ui_text_danish = dtGetUitext.Rows[0]["s_ui_text_danish"].ToString();
                uitext.s_ui_text_polish = dtGetUitext.Rows[0]["s_ui_text_polish"].ToString();
                uitext.s_ui_text_swedish = dtGetUitext.Rows[0]["s_ui_text_swedish"].ToString();
                uitext.s_ui_text_finnish = dtGetUitext.Rows[0]["s_ui_text_finnish"].ToString();
                uitext.s_ui_text_korean = dtGetUitext.Rows[0]["s_ui_text_korean"].ToString();
                uitext.s_ui_text_italian = dtGetUitext.Rows[0]["s_ui_text_italian"].ToString();
                uitext.s_ui_text_dutch = dtGetUitext.Rows[0]["s_ui_text_dutch"].ToString();
                uitext.s_ui_text_indonesian = dtGetUitext.Rows[0]["s_ui_text_indonesian"].ToString();
                uitext.s_ui_text_greek = dtGetUitext.Rows[0]["s_ui_text_greek"].ToString();
                uitext.s_ui_text_hungarian = dtGetUitext.Rows[0]["s_ui_text_hungarian"].ToString();
                uitext.s_ui_text_norwegian = dtGetUitext.Rows[0]["s_ui_text_norwegian"].ToString();
                uitext.s_ui_text_turkish = dtGetUitext.Rows[0]["s_ui_text_turkish"].ToString();
                uitext.s_ui_text_arabic_rtl = dtGetUitext.Rows[0]["s_ui_text_arabic_rtl"].ToString();
                uitext.s_ui_text_custom_01 = dtGetUitext.Rows[0]["s_ui_text_custom_01"].ToString();
                uitext.s_ui_text_custom_02 = dtGetUitext.Rows[0]["s_ui_text_custom_02"].ToString();
                uitext.s_ui_text_custom_03 = dtGetUitext.Rows[0]["s_ui_text_custom_03"].ToString();
                uitext.s_ui_text_custom_04 = dtGetUitext.Rows[0]["s_ui_text_custom_04"].ToString();
                uitext.s_ui_text_custom_05 = dtGetUitext.Rows[0]["s_ui_text_custom_05"].ToString();
                uitext.s_ui_text_custom_06 = dtGetUitext.Rows[0]["s_ui_text_custom_06"].ToString();
                uitext.s_ui_text_custom_07 = dtGetUitext.Rows[0]["s_ui_text_custom_07"].ToString();
                uitext.s_ui_text_custom_08 = dtGetUitext.Rows[0]["s_ui_text_custom_08"].ToString();
                uitext.s_ui_text_custom_09 = dtGetUitext.Rows[0]["s_ui_text_custom_09"].ToString();
                uitext.s_ui_text_custom_10 = dtGetUitext.Rows[0]["s_ui_text_custom_10"].ToString();
                uitext.s_ui_text_custom_11 = dtGetUitext.Rows[0]["s_ui_text_custom_11"].ToString();
                uitext.s_ui_text_custom_12 = dtGetUitext.Rows[0]["s_ui_text_custom_12"].ToString();
                uitext.s_ui_text_custom_13 = dtGetUitext.Rows[0]["s_ui_text_custom_13"].ToString();
                return uitext;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update ui text default locale (us_english)
        /// </summary>
        /// <param name="s_ui_text_id_pk"></param>
        /// <param name="s_ui_text_us_english"></param>
        /// <returns></returns>
        public static int UpdateUiTextDefault(string s_ui_text_id_pk, string s_ui_text_us_english, string s_app_name)
        {
            Hashtable htUpdateUiText = new Hashtable();
            if (!string.IsNullOrEmpty(s_ui_text_id_pk))
            {
                htUpdateUiText.Add("@s_ui_text_id_pk", s_ui_text_id_pk);
            }
            else
            {
                htUpdateUiText.Add("@s_ui_text_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_app_name))
            {
                htUpdateUiText.Add("@s_app_name", s_app_name);
            }
            else
            {
                htUpdateUiText.Add("@s_app_name", DBNull.Value);
            }
            htUpdateUiText.Add("@s_ui_text_us_english", s_ui_text_us_english);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_text_default_locale", htUpdateUiText);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateUiText(string s_ui_text_id_pk, string s_locale_name, string s_ui_text, string s_app_name)
        {
            Hashtable htUpdateUiText = new Hashtable();
            if (!string.IsNullOrEmpty(s_ui_text_id_pk))
            {
                htUpdateUiText.Add("@s_ui_text_id_pk", s_ui_text_id_pk);
            }
            else
            {
                htUpdateUiText.Add("@s_ui_text_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_app_name))
            {
                htUpdateUiText.Add("@s_app_name", s_app_name);
            }
            else
            {
                htUpdateUiText.Add("@s_app_name", DBNull.Value);
            }
            htUpdateUiText.Add("@s_locale_name", s_locale_name);
            htUpdateUiText.Add("@s_ui_text", s_ui_text);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_ui_text", htUpdateUiText);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteUiText(string s_ui_text_id_pk, string s_locale_name)
        {
            Hashtable htUpdateUiText = new Hashtable();
            htUpdateUiText.Add("@s_ui_text_id_pk", s_ui_text_id_pk);
            htUpdateUiText.Add("@s_locale_name", s_locale_name);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_ui_text", htUpdateUiText);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSingleUIText(string s_ui_text_id_pk, string s_locale_name, string s_app_name)
        {
            Hashtable htGetUiText = new Hashtable();
            if (!string.IsNullOrEmpty(s_ui_text_id_pk))
            {
                htGetUiText.Add("@s_ui_text_id_pk", s_ui_text_id_pk);
            }
            else
            {
                htGetUiText.Add("@s_ui_text_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_app_name))
            {
                htGetUiText.Add("@s_app_name", s_app_name);
            }
            else
            {
                htGetUiText.Add("@s_app_name", DBNull.Value);
            }
            htGetUiText.Add("@s_locale_name", s_locale_name);

            try
            {
                return DataProxy.FetchDataTable("s_sp_get_single_ui_text", htGetUiText);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
