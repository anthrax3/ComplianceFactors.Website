using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemCategoriesBLL
    {
        /// <summary>
        /// Search Categories
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public static DataTable SearchCategories(SystemCategories categories)
        {

            Hashtable htSearchCategories = new Hashtable();
            htSearchCategories.Add("@s_category_id", categories.s_category_id);
            htSearchCategories.Add("@s_category_name_us_english", categories.s_category_name_us_english);

            if (categories.s_parent_category_id == "0")
                htSearchCategories.Add("@s_parent_category_id", DBNull.Value);
            else
                htSearchCategories.Add("@s_parent_category_id", categories.s_parent_category_id);

            if (categories.s_category_status_id_fk == "0")
                htSearchCategories.Add("@s_category_status_id_fk", DBNull.Value);
            else
                htSearchCategories.Add("@s_category_status_id_fk", categories.s_category_status_id_fk);



            try
            {
                return DataProxy.FetchDataTable("s_sp_search_categories", htSearchCategories);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        public static int DeleteCategory(SystemCategories categories)
        {
            Hashtable htDeleteCategory = new Hashtable();
            htDeleteCategory.Add("@s_category_system_id_pk", categories.s_category_system_id_pk);
            htDeleteCategory.Add("@CategoryID", categories.CategoryID);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_categories", htDeleteCategory);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insert Category
        /// </summary>
        public static int InsertCategory(string CategoryID, string s_category_system_id_pk)
        {
            Hashtable htInsertCategory = new Hashtable();

            htInsertCategory.Add("@CategoryID", CategoryID);
            htInsertCategory.Add("@s_category_system_id_pk", s_category_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_categories", htInsertCategory);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Get CourseCategory
        /// </summary>
        /// <param name="c_course_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetCourseCategory(string s_category_system_id_pk)
        {
            Hashtable htGetCourseCategory = new Hashtable();
            htGetCourseCategory.Add("@s_category_system_id_pk", s_category_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_categories", htGetCourseCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Create Categories
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public static int CreateCategories(SystemCategories categories)
        {
            Hashtable htInsertCategories = new Hashtable();
            htInsertCategories.Add("@s_category_system_id_pk", categories.s_category_system_id_pk);
            htInsertCategories.Add("@s_category_id", categories.s_category_id);
            if (!string.IsNullOrEmpty(categories.s_parent_category_id))
            {
                htInsertCategories.Add("@s_parent_category_id", categories.s_parent_category_id);
            }
            else
            {
                htInsertCategories.Add("@s_parent_category_id", DBNull.Value);
            }
            htInsertCategories.Add("@s_category_status_id_fk", categories.s_category_status_id_fk);


            htInsertCategories.Add("@s_category_name_us_english", categories.s_category_name_us_english);
            htInsertCategories.Add("@s_category_desc_us_english", categories.s_category_desc_us_english);
            htInsertCategories.Add("@s_category_name_uk_english", categories.s_category_name_uk_english);
            htInsertCategories.Add("@s_category_desc_uk_english", categories.s_category_desc_uk_english);
            htInsertCategories.Add("@s_category_name_ca_french", categories.s_category_name_ca_french);
            htInsertCategories.Add("@s_category_desc_ca_french", categories.s_category_desc_ca_french);
            htInsertCategories.Add("@s_category_name_fr_french", categories.s_category_name_fr_french);
            htInsertCategories.Add("@s_category_desc_fr_french", categories.s_category_desc_fr_french);
            htInsertCategories.Add("@s_category_name_mx_spanish", categories.s_category_name_mx_spanish);
            htInsertCategories.Add("@s_category_desc_mx_spanish", categories.s_category_desc_mx_spanish);
            htInsertCategories.Add("@s_category_name_sp_spanish", categories.s_category_name_sp_spanish);
            htInsertCategories.Add("@s_category_desc_sp_spanish", categories.s_category_desc_sp_spanish);
            htInsertCategories.Add("@s_category_name_portuguese", categories.s_category_name_portuguese);
            htInsertCategories.Add("@s_category_desc_portuguese", categories.s_category_desc_portuguese);
            htInsertCategories.Add("@s_category_name_simp_chinese", categories.s_category_name_simp_chinese);
            htInsertCategories.Add("@s_category_desc_simp_chinese", categories.s_category_desc_simp_chinese);
            htInsertCategories.Add("@s_category_name_german", categories.s_category_name_german);
            htInsertCategories.Add("@s_category_desc_german", categories.s_category_desc_german);
            htInsertCategories.Add("@s_category_name_japanese", categories.s_category_name_japanese);
            htInsertCategories.Add("@s_category_desc_japanese", categories.s_category_desc_japanese);
            htInsertCategories.Add("@s_category_name_russian", categories.s_category_name_russian);
            htInsertCategories.Add("@s_category_desc_russian", categories.s_category_desc_russian);
            htInsertCategories.Add("@s_category_name_danish", categories.s_category_name_danish);
            htInsertCategories.Add("@s_category_desc_danish", categories.s_category_desc_danish);
            htInsertCategories.Add("@s_category_name_polish", categories.s_category_name_polish);
            htInsertCategories.Add("@s_category_desc_polish", categories.s_category_desc_polish);
            htInsertCategories.Add("@s_category_name_swedish", categories.s_category_name_swedish);
            htInsertCategories.Add("@s_category_desc_swedish", categories.s_category_desc_swedish);
            htInsertCategories.Add("@s_category_name_finnish", categories.s_category_name_finnish);
            htInsertCategories.Add("@s_category_desc_finnish", categories.s_category_desc_finnish);
            htInsertCategories.Add("@s_category_name_korean", categories.s_category_name_korean);
            htInsertCategories.Add("@s_category_desc_korean", categories.s_category_desc_korean);
            htInsertCategories.Add("@s_category_name_italian", categories.s_category_name_italian);
            htInsertCategories.Add("@s_category_desc_italian", categories.s_category_desc_italian);
            htInsertCategories.Add("@s_category_name_dutch", categories.s_category_name_dutch);
            htInsertCategories.Add("@s_category_desc_dutch", categories.s_category_desc_dutch);
            htInsertCategories.Add("@s_category_name_indonesian", categories.s_category_name_indonesian);
            htInsertCategories.Add("@s_category_desc_indonesian", categories.s_category_desc_indonesian);
            htInsertCategories.Add("@s_category_name_greek", categories.s_category_name_greek);
            htInsertCategories.Add("@s_category_desc_greek", categories.s_category_desc_greek);
            htInsertCategories.Add("@s_category_name_hungarian", categories.s_category_name_hungarian);
            htInsertCategories.Add("@s_category_desc_hungarian", categories.s_category_desc_hungarian);
            htInsertCategories.Add("@s_category_name_norwegian", categories.s_category_name_norwegian);
            htInsertCategories.Add("@s_category_desc_norwegian", categories.s_category_desc_norwegian);
            htInsertCategories.Add("@s_category_name_turkish", categories.s_category_name_turkish);
            htInsertCategories.Add("@s_category_desc_turkish", categories.s_category_desc_turkish);
            htInsertCategories.Add("@s_category_name_arabic_rtl", categories.s_category_name_arabic_rtl);
            htInsertCategories.Add("@s_category_desc_arabic_rtl", categories.s_category_desc_arabic_rtl);
            htInsertCategories.Add("@s_category_name_custom_01", categories.s_category_name_custom_01);
            htInsertCategories.Add("@s_category_desc_custom_01", categories.s_category_desc_custom_01);
            htInsertCategories.Add("@s_category_name_custom_02", categories.s_category_name_custom_02);
            htInsertCategories.Add("@s_category_desc_custom_02", categories.s_category_desc_custom_02);
            htInsertCategories.Add("@s_category_name_custom_03", categories.s_category_name_custom_03);
            htInsertCategories.Add("@s_category_desc_custom_03", categories.s_category_desc_custom_03);
            htInsertCategories.Add("@s_category_name_custom_04", categories.s_category_name_custom_04);
            htInsertCategories.Add("@s_category_desc_custom_04", categories.s_category_desc_custom_04);
            htInsertCategories.Add("@s_category_name_custom_05", categories.s_category_name_custom_05);
            htInsertCategories.Add("@s_category_desc_custom_05", categories.s_category_desc_custom_05);
            htInsertCategories.Add("@s_category_name_custom_06", categories.s_category_name_custom_06);
            htInsertCategories.Add("@s_category_desc_custom_06", categories.s_category_desc_custom_06);
            htInsertCategories.Add("@s_category_name_custom_07", categories.s_category_name_custom_07);
            htInsertCategories.Add("@s_category_desc_custom_07", categories.s_category_desc_custom_07);
            htInsertCategories.Add("@s_category_name_custom_08", categories.s_category_name_custom_08);
            htInsertCategories.Add("@s_category_desc_custom_08", categories.s_category_desc_custom_08);
            htInsertCategories.Add("@s_category_name_custom_09", categories.s_category_name_custom_09);
            htInsertCategories.Add("@s_category_desc_custom_09", categories.s_category_desc_custom_09);
            htInsertCategories.Add("@s_category_name_custom_10", categories.s_category_name_custom_10);
            htInsertCategories.Add("@s_category_desc_custom_10", categories.s_category_desc_custom_10);
            htInsertCategories.Add("@s_category_name_custom_11", categories.s_category_name_custom_11);
            htInsertCategories.Add("@s_category_desc_custom_11", categories.s_category_desc_custom_11);
            htInsertCategories.Add("@s_category_name_custom_12", categories.s_category_name_custom_12);
            htInsertCategories.Add("@s_category_desc_custom_12", categories.s_category_desc_custom_12);
            htInsertCategories.Add("@s_category_name_custom_13", categories.s_category_name_custom_13);
            htInsertCategories.Add("@s_category_desc_custom_13", categories.s_category_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_categories", htInsertCategories);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Get Parent Category
        /// </summary>
        /// <returns></returns>
        public static DataTable GetParentCategory(string s_locale)
        {
            try
            {
                Hashtable htGetParentCategory = new Hashtable();
                htGetParentCategory.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_parent_category",htGetParentCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Status
        /// </summary>
        /// <returns></returns>
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
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Category statuss
        /// </summary>
        /// <param name="s_category_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateCategoryStatus(string s_category_system_id_pk)
        {
            Hashtable htUpdateCategoryStatus = new Hashtable();
            htUpdateCategoryStatus.Add("@s_category_system_id_pk", s_category_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_category_status", htUpdateCategoryStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Categories
        /// </summary>
        /// <param name="s_category_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCategories GetCategories(string s_category_system_id_pk)
        {
            SystemCategories categories;

            try
            {
                Hashtable htGetDeliveryTypes = new Hashtable();
                htGetDeliveryTypes.Add("@s_category_system_id_pk", s_category_system_id_pk);
                categories = new SystemCategories();
                DataTable dtGetCategories = DataProxy.FetchDataTable("s_sp_get_categories", htGetDeliveryTypes);

                categories.s_category_id = dtGetCategories.Rows[0]["s_category_id"].ToString();
                categories.s_category_status_id_fk = dtGetCategories.Rows[0]["s_category_status_id_fk"].ToString();
                categories.s_parent_category_id = dtGetCategories.Rows[0]["s_parent_category_id"].ToString();

                categories.s_category_name_us_english = dtGetCategories.Rows[0]["s_category_name_us_english"].ToString();
                categories.s_category_desc_us_english = dtGetCategories.Rows[0]["s_category_desc_us_english"].ToString();
                categories.s_category_name_uk_english = dtGetCategories.Rows[0]["s_category_name_uk_english"].ToString();
                categories.s_category_desc_uk_english = dtGetCategories.Rows[0]["s_category_desc_uk_english"].ToString();
                categories.s_category_name_ca_french = dtGetCategories.Rows[0]["s_category_name_ca_french"].ToString();
                categories.s_category_desc_ca_french = dtGetCategories.Rows[0]["s_category_desc_ca_french"].ToString();
                categories.s_category_name_fr_french = dtGetCategories.Rows[0]["s_category_name_fr_french"].ToString();
                categories.s_category_desc_fr_french = dtGetCategories.Rows[0]["s_category_desc_fr_french"].ToString();
                categories.s_category_name_mx_spanish = dtGetCategories.Rows[0]["s_category_name_mx_spanish"].ToString();
                categories.s_category_desc_mx_spanish = dtGetCategories.Rows[0]["s_category_desc_mx_spanish"].ToString();
                categories.s_category_name_sp_spanish = dtGetCategories.Rows[0]["s_category_name_sp_spanish"].ToString();
                categories.s_category_desc_sp_spanish = dtGetCategories.Rows[0]["s_category_desc_sp_spanish"].ToString();
                categories.s_category_name_portuguese = dtGetCategories.Rows[0]["s_category_name_portuguese"].ToString();
                categories.s_category_desc_portuguese = dtGetCategories.Rows[0]["s_category_desc_portuguese"].ToString();
                categories.s_category_name_simp_chinese = dtGetCategories.Rows[0]["s_category_name_simp_chinese"].ToString();
                categories.s_category_desc_simp_chinese = dtGetCategories.Rows[0]["s_category_desc_simp_chinese"].ToString();
                categories.s_category_name_german = dtGetCategories.Rows[0]["s_category_name_german"].ToString();
                categories.s_category_desc_german = dtGetCategories.Rows[0]["s_category_desc_german"].ToString();
                categories.s_category_name_japanese = dtGetCategories.Rows[0]["s_category_name_japanese"].ToString();
                categories.s_category_desc_japanese = dtGetCategories.Rows[0]["s_category_desc_japanese"].ToString();
                categories.s_category_name_russian = dtGetCategories.Rows[0]["s_category_name_russian"].ToString();
                categories.s_category_desc_russian = dtGetCategories.Rows[0]["s_category_desc_russian"].ToString();
                categories.s_category_name_danish = dtGetCategories.Rows[0]["s_category_name_danish"].ToString();
                categories.s_category_desc_danish = dtGetCategories.Rows[0]["s_category_desc_danish"].ToString();
                categories.s_category_name_polish = dtGetCategories.Rows[0]["s_category_name_polish"].ToString();
                categories.s_category_desc_polish = dtGetCategories.Rows[0]["s_category_desc_polish"].ToString();
                categories.s_category_name_swedish = dtGetCategories.Rows[0]["s_category_name_swedish"].ToString();
                categories.s_category_desc_swedish = dtGetCategories.Rows[0]["s_category_desc_swedish"].ToString();
                categories.s_category_name_finnish = dtGetCategories.Rows[0]["s_category_name_finnish"].ToString();
                categories.s_category_desc_finnish = dtGetCategories.Rows[0]["s_category_desc_finnish"].ToString();
                categories.s_category_name_korean = dtGetCategories.Rows[0]["s_category_name_korean"].ToString();
                categories.s_category_desc_korean = dtGetCategories.Rows[0]["s_category_desc_korean"].ToString();
                categories.s_category_name_italian = dtGetCategories.Rows[0]["s_category_name_italian"].ToString();
                categories.s_category_desc_italian = dtGetCategories.Rows[0]["s_category_desc_italian"].ToString();
                categories.s_category_name_dutch = dtGetCategories.Rows[0]["s_category_name_dutch"].ToString();
                categories.s_category_desc_dutch = dtGetCategories.Rows[0]["s_category_desc_dutch"].ToString();
                categories.s_category_name_indonesian = dtGetCategories.Rows[0]["s_category_name_indonesian"].ToString();
                categories.s_category_desc_indonesian = dtGetCategories.Rows[0]["s_category_desc_indonesian"].ToString();
                categories.s_category_name_greek = dtGetCategories.Rows[0]["s_category_name_greek"].ToString();
                categories.s_category_desc_greek = dtGetCategories.Rows[0]["s_category_desc_greek"].ToString();
                categories.s_category_name_hungarian = dtGetCategories.Rows[0]["s_category_name_hungarian"].ToString();
                categories.s_category_desc_hungarian = dtGetCategories.Rows[0]["s_category_desc_hungarian"].ToString();
                categories.s_category_name_norwegian = dtGetCategories.Rows[0]["s_category_name_norwegian"].ToString();
                categories.s_category_desc_norwegian = dtGetCategories.Rows[0]["s_category_desc_norwegian"].ToString();
                categories.s_category_name_turkish = dtGetCategories.Rows[0]["s_category_name_turkish"].ToString();
                categories.s_category_desc_turkish = dtGetCategories.Rows[0]["s_category_desc_turkish"].ToString();
                categories.s_category_name_arabic_rtl = dtGetCategories.Rows[0]["s_category_name_arabic_rtl"].ToString();
                categories.s_category_desc_arabic_rtl = dtGetCategories.Rows[0]["s_category_desc_arabic_rtl"].ToString();
                categories.s_category_name_custom_01 = dtGetCategories.Rows[0]["s_category_name_custom_01"].ToString();
                categories.s_category_desc_custom_01 = dtGetCategories.Rows[0]["s_category_desc_custom_01"].ToString();
                categories.s_category_name_custom_02 = dtGetCategories.Rows[0]["s_category_name_custom_02"].ToString();
                categories.s_category_desc_custom_02 = dtGetCategories.Rows[0]["s_category_desc_custom_02"].ToString();
                categories.s_category_name_custom_03 = dtGetCategories.Rows[0]["s_category_name_custom_03"].ToString();
                categories.s_category_desc_custom_03 = dtGetCategories.Rows[0]["s_category_desc_custom_03"].ToString();
                categories.s_category_name_custom_04 = dtGetCategories.Rows[0]["s_category_name_custom_04"].ToString();
                categories.s_category_desc_custom_04 = dtGetCategories.Rows[0]["s_category_desc_custom_04"].ToString();
                categories.s_category_name_custom_05 = dtGetCategories.Rows[0]["s_category_name_custom_05"].ToString();
                categories.s_category_desc_custom_05 = dtGetCategories.Rows[0]["s_category_desc_custom_05"].ToString();
                categories.s_category_name_custom_06 = dtGetCategories.Rows[0]["s_category_name_custom_06"].ToString();
                categories.s_category_desc_custom_06 = dtGetCategories.Rows[0]["s_category_desc_custom_06"].ToString();
                categories.s_category_name_custom_07 = dtGetCategories.Rows[0]["s_category_name_custom_07"].ToString();
                categories.s_category_desc_custom_07 = dtGetCategories.Rows[0]["s_category_desc_custom_07"].ToString();
                categories.s_category_name_custom_08 = dtGetCategories.Rows[0]["s_category_name_custom_08"].ToString();
                categories.s_category_desc_custom_08 = dtGetCategories.Rows[0]["s_category_desc_custom_08"].ToString();
                categories.s_category_name_custom_09 = dtGetCategories.Rows[0]["s_category_name_custom_09"].ToString();
                categories.s_category_desc_custom_09 = dtGetCategories.Rows[0]["s_category_desc_custom_09"].ToString();
                categories.s_category_name_custom_10 = dtGetCategories.Rows[0]["s_category_name_custom_10"].ToString();
                categories.s_category_desc_custom_10 = dtGetCategories.Rows[0]["s_category_desc_custom_10"].ToString();
                categories.s_category_name_custom_11 = dtGetCategories.Rows[0]["s_category_name_custom_11"].ToString();
                categories.s_category_desc_custom_11 = dtGetCategories.Rows[0]["s_category_desc_custom_11"].ToString();
                categories.s_category_name_custom_12 = dtGetCategories.Rows[0]["s_category_name_custom_12"].ToString();
                categories.s_category_desc_custom_12 = dtGetCategories.Rows[0]["s_category_desc_custom_12"].ToString();
                categories.s_category_name_custom_13 = dtGetCategories.Rows[0]["s_category_name_custom_13"].ToString();
                categories.s_category_desc_custom_13 = dtGetCategories.Rows[0]["s_category_desc_custom_13"].ToString();


                return categories;
            }
            catch (Exception)
            {
                throw;
            }


        }

        /// <summary>
        /// Update Categories
        /// </summary>
        /// <param name="updateCategories"></param>
        /// <returns></returns>
        public static int UpdateCategories(SystemCategories updateCategories)
        {
            Hashtable htUpdateCategories = new Hashtable();

            htUpdateCategories.Add("@s_category_system_id_pk", updateCategories.s_category_system_id_pk);
            htUpdateCategories.Add("@s_category_id", updateCategories.s_category_id);
            htUpdateCategories.Add("@s_category_status_id_fk", updateCategories.s_category_status_id_fk);
            if (!string.IsNullOrEmpty(updateCategories.s_parent_category_id))
            {
                htUpdateCategories.Add("@s_parent_category_id", updateCategories.s_parent_category_id);
            }
            else
            {
                htUpdateCategories.Add("@s_parent_category_id", DBNull.Value);
            }

            htUpdateCategories.Add("@s_category_name_us_english", updateCategories.s_category_name_us_english);
            htUpdateCategories.Add("@s_category_desc_us_english", updateCategories.s_category_desc_us_english);
            htUpdateCategories.Add("@s_category_name_uk_english", updateCategories.s_category_name_uk_english);
            htUpdateCategories.Add("@s_category_desc_uk_english", updateCategories.s_category_desc_uk_english);
            htUpdateCategories.Add("@s_category_name_ca_french", updateCategories.s_category_name_ca_french);
            htUpdateCategories.Add("@s_category_desc_ca_french", updateCategories.s_category_desc_ca_french);
            htUpdateCategories.Add("@s_category_name_fr_french", updateCategories.s_category_name_fr_french);
            htUpdateCategories.Add("@s_category_desc_fr_french", updateCategories.s_category_desc_fr_french);
            htUpdateCategories.Add("@s_category_name_mx_spanish", updateCategories.s_category_name_mx_spanish);
            htUpdateCategories.Add("@s_category_desc_mx_spanish", updateCategories.s_category_desc_mx_spanish);
            htUpdateCategories.Add("@s_category_name_sp_spanish", updateCategories.s_category_name_sp_spanish);
            htUpdateCategories.Add("@s_category_desc_sp_spanish", updateCategories.s_category_desc_sp_spanish);
            htUpdateCategories.Add("@s_category_name_portuguese", updateCategories.s_category_name_portuguese);
            htUpdateCategories.Add("@s_category_desc_portuguese", updateCategories.s_category_desc_portuguese);
            htUpdateCategories.Add("@s_category_name_simp_chinese", updateCategories.s_category_name_simp_chinese);
            htUpdateCategories.Add("@s_category_desc_simp_chinese", updateCategories.s_category_desc_simp_chinese);
            htUpdateCategories.Add("@s_category_name_german", updateCategories.s_category_name_german);
            htUpdateCategories.Add("@s_category_desc_german", updateCategories.s_category_desc_german);
            htUpdateCategories.Add("@s_category_name_japanese", updateCategories.s_category_name_japanese);
            htUpdateCategories.Add("@s_category_desc_japanese", updateCategories.s_category_desc_japanese);
            htUpdateCategories.Add("@s_category_name_russian", updateCategories.s_category_name_russian);
            htUpdateCategories.Add("@s_category_desc_russian", updateCategories.s_category_desc_russian);
            htUpdateCategories.Add("@s_category_name_danish", updateCategories.s_category_name_danish);
            htUpdateCategories.Add("@s_category_desc_danish", updateCategories.s_category_desc_danish);
            htUpdateCategories.Add("@s_category_name_polish", updateCategories.s_category_name_polish);
            htUpdateCategories.Add("@s_category_desc_polish", updateCategories.s_category_desc_polish);
            htUpdateCategories.Add("@s_category_name_swedish", updateCategories.s_category_name_swedish);
            htUpdateCategories.Add("@s_category_desc_swedish", updateCategories.s_category_desc_swedish);
            htUpdateCategories.Add("@s_category_name_finnish", updateCategories.s_category_name_finnish);
            htUpdateCategories.Add("@s_category_desc_finnish", updateCategories.s_category_desc_finnish);
            htUpdateCategories.Add("@s_category_name_korean", updateCategories.s_category_name_korean);
            htUpdateCategories.Add("@s_category_desc_korean", updateCategories.s_category_desc_korean);
            htUpdateCategories.Add("@s_category_name_italian", updateCategories.s_category_name_italian);
            htUpdateCategories.Add("@s_category_desc_italian", updateCategories.s_category_desc_italian);
            htUpdateCategories.Add("@s_category_name_dutch", updateCategories.s_category_name_dutch);
            htUpdateCategories.Add("@s_category_desc_dutch", updateCategories.s_category_desc_dutch);
            htUpdateCategories.Add("@s_category_name_indonesian", updateCategories.s_category_name_indonesian);
            htUpdateCategories.Add("@s_category_desc_indonesian", updateCategories.s_category_desc_indonesian);
            htUpdateCategories.Add("@s_category_name_greek", updateCategories.s_category_name_greek);
            htUpdateCategories.Add("@s_category_desc_greek", updateCategories.s_category_desc_greek);
            htUpdateCategories.Add("@s_category_name_hungarian", updateCategories.s_category_name_hungarian);
            htUpdateCategories.Add("@s_category_desc_hungarian", updateCategories.s_category_desc_hungarian);
            htUpdateCategories.Add("@s_category_name_norwegian", updateCategories.s_category_name_norwegian);
            htUpdateCategories.Add("@s_category_desc_norwegian", updateCategories.s_category_desc_norwegian);
            htUpdateCategories.Add("@s_category_name_turkish", updateCategories.s_category_name_turkish);
            htUpdateCategories.Add("@s_category_desc_turkish", updateCategories.s_category_desc_turkish);
            htUpdateCategories.Add("@s_category_name_arabic_rtl", updateCategories.s_category_name_arabic_rtl);
            htUpdateCategories.Add("@s_category_desc_arabic_rtl", updateCategories.s_category_desc_arabic_rtl);
            htUpdateCategories.Add("@s_category_name_custom_01", updateCategories.s_category_name_custom_01);
            htUpdateCategories.Add("@s_category_desc_custom_01", updateCategories.s_category_desc_custom_01);
            htUpdateCategories.Add("@s_category_name_custom_02", updateCategories.s_category_name_custom_02);
            htUpdateCategories.Add("@s_category_desc_custom_02", updateCategories.s_category_desc_custom_02);
            htUpdateCategories.Add("@s_category_name_custom_03", updateCategories.s_category_name_custom_03);
            htUpdateCategories.Add("@s_category_desc_custom_03", updateCategories.s_category_desc_custom_03);
            htUpdateCategories.Add("@s_category_name_custom_04", updateCategories.s_category_name_custom_04);
            htUpdateCategories.Add("@s_category_desc_custom_04", updateCategories.s_category_desc_custom_04);
            htUpdateCategories.Add("@s_category_name_custom_05", updateCategories.s_category_name_custom_05);
            htUpdateCategories.Add("@s_category_desc_custom_05", updateCategories.s_category_desc_custom_05);
            htUpdateCategories.Add("@s_category_name_custom_06", updateCategories.s_category_name_custom_06);
            htUpdateCategories.Add("@s_category_desc_custom_06", updateCategories.s_category_desc_custom_06);
            htUpdateCategories.Add("@s_category_name_custom_07", updateCategories.s_category_name_custom_07);
            htUpdateCategories.Add("@s_category_desc_custom_07", updateCategories.s_category_desc_custom_07);
            htUpdateCategories.Add("@s_category_name_custom_08", updateCategories.s_category_name_custom_08);
            htUpdateCategories.Add("@s_category_desc_custom_08", updateCategories.s_category_desc_custom_08);
            htUpdateCategories.Add("@s_category_name_custom_09", updateCategories.s_category_name_custom_09);
            htUpdateCategories.Add("@s_category_desc_custom_09", updateCategories.s_category_desc_custom_09);
            htUpdateCategories.Add("@s_category_name_custom_10", updateCategories.s_category_name_custom_10);
            htUpdateCategories.Add("@s_category_desc_custom_10", updateCategories.s_category_desc_custom_10);
            htUpdateCategories.Add("@s_category_name_custom_11", updateCategories.s_category_name_custom_11);
            htUpdateCategories.Add("@s_category_desc_custom_11", updateCategories.s_category_desc_custom_11);
            htUpdateCategories.Add("@s_category_name_custom_12", updateCategories.s_category_name_custom_12);
            htUpdateCategories.Add("@s_category_desc_custom_12", updateCategories.s_category_desc_custom_12);
            htUpdateCategories.Add("@s_category_name_custom_13", updateCategories.s_category_name_custom_13);
            htUpdateCategories.Add("@s_category_desc_custom_13", updateCategories.s_category_desc_custom_13);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_categories", htUpdateCategories);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
