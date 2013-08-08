using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemAssignmentRules
    {
        public string u_assignment_rules_system_id_pk { get; set; }
        public string u_assignment_rules_id_pk { get; set; }
        public string u_assignment_rules_name { get; set; }
        public string u_assignment_rules_desc { get; set; }
        public string u_assignment_rules_status_id_fk { get; set; }
        public bool u_assignment_rules_required_flag { get; set; }
        public string u_assignment_rules_due_select_param { get; set; }
        public DateTime u_assignment_rules_fix_date_param { get; set; }
        public int u_assignment_rules_days_param { get; set; }

        public string u_assignment_rules_name_uk_english { get; set; }
        public string u_assignment_rules_desc_uk_english { get; set; }
        public string u_assignment_rules_name_ca_french { get; set; }
        public string u_assignment_rules_desc_ca_french { get; set; }
        public string u_assignment_rules_name_fr_french { get; set; }
        public string u_assignment_rules_desc_fr_french { get; set; }
        public string u_assignment_rules_name_mx_spanish { get; set; }
        public string u_assignment_rules_desc_mx_spanish { get; set; }
        public string u_assignment_rules_name_sp_spanish { get; set; }
        public string u_assignment_rules_desc_sp_spanish { get; set; }
        public string u_assignment_rules_name_portuguese { get; set; }
        public string u_assignment_rules_desc_portuguese { get; set; }
        public string u_assignment_rules_name_simp_chinese { get; set; }
        public string u_assignment_rules_desc_simp_chinese { get; set; }
        public string u_assignment_rules_name_german { get; set; }
        public string u_assignment_rules_desc_german { get; set; }
        public string u_assignment_rules_name_japanese { get; set; }
        public string u_assignment_rules_desc_japanese { get; set; }
        public string u_assignment_rules_name_russian { get; set; }
        public string u_assignment_rules_desc_russian { get; set; }
        public string u_assignment_rules_name_danish { get; set; }
        public string u_assignment_rules_desc_danish { get; set; }
        public string u_assignment_rules_name_polish { get; set; }
        public string u_assignment_rules_desc_polish { get; set; }
        public string u_assignment_rules_name_swedish { get; set; }
        public string u_assignment_rules_desc_swedish { get; set; }
        public string u_assignment_rules_name_finnish { get; set; }
        public string u_assignment_rules_desc_finnish { get; set; }
        public string u_assignment_rules_name_korean { get; set; }
        public string u_assignment_rules_desc_korean { get; set; }
        public string u_assignment_rules_name_italian { get; set; }
        public string u_assignment_rules_desc_italian { get; set; }
        public string u_assignment_rules_name_dutch { get; set; }
        public string u_assignment_rules_desc_dutch { get; set; }
        public string u_assignment_rules_name_indonesian { get; set; }
        public string u_assignment_rules_desc_indonesian { get; set; }
        public string u_assignment_rules_name_greek { get; set; }
        public string u_assignment_rules_desc_greek { get; set; }
        public string u_assignment_rules_name_hungarian { get; set; }
        public string u_assignment_rules_desc_hungarian { get; set; }
        public string u_assignment_rules_name_norwegian { get; set; }
        public string u_assignment_rules_desc_norwegian { get; set; }
        public string u_assignment_rules_name_turkish { get; set; }
        public string u_assignment_rules_desc_turkish { get; set; }
        public string u_assignment_rules_name_arabic { get; set; }
        public string u_assignment_rules_desc_arabic { get; set; }
        public string u_assignment_rules_name_custom_01 { get; set; }
        public string u_assignment_rules_desc_custom_01 { get; set; }
        public string u_assignment_rules_name_custom_02 { get; set; }
        public string u_assignment_rules_desc_custom_02 { get; set; }
        public string u_assignment_rules_name_custom_03 { get; set; }
        public string u_assignment_rules_desc_custom_03 { get; set; }
        public string u_assignment_rules_name_custom_04 { get; set; }
        public string u_assignment_rules_desc_custom_04 { get; set; }
        public string u_assignment_rules_name_custom_05 { get; set; }
        public string u_assignment_rules_desc_custom_05 { get; set; }
        public string u_assignment_rules_name_custom_06 { get; set; }
        public string u_assignment_rules_desc_custom_06 { get; set; }
        public string u_assignment_rules_name_custom_07 { get; set; }
        public string u_assignment_rules_desc_custom_07 { get; set; }
        public string u_assignment_rules_name_custom_08 { get; set; }
        public string u_assignment_rules_desc_custom_08 { get; set; }
        public string u_assignment_rules_name_custom_09 { get; set; }
        public string u_assignment_rules_desc_custom_09 { get; set; }
        public string u_assignment_rules_name_custom_10 { get; set; }
        public string u_assignment_rules_desc_custom_10 { get; set; }
        public string u_assignment_rules_name_custom_11 { get; set; }
        public string u_assignment_rules_desc_custom_11 { get; set; }
        public string u_assignment_rules_name_custom_12 { get; set; }
        public string u_assignment_rules_desc_custom_12 { get; set; }
        public string u_assignment_rules_name_custom_13 { get; set; }
        public string u_assignment_rules_desc_custom_13 { get; set; }

        public string u_assignment_rule_item_system_id_pk { get; set; }
        public string u_assignment_rule_item_id_fk { get; set; }
        public string u_assignment_rule_id_fk { get; set; }

        //e e_tb_assignment_rule_groups
        public string u_assignment_rule_group_system_id_fk { get; set; }
        public string u_assignment_rule_group_id_fk { get; set; }
        //public string u_assignment_rule_id_fk { get; set; }


    }
}
