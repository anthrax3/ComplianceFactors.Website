using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemCurriculumStatusBLL
    {
        /// <summary>
        /// Create Curriculum Types
        /// </summary>
        /// <param name="createCurriculumStatus"></param>
        /// <returns></returns>
        public static int CreateCurriculumStatus(SystemCurriculumStatus createCurriculumStatus)
        {
            Hashtable htCreateCurriculumStatus = new Hashtable();

            htCreateCurriculumStatus.Add("@s_curr_status_system_id_pk", createCurriculumStatus.s_curriculum_status_system_id_pk);
            htCreateCurriculumStatus.Add("@s_curr_status_id", createCurriculumStatus.s_curriculum_status_id);
            if (createCurriculumStatus.s_curriculum_status_status_id_fk == "0")
                htCreateCurriculumStatus.Add("@s_curr_status_status_id_fk", DBNull.Value);
            else
                htCreateCurriculumStatus.Add("@s_curr_status_status_id_fk", createCurriculumStatus.s_curriculum_status_status_id_fk);

            htCreateCurriculumStatus.Add("@s_curr_status_english_us_name", createCurriculumStatus.s_curriculum_status_name_us_english);
            htCreateCurriculumStatus.Add("@s_curr_status_english_us_description", createCurriculumStatus.s_curriculum_status_desc_us_english);
            htCreateCurriculumStatus.Add("@s_curr_status_english_uk_name", createCurriculumStatus.s_curriculum_status_name_uk_english);
            htCreateCurriculumStatus.Add("@s_curr_status_english_uk_description", createCurriculumStatus.s_curriculum_status_desc_uk_english);
            htCreateCurriculumStatus.Add("@s_curr_status_france_ca_name", createCurriculumStatus.s_curriculum_status_name_ca_french);
            htCreateCurriculumStatus.Add("@s_curr_status_france_ca_description", createCurriculumStatus.s_curriculum_status_desc_ca_french);
            htCreateCurriculumStatus.Add("@s_curr_status_french_fr_name", createCurriculumStatus.s_curriculum_status_name_fr_french);
            htCreateCurriculumStatus.Add("@s_curr_status_french_fr_description", createCurriculumStatus.s_curriculum_status_desc_fr_french);
            htCreateCurriculumStatus.Add("@s_curr_status_spanish_mx_name", createCurriculumStatus.s_curriculum_status_name_mx_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_spanish_mx_description", createCurriculumStatus.s_curriculum_status_desc_mx_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_sapnish_sp_name", createCurriculumStatus.s_curriculum_status_name_sp_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_spanish_sp_description", createCurriculumStatus.s_curriculum_status_desc_sp_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_portuguse_name", createCurriculumStatus.s_curriculum_status_name_portuguese);
            htCreateCurriculumStatus.Add("@s_curr_status_portuguse_description", createCurriculumStatus.s_curriculum_status_desc_portuguese);
            htCreateCurriculumStatus.Add("@s_curr_status_chinese_name", createCurriculumStatus.s_curriculum_status_name_simp_chinese);
            htCreateCurriculumStatus.Add("@s_curr_status_chinese_description", createCurriculumStatus.s_curriculum_status_desc_simp_chinese);
            htCreateCurriculumStatus.Add("@s_curr_status_german_name", createCurriculumStatus.s_curriculum_status_name_german);
            htCreateCurriculumStatus.Add("@s_curr_status_german_description", createCurriculumStatus.s_curriculum_status_desc_german);
            htCreateCurriculumStatus.Add("@s_curr_status_japanese_name", createCurriculumStatus.s_curriculum_status_name_japanese);
            htCreateCurriculumStatus.Add("@s_curr_status_japanese_description", createCurriculumStatus.s_curriculum_status_desc_japanese);
            htCreateCurriculumStatus.Add("@s_curr_status_russian_name", createCurriculumStatus.s_curriculum_status_name_russian);
            htCreateCurriculumStatus.Add("@s_curr_status_russian_description", createCurriculumStatus.s_curriculum_status_desc_russian);
            htCreateCurriculumStatus.Add("@s_curr_status_danish_name", createCurriculumStatus.s_curriculum_status_name_danish);
            htCreateCurriculumStatus.Add("@s_curr_status_danish_description", createCurriculumStatus.s_curriculum_status_desc_danish);
            htCreateCurriculumStatus.Add("@s_curr_status_polish_name", createCurriculumStatus.s_curriculum_status_name_polish);
            htCreateCurriculumStatus.Add("@s_curr_status_polish_description", createCurriculumStatus.s_curriculum_status_desc_polish);
            htCreateCurriculumStatus.Add("@s_curr_status_swedish_name", createCurriculumStatus.s_curriculum_status_name_swedish);
            htCreateCurriculumStatus.Add("@s_curr_status_swedish_description", createCurriculumStatus.s_curriculum_status_desc_swedish);
            htCreateCurriculumStatus.Add("@s_curr_status_finnish_name", createCurriculumStatus.s_curriculum_status_name_finnish);
            htCreateCurriculumStatus.Add("@s_curr_status_finnish_description", createCurriculumStatus.s_curriculum_status_desc_finnish);
            htCreateCurriculumStatus.Add("@s_curr_status_korean_name", createCurriculumStatus.s_curriculum_status_name_korean);
            htCreateCurriculumStatus.Add("@s_curr_status_korean_description", createCurriculumStatus.s_curriculum_status_desc_korean);
            htCreateCurriculumStatus.Add("@s_curr_status_italian_name", createCurriculumStatus.s_curriculum_status_name_italian);
            htCreateCurriculumStatus.Add("@s_curr_status_italian_description", createCurriculumStatus.s_curriculum_status_desc_italian);
            htCreateCurriculumStatus.Add("@s_curr_status_dutch_name", createCurriculumStatus.s_curriculum_status_name_dutch);
            htCreateCurriculumStatus.Add("@s_curr_status_dutch_description", createCurriculumStatus.s_curriculum_status_desc_dutch);
            htCreateCurriculumStatus.Add("@s_curr_status_indonesian_name", createCurriculumStatus.s_curriculum_status_name_indonesian);
            htCreateCurriculumStatus.Add("@s_curr_status_indonesian_description", createCurriculumStatus.s_curriculum_status_desc_indonesian);
            htCreateCurriculumStatus.Add("@s_curr_status_greek_name", createCurriculumStatus.s_curriculum_status_name_greek);
            htCreateCurriculumStatus.Add("@s_curr_status_greek_description", createCurriculumStatus.s_curriculum_status_desc_greek);
            htCreateCurriculumStatus.Add("@s_curr_status_hungarian_name", createCurriculumStatus.s_curriculum_status_name_hungarian);
            htCreateCurriculumStatus.Add("@s_curr_status_hungarian_description", createCurriculumStatus.s_curriculum_status_desc_hungarian);
            htCreateCurriculumStatus.Add("@s_curr_status_norwegian_name", createCurriculumStatus.s_curriculum_status_name_norwegian);
            htCreateCurriculumStatus.Add("@s_curr_status_norwegian_description", createCurriculumStatus.s_curriculum_status_desc_norwegian);
            htCreateCurriculumStatus.Add("@s_curr_status_turkish_name", createCurriculumStatus.s_curriculum_status_name_turkish);
            htCreateCurriculumStatus.Add("@s_curr_status_turkish_description", createCurriculumStatus.s_curriculum_status_desc_turkish);
            htCreateCurriculumStatus.Add("@s_curr_status_arabic_name", createCurriculumStatus.s_curriculum_status_name_arabic_rtl);
            htCreateCurriculumStatus.Add("@s_curr_status_arabic_description", createCurriculumStatus.s_curriculum_status_desc_arabic_rtl);
            htCreateCurriculumStatus.Add("@s_curr_status_custom01_name", createCurriculumStatus.s_curriculum_status_name_custom_01);
            htCreateCurriculumStatus.Add("@s_curr_status_custom01_description", createCurriculumStatus.s_curriculum_status_desc_custom_01);
            htCreateCurriculumStatus.Add("@s_curr_status_custom02_name", createCurriculumStatus.s_curriculum_status_name_custom_02);
            htCreateCurriculumStatus.Add("@s_curr_status_custom02_description", createCurriculumStatus.s_curriculum_status_desc_custom_02);
            htCreateCurriculumStatus.Add("@s_curr_status_custom03_name", createCurriculumStatus.s_curriculum_status_name_custom_03);
            htCreateCurriculumStatus.Add("@s_curr_status_custom03_description", createCurriculumStatus.s_curriculum_status_desc_custom_03);
            htCreateCurriculumStatus.Add("@s_curr_status_custom04_name", createCurriculumStatus.s_curriculum_status_name_custom_04);
            htCreateCurriculumStatus.Add("@s_curr_status_custom04_description", createCurriculumStatus.s_curriculum_status_desc_custom_04);
            htCreateCurriculumStatus.Add("@s_curr_status_custom05_name", createCurriculumStatus.s_curriculum_status_name_custom_05);
            htCreateCurriculumStatus.Add("@s_curr_status_custom05_description", createCurriculumStatus.s_curriculum_status_desc_custom_05);
            htCreateCurriculumStatus.Add("@s_curr_status_custom06_name", createCurriculumStatus.s_curriculum_status_name_custom_06);
            htCreateCurriculumStatus.Add("@s_curr_status_custom06_description", createCurriculumStatus.s_curriculum_status_desc_custom_06);
            htCreateCurriculumStatus.Add("@s_curr_status_custom07_name", createCurriculumStatus.s_curriculum_status_name_custom_07);
            htCreateCurriculumStatus.Add("@s_curr_status_custom07_description", createCurriculumStatus.s_curriculum_status_desc_custom_07);
            htCreateCurriculumStatus.Add("@s_curr_status_custom08_name", createCurriculumStatus.s_curriculum_status_name_custom_08);
            htCreateCurriculumStatus.Add("@s_curr_status_custom08_description", createCurriculumStatus.s_curriculum_status_desc_custom_08);
            htCreateCurriculumStatus.Add("@s_curr_status_custom09_name", createCurriculumStatus.s_curriculum_status_name_custom_09);
            htCreateCurriculumStatus.Add("@s_curr_status_custom09_description", createCurriculumStatus.s_curriculum_status_desc_custom_09);
            htCreateCurriculumStatus.Add("@s_curr_status_custom10_name", createCurriculumStatus.s_curriculum_status_name_custom_10);
            htCreateCurriculumStatus.Add("@s_curr_status_custom10_description", createCurriculumStatus.s_curriculum_status_desc_custom_10);
            htCreateCurriculumStatus.Add("@s_curr_status_custom11_name", createCurriculumStatus.s_curriculum_status_name_custom_11);
            htCreateCurriculumStatus.Add("@s_curr_status_custom11_description", createCurriculumStatus.s_curriculum_status_desc_custom_11);
            htCreateCurriculumStatus.Add("@s_curr_status_custom12_name", createCurriculumStatus.s_curriculum_status_name_custom_12);
            htCreateCurriculumStatus.Add("@s_curr_status_custom12_description", createCurriculumStatus.s_curriculum_status_desc_custom_12);
            htCreateCurriculumStatus.Add("@s_curr_status_custom13_name", createCurriculumStatus.s_curriculum_status_name_custom_13);
            htCreateCurriculumStatus.Add("@s_curr_status_custom13_description", createCurriculumStatus.s_curriculum_status_desc_custom_13);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_curriculum_status", htCreateCurriculumStatus);
            }
            catch (Exception)
            {
                throw;
            }



        }

        /// <summary>
        /// Create Curriculum Types
        /// </summary>
        /// <param name="createCurriculumTypes"></param>
        /// <returns></returns>
        public static int UpdateCurriculumStatus(SystemCurriculumStatus updateCurriculumStatus)
        {
            Hashtable htUpdateCurriculumStatus = new Hashtable();
            htUpdateCurriculumStatus.Add("@s_curriculum_status_system_id_pk", updateCurriculumStatus.s_curriculum_status_system_id_pk);
            htUpdateCurriculumStatus.Add("@s_curriculum_status_id", updateCurriculumStatus.s_curriculum_status_id);
            if (updateCurriculumStatus.s_curriculum_status_status_id_fk == "0")
                htUpdateCurriculumStatus.Add("@s_curriculum_status_status_id_fk", DBNull.Value);
            else
                htUpdateCurriculumStatus.Add("@s_curriculum_status_status_id_fk", updateCurriculumStatus.s_curriculum_status_status_id_fk);

            htUpdateCurriculumStatus.Add("@s_curr_status_english_us_name", updateCurriculumStatus.s_curriculum_status_name_us_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_english_us_description", updateCurriculumStatus.s_curriculum_status_desc_us_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_english_uk_name", updateCurriculumStatus.s_curriculum_status_name_uk_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_english_uk_description", updateCurriculumStatus.s_curriculum_status_desc_uk_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_france_ca_name", updateCurriculumStatus.s_curriculum_status_name_ca_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_france_ca_description", updateCurriculumStatus.s_curriculum_status_desc_ca_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_french_fr_name", updateCurriculumStatus.s_curriculum_status_name_fr_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_french_fr_description", updateCurriculumStatus.s_curriculum_status_desc_fr_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_spanish_mx_name", updateCurriculumStatus.s_curriculum_status_name_mx_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_spanish_mx_description", updateCurriculumStatus.s_curriculum_status_desc_mx_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_sapnish_sp_name", updateCurriculumStatus.s_curriculum_status_name_sp_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_spanish_sp_description", updateCurriculumStatus.s_curriculum_status_desc_sp_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_portuguse_name", updateCurriculumStatus.s_curriculum_status_name_portuguese);
            htUpdateCurriculumStatus.Add("@s_curr_status_portuguse_description", updateCurriculumStatus.s_curriculum_status_desc_portuguese);
            htUpdateCurriculumStatus.Add("@s_curr_status_chinese_name", updateCurriculumStatus.s_curriculum_status_name_simp_chinese);
            htUpdateCurriculumStatus.Add("@s_curr_status_chinese_description", updateCurriculumStatus.s_curriculum_status_desc_simp_chinese);
            htUpdateCurriculumStatus.Add("@s_curr_status_german_name", updateCurriculumStatus.s_curriculum_status_name_german);
            htUpdateCurriculumStatus.Add("@s_curr_status_german_description", updateCurriculumStatus.s_curriculum_status_desc_german);
            htUpdateCurriculumStatus.Add("@s_curr_status_japanese_name", updateCurriculumStatus.s_curriculum_status_name_japanese);
            htUpdateCurriculumStatus.Add("@s_curr_status_japanese_description", updateCurriculumStatus.s_curriculum_status_desc_japanese);
            htUpdateCurriculumStatus.Add("@s_curr_status_russian_name", updateCurriculumStatus.s_curriculum_status_name_russian);
            htUpdateCurriculumStatus.Add("@s_curr_status_russian_description", updateCurriculumStatus.s_curriculum_status_desc_russian);
            htUpdateCurriculumStatus.Add("@s_curr_status_danish_name", updateCurriculumStatus.s_curriculum_status_name_danish);
            htUpdateCurriculumStatus.Add("@s_curr_status_danish_description", updateCurriculumStatus.s_curriculum_status_desc_danish);
            htUpdateCurriculumStatus.Add("@s_curr_status_polish_name", updateCurriculumStatus.s_curriculum_status_name_polish);
            htUpdateCurriculumStatus.Add("@s_curr_status_polish_description", updateCurriculumStatus.s_curriculum_status_desc_polish);
            htUpdateCurriculumStatus.Add("@s_curr_status_swedish_name", updateCurriculumStatus.s_curriculum_status_name_swedish);
            htUpdateCurriculumStatus.Add("@s_curr_status_swedish_description", updateCurriculumStatus.s_curriculum_status_desc_swedish);
            htUpdateCurriculumStatus.Add("@s_curr_status_finnish_name", updateCurriculumStatus.s_curriculum_status_name_finnish);
            htUpdateCurriculumStatus.Add("@s_curr_status_finnish_description", updateCurriculumStatus.s_curriculum_status_desc_finnish);
            htUpdateCurriculumStatus.Add("@s_curr_status_korean_name", updateCurriculumStatus.s_curriculum_status_name_korean);
            htUpdateCurriculumStatus.Add("@s_curr_status_korean_description", updateCurriculumStatus.s_curriculum_status_desc_korean);
            htUpdateCurriculumStatus.Add("@s_curr_status_italian_name", updateCurriculumStatus.s_curriculum_status_name_italian);
            htUpdateCurriculumStatus.Add("@s_curr_status_italian_description", updateCurriculumStatus.s_curriculum_status_desc_italian);
            htUpdateCurriculumStatus.Add("@s_curr_status_dutch_name", updateCurriculumStatus.s_curriculum_status_name_dutch);
            htUpdateCurriculumStatus.Add("@s_curr_status_dutch_description", updateCurriculumStatus.s_curriculum_status_desc_dutch);
            htUpdateCurriculumStatus.Add("@s_curr_status_indonesian_name", updateCurriculumStatus.s_curriculum_status_name_indonesian);
            htUpdateCurriculumStatus.Add("@s_curr_status_indonesian_description", updateCurriculumStatus.s_curriculum_status_desc_indonesian);
            htUpdateCurriculumStatus.Add("@s_curr_status_greek_name", updateCurriculumStatus.s_curriculum_status_name_greek);
            htUpdateCurriculumStatus.Add("@s_curr_status_greek_description", updateCurriculumStatus.s_curriculum_status_desc_greek);
            htUpdateCurriculumStatus.Add("@s_curr_status_hungarian_name", updateCurriculumStatus.s_curriculum_status_name_hungarian);
            htUpdateCurriculumStatus.Add("@s_curr_status_hungarian_description", updateCurriculumStatus.s_curriculum_status_desc_hungarian);
            htUpdateCurriculumStatus.Add("@s_curr_status_norwegian_name", updateCurriculumStatus.s_curriculum_status_name_norwegian);
            htUpdateCurriculumStatus.Add("@s_curr_status_norwegian_description", updateCurriculumStatus.s_curriculum_status_desc_norwegian);
            htUpdateCurriculumStatus.Add("@s_curr_status_turkish_name", updateCurriculumStatus.s_curriculum_status_name_turkish);
            htUpdateCurriculumStatus.Add("@s_curr_status_turkish_description", updateCurriculumStatus.s_curriculum_status_desc_turkish);
            htUpdateCurriculumStatus.Add("@s_curr_status_arabic_name", updateCurriculumStatus.s_curriculum_status_name_arabic_rtl);
            htUpdateCurriculumStatus.Add("@s_curr_status_arabic_description", updateCurriculumStatus.s_curriculum_status_desc_arabic_rtl);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom01_name", updateCurriculumStatus.s_curriculum_status_name_custom_01);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom01_description", updateCurriculumStatus.s_curriculum_status_desc_custom_01);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom02_name", updateCurriculumStatus.s_curriculum_status_name_custom_02);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom02_description", updateCurriculumStatus.s_curriculum_status_desc_custom_02);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom03_name", updateCurriculumStatus.s_curriculum_status_name_custom_03);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom03_description", updateCurriculumStatus.s_curriculum_status_desc_custom_03);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom04_name", updateCurriculumStatus.s_curriculum_status_name_custom_04);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom04_description", updateCurriculumStatus.s_curriculum_status_desc_custom_04);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom05_name", updateCurriculumStatus.s_curriculum_status_name_custom_05);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom05_description", updateCurriculumStatus.s_curriculum_status_desc_custom_05);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom06_name", updateCurriculumStatus.s_curriculum_status_name_custom_06);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom06_description", updateCurriculumStatus.s_curriculum_status_desc_custom_06);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom07_name", updateCurriculumStatus.s_curriculum_status_name_custom_07);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom07_description", updateCurriculumStatus.s_curriculum_status_desc_custom_07);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom08_name", updateCurriculumStatus.s_curriculum_status_name_custom_08);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom08_description", updateCurriculumStatus.s_curriculum_status_desc_custom_08);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom09_name", updateCurriculumStatus.s_curriculum_status_name_custom_09);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom09_description", updateCurriculumStatus.s_curriculum_status_desc_custom_09);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom10_name", updateCurriculumStatus.s_curriculum_status_name_custom_10);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom10_description", updateCurriculumStatus.s_curriculum_status_desc_custom_10);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom11_name", updateCurriculumStatus.s_curriculum_status_name_custom_11);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom11_description", updateCurriculumStatus.s_curriculum_status_desc_custom_11);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom12_name", updateCurriculumStatus.s_curriculum_status_name_custom_12);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom12_description", updateCurriculumStatus.s_curriculum_status_desc_custom_12);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom13_name", updateCurriculumStatus.s_curriculum_status_name_custom_13);
            htUpdateCurriculumStatus.Add("@s_curr_status_custom13_description", updateCurriculumStatus.s_curriculum_status_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_status", htUpdateCurriculumStatus);
            }
            catch (Exception)
            {
                throw;
            }



        }

        public static DataTable SearchCurriculumStatus(SystemCurriculumStatus curriculumStatus)
        {
            Hashtable htCurriculumStatus = new Hashtable();
            htCurriculumStatus.Add("@s_curriculum_status_id", curriculumStatus.s_curriculum_status_id);
            htCurriculumStatus.Add("@s_curr_status_english_us_name", curriculumStatus.s_curriculum_status_name_us_english);
            if (curriculumStatus.s_curriculum_status_status_id_fk == "0")
                htCurriculumStatus.Add("@s_curriculum_status_status_id_fk", DBNull.Value);
            else
                htCurriculumStatus.Add("@s_curriculum_status_status_id_fk", curriculumStatus.s_curriculum_status_status_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_curriculum_status", htCurriculumStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetStatus);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllStatus = new Hashtable();
                htGetAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetAllStatus);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static SystemCurriculumStatus GetCurriculumStatus(string s_curriculum_status_system_id_pk)
        {
            SystemCurriculumStatus curriculumStatus;
            try
            {
                Hashtable htGetCurriculumTypes = new Hashtable();
                htGetCurriculumTypes.Add("@s_curriculum_status_system_id_pk", s_curriculum_status_system_id_pk);
                curriculumStatus = new SystemCurriculumStatus();
                DataTable dtGetCurriculumType = DataProxy.FetchDataTable("s_sp_get_single_curriculum_status", htGetCurriculumTypes);
                curriculumStatus.s_curriculum_status_id = dtGetCurriculumType.Rows[0]["s_curr_status_id"].ToString();
                curriculumStatus.s_curriculum_status_status_id_fk = dtGetCurriculumType.Rows[0]["s_curr_status_status_id_fk"].ToString();
                curriculumStatus.s_curriculum_status_name_us_english = dtGetCurriculumType.Rows[0]["s_curr_status_english_us_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_us_english = dtGetCurriculumType.Rows[0]["s_curr_status_english_us_description"].ToString();
                curriculumStatus.s_curriculum_status_name_uk_english = dtGetCurriculumType.Rows[0]["s_curr_status_english_uk_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_uk_english = dtGetCurriculumType.Rows[0]["s_curr_status_english_uk_description"].ToString();
                curriculumStatus.s_curriculum_status_name_ca_french = dtGetCurriculumType.Rows[0]["s_curr_status_france_ca_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_ca_french = dtGetCurriculumType.Rows[0]["s_curr_status_france_ca_description"].ToString();
                curriculumStatus.s_curriculum_status_name_fr_french = dtGetCurriculumType.Rows[0]["s_curr_status_french_fr_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_fr_french = dtGetCurriculumType.Rows[0]["s_curr_status_french_fr_description"].ToString();
                curriculumStatus.s_curriculum_status_name_mx_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_spanish_mx_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_mx_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_spanish_mx_description"].ToString();
                curriculumStatus.s_curriculum_status_name_sp_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_sapnish_sp_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_sp_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_spanish_sp_description"].ToString();
                curriculumStatus.s_curriculum_status_name_portuguese = dtGetCurriculumType.Rows[0]["s_curr_status_portuguse_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_portuguese = dtGetCurriculumType.Rows[0]["s_curr_status_portuguse_description"].ToString();
                curriculumStatus.s_curriculum_status_name_simp_chinese = dtGetCurriculumType.Rows[0]["s_curr_status_chinese_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_simp_chinese = dtGetCurriculumType.Rows[0]["s_curr_status_chinese_description"].ToString();
                curriculumStatus.s_curriculum_status_name_german = dtGetCurriculumType.Rows[0]["s_curr_status_german_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_german = dtGetCurriculumType.Rows[0]["s_curr_status_german_description"].ToString();
                curriculumStatus.s_curriculum_status_name_japanese = dtGetCurriculumType.Rows[0]["s_curr_status_japanese_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_japanese = dtGetCurriculumType.Rows[0]["s_curr_status_japanese_description"].ToString();
                curriculumStatus.s_curriculum_status_name_russian = dtGetCurriculumType.Rows[0]["s_curr_status_russian_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_russian = dtGetCurriculumType.Rows[0]["s_curr_status_russian_description"].ToString();
                curriculumStatus.s_curriculum_status_name_danish = dtGetCurriculumType.Rows[0]["s_curr_status_danish_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_danish = dtGetCurriculumType.Rows[0]["s_curr_status_danish_description"].ToString();
                curriculumStatus.s_curriculum_status_name_polish = dtGetCurriculumType.Rows[0]["s_curr_status_polish_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_polish = dtGetCurriculumType.Rows[0]["s_curr_status_polish_description"].ToString();
                curriculumStatus.s_curriculum_status_name_swedish = dtGetCurriculumType.Rows[0]["s_curr_status_swedish_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_swedish = dtGetCurriculumType.Rows[0]["s_curr_status_swedish_description"].ToString();
                curriculumStatus.s_curriculum_status_name_finnish = dtGetCurriculumType.Rows[0]["s_curr_status_finnish_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_finnish = dtGetCurriculumType.Rows[0]["s_curr_status_finnish_description"].ToString();
                curriculumStatus.s_curriculum_status_name_korean = dtGetCurriculumType.Rows[0]["s_curr_status_korean_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_korean = dtGetCurriculumType.Rows[0]["s_curr_status_korean_description"].ToString();
                curriculumStatus.s_curriculum_status_name_italian = dtGetCurriculumType.Rows[0]["s_curr_status_italian_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_italian = dtGetCurriculumType.Rows[0]["s_curr_status_italian_description"].ToString();
                curriculumStatus.s_curriculum_status_name_dutch = dtGetCurriculumType.Rows[0]["s_curr_status_dutch_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_dutch = dtGetCurriculumType.Rows[0]["s_curr_status_dutch_description"].ToString();
                curriculumStatus.s_curriculum_status_name_indonesian = dtGetCurriculumType.Rows[0]["s_curr_status_indonesian_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_indonesian = dtGetCurriculumType.Rows[0]["s_curr_status_indonesian_description"].ToString();
                curriculumStatus.s_curriculum_status_name_greek = dtGetCurriculumType.Rows[0]["s_curr_status_greek_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_greek = dtGetCurriculumType.Rows[0]["s_curr_status_greek_description"].ToString();
                curriculumStatus.s_curriculum_status_name_hungarian = dtGetCurriculumType.Rows[0]["s_curr_status_hungarian_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_hungarian = dtGetCurriculumType.Rows[0]["s_curr_status_hungarian_description"].ToString();
                curriculumStatus.s_curriculum_status_name_norwegian = dtGetCurriculumType.Rows[0]["s_curr_status_norwegian_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_norwegian = dtGetCurriculumType.Rows[0]["s_curr_status_norwegian_description"].ToString();
                curriculumStatus.s_curriculum_status_name_turkish = dtGetCurriculumType.Rows[0]["s_curr_status_turkish_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_turkish = dtGetCurriculumType.Rows[0]["s_curr_status_turkish_description"].ToString();
                curriculumStatus.s_curriculum_status_name_arabic_rtl = dtGetCurriculumType.Rows[0]["s_curr_status_arabic_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_arabic_rtl = dtGetCurriculumType.Rows[0]["s_curr_status_arabic_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_01 = dtGetCurriculumType.Rows[0]["s_curr_status_custom01_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_01 = dtGetCurriculumType.Rows[0]["s_curr_status_custom01_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_02 = dtGetCurriculumType.Rows[0]["s_curr_status_custom02_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_02 = dtGetCurriculumType.Rows[0]["s_curr_status_custom02_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_03 = dtGetCurriculumType.Rows[0]["s_curr_status_custom03_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_03 = dtGetCurriculumType.Rows[0]["s_curr_status_custom03_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_04 = dtGetCurriculumType.Rows[0]["s_curr_status_custom04_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_04 = dtGetCurriculumType.Rows[0]["s_curr_status_custom04_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_05 = dtGetCurriculumType.Rows[0]["s_curr_status_custom05_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_05 = dtGetCurriculumType.Rows[0]["s_curr_status_custom05_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_06 = dtGetCurriculumType.Rows[0]["s_curr_status_custom06_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_06 = dtGetCurriculumType.Rows[0]["s_curr_status_custom06_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_07 = dtGetCurriculumType.Rows[0]["s_curr_status_custom07_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_07 = dtGetCurriculumType.Rows[0]["s_curr_status_custom07_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_08 = dtGetCurriculumType.Rows[0]["s_curr_status_custom08_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_08 = dtGetCurriculumType.Rows[0]["s_curr_status_custom08_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_09 = dtGetCurriculumType.Rows[0]["s_curr_status_custom09_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_09 = dtGetCurriculumType.Rows[0]["s_curr_status_custom09_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_10 = dtGetCurriculumType.Rows[0]["s_curr_status_custom10_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_10 = dtGetCurriculumType.Rows[0]["s_curr_status_custom10_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_11 = dtGetCurriculumType.Rows[0]["s_curr_status_custom11_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_11 = dtGetCurriculumType.Rows[0]["s_curr_status_custom11_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_12 = dtGetCurriculumType.Rows[0]["s_curr_status_custom12_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_12 = dtGetCurriculumType.Rows[0]["s_curr_status_custom12_description"].ToString();
                curriculumStatus.s_curriculum_status_name_custom_13 = dtGetCurriculumType.Rows[0]["s_curr_status_custom13_name"].ToString();
                curriculumStatus.s_curriculum_status_desc_custom_13 = dtGetCurriculumType.Rows[0]["s_curr_status_custom13_description"].ToString();


                return curriculumStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateCurriculumStatusType(string s_curriculum_status_system_id_pk)
        {
            Hashtable htUpdateCurriculumStatus = new Hashtable();
            htUpdateCurriculumStatus.Add("@s_curriculum_status_system_id_pk", s_curriculum_status_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_status_status", htUpdateCurriculumStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
