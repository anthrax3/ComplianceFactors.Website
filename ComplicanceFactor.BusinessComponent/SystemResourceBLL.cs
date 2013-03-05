using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemResourceBLL
    {
        /// <summary>
        /// Create the Resource
        /// </summary>
        /// <param name="createResource"></param>
        /// <returns></returns>
        public static int CreateNewResource(SystemResource createResource)
        {
            Hashtable htCreateResource = new Hashtable();
            htCreateResource.Add("@c_resource_system_id_pk", createResource.c_resource_system_id_pk);
            htCreateResource.Add("@c_resource_id_pk", createResource.c_resource_id_pk);
            htCreateResource.Add("@c_resource_name", createResource.c_resource_name);
            htCreateResource.Add("@c_resource_description", createResource.c_resource_description);
            htCreateResource.Add("@c_resource_serial_number", createResource.c_resource_serial_number);
            htCreateResource.Add("@c_resource_status_id", createResource.c_resource_status_id);
            htCreateResource.Add("@c_resource_type_id_fk", createResource.c_resource_type_id_fk);
            if (!string.IsNullOrEmpty(createResource.s_resource_locale))
            {
                htCreateResource.Add("@s_resource_locale", createResource.s_resource_locale);
            }
            else
            {
                htCreateResource.Add("@s_resource_locale", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_resource", htCreateResource);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update the resource
        /// </summary>
        /// <param name="updateResource"></param>
        /// <returns></returns>
        public static int UpdateResource(SystemResource updateResource)
        {
            Hashtable htUpdateResource = new Hashtable();
            htUpdateResource.Add("@c_resource_system_id_pk", updateResource.c_resource_system_id_pk);
            htUpdateResource.Add("@c_resource_id_pk", updateResource.c_resource_id_pk);
            htUpdateResource.Add("@c_resource_name", updateResource.c_resource_name);
            htUpdateResource.Add("@c_resource_description", updateResource.c_resource_description);
            htUpdateResource.Add("@c_resource_serial_number", updateResource.c_resource_serial_number);
            htUpdateResource.Add("@c_resource_status_id", updateResource.c_resource_status_id);
            htUpdateResource.Add("@c_resource_type_id_fk", updateResource.c_resource_type_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_resource", htUpdateResource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get the status
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
        /// <returns></returns>
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
        /// <summary>
        /// Get Resource Type
        /// </summary>
        /// <returns></returns>
        public static DataTable GetResourceType(string s_locale)
        {
            try
            {
                Hashtable htGetResourceType = new Hashtable();
                if (!string.IsNullOrEmpty(s_locale))
                {
                    htGetResourceType.Add("@s_locale", s_locale);
                }
                else
                {
                    htGetResourceType.Add("@s_locale", DBNull.Value);
                }
                return DataProxy.FetchDataTable("s_sp_get_resource_type", htGetResourceType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the single Resource
        /// </summary>
        /// <param name="c_resource_system_id_pk"></param>
        /// <returns></returns>
        public static SystemResource GetSingleResource(string c_resource_system_id_pk, DataTable dtResource)
        {
            SystemResource getResource = new SystemResource();
            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@c_resource_system_id_pk", c_resource_system_id_pk);
                DataTable dtSingleResource = dtResource;
                getResource.c_resource_id_pk = dtSingleResource.Rows[0]["c_resource_id_pk"].ToString();
                getResource.c_resource_name = dtSingleResource.Rows[0]["c_resource_name"].ToString();
                getResource.c_resource_description = dtSingleResource.Rows[0]["c_resource_description"].ToString();
                getResource.c_resource_serial_number = dtSingleResource.Rows[0]["c_resource_serial_number"].ToString();
                getResource.c_resource_status_id = dtSingleResource.Rows[0]["c_resource_status_id"].ToString();
                getResource.c_resource_type_id_fk = dtSingleResource.Rows[0]["c_resource_type_id_fk"].ToString();


                return getResource;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get resource
        /// </summary>
        /// <param name="c_resource_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetResource(string c_resource_system_id_pk)
        {
            try
            {
                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@c_resource_system_id_pk", c_resource_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_single_resource", htGetResource);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Search Resources 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static DataTable SearchResources(SystemResource resource)
        {
            Hashtable htSearchResource = new Hashtable();
            htSearchResource.Add("@c_resource_id_pk", resource.c_resource_id_pk);
            htSearchResource.Add("@c_resource_name", resource.c_resource_name);
            htSearchResource.Add("@c_resource_serial_number", resource.c_resource_serial_number);
            if (resource.c_resource_type_id_fk == "0")
                htSearchResource.Add("@c_resource_type_id_fk", DBNull.Value);
            else
                htSearchResource.Add("@c_resource_type_id_fk", resource.c_resource_type_id_fk);

            if (resource.c_resource_status_id == "0")
                htSearchResource.Add("@c_resource_status_id", DBNull.Value);
            else
                htSearchResource.Add("@c_resource_status_id", resource.c_resource_status_id);


            try
            {
                return DataProxy.FetchDataTable("s_sp_search_resource", htSearchResource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update status of the resource
        /// </summary>
        /// <param name="c_resource_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateResourceStatus(string c_resource_system_id_pk)
        {
            Hashtable htUpdateResourceStatus = new Hashtable();
            htUpdateResourceStatus.Add("@c_resource_system_id_pk", c_resource_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_resource_status", htUpdateResourceStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertResourceLocale(SystemResource resLocale)
        {
            Hashtable htInsertResourceLocale = new Hashtable();
            htInsertResourceLocale.Add("@s_resource_system_id_fk", resLocale.s_resource_system_id_fk);
            htInsertResourceLocale.Add("@s_resource_locale_name", resLocale.s_resource_locale_name);
            htInsertResourceLocale.Add("@s_resource_locale_description", resLocale.s_resource_locale_description);
            htInsertResourceLocale.Add("@s_locale_id_fk", resLocale.s_locale_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_resource_locale", htInsertResourceLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update resource locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateResourceLocale(SystemResource resLocale)
        {
            Hashtable htUpdateResourceLocale = new Hashtable();
            htUpdateResourceLocale.Add("@s_resource_locale_system_id_pk", resLocale.s_resource_locale_system_id_pk);
            if (!string.IsNullOrEmpty(resLocale.s_resource_locale_name))
            {
                htUpdateResourceLocale.Add("@s_resource_locale_name", resLocale.s_resource_locale_name);
            }
            else
            {
                htUpdateResourceLocale.Add("@s_resource_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_resource_locale_description))
            {
                htUpdateResourceLocale.Add("@s_resource_locale_description", resLocale.s_resource_locale_description);
            }
            else
            {
                htUpdateResourceLocale.Add("@s_resource_locale_description", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_resource_locale", htUpdateResourceLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// get one locale from temp locale datatable
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <param name="dtTempLocale"></param>
        /// <returns></returns>
        public static SystemResource TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemResource reslocale;
            try
            {
                reslocale = new SystemResource();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_resource_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_resource_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_resource_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Get single resource locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemResource GetSingleResourceLocale(string s_locale_system_id_pk)
        {
            SystemResource resLocale;
            try
            {
                resLocale = new SystemResource();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_resource_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_resource_locale", htGetLocale);
                resLocale.s_resource_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                resLocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                resLocale.s_resource_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                resLocale.s_resource_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                resLocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                return resLocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// get resource locale
        /// </summary>
        /// <returns></returns>
        public static DataTable GetResourceLocale(string s_resource_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_resource_system_id_fk", s_resource_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_resource_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete resource locale
        /// </summary>
        /// <param name="s_resource_system_id_fk"></param>
        /// <returns></returns>
        public static int DeleteResourceLocale(string s_resource_system_id_fk, string s_resource_locale, string s_resource_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_resource_system_id_fk))
            {
                htDeleteLocale.Add("@s_resource_system_id_fk", s_resource_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_resource_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_resource_locale))
            {
                htDeleteLocale.Add("@s_resource_locale", s_resource_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_resource_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_resource_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_resource_locale_system_id_pk", s_resource_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_resource_locale_system_id_pk", DBNull.Value);

            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_resource_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
