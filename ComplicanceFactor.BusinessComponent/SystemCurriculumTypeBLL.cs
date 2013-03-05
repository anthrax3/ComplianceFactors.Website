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
    public class SystemCurriculumTypeBLL
    {
        /// <summary>
        /// Create Curriculum Types
        /// </summary>
        /// <param name="createCurriculumTypes"></param>
        /// <returns></returns>
        public static int CreateCurriculumTypes(SystemCurriculumType createCurriculumTypes)
        {
            Hashtable htCreateCurriculumTypes = new Hashtable();

            htCreateCurriculumTypes.Add("@s_curriculum_type_system_id_pk", createCurriculumTypes.s_curriculum_type_system_id_pk);
            htCreateCurriculumTypes.Add("@s_curriculum_type_id", createCurriculumTypes.s_curriculum_type_id);
            if (createCurriculumTypes.s_curriculum_type_status_id_fk == "0")
                htCreateCurriculumTypes.Add("@s_curriculum_type_status_id_fk", DBNull.Value);
            else
                htCreateCurriculumTypes.Add("@s_curriculum_type_status_id_fk", createCurriculumTypes.s_curriculum_type_status_id_fk);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_us_english", createCurriculumTypes.s_curriculum_type_name_us_english);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_us_english", createCurriculumTypes.s_curriculum_type_desc_us_english);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_uk_english", createCurriculumTypes.s_curriculum_type_name_uk_english);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_uk_english", createCurriculumTypes.s_curriculum_type_desc_uk_english);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_ca_french", createCurriculumTypes.s_curriculum_type_name_ca_french);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_ca_french", createCurriculumTypes.s_curriculum_type_desc_ca_french);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_fr_french", createCurriculumTypes.s_curriculum_type_name_fr_french);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_fr_french", createCurriculumTypes.s_curriculum_type_desc_fr_french);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_mx_spanish", createCurriculumTypes.s_curriculum_type_name_mx_spanish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_mx_spanish", createCurriculumTypes.s_curriculum_type_desc_mx_spanish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_sp_spanish", createCurriculumTypes.s_curriculum_type_name_sp_spanish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_sp_spanish", createCurriculumTypes.s_curriculum_type_desc_sp_spanish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_portuguese", createCurriculumTypes.s_curriculum_type_name_portuguese);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_portuguese", createCurriculumTypes.s_curriculum_type_desc_portuguese);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_simp_chinese", createCurriculumTypes.s_curriculum_type_name_simp_chinese);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_simp_chinese", createCurriculumTypes.s_curriculum_type_desc_simp_chinese);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_german", createCurriculumTypes.s_curriculum_type_name_german);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_german", createCurriculumTypes.s_curriculum_type_desc_german);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_japanese", createCurriculumTypes.s_curriculum_type_name_japanese);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_japanese", createCurriculumTypes.s_curriculum_type_desc_japanese);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_russian", createCurriculumTypes.s_curriculum_type_name_russian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_russian", createCurriculumTypes.s_curriculum_type_desc_russian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_danish", createCurriculumTypes.s_curriculum_type_name_danish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_danish", createCurriculumTypes.s_curriculum_type_desc_danish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_polish", createCurriculumTypes.s_curriculum_type_name_polish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_polish", createCurriculumTypes.s_curriculum_type_desc_polish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_swedish", createCurriculumTypes.s_curriculum_type_name_swedish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_swedish", createCurriculumTypes.s_curriculum_type_desc_swedish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_finnish", createCurriculumTypes.s_curriculum_type_name_finnish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_finnish", createCurriculumTypes.s_curriculum_type_desc_finnish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_korean", createCurriculumTypes.s_curriculum_type_name_korean);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_korean", createCurriculumTypes.s_curriculum_type_desc_korean);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_italian", createCurriculumTypes.s_curriculum_type_name_italian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_italian", createCurriculumTypes.s_curriculum_type_desc_italian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_dutch", createCurriculumTypes.s_curriculum_type_name_dutch);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_dutch", createCurriculumTypes.s_curriculum_type_desc_dutch);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_indonesian", createCurriculumTypes.s_curriculum_type_name_indonesian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_indonesian", createCurriculumTypes.s_curriculum_type_desc_indonesian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_greek", createCurriculumTypes.s_curriculum_type_name_greek);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_greek", createCurriculumTypes.s_curriculum_type_desc_greek);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_hungarian", createCurriculumTypes.s_curriculum_type_name_hungarian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_hungarian", createCurriculumTypes.s_curriculum_type_desc_hungarian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_norwegian", createCurriculumTypes.s_curriculum_type_name_norwegian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_norwegian", createCurriculumTypes.s_curriculum_type_desc_norwegian);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_turkish", createCurriculumTypes.s_curriculum_type_name_turkish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_turkish", createCurriculumTypes.s_curriculum_type_desc_turkish);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_arabic_rtl", createCurriculumTypes.s_curriculum_type_name_arabic_rtl);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_arabic_rtl", createCurriculumTypes.s_curriculum_type_desc_arabic_rtl);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_01", createCurriculumTypes.s_curriculum_type_name_custom_01);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_01", createCurriculumTypes.s_curriculum_type_desc_custom_01);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_02", createCurriculumTypes.s_curriculum_type_name_custom_02);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_02", createCurriculumTypes.s_curriculum_type_desc_custom_02);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_03", createCurriculumTypes.s_curriculum_type_name_custom_03);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_03", createCurriculumTypes.s_curriculum_type_desc_custom_03);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_04", createCurriculumTypes.s_curriculum_type_name_custom_04);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_04", createCurriculumTypes.s_curriculum_type_desc_custom_04);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_05", createCurriculumTypes.s_curriculum_type_name_custom_05);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_05", createCurriculumTypes.s_curriculum_type_desc_custom_05);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_06", createCurriculumTypes.s_curriculum_type_name_custom_06);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_06", createCurriculumTypes.s_curriculum_type_desc_custom_06);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_07", createCurriculumTypes.s_curriculum_type_name_custom_07);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_07", createCurriculumTypes.s_curriculum_type_desc_custom_07);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_08", createCurriculumTypes.s_curriculum_type_name_custom_08);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_08", createCurriculumTypes.s_curriculum_type_desc_custom_08);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_09", createCurriculumTypes.s_curriculum_type_name_custom_09);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_09", createCurriculumTypes.s_curriculum_type_desc_custom_09);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_10", createCurriculumTypes.s_curriculum_type_name_custom_10);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_10", createCurriculumTypes.s_curriculum_type_desc_custom_10);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_11", createCurriculumTypes.s_curriculum_type_name_custom_11);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_11", createCurriculumTypes.s_curriculum_type_desc_custom_11);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_12", createCurriculumTypes.s_curriculum_type_name_custom_12);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_12", createCurriculumTypes.s_curriculum_type_desc_custom_12);
            htCreateCurriculumTypes.Add("@s_curriculum_type_name_custom_13", createCurriculumTypes.s_curriculum_type_name_custom_13);
            htCreateCurriculumTypes.Add("@s_curriculum_type_desc_custom_13", createCurriculumTypes.s_curriculum_type_desc_custom_13);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_curriculum_types", htCreateCurriculumTypes);
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
        public static int UpdateCurriculumTypes(SystemCurriculumType updateCurriculumTypes)
        {
            Hashtable htUpdateCurriculumTypes = new Hashtable();
            htUpdateCurriculumTypes.Add("@s_curriculum_type_system_id_pk", updateCurriculumTypes.s_curriculum_type_system_id_pk);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_id", updateCurriculumTypes.s_curriculum_type_id);
            if (updateCurriculumTypes.s_curriculum_type_status_id_fk == "0")
                htUpdateCurriculumTypes.Add("@s_curriculum_type_status_id_fk", DBNull.Value);
            else
                htUpdateCurriculumTypes.Add("@s_curriculum_type_status_id_fk", updateCurriculumTypes.s_curriculum_type_status_id_fk);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_us_english", updateCurriculumTypes.s_curriculum_type_name_us_english);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_us_english", updateCurriculumTypes.s_curriculum_type_desc_us_english);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_uk_english", updateCurriculumTypes.s_curriculum_type_name_uk_english);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_uk_english", updateCurriculumTypes.s_curriculum_type_desc_uk_english);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_ca_french", updateCurriculumTypes.s_curriculum_type_name_ca_french);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_ca_french", updateCurriculumTypes.s_curriculum_type_desc_ca_french);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_fr_french", updateCurriculumTypes.s_curriculum_type_name_fr_french);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_fr_french", updateCurriculumTypes.s_curriculum_type_desc_fr_french);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_mx_spanish", updateCurriculumTypes.s_curriculum_type_name_mx_spanish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_mx_spanish", updateCurriculumTypes.s_curriculum_type_desc_mx_spanish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_sp_spanish", updateCurriculumTypes.s_curriculum_type_name_sp_spanish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_sp_spanish", updateCurriculumTypes.s_curriculum_type_desc_sp_spanish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_portuguese", updateCurriculumTypes.s_curriculum_type_name_portuguese);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_portuguese", updateCurriculumTypes.s_curriculum_type_desc_portuguese);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_simp_chinese", updateCurriculumTypes.s_curriculum_type_name_simp_chinese);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_simp_chinese", updateCurriculumTypes.s_curriculum_type_desc_simp_chinese);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_german", updateCurriculumTypes.s_curriculum_type_name_german);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_german", updateCurriculumTypes.s_curriculum_type_desc_german);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_japanese", updateCurriculumTypes.s_curriculum_type_name_japanese);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_japanese", updateCurriculumTypes.s_curriculum_type_desc_japanese);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_russian", updateCurriculumTypes.s_curriculum_type_name_russian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_russian", updateCurriculumTypes.s_curriculum_type_desc_russian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_danish", updateCurriculumTypes.s_curriculum_type_name_danish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_danish", updateCurriculumTypes.s_curriculum_type_desc_danish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_polish", updateCurriculumTypes.s_curriculum_type_name_polish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_polish", updateCurriculumTypes.s_curriculum_type_desc_polish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_swedish", updateCurriculumTypes.s_curriculum_type_name_swedish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_swedish", updateCurriculumTypes.s_curriculum_type_desc_swedish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_finnish", updateCurriculumTypes.s_curriculum_type_name_finnish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_finnish", updateCurriculumTypes.s_curriculum_type_desc_finnish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_korean", updateCurriculumTypes.s_curriculum_type_name_korean);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_korean", updateCurriculumTypes.s_curriculum_type_desc_korean);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_italian", updateCurriculumTypes.s_curriculum_type_name_italian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_italian", updateCurriculumTypes.s_curriculum_type_desc_italian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_dutch", updateCurriculumTypes.s_curriculum_type_name_dutch);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_dutch", updateCurriculumTypes.s_curriculum_type_desc_dutch);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_indonesian", updateCurriculumTypes.s_curriculum_type_name_indonesian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_indonesian", updateCurriculumTypes.s_curriculum_type_desc_indonesian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_greek", updateCurriculumTypes.s_curriculum_type_name_greek);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_greek", updateCurriculumTypes.s_curriculum_type_desc_greek);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_hungarian", updateCurriculumTypes.s_curriculum_type_name_hungarian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_hungarian", updateCurriculumTypes.s_curriculum_type_desc_hungarian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_norwegian", updateCurriculumTypes.s_curriculum_type_name_norwegian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_norwegian", updateCurriculumTypes.s_curriculum_type_desc_norwegian);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_turkish", updateCurriculumTypes.s_curriculum_type_name_turkish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_turkish", updateCurriculumTypes.s_curriculum_type_desc_turkish);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_arabic_rtl", updateCurriculumTypes.s_curriculum_type_name_arabic_rtl);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_arabic_rtl", updateCurriculumTypes.s_curriculum_type_desc_arabic_rtl);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_01", updateCurriculumTypes.s_curriculum_type_name_custom_01);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_01", updateCurriculumTypes.s_curriculum_type_desc_custom_01);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_02", updateCurriculumTypes.s_curriculum_type_name_custom_02);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_02", updateCurriculumTypes.s_curriculum_type_desc_custom_02);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_03", updateCurriculumTypes.s_curriculum_type_name_custom_03);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_03", updateCurriculumTypes.s_curriculum_type_desc_custom_03);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_04", updateCurriculumTypes.s_curriculum_type_name_custom_04);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_04", updateCurriculumTypes.s_curriculum_type_desc_custom_04);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_05", updateCurriculumTypes.s_curriculum_type_name_custom_05);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_05", updateCurriculumTypes.s_curriculum_type_desc_custom_05);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_06", updateCurriculumTypes.s_curriculum_type_name_custom_06);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_06", updateCurriculumTypes.s_curriculum_type_desc_custom_06);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_07", updateCurriculumTypes.s_curriculum_type_name_custom_07);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_07", updateCurriculumTypes.s_curriculum_type_desc_custom_07);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_08", updateCurriculumTypes.s_curriculum_type_name_custom_08);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_08", updateCurriculumTypes.s_curriculum_type_desc_custom_08);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_09", updateCurriculumTypes.s_curriculum_type_name_custom_09);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_09", updateCurriculumTypes.s_curriculum_type_desc_custom_09);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_10", updateCurriculumTypes.s_curriculum_type_name_custom_10);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_10", updateCurriculumTypes.s_curriculum_type_desc_custom_10);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_11", updateCurriculumTypes.s_curriculum_type_name_custom_11);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_11", updateCurriculumTypes.s_curriculum_type_desc_custom_11);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_12", updateCurriculumTypes.s_curriculum_type_name_custom_12);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_12", updateCurriculumTypes.s_curriculum_type_desc_custom_12);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_name_custom_13", updateCurriculumTypes.s_curriculum_type_name_custom_13);
            htUpdateCurriculumTypes.Add("@s_curriculum_type_desc_custom_13", updateCurriculumTypes.s_curriculum_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_types", htUpdateCurriculumTypes);
            }
            catch (Exception)
            {
                throw;
            }



        }

        public static DataTable SearchCurriculumTypes(SystemCurriculumType curriculumType)
        {
            Hashtable htCurriculumType = new Hashtable();
            htCurriculumType.Add("@s_curriculum_type_id", curriculumType.s_curriculum_type_id);
            htCurriculumType.Add("@s_curriculum_type_name_us_english", curriculumType.s_curriculum_type_name_us_english);
            if (curriculumType.s_curriculum_type_status_id_fk == "0")
                htCurriculumType.Add("@s_curriculum_type_status_id_fk", DBNull.Value);
            else
                htCurriculumType.Add("@s_curriculum_type_status_id_fk", curriculumType.s_curriculum_type_status_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_curriculum_type", htCurriculumType);
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

        public static SystemCurriculumType GetCurriculumType(string s_curriculum_type_system_id_pk)
        {
            SystemCurriculumType curriculumType;
            try
            {
                Hashtable htGetCurriculumTypes = new Hashtable();
                htGetCurriculumTypes.Add("@s_curriculum_type_system_id_pk", s_curriculum_type_system_id_pk);
                curriculumType = new SystemCurriculumType();
                DataTable dtGetCurriculumType = DataProxy.FetchDataTable("s_sp_get_single_curriculum_type", htGetCurriculumTypes);
                curriculumType.s_curriculum_type_id = dtGetCurriculumType.Rows[0]["s_curriculum_type_id"].ToString();
                curriculumType.s_curriculum_type_status_id_fk = dtGetCurriculumType.Rows[0]["s_curriculum_type_status_id_fk"].ToString();
                curriculumType.s_curriculum_type_name_us_english = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_us_english"].ToString();
                curriculumType.s_curriculum_type_desc_us_english = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_us_english"].ToString();
                curriculumType.s_curriculum_type_name_uk_english = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_uk_english"].ToString();
                curriculumType.s_curriculum_type_desc_uk_english = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_uk_english"].ToString();
                curriculumType.s_curriculum_type_name_ca_french = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_ca_french"].ToString();
                curriculumType.s_curriculum_type_desc_ca_french = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_ca_french"].ToString();
                curriculumType.s_curriculum_type_name_fr_french = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_fr_french"].ToString();
                curriculumType.s_curriculum_type_desc_fr_french = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_fr_french"].ToString();
                curriculumType.s_curriculum_type_name_mx_spanish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_mx_spanish"].ToString();
                curriculumType.s_curriculum_type_desc_mx_spanish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_mx_spanish"].ToString();
                curriculumType.s_curriculum_type_name_sp_spanish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_sp_spanish"].ToString();
                curriculumType.s_curriculum_type_desc_sp_spanish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_sp_spanish"].ToString();
                curriculumType.s_curriculum_type_name_portuguese = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_portuguese"].ToString();
                curriculumType.s_curriculum_type_desc_portuguese = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_portuguese"].ToString();
                curriculumType.s_curriculum_type_name_simp_chinese = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_simp_chinese"].ToString();
                curriculumType.s_curriculum_type_desc_simp_chinese = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_simp_chinese"].ToString();
                curriculumType.s_curriculum_type_name_german = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_german"].ToString();
                curriculumType.s_curriculum_type_desc_german = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_german"].ToString();
                curriculumType.s_curriculum_type_name_japanese = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_japanese"].ToString();
                curriculumType.s_curriculum_type_desc_japanese = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_japanese"].ToString();
                curriculumType.s_curriculum_type_name_russian = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_russian"].ToString();
                curriculumType.s_curriculum_type_desc_russian = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_russian"].ToString();
                curriculumType.s_curriculum_type_name_danish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_danish"].ToString();
                curriculumType.s_curriculum_type_desc_danish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_danish"].ToString();
                curriculumType.s_curriculum_type_name_polish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_polish"].ToString();
                curriculumType.s_curriculum_type_desc_polish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_polish"].ToString();
                curriculumType.s_curriculum_type_name_swedish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_swedish"].ToString();
                curriculumType.s_curriculum_type_desc_swedish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_swedish"].ToString();
                curriculumType.s_curriculum_type_name_finnish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_finnish"].ToString();
                curriculumType.s_curriculum_type_desc_finnish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_finnish"].ToString();
                curriculumType.s_curriculum_type_name_korean = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_korean"].ToString();
                curriculumType.s_curriculum_type_desc_korean = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_korean"].ToString();
                curriculumType.s_curriculum_type_name_italian = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_italian"].ToString();
                curriculumType.s_curriculum_type_desc_italian = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_italian"].ToString();
                curriculumType.s_curriculum_type_name_dutch = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_dutch"].ToString();
                curriculumType.s_curriculum_type_desc_dutch = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_dutch"].ToString();
                curriculumType.s_curriculum_type_name_indonesian = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_indonesian"].ToString();
                curriculumType.s_curriculum_type_desc_indonesian = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_indonesian"].ToString();
                curriculumType.s_curriculum_type_name_greek = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_greek"].ToString();
                curriculumType.s_curriculum_type_desc_greek = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_greek"].ToString();
                curriculumType.s_curriculum_type_name_hungarian = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_hungarian"].ToString();
                curriculumType.s_curriculum_type_desc_hungarian = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_hungarian"].ToString();
                curriculumType.s_curriculum_type_name_norwegian = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_norwegian"].ToString();
                curriculumType.s_curriculum_type_desc_norwegian = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_norwegian"].ToString();
                curriculumType.s_curriculum_type_name_turkish = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_turkish"].ToString();
                curriculumType.s_curriculum_type_desc_turkish = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_turkish"].ToString();
                curriculumType.s_curriculum_type_name_arabic_rtl = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_arabic_rtl"].ToString();
                curriculumType.s_curriculum_type_desc_arabic_rtl = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_arabic_rtl"].ToString();
                curriculumType.s_curriculum_type_name_custom_01 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_01"].ToString();
                curriculumType.s_curriculum_type_desc_custom_01 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_01"].ToString();
                curriculumType.s_curriculum_type_name_custom_02 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_02"].ToString();
                curriculumType.s_curriculum_type_desc_custom_02 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_02"].ToString();
                curriculumType.s_curriculum_type_name_custom_03 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_03"].ToString();
                curriculumType.s_curriculum_type_desc_custom_03 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_03"].ToString();
                curriculumType.s_curriculum_type_name_custom_04 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_04"].ToString();
                curriculumType.s_curriculum_type_desc_custom_04 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_04"].ToString();
                curriculumType.s_curriculum_type_name_custom_05 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_05"].ToString();
                curriculumType.s_curriculum_type_desc_custom_05 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_05"].ToString();
                curriculumType.s_curriculum_type_name_custom_06 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_06"].ToString();
                curriculumType.s_curriculum_type_desc_custom_06 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_06"].ToString();
                curriculumType.s_curriculum_type_name_custom_07 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_07"].ToString();
                curriculumType.s_curriculum_type_desc_custom_07 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_07"].ToString();
                curriculumType.s_curriculum_type_name_custom_08 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_08"].ToString();
                curriculumType.s_curriculum_type_desc_custom_08 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_08"].ToString();
                curriculumType.s_curriculum_type_name_custom_09 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_09"].ToString();
                curriculumType.s_curriculum_type_desc_custom_09 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_09"].ToString();
                curriculumType.s_curriculum_type_name_custom_10 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_10"].ToString();
                curriculumType.s_curriculum_type_desc_custom_10 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_10"].ToString();
                curriculumType.s_curriculum_type_name_custom_11 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_11"].ToString();
                curriculumType.s_curriculum_type_desc_custom_11 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_11"].ToString();
                curriculumType.s_curriculum_type_name_custom_12 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_12"].ToString();
                curriculumType.s_curriculum_type_desc_custom_12 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_12"].ToString();
                curriculumType.s_curriculum_type_name_custom_13 = dtGetCurriculumType.Rows[0]["s_curriculum_type_name_custom_13"].ToString();
                curriculumType.s_curriculum_type_desc_custom_13 = dtGetCurriculumType.Rows[0]["s_curriculum_type_desc_custom_13"].ToString();


                return curriculumType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateCurriculumTypeStatus(string s_curriculum_type_system_id_pk)
        {
            Hashtable htUpdateCurriculumStatus = new Hashtable();
            htUpdateCurriculumStatus.Add("@s_curriculum_type_system_id_pk", s_curriculum_type_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_type_status", htUpdateCurriculumStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
