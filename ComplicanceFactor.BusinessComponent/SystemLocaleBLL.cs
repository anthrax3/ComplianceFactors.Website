using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemLocaleBLL
    {
        /// <summary>
        /// get locale list
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLocaleList()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_locale");
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get locale list except english
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLocaleListExceptEnglish()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_locale_except_english");
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get all language from s_tb_locale tabel
        /// </summary>
        /// <returns></returns>
        public static SystemLocale GetAllLocale()
        {
            try
            {
                SystemLocale locale = new SystemLocale();
                DataTable dtGetlocale = DataProxy.FetchDataTable("s_sp_get_all_locale");
                locale.s_locale_us_english = dtGetlocale.Rows[0]["s_locale_description"].ToString();
                locale.s_locale_uk_english = dtGetlocale.Rows[1]["s_locale_description"].ToString();
                locale.s_locale_ca_french = dtGetlocale.Rows[2]["s_locale_description"].ToString();
                locale.s_locale_fr_french = dtGetlocale.Rows[3]["s_locale_description"].ToString();
                locale.s_locale_mx_spanish = dtGetlocale.Rows[4]["s_locale_description"].ToString();
                locale.s_locale_sp_spanish = dtGetlocale.Rows[5]["s_locale_description"].ToString();
                locale.s_locale_portuguese = dtGetlocale.Rows[6]["s_locale_description"].ToString();
                locale.s_locale_simp_chinese = dtGetlocale.Rows[7]["s_locale_description"].ToString();
                locale.s_locale_german = dtGetlocale.Rows[8]["s_locale_description"].ToString();
                locale.s_locale_japanese = dtGetlocale.Rows[9]["s_locale_description"].ToString();
                locale.s_locale_russian = dtGetlocale.Rows[10]["s_locale_description"].ToString();
                locale.s_locale_danish = dtGetlocale.Rows[11]["s_locale_description"].ToString();
                locale.s_locale_polish = dtGetlocale.Rows[12]["s_locale_description"].ToString();
                locale.s_locale_swedish = dtGetlocale.Rows[13]["s_locale_description"].ToString();
                locale.s_locale_finnish = dtGetlocale.Rows[14]["s_locale_description"].ToString();
                locale.s_locale_korean = dtGetlocale.Rows[15]["s_locale_description"].ToString();
                locale.s_locale_italian = dtGetlocale.Rows[16]["s_locale_description"].ToString();
                locale.s_locale_dutch = dtGetlocale.Rows[17]["s_locale_description"].ToString();
                locale.s_locale_indonesian = dtGetlocale.Rows[18]["s_locale_description"].ToString();
                locale.s_locale_greek = dtGetlocale.Rows[19]["s_locale_description"].ToString();
                locale.s_locale_hungarian = dtGetlocale.Rows[20]["s_locale_description"].ToString();
                locale.s_locale_norwegian = dtGetlocale.Rows[21]["s_locale_description"].ToString();
                locale.s_locale_turkish = dtGetlocale.Rows[22]["s_locale_description"].ToString();
                locale.s_locale_arabic_rtl = dtGetlocale.Rows[23]["s_locale_description"].ToString();
                locale.s_locale_custom_01 = dtGetlocale.Rows[24]["s_locale_description"].ToString();
                locale.s_locale_custom_02 = dtGetlocale.Rows[25]["s_locale_description"].ToString();
                locale.s_locale_custom_03 = dtGetlocale.Rows[26]["s_locale_description"].ToString();
                locale.s_locale_custom_04 = dtGetlocale.Rows[27]["s_locale_description"].ToString();
                locale.s_locale_custom_05 = dtGetlocale.Rows[28]["s_locale_description"].ToString();
                locale.s_locale_custom_06 = dtGetlocale.Rows[29]["s_locale_description"].ToString();
                locale.s_locale_custom_07 = dtGetlocale.Rows[30]["s_locale_description"].ToString();
                locale.s_locale_custom_08 = dtGetlocale.Rows[31]["s_locale_description"].ToString();
                locale.s_locale_custom_09 = dtGetlocale.Rows[32]["s_locale_description"].ToString();
                locale.s_locale_custom_10 = dtGetlocale.Rows[33]["s_locale_description"].ToString();
                locale.s_locale_custom_11 = dtGetlocale.Rows[34]["s_locale_description"].ToString();
                locale.s_locale_custom_12 = dtGetlocale.Rows[35]["s_locale_description"].ToString();
                locale.s_locale_custom_13 = dtGetlocale.Rows[36]["s_locale_description"].ToString();
                //visible
                locale.s_locale_visible_us_english = Convert.ToBoolean(dtGetlocale.Rows[0]["s_locale_active_flag"]);
                locale.s_locale_visible_uk_english= Convert.ToBoolean( dtGetlocale.Rows[1]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_ca_french= Convert.ToBoolean( dtGetlocale.Rows[2]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_fr_french= Convert.ToBoolean( dtGetlocale.Rows[3]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_mx_spanish= Convert.ToBoolean( dtGetlocale.Rows[4]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_sp_spanish= Convert.ToBoolean( dtGetlocale.Rows[5]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_portuguese =Convert.ToBoolean( dtGetlocale.Rows[6]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_simp_chinese =Convert.ToBoolean( dtGetlocale.Rows[7]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_german =Convert.ToBoolean( dtGetlocale.Rows[8]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_japanese =Convert.ToBoolean( dtGetlocale.Rows[9]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_russian= Convert.ToBoolean( dtGetlocale.Rows[10]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_danish =Convert.ToBoolean( dtGetlocale.Rows[11]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_polish =Convert.ToBoolean( dtGetlocale.Rows[12]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_swedish =Convert.ToBoolean( dtGetlocale.Rows[13]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_finnish =Convert.ToBoolean( dtGetlocale.Rows[14]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_korean= Convert.ToBoolean( dtGetlocale.Rows[15]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_italian =Convert.ToBoolean( dtGetlocale.Rows[16]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_dutch =Convert.ToBoolean( dtGetlocale.Rows[17]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_indonesian =Convert.ToBoolean( dtGetlocale.Rows[18]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_greek= Convert.ToBoolean( dtGetlocale.Rows[19]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_hungarian= Convert.ToBoolean( dtGetlocale.Rows[20]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_norwegian= Convert.ToBoolean( dtGetlocale.Rows[21]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_turkish =Convert.ToBoolean( dtGetlocale.Rows[22]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_arabic_rtl= Convert.ToBoolean( dtGetlocale.Rows[23]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_01 =Convert.ToBoolean( dtGetlocale.Rows[24]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_02= Convert.ToBoolean( dtGetlocale.Rows[25]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_03 =Convert.ToBoolean( dtGetlocale.Rows[26]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_04 =Convert.ToBoolean( dtGetlocale.Rows[27]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_05 =Convert.ToBoolean( dtGetlocale.Rows[28]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_06 =Convert.ToBoolean( dtGetlocale.Rows[29]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_07 =Convert.ToBoolean( dtGetlocale.Rows[30]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_08= Convert.ToBoolean( dtGetlocale.Rows[31]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_09 =Convert.ToBoolean( dtGetlocale.Rows[32]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_10 =Convert.ToBoolean( dtGetlocale.Rows[33]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_11 =Convert.ToBoolean( dtGetlocale.Rows[34]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_12 =Convert.ToBoolean( dtGetlocale.Rows[35]["s_locale_active_flag"].ToString());
                locale.s_locale_visible_custom_13 =Convert.ToBoolean( dtGetlocale.Rows[36]["s_locale_active_flag"].ToString());
                return locale;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        /// <summary>
        /// update locale visibility
        /// </summary>
        /// <param name="s_locale_short_name"></param>
        /// <param name="s_locale_active_flag"></param>
        /// <returns></returns>
        public static int UpdateLocaleVisibility(string s_locale_short_name, bool s_locale_active_flag, string s_locale_description)
        {
            Hashtable htLocaleVisibility = new Hashtable();
            htLocaleVisibility.Add("@s_locale_short_name", s_locale_short_name);
            htLocaleVisibility.Add("@s_locale_active_flag", s_locale_active_flag);
            htLocaleVisibility.Add("@s_locale_description", s_locale_description);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_locale_visibility",htLocaleVisibility);
            }

            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Get all label,text and dropdown
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllLabelTextDropdown()
        {
            try
            {
                return DataProxy.FetchDataSet("s_sp_get_all_label_text_dropdown");
            }

            catch (Exception)
            {
                throw;
            }
        }
       
        public static int Import_UI_Label_Text_Dropdown(string label,string text,string dropdown)
        {
            Hashtable htLable = new Hashtable();
            if (!string.IsNullOrEmpty(label))
            {
                htLable.Add("@s_label", label);
            }
            else
            {
                htLable.Add("@s_label",DBNull.Value);
            }
            if (!string.IsNullOrEmpty(text))
            {
                htLable.Add("@s_text", text);
            }
            else
            {
                htLable.Add("@s_text", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dropdown))
            {
                htLable.Add("@s_dropdown", dropdown);
            }
            else
            {
                htLable.Add("@s_dropdown", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_ui_label_text_dropdown", htLable);
            }
            catch (Exception)
            {
                throw;
            }

        }
       
    }
}
