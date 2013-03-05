using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemCurriculum
    {

        public bool c_curriculum_active_flag { get; set; }
        //public string c_curriculum_owner_id_fk { get; set; }
        //public string c_curriculum { get; set; }
        public string c_curriculum_owner_name { get; set; }
        public string c_curriculum_coordinator_name { get; set; }
        public string c_curriculum_type { get; set; }
        public string c_curriculum_id_pk { get; set; }
        public string c_curriculum_desc { get; set; }
        public string c_curriculum_abstract { get; set; }
        public string c_curriculum_icon_uri { get; set; }
        public string c_curriculum_version { get; set; }
        public bool c_curriculum_approval_req { get; set; }
        public string c_curriculum_approval_id_fk { get; set; }
        public int? c_curriculum_credit_hours { get; set; }
        public int? c_curriculum_credit_units { get; set; }
        public bool c_curriculum_cert_flag { get; set; }
        //public int? c_curriculum_cert_cycle_days { get; set; }
        public int? c_curriculum_recurrance_grace_days { get; set; }
        public DateTime c_curriculum_cert_date { get; set; }
        public string c_curriculum_owner_id_fk { get; set; }
        public string c_curriculum_coordinator_id_fk { get; set; }
        //public bool c_curriculum_active_flag { get; set; }
        public string c_curriculum_active_type_id_fk { get; set; }
        public bool c_curriculum_visible_flag { get; set; }
        public string c_curriculum_custom_01 { get; set; }
        public string c_curriculum_custom_02 { get; set; }
        public string c_curriculum_custom_03 { get; set; }
        public string c_curriculum_custom_04 { get; set; }
        public string c_curriculum_custom_05 { get; set; }
        public string c_curriculum_custom_06 { get; set; }
        public string c_curriculum_custom_07 { get; set; }
        public string c_curriculum_custom_08 { get; set; }
        public string c_curriculum_custom_09 { get; set; }
        public string c_curriculum_custom_10 { get; set; }
        public string c_curriculum_custom_11 { get; set; }
        public string c_curriculum_custom_12 { get; set; }
        public string c_curriculum_custom_13 { get; set; }
        public string c_curriculum_title { get; set; }
        public string c_curriculum_system_id_pk { get; set; }
        public string c_curriculum_id_fk { get; set; }
        public string c_curriculum_Prerequistist { get; set; }
        public string c_curriculum_Equivalencies { get; set; }
        public string c_curriculum_Fulfillments { get; set; }
        public string c_curriculum_approval_id { get; set; }
        public int? c_curriculum_recurrance_every { get; set; }
        public string c_curriculum_recurrance_period { get; set; }
        public string c_curriculum_recurance_date_option { get; set; }
        public DateTime? c_curriculum_recurance_date { get; set; }
        public string c_related_curriculum_group_id { get; set; }
        public int? c_curriculum_cost { get; set; }
        public string cost_text { get; set; }
        public string c_curriculum_status_name { get; set; }
        public string c_curriculum_visible_flag_text { get; set; }
        public string c_curriculum_approval_name { get; set; }
        public string c_curriculum_recurrences_text { get; set; }
        public string c_curriculum_icon_uri_file_name { get; set; }
        public string c_curriculum_approval_req_text { get; set; }
        public string c_related_domain_id_fk { get; set; }
        public string c_curriculum_type_id_fk { get; set; }
        //attchment
        public string c_curriculum_attachment { get; set; }
        public string c_curriculum_attachment_file_guid { get; set; }
        public string c_curriculum_attachment_file_name { get; set; }
        public string c_curriculum_attchments_system_id_pk { get; set; }
        //domain
        public string c_curriculum_domain { get; set; }
        public string c_domain_id_fk { get; set; }
        //Cousre Category
        public string c_curriculum_category { get; set; }
        public string c_related_category_id_fk { get; set; }
        public bool c_category { get; set; }
        public string c_new_curriculum_system_id_pk { get; set; }
        public bool c_domain { get; set; }
        public bool c_audiences { get; set; }
        public bool c_recurrance { get; set; }
        public bool c_prerequisite { get; set; }
        public bool c_equivalency { get; set; }
        public bool c_fulfillment { get; set; }
        public string s_curriculum_locale { get; set; }
        public bool c_attchment { get; set; }
        public string c_created_name { get; set; }
        public string c_curriculum_created_by_id_fk { get; set; }
        //locale
        public string s_curriculum_locale_title { get; set; }
        public string s_curriculum_locale_description { get; set; }
        public string s_curriculum_system_id_fk { get; set; }
        public string s_curriculum_locale_abstract { get; set; }
        public string s_locale_id_fk { get; set; }
        public int s_curriculum_locale_sort_order { get; set; }
        public string s_curriculum_locales_system_id_pk { get; set; }
        public string s_locale_text { get; set; }
        public string s_locale_system_id_pk { get; set; }
        //Path 
        public string c_curricula_path_system_id_pk { get; set; }
        public string c_curricula_id_fk { get; set; }
        public string c_curricula_path_name { get; set; }
        public string c_curricula_path_Description { get; set; }
        public string c_curricula_path_abstract { get; set; }
        public bool c_curricula_path_enforce_section_seq_flag { get; set; }
        public int c_curricula_path_complete { get; set; }
        public int c_curricula_path_sections { get; set; }
        public string c_curricula_path_section { get; set; }
        public string c_curricula_path_courses { get; set; }

        public string c_curriculum_path { get; set; }
        public string c_curriculum_path_sections { get; set; }
        public string c_curriculum_path_courses { get; set; }
        public bool c_path { get; set; }

        //Recert Path
        public string c_curricula_recert_path_system_id_pk { get; set; }
        public string c_curricula_recert_id_fk { get; set; }
        public string c_curricula_recert_path_name { get; set; }
        public string c_curricula_recert_path_Description { get; set; }
        public string c_curricula_recert_path_abstract { get; set; }
        public bool c_curricula_recert_path_enforce_section_seq_flag { get; set; }
        public int c_curricula_recert_path_complete { get; set; }
        public int c_curricula_recert_path_sections { get; set; }
        public string c_curricula_recert_path_section { get; set; }
        public string c_curricula_recert_path_courses { get; set; }

        public string c_curriculum_recert_path { get; set; }
        public string c_curriculum_recert_path_sections { get; set; }
        public string c_curriculum_recert_path_courses { get; set; }
        public bool c_recert_path { get; set; }
    }
}
