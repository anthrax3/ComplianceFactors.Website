using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.DataAccessLayer;
using System.Collections;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemAssignmentRuleBLL
    {
        public static int InsertAssignmentRule(SystemAssignmentRules assignmentRule)
        {
            Hashtable htCreateAssignmentRule = new Hashtable();

            htCreateAssignmentRule.Add("@u_assignment_rules_system_id_pk", assignmentRule.u_assignment_rules_system_id_pk);
            htCreateAssignmentRule.Add("@u_assignment_rules_id_pk", assignmentRule.u_assignment_rules_id_pk);
            htCreateAssignmentRule.Add("@u_assignment_rules_name", assignmentRule.u_assignment_rules_name);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc", assignmentRule.u_assignment_rules_desc);
            htCreateAssignmentRule.Add("@u_assignment_rules_status_id_fk", assignmentRule.u_assignment_rules_status_id_fk);
            htCreateAssignmentRule.Add("@u_assignment_rules_required_flag", assignmentRule.u_assignment_rules_required_flag);
            htCreateAssignmentRule.Add("@u_assignment_rules_due_select_param", assignmentRule.u_assignment_rules_due_select_param);

            if (!string.IsNullOrEmpty(assignmentRule.u_assignment_rules_fix_date_param.ToString()))
            {
                htCreateAssignmentRule.Add("@u_assignment_rules_fix_date_param", assignmentRule.u_assignment_rules_fix_date_param);
            }
            else
            {
                htCreateAssignmentRule.Add("@u_assignment_rules_fix_date_param", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(assignmentRule.u_assignment_rules_days_param.ToString()))
            {
                htCreateAssignmentRule.Add("@u_assignment_rules_days_param", assignmentRule.u_assignment_rules_days_param);
            }
            else
            {
                htCreateAssignmentRule.Add("@u_assignment_rules_days_param", DBNull.Value);
            }

            htCreateAssignmentRule.Add("@u_assignment_rules_name_uk_english", assignmentRule.u_assignment_rules_name_uk_english);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_uk_english", assignmentRule.u_assignment_rules_desc_uk_english);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_ca_french", assignmentRule.u_assignment_rules_name_ca_french);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_ca_french", assignmentRule.u_assignment_rules_desc_ca_french);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_fr_french", assignmentRule.u_assignment_rules_name_fr_french);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_fr_french", assignmentRule.u_assignment_rules_desc_fr_french);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_mx_spanish", assignmentRule.u_assignment_rules_name_mx_spanish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_mx_spanish", assignmentRule.u_assignment_rules_desc_mx_spanish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_sp_spanish", assignmentRule.u_assignment_rules_name_sp_spanish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_sp_spanish", assignmentRule.u_assignment_rules_desc_sp_spanish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_portuguese", assignmentRule.u_assignment_rules_name_portuguese);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_portuguese", assignmentRule.u_assignment_rules_desc_portuguese);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_simp_chinese", assignmentRule.u_assignment_rules_name_simp_chinese);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_simp_chinese", assignmentRule.u_assignment_rules_desc_simp_chinese);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_german", assignmentRule.u_assignment_rules_name_german);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_german", assignmentRule.u_assignment_rules_desc_german);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_japanese", assignmentRule.u_assignment_rules_name_japanese);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_japanese", assignmentRule.u_assignment_rules_desc_japanese);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_russian", assignmentRule.u_assignment_rules_name_russian);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_russian", assignmentRule.u_assignment_rules_desc_russian);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_danish", assignmentRule.u_assignment_rules_name_danish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_danish", assignmentRule.u_assignment_rules_desc_danish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_polish", assignmentRule.u_assignment_rules_name_polish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_polish", assignmentRule.u_assignment_rules_desc_polish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_swedish", assignmentRule.u_assignment_rules_name_swedish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_swedish", assignmentRule.u_assignment_rules_desc_swedish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_finnish", assignmentRule.u_assignment_rules_name_finnish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_finnish", assignmentRule.u_assignment_rules_desc_finnish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_korean", assignmentRule.u_assignment_rules_name_korean);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_korean", assignmentRule.u_assignment_rules_desc_korean);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_italian", assignmentRule.u_assignment_rules_name_italian);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_italian", assignmentRule.u_assignment_rules_desc_italian);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_dutch", assignmentRule.u_assignment_rules_name_dutch);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_dutch", assignmentRule.u_assignment_rules_desc_dutch);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_indonesian", assignmentRule.u_assignment_rules_name_indonesian);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_indonesian", assignmentRule.u_assignment_rules_desc_indonesian);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_greek", assignmentRule.u_assignment_rules_name_greek);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_greek", assignmentRule.u_assignment_rules_desc_greek);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_hungarian", assignmentRule.u_assignment_rules_name_hungarian);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_hungarian", assignmentRule.u_assignment_rules_desc_hungarian);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_norwegian", assignmentRule.u_assignment_rules_name_norwegian);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_norwegian", assignmentRule.u_assignment_rules_desc_norwegian);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_turkish", assignmentRule.u_assignment_rules_name_turkish);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_turkish", assignmentRule.u_assignment_rules_desc_turkish);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_arabic", assignmentRule.u_assignment_rules_name_arabic);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_arabic", assignmentRule.u_assignment_rules_desc_arabic);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_01", assignmentRule.u_assignment_rules_name_custom_01);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_01", assignmentRule.u_assignment_rules_desc_custom_01);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_02", assignmentRule.u_assignment_rules_name_custom_02);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_02", assignmentRule.u_assignment_rules_desc_custom_02);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_03", assignmentRule.u_assignment_rules_name_custom_03);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_03", assignmentRule.u_assignment_rules_desc_custom_03);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_04", assignmentRule.u_assignment_rules_name_custom_04);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_04", assignmentRule.u_assignment_rules_desc_custom_04);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_05", assignmentRule.u_assignment_rules_name_custom_05);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_05", assignmentRule.u_assignment_rules_desc_custom_05);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_06", assignmentRule.u_assignment_rules_name_custom_06);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_06", assignmentRule.u_assignment_rules_desc_custom_06);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_07", assignmentRule.u_assignment_rules_name_custom_07);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_07", assignmentRule.u_assignment_rules_desc_custom_07);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_08", assignmentRule.u_assignment_rules_name_custom_08);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_08", assignmentRule.u_assignment_rules_desc_custom_08);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_09", assignmentRule.u_assignment_rules_name_custom_09);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_09", assignmentRule.u_assignment_rules_desc_custom_09);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_10", assignmentRule.u_assignment_rules_name_custom_10);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_10", assignmentRule.u_assignment_rules_desc_custom_10);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_11", assignmentRule.u_assignment_rules_name_custom_11);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_11", assignmentRule.u_assignment_rules_desc_custom_11);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_12", assignmentRule.u_assignment_rules_name_custom_12);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_12", assignmentRule.u_assignment_rules_desc_custom_12);
            htCreateAssignmentRule.Add("@u_assignment_rules_name_custom_13", assignmentRule.u_assignment_rules_name_custom_13);
            htCreateAssignmentRule.Add("@u_assignment_rules_desc_custom_13", assignmentRule.u_assignment_rules_desc_custom_13);
            //htCreateAssignmentRule.Add("@u_assignment_rules_values", assignmentRule.u_assignment_rules_values);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_assignment_rule", htCreateAssignmentRule);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static SystemAssignmentRules GetAssignmentRule(string u_assignment_rules_system_id_pk)
        {
            SystemAssignmentRules AssignmentRule;
            try
            {
                Hashtable htGetAssignmentRules = new Hashtable();
                htGetAssignmentRules.Add("@u_assignment_rules_system_id_pk", u_assignment_rules_system_id_pk);
                AssignmentRule = new SystemAssignmentRules();

                //DataTable dtGetAssignmentRules = DataProxy.FetchDataTable("***STORED PROCEDURE TO GET THE SELECTED SCHEME***", htGetAssignmentRules);
                DataTable dtGetAssignmentRules = DataProxy.FetchDataTable("s_sp_get_single_assignment_rule", htGetAssignmentRules);

                AssignmentRule.u_assignment_rules_id_pk = dtGetAssignmentRules.Rows[0]["u_assignment_rules_id_pk"].ToString();
                AssignmentRule.u_assignment_rules_name = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name"].ToString();
                AssignmentRule.u_assignment_rules_desc = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc"].ToString();
                AssignmentRule.u_assignment_rules_status_id_fk = dtGetAssignmentRules.Rows[0]["u_assignment_rules_status_id_fk"].ToString();
                AssignmentRule.u_assignment_rules_required_flag = Convert.ToBoolean(dtGetAssignmentRules.Rows[0]["u_assignment_rules_required_flag"]);
                AssignmentRule.u_assignment_rules_due_select_param = dtGetAssignmentRules.Rows[0]["u_assignment_rules_due_select_param"].ToString();
                if (!string.IsNullOrEmpty(dtGetAssignmentRules.Rows[0]["u_assignment_rules_fix_date_param"].ToString()))
                {
                    AssignmentRule.u_assignment_rules_fix_date_param = Convert.ToDateTime(dtGetAssignmentRules.Rows[0]["u_assignment_rules_fix_date_param"]);
                }
                if (!string.IsNullOrEmpty(dtGetAssignmentRules.Rows[0]["u_assignment_rules_days_param"].ToString()))
                {
                    AssignmentRule.u_assignment_rules_days_param = Convert.ToInt16(dtGetAssignmentRules.Rows[0]["u_assignment_rules_days_param"]);
                }

                AssignmentRule.u_assignment_rules_name_uk_english = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_uk_english"].ToString();
                AssignmentRule.u_assignment_rules_desc_uk_english = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_uk_english"].ToString();
                AssignmentRule.u_assignment_rules_name_ca_french = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_ca_french"].ToString();
                AssignmentRule.u_assignment_rules_desc_ca_french = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_ca_french"].ToString();
                AssignmentRule.u_assignment_rules_name_fr_french = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_fr_french"].ToString();
                AssignmentRule.u_assignment_rules_desc_fr_french = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_fr_french"].ToString();
                AssignmentRule.u_assignment_rules_name_mx_spanish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_mx_spanish"].ToString();
                AssignmentRule.u_assignment_rules_desc_mx_spanish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_mx_spanish"].ToString();
                AssignmentRule.u_assignment_rules_name_sp_spanish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_sp_spanish"].ToString();
                AssignmentRule.u_assignment_rules_desc_sp_spanish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_sp_spanish"].ToString();
                AssignmentRule.u_assignment_rules_name_portuguese = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_portuguese"].ToString();
                AssignmentRule.u_assignment_rules_desc_portuguese = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_portuguese"].ToString();
                AssignmentRule.u_assignment_rules_name_simp_chinese = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_simp_chinese"].ToString();
                AssignmentRule.u_assignment_rules_desc_simp_chinese = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_simp_chinese"].ToString();
                AssignmentRule.u_assignment_rules_name_german = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_german"].ToString();
                AssignmentRule.u_assignment_rules_desc_german = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_german"].ToString();
                AssignmentRule.u_assignment_rules_name_japanese = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_japanese"].ToString();
                AssignmentRule.u_assignment_rules_desc_japanese = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_japanese"].ToString();
                AssignmentRule.u_assignment_rules_name_russian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_russian"].ToString();
                AssignmentRule.u_assignment_rules_desc_russian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_russian"].ToString();
                AssignmentRule.u_assignment_rules_name_danish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_danish"].ToString();
                AssignmentRule.u_assignment_rules_desc_danish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_danish"].ToString();
                AssignmentRule.u_assignment_rules_name_polish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_polish"].ToString();
                AssignmentRule.u_assignment_rules_desc_polish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_polish"].ToString();
                AssignmentRule.u_assignment_rules_name_swedish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_swedish"].ToString();
                AssignmentRule.u_assignment_rules_desc_swedish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_swedish"].ToString();
                AssignmentRule.u_assignment_rules_name_finnish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_finnish"].ToString();
                AssignmentRule.u_assignment_rules_desc_finnish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_finnish"].ToString();
                AssignmentRule.u_assignment_rules_name_korean = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_korean"].ToString();
                AssignmentRule.u_assignment_rules_desc_korean = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_korean"].ToString();
                AssignmentRule.u_assignment_rules_name_italian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_italian"].ToString();
                AssignmentRule.u_assignment_rules_desc_italian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_italian"].ToString();
                AssignmentRule.u_assignment_rules_name_dutch = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_dutch"].ToString();
                AssignmentRule.u_assignment_rules_desc_dutch = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_dutch"].ToString();
                AssignmentRule.u_assignment_rules_name_indonesian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_indonesian"].ToString();
                AssignmentRule.u_assignment_rules_desc_indonesian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_indonesian"].ToString();
                AssignmentRule.u_assignment_rules_name_greek = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_greek"].ToString();
                AssignmentRule.u_assignment_rules_desc_greek = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_greek"].ToString();
                AssignmentRule.u_assignment_rules_name_hungarian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_hungarian"].ToString();
                AssignmentRule.u_assignment_rules_desc_hungarian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_hungarian"].ToString();
                AssignmentRule.u_assignment_rules_name_norwegian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_norwegian"].ToString();
                AssignmentRule.u_assignment_rules_desc_norwegian = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_norwegian"].ToString();
                AssignmentRule.u_assignment_rules_name_turkish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_turkish"].ToString();
                AssignmentRule.u_assignment_rules_desc_turkish = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_turkish"].ToString();
                AssignmentRule.u_assignment_rules_name_arabic = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_arabic"].ToString();
                AssignmentRule.u_assignment_rules_desc_arabic = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_arabic"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_01 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_01"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_01 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_01"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_02 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_02"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_02 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_02"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_03 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_03"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_03 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_03"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_04 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_04"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_04 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_04"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_05 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_05"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_05 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_05"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_06 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_06"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_06 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_06"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_07 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_07"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_07 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_07"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_08 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_08"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_08 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_08"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_09 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_09"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_09 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_09"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_10 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_10"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_10 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_10"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_11 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_11"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_11 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_11"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_12 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_12"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_12 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_12"].ToString();
                AssignmentRule.u_assignment_rules_name_custom_13 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_name_custom_13"].ToString();
                AssignmentRule.u_assignment_rules_desc_custom_13 = dtGetAssignmentRules.Rows[0]["u_assignment_rules_desc_custom_13"].ToString();
                return AssignmentRule;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateAssignmentRule(SystemAssignmentRules assignmentRule)
        {
            Hashtable htUpdateAssignmentRule = new Hashtable();

            htUpdateAssignmentRule.Add("@u_assignment_rules_system_id_pk", assignmentRule.u_assignment_rules_system_id_pk);
            htUpdateAssignmentRule.Add("@u_assignment_rules_id_pk", assignmentRule.u_assignment_rules_id_pk);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name", assignmentRule.u_assignment_rules_name);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc", assignmentRule.u_assignment_rules_desc);
            htUpdateAssignmentRule.Add("@u_assignment_rules_status_id_fk", assignmentRule.u_assignment_rules_status_id_fk);
            htUpdateAssignmentRule.Add("@u_assignment_rules_required_flag", assignmentRule.u_assignment_rules_required_flag);
            htUpdateAssignmentRule.Add("@u_assignment_rules_due_select_param", assignmentRule.u_assignment_rules_due_select_param);
            if (!string.IsNullOrEmpty(assignmentRule.u_assignment_rules_fix_date_param.ToString()))
            {
                htUpdateAssignmentRule.Add("@u_assignment_rules_fix_date_param", assignmentRule.u_assignment_rules_fix_date_param);
            }
            else
            {
                htUpdateAssignmentRule.Add("@u_assignment_rules_fix_date_param", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(assignmentRule.u_assignment_rules_days_param.ToString()))
            {
                htUpdateAssignmentRule.Add("@u_assignment_rules_days_param", assignmentRule.u_assignment_rules_days_param);
            }
            else
            {
                htUpdateAssignmentRule.Add("@u_assignment_rules_days_param", DBNull.Value);
            }

            htUpdateAssignmentRule.Add("@u_assignment_rules_name_uk_english", assignmentRule.u_assignment_rules_name_uk_english);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_uk_english", assignmentRule.u_assignment_rules_desc_uk_english);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_ca_french", assignmentRule.u_assignment_rules_name_ca_french);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_ca_french", assignmentRule.u_assignment_rules_desc_ca_french);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_fr_french", assignmentRule.u_assignment_rules_name_fr_french);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_fr_french", assignmentRule.u_assignment_rules_desc_fr_french);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_mx_spanish", assignmentRule.u_assignment_rules_name_mx_spanish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_mx_spanish", assignmentRule.u_assignment_rules_desc_mx_spanish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_sp_spanish", assignmentRule.u_assignment_rules_name_sp_spanish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_sp_spanish", assignmentRule.u_assignment_rules_desc_sp_spanish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_portuguese", assignmentRule.u_assignment_rules_name_portuguese);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_portuguese", assignmentRule.u_assignment_rules_desc_portuguese);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_simp_chinese", assignmentRule.u_assignment_rules_name_simp_chinese);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_simp_chinese", assignmentRule.u_assignment_rules_desc_simp_chinese);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_german", assignmentRule.u_assignment_rules_name_german);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_german", assignmentRule.u_assignment_rules_desc_german);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_japanese", assignmentRule.u_assignment_rules_name_japanese);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_japanese", assignmentRule.u_assignment_rules_desc_japanese);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_russian", assignmentRule.u_assignment_rules_name_russian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_russian", assignmentRule.u_assignment_rules_desc_russian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_danish", assignmentRule.u_assignment_rules_name_danish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_danish", assignmentRule.u_assignment_rules_desc_danish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_polish", assignmentRule.u_assignment_rules_name_polish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_polish", assignmentRule.u_assignment_rules_desc_polish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_swedish", assignmentRule.u_assignment_rules_name_swedish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_swedish", assignmentRule.u_assignment_rules_desc_swedish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_finnish", assignmentRule.u_assignment_rules_name_finnish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_finnish", assignmentRule.u_assignment_rules_desc_finnish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_korean", assignmentRule.u_assignment_rules_name_korean);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_korean", assignmentRule.u_assignment_rules_desc_korean);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_italian", assignmentRule.u_assignment_rules_name_italian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_italian", assignmentRule.u_assignment_rules_desc_italian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_dutch", assignmentRule.u_assignment_rules_name_dutch);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_dutch", assignmentRule.u_assignment_rules_desc_dutch);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_indonesian", assignmentRule.u_assignment_rules_name_indonesian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_indonesian", assignmentRule.u_assignment_rules_desc_indonesian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_greek", assignmentRule.u_assignment_rules_name_greek);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_greek", assignmentRule.u_assignment_rules_desc_greek);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_hungarian", assignmentRule.u_assignment_rules_name_hungarian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_hungarian", assignmentRule.u_assignment_rules_desc_hungarian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_norwegian", assignmentRule.u_assignment_rules_name_norwegian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_norwegian", assignmentRule.u_assignment_rules_desc_norwegian);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_turkish", assignmentRule.u_assignment_rules_name_turkish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_turkish", assignmentRule.u_assignment_rules_desc_turkish);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_arabic", assignmentRule.u_assignment_rules_name_arabic);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_arabic", assignmentRule.u_assignment_rules_desc_arabic);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_01", assignmentRule.u_assignment_rules_name_custom_01);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_01", assignmentRule.u_assignment_rules_desc_custom_01);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_02", assignmentRule.u_assignment_rules_name_custom_02);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_02", assignmentRule.u_assignment_rules_desc_custom_02);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_03", assignmentRule.u_assignment_rules_name_custom_03);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_03", assignmentRule.u_assignment_rules_desc_custom_03);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_04", assignmentRule.u_assignment_rules_name_custom_04);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_04", assignmentRule.u_assignment_rules_desc_custom_04);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_05", assignmentRule.u_assignment_rules_name_custom_05);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_05", assignmentRule.u_assignment_rules_desc_custom_05);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_06", assignmentRule.u_assignment_rules_name_custom_06);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_06", assignmentRule.u_assignment_rules_desc_custom_06);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_07", assignmentRule.u_assignment_rules_name_custom_07);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_07", assignmentRule.u_assignment_rules_desc_custom_07);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_08", assignmentRule.u_assignment_rules_name_custom_08);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_08", assignmentRule.u_assignment_rules_desc_custom_08);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_09", assignmentRule.u_assignment_rules_name_custom_09);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_09", assignmentRule.u_assignment_rules_desc_custom_09);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_10", assignmentRule.u_assignment_rules_name_custom_10);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_10", assignmentRule.u_assignment_rules_desc_custom_10);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_11", assignmentRule.u_assignment_rules_name_custom_11);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_11", assignmentRule.u_assignment_rules_desc_custom_11);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_12", assignmentRule.u_assignment_rules_name_custom_12);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_12", assignmentRule.u_assignment_rules_desc_custom_12);
            htUpdateAssignmentRule.Add("@u_assignment_rules_name_custom_13", assignmentRule.u_assignment_rules_name_custom_13);
            htUpdateAssignmentRule.Add("@u_assignment_rules_desc_custom_13", assignmentRule.u_assignment_rules_desc_custom_13);
            //htCreateAssignmentRule.Add("@u_assignment_rules_values", assignmentRule.u_assignment_rules_values);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_assignment_rule", htUpdateAssignmentRule);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable SearchAssignmentRule(SystemAssignmentRules assignmentRule)
        {
            Hashtable htSearchAssignmentRule = new Hashtable();
            htSearchAssignmentRule.Add("@u_assignment_rules_id_pk", assignmentRule.u_assignment_rules_id_pk);
            htSearchAssignmentRule.Add("@u_assignment_rules_name", assignmentRule.u_assignment_rules_name);
            if (assignmentRule.u_assignment_rules_status_id_fk == "0")
            {
                htSearchAssignmentRule.Add("@u_assignment_rules_status_id_fk", DBNull.Value);
            }
            else
            {
                htSearchAssignmentRule.Add("@u_assignment_rules_status_id_fk", assignmentRule.u_assignment_rules_status_id_fk);
            }

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_assignment_rule", htSearchAssignmentRule);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateAssignmentStatus(string u_assignment_rules_system_id_pk)
        {
            Hashtable htUpdateStatus = new Hashtable();
            htUpdateStatus.Add("@u_assignment_rules_system_id_pk", u_assignment_rules_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_assignment_rule_status", htUpdateStatus);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static DataTable GetCatalogItems(string u_assignment_rules_system_id_pk)
        {
            Hashtable htGetCatalogItems = new Hashtable();
            htGetCatalogItems.Add("@u_assignment_rule_id_fk", u_assignment_rules_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_assignment_catalog_items", htGetCatalogItems);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertCatalogItemForRule(string assignment_rule_catalog_item, string u_assignment_rule_id_fk)
        {
            Hashtable htInsertCatalogItems = new Hashtable();
            htInsertCatalogItems.Add("@assignment_rule_catalog_item", assignment_rule_catalog_item);
            htInsertCatalogItems.Add("@u_assignment_rule_id_fk", u_assignment_rule_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_assignment_rule_catalog_item", htInsertCatalogItems);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetCatalogItemForRule(string assignment_rule_catalog_item, string u_assignment_rule_id_fk)
        {
            Hashtable htInsertCatalogItems = new Hashtable();
            htInsertCatalogItems.Add("@assignment_rule_catalog_item", assignment_rule_catalog_item);
            htInsertCatalogItems.Add("@u_assignment_rule_id_fk", u_assignment_rule_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_assignment_rule_catalog_item", htInsertCatalogItems);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertCatalogItemForRuleFromCopy(string assignment_rule_catalog_item, string u_assignment_rule_id_fk)
        {
            Hashtable htInsertCatalogItems = new Hashtable();
            htInsertCatalogItems.Add("@assignment_rule_catalog_item", assignment_rule_catalog_item);
            htInsertCatalogItems.Add("@u_assignment_rule_id_fk", u_assignment_rule_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_assignment_rule_catalog_item_for_copy", htInsertCatalogItems);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static int DeleteCatalog(string u_assignment_rule_item_system_id_pk)
        {
            Hashtable htInsertCatalogItems = new Hashtable();
            htInsertCatalogItems.Add("@u_assignment_rule_item_system_id_pk", u_assignment_rule_item_system_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_assignment_rule_catalog_item", htInsertCatalogItems);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
