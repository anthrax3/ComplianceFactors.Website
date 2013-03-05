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
    public class SysemDeliveryTypesBLL
    {
        /// <summary>
        /// Get Delivery Types
        /// </summary>
        /// <returns></returns>

        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmStatus = new Hashtable();
                htGetHarmStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetHarmStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmAllStatus = new Hashtable();
                htGetHarmAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetHarmAllStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetDeliveryMode()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_delivery_mode");
            }
            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Create Delivery Types
        /// </summary>
        /// <param name="createDeliveryTypes"></param>
        /// <returns></returns>
        public static int CreateDeliveryTypes(SystemDeliveryType createDeliveryTypes)
        {
            Hashtable htCreateDeliveryTypes = new Hashtable();

            htCreateDeliveryTypes.Add("@s_delivery_type_system_id_pk", createDeliveryTypes.s_delivery_type_system_id_pk);
            htCreateDeliveryTypes.Add("@s_delivery_type_id", createDeliveryTypes.s_delivery_type_id);
            htCreateDeliveryTypes.Add("@s_delivery_type_status_id_fk", createDeliveryTypes.s_delivery_type_status_id_fk);
            htCreateDeliveryTypes.Add("@s_delivery_type_mode_id_fk", createDeliveryTypes.s_delivery_type_mode_id_fk);

            htCreateDeliveryTypes.Add("@s_delivery_type_name_us_english", createDeliveryTypes.s_delivery_type_name_us_english);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_us_english", createDeliveryTypes.s_delivery_type_desc_us_english);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_uk_english", createDeliveryTypes.s_delivery_type_name_uk_english);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_uk_english", createDeliveryTypes.s_delivery_type_desc_uk_english);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_ca_french", createDeliveryTypes.s_delivery_type_name_ca_french);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_ca_french", createDeliveryTypes.s_delivery_type_desc_ca_french);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_fr_french", createDeliveryTypes.s_delivery_type_name_fr_french);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_fr_french", createDeliveryTypes.s_delivery_type_desc_fr_french);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_mx_spanish", createDeliveryTypes.s_delivery_type_name_mx_spanish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_mx_spanish", createDeliveryTypes.s_delivery_type_desc_mx_spanish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_sp_spanish", createDeliveryTypes.s_delivery_type_name_sp_spanish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_sp_spanish", createDeliveryTypes.s_delivery_type_desc_sp_spanish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_portuguese", createDeliveryTypes.s_delivery_type_name_portuguese);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_portuguese", createDeliveryTypes.s_delivery_type_desc_portuguese);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_simp_chinese", createDeliveryTypes.s_delivery_type_name_simp_chinese);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_simp_chinese", createDeliveryTypes.s_delivery_type_desc_simp_chinese);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_german", createDeliveryTypes.s_delivery_type_name_german);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_german", createDeliveryTypes.s_delivery_type_desc_german);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_japanese", createDeliveryTypes.s_delivery_type_name_japanese);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_japanese", createDeliveryTypes.s_delivery_type_desc_japanese);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_russian", createDeliveryTypes.s_delivery_type_name_russian);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_russian", createDeliveryTypes.s_delivery_type_desc_russian);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_danish", createDeliveryTypes.s_delivery_type_name_danish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_danish", createDeliveryTypes.s_delivery_type_desc_danish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_polish", createDeliveryTypes.s_delivery_type_name_polish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_polish", createDeliveryTypes.s_delivery_type_desc_polish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_swedish", createDeliveryTypes.s_delivery_type_name_swedish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_swedish", createDeliveryTypes.s_delivery_type_desc_swedish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_finnish", createDeliveryTypes.s_delivery_type_name_finnish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_finnish", createDeliveryTypes.s_delivery_type_desc_finnish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_korean", createDeliveryTypes.s_delivery_type_name_korean);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_korean", createDeliveryTypes.s_delivery_type_desc_korean);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_italian", createDeliveryTypes.s_delivery_type_name_italian);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_italian", createDeliveryTypes.s_delivery_type_desc_italian);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_dutch", createDeliveryTypes.s_delivery_type_name_dutch);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_dutch", createDeliveryTypes.s_delivery_type_desc_dutch);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_indonesian", createDeliveryTypes.s_delivery_type_name_indonesian);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_indonesian", createDeliveryTypes.s_delivery_type_desc_indonesian);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_greek", createDeliveryTypes.s_delivery_type_name_greek);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_greek", createDeliveryTypes.s_delivery_type_desc_greek);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_hungarian", createDeliveryTypes.s_delivery_type_name_hungarian);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_hungarian", createDeliveryTypes.s_delivery_type_desc_hungarian);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_norwegian", createDeliveryTypes.s_delivery_type_name_norwegian);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_norwegian", createDeliveryTypes.s_delivery_type_desc_norwegian);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_turkish", createDeliveryTypes.s_delivery_type_name_turkish);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_turkish", createDeliveryTypes.s_delivery_type_desc_turkish);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_arabic_rtl", createDeliveryTypes.s_delivery_type_name_arabic_rtl);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_arabic_rtl", createDeliveryTypes.s_delivery_type_desc_arabic_rtl);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_01", createDeliveryTypes.s_delivery_type_name_custom_01);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_01", createDeliveryTypes.s_delivery_type_desc_custom_01);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_02", createDeliveryTypes.s_delivery_type_name_custom_02);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_02", createDeliveryTypes.s_delivery_type_desc_custom_02);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_03", createDeliveryTypes.s_delivery_type_name_custom_03);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_03", createDeliveryTypes.s_delivery_type_desc_custom_03);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_04", createDeliveryTypes.s_delivery_type_name_custom_04);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_04", createDeliveryTypes.s_delivery_type_desc_custom_04);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_05", createDeliveryTypes.s_delivery_type_name_custom_05);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_05", createDeliveryTypes.s_delivery_type_desc_custom_05);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_06", createDeliveryTypes.s_delivery_type_name_custom_06);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_06", createDeliveryTypes.s_delivery_type_desc_custom_06);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_07", createDeliveryTypes.s_delivery_type_name_custom_07);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_07", createDeliveryTypes.s_delivery_type_desc_custom_07);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_08", createDeliveryTypes.s_delivery_type_name_custom_08);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_08", createDeliveryTypes.s_delivery_type_desc_custom_08);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_09", createDeliveryTypes.s_delivery_type_name_custom_09);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_09", createDeliveryTypes.s_delivery_type_desc_custom_09);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_10", createDeliveryTypes.s_delivery_type_name_custom_10);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_10", createDeliveryTypes.s_delivery_type_desc_custom_10);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_11", createDeliveryTypes.s_delivery_type_name_custom_11);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_11", createDeliveryTypes.s_delivery_type_desc_custom_11);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_12", createDeliveryTypes.s_delivery_type_name_custom_12);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_12", createDeliveryTypes.s_delivery_type_desc_custom_12);
            htCreateDeliveryTypes.Add("@s_delivery_type_name_custom_13", createDeliveryTypes.s_delivery_type_name_custom_13);
            htCreateDeliveryTypes.Add("@s_delivery_type_desc_custom_13", createDeliveryTypes.s_delivery_type_desc_custom_13);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_delivery_types", htCreateDeliveryTypes);
            }
            catch (Exception)
            {
                throw;
            }



        }
        /// <summary>
        /// Get Delivery Types
        /// </summary>
        /// <param name="s_delivery_type_system_id_pk"></param>
        /// <returns></returns>
        public static SystemDeliveryType GetDeliveryType(string s_delivery_type_system_id_pk)
        {
            SystemDeliveryType deliveryType;

            try
            {
                Hashtable htGetDeliveryTypes = new Hashtable();
                htGetDeliveryTypes.Add("@s_delivery_type_system_id_pk", s_delivery_type_system_id_pk);
                deliveryType = new SystemDeliveryType();
                DataTable dtGetDeliveryType = DataProxy.FetchDataTable("s_sp_get_delivery_types", htGetDeliveryTypes);
                deliveryType.s_delivery_type_id = dtGetDeliveryType.Rows[0]["s_delivery_type_id"].ToString();
                deliveryType.s_delivery_type_status_id_fk = dtGetDeliveryType.Rows[0]["s_delivery_type_status_id_fk"].ToString();
                deliveryType.s_delivery_type_mode_id_fk = dtGetDeliveryType.Rows[0]["s_delivery_type_mode_id_fk"].ToString();

                deliveryType.s_delivery_type_name_us_english = dtGetDeliveryType.Rows[0]["s_delivery_type_name_us_english"].ToString();
                deliveryType.s_delivery_type_desc_us_english = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_us_english"].ToString();
                deliveryType.s_delivery_type_name_uk_english = dtGetDeliveryType.Rows[0]["s_delivery_type_name_uk_english"].ToString();
                deliveryType.s_delivery_type_desc_uk_english = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_uk_english"].ToString();
                deliveryType.s_delivery_type_name_ca_french = dtGetDeliveryType.Rows[0]["s_delivery_type_name_ca_french"].ToString();
                deliveryType.s_delivery_type_desc_ca_french = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_ca_french"].ToString();
                deliveryType.s_delivery_type_name_fr_french = dtGetDeliveryType.Rows[0]["s_delivery_type_name_fr_french"].ToString();
                deliveryType.s_delivery_type_desc_fr_french = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_fr_french"].ToString();
                deliveryType.s_delivery_type_name_mx_spanish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_mx_spanish"].ToString();
                deliveryType.s_delivery_type_desc_mx_spanish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_mx_spanish"].ToString();
                deliveryType.s_delivery_type_name_sp_spanish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_sp_spanish"].ToString();
                deliveryType.s_delivery_type_desc_sp_spanish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_sp_spanish"].ToString();
                deliveryType.s_delivery_type_name_portuguese = dtGetDeliveryType.Rows[0]["s_delivery_type_name_portuguese"].ToString();
                deliveryType.s_delivery_type_desc_portuguese = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_portuguese"].ToString();
                deliveryType.s_delivery_type_name_simp_chinese = dtGetDeliveryType.Rows[0]["s_delivery_type_name_simp_chinese"].ToString();
                deliveryType.s_delivery_type_desc_simp_chinese = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_simp_chinese"].ToString();
                deliveryType.s_delivery_type_name_german = dtGetDeliveryType.Rows[0]["s_delivery_type_name_german"].ToString();
                deliveryType.s_delivery_type_desc_german = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_german"].ToString();
                deliveryType.s_delivery_type_name_japanese = dtGetDeliveryType.Rows[0]["s_delivery_type_name_japanese"].ToString();
                deliveryType.s_delivery_type_desc_japanese = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_japanese"].ToString();
                deliveryType.s_delivery_type_name_russian = dtGetDeliveryType.Rows[0]["s_delivery_type_name_russian"].ToString();
                deliveryType.s_delivery_type_desc_russian = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_russian"].ToString();
                deliveryType.s_delivery_type_name_danish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_danish"].ToString();
                deliveryType.s_delivery_type_desc_danish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_danish"].ToString();
                deliveryType.s_delivery_type_name_polish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_polish"].ToString();
                deliveryType.s_delivery_type_desc_polish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_polish"].ToString();
                deliveryType.s_delivery_type_name_swedish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_swedish"].ToString();
                deliveryType.s_delivery_type_desc_swedish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_swedish"].ToString();
                deliveryType.s_delivery_type_name_finnish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_finnish"].ToString();
                deliveryType.s_delivery_type_desc_finnish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_finnish"].ToString();
                deliveryType.s_delivery_type_name_korean = dtGetDeliveryType.Rows[0]["s_delivery_type_name_korean"].ToString();
                deliveryType.s_delivery_type_desc_korean = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_korean"].ToString();
                deliveryType.s_delivery_type_name_italian = dtGetDeliveryType.Rows[0]["s_delivery_type_name_italian"].ToString();
                deliveryType.s_delivery_type_desc_italian = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_italian"].ToString();
                deliveryType.s_delivery_type_name_dutch = dtGetDeliveryType.Rows[0]["s_delivery_type_name_dutch"].ToString();
                deliveryType.s_delivery_type_desc_dutch = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_dutch"].ToString();
                deliveryType.s_delivery_type_name_indonesian = dtGetDeliveryType.Rows[0]["s_delivery_type_name_indonesian"].ToString();
                deliveryType.s_delivery_type_desc_indonesian = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_indonesian"].ToString();
                deliveryType.s_delivery_type_name_greek = dtGetDeliveryType.Rows[0]["s_delivery_type_name_greek"].ToString();
                deliveryType.s_delivery_type_desc_greek = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_greek"].ToString();
                deliveryType.s_delivery_type_name_hungarian = dtGetDeliveryType.Rows[0]["s_delivery_type_name_hungarian"].ToString();
                deliveryType.s_delivery_type_desc_hungarian = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_hungarian"].ToString();
                deliveryType.s_delivery_type_name_norwegian = dtGetDeliveryType.Rows[0]["s_delivery_type_name_norwegian"].ToString();
                deliveryType.s_delivery_type_desc_norwegian = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_norwegian"].ToString();
                deliveryType.s_delivery_type_name_turkish = dtGetDeliveryType.Rows[0]["s_delivery_type_name_turkish"].ToString();
                deliveryType.s_delivery_type_desc_turkish = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_turkish"].ToString();
                deliveryType.s_delivery_type_name_arabic_rtl = dtGetDeliveryType.Rows[0]["s_delivery_type_name_arabic_rtl"].ToString();
                deliveryType.s_delivery_type_desc_arabic_rtl = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_arabic_rtl"].ToString();
                deliveryType.s_delivery_type_name_custom_01 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_01"].ToString();
                deliveryType.s_delivery_type_desc_custom_01 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_01"].ToString();
                deliveryType.s_delivery_type_name_custom_02 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_02"].ToString();
                deliveryType.s_delivery_type_desc_custom_02 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_02"].ToString();
                deliveryType.s_delivery_type_name_custom_03 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_03"].ToString();
                deliveryType.s_delivery_type_desc_custom_03 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_03"].ToString();
                deliveryType.s_delivery_type_name_custom_04 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_04"].ToString();
                deliveryType.s_delivery_type_desc_custom_04 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_04"].ToString();
                deliveryType.s_delivery_type_name_custom_05 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_05"].ToString();
                deliveryType.s_delivery_type_desc_custom_05 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_05"].ToString();
                deliveryType.s_delivery_type_name_custom_06 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_06"].ToString();
                deliveryType.s_delivery_type_desc_custom_06 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_06"].ToString();
                deliveryType.s_delivery_type_name_custom_07 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_07"].ToString();
                deliveryType.s_delivery_type_desc_custom_07 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_07"].ToString();
                deliveryType.s_delivery_type_name_custom_08 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_08"].ToString();
                deliveryType.s_delivery_type_desc_custom_08 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_08"].ToString();
                deliveryType.s_delivery_type_name_custom_09 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_09"].ToString();
                deliveryType.s_delivery_type_desc_custom_09 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_09"].ToString();
                deliveryType.s_delivery_type_name_custom_10 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_10"].ToString();
                deliveryType.s_delivery_type_desc_custom_10 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_10"].ToString();
                deliveryType.s_delivery_type_name_custom_11 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_11"].ToString();
                deliveryType.s_delivery_type_desc_custom_11 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_11"].ToString();
                deliveryType.s_delivery_type_name_custom_12 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_12"].ToString();
                deliveryType.s_delivery_type_desc_custom_12 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_12"].ToString();
                deliveryType.s_delivery_type_name_custom_13 = dtGetDeliveryType.Rows[0]["s_delivery_type_name_custom_13"].ToString();
                deliveryType.s_delivery_type_desc_custom_13 = dtGetDeliveryType.Rows[0]["s_delivery_type_desc_custom_13"].ToString();
                return deliveryType;
            }
            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Update Delivery Types
        /// </summary>
        /// <param name="updateDeliveryTypes"></param>
        /// <returns></returns>
        public static int UpdateDeliveryTypes(SystemDeliveryType updateDeliveryTypes)
        {
            Hashtable htUpdateDeliveryTypes = new Hashtable();

            htUpdateDeliveryTypes.Add("@s_delivery_type_system_id_pk", updateDeliveryTypes.s_delivery_type_system_id_pk);
            htUpdateDeliveryTypes.Add("@s_delivery_type_id", updateDeliveryTypes.s_delivery_type_id);
            htUpdateDeliveryTypes.Add("@s_delivery_type_status_id_fk", updateDeliveryTypes.s_delivery_type_status_id_fk);
            htUpdateDeliveryTypes.Add("@s_delivery_type_mode_id_fk", updateDeliveryTypes.s_delivery_type_mode_id_fk);

            htUpdateDeliveryTypes.Add("@s_delivery_type_name_us_english", updateDeliveryTypes.s_delivery_type_name_us_english);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_us_english", updateDeliveryTypes.s_delivery_type_desc_us_english);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_uk_english", updateDeliveryTypes.s_delivery_type_name_uk_english);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_uk_english", updateDeliveryTypes.s_delivery_type_desc_uk_english);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_ca_french", updateDeliveryTypes.s_delivery_type_name_ca_french);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_ca_french", updateDeliveryTypes.s_delivery_type_desc_ca_french);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_fr_french", updateDeliveryTypes.s_delivery_type_name_fr_french);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_fr_french", updateDeliveryTypes.s_delivery_type_desc_fr_french);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_mx_spanish", updateDeliveryTypes.s_delivery_type_name_mx_spanish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_mx_spanish", updateDeliveryTypes.s_delivery_type_desc_mx_spanish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_sp_spanish", updateDeliveryTypes.s_delivery_type_name_sp_spanish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_sp_spanish", updateDeliveryTypes.s_delivery_type_desc_sp_spanish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_portuguese", updateDeliveryTypes.s_delivery_type_name_portuguese);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_portuguese", updateDeliveryTypes.s_delivery_type_desc_portuguese);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_simp_chinese", updateDeliveryTypes.s_delivery_type_name_simp_chinese);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_simp_chinese", updateDeliveryTypes.s_delivery_type_desc_simp_chinese);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_german", updateDeliveryTypes.s_delivery_type_name_german);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_german", updateDeliveryTypes.s_delivery_type_desc_german);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_japanese", updateDeliveryTypes.s_delivery_type_name_japanese);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_japanese", updateDeliveryTypes.s_delivery_type_desc_japanese);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_russian", updateDeliveryTypes.s_delivery_type_name_russian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_russian", updateDeliveryTypes.s_delivery_type_desc_russian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_danish", updateDeliveryTypes.s_delivery_type_name_danish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_danish", updateDeliveryTypes.s_delivery_type_desc_danish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_polish", updateDeliveryTypes.s_delivery_type_name_polish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_polish", updateDeliveryTypes.s_delivery_type_desc_polish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_swedish", updateDeliveryTypes.s_delivery_type_name_swedish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_swedish", updateDeliveryTypes.s_delivery_type_desc_swedish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_finnish", updateDeliveryTypes.s_delivery_type_name_finnish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_finnish", updateDeliveryTypes.s_delivery_type_desc_finnish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_korean", updateDeliveryTypes.s_delivery_type_name_korean);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_korean", updateDeliveryTypes.s_delivery_type_desc_korean);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_italian", updateDeliveryTypes.s_delivery_type_name_italian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_italian", updateDeliveryTypes.s_delivery_type_desc_italian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_dutch", updateDeliveryTypes.s_delivery_type_name_dutch);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_dutch", updateDeliveryTypes.s_delivery_type_desc_dutch);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_indonesian", updateDeliveryTypes.s_delivery_type_name_indonesian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_indonesian", updateDeliveryTypes.s_delivery_type_desc_indonesian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_greek", updateDeliveryTypes.s_delivery_type_name_greek);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_greek", updateDeliveryTypes.s_delivery_type_desc_greek);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_hungarian", updateDeliveryTypes.s_delivery_type_name_hungarian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_hungarian", updateDeliveryTypes.s_delivery_type_desc_hungarian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_norwegian", updateDeliveryTypes.s_delivery_type_name_norwegian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_norwegian", updateDeliveryTypes.s_delivery_type_desc_norwegian);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_turkish", updateDeliveryTypes.s_delivery_type_name_turkish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_turkish", updateDeliveryTypes.s_delivery_type_desc_turkish);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_arabic_rtl", updateDeliveryTypes.s_delivery_type_name_arabic_rtl);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_arabic_rtl", updateDeliveryTypes.s_delivery_type_desc_arabic_rtl);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_01", updateDeliveryTypes.s_delivery_type_name_custom_01);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_01", updateDeliveryTypes.s_delivery_type_desc_custom_01);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_02", updateDeliveryTypes.s_delivery_type_name_custom_02);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_02", updateDeliveryTypes.s_delivery_type_desc_custom_02);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_03", updateDeliveryTypes.s_delivery_type_name_custom_03);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_03", updateDeliveryTypes.s_delivery_type_desc_custom_03);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_04", updateDeliveryTypes.s_delivery_type_name_custom_04);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_04", updateDeliveryTypes.s_delivery_type_desc_custom_04);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_05", updateDeliveryTypes.s_delivery_type_name_custom_05);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_05", updateDeliveryTypes.s_delivery_type_desc_custom_05);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_06", updateDeliveryTypes.s_delivery_type_name_custom_06);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_06", updateDeliveryTypes.s_delivery_type_desc_custom_06);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_07", updateDeliveryTypes.s_delivery_type_name_custom_07);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_07", updateDeliveryTypes.s_delivery_type_desc_custom_07);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_08", updateDeliveryTypes.s_delivery_type_name_custom_08);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_08", updateDeliveryTypes.s_delivery_type_desc_custom_08);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_09", updateDeliveryTypes.s_delivery_type_name_custom_09);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_09", updateDeliveryTypes.s_delivery_type_desc_custom_09);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_10", updateDeliveryTypes.s_delivery_type_name_custom_10);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_10", updateDeliveryTypes.s_delivery_type_desc_custom_10);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_11", updateDeliveryTypes.s_delivery_type_name_custom_11);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_11", updateDeliveryTypes.s_delivery_type_desc_custom_11);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_12", updateDeliveryTypes.s_delivery_type_name_custom_12);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_12", updateDeliveryTypes.s_delivery_type_desc_custom_12);
            htUpdateDeliveryTypes.Add("@s_delivery_type_name_custom_13", updateDeliveryTypes.s_delivery_type_name_custom_13);
            htUpdateDeliveryTypes.Add("@s_delivery_type_desc_custom_13", updateDeliveryTypes.s_delivery_type_desc_custom_13);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_delivery_types", htUpdateDeliveryTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchDeliveryTypes(SystemDeliveryType deliveryType)
        {
            Hashtable htDeliveryType = new Hashtable();
            htDeliveryType.Add("@s_delivery_type_id", deliveryType.s_delivery_type_id);
            htDeliveryType.Add("@s_delivery_type_name_us_english", deliveryType.s_delivery_type_name_us_english);


            if (deliveryType.s_delivery_type_status_id_fk == "0")
                htDeliveryType.Add("@s_delivery_type_status_id_fk", DBNull.Value);
            else
                htDeliveryType.Add("@s_delivery_type_status_id_fk", deliveryType.s_delivery_type_status_id_fk);

            if (deliveryType.s_delivery_type_mode_id_fk == "0")
                htDeliveryType.Add("@s_delivery_type_mode_id_fk", DBNull.Value);
            else
                htDeliveryType.Add("@s_delivery_type_mode_id_fk", deliveryType.s_delivery_type_mode_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_delivery_type_search", htDeliveryType);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UpdateDeliveryTypeStatus(string s_delivery_type_system_id_pk)
        {
            Hashtable htUpdateDeliveryStatus = new Hashtable();
            htUpdateDeliveryStatus.Add("@s_delivery_type_system_id_pk", s_delivery_type_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_delivery_type_status", htUpdateDeliveryStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
