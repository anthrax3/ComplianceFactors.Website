using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.DataAccessLayer;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemResourceTypeBLL
    {
        public static int CreateResourceType(SystemResourceType createResourceType)
        {
            Hashtable htCreateResourceType = new Hashtable();
            htCreateResourceType.Add("@s_resource_type_system_id_pk", createResourceType.s_resource_type_system_id_pk);
            htCreateResourceType.Add("@s_resource_type_id", createResourceType.s_resource_type_id);
            if (createResourceType.s_resource_type_status_id_fk == "0")
                htCreateResourceType.Add("@s_resource_type_status_id_fk", DBNull.Value);
            else
                htCreateResourceType.Add("@s_resource_type_status_id_fk", createResourceType.s_resource_type_status_id_fk);
            htCreateResourceType.Add("@s_resource_type_name_us_english", createResourceType.s_resource_type_name_us_english);
            htCreateResourceType.Add("@s_resource_type_desc_us_english", createResourceType.s_resource_type_desc_us_english);
            htCreateResourceType.Add("@s_resource_type_name_uk_english", createResourceType.s_resource_type_name_uk_english);
            htCreateResourceType.Add("@s_resource_type_desc_uk_english", createResourceType.s_resource_type_desc_uk_english);
            htCreateResourceType.Add("@s_resource_type_name_ca_french", createResourceType.s_resource_type_name_ca_french);
            htCreateResourceType.Add("@s_resource_type_desc_ca_french", createResourceType.s_resource_type_desc_ca_french);
            htCreateResourceType.Add("@s_resource_type_name_fr_french", createResourceType.s_resource_type_name_fr_french);
            htCreateResourceType.Add("@s_resource_type_desc_fr_french", createResourceType.s_resource_type_desc_fr_french);
            htCreateResourceType.Add("@s_resource_type_name_mx_spanish", createResourceType.s_resource_type_name_mx_spanish);
            htCreateResourceType.Add("@s_resource_type_desc_mx_spanish", createResourceType.s_resource_type_desc_mx_spanish);
            htCreateResourceType.Add("@s_resource_type_name_sp_spanish", createResourceType.s_resource_type_name_sp_spanish);
            htCreateResourceType.Add("@s_resource_type_desc_sp_spanish", createResourceType.s_resource_type_desc_sp_spanish);
            htCreateResourceType.Add("@s_resource_type_name_portuguese", createResourceType.s_resource_type_name_portuguese);
            htCreateResourceType.Add("@s_resource_type_desc_portuguese", createResourceType.s_resource_type_desc_portuguese);
            htCreateResourceType.Add("@s_resource_type_name_simp_chinese", createResourceType.s_resource_type_name_simp_chinese);
            htCreateResourceType.Add("@s_resource_type_desc_simp_chinese", createResourceType.s_resource_type_desc_simp_chinese);
            htCreateResourceType.Add("@s_resource_type_name_german", createResourceType.s_resource_type_name_german);
            htCreateResourceType.Add("@s_resource_type_desc_german", createResourceType.s_resource_type_desc_german);
            htCreateResourceType.Add("@s_resource_type_name_japanese", createResourceType.s_resource_type_name_japanese);
            htCreateResourceType.Add("@s_resource_type_desc_japanese", createResourceType.s_resource_type_desc_japanese);
            htCreateResourceType.Add("@s_resource_type_name_russian", createResourceType.s_resource_type_name_russian);
            htCreateResourceType.Add("@s_resource_type_desc_russian", createResourceType.s_resource_type_desc_russian);
            htCreateResourceType.Add("@s_resource_type_name_danish", createResourceType.s_resource_type_name_danish);
            htCreateResourceType.Add("@s_resource_type_desc_danish", createResourceType.s_resource_type_desc_danish);
            htCreateResourceType.Add("@s_resource_type_name_polish", createResourceType.s_resource_type_name_polish);
            htCreateResourceType.Add("@s_resource_type_desc_polish", createResourceType.s_resource_type_desc_polish);
            htCreateResourceType.Add("@s_resource_type_name_swedish", createResourceType.s_resource_type_name_swedish);
            htCreateResourceType.Add("@s_resource_type_desc_swedish", createResourceType.s_resource_type_desc_swedish);
            htCreateResourceType.Add("@s_resource_type_name_finnish", createResourceType.s_resource_type_name_finnish);
            htCreateResourceType.Add("@s_resource_type_desc_finnish", createResourceType.s_resource_type_desc_finnish);
            htCreateResourceType.Add("@s_resource_type_name_korean", createResourceType.s_resource_type_name_korean);
            htCreateResourceType.Add("@s_resource_type_desc_korean", createResourceType.s_resource_type_desc_korean);
            htCreateResourceType.Add("@s_resource_type_name_italian", createResourceType.s_resource_type_name_italian);
            htCreateResourceType.Add("@s_resource_type_desc_italian", createResourceType.s_resource_type_desc_italian);
            htCreateResourceType.Add("@s_resource_type_name_dutch", createResourceType.s_resource_type_name_dutch);
            htCreateResourceType.Add("@s_resource_type_desc_dutch", createResourceType.s_resource_type_desc_dutch);
            htCreateResourceType.Add("@s_resource_type_name_indonesian", createResourceType.s_resource_type_name_indonesian);
            htCreateResourceType.Add("@s_resource_type_desc_indonesian", createResourceType.s_resource_type_desc_indonesian);
            htCreateResourceType.Add("@s_resource_type_name_greek", createResourceType.s_resource_type_name_greek);
            htCreateResourceType.Add("@s_resource_type_desc_greek", createResourceType.s_resource_type_desc_greek);
            htCreateResourceType.Add("@s_resource_type_name_hungarian", createResourceType.s_resource_type_name_hungarian);
            htCreateResourceType.Add("@s_resource_type_desc_hungarian", createResourceType.s_resource_type_desc_hungarian);
            htCreateResourceType.Add("@s_resource_type_name_norwegian", createResourceType.s_resource_type_name_norwegian);
            htCreateResourceType.Add("@s_resource_type_desc_norwegian", createResourceType.s_resource_type_desc_norwegian);
            htCreateResourceType.Add("@s_resource_type_name_turkish", createResourceType.s_resource_type_name_turkish);
            htCreateResourceType.Add("@s_resource_type_desc_turkish", createResourceType.s_resource_type_desc_turkish);
            htCreateResourceType.Add("@s_resource_type_name_arabic_rtl", createResourceType.s_resource_type_name_arabic_rtl);
            htCreateResourceType.Add("@s_resource_type_desc_arabic_rtl", createResourceType.s_resource_type_desc_arabic_rtl);
            htCreateResourceType.Add("@s_resource_type_name_custom_01", createResourceType.s_resource_type_name_custom_01);
            htCreateResourceType.Add("@s_resource_type_desc_custom_01", createResourceType.s_resource_type_desc_custom_01);
            htCreateResourceType.Add("@s_resource_type_name_custom_02", createResourceType.s_resource_type_name_custom_02);
            htCreateResourceType.Add("@s_resource_type_desc_custom_02", createResourceType.s_resource_type_desc_custom_02);
            htCreateResourceType.Add("@s_resource_type_name_custom_03", createResourceType.s_resource_type_name_custom_03);
            htCreateResourceType.Add("@s_resource_type_desc_custom_03", createResourceType.s_resource_type_desc_custom_03);
            htCreateResourceType.Add("@s_resource_type_name_custom_04", createResourceType.s_resource_type_name_custom_04);
            htCreateResourceType.Add("@s_resource_type_desc_custom_04", createResourceType.s_resource_type_desc_custom_04);
            htCreateResourceType.Add("@s_resource_type_name_custom_05", createResourceType.s_resource_type_name_custom_05);
            htCreateResourceType.Add("@s_resource_type_desc_custom_05", createResourceType.s_resource_type_desc_custom_05);
            htCreateResourceType.Add("@s_resource_type_name_custom_06", createResourceType.s_resource_type_name_custom_06);
            htCreateResourceType.Add("@s_resource_type_desc_custom_06", createResourceType.s_resource_type_desc_custom_06);
            htCreateResourceType.Add("@s_resource_type_name_custom_07", createResourceType.s_resource_type_name_custom_07);
            htCreateResourceType.Add("@s_resource_type_desc_custom_07", createResourceType.s_resource_type_desc_custom_07);
            htCreateResourceType.Add("@s_resource_type_name_custom_08", createResourceType.s_resource_type_name_custom_08);
            htCreateResourceType.Add("@s_resource_type_desc_custom_08", createResourceType.s_resource_type_desc_custom_08);
            htCreateResourceType.Add("@s_resource_type_name_custom_09", createResourceType.s_resource_type_name_custom_09);
            htCreateResourceType.Add("@s_resource_type_desc_custom_09", createResourceType.s_resource_type_desc_custom_09);
            htCreateResourceType.Add("@s_resource_type_name_custom_10", createResourceType.s_resource_type_name_custom_10);
            htCreateResourceType.Add("@s_resource_type_desc_custom_10", createResourceType.s_resource_type_desc_custom_10);
            htCreateResourceType.Add("@s_resource_type_name_custom_11", createResourceType.s_resource_type_name_custom_11);
            htCreateResourceType.Add("@s_resource_type_desc_custom_11", createResourceType.s_resource_type_desc_custom_11);
            htCreateResourceType.Add("@s_resource_type_name_custom_12", createResourceType.s_resource_type_name_custom_12);
            htCreateResourceType.Add("@s_resource_type_desc_custom_12", createResourceType.s_resource_type_desc_custom_12);
            htCreateResourceType.Add("@s_resource_type_name_custom_13", createResourceType.s_resource_type_name_custom_13);
            htCreateResourceType.Add("@s_resource_type_desc_custom_13", createResourceType.s_resource_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_resource_type", htCreateResourceType);
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

        public static DataTable GetResourceType(SystemResourceType resource)
        {
            Hashtable htSearchResource = new Hashtable();
            htSearchResource.Add("@s_resource_type_id", resource.s_resource_type_id);
            htSearchResource.Add("@s_resource_type_name_us_english", resource.s_resource_type_name_us_english);
            if (resource.s_resource_type_status_id_fk == "0")
                htSearchResource.Add("@s_resource_type_status_id_fk", DBNull.Value);
            else
                htSearchResource.Add("@s_resource_type_status_id_fk", resource.s_resource_type_status_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_resource_type", htSearchResource);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemResourceType GetResourceTypesbyId(string s_resource_type_system_id_pk)
        {
            SystemResourceType resourceType =new SystemResourceType();
            try
            {

                Hashtable htGetResource = new Hashtable();
                htGetResource.Add("@s_resource_type_system_id_pk", s_resource_type_system_id_pk);
                DataTable dtGetresourceType = DataProxy.FetchDataSet("s_sp_get_single_resource_type", htGetResource).Tables[0];
                resourceType.s_resource_type_id = dtGetresourceType.Rows[0]["s_resource_type_id"].ToString();
                resourceType.s_resource_type_status_id_fk = dtGetresourceType.Rows[0]["s_resource_type_status_id_fk"].ToString();

                resourceType.s_resource_type_name_us_english = dtGetresourceType.Rows[0]["s_resource_type_name_us_english"].ToString();
                resourceType.s_resource_type_desc_us_english = dtGetresourceType.Rows[0]["s_resource_type_desc_us_english"].ToString();
                resourceType.s_resource_type_name_uk_english = dtGetresourceType.Rows[0]["s_resource_type_name_uk_english"].ToString();
                resourceType.s_resource_type_desc_uk_english = dtGetresourceType.Rows[0]["s_resource_type_desc_uk_english"].ToString();
                resourceType.s_resource_type_name_ca_french = dtGetresourceType.Rows[0]["s_resource_type_name_ca_french"].ToString();
                resourceType.s_resource_type_desc_ca_french = dtGetresourceType.Rows[0]["s_resource_type_desc_ca_french"].ToString();
                resourceType.s_resource_type_name_fr_french = dtGetresourceType.Rows[0]["s_resource_type_name_fr_french"].ToString();
                resourceType.s_resource_type_desc_fr_french = dtGetresourceType.Rows[0]["s_resource_type_desc_fr_french"].ToString();
                resourceType.s_resource_type_name_mx_spanish = dtGetresourceType.Rows[0]["s_resource_type_name_mx_spanish"].ToString();
                resourceType.s_resource_type_desc_mx_spanish = dtGetresourceType.Rows[0]["s_resource_type_desc_mx_spanish"].ToString();
                resourceType.s_resource_type_name_sp_spanish = dtGetresourceType.Rows[0]["s_resource_type_name_sp_spanish"].ToString();
                resourceType.s_resource_type_desc_sp_spanish = dtGetresourceType.Rows[0]["s_resource_type_desc_sp_spanish"].ToString();
                resourceType.s_resource_type_name_portuguese = dtGetresourceType.Rows[0]["s_resource_type_name_portuguese"].ToString();
                resourceType.s_resource_type_desc_portuguese = dtGetresourceType.Rows[0]["s_resource_type_desc_portuguese"].ToString();
                resourceType.s_resource_type_name_simp_chinese = dtGetresourceType.Rows[0]["s_resource_type_name_simp_chinese"].ToString();
                resourceType.s_resource_type_desc_simp_chinese = dtGetresourceType.Rows[0]["s_resource_type_desc_simp_chinese"].ToString();
                resourceType.s_resource_type_name_german = dtGetresourceType.Rows[0]["s_resource_type_name_german"].ToString();
                resourceType.s_resource_type_desc_german = dtGetresourceType.Rows[0]["s_resource_type_desc_german"].ToString();
                resourceType.s_resource_type_name_japanese = dtGetresourceType.Rows[0]["s_resource_type_name_japanese"].ToString();
                resourceType.s_resource_type_desc_japanese = dtGetresourceType.Rows[0]["s_resource_type_desc_japanese"].ToString();
                resourceType.s_resource_type_name_russian = dtGetresourceType.Rows[0]["s_resource_type_name_russian"].ToString();
                resourceType.s_resource_type_desc_russian = dtGetresourceType.Rows[0]["s_resource_type_desc_russian"].ToString();
                resourceType.s_resource_type_name_danish = dtGetresourceType.Rows[0]["s_resource_type_name_danish"].ToString();
                resourceType.s_resource_type_desc_danish = dtGetresourceType.Rows[0]["s_resource_type_desc_danish"].ToString();
                resourceType.s_resource_type_name_polish = dtGetresourceType.Rows[0]["s_resource_type_name_polish"].ToString();
                resourceType.s_resource_type_desc_polish = dtGetresourceType.Rows[0]["s_resource_type_desc_polish"].ToString();
                resourceType.s_resource_type_name_swedish = dtGetresourceType.Rows[0]["s_resource_type_name_swedish"].ToString();
                resourceType.s_resource_type_desc_swedish = dtGetresourceType.Rows[0]["s_resource_type_desc_swedish"].ToString();
                resourceType.s_resource_type_name_finnish = dtGetresourceType.Rows[0]["s_resource_type_name_finnish"].ToString();
                resourceType.s_resource_type_desc_finnish = dtGetresourceType.Rows[0]["s_resource_type_desc_finnish"].ToString();
                resourceType.s_resource_type_name_korean = dtGetresourceType.Rows[0]["s_resource_type_name_korean"].ToString();
                resourceType.s_resource_type_desc_korean = dtGetresourceType.Rows[0]["s_resource_type_desc_korean"].ToString();
                resourceType.s_resource_type_name_italian = dtGetresourceType.Rows[0]["s_resource_type_name_italian"].ToString();
                resourceType.s_resource_type_desc_italian = dtGetresourceType.Rows[0]["s_resource_type_desc_italian"].ToString();
                resourceType.s_resource_type_name_dutch = dtGetresourceType.Rows[0]["s_resource_type_name_dutch"].ToString();
                resourceType.s_resource_type_desc_dutch = dtGetresourceType.Rows[0]["s_resource_type_desc_dutch"].ToString();
                resourceType.s_resource_type_name_indonesian = dtGetresourceType.Rows[0]["s_resource_type_name_indonesian"].ToString();
                resourceType.s_resource_type_desc_indonesian = dtGetresourceType.Rows[0]["s_resource_type_desc_indonesian"].ToString();
                resourceType.s_resource_type_name_greek = dtGetresourceType.Rows[0]["s_resource_type_name_greek"].ToString();
                resourceType.s_resource_type_desc_greek = dtGetresourceType.Rows[0]["s_resource_type_desc_greek"].ToString();
                resourceType.s_resource_type_name_hungarian = dtGetresourceType.Rows[0]["s_resource_type_name_hungarian"].ToString();
                resourceType.s_resource_type_desc_hungarian = dtGetresourceType.Rows[0]["s_resource_type_desc_hungarian"].ToString();
                resourceType.s_resource_type_name_norwegian = dtGetresourceType.Rows[0]["s_resource_type_name_norwegian"].ToString();
                resourceType.s_resource_type_desc_norwegian = dtGetresourceType.Rows[0]["s_resource_type_desc_norwegian"].ToString();
                resourceType.s_resource_type_name_turkish = dtGetresourceType.Rows[0]["s_resource_type_name_turkish"].ToString();
                resourceType.s_resource_type_desc_turkish = dtGetresourceType.Rows[0]["s_resource_type_desc_turkish"].ToString();
                resourceType.s_resource_type_name_arabic_rtl = dtGetresourceType.Rows[0]["s_resource_type_name_arabic_rtl"].ToString();
                resourceType.s_resource_type_desc_arabic_rtl = dtGetresourceType.Rows[0]["s_resource_type_desc_arabic_rtl"].ToString();
                resourceType.s_resource_type_name_custom_01 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_01"].ToString();
                resourceType.s_resource_type_desc_custom_01 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_01"].ToString();
                resourceType.s_resource_type_name_custom_02 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_02"].ToString();
                resourceType.s_resource_type_desc_custom_02 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_02"].ToString();
                resourceType.s_resource_type_name_custom_03 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_03"].ToString();
                resourceType.s_resource_type_desc_custom_03 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_03"].ToString();
                resourceType.s_resource_type_name_custom_04 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_04"].ToString();
                resourceType.s_resource_type_desc_custom_04 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_04"].ToString();
                resourceType.s_resource_type_name_custom_05 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_05"].ToString();
                resourceType.s_resource_type_desc_custom_05 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_05"].ToString();
                resourceType.s_resource_type_name_custom_06 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_06"].ToString();
                resourceType.s_resource_type_desc_custom_06 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_06"].ToString();
                resourceType.s_resource_type_name_custom_07 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_07"].ToString();
                resourceType.s_resource_type_desc_custom_07 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_07"].ToString();
                resourceType.s_resource_type_name_custom_08 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_08"].ToString();
                resourceType.s_resource_type_desc_custom_08 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_08"].ToString();
                resourceType.s_resource_type_name_custom_09 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_09"].ToString();
                resourceType.s_resource_type_desc_custom_09 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_09"].ToString();
                resourceType.s_resource_type_name_custom_10 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_10"].ToString();
                resourceType.s_resource_type_desc_custom_10 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_10"].ToString();
                resourceType.s_resource_type_name_custom_11 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_11"].ToString();
                resourceType.s_resource_type_desc_custom_11 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_11"].ToString();
                resourceType.s_resource_type_name_custom_12 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_12"].ToString();
                resourceType.s_resource_type_desc_custom_12 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_12"].ToString();
                resourceType.s_resource_type_name_custom_13 = dtGetresourceType.Rows[0]["s_resource_type_name_custom_13"].ToString();
                resourceType.s_resource_type_desc_custom_13 = dtGetresourceType.Rows[0]["s_resource_type_desc_custom_13"].ToString();
                return resourceType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateResourceType(SystemResourceType updateResourceType)
        {
            Hashtable htUpdateResourceTypes = new Hashtable();
            htUpdateResourceTypes.Add("@s_resource_type_system_id_pk", updateResourceType.s_resource_type_system_id_pk);
            htUpdateResourceTypes.Add("@s_resource_type_id", updateResourceType.s_resource_type_id);
            htUpdateResourceTypes.Add("@s_resource_type_status_id_fk", updateResourceType.s_resource_type_status_id_fk);
            htUpdateResourceTypes.Add("@s_resource_type_name_us_english", updateResourceType.s_resource_type_name_us_english);
            htUpdateResourceTypes.Add("@s_resource_type_desc_us_english", updateResourceType.s_resource_type_desc_us_english);
            htUpdateResourceTypes.Add("@s_resource_type_name_uk_english", updateResourceType.s_resource_type_name_uk_english);
            htUpdateResourceTypes.Add("@s_resource_type_desc_uk_english", updateResourceType.s_resource_type_desc_uk_english);
            htUpdateResourceTypes.Add("@s_resource_type_name_ca_french", updateResourceType.s_resource_type_name_ca_french);
            htUpdateResourceTypes.Add("@s_resource_type_desc_ca_french", updateResourceType.s_resource_type_desc_ca_french);
            htUpdateResourceTypes.Add("@s_resource_type_name_fr_french", updateResourceType.s_resource_type_name_fr_french);
            htUpdateResourceTypes.Add("@s_resource_type_desc_fr_french", updateResourceType.s_resource_type_desc_fr_french);
            htUpdateResourceTypes.Add("@s_resource_type_name_mx_spanish", updateResourceType.s_resource_type_name_mx_spanish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_mx_spanish", updateResourceType.s_resource_type_desc_mx_spanish);
            htUpdateResourceTypes.Add("@s_resource_type_name_sp_spanish", updateResourceType.s_resource_type_name_sp_spanish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_sp_spanish", updateResourceType.s_resource_type_desc_sp_spanish);
            htUpdateResourceTypes.Add("@s_resource_type_name_portuguese", updateResourceType.s_resource_type_name_portuguese);
            htUpdateResourceTypes.Add("@s_resource_type_desc_portuguese", updateResourceType.s_resource_type_desc_portuguese);
            htUpdateResourceTypes.Add("@s_resource_type_name_simp_chinese", updateResourceType.s_resource_type_name_simp_chinese);
            htUpdateResourceTypes.Add("@s_resource_type_desc_simp_chinese", updateResourceType.s_resource_type_desc_simp_chinese);
            htUpdateResourceTypes.Add("@s_resource_type_name_german", updateResourceType.s_resource_type_name_german);
            htUpdateResourceTypes.Add("@s_resource_type_desc_german", updateResourceType.s_resource_type_desc_german);
            htUpdateResourceTypes.Add("@s_resource_type_name_japanese", updateResourceType.s_resource_type_name_japanese);
            htUpdateResourceTypes.Add("@s_resource_type_desc_japanese", updateResourceType.s_resource_type_desc_japanese);
            htUpdateResourceTypes.Add("@s_resource_type_name_russian", updateResourceType.s_resource_type_name_russian);
            htUpdateResourceTypes.Add("@s_resource_type_desc_russian", updateResourceType.s_resource_type_desc_russian);
            htUpdateResourceTypes.Add("@s_resource_type_name_danish", updateResourceType.s_resource_type_name_danish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_danish", updateResourceType.s_resource_type_desc_danish);
            htUpdateResourceTypes.Add("@s_resource_type_name_polish", updateResourceType.s_resource_type_name_polish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_polish", updateResourceType.s_resource_type_desc_polish);
            htUpdateResourceTypes.Add("@s_resource_type_name_swedish", updateResourceType.s_resource_type_name_swedish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_swedish", updateResourceType.s_resource_type_desc_swedish);
            htUpdateResourceTypes.Add("@s_resource_type_name_finnish", updateResourceType.s_resource_type_name_finnish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_finnish", updateResourceType.s_resource_type_desc_finnish);
            htUpdateResourceTypes.Add("@s_resource_type_name_korean", updateResourceType.s_resource_type_name_korean);
            htUpdateResourceTypes.Add("@s_resource_type_desc_korean", updateResourceType.s_resource_type_desc_korean);
            htUpdateResourceTypes.Add("@s_resource_type_name_italian", updateResourceType.s_resource_type_name_italian);
            htUpdateResourceTypes.Add("@s_resource_type_desc_italian", updateResourceType.s_resource_type_desc_italian);
            htUpdateResourceTypes.Add("@s_resource_type_name_dutch", updateResourceType.s_resource_type_name_dutch);
            htUpdateResourceTypes.Add("@s_resource_type_desc_dutch", updateResourceType.s_resource_type_desc_dutch);
            htUpdateResourceTypes.Add("@s_resource_type_name_indonesian", updateResourceType.s_resource_type_name_indonesian);
            htUpdateResourceTypes.Add("@s_resource_type_desc_indonesian", updateResourceType.s_resource_type_desc_indonesian);
            htUpdateResourceTypes.Add("@s_resource_type_name_greek", updateResourceType.s_resource_type_name_greek);
            htUpdateResourceTypes.Add("@s_resource_type_desc_greek", updateResourceType.s_resource_type_desc_greek);
            htUpdateResourceTypes.Add("@s_resource_type_name_hungarian", updateResourceType.s_resource_type_name_hungarian);
            htUpdateResourceTypes.Add("@s_resource_type_desc_hungarian", updateResourceType.s_resource_type_desc_hungarian);
            htUpdateResourceTypes.Add("@s_resource_type_name_norwegian", updateResourceType.s_resource_type_name_norwegian);
            htUpdateResourceTypes.Add("@s_resource_type_desc_norwegian", updateResourceType.s_resource_type_desc_norwegian);
            htUpdateResourceTypes.Add("@s_resource_type_name_turkish", updateResourceType.s_resource_type_name_turkish);
            htUpdateResourceTypes.Add("@s_resource_type_desc_turkish", updateResourceType.s_resource_type_desc_turkish);
            htUpdateResourceTypes.Add("@s_resource_type_name_arabic_rtl", updateResourceType.s_resource_type_name_arabic_rtl);
            htUpdateResourceTypes.Add("@s_resource_type_desc_arabic_rtl", updateResourceType.s_resource_type_desc_arabic_rtl);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_01", updateResourceType.s_resource_type_name_custom_01);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_01", updateResourceType.s_resource_type_desc_custom_01);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_02", updateResourceType.s_resource_type_name_custom_02);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_02", updateResourceType.s_resource_type_desc_custom_02);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_03", updateResourceType.s_resource_type_name_custom_03);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_03", updateResourceType.s_resource_type_desc_custom_03);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_04", updateResourceType.s_resource_type_name_custom_04);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_04", updateResourceType.s_resource_type_desc_custom_04);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_05", updateResourceType.s_resource_type_name_custom_05);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_05", updateResourceType.s_resource_type_desc_custom_05);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_06", updateResourceType.s_resource_type_name_custom_06);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_06", updateResourceType.s_resource_type_desc_custom_06);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_07", updateResourceType.s_resource_type_name_custom_07);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_07", updateResourceType.s_resource_type_desc_custom_07);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_08", updateResourceType.s_resource_type_name_custom_08);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_08", updateResourceType.s_resource_type_desc_custom_08);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_09", updateResourceType.s_resource_type_name_custom_09);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_09", updateResourceType.s_resource_type_desc_custom_09);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_10", updateResourceType.s_resource_type_name_custom_10);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_10", updateResourceType.s_resource_type_desc_custom_10);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_11", updateResourceType.s_resource_type_name_custom_11);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_11", updateResourceType.s_resource_type_desc_custom_11);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_12", updateResourceType.s_resource_type_name_custom_12);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_12", updateResourceType.s_resource_type_desc_custom_12);
            htUpdateResourceTypes.Add("@s_resource_type_name_custom_13", updateResourceType.s_resource_type_name_custom_13);
            htUpdateResourceTypes.Add("@s_resource_type_desc_custom_13", updateResourceType.s_resource_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_resource_type", htUpdateResourceTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateResourceStatus(string s_resource_type_system_id_pk)
        {
            Hashtable htUpdateResourceStatus = new Hashtable();
            htUpdateResourceStatus.Add("@s_resource_type_system_id_pk", s_resource_type_system_id_pk);
            
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_resource_type_status", htUpdateResourceStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}
