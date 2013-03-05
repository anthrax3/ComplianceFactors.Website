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
    public class EmployeeCatalogBLL
    {
        public static DataTable QuickSearchResult(string keyWord)
        {

            Hashtable htQuickSearchResult = new Hashtable();
            htQuickSearchResult.Add("@Search", keyWord);
            try
            {
                return DataProxy.FetchDataTable("c_sp_catalog_quick_search", htQuickSearchResult);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetCatalogType(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetCatalogType = new Hashtable();
                htGetCatalogType.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetCatalogType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_sp_get_catalog_type",htGetCatalogType);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDeliveryType()
        {
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_delivery_type");
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetLocalelist()
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

        public static DataTable SearchCatalog(EmployeeCatalog catalog)
        {


            Hashtable htSearchCatalog = new Hashtable();
            htSearchCatalog.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htSearchCatalog.Add("@Keyword", catalog.keyword);
            htSearchCatalog.Add("@c_course_title", catalog.c_course_title);
            if (string.IsNullOrEmpty(catalog.c_type) || catalog.c_type == "app_ddl_all_text")
            {
                htSearchCatalog.Add("@c_type", DBNull.Value);
            }
            else
            {
                htSearchCatalog.Add("@c_type", catalog.c_type);

            }
            if (catalog.c_delivery_id_fk == "app_ddl_all_text")
            {
                htSearchCatalog.Add("@c_delivery_type_id_pk", DBNull.Value);
            }
            else
            {
                htSearchCatalog.Add("@c_delivery_type_id_pk", catalog.c_delivery_id_fk);
            }
            if (catalog.c_language == "1" || catalog.c_language == "" || catalog.c_language == null)
            {
                htSearchCatalog.Add("@c_language", DBNull.Value);
            }
            else
            {
                htSearchCatalog.Add("@c_language", catalog.c_language);
            }

            try
            {
                return DataProxy.FetchDataTable("c_sp_search_catalog", htSearchCatalog);

            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMainCategory()
        {
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_main_categories");
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetParentCategory(string s_locale)
        {
            try
            {
                Hashtable htGetParentCategory = new Hashtable();
                htGetParentCategory.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("c_sp_get_parent_category",htGetParentCategory);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetChildCategory(string s_parent_category_id,string s_locale)
        {
            Hashtable htGetChildCategory = new Hashtable();
            htGetChildCategory.Add("@s_parent_category_id", s_parent_category_id);
            htGetChildCategory.Add("@s_locale", s_locale);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_child_category", htGetChildCategory);
            }
            catch (Exception)
            {
                throw;
            }

        }
        //public static DataTable GetSubCategory(string parentCategoryID)
        //{
        //    Hashtable htGetSubCategory = new Hashtable();
        //    htGetSubCategory.Add("@ParentCategoryID", parentCategoryID);
        //    try
        //    {
        //        return DataProxy.FetchDataTable("c_sp_get_sub_categories", htGetSubCategory);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
        public static DataTable GetBrowseCatalogResult(string categoryid)
        {
            Hashtable htBrowseCatalogResult = new Hashtable();
            htBrowseCatalogResult.Add("@categoryid", categoryid);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_browse_catalog_result", htBrowseCatalogResult);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static EmployeeCatalog GetCategory(string categoryid)
        {

            EmployeeCatalog catalog;
            try
            {

                Hashtable htGetCategory = new Hashtable();
                htGetCategory.Add("@CategoryID", categoryid);
                catalog = new EmployeeCatalog();
                DataTable dtGetCategory = DataProxy.FetchDataTable("c_sp_get_category", htGetCategory);
                catalog.categoryName = dtGetCategory.Rows[0]["CategoryName"].ToString();
                return catalog;
            }

            catch (Exception)
            {
                throw;
            }

        }
        //c_sp_get_catalog_category
        //12
        public static EmployeeCatalog GetCatalogCategory(string s_category_system_id_pk)
        {

            EmployeeCatalog catalog;
            try
            {

                Hashtable htGetCategory = new Hashtable();
                htGetCategory.Add("@s_category_system_id_pk", s_category_system_id_pk);
                catalog = new EmployeeCatalog();
                DataTable dtGetCategory = DataProxy.FetchDataTable("c_sp_get_catalog_category", htGetCategory);
                catalog.categoryName = dtGetCategory.Rows[0]["s_category_name"].ToString();
                return catalog;
            }

            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetCourse(string courseId)
        {

            Hashtable htGetCourse = new Hashtable();
            htGetCourse.Add("@c_course_system_id_pk", courseId);
            try
            {
                return DataProxy.FetchDataTable("c_sp_get_course", htGetCourse);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static EmployeeCatalog GetCourseDetails(string courseId)
        {

            EmployeeCatalog courseDetails;
            try
            {

                Hashtable htCourseDetails = new Hashtable();
                htCourseDetails.Add("@c_course_system_id_pk", courseId);
                courseDetails = new EmployeeCatalog();
                DataTable dtGetCategory = DataProxy.FetchDataTable("c_sp_get_course", htCourseDetails);
                courseDetails.c_course_title = dtGetCategory.Rows[0]["c_course_title"].ToString();
                courseDetails.c_course_id_pk = dtGetCategory.Rows[0]["c_course_id_pk"].ToString();
                courseDetails.c_course_recurrences_text = dtGetCategory.Rows[0]["c_course_recurrences_text"].ToString();
                return courseDetails;
            }

            catch (Exception)
            {
                throw;
            }

        }
        public static DataSet GetOLT(string courseId)
        {
            Hashtable htGetOLTDelivery = new Hashtable();
            htGetOLTDelivery.Add("@c_course_system_id_pk", courseId);
            return DataProxy.FetchDataSet("c_sp_get_olt_delivery", htGetOLTDelivery);
        }
        public static EmployeeCatalog GetSingleOLTDelivery(string courseId, DataTable dtOLTDelivery)
        {
            try
            {
                Hashtable htGetOLTDelivery = new Hashtable();
                htGetOLTDelivery.Add("@c_course_system_id_pk", courseId);
                EmployeeCatalog getOLTDelivery = new EmployeeCatalog();
                DataTable dtGetOLTDelivery = dtOLTDelivery;
                if (dtGetOLTDelivery.Rows.Count > 0)
                {
                    getOLTDelivery.c_delivery_type_text = dtGetOLTDelivery.Rows[0]["s_delivery_type_name_us_english"].ToString();
                    getOLTDelivery.c_delivery_approval_req = Convert.ToBoolean(dtGetOLTDelivery.Rows[0]["c_delivery_approval_req"]);
                    getOLTDelivery.c_delivery_id_fk = dtGetOLTDelivery.Rows[0]["c_delivery_system_id_pk"].ToString();
                    getOLTDelivery.c_delivery_count = Convert.ToInt32(dtGetOLTDelivery.Rows[0]["c_delivery_count"]);
                }
                return getOLTDelivery;

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool GetApprovalDelivery(string courseId, DataTable dtDelivery)
        {
            try
            {
                Hashtable htGetApprovalDelivery = new Hashtable();
                htGetApprovalDelivery.Add("@c_course_system_id_pk", courseId);
                DataTable dtGetOLTDelivery = dtDelivery;
                if (dtGetOLTDelivery.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dtGetOLTDelivery.Rows[0]["c_delivery_approval_req"]);
                }
                else
                {
                    return false;
                }
               

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
