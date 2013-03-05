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
            Hashtable htNewInstructorType = new Hashtable();
            htNewInstructorType.Add("@s_instructor_type_system_id_pk", instructor.s_instructor_type_system_id_pk);
            htNewInstructorType.Add("@s_instructor_type_id", instructor.s_instructor_type_id);          
            htNewInstructorType.Add("@s_instructor_english_us_name", instructor.s_instructor_english_us_name);
            htNewInstructorType.Add("@s_instructor_english_us_description", instructor.s_instructor_english_us_description);
            htNewInstructorType.Add("@s_instructor_english_us_status_id_fk", instructor.s_instructor_english_us_status_id_fk);
            htNewInstructorType.Add("@s_instructor_english_uk_name", instructor.s_instructor_english_uk_name);
            htNewInstructorType.Add("@s_instructor_english_uk_description", instructor.s_instructor_english_uk_description);
            htNewInstructorType.Add("@s_instructor_france_ca_name", instructor.s_instructor_france_ca_name);
            htNewInstructorType.Add("@s_instructor_france_ca_description", instructor.s_instructor_france_ca_description);
            htNewInstructorType.Add("@s_instructor_french_fr_name", instructor.s_instructor_french_fr_name);
            htNewInstructorType.Add("@s_instructor_french_fr_description", instructor.s_instructor_french_fr_description);
            htNewInstructorType.Add("@s_instructor_spanish_mx_name", instructor.s_instructor_spanish_mx_name);
            htNewInstructorType.Add("@s_instructor_spanish_mx_description", instructor.s_instructor_spanish_mx_description);
            htNewInstructorType.Add("@s_instructor_sapnish_sp_name", instructor.s_instructor_sapnish_sp_name);
            htNewInstructorType.Add("@s_instructor_spanish_sp_description", instructor.s_instructor_spanish_sp_description);
            htNewInstructorType.Add("@s_instructor_portuguse_name", instructor.s_instructor_portuguse_name);
            htNewInstructorType.Add("@s_instructor_portuguse_description", instructor.s_instructor_portuguse_description);
            htNewInstructorType.Add("@s_instructor_chinese_name " ,instructor.s_instructor_chinese_name);
            htNewInstructorType.Add("@s_instructor_chinese_description", instructor.s_instructor_chinese_name);  
            htNewInstructorType.Add("@s_instructor_german_name", instructor.s_instructor_german_name);
            htNewInstructorType.Add("@s_instructor_german_description", instructor.s_instructor_german_description);
            htNewInstructorType.Add("@s_instructor_japanese_name", instructor.s_instructor_japanese_name);
            htNewInstructorType.Add("@s_instructor_japanese_description", instructor.s_instructor_japanese_description);
            htNewInstructorType.Add("@s_instructor_russian_name", instructor.s_instructor_russian_name);
            htNewInstructorType.Add("@s_instructor_russian_description", instructor.s_instructor_russian_description);
            htNewInstructorType.Add("@s_instructor_danish_name", instructor.s_instructor_danish_name);
            htNewInstructorType.Add("@s_instructor_danish_description", instructor.s_instructor_danish_description);
            htNewInstructorType.Add("@s_instructor_polish_name", instructor.s_instructor_polish_name);
            htNewInstructorType.Add("@s_instructor_polish_description", instructor.s_instructor_polish_description);
            htNewInstructorType.Add("@s_instructor_swedish_name", instructor.s_instructor_swedish_name);
            htNewInstructorType.Add("@s_instructor_swedish_description", instructor.s_instructor_swedish_description);
            htNewInstructorType.Add("@s_instructor_finnish_name", instructor.s_instructor_finnish_name);
            htNewInstructorType.Add("@s_instructor_finnish_description", instructor.s_instructor_finnish_description);
            htNewInstructorType.Add("@s_instructor_korean_name", instructor.s_instructor_korean_name);
            htNewInstructorType.Add("@s_instructor_korean_description", instructor.s_instructor_korean_description);
            htNewInstructorType.Add("@s_instructor_italian_name", instructor.s_instructor_italian_name);
            htNewInstructorType.Add("@s_instructor_italian_description", instructor.s_instructor_italian_description);
            htNewInstructorType.Add("@s_instructor_dutch_name", instructor.s_instructor_dutch_name);
            htNewInstructorType.Add("@s_instructor_dutch_description", instructor.s_instructor_dutch_description);
            htNewInstructorType.Add("@s_instructor_indonesian_name", instructor.s_instructor_indonesian_name);
            htNewInstructorType.Add("@s_instructor_indonesian_description", instructor.s_instructor_indonesian_description);
            htNewInstructorType.Add("@s_instructor_greek_name", instructor.s_instructor_greek_name);
            htNewInstructorType.Add("@s_instructor_greek_description", instructor.s_instructor_greek_description);
            htNewInstructorType.Add("@s_instructor_hungarian_name", instructor.s_instructor_hungarian_name);
            htNewInstructorType.Add("@s_instructor_hungarian_description", instructor.s_instructor_hungarian_description);
            htNewInstructorType.Add("@s_instructor_norwegian_name", instructor.s_instructor_norwegian_name);
            htNewInstructorType.Add("@s_instructor_norwegian_description", instructor.s_instructor_norwegian_description);
            htNewInstructorType.Add("@s_instructor_turkish_name", instructor.s_instructor_turkish_name);
            htNewInstructorType.Add("@s_instructor_turkish_description", instructor.s_instructor_turkish_description);
            htNewInstructorType.Add("@s_instructor_arabic_name", instructor.s_instructor_arabic_name);
            htNewInstructorType.Add("@s_instructor_arabic_description", instructor.s_instructor_arabic_description);
            htNewInstructorType.Add("@s_instructor_custom01_name", instructor.s_instructor_custom01_name);
            htNewInstructorType.Add("@s_instructor_custom01_description", instructor.s_instructor_custom01_description);
            htNewInstructorType.Add("@s_instructor_custom02_name", instructor.s_instructor_custom02_name);
            htNewInstructorType.Add("@s_instructor_custom02_description", instructor.s_instructor_custom02_description);
            htNewInstructorType.Add("@s_instructor_custom03_name", instructor.s_instructor_custom03_name);
            htNewInstructorType.Add("@s_instructor_custom03_description", instructor.s_instructor_custom03_description);
            htNewInstructorType.Add("@s_instructor_custom04_name", instructor.s_instructor_custom04_name);
            htNewInstructorType.Add("@s_instructor_custom04_description", instructor.s_instructor_custom04_description);
            htNewInstructorType.Add("@s_instructor_custom05_name", instructor.s_instructor_custom05_name);
            htNewInstructorType.Add("@s_instructor_custom05_description", instructor.s_instructor_custom05_description);
            htNewInstructorType.Add("@s_instructor_custom06_name", instructor.s_instructor_custom06_name);
            htNewInstructorType.Add("@s_instructor_custom06_description", instructor.s_instructor_custom06_description);
            htNewInstructorType.Add("@s_instructor_custom07_name", instructor.s_instructor_custom07_name);
            htNewInstructorType.Add("@s_instructor_custom07_description", instructor.s_instructor_custom07_description);
            htNewInstructorType.Add("@s_instructor_custom08_name", instructor.s_instructor_custom08_name);
            htNewInstructorType.Add("@s_instructor_custom08_description", instructor.s_instructor_custom08_description);
            htNewInstructorType.Add("@s_instructor_custom09_name", instructor.s_instructor_custom09_name);
            htNewInstructorType.Add("@s_instructor_custom09_description", instructor.s_instructor_custom09_description);
            htNewInstructorType.Add("@s_instructor_custom10_name", instructor.s_instructor_custom10_name);
            htNewInstructorType.Add("@s_instructor_custom10_description", instructor.s_instructor_custom10_description);
            htNewInstructorType.Add("@s_instructor_custom11_name", instructor.s_instructor_custom11_name);
            htNewInstructorType.Add("@s_instructor_custom11_description", instructor.s_instructor_custom11_description);
            htNewInstructorType.Add("@s_instructor_custom12_name", instructor.s_instructor_custom12_name);
            htNewInstructorType.Add("@s_instructor_custom12_description", instructor.s_instructor_custom12_description);
            htNewInstructorType.Add("@s_instructor_custom13_name", instructor.s_instructor_custom13_name);
            htNewInstructorType.Add("@s_instructor_custom13_description", instructor.s_instructor_custom13_description);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_instructor_type", htNewInstructorType);
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

        public static DataTable GetInstructorType(SystemInstructorType instructor)
        {
            Hashtable htSearchInstructor = new Hashtable();
            htSearchInstructor.Add("@s_instructor_type_id", instructor.s_instructor_type_id);
            htSearchInstructor.Add("@s_instructor_english_us_name", instructor.s_instructor_english_us_name);
            if (instructor.s_instructor_english_us_status_id_fk == "0")
                htSearchInstructor.Add("@s_instructor_english_us_status_id_fk", DBNull.Value);
            else
                htSearchInstructor.Add("@s_instructor_english_us_status_id_fk", instructor.s_instructor_english_us_status_id_fk);

            

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
            SystemInstructorType instructor =new SystemInstructorType();
            try
            {

                Hashtable htGetInstructor = new Hashtable();
                htGetInstructor.Add("@s_instructor_type_system_id_pk", s_instructor_type_system_id_pk);
                DataTable dtGetInstructor = DataProxy.FetchDataSet("s_sp_get_single_instructor_type", htGetInstructor).Tables[0];

                instructor.s_instructor_type_id = dtGetInstructor.Rows[0]["s_instructor_type_id"].ToString();                
                instructor.s_instructor_english_us_name = dtGetInstructor.Rows[0]["s_instructor_english_us_name"].ToString();
                instructor.s_instructor_english_us_description = dtGetInstructor.Rows[0]["s_instructor_english_us_description"].ToString();
                instructor.s_instructor_english_us_status_id_fk = dtGetInstructor.Rows[0]["s_instructor_english_us_status_id_fk"].ToString();
                instructor.s_instructor_english_uk_name = dtGetInstructor.Rows[0]["s_instructor_english_uk_name"].ToString();
                instructor.s_instructor_english_uk_description = dtGetInstructor.Rows[0]["s_instructor_english_uk_description"].ToString();
                instructor.s_instructor_france_ca_name = dtGetInstructor.Rows[0]["s_instructor_france_ca_name"].ToString();
                instructor.s_instructor_france_ca_description = dtGetInstructor.Rows[0]["s_instructor_france_ca_description"].ToString();
                instructor.s_instructor_french_fr_name = dtGetInstructor.Rows[0]["s_instructor_french_fr_name"].ToString();
                instructor.s_instructor_french_fr_description = dtGetInstructor.Rows[0]["s_instructor_french_fr_description"].ToString();
                instructor.s_instructor_spanish_mx_name = dtGetInstructor.Rows[0]["s_instructor_spanish_mx_name"].ToString();
                instructor.s_instructor_spanish_mx_description = dtGetInstructor.Rows[0]["s_instructor_spanish_mx_description"].ToString();
                instructor.s_instructor_sapnish_sp_name = dtGetInstructor.Rows[0]["s_instructor_sapnish_sp_name"].ToString();
                instructor.s_instructor_spanish_sp_description = dtGetInstructor.Rows[0]["s_instructor_spanish_sp_description"].ToString();
                instructor.s_instructor_portuguse_name = dtGetInstructor.Rows[0]["s_instructor_portuguse_name"].ToString();
                instructor.s_instructor_portuguse_description = dtGetInstructor.Rows[0]["s_instructor_portuguse_description"].ToString();
                instructor.s_instructor_chinese_name = dtGetInstructor.Rows[0]["s_instructor_chinese_name"].ToString();
                instructor.s_instructor_chinese_description = dtGetInstructor.Rows[0]["s_instructor_chinese_description"].ToString();
                instructor.s_instructor_german_name = dtGetInstructor.Rows[0]["s_instructor_german_name"].ToString();
                instructor.s_instructor_german_description = dtGetInstructor.Rows[0]["s_instructor_german_description"].ToString();
                instructor.s_instructor_japanese_name = dtGetInstructor.Rows[0]["s_instructor_japanese_name"].ToString();
                instructor.s_instructor_japanese_description = dtGetInstructor.Rows[0]["s_instructor_japanese_description"].ToString();
                instructor.s_instructor_russian_name = dtGetInstructor.Rows[0]["s_instructor_russian_name"].ToString();
                instructor.s_instructor_russian_description = dtGetInstructor.Rows[0]["s_instructor_russian_description"].ToString();
                instructor.s_instructor_danish_name = dtGetInstructor.Rows[0]["s_instructor_danish_name"].ToString();
                instructor.s_instructor_danish_description = dtGetInstructor.Rows[0]["s_instructor_danish_description"].ToString();
                instructor.s_instructor_polish_name = dtGetInstructor.Rows[0]["s_instructor_polish_name"].ToString();
                instructor.s_instructor_polish_description = dtGetInstructor.Rows[0]["s_instructor_polish_description"].ToString();
                instructor.s_instructor_swedish_name = dtGetInstructor.Rows[0]["s_instructor_swedish_name"].ToString();
                instructor.s_instructor_swedish_description = dtGetInstructor.Rows[0]["s_instructor_swedish_description"].ToString();
                instructor.s_instructor_finnish_name = dtGetInstructor.Rows[0]["s_instructor_finnish_name"].ToString();
                instructor.s_instructor_finnish_description = dtGetInstructor.Rows[0]["s_instructor_finnish_description"].ToString();
                instructor.s_instructor_korean_name = dtGetInstructor.Rows[0]["s_instructor_korean_name"].ToString();
                instructor.s_instructor_korean_description = dtGetInstructor.Rows[0]["s_instructor_korean_description"].ToString();
                instructor.s_instructor_italian_name = dtGetInstructor.Rows[0]["s_instructor_italian_name"].ToString();
                instructor.s_instructor_italian_description = dtGetInstructor.Rows[0]["s_instructor_italian_description"].ToString();
                instructor.s_instructor_dutch_name = dtGetInstructor.Rows[0]["s_instructor_dutch_name"].ToString();
                instructor.s_instructor_dutch_description = dtGetInstructor.Rows[0]["s_instructor_dutch_description"].ToString();
                instructor.s_instructor_indonesian_name = dtGetInstructor.Rows[0]["s_instructor_indonesian_name"].ToString();
                instructor.s_instructor_indonesian_description = dtGetInstructor.Rows[0]["s_instructor_indonesian_description"].ToString();
                instructor.s_instructor_greek_name = dtGetInstructor.Rows[0]["s_instructor_greek_name"].ToString();
                instructor.s_instructor_greek_description = dtGetInstructor.Rows[0]["s_instructor_greek_description"].ToString();
                instructor.s_instructor_hungarian_name = dtGetInstructor.Rows[0]["s_instructor_hungarian_name"].ToString();
                instructor.s_instructor_hungarian_description = dtGetInstructor.Rows[0]["s_instructor_hungarian_description"].ToString();
                instructor.s_instructor_norwegian_name = dtGetInstructor.Rows[0]["s_instructor_norwegian_name"].ToString();
                instructor.s_instructor_norwegian_description = dtGetInstructor.Rows[0]["s_instructor_norwegian_description"].ToString();
                instructor.s_instructor_turkish_name = dtGetInstructor.Rows[0]["s_instructor_turkish_name"].ToString();
                instructor.s_instructor_turkish_description = dtGetInstructor.Rows[0]["s_instructor_turkish_description"].ToString();
                instructor.s_instructor_arabic_name = dtGetInstructor.Rows[0]["s_instructor_arabic_name"].ToString();
                instructor.s_instructor_arabic_description = dtGetInstructor.Rows[0]["s_instructor_arabic_description"].ToString();
                instructor.s_instructor_custom01_name = dtGetInstructor.Rows[0]["s_instructor_custom01_name"].ToString();
                instructor.s_instructor_custom01_description = dtGetInstructor.Rows[0]["s_instructor_custom01_description"].ToString();
                instructor.s_instructor_custom02_name = dtGetInstructor.Rows[0]["s_instructor_custom02_name"].ToString();
                instructor.s_instructor_custom02_description = dtGetInstructor.Rows[0]["s_instructor_custom02_description"].ToString();
                instructor.s_instructor_custom03_name = dtGetInstructor.Rows[0]["s_instructor_custom03_name"].ToString();
                instructor.s_instructor_custom03_description = dtGetInstructor.Rows[0]["s_instructor_custom03_description"].ToString();
                instructor.s_instructor_custom04_name = dtGetInstructor.Rows[0]["s_instructor_custom04_name"].ToString();
                instructor.s_instructor_custom04_description = dtGetInstructor.Rows[0]["s_instructor_custom04_description"].ToString();
                instructor.s_instructor_custom05_name = dtGetInstructor.Rows[0]["s_instructor_custom05_name"].ToString();
                instructor.s_instructor_custom05_description = dtGetInstructor.Rows[0]["s_instructor_custom05_description"].ToString();
                instructor.s_instructor_custom06_name = dtGetInstructor.Rows[0]["s_instructor_custom06_name"].ToString();
                instructor.s_instructor_custom06_description = dtGetInstructor.Rows[0]["s_instructor_custom06_description"].ToString();
                instructor.s_instructor_custom07_name = dtGetInstructor.Rows[0]["s_instructor_custom07_name"].ToString();
                instructor.s_instructor_custom07_description = dtGetInstructor.Rows[0]["s_instructor_custom07_description"].ToString();
                instructor.s_instructor_custom08_name = dtGetInstructor.Rows[0]["s_instructor_custom08_name"].ToString();
                instructor.s_instructor_custom08_description = dtGetInstructor.Rows[0]["s_instructor_custom08_description"].ToString();
                instructor.s_instructor_custom09_name = dtGetInstructor.Rows[0]["s_instructor_custom09_name"].ToString();
                instructor.s_instructor_custom09_description = dtGetInstructor.Rows[0]["s_instructor_custom09_description"].ToString();
                instructor.s_instructor_custom10_name = dtGetInstructor.Rows[0]["s_instructor_custom10_name"].ToString();
                instructor.s_instructor_custom10_description = dtGetInstructor.Rows[0]["s_instructor_custom10_description"].ToString();
                instructor.s_instructor_custom11_name = dtGetInstructor.Rows[0]["s_instructor_custom11_name"].ToString();
                instructor.s_instructor_custom11_description = dtGetInstructor.Rows[0]["s_instructor_custom11_description"].ToString();
                instructor.s_instructor_custom12_name = dtGetInstructor.Rows[0]["s_instructor_custom12_name"].ToString();
                instructor.s_instructor_custom12_description = dtGetInstructor.Rows[0]["s_instructor_custom12_description"].ToString();
                instructor.s_instructor_custom13_name = dtGetInstructor.Rows[0]["s_instructor_custom13_name"].ToString();
                instructor.s_instructor_custom13_description = dtGetInstructor.Rows[0]["s_instructor_custom13_description"].ToString();
                return instructor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int  UpdateInstructorType(SystemInstructorType instructor)
        {
            Hashtable htUpdateInstructorType = new Hashtable();
            htUpdateInstructorType.Add("@s_instructor_type_system_id_pk", instructor.s_instructor_type_system_id_pk);
            htUpdateInstructorType.Add("@s_instructor_type_id", instructor.s_instructor_type_id);          
            htUpdateInstructorType.Add("@s_instructor_english_us_name", instructor.s_instructor_english_us_name);
            htUpdateInstructorType.Add("@s_instructor_english_us_description", instructor.s_instructor_english_us_description);
            htUpdateInstructorType.Add("@s_instructor_english_us_status_id_fk", instructor.s_instructor_english_us_status_id_fk);
            htUpdateInstructorType.Add("@s_instructor_english_uk_name", instructor.s_instructor_english_uk_name);
            htUpdateInstructorType.Add("@s_instructor_english_uk_description", instructor.s_instructor_english_uk_description);
            htUpdateInstructorType.Add("@s_instructor_france_ca_name", instructor.s_instructor_france_ca_name);
            htUpdateInstructorType.Add("@s_instructor_france_ca_description", instructor.s_instructor_france_ca_description);
            htUpdateInstructorType.Add("@s_instructor_french_fr_name", instructor.s_instructor_french_fr_name);
            htUpdateInstructorType.Add("@s_instructor_french_fr_description", instructor.s_instructor_french_fr_description);
            htUpdateInstructorType.Add("@s_instructor_spanish_mx_name", instructor.s_instructor_spanish_mx_name);
            htUpdateInstructorType.Add("@s_instructor_spanish_mx_description", instructor.s_instructor_spanish_mx_description);
            htUpdateInstructorType.Add("@s_instructor_sapnish_sp_name", instructor.s_instructor_sapnish_sp_name);
            htUpdateInstructorType.Add("@s_instructor_spanish_sp_description", instructor.s_instructor_spanish_sp_description);
            htUpdateInstructorType.Add("@s_instructor_portuguse_name", instructor.s_instructor_portuguse_name);
            htUpdateInstructorType.Add("@s_instructor_portuguse_description", instructor.s_instructor_portuguse_description);
            htUpdateInstructorType.Add("@s_instructor_chinese_name ", instructor.s_instructor_chinese_name);
            htUpdateInstructorType.Add("@s_instructor_chinese_description", instructor.s_instructor_chinese_name);
            htUpdateInstructorType.Add("@s_instructor_german_name", instructor.s_instructor_german_name);
            htUpdateInstructorType.Add("@s_instructor_german_description", instructor.s_instructor_german_description);
            htUpdateInstructorType.Add("@s_instructor_japanese_name", instructor.s_instructor_japanese_name);
            htUpdateInstructorType.Add("@s_instructor_japanese_description", instructor.s_instructor_japanese_description);
            htUpdateInstructorType.Add("@s_instructor_russian_name", instructor.s_instructor_russian_name);
            htUpdateInstructorType.Add("@s_instructor_russian_description", instructor.s_instructor_russian_description);
            htUpdateInstructorType.Add("@s_instructor_danish_name", instructor.s_instructor_danish_name);
            htUpdateInstructorType.Add("@s_instructor_danish_description", instructor.s_instructor_danish_description);
            htUpdateInstructorType.Add("@s_instructor_polish_name", instructor.s_instructor_polish_name);
            htUpdateInstructorType.Add("@s_instructor_polish_description", instructor.s_instructor_polish_description);
            htUpdateInstructorType.Add("@s_instructor_swedish_name", instructor.s_instructor_swedish_name);
            htUpdateInstructorType.Add("@s_instructor_swedish_description", instructor.s_instructor_swedish_description);
            htUpdateInstructorType.Add("@s_instructor_finnish_name", instructor.s_instructor_finnish_name);
            htUpdateInstructorType.Add("@s_instructor_finnish_description", instructor.s_instructor_finnish_description);
            htUpdateInstructorType.Add("@s_instructor_korean_name", instructor.s_instructor_korean_name);
            htUpdateInstructorType.Add("@s_instructor_korean_description", instructor.s_instructor_korean_description);
            htUpdateInstructorType.Add("@s_instructor_italian_name", instructor.s_instructor_italian_name);
            htUpdateInstructorType.Add("@s_instructor_italian_description", instructor.s_instructor_italian_description);
            htUpdateInstructorType.Add("@s_instructor_dutch_name", instructor.s_instructor_dutch_name);
            htUpdateInstructorType.Add("@s_instructor_dutch_description", instructor.s_instructor_dutch_description);
            htUpdateInstructorType.Add("@s_instructor_indonesian_name", instructor.s_instructor_indonesian_name);
            htUpdateInstructorType.Add("@s_instructor_indonesian_description", instructor.s_instructor_indonesian_description);
            htUpdateInstructorType.Add("@s_instructor_greek_name", instructor.s_instructor_greek_name);
            htUpdateInstructorType.Add("@s_instructor_greek_description", instructor.s_instructor_greek_description);
            htUpdateInstructorType.Add("@s_instructor_hungarian_name", instructor.s_instructor_hungarian_name);
            htUpdateInstructorType.Add("@s_instructor_hungarian_description", instructor.s_instructor_hungarian_description);
            htUpdateInstructorType.Add("@s_instructor_norwegian_name", instructor.s_instructor_norwegian_name);
            htUpdateInstructorType.Add("@s_instructor_norwegian_description", instructor.s_instructor_norwegian_description);
            htUpdateInstructorType.Add("@s_instructor_turkish_name", instructor.s_instructor_turkish_name);
            htUpdateInstructorType.Add("@s_instructor_turkish_description", instructor.s_instructor_turkish_description);
            htUpdateInstructorType.Add("@s_instructor_arabic_name", instructor.s_instructor_arabic_name);
            htUpdateInstructorType.Add("@s_instructor_arabic_description", instructor.s_instructor_arabic_description);
            htUpdateInstructorType.Add("@s_instructor_custom01_name", instructor.s_instructor_custom01_name);
            htUpdateInstructorType.Add("@s_instructor_custom01_description", instructor.s_instructor_custom01_description);
            htUpdateInstructorType.Add("@s_instructor_custom02_name", instructor.s_instructor_custom02_name);
            htUpdateInstructorType.Add("@s_instructor_custom02_description", instructor.s_instructor_custom02_description);
            htUpdateInstructorType.Add("@s_instructor_custom03_name", instructor.s_instructor_custom03_name);
            htUpdateInstructorType.Add("@s_instructor_custom03_description", instructor.s_instructor_custom03_description);
            htUpdateInstructorType.Add("@s_instructor_custom04_name", instructor.s_instructor_custom04_name);
            htUpdateInstructorType.Add("@s_instructor_custom04_description", instructor.s_instructor_custom04_description);
            htUpdateInstructorType.Add("@s_instructor_custom05_name", instructor.s_instructor_custom05_name);
            htUpdateInstructorType.Add("@s_instructor_custom05_description", instructor.s_instructor_custom05_description);
            htUpdateInstructorType.Add("@s_instructor_custom06_name", instructor.s_instructor_custom06_name);
            htUpdateInstructorType.Add("@s_instructor_custom06_description", instructor.s_instructor_custom06_description);
            htUpdateInstructorType.Add("@s_instructor_custom07_name", instructor.s_instructor_custom07_name);
            htUpdateInstructorType.Add("@s_instructor_custom07_description", instructor.s_instructor_custom07_description);
            htUpdateInstructorType.Add("@s_instructor_custom08_name", instructor.s_instructor_custom08_name);
            htUpdateInstructorType.Add("@s_instructor_custom08_description", instructor.s_instructor_custom08_description);
            htUpdateInstructorType.Add("@s_instructor_custom09_name", instructor.s_instructor_custom09_name);
            htUpdateInstructorType.Add("@s_instructor_custom09_description", instructor.s_instructor_custom09_description);
            htUpdateInstructorType.Add("@s_instructor_custom10_name", instructor.s_instructor_custom10_name);
            htUpdateInstructorType.Add("@s_instructor_custom10_description", instructor.s_instructor_custom10_description);
            htUpdateInstructorType.Add("@s_instructor_custom11_name", instructor.s_instructor_custom11_name);
            htUpdateInstructorType.Add("@s_instructor_custom11_description", instructor.s_instructor_custom11_description);
            htUpdateInstructorType.Add("@s_instructor_custom12_name", instructor.s_instructor_custom12_name);
            htUpdateInstructorType.Add("@s_instructor_custom12_description", instructor.s_instructor_custom12_description);
            htUpdateInstructorType.Add("@s_instructor_custom13_name", instructor.s_instructor_custom13_name);
            htUpdateInstructorType.Add("@s_instructor_custom13_description", instructor.s_instructor_custom13_description);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_instructor_type", htUpdateInstructorType);
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
