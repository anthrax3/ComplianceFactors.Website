using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemCatalog
    {
        public bool c_course_active_flag { get; set; }
        public string c_course_owner_name { get; set; }
        public string c_course_coordinator_name { get; set; }
        public string c_course_id_pk { get; set; }
        public string c_course_desc { get; set; }
        public string c_course_abstract { get; set; }
        public string c_course_icon_uri { get; set; }
        public string c_course_version { get; set; }
        public bool c_course_approval_req { get; set; }
        public string c_course_approval_id_fk { get; set; }
        public int? c_course_credit_hours { get; set; }
        public int? c_course_credit_units { get; set; }
        public bool c_course_cert_flag { get; set; }
        public int? c_course_recurrence_grace_days { get; set; }
        public DateTime c_course_cert_date { get; set; }
        public string c_course_owner_id_fk { get; set; }
        public string c_course_coordinator_id_fk { get; set; }
        public string c_course_active_type_id_fk { get; set; }
        public bool c_course_visible_flag { get; set; }

        public string c_course_available_from_date { get; set; }
        public string c_course_available_to_date { get; set; }
        public string c_course_effective_date { get; set; }
        public string c_course_cut_off_date { get; set; }
        public string c_course_cut_off_time { get; set; }

        public string c_course_custom_01 { get; set; }
        public string c_course_custom_02 { get; set; }
        public string c_course_custom_03 { get; set; }
        public string c_course_custom_04 { get; set; }
        public string c_course_custom_05 { get; set; }
        public string c_course_custom_06 { get; set; }
        public string c_course_custom_07 { get; set; }
        public string c_course_custom_08 { get; set; }
        public string c_course_custom_09 { get; set; }
        public string c_course_custom_10 { get; set; }
        public string c_course_custom_11 { get; set; }
        public string c_course_custom_12 { get; set; }
        public string c_course_custom_13 { get; set; }
        public string c_course_title { get; set; }
        public string c_course_system_id_pk { get; set; }
        public string c_course_Prerequistist { get; set; }
        public string c_course_Equivalencies { get; set; }
        public string c_course_Fulfillments { get; set; }

        public int? c_course_recurrence_every { get; set; }
        public string c_course_recurrence_period { get; set; }
        public string c_course_recurrence_date_option { get; set; }
        public DateTime? c_course_recurrence_date { get; set; }

        public string c_related_course_group_id { get; set; }
        public int? c_course_cost { get; set; }
        public string cost_text { get; set; }
        public string c_course_status_name { get; set; }
        public string c_course_visible_flag_text { get; set; }
        public string c_course_approval_name { get; set; }
        public string c_course_recurrences_text { get; set; }
        public string c_course_icon_uri_file_name { get; set; }
        public string c_course_approval_req_text { get; set; }
        public string c_related_domain_id_fk { get; set; }
        public string c_course_created_by_id_fk { get; set; }
        public string c_delivery_system_id_pk { get; set; }
        public string c_course_id_fk { get; set; }
        public string c_delivery_id_pk { get; set; }
        public string c_delivery_type_id_fk { get; set; }
        public string c_delivery_title { get; set; }
        public string c_delivery_desc { get; set; }
        public string c_delivery_abstract { get; set; }
        public string c_delivery_icon_uri { get; set; }
        public bool c_delivery_approval_req { get; set; }
        public string c_delivery_approval_id_fk { get; set; }
        public int? c_delivery_credit_hours { get; set; }
        public int? c_delivery_credit_units { get; set; }
        public string c_delivery_owner_id_fk { get; set; }
        public string c_delivery_coordinator_id_fk { get; set; }
        public bool c_delivery_active_flag { get; set; }
        public string c_delivery_active_type_id_fk { get; set; }
        public bool c_delivery_visible_flag { get; set; }

        public string c_delivery_available_from_date { get; set; }
        public string c_delivery_available_to_date { get; set; }
        public string c_delivery_effective_date { get; set; }
        public string c_delivery_cut_off_date { get; set; }
        public string c_delivery_cut_off_time { get; set; }

        public int? c_delivery_min_enroll { get; set; }
        public int? c_delivery_max_enroll { get; set; }
        public int? c_delivery_enroll_threshold { get; set; }
        public bool c_delivery_waitlist_flag { get; set; }
        public int? c_delivery_max_waitlist { get; set; }
        public string c_vlt_type_id_fk { get; set; }
        public string c_vlt_session_id_fk { get; set; }
        public string c_vlt_launch_url { get; set; }
        public string c_vlt_launch_param { get; set; }
        public string c_olt_type_id_fk { get; set; }
        public string c_olt_object_id_fk { get; set; }
        public string c_olt_launch_url { get; set; }
        public string c_olt_launch_param { get; set; }
        public int c_olt_mastery_score { get; set; }
        public string c_ojt_job_site_id_fk { get; set; }
        public string c_sop_doc_id_fk { get; set; }
        public string c_survey_id_fk { get; set; }
        public string c_survey_type_fk { get; set; }
        public string c_survey_scoring_scheme_id_fk { get; set; }
        public string c_exam_id_fk { get; set; }
        public string c_exam_type_fk { get; set; }
        public string c_exam_scoring_scheme_id_fk { get; set; }
        public string c_exam_passing_grade_id_fk { get; set; }
        public string c_checklist_id_fk { get; set; }
        public string c_checklist_fk { get; set; }
        public string c_delivery_custom_01 { get; set; }
        public string c_delivery_custom_02 { get; set; }
        public string c_delivery_custom_03 { get; set; }
        public string c_delivery_custom_04 { get; set; }
        public string c_delivery_custom_05 { get; set; }
        public string c_delivery_custom_06 { get; set; }
        public string c_delivery_custom_07 { get; set; }
        public string c_delivery_custom_08 { get; set; }
        public string c_delivery_custom_09 { get; set; }
        public string c_delivery_custom_10 { get; set; }
        public string c_delivery_custom_11 { get; set; }
        public string c_delivery_custom_12 { get; set; }
        public string c_delivery_custom_13 { get; set; }
        public string c_enroll_delivery_count { get; set; }
        public string c_delivery_attachments { get; set; }
        public string c_delivery_owner_name { get; set; }
        public string c_delivery_coordinator_name { get; set; }
        public string c_nc_olt_launch_url { get; set; }
        public string c_nc_olt_launch_param { get; set; }
        public bool c_nc_olt_waitlist_flag { get; set; }
        public string c_nc_olt_wrapper_id_fk { get; set; }
        public string c_created_name { get; set; }
        public string c_delivery_approval_req_text { get; set; }
        public string s_delivery_type_text { get; set; }
        public string c_session_list { get; set; }
        public string c_instructor_list { get; set; }
        public string c_course_list { get; set; }
        public string c_delivery_list { get; set; }
        public string c_session_start_date_time { get; set; }
        public string c_session_end_date_time { get; set; }
        public string user_name { get; set; }
        public string c_to_address { get; set; }
        public string c_session_system_id_pk { get; set; }
        public string c_session_id_pk { get; set; }
        public string c_delivery_id_fk { get; set; }
        public string c_session_title { get; set; }
        public string c_sessions_desc { get; set; }
        public DateTime? c_session_start_date { get; set; }
        public DateTime? c_session_end_date { get; set; }
        public DateTime? c_session_start_time { get; set; }
        public DateTime? c_sessions_end_time { get; set; }
        public DateTime? c_session_duration { get; set; }
        public string c_session_location_id_fk { get; set; }
        public string c_session_facility_id_fk { get; set; }
        public string c_session_room_id_fk { get; set; }
        public string c_session_location_names { get; set; }
        public string c_session_facility_names { get; set; }
        public string c_session_room_names { get; set; }
        public string c_session_location_name { get; set; }
        public string c_session_facility_name { get; set; }
        public string c_session_room_name { get; set; }
        public string c_instructor_name { get; set; }
        public string c_instructor_id { get; set; }
        public int session_start_HH { get; set; }
        public int session_start_MM { get; set; }
        public int session_end_HH { get; set; }
        public int session_end_MM { get; set; }
        public int session_duration_HH { get; set; }
        public int session_duration_MM { get; set; }
        public string c_resource_id_pk { get; set; }
        public string c_resource_name { get; set; }
        public string c_material_id_pk { get; set; }
        public string c_material_name { get; set; }
        public string c_session_instructor { get; set; }
        public string c_delivery_resources { get; set; }
        public string c_delivery_material { get; set; }
        public string c_session_last_name { get; set; }
        public string c_session_first_name { get; set; }
        public string c_deliveries { get; set; }
        public string c_sessions { get; set; }
        public string c_instructor_system_id_pk { get; set; }
        public string c_delivery_attachment_id_pk { get; set; }
        public string c_delivery_attachment_file_guid { get; set; }
        public string c_delivery_attachment_file_name { get; set; }
        public string c_course_resources_id_pk { get; set; }
        public string c_course_material_id_pk { get; set; }
        public string c_course_domains { get; set; }
        public string c_course_category { get; set; }
        public bool c_category { get; set; }
        public string c_new_course_system_id_pk { get; set; }
        public bool c_domain { get; set; }
        public bool c_audiences { get; set; }
        public bool c_recurrance { get; set; }
        public bool c_prerequisite { get; set; }
        public bool c_equivalency { get; set; }
        public bool c_fulfillment { get; set; }
        public bool c_delivery { get; set; }
        public string s_course_locale { get; set; }
        public string s_delivery_locale { get; set; }
        public DateTime dtFromDate { get; set; }
        public DateTime dtpEndDate { get; set; }
        public DateTime? dtpStartDate { get; set;}
        public int recurrenceEvery {get;set;}
        public int breakOccuranceCount { get;set;}
        public DateTime? dtpBreakOccuranceDate { get; set;}
        public string u_holiday_schedule_system_id_pk { get; set;}
        public string s_weekday_schedule_system_id_pk { get; set;}
        public string c_waitlist_count { get; set; }
        public string c_session_date_format { get; set; }
        public string c_delivery_type_id { get; set; }
        public string c_location_airport_code { get; set; }

        public string s_locale_culture { get; set; }
        public string s_reset_waitlist { get; set; }

        public string u_hris_employee_id{ get; set; }
        public string c_employee_name { get; set; }
    }
}

