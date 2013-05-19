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

            htCreateCurriculumStatus.Add("@s_curr_status_system_id_pk", createCurriculumStatus.s_curr_status_system_id_pk);
            htCreateCurriculumStatus.Add("@s_curr_status_id", createCurriculumStatus.s_curr_status_id);
            if (createCurriculumStatus.s_curr_status_status_id_fk == "0")
                htCreateCurriculumStatus.Add("@s_curr_status_status_id_fk", DBNull.Value);
            else
                htCreateCurriculumStatus.Add("@s_curr_status_status_id_fk", createCurriculumStatus.s_curr_status_status_id_fk);

            htCreateCurriculumStatus.Add("@s_curr_status_name_us_english", createCurriculumStatus.s_curr_status_name_us_english);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_us_english", createCurriculumStatus.s_curr_status_desc_us_english);
            htCreateCurriculumStatus.Add("@s_curr_status_name_uk_english", createCurriculumStatus.s_curr_status_name_uk_english);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_uk_english", createCurriculumStatus.s_curr_status_desc_uk_english);
            htCreateCurriculumStatus.Add("@s_curr_status_name_ca_france", createCurriculumStatus.s_curr_status_name_ca_french);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_ca_france", createCurriculumStatus.s_curr_status_desc_ca_french);
            htCreateCurriculumStatus.Add("@s_curr_status_name_fr_french", createCurriculumStatus.s_curr_status_name_fr_french);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_fr_french", createCurriculumStatus.s_curr_status_desc_fr_french);
            htCreateCurriculumStatus.Add("@s_curr_status_name_mx_spanish", createCurriculumStatus.s_curr_status_name_mx_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_mx_spanish", createCurriculumStatus.s_curr_status_desc_mx_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_sp_spanish", createCurriculumStatus.s_curr_status_name_sp_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_sp_spanish", createCurriculumStatus.s_curr_status_desc_sp_spanish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_portuguse", createCurriculumStatus.s_curr_status_name_portuguese);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_portuguse", createCurriculumStatus.s_curr_status_desc_portuguese);
            htCreateCurriculumStatus.Add("@s_curr_status_name_chinese", createCurriculumStatus.s_curr_status_name_simp_chinese);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_chinese", createCurriculumStatus.s_curr_status_desc_simp_chinese);
            htCreateCurriculumStatus.Add("@s_curr_status_name_german", createCurriculumStatus.s_curr_status_name_german);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_german", createCurriculumStatus.s_curr_status_desc_german);
            htCreateCurriculumStatus.Add("@s_curr_status_name_japanese", createCurriculumStatus.s_curr_status_name_japanese);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_japanese", createCurriculumStatus.s_curr_status_desc_japanese);
            htCreateCurriculumStatus.Add("@s_curr_status_name_russian", createCurriculumStatus.s_curr_status_name_russian);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_russian", createCurriculumStatus.s_curr_status_desc_russian);
            htCreateCurriculumStatus.Add("@s_curr_status_name_danish", createCurriculumStatus.s_curr_status_name_danish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_danish", createCurriculumStatus.s_curr_status_desc_danish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_polish", createCurriculumStatus.s_curr_status_name_polish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_polish", createCurriculumStatus.s_curr_status_desc_polish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_swedish", createCurriculumStatus.s_curr_status_name_swedish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_swedish", createCurriculumStatus.s_curr_status_desc_swedish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_finnish", createCurriculumStatus.s_curr_status_name_finnish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_finnish", createCurriculumStatus.s_curr_status_desc_finnish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_korean", createCurriculumStatus.s_curr_status_name_korean);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_korean", createCurriculumStatus.s_curr_status_desc_korean);
            htCreateCurriculumStatus.Add("@s_curr_status_name_italian", createCurriculumStatus.s_curr_status_name_italian);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_italian", createCurriculumStatus.s_curr_status_desc_italian);
            htCreateCurriculumStatus.Add("@s_curr_status_name_dutch", createCurriculumStatus.s_curr_status_name_dutch);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_dutch", createCurriculumStatus.s_curr_status_desc_dutch);
            htCreateCurriculumStatus.Add("@s_curr_status_name_indonesian", createCurriculumStatus.s_curr_status_name_indonesian);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_indonesian", createCurriculumStatus.s_curr_status_desc_indonesian);
            htCreateCurriculumStatus.Add("@s_curr_status_name_greek", createCurriculumStatus.s_curr_status_name_greek);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_greek", createCurriculumStatus.s_curr_status_desc_greek);
            htCreateCurriculumStatus.Add("@s_curr_status_name_hungarian", createCurriculumStatus.s_curr_status_name_hungarian);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_hungarian", createCurriculumStatus.s_curr_status_desc_hungarian);
            htCreateCurriculumStatus.Add("@s_curr_status_name_norwegian", createCurriculumStatus.s_curr_status_name_norwegian);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_norwegian", createCurriculumStatus.s_curr_status_desc_norwegian);
            htCreateCurriculumStatus.Add("@s_curr_status_name_turkish", createCurriculumStatus.s_curr_status_name_turkish);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_turkish", createCurriculumStatus.s_curr_status_desc_turkish);
            htCreateCurriculumStatus.Add("@s_curr_status_name_arabic", createCurriculumStatus.s_curr_status_name_arabic_rtl);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_arabic", createCurriculumStatus.s_curr_status_desc_arabic_rtl);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_01", createCurriculumStatus.s_curr_status_name_custom_01);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_01", createCurriculumStatus.s_curr_status_desc_custom_01);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_02", createCurriculumStatus.s_curr_status_name_custom_02);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_02", createCurriculumStatus.s_curr_status_desc_custom_02);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_03", createCurriculumStatus.s_curr_status_name_custom_03);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_03", createCurriculumStatus.s_curr_status_desc_custom_03);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_04", createCurriculumStatus.s_curr_status_name_custom_04);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_04", createCurriculumStatus.s_curr_status_desc_custom_04);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_05", createCurriculumStatus.s_curr_status_name_custom_05);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_05", createCurriculumStatus.s_curr_status_desc_custom_05);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_06", createCurriculumStatus.s_curr_status_name_custom_06);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_06", createCurriculumStatus.s_curr_status_desc_custom_06);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_07", createCurriculumStatus.s_curr_status_name_custom_07);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_07", createCurriculumStatus.s_curr_status_desc_custom_07);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_08", createCurriculumStatus.s_curr_status_name_custom_08);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_08", createCurriculumStatus.s_curr_status_desc_custom_08);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_09", createCurriculumStatus.s_curr_status_name_custom_09);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_09", createCurriculumStatus.s_curr_status_desc_custom_09);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_10", createCurriculumStatus.s_curr_status_name_custom_10);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_10", createCurriculumStatus.s_curr_status_desc_custom_10);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_11", createCurriculumStatus.s_curr_status_name_custom_11);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_11", createCurriculumStatus.s_curr_status_desc_custom_11);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_12", createCurriculumStatus.s_curr_status_name_custom_12);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_12", createCurriculumStatus.s_curr_status_desc_custom_12);
            htCreateCurriculumStatus.Add("@s_curr_status_name_custom_13", createCurriculumStatus.s_curr_status_name_custom_13);
            htCreateCurriculumStatus.Add("@s_curr_status_desc_custom_13", createCurriculumStatus.s_curr_status_desc_custom_13);

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
            htUpdateCurriculumStatus.Add("@s_curr_status_system_id_pk", updateCurriculumStatus.s_curr_status_system_id_pk);
            htUpdateCurriculumStatus.Add("@s_curr_status_id", updateCurriculumStatus.s_curr_status_id);
            if (updateCurriculumStatus.s_curr_status_status_id_fk == "0")
                htUpdateCurriculumStatus.Add("@s_curr_status_status_id_fk", DBNull.Value);
            else
                htUpdateCurriculumStatus.Add("@s_curr_status_status_id_fk", updateCurriculumStatus.s_curr_status_status_id_fk);

            htUpdateCurriculumStatus.Add("@s_curr_status_name_us_english", updateCurriculumStatus.s_curr_status_name_us_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_us_english", updateCurriculumStatus.s_curr_status_desc_us_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_uk_english", updateCurriculumStatus.s_curr_status_name_uk_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_uk_english", updateCurriculumStatus.s_curr_status_desc_uk_english);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_ca_france", updateCurriculumStatus.s_curr_status_name_ca_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_ca_france", updateCurriculumStatus.s_curr_status_desc_ca_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_fr_french", updateCurriculumStatus.s_curr_status_name_fr_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_fr_french", updateCurriculumStatus.s_curr_status_desc_fr_french);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_mx_spanish", updateCurriculumStatus.s_curr_status_name_mx_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_mx_spanish", updateCurriculumStatus.s_curr_status_desc_mx_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_sp_spanish", updateCurriculumStatus.s_curr_status_name_sp_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_sp_spanish", updateCurriculumStatus.s_curr_status_desc_sp_spanish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_portuguse", updateCurriculumStatus.s_curr_status_name_portuguese);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_portuguse", updateCurriculumStatus.s_curr_status_desc_portuguese);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_chinese", updateCurriculumStatus.s_curr_status_name_simp_chinese);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_chinese", updateCurriculumStatus.s_curr_status_desc_simp_chinese);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_german", updateCurriculumStatus.s_curr_status_name_german);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_german", updateCurriculumStatus.s_curr_status_desc_german);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_japanese", updateCurriculumStatus.s_curr_status_name_japanese);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_japanese", updateCurriculumStatus.s_curr_status_desc_japanese);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_russian", updateCurriculumStatus.s_curr_status_name_russian);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_russian", updateCurriculumStatus.s_curr_status_desc_russian);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_danish", updateCurriculumStatus.s_curr_status_name_danish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_danish", updateCurriculumStatus.s_curr_status_desc_danish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_polish", updateCurriculumStatus.s_curr_status_name_polish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_polish", updateCurriculumStatus.s_curr_status_desc_polish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_swedish", updateCurriculumStatus.s_curr_status_name_swedish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_swedish", updateCurriculumStatus.s_curr_status_desc_swedish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_finnish", updateCurriculumStatus.s_curr_status_name_finnish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_finnish", updateCurriculumStatus.s_curr_status_desc_finnish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_korean", updateCurriculumStatus.s_curr_status_name_korean);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_korean", updateCurriculumStatus.s_curr_status_desc_korean);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_italian", updateCurriculumStatus.s_curr_status_name_italian);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_italian", updateCurriculumStatus.s_curr_status_desc_italian);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_dutch", updateCurriculumStatus.s_curr_status_name_dutch);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_dutch", updateCurriculumStatus.s_curr_status_desc_dutch);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_indonesian", updateCurriculumStatus.s_curr_status_name_indonesian);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_indonesian", updateCurriculumStatus.s_curr_status_desc_indonesian);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_greek", updateCurriculumStatus.s_curr_status_name_greek);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_greek", updateCurriculumStatus.s_curr_status_desc_greek);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_hungarian", updateCurriculumStatus.s_curr_status_name_hungarian);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_hungarian", updateCurriculumStatus.s_curr_status_desc_hungarian);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_norwegian", updateCurriculumStatus.s_curr_status_name_norwegian);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_norwegian", updateCurriculumStatus.s_curr_status_desc_norwegian);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_turkish", updateCurriculumStatus.s_curr_status_name_turkish);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_turkish", updateCurriculumStatus.s_curr_status_desc_turkish);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_arabic", updateCurriculumStatus.s_curr_status_name_arabic_rtl);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_arabic", updateCurriculumStatus.s_curr_status_desc_arabic_rtl);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_01", updateCurriculumStatus.s_curr_status_name_custom_01);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_01", updateCurriculumStatus.s_curr_status_desc_custom_01);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_02", updateCurriculumStatus.s_curr_status_name_custom_02);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_02", updateCurriculumStatus.s_curr_status_desc_custom_02);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_03", updateCurriculumStatus.s_curr_status_name_custom_03);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_03", updateCurriculumStatus.s_curr_status_desc_custom_03);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_04", updateCurriculumStatus.s_curr_status_name_custom_04);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_04", updateCurriculumStatus.s_curr_status_desc_custom_04);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_05", updateCurriculumStatus.s_curr_status_name_custom_05);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_05", updateCurriculumStatus.s_curr_status_desc_custom_05);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_06", updateCurriculumStatus.s_curr_status_name_custom_06);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_06", updateCurriculumStatus.s_curr_status_desc_custom_06);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_07", updateCurriculumStatus.s_curr_status_name_custom_07);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_07", updateCurriculumStatus.s_curr_status_desc_custom_07);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_08", updateCurriculumStatus.s_curr_status_name_custom_08);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_08", updateCurriculumStatus.s_curr_status_desc_custom_08);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_09", updateCurriculumStatus.s_curr_status_name_custom_09);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_09", updateCurriculumStatus.s_curr_status_desc_custom_09);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_10", updateCurriculumStatus.s_curr_status_name_custom_10);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_10", updateCurriculumStatus.s_curr_status_desc_custom_10);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_11", updateCurriculumStatus.s_curr_status_name_custom_11);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_11", updateCurriculumStatus.s_curr_status_desc_custom_11);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_12", updateCurriculumStatus.s_curr_status_name_custom_12);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_12", updateCurriculumStatus.s_curr_status_desc_custom_12);
            htUpdateCurriculumStatus.Add("@s_curr_status_name_custom_13", updateCurriculumStatus.s_curr_status_name_custom_13);
            htUpdateCurriculumStatus.Add("@s_curr_status_desc_custom_13", updateCurriculumStatus.s_curr_status_desc_custom_13);
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
            htCurriculumStatus.Add("@s_curr_status_id", curriculumStatus.s_curr_status_id);
            htCurriculumStatus.Add("@s_curr_status_name_us_english", curriculumStatus.s_curr_status_name_us_english);
            if (curriculumStatus.s_curr_status_status_id_fk == "0")
                htCurriculumStatus.Add("@s_curr_status_status_id_fk", DBNull.Value);
            else
                htCurriculumStatus.Add("@s_curr_status_status_id_fk", curriculumStatus.s_curr_status_status_id_fk);

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

        public static SystemCurriculumStatus GetCurriculumStatus(string s_curr_status_system_id_pk)
        {
            SystemCurriculumStatus curriculumStatus;
            try
            {
                Hashtable htGetCurriculumTypes = new Hashtable();
                htGetCurriculumTypes.Add("@s_curr_status_system_id_pk", s_curr_status_system_id_pk);
                curriculumStatus = new SystemCurriculumStatus();
                DataTable dtGetCurriculumType = DataProxy.FetchDataTable("s_sp_get_single_curriculum_status", htGetCurriculumTypes);
                curriculumStatus.s_curr_status_id = dtGetCurriculumType.Rows[0]["s_curr_status_id"].ToString();
                curriculumStatus.s_curr_status_status_id_fk = dtGetCurriculumType.Rows[0]["s_curr_status_status_id_fk"].ToString();
                curriculumStatus.s_curr_status_name_us_english = dtGetCurriculumType.Rows[0]["s_curr_status_name_us_english"].ToString();
                curriculumStatus.s_curr_status_desc_us_english = dtGetCurriculumType.Rows[0]["s_curr_status_desc_us_english"].ToString();
                curriculumStatus.s_curr_status_name_uk_english = dtGetCurriculumType.Rows[0]["s_curr_status_name_uk_english"].ToString();
                curriculumStatus.s_curr_status_desc_uk_english = dtGetCurriculumType.Rows[0]["s_curr_status_desc_uk_english"].ToString();
                curriculumStatus.s_curr_status_name_ca_french = dtGetCurriculumType.Rows[0]["s_curr_status_name_ca_france"].ToString();
                curriculumStatus.s_curr_status_desc_ca_french = dtGetCurriculumType.Rows[0]["s_curr_status_desc_ca_france"].ToString();
                curriculumStatus.s_curr_status_name_fr_french = dtGetCurriculumType.Rows[0]["s_curr_status_name_fr_french"].ToString();
                curriculumStatus.s_curr_status_desc_fr_french = dtGetCurriculumType.Rows[0]["s_curr_status_desc_fr_french"].ToString();
                curriculumStatus.s_curr_status_name_mx_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_name_mx_spanish"].ToString();
                curriculumStatus.s_curr_status_desc_mx_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_mx_spanish"].ToString();
                curriculumStatus.s_curr_status_name_sp_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_name_sp_spanish"].ToString();
                curriculumStatus.s_curr_status_desc_sp_spanish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_sp_spanish"].ToString();
                curriculumStatus.s_curr_status_name_portuguese = dtGetCurriculumType.Rows[0]["s_curr_status_name_portuguse"].ToString();
                curriculumStatus.s_curr_status_desc_portuguese = dtGetCurriculumType.Rows[0]["s_curr_status_desc_portuguse"].ToString();
                curriculumStatus.s_curr_status_name_simp_chinese = dtGetCurriculumType.Rows[0]["s_curr_status_name_chinese"].ToString();
                curriculumStatus.s_curr_status_desc_simp_chinese = dtGetCurriculumType.Rows[0]["s_curr_status_desc_chinese"].ToString();
                curriculumStatus.s_curr_status_name_german = dtGetCurriculumType.Rows[0]["s_curr_status_name_german"].ToString();
                curriculumStatus.s_curr_status_desc_german = dtGetCurriculumType.Rows[0]["s_curr_status_desc_german"].ToString();
                curriculumStatus.s_curr_status_name_japanese = dtGetCurriculumType.Rows[0]["s_curr_status_name_japanese"].ToString();
                curriculumStatus.s_curr_status_desc_japanese = dtGetCurriculumType.Rows[0]["s_curr_status_desc_japanese"].ToString();
                curriculumStatus.s_curr_status_name_russian = dtGetCurriculumType.Rows[0]["s_curr_status_name_russian"].ToString();
                curriculumStatus.s_curr_status_desc_russian = dtGetCurriculumType.Rows[0]["s_curr_status_desc_russian"].ToString();
                curriculumStatus.s_curr_status_name_danish = dtGetCurriculumType.Rows[0]["s_curr_status_name_danish"].ToString();
                curriculumStatus.s_curr_status_desc_danish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_danish"].ToString();
                curriculumStatus.s_curr_status_name_polish = dtGetCurriculumType.Rows[0]["s_curr_status_name_polish"].ToString();
                curriculumStatus.s_curr_status_desc_polish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_polish"].ToString();
                curriculumStatus.s_curr_status_name_swedish = dtGetCurriculumType.Rows[0]["s_curr_status_name_swedish"].ToString();
                curriculumStatus.s_curr_status_desc_swedish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_swedish"].ToString();
                curriculumStatus.s_curr_status_name_finnish = dtGetCurriculumType.Rows[0]["s_curr_status_name_finnish"].ToString();
                curriculumStatus.s_curr_status_desc_finnish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_finnish"].ToString();
                curriculumStatus.s_curr_status_name_korean = dtGetCurriculumType.Rows[0]["s_curr_status_name_korean"].ToString();
                curriculumStatus.s_curr_status_desc_korean = dtGetCurriculumType.Rows[0]["s_curr_status_desc_korean"].ToString();
                curriculumStatus.s_curr_status_name_italian = dtGetCurriculumType.Rows[0]["s_curr_status_name_italian"].ToString();
                curriculumStatus.s_curr_status_desc_italian = dtGetCurriculumType.Rows[0]["s_curr_status_desc_italian"].ToString();
                curriculumStatus.s_curr_status_name_dutch = dtGetCurriculumType.Rows[0]["s_curr_status_name_dutch"].ToString();
                curriculumStatus.s_curr_status_desc_dutch = dtGetCurriculumType.Rows[0]["s_curr_status_desc_dutch"].ToString();
                curriculumStatus.s_curr_status_name_indonesian = dtGetCurriculumType.Rows[0]["s_curr_status_name_indonesian"].ToString();
                curriculumStatus.s_curr_status_desc_indonesian = dtGetCurriculumType.Rows[0]["s_curr_status_desc_indonesian"].ToString();
                curriculumStatus.s_curr_status_name_greek = dtGetCurriculumType.Rows[0]["s_curr_status_name_greek"].ToString();
                curriculumStatus.s_curr_status_desc_greek = dtGetCurriculumType.Rows[0]["s_curr_status_desc_greek"].ToString();
                curriculumStatus.s_curr_status_name_hungarian = dtGetCurriculumType.Rows[0]["s_curr_status_name_hungarian"].ToString();
                curriculumStatus.s_curr_status_desc_hungarian = dtGetCurriculumType.Rows[0]["s_curr_status_desc_hungarian"].ToString();
                curriculumStatus.s_curr_status_name_norwegian = dtGetCurriculumType.Rows[0]["s_curr_status_name_norwegian"].ToString();
                curriculumStatus.s_curr_status_desc_norwegian = dtGetCurriculumType.Rows[0]["s_curr_status_desc_norwegian"].ToString();
                curriculumStatus.s_curr_status_name_turkish = dtGetCurriculumType.Rows[0]["s_curr_status_name_turkish"].ToString();
                curriculumStatus.s_curr_status_desc_turkish = dtGetCurriculumType.Rows[0]["s_curr_status_desc_turkish"].ToString();
                curriculumStatus.s_curr_status_name_arabic_rtl = dtGetCurriculumType.Rows[0]["s_curr_status_name_arabic"].ToString();
                curriculumStatus.s_curr_status_desc_arabic_rtl = dtGetCurriculumType.Rows[0]["s_curr_status_desc_arabic"].ToString();
                curriculumStatus.s_curr_status_name_custom_01 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_01"].ToString();
                curriculumStatus.s_curr_status_desc_custom_01 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_01"].ToString();
                curriculumStatus.s_curr_status_name_custom_02 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_02"].ToString();
                curriculumStatus.s_curr_status_desc_custom_02 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_02"].ToString();
                curriculumStatus.s_curr_status_name_custom_03 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_03"].ToString();
                curriculumStatus.s_curr_status_desc_custom_03 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_03"].ToString();
                curriculumStatus.s_curr_status_name_custom_04 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_04"].ToString();
                curriculumStatus.s_curr_status_desc_custom_04 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_04"].ToString();
                curriculumStatus.s_curr_status_name_custom_05 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_05"].ToString();
                curriculumStatus.s_curr_status_desc_custom_05 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_05"].ToString();
                curriculumStatus.s_curr_status_name_custom_06 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_06"].ToString();
                curriculumStatus.s_curr_status_desc_custom_06 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_06"].ToString();
                curriculumStatus.s_curr_status_name_custom_07 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_07"].ToString();
                curriculumStatus.s_curr_status_desc_custom_07 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_07"].ToString();
                curriculumStatus.s_curr_status_name_custom_08 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_08"].ToString();
                curriculumStatus.s_curr_status_desc_custom_08 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_08"].ToString();
                curriculumStatus.s_curr_status_name_custom_09 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_09"].ToString();
                curriculumStatus.s_curr_status_desc_custom_09 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_09"].ToString();
                curriculumStatus.s_curr_status_name_custom_10 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_10"].ToString();
                curriculumStatus.s_curr_status_desc_custom_10 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_10"].ToString();
                curriculumStatus.s_curr_status_name_custom_11 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_11"].ToString();
                curriculumStatus.s_curr_status_desc_custom_11 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_11"].ToString();
                curriculumStatus.s_curr_status_name_custom_12 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_12"].ToString();
                curriculumStatus.s_curr_status_desc_custom_12 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_12"].ToString();
                curriculumStatus.s_curr_status_name_custom_13 = dtGetCurriculumType.Rows[0]["s_curr_status_name_custom_13"].ToString();
                curriculumStatus.s_curr_status_desc_custom_13 = dtGetCurriculumType.Rows[0]["s_curr_status_desc_custom_13"].ToString();


                return curriculumStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateCurriculumStatusType(string s_curr_status_system_id_pk)
        {
            Hashtable htUpdateCurriculumStatus = new Hashtable();
            htUpdateCurriculumStatus.Add("@s_curr_status_system_id_pk", s_curr_status_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_archive_curriculum_status", htUpdateCurriculumStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
