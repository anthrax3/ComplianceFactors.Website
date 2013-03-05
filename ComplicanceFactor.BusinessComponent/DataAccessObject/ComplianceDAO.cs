using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class ComplianceDAO
    {
        //Case
        public string c_case_id_pk { get; set; }
        public string u_user_id_fk { get; set; }
        public string c_case_number { get; set; }
        public string c_case_title { get; set; }
        public string c_case_category_fk { get; set; }
        public string c_case_type_fk { get; set; }
        public string c_case_status { get; set; }
        public string c_employee_name { get; set; }
        public DateTime c_employee_dob { get; set; }
        public DateTime c_employee_hire_date { get; set; }
        public string c_employee_id { get; set; }
        public string c_ssn { get; set; }
        public string c_supervisor { get; set; }
        public string c_incident_location { get; set; }
        public DateTime c_incident_date { get; set; }
        public DateTime c_incident_time { get; set; }
        public string c_employee_report_location { get; set; }
        public string c_note { get; set; }
        public string c_root_cause_analysic_info { get; set; }
        public string c_corrective_action_info { get; set; }
        public string c_osha_300_case_outcome { get; set; }
        public int c_osha_300_days_away_from_work { get; set; }
        public int c_osha_300_days_of_restriction { get; set; }
        public string c_osha_300_info { get; set; }
        public string c_osha_301_worker_gender { get; set; }
        public DateTime? c_osha_301_work_start_time { get; set; }
        public string c_osha_301_physician { get; set; }
        public string c_osha_301_treatment_facilities { get; set; }
        public bool c_osha_301_emergency_room { get; set; }
        public bool c_osha_301_hospitalized { get; set; }
        public string c_osha_301_address1 { get; set; }
        public string c_osha_301_address2 { get; set; }
        public string c_osha_301_address3 { get; set; }
        public string c_osha_301_city { get; set; }
        public string c_osha_301_state { get; set; }
        public string c_osha_301_zip { get; set; }
        public string c_osha_301_info_1 { get; set; }
        public string c_osha_301_info_2 { get; set; }
        public string c_osha_301_info_3 { get; set; }
        public string c_osha_301_info_4 { get; set; }
        public string c_custom_01 { get; set; }
        public string c_custom_02 { get; set; }
        public string c_custom_03 { get; set; }
        public string c_custom_04 { get; set; }
        public string c_custom_05 { get; set; }
        public string c_custom_06 { get; set; }
        public string c_custom_07 { get; set; }
        public string c_custom_08 { get; set; }
        public string c_custom_09 { get; set; }
        public string c_custom_10 { get; set; }
        public string c_custom_11 { get; set; }
        public string c_custom_12 { get; set; }
        public string c_custom_13 { get; set; }
        public DateTime? c_case_date { get; set; }
        public DateTime c_temp_case_date { get; set; }
        public DateTime? c_osha_300_date_of_death { get; set; }
        public string c_osha_300_type_of_illness { get; set; }
        public string u_time_zone_display { get; set; }


        // Case details OI and MVI 

        public DateTime? c_time_and_date_notified { get; set; }
        public string c_job_title { get; set; }
        public string c_department_code { get; set; }
        public bool c_privacy_case { get; set; }
        public bool c_company_owned { get; set; }
        public string c_location_description { get; set; }
        public string c_incident_description { get; set; }
        public string c_injury_complaint { get; set; }
        public string c_injury_type_fk { get; set; }
        public string c_injury_cause_fk { get; set; }
        public string c_contributing_factors { get; set; }
        public string c_contributing_objects { get; set; }
        public string c_severity_fk { get; set; }
        public string c_hospital { get; set; }
        public string c_treatment_description { get; set; }
        public string c_dart { get; set; }
        public string c_est_lwd { get; set; }
        public string c_actual_lwd_and_osha_lwd { get; set; }
        public string c_light_duty { get; set; }
        public string c_est_ld { get; set; }
        public string c_actual_ld_and_osha_restricted { get; set; }
        public string c_restricted_or_transferred { get; set; }
        public string c_firstday_of_days_away { get; set; }
        public string c_firstday_of_days_restricted_or_transferred { get; set; }
        public string c_lastday_days_away { get; set; }
        public string c_lastday_days_restricted_or_transferred { get; set; }
        //have to add “has employee returned to full duty?”  Yes/No

        //MV 
        public string c_case_desc_vehicle_01_fk { get; set; }
        public string c_case_desc_vehicle_02_fk { get; set; }

        public string c_case_desc_vehicle_id { get; set; }
        public string c_case_desc_vehicle_vin { get; set; }
        public string c_case_desc_licence_number { get; set; }
        public string c_case_desc_vehicle_make { get; set; }
        public string c_case_desc_vehicle_model { get; set; }
        public string c_case_desc_vehicle_type_fk { get; set; }
        public string c_case_desc_year { get; set; }
        public string c_case_desc_state { get; set; }
        public string c_case_desc_company_vehicle_struck_fk { get; set; }
        public string c_case_desc_company_vehicle_struck_by_fk { get; set; }
        public bool c_case_desc_non_collision { get; set; }
        public string c_case_desc_non_collision_text { get; set; }

        public string c_case_detail_drivers_lic { get; set; }
        public string c_case_detail_state_and_class { get; set; }
        public DateTime? c_case_detail_expire_date { get; set; }
        public string c_case_detail_address { get; set; }
        public string c_case_detail_city { get; set; }
        public string c_case_detail_state { get; set; }
        public string c_case_detail_nearest_cross_street { get; set; }
        public string c_case_detail_type_of_roadway { get; set; }
        public string c_case_detail_road_condition_fk { get; set; }
        public DateTime? c_case_detail_time_of_day { get; set; }
        // here we need to add one column
        public string c_case_detail_weather_fk { get; set; }
        public string c_case_detail_traffic_condition_fk { get; set; }
        public string c_case_detail_traffic_controls_fk { get; set; }
        public string c_case_detail_oprating_speed { get; set; }
        public string c_case_detail_speed_limit { get; set; }
        public string c_case_detail_vehicle_struck_fk { get; set; }
        public string c_case_detail_vehicle_struck_by_fk { get; set; }
        public string c_case_detail_collision_type_fk { get; set; }
        public string c_case_detail_collision_location_fk { get; set; }
        public string c_case_detail_collision_direction_fk { get; set; }
        public string c_case_detail_non_collision_type_fk { get; set; }
        public string c_case_detail_number_of_vehicle_involved { get; set; }
        public string c_case_detail_number_of_vehicle_towed { get; set; }
        public string c_case_detail_number_of_people_injured { get; set; }
        public string c_case_detail_number_of_people_killed { get; set; }
        public bool c_case_detail_cituation_issued { get; set; }
        public string c_case_detail_at_whom { get; set; }
        public bool c_case_detail_at_fault { get; set; }
        public bool c_case_detail_contributory { get; set; }
        public string c_case_detail_gross_vehicle_weight { get; set; }
        public string c_case_detail_combined_gross_vehicle_weight { get; set; }
        public bool c_case_detail_dot_vehicle { get; set; }
        public bool c_case_detail_dot_driver { get; set; }
        public bool c_case_detail_seat_belt_used { get; set; }
        public bool c_case_detail_air_bag_eqiupped { get; set; }
        public bool c_case_detail_air_bag_deployed { get; set; }
        public bool c_case_detail_cellphone_in_use { get; set; }
        public bool c_case_detail_computer_in_use { get; set; }
        public bool c_case_detail_special_equipment { get; set; }
        public string c_case_detail_special_equipment_text { get; set; }
        public string c_case_detail_location_of_impact_fk { get; set; }
        public bool c_case_detail_driver_injured { get; set; }
        public bool c_case_detail_passenger_injured { get; set; }
        public string c_case_detail_damage_heavy { get; set; }
        public string c_case_detail_damage_moderate { get; set; }
        public string c_case_detail_damage_light { get; set; }


        public string c_pub_vehicle_driver_name { get; set; }
        public string c_pub_vehicle_driver_address { get; set; }
        public string c_pub_vehicle_driver_contact { get; set; }
        public string c_pub_vehicle_owner_name { get; set; }
        public string c_pub_vehicle_owner_address { get; set; }
        public string c_pub_vehicle_owner_contact { get; set; }
        public string c_pub_vehicle_vehicle_id { get; set; }
        public string c_pub_vehicle_vehicle_vin { get; set; }
        public string c_pub_vehicle_licence_number { get; set; }
        public string c_pub_vehicle_vehicle_make { get; set; }
        public string c_pub_vehicle_vehicle_model { get; set; }
        public string c_pub_vehicle_vehicle_type_fk { get; set; }
        public string c_pub_vehicle_year { get; set; }
        public string c_pub_vehicle_state { get; set; }
        public string c_pub_vehicle_gross_vehicle_weight { get; set; }
        public string c_pub_vehicle_combined_gross_vehicle_weight { get; set; }
        public bool c_pub_vehicle_dot_vehicle { get; set; }
        public bool c_pub_vehicle_dot_driver { get; set; }
        public bool c_pub_vehicle_seat_belt_used { get; set; }
        public bool c_pub_vehicle_air_bag_eqiupped { get; set; }
        public bool c_pub_vehicle_air_bag_deployed { get; set; }
        public bool c_pub_vehicle_cellphone_in_use { get; set; }
        public bool c_pub_vehicle_computer_in_use { get; set; }
        public bool c_pub_vehicle_special_equipment { get; set; }
        public string c_pub_vehicle_special_equipment_text { get; set; }
        public string c_pub_vehicle_location_of_impact_fk { get; set; }
        public bool c_pub_vehicle_driver_injured { get; set; }
        public bool c_pub_vehicle_passenger_injured { get; set; }
        public string c_pub_vehicle_driver_injured_text { get; set; }
        public string c_pub_vehicle_passenger_injured_text { get; set; }
        public string c_pub_vehicle_number_of_total_vehicle_injured { get; set; }
        public string c_pub_vehicle_damage_heavy { get; set; }
        public string c_pub_vehicle_damage_moderate { get; set; }
        public string c_pub_vehicle_damage_light { get; set; }
        //--Pedestrain Incident
        public string c_pedestrain_name { get; set; }
        public string c_pedestrain_address { get; set; }
        public string c_pedestrain_phone { get; set; }
        public string c_pedestrain_sex { get; set; }
        public string c_pedestrain_age { get; set; }
        public string c_pedestrain_collision_type_fk { get; set; }
        public string c_pedestrain_description { get; set; }
        //--BICycle Incident
        public string c_bicycle_person_name { get; set; }
        public string c_bicycle_person_address { get; set; }
        public string c_bicycle_person_phone { get; set; }
        public string c_bicycle_person_sex { get; set; }
        public string c_bicycle_person_age { get; set; }
        public string c_bicycle_person_collision_type_fk { get; set; }
        public string c_bicycle_person_description { get; set; }
        //--Animal Incident
        public string c_animal_name { get; set; }
        public string c_animal_place { get; set; }
        public string c_animal_collision_type_fk { get; set; }
        public string c_animal_description { get; set; }
        //--Fixed Object Incident
        public string c_fixed_object_property_name { get; set; }
        public string c_fixed_object_address { get; set; }
        public string c_fixed_object_contact_info { get; set; }
        public string c_fixed_object_collision_type_fk { get; set; }
        public string c_fixed_object_description { get; set; }
        public string c_fixed_object_property_description { get; set; }


        //MV newly added (for Vehicle)

        public string c_case_desc_vehicle_02_id { get; set; }
        public string c_case_desc_vehicle_02_vin { get; set; }
        public string c_case_desc_licence_02_number { get; set; }
        public string c_case_desc_vehicle_02_make { get; set; }
        public string c_case_desc_vehicle_02_model { get; set; }
        public string c_case_desc_vehicle_02_type_fk { get; set; }
        public string c_case_desc_vehicle_02_year { get; set; }
        public string c_case_desc_vehicle_02_state { get; set; }


        public string c_case_desc_vehicle_03_fk { get; set; }
        public string c_case_desc_vehicle_03_id { get; set; }
        public string c_case_desc_vehicle_03_vin { get; set; }
        public string c_case_desc_licence_03_number { get; set; }
        public string c_case_desc_vehicle_03_make { get; set; }
        public string c_case_desc_vehicle_03_model { get; set; }
        public string c_case_desc_vehicle_03_type_fk { get; set; }
        public string c_case_desc_vehicle_03_year { get; set; }
        public string c_case_desc_vehicle_03_state { get; set; }


        public string c_case_desc_vehicle_04_fk { get; set; }
        public string c_case_desc_vehicle_04_id { get; set; }
        public string c_case_desc_vehicle_04_vin { get; set; }
        public string c_case_desc_licence_04_number { get; set; }
        public string c_case_desc_vehicle_04_make { get; set; }
        public string c_case_desc_vehicle_04_model { get; set; }
        public string c_case_desc_vehicle_04_type_fk { get; set; }
        public string c_case_desc_vehicle_04_year { get; set; }
        public string c_case_desc_vehicle_04_state { get; set; }


        public string c_case_desc_vehicle_05_fk { get; set; }
        public string c_case_desc_vehicle_05_id { get; set; }
        public string c_case_desc_vehicle_05_vin { get; set; }
        public string c_case_desc_licence_05_number { get; set; }
        public string c_case_desc_vehicle_05_make { get; set; }
        public string c_case_desc_vehicle_05_model { get; set; }
        public string c_case_desc_vehicle_05_type_fk { get; set; }
        public string c_case_desc_vehicle_05_year { get; set; }
        public string c_case_desc_vehicle_05_state { get; set; }

        public string c_case_desc_vehicle_06_fk { get; set; }
        public string c_case_desc_vehicle_06_id { get; set; }
        public string c_case_desc_vehicle_06_vin { get; set; }
        public string c_case_desc_licence_06_number { get; set; }
        public string c_case_desc_vehicle_06_make { get; set; }
        public string c_case_desc_vehicle_06_model { get; set; }
        public string c_case_desc_vehicle_06_type_fk { get; set; }
        public string c_case_desc_vehicle_06_year { get; set; }
        public string c_case_desc_vehicle_06_state { get; set; }

        public string c_case_desc_vehicle_07_fk { get; set; }
        public string c_case_desc_vehicle_07_id { get; set; }
        public string c_case_desc_vehicle_07_vin { get; set; }
        public string c_case_desc_licence_07_number { get; set; }
        public string c_case_desc_vehicle_07_make { get; set; }
        public string c_case_desc_vehicle_07_model { get; set; }
        public string c_case_desc_vehicle_07_type_fk { get; set; }
        public string c_case_desc_vehicle_07_year { get; set; }
        public string c_case_desc_vehicle_07_state { get; set; }


        public string c_case_desc_vehicle_08_fk { get; set; }
        public string c_case_desc_vehicle_08_id { get; set; }
        public string c_case_desc_vehicle_08_vin { get; set; }
        public string c_case_desc_licence_08_number { get; set; }
        public string c_case_desc_vehicle_08_make { get; set; }
        public string c_case_desc_vehicle_08_model { get; set; }
        public string c_case_desc_vehicle_08_type_fk { get; set; }
        public string c_case_desc_vehicle_08_year { get; set; }
        public string c_case_desc_vehicle_08_state { get; set; }


        public string c_case_desc_vehicle_09_fk { get; set; }
        public string c_case_desc_vehicle_09_id { get; set; }
        public string c_case_desc_vehicle_09_vin { get; set; }
        public string c_case_desc_licence_09_number { get; set; }
        public string c_case_desc_vehicle_09_make { get; set; }
        public string c_case_desc_vehicle_09_model { get; set; }
        public string c_case_desc_vehicle_09_type_fk { get; set; }
        public string c_case_desc_vehicle_09_year { get; set; }
        public string c_case_desc_vehicle_09_state { get; set; }


        public string c_case_desc_vehicle_10_fk { get; set; }
        public string c_case_desc_vehicle_10_id { get; set; }
        public string c_case_desc_vehicle_10_vin { get; set; }
        public string c_case_desc_licence_10_number { get; set; }
        public string c_case_desc_vehicle_10_make { get; set; }
        public string c_case_desc_vehicle_10_model { get; set; }
        public string c_case_desc_vehicle_10_type_fk { get; set; }
        public string c_case_desc_vehicle_10_year { get; set; }
        public string c_case_desc_vehicle_10_state { get; set; }

        public bool c_case_desc_was_fatality { get; set; }
        public bool c_case_desc_public_vehicle_involved { get; set; }


        public string vehicle_fk { get; set; }
        public string vehicle_vin { get; set; }
        public string vehicle_id { get; set; }
        public string vehicle_licence { get; set; }
        public string vehicle_make { get; set; }
        public string vehicle_type { get; set; }
        public string vehicle_model { get; set; }
        public string vehicle_year { get; set; }
        public string vehicle_state { get; set; }


        //case category
        public string c_category_id { get; set; }
        public string c_category_abbreviation { get; set; }
        public string c_category_name { get; set; }


        public int incident_HH { get; set; }
        public int incident_MM { get; set; }
        public int workstart_HH { get; set; }
        public int workstart_MM { get; set; }
        public string c_osha_301_emergency_room_text { get; set; }
        public string c_osha_301_hospitalized_text { get; set; }

        public string c_case_category_text { get; set; }
        public string c_case_type_text { get; set; }
        public string c_status_text { get; set; }
        public string c_outcome_text { get; set; }
        public string c_illness_type_text { get; set; }


        public string c_case_category_value { get; set; }
        public string c_case_type_value { get; set; }
        public string c_case_status_value { get; set; }
        public string c_osha_300_case_outcome_value { get; set; }
        public string c_osha_300_type_of_illness_value { get; set; }




        public string c_witness_id_pk { get; set; }
        public string c_name { get; set; }
        public string c_contact_info { get; set; }
        public string c_file_guid { get; set; }
        public string c_file_name { get; set; }
        public string c_timezoneId { get; set; }

        public string incident_HH_text { get; set; }
        public string workstart_HH_text { get; set; }
        public string c_note_text { get; set; }

        public string c_osha_300_days_away_from_work_text { get; set; }
        public string c_osha_300_days_of_restriction_text { get; set; }
        public string c_osha_300_date_of_death_text { get; set; }
        public string c_file_id { get; set; }
        public string c_current_culture { get; set; }
        public string u_time_zone_location { get; set; }

        public string c_miris_witness { get; set; }
        public string c_miris_photo { get; set; }
        public string c_miris_police_report { get; set; }
        public string c_miris_scene_sketch { get; set; }
        public string c_miris_extenuating_condition { get; set; }
        public string c_miris_employee_interview { get; set; }

        public string c_miris_employee_statement { get; set; }
        public string c_miris_policies { get; set; }
        public string c_miris_training_history { get; set; }
        public string c_miris_observation { get; set; }
        public string c_miris_incident_history { get; set; }
        //HARM
        public string h_harm_id_pk { get; set; }
        public string h_harm_number { get; set; }
        public string h_case_title { get; set; }
        public DateTime? h_case_date { get; set; }
        public string h_case_category_fk { get; set; }
        public string h_status { get; set; }
        public string h_employee_report_location { get; set; }
        public string h_status_id { get; set; }
        public string h_case_category_text_view { get; set; }
        public string h_status_text_view { get; set; }


        public string h_custom_01 { get; set; }
        public string h_custom_02 { get; set; }
        public string h_custom_03 { get; set; }
        public string h_custom_04 { get; set; }
        public string h_custom_05 { get; set; }
        public string h_custom_06 { get; set; }
        public string h_custom_07 { get; set; }
        public string h_custom_08 { get; set; }
        public string h_custom_09 { get; set; }
        public string h_custom_10 { get; set; }
        public string h_custom_11 { get; set; }
        public string h_custom_12 { get; set; }
        public string h_custom_13 { get; set; }
        public DateTime h_creation_date { get; set; }

        public string h_control_measure_id_fk { get; set; }
        public string h_job_title { get; set; }

        public string h_hazard_id_pk { get; set; }
        public string h_hazard_name { get; set; }
        public string h_hazard_description { get; set; }
        public bool h_inactive { get; set; }


        public string h_hazard_control_meausre_id_pk { get; set; }
        public string h_hazard_id_fk { get; set; }
        public string h_control_measure_summary { get; set; }


        public string h_file_guid { get; set; }
        public string h_file_name { get; set; }
        public string h_file_id { get; set; }
        public string h_name { get; set; }
        public string h_contact_info { get; set; }
        public string h_program_compliance_value { get; set; }
        public string h_permit_compliance_value { get; set; }
        public string s_locale_culture { get; set; }


    }
}
