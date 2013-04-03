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
   public class SystemEmployeeTypesBLL
    {
       /// <summary>
        /// Get employee  status
       /// </summary>
       /// <returns></returns>
       public static DataTable GetEmployeeStatus(string s_ui_locale_name, string s_ui_page_name)
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
       /// Get employee all status
       /// </summary>
       /// <param name="s_ui_locale_name"></param>
       /// <param name="s_ui_page_name"></param>
       /// <returns></returns>
       public static DataTable GetEmployeeAllStatus(string s_ui_locale_name, string s_ui_page_name)
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
       /// Create Employee Types
       /// </summary>
       /// <param name="createEmployeeTypes"></param>
       /// <returns></returns>
       public static int CreateEmployeeTypes(SystemEmployeeType createEmployeeTypes)
       {
           Hashtable htCreateEmployeeTypes = new Hashtable();

           htCreateEmployeeTypes.Add("@s_employee_type_system_id_pk", createEmployeeTypes.s_employee_type_system_id_pk);
           htCreateEmployeeTypes.Add("@s_employee_type_id", createEmployeeTypes.s_employee_type_id);
           if (createEmployeeTypes.s_employee_type_status_id_fk == "0")
               htCreateEmployeeTypes.Add("@s_employee_type_status_id_fk", DBNull.Value);
           else
               htCreateEmployeeTypes.Add("@s_employee_type_status_id_fk", createEmployeeTypes.s_employee_type_status_id_fk);


           htCreateEmployeeTypes.Add("@s_employee_type_name_us_english", createEmployeeTypes.s_employee_type_name_us_english);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_us_english", createEmployeeTypes.s_employee_type_desc_us_english);
           htCreateEmployeeTypes.Add("@s_employee_type_name_uk_english", createEmployeeTypes.s_employee_type_name_uk_english);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_uk_english", createEmployeeTypes.s_employee_type_desc_uk_english);
           htCreateEmployeeTypes.Add("@s_employee_type_name_ca_french", createEmployeeTypes.s_employee_type_name_ca_french);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_ca_french", createEmployeeTypes.s_employee_type_desc_ca_french);
           htCreateEmployeeTypes.Add("@s_employee_type_name_fr_french", createEmployeeTypes.s_employee_type_name_fr_french);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_fr_french", createEmployeeTypes.s_employee_type_desc_fr_french);
           htCreateEmployeeTypes.Add("@s_employee_type_name_mx_spanish", createEmployeeTypes.s_employee_type_name_mx_spanish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_mx_spanish", createEmployeeTypes.s_employee_type_desc_mx_spanish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_sp_spanish", createEmployeeTypes.s_employee_type_name_sp_spanish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_sp_spanish", createEmployeeTypes.s_employee_type_desc_sp_spanish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_portuguese", createEmployeeTypes.s_employee_type_name_portuguese);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_portuguese", createEmployeeTypes.s_employee_type_desc_portuguese);
           htCreateEmployeeTypes.Add("@s_employee_type_name_simp_chinese", createEmployeeTypes.s_employee_type_name_simp_chinese);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_simp_chinese", createEmployeeTypes.s_employee_type_desc_simp_chinese);
           htCreateEmployeeTypes.Add("@s_employee_type_name_german", createEmployeeTypes.s_employee_type_name_german);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_german", createEmployeeTypes.s_employee_type_desc_german);
           htCreateEmployeeTypes.Add("@s_employee_type_name_japanese", createEmployeeTypes.s_employee_type_name_japanese);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_japanese", createEmployeeTypes.s_employee_type_desc_japanese);
           htCreateEmployeeTypes.Add("@s_employee_type_name_russian", createEmployeeTypes.s_employee_type_name_russian);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_russian", createEmployeeTypes.s_employee_type_desc_russian);
           htCreateEmployeeTypes.Add("@s_employee_type_name_danish", createEmployeeTypes.s_employee_type_name_danish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_danish", createEmployeeTypes.s_employee_type_desc_danish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_polish", createEmployeeTypes.s_employee_type_name_polish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_polish", createEmployeeTypes.s_employee_type_desc_polish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_swedish", createEmployeeTypes.s_employee_type_name_swedish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_swedish", createEmployeeTypes.s_employee_type_desc_swedish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_finnish", createEmployeeTypes.s_employee_type_name_finnish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_finnish", createEmployeeTypes.s_employee_type_desc_finnish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_korean", createEmployeeTypes.s_employee_type_name_korean);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_korean", createEmployeeTypes.s_employee_type_desc_korean);
           htCreateEmployeeTypes.Add("@s_employee_type_name_italian", createEmployeeTypes.s_employee_type_name_italian);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_italian", createEmployeeTypes.s_employee_type_desc_italian);
           htCreateEmployeeTypes.Add("@s_employee_type_name_dutch", createEmployeeTypes.s_employee_type_name_dutch);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_dutch", createEmployeeTypes.s_employee_type_desc_dutch);
           htCreateEmployeeTypes.Add("@s_employee_type_name_indonesian", createEmployeeTypes.s_employee_type_name_indonesian);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_indonesian", createEmployeeTypes.s_employee_type_desc_indonesian);
           htCreateEmployeeTypes.Add("@s_employee_type_name_greek", createEmployeeTypes.s_employee_type_name_greek);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_greek", createEmployeeTypes.s_employee_type_desc_greek);
           htCreateEmployeeTypes.Add("@s_employee_type_name_hungarian", createEmployeeTypes.s_employee_type_name_hungarian);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_hungarian", createEmployeeTypes.s_employee_type_desc_hungarian);
           htCreateEmployeeTypes.Add("@s_employee_type_name_norwegian", createEmployeeTypes.s_employee_type_name_norwegian);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_norwegian", createEmployeeTypes.s_employee_type_desc_norwegian);
           htCreateEmployeeTypes.Add("@s_employee_type_name_turkish", createEmployeeTypes.s_employee_type_name_turkish);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_turkish", createEmployeeTypes.s_employee_type_desc_turkish);
           htCreateEmployeeTypes.Add("@s_employee_type_name_arabic_rtl", createEmployeeTypes.s_employee_type_name_arabic_rtl);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_arabic_rtl", createEmployeeTypes.s_employee_type_desc_arabic_rtl);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_01", createEmployeeTypes.s_employee_type_name_custom_01);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_01", createEmployeeTypes.s_employee_type_desc_custom_01);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_02", createEmployeeTypes.s_employee_type_name_custom_02);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_02", createEmployeeTypes.s_employee_type_desc_custom_02);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_03", createEmployeeTypes.s_employee_type_name_custom_03);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_03", createEmployeeTypes.s_employee_type_desc_custom_03);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_04", createEmployeeTypes.s_employee_type_name_custom_04);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_04", createEmployeeTypes.s_employee_type_desc_custom_04);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_05", createEmployeeTypes.s_employee_type_name_custom_05);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_05", createEmployeeTypes.s_employee_type_desc_custom_05);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_06", createEmployeeTypes.s_employee_type_name_custom_06);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_06", createEmployeeTypes.s_employee_type_desc_custom_06);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_07", createEmployeeTypes.s_employee_type_name_custom_07);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_07", createEmployeeTypes.s_employee_type_desc_custom_07);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_08", createEmployeeTypes.s_employee_type_name_custom_08);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_08", createEmployeeTypes.s_employee_type_desc_custom_08);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_09", createEmployeeTypes.s_employee_type_name_custom_09);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_09", createEmployeeTypes.s_employee_type_desc_custom_09);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_10", createEmployeeTypes.s_employee_type_name_custom_10);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_10", createEmployeeTypes.s_employee_type_desc_custom_10);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_11", createEmployeeTypes.s_employee_type_name_custom_11);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_11", createEmployeeTypes.s_employee_type_desc_custom_11);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_12", createEmployeeTypes.s_employee_type_name_custom_12);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_12", createEmployeeTypes.s_employee_type_desc_custom_12);
           htCreateEmployeeTypes.Add("@s_employee_type_name_custom_13", createEmployeeTypes.s_employee_type_name_custom_13);
           htCreateEmployeeTypes.Add("@s_employee_type_desc_custom_13", createEmployeeTypes.s_employee_type_desc_custom_13);

           try
           {
               return DataProxy.FetchSPOutput("s_sp_insert_employee_types",htCreateEmployeeTypes);
           }
           catch (Exception)
           {
               throw;
           }



       }
       /// <summary>
       /// Get Employee Types
       /// </summary>
       /// <param name="s_employee_type_system_id_pk"></param>
       /// <returns></returns>
       public static SystemEmployeeType GetEmployeeType(string s_employee_type_system_id_pk)
        {
           SystemEmployeeType employeeType;

           try
           {
               Hashtable htGetEmployeeTypes = new Hashtable();
               htGetEmployeeTypes.Add("@s_employee_type_system_id_pk", s_employee_type_system_id_pk);
               employeeType = new SystemEmployeeType();
               DataTable dtGetEmployeeType = DataProxy.FetchDataTable("s_sp_get_employee_types", htGetEmployeeTypes);
               employeeType.s_employee_type_id = dtGetEmployeeType.Rows[0]["s_employee_type_id"].ToString();
               employeeType.s_employee_type_status_id_fk = dtGetEmployeeType.Rows[0]["s_employee_type_status_id_fk"].ToString();

               employeeType.s_employee_type_name_us_english = dtGetEmployeeType.Rows[0]["s_employee_type_name_us_english"].ToString();
               employeeType.s_employee_type_desc_us_english = dtGetEmployeeType.Rows[0]["s_employee_type_desc_us_english"].ToString();
               employeeType.s_employee_type_name_uk_english = dtGetEmployeeType.Rows[0]["s_employee_type_name_uk_english"].ToString();
               employeeType.s_employee_type_desc_uk_english = dtGetEmployeeType.Rows[0]["s_employee_type_desc_uk_english"].ToString();
               employeeType.s_employee_type_name_ca_french = dtGetEmployeeType.Rows[0]["s_employee_type_name_ca_french"].ToString();
               employeeType.s_employee_type_desc_ca_french = dtGetEmployeeType.Rows[0]["s_employee_type_desc_ca_french"].ToString();
               employeeType.s_employee_type_name_fr_french = dtGetEmployeeType.Rows[0]["s_employee_type_name_fr_french"].ToString();
               employeeType.s_employee_type_desc_fr_french = dtGetEmployeeType.Rows[0]["s_employee_type_desc_fr_french"].ToString();
               employeeType.s_employee_type_name_mx_spanish = dtGetEmployeeType.Rows[0]["s_employee_type_name_mx_spanish"].ToString();
               employeeType.s_employee_type_desc_mx_spanish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_mx_spanish"].ToString();
               employeeType.s_employee_type_name_sp_spanish = dtGetEmployeeType.Rows[0]["s_employee_type_name_sp_spanish"].ToString();
               employeeType.s_employee_type_desc_sp_spanish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_sp_spanish"].ToString();
               employeeType.s_employee_type_name_portuguese = dtGetEmployeeType.Rows[0]["s_employee_type_name_portuguese"].ToString();
               employeeType.s_employee_type_desc_portuguese = dtGetEmployeeType.Rows[0]["s_employee_type_desc_portuguese"].ToString();
               employeeType.s_employee_type_name_simp_chinese = dtGetEmployeeType.Rows[0]["s_employee_type_name_simp_chinese"].ToString();
               employeeType.s_employee_type_desc_simp_chinese = dtGetEmployeeType.Rows[0]["s_employee_type_desc_simp_chinese"].ToString();
               employeeType.s_employee_type_name_german = dtGetEmployeeType.Rows[0]["s_employee_type_name_german"].ToString();
               employeeType.s_employee_type_desc_german = dtGetEmployeeType.Rows[0]["s_employee_type_desc_german"].ToString();
               employeeType.s_employee_type_name_japanese = dtGetEmployeeType.Rows[0]["s_employee_type_name_japanese"].ToString();
               employeeType.s_employee_type_desc_japanese = dtGetEmployeeType.Rows[0]["s_employee_type_desc_japanese"].ToString();
               employeeType.s_employee_type_name_russian = dtGetEmployeeType.Rows[0]["s_employee_type_name_russian"].ToString();
               employeeType.s_employee_type_desc_russian = dtGetEmployeeType.Rows[0]["s_employee_type_desc_russian"].ToString();
               employeeType.s_employee_type_name_danish = dtGetEmployeeType.Rows[0]["s_employee_type_name_danish"].ToString();
               employeeType.s_employee_type_desc_danish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_danish"].ToString();
               employeeType.s_employee_type_name_polish = dtGetEmployeeType.Rows[0]["s_employee_type_name_polish"].ToString();
               employeeType.s_employee_type_desc_polish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_polish"].ToString();
               employeeType.s_employee_type_name_swedish = dtGetEmployeeType.Rows[0]["s_employee_type_name_swedish"].ToString();
               employeeType.s_employee_type_desc_swedish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_swedish"].ToString();
               employeeType.s_employee_type_name_finnish = dtGetEmployeeType.Rows[0]["s_employee_type_name_finnish"].ToString();
               employeeType.s_employee_type_desc_finnish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_finnish"].ToString();
               employeeType.s_employee_type_name_korean = dtGetEmployeeType.Rows[0]["s_employee_type_name_korean"].ToString();
               employeeType.s_employee_type_desc_korean = dtGetEmployeeType.Rows[0]["s_employee_type_desc_korean"].ToString();
               employeeType.s_employee_type_name_italian = dtGetEmployeeType.Rows[0]["s_employee_type_name_italian"].ToString();
               employeeType.s_employee_type_desc_italian = dtGetEmployeeType.Rows[0]["s_employee_type_desc_italian"].ToString();
               employeeType.s_employee_type_name_dutch = dtGetEmployeeType.Rows[0]["s_employee_type_name_dutch"].ToString();
               employeeType.s_employee_type_desc_dutch = dtGetEmployeeType.Rows[0]["s_employee_type_desc_dutch"].ToString();
               employeeType.s_employee_type_name_indonesian = dtGetEmployeeType.Rows[0]["s_employee_type_name_indonesian"].ToString();
               employeeType.s_employee_type_desc_indonesian = dtGetEmployeeType.Rows[0]["s_employee_type_desc_indonesian"].ToString();
               employeeType.s_employee_type_name_greek = dtGetEmployeeType.Rows[0]["s_employee_type_name_greek"].ToString();
               employeeType.s_employee_type_desc_greek = dtGetEmployeeType.Rows[0]["s_employee_type_desc_greek"].ToString();
               employeeType.s_employee_type_name_hungarian = dtGetEmployeeType.Rows[0]["s_employee_type_name_hungarian"].ToString();
               employeeType.s_employee_type_desc_hungarian = dtGetEmployeeType.Rows[0]["s_employee_type_desc_hungarian"].ToString();
               employeeType.s_employee_type_name_norwegian = dtGetEmployeeType.Rows[0]["s_employee_type_name_norwegian"].ToString();
               employeeType.s_employee_type_desc_norwegian = dtGetEmployeeType.Rows[0]["s_employee_type_desc_norwegian"].ToString();
               employeeType.s_employee_type_name_turkish = dtGetEmployeeType.Rows[0]["s_employee_type_name_turkish"].ToString();
               employeeType.s_employee_type_desc_turkish = dtGetEmployeeType.Rows[0]["s_employee_type_desc_turkish"].ToString();
               employeeType.s_employee_type_name_arabic_rtl = dtGetEmployeeType.Rows[0]["s_employee_type_name_arabic_rtl"].ToString();
               employeeType.s_employee_type_desc_arabic_rtl = dtGetEmployeeType.Rows[0]["s_employee_type_desc_arabic_rtl"].ToString();
               employeeType.s_employee_type_name_custom_01 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_01"].ToString();
               employeeType.s_employee_type_desc_custom_01 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_01"].ToString();
               employeeType.s_employee_type_name_custom_02 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_02"].ToString();
               employeeType.s_employee_type_desc_custom_02 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_02"].ToString();
               employeeType.s_employee_type_name_custom_03 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_03"].ToString();
               employeeType.s_employee_type_desc_custom_03 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_03"].ToString();
               employeeType.s_employee_type_name_custom_04 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_04"].ToString();
               employeeType.s_employee_type_desc_custom_04 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_04"].ToString();
               employeeType.s_employee_type_name_custom_05 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_05"].ToString();
               employeeType.s_employee_type_desc_custom_05 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_05"].ToString();
               employeeType.s_employee_type_name_custom_06 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_06"].ToString();
               employeeType.s_employee_type_desc_custom_06 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_06"].ToString();
               employeeType.s_employee_type_name_custom_07 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_07"].ToString();
               employeeType.s_employee_type_desc_custom_07 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_07"].ToString();
               employeeType.s_employee_type_name_custom_08 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_08"].ToString();
               employeeType.s_employee_type_desc_custom_08 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_08"].ToString();
               employeeType.s_employee_type_name_custom_09 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_09"].ToString();
               employeeType.s_employee_type_desc_custom_09 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_09"].ToString();
               employeeType.s_employee_type_name_custom_10 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_10"].ToString();
               employeeType.s_employee_type_desc_custom_10 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_10"].ToString();
               employeeType.s_employee_type_name_custom_11 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_11"].ToString();
               employeeType.s_employee_type_desc_custom_11 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_11"].ToString();
               employeeType.s_employee_type_name_custom_12 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_12"].ToString();
               employeeType.s_employee_type_desc_custom_12 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_12"].ToString();
               employeeType.s_employee_type_name_custom_13 = dtGetEmployeeType.Rows[0]["s_employee_type_name_custom_13"].ToString();
               employeeType.s_employee_type_desc_custom_13 = dtGetEmployeeType.Rows[0]["s_employee_type_desc_custom_13"].ToString();

              
               return employeeType;
           }
           catch (Exception)
           {
               throw;
           }


       }
       /// <summary>
       /// Update Employee Types  
       /// </summary>
       /// <param name="updateEmployeeTypes"></param>
       /// <returns></returns>
       public static int UpdateEmployeeTypes(SystemEmployeeType updateEmployeeTypes)
       {
           Hashtable htUpdateEmployeeTypes = new Hashtable();
           htUpdateEmployeeTypes.Add("@s_employee_type_system_id_pk", updateEmployeeTypes.s_employee_type_system_id_pk);
           htUpdateEmployeeTypes.Add("@s_employee_type_id", updateEmployeeTypes.s_employee_type_id);
           htUpdateEmployeeTypes.Add("@s_employee_type_status_id_fk", updateEmployeeTypes.s_employee_type_status_id_fk);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_us_english", updateEmployeeTypes.s_employee_type_name_us_english);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_us_english", updateEmployeeTypes.s_employee_type_desc_us_english);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_uk_english", updateEmployeeTypes.s_employee_type_name_uk_english);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_uk_english", updateEmployeeTypes.s_employee_type_desc_uk_english);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_ca_french", updateEmployeeTypes.s_employee_type_name_ca_french);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_ca_french", updateEmployeeTypes.s_employee_type_desc_ca_french);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_fr_french", updateEmployeeTypes.s_employee_type_name_fr_french);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_fr_french", updateEmployeeTypes.s_employee_type_desc_fr_french);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_mx_spanish", updateEmployeeTypes.s_employee_type_name_mx_spanish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_mx_spanish", updateEmployeeTypes.s_employee_type_desc_mx_spanish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_sp_spanish", updateEmployeeTypes.s_employee_type_name_sp_spanish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_sp_spanish", updateEmployeeTypes.s_employee_type_desc_sp_spanish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_portuguese", updateEmployeeTypes.s_employee_type_name_portuguese);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_portuguese", updateEmployeeTypes.s_employee_type_desc_portuguese);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_simp_chinese", updateEmployeeTypes.s_employee_type_name_simp_chinese);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_simp_chinese", updateEmployeeTypes.s_employee_type_desc_simp_chinese);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_german", updateEmployeeTypes.s_employee_type_name_german);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_german", updateEmployeeTypes.s_employee_type_desc_german);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_japanese", updateEmployeeTypes.s_employee_type_name_japanese);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_japanese", updateEmployeeTypes.s_employee_type_desc_japanese);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_russian", updateEmployeeTypes.s_employee_type_name_russian);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_russian", updateEmployeeTypes.s_employee_type_desc_russian);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_danish", updateEmployeeTypes.s_employee_type_name_danish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_danish", updateEmployeeTypes.s_employee_type_desc_danish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_polish", updateEmployeeTypes.s_employee_type_name_polish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_polish", updateEmployeeTypes.s_employee_type_desc_polish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_swedish", updateEmployeeTypes.s_employee_type_name_swedish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_swedish", updateEmployeeTypes.s_employee_type_desc_swedish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_finnish", updateEmployeeTypes.s_employee_type_name_finnish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_finnish", updateEmployeeTypes.s_employee_type_desc_finnish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_korean", updateEmployeeTypes.s_employee_type_name_korean);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_korean", updateEmployeeTypes.s_employee_type_desc_korean);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_italian", updateEmployeeTypes.s_employee_type_name_italian);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_italian", updateEmployeeTypes.s_employee_type_desc_italian);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_dutch", updateEmployeeTypes.s_employee_type_name_dutch);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_dutch", updateEmployeeTypes.s_employee_type_desc_dutch);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_indonesian", updateEmployeeTypes.s_employee_type_name_indonesian);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_indonesian", updateEmployeeTypes.s_employee_type_desc_indonesian);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_greek", updateEmployeeTypes.s_employee_type_name_greek);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_greek", updateEmployeeTypes.s_employee_type_desc_greek);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_hungarian", updateEmployeeTypes.s_employee_type_name_hungarian);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_hungarian", updateEmployeeTypes.s_employee_type_desc_hungarian);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_norwegian", updateEmployeeTypes.s_employee_type_name_norwegian);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_norwegian", updateEmployeeTypes.s_employee_type_desc_norwegian);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_turkish", updateEmployeeTypes.s_employee_type_name_turkish);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_turkish", updateEmployeeTypes.s_employee_type_desc_turkish);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_arabic_rtl", updateEmployeeTypes.s_employee_type_name_arabic_rtl);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_arabic_rtl", updateEmployeeTypes.s_employee_type_desc_arabic_rtl);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_01", updateEmployeeTypes.s_employee_type_name_custom_01);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_01", updateEmployeeTypes.s_employee_type_desc_custom_01);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_02", updateEmployeeTypes.s_employee_type_name_custom_02);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_02", updateEmployeeTypes.s_employee_type_desc_custom_02);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_03", updateEmployeeTypes.s_employee_type_name_custom_03);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_03", updateEmployeeTypes.s_employee_type_desc_custom_03);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_04", updateEmployeeTypes.s_employee_type_name_custom_04);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_04", updateEmployeeTypes.s_employee_type_desc_custom_04);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_05", updateEmployeeTypes.s_employee_type_name_custom_05);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_05", updateEmployeeTypes.s_employee_type_desc_custom_05);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_06", updateEmployeeTypes.s_employee_type_name_custom_06);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_06", updateEmployeeTypes.s_employee_type_desc_custom_06);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_07", updateEmployeeTypes.s_employee_type_name_custom_07);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_07", updateEmployeeTypes.s_employee_type_desc_custom_07);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_08", updateEmployeeTypes.s_employee_type_name_custom_08);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_08", updateEmployeeTypes.s_employee_type_desc_custom_08);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_09", updateEmployeeTypes.s_employee_type_name_custom_09);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_09", updateEmployeeTypes.s_employee_type_desc_custom_09);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_10", updateEmployeeTypes.s_employee_type_name_custom_10);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_10", updateEmployeeTypes.s_employee_type_desc_custom_10);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_11", updateEmployeeTypes.s_employee_type_name_custom_11);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_11", updateEmployeeTypes.s_employee_type_desc_custom_11);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_12", updateEmployeeTypes.s_employee_type_name_custom_12);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_12", updateEmployeeTypes.s_employee_type_desc_custom_12);
           htUpdateEmployeeTypes.Add("@s_employee_type_name_custom_13", updateEmployeeTypes.s_employee_type_name_custom_13);
           htUpdateEmployeeTypes.Add("@s_employee_type_desc_custom_13", updateEmployeeTypes.s_employee_type_desc_custom_13);

           try
           {
               return DataProxy.FetchSPOutput("s_sp_update_employee_types", htUpdateEmployeeTypes);
           }
           catch (Exception)
           {
               throw;
           }
       }

       public static DataTable SearchEmployeeTypes(SystemEmployeeType employeeType)
       {
           Hashtable htEmployeeType = new Hashtable();
           htEmployeeType.Add("@s_employee_type_id", employeeType.s_employee_type_id);
           htEmployeeType.Add("@s_employee_type_name_us_english", employeeType.s_employee_type_name_us_english);


           if (employeeType.s_employee_type_status_id_fk == "0")
               htEmployeeType.Add("@s_employee_type_status_id_fk", DBNull.Value);
           else
               htEmployeeType.Add("@s_employee_type_status_id_fk", employeeType.s_employee_type_status_id_fk);

           try
           {
               return DataProxy.FetchDataTable("s_sp_employee_type_search", htEmployeeType);
           }
           catch (Exception)
           {
               throw;
           }

       }

       public static int UpdateEmployeeTypeStatus(string s_employee_type_system_id_pk)
       {
           Hashtable htUpdateDomainStatus = new Hashtable();
           htUpdateDomainStatus.Add("@s_employee_type_system_id_pk", s_employee_type_system_id_pk);
           try
           {
               return DataProxy.FetchSPOutput("s_sp_update_employee_type_status", htUpdateDomainStatus);
           }
           catch (Exception)
           {
               throw;
           }
       }
    }
}
