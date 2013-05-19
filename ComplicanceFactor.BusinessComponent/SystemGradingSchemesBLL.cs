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
        /// Get All Grading scheme type
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetAllGradingSchemeType(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGradingSchemeType = new Hashtable();
                htGradingSchemeType.Add("@s_ui_locale_name", s_ui_locale_name);
                htGradingSchemeType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_grading_scheme_type", htGradingSchemeType);
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
        /// <summary>
        /// Get all status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmStatus = new Hashtable();
                htGetHarmStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetHarmStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }


        public static DataTable GetPassingStatus(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGradingSchemeType = new Hashtable();
                htGradingSchemeType.Add("@s_ui_locale_name", s_ui_locale_name);
                htGradingSchemeType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_grading_passing_status", htGradingSchemeType);
            }

            catch (Exception)
            {
                throw;
            }


        }

        public static int CreateGradingSchemes(SystemGradingSchemes createGradingSchemes)
        {
            Hashtable htCreateGradingSchemes = new Hashtable();
            htCreateGradingSchemes.Add("@s_grading_scheme_system_id_pk", createGradingSchemes.s_grading_scheme_system_id_pk);
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
            htCreateGradingSchemes.Add("@s_grading_scheme_name_us_english", createGradingSchemes.s_grading_scheme_name_us_english);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_us_english", createGradingSchemes.s_grading_scheme_desc_us_english);
            htCreateGradingSchemes.Add("s_grading_scheme_name_uk_english", createGradingSchemes.s_grading_scheme_name_uk_english);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_uk_english", createGradingSchemes.s_grading_scheme_desc_uk_english);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_ca_france", createGradingSchemes.s_grading_scheme_name_ca_france);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_ca_france", createGradingSchemes.s_grading_scheme_desc_ca_france);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_fr_french", createGradingSchemes.s_grading_scheme_name_fr_french);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_fr_french", createGradingSchemes.s_grading_scheme_desc_fr_french);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_mx_spanish", createGradingSchemes.s_grading_scheme_name_mx_spanish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_mx_spanish", createGradingSchemes.s_grading_scheme_desc_mx_spanish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_sp_spanish", createGradingSchemes.s_grading_scheme_name_sp_spanish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_sp_spanish", createGradingSchemes.s_grading_scheme_desc_sp_spanish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_portuguse", createGradingSchemes.s_grading_scheme_name_portuguse);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_portuguse", createGradingSchemes.s_grading_scheme_desc_portuguse);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_chinese", createGradingSchemes.s_grading_scheme_name_chinese);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_chinese", createGradingSchemes.s_grading_scheme_desc_chinese);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_german", createGradingSchemes.s_grading_scheme_name_german);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_german", createGradingSchemes.s_grading_scheme_desc_german);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_japanese", createGradingSchemes.s_grading_scheme_name_japanese);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_japanese", createGradingSchemes.s_grading_scheme_desc_japanese);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_russian", createGradingSchemes.s_grading_scheme_name_russian);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_russian", createGradingSchemes.s_grading_scheme_desc_russian);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_danish", createGradingSchemes.s_grading_scheme_name_danish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_danish", createGradingSchemes.s_grading_scheme_desc_danish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_polish", createGradingSchemes.s_grading_scheme_name_polish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_polish", createGradingSchemes.s_grading_scheme_desc_polish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_swedish", createGradingSchemes.s_grading_scheme_name_swedish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_swedish", createGradingSchemes.s_grading_scheme_desc_swedish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_finnish", createGradingSchemes.s_grading_scheme_name_finnish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_finnish", createGradingSchemes.s_grading_scheme_desc_finnish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_korean", createGradingSchemes.s_grading_scheme_name_korean);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_korean", createGradingSchemes.s_grading_scheme_desc_korean);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_italian", createGradingSchemes.s_grading_scheme_name_italian);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_italian", createGradingSchemes.s_grading_scheme_desc_italian);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_dutch", createGradingSchemes.s_grading_scheme_name_dutch);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_dutch", createGradingSchemes.s_grading_scheme_desc_dutch);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_indonesian", createGradingSchemes.s_grading_scheme_name_indonesian);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_indonesian", createGradingSchemes.s_grading_scheme_desc_indonesian);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_greek", createGradingSchemes.s_grading_scheme_name_greek);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_greek", createGradingSchemes.s_grading_scheme_desc_greek);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_hungarian", createGradingSchemes.s_grading_scheme_name_hungarian);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_hungarian", createGradingSchemes.s_grading_scheme_desc_hungarian);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_norwegian", createGradingSchemes.s_grading_scheme_name_norwegian);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_norwegian", createGradingSchemes.s_grading_scheme_desc_norwegian);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_turkish", createGradingSchemes.s_grading_scheme_name_turkish);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_turkish", createGradingSchemes.s_grading_scheme_desc_turkish);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_arabic", createGradingSchemes.s_grading_scheme_name_arabic);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_arabic", createGradingSchemes.s_grading_scheme_desc_arabic);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_01", createGradingSchemes.s_grading_scheme_name_custom_01);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_01", createGradingSchemes.s_grading_scheme_desc_custom_01);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_02", createGradingSchemes.s_grading_scheme_name_custom_02);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_02", createGradingSchemes.s_grading_scheme_desc_custom_02);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_03", createGradingSchemes.s_grading_scheme_name_custom_03);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_03", createGradingSchemes.s_grading_scheme_desc_custom_03);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_04", createGradingSchemes.s_grading_scheme_name_custom_04);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_04", createGradingSchemes.s_grading_scheme_desc_custom_04);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_05", createGradingSchemes.s_grading_scheme_name_custom_05);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_05", createGradingSchemes.s_grading_scheme_desc_custom_05);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_06", createGradingSchemes.s_grading_scheme_name_custom_06);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_06", createGradingSchemes.s_grading_scheme_desc_custom_06);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_07", createGradingSchemes.s_grading_scheme_name_custom_07);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_07", createGradingSchemes.s_grading_scheme_desc_custom_07);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_08", createGradingSchemes.s_grading_scheme_name_custom_08);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_08", createGradingSchemes.s_grading_scheme_desc_custom_08);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_09", createGradingSchemes.s_grading_scheme_name_custom_09);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_09", createGradingSchemes.s_grading_scheme_desc_custom_09);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_10", createGradingSchemes.s_grading_scheme_name_custom_10);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_10", createGradingSchemes.s_grading_scheme_desc_custom_10);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_11", createGradingSchemes.s_grading_scheme_name_custom_11);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_11", createGradingSchemes.s_grading_scheme_desc_custom_11);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_12", createGradingSchemes.s_grading_scheme_name_custom_12);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_12", createGradingSchemes.s_grading_scheme_desc_custom_12);
            htCreateGradingSchemes.Add("@s_grading_scheme_name_custom_13", createGradingSchemes.s_grading_scheme_name_custom_13);
            htCreateGradingSchemes.Add("@s_grading_scheme_desc_custom_13", createGradingSchemes.s_grading_scheme_desc_custom_13);
            htCreateGradingSchemes.Add("@s_grading_scheme_values", createGradingSchemes.s_grading_scheme_values);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_grading_schemes", htCreateGradingSchemes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemGradingSchemes GetGradingSchemes(string s_grading_scheme_system_id_pk)
        {
            SystemGradingSchemes GradingScheme;
            try
            {
                Hashtable htGetGradingSchemes=new Hashtable();
                htGetGradingSchemes.Add("@s_grading_scheme_system_id_pk", s_grading_scheme_system_id_pk);          
                GradingScheme=new SystemGradingSchemes();

                //DataTable dtGetGradingSchemes = DataProxy.FetchDataTable("***STORED PROCEDURE TO GET THE SELECTED SCHEME***", htGetGradingSchemes);
                DataTable dtGetGradingSchemes = DataProxy.FetchDataTable("s_sp_get_grading_shemes", htGetGradingSchemes);

                GradingScheme.s_grading_scheme_system_id_pk = dtGetGradingSchemes.Rows[0]["s_grading_scheme_system_id_pk"].ToString();
                GradingScheme.s_grading_scheme_id=dtGetGradingSchemes.Rows[0]["s_grading_scheme_id"].ToString();
                GradingScheme.s_grading_scheme_status_id_fk=dtGetGradingSchemes.Rows[0]["s_grading_scheme_status_id_fk"].ToString();
                GradingScheme.s_grading_scheme_type_id_fk=dtGetGradingSchemes.Rows[0]["s_grading_scheme_type_id_fk"].ToString();
                GradingScheme.s_grading_scheme_name_us_english = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_us_english"].ToString();
                GradingScheme.s_grading_scheme_desc_us_english = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_us_english"].ToString();
                GradingScheme.s_grading_scheme_name_uk_english = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_uk_english"].ToString();
                GradingScheme.s_grading_scheme_desc_uk_english = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_uk_english"].ToString();
                GradingScheme.s_grading_scheme_name_ca_france = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_ca_france"].ToString();
                GradingScheme.s_grading_scheme_desc_ca_france = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_ca_france"].ToString();
                GradingScheme.s_grading_scheme_name_fr_french = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_fr_french"].ToString();
                GradingScheme.s_grading_scheme_desc_fr_french = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_fr_french"].ToString();
                GradingScheme.s_grading_scheme_name_mx_spanish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_mx_spanish"].ToString();
                GradingScheme.s_grading_scheme_desc_mx_spanish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_mx_spanish"].ToString();
                GradingScheme.s_grading_scheme_name_sp_spanish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_sp_spanish"].ToString();
                GradingScheme.s_grading_scheme_desc_sp_spanish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_sp_spanish"].ToString();
                GradingScheme.s_grading_scheme_name_portuguse = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_portuguse"].ToString();
                GradingScheme.s_grading_scheme_desc_portuguse = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_portuguse"].ToString();
                GradingScheme.s_grading_scheme_name_chinese = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_chinese"].ToString();
                GradingScheme.s_grading_scheme_desc_chinese = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_chinese"].ToString();
                GradingScheme.s_grading_scheme_name_german = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_german"].ToString();
                GradingScheme.s_grading_scheme_desc_german = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_german"].ToString();
                GradingScheme.s_grading_scheme_name_japanese = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_japanese"].ToString();
                GradingScheme.s_grading_scheme_desc_japanese = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_japanese"].ToString();
                GradingScheme.s_grading_scheme_name_russian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_russian"].ToString();
                GradingScheme.s_grading_scheme_desc_russian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_russian"].ToString();
                GradingScheme.s_grading_scheme_name_danish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_danish"].ToString();
                GradingScheme.s_grading_scheme_desc_danish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_danish"].ToString();
                GradingScheme.s_grading_scheme_name_polish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_polish"].ToString();
                GradingScheme.s_grading_scheme_desc_polish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_polish"].ToString();
                GradingScheme.s_grading_scheme_name_swedish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_swedish"].ToString();
                GradingScheme.s_grading_scheme_desc_swedish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_swedish"].ToString();
                GradingScheme.s_grading_scheme_name_finnish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_finnish"].ToString();
                GradingScheme.s_grading_scheme_desc_finnish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_finnish"].ToString();
                GradingScheme.s_grading_scheme_name_korean = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_korean"].ToString();
                GradingScheme.s_grading_scheme_desc_korean = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_korean"].ToString();
                GradingScheme.s_grading_scheme_name_italian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_italian"].ToString();
                GradingScheme.s_grading_scheme_desc_italian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_italian"].ToString();
                GradingScheme.s_grading_scheme_name_dutch = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_dutch"].ToString();
                GradingScheme.s_grading_scheme_desc_dutch = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_dutch"].ToString();
                GradingScheme.s_grading_scheme_name_indonesian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_indonesian"].ToString();
                GradingScheme.s_grading_scheme_desc_indonesian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_indonesian"].ToString();
                GradingScheme.s_grading_scheme_name_greek = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_greek"].ToString();
                GradingScheme.s_grading_scheme_desc_greek = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_greek"].ToString();
                GradingScheme.s_grading_scheme_name_hungarian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_hungarian"].ToString();
                GradingScheme.s_grading_scheme_desc_hungarian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_hungarian"].ToString();
                GradingScheme.s_grading_scheme_name_norwegian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_norwegian"].ToString();
                GradingScheme.s_grading_scheme_desc_norwegian = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_norwegian"].ToString();
                GradingScheme.s_grading_scheme_name_turkish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_turkish"].ToString();
                GradingScheme.s_grading_scheme_desc_turkish = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_turkish"].ToString();
                GradingScheme.s_grading_scheme_name_arabic = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_arabic"].ToString();
                GradingScheme.s_grading_scheme_desc_arabic = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_arabic"].ToString();
                GradingScheme.s_grading_scheme_name_custom_01 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_01"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_01 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_01"].ToString();
                GradingScheme.s_grading_scheme_name_custom_02 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_02"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_02 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_02"].ToString();
                GradingScheme.s_grading_scheme_name_custom_03 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_03"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_03 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_03"].ToString();
                GradingScheme.s_grading_scheme_name_custom_04 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_04"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_04 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_04"].ToString();
                GradingScheme.s_grading_scheme_name_custom_05 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_05"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_05 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_05"].ToString();
                GradingScheme.s_grading_scheme_name_custom_06 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_06"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_06 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_06"].ToString();
                GradingScheme.s_grading_scheme_name_custom_07 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_07"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_07 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_07"].ToString();
                GradingScheme.s_grading_scheme_name_custom_08 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_08"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_08 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_08"].ToString();
                GradingScheme.s_grading_scheme_name_custom_09 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_09"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_09 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_09"].ToString();
                GradingScheme.s_grading_scheme_name_custom_10 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_10"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_10 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_10"].ToString();
                GradingScheme.s_grading_scheme_name_custom_11 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_11"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_11 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_11"].ToString();
                GradingScheme.s_grading_scheme_name_custom_12 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_12"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_12 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_12"].ToString();
                GradingScheme.s_grading_scheme_name_custom_13 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_name_custom_13"].ToString();
                GradingScheme.s_grading_scheme_desc_custom_13 = dtGetGradingSchemes.Rows[0]["s_grading_scheme_desc_custom_13"].ToString();
                return GradingScheme;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static int UpdateGradingSchemes( SystemGradingSchemes updateGradingSchemes)
        {
            Hashtable htUpdateGradingSchemes=new Hashtable();
            htUpdateGradingSchemes.Add("@s_grading_scheme_system_id_pk", updateGradingSchemes.s_grading_scheme_system_id_pk);
            htUpdateGradingSchemes.Add("@s_grading_scheme_id", updateGradingSchemes.s_grading_scheme_id);
            htUpdateGradingSchemes.Add("@s_grading_scheme_status_id_fk", updateGradingSchemes.s_grading_scheme_status_id_fk);
            htUpdateGradingSchemes.Add("@s_grading_scheme_type_id_fk", updateGradingSchemes.s_grading_scheme_type_id_fk);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_us_english", updateGradingSchemes.s_grading_scheme_name_us_english);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_us_english", updateGradingSchemes.s_grading_scheme_desc_us_english);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_uk_english", updateGradingSchemes.s_grading_scheme_name_uk_english);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_uk_english", updateGradingSchemes.s_grading_scheme_desc_uk_english);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_ca_france", updateGradingSchemes.s_grading_scheme_name_ca_france);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_ca_france", updateGradingSchemes.s_grading_scheme_desc_ca_france);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_fr_french", updateGradingSchemes.s_grading_scheme_name_fr_french);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_fr_french", updateGradingSchemes.s_grading_scheme_desc_fr_french);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_mx_spanish", updateGradingSchemes.s_grading_scheme_name_mx_spanish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_mx_spanish", updateGradingSchemes.s_grading_scheme_desc_mx_spanish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_sp_spanish", updateGradingSchemes.s_grading_scheme_name_sp_spanish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_sp_spanish", updateGradingSchemes.s_grading_scheme_desc_sp_spanish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_portuguse", updateGradingSchemes.s_grading_scheme_name_portuguse);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_portuguse", updateGradingSchemes.s_grading_scheme_desc_portuguse);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_chinese", updateGradingSchemes.s_grading_scheme_name_chinese);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_chinese", updateGradingSchemes.s_grading_scheme_desc_chinese);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_german", updateGradingSchemes.s_grading_scheme_name_german);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_german", updateGradingSchemes.s_grading_scheme_desc_german);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_japanese", updateGradingSchemes.s_grading_scheme_name_japanese);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_japanese", updateGradingSchemes.s_grading_scheme_desc_japanese);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_russian", updateGradingSchemes.s_grading_scheme_name_russian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_russian", updateGradingSchemes.s_grading_scheme_desc_russian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_danish", updateGradingSchemes.s_grading_scheme_name_danish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_danish", updateGradingSchemes.s_grading_scheme_desc_danish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_polish", updateGradingSchemes.s_grading_scheme_name_polish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_polish", updateGradingSchemes.s_grading_scheme_desc_polish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_swedish", updateGradingSchemes.s_grading_scheme_name_swedish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_swedish", updateGradingSchemes.s_grading_scheme_desc_swedish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_finnish", updateGradingSchemes.s_grading_scheme_name_finnish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_finnish", updateGradingSchemes.s_grading_scheme_desc_finnish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_korean", updateGradingSchemes.s_grading_scheme_name_korean);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_korean", updateGradingSchemes.s_grading_scheme_desc_korean);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_italian", updateGradingSchemes.s_grading_scheme_name_italian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_italian", updateGradingSchemes.s_grading_scheme_desc_italian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_dutch", updateGradingSchemes.s_grading_scheme_name_dutch);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_dutch", updateGradingSchemes.s_grading_scheme_desc_dutch);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_indonesian", updateGradingSchemes.s_grading_scheme_name_indonesian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_indonesian", updateGradingSchemes.s_grading_scheme_desc_indonesian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_greek", updateGradingSchemes.s_grading_scheme_name_greek);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_greek", updateGradingSchemes.s_grading_scheme_desc_greek);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_hungarian", updateGradingSchemes.s_grading_scheme_name_hungarian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_hungarian", updateGradingSchemes.s_grading_scheme_desc_hungarian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_norwegian", updateGradingSchemes.s_grading_scheme_name_norwegian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_norwegian", updateGradingSchemes.s_grading_scheme_desc_norwegian);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_turkish", updateGradingSchemes.s_grading_scheme_name_turkish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_turkish", updateGradingSchemes.s_grading_scheme_desc_turkish);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_arabic", updateGradingSchemes.s_grading_scheme_name_arabic);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_arabic", updateGradingSchemes.s_grading_scheme_desc_arabic);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_01", updateGradingSchemes.s_grading_scheme_name_custom_01);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_01", updateGradingSchemes.s_grading_scheme_desc_custom_01);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_02", updateGradingSchemes.s_grading_scheme_name_custom_02);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_02", updateGradingSchemes.s_grading_scheme_desc_custom_02);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_03", updateGradingSchemes.s_grading_scheme_name_custom_03);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_03", updateGradingSchemes.s_grading_scheme_desc_custom_03);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_04", updateGradingSchemes.s_grading_scheme_name_custom_04);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_04", updateGradingSchemes.s_grading_scheme_desc_custom_04);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_05", updateGradingSchemes.s_grading_scheme_name_custom_05);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_05", updateGradingSchemes.s_grading_scheme_desc_custom_05);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_06", updateGradingSchemes.s_grading_scheme_name_custom_06);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_06", updateGradingSchemes.s_grading_scheme_desc_custom_06);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_07", updateGradingSchemes.s_grading_scheme_name_custom_07);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_07", updateGradingSchemes.s_grading_scheme_desc_custom_07);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_08", updateGradingSchemes.s_grading_scheme_name_custom_08);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_08", updateGradingSchemes.s_grading_scheme_desc_custom_08);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_09", updateGradingSchemes.s_grading_scheme_name_custom_09);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_09", updateGradingSchemes.s_grading_scheme_desc_custom_09);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_10", updateGradingSchemes.s_grading_scheme_name_custom_10);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_10", updateGradingSchemes.s_grading_scheme_desc_custom_10);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_11", updateGradingSchemes.s_grading_scheme_name_custom_11);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_11", updateGradingSchemes.s_grading_scheme_desc_custom_11);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_12", updateGradingSchemes.s_grading_scheme_name_custom_12);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_12", updateGradingSchemes.s_grading_scheme_desc_custom_12);
            htUpdateGradingSchemes.Add("@s_grading_scheme_name_custom_13", updateGradingSchemes.s_grading_scheme_name_custom_13);
            htUpdateGradingSchemes.Add("@s_grading_scheme_desc_custom_13", updateGradingSchemes.s_grading_scheme_desc_custom_13);

            try
            {
                //return DataProxy.FetchSPOutput("***PROCEDURE NAME TO UPDATE GRADING SCHEME****", htUpdateGradingSchemes);
                return DataProxy.FetchSPOutput("s_sp_update_grading_schemes", htUpdateGradingSchemes);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static DataTable GetSearchGradingSchemes(SystemGradingSchemes serachGradingSchemes)
        {

            try
            {
                Hashtable htGetSearchGradingSchemes = new Hashtable();
                htGetSearchGradingSchemes.Add("@s_grading_scheme_id", serachGradingSchemes.s_grading_scheme_id);
                htGetSearchGradingSchemes.Add("@s_grading_scheme_name_us_english", serachGradingSchemes.s_grading_scheme_name_us_english);
                if (serachGradingSchemes.s_grading_scheme_status_id_fk == "0")
                {
                    htGetSearchGradingSchemes.Add("@s_grading_scheme_status_id_fk", DBNull.Value);
                }
                else
                {
                    htGetSearchGradingSchemes.Add("@s_grading_scheme_status_id_fk", serachGradingSchemes.s_grading_scheme_status_id_fk);
                }
                if (serachGradingSchemes.s_grading_scheme_type_id_fk == "0")
                {
                    htGetSearchGradingSchemes.Add("@s_grading_scheme_type_id_fk", DBNull.Value);
                }
                else
                {
                    htGetSearchGradingSchemes.Add("@s_grading_scheme_type_id_fk", serachGradingSchemes.s_grading_scheme_type_id_fk);
                }
                
                return DataProxy.FetchDataTable("s_sp_search_grading_schemes", htGetSearchGradingSchemes);
            }
          
            catch (Exception)
            {
                throw;
            }


        }


        /// <summary>
        /// Get grading schemes values
        /// </summary>
        /// <param name="s_grading_scheme_system_value_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetGradingSchemesValue(string s_grading_scheme_system_id_fk)
        {


            try
            {
                Hashtable htGetGradingSchemesValue = new Hashtable();
                htGetGradingSchemesValue.Add("@s_grading_scheme_system_id_fk", s_grading_scheme_system_id_fk);
                return DataProxy.FetchDataTable("s_sp_get_grading_schemes_values", htGetGradingSchemesValue);
            }

            catch (Exception)
            {
                throw;
            }


        }


        /// <summary>
        /// Get single grading schemes values
        /// </summary>
        /// <param name="s_grading_scheme_system_value_id_pk"></param>
        /// <returns></returns>
        public static SystemGradingSchemes GetSingleGradingSchemesValue(string s_grading_scheme_system_value_id_pk)
        {


            try
            {
                Hashtable htGetGradingSchemesValue = new Hashtable();
                SystemGradingSchemes gradingSchemes = new SystemGradingSchemes();
                htGetGradingSchemesValue.Add("@s_grading_scheme_system_value_id_pk", s_grading_scheme_system_value_id_pk);
                DataTable dtGetSingletGradingSchemes = DataProxy.FetchDataTable("s_sp_get_single_grading_schemes_values", htGetGradingSchemesValue);
                gradingSchemes.s_grading_scheme_system_id_pk = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_system_value_id_pk"].ToString();
                gradingSchemes.s_grading_scheme_value_id = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_id"].ToString();
                gradingSchemes.s_grading_scheme_system_id_fk = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_system_id_fk"].ToString();
                gradingSchemes.s_grading_scheme_value_name = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_name"].ToString();
                gradingSchemes.s_grading_scheme_value_description = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_description"].ToString();
                gradingSchemes.s_grading_scheme_value_min_score = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_min_score"].ToString();
                gradingSchemes.s_grading_scheme_value_max_score = Convert.ToInt32(dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_max_score"].ToString());
                gradingSchemes.s_grading_scheme_value_grade = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_grade"].ToString();
                gradingSchemes.s_grading_scheme_value_min_num = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_min_num"].ToString();
                gradingSchemes.s_grading_scheme_value_max_num = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_max_num"].ToString();
                gradingSchemes.s_grading_scheme_value_gpa = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_gpa"].ToString();
                gradingSchemes.s_grading_scheme_value_descriptior = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_descriptior"].ToString();
                gradingSchemes.s_grading_scheme_value_qualification = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_qualification"].ToString();
                gradingSchemes.s_grading_scheme_value_pass_status_id_fk = dtGetSingletGradingSchemes.Rows[0]["s_grading_scheme_value_pass_status_id_fk"].ToString();

                return gradingSchemes;
            }

            catch (Exception)
            {
                throw;
            }


        }

        /// <summary>
        /// Update Grading Scheme Value
        /// </summary>
        /// <param name="gradingschemesValue"></param>
        /// <returns></returns>
        public static int UpdateGradingSchemesValues(SystemGradingSchemes gradingschemesValue)
        {

            Hashtable htUpdateGradingSchemesValues = new Hashtable();
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_system_value_id_pk", gradingschemesValue.s_grading_scheme_system_value_id_pk);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_id", gradingschemesValue.s_grading_scheme_value_id);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_system_id_fk", gradingschemesValue.s_grading_scheme_system_id_fk);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_name", gradingschemesValue.s_grading_scheme_value_name);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_description", gradingschemesValue.s_grading_scheme_value_description);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_min_score", gradingschemesValue.s_grading_scheme_value_min_score);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_max_score", gradingschemesValue.s_grading_scheme_value_max_score);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_grade", gradingschemesValue.s_grading_scheme_value_grade);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_min_num", gradingschemesValue.s_grading_scheme_value_min_num);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_max_num", gradingschemesValue.s_grading_scheme_value_max_num);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_gpa", gradingschemesValue.s_grading_scheme_value_gpa);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_descriptior", gradingschemesValue.s_grading_scheme_value_descriptior);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_qualification", gradingschemesValue.s_grading_scheme_value_qualification);
            htUpdateGradingSchemesValues.Add("@s_grading_scheme_value_pass_status_id_fk", gradingschemesValue.s_grading_scheme_value_pass_status_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_grading_scheme_value", htUpdateGradingSchemesValues);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static int DeleteGradingSchemesValues(string s_grading_scheme_system_value_id_pk)
        {
            Hashtable htDeleteGradingSchemes = new Hashtable();
            htDeleteGradingSchemes.Add("@s_grading_scheme_system_value_id_pk", s_grading_scheme_system_value_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_gradingscheme_value", htDeleteGradingSchemes);
            }
            catch(Exception)
            {
                throw;
            }

        }
        public static int InsertGradingSchemeValues(SystemGradingSchemes createGradingSchemes)
        {
            Hashtable htInsertGradingSchemeValues = new Hashtable();
            htInsertGradingSchemeValues.Add("@s_grading_scheme_system_value_id_pk", createGradingSchemes.s_grading_scheme_system_value_id_pk);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_id",createGradingSchemes.s_grading_scheme_value_id);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_system_id_fk",createGradingSchemes.s_grading_scheme_system_id_fk);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_name",createGradingSchemes.s_grading_scheme_value_name);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_description",createGradingSchemes.s_grading_scheme_value_description);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_min_score",createGradingSchemes.s_grading_scheme_value_min_score);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_max_score",createGradingSchemes.s_grading_scheme_value_max_score);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_grade",createGradingSchemes.s_grading_scheme_value_grade);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_min_num",createGradingSchemes.s_grading_scheme_value_min_num);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_max_num",createGradingSchemes.s_grading_scheme_value_max_num);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_gpa",createGradingSchemes.s_grading_scheme_value_gpa);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_descriptior",createGradingSchemes.s_grading_scheme_value_descriptior);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_qualification",createGradingSchemes.s_grading_scheme_value_qualification);
            htInsertGradingSchemeValues.Add("@s_grading_scheme_value_pass_status_id_fk", createGradingSchemes.s_grading_scheme_value_pass_status_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_grading_schemes_values", htInsertGradingSchemeValues);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int UpdateGradingSchemeStatus(string s_grading_scheme_system_id_pk)
        {
            Hashtable htUpdateGradingSchemeStatus = new Hashtable();
            htUpdateGradingSchemeStatus.Add("@s_grading_scheme_system_id_pk", s_grading_scheme_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_grading_scheme_status", htUpdateGradingSchemeStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateallGradingSchemeValue(string s_grading_scheme_values)
        {
            Hashtable htUpdateGradingSchemeValue = new Hashtable();
            htUpdateGradingSchemeValue.Add("@s_grading_scheme_values", s_grading_scheme_values);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_grading_scheme_values", htUpdateGradingSchemeValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
