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
    public class SystemApprovalWorkflowBLL
    {
        /// <summary>
        /// Get Approval Workflow status
        /// </summary>
        /// <returns></returns>
        public static DataTable GetApprovalWorkflowstatus(string s_ui_locale_name, string s_ui_page_name)
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
        /// Get approval workflow all status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetApprovalWorkflowAllstatus(string s_ui_locale_name, string s_ui_page_name)
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
        /// Get Approval Workflow types for dropdown
        /// </summary>
        /// <returns></returns>
        public static DataTable GetApproval(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetApproval = new Hashtable();
                htGetApproval.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetApproval.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_course_sp_get_approval",htGetApproval);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create Approval workflow
        /// </summary>
        /// <param name="createApprovalWorkflow"></param>
        /// <returns></returns>
        public static int CreateApprovalWorkflow(SystemApprovalWorkflow createApprovalWorkFlow)
        {
            Hashtable htCreateApprovalWorkFlow = new Hashtable();

            htCreateApprovalWorkFlow.Add("@s_approval_workflow_system_id_pk", createApprovalWorkFlow.s_approval_workflow_system_id_pk);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_id", createApprovalWorkFlow.s_approval_workflow_id);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_status_id_fk", createApprovalWorkFlow.s_approval_workflow_status_id_fk);
            if (!string.IsNullOrEmpty(createApprovalWorkFlow.s_first_level_approver_id_fk))
            {
                htCreateApprovalWorkFlow.Add("@s_first_level_approver_id_fk", createApprovalWorkFlow.s_first_level_approver_id_fk);
            }
            else
            {
                htCreateApprovalWorkFlow.Add("@s_first_level_approver_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(createApprovalWorkFlow.s_second_level_approver_id_fk))
            {
                htCreateApprovalWorkFlow.Add("@s_second_level_approver_id_fk", createApprovalWorkFlow.s_second_level_approver_id_fk);
            }
            else
            {
                htCreateApprovalWorkFlow.Add("@s_second_level_approver_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(createApprovalWorkFlow.s_third_level_approver_id_fk))
            {
                htCreateApprovalWorkFlow.Add("@s_third_level_approver_id_fk", createApprovalWorkFlow.s_third_level_approver_id_fk);
            }
            else
            {
                htCreateApprovalWorkFlow.Add("@s_third_level_approver_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(createApprovalWorkFlow.s_first_level_approver_user_id_fk))
            {
                htCreateApprovalWorkFlow.Add("@s_first_level_approver_user_id_fk", createApprovalWorkFlow.s_first_level_approver_user_id_fk);

            }
            else
            {
                htCreateApprovalWorkFlow.Add("@s_first_level_approver_user_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createApprovalWorkFlow.s_second_level_approver_user_id_fk))
            {
                htCreateApprovalWorkFlow.Add("@s_second_level_approver_user_id_fk", createApprovalWorkFlow.s_second_level_approver_user_id_fk);

            }
            else
            {
                htCreateApprovalWorkFlow.Add("@s_second_level_approver_user_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createApprovalWorkFlow.s_third_level_approver_user_id_fk))
            {
                htCreateApprovalWorkFlow.Add("@s_third_level_approver_user_id_fk", createApprovalWorkFlow.s_third_level_approver_user_id_fk);

            }
            else
            {
                htCreateApprovalWorkFlow.Add("@s_third_level_approver_user_id_fk", DBNull.Value);
            }
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_us_english", createApprovalWorkFlow.s_approval_workflow_name_us_english);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_us_english", createApprovalWorkFlow.s_approval_workflow_desc_us_english);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_uk_english", createApprovalWorkFlow.s_approval_workflow_name_uk_english);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_uk_english", createApprovalWorkFlow.s_approval_workflow_desc_uk_english);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_ca_french", createApprovalWorkFlow.s_approval_workflow_name_ca_french);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_ca_french", createApprovalWorkFlow.s_approval_workflow_desc_ca_french);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_fr_french", createApprovalWorkFlow.s_approval_workflow_name_fr_french);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_fr_french", createApprovalWorkFlow.s_approval_workflow_desc_fr_french);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_mx_spanish", createApprovalWorkFlow.s_approval_workflow_name_mx_spanish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_mx_spanish", createApprovalWorkFlow.s_approval_workflow_desc_mx_spanish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_sp_spanish", createApprovalWorkFlow.s_approval_workflow_name_sp_spanish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_sp_spanish", createApprovalWorkFlow.s_approval_workflow_desc_sp_spanish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_portuguese", createApprovalWorkFlow.s_approval_workflow_name_portuguese);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_portuguese", createApprovalWorkFlow.s_approval_workflow_desc_portuguese);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_simp_chinese", createApprovalWorkFlow.s_approval_workflow_name_simp_chinese);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_simp_chinese", createApprovalWorkFlow.s_approval_workflow_desc_simp_chinese);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_german", createApprovalWorkFlow.s_approval_workflow_name_german);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_german", createApprovalWorkFlow.s_approval_workflow_desc_german);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_japanese", createApprovalWorkFlow.s_approval_workflow_name_japanese);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_japanese", createApprovalWorkFlow.s_approval_workflow_desc_japanese);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_russian", createApprovalWorkFlow.s_approval_workflow_name_russian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_russian", createApprovalWorkFlow.s_approval_workflow_desc_russian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_danish", createApprovalWorkFlow.s_approval_workflow_name_danish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_danish", createApprovalWorkFlow.s_approval_workflow_desc_danish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_polish", createApprovalWorkFlow.s_approval_workflow_name_polish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_polish", createApprovalWorkFlow.s_approval_workflow_desc_polish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_swedish", createApprovalWorkFlow.s_approval_workflow_name_swedish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_swedish", createApprovalWorkFlow.s_approval_workflow_desc_swedish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_finnish", createApprovalWorkFlow.s_approval_workflow_name_finnish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_finnish", createApprovalWorkFlow.s_approval_workflow_desc_finnish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_korean", createApprovalWorkFlow.s_approval_workflow_name_korean);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_korean", createApprovalWorkFlow.s_approval_workflow_desc_korean);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_italian", createApprovalWorkFlow.s_approval_workflow_name_italian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_italian", createApprovalWorkFlow.s_approval_workflow_desc_italian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_dutch", createApprovalWorkFlow.s_approval_workflow_name_dutch);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_dutch", createApprovalWorkFlow.s_approval_workflow_desc_dutch);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_indonesian", createApprovalWorkFlow.s_approval_workflow_name_indonesian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_indonesian", createApprovalWorkFlow.s_approval_workflow_desc_indonesian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_greek", createApprovalWorkFlow.s_approval_workflow_name_greek);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_greek", createApprovalWorkFlow.s_approval_workflow_desc_greek);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_hungarian", createApprovalWorkFlow.s_approval_workflow_name_hungarian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_hungarian", createApprovalWorkFlow.s_approval_workflow_desc_hungarian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_norwegian", createApprovalWorkFlow.s_approval_workflow_name_norwegian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_norwegian", createApprovalWorkFlow.s_approval_workflow_desc_norwegian);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_turkish", createApprovalWorkFlow.s_approval_workflow_name_turkish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_turkish", createApprovalWorkFlow.s_approval_workflow_desc_turkish);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_arabic_rtl", createApprovalWorkFlow.s_approval_workflow_name_arabic_rtl);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_arabic_rtl", createApprovalWorkFlow.s_approval_workflow_desc_arabic_rtl);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_01", createApprovalWorkFlow.s_approval_workflow_name_custom_01);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_01", createApprovalWorkFlow.s_approval_workflow_desc_custom_01);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_02", createApprovalWorkFlow.s_approval_workflow_name_custom_02);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_02", createApprovalWorkFlow.s_approval_workflow_desc_custom_02);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_03", createApprovalWorkFlow.s_approval_workflow_name_custom_03);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_03", createApprovalWorkFlow.s_approval_workflow_desc_custom_03);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_04", createApprovalWorkFlow.s_approval_workflow_name_custom_04);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_04", createApprovalWorkFlow.s_approval_workflow_desc_custom_04);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_05", createApprovalWorkFlow.s_approval_workflow_name_custom_05);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_05", createApprovalWorkFlow.s_approval_workflow_desc_custom_05);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_06", createApprovalWorkFlow.s_approval_workflow_name_custom_06);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_06", createApprovalWorkFlow.s_approval_workflow_desc_custom_06);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_07", createApprovalWorkFlow.s_approval_workflow_name_custom_07);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_07", createApprovalWorkFlow.s_approval_workflow_desc_custom_07);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_08", createApprovalWorkFlow.s_approval_workflow_name_custom_08);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_08", createApprovalWorkFlow.s_approval_workflow_desc_custom_08);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_09", createApprovalWorkFlow.s_approval_workflow_name_custom_09);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_09", createApprovalWorkFlow.s_approval_workflow_desc_custom_09);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_10", createApprovalWorkFlow.s_approval_workflow_name_custom_10);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_10", createApprovalWorkFlow.s_approval_workflow_desc_custom_10);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_11", createApprovalWorkFlow.s_approval_workflow_name_custom_11);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_11", createApprovalWorkFlow.s_approval_workflow_desc_custom_11);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_12", createApprovalWorkFlow.s_approval_workflow_name_custom_12);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_12", createApprovalWorkFlow.s_approval_workflow_desc_custom_12);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_13", createApprovalWorkFlow.s_approval_workflow_name_custom_13);
            htCreateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_13", createApprovalWorkFlow.s_approval_workflow_desc_custom_13);
            htCreateApprovalWorkFlow.Add("@s_first_level_status", createApprovalWorkFlow.s_first_level_status);
            htCreateApprovalWorkFlow.Add("@s_second_level_status", createApprovalWorkFlow.s_second_level_status);
            htCreateApprovalWorkFlow.Add("@s_third_level_status", createApprovalWorkFlow.s_third_level_status);



            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_approval_workflow", htCreateApprovalWorkFlow);
            }
            catch (Exception)
            {
                throw;
            }



        }
        /// <summary>
        /// Get Approval workflow
        /// </summary>
        /// <param name="s_approval_workflow_system_id_pk"></param>
        /// <returns></returns>
        public static SystemApprovalWorkflow GetApprovalWorkflow(string s_approval_workflow_system_id_pk)
        {
            SystemApprovalWorkflow approvalWorkFlow;

            try
            {
                Hashtable htGetEmployeeTypes = new Hashtable();
                htGetEmployeeTypes.Add("@s_approval_workflow_system_id_pk", s_approval_workflow_system_id_pk);
                approvalWorkFlow = new SystemApprovalWorkflow();
                DataTable dtGetApprovalWorkFlow = DataProxy.FetchDataTable("s_sp_get_approval_workflow", htGetEmployeeTypes);
                approvalWorkFlow.s_approval_workflow_id = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_id"].ToString();
                approvalWorkFlow.s_approval_workflow_status_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_status_id_fk"].ToString();

                approvalWorkFlow.s_first_level_approver_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_first_level_approver_id_fk"].ToString();
                approvalWorkFlow.s_second_level_approver_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_second_level_approver_id_fk"].ToString();
                approvalWorkFlow.s_third_level_approver_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_third_level_approver_id_fk"].ToString();
                approvalWorkFlow.s_first_level_approver_user_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_first_level_approver_user_id_fk"].ToString();
                approvalWorkFlow.s_second_level_approver_user_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_second_level_approver_user_id_fk"].ToString();
                approvalWorkFlow.s_third_level_approver_user_id_fk = dtGetApprovalWorkFlow.Rows[0]["s_third_level_approver_user_id_fk"].ToString();

                approvalWorkFlow.first_level_user_name = dtGetApprovalWorkFlow.Rows[0]["first_level_user_name"].ToString();
                approvalWorkFlow.second_level_user_name = dtGetApprovalWorkFlow.Rows[0]["second_level_user_name"].ToString();
                approvalWorkFlow.third_level_user_name = dtGetApprovalWorkFlow.Rows[0]["third_level_user_name"].ToString();
                approvalWorkFlow.s_approval_workflow_name_us_english = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_us_english"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_us_english = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_us_english"].ToString();
                approvalWorkFlow.s_approval_workflow_name_uk_english = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_uk_english"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_uk_english = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_uk_english"].ToString();
                approvalWorkFlow.s_approval_workflow_name_ca_french = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_ca_french"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_ca_french = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_ca_french"].ToString();
                approvalWorkFlow.s_approval_workflow_name_fr_french = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_fr_french"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_fr_french = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_fr_french"].ToString();
                approvalWorkFlow.s_approval_workflow_name_mx_spanish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_mx_spanish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_mx_spanish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_mx_spanish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_sp_spanish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_sp_spanish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_sp_spanish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_sp_spanish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_portuguese = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_portuguese"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_portuguese = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_portuguese"].ToString();
                approvalWorkFlow.s_approval_workflow_name_simp_chinese = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_simp_chinese"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_simp_chinese = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_simp_chinese"].ToString();
                approvalWorkFlow.s_approval_workflow_name_german = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_german"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_german = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_german"].ToString();
                approvalWorkFlow.s_approval_workflow_name_japanese = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_japanese"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_japanese = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_japanese"].ToString();
                approvalWorkFlow.s_approval_workflow_name_russian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_russian"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_russian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_russian"].ToString();
                approvalWorkFlow.s_approval_workflow_name_danish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_danish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_danish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_danish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_polish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_polish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_polish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_polish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_swedish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_swedish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_swedish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_swedish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_finnish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_finnish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_finnish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_finnish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_korean = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_korean"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_korean = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_korean"].ToString();
                approvalWorkFlow.s_approval_workflow_name_italian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_italian"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_italian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_italian"].ToString();
                approvalWorkFlow.s_approval_workflow_name_dutch = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_dutch"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_dutch = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_dutch"].ToString();
                approvalWorkFlow.s_approval_workflow_name_indonesian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_indonesian"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_indonesian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_indonesian"].ToString();
                approvalWorkFlow.s_approval_workflow_name_greek = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_greek"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_greek = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_greek"].ToString();
                approvalWorkFlow.s_approval_workflow_name_hungarian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_hungarian"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_hungarian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_hungarian"].ToString();
                approvalWorkFlow.s_approval_workflow_name_norwegian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_norwegian"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_norwegian = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_norwegian"].ToString();
                approvalWorkFlow.s_approval_workflow_name_turkish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_turkish"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_turkish = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_turkish"].ToString();
                approvalWorkFlow.s_approval_workflow_name_arabic_rtl = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_arabic_rtl"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_arabic_rtl = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_arabic_rtl"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_01 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_01"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_01 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_01"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_02 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_02"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_02 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_02"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_03 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_03"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_03 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_03"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_04 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_04"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_04 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_04"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_05 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_05"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_05 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_05"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_06 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_06"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_06 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_06"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_07 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_07"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_07 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_07"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_08 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_08"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_08 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_08"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_09 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_09"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_09 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_09"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_10 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_10"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_10 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_10"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_11 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_11"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_11 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_11"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_12 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_12"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_12 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_12"].ToString();
                approvalWorkFlow.s_approval_workflow_name_custom_13 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_name_custom_13"].ToString();
                approvalWorkFlow.s_approval_workflow_desc_custom_13 = dtGetApprovalWorkFlow.Rows[0]["s_approval_workflow_desc_custom_13"].ToString();
                approvalWorkFlow.s_first_level_status = Convert.ToBoolean(dtGetApprovalWorkFlow.Rows[0]["s_first_level_status"]);
                approvalWorkFlow.s_second_level_status = Convert.ToBoolean(dtGetApprovalWorkFlow.Rows[0]["s_second_level_status"]);
                approvalWorkFlow.s_third_level_status = Convert.ToBoolean(dtGetApprovalWorkFlow.Rows[0]["s_third_level_status"]);



                return approvalWorkFlow;
            }
            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Update Approval Workflow
        /// </summary>
        /// <param name="updatetApprovalWorkflow"></param>
        /// <returns></returns>
        public static int UpdateApprovalWorkflow(SystemApprovalWorkflow updateApprovalWorkFlow)
        {
            Hashtable htUpdateApprovalWorkFlow = new Hashtable();

            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_system_id_pk", updateApprovalWorkFlow.s_approval_workflow_system_id_pk);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_id", updateApprovalWorkFlow.s_approval_workflow_id);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_status_id_fk", updateApprovalWorkFlow.s_approval_workflow_status_id_fk);
            if (!string.IsNullOrEmpty(updateApprovalWorkFlow.s_first_level_approver_id_fk))
            {
                htUpdateApprovalWorkFlow.Add("@s_first_level_approver_id_fk", updateApprovalWorkFlow.s_first_level_approver_id_fk);
            }
            else
            {
                htUpdateApprovalWorkFlow.Add("@s_first_level_approver_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(updateApprovalWorkFlow.s_second_level_approver_id_fk))
            {
                htUpdateApprovalWorkFlow.Add("@s_second_level_approver_id_fk", updateApprovalWorkFlow.s_second_level_approver_id_fk);
            }
            else
            {
                htUpdateApprovalWorkFlow.Add("@s_second_level_approver_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(updateApprovalWorkFlow.s_third_level_approver_id_fk))
            {
                htUpdateApprovalWorkFlow.Add("@s_third_level_approver_id_fk", updateApprovalWorkFlow.s_third_level_approver_id_fk);
            }
            else
            {
                htUpdateApprovalWorkFlow.Add("@s_third_level_approver_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(updateApprovalWorkFlow.s_first_level_approver_user_id_fk))
            {
                htUpdateApprovalWorkFlow.Add("@s_first_level_approver_user_id_fk", updateApprovalWorkFlow.s_first_level_approver_user_id_fk);

            }
            else
            {
                htUpdateApprovalWorkFlow.Add("@s_first_level_approver_user_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(updateApprovalWorkFlow.s_second_level_approver_user_id_fk))
            {
                htUpdateApprovalWorkFlow.Add("@s_second_level_approver_user_id_fk", updateApprovalWorkFlow.s_second_level_approver_user_id_fk);

            }
            else
            {
                htUpdateApprovalWorkFlow.Add("@s_second_level_approver_user_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(updateApprovalWorkFlow.s_third_level_approver_user_id_fk))
            {
                htUpdateApprovalWorkFlow.Add("@s_third_level_approver_user_id_fk", updateApprovalWorkFlow.s_third_level_approver_user_id_fk);

            }
            else
            {
                htUpdateApprovalWorkFlow.Add("@s_third_level_approver_user_id_fk", DBNull.Value);
            }
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_us_english", updateApprovalWorkFlow.s_approval_workflow_name_us_english);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_us_english", updateApprovalWorkFlow.s_approval_workflow_desc_us_english);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_uk_english", updateApprovalWorkFlow.s_approval_workflow_name_uk_english);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_uk_english", updateApprovalWorkFlow.s_approval_workflow_desc_uk_english);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_ca_french", updateApprovalWorkFlow.s_approval_workflow_name_ca_french);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_ca_french", updateApprovalWorkFlow.s_approval_workflow_desc_ca_french);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_fr_french", updateApprovalWorkFlow.s_approval_workflow_name_fr_french);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_fr_french", updateApprovalWorkFlow.s_approval_workflow_desc_fr_french);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_mx_spanish", updateApprovalWorkFlow.s_approval_workflow_name_mx_spanish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_mx_spanish", updateApprovalWorkFlow.s_approval_workflow_desc_mx_spanish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_sp_spanish", updateApprovalWorkFlow.s_approval_workflow_name_sp_spanish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_sp_spanish", updateApprovalWorkFlow.s_approval_workflow_desc_sp_spanish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_portuguese", updateApprovalWorkFlow.s_approval_workflow_name_portuguese);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_portuguese", updateApprovalWorkFlow.s_approval_workflow_desc_portuguese);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_simp_chinese", updateApprovalWorkFlow.s_approval_workflow_name_simp_chinese);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_simp_chinese", updateApprovalWorkFlow.s_approval_workflow_desc_simp_chinese);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_german", updateApprovalWorkFlow.s_approval_workflow_name_german);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_german", updateApprovalWorkFlow.s_approval_workflow_desc_german);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_japanese", updateApprovalWorkFlow.s_approval_workflow_name_japanese);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_japanese", updateApprovalWorkFlow.s_approval_workflow_desc_japanese);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_russian", updateApprovalWorkFlow.s_approval_workflow_name_russian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_russian", updateApprovalWorkFlow.s_approval_workflow_desc_russian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_danish", updateApprovalWorkFlow.s_approval_workflow_name_danish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_danish", updateApprovalWorkFlow.s_approval_workflow_desc_danish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_polish", updateApprovalWorkFlow.s_approval_workflow_name_polish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_polish", updateApprovalWorkFlow.s_approval_workflow_desc_polish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_swedish", updateApprovalWorkFlow.s_approval_workflow_name_swedish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_swedish", updateApprovalWorkFlow.s_approval_workflow_desc_swedish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_finnish", updateApprovalWorkFlow.s_approval_workflow_name_finnish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_finnish", updateApprovalWorkFlow.s_approval_workflow_desc_finnish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_korean", updateApprovalWorkFlow.s_approval_workflow_name_korean);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_korean", updateApprovalWorkFlow.s_approval_workflow_desc_korean);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_italian", updateApprovalWorkFlow.s_approval_workflow_name_italian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_italian", updateApprovalWorkFlow.s_approval_workflow_desc_italian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_dutch", updateApprovalWorkFlow.s_approval_workflow_name_dutch);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_dutch", updateApprovalWorkFlow.s_approval_workflow_desc_dutch);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_indonesian", updateApprovalWorkFlow.s_approval_workflow_name_indonesian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_indonesian", updateApprovalWorkFlow.s_approval_workflow_desc_indonesian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_greek", updateApprovalWorkFlow.s_approval_workflow_name_greek);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_greek", updateApprovalWorkFlow.s_approval_workflow_desc_greek);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_hungarian", updateApprovalWorkFlow.s_approval_workflow_name_hungarian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_hungarian", updateApprovalWorkFlow.s_approval_workflow_desc_hungarian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_norwegian", updateApprovalWorkFlow.s_approval_workflow_name_norwegian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_norwegian", updateApprovalWorkFlow.s_approval_workflow_desc_norwegian);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_turkish", updateApprovalWorkFlow.s_approval_workflow_name_turkish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_turkish", updateApprovalWorkFlow.s_approval_workflow_desc_turkish);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_arabic_rtl", updateApprovalWorkFlow.s_approval_workflow_name_arabic_rtl);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_arabic_rtl", updateApprovalWorkFlow.s_approval_workflow_desc_arabic_rtl);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_01", updateApprovalWorkFlow.s_approval_workflow_name_custom_01);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_01", updateApprovalWorkFlow.s_approval_workflow_desc_custom_01);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_02", updateApprovalWorkFlow.s_approval_workflow_name_custom_02);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_02", updateApprovalWorkFlow.s_approval_workflow_desc_custom_02);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_03", updateApprovalWorkFlow.s_approval_workflow_name_custom_03);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_03", updateApprovalWorkFlow.s_approval_workflow_desc_custom_03);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_04", updateApprovalWorkFlow.s_approval_workflow_name_custom_04);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_04", updateApprovalWorkFlow.s_approval_workflow_desc_custom_04);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_05", updateApprovalWorkFlow.s_approval_workflow_name_custom_05);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_05", updateApprovalWorkFlow.s_approval_workflow_desc_custom_05);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_06", updateApprovalWorkFlow.s_approval_workflow_name_custom_06);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_06", updateApprovalWorkFlow.s_approval_workflow_desc_custom_06);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_07", updateApprovalWorkFlow.s_approval_workflow_name_custom_07);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_07", updateApprovalWorkFlow.s_approval_workflow_desc_custom_07);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_08", updateApprovalWorkFlow.s_approval_workflow_name_custom_08);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_08", updateApprovalWorkFlow.s_approval_workflow_desc_custom_08);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_09", updateApprovalWorkFlow.s_approval_workflow_name_custom_09);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_09", updateApprovalWorkFlow.s_approval_workflow_desc_custom_09);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_10", updateApprovalWorkFlow.s_approval_workflow_name_custom_10);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_10", updateApprovalWorkFlow.s_approval_workflow_desc_custom_10);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_11", updateApprovalWorkFlow.s_approval_workflow_name_custom_11);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_11", updateApprovalWorkFlow.s_approval_workflow_desc_custom_11);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_12", updateApprovalWorkFlow.s_approval_workflow_name_custom_12);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_12", updateApprovalWorkFlow.s_approval_workflow_desc_custom_12);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_name_custom_13", updateApprovalWorkFlow.s_approval_workflow_name_custom_13);
            htUpdateApprovalWorkFlow.Add("@s_approval_workflow_desc_custom_13", updateApprovalWorkFlow.s_approval_workflow_desc_custom_13);
            htUpdateApprovalWorkFlow.Add("@s_first_level_status", updateApprovalWorkFlow.s_first_level_status);
            htUpdateApprovalWorkFlow.Add("@s_second_level_status", updateApprovalWorkFlow.s_second_level_status);
            htUpdateApprovalWorkFlow.Add("@s_third_level_status", updateApprovalWorkFlow.s_third_level_status);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_approval_workflow", htUpdateApprovalWorkFlow);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Search Approval Workflow
        /// </summary>
        /// <param name="approvalWorkflow"></param>
        /// <returns></returns>
        public static DataTable SearchApprovalWorkflow(SystemApprovalWorkflow approvalWorkflow)
        {
            Hashtable htApprovalWorkflow = new Hashtable();
            htApprovalWorkflow.Add("@s_approval_workflow_id", approvalWorkflow.s_approval_workflow_id);
            htApprovalWorkflow.Add("@s_approval_workflow_name_us_english", approvalWorkflow.s_approval_workflow_name_us_english);


            if (approvalWorkflow.s_approval_workflow_status_id_fk == "0")
                htApprovalWorkflow.Add("@s_approval_workflow_status_id_fk", DBNull.Value);
            else
                htApprovalWorkflow.Add("@s_approval_workflow_status_id_fk", approvalWorkflow.s_approval_workflow_status_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_approval_workflow_search", htApprovalWorkflow);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Update approval workflow status
        /// </summary>
        /// <param name="s_approval_workflow_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateApprovalWorkflowStatus(string s_approval_workflow_system_id_pk)
        {
            Hashtable htUpdateApprovalWorkflowStatus = new Hashtable();
            htUpdateApprovalWorkflowStatus.Add("@s_approval_workflow_system_id_pk", s_approval_workflow_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_approval_workflow_status", htUpdateApprovalWorkflowStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
