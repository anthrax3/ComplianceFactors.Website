using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data.SqlTypes;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemCatalogBLL
    {
        /// <summary>
        /// Get Course Status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetCourseStatus(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetCourseDetails = new Hashtable();
                htGetCourseDetails.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetCourseDetails.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_course_sp_get_status", htGetCourseDetails);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Get Course All status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetCourseAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetCourseDetails = new Hashtable();
                htGetCourseDetails.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetCourseDetails.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_course_sp_get_all_status", htGetCourseDetails);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable SearchSystemCatalog(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            htSearchCourse.Add("@c_course_version", catalog.c_course_version);

            if (catalog.c_course_active_type_id_fk == "0")
                htSearchCourse.Add("@c_course_active_type_id_fk", DBNull.Value);
            else
                htSearchCourse.Add("@c_course_active_type_id_fk", catalog.c_course_active_type_id_fk);

            htSearchCourse.Add("@c_course_owner_name", catalog.c_course_owner_name);
            htSearchCourse.Add("@c_course_coordinator_name", catalog.c_course_coordinator_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_search_course", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// create new course 
        /// </summary>
        /// <param name="course"></param>
        /// <returns>0-Success, 1-failure</returns>
        public static int CreateCourse(SystemCatalog course)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Hashtable htNewCourse = new Hashtable();
            htNewCourse.Add("@c_course_id_pk", course.c_course_id_pk);
            htNewCourse.Add("@c_course_desc", course.c_course_desc);
            htNewCourse.Add("@c_course_abstract", course.c_course_abstract);
            htNewCourse.Add("@c_course_icon_uri", course.c_course_icon_uri);
            htNewCourse.Add("@c_course_version", course.c_course_version);
            htNewCourse.Add("@c_course_approval_req", course.c_course_approval_req);

            if (course.c_course_approval_id_fk != "0")
            {
                htNewCourse.Add("@c_course_approval_id_fk", course.c_course_approval_id_fk);
            }
            else
            {
                htNewCourse.Add("@c_course_approval_id_fk", DBNull.Value);
            }
            if (course.c_course_credit_hours != null)
            {
                htNewCourse.Add("@c_course_credit_hours", course.c_course_credit_hours);
            }
            else
            {
                htNewCourse.Add("@c_course_credit_hours", DBNull.Value);
            }
            if (course.c_course_credit_units != null)
            {
                htNewCourse.Add("@c_course_credit_units", course.c_course_credit_units);
            }
            else
            {
                htNewCourse.Add("@c_course_credit_units", DBNull.Value);
            }

            htNewCourse.Add("@c_course_cert_flag", course.c_course_cert_flag);

            //if (course.c_course_cert_cycle_days != null)
            //{
            //    htNewCourse.Add("@c_course_cert_cycle_days", course.c_course_cert_cycle_days);
            //}
            //else
            //{
            //    htNewCourse.Add("@c_course_cert_cycle_days", DBNull.Value);
            //}
            if (course.c_course_recurrance_grace_days != null)
            {
                htNewCourse.Add("@c_course_recurrance_grace_days", course.c_course_recurrance_grace_days);
            }
            else
            {
                htNewCourse.Add("@c_course_recurrance_grace_days", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(course.c_course_owner_id_fk))
            {
                htNewCourse.Add("@c_course_owner_id_fk", course.c_course_owner_id_fk);
            }
            else
            {
                htNewCourse.Add("@c_course_owner_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(course.c_course_coordinator_id_fk))
            {
                htNewCourse.Add("@c_course_coordinator_id_fk", course.c_course_coordinator_id_fk);
            }
            else
            {
                htNewCourse.Add("@c_course_coordinator_id_fk", DBNull.Value);
            }
            htNewCourse.Add("@c_course_active_flag", course.c_course_active_flag);
            htNewCourse.Add("@c_course_active_type_id_fk", course.c_course_active_type_id_fk);
            htNewCourse.Add("@c_course_visible_flag", course.c_course_visible_flag);
            htNewCourse.Add("@c_course_custom_01", course.c_course_custom_01);
            htNewCourse.Add("@c_course_custom_02", course.c_course_custom_02);
            htNewCourse.Add("@c_course_custom_03", course.c_course_custom_03);
            htNewCourse.Add("@c_course_custom_04", course.c_course_custom_04);
            htNewCourse.Add("@c_course_custom_05", course.c_course_custom_05);
            htNewCourse.Add("@c_course_custom_06", course.c_course_custom_06);
            htNewCourse.Add("@c_course_custom_07", course.c_course_custom_07);
            htNewCourse.Add("@c_course_custom_08", course.c_course_custom_08);
            htNewCourse.Add("@c_course_custom_09", course.c_course_custom_09);
            htNewCourse.Add("@c_course_custom_10", course.c_course_custom_10);
            htNewCourse.Add("@c_course_custom_11", course.c_course_custom_11);
            htNewCourse.Add("@c_course_custom_12", course.c_course_custom_12);
            htNewCourse.Add("@c_course_custom_13", course.c_course_custom_13);
            htNewCourse.Add("@c_course_title", course.c_course_title);
            htNewCourse.Add("@c_course_system_id_pk", course.c_course_system_id_pk);

            htNewCourse.Add("@c_cource_prerequisite", course.c_course_Prerequistist);
            htNewCourse.Add("@c_cource_equivalencies", course.c_course_Equivalencies);
            htNewCourse.Add("@c_cource_fulfillments", course.c_course_Fulfillments);
            htNewCourse.Add("@c_cource_domains", course.c_course_domains);
            htNewCourse.Add("@c_course_category", course.c_course_category);
            if (course.c_cource_recurrance_every != null)
            {
                htNewCourse.Add("@c_cource_recurrance_every", course.c_cource_recurrance_every);
            }
            else
            {
                htNewCourse.Add("@c_cource_recurrance_every", DBNull.Value);
            }
            htNewCourse.Add("@c_cource_recurrance_period", course.c_cource_recurrance_period);
            htNewCourse.Add("@c_cource_recurance_date_option", course.c_cource_recurance_date_option);
            htNewCourse.Add("@c_course_icon_uri_file_name", course.c_course_icon_uri_file_name);

            if (course.c_cource_recurance_date != null)
            {
                htNewCourse.Add("@c_cource_recurance_date", course.c_cource_recurance_date);
            }
            else
            {
                htNewCourse.Add("@c_cource_recurance_date", DBNull.Value);
            }
            if (course.c_course_cert_date != null)
            {
                htNewCourse.Add("@c_course_cert_date", course.c_course_cert_date);
            }
            else
            {
                htNewCourse.Add("@c_course_cert_date", DBNull.Value);
            }
            if (course.c_course_cost != null)
            {
                htNewCourse.Add("@c_course_cost", course.c_course_cost);
            }
            else
            {
                htNewCourse.Add("@c_course_cost", DBNull.Value);
            }
            htNewCourse.Add("@c_course_created_by_id_fk", course.c_course_created_by_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_insert_add_new_course", htNewCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateCourse
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>

        public static int UpdateCourse(SystemCatalog course)
        {
            Hashtable htUpdateCourse = new Hashtable();
            htUpdateCourse.Add("@c_course_id_pk", course.c_course_id_pk);
            htUpdateCourse.Add("@c_course_desc", course.c_course_desc);
            htUpdateCourse.Add("@c_course_abstract", course.c_course_abstract);
            htUpdateCourse.Add("@c_course_icon_uri", course.c_course_icon_uri);
            htUpdateCourse.Add("@c_course_version", course.c_course_version);
            htUpdateCourse.Add("@c_course_approval_req", course.c_course_approval_req);
            if (course.c_course_approval_id_fk != "0")
            {
                htUpdateCourse.Add("@c_course_approval_id_fk", course.c_course_approval_id_fk);
            }
            else
            {
                htUpdateCourse.Add("@c_course_approval_id_fk", DBNull.Value);
            }
            if (course.c_course_credit_hours != null)
            {
                htUpdateCourse.Add("@c_course_credit_hours", course.c_course_credit_hours);
            }
            else
            {
                htUpdateCourse.Add("@c_course_credit_hours", DBNull.Value);

            }
            if (course.c_course_credit_units != null)
            {
                htUpdateCourse.Add("@c_course_credit_units", course.c_course_credit_units);
            }
            else
            {
                htUpdateCourse.Add("@c_course_credit_units", DBNull.Value);
            }
            htUpdateCourse.Add("@c_course_cert_flag", course.c_course_cert_flag);
            //if (course.c_course_cert_cycle_days != null)
            //{
            //    htUpdateCourse.Add("@c_course_cert_cycle_days", course.c_course_cert_cycle_days);
            //}
            //else
            //{
            //    htUpdateCourse.Add("@c_course_cert_cycle_days", DBNull.Value);
            //}
            if (course.c_course_recurrance_grace_days != null)
            {
                htUpdateCourse.Add("@c_course_recurrance_grace_days", course.c_course_recurrance_grace_days);
            }
            else
            {
                htUpdateCourse.Add("@c_course_recurrance_grace_days", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(course.c_course_owner_id_fk))
            {
                htUpdateCourse.Add("@c_course_owner_id_fk", course.c_course_owner_id_fk);
            }
            else
            {
                htUpdateCourse.Add("@c_course_owner_id_fk", DBNull.Value);
            }
            htUpdateCourse.Add("@c_course_icon_uri_file_name", course.c_course_icon_uri_file_name);

            if (!string.IsNullOrEmpty(course.c_course_coordinator_id_fk))
            {
                htUpdateCourse.Add("@c_course_coordinator_id_fk", course.c_course_coordinator_id_fk);
            }
            else
            {
                htUpdateCourse.Add("@c_course_coordinator_id_fk", DBNull.Value);
            }
            htUpdateCourse.Add("@c_course_active_flag", course.c_course_active_flag);
            htUpdateCourse.Add("@c_course_active_type_id_fk", course.c_course_active_type_id_fk);
            htUpdateCourse.Add("@c_course_visible_flag", course.c_course_visible_flag);
            htUpdateCourse.Add("@c_course_custom_01", course.c_course_custom_01);
            htUpdateCourse.Add("@c_course_custom_02", course.c_course_custom_02);
            htUpdateCourse.Add("@c_course_custom_03", course.c_course_custom_03);
            htUpdateCourse.Add("@c_course_custom_04", course.c_course_custom_04);
            htUpdateCourse.Add("@c_course_custom_05", course.c_course_custom_05);
            htUpdateCourse.Add("@c_course_custom_06", course.c_course_custom_06);
            htUpdateCourse.Add("@c_course_custom_07", course.c_course_custom_07);
            htUpdateCourse.Add("@c_course_custom_08", course.c_course_custom_08);
            htUpdateCourse.Add("@c_course_custom_09", course.c_course_custom_09);
            htUpdateCourse.Add("@c_course_custom_10", course.c_course_custom_10);
            htUpdateCourse.Add("@c_course_custom_11", course.c_course_custom_11);
            htUpdateCourse.Add("@c_course_custom_12", course.c_course_custom_12);
            htUpdateCourse.Add("@c_course_custom_13", course.c_course_custom_13);
            htUpdateCourse.Add("@c_course_title", course.c_course_title);
            htUpdateCourse.Add("@c_course_system_id_pk", course.c_course_system_id_pk);

            //htUpdateCourse.Add("@c_course_Prerequistist", course.c_course_Prerequistist);
            //htUpdateCourse.Add("@c_course_Equivalencies", course.c_course_Equivalencies);
            //htUpdateCourse.Add("@c_course_Fulfillments", course.c_course_Fulfillments);
            if (course.c_cource_recurrance_every != null)
            {
                htUpdateCourse.Add("@c_cource_recurrance_every", course.c_cource_recurrance_every);
            }
            else
            {
                htUpdateCourse.Add("@c_cource_recurrance_every", DBNull.Value);
            }
            htUpdateCourse.Add("@c_cource_recurrance_period", course.c_cource_recurrance_period);
            htUpdateCourse.Add("@c_cource_recurance_date_option", course.c_cource_recurance_date_option);


            if (course.c_cource_recurance_date != null)
            {
                htUpdateCourse.Add("@c_cource_recurance_date", course.c_cource_recurance_date);
            }
            else
            {
                htUpdateCourse.Add("@c_cource_recurance_date", DBNull.Value);
            }
            //if (course.c_course_cert_date != null)
            //{
            //    htUpdateCourse.Add("@c_course_cert_date", course.c_course_cert_date);
            //}
            //else
            //{
            //    htUpdateCourse.Add("@c_course_cert_date", DBNull.Value);
            //}
            if (course.c_course_cost != null)
            {
                htUpdateCourse.Add("@c_course_cost", course.c_course_cost);
            }
            else
            {
                htUpdateCourse.Add("@c_course_cost", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_course_master", htUpdateCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateSystemCatalogPrerequistist
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static int UpdateSystemCatalogPrerequistist(SystemCatalog course)
        {
            Hashtable htUpdateCoursePrerequistist = new Hashtable();
            htUpdateCoursePrerequistist.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            htUpdateCoursePrerequistist.Add("@c_course_prerequistist", course.c_course_Prerequistist);
            if (course.c_related_course_group_id != "")
            {
                htUpdateCoursePrerequistist.Add("@c_related_course_group_id", course.c_related_course_group_id);
            }
            else
            {
                htUpdateCoursePrerequistist.Add("@c_related_course_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_course_prerequistist", htUpdateCoursePrerequistist);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateSystemCatalog Equivalencies
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static int UpdateSystemCatalogEquivalencies(SystemCatalog course)
        {
            Hashtable htUpdateCourseEquivalencies = new Hashtable();
            htUpdateCourseEquivalencies.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            htUpdateCourseEquivalencies.Add("@c_course_equivalencies", course.c_course_Equivalencies);
            if (course.c_related_course_group_id != "")
            {
                htUpdateCourseEquivalencies.Add("@c_related_course_group_id", course.c_related_course_group_id);
            }
            else
            {
                htUpdateCourseEquivalencies.Add("@c_related_course_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_course_equivalencies", htUpdateCourseEquivalencies);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateSystemCatalog Fulfillments
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static int UpdateSystemCatalogFulfillments(SystemCatalog course)
        {
            Hashtable htUpdateCourseFulfillments = new Hashtable();
            htUpdateCourseFulfillments.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            htUpdateCourseFulfillments.Add("@c_course_fulfillments", course.c_course_Fulfillments);
            if (course.c_related_course_group_id != "")
            {
                htUpdateCourseFulfillments.Add("@c_related_course_group_id", course.c_related_course_group_id);
            }
            else
            {
                htUpdateCourseFulfillments.Add("@c_related_course_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_update_course_fulfillments", htUpdateCourseFulfillments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// c_course_sp_get_prerequisite_equivalencies_fullfillments
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns>Single Catalog record</returns>
        public static DataSet GetprerequisiteEquivalenciesFullfillments(string c_course_system_id_pk)
        {
            Hashtable htCourse = new Hashtable();
            htCourse.Add("@c_course_system_id_pk", c_course_system_id_pk);
            try
            {
                return DataProxy.FetchDataSet("c_course_sp_get_prerequisite_equivalencies_fullfillments", htCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Course
        /// </summary>
        /// <param name="c_course_system_id_pk"></param>
        /// <returns>Single course record</returns>
        public static SystemCatalog GetCourse(string c_course_system_id_pk, string s_ui_locale_name)
        {
            SystemCatalog course;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCourse = new Hashtable();
                htGetCourse.Add("@c_course_system_id_pk", c_course_system_id_pk);
                htGetCourse.Add("@s_ui_locale_name", s_ui_locale_name);
                course = new SystemCatalog();
                DataTable dtGetCourse = DataProxy.FetchDataSet("c_get_Particular_course_Master", htGetCourse).Tables[0];
                course.c_course_id_pk = dtGetCourse.Rows[0]["c_course_id_pk"].ToString();
                course.c_course_desc = dtGetCourse.Rows[0]["c_course_desc"].ToString();
                course.c_course_abstract = dtGetCourse.Rows[0]["c_course_abstract"].ToString();
                course.c_course_icon_uri = dtGetCourse.Rows[0]["c_course_icon_uri"].ToString();
                course.c_course_version = dtGetCourse.Rows[0]["c_course_version"].ToString();
                course.c_course_approval_req = Convert.ToBoolean(dtGetCourse.Rows[0]["c_course_approval_req"]);
                course.c_course_approval_id_fk = dtGetCourse.Rows[0]["c_course_approval_id_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_credit_hours"].ToString()))
                {
                    course.c_course_credit_hours = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_credit_hours"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_credit_units"].ToString()))
                {
                    course.c_course_credit_units = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_credit_units"]);
                }

                course.c_course_cert_flag = Convert.ToBoolean(dtGetCourse.Rows[0]["c_course_cert_flag"]);

                //if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_cert_cycle_days"].ToString()))
                //{
                //    course.c_course_cert_cycle_days = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_cert_cycle_days"]);
                //}
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_recurrance_grace_days"].ToString()))
                {
                    course.c_course_recurrance_grace_days = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_recurrance_grace_days"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_cost"].ToString()))
                {
                    course.c_course_cost = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_cost"]);
                }
                course.c_course_owner_id_fk = dtGetCourse.Rows[0]["c_course_owner_id_fk"].ToString();
                course.c_course_coordinator_id_fk = dtGetCourse.Rows[0]["c_course_coordinator_id_fk"].ToString();

                course.c_course_active_flag = Convert.ToBoolean(dtGetCourse.Rows[0]["c_course_active_flag"]);
                course.c_course_icon_uri_file_name = dtGetCourse.Rows[0]["c_course_icon_uri_file_name"].ToString();
                course.c_course_active_type_id_fk = dtGetCourse.Rows[0]["c_course_active_type_id_fk"].ToString();
                course.c_course_visible_flag = Convert.ToBoolean(dtGetCourse.Rows[0]["c_course_visible_flag"]);
                course.c_course_custom_01 = dtGetCourse.Rows[0]["c_course_custom_01"].ToString();
                course.c_course_custom_02 = dtGetCourse.Rows[0]["c_course_custom_02"].ToString();
                course.c_course_custom_03 = dtGetCourse.Rows[0]["c_course_custom_03"].ToString();
                course.c_course_custom_04 = dtGetCourse.Rows[0]["c_course_custom_04"].ToString();
                course.c_course_custom_05 = dtGetCourse.Rows[0]["c_course_custom_05"].ToString();
                course.c_course_custom_06 = dtGetCourse.Rows[0]["c_course_custom_06"].ToString();
                course.c_course_custom_07 = dtGetCourse.Rows[0]["c_course_custom_07"].ToString();
                course.c_course_custom_08 = dtGetCourse.Rows[0]["c_course_custom_08"].ToString();
                course.c_course_custom_09 = dtGetCourse.Rows[0]["c_course_custom_09"].ToString();
                course.c_course_custom_10 = dtGetCourse.Rows[0]["c_course_custom_10"].ToString();
                course.c_course_custom_11 = dtGetCourse.Rows[0]["c_course_custom_11"].ToString();
                course.c_course_custom_12 = dtGetCourse.Rows[0]["c_course_custom_12"].ToString();
                course.c_course_custom_13 = dtGetCourse.Rows[0]["c_course_custom_13"].ToString();
                course.c_course_title = dtGetCourse.Rows[0]["c_course_title"].ToString();
                course.c_course_system_id_pk = dtGetCourse.Rows[0]["c_course_system_id_pk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_cource_recurrance_every"].ToString()))
                {
                    course.c_cource_recurrance_every = Convert.ToInt32(dtGetCourse.Rows[0]["c_cource_recurrance_every"]);
                }
                course.c_cource_recurrance_period = dtGetCourse.Rows[0]["c_cource_recurrance_period"].ToString();
                course.c_cource_recurance_date_option = dtGetCourse.Rows[0]["c_cource_recurance_date_option"].ToString();
                course.c_course_owner_name = dtGetCourse.Rows[0]["ownername"].ToString();
                course.c_course_coordinator_name = dtGetCourse.Rows[0]["coordinatorname"].ToString();
                course.c_course_owner_id_fk = dtGetCourse.Rows[0]["c_course_owner_id_fk"].ToString();
                course.c_course_coordinator_id_fk = dtGetCourse.Rows[0]["c_course_coordinator_id_fk"].ToString();

                course.cost_text = dtGetCourse.Rows[0]["cost_text"].ToString();
                course.c_course_status_name = dtGetCourse.Rows[0]["c_course_status_name"].ToString();
                course.c_course_visible_flag_text = dtGetCourse.Rows[0]["c_course_visible_flag_text"].ToString();
                course.c_course_approval_name = dtGetCourse.Rows[0]["s_approval_workflow_name"].ToString();
                course.c_course_recurrences_text = dtGetCourse.Rows[0]["c_course_recurrences_text"].ToString();
                course.c_course_approval_req_text = dtGetCourse.Rows[0]["c_course_approval_req_text"].ToString();
                course.c_course_approval_req_text = dtGetCourse.Rows[0]["c_course_approval_req_text"].ToString();
                course.c_created_name = dtGetCourse.Rows[0]["c_created_name"].ToString();
                course.c_delivery_type_id = dtGetCourse.Rows[0]["c_delivery_type"].ToString();

                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_cource_recurance_date"].ToString()))
                {
                    course.c_cource_recurance_date = Convert.ToDateTime(dtGetCourse.Rows[0]["c_cource_recurance_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_cert_date"].ToString()))
                {
                    course.c_course_cert_date = Convert.ToDateTime(dtGetCourse.Rows[0]["c_course_cert_date"], culture);
                }

                return course;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// GetCourseRelatedData
        /// </summary>
        /// <param name="c_course_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetCourseRelatedData(string c_course_system_id_pk, string s_ui_locale_name)
        {
            Hashtable htGetCourse = new Hashtable();
            htGetCourse.Add("@c_course_system_id_pk", c_course_system_id_pk);
            htGetCourse.Add("@s_ui_locale_name", s_ui_locale_name);
            try
            {
                return DataProxy.FetchDataSet("c_get_Particular_course_Master", htGetCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// c_Archive_Particular_course_Master
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns>Single Catalog record</returns>
        public static DataSet ArchiveParticularCourse(SystemCatalog catalog)
        {
            Hashtable htArchiveCourse = new Hashtable();
            htArchiveCourse.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            htArchiveCourse.Add("@c_course_active_flag", catalog.c_course_active_flag);
            try
            {
                return DataProxy.FetchDataSet("c_Archive_Particular_course_Master", htArchiveCourse);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// course approval
        /// </summary>
        /// <returns>All records</returns>
        public static DataTable GetApproval()
        {

            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_approval");

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Prerequisitie
        /// </summary>
        public static int DeletePrerequisite(SystemCatalog course)
        {
            Hashtable htDeletePrerequisite = new Hashtable();
            htDeletePrerequisite.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            if (course.c_related_course_group_id != "")
            {
                htDeletePrerequisite.Add("@c_related_course_group_id", course.c_related_course_group_id);
            }
            else
            {
                htDeletePrerequisite.Add("@c_related_course_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_prerequisite", htDeletePrerequisite);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Equivalencies
        /// </summary>
        public static int DeleteEquivalencies(SystemCatalog course)
        {
            Hashtable htDeleteEquivalencies = new Hashtable();
            htDeleteEquivalencies.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            if (course.c_related_course_group_id != "")
            {
                htDeleteEquivalencies.Add("@c_related_course_group_id", course.c_related_course_group_id);
            }
            else
            {
                htDeleteEquivalencies.Add("@c_related_course_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_equivalencies", htDeleteEquivalencies);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Fulfillments
        /// </summary>
        public static int DeleteFulfillments(SystemCatalog course)
        {
            Hashtable htDeleteFulfillments = new Hashtable();
            htDeleteFulfillments.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            if (course.c_related_course_group_id != "")
            {
                htDeleteFulfillments.Add("@c_related_course_group_id", course.c_related_course_group_id);
            }
            else
            {
                htDeleteFulfillments.Add("@c_related_course_group_id", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_fulfillments", htDeleteFulfillments);

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///<summary>
        ///update icon uri
        ///</summary>
        public static int UpdateIcon(SystemCatalog course)
        {
            Hashtable htUpdateIcone = new Hashtable();
            htUpdateIcone.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            htUpdateIcone.Add("@c_course_icon_uri", course.c_course_icon_uri);
            htUpdateIcone.Add("@c_course_icon_uri_file_name", course.c_course_icon_uri_file_name);
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_update_icon_uri", htUpdateIcone);

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///<summary>
        ///Remove icon uri
        ///</summary>
        public static int RemoveIcon(SystemCatalog course)
        {
            Hashtable htUpdateIcone = new Hashtable();
            htUpdateIcone.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_icon_uri", htUpdateIcone);

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///<summary>
        ///Delivery type
        ///</summary>
        public static DataTable GetDeliveryType(string s_locale)
        {
            Hashtable htDeliveryType = new Hashtable();
            if (!string.IsNullOrEmpty(s_locale))
            {
                htDeliveryType.Add("@s_locale", s_locale);
            }
            else
            {
                htDeliveryType.Add("@s_locale", "us_english");
            }
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_delivery_type", htDeliveryType);
            }

            catch (Exception)
            {
                throw;
            }


        }
        ///<summary>
        ///Location search
        ///</summary>
        public static DataTable LocationSearch(SystemCatalog catalog)
        {
            Hashtable htLocationSearch = new Hashtable();
            htLocationSearch.Add("@c_location_id_pk", catalog.c_session_location_id_fk);
            htLocationSearch.Add("@c_location_name", catalog.c_session_location_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_location_search", htLocationSearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        ///<summary>
        ///Facility search
        ///</summary>
        public static DataTable FacilitySearch(SystemCatalog catalog)
        {
            Hashtable htFacilitySearch = new Hashtable();
            htFacilitySearch.Add("@c_facility_id_pk", catalog.c_session_facility_id_fk);
            htFacilitySearch.Add("@c_facility_name", catalog.c_session_facility_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_facility_search", htFacilitySearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        ///<summary>
        ///Room search
        ///</summary>
        public static DataTable RoomSearch(SystemCatalog catalog)
        {
            Hashtable htRoomSearch = new Hashtable();
            htRoomSearch.Add("@c_room_id_pk", catalog.c_session_room_id_fk);
            htRoomSearch.Add("@c_room_name", catalog.c_session_room_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_room_search", htRoomSearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// InsertDeliveryAndSessions
        /// </summary>
        /// <param name="insertDeliverySession"></param>
        /// <returns></returns>
        public static int InsertDeliveries(SystemCatalog insertDeliverySession, bool c_course_reset)
        {
            Hashtable htInsertDelivery = new Hashtable();
            htInsertDelivery.Add("@c_course_id_fk", insertDeliverySession.c_course_id_fk);
            htInsertDelivery.Add("@c_deliveries", insertDeliverySession.c_deliveries);
            htInsertDelivery.Add("@c_delivery_attachments", insertDeliverySession.c_delivery_attachments);
            htInsertDelivery.Add("@c_delivery_resources", insertDeliverySession.c_delivery_resources);
            htInsertDelivery.Add("@c_delivery_material", insertDeliverySession.c_delivery_material);
            htInsertDelivery.Add("@c_sessions", insertDeliverySession.c_sessions);
            htInsertDelivery.Add("@c_session_instructor", insertDeliverySession.c_session_instructor);
            // htInsertDelivery.Add("@c_related_domain_id_fk", insertDeliverySession.c_related_domain_id_fk);
            if (!string.IsNullOrEmpty(insertDeliverySession.c_related_domain_id_fk))
            {
                htInsertDelivery.Add("@c_related_domain_id_fk", insertDeliverySession.c_related_domain_id_fk);
            }
            else
            {
                htInsertDelivery.Add("@c_related_domain_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(insertDeliverySession.c_delivery_system_id_pk))
            {
                htInsertDelivery.Add("@c_delivery_system_id_pk", insertDeliverySession.c_delivery_system_id_pk);
            }
            else
            {
                htInsertDelivery.Add("@c_delivery_system_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(insertDeliverySession.c_course_category))
            {
                htInsertDelivery.Add("@c_course_category", insertDeliverySession.c_course_category);
            }
            else
            {
                htInsertDelivery.Add("@c_course_category", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(insertDeliverySession.s_course_locale))
            {
                htInsertDelivery.Add("@s_course_locale", insertDeliverySession.s_course_locale);
            }
            else
            {
                htInsertDelivery.Add("@s_course_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(insertDeliverySession.s_delivery_locale))
            {
                htInsertDelivery.Add("@s_delivery_locale", insertDeliverySession.s_delivery_locale);
            }
            else
            {
                htInsertDelivery.Add("@s_delivery_locale", DBNull.Value);
            }
            htInsertDelivery.Add("@c_course_reset", c_course_reset);
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_delivery", htInsertDelivery);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert course delivery
        /// </summary>
        /// <param name="insertDelivery"></param>
        /// <returns></returns>
        //public static int InsertDelivery(SystemCatalog insertDelivery)
        //{
        //    Hashtable htInsertDelivery = new Hashtable();

        //    htInsertDelivery.Add("@c_delivery_system_id_pk", insertDelivery.c_delivery_system_id_pk);
        //    htInsertDelivery.Add("@c_course_id_fk", insertDelivery.c_course_id_fk);
        //    htInsertDelivery.Add("@c_delivery_id_pk", insertDelivery.c_delivery_id_pk);
        //    htInsertDelivery.Add("@c_delivery_type_id_fk", insertDelivery.c_delivery_type_id_fk);
        //    htInsertDelivery.Add("@c_delivery_title", insertDelivery.c_delivery_title);
        //    htInsertDelivery.Add("@c_delivery_desc", insertDelivery.c_delivery_desc);
        //    htInsertDelivery.Add("@c_delivery_abstract", insertDelivery.c_delivery_abstract);
        //    //htInsertDelivery.Add("@c_delivery_icon_uri", insertDelivery.c_delivery_icon_uri);
        //    htInsertDelivery.Add("@c_delivery_approval_req", insertDelivery.c_delivery_approval_req);
        //    htInsertDelivery.Add("@c_delivery_approval_id_fk", insertDelivery.c_delivery_approval_id_fk);
        //    htInsertDelivery.Add("@c_delivery_credit_hours", insertDelivery.c_delivery_credit_hours);
        //    htInsertDelivery.Add("@c_delivery_credit_units", insertDelivery.c_delivery_credit_units);


        //    if (insertDelivery.c_delivery_owner_id_fk != "")
        //    {
        //        htInsertDelivery.Add("@c_delivery_owner_id_fk", insertDelivery.c_delivery_owner_id_fk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_delivery_owner_id_fk", DBNull.Value);
        //    }

        //    if (insertDelivery.c_delivery_coordinator_id_fk != "")
        //    {
        //        htInsertDelivery.Add("@c_delivery_coordinator_id_fk", insertDelivery.c_delivery_coordinator_id_fk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_delivery_coordinator_id_fk", DBNull.Value);
        //    }


        //    htInsertDelivery.Add("@c_delivery_active_flag", insertDelivery.c_delivery_active_flag);
        //    htInsertDelivery.Add("@c_delivery_active_type_id_fk", insertDelivery.c_delivery_active_type_id_fk);
        //    htInsertDelivery.Add("@c_delivery_visible_flag", insertDelivery.c_delivery_visible_flag);
        //    htInsertDelivery.Add("@c_delivery_min_enroll", insertDelivery.c_delivery_min_enroll);
        //    htInsertDelivery.Add("@c_delivery_max_enroll", insertDelivery.c_delivery_max_enroll);
        //    htInsertDelivery.Add("@c_delivery_enroll_threshold", insertDelivery.c_delivery_enroll_threshold);
        //    htInsertDelivery.Add("@c_delivery_waitlist_flag", insertDelivery.c_delivery_waitlist_flag);
        //    htInsertDelivery.Add("@c_delivery_max_waitlist", insertDelivery.c_delivery_max_waitlist);

        //    htInsertDelivery.Add("@c_vlt_launch_url", insertDelivery.c_vlt_launch_url);

        //    htInsertDelivery.Add("@c_olt_launch_url", insertDelivery.c_olt_launch_url);
        //    htInsertDelivery.Add("@c_olt_launch_param", insertDelivery.c_olt_launch_param);

        //    htInsertDelivery.Add("@c_delivery_custom_01", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_02", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_03", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_04", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_05", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_06", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_07", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_08", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_09", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_10", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_11", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_12", insertDelivery.c_delivery_custom_01);
        //    htInsertDelivery.Add("@c_delivery_custom_13", insertDelivery.c_delivery_custom_01);

        //    //Attachment
        //    htInsertDelivery.Add("@c_delivery_attachments", insertDelivery.c_delivery_attachments);

        //    //Insert session

        //    if (insertDelivery.c_session_system_id_pk != "")
        //    {
        //        htInsertDelivery.Add("@c_session_system_id_pk", insertDelivery.c_session_system_id_pk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_system_id_pk", DBNull.Value);
        //    }
        //    if (insertDelivery.c_session_id_pk != "")
        //    {
        //        htInsertDelivery.Add("@c_session_id_pk", insertDelivery.c_session_id_pk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_id_pk", DBNull.Value);
        //    }
        //    if (insertDelivery.c_delivery_id_fk != "")
        //    {
        //        htInsertDelivery.Add("@c_delivery_id_fk", insertDelivery.c_delivery_id_fk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_delivery_id_fk", DBNull.Value);
        //    }


        //    htInsertDelivery.Add("@c_session_title", insertDelivery.c_session_title);
        //    htInsertDelivery.Add("@c_sessions_desc", insertDelivery.c_sessions_desc);

        //    if (insertDelivery.c_session_start_date != null)
        //    {
        //        htInsertDelivery.Add("@c_session_start_date", insertDelivery.c_session_start_date);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_start_date", DBNull.Value);
        //    }
        //    if (insertDelivery.c_session_end_date != null)
        //    {
        //        htInsertDelivery.Add("@c_session_end_date", insertDelivery.c_session_end_date);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_end_date", DBNull.Value);
        //    }
        //    if (insertDelivery.c_session_start_time != null)
        //    {
        //        htInsertDelivery.Add("@c_session_start_time", insertDelivery.c_session_start_time);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_start_time", DBNull.Value);
        //    }
        //    if (insertDelivery.c_sessions_end_time != null)
        //    {
        //        htInsertDelivery.Add("@c_sessions_end_time", insertDelivery.c_sessions_end_time);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_sessions_end_time", DBNull.Value);
        //    }
        //    if (insertDelivery.c_session_duration != null)
        //    {
        //        htInsertDelivery.Add("@c_session_duration", insertDelivery.c_session_duration);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_duration", DBNull.Value);
        //    }


        //    if (insertDelivery.c_session_location_id_fk != "")
        //    {
        //        htInsertDelivery.Add("@c_session_location_id_fk", insertDelivery.c_session_location_id_fk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_location_id_fk", DBNull.Value);
        //    }


        //    if (insertDelivery.c_session_facility_id_fk != "")
        //    {
        //        htInsertDelivery.Add("@c_session_facility_id_fk", insertDelivery.c_session_facility_id_fk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_session_facility_id_fk", DBNull.Value);
        //    }


        //    if (insertDelivery.c_session_room_id_fk != "")
        //    {
        //        htInsertDelivery.Add("@c_sessions_room_id_fk", insertDelivery.c_session_room_id_fk);
        //    }
        //    else
        //    {
        //        htInsertDelivery.Add("@c_sessions_room_id_fk", DBNull.Value);
        //    }
        //    htInsertDelivery.Add("@c_session_instructor", insertDelivery.c_session_instructor);
        //    htInsertDelivery.Add("@c_delivery_resources", insertDelivery.c_delivery_resources);
        //    htInsertDelivery.Add("@c_delivery_material", insertDelivery.c_delivery_material);



        //    try
        //    {
        //        return DataProxy.FetchSPOutput("c_course_sp_insert_delivery", htInsertDelivery);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// Update course delivery
        /// </summary>
        /// <param name="updateCourseDelivery"></param>
        /// <returns></returns>
        public static int UpdateCourseDelivery(SystemCatalog updateCourseDelivery)
        {
            Hashtable htUpdateCourseDelivery = new Hashtable();

            htUpdateCourseDelivery.Add("@c_delivery_system_id_pk", updateCourseDelivery.c_delivery_system_id_pk);
            //htUpdateCourseDelivery.Add("@c_course_id_fk", updateCourseDelivery.c_course_id_fk);
            htUpdateCourseDelivery.Add("@c_delivery_id_pk", updateCourseDelivery.c_delivery_id_pk);
            htUpdateCourseDelivery.Add("@c_delivery_type_id_fk", updateCourseDelivery.c_delivery_type_id_fk);
            htUpdateCourseDelivery.Add("@c_delivery_title", updateCourseDelivery.c_delivery_title);
            htUpdateCourseDelivery.Add("@c_delivery_desc", updateCourseDelivery.c_delivery_desc);
            htUpdateCourseDelivery.Add("@c_delivery_abstract", updateCourseDelivery.c_delivery_abstract);
            htUpdateCourseDelivery.Add("@c_delivery_approval_req", updateCourseDelivery.c_delivery_approval_req);
            htUpdateCourseDelivery.Add("@c_delivery_approval_id_fk", updateCourseDelivery.c_delivery_approval_id_fk);
            if (updateCourseDelivery.c_delivery_credit_hours != null)
            {
                htUpdateCourseDelivery.Add("@c_delivery_credit_hours", updateCourseDelivery.c_delivery_credit_hours);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_credit_hours", DBNull.Value);
            }
            if (updateCourseDelivery.c_delivery_credit_units != null)
            {
                htUpdateCourseDelivery.Add("@c_delivery_credit_units", updateCourseDelivery.c_delivery_credit_units);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_credit_units", DBNull.Value);
            }
            if (updateCourseDelivery.c_delivery_owner_id_fk != "")
            {
                htUpdateCourseDelivery.Add("@c_delivery_owner_id_fk", updateCourseDelivery.c_delivery_owner_id_fk);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_owner_id_fk", DBNull.Value);
            }

            if (updateCourseDelivery.c_delivery_coordinator_id_fk != "")
            {
                htUpdateCourseDelivery.Add("@c_delivery_coordinator_id_fk", updateCourseDelivery.c_delivery_coordinator_id_fk);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_coordinator_id_fk", DBNull.Value);
            }

            htUpdateCourseDelivery.Add("@c_delivery_active_flag", updateCourseDelivery.c_delivery_active_flag);
            htUpdateCourseDelivery.Add("@c_delivery_active_type_id_fk", updateCourseDelivery.c_delivery_active_type_id_fk);
            htUpdateCourseDelivery.Add("@c_delivery_visible_flag", updateCourseDelivery.c_delivery_visible_flag);
            if (updateCourseDelivery.c_delivery_min_enroll != null)
            {
                htUpdateCourseDelivery.Add("@c_delivery_min_enroll", updateCourseDelivery.c_delivery_min_enroll);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_min_enroll", DBNull.Value);
            }
            if (updateCourseDelivery.c_delivery_max_enroll != null)
            {
                htUpdateCourseDelivery.Add("@c_delivery_max_enroll", updateCourseDelivery.c_delivery_max_enroll);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_max_enroll", DBNull.Value);
            }
            if (updateCourseDelivery.c_delivery_enroll_threshold != null)
            {
                htUpdateCourseDelivery.Add("@c_delivery_enroll_threshold", updateCourseDelivery.c_delivery_enroll_threshold);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_enroll_threshold", DBNull.Value);
            }
            htUpdateCourseDelivery.Add("@c_delivery_waitlist_flag", updateCourseDelivery.c_delivery_waitlist_flag);
            if (updateCourseDelivery.c_delivery_max_waitlist != null)
            {
                htUpdateCourseDelivery.Add("@c_delivery_max_waitlist", updateCourseDelivery.c_delivery_max_waitlist);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_delivery_max_waitlist", DBNull.Value);
            }
            //if (updateCourseDelivery.c_survey_scoring_scheme_id_fk == "app_ddl_all_text")
            //{
                //htUpdateCourseDelivery.Add("@c_delivery_grading_scheme_id_fk", DBNull.Value);
            //}
            //else
            //{
                htUpdateCourseDelivery.Add("@c_delivery_grading_scheme_id_fk", updateCourseDelivery.c_survey_scoring_scheme_id_fk);
            //}
            

            htUpdateCourseDelivery.Add("@c_vlt_launch_url", updateCourseDelivery.c_vlt_launch_url);
            htUpdateCourseDelivery.Add("@c_olt_launch_url", updateCourseDelivery.c_olt_launch_url);
            htUpdateCourseDelivery.Add("@c_olt_launch_param", updateCourseDelivery.c_olt_launch_param);

            htUpdateCourseDelivery.Add("@c_delivery_custom_01", updateCourseDelivery.c_delivery_custom_01);
            htUpdateCourseDelivery.Add("@c_delivery_custom_02", updateCourseDelivery.c_delivery_custom_02);
            htUpdateCourseDelivery.Add("@c_delivery_custom_03", updateCourseDelivery.c_delivery_custom_03);
            htUpdateCourseDelivery.Add("@c_delivery_custom_04", updateCourseDelivery.c_delivery_custom_04);
            htUpdateCourseDelivery.Add("@c_delivery_custom_05", updateCourseDelivery.c_delivery_custom_05);
            htUpdateCourseDelivery.Add("@c_delivery_custom_06", updateCourseDelivery.c_delivery_custom_06);
            htUpdateCourseDelivery.Add("@c_delivery_custom_07", updateCourseDelivery.c_delivery_custom_07);
            htUpdateCourseDelivery.Add("@c_delivery_custom_08", updateCourseDelivery.c_delivery_custom_08);
            htUpdateCourseDelivery.Add("@c_delivery_custom_09", updateCourseDelivery.c_delivery_custom_09);
            htUpdateCourseDelivery.Add("@c_delivery_custom_10", updateCourseDelivery.c_delivery_custom_10);
            htUpdateCourseDelivery.Add("@c_delivery_custom_11", updateCourseDelivery.c_delivery_custom_11);
            htUpdateCourseDelivery.Add("@c_delivery_custom_12", updateCourseDelivery.c_delivery_custom_12);
            htUpdateCourseDelivery.Add("@c_delivery_custom_13", updateCourseDelivery.c_delivery_custom_13);
            htUpdateCourseDelivery.Add("@c_nc_olt_launch_url", updateCourseDelivery.c_nc_olt_launch_url);
            htUpdateCourseDelivery.Add("@c_nc_olt_launch_param", updateCourseDelivery.c_nc_olt_launch_param);
            htUpdateCourseDelivery.Add("@c_nc_olt_waitlist_flag", updateCourseDelivery.c_nc_olt_waitlist_flag);
            if (!string.IsNullOrEmpty(updateCourseDelivery.c_nc_olt_wrapper_id_fk))
            {
                htUpdateCourseDelivery.Add("@c_nc_olt_wrapper_id_fk", updateCourseDelivery.c_nc_olt_wrapper_id_fk);
            }
            else
            {
                htUpdateCourseDelivery.Add("@c_nc_olt_wrapper_id_fk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_update_delivery", htUpdateCourseDelivery);
            }
            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// GetDeliveryResourceMaterialAttachments
        /// </summary>
        /// <param name="c_delivery_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetDeliveries(string c_delivery_system_id_pk)
        {
            Hashtable htGetCourseDelivery = new Hashtable();
            htGetCourseDelivery.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);
            try
            {
                return DataProxy.FetchDataSet("c_course_sp_get_delivery", htGetCourseDelivery);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get course delivery
        /// </summary>
        /// <param name="c_delivery_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCatalog GetDelivery(string c_delivery_system_id_pk, DataTable dtDelivery)
        {
            SystemCatalog courseDelivery;

            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCourseDelivery = new Hashtable();
                htGetCourseDelivery.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);
                courseDelivery = new SystemCatalog();
                DataTable dtGetCourseDelivery = dtDelivery;
                courseDelivery.c_delivery_id_pk = dtGetCourseDelivery.Rows[0]["c_delivery_id_pk"].ToString();
                courseDelivery.c_delivery_type_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_type_id_fk"].ToString();
                courseDelivery.c_delivery_title = dtGetCourseDelivery.Rows[0]["c_delivery_title"].ToString();
                courseDelivery.c_delivery_desc = dtGetCourseDelivery.Rows[0]["c_delivery_desc"].ToString();
                courseDelivery.c_delivery_abstract = dtGetCourseDelivery.Rows[0]["c_delivery_abstract"].ToString();
                courseDelivery.c_delivery_approval_req = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_approval_req"]);
                courseDelivery.c_delivery_approval_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_approval_id_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_credit_hours"].ToString()))
                {
                    courseDelivery.c_delivery_credit_hours = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_credit_hours"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_credit_units"].ToString()))
                {
                    courseDelivery.c_delivery_credit_units = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_credit_units"]);
                }
                courseDelivery.c_delivery_owner_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_owner_id_fk"].ToString();
                courseDelivery.c_delivery_coordinator_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_coordinator_id_fk"].ToString();
                courseDelivery.c_delivery_active_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_active_flag"]);
                courseDelivery.c_delivery_active_type_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_active_type_id_fk"].ToString();
                courseDelivery.c_delivery_visible_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_visible_flag"]);
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_min_enroll"].ToString()))
                {
                    courseDelivery.c_delivery_min_enroll = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_min_enroll"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_max_enroll"].ToString()))
                {
                    courseDelivery.c_delivery_max_enroll = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_max_enroll"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_enroll_threshold"].ToString()))
                {
                    courseDelivery.c_delivery_enroll_threshold = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_enroll_threshold"]);
                }
                courseDelivery.c_delivery_waitlist_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_waitlist_flag"]);
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_max_waitlist"].ToString()))
                {
                    courseDelivery.c_delivery_max_waitlist = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_max_waitlist"]);
                }
                courseDelivery.c_vlt_launch_url = dtGetCourseDelivery.Rows[0]["c_vlt_launch_url"].ToString();
                courseDelivery.c_olt_launch_url = dtGetCourseDelivery.Rows[0]["c_olt_launch_url"].ToString();
                courseDelivery.c_olt_launch_param = dtGetCourseDelivery.Rows[0]["c_olt_launch_param"].ToString();
                courseDelivery.c_survey_scoring_scheme_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_grading_scheme_id_fk"].ToString();
                courseDelivery.c_delivery_custom_01 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_01"].ToString();
                courseDelivery.c_delivery_custom_02 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_02"].ToString();
                courseDelivery.c_delivery_custom_03 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_03"].ToString();
                courseDelivery.c_delivery_custom_04 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_04"].ToString();
                courseDelivery.c_delivery_custom_05 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_05"].ToString();
                courseDelivery.c_delivery_custom_06 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_06"].ToString();
                courseDelivery.c_delivery_custom_07 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_07"].ToString();
                courseDelivery.c_delivery_custom_08 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_08"].ToString();
                courseDelivery.c_delivery_custom_09 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_09"].ToString();
                courseDelivery.c_delivery_custom_10 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_10"].ToString();
                courseDelivery.c_delivery_custom_11 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_11"].ToString();
                courseDelivery.c_delivery_custom_12 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_12"].ToString();
                courseDelivery.c_delivery_custom_13 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_13"].ToString();
                courseDelivery.c_delivery_owner_name = dtGetCourseDelivery.Rows[0]["c_delivery_owner_name"].ToString();
                courseDelivery.c_delivery_coordinator_name = dtGetCourseDelivery.Rows[0]["c_delivery_coordinator_name"].ToString();
                courseDelivery.c_nc_olt_launch_url = dtGetCourseDelivery.Rows[0]["c_nc_olt_launch_url"].ToString();
                courseDelivery.c_nc_olt_launch_param = dtGetCourseDelivery.Rows[0]["c_nc_olt_launch_param"].ToString();
                courseDelivery.c_nc_olt_waitlist_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_nc_olt_waitlist_flag"]);
                courseDelivery.c_nc_olt_wrapper_id_fk = dtGetCourseDelivery.Rows[0]["c_nc_olt_wrapper_id_fk"].ToString();
                courseDelivery.c_delivery_approval_req_text = dtGetCourseDelivery.Rows[0]["c_delivery_approval_req_text"].ToString();
                courseDelivery.s_delivery_type_text = dtGetCourseDelivery.Rows[0]["s_delivery_type_text"].ToString();
                courseDelivery.c_waitlist_count = dtGetCourseDelivery.Rows[0]["waitlistcount"].ToString();
                courseDelivery.c_enroll_delivery_count = dtGetCourseDelivery.Rows[0]["c_enroll_delivery_count"].ToString();
                return courseDelivery;

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Instructor search
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static DataTable InstructorSearch(SystemCatalog catalog)
        {
            Hashtable htLocationSearch = new Hashtable();
            htLocationSearch.Add("@c_session_last_name", catalog.c_session_last_name);
            htLocationSearch.Add("@c_session_first_name", catalog.c_session_first_name);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_instructor_search", htLocationSearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Search authorized instructor
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static DataTable AuthorizedInstructorSearch(SystemCatalog catalog)
        {
            Hashtable htLocationSearch = new Hashtable();
            htLocationSearch.Add("@c_session_last_name", catalog.c_session_last_name);
            htLocationSearch.Add("@c_session_first_name", catalog.c_session_first_name);
            htLocationSearch.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_search_authorized_instructor", htLocationSearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Get CourseSession
        /// </summary>
        /// <param name="c_session_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCatalog GetCourseDeliverySession(string c_session_system_id_pk, DataTable dtSessions)
        {
            SystemCatalog courseSession;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCourseSession = new Hashtable();
                htGetCourseSession.Add("@c_session_system_id_pk", c_session_system_id_pk);

                courseSession = new SystemCatalog();
                DataTable dtGetCourseSession = dtSessions;

                courseSession.c_session_id_pk = dtGetCourseSession.Rows[0]["c_session_id_pk"].ToString();
                courseSession.c_delivery_id_pk = dtGetCourseSession.Rows[0]["c_delivery_id_fk"].ToString();
                courseSession.c_session_title = dtGetCourseSession.Rows[0]["c_session_title"].ToString();
                courseSession.c_sessions_desc = dtGetCourseSession.Rows[0]["c_sessions_desc"].ToString();

                if (!string.IsNullOrEmpty(dtGetCourseSession.Rows[0]["c_session_start_date"].ToString()))
                {
                    courseSession.c_session_start_date = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_start_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCourseSession.Rows[0]["c_session_end_date"].ToString()))
                {
                    courseSession.c_session_end_date = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_end_date"], culture);
                }
                courseSession.c_session_start_time = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_start_time"], culture);
                courseSession.c_sessions_end_time = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_sessions_end_time"], culture);
                courseSession.c_session_duration = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_duration"], culture);
                courseSession.c_session_location_id_fk = dtGetCourseSession.Rows[0]["c_session_location_id_fk"].ToString();
                courseSession.c_session_facility_id_fk = dtGetCourseSession.Rows[0]["c_session_facility_id_fk"].ToString();
                courseSession.c_session_room_id_fk = dtGetCourseSession.Rows[0]["c_sessions_room_id_fk"].ToString();
                courseSession.c_session_location_name = dtGetCourseSession.Rows[0]["c_location_name"].ToString();
                courseSession.c_session_facility_name = dtGetCourseSession.Rows[0]["c_facility_name"].ToString();
                courseSession.c_session_room_name = dtGetCourseSession.Rows[0]["c_room_name"].ToString();


                return courseSession;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Resource search
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static DataTable ResourceSearch(SystemCatalog catalog)
        {
            Hashtable htResourceSearch = new Hashtable();
            htResourceSearch.Add("@c_resource_id_pk", catalog.c_resource_id_pk);
            htResourceSearch.Add("@c_resource_name", catalog.c_resource_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_resource_search", htResourceSearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Material search
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static DataTable MaterialSearch(SystemCatalog catalog)
        {
            Hashtable htMaterialSearch = new Hashtable();
            htMaterialSearch.Add("@c_material_id_pk", catalog.c_material_id_pk);
            htMaterialSearch.Add("@c_material_name", catalog.c_material_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_material_search", htMaterialSearch);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// TempGetCourseDelivery
        /// </summary>
        /// <param name="c_delivery_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCatalog TempGetCourseDelivery(string c_delivery_system_id_pk, DataTable dtDelivery)
        {
            SystemCatalog courseDelivery;

            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCourseDelivery = new Hashtable();
                htGetCourseDelivery.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);

                courseDelivery = new SystemCatalog();
                DataTable dtGetCourseDelivery = dtDelivery;

                courseDelivery.c_delivery_id_pk = dtGetCourseDelivery.Rows[0]["c_delivery_id_pk"].ToString();
                courseDelivery.c_delivery_type_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_type_id_fk"].ToString();
                courseDelivery.c_delivery_title = dtGetCourseDelivery.Rows[0]["c_delivery_title"].ToString();
                courseDelivery.c_delivery_desc = dtGetCourseDelivery.Rows[0]["c_delivery_desc"].ToString();
                courseDelivery.c_delivery_abstract = dtGetCourseDelivery.Rows[0]["c_delivery_abstract"].ToString();
                courseDelivery.c_delivery_approval_req = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_approval_req"]);
                courseDelivery.c_delivery_approval_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_approval_id_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_credit_hours"].ToString()))
                {
                    courseDelivery.c_delivery_credit_hours = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_credit_hours"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_credit_units"].ToString()))
                {
                    courseDelivery.c_delivery_credit_units = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_credit_units"]);
                }
                courseDelivery.c_delivery_owner_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_owner_id_fk"].ToString();
                courseDelivery.c_delivery_coordinator_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_coordinator_id_fk"].ToString();
                courseDelivery.c_delivery_active_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_active_flag"]);
                courseDelivery.c_delivery_active_type_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_active_type_id_fk"].ToString();
                courseDelivery.c_delivery_visible_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_visible_flag"]);
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_min_enroll"].ToString()))
                {
                    courseDelivery.c_delivery_min_enroll = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_min_enroll"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_max_enroll"].ToString()))
                {
                    courseDelivery.c_delivery_max_enroll = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_max_enroll"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_enroll_threshold"].ToString()))
                {
                    courseDelivery.c_delivery_enroll_threshold = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_enroll_threshold"]);
                }
                courseDelivery.c_delivery_waitlist_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_delivery_waitlist_flag"]);
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_max_waitlist"].ToString()))
                {
                    courseDelivery.c_delivery_max_waitlist = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_max_waitlist"]);
                }
                courseDelivery.c_vlt_launch_url = dtGetCourseDelivery.Rows[0]["c_vlt_launch_url"].ToString();
                courseDelivery.c_olt_launch_url = dtGetCourseDelivery.Rows[0]["c_olt_launch_url"].ToString();
                courseDelivery.c_olt_launch_param = dtGetCourseDelivery.Rows[0]["c_olt_launch_param"].ToString();
                courseDelivery.c_delivery_custom_01 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_01"].ToString();
                courseDelivery.c_delivery_custom_02 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_02"].ToString();
                courseDelivery.c_delivery_custom_03 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_03"].ToString();
                courseDelivery.c_delivery_custom_04 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_04"].ToString();
                courseDelivery.c_delivery_custom_05 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_05"].ToString();
                courseDelivery.c_delivery_custom_06 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_06"].ToString();
                courseDelivery.c_delivery_custom_07 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_07"].ToString();
                courseDelivery.c_delivery_custom_08 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_08"].ToString();
                courseDelivery.c_delivery_custom_09 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_09"].ToString();
                courseDelivery.c_delivery_custom_10 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_10"].ToString();
                courseDelivery.c_delivery_custom_11 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_11"].ToString();
                courseDelivery.c_delivery_custom_12 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_12"].ToString();
                courseDelivery.c_delivery_custom_13 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_13"].ToString();
                courseDelivery.c_delivery_owner_name = dtGetCourseDelivery.Rows[0]["c_delivery_owner_name"].ToString();
                courseDelivery.c_delivery_coordinator_name = dtGetCourseDelivery.Rows[0]["c_delivery_coordinator_name"].ToString();

                courseDelivery.c_nc_olt_launch_url = dtGetCourseDelivery.Rows[0]["c_nc_olt_launch_url"].ToString();
                courseDelivery.c_nc_olt_launch_param = dtGetCourseDelivery.Rows[0]["c_nc_olt_launch_param"].ToString();
                courseDelivery.c_nc_olt_waitlist_flag = Convert.ToBoolean(dtGetCourseDelivery.Rows[0]["c_nc_olt_waitlist_flag"]);
                courseDelivery.c_nc_olt_wrapper_id_fk = dtGetCourseDelivery.Rows[0]["c_nc_olt_wrapper_id_fk"].ToString();
                return courseDelivery;

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// TempGetCourseSession
        /// </summary>
        /// <param name="c_session_system_id_pk"></param>
        /// <returns></returns>
        public static SystemCatalog TempGetCourseSession(string c_session_system_id_pk, DataTable dtSessions)
        {
            SystemCatalog courseSession;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCourseSession = new Hashtable();
                htGetCourseSession.Add("@c_session_system_id_pk", c_session_system_id_pk);

                courseSession = new SystemCatalog();
                DataTable dtGetCourseSession = dtSessions;

                courseSession.c_session_id_pk = dtGetCourseSession.Rows[0]["c_session_id_pk"].ToString();
                courseSession.c_delivery_id_pk = dtGetCourseSession.Rows[0]["c_delivery_id_fk"].ToString();
                courseSession.c_session_title = dtGetCourseSession.Rows[0]["c_session_title"].ToString();
                courseSession.c_sessions_desc = dtGetCourseSession.Rows[0]["c_sessions_desc"].ToString();

                if (!string.IsNullOrEmpty(dtGetCourseSession.Rows[0]["c_session_start_date"].ToString()))
                {
                    courseSession.c_session_start_date = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_start_date"], culture);
                }

                if (!string.IsNullOrEmpty(dtGetCourseSession.Rows[0]["c_session_end_date"].ToString()))
                {
                    courseSession.c_session_end_date = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_end_date"], culture);
                }
                courseSession.c_session_start_time = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_start_time"], culture);
                courseSession.c_sessions_end_time = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_sessions_end_time"], culture);
                courseSession.c_session_duration = Convert.ToDateTime(dtGetCourseSession.Rows[0]["c_session_duration"], culture);
                courseSession.c_session_location_id_fk = dtGetCourseSession.Rows[0]["c_session_location_id_fk"].ToString();
                courseSession.c_session_facility_id_fk = dtGetCourseSession.Rows[0]["c_session_facility_id_fk"].ToString();
                courseSession.c_session_room_id_fk = dtGetCourseSession.Rows[0]["c_sessions_room_id_fk"].ToString();
                courseSession.c_session_location_name = dtGetCourseSession.Rows[0]["c_location_name"].ToString();
                courseSession.c_session_facility_name = dtGetCourseSession.Rows[0]["c_facility_name"].ToString();
                courseSession.c_session_room_name = dtGetCourseSession.Rows[0]["c_room_name"].ToString();


                return courseSession;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Course Delivery Attachment
        /// </summary>
        /// <param name="insertDeliveryAttachment"></param>
        /// <returns></returns>
        public static int InsertDeliveryAttachment(SystemCatalog insertDeliveryAttachment)
        {
            Hashtable htInsertDeliveryAttachment = new Hashtable();


            htInsertDeliveryAttachment.Add("@c_delivery_id_fk", insertDeliveryAttachment.c_delivery_id_fk);
            htInsertDeliveryAttachment.Add("@c_delivery_attachment_file_guid", insertDeliveryAttachment.c_delivery_attachment_file_guid);
            htInsertDeliveryAttachment.Add("@c_delivery_attachment_file_name", insertDeliveryAttachment.c_delivery_attachment_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_delivery_attachment", htInsertDeliveryAttachment);
            }
            catch
            {
                throw;
            }


        }
        /// <summary>
        /// Update Course Delivery Attachment
        /// </summary>
        /// <param name="updateDeliveryAttachment"></param>
        /// <returns></returns>
        public static int UpdateDeliveryAttachment(SystemCatalog updateDeliveryAttachment)
        {
            Hashtable htUpdateDeliveryAttachment = new Hashtable();

            htUpdateDeliveryAttachment.Add("@c_delivery_attachment_id_pk", updateDeliveryAttachment.c_delivery_attachment_id_pk);
            htUpdateDeliveryAttachment.Add("@c_delivery_id_fk", updateDeliveryAttachment.c_delivery_id_fk);
            htUpdateDeliveryAttachment.Add("@c_delivery_attachment_file_guid", updateDeliveryAttachment.c_delivery_attachment_file_guid);
            htUpdateDeliveryAttachment.Add("@c_delivery_attachment_file_name", updateDeliveryAttachment.c_delivery_attachment_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_update_delivery_attachment", htUpdateDeliveryAttachment);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Course Delivery Attachment
        /// </summary>
        /// <param name="deleteDeliveryResource"></param>
        /// <returns></returns>
        public static int DeleteDeliveryResource(string c_course_resources_id_pk)
        {
            Hashtable htDeleteDeliveryResource = new Hashtable();

            htDeleteDeliveryResource.Add("@c_course_resources_id_pk", c_course_resources_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_delivery_resource", htDeleteDeliveryResource);
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// Delete Session Instructor
        /// </summary>
        /// <param name="deleteSessionInstructor"></param>
        /// <returns></returns>
        public static int DeleteSessionInstructor(string c_instructor_system_id_pk)
        {
            Hashtable htdeleteSessionInstructor = new Hashtable();

            htdeleteSessionInstructor.Add("@c_instructor_system_id_pk", c_instructor_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_session_instructor", htdeleteSessionInstructor);
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// Delete Delivery Material
        /// </summary>
        /// <param name="deleteDeliveryMaterial"></param>
        /// <returns></returns>
        public static int DeleteDeliveryMaterial(string c_course_material_id_pk)
        {
            Hashtable htDeleteDeliveryMaterial = new Hashtable();

            htDeleteDeliveryMaterial.Add("@c_course_material_id_pk", c_course_material_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_delivery_material", htDeleteDeliveryMaterial);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Delivery Resources
        /// </summary>
        /// <param name="insertDeliveryResources"></param>
        /// <returns></returns>
        public static int InsertDeliveryResources(string c_delivery_resources)
        {
            Hashtable htInsertDeliveryResources = new Hashtable();

            htInsertDeliveryResources.Add("@c_delivery_resources", c_delivery_resources);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_delivery_resources", htInsertDeliveryResources);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Session Instructors
        /// </summary>
        /// <param name="insertSessionInstructors"></param>
        /// <returns></returns>
        public static int InsertSessionInstructors(string c_sessions, string c_session_instructor, string c_course_id_fk, Boolean c_instructor_reset)
        {
            Hashtable htInsertSessionInstructor = new Hashtable();

            if (!string.IsNullOrEmpty(c_sessions))
            {
                htInsertSessionInstructor.Add("@c_sessions", c_sessions);
            }
            else
            {
                htInsertSessionInstructor.Add("@c_sessions", DBNull.Value);

            }
            //htInsertSessionInstructor.Add("@c_sessions", c_sessions);
            htInsertSessionInstructor.Add("@c_session_instructor", c_session_instructor);
            htInsertSessionInstructor.Add("@c_course_id_fk", c_course_id_fk);
            htInsertSessionInstructor.Add("@c_instructor_reset", c_instructor_reset);
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_session_instructors", htInsertSessionInstructor);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Insert Delivery Material
        /// </summary>
        /// <param name="insertDeliveryMaterial"></param>
        /// <returns></returns>
        public static int InsertDeliveryMaterial(string c_delivery_material)
        {
            Hashtable htInsertDeliveryMaterial = new Hashtable();

            htInsertDeliveryMaterial.Add("@c_delivery_material", c_delivery_material);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_delivery_materials", htInsertDeliveryMaterial);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// DeleteDelivery
        /// </summary>
        /// <param name="deleteDelivery"></param>
        /// <returns></returns>
        public static int DeleteDelivery(string c_delivery_system_id_pk)
        {
            Hashtable htDeleteDelivery = new Hashtable();

            htDeleteDelivery.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_delivery", htDeleteDelivery);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// GetCourseDelivery
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCourseDelivery(string c_course_id_fk)
        {
            Hashtable htGetCourseDelivery = new Hashtable();
            htGetCourseDelivery.Add("@c_course_id_fk", c_course_id_fk);
            try
            {
                return DataProxy.FetchDataSet("c_course_sp_get_course_delivery", htGetCourseDelivery);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Delete Course Session
        /// </summary>
        /// <param name="deleteCourseSession"></param>
        /// <returns></returns>
        public static int DeleteDeliverySession(string c_session_system_id_pk)
        {
            Hashtable htDeleteCourseSession = new Hashtable();

            htDeleteCourseSession.Add("@c_session_system_id_pk", c_session_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_session", htDeleteCourseSession);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// GetSessionInstructor
        /// </summary>
        /// <param name="c_session_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetSessionInstructor(string c_session_id_fk)
        {
            Hashtable htGetSessionInstructor = new Hashtable();
            htGetSessionInstructor.Add("@c_session_id_fk", c_session_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_session_instructors", htGetSessionInstructor);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// GetDeliveryAttachments
        /// </summary>
        /// <param name="c_delivery_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetDeliveryAttachments(string c_delivery_system_id_pk)
        {
            Hashtable htGetDeliveryInstructor = new Hashtable();
            htGetDeliveryInstructor.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_delivery_attachments", htGetDeliveryInstructor);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// DeleteDeliveryAttachment
        /// </summary>
        /// <param name="c_delivery_attachment_id_pk"></param>
        /// <returns></returns>
        public static int DeleteDeliveryAttachment(string @c_delivery_attachment_id_pk)
        {
            Hashtable htDeleteDeliveryAttachment = new Hashtable();

            htDeleteDeliveryAttachment.Add("@c_delivery_attachment_id_pk", c_delivery_attachment_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_delivery_attachment", htDeleteDeliveryAttachment);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Get session and instructor
        /// </summary>
        /// <param name="c_delivery_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetSessions(string c_session_system_id_pk)
        {
            Hashtable htGetSessionsAndInstructor = new Hashtable();
            htGetSessionsAndInstructor.Add("@c_session_system_id_pk", c_session_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_session", htGetSessionsAndInstructor);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update delivery session
        /// </summary>
        /// <param name="updateSession"></param>
        /// <returns></returns>
        public static int UpdateDeliverySession(SystemCatalog updateSession)
        {
            Hashtable htUpdateDeliverySession = new Hashtable();
            htUpdateDeliverySession.Add("@c_session_system_id_pk", updateSession.c_session_system_id_pk);
            htUpdateDeliverySession.Add("@c_session_id_pk", updateSession.c_session_id_pk);
            htUpdateDeliverySession.Add("@c_session_title", updateSession.c_session_title);
            htUpdateDeliverySession.Add("@c_sessions_desc", updateSession.c_sessions_desc);
            htUpdateDeliverySession.Add("@c_session_start_date", updateSession.c_session_start_date);
            htUpdateDeliverySession.Add("@c_session_end_date", updateSession.c_session_end_date);
            htUpdateDeliverySession.Add("@c_session_start_time", updateSession.c_session_start_time);
            htUpdateDeliverySession.Add("@c_sessions_end_time", updateSession.c_sessions_end_time);
            htUpdateDeliverySession.Add("@c_session_duration", updateSession.c_session_duration);
            if (updateSession.c_session_location_id_fk != "")
            {
                htUpdateDeliverySession.Add("@c_session_location_id_fk", updateSession.c_session_location_id_fk);
            }
            else
            {
                htUpdateDeliverySession.Add("@c_session_location_id_fk", DBNull.Value);
            }

            if (updateSession.c_session_facility_id_fk != "")
            {
                htUpdateDeliverySession.Add("@c_session_facility_id_fk", updateSession.c_session_facility_id_fk);
            }
            else
            {
                htUpdateDeliverySession.Add("@c_session_facility_id_fk", DBNull.Value);
            }

            if (updateSession.c_session_room_id_fk != "")
            {
                htUpdateDeliverySession.Add("@c_sessions_room_id_fk", updateSession.c_session_room_id_fk);
            }
            else
            {
                htUpdateDeliverySession.Add("@c_sessions_room_id_fk", DBNull.Value);
            }

            htUpdateDeliverySession.Add("@c_session_instructor", updateSession.c_session_instructor);
            htUpdateDeliverySession.Add("@c_course_id_fk", updateSession.c_course_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_update_delivery_session", htUpdateDeliverySession);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Domian
        /// </summary>
        /// <param name="c_course_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetCourseDomain(string c_course_system_id_pk)
        {
            Hashtable htGetCourseDomain = new Hashtable();
            htGetCourseDomain.Add("@c_course_system_id_pk", c_course_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_domain", htGetCourseDomain);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Insert Domain
        /// </summary>
        public static int InsertDomain(string c_related_domain_id_fk, string c_course_system_id_pk)
        {
            Hashtable htInsertDomain = new Hashtable();

            htInsertDomain.Add("@c_related_domain_id_fk", c_related_domain_id_fk);
            htInsertDomain.Add("@c_course_system_id_pk", c_course_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_insert_domain", htInsertDomain);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Domain
        /// </summary>
        public static int DeleteDomain(SystemCatalog course)
        {
            Hashtable htDeleteDomain = new Hashtable();
            htDeleteDomain.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            if (course.c_related_course_group_id != "")
            {
                htDeleteDomain.Add("@c_related_domain_id_fk", course.c_related_domain_id_fk);
            }
            else
            {
                htDeleteDomain.Add("@c_related_domain_id_fk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_delete_domain", htDeleteDomain);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateCourseNewVersion(SystemCatalog course)
        {
            Hashtable htNewVersion = new Hashtable();
            htNewVersion.Add("@c_course_system_id_pk", course.c_course_system_id_pk);
            htNewVersion.Add("@c_new_course_system_id_pk", course.c_new_course_system_id_pk);
            htNewVersion.Add("@c_course_version", course.c_course_version);
            htNewVersion.Add("@c_category", course.c_category);
            htNewVersion.Add("@c_domain", course.c_domain);
            htNewVersion.Add("@c_audiences", course.c_audiences);
            htNewVersion.Add("@c_recurrance", course.c_recurrance);
            htNewVersion.Add("@c_prerequisite", course.c_prerequisite);
            htNewVersion.Add("@c_equivalency", course.c_equivalency);
            htNewVersion.Add("@c_fulfillment", course.c_fulfillment);
            htNewVersion.Add("@c_delivery", course.c_delivery);
            htNewVersion.Add("@c_course_created_by_id_fk", course.c_course_created_by_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_course_sp_new_version", htNewVersion);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetCourseVersionList(string c_course_system_id_pk, int u_time_zone_id_pk)
        {
            Hashtable htGetVersionList = new Hashtable();
            htGetVersionList.Add("@u_time_zone_id_pk", u_time_zone_id_pk);
            htGetVersionList.Add("@c_course_system_id_pk", c_course_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_version_list", htGetVersionList);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAllHolidaySchedule()
        {

            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_all_holiday_schedule");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllWeekdaySchedule()
        {

            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_all_weekday_schedule");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Holiday
        /// </summary>
        /// <param name="s_holiday_date"></param>
        /// <returns></returns>
        public static DataTable GetHolidays(SystemCatalog getAllHolidays)
        {
            Hashtable htGetAllHolidays = new Hashtable();
            htGetAllHolidays.Add("@dtFromDate", getAllHolidays.dtFromDate);
            htGetAllHolidays.Add("@dtpEndDate", getAllHolidays.dtpEndDate);
            if (getAllHolidays.dtpStartDate != null)
            {
                htGetAllHolidays.Add("@dtpStartDate", getAllHolidays.dtpStartDate);
            }
            else
            {
                htGetAllHolidays.Add("@dtpStartDate", DBNull.Value);
            }
            if (getAllHolidays.dtpBreakOccuranceDate != null)
            {
                htGetAllHolidays.Add("@dtpBreakOccuranceDate", getAllHolidays.dtpBreakOccuranceDate);
            }
            else
            {
                htGetAllHolidays.Add("@dtpBreakOccuranceDate", DBNull.Value);
            }
            htGetAllHolidays.Add("@recurrenceEvery", getAllHolidays.recurrenceEvery);
            htGetAllHolidays.Add("@breakOccuranceCount", getAllHolidays.breakOccuranceCount);

            htGetAllHolidays.Add("@u_holiday_schedule_system_id_pk", getAllHolidays.u_holiday_schedule_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_holidays", htGetAllHolidays);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetWeekdays(SystemCatalog getAllWeekDays)
        {
            Hashtable htGetAllWeekdays = new Hashtable();
            htGetAllWeekdays.Add("@dtFromDate", getAllWeekDays.dtFromDate);
            htGetAllWeekdays.Add("@dtpEndDate", getAllWeekDays.dtpEndDate);
            if (getAllWeekDays.dtpStartDate != null)
            {
                htGetAllWeekdays.Add("@dtpStartDate", getAllWeekDays.dtpStartDate);
            }
            else
            {
                htGetAllWeekdays.Add("@dtpStartDate", DBNull.Value);
            }
            if (getAllWeekDays.dtpBreakOccuranceDate != null)
            {
                htGetAllWeekdays.Add("@dtpBreakOccuranceDate", getAllWeekDays.dtpBreakOccuranceDate);
            }
            else
            {
                htGetAllWeekdays.Add("@dtpBreakOccuranceDate", DBNull.Value);
            }
            htGetAllWeekdays.Add("@recurrenceEvery", getAllWeekDays.recurrenceEvery);
            htGetAllWeekdays.Add("@breakOccuranceCount", getAllWeekDays.breakOccuranceCount);
            htGetAllWeekdays.Add("@s_weekday_schedule_system_id_pk", getAllWeekDays.s_weekday_schedule_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_weekdays", htGetAllWeekdays);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllWeekdaysAndHolidays(SystemCatalog getAllWeekdaysAndHolidays)
        {
            Hashtable htGetAllWeekdaysAndHolidays = new Hashtable();
            htGetAllWeekdaysAndHolidays.Add("@dtFromDate", getAllWeekdaysAndHolidays.dtFromDate);
            htGetAllWeekdaysAndHolidays.Add("@dtpEndDate", getAllWeekdaysAndHolidays.dtpEndDate);
            htGetAllWeekdaysAndHolidays.Add("@recurrenceEvery", getAllWeekdaysAndHolidays.recurrenceEvery);
            htGetAllWeekdaysAndHolidays.Add("@breakOccuranceCount", getAllWeekdaysAndHolidays.breakOccuranceCount);
            if (getAllWeekdaysAndHolidays.dtpStartDate != null)
            {
                htGetAllWeekdaysAndHolidays.Add("@dtpStartDate", getAllWeekdaysAndHolidays.dtpStartDate);
            }
            else
            {
                htGetAllWeekdaysAndHolidays.Add("@dtpStartDate", DBNull.Value);
            }
            if (getAllWeekdaysAndHolidays.dtpBreakOccuranceDate != null)
            {
                htGetAllWeekdaysAndHolidays.Add("@dtpBreakOccuranceDate", getAllWeekdaysAndHolidays.dtpBreakOccuranceDate);
            }
            else
            {
                htGetAllWeekdaysAndHolidays.Add("@dtpBreakOccuranceDate", DBNull.Value);
            }
            if (getAllWeekdaysAndHolidays.u_holiday_schedule_system_id_pk != null)
            {
                htGetAllWeekdaysAndHolidays.Add("@u_holiday_schedule_system_id_pk", getAllWeekdaysAndHolidays.u_holiday_schedule_system_id_pk);
            }
            else
            {
                htGetAllWeekdaysAndHolidays.Add("@u_holiday_schedule_system_id_pk", DBNull.Value);
            }
            if (getAllWeekdaysAndHolidays.s_weekday_schedule_system_id_pk != null)
            {
                htGetAllWeekdaysAndHolidays.Add("@s_weekday_schedule_system_id_pk", getAllWeekdaysAndHolidays.s_weekday_schedule_system_id_pk);
            }
            else
            {
                htGetAllWeekdaysAndHolidays.Add("@s_weekday_schedule_system_id_pk", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_all_weekdays_holidays", htGetAllWeekdaysAndHolidays);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemCatalog GetSingleDeliveryList(string c_delivery_system_id_pk)
        {
            try
            {
                SystemCatalog deliveryList = new SystemCatalog();
                Hashtable htDeliveryList = new Hashtable();
                htDeliveryList.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);
                DataTable dtDeliveryList = DataProxy.FetchDataTable("c_sp_get_single_delivery_list", htDeliveryList);
                deliveryList.c_session_location_names = dtDeliveryList.Rows[0]["locations"].ToString();
                deliveryList.c_session_facility_names = dtDeliveryList.Rows[0]["facilities"].ToString();
                deliveryList.c_session_room_names = dtDeliveryList.Rows[0]["rooms"].ToString();
                deliveryList.c_session_list = dtDeliveryList.Rows[0]["sessionids"].ToString();
                deliveryList.c_instructor_list = dtDeliveryList.Rows[0]["instructors"].ToString();
                deliveryList.c_delivery_list = dtDeliveryList.Rows[0]["deliveries"].ToString();
                deliveryList.c_course_list = dtDeliveryList.Rows[0]["course"].ToString();
                deliveryList.c_session_start_date_time = dtDeliveryList.Rows[0]["session_start_date"].ToString();
                deliveryList.c_session_end_date_time = dtDeliveryList.Rows[0]["session_end_date"].ToString();
                deliveryList.c_created_name = dtDeliveryList.Rows[0]["name"].ToString();
                deliveryList.c_to_address = dtDeliveryList.Rows[0]["toaddress"].ToString();
                deliveryList.c_course_title = dtDeliveryList.Rows[0]["c_course_title"].ToString();
                deliveryList.c_course_id_pk = dtDeliveryList.Rows[0]["c_course_id_pk"].ToString();
                deliveryList.c_delivery_type_id = dtDeliveryList.Rows[0]["deliveryType"].ToString();
                return deliveryList;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetApprovalForCourse(string s_ui_locale_name)
        {
            Hashtable htGetApproval = new Hashtable();
            htGetApproval.Add("@s_ui_locale_name", s_ui_locale_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_approval_name", htGetApproval);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemCatalog GetSessionDate(string c_delivery_id_pk)
        {
            SystemCatalog sessionDate = new SystemCatalog();
            Hashtable htGetSessionDate = new Hashtable();
            htGetSessionDate.Add("@c_delivery_id_pk", c_delivery_id_pk);
            DataTable dtDeliveryList = DataProxy.FetchDataTable("c_course_sp_get_single_session_date", htGetSessionDate);
            try
            {
                if (dtDeliveryList.Rows.Count > 0)
                {
                    sessionDate.c_session_location_names = dtDeliveryList.Rows[0]["c_location_name"].ToString();
                    sessionDate.c_session_facility_names = dtDeliveryList.Rows[0]["c_facility_name"].ToString();
                    sessionDate.c_session_room_names = dtDeliveryList.Rows[0]["c_room_name"].ToString();
                    sessionDate.c_session_date_format = dtDeliveryList.Rows[0]["c_session_date"].ToString();
                }
                return sessionDate;
            }

            catch (Exception)
            {
                throw;
            }


        }



        public static DataTable GetSessionByCourseID(string c_course_id_fk)
        {
            Hashtable htGetSessionByCourseID = new Hashtable();
            htGetSessionByCourseID.Add("@c_course_id_fk", c_course_id_fk);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_session_by_course_id", htGetSessionByCourseID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Copy Single Session
        /// </summary>
        /// <param name="c_session_system_id_pk"></param>
        /// <returns></returns>
        public static int CopySingleSession(string c_session_system_id_pk, string c_delivery_id_fk)
        {
            try
            {
                Hashtable htCopySingleSession = new Hashtable();
                htCopySingleSession.Add("@c_session_system_id_pk", c_session_system_id_pk);
                htCopySingleSession.Add("@c_delivery_id_fk", c_delivery_id_fk);
                return DataProxy.FetchSPOutput("c_course_sp_copy_single_session", htCopySingleSession);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get instructor Type
        /// </summary>
        /// <param name="s_locale"></param>
        /// <returns></returns>
        public static DataTable GetInstructorType(string s_locale)
        {

            try
            {
                Hashtable htGetCourseDetails = new Hashtable();
                htGetCourseDetails.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("c_sp_get_instructor_type", htGetCourseDetails);
            }

            catch (Exception)
            {
                throw;
            }


        }

      /// <summary>
      /// check maximum one primary instructor per session
      /// </summary>
      /// <param name="c_session_instructor"></param>
      /// <returns></returns>
        public static bool checkMaximumOnePrimaryInstructors(string c_session_instructor)
        {
            Hashtable htInsertSessionInstructor = new Hashtable();
            htInsertSessionInstructor.Add("@c_session_instructor", c_session_instructor);
            try
            {
                int res = DataProxy.FetchSPOutput("c_course_check_max_one_primary_instructor", htInsertSessionInstructor);
                return res == 1 ? true : false;
            }
            catch
            {
                throw;
            }
        }


    }
}






