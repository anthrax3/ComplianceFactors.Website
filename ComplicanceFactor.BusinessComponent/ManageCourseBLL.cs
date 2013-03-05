using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class ManageCourseBLL
    {
        public static DataTable SearchSystemCatalog(ManageCourse course)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", course.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", course.c_course_title);
            htSearchCourse.Add("@c_course_version", course.c_course_version);
            if (course.c_course_active_type_id_fk == "0")
                htSearchCourse.Add("@c_course_active_type_id_fk", DBNull.Value);
            else
                htSearchCourse.Add("@c_course_active_type_id_fk", course.c_course_active_type_id_fk);
            htSearchCourse.Add("@c_course_owner_name", course.c_course_owner_name);
            htSearchCourse.Add("@c_course_coordinator_name", course.c_course_coordinator_name);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Delete location locale
        /// </summary>
        /// <param name="s_location_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteCourseLocale(string s_course_system_id_fk, string s_course_locale, string s_course_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_course_system_id_fk))
            {
                htDeleteLocale.Add("@s_course_system_id_fk", s_course_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_course_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_course_locale))
            {
                htDeleteLocale.Add("@s_course_locale", s_course_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_course_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_course_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_course_locale_system_id_pk", s_course_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_course_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_course_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// GetCourseLocale
        /// </summary>
        /// <param name="s_course_system_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetCourseLocale(string s_course_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_course_system_id_fk", s_course_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_course_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update course locale
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static int UpdateCourseLocale(ManageCourse locale)
        {
            Hashtable htUpdatecourseLocale = new Hashtable();
            htUpdatecourseLocale.Add("@s_course_locale_system_id_pk", locale.s_course_locale_system_id_pk);
            if (!string.IsNullOrEmpty(locale.s_course_locale_name))
            {
                htUpdatecourseLocale.Add("@s_course_locale_title", locale.s_course_locale_name);
            }
            else
            {
                htUpdatecourseLocale.Add("@s_course_locale_title", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_course_locale_description))
            {
                htUpdatecourseLocale.Add("@s_course_locale_description", locale.s_course_locale_description);
            }
            else
            {
                htUpdatecourseLocale.Add("@s_course_locale_description", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_course_locale_abstract))
            {
                htUpdatecourseLocale.Add("@s_course_locale_abstract", locale.s_course_locale_abstract);
            }
            else
            {
                htUpdatecourseLocale.Add("@s_course_locale_abstract", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_course_locale", htUpdatecourseLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get single course locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static ManageCourse GetSinglecourseLocale(string s_locale_system_id_pk)
        {
            ManageCourse Locale;
            try
            {
                Locale = new ManageCourse();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_course_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_course_locale", htGetLocale);
                Locale.s_course_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_course_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_course_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                Locale.s_course_locale_abstract = dtGetLocale.Rows[0]["s_locale_abstract"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// insert course locale
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static int InsertCourseLocale(ManageCourse locale)
        {
            Hashtable htInsertcourseLocale = new Hashtable();
            htInsertcourseLocale.Add("@s_course_system_id_fk", locale.s_course_system_id_fk);
            htInsertcourseLocale.Add("@s_course_locale_title", locale.s_course_locale_name);
            htInsertcourseLocale.Add("@s_course_locale_description", locale.s_course_locale_description);
            htInsertcourseLocale.Add("@s_course_locale_abstract", locale.s_course_locale_abstract);
            htInsertcourseLocale.Add("@s_locale_id_fk", locale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_course_locale", htInsertcourseLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get single course locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <param name="dtTempLocale"></param>
        /// <returns></returns>
        public static ManageCourse TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            ManageCourse locale;
            try
            {
                locale = new ManageCourse();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                locale.s_course_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                locale.s_course_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                locale.s_course_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                locale.s_course_locale_abstract = dtGetLocale.Rows[0]["s_course_locale_abstract"].ToString();
                return locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        //delivery locale
        public static int InsertDeliveryLocale(ManageCourse locale)
        {
            Hashtable htInsertdeliveryLocale = new Hashtable();
            htInsertdeliveryLocale.Add("@s_delivery_system_id_fk", locale.s_delivery_system_id_fk);
            htInsertdeliveryLocale.Add("@s_delivery_locale_title", locale.s_delivery_locale_name);
            htInsertdeliveryLocale.Add("@s_delivery_locale_description", locale.s_delivery_locale_description);
            htInsertdeliveryLocale.Add("@s_delivery_locale_abstract", locale.s_delivery_locale_abstract);
            htInsertdeliveryLocale.Add("@s_delivery_aicc_url", locale.s_delivery_aicc_url);
            htInsertdeliveryLocale.Add("@s_delivery_scorm_url", locale.s_delivery_scorm_url);
            htInsertdeliveryLocale.Add("@s_locale_id_fk", locale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_delivery_locale", htInsertdeliveryLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get single delivery locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static ManageCourse GetSingleDeliveryLocale(string s_locale_system_id_pk)
        {
            ManageCourse Locale;
            try
            {
                Locale = new ManageCourse();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_delivery_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_delivery_locale", htGetLocale);
                Locale.s_delivery_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                Locale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                Locale.s_delivery_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                Locale.s_delivery_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                Locale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                Locale.s_delivery_locale_abstract = dtGetLocale.Rows[0]["s_locale_abstract"].ToString();
                Locale.s_delivery_aicc_url = dtGetLocale.Rows[0]["s_locale_aicc_url"].ToString();
                Locale.s_delivery_scorm_url = dtGetLocale.Rows[0]["s_locale_scorm_url"].ToString();
                return Locale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int UpdateDeliveryLocale(ManageCourse locale)
        {
            Hashtable htUpdateDeliveryLocale = new Hashtable();
            htUpdateDeliveryLocale.Add("@s_delivery_locale_system_id_pk", locale.s_delivery_locale_system_id_pk);
            if (!string.IsNullOrEmpty(locale.s_delivery_locale_name))
            {
                htUpdateDeliveryLocale.Add("@s_delivery_locale_title", locale.s_delivery_locale_name);
            }
            else
            {
                htUpdateDeliveryLocale.Add("@s_delivery_locale_title", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_delivery_locale_description))
            {
                htUpdateDeliveryLocale.Add("@s_delivery_locale_description", locale.s_delivery_locale_description);
            }
            else
            {
                htUpdateDeliveryLocale.Add("@s_delivery_locale_description", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_delivery_locale_abstract))
            {
                htUpdateDeliveryLocale.Add("@s_delivery_locale_abstract", locale.s_delivery_locale_abstract);
            }
            else
            {
                htUpdateDeliveryLocale.Add("@s_delivery_locale_abstract", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_delivery_aicc_url))
            {
                htUpdateDeliveryLocale.Add("@s_delivery_aicc_url", locale.s_delivery_aicc_url);
            }
            else
            {
                htUpdateDeliveryLocale.Add("@s_delivery_aicc_url", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(locale.s_delivery_scorm_url))
            {
                htUpdateDeliveryLocale.Add("@s_delivery_scorm_url", locale.s_delivery_scorm_url);
            }
            else
            {
                htUpdateDeliveryLocale.Add("@s_delivery_scorm_url", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_delivery_locale", htUpdateDeliveryLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDeliveryLocale(string s_delivery_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_delivery_system_id_fk", s_delivery_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_delivery_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteDeliveryLocale(string s_delivery_system_id_fk, string s_delivery_locale, string s_delivery_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_delivery_system_id_fk))
            {
                htDeleteLocale.Add("@s_delivery_system_id_fk", s_delivery_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_delivery_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_delivery_locale))
            {
                htDeleteLocale.Add("@s_delivery_locale", s_delivery_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_delivery_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_delivery_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_delivery_locale_system_id_pk", s_delivery_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_delivery_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_delivery_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get olt wrapper
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOLTWrapper(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetOltWrapper = new Hashtable();
                htGetOltWrapper.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetOltWrapper.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_olt_wrapper",htGetOltWrapper);
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
