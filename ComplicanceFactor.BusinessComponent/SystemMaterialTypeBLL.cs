using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.DataAccessLayer;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemMaterialTypeBLL
    {
        public static int CreateMaterialType(SystemMaterialType creatematerialTypes)
        {
            Hashtable htCreatematerialTypes = new Hashtable();

            htCreatematerialTypes.Add("@s_material_type_system_id_pk", creatematerialTypes.s_material_type_system_id_pk);
            htCreatematerialTypes.Add("@s_material_type_id", creatematerialTypes.s_material_type_id);
            if (creatematerialTypes.s_material_type_status_id_fk == "0")
                htCreatematerialTypes.Add("@s_material_type_status_id_fk", DBNull.Value);
            else
                htCreatematerialTypes.Add("@s_material_type_status_id_fk", creatematerialTypes.s_material_type_status_id_fk);
            htCreatematerialTypes.Add("@s_material_type_name_us_english", creatematerialTypes.s_material_type_name_us_english);
            htCreatematerialTypes.Add("@s_material_type_desc_us_english", creatematerialTypes.s_material_type_desc_us_english);
            htCreatematerialTypes.Add("@s_material_type_name_uk_english", creatematerialTypes.s_material_type_name_uk_english);
            htCreatematerialTypes.Add("@s_material_type_desc_uk_english", creatematerialTypes.s_material_type_desc_uk_english);
            htCreatematerialTypes.Add("@s_material_type_name_ca_french", creatematerialTypes.s_material_type_name_ca_french);
            htCreatematerialTypes.Add("@s_material_type_desc_ca_french", creatematerialTypes.s_material_type_desc_ca_french);
            htCreatematerialTypes.Add("@s_material_type_name_fr_french", creatematerialTypes.s_material_type_name_fr_french);
            htCreatematerialTypes.Add("@s_material_type_desc_fr_french", creatematerialTypes.s_material_type_desc_fr_french);
            htCreatematerialTypes.Add("@s_material_type_name_mx_spanish", creatematerialTypes.s_material_type_name_mx_spanish);
            htCreatematerialTypes.Add("@s_material_type_desc_mx_spanish", creatematerialTypes.s_material_type_desc_mx_spanish);
            htCreatematerialTypes.Add("@s_material_type_name_sp_spanish", creatematerialTypes.s_material_type_name_sp_spanish);
            htCreatematerialTypes.Add("@s_material_type_desc_sp_spanish", creatematerialTypes.s_material_type_desc_sp_spanish);
            htCreatematerialTypes.Add("@s_material_type_name_portuguese", creatematerialTypes.s_material_type_name_portuguese);
            htCreatematerialTypes.Add("@s_material_type_desc_portuguese", creatematerialTypes.s_material_type_desc_portuguese);
            htCreatematerialTypes.Add("@s_material_type_name_simp_chinese", creatematerialTypes.s_material_type_name_simp_chinese);
            htCreatematerialTypes.Add("@s_material_type_desc_simp_chinese", creatematerialTypes.s_material_type_desc_simp_chinese);
            htCreatematerialTypes.Add("@s_material_type_name_german", creatematerialTypes.s_material_type_name_german);
            htCreatematerialTypes.Add("@s_material_type_desc_german", creatematerialTypes.s_material_type_desc_german);
            htCreatematerialTypes.Add("@s_material_type_name_japanese", creatematerialTypes.s_material_type_name_japanese);
            htCreatematerialTypes.Add("@s_material_type_desc_japanese", creatematerialTypes.s_material_type_desc_japanese);
            htCreatematerialTypes.Add("@s_material_type_name_russian", creatematerialTypes.s_material_type_name_russian);
            htCreatematerialTypes.Add("@s_material_type_desc_russian", creatematerialTypes.s_material_type_desc_russian);
            htCreatematerialTypes.Add("@s_material_type_name_danish", creatematerialTypes.s_material_type_name_danish);
            htCreatematerialTypes.Add("@s_material_type_desc_danish", creatematerialTypes.s_material_type_desc_danish);
            htCreatematerialTypes.Add("@s_material_type_name_polish", creatematerialTypes.s_material_type_name_polish);
            htCreatematerialTypes.Add("@s_material_type_desc_polish", creatematerialTypes.s_material_type_desc_polish);
            htCreatematerialTypes.Add("@s_material_type_name_swedish", creatematerialTypes.s_material_type_name_swedish);
            htCreatematerialTypes.Add("@s_material_type_desc_swedish", creatematerialTypes.s_material_type_desc_swedish);
            htCreatematerialTypes.Add("@s_material_type_name_finnish", creatematerialTypes.s_material_type_name_finnish);
            htCreatematerialTypes.Add("@s_material_type_desc_finnish", creatematerialTypes.s_material_type_desc_finnish);
            htCreatematerialTypes.Add("@s_material_type_name_korean", creatematerialTypes.s_material_type_name_korean);
            htCreatematerialTypes.Add("@s_material_type_desc_korean", creatematerialTypes.s_material_type_desc_korean);
            htCreatematerialTypes.Add("@s_material_type_name_italian", creatematerialTypes.s_material_type_name_italian);
            htCreatematerialTypes.Add("@s_material_type_desc_italian", creatematerialTypes.s_material_type_desc_italian);
            htCreatematerialTypes.Add("@s_material_type_name_dutch", creatematerialTypes.s_material_type_name_dutch);
            htCreatematerialTypes.Add("@s_material_type_desc_dutch", creatematerialTypes.s_material_type_desc_dutch);
            htCreatematerialTypes.Add("@s_material_type_name_indonesian", creatematerialTypes.s_material_type_name_indonesian);
            htCreatematerialTypes.Add("@s_material_type_desc_indonesian", creatematerialTypes.s_material_type_desc_indonesian);
            htCreatematerialTypes.Add("@s_material_type_name_greek", creatematerialTypes.s_material_type_name_greek);
            htCreatematerialTypes.Add("@s_material_type_desc_greek", creatematerialTypes.s_material_type_desc_greek);
            htCreatematerialTypes.Add("@s_material_type_name_hungarian", creatematerialTypes.s_material_type_name_hungarian);
            htCreatematerialTypes.Add("@s_material_type_desc_hungarian", creatematerialTypes.s_material_type_desc_hungarian);
            htCreatematerialTypes.Add("@s_material_type_name_norwegian", creatematerialTypes.s_material_type_name_norwegian);
            htCreatematerialTypes.Add("@s_material_type_desc_norwegian", creatematerialTypes.s_material_type_desc_norwegian);
            htCreatematerialTypes.Add("@s_material_type_name_turkish", creatematerialTypes.s_material_type_name_turkish);
            htCreatematerialTypes.Add("@s_material_type_desc_turkish", creatematerialTypes.s_material_type_desc_turkish);
            htCreatematerialTypes.Add("@s_material_type_name_arabic_rtl", creatematerialTypes.s_material_type_name_arabic_rtl);
            htCreatematerialTypes.Add("@s_material_type_desc_arabic_rtl", creatematerialTypes.s_material_type_desc_arabic_rtl);
            htCreatematerialTypes.Add("@s_material_type_name_custom_01", creatematerialTypes.s_material_type_name_custom_01);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_01", creatematerialTypes.s_material_type_desc_custom_01);
            htCreatematerialTypes.Add("@s_material_type_name_custom_02", creatematerialTypes.s_material_type_name_custom_02);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_02", creatematerialTypes.s_material_type_desc_custom_02);
            htCreatematerialTypes.Add("@s_material_type_name_custom_03", creatematerialTypes.s_material_type_name_custom_03);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_03", creatematerialTypes.s_material_type_desc_custom_03);
            htCreatematerialTypes.Add("@s_material_type_name_custom_04", creatematerialTypes.s_material_type_name_custom_04);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_04", creatematerialTypes.s_material_type_desc_custom_04);
            htCreatematerialTypes.Add("@s_material_type_name_custom_05", creatematerialTypes.s_material_type_name_custom_05);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_05", creatematerialTypes.s_material_type_desc_custom_05);
            htCreatematerialTypes.Add("@s_material_type_name_custom_06", creatematerialTypes.s_material_type_name_custom_06);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_06", creatematerialTypes.s_material_type_desc_custom_06);
            htCreatematerialTypes.Add("@s_material_type_name_custom_07", creatematerialTypes.s_material_type_name_custom_07);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_07", creatematerialTypes.s_material_type_desc_custom_07);
            htCreatematerialTypes.Add("@s_material_type_name_custom_08", creatematerialTypes.s_material_type_name_custom_08);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_08", creatematerialTypes.s_material_type_desc_custom_08);
            htCreatematerialTypes.Add("@s_material_type_name_custom_09", creatematerialTypes.s_material_type_name_custom_09);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_09", creatematerialTypes.s_material_type_desc_custom_09);
            htCreatematerialTypes.Add("@s_material_type_name_custom_10", creatematerialTypes.s_material_type_name_custom_10);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_10", creatematerialTypes.s_material_type_desc_custom_10);
            htCreatematerialTypes.Add("@s_material_type_name_custom_11", creatematerialTypes.s_material_type_name_custom_11);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_11", creatematerialTypes.s_material_type_desc_custom_11);
            htCreatematerialTypes.Add("@s_material_type_name_custom_12", creatematerialTypes.s_material_type_name_custom_12);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_12", creatematerialTypes.s_material_type_desc_custom_12);
            htCreatematerialTypes.Add("@s_material_type_name_custom_13", creatematerialTypes.s_material_type_name_custom_13);
            htCreatematerialTypes.Add("@s_material_type_desc_custom_13", creatematerialTypes.s_material_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_material_type", htCreatematerialTypes);
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
        public static DataTable SearchMaterial(SystemMaterialType material)
        {
            Hashtable htSearchMaterial = new Hashtable();
            htSearchMaterial.Add("@s_material_type_id", material.s_material_type_id);
            htSearchMaterial.Add("@s_material_type_name_us_english", material.s_material_type_name_us_english);
            if (material.s_material_type_status_id_fk == "0")
                htSearchMaterial.Add("@s_material_type_status_id_fk", DBNull.Value);
            else
                htSearchMaterial.Add("@s_material_type_status_id_fk", material.s_material_type_status_id_fk);


            try
            {
                return DataProxy.FetchDataTable("s_sp_search_material_type", htSearchMaterial);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemMaterialType GetMaterialType(string s_material_type_system_id_pk)
        {
            SystemMaterialType materialType;
            try
            {
                Hashtable htGetmaterialTypes = new Hashtable();
                htGetmaterialTypes.Add("@s_material_type_system_id_pk", s_material_type_system_id_pk);
                materialType = new SystemMaterialType();
                DataTable dtGetmaterialType = DataProxy.FetchDataTable("s_sp_get_single_material_type", htGetmaterialTypes);
                materialType.s_material_type_id = dtGetmaterialType.Rows[0]["s_material_type_id"].ToString();
                materialType.s_material_type_status_id_fk = dtGetmaterialType.Rows[0]["s_material_type_status_id_fk"].ToString();
                materialType.s_material_type_name_us_english = dtGetmaterialType.Rows[0]["s_material_type_name_us_english"].ToString();
                materialType.s_material_type_desc_us_english = dtGetmaterialType.Rows[0]["s_material_type_desc_us_english"].ToString();
                materialType.s_material_type_name_uk_english = dtGetmaterialType.Rows[0]["s_material_type_name_uk_english"].ToString();
                materialType.s_material_type_desc_uk_english = dtGetmaterialType.Rows[0]["s_material_type_desc_uk_english"].ToString();
                materialType.s_material_type_name_ca_french = dtGetmaterialType.Rows[0]["s_material_type_name_ca_french"].ToString();
                materialType.s_material_type_desc_ca_french = dtGetmaterialType.Rows[0]["s_material_type_desc_ca_french"].ToString();
                materialType.s_material_type_name_fr_french = dtGetmaterialType.Rows[0]["s_material_type_name_fr_french"].ToString();
                materialType.s_material_type_desc_fr_french = dtGetmaterialType.Rows[0]["s_material_type_desc_fr_french"].ToString();
                materialType.s_material_type_name_mx_spanish = dtGetmaterialType.Rows[0]["s_material_type_name_mx_spanish"].ToString();
                materialType.s_material_type_desc_mx_spanish = dtGetmaterialType.Rows[0]["s_material_type_desc_mx_spanish"].ToString();
                materialType.s_material_type_name_sp_spanish = dtGetmaterialType.Rows[0]["s_material_type_name_sp_spanish"].ToString();
                materialType.s_material_type_desc_sp_spanish = dtGetmaterialType.Rows[0]["s_material_type_desc_sp_spanish"].ToString();
                materialType.s_material_type_name_portuguese = dtGetmaterialType.Rows[0]["s_material_type_name_portuguese"].ToString();
                materialType.s_material_type_desc_portuguese = dtGetmaterialType.Rows[0]["s_material_type_desc_portuguese"].ToString();
                materialType.s_material_type_name_simp_chinese = dtGetmaterialType.Rows[0]["s_material_type_name_simp_chinese"].ToString();
                materialType.s_material_type_desc_simp_chinese = dtGetmaterialType.Rows[0]["s_material_type_desc_simp_chinese"].ToString();
                materialType.s_material_type_name_german = dtGetmaterialType.Rows[0]["s_material_type_name_german"].ToString();
                materialType.s_material_type_desc_german = dtGetmaterialType.Rows[0]["s_material_type_desc_german"].ToString();
                materialType.s_material_type_name_japanese = dtGetmaterialType.Rows[0]["s_material_type_name_japanese"].ToString();
                materialType.s_material_type_desc_japanese = dtGetmaterialType.Rows[0]["s_material_type_desc_japanese"].ToString();
                materialType.s_material_type_name_russian = dtGetmaterialType.Rows[0]["s_material_type_name_russian"].ToString();
                materialType.s_material_type_desc_russian = dtGetmaterialType.Rows[0]["s_material_type_desc_russian"].ToString();
                materialType.s_material_type_name_danish = dtGetmaterialType.Rows[0]["s_material_type_name_danish"].ToString();
                materialType.s_material_type_desc_danish = dtGetmaterialType.Rows[0]["s_material_type_desc_danish"].ToString();
                materialType.s_material_type_name_polish = dtGetmaterialType.Rows[0]["s_material_type_name_polish"].ToString();
                materialType.s_material_type_desc_polish = dtGetmaterialType.Rows[0]["s_material_type_desc_polish"].ToString();
                materialType.s_material_type_name_swedish = dtGetmaterialType.Rows[0]["s_material_type_name_swedish"].ToString();
                materialType.s_material_type_desc_swedish = dtGetmaterialType.Rows[0]["s_material_type_desc_swedish"].ToString();
                materialType.s_material_type_name_finnish = dtGetmaterialType.Rows[0]["s_material_type_name_finnish"].ToString();
                materialType.s_material_type_desc_finnish = dtGetmaterialType.Rows[0]["s_material_type_desc_finnish"].ToString();
                materialType.s_material_type_name_korean = dtGetmaterialType.Rows[0]["s_material_type_name_korean"].ToString();
                materialType.s_material_type_desc_korean = dtGetmaterialType.Rows[0]["s_material_type_desc_korean"].ToString();
                materialType.s_material_type_name_italian = dtGetmaterialType.Rows[0]["s_material_type_name_italian"].ToString();
                materialType.s_material_type_desc_italian = dtGetmaterialType.Rows[0]["s_material_type_desc_italian"].ToString();
                materialType.s_material_type_name_dutch = dtGetmaterialType.Rows[0]["s_material_type_name_dutch"].ToString();
                materialType.s_material_type_desc_dutch = dtGetmaterialType.Rows[0]["s_material_type_desc_dutch"].ToString();
                materialType.s_material_type_name_indonesian = dtGetmaterialType.Rows[0]["s_material_type_name_indonesian"].ToString();
                materialType.s_material_type_desc_indonesian = dtGetmaterialType.Rows[0]["s_material_type_desc_indonesian"].ToString();
                materialType.s_material_type_name_greek = dtGetmaterialType.Rows[0]["s_material_type_name_greek"].ToString();
                materialType.s_material_type_desc_greek = dtGetmaterialType.Rows[0]["s_material_type_desc_greek"].ToString();
                materialType.s_material_type_name_hungarian = dtGetmaterialType.Rows[0]["s_material_type_name_hungarian"].ToString();
                materialType.s_material_type_desc_hungarian = dtGetmaterialType.Rows[0]["s_material_type_desc_hungarian"].ToString();
                materialType.s_material_type_name_norwegian = dtGetmaterialType.Rows[0]["s_material_type_name_norwegian"].ToString();
                materialType.s_material_type_desc_norwegian = dtGetmaterialType.Rows[0]["s_material_type_desc_norwegian"].ToString();
                materialType.s_material_type_name_turkish = dtGetmaterialType.Rows[0]["s_material_type_name_turkish"].ToString();
                materialType.s_material_type_desc_turkish = dtGetmaterialType.Rows[0]["s_material_type_desc_turkish"].ToString();
                materialType.s_material_type_name_arabic_rtl = dtGetmaterialType.Rows[0]["s_material_type_name_arabic_rtl"].ToString();
                materialType.s_material_type_desc_arabic_rtl = dtGetmaterialType.Rows[0]["s_material_type_desc_arabic_rtl"].ToString();
                materialType.s_material_type_name_custom_01 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_01"].ToString();
                materialType.s_material_type_desc_custom_01 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_01"].ToString();
                materialType.s_material_type_name_custom_02 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_02"].ToString();
                materialType.s_material_type_desc_custom_02 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_02"].ToString();
                materialType.s_material_type_name_custom_03 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_03"].ToString();
                materialType.s_material_type_desc_custom_03 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_03"].ToString();
                materialType.s_material_type_name_custom_04 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_04"].ToString();
                materialType.s_material_type_desc_custom_04 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_04"].ToString();
                materialType.s_material_type_name_custom_05 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_05"].ToString();
                materialType.s_material_type_desc_custom_05 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_05"].ToString();
                materialType.s_material_type_name_custom_06 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_06"].ToString();
                materialType.s_material_type_desc_custom_06 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_06"].ToString();
                materialType.s_material_type_name_custom_07 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_07"].ToString();
                materialType.s_material_type_desc_custom_07 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_07"].ToString();
                materialType.s_material_type_name_custom_08 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_08"].ToString();
                materialType.s_material_type_desc_custom_08 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_08"].ToString();
                materialType.s_material_type_name_custom_09 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_09"].ToString();
                materialType.s_material_type_desc_custom_09 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_09"].ToString();
                materialType.s_material_type_name_custom_10 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_10"].ToString();
                materialType.s_material_type_desc_custom_10 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_10"].ToString();
                materialType.s_material_type_name_custom_11 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_11"].ToString();
                materialType.s_material_type_desc_custom_11 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_11"].ToString();
                materialType.s_material_type_name_custom_12 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_12"].ToString();
                materialType.s_material_type_desc_custom_12 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_12"].ToString();
                materialType.s_material_type_name_custom_13 = dtGetmaterialType.Rows[0]["s_material_type_name_custom_13"].ToString();
                materialType.s_material_type_desc_custom_13 = dtGetmaterialType.Rows[0]["s_material_type_desc_custom_13"].ToString();

                return materialType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateMaterialType(SystemMaterialType updatematerialTypes)
        {
            Hashtable htUpdatematerialTypes = new Hashtable();
            htUpdatematerialTypes.Add("@s_material_type_system_id_pk", updatematerialTypes.s_material_type_system_id_pk);
            htUpdatematerialTypes.Add("@s_material_type_id", updatematerialTypes.s_material_type_id);
            htUpdatematerialTypes.Add("@s_material_type_status_id_fk", updatematerialTypes.s_material_type_status_id_fk);
            htUpdatematerialTypes.Add("@s_material_type_name_us_english", updatematerialTypes.s_material_type_name_us_english);
            htUpdatematerialTypes.Add("@s_material_type_desc_us_english", updatematerialTypes.s_material_type_desc_us_english);
            htUpdatematerialTypes.Add("@s_material_type_name_uk_english", updatematerialTypes.s_material_type_name_uk_english);
            htUpdatematerialTypes.Add("@s_material_type_desc_uk_english", updatematerialTypes.s_material_type_desc_uk_english);
            htUpdatematerialTypes.Add("@s_material_type_name_ca_french", updatematerialTypes.s_material_type_name_ca_french);
            htUpdatematerialTypes.Add("@s_material_type_desc_ca_french", updatematerialTypes.s_material_type_desc_ca_french);
            htUpdatematerialTypes.Add("@s_material_type_name_fr_french", updatematerialTypes.s_material_type_name_fr_french);
            htUpdatematerialTypes.Add("@s_material_type_desc_fr_french", updatematerialTypes.s_material_type_desc_fr_french);
            htUpdatematerialTypes.Add("@s_material_type_name_mx_spanish", updatematerialTypes.s_material_type_name_mx_spanish);
            htUpdatematerialTypes.Add("@s_material_type_desc_mx_spanish", updatematerialTypes.s_material_type_desc_mx_spanish);
            htUpdatematerialTypes.Add("@s_material_type_name_sp_spanish", updatematerialTypes.s_material_type_name_sp_spanish);
            htUpdatematerialTypes.Add("@s_material_type_desc_sp_spanish", updatematerialTypes.s_material_type_desc_sp_spanish);
            htUpdatematerialTypes.Add("@s_material_type_name_portuguese", updatematerialTypes.s_material_type_name_portuguese);
            htUpdatematerialTypes.Add("@s_material_type_desc_portuguese", updatematerialTypes.s_material_type_desc_portuguese);
            htUpdatematerialTypes.Add("@s_material_type_name_simp_chinese", updatematerialTypes.s_material_type_name_simp_chinese);
            htUpdatematerialTypes.Add("@s_material_type_desc_simp_chinese", updatematerialTypes.s_material_type_desc_simp_chinese);
            htUpdatematerialTypes.Add("@s_material_type_name_german", updatematerialTypes.s_material_type_name_german);
            htUpdatematerialTypes.Add("@s_material_type_desc_german", updatematerialTypes.s_material_type_desc_german);
            htUpdatematerialTypes.Add("@s_material_type_name_japanese", updatematerialTypes.s_material_type_name_japanese);
            htUpdatematerialTypes.Add("@s_material_type_desc_japanese", updatematerialTypes.s_material_type_desc_japanese);
            htUpdatematerialTypes.Add("@s_material_type_name_russian", updatematerialTypes.s_material_type_name_russian);
            htUpdatematerialTypes.Add("@s_material_type_desc_russian", updatematerialTypes.s_material_type_desc_russian);
            htUpdatematerialTypes.Add("@s_material_type_name_danish", updatematerialTypes.s_material_type_name_danish);
            htUpdatematerialTypes.Add("@s_material_type_desc_danish", updatematerialTypes.s_material_type_desc_danish);
            htUpdatematerialTypes.Add("@s_material_type_name_polish", updatematerialTypes.s_material_type_name_polish);
            htUpdatematerialTypes.Add("@s_material_type_desc_polish", updatematerialTypes.s_material_type_desc_polish);
            htUpdatematerialTypes.Add("@s_material_type_name_swedish", updatematerialTypes.s_material_type_name_swedish);
            htUpdatematerialTypes.Add("@s_material_type_desc_swedish", updatematerialTypes.s_material_type_desc_swedish);
            htUpdatematerialTypes.Add("@s_material_type_name_finnish", updatematerialTypes.s_material_type_name_finnish);
            htUpdatematerialTypes.Add("@s_material_type_desc_finnish", updatematerialTypes.s_material_type_desc_finnish);
            htUpdatematerialTypes.Add("@s_material_type_name_korean", updatematerialTypes.s_material_type_name_korean);
            htUpdatematerialTypes.Add("@s_material_type_desc_korean", updatematerialTypes.s_material_type_desc_korean);
            htUpdatematerialTypes.Add("@s_material_type_name_italian", updatematerialTypes.s_material_type_name_italian);
            htUpdatematerialTypes.Add("@s_material_type_desc_italian", updatematerialTypes.s_material_type_desc_italian);
            htUpdatematerialTypes.Add("@s_material_type_name_dutch", updatematerialTypes.s_material_type_name_dutch);
            htUpdatematerialTypes.Add("@s_material_type_desc_dutch", updatematerialTypes.s_material_type_desc_dutch);
            htUpdatematerialTypes.Add("@s_material_type_name_indonesian", updatematerialTypes.s_material_type_name_indonesian);
            htUpdatematerialTypes.Add("@s_material_type_desc_indonesian", updatematerialTypes.s_material_type_desc_indonesian);
            htUpdatematerialTypes.Add("@s_material_type_name_greek", updatematerialTypes.s_material_type_name_greek);
            htUpdatematerialTypes.Add("@s_material_type_desc_greek", updatematerialTypes.s_material_type_desc_greek);
            htUpdatematerialTypes.Add("@s_material_type_name_hungarian", updatematerialTypes.s_material_type_name_hungarian);
            htUpdatematerialTypes.Add("@s_material_type_desc_hungarian", updatematerialTypes.s_material_type_desc_hungarian);
            htUpdatematerialTypes.Add("@s_material_type_name_norwegian", updatematerialTypes.s_material_type_name_norwegian);
            htUpdatematerialTypes.Add("@s_material_type_desc_norwegian", updatematerialTypes.s_material_type_desc_norwegian);
            htUpdatematerialTypes.Add("@s_material_type_name_turkish", updatematerialTypes.s_material_type_name_turkish);
            htUpdatematerialTypes.Add("@s_material_type_desc_turkish", updatematerialTypes.s_material_type_desc_turkish);
            htUpdatematerialTypes.Add("@s_material_type_name_arabic_rtl", updatematerialTypes.s_material_type_name_arabic_rtl);
            htUpdatematerialTypes.Add("@s_material_type_desc_arabic_rtl", updatematerialTypes.s_material_type_desc_arabic_rtl);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_01", updatematerialTypes.s_material_type_name_custom_01);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_01", updatematerialTypes.s_material_type_desc_custom_01);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_02", updatematerialTypes.s_material_type_name_custom_02);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_02", updatematerialTypes.s_material_type_desc_custom_02);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_03", updatematerialTypes.s_material_type_name_custom_03);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_03", updatematerialTypes.s_material_type_desc_custom_03);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_04", updatematerialTypes.s_material_type_name_custom_04);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_04", updatematerialTypes.s_material_type_desc_custom_04);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_05", updatematerialTypes.s_material_type_name_custom_05);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_05", updatematerialTypes.s_material_type_desc_custom_05);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_06", updatematerialTypes.s_material_type_name_custom_06);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_06", updatematerialTypes.s_material_type_desc_custom_06);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_07", updatematerialTypes.s_material_type_name_custom_07);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_07", updatematerialTypes.s_material_type_desc_custom_07);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_08", updatematerialTypes.s_material_type_name_custom_08);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_08", updatematerialTypes.s_material_type_desc_custom_08);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_09", updatematerialTypes.s_material_type_name_custom_09);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_09", updatematerialTypes.s_material_type_desc_custom_09);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_10", updatematerialTypes.s_material_type_name_custom_10);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_10", updatematerialTypes.s_material_type_desc_custom_10);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_11", updatematerialTypes.s_material_type_name_custom_11);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_11", updatematerialTypes.s_material_type_desc_custom_11);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_12", updatematerialTypes.s_material_type_name_custom_12);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_12", updatematerialTypes.s_material_type_desc_custom_12);
            htUpdatematerialTypes.Add("@s_material_type_name_custom_13", updatematerialTypes.s_material_type_name_custom_13);
            htUpdatematerialTypes.Add("@s_material_type_desc_custom_13", updatematerialTypes.s_material_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_material_type", htUpdatematerialTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateMaterialStatus(string s_material_type_system_id_pk)
        {
            Hashtable htUpdatematerialStatus = new Hashtable();
            htUpdatematerialStatus.Add("@s_material_type_system_id_pk", s_material_type_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_material_type_status", htUpdatematerialStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
