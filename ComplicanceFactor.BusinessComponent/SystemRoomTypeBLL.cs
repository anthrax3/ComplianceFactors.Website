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
    public class SystemRoomTypeBLL
    {
        public static int CreateRoomType(SystemRoomType createRoomType)
        {
            Hashtable htCreateRoomType = new Hashtable();

            htCreateRoomType.Add("@s_room_type_system_id_pk", createRoomType.s_room_type_system_id_pk);
            htCreateRoomType.Add("@s_room_type_id", createRoomType.s_room_type_id);
            if (createRoomType.s_room_type_status_id_fk == "0")
                htCreateRoomType.Add("@s_room_type_status_id_fk", DBNull.Value);
            else
                htCreateRoomType.Add("@s_room_type_status_id_fk", createRoomType.s_room_type_status_id_fk);
            htCreateRoomType.Add("@s_room_type_name_us_english", createRoomType.s_room_type_name_us_english);
            htCreateRoomType.Add("@s_room_type_desc_us_english", createRoomType.s_room_type_desc_us_english);
            htCreateRoomType.Add("@s_room_type_name_uk_english", createRoomType.s_room_type_name_uk_english);
            htCreateRoomType.Add("@s_room_type_desc_uk_english", createRoomType.s_room_type_desc_uk_english);
            htCreateRoomType.Add("@s_room_type_name_ca_french", createRoomType.s_room_type_name_ca_french);
            htCreateRoomType.Add("@s_room_type_desc_ca_french", createRoomType.s_room_type_desc_ca_french);
            htCreateRoomType.Add("@s_room_type_name_fr_french", createRoomType.s_room_type_name_fr_french);
            htCreateRoomType.Add("@s_room_type_desc_fr_french", createRoomType.s_room_type_desc_fr_french);
            htCreateRoomType.Add("@s_room_type_name_mx_spanish", createRoomType.s_room_type_name_mx_spanish);
            htCreateRoomType.Add("@s_room_type_desc_mx_spanish", createRoomType.s_room_type_desc_mx_spanish);
            htCreateRoomType.Add("@s_room_type_name_sp_spanish", createRoomType.s_room_type_name_sp_spanish);
            htCreateRoomType.Add("@s_room_type_desc_sp_spanish", createRoomType.s_room_type_desc_sp_spanish);
            htCreateRoomType.Add("@s_room_type_name_portuguese", createRoomType.s_room_type_name_portuguese);
            htCreateRoomType.Add("@s_room_type_desc_portuguese", createRoomType.s_room_type_desc_portuguese);
            htCreateRoomType.Add("@s_room_type_name_simp_chinese", createRoomType.s_room_type_name_simp_chinese);
            htCreateRoomType.Add("@s_room_type_desc_simp_chinese", createRoomType.s_room_type_desc_simp_chinese);
            htCreateRoomType.Add("@s_room_type_name_german", createRoomType.s_room_type_name_german);
            htCreateRoomType.Add("@s_room_type_desc_german", createRoomType.s_room_type_desc_german);
            htCreateRoomType.Add("@s_room_type_name_japanese", createRoomType.s_room_type_name_japanese);
            htCreateRoomType.Add("@s_room_type_desc_japanese", createRoomType.s_room_type_desc_japanese);
            htCreateRoomType.Add("@s_room_type_name_russian", createRoomType.s_room_type_name_russian);
            htCreateRoomType.Add("@s_room_type_desc_russian", createRoomType.s_room_type_desc_russian);
            htCreateRoomType.Add("@s_room_type_name_danish", createRoomType.s_room_type_name_danish);
            htCreateRoomType.Add("@s_room_type_desc_danish", createRoomType.s_room_type_desc_danish);
            htCreateRoomType.Add("@s_room_type_name_polish", createRoomType.s_room_type_name_polish);
            htCreateRoomType.Add("@s_room_type_desc_polish", createRoomType.s_room_type_desc_polish);
            htCreateRoomType.Add("@s_room_type_name_swedish", createRoomType.s_room_type_name_swedish);
            htCreateRoomType.Add("@s_room_type_desc_swedish", createRoomType.s_room_type_desc_swedish);
            htCreateRoomType.Add("@s_room_type_name_finnish", createRoomType.s_room_type_name_finnish);
            htCreateRoomType.Add("@s_room_type_desc_finnish", createRoomType.s_room_type_desc_finnish);
            htCreateRoomType.Add("@s_room_type_name_korean", createRoomType.s_room_type_name_korean);
            htCreateRoomType.Add("@s_room_type_desc_korean", createRoomType.s_room_type_desc_korean);
            htCreateRoomType.Add("@s_room_type_name_italian", createRoomType.s_room_type_name_italian);
            htCreateRoomType.Add("@s_room_type_desc_italian", createRoomType.s_room_type_desc_italian);
            htCreateRoomType.Add("@s_room_type_name_dutch", createRoomType.s_room_type_name_dutch);
            htCreateRoomType.Add("@s_room_type_desc_dutch", createRoomType.s_room_type_desc_dutch);
            htCreateRoomType.Add("@s_room_type_name_indonesian", createRoomType.s_room_type_name_indonesian);
            htCreateRoomType.Add("@s_room_type_desc_indonesian", createRoomType.s_room_type_desc_indonesian);
            htCreateRoomType.Add("@s_room_type_name_greek", createRoomType.s_room_type_name_greek);
            htCreateRoomType.Add("@s_room_type_desc_greek", createRoomType.s_room_type_desc_greek);
            htCreateRoomType.Add("@s_room_type_name_hungarian", createRoomType.s_room_type_name_hungarian);
            htCreateRoomType.Add("@s_room_type_desc_hungarian", createRoomType.s_room_type_desc_hungarian);
            htCreateRoomType.Add("@s_room_type_name_norwegian", createRoomType.s_room_type_name_norwegian);
            htCreateRoomType.Add("@s_room_type_desc_norwegian", createRoomType.s_room_type_desc_norwegian);
            htCreateRoomType.Add("@s_room_type_name_turkish", createRoomType.s_room_type_name_turkish);
            htCreateRoomType.Add("@s_room_type_desc_turkish", createRoomType.s_room_type_desc_turkish);
            htCreateRoomType.Add("@s_room_type_name_arabic_rtl", createRoomType.s_room_type_name_arabic_rtl);
            htCreateRoomType.Add("@s_room_type_desc_arabic_rtl", createRoomType.s_room_type_desc_arabic_rtl);
            htCreateRoomType.Add("@s_room_type_name_custom_01", createRoomType.s_room_type_name_custom_01);
            htCreateRoomType.Add("@s_room_type_desc_custom_01", createRoomType.s_room_type_desc_custom_01);
            htCreateRoomType.Add("@s_room_type_name_custom_02", createRoomType.s_room_type_name_custom_02);
            htCreateRoomType.Add("@s_room_type_desc_custom_02", createRoomType.s_room_type_desc_custom_02);
            htCreateRoomType.Add("@s_room_type_name_custom_03", createRoomType.s_room_type_name_custom_03);
            htCreateRoomType.Add("@s_room_type_desc_custom_03", createRoomType.s_room_type_desc_custom_03);
            htCreateRoomType.Add("@s_room_type_name_custom_04", createRoomType.s_room_type_name_custom_04);
            htCreateRoomType.Add("@s_room_type_desc_custom_04", createRoomType.s_room_type_desc_custom_04);
            htCreateRoomType.Add("@s_room_type_name_custom_05", createRoomType.s_room_type_name_custom_05);
            htCreateRoomType.Add("@s_room_type_desc_custom_05", createRoomType.s_room_type_desc_custom_05);
            htCreateRoomType.Add("@s_room_type_name_custom_06", createRoomType.s_room_type_name_custom_06);
            htCreateRoomType.Add("@s_room_type_desc_custom_06", createRoomType.s_room_type_desc_custom_06);
            htCreateRoomType.Add("@s_room_type_name_custom_07", createRoomType.s_room_type_name_custom_07);
            htCreateRoomType.Add("@s_room_type_desc_custom_07", createRoomType.s_room_type_desc_custom_07);
            htCreateRoomType.Add("@s_room_type_name_custom_08", createRoomType.s_room_type_name_custom_08);
            htCreateRoomType.Add("@s_room_type_desc_custom_08", createRoomType.s_room_type_desc_custom_08);
            htCreateRoomType.Add("@s_room_type_name_custom_09", createRoomType.s_room_type_name_custom_09);
            htCreateRoomType.Add("@s_room_type_desc_custom_09", createRoomType.s_room_type_desc_custom_09);
            htCreateRoomType.Add("@s_room_type_name_custom_10", createRoomType.s_room_type_name_custom_10);
            htCreateRoomType.Add("@s_room_type_desc_custom_10", createRoomType.s_room_type_desc_custom_10);
            htCreateRoomType.Add("@s_room_type_name_custom_11", createRoomType.s_room_type_name_custom_11);
            htCreateRoomType.Add("@s_room_type_desc_custom_11", createRoomType.s_room_type_desc_custom_11);
            htCreateRoomType.Add("@s_room_type_name_custom_12", createRoomType.s_room_type_name_custom_12);
            htCreateRoomType.Add("@s_room_type_desc_custom_12", createRoomType.s_room_type_desc_custom_12);
            htCreateRoomType.Add("@s_room_type_name_custom_13", createRoomType.s_room_type_name_custom_13);
            htCreateRoomType.Add("@s_room_type_desc_custom_13", createRoomType.s_room_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_room_type", htCreateRoomType);
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


        public static DataTable GetRoomType(SystemRoomType room)
        {
            Hashtable htSearchRoom = new Hashtable();
            htSearchRoom.Add("@s_room_type_id", room.s_room_type_id);
            htSearchRoom.Add("@s_room_type_name_us_english", room.s_room_type_name_us_english);
            if (room.s_room_type_status_id_fk == "0")
                htSearchRoom.Add("@s_room_type_status_id_fk", DBNull.Value);
            else
                htSearchRoom.Add("@s_room_type_status_id_fk", room.s_room_type_status_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_room_type", htSearchRoom);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemRoomType GetRoomType(string s_room_type_system_id_pk)
        {
            SystemRoomType roomType;
            try
            {

                Hashtable htGetroomTypes = new Hashtable();
                htGetroomTypes.Add("@s_room_type_system_id_pk", s_room_type_system_id_pk);
                roomType = new SystemRoomType();
                DataTable dtGetroomType = DataProxy.FetchDataTable("s_sp_get_single_room_type", htGetroomTypes);
                roomType.s_room_type_id = dtGetroomType.Rows[0]["s_room_type_id"].ToString();
                roomType.s_room_type_status_id_fk = dtGetroomType.Rows[0]["s_room_type_status_id_fk"].ToString();

                roomType.s_room_type_name_us_english = dtGetroomType.Rows[0]["s_room_type_name_us_english"].ToString();
                roomType.s_room_type_desc_us_english = dtGetroomType.Rows[0]["s_room_type_desc_us_english"].ToString();
                roomType.s_room_type_name_uk_english = dtGetroomType.Rows[0]["s_room_type_name_uk_english"].ToString();
                roomType.s_room_type_desc_uk_english = dtGetroomType.Rows[0]["s_room_type_desc_uk_english"].ToString();
                roomType.s_room_type_name_ca_french = dtGetroomType.Rows[0]["s_room_type_name_ca_french"].ToString();
                roomType.s_room_type_desc_ca_french = dtGetroomType.Rows[0]["s_room_type_desc_ca_french"].ToString();
                roomType.s_room_type_name_fr_french = dtGetroomType.Rows[0]["s_room_type_name_fr_french"].ToString();
                roomType.s_room_type_desc_fr_french = dtGetroomType.Rows[0]["s_room_type_desc_fr_french"].ToString();
                roomType.s_room_type_name_mx_spanish = dtGetroomType.Rows[0]["s_room_type_name_mx_spanish"].ToString();
                roomType.s_room_type_desc_mx_spanish = dtGetroomType.Rows[0]["s_room_type_desc_mx_spanish"].ToString();
                roomType.s_room_type_name_sp_spanish = dtGetroomType.Rows[0]["s_room_type_name_sp_spanish"].ToString();
                roomType.s_room_type_desc_sp_spanish = dtGetroomType.Rows[0]["s_room_type_desc_sp_spanish"].ToString();
                roomType.s_room_type_name_portuguese = dtGetroomType.Rows[0]["s_room_type_name_portuguese"].ToString();
                roomType.s_room_type_desc_portuguese = dtGetroomType.Rows[0]["s_room_type_desc_portuguese"].ToString();
                roomType.s_room_type_name_simp_chinese = dtGetroomType.Rows[0]["s_room_type_name_simp_chinese"].ToString();
                roomType.s_room_type_desc_simp_chinese = dtGetroomType.Rows[0]["s_room_type_desc_simp_chinese"].ToString();
                roomType.s_room_type_name_german = dtGetroomType.Rows[0]["s_room_type_name_german"].ToString();
                roomType.s_room_type_desc_german = dtGetroomType.Rows[0]["s_room_type_desc_german"].ToString();
                roomType.s_room_type_name_japanese = dtGetroomType.Rows[0]["s_room_type_name_japanese"].ToString();
                roomType.s_room_type_desc_japanese = dtGetroomType.Rows[0]["s_room_type_desc_japanese"].ToString();
                roomType.s_room_type_name_russian = dtGetroomType.Rows[0]["s_room_type_name_russian"].ToString();
                roomType.s_room_type_desc_russian = dtGetroomType.Rows[0]["s_room_type_desc_russian"].ToString();
                roomType.s_room_type_name_danish = dtGetroomType.Rows[0]["s_room_type_name_danish"].ToString();
                roomType.s_room_type_desc_danish = dtGetroomType.Rows[0]["s_room_type_desc_danish"].ToString();
                roomType.s_room_type_name_polish = dtGetroomType.Rows[0]["s_room_type_name_polish"].ToString();
                roomType.s_room_type_desc_polish = dtGetroomType.Rows[0]["s_room_type_desc_polish"].ToString();
                roomType.s_room_type_name_swedish = dtGetroomType.Rows[0]["s_room_type_name_swedish"].ToString();
                roomType.s_room_type_desc_swedish = dtGetroomType.Rows[0]["s_room_type_desc_swedish"].ToString();
                roomType.s_room_type_name_finnish = dtGetroomType.Rows[0]["s_room_type_name_finnish"].ToString();
                roomType.s_room_type_desc_finnish = dtGetroomType.Rows[0]["s_room_type_desc_finnish"].ToString();
                roomType.s_room_type_name_korean = dtGetroomType.Rows[0]["s_room_type_name_korean"].ToString();
                roomType.s_room_type_desc_korean = dtGetroomType.Rows[0]["s_room_type_desc_korean"].ToString();
                roomType.s_room_type_name_italian = dtGetroomType.Rows[0]["s_room_type_name_italian"].ToString();
                roomType.s_room_type_desc_italian = dtGetroomType.Rows[0]["s_room_type_desc_italian"].ToString();
                roomType.s_room_type_name_dutch = dtGetroomType.Rows[0]["s_room_type_name_dutch"].ToString();
                roomType.s_room_type_desc_dutch = dtGetroomType.Rows[0]["s_room_type_desc_dutch"].ToString();
                roomType.s_room_type_name_indonesian = dtGetroomType.Rows[0]["s_room_type_name_indonesian"].ToString();
                roomType.s_room_type_desc_indonesian = dtGetroomType.Rows[0]["s_room_type_desc_indonesian"].ToString();
                roomType.s_room_type_name_greek = dtGetroomType.Rows[0]["s_room_type_name_greek"].ToString();
                roomType.s_room_type_desc_greek = dtGetroomType.Rows[0]["s_room_type_desc_greek"].ToString();
                roomType.s_room_type_name_hungarian = dtGetroomType.Rows[0]["s_room_type_name_hungarian"].ToString();
                roomType.s_room_type_desc_hungarian = dtGetroomType.Rows[0]["s_room_type_desc_hungarian"].ToString();
                roomType.s_room_type_name_norwegian = dtGetroomType.Rows[0]["s_room_type_name_norwegian"].ToString();
                roomType.s_room_type_desc_norwegian = dtGetroomType.Rows[0]["s_room_type_desc_norwegian"].ToString();
                roomType.s_room_type_name_turkish = dtGetroomType.Rows[0]["s_room_type_name_turkish"].ToString();
                roomType.s_room_type_desc_turkish = dtGetroomType.Rows[0]["s_room_type_desc_turkish"].ToString();
                roomType.s_room_type_name_arabic_rtl = dtGetroomType.Rows[0]["s_room_type_name_arabic_rtl"].ToString();
                roomType.s_room_type_desc_arabic_rtl = dtGetroomType.Rows[0]["s_room_type_desc_arabic_rtl"].ToString();
                roomType.s_room_type_name_custom_01 = dtGetroomType.Rows[0]["s_room_type_name_custom_01"].ToString();
                roomType.s_room_type_desc_custom_01 = dtGetroomType.Rows[0]["s_room_type_desc_custom_01"].ToString();
                roomType.s_room_type_name_custom_02 = dtGetroomType.Rows[0]["s_room_type_name_custom_02"].ToString();
                roomType.s_room_type_desc_custom_02 = dtGetroomType.Rows[0]["s_room_type_desc_custom_02"].ToString();
                roomType.s_room_type_name_custom_03 = dtGetroomType.Rows[0]["s_room_type_name_custom_03"].ToString();
                roomType.s_room_type_desc_custom_03 = dtGetroomType.Rows[0]["s_room_type_desc_custom_03"].ToString();
                roomType.s_room_type_name_custom_04 = dtGetroomType.Rows[0]["s_room_type_name_custom_04"].ToString();
                roomType.s_room_type_desc_custom_04 = dtGetroomType.Rows[0]["s_room_type_desc_custom_04"].ToString();
                roomType.s_room_type_name_custom_05 = dtGetroomType.Rows[0]["s_room_type_name_custom_05"].ToString();
                roomType.s_room_type_desc_custom_05 = dtGetroomType.Rows[0]["s_room_type_desc_custom_05"].ToString();
                roomType.s_room_type_name_custom_06 = dtGetroomType.Rows[0]["s_room_type_name_custom_06"].ToString();
                roomType.s_room_type_desc_custom_06 = dtGetroomType.Rows[0]["s_room_type_desc_custom_06"].ToString();
                roomType.s_room_type_name_custom_07 = dtGetroomType.Rows[0]["s_room_type_name_custom_07"].ToString();
                roomType.s_room_type_desc_custom_07 = dtGetroomType.Rows[0]["s_room_type_desc_custom_07"].ToString();
                roomType.s_room_type_name_custom_08 = dtGetroomType.Rows[0]["s_room_type_name_custom_08"].ToString();
                roomType.s_room_type_desc_custom_08 = dtGetroomType.Rows[0]["s_room_type_desc_custom_08"].ToString();
                roomType.s_room_type_name_custom_09 = dtGetroomType.Rows[0]["s_room_type_name_custom_09"].ToString();
                roomType.s_room_type_desc_custom_09 = dtGetroomType.Rows[0]["s_room_type_desc_custom_09"].ToString();
                roomType.s_room_type_name_custom_10 = dtGetroomType.Rows[0]["s_room_type_name_custom_10"].ToString();
                roomType.s_room_type_desc_custom_10 = dtGetroomType.Rows[0]["s_room_type_desc_custom_10"].ToString();
                roomType.s_room_type_name_custom_11 = dtGetroomType.Rows[0]["s_room_type_name_custom_11"].ToString();
                roomType.s_room_type_desc_custom_11 = dtGetroomType.Rows[0]["s_room_type_desc_custom_11"].ToString();
                roomType.s_room_type_name_custom_12 = dtGetroomType.Rows[0]["s_room_type_name_custom_12"].ToString();
                roomType.s_room_type_desc_custom_12 = dtGetroomType.Rows[0]["s_room_type_desc_custom_12"].ToString();
                roomType.s_room_type_name_custom_13 = dtGetroomType.Rows[0]["s_room_type_name_custom_13"].ToString();
                roomType.s_room_type_desc_custom_13 = dtGetroomType.Rows[0]["s_room_type_desc_custom_13"].ToString();

                return roomType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateRoomType(SystemRoomType updateRoomType)
        {
            Hashtable htUpdateRoomType = new Hashtable();
            htUpdateRoomType.Add("@s_room_type_system_id_pk", updateRoomType.s_room_type_system_id_pk);
            htUpdateRoomType.Add("@s_room_type_id", updateRoomType.s_room_type_id);
            htUpdateRoomType.Add("@s_room_type_status_id_fk", updateRoomType.s_room_type_status_id_fk);
            htUpdateRoomType.Add("@s_room_type_name_us_english", updateRoomType.s_room_type_name_us_english);
            htUpdateRoomType.Add("@s_room_type_desc_us_english", updateRoomType.s_room_type_desc_us_english);
            htUpdateRoomType.Add("@s_room_type_name_uk_english", updateRoomType.s_room_type_name_uk_english);
            htUpdateRoomType.Add("@s_room_type_desc_uk_english", updateRoomType.s_room_type_desc_uk_english);
            htUpdateRoomType.Add("@s_room_type_name_ca_french", updateRoomType.s_room_type_name_ca_french);
            htUpdateRoomType.Add("@s_room_type_desc_ca_french", updateRoomType.s_room_type_desc_ca_french);
            htUpdateRoomType.Add("@s_room_type_name_fr_french", updateRoomType.s_room_type_name_fr_french);
            htUpdateRoomType.Add("@s_room_type_desc_fr_french", updateRoomType.s_room_type_desc_fr_french);
            htUpdateRoomType.Add("@s_room_type_name_mx_spanish", updateRoomType.s_room_type_name_mx_spanish);
            htUpdateRoomType.Add("@s_room_type_desc_mx_spanish", updateRoomType.s_room_type_desc_mx_spanish);
            htUpdateRoomType.Add("@s_room_type_name_sp_spanish", updateRoomType.s_room_type_name_sp_spanish);
            htUpdateRoomType.Add("@s_room_type_desc_sp_spanish", updateRoomType.s_room_type_desc_sp_spanish);
            htUpdateRoomType.Add("@s_room_type_name_portuguese", updateRoomType.s_room_type_name_portuguese);
            htUpdateRoomType.Add("@s_room_type_desc_portuguese", updateRoomType.s_room_type_desc_portuguese);
            htUpdateRoomType.Add("@s_room_type_name_simp_chinese", updateRoomType.s_room_type_name_simp_chinese);
            htUpdateRoomType.Add("@s_room_type_desc_simp_chinese", updateRoomType.s_room_type_desc_simp_chinese);
            htUpdateRoomType.Add("@s_room_type_name_german", updateRoomType.s_room_type_name_german);
            htUpdateRoomType.Add("@s_room_type_desc_german", updateRoomType.s_room_type_desc_german);
            htUpdateRoomType.Add("@s_room_type_name_japanese", updateRoomType.s_room_type_name_japanese);
            htUpdateRoomType.Add("@s_room_type_desc_japanese", updateRoomType.s_room_type_desc_japanese);
            htUpdateRoomType.Add("@s_room_type_name_russian", updateRoomType.s_room_type_name_russian);
            htUpdateRoomType.Add("@s_room_type_desc_russian", updateRoomType.s_room_type_desc_russian);
            htUpdateRoomType.Add("@s_room_type_name_danish", updateRoomType.s_room_type_name_danish);
            htUpdateRoomType.Add("@s_room_type_desc_danish", updateRoomType.s_room_type_desc_danish);
            htUpdateRoomType.Add("@s_room_type_name_polish", updateRoomType.s_room_type_name_polish);
            htUpdateRoomType.Add("@s_room_type_desc_polish", updateRoomType.s_room_type_desc_polish);
            htUpdateRoomType.Add("@s_room_type_name_swedish", updateRoomType.s_room_type_name_swedish);
            htUpdateRoomType.Add("@s_room_type_desc_swedish", updateRoomType.s_room_type_desc_swedish);
            htUpdateRoomType.Add("@s_room_type_name_finnish", updateRoomType.s_room_type_name_finnish);
            htUpdateRoomType.Add("@s_room_type_desc_finnish", updateRoomType.s_room_type_desc_finnish);
            htUpdateRoomType.Add("@s_room_type_name_korean", updateRoomType.s_room_type_name_korean);
            htUpdateRoomType.Add("@s_room_type_desc_korean", updateRoomType.s_room_type_desc_korean);
            htUpdateRoomType.Add("@s_room_type_name_italian", updateRoomType.s_room_type_name_italian);
            htUpdateRoomType.Add("@s_room_type_desc_italian", updateRoomType.s_room_type_desc_italian);
            htUpdateRoomType.Add("@s_room_type_name_dutch", updateRoomType.s_room_type_name_dutch);
            htUpdateRoomType.Add("@s_room_type_desc_dutch", updateRoomType.s_room_type_desc_dutch);
            htUpdateRoomType.Add("@s_room_type_name_indonesian", updateRoomType.s_room_type_name_indonesian);
            htUpdateRoomType.Add("@s_room_type_desc_indonesian", updateRoomType.s_room_type_desc_indonesian);
            htUpdateRoomType.Add("@s_room_type_name_greek", updateRoomType.s_room_type_name_greek);
            htUpdateRoomType.Add("@s_room_type_desc_greek", updateRoomType.s_room_type_desc_greek);
            htUpdateRoomType.Add("@s_room_type_name_hungarian", updateRoomType.s_room_type_name_hungarian);
            htUpdateRoomType.Add("@s_room_type_desc_hungarian", updateRoomType.s_room_type_desc_hungarian);
            htUpdateRoomType.Add("@s_room_type_name_norwegian", updateRoomType.s_room_type_name_norwegian);
            htUpdateRoomType.Add("@s_room_type_desc_norwegian", updateRoomType.s_room_type_desc_norwegian);
            htUpdateRoomType.Add("@s_room_type_name_turkish", updateRoomType.s_room_type_name_turkish);
            htUpdateRoomType.Add("@s_room_type_desc_turkish", updateRoomType.s_room_type_desc_turkish);
            htUpdateRoomType.Add("@s_room_type_name_arabic_rtl", updateRoomType.s_room_type_name_arabic_rtl);
            htUpdateRoomType.Add("@s_room_type_desc_arabic_rtl", updateRoomType.s_room_type_desc_arabic_rtl);
            htUpdateRoomType.Add("@s_room_type_name_custom_01", updateRoomType.s_room_type_name_custom_01);
            htUpdateRoomType.Add("@s_room_type_desc_custom_01", updateRoomType.s_room_type_desc_custom_01);
            htUpdateRoomType.Add("@s_room_type_name_custom_02", updateRoomType.s_room_type_name_custom_02);
            htUpdateRoomType.Add("@s_room_type_desc_custom_02", updateRoomType.s_room_type_desc_custom_02);
            htUpdateRoomType.Add("@s_room_type_name_custom_03", updateRoomType.s_room_type_name_custom_03);
            htUpdateRoomType.Add("@s_room_type_desc_custom_03", updateRoomType.s_room_type_desc_custom_03);
            htUpdateRoomType.Add("@s_room_type_name_custom_04", updateRoomType.s_room_type_name_custom_04);
            htUpdateRoomType.Add("@s_room_type_desc_custom_04", updateRoomType.s_room_type_desc_custom_04);
            htUpdateRoomType.Add("@s_room_type_name_custom_05", updateRoomType.s_room_type_name_custom_05);
            htUpdateRoomType.Add("@s_room_type_desc_custom_05", updateRoomType.s_room_type_desc_custom_05);
            htUpdateRoomType.Add("@s_room_type_name_custom_06", updateRoomType.s_room_type_name_custom_06);
            htUpdateRoomType.Add("@s_room_type_desc_custom_06", updateRoomType.s_room_type_desc_custom_06);
            htUpdateRoomType.Add("@s_room_type_name_custom_07", updateRoomType.s_room_type_name_custom_07);
            htUpdateRoomType.Add("@s_room_type_desc_custom_07", updateRoomType.s_room_type_desc_custom_07);
            htUpdateRoomType.Add("@s_room_type_name_custom_08", updateRoomType.s_room_type_name_custom_08);
            htUpdateRoomType.Add("@s_room_type_desc_custom_08", updateRoomType.s_room_type_desc_custom_08);
            htUpdateRoomType.Add("@s_room_type_name_custom_09", updateRoomType.s_room_type_name_custom_09);
            htUpdateRoomType.Add("@s_room_type_desc_custom_09", updateRoomType.s_room_type_desc_custom_09);
            htUpdateRoomType.Add("@s_room_type_name_custom_10", updateRoomType.s_room_type_name_custom_10);
            htUpdateRoomType.Add("@s_room_type_desc_custom_10", updateRoomType.s_room_type_desc_custom_10);
            htUpdateRoomType.Add("@s_room_type_name_custom_11", updateRoomType.s_room_type_name_custom_11);
            htUpdateRoomType.Add("@s_room_type_desc_custom_11", updateRoomType.s_room_type_desc_custom_11);
            htUpdateRoomType.Add("@s_room_type_name_custom_12", updateRoomType.s_room_type_name_custom_12);
            htUpdateRoomType.Add("@s_room_type_desc_custom_12", updateRoomType.s_room_type_desc_custom_12);
            htUpdateRoomType.Add("@s_room_type_name_custom_13", updateRoomType.s_room_type_name_custom_13);
            htUpdateRoomType.Add("@s_room_type_desc_custom_13", updateRoomType.s_room_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_room_type", htUpdateRoomType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateRoomStatus(string s_room_type_system_id_pk)
        {
            Hashtable htUpdateRoomStatus = new Hashtable();
            htUpdateRoomStatus.Add("@s_room_type_system_id_pk", s_room_type_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_room_type_status", htUpdateRoomStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
