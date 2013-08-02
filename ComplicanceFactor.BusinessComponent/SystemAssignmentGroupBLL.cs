using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemAssignmentGroupBLL
    {
        

        
        /// <summary>
        /// Get status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
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
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
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


        public static int CreateAssignmentGroup(SystemAssingnmentGroup createAssignmentGroup)
        {
            Hashtable htCreateAssignmentGroup = new Hashtable();
            htCreateAssignmentGroup.Add("@s_assignment_group_system_id_pk", createAssignmentGroup.s_assignment_group_system_id_pk);
            htCreateAssignmentGroup.Add("@s_assignment_group_id", createAssignmentGroup.s_assignment_group_id);
            if (createAssignmentGroup.s_assignment_group_status_id_fk == "0")
            {
                htCreateAssignmentGroup.Add("@s_assignment_group_status_id_fk", DBNull.Value);
            }
            else
            {
                htCreateAssignmentGroup.Add("@s_assignment_group_status_id_fk", createAssignmentGroup.s_assignment_group_status_id_fk);
            }
            htCreateAssignmentGroup.Add("@s_assignment_group_name_us_english", createAssignmentGroup.s_assignment_group_name_us_english);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_us_english", createAssignmentGroup.s_assignment_group_desc_us_english);
            htCreateAssignmentGroup.Add("s_assignment_group_name_uk_english", createAssignmentGroup.s_assignment_group_name_uk_english);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_uk_english", createAssignmentGroup.s_assignment_group_desc_uk_english);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_ca_france", createAssignmentGroup.s_assignment_group_name_ca_france);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_ca_france", createAssignmentGroup.s_assignment_group_desc_ca_france);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_fr_french", createAssignmentGroup.s_assignment_group_name_fr_french);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_fr_french", createAssignmentGroup.s_assignment_group_desc_fr_french);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_mx_spanish", createAssignmentGroup.s_assignment_group_name_mx_spanish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_mx_spanish", createAssignmentGroup.s_assignment_group_desc_mx_spanish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_sp_spanish", createAssignmentGroup.s_assignment_group_name_sp_spanish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_sp_spanish", createAssignmentGroup.s_assignment_group_desc_sp_spanish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_portuguse", createAssignmentGroup.s_assignment_group_name_portuguse);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_portuguse", createAssignmentGroup.s_assignment_group_desc_portuguse);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_chinese", createAssignmentGroup.s_assignment_group_name_chinese);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_chinese", createAssignmentGroup.s_assignment_group_desc_chinese);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_german", createAssignmentGroup.s_assignment_group_name_german);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_german", createAssignmentGroup.s_assignment_group_desc_german);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_japanese", createAssignmentGroup.s_assignment_group_name_japanese);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_japanese", createAssignmentGroup.s_assignment_group_desc_japanese);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_russian", createAssignmentGroup.s_assignment_group_name_russian);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_russian", createAssignmentGroup.s_assignment_group_desc_russian);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_danish", createAssignmentGroup.s_assignment_group_name_danish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_danish", createAssignmentGroup.s_assignment_group_desc_danish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_polish", createAssignmentGroup.s_assignment_group_name_polish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_polish", createAssignmentGroup.s_assignment_group_desc_polish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_swedish", createAssignmentGroup.s_assignment_group_name_swedish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_swedish", createAssignmentGroup.s_assignment_group_desc_swedish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_finnish", createAssignmentGroup.s_assignment_group_name_finnish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_finnish", createAssignmentGroup.s_assignment_group_desc_finnish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_korean", createAssignmentGroup.s_assignment_group_name_korean);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_korean", createAssignmentGroup.s_assignment_group_desc_korean);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_italian", createAssignmentGroup.s_assignment_group_name_italian);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_italian", createAssignmentGroup.s_assignment_group_desc_italian);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_dutch", createAssignmentGroup.s_assignment_group_name_dutch);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_dutch", createAssignmentGroup.s_assignment_group_desc_dutch);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_indonesian", createAssignmentGroup.s_assignment_group_name_indonesian);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_indonesian", createAssignmentGroup.s_assignment_group_desc_indonesian);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_greek", createAssignmentGroup.s_assignment_group_name_greek);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_greek", createAssignmentGroup.s_assignment_group_desc_greek);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_hungarian", createAssignmentGroup.s_assignment_group_name_hungarian);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_hungarian", createAssignmentGroup.s_assignment_group_desc_hungarian);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_norwegian", createAssignmentGroup.s_assignment_group_name_norwegian);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_norwegian", createAssignmentGroup.s_assignment_group_desc_norwegian);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_turkish", createAssignmentGroup.s_assignment_group_name_turkish);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_turkish", createAssignmentGroup.s_assignment_group_desc_turkish);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_arabic", createAssignmentGroup.s_assignment_group_name_arabic);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_arabic", createAssignmentGroup.s_assignment_group_desc_arabic);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_01", createAssignmentGroup.s_assignment_group_name_custom_01);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_01", createAssignmentGroup.s_assignment_group_desc_custom_01);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_02", createAssignmentGroup.s_assignment_group_name_custom_02);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_02", createAssignmentGroup.s_assignment_group_desc_custom_02);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_03", createAssignmentGroup.s_assignment_group_name_custom_03);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_03", createAssignmentGroup.s_assignment_group_desc_custom_03);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_04", createAssignmentGroup.s_assignment_group_name_custom_04);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_04", createAssignmentGroup.s_assignment_group_desc_custom_04);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_05", createAssignmentGroup.s_assignment_group_name_custom_05);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_05", createAssignmentGroup.s_assignment_group_desc_custom_05);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_06", createAssignmentGroup.s_assignment_group_name_custom_06);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_06", createAssignmentGroup.s_assignment_group_desc_custom_06);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_07", createAssignmentGroup.s_assignment_group_name_custom_07);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_07", createAssignmentGroup.s_assignment_group_desc_custom_07);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_08", createAssignmentGroup.s_assignment_group_name_custom_08);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_08", createAssignmentGroup.s_assignment_group_desc_custom_08);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_09", createAssignmentGroup.s_assignment_group_name_custom_09);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_09", createAssignmentGroup.s_assignment_group_desc_custom_09);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_10", createAssignmentGroup.s_assignment_group_name_custom_10);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_10", createAssignmentGroup.s_assignment_group_desc_custom_10);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_11", createAssignmentGroup.s_assignment_group_name_custom_11);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_11", createAssignmentGroup.s_assignment_group_desc_custom_11);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_12", createAssignmentGroup.s_assignment_group_name_custom_12);
            htCreateAssignmentGroup.Add("@s_assignment_group_desc_custom_12", createAssignmentGroup.s_assignment_group_desc_custom_12);
            htCreateAssignmentGroup.Add("@s_assignment_group_name_custom_13", createAssignmentGroup.s_assignment_group_name_custom_13);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_assignment_groups", htCreateAssignmentGroup);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemAssingnmentGroup GetAssignmentGroup(string s_assignment_group_system_id_pk)
        {
            SystemAssingnmentGroup AssignmentGroup;
            try
            {
                Hashtable htGetAssignmentGroup=new Hashtable();
                htGetAssignmentGroup.Add("@s_assignment_group_system_id_pk", s_assignment_group_system_id_pk);
                AssignmentGroup = new SystemAssingnmentGroup();

                //DataTable dtGetAssignmentGroup = DataProxy.FetchDataTable("***STORED PROCEDURE TO GET THE SELECTED SCHEME***", htGetAssignmentGroup);
                DataTable dtGetAssignmentGroup = DataProxy.FetchDataTable("s_sp_get_grading_shemes", htGetAssignmentGroup);

                AssignmentGroup.s_assignment_group_system_id_pk = dtGetAssignmentGroup.Rows[0]["s_assignment_group_system_id_pk"].ToString();
                AssignmentGroup.s_assignment_group_id=dtGetAssignmentGroup.Rows[0]["s_assignment_group_id"].ToString();
                AssignmentGroup.s_assignment_group_status_id_fk=dtGetAssignmentGroup.Rows[0]["s_assignment_group_status_id_fk"].ToString();
                AssignmentGroup.s_assignment_group_name_us_english = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_us_english"].ToString();
                AssignmentGroup.s_assignment_group_desc_us_english = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_us_english"].ToString();
                AssignmentGroup.s_assignment_group_name_uk_english = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_uk_english"].ToString();
                AssignmentGroup.s_assignment_group_desc_uk_english = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_uk_english"].ToString();
                AssignmentGroup.s_assignment_group_name_ca_france = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_ca_france"].ToString();
                AssignmentGroup.s_assignment_group_desc_ca_france = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_ca_france"].ToString();
                AssignmentGroup.s_assignment_group_name_fr_french = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_fr_french"].ToString();
                AssignmentGroup.s_assignment_group_desc_fr_french = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_fr_french"].ToString();
                AssignmentGroup.s_assignment_group_name_mx_spanish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_mx_spanish"].ToString();
                AssignmentGroup.s_assignment_group_desc_mx_spanish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_mx_spanish"].ToString();
                AssignmentGroup.s_assignment_group_name_sp_spanish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_sp_spanish"].ToString();
                AssignmentGroup.s_assignment_group_desc_sp_spanish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_sp_spanish"].ToString();
                AssignmentGroup.s_assignment_group_name_portuguse = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_portuguse"].ToString();
                AssignmentGroup.s_assignment_group_desc_portuguse = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_portuguse"].ToString();
                AssignmentGroup.s_assignment_group_name_chinese = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_chinese"].ToString();
                AssignmentGroup.s_assignment_group_desc_chinese = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_chinese"].ToString();
                AssignmentGroup.s_assignment_group_name_german = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_german"].ToString();
                AssignmentGroup.s_assignment_group_desc_german = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_german"].ToString();
                AssignmentGroup.s_assignment_group_name_japanese = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_japanese"].ToString();
                AssignmentGroup.s_assignment_group_desc_japanese = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_japanese"].ToString();
                AssignmentGroup.s_assignment_group_name_russian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_russian"].ToString();
                AssignmentGroup.s_assignment_group_desc_russian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_russian"].ToString();
                AssignmentGroup.s_assignment_group_name_danish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_danish"].ToString();
                AssignmentGroup.s_assignment_group_desc_danish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_danish"].ToString();
                AssignmentGroup.s_assignment_group_name_polish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_polish"].ToString();
                AssignmentGroup.s_assignment_group_desc_polish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_polish"].ToString();
                AssignmentGroup.s_assignment_group_name_swedish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_swedish"].ToString();
                AssignmentGroup.s_assignment_group_desc_swedish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_swedish"].ToString();
                AssignmentGroup.s_assignment_group_name_finnish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_finnish"].ToString();
                AssignmentGroup.s_assignment_group_desc_finnish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_finnish"].ToString();
                AssignmentGroup.s_assignment_group_name_korean = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_korean"].ToString();
                AssignmentGroup.s_assignment_group_desc_korean = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_korean"].ToString();
                AssignmentGroup.s_assignment_group_name_italian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_italian"].ToString();
                AssignmentGroup.s_assignment_group_desc_italian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_italian"].ToString();
                AssignmentGroup.s_assignment_group_name_dutch = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_dutch"].ToString();
                AssignmentGroup.s_assignment_group_desc_dutch = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_dutch"].ToString();
                AssignmentGroup.s_assignment_group_name_indonesian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_indonesian"].ToString();
                AssignmentGroup.s_assignment_group_desc_indonesian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_indonesian"].ToString();
                AssignmentGroup.s_assignment_group_name_greek = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_greek"].ToString();
                AssignmentGroup.s_assignment_group_desc_greek = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_greek"].ToString();
                AssignmentGroup.s_assignment_group_name_hungarian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_hungarian"].ToString();
                AssignmentGroup.s_assignment_group_desc_hungarian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_hungarian"].ToString();
                AssignmentGroup.s_assignment_group_name_norwegian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_norwegian"].ToString();
                AssignmentGroup.s_assignment_group_desc_norwegian = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_norwegian"].ToString();
                AssignmentGroup.s_assignment_group_name_turkish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_turkish"].ToString();
                AssignmentGroup.s_assignment_group_desc_turkish = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_turkish"].ToString();
                AssignmentGroup.s_assignment_group_name_arabic = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_arabic"].ToString();
                AssignmentGroup.s_assignment_group_desc_arabic = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_arabic"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_01 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_01"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_01 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_01"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_02 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_02"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_02 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_02"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_03 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_03"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_03 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_03"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_04 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_04"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_04 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_04"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_05 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_05"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_05 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_05"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_06 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_06"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_06 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_06"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_07 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_07"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_07 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_07"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_08 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_08"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_08 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_08"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_09 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_09"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_09 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_09"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_10 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_10"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_10 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_10"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_11 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_11"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_11 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_11"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_12 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_12"].ToString();
                AssignmentGroup.s_assignment_group_desc_custom_12 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_desc_custom_12"].ToString();
                AssignmentGroup.s_assignment_group_name_custom_13 = dtGetAssignmentGroup.Rows[0]["s_assignment_group_name_custom_13"].ToString();
                return AssignmentGroup;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static int UpdateAssignmentGroup(SystemAssingnmentGroup updateAssignmentGroup)
        {
            Hashtable htUpdateAssignmentGroup=new Hashtable();
            htUpdateAssignmentGroup.Add("@s_assignment_group_system_id_pk", updateAssignmentGroup.s_assignment_group_system_id_pk);
            htUpdateAssignmentGroup.Add("@s_assignment_group_id", updateAssignmentGroup.s_assignment_group_id);
            htUpdateAssignmentGroup.Add("@s_assignment_group_status_id_fk", updateAssignmentGroup.s_assignment_group_status_id_fk);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_us_english", updateAssignmentGroup.s_assignment_group_name_us_english);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_us_english", updateAssignmentGroup.s_assignment_group_desc_us_english);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_uk_english", updateAssignmentGroup.s_assignment_group_name_uk_english);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_uk_english", updateAssignmentGroup.s_assignment_group_desc_uk_english);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_ca_france", updateAssignmentGroup.s_assignment_group_name_ca_france);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_ca_france", updateAssignmentGroup.s_assignment_group_desc_ca_france);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_fr_french", updateAssignmentGroup.s_assignment_group_name_fr_french);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_fr_french", updateAssignmentGroup.s_assignment_group_desc_fr_french);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_mx_spanish", updateAssignmentGroup.s_assignment_group_name_mx_spanish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_mx_spanish", updateAssignmentGroup.s_assignment_group_desc_mx_spanish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_sp_spanish", updateAssignmentGroup.s_assignment_group_name_sp_spanish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_sp_spanish", updateAssignmentGroup.s_assignment_group_desc_sp_spanish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_portuguse", updateAssignmentGroup.s_assignment_group_name_portuguse);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_portuguse", updateAssignmentGroup.s_assignment_group_desc_portuguse);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_chinese", updateAssignmentGroup.s_assignment_group_name_chinese);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_chinese", updateAssignmentGroup.s_assignment_group_desc_chinese);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_german", updateAssignmentGroup.s_assignment_group_name_german);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_german", updateAssignmentGroup.s_assignment_group_desc_german);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_japanese", updateAssignmentGroup.s_assignment_group_name_japanese);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_japanese", updateAssignmentGroup.s_assignment_group_desc_japanese);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_russian", updateAssignmentGroup.s_assignment_group_name_russian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_russian", updateAssignmentGroup.s_assignment_group_desc_russian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_danish", updateAssignmentGroup.s_assignment_group_name_danish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_danish", updateAssignmentGroup.s_assignment_group_desc_danish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_polish", updateAssignmentGroup.s_assignment_group_name_polish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_polish", updateAssignmentGroup.s_assignment_group_desc_polish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_swedish", updateAssignmentGroup.s_assignment_group_name_swedish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_swedish", updateAssignmentGroup.s_assignment_group_desc_swedish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_finnish", updateAssignmentGroup.s_assignment_group_name_finnish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_finnish", updateAssignmentGroup.s_assignment_group_desc_finnish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_korean", updateAssignmentGroup.s_assignment_group_name_korean);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_korean", updateAssignmentGroup.s_assignment_group_desc_korean);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_italian", updateAssignmentGroup.s_assignment_group_name_italian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_italian", updateAssignmentGroup.s_assignment_group_desc_italian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_dutch", updateAssignmentGroup.s_assignment_group_name_dutch);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_dutch", updateAssignmentGroup.s_assignment_group_desc_dutch);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_indonesian", updateAssignmentGroup.s_assignment_group_name_indonesian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_indonesian", updateAssignmentGroup.s_assignment_group_desc_indonesian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_greek", updateAssignmentGroup.s_assignment_group_name_greek);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_greek", updateAssignmentGroup.s_assignment_group_desc_greek);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_hungarian", updateAssignmentGroup.s_assignment_group_name_hungarian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_hungarian", updateAssignmentGroup.s_assignment_group_desc_hungarian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_norwegian", updateAssignmentGroup.s_assignment_group_name_norwegian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_norwegian", updateAssignmentGroup.s_assignment_group_desc_norwegian);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_turkish", updateAssignmentGroup.s_assignment_group_name_turkish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_turkish", updateAssignmentGroup.s_assignment_group_desc_turkish);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_arabic", updateAssignmentGroup.s_assignment_group_name_arabic);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_arabic", updateAssignmentGroup.s_assignment_group_desc_arabic);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_01", updateAssignmentGroup.s_assignment_group_name_custom_01);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_01", updateAssignmentGroup.s_assignment_group_desc_custom_01);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_02", updateAssignmentGroup.s_assignment_group_name_custom_02);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_02", updateAssignmentGroup.s_assignment_group_desc_custom_02);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_03", updateAssignmentGroup.s_assignment_group_name_custom_03);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_03", updateAssignmentGroup.s_assignment_group_desc_custom_03);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_04", updateAssignmentGroup.s_assignment_group_name_custom_04);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_04", updateAssignmentGroup.s_assignment_group_desc_custom_04);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_05", updateAssignmentGroup.s_assignment_group_name_custom_05);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_05", updateAssignmentGroup.s_assignment_group_desc_custom_05);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_06", updateAssignmentGroup.s_assignment_group_name_custom_06);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_06", updateAssignmentGroup.s_assignment_group_desc_custom_06);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_07", updateAssignmentGroup.s_assignment_group_name_custom_07);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_07", updateAssignmentGroup.s_assignment_group_desc_custom_07);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_08", updateAssignmentGroup.s_assignment_group_name_custom_08);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_08", updateAssignmentGroup.s_assignment_group_desc_custom_08);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_09", updateAssignmentGroup.s_assignment_group_name_custom_09);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_09", updateAssignmentGroup.s_assignment_group_desc_custom_09);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_10", updateAssignmentGroup.s_assignment_group_name_custom_10);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_10", updateAssignmentGroup.s_assignment_group_desc_custom_10);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_11", updateAssignmentGroup.s_assignment_group_name_custom_11);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_11", updateAssignmentGroup.s_assignment_group_desc_custom_11);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_12", updateAssignmentGroup.s_assignment_group_name_custom_12);
            htUpdateAssignmentGroup.Add("@s_assignment_group_desc_custom_12", updateAssignmentGroup.s_assignment_group_desc_custom_12);
            htUpdateAssignmentGroup.Add("@s_assignment_group_name_custom_13", updateAssignmentGroup.s_assignment_group_name_custom_13);


            try
            {
                //return DataProxy.FetchSPOutput("***PROCEDURE NAME TO UPDATE GRADING SCHEME****", htUpdateAssignmentGroup);
                return DataProxy.FetchSPOutput("s_sp_update_assignment_groups", htUpdateAssignmentGroup);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static DataTable GetSearchAssignmentGroup(SystemAssingnmentGroup serachAssignmentGroup)
        {

            try
            {
                Hashtable htGetSearchAssignmentGroup = new Hashtable();
                htGetSearchAssignmentGroup.Add("@s_assignment_group_id", serachAssignmentGroup.s_assignment_group_id);
                htGetSearchAssignmentGroup.Add("@s_assignment_group_name_us_english", serachAssignmentGroup.s_assignment_group_name_us_english);
                if (serachAssignmentGroup.s_assignment_group_status_id_fk == "0")
                {
                    htGetSearchAssignmentGroup.Add("@s_assignment_group_status_id_fk", DBNull.Value);
                }
                else
                {
                    htGetSearchAssignmentGroup.Add("@s_assignment_group_status_id_fk", serachAssignmentGroup.s_assignment_group_status_id_fk);
                }
                
                return DataProxy.FetchDataTable("s_sp_search_assignment_groups", htGetSearchAssignmentGroup);
            }
          
            catch (Exception)
            {
                throw;
            }


        }

        public static int DeleteAssignmentGroupValues(string s_assignment_group_system_value_id_pk)
        {
            Hashtable htDeleteAssignmentGroup = new Hashtable();
            htDeleteAssignmentGroup.Add("@s_assignment_group_system_value_id_pk", s_assignment_group_system_value_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_AssignmentGroup_value", htDeleteAssignmentGroup);
            }
            catch(Exception)
            {
                throw;
            }

        }
        
        public static int UpdateAssignmentGrouptatus(string s_assignment_group_system_id_pk)
        {
            Hashtable htUpdateAssignmentGrouptatus = new Hashtable();
            htUpdateAssignmentGrouptatus.Add("@s_assignment_group_system_id_pk", s_assignment_group_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_assignment_group_status", htUpdateAssignmentGrouptatus);

            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}
