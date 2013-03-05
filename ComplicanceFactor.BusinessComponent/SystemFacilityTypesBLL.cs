using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemFacilityTypesBLL
    {
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
        /// Create Facility Types
        /// </summary>
        /// <param name="createFacilityTypes"></param>
        /// <returns></returns>
        public static int CreateFacilityTypes(SystemFacilityType createFacilityTypes)
        {
            Hashtable htcreateFacilityTypes = new Hashtable();

            htcreateFacilityTypes.Add("@s_facility_type_system_id_pk", createFacilityTypes.s_facility_type_system_id_pk);
            htcreateFacilityTypes.Add("@s_facility_type_id", createFacilityTypes.s_facility_type_id);
            if (createFacilityTypes.s_facility_type_status_id_fk == "0")
                htcreateFacilityTypes.Add("@s_facility_type_status_id_fk", DBNull.Value);
            else
                htcreateFacilityTypes.Add("@s_facility_type_status_id_fk", createFacilityTypes.s_facility_type_status_id_fk);
            htcreateFacilityTypes.Add("@s_facility_type_name_us_english", createFacilityTypes.s_facility_type_name_us_english);
            htcreateFacilityTypes.Add("@s_facility_type_desc_us_english", createFacilityTypes.s_facility_type_desc_us_english);
            htcreateFacilityTypes.Add("@s_facility_type_name_uk_english", createFacilityTypes.s_facility_type_name_uk_english);
            htcreateFacilityTypes.Add("@s_facility_type_desc_uk_english", createFacilityTypes.s_facility_type_desc_uk_english);
            htcreateFacilityTypes.Add("@s_facility_type_name_ca_french", createFacilityTypes.s_facility_type_name_ca_french);
            htcreateFacilityTypes.Add("@s_facility_type_desc_ca_french", createFacilityTypes.s_facility_type_desc_ca_french);
            htcreateFacilityTypes.Add("@s_facility_type_name_fr_french", createFacilityTypes.s_facility_type_name_fr_french);
            htcreateFacilityTypes.Add("@s_facility_type_desc_fr_french", createFacilityTypes.s_facility_type_desc_fr_french);
            htcreateFacilityTypes.Add("@s_facility_type_name_mx_spanish", createFacilityTypes.s_facility_type_name_mx_spanish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_mx_spanish", createFacilityTypes.s_facility_type_desc_mx_spanish);
            htcreateFacilityTypes.Add("@s_facility_type_name_sp_spanish", createFacilityTypes.s_facility_type_name_sp_spanish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_sp_spanish", createFacilityTypes.s_facility_type_desc_sp_spanish);
            htcreateFacilityTypes.Add("@s_facility_type_name_portuguese", createFacilityTypes.s_facility_type_name_portuguese);
            htcreateFacilityTypes.Add("@s_facility_type_desc_portuguese", createFacilityTypes.s_facility_type_desc_portuguese);
            htcreateFacilityTypes.Add("@s_facility_type_name_simp_chinese", createFacilityTypes.s_facility_type_name_simp_chinese);
            htcreateFacilityTypes.Add("@s_facility_type_desc_simp_chinese", createFacilityTypes.s_facility_type_desc_simp_chinese);
            htcreateFacilityTypes.Add("@s_facility_type_name_german", createFacilityTypes.s_facility_type_name_german);
            htcreateFacilityTypes.Add("@s_facility_type_desc_german", createFacilityTypes.s_facility_type_desc_german);
            htcreateFacilityTypes.Add("@s_facility_type_name_japanese", createFacilityTypes.s_facility_type_name_japanese);
            htcreateFacilityTypes.Add("@s_facility_type_desc_japanese", createFacilityTypes.s_facility_type_desc_japanese);
            htcreateFacilityTypes.Add("@s_facility_type_name_russian", createFacilityTypes.s_facility_type_name_russian);
            htcreateFacilityTypes.Add("@s_facility_type_desc_russian", createFacilityTypes.s_facility_type_desc_russian);
            htcreateFacilityTypes.Add("@s_facility_type_name_danish", createFacilityTypes.s_facility_type_name_danish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_danish", createFacilityTypes.s_facility_type_desc_danish);
            htcreateFacilityTypes.Add("@s_facility_type_name_polish", createFacilityTypes.s_facility_type_name_polish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_polish", createFacilityTypes.s_facility_type_desc_polish);
            htcreateFacilityTypes.Add("@s_facility_type_name_swedish", createFacilityTypes.s_facility_type_name_swedish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_swedish", createFacilityTypes.s_facility_type_desc_swedish);
            htcreateFacilityTypes.Add("@s_facility_type_name_finnish", createFacilityTypes.s_facility_type_name_finnish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_finnish", createFacilityTypes.s_facility_type_desc_finnish);
            htcreateFacilityTypes.Add("@s_facility_type_name_korean", createFacilityTypes.s_facility_type_name_korean);
            htcreateFacilityTypes.Add("@s_facility_type_desc_korean", createFacilityTypes.s_facility_type_desc_korean);
            htcreateFacilityTypes.Add("@s_facility_type_name_italian", createFacilityTypes.s_facility_type_name_italian);
            htcreateFacilityTypes.Add("@s_facility_type_desc_italian", createFacilityTypes.s_facility_type_desc_italian);
            htcreateFacilityTypes.Add("@s_facility_type_name_dutch", createFacilityTypes.s_facility_type_name_dutch);
            htcreateFacilityTypes.Add("@s_facility_type_desc_dutch", createFacilityTypes.s_facility_type_desc_dutch);
            htcreateFacilityTypes.Add("@s_facility_type_name_indonesian", createFacilityTypes.s_facility_type_name_indonesian);
            htcreateFacilityTypes.Add("@s_facility_type_desc_indonesian", createFacilityTypes.s_facility_type_desc_indonesian);
            htcreateFacilityTypes.Add("@s_facility_type_name_greek", createFacilityTypes.s_facility_type_name_greek);
            htcreateFacilityTypes.Add("@s_facility_type_desc_greek", createFacilityTypes.s_facility_type_desc_greek);
            htcreateFacilityTypes.Add("@s_facility_type_name_hungarian", createFacilityTypes.s_facility_type_name_hungarian);
            htcreateFacilityTypes.Add("@s_facility_type_desc_hungarian", createFacilityTypes.s_facility_type_desc_hungarian);
            htcreateFacilityTypes.Add("@s_facility_type_name_norwegian", createFacilityTypes.s_facility_type_name_norwegian);
            htcreateFacilityTypes.Add("@s_facility_type_desc_norwegian", createFacilityTypes.s_facility_type_desc_norwegian);
            htcreateFacilityTypes.Add("@s_facility_type_name_turkish", createFacilityTypes.s_facility_type_name_turkish);
            htcreateFacilityTypes.Add("@s_facility_type_desc_turkish", createFacilityTypes.s_facility_type_desc_turkish);
            htcreateFacilityTypes.Add("@s_facility_type_name_arabic_rtl", createFacilityTypes.s_facility_type_name_arabic_rtl);
            htcreateFacilityTypes.Add("@s_facility_type_desc_arabic_rtl", createFacilityTypes.s_facility_type_desc_arabic_rtl);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_01", createFacilityTypes.s_facility_type_name_custom_01);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_01", createFacilityTypes.s_facility_type_desc_custom_01);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_02", createFacilityTypes.s_facility_type_name_custom_02);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_02", createFacilityTypes.s_facility_type_desc_custom_02);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_03", createFacilityTypes.s_facility_type_name_custom_03);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_03", createFacilityTypes.s_facility_type_desc_custom_03);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_04", createFacilityTypes.s_facility_type_name_custom_04);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_04", createFacilityTypes.s_facility_type_desc_custom_04);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_05", createFacilityTypes.s_facility_type_name_custom_05);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_05", createFacilityTypes.s_facility_type_desc_custom_05);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_06", createFacilityTypes.s_facility_type_name_custom_06);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_06", createFacilityTypes.s_facility_type_desc_custom_06);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_07", createFacilityTypes.s_facility_type_name_custom_07);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_07", createFacilityTypes.s_facility_type_desc_custom_07);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_08", createFacilityTypes.s_facility_type_name_custom_08);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_08", createFacilityTypes.s_facility_type_desc_custom_08);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_09", createFacilityTypes.s_facility_type_name_custom_09);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_09", createFacilityTypes.s_facility_type_desc_custom_09);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_10", createFacilityTypes.s_facility_type_name_custom_10);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_10", createFacilityTypes.s_facility_type_desc_custom_10);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_11", createFacilityTypes.s_facility_type_name_custom_11);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_11", createFacilityTypes.s_facility_type_desc_custom_11);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_12", createFacilityTypes.s_facility_type_name_custom_12);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_12", createFacilityTypes.s_facility_type_desc_custom_12);
            htcreateFacilityTypes.Add("@s_facility_type_name_custom_13", createFacilityTypes.s_facility_type_name_custom_13);
            htcreateFacilityTypes.Add("@s_facility_type_desc_custom_13", createFacilityTypes.s_facility_type_desc_custom_13);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_facility_types", htcreateFacilityTypes);
            }
            catch (Exception)
            {
                throw;
            }



        }
        /// <summary>
        /// Get Facility Types
        /// </summary>
        /// <param name="s_facility_type_system_id_pk"></param>
        /// <returns></returns>
        public static SystemFacilityType GetFacilityType(string s_facility_type_system_id_pk)
        {
            SystemFacilityType facilityType;

            try
            {
                Hashtable htGetFacilityTypes = new Hashtable();
                htGetFacilityTypes.Add("@s_facility_type_system_id_pk", s_facility_type_system_id_pk);
                facilityType = new SystemFacilityType();
                DataTable dtGetFacilityType = DataProxy.FetchDataTable("s_sp_get_facility_types", htGetFacilityTypes);
                facilityType.s_facility_type_id = dtGetFacilityType.Rows[0]["s_facility_type_id"].ToString();
                facilityType.s_facility_type_status_id_fk = dtGetFacilityType.Rows[0]["s_facility_type_status_id_fk"].ToString();

                facilityType.s_facility_type_name_us_english = dtGetFacilityType.Rows[0]["s_facility_type_name_us_english"].ToString();
                facilityType.s_facility_type_desc_us_english = dtGetFacilityType.Rows[0]["s_facility_type_desc_us_english"].ToString();
                facilityType.s_facility_type_name_uk_english = dtGetFacilityType.Rows[0]["s_facility_type_name_uk_english"].ToString();
                facilityType.s_facility_type_desc_uk_english = dtGetFacilityType.Rows[0]["s_facility_type_desc_uk_english"].ToString();
                facilityType.s_facility_type_name_ca_french = dtGetFacilityType.Rows[0]["s_facility_type_name_ca_french"].ToString();
                facilityType.s_facility_type_desc_ca_french = dtGetFacilityType.Rows[0]["s_facility_type_desc_ca_french"].ToString();
                facilityType.s_facility_type_name_fr_french = dtGetFacilityType.Rows[0]["s_facility_type_name_fr_french"].ToString();
                facilityType.s_facility_type_desc_fr_french = dtGetFacilityType.Rows[0]["s_facility_type_desc_fr_french"].ToString();
                facilityType.s_facility_type_name_mx_spanish = dtGetFacilityType.Rows[0]["s_facility_type_name_mx_spanish"].ToString();
                facilityType.s_facility_type_desc_mx_spanish = dtGetFacilityType.Rows[0]["s_facility_type_desc_mx_spanish"].ToString();
                facilityType.s_facility_type_name_sp_spanish = dtGetFacilityType.Rows[0]["s_facility_type_name_sp_spanish"].ToString();
                facilityType.s_facility_type_desc_sp_spanish = dtGetFacilityType.Rows[0]["s_facility_type_desc_sp_spanish"].ToString();
                facilityType.s_facility_type_name_portuguese = dtGetFacilityType.Rows[0]["s_facility_type_name_portuguese"].ToString();
                facilityType.s_facility_type_desc_portuguese = dtGetFacilityType.Rows[0]["s_facility_type_desc_portuguese"].ToString();
                facilityType.s_facility_type_name_simp_chinese = dtGetFacilityType.Rows[0]["s_facility_type_name_simp_chinese"].ToString();
                facilityType.s_facility_type_desc_simp_chinese = dtGetFacilityType.Rows[0]["s_facility_type_desc_simp_chinese"].ToString();
                facilityType.s_facility_type_name_german = dtGetFacilityType.Rows[0]["s_facility_type_name_german"].ToString();
                facilityType.s_facility_type_desc_german = dtGetFacilityType.Rows[0]["s_facility_type_desc_german"].ToString();
                facilityType.s_facility_type_name_japanese = dtGetFacilityType.Rows[0]["s_facility_type_name_japanese"].ToString();
                facilityType.s_facility_type_desc_japanese = dtGetFacilityType.Rows[0]["s_facility_type_desc_japanese"].ToString();
                facilityType.s_facility_type_name_russian = dtGetFacilityType.Rows[0]["s_facility_type_name_russian"].ToString();
                facilityType.s_facility_type_desc_russian = dtGetFacilityType.Rows[0]["s_facility_type_desc_russian"].ToString();
                facilityType.s_facility_type_name_danish = dtGetFacilityType.Rows[0]["s_facility_type_name_danish"].ToString();
                facilityType.s_facility_type_desc_danish = dtGetFacilityType.Rows[0]["s_facility_type_desc_danish"].ToString();
                facilityType.s_facility_type_name_polish = dtGetFacilityType.Rows[0]["s_facility_type_name_polish"].ToString();
                facilityType.s_facility_type_desc_polish = dtGetFacilityType.Rows[0]["s_facility_type_desc_polish"].ToString();
                facilityType.s_facility_type_name_swedish = dtGetFacilityType.Rows[0]["s_facility_type_name_swedish"].ToString();
                facilityType.s_facility_type_desc_swedish = dtGetFacilityType.Rows[0]["s_facility_type_desc_swedish"].ToString();
                facilityType.s_facility_type_name_finnish = dtGetFacilityType.Rows[0]["s_facility_type_name_finnish"].ToString();
                facilityType.s_facility_type_desc_finnish = dtGetFacilityType.Rows[0]["s_facility_type_desc_finnish"].ToString();
                facilityType.s_facility_type_name_korean = dtGetFacilityType.Rows[0]["s_facility_type_name_korean"].ToString();
                facilityType.s_facility_type_desc_korean = dtGetFacilityType.Rows[0]["s_facility_type_desc_korean"].ToString();
                facilityType.s_facility_type_name_italian = dtGetFacilityType.Rows[0]["s_facility_type_name_italian"].ToString();
                facilityType.s_facility_type_desc_italian = dtGetFacilityType.Rows[0]["s_facility_type_desc_italian"].ToString();
                facilityType.s_facility_type_name_dutch = dtGetFacilityType.Rows[0]["s_facility_type_name_dutch"].ToString();
                facilityType.s_facility_type_desc_dutch = dtGetFacilityType.Rows[0]["s_facility_type_desc_dutch"].ToString();
                facilityType.s_facility_type_name_indonesian = dtGetFacilityType.Rows[0]["s_facility_type_name_indonesian"].ToString();
                facilityType.s_facility_type_desc_indonesian = dtGetFacilityType.Rows[0]["s_facility_type_desc_indonesian"].ToString();
                facilityType.s_facility_type_name_greek = dtGetFacilityType.Rows[0]["s_facility_type_name_greek"].ToString();
                facilityType.s_facility_type_desc_greek = dtGetFacilityType.Rows[0]["s_facility_type_desc_greek"].ToString();
                facilityType.s_facility_type_name_hungarian = dtGetFacilityType.Rows[0]["s_facility_type_name_hungarian"].ToString();
                facilityType.s_facility_type_desc_hungarian = dtGetFacilityType.Rows[0]["s_facility_type_desc_hungarian"].ToString();
                facilityType.s_facility_type_name_norwegian = dtGetFacilityType.Rows[0]["s_facility_type_name_norwegian"].ToString();
                facilityType.s_facility_type_desc_norwegian = dtGetFacilityType.Rows[0]["s_facility_type_desc_norwegian"].ToString();
                facilityType.s_facility_type_name_turkish = dtGetFacilityType.Rows[0]["s_facility_type_name_turkish"].ToString();
                facilityType.s_facility_type_desc_turkish = dtGetFacilityType.Rows[0]["s_facility_type_desc_turkish"].ToString();
                facilityType.s_facility_type_name_arabic_rtl = dtGetFacilityType.Rows[0]["s_facility_type_name_arabic_rtl"].ToString();
                facilityType.s_facility_type_desc_arabic_rtl = dtGetFacilityType.Rows[0]["s_facility_type_desc_arabic_rtl"].ToString();
                facilityType.s_facility_type_name_custom_01 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_01"].ToString();
                facilityType.s_facility_type_desc_custom_01 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_01"].ToString();
                facilityType.s_facility_type_name_custom_02 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_02"].ToString();
                facilityType.s_facility_type_desc_custom_02 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_02"].ToString();
                facilityType.s_facility_type_name_custom_03 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_03"].ToString();
                facilityType.s_facility_type_desc_custom_03 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_03"].ToString();
                facilityType.s_facility_type_name_custom_04 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_04"].ToString();
                facilityType.s_facility_type_desc_custom_04 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_04"].ToString();
                facilityType.s_facility_type_name_custom_05 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_05"].ToString();
                facilityType.s_facility_type_desc_custom_05 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_05"].ToString();
                facilityType.s_facility_type_name_custom_06 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_06"].ToString();
                facilityType.s_facility_type_desc_custom_06 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_06"].ToString();
                facilityType.s_facility_type_name_custom_07 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_07"].ToString();
                facilityType.s_facility_type_desc_custom_07 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_07"].ToString();
                facilityType.s_facility_type_name_custom_08 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_08"].ToString();
                facilityType.s_facility_type_desc_custom_08 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_08"].ToString();
                facilityType.s_facility_type_name_custom_09 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_09"].ToString();
                facilityType.s_facility_type_desc_custom_09 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_09"].ToString();
                facilityType.s_facility_type_name_custom_10 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_10"].ToString();
                facilityType.s_facility_type_desc_custom_10 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_10"].ToString();
                facilityType.s_facility_type_name_custom_11 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_11"].ToString();
                facilityType.s_facility_type_desc_custom_11 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_11"].ToString();
                facilityType.s_facility_type_name_custom_12 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_12"].ToString();
                facilityType.s_facility_type_desc_custom_12 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_12"].ToString();
                facilityType.s_facility_type_name_custom_13 = dtGetFacilityType.Rows[0]["s_facility_type_name_custom_13"].ToString();
                facilityType.s_facility_type_desc_custom_13 = dtGetFacilityType.Rows[0]["s_facility_type_desc_custom_13"].ToString();


                return facilityType;
            }
            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Update Facility Types
        /// </summary>
        /// <param name="updateFacilityTypes"></param>
        /// <returns></returns>
        public static int UpdateFacilityTypes(SystemFacilityType updateFacilityTypes)
        {
            Hashtable htUpdateFacilityTypes = new Hashtable();

            htUpdateFacilityTypes.Add("@s_facility_type_system_id_pk", updateFacilityTypes.s_facility_type_system_id_pk);
            htUpdateFacilityTypes.Add("@s_facility_type_id", updateFacilityTypes.s_facility_type_id);
            htUpdateFacilityTypes.Add("@s_facility_type_status_id_fk", updateFacilityTypes.s_facility_type_status_id_fk);

            htUpdateFacilityTypes.Add("@s_facility_type_name_us_english", updateFacilityTypes.s_facility_type_name_us_english);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_us_english", updateFacilityTypes.s_facility_type_desc_us_english);
            htUpdateFacilityTypes.Add("@s_facility_type_name_uk_english", updateFacilityTypes.s_facility_type_name_uk_english);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_uk_english", updateFacilityTypes.s_facility_type_desc_uk_english);
            htUpdateFacilityTypes.Add("@s_facility_type_name_ca_french", updateFacilityTypes.s_facility_type_name_ca_french);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_ca_french", updateFacilityTypes.s_facility_type_desc_ca_french);
            htUpdateFacilityTypes.Add("@s_facility_type_name_fr_french", updateFacilityTypes.s_facility_type_name_fr_french);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_fr_french", updateFacilityTypes.s_facility_type_desc_fr_french);
            htUpdateFacilityTypes.Add("@s_facility_type_name_mx_spanish", updateFacilityTypes.s_facility_type_name_mx_spanish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_mx_spanish", updateFacilityTypes.s_facility_type_desc_mx_spanish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_sp_spanish", updateFacilityTypes.s_facility_type_name_sp_spanish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_sp_spanish", updateFacilityTypes.s_facility_type_desc_sp_spanish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_portuguese", updateFacilityTypes.s_facility_type_name_portuguese);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_portuguese", updateFacilityTypes.s_facility_type_desc_portuguese);
            htUpdateFacilityTypes.Add("@s_facility_type_name_simp_chinese", updateFacilityTypes.s_facility_type_name_simp_chinese);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_simp_chinese", updateFacilityTypes.s_facility_type_desc_simp_chinese);
            htUpdateFacilityTypes.Add("@s_facility_type_name_german", updateFacilityTypes.s_facility_type_name_german);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_german", updateFacilityTypes.s_facility_type_desc_german);
            htUpdateFacilityTypes.Add("@s_facility_type_name_japanese", updateFacilityTypes.s_facility_type_name_japanese);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_japanese", updateFacilityTypes.s_facility_type_desc_japanese);
            htUpdateFacilityTypes.Add("@s_facility_type_name_russian", updateFacilityTypes.s_facility_type_name_russian);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_russian", updateFacilityTypes.s_facility_type_desc_russian);
            htUpdateFacilityTypes.Add("@s_facility_type_name_danish", updateFacilityTypes.s_facility_type_name_danish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_danish", updateFacilityTypes.s_facility_type_desc_danish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_polish", updateFacilityTypes.s_facility_type_name_polish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_polish", updateFacilityTypes.s_facility_type_desc_polish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_swedish", updateFacilityTypes.s_facility_type_name_swedish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_swedish", updateFacilityTypes.s_facility_type_desc_swedish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_finnish", updateFacilityTypes.s_facility_type_name_finnish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_finnish", updateFacilityTypes.s_facility_type_desc_finnish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_korean", updateFacilityTypes.s_facility_type_name_korean);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_korean", updateFacilityTypes.s_facility_type_desc_korean);
            htUpdateFacilityTypes.Add("@s_facility_type_name_italian", updateFacilityTypes.s_facility_type_name_italian);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_italian", updateFacilityTypes.s_facility_type_desc_italian);
            htUpdateFacilityTypes.Add("@s_facility_type_name_dutch", updateFacilityTypes.s_facility_type_name_dutch);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_dutch", updateFacilityTypes.s_facility_type_desc_dutch);
            htUpdateFacilityTypes.Add("@s_facility_type_name_indonesian", updateFacilityTypes.s_facility_type_name_indonesian);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_indonesian", updateFacilityTypes.s_facility_type_desc_indonesian);
            htUpdateFacilityTypes.Add("@s_facility_type_name_greek", updateFacilityTypes.s_facility_type_name_greek);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_greek", updateFacilityTypes.s_facility_type_desc_greek);
            htUpdateFacilityTypes.Add("@s_facility_type_name_hungarian", updateFacilityTypes.s_facility_type_name_hungarian);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_hungarian", updateFacilityTypes.s_facility_type_desc_hungarian);
            htUpdateFacilityTypes.Add("@s_facility_type_name_norwegian", updateFacilityTypes.s_facility_type_name_norwegian);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_norwegian", updateFacilityTypes.s_facility_type_desc_norwegian);
            htUpdateFacilityTypes.Add("@s_facility_type_name_turkish", updateFacilityTypes.s_facility_type_name_turkish);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_turkish", updateFacilityTypes.s_facility_type_desc_turkish);
            htUpdateFacilityTypes.Add("@s_facility_type_name_arabic_rtl", updateFacilityTypes.s_facility_type_name_arabic_rtl);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_arabic_rtl", updateFacilityTypes.s_facility_type_desc_arabic_rtl);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_01", updateFacilityTypes.s_facility_type_name_custom_01);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_01", updateFacilityTypes.s_facility_type_desc_custom_01);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_02", updateFacilityTypes.s_facility_type_name_custom_02);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_02", updateFacilityTypes.s_facility_type_desc_custom_02);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_03", updateFacilityTypes.s_facility_type_name_custom_03);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_03", updateFacilityTypes.s_facility_type_desc_custom_03);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_04", updateFacilityTypes.s_facility_type_name_custom_04);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_04", updateFacilityTypes.s_facility_type_desc_custom_04);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_05", updateFacilityTypes.s_facility_type_name_custom_05);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_05", updateFacilityTypes.s_facility_type_desc_custom_05);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_06", updateFacilityTypes.s_facility_type_name_custom_06);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_06", updateFacilityTypes.s_facility_type_desc_custom_06);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_07", updateFacilityTypes.s_facility_type_name_custom_07);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_07", updateFacilityTypes.s_facility_type_desc_custom_07);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_08", updateFacilityTypes.s_facility_type_name_custom_08);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_08", updateFacilityTypes.s_facility_type_desc_custom_08);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_09", updateFacilityTypes.s_facility_type_name_custom_09);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_09", updateFacilityTypes.s_facility_type_desc_custom_09);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_10", updateFacilityTypes.s_facility_type_name_custom_10);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_10", updateFacilityTypes.s_facility_type_desc_custom_10);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_11", updateFacilityTypes.s_facility_type_name_custom_11);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_11", updateFacilityTypes.s_facility_type_desc_custom_11);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_12", updateFacilityTypes.s_facility_type_name_custom_12);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_12", updateFacilityTypes.s_facility_type_desc_custom_12);
            htUpdateFacilityTypes.Add("@s_facility_type_name_custom_13", updateFacilityTypes.s_facility_type_name_custom_13);
            htUpdateFacilityTypes.Add("@s_facility_type_desc_custom_13", updateFacilityTypes.s_facility_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_facility_types", htUpdateFacilityTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchFacilityTypes(SystemFacilityType facilityType)
        {
            Hashtable htFacilityType = new Hashtable();
            htFacilityType.Add("@s_facility_type_id", facilityType.s_facility_type_id);
            htFacilityType.Add("@s_facility_type_name_us_english", facilityType.s_facility_type_name_us_english);


            if (facilityType.s_facility_type_status_id_fk == "0")
                htFacilityType.Add("@s_facility_type_status_id_fk", DBNull.Value);
            else
                htFacilityType.Add("@s_facility_type_status_id_fk", facilityType.s_facility_type_status_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_facility_type_search", htFacilityType);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UpdateFacilityTypeStatus(string s_facility_type_system_id_pk)
        {
            Hashtable htUpdateDomainStatus = new Hashtable();
            htUpdateDomainStatus.Add("@s_facility_type_system_id_pk", s_facility_type_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_facility_type_status", htUpdateDomainStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
