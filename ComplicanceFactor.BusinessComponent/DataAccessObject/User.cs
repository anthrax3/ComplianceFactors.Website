using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class User
    {
        public bool u_splash_display_flag { get; set; }
        public string currentSessionGuid { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public string Username_enc_ash { get; set; }
        public string Password_enc_ash { get; set; }
        public string Password_enc_salt { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string EmailId { get; set; }
        public string Mobiletype { get; set; }
        public string MobileCarrier { get; set; }
        public string MobileNumber { get; set; }
        public string WorkPhone { get; set; }
        public string Workextension { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalcode { get; set; }
        public string Country { get; set; }
        public string DomainId { get; set; }
        public string LocaleId { get; set; }
        public string TimezoneId { get; set; }
        public string Usertype { get; set; }
        public string CultureName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string creation_type { get; set; }
        public string Active_status_flag { get; set; }
        public string Active_Type { get; set; }
        public string Hris_employeid { get; set; }
        public string Hris_employee_type { get; set; }
        public DateTime? Hris_hire_date { get; set; }
        public DateTime? Hris_last_rehire_date { get; set; }
        public string Hris_company { get; set; }
        public string Hris_region { get; set; }
        public string Hris_division { get; set; }
        public string Hris_department { get; set; }
        public string Hris_cost_center { get; set; }
        public string Hris_job_group { get; set; }
        public string Hris_job_code { get; set; }
        public string Hris_job_title { get; set; }
        public string Hris_job_position { get; set; }
        public string Hris_pay_grade { get; set; }


        public string Hris_manager_id { get; set; }
        public string Hris_supervisor_id { get; set; }
        public string Hris_Alternate_manager_id { get; set; }
        public string Hris_alternate_supervisor_id { get; set; }
        public string Hris_mentor_id { get; set; }
        public string Alternate_mentor_id { get; set; }

        public string Hris_manager_text { get; set; }
        public string Hris_supervisor_text { get; set; }
        public string Hris_Alternate_manager_text { get; set; }
        public string Hris_alternate_supervisor_text { get; set; }
        public string Hris_mentor_text { get; set; }
        public string Alternate_mentor_text { get; set; }


        public bool sr_is_employee { get; set; }
        public bool sr_is_manager { get; set; }
        public bool sr_is_compliance { get; set; }
        public bool sr_is_instructor { get; set; }
        public bool sr_is_training { get; set; }
        public bool sr_is_administrator { get; set; }
        public bool sr_is_system_admin { get; set; }
        public bool sr_is_compliance_approver { get; set; }
        public string Custom_01 { get; set; }
        public string Custom_02 { get; set; }
        public string Custom_03 { get; set; }
        public string Custom_04 { get; set; }
        public string Custom_05 { get; set; }
        public string Custom_06 { get; set; }
        public string Custom_07 { get; set; }
        public string Custom_08 { get; set; }
        public string Custom_09 { get; set; }
        public string Custom_10 { get; set; }
        public string Custom_11 { get; set; }
        public string Custom_12 { get; set; }
        public string Custom_13 { get; set; }
        public string LastPassword_enc { get; set; }


        public int Role { get; set; }




        public string lastvisited { get; set; }
        public string selectedlanguage { get; set; }
        public string u_current_username { get; set; }

        //convert boolean value to string using stored procedure
        public string text_sr_is_employee { get; set; }
        public string text_sr_is_manager { get; set; }
        public string text_sr_is_compliance { get; set; }
        public string text_sr_is_instructor { get; set; }
        public string text_sr_is_training { get; set; }
        public string text_sr_is_administrator { get; set; }
        public string text_sr_is_system_admin { get; set; }
        public string text_sr_is_compliance_approver { get; set; }

        public bool text_sr_is_compliance_approver_text { get; set; }



        public bool u_hris_is_rehire { get; set; }
        public string u_hris_is_rehire_text { get; set; }
        public string u_locale_descriptoin { get; set; }
        public string u_timezone_location { get; set; }
        public DateTime utcdatetime { get; set; }
        public DateTime localdatetime { get; set; }
        public string converted_date_time { get; set; }
        public string s_locale_culture { get; set; }
        public string check_last_visited_tab_role { get; set; }

        public bool u_is_active { get; set; }

        public string u_country_name { get; set; }

        public string u_profile_my_courses_collapse_pref { get; set; }
        public string u_profile_my_curricula_collapse_pref { get; set; }
        public string u_profile_my_learning_history_collapse_pref { get; set; }
        public int u_profile_my_courses_records_display_pref { get; set; }
        public int u_profile_my_curricula_records_display_pref { get; set; }
        public int u_profile_my_learning_history_records_display_pref { get; set; }
        public string u_profile_my_todos_collapse_pref { get; set; }
        public string u_profile_my_team_collapse_pref { get; set; }
        public string u_profile_my_report_history_collapse_pref { get; set; }
        public int u_profile_my_todos_records_display_pref { get; set; }
        public int u_profile_my_team_records_display_pref { get; set; }
        public int u_profile_my_report_history_records_display_pref { get; set; }
        public string u_profile_my_system_splashes_collapse_pref { get; set; }
        public string u_profile_my_system_themes_collapse_pref { get; set; }
        public string u_profile_my_system_reports_collapse_pref { get; set; }
        public int u_profile_my_system_splashes_records_display_pref { get; set; }
        public int u_profile_my_system_themes_records_display_pref { get; set; }
        public int u_profile_my_system_reports_records_display_pref { get; set; }

        public string u_profile_my_admin_todos_collapse_pref { get; set; }
        public string u_profile_my_amdin_courses_collapse_pref { get; set; }
        public string u_profile_my_admin_reports_collapse_pref { get; set; }
        public int u_profile_my_admin_todos_display_pref { get; set; }
        public int u_profile_my_admin_courses_display_pref { get; set; }
        public int u_profile_my_admin_reports_display_pref { get; set; }

        public string u_profile_my_inst_todos_collapse_pref { get; set; }
        public string u_profile_my_inst_rosters_collapse_pref { get; set; }
        public string u_profile_my_inst_reports_collapse_pref { get; set; }
        public int u_profile_my_inst_todos_display_pref { get; set; }
        public int u_profile_my_inst_rosters_display_pref { get; set; }
        public int u_profile_my_inst_reports_display_pref { get; set; }
        public string u_profile_my_train_todos_collapse_pref { get; set; }
        public string u_profile_my_train_deliveries_collapse_pref { get; set; }
        public string u_profile_my_train_reports_collapse_pref { get; set; }
        public int u_profile_my_train_todos_display_pref { get; set; }
        public int u_profile_my_train_deliveries_display_pref { get; set; }
        public int u_profile_my_train_reports_display_pref { get; set; }
        public string u_profile_my_comp_todos_collapse_pref { get; set; }
        public string u_profile_my_comp_harm_collapse_pref { get; set; }
        public string u_profile_my_comp_giris_collapse_pref { get; set; }
        public string u_profile_my_comp_reports_collapse_pref { get; set; }
        public int u_profile_my_comp_todos_display_pref { get; set; }
        public int u_profile_my_comp_harm_display_pref { get; set; }
        public int u_profile_my_comp_giris_display_pref { get; set; }
        public int u_profile_my_comp_reports_display_pref { get; set; }

        public string type { get; set; }
        public string courseId { get; set; }
        public string deliveryId { get; set; }
    }
}
