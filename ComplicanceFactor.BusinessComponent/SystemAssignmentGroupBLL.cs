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
        /// <summary>
        /// Create Assignment group
        /// </summary>
        /// <param name="createAssignmentGroup"></param>
        /// <returns></returns>
        public static int CreateAssignmentGroup(SystemAssingnmentGroup createAssignmentGroup)
        {
            Hashtable htCreateAssignmentGroup = new Hashtable();
            htCreateAssignmentGroup.Add("@u_assignment_group_system_id_pk", createAssignmentGroup.u_assignment_group_system_id_pk);
            htCreateAssignmentGroup.Add("@u_assignment_group_id_pk", createAssignmentGroup.u_assignment_group_id_pk);
            if (createAssignmentGroup.u_assignment_group_status_id_fk == "0")
            {
                htCreateAssignmentGroup.Add("@u_assignment_group_status_id_fk", DBNull.Value);
            }
            else
            {
                htCreateAssignmentGroup.Add("@u_assignment_group_status_id_fk", createAssignmentGroup.u_assignment_group_status_id_fk);
            }
            htCreateAssignmentGroup.Add("@u_assignment_group_name", createAssignmentGroup.u_assignment_group_name);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc", createAssignmentGroup.u_assignment_group_desc);
            htCreateAssignmentGroup.Add("u_assignment_group_name_uk_english", createAssignmentGroup.u_assignment_group_name_uk_english);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_uk_english", createAssignmentGroup.u_assignment_group_desc_uk_english);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_ca_france", createAssignmentGroup.u_assignment_group_name_ca_france);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_ca_france", createAssignmentGroup.u_assignment_group_desc_ca_france);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_fr_french", createAssignmentGroup.u_assignment_group_name_fr_french);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_fr_french", createAssignmentGroup.u_assignment_group_desc_fr_french);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_mx_spanish", createAssignmentGroup.u_assignment_group_name_mx_spanish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_mx_spanish", createAssignmentGroup.u_assignment_group_desc_mx_spanish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_sp_spanish", createAssignmentGroup.u_assignment_group_name_sp_spanish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_sp_spanish", createAssignmentGroup.u_assignment_group_desc_sp_spanish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_portuguse", createAssignmentGroup.u_assignment_group_name_portuguse);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_portuguse", createAssignmentGroup.u_assignment_group_desc_portuguse);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_chinese", createAssignmentGroup.u_assignment_group_name_chinese);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_chinese", createAssignmentGroup.u_assignment_group_desc_chinese);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_german", createAssignmentGroup.u_assignment_group_name_german);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_german", createAssignmentGroup.u_assignment_group_desc_german);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_japanese", createAssignmentGroup.u_assignment_group_name_japanese);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_japanese", createAssignmentGroup.u_assignment_group_desc_japanese);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_russian", createAssignmentGroup.u_assignment_group_name_russian);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_russian", createAssignmentGroup.u_assignment_group_desc_russian);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_danish", createAssignmentGroup.u_assignment_group_name_danish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_danish", createAssignmentGroup.u_assignment_group_desc_danish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_polish", createAssignmentGroup.u_assignment_group_name_polish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_polish", createAssignmentGroup.u_assignment_group_desc_polish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_swedish", createAssignmentGroup.u_assignment_group_name_swedish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_swedish", createAssignmentGroup.u_assignment_group_desc_swedish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_finnish", createAssignmentGroup.u_assignment_group_name_finnish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_finnish", createAssignmentGroup.u_assignment_group_desc_finnish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_korean", createAssignmentGroup.u_assignment_group_name_korean);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_korean", createAssignmentGroup.u_assignment_group_desc_korean);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_italian", createAssignmentGroup.u_assignment_group_name_italian);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_italian", createAssignmentGroup.u_assignment_group_desc_italian);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_dutch", createAssignmentGroup.u_assignment_group_name_dutch);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_dutch", createAssignmentGroup.u_assignment_group_desc_dutch);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_indonesian", createAssignmentGroup.u_assignment_group_name_indonesian);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_indonesian", createAssignmentGroup.u_assignment_group_desc_indonesian);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_greek", createAssignmentGroup.u_assignment_group_name_greek);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_greek", createAssignmentGroup.u_assignment_group_desc_greek);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_hungarian", createAssignmentGroup.u_assignment_group_name_hungarian);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_hungarian", createAssignmentGroup.u_assignment_group_desc_hungarian);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_norwegian", createAssignmentGroup.u_assignment_group_name_norwegian);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_norwegian", createAssignmentGroup.u_assignment_group_desc_norwegian);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_turkish", createAssignmentGroup.u_assignment_group_name_turkish);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_turkish", createAssignmentGroup.u_assignment_group_desc_turkish);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_arabic", createAssignmentGroup.u_assignment_group_name_arabic);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_arabic", createAssignmentGroup.u_assignment_group_desc_arabic);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_01", createAssignmentGroup.u_assignment_group_name_custom_01);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_01", createAssignmentGroup.u_assignment_group_desc_custom_01);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_02", createAssignmentGroup.u_assignment_group_name_custom_02);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_02", createAssignmentGroup.u_assignment_group_desc_custom_02);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_03", createAssignmentGroup.u_assignment_group_name_custom_03);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_03", createAssignmentGroup.u_assignment_group_desc_custom_03);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_04", createAssignmentGroup.u_assignment_group_name_custom_04);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_04", createAssignmentGroup.u_assignment_group_desc_custom_04);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_05", createAssignmentGroup.u_assignment_group_name_custom_05);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_05", createAssignmentGroup.u_assignment_group_desc_custom_05);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_06", createAssignmentGroup.u_assignment_group_name_custom_06);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_06", createAssignmentGroup.u_assignment_group_desc_custom_06);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_07", createAssignmentGroup.u_assignment_group_name_custom_07);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_07", createAssignmentGroup.u_assignment_group_desc_custom_07);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_08", createAssignmentGroup.u_assignment_group_name_custom_08);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_08", createAssignmentGroup.u_assignment_group_desc_custom_08);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_09", createAssignmentGroup.u_assignment_group_name_custom_09);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_09", createAssignmentGroup.u_assignment_group_desc_custom_09);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_10", createAssignmentGroup.u_assignment_group_name_custom_10);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_10", createAssignmentGroup.u_assignment_group_desc_custom_10);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_11", createAssignmentGroup.u_assignment_group_name_custom_11);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_11", createAssignmentGroup.u_assignment_group_desc_custom_11);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_12", createAssignmentGroup.u_assignment_group_name_custom_12);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_12", createAssignmentGroup.u_assignment_group_desc_custom_12);
            htCreateAssignmentGroup.Add("@u_assignment_group_name_custom_13", createAssignmentGroup.u_assignment_group_name_custom_13);
            htCreateAssignmentGroup.Add("@u_assignment_group_desc_custom_13", createAssignmentGroup.u_assignment_group_name_custom_13);
            if (createAssignmentGroup.assignment_parameters != null)
            {
                htCreateAssignmentGroup.Add("@assignment_parameters", createAssignmentGroup.assignment_parameters);
            }
            else
            {
                htCreateAssignmentGroup.Add("@assignment_parameters", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("e_sp_insert_assignment_group", htCreateAssignmentGroup);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get assignment group
        /// </summary>
        /// <param name="u_assignment_group_system_id_pk"></param>
        /// <returns></returns>
        public static SystemAssingnmentGroup GetAssignmentGroup(string u_assignment_group_system_id_pk)
        {
            SystemAssingnmentGroup AssignmentGroup;
            try
            {
                Hashtable htGetAssignmentGroup = new Hashtable();
                htGetAssignmentGroup.Add("@u_assignment_group_system_id_pk", u_assignment_group_system_id_pk);
                AssignmentGroup = new SystemAssingnmentGroup();

                DataTable dtGetAssignmentGroup = DataProxy.FetchDataTable("e_sp_get_assignment_group", htGetAssignmentGroup);
                AssignmentGroup.u_assignment_group_system_id_pk = dtGetAssignmentGroup.Rows[0]["u_assignment_group_system_id_pk"].ToString();
                AssignmentGroup.u_assignment_group_id_pk = dtGetAssignmentGroup.Rows[0]["u_assignment_group_id_pk"].ToString();
                AssignmentGroup.u_assignment_group_status_id_fk = dtGetAssignmentGroup.Rows[0]["u_assignment_group_status_id_fk"].ToString();
                AssignmentGroup.u_assignment_group_name = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name"].ToString();
                AssignmentGroup.u_assignment_group_desc = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc"].ToString();
                AssignmentGroup.u_assignment_group_name_uk_english = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_uk_english"].ToString();
                AssignmentGroup.u_assignment_group_desc_uk_english = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_uk_english"].ToString();
                AssignmentGroup.u_assignment_group_name_ca_france = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_ca_france"].ToString();
                AssignmentGroup.u_assignment_group_desc_ca_france = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_ca_france"].ToString();
                AssignmentGroup.u_assignment_group_name_fr_french = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_fr_french"].ToString();
                AssignmentGroup.u_assignment_group_desc_fr_french = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_fr_french"].ToString();
                AssignmentGroup.u_assignment_group_name_mx_spanish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_mx_spanish"].ToString();
                AssignmentGroup.u_assignment_group_desc_mx_spanish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_mx_spanish"].ToString();
                AssignmentGroup.u_assignment_group_name_sp_spanish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_sp_spanish"].ToString();
                AssignmentGroup.u_assignment_group_desc_sp_spanish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_sp_spanish"].ToString();
                AssignmentGroup.u_assignment_group_name_portuguse = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_portuguse"].ToString();
                AssignmentGroup.u_assignment_group_desc_portuguse = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_portuguse"].ToString();
                AssignmentGroup.u_assignment_group_name_chinese = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_chinese"].ToString();
                AssignmentGroup.u_assignment_group_desc_chinese = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_chinese"].ToString();
                AssignmentGroup.u_assignment_group_name_german = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_german"].ToString();
                AssignmentGroup.u_assignment_group_desc_german = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_german"].ToString();
                AssignmentGroup.u_assignment_group_name_japanese = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_japanese"].ToString();
                AssignmentGroup.u_assignment_group_desc_japanese = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_japanese"].ToString();
                AssignmentGroup.u_assignment_group_name_russian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_russian"].ToString();
                AssignmentGroup.u_assignment_group_desc_russian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_russian"].ToString();
                AssignmentGroup.u_assignment_group_name_danish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_danish"].ToString();
                AssignmentGroup.u_assignment_group_desc_danish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_danish"].ToString();
                AssignmentGroup.u_assignment_group_name_polish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_polish"].ToString();
                AssignmentGroup.u_assignment_group_desc_polish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_polish"].ToString();
                AssignmentGroup.u_assignment_group_name_swedish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_swedish"].ToString();
                AssignmentGroup.u_assignment_group_desc_swedish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_swedish"].ToString();
                AssignmentGroup.u_assignment_group_name_finnish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_finnish"].ToString();
                AssignmentGroup.u_assignment_group_desc_finnish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_finnish"].ToString();
                AssignmentGroup.u_assignment_group_name_korean = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_korean"].ToString();
                AssignmentGroup.u_assignment_group_desc_korean = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_korean"].ToString();
                AssignmentGroup.u_assignment_group_name_italian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_italian"].ToString();
                AssignmentGroup.u_assignment_group_desc_italian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_italian"].ToString();
                AssignmentGroup.u_assignment_group_name_dutch = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_dutch"].ToString();
                AssignmentGroup.u_assignment_group_desc_dutch = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_dutch"].ToString();
                AssignmentGroup.u_assignment_group_name_indonesian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_indonesian"].ToString();
                AssignmentGroup.u_assignment_group_desc_indonesian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_indonesian"].ToString();
                AssignmentGroup.u_assignment_group_name_greek = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_greek"].ToString();
                AssignmentGroup.u_assignment_group_desc_greek = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_greek"].ToString();
                AssignmentGroup.u_assignment_group_name_hungarian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_hungarian"].ToString();
                AssignmentGroup.u_assignment_group_desc_hungarian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_hungarian"].ToString();
                AssignmentGroup.u_assignment_group_name_norwegian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_norwegian"].ToString();
                AssignmentGroup.u_assignment_group_desc_norwegian = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_norwegian"].ToString();
                AssignmentGroup.u_assignment_group_name_turkish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_turkish"].ToString();
                AssignmentGroup.u_assignment_group_desc_turkish = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_turkish"].ToString();
                AssignmentGroup.u_assignment_group_name_arabic = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_arabic"].ToString();
                AssignmentGroup.u_assignment_group_desc_arabic = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_arabic"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_01 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_01"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_01 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_01"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_02 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_02"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_02 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_02"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_03 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_03"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_03 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_03"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_04 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_04"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_04 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_04"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_05 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_05"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_05 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_05"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_06 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_06"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_06 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_06"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_07 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_07"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_07 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_07"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_08 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_08"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_08 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_08"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_09 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_09"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_09 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_09"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_10 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_10"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_10 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_10"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_11 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_11"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_11 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_11"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_12 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_12"].ToString();
                AssignmentGroup.u_assignment_group_desc_custom_12 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_desc_custom_12"].ToString();
                AssignmentGroup.u_assignment_group_name_custom_13 = dtGetAssignmentGroup.Rows[0]["u_assignment_group_name_custom_13"].ToString();
                return AssignmentGroup;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Assignment group
        /// </summary>
        /// <param name="updateAssignmentGroup"></param>
        /// <returns></returns>
        public static int UpdateAssignmentGroup(SystemAssingnmentGroup updateAssignmentGroup)
        {
            Hashtable htUpdateAssignmentGroup = new Hashtable();
            htUpdateAssignmentGroup.Add("@u_assignment_group_system_id_pk", updateAssignmentGroup.u_assignment_group_system_id_pk);
            htUpdateAssignmentGroup.Add("@u_assignment_group_id_pk", updateAssignmentGroup.u_assignment_group_id_pk);
            htUpdateAssignmentGroup.Add("@u_assignment_group_status_id_fk", updateAssignmentGroup.u_assignment_group_status_id_fk);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name", updateAssignmentGroup.u_assignment_group_name);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc", updateAssignmentGroup.u_assignment_group_desc);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_uk_english", updateAssignmentGroup.u_assignment_group_name_uk_english);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_uk_english", updateAssignmentGroup.u_assignment_group_desc_uk_english);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_ca_france", updateAssignmentGroup.u_assignment_group_name_ca_france);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_ca_france", updateAssignmentGroup.u_assignment_group_desc_ca_france);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_fr_french", updateAssignmentGroup.u_assignment_group_name_fr_french);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_fr_french", updateAssignmentGroup.u_assignment_group_desc_fr_french);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_mx_spanish", updateAssignmentGroup.u_assignment_group_name_mx_spanish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_mx_spanish", updateAssignmentGroup.u_assignment_group_desc_mx_spanish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_sp_spanish", updateAssignmentGroup.u_assignment_group_name_sp_spanish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_sp_spanish", updateAssignmentGroup.u_assignment_group_desc_sp_spanish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_portuguse", updateAssignmentGroup.u_assignment_group_name_portuguse);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_portuguse", updateAssignmentGroup.u_assignment_group_desc_portuguse);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_chinese", updateAssignmentGroup.u_assignment_group_name_chinese);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_chinese", updateAssignmentGroup.u_assignment_group_desc_chinese);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_german", updateAssignmentGroup.u_assignment_group_name_german);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_german", updateAssignmentGroup.u_assignment_group_desc_german);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_japanese", updateAssignmentGroup.u_assignment_group_name_japanese);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_japanese", updateAssignmentGroup.u_assignment_group_desc_japanese);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_russian", updateAssignmentGroup.u_assignment_group_name_russian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_russian", updateAssignmentGroup.u_assignment_group_desc_russian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_danish", updateAssignmentGroup.u_assignment_group_name_danish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_danish", updateAssignmentGroup.u_assignment_group_desc_danish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_polish", updateAssignmentGroup.u_assignment_group_name_polish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_polish", updateAssignmentGroup.u_assignment_group_desc_polish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_swedish", updateAssignmentGroup.u_assignment_group_name_swedish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_swedish", updateAssignmentGroup.u_assignment_group_desc_swedish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_finnish", updateAssignmentGroup.u_assignment_group_name_finnish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_finnish", updateAssignmentGroup.u_assignment_group_desc_finnish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_korean", updateAssignmentGroup.u_assignment_group_name_korean);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_korean", updateAssignmentGroup.u_assignment_group_desc_korean);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_italian", updateAssignmentGroup.u_assignment_group_name_italian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_italian", updateAssignmentGroup.u_assignment_group_desc_italian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_dutch", updateAssignmentGroup.u_assignment_group_name_dutch);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_dutch", updateAssignmentGroup.u_assignment_group_desc_dutch);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_indonesian", updateAssignmentGroup.u_assignment_group_name_indonesian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_indonesian", updateAssignmentGroup.u_assignment_group_desc_indonesian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_greek", updateAssignmentGroup.u_assignment_group_name_greek);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_greek", updateAssignmentGroup.u_assignment_group_desc_greek);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_hungarian", updateAssignmentGroup.u_assignment_group_name_hungarian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_hungarian", updateAssignmentGroup.u_assignment_group_desc_hungarian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_norwegian", updateAssignmentGroup.u_assignment_group_name_norwegian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_norwegian", updateAssignmentGroup.u_assignment_group_desc_norwegian);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_turkish", updateAssignmentGroup.u_assignment_group_name_turkish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_turkish", updateAssignmentGroup.u_assignment_group_desc_turkish);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_arabic", updateAssignmentGroup.u_assignment_group_name_arabic);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_arabic", updateAssignmentGroup.u_assignment_group_desc_arabic);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_01", updateAssignmentGroup.u_assignment_group_name_custom_01);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_01", updateAssignmentGroup.u_assignment_group_desc_custom_01);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_02", updateAssignmentGroup.u_assignment_group_name_custom_02);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_02", updateAssignmentGroup.u_assignment_group_desc_custom_02);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_03", updateAssignmentGroup.u_assignment_group_name_custom_03);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_03", updateAssignmentGroup.u_assignment_group_desc_custom_03);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_04", updateAssignmentGroup.u_assignment_group_name_custom_04);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_04", updateAssignmentGroup.u_assignment_group_desc_custom_04);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_05", updateAssignmentGroup.u_assignment_group_name_custom_05);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_05", updateAssignmentGroup.u_assignment_group_desc_custom_05);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_06", updateAssignmentGroup.u_assignment_group_name_custom_06);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_06", updateAssignmentGroup.u_assignment_group_desc_custom_06);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_07", updateAssignmentGroup.u_assignment_group_name_custom_07);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_07", updateAssignmentGroup.u_assignment_group_desc_custom_07);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_08", updateAssignmentGroup.u_assignment_group_name_custom_08);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_08", updateAssignmentGroup.u_assignment_group_desc_custom_08);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_09", updateAssignmentGroup.u_assignment_group_name_custom_09);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_09", updateAssignmentGroup.u_assignment_group_desc_custom_09);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_10", updateAssignmentGroup.u_assignment_group_name_custom_10);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_10", updateAssignmentGroup.u_assignment_group_desc_custom_10);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_11", updateAssignmentGroup.u_assignment_group_name_custom_11);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_11", updateAssignmentGroup.u_assignment_group_desc_custom_11);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_12", updateAssignmentGroup.u_assignment_group_name_custom_12);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_12", updateAssignmentGroup.u_assignment_group_desc_custom_12);
            htUpdateAssignmentGroup.Add("@u_assignment_group_name_custom_13", updateAssignmentGroup.u_assignment_group_name_custom_13);
            htUpdateAssignmentGroup.Add("@u_assignment_group_desc_custom_13", updateAssignmentGroup.u_assignment_group_desc_custom_13);
            if (!string.IsNullOrEmpty(updateAssignmentGroup.assignment_parameters))
            {
                htUpdateAssignmentGroup.Add("@assignment_parameters", updateAssignmentGroup.assignment_parameters);
            }
            else
            {
                htUpdateAssignmentGroup.Add("@assignment_parameters", DBNull.Value);
            }
            
            try
            {
                return DataProxy.FetchSPOutput("e_sp_update_assignment_group", htUpdateAssignmentGroup);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Search assignment group
        /// </summary>
        /// <param name="serachAssignmentGroup"></param>
        /// <returns></returns>
        public static DataTable GetSearchAssignmentGroup(SystemAssingnmentGroup serachAssignmentGroup)
        {
            try
            {
                Hashtable htGetSearchAssignmentGroup = new Hashtable();
                htGetSearchAssignmentGroup.Add("@u_assignment_group_id_pk", serachAssignmentGroup.u_assignment_group_id_pk);
                htGetSearchAssignmentGroup.Add("@u_assignment_group_name", serachAssignmentGroup.u_assignment_group_name);
                if (serachAssignmentGroup.u_assignment_group_status_id_fk == "0")
                {
                    htGetSearchAssignmentGroup.Add("@u_assignment_group_status_id_fk", DBNull.Value);
                }
                else
                {
                    htGetSearchAssignmentGroup.Add("@u_assignment_group_status_id_fk", serachAssignmentGroup.u_assignment_group_status_id_fk);
                }

                return DataProxy.FetchDataTable("e_sp_search_assignment_group", htGetSearchAssignmentGroup);
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update assignment group status
        /// </summary>
        /// <param name="u_assignment_group_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateAssignmentGrouptatus(string u_assignment_group_system_id_pk)
        {
            Hashtable htUpdateAssignmentGrouptatus = new Hashtable();
            htUpdateAssignmentGrouptatus.Add("@u_assignment_group_system_id_pk", u_assignment_group_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_update_assignment_group_status", htUpdateAssignmentGrouptatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="addparam"></param>
        /// <returns></returns>
        public static int AddParameter(SystemAssingnmentGroup addparam)
        {
            Hashtable htParameter = new Hashtable();
            htParameter.Add("@u_assignment_group_id_fk", addparam.u_assignment_group_id_fk);
            htParameter.Add("@u_assignment_group_param_element_id_fk", addparam.u_assignment_group_param_element_id_fk);
            if (!string.IsNullOrEmpty(addparam.u_assignment_group_param_operator_id_fk))
            {
                htParameter.Add("@u_assignment_group_param_operator_id_fk", addparam.u_assignment_group_param_operator_id_fk);
            }
            else
            {
                htParameter.Add("@u_assignment_group_param_operator_id_fk", DBNull.Value);
            }
           
            if (!string.IsNullOrEmpty(addparam.u_assignment_group_param_values))
            {
                htParameter.Add("@u_assignment_group_param_values", addparam.u_assignment_group_param_values);
            }
            else
            {
                htParameter.Add("@u_assignment_group_param_values", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("e_sp_add_assignment_parameter", htParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Remove Parameter
        /// </summary>
        /// <param name="u_assignment_group_id_fk"></param>
        /// <param name="u_assignment_group_param_system_id_pk"></param>
        /// <returns></returns>
        public static int RemoveParameter(string u_assignment_group_id_fk, string u_assignment_group_param_system_id_pk)
        {
            Hashtable htRemoveParameter = new Hashtable();
            htRemoveParameter.Add("@u_assignment_group_id_fk",u_assignment_group_id_fk);
            htRemoveParameter.Add("@u_assignment_group_param_system_id_pk",u_assignment_group_param_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_remove_assignment_parameter",htRemoveParameter);
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get assignment Parameter
        /// </summary>
        /// <param name="u_assignment_group_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetAssignmentParameter(string u_assignment_group_id_fk)
        {
            Hashtable htGetAssignmentParameter = new Hashtable();
            htGetAssignmentParameter.Add("@u_assignment_group_id_fk", u_assignment_group_id_fk);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_parameter_using_group_id", htGetAssignmentParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="addparam"></param>
        /// <returns></returns>
        public static int ResetAssignmentParameter(string assignment_parameters,string u_assignment_group_id_fk)
        {
            Hashtable htParameter = new Hashtable();
            htParameter.Add("@u_assignment_group_id_fk", u_assignment_group_id_fk);
            htParameter.Add("@assignment_parameters", assignment_parameters);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_reset_assignment_gropup_parameter", htParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Assignment Element
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAssignmentElement()
        {
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_assignment_element");
            }

            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Assignment Operator
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAssignmentOperator()
        {
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_assignment_operator");
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAssignmentRuleUser(string u_assignment_group_system_id_pk,string locale)
        {
            Hashtable htUser = new Hashtable();
            htUser.Add("@u_assignment_group_system_id_pk", u_assignment_group_system_id_pk);
            htUser.Add("@locale", locale);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_get_assignment_group_dynamic_query", htUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //

        public static DataTable GetAssignmentRuleUserDetails(string u_assignment_group_system_id_pk, string locale)
        {
            Hashtable htUser = new Hashtable();
            htUser.Add("@u_assignment_group_system_id_pk", u_assignment_group_system_id_pk);
            htUser.Add("@locale", locale);
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_assignment_group_user_details", htUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertGroupUser(string u_assignment_group_id_fk, string assignment_group_user)
        {
            Hashtable htInsertUser = new Hashtable();
            htInsertUser.Add("@u_assignment_group_id_fk", u_assignment_group_id_fk);
            htInsertUser.Add("@assignment_group_user", assignment_group_user);
            try
            {
                return DataProxy.FetchSPOutput("e_sp_insert_assignment_groups_users", htInsertUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetUserPDFExcel(string u_assignment_group_system_id_pk, string s_locale_culture)
        {
            Hashtable htGetAllLearningHistory = new Hashtable();
            htGetAllLearningHistory.Add("@u_assignment_group_system_id_pk", u_assignment_group_system_id_pk);
            htGetAllLearningHistory.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("e_sp_get_assignment_preview_pdf", htGetAllLearningHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
