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
    public class SystemInstructorTypeBLL
    {
         public static int CreateInstructorType(SystemInstructorType instructor)
        {
            Hashtable htcreateInstructorTypes = new Hashtable();
            htcreateInstructorTypes.Add("@s_instructor_type_system_id_pk", instructor.s_instructor_type_system_id_pk);
            htcreateInstructorTypes.Add("@s_instructor_type_id", instructor.s_instructor_type_id);
            if (instructor.s_instructor_type_status_id_fk == "0")
                htcreateInstructorTypes.Add("@s_instructor_type_status_id_fk", DBNull.Value);
            else
                htcreateInstructorTypes.Add("@s_instructor_type_status_id_fk", instructor.s_instructor_type_status_id_fk);
            htcreateInstructorTypes.Add("@s_instructor_type_name_us_english", instructor.s_instructor_type_name_us_english);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_us_english", instructor.s_instructor_type_desc_us_english);
            htcreateInstructorTypes.Add("@s_instructor_type_name_uk_english", instructor.s_instructor_type_name_uk_english);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_uk_english", instructor.s_instructor_type_desc_uk_english);
            htcreateInstructorTypes.Add("@s_instructor_type_name_ca_french", instructor.s_instructor_type_name_ca_french);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_ca_french", instructor.s_instructor_type_desc_ca_french);
            htcreateInstructorTypes.Add("@s_instructor_type_name_fr_french", instructor.s_instructor_type_name_fr_french);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_fr_french", instructor.s_instructor_type_desc_fr_french);
            htcreateInstructorTypes.Add("@s_instructor_type_name_mx_spanish", instructor.s_instructor_type_name_mx_spanish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_mx_spanish", instructor.s_instructor_type_desc_mx_spanish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_sp_spanish", instructor.s_instructor_type_name_sp_spanish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_sp_spanish", instructor.s_instructor_type_desc_sp_spanish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_portuguese", instructor.s_instructor_type_name_portuguese);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_portuguese", instructor.s_instructor_type_desc_portuguese);
            htcreateInstructorTypes.Add("@s_instructor_type_name_simp_chinese", instructor.s_instructor_type_name_simp_chinese);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_simp_chinese", instructor.s_instructor_type_desc_simp_chinese);
            htcreateInstructorTypes.Add("@s_instructor_type_name_german", instructor.s_instructor_type_name_german);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_german", instructor.s_instructor_type_desc_german);
            htcreateInstructorTypes.Add("@s_instructor_type_name_japanese", instructor.s_instructor_type_name_japanese);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_japanese", instructor.s_instructor_type_desc_japanese);
            htcreateInstructorTypes.Add("@s_instructor_type_name_russian", instructor.s_instructor_type_name_russian);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_russian", instructor.s_instructor_type_desc_russian);
            htcreateInstructorTypes.Add("@s_instructor_type_name_danish", instructor.s_instructor_type_name_danish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_danish", instructor.s_instructor_type_desc_danish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_polish", instructor.s_instructor_type_name_polish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_polish", instructor.s_instructor_type_desc_polish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_swedish", instructor.s_instructor_type_name_swedish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_swedish", instructor.s_instructor_type_desc_swedish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_finnish", instructor.s_instructor_type_name_finnish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_finnish", instructor.s_instructor_type_desc_finnish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_korean", instructor.s_instructor_type_name_korean);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_korean", instructor.s_instructor_type_desc_korean);
            htcreateInstructorTypes.Add("@s_instructor_type_name_italian", instructor.s_instructor_type_name_italian);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_italian", instructor.s_instructor_type_desc_italian);
            htcreateInstructorTypes.Add("@s_instructor_type_name_dutch", instructor.s_instructor_type_name_dutch);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_dutch", instructor.s_instructor_type_desc_dutch);
            htcreateInstructorTypes.Add("@s_instructor_type_name_indonesian", instructor.s_instructor_type_name_indonesian);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_indonesian", instructor.s_instructor_type_desc_indonesian);
            htcreateInstructorTypes.Add("@s_instructor_type_name_greek", instructor.s_instructor_type_name_greek);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_greek", instructor.s_instructor_type_desc_greek);
            htcreateInstructorTypes.Add("@s_instructor_type_name_hungarian", instructor.s_instructor_type_name_hungarian);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_hungarian", instructor.s_instructor_type_desc_hungarian);
            htcreateInstructorTypes.Add("@s_instructor_type_name_norwegian", instructor.s_instructor_type_name_norwegian);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_norwegian", instructor.s_instructor_type_desc_norwegian);
            htcreateInstructorTypes.Add("@s_instructor_type_name_turkish", instructor.s_instructor_type_name_turkish);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_turkish", instructor.s_instructor_type_desc_turkish);
            htcreateInstructorTypes.Add("@s_instructor_type_name_arabic_rtl", instructor.s_instructor_type_name_arabic_rtl);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_arabic_rtl", instructor.s_instructor_type_desc_arabic_rtl);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_01", instructor.s_instructor_type_name_custom_01);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_01", instructor.s_instructor_type_desc_custom_01);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_02", instructor.s_instructor_type_name_custom_02);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_02", instructor.s_instructor_type_desc_custom_02);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_03", instructor.s_instructor_type_name_custom_03);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_03", instructor.s_instructor_type_desc_custom_03);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_04", instructor.s_instructor_type_name_custom_04);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_04", instructor.s_instructor_type_desc_custom_04);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_05", instructor.s_instructor_type_name_custom_05);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_05", instructor.s_instructor_type_desc_custom_05);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_06", instructor.s_instructor_type_name_custom_06);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_06", instructor.s_instructor_type_desc_custom_06);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_07", instructor.s_instructor_type_name_custom_07);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_07", instructor.s_instructor_type_desc_custom_07);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_08", instructor.s_instructor_type_name_custom_08);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_08", instructor.s_instructor_type_desc_custom_08);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_09", instructor.s_instructor_type_name_custom_09);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_09", instructor.s_instructor_type_desc_custom_09);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_10", instructor.s_instructor_type_name_custom_10);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_10", instructor.s_instructor_type_desc_custom_10);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_11", instructor.s_instructor_type_name_custom_11);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_11", instructor.s_instructor_type_desc_custom_11);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_12", instructor.s_instructor_type_name_custom_12);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_12", instructor.s_instructor_type_desc_custom_12);
            htcreateInstructorTypes.Add("@s_instructor_type_name_custom_13", instructor.s_instructor_type_name_custom_13);
            htcreateInstructorTypes.Add("@s_instructor_type_desc_custom_13", instructor.s_instructor_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_instructor_type", htcreateInstructorTypes);
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

         public static DataTable GetInstructorType(SystemInstructorType instructorType)
        {
            Hashtable htSearchInstructor = new Hashtable();
            htSearchInstructor.Add("@s_instructor_type_id", instructorType.s_instructor_type_id);
            htSearchInstructor.Add("@s_instructor_type_name_us_english", instructorType.s_instructor_type_name_us_english);


            if (instructorType.s_instructor_type_status_id_fk == "0")
                htSearchInstructor.Add("@s_instructor_type_status_id_fk", DBNull.Value);
            else
                htSearchInstructor.Add("@s_instructor_type_status_id_fk", instructorType.s_instructor_type_status_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_instructor_type", htSearchInstructor);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemInstructorType GetInstructorTypesbyId(string s_instructor_type_system_id_pk)
        {
            SystemInstructorType instructorType = new SystemInstructorType();
            try
            {

                Hashtable htGetInstructor = new Hashtable();
                htGetInstructor.Add("@s_instructor_type_system_id_pk", s_instructor_type_system_id_pk);
                DataTable dtGetInstructorType = DataProxy.FetchDataSet("s_sp_get_single_instructor_type", htGetInstructor).Tables[0];

                instructorType.s_instructor_type_id = dtGetInstructorType.Rows[0]["s_instructor_type_id"].ToString();
                instructorType.s_instructor_type_status_id_fk = dtGetInstructorType.Rows[0]["s_instructor_type_status_id_fk"].ToString();

                instructorType.s_instructor_type_name_us_english = dtGetInstructorType.Rows[0]["s_instructor_type_name_us_english"].ToString();
                instructorType.s_instructor_type_desc_us_english = dtGetInstructorType.Rows[0]["s_instructor_type_desc_us_english"].ToString();
                instructorType.s_instructor_type_name_uk_english = dtGetInstructorType.Rows[0]["s_instructor_type_name_uk_english"].ToString();
                instructorType.s_instructor_type_desc_uk_english = dtGetInstructorType.Rows[0]["s_instructor_type_desc_uk_english"].ToString();
                instructorType.s_instructor_type_name_ca_french = dtGetInstructorType.Rows[0]["s_instructor_type_name_ca_french"].ToString();
                instructorType.s_instructor_type_desc_ca_french = dtGetInstructorType.Rows[0]["s_instructor_type_desc_ca_french"].ToString();
                instructorType.s_instructor_type_name_fr_french = dtGetInstructorType.Rows[0]["s_instructor_type_name_fr_french"].ToString();
                instructorType.s_instructor_type_desc_fr_french = dtGetInstructorType.Rows[0]["s_instructor_type_desc_fr_french"].ToString();
                instructorType.s_instructor_type_name_mx_spanish = dtGetInstructorType.Rows[0]["s_instructor_type_name_mx_spanish"].ToString();
                instructorType.s_instructor_type_desc_mx_spanish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_mx_spanish"].ToString();
                instructorType.s_instructor_type_name_sp_spanish = dtGetInstructorType.Rows[0]["s_instructor_type_name_sp_spanish"].ToString();
                instructorType.s_instructor_type_desc_sp_spanish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_sp_spanish"].ToString();
                instructorType.s_instructor_type_name_portuguese = dtGetInstructorType.Rows[0]["s_instructor_type_name_portuguese"].ToString();
                instructorType.s_instructor_type_desc_portuguese = dtGetInstructorType.Rows[0]["s_instructor_type_desc_portuguese"].ToString();
                instructorType.s_instructor_type_name_simp_chinese = dtGetInstructorType.Rows[0]["s_instructor_type_name_simp_chinese"].ToString();
                instructorType.s_instructor_type_desc_simp_chinese = dtGetInstructorType.Rows[0]["s_instructor_type_desc_simp_chinese"].ToString();
                instructorType.s_instructor_type_name_german = dtGetInstructorType.Rows[0]["s_instructor_type_name_german"].ToString();
                instructorType.s_instructor_type_desc_german = dtGetInstructorType.Rows[0]["s_instructor_type_desc_german"].ToString();
                instructorType.s_instructor_type_name_japanese = dtGetInstructorType.Rows[0]["s_instructor_type_name_japanese"].ToString();
                instructorType.s_instructor_type_desc_japanese = dtGetInstructorType.Rows[0]["s_instructor_type_desc_japanese"].ToString();
                instructorType.s_instructor_type_name_russian = dtGetInstructorType.Rows[0]["s_instructor_type_name_russian"].ToString();
                instructorType.s_instructor_type_desc_russian = dtGetInstructorType.Rows[0]["s_instructor_type_desc_russian"].ToString();
                instructorType.s_instructor_type_name_danish = dtGetInstructorType.Rows[0]["s_instructor_type_name_danish"].ToString();
                instructorType.s_instructor_type_desc_danish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_danish"].ToString();
                instructorType.s_instructor_type_name_polish = dtGetInstructorType.Rows[0]["s_instructor_type_name_polish"].ToString();
                instructorType.s_instructor_type_desc_polish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_polish"].ToString();
                instructorType.s_instructor_type_name_swedish = dtGetInstructorType.Rows[0]["s_instructor_type_name_swedish"].ToString();
                instructorType.s_instructor_type_desc_swedish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_swedish"].ToString();
                instructorType.s_instructor_type_name_finnish = dtGetInstructorType.Rows[0]["s_instructor_type_name_finnish"].ToString();
                instructorType.s_instructor_type_desc_finnish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_finnish"].ToString();
                instructorType.s_instructor_type_name_korean = dtGetInstructorType.Rows[0]["s_instructor_type_name_korean"].ToString();
                instructorType.s_instructor_type_desc_korean = dtGetInstructorType.Rows[0]["s_instructor_type_desc_korean"].ToString();
                instructorType.s_instructor_type_name_italian = dtGetInstructorType.Rows[0]["s_instructor_type_name_italian"].ToString();
                instructorType.s_instructor_type_desc_italian = dtGetInstructorType.Rows[0]["s_instructor_type_desc_italian"].ToString();
                instructorType.s_instructor_type_name_dutch = dtGetInstructorType.Rows[0]["s_instructor_type_name_dutch"].ToString();
                instructorType.s_instructor_type_desc_dutch = dtGetInstructorType.Rows[0]["s_instructor_type_desc_dutch"].ToString();
                instructorType.s_instructor_type_name_indonesian = dtGetInstructorType.Rows[0]["s_instructor_type_name_indonesian"].ToString();
                instructorType.s_instructor_type_desc_indonesian = dtGetInstructorType.Rows[0]["s_instructor_type_desc_indonesian"].ToString();
                instructorType.s_instructor_type_name_greek = dtGetInstructorType.Rows[0]["s_instructor_type_name_greek"].ToString();
                instructorType.s_instructor_type_desc_greek = dtGetInstructorType.Rows[0]["s_instructor_type_desc_greek"].ToString();
                instructorType.s_instructor_type_name_hungarian = dtGetInstructorType.Rows[0]["s_instructor_type_name_hungarian"].ToString();
                instructorType.s_instructor_type_desc_hungarian = dtGetInstructorType.Rows[0]["s_instructor_type_desc_hungarian"].ToString();
                instructorType.s_instructor_type_name_norwegian = dtGetInstructorType.Rows[0]["s_instructor_type_name_norwegian"].ToString();
                instructorType.s_instructor_type_desc_norwegian = dtGetInstructorType.Rows[0]["s_instructor_type_desc_norwegian"].ToString();
                instructorType.s_instructor_type_name_turkish = dtGetInstructorType.Rows[0]["s_instructor_type_name_turkish"].ToString();
                instructorType.s_instructor_type_desc_turkish = dtGetInstructorType.Rows[0]["s_instructor_type_desc_turkish"].ToString();
                instructorType.s_instructor_type_name_arabic_rtl = dtGetInstructorType.Rows[0]["s_instructor_type_name_arabic_rtl"].ToString();
                instructorType.s_instructor_type_desc_arabic_rtl = dtGetInstructorType.Rows[0]["s_instructor_type_desc_arabic_rtl"].ToString();
                instructorType.s_instructor_type_name_custom_01 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_01"].ToString();
                instructorType.s_instructor_type_desc_custom_01 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_01"].ToString();
                instructorType.s_instructor_type_name_custom_02 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_02"].ToString();
                instructorType.s_instructor_type_desc_custom_02 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_02"].ToString();
                instructorType.s_instructor_type_name_custom_03 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_03"].ToString();
                instructorType.s_instructor_type_desc_custom_03 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_03"].ToString();
                instructorType.s_instructor_type_name_custom_04 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_04"].ToString();
                instructorType.s_instructor_type_desc_custom_04 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_04"].ToString();
                instructorType.s_instructor_type_name_custom_05 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_05"].ToString();
                instructorType.s_instructor_type_desc_custom_05 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_05"].ToString();
                instructorType.s_instructor_type_name_custom_06 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_06"].ToString();
                instructorType.s_instructor_type_desc_custom_06 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_06"].ToString();
                instructorType.s_instructor_type_name_custom_07 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_07"].ToString();
                instructorType.s_instructor_type_desc_custom_07 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_07"].ToString();
                instructorType.s_instructor_type_name_custom_08 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_08"].ToString();
                instructorType.s_instructor_type_desc_custom_08 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_08"].ToString();
                instructorType.s_instructor_type_name_custom_09 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_09"].ToString();
                instructorType.s_instructor_type_desc_custom_09 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_09"].ToString();
                instructorType.s_instructor_type_name_custom_10 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_10"].ToString();
                instructorType.s_instructor_type_desc_custom_10 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_10"].ToString();
                instructorType.s_instructor_type_name_custom_11 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_11"].ToString();
                instructorType.s_instructor_type_desc_custom_11 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_11"].ToString();
                instructorType.s_instructor_type_name_custom_12 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_12"].ToString();
                instructorType.s_instructor_type_desc_custom_12 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_12"].ToString();
                instructorType.s_instructor_type_name_custom_13 = dtGetInstructorType.Rows[0]["s_instructor_type_name_custom_13"].ToString();
                instructorType.s_instructor_type_desc_custom_13 = dtGetInstructorType.Rows[0]["s_instructor_type_desc_custom_13"].ToString();
                return instructorType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInstructorType(SystemInstructorType updateInstructorTypes)
        {
            Hashtable htUpdateInstructorTypes = new Hashtable();
            htUpdateInstructorTypes.Add("@s_instructor_type_system_id_pk", updateInstructorTypes.s_instructor_type_system_id_pk);
            htUpdateInstructorTypes.Add("@s_instructor_type_id", updateInstructorTypes.s_instructor_type_id);
            htUpdateInstructorTypes.Add("@s_instructor_type_status_id_fk", updateInstructorTypes.s_instructor_type_status_id_fk);

            htUpdateInstructorTypes.Add("@s_instructor_type_name_us_english", updateInstructorTypes.s_instructor_type_name_us_english);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_us_english", updateInstructorTypes.s_instructor_type_desc_us_english);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_uk_english", updateInstructorTypes.s_instructor_type_name_uk_english);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_uk_english", updateInstructorTypes.s_instructor_type_desc_uk_english);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_ca_french", updateInstructorTypes.s_instructor_type_name_ca_french);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_ca_french", updateInstructorTypes.s_instructor_type_desc_ca_french);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_fr_french", updateInstructorTypes.s_instructor_type_name_fr_french);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_fr_french", updateInstructorTypes.s_instructor_type_desc_fr_french);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_mx_spanish", updateInstructorTypes.s_instructor_type_name_mx_spanish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_mx_spanish", updateInstructorTypes.s_instructor_type_desc_mx_spanish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_sp_spanish", updateInstructorTypes.s_instructor_type_name_sp_spanish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_sp_spanish", updateInstructorTypes.s_instructor_type_desc_sp_spanish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_portuguese", updateInstructorTypes.s_instructor_type_name_portuguese);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_portuguese", updateInstructorTypes.s_instructor_type_desc_portuguese);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_simp_chinese", updateInstructorTypes.s_instructor_type_name_simp_chinese);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_simp_chinese", updateInstructorTypes.s_instructor_type_desc_simp_chinese);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_german", updateInstructorTypes.s_instructor_type_name_german);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_german", updateInstructorTypes.s_instructor_type_desc_german);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_japanese", updateInstructorTypes.s_instructor_type_name_japanese);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_japanese", updateInstructorTypes.s_instructor_type_desc_japanese);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_russian", updateInstructorTypes.s_instructor_type_name_russian);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_russian", updateInstructorTypes.s_instructor_type_desc_russian);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_danish", updateInstructorTypes.s_instructor_type_name_danish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_danish", updateInstructorTypes.s_instructor_type_desc_danish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_polish", updateInstructorTypes.s_instructor_type_name_polish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_polish", updateInstructorTypes.s_instructor_type_desc_polish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_swedish", updateInstructorTypes.s_instructor_type_name_swedish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_swedish", updateInstructorTypes.s_instructor_type_desc_swedish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_finnish", updateInstructorTypes.s_instructor_type_name_finnish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_finnish", updateInstructorTypes.s_instructor_type_desc_finnish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_korean", updateInstructorTypes.s_instructor_type_name_korean);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_korean", updateInstructorTypes.s_instructor_type_desc_korean);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_italian", updateInstructorTypes.s_instructor_type_name_italian);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_italian", updateInstructorTypes.s_instructor_type_desc_italian);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_dutch", updateInstructorTypes.s_instructor_type_name_dutch);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_dutch", updateInstructorTypes.s_instructor_type_desc_dutch);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_indonesian", updateInstructorTypes.s_instructor_type_name_indonesian);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_indonesian", updateInstructorTypes.s_instructor_type_desc_indonesian);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_greek", updateInstructorTypes.s_instructor_type_name_greek);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_greek", updateInstructorTypes.s_instructor_type_desc_greek);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_hungarian", updateInstructorTypes.s_instructor_type_name_hungarian);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_hungarian", updateInstructorTypes.s_instructor_type_desc_hungarian);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_norwegian", updateInstructorTypes.s_instructor_type_name_norwegian);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_norwegian", updateInstructorTypes.s_instructor_type_desc_norwegian);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_turkish", updateInstructorTypes.s_instructor_type_name_turkish);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_turkish", updateInstructorTypes.s_instructor_type_desc_turkish);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_arabic_rtl", updateInstructorTypes.s_instructor_type_name_arabic_rtl);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_arabic_rtl", updateInstructorTypes.s_instructor_type_desc_arabic_rtl);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_01", updateInstructorTypes.s_instructor_type_name_custom_01);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_01", updateInstructorTypes.s_instructor_type_desc_custom_01);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_02", updateInstructorTypes.s_instructor_type_name_custom_02);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_02", updateInstructorTypes.s_instructor_type_desc_custom_02);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_03", updateInstructorTypes.s_instructor_type_name_custom_03);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_03", updateInstructorTypes.s_instructor_type_desc_custom_03);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_04", updateInstructorTypes.s_instructor_type_name_custom_04);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_04", updateInstructorTypes.s_instructor_type_desc_custom_04);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_05", updateInstructorTypes.s_instructor_type_name_custom_05);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_05", updateInstructorTypes.s_instructor_type_desc_custom_05);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_06", updateInstructorTypes.s_instructor_type_name_custom_06);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_06", updateInstructorTypes.s_instructor_type_desc_custom_06);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_07", updateInstructorTypes.s_instructor_type_name_custom_07);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_07", updateInstructorTypes.s_instructor_type_desc_custom_07);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_08", updateInstructorTypes.s_instructor_type_name_custom_08);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_08", updateInstructorTypes.s_instructor_type_desc_custom_08);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_09", updateInstructorTypes.s_instructor_type_name_custom_09);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_09", updateInstructorTypes.s_instructor_type_desc_custom_09);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_10", updateInstructorTypes.s_instructor_type_name_custom_10);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_10", updateInstructorTypes.s_instructor_type_desc_custom_10);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_11", updateInstructorTypes.s_instructor_type_name_custom_11);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_11", updateInstructorTypes.s_instructor_type_desc_custom_11);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_12", updateInstructorTypes.s_instructor_type_name_custom_12);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_12", updateInstructorTypes.s_instructor_type_desc_custom_12);
            htUpdateInstructorTypes.Add("@s_instructor_type_name_custom_13", updateInstructorTypes.s_instructor_type_name_custom_13);
            htUpdateInstructorTypes.Add("@s_instructor_type_desc_custom_13", updateInstructorTypes.s_instructor_type_desc_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_instructor_type", htUpdateInstructorTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateInstructorStatus(SystemInstructorType instructor)
        {
            Hashtable htUpdateInstructorStatus = new Hashtable();
            htUpdateInstructorStatus.Add("@s_instructor_type_system_id_pk", instructor.s_instructor_type_system_id_pk);
            //htUpdateCaseStatus.Add("@c_case_status", miris.c_case_status);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_instructor_type_status", htUpdateInstructorStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
