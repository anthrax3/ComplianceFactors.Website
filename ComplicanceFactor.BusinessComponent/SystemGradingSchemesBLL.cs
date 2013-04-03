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
    public class SystemGradingSchemesBLL
    {


        /// <summary>
        /// Get Grading scheme type
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetGradingSchemeType(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGradingSchemeType = new Hashtable();
                htGradingSchemeType.Add("@s_ui_locale_name", s_ui_locale_name);
                htGradingSchemeType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_grading_scheme_type", htGradingSchemeType);
            }

            catch (Exception)
            {
                throw;
            }


        }


        /// <summary>
        /// Get status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmStatus = new Hashtable();
                htGetHarmStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetHarmStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }




        public static int CreateGradingSchemes(SystemGradingSchemes createGradingSchemes)
        {
            Hashtable htCreateGradingSchemes = new Hashtable();
            htCreateGradingSchemes.Add("@s_grading_scheme_system_id_pk",createGradingSchemes.s_grading_scheme_system_id_pk);
            htCreateGradingSchemes.Add("@s_grading_scheme_id", createGradingSchemes.s_grading_scheme_id);
            if (createGradingSchemes.s_grading_scheme_status_id_fk == "0")
            {
                htCreateGradingSchemes.Add("@s_grading_scheme_status_id_fk", DBNull.Value);
            }
            else 
            {
                htCreateGradingSchemes.Add("@s_grading_scheme_status_id_fk", createGradingSchemes.s_grading_scheme_status_id_fk);
            }
            if (createGradingSchemes.s_grading_scheme_type_id_fk == "0")
            {
                htCreateGradingSchemes.Add("@s_grading_scheme_type_id_fk", DBNull.Value);
            }
            else
            {
                htCreateGradingSchemes.Add("@s_grading_scheme_type_id_fk", createGradingSchemes.s_grading_scheme_type_id_fk);
            }
             htCreateGradingSchemes.Add("@s_grading_scheme_english_us_name",createGradingSchemes.s_grading_scheme_english_us_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_english_us_description",createGradingSchemes.s_grading_scheme_english_us_description);
             htCreateGradingSchemes.Add("s_grading_scheme_english_uk_name",createGradingSchemes.s_grading_scheme_english_uk_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_english_uk_description",createGradingSchemes.s_grading_scheme_english_uk_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_france_ca_name",createGradingSchemes.s_grading_scheme_france_ca_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_france_ca_description",createGradingSchemes.s_grading_scheme_france_ca_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_french_fr_name",createGradingSchemes.s_grading_scheme_french_fr_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_french_fr_description",createGradingSchemes.s_grading_scheme_french_fr_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_spanish_mx_name",createGradingSchemes.s_grading_scheme_spanish_mx_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_spanish_mx_description",createGradingSchemes.s_grading_scheme_spanish_mx_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_sapnish_sp_name",createGradingSchemes.s_grading_scheme_sapnish_sp_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_spanish_sp_description",createGradingSchemes.s_grading_scheme_spanish_sp_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_portuguse_name",createGradingSchemes.s_grading_scheme_portuguse_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_portuguse_description",createGradingSchemes.s_grading_scheme_portuguse_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_chinese_name",createGradingSchemes.s_grading_scheme_chinese_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_chinese_description",createGradingSchemes.s_grading_scheme_chinese_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_german_name",createGradingSchemes.s_grading_scheme_german_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_german_description",createGradingSchemes.s_grading_scheme_german_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_japanese_name",createGradingSchemes.s_grading_scheme_japanese_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_japanese_description",createGradingSchemes.s_grading_scheme_japanese_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_russian_name",createGradingSchemes.s_grading_scheme_russian_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_russian_description",createGradingSchemes.s_grading_scheme_russian_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_danish_name",createGradingSchemes.s_grading_scheme_danish_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_danish_description",createGradingSchemes.s_grading_scheme_danish_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_polish_name",createGradingSchemes.s_grading_scheme_polish_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_polish_description",createGradingSchemes.s_grading_scheme_polish_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_swedish_name",createGradingSchemes.s_grading_scheme_swedish_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_swedish_description",createGradingSchemes.s_grading_scheme_swedish_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_finnish_name",createGradingSchemes.s_grading_scheme_finnish_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_finnish_description",createGradingSchemes.s_grading_scheme_finnish_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_korean_name",createGradingSchemes.s_grading_scheme_korean_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_korean_description",createGradingSchemes.s_grading_scheme_korean_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_italian_name",createGradingSchemes.s_grading_scheme_italian_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_italian_description",createGradingSchemes.s_grading_scheme_italian_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_dutch_name",createGradingSchemes.s_grading_scheme_dutch_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_dutch_description",createGradingSchemes.s_grading_scheme_dutch_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_indonesian_name",createGradingSchemes.s_grading_scheme_indonesian_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_indonesian_description",createGradingSchemes.s_grading_scheme_indonesian_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_greek_name",createGradingSchemes.s_grading_scheme_greek_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_greek_description",createGradingSchemes.s_grading_scheme_greek_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_hungarian_name",createGradingSchemes.s_grading_scheme_hungarian_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_hungarian_description",createGradingSchemes.s_grading_scheme_hungarian_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_norwegian_name",createGradingSchemes.s_grading_scheme_norwegian_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_norwegian_description",createGradingSchemes.s_grading_scheme_norwegian_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_turkish_name",createGradingSchemes.s_grading_scheme_turkish_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_turkish_description",createGradingSchemes.s_grading_scheme_turkish_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_arabic_name",createGradingSchemes.s_grading_scheme_arabic_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_arabic_description",createGradingSchemes.s_grading_scheme_arabic_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom01_name",createGradingSchemes.s_grading_scheme_custom01_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom01_description",createGradingSchemes.s_grading_scheme_custom01_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom02_name",createGradingSchemes.s_grading_scheme_custom02_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom02_description",createGradingSchemes.s_grading_scheme_custom02_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom03_name",createGradingSchemes.s_grading_scheme_custom03_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom03_description",createGradingSchemes.s_grading_scheme_custom03_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom04_name",createGradingSchemes.s_grading_scheme_custom04_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom04_description",createGradingSchemes.s_grading_scheme_custom04_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom05_name",createGradingSchemes.s_grading_scheme_custom05_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom05_description",createGradingSchemes.s_grading_scheme_custom05_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom06_name",createGradingSchemes.s_grading_scheme_custom06_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom06_description",createGradingSchemes.s_grading_scheme_custom06_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom07_name",createGradingSchemes.s_grading_scheme_custom07_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom07_description",createGradingSchemes.s_grading_scheme_custom07_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom08_name",createGradingSchemes.s_grading_scheme_custom08_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom08_description",createGradingSchemes.s_grading_scheme_custom08_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom09_name",createGradingSchemes.s_grading_scheme_custom09_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom09_description",createGradingSchemes.s_grading_scheme_custom09_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom10_name",createGradingSchemes.s_grading_scheme_custom10_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom10_description",createGradingSchemes.s_grading_scheme_custom10_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom11_name",createGradingSchemes.s_grading_scheme_custom11_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom11_description",createGradingSchemes.s_grading_scheme_custom11_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom12_name",createGradingSchemes.s_grading_scheme_custom12_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom12_description",createGradingSchemes.s_grading_scheme_custom12_description);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom13_name",createGradingSchemes.s_grading_scheme_custom13_name);
             htCreateGradingSchemes.Add("@s_grading_scheme_custom13_description",createGradingSchemes.s_grading_scheme_custom13_description);
            
            try
            {
                return DataProxy.FetchSPOutput("***PROCEDURE NAME***",htCreateGradingSchemes);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
