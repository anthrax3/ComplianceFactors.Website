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
    public class SystemCatalogBLL_Old
    {
        public static DataTable GetCourseStatus()
        {


            try
            {
                return DataProxy.FetchDataTable("c_course_sp_get_status");
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
            htSearchCourse.Add("@c_course_active_flag", catalog.c_course_active_flag);
            htSearchCourse.Add("@c_course_owner_name", catalog.c_course_owner_name);
            htSearchCourse.Add("@c_course_coordinator_name", catalog.c_course_coordinator_name);
            try
            {
                return DataProxy.FetchDataTable("c_system_catalog_sp_search_course", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// CreateNewSystemCatalog 
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns>0-Success, 1-failure</returns>
        public static int CreateNewSystemCatalog(SystemCatalog catalog)
        {
            Hashtable htNewCourse = new Hashtable();
            htNewCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htNewCourse.Add("@c_course_desc", catalog.c_course_desc);
            htNewCourse.Add("@c_course_abstract", catalog.c_course_abstract);
            htNewCourse.Add("@c_course_icon_uri", catalog.c_course_icon_uri);
            htNewCourse.Add("@c_course_version", catalog.c_course_version);
            htNewCourse.Add("@c_course_approval_req", catalog.c_course_approval_req);
            htNewCourse.Add("@c_course_approval_id_fk", catalog.c_course_approval_id_fk);
            htNewCourse.Add("@c_course_credit_hours", catalog.c_course_credit_hours);
            htNewCourse.Add("@c_course_credit_units", catalog.c_course_credit_units);
            htNewCourse.Add("@c_course_cert_flag", catalog.c_course_cert_flag);
            htNewCourse.Add("@c_course_cert_cycle_days", catalog.c_course_cert_cycle_days);
            htNewCourse.Add("@c_course_cert_grace_days", catalog.c_course_cert_grace_days);
            htNewCourse.Add("@c_course_cert_date", catalog.c_course_cert_date);
            htNewCourse.Add("@c_course_owner_id_fk", catalog.c_course_owner_id_fk);
            htNewCourse.Add("@c_course_coordinator_id_fk", catalog.c_course_coordinator_id_fk);
            htNewCourse.Add("@c_course_active_flag", catalog.c_course_active_flag);
            htNewCourse.Add("@c_course_active_type_id_fk", catalog.c_course_active_type_id_fk);
            htNewCourse.Add("@c_course_visible_flag", catalog.c_course_visible_flag);
            htNewCourse.Add("@c_course_custom_01", catalog.c_course_custom_01);
            htNewCourse.Add("@c_course_custom_02", catalog.c_course_custom_02);
            htNewCourse.Add("@c_course_custom_03", catalog.c_course_custom_03);
            htNewCourse.Add("@c_course_custom_04", catalog.c_course_custom_04);
            htNewCourse.Add("@c_course_custom_05", catalog.c_course_custom_05);
            htNewCourse.Add("@c_course_custom_06", catalog.c_course_custom_06);
            htNewCourse.Add("@c_course_custom_07", catalog.c_course_custom_07);
            htNewCourse.Add("@c_course_custom_08", catalog.c_course_custom_08);
            htNewCourse.Add("@c_course_custom_09", catalog.c_course_custom_09);
            htNewCourse.Add("@c_course_custom_10", catalog.c_course_custom_10);
            htNewCourse.Add("@c_course_custom_11", catalog.c_course_custom_11);
            htNewCourse.Add("@c_course_custom_12", catalog.c_course_custom_12);
            htNewCourse.Add("@c_course_custom_13", catalog.c_course_custom_13);
            htNewCourse.Add("@c_course_title", catalog.c_course_title);
            htNewCourse.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            htNewCourse.Add("@c_course_Prerequistist", catalog.c_course_Prerequistist);
            htNewCourse.Add("@c_course_Equivalencies", catalog.c_course_Equivalencies);
            htNewCourse.Add("@c_course_Fulfillments", catalog.c_course_Fulfillments);

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
        /// UpdateSystemCatalog
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>

        public static int UpdateSystemCatalog(SystemCatalog catalog)
        {
            Hashtable htUpdateCourse = new Hashtable();
            htUpdateCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htUpdateCourse.Add("@c_course_desc", catalog.c_course_desc);
            htUpdateCourse.Add("@c_course_abstract", catalog.c_course_abstract);
            htUpdateCourse.Add("@c_course_icon_uri", catalog.c_course_icon_uri);
            htUpdateCourse.Add("@c_course_version", catalog.c_course_version);
            htUpdateCourse.Add("@c_course_approval_req", catalog.c_course_approval_req);
            htUpdateCourse.Add("@c_course_approval_id_fk", catalog.c_course_approval_id_fk);
            htUpdateCourse.Add("@c_course_credit_hours", catalog.c_course_credit_hours);
            htUpdateCourse.Add("@c_course_credit_units", catalog.c_course_credit_units);
            htUpdateCourse.Add("@c_course_cert_flag", catalog.c_course_cert_flag);
            htUpdateCourse.Add("@c_course_cert_cycle_days", catalog.c_course_cert_cycle_days);
            htUpdateCourse.Add("@c_course_cert_grace_days", catalog.c_course_cert_grace_days);
            htUpdateCourse.Add("@c_course_cert_date", catalog.c_course_cert_date);
            htUpdateCourse.Add("@c_course_owner_id_fk", catalog.c_course_owner_id_fk);
            htUpdateCourse.Add("@c_course_coordinator_id_fk", catalog.c_course_coordinator_id_fk);
            htUpdateCourse.Add("@c_course_active_flag", catalog.c_course_active_flag);
            htUpdateCourse.Add("@c_course_active_type_id_fk", catalog.c_course_active_type_id_fk);
            htUpdateCourse.Add("@c_course_visible_flag", catalog.c_course_visible_flag);
            htUpdateCourse.Add("@c_course_custom_01", catalog.c_course_custom_01);
            htUpdateCourse.Add("@c_course_custom_02", catalog.c_course_custom_02);
            htUpdateCourse.Add("@c_course_custom_03", catalog.c_course_custom_03);
            htUpdateCourse.Add("@c_course_custom_04", catalog.c_course_custom_04);
            htUpdateCourse.Add("@c_course_custom_05", catalog.c_course_custom_05);
            htUpdateCourse.Add("@c_course_custom_06", catalog.c_course_custom_06);
            htUpdateCourse.Add("@c_course_custom_07", catalog.c_course_custom_07);
            htUpdateCourse.Add("@c_course_custom_08", catalog.c_course_custom_08);
            htUpdateCourse.Add("@c_course_custom_09", catalog.c_course_custom_09);
            htUpdateCourse.Add("@c_course_custom_10", catalog.c_course_custom_10);
            htUpdateCourse.Add("@c_course_custom_11", catalog.c_course_custom_11);
            htUpdateCourse.Add("@c_course_custom_12", catalog.c_course_custom_12);
            htUpdateCourse.Add("@c_course_custom_13", catalog.c_course_custom_13);
            htUpdateCourse.Add("@c_course_title", catalog.c_course_title);
            htUpdateCourse.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
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
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static int UpdateSystemCatalogPrerequistist(SystemCatalog catalog)
        {
            Hashtable htUpdateCoursePrerequistist = new Hashtable();
            htUpdateCoursePrerequistist.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            htUpdateCoursePrerequistist.Add("@c_course_prerequistist", catalog.c_course_Prerequistist);
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
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static int UpdateSystemCatalogEquivalencies(SystemCatalog catalog)
        {
            Hashtable htUpdateCourseEquivalencies = new Hashtable();
            htUpdateCourseEquivalencies.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            htUpdateCourseEquivalencies.Add("@c_course_equivalencies", catalog.c_course_Equivalencies);
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
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static int UpdateSystemCatalogFulfillments(SystemCatalog catalog)
        {
            Hashtable htUpdateCourseFulfillments = new Hashtable();
            htUpdateCourseFulfillments.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            htUpdateCourseFulfillments.Add("@c_course_fulfillments", catalog.c_course_Fulfillments);
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
        /// c_get_Particular_course_Master
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns>Single Catalog record</returns>
        public static DataSet GetParticularCourse(SystemCatalog catalog)
        {
            Hashtable htCourse = new Hashtable();
            htCourse.Add("@c_course_system_id_pk", catalog.c_course_system_id_pk);
            try
            {
                return DataProxy.FetchDataSet("c_get_Particular_course_Master", htCourse);

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


    }

}
