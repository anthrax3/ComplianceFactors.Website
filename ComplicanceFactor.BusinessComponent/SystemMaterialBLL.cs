using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using System.Data;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemMaterialBLL
    {
        /// <summary>
        /// Create the Material
        /// </summary>
        /// <param name="createMaterial"></param>
        /// <returns></returns>
        public static int CreateNewMaterial(SystemMaterial createMaterial)
        {
            Hashtable htCreateMaterial = new Hashtable();
            htCreateMaterial.Add("@c_material_system_id_pk", createMaterial.c_material_system_id_pk);
            htCreateMaterial.Add("@c_material_id_pk", createMaterial.c_material_id_pk);
            htCreateMaterial.Add("@c_material_name", createMaterial.c_material_name);
            htCreateMaterial.Add("@c_material_description", createMaterial.c_material_description);
            htCreateMaterial.Add("@c_material_status_id", createMaterial.c_material_status_id);
            htCreateMaterial.Add("@c_material_type_id_fk", createMaterial.c_material_type_id_fk);
            htCreateMaterial.Add("@c_material_file_guid", createMaterial.c_material_file_guid);
            htCreateMaterial.Add("@c_material_file_name", createMaterial.c_material_file_name);
            if (!string.IsNullOrEmpty(createMaterial.s_material_locale))
            {
                htCreateMaterial.Add("@s_material_locale", createMaterial.s_material_locale);
            }
            else
            {
                htCreateMaterial.Add("@s_material_locale", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_material", htCreateMaterial);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update the material
        /// </summary>
        /// <param name="updateMaterial"></param>
        /// <returns></returns>
        public static int UpdateMaterial(SystemMaterial updateMaterial)
        {
            Hashtable htUpdateMaterial = new Hashtable();
            htUpdateMaterial.Add("@c_material_system_id_pk", updateMaterial.c_material_system_id_pk);
            htUpdateMaterial.Add("@c_material_id_pk", updateMaterial.c_material_id_pk);
            htUpdateMaterial.Add("@c_material_name", updateMaterial.c_material_name);
            htUpdateMaterial.Add("@c_material_description", updateMaterial.c_material_description);
            htUpdateMaterial.Add("@c_material_status_id", updateMaterial.c_material_status_id);
            htUpdateMaterial.Add("@c_material_type_id_fk", updateMaterial.c_material_type_id_fk);
            htUpdateMaterial.Add("@c_material_file_guid", updateMaterial.c_material_file_guid);
            htUpdateMaterial.Add("@c_material_file_name", updateMaterial.c_material_file_name);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_material", htUpdateMaterial);
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
        /// Get all Status
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllStatus = new Hashtable();
                htGetAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status",htGetAllStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Material Type
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMaterialType(string s_locale)
        {
            try
            {
                Hashtable htGetMaterialType = new Hashtable();
                htGetMaterialType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_material_type",htGetMaterialType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the single Material
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        /// <returns></returns>
        public static SystemMaterial GetSingleMaterial(string c_material_system_id_pk, DataTable dtMaterial)
        {
            SystemMaterial getMaterial = new SystemMaterial();
            try
            {
                Hashtable htGetMaterial = new Hashtable();
                htGetMaterial.Add("@c_material_system_id_pk", c_material_system_id_pk);
                DataTable dtSingleMaterial = dtMaterial;
                getMaterial.c_material_id_pk = dtSingleMaterial.Rows[0]["c_material_id_pk"].ToString();
                getMaterial.c_material_name = dtSingleMaterial.Rows[0]["c_material_name"].ToString();
                getMaterial.c_material_description = dtSingleMaterial.Rows[0]["c_material_description"].ToString();
                getMaterial.c_material_status_id = dtSingleMaterial.Rows[0]["c_material_status_id"].ToString();
                getMaterial.c_material_type_id_fk = dtSingleMaterial.Rows[0]["c_material_type_id_fk"].ToString();
                getMaterial.c_material_file_guid = dtSingleMaterial.Rows[0]["c_material_file_guid"].ToString();
                getMaterial.c_material_file_name = dtSingleMaterial.Rows[0]["c_material_file_name"].ToString();


                return getMaterial;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get material
        /// </summary>
        /// <param name="s_material_system_id_pk"></param>
        /// <returns></returns>
        public static DataSet GetMaterial(string s_material_system_id_pk)
        {
            try
            {
                Hashtable htGetMaterial = new Hashtable();
                htGetMaterial.Add("@c_material_system_id_pk", s_material_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_single_material", htGetMaterial);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemMaterial TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemMaterial reslocale;
            try
            {
                reslocale = new SystemMaterial();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_material_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_material_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_material_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                reslocale.s_material_locale_file_guid = dtGetLocale.Rows[0]["s_locale_file_guid"].ToString();
                reslocale.s_material_locale_file_name = dtGetLocale.Rows[0]["s_locale_file_name"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Search Materials 
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public static DataTable SearchMaterials(SystemMaterial material)
        {
            Hashtable htSearchMaterial = new Hashtable();
            htSearchMaterial.Add("@c_material_id_pk", material.c_material_id_pk);
            htSearchMaterial.Add("@c_material_name", material.c_material_name);
            if (material.c_material_type_id_fk == "0")
                htSearchMaterial.Add("@c_material_type_id_fk", DBNull.Value);
            else
                htSearchMaterial.Add("@c_material_type_id_fk", material.c_material_type_id_fk);

            if (material.c_material_status_id == "0")
                htSearchMaterial.Add("@c_material_status_id", DBNull.Value);
            else
                htSearchMaterial.Add("@c_material_status_id", material.c_material_status_id);


            try
            {
                return DataProxy.FetchDataTable("s_sp_search_material", htSearchMaterial);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update status of the material
        /// </summary>
        /// <param name="c_material_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateMaterialStatus(string c_material_system_id_pk)
        {
            Hashtable htUpdateMaterialStatus = new Hashtable();
            htUpdateMaterialStatus.Add("@c_material_system_id_pk", c_material_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_material_status", htUpdateMaterialStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get single material locale
        /// </summary>
        /// <param name="s_locale_system_id_pk"></param>
        /// <returns></returns>
        public static SystemMaterial GetSingleMaterialLocale(string s_locale_system_id_pk)
        {
            SystemMaterial resLocale;
            try
            {
                resLocale = new SystemMaterial();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_material_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_material_locale", htGetLocale);
                resLocale.s_material_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                resLocale.s_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                resLocale.s_material_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                resLocale.s_material_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                resLocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                resLocale.s_material_locale_file_guid = dtGetLocale.Rows[0]["s_locale_file_guid"].ToString();
                resLocale.s_material_locale_file_name = dtGetLocale.Rows[0]["s_locale_file_name"].ToString();
                return resLocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// update material locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int UpdateMaterialLocale(SystemMaterial resLocale)
        {
            Hashtable htUpdatematerialLocale = new Hashtable();
            htUpdatematerialLocale.Add("@s_material_locale_system_id_pk", resLocale.s_material_locale_system_id_pk);
            if (!string.IsNullOrEmpty(resLocale.s_material_locale_name))
            {
                htUpdatematerialLocale.Add("@s_material_locale_name", resLocale.s_material_locale_name);
            }
            else
            {
                htUpdatematerialLocale.Add("@s_material_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_material_locale_description))
            {
                htUpdatematerialLocale.Add("@s_material_locale_description", resLocale.s_material_locale_description);
            }
            else
            {
                htUpdatematerialLocale.Add("@s_material_locale_description", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_material_locale_file_guid))
            {
                htUpdatematerialLocale.Add("@s_material_locale_file_guid", resLocale.s_material_locale_file_guid);
            }
            else
            {
                htUpdatematerialLocale.Add("@s_material_locale_file_guid", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_material_locale_file_name))
            {
                htUpdatematerialLocale.Add("@s_material_locale_file_name", resLocale.s_material_locale_file_name);
            }
            else
            {
                htUpdatematerialLocale.Add("@s_material_locale_file_name", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_material_locale", htUpdatematerialLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert material locale
        /// </summary>
        /// <param name="resLocale"></param>
        /// <returns></returns>
        public static int InsertMaterialLocale(SystemMaterial resLocale)
        {
            Hashtable htInsertmaterialLocale = new Hashtable();
            htInsertmaterialLocale.Add("@s_material_system_id_fk", resLocale.s_material_system_id_fk);
            htInsertmaterialLocale.Add("@s_material_locale_name", resLocale.s_material_locale_name);
            htInsertmaterialLocale.Add("@s_material_locale_description", resLocale.s_material_locale_description);
            htInsertmaterialLocale.Add("@s_locale_id_fk", resLocale.s_locale_id_fk);
            if (!string.IsNullOrEmpty(resLocale.s_material_locale_file_guid))
            {
                htInsertmaterialLocale.Add("@s_material_locale_file_guid", resLocale.s_material_locale_file_guid);
            }
            else
            {
                htInsertmaterialLocale.Add("@s_material_locale_file_guid", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_material_locale_file_name))
            {
                htInsertmaterialLocale.Add("@s_material_locale_file_name", resLocale.s_material_locale_file_name);
            }
            else
            {
                htInsertmaterialLocale.Add("@s_material_locale_file_name", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_material_locale", htInsertmaterialLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get material locale
        /// </summary>
        /// <param name="s_material_system_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetMaterialLocale(string s_material_system_id_fk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_material_system_id_fk", s_material_system_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_material_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteMaterialLocale(string s_material_system_id_fk, string s_material_locale, string s_material_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_material_system_id_fk))
            {
                htDeleteLocale.Add("@s_material_system_id_fk", s_material_system_id_fk);
            }
            else
            {
                htDeleteLocale.Add("@s_material_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_material_locale))
            {
                htDeleteLocale.Add("@s_material_locale", s_material_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_material_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_material_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_material_locale_system_id_pk", s_material_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_material_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_material_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update material locale attachment
        /// </summary>
        /// <param name="s_material_locale_system_id_pk"></param>
        /// <param name="s_material_locale_file_guid"></param>
        /// <param name="s_material_locale_file_name"></param>
        /// <returns></returns>
        public static int UpdateMaterialLocaleAttachment(string s_material_locale_system_id_pk,string s_material_locale_file_guid,string s_material_locale_file_name)
        {
            Hashtable htLocale = new Hashtable();
            htLocale.Add("@s_material_locale_system_id_pk", s_material_locale_system_id_pk);
            htLocale.Add("@s_material_locale_file_guid", s_material_locale_file_guid);
            htLocale.Add("@s_material_locale_file_name", s_material_locale_file_name);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_material_locale_attachment", htLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
