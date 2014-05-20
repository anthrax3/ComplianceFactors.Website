using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data.SqlTypes;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public class ComplianceBLL
    {


        public static int InsertCase(ComplianceDAO miris)
        {
            Hashtable htInsertCase = new Hashtable();
            htInsertCase.Add("@c_case_id_pk", miris.c_case_id_pk);
            htInsertCase.Add("@u_user_id_fk", miris.u_user_id_fk);
            htInsertCase.Add("@c_case_number", miris.c_case_number);
            htInsertCase.Add("@c_case_title", miris.c_case_title);
            htInsertCase.Add("@c_case_category_fk", miris.c_case_category_fk);
            htInsertCase.Add("@c_case_type_fk", miris.c_case_type_fk);
            htInsertCase.Add("@c_case_status", miris.c_case_status);
            htInsertCase.Add("@c_employee_name", miris.c_employee_name);
            htInsertCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htInsertCase.Add("@c_employee_dob", miris.c_employee_dob);
            htInsertCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
            htInsertCase.Add("@c_employee_id", miris.c_employee_id);
            htInsertCase.Add("@c_ssn", miris.c_ssn);
            htInsertCase.Add("@c_supervisor", miris.c_supervisor);
            htInsertCase.Add("@c_incident_location", miris.c_incident_location);
            htInsertCase.Add("@c_incident_date", miris.c_incident_date);
            htInsertCase.Add("@c_incident_time", miris.c_incident_time);
            htInsertCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htInsertCase.Add("@c_note", miris.c_note);
            htInsertCase.Add("@c_company_owned", miris.c_company_owned);
            htInsertCase.Add("@c_root_cause_analysic_info", "");
            htInsertCase.Add("@c_corrective_action_info", "");
            htInsertCase.Add("@c_osha_300_case_outcome", DBNull.Value);
            htInsertCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
            htInsertCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

            if (miris.c_osha_300_date_of_death != null)
            {
                htInsertCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
            }
            else
            {
                htInsertCase.Add("@c_osha_300_date_of_death", DBNull.Value);
            }
            if (miris.c_date_in_title != null)
            {
                htInsertCase.Add("@c_date_in_title", miris.c_date_in_title);
            }
            else
            {
                htInsertCase.Add("@c_date_in_title", DBNull.Value);
            }

            htInsertCase.Add("@c_osha_300_type_of_illness", DBNull.Value);



            htInsertCase.Add("@c_osha_300_info", DBNull.Value);
            htInsertCase.Add("@c_osha_301_worker_gender", DBNull.Value);

            if (miris.c_osha_301_work_start_time != null)
            {
                htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }
            else
            {
                htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }


            htInsertCase.Add("@c_osha_301_physician", DBNull.Value);
            htInsertCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
            htInsertCase.Add("@c_osha_301_emergency_room", DBNull.Value);
            htInsertCase.Add("@c_osha_301_hospitalized", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address1", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address2", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address3", DBNull.Value);
            htInsertCase.Add("@c_osha_301_city", DBNull.Value);
            htInsertCase.Add("@c_osha_301_state", DBNull.Value);
            htInsertCase.Add("@c_osha_301_zip", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_1", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_2", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_3", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_4", DBNull.Value);
            htInsertCase.Add("@c_custom_01", miris.c_custom_01);
            htInsertCase.Add("@c_custom_02", miris.c_custom_02);
            htInsertCase.Add("@c_custom_03", miris.c_custom_03);
            htInsertCase.Add("@c_custom_04", miris.c_custom_04);
            htInsertCase.Add("@c_custom_05", miris.c_custom_05);
            htInsertCase.Add("@c_custom_06", miris.c_custom_06);
            htInsertCase.Add("@c_custom_07", miris.c_custom_07);
            htInsertCase.Add("@c_custom_08", miris.c_custom_08);
            htInsertCase.Add("@c_custom_09", miris.c_custom_09);
            htInsertCase.Add("@c_custom_10", miris.c_custom_10);
            htInsertCase.Add("@c_custom_11", miris.c_custom_11);
            htInsertCase.Add("@c_custom_12", miris.c_custom_12);
            htInsertCase.Add("@c_custom_13", miris.c_custom_13);
            htInsertCase.Add("@c_case_date", miris.c_case_date);
            htInsertCase.Add("@c_timezone_id_fk", miris.c_timezoneId);
            //Witness
            if (!string.IsNullOrEmpty(miris.c_miris_witness))
            {
                htInsertCase.Add("@c_miris_witness", miris.c_miris_witness);
            }
            else
            {
                htInsertCase.Add("@c_miris_witness", DBNull.Value);
            }
            //photo
            if (!string.IsNullOrEmpty(miris.c_miris_photo))
            {
                htInsertCase.Add("@c_miris_photo", miris.c_miris_photo);
            }
            else
            {
                htInsertCase.Add("@c_miris_photo", DBNull.Value);
            }
            //police report
            if (!string.IsNullOrEmpty(miris.c_miris_police_report))
            {
                htInsertCase.Add("@c_miris_police_report", miris.c_miris_police_report);
            }
            else
            {
                htInsertCase.Add("@c_miris_police_report", DBNull.Value);
            }
            //scene sketch
            if (!string.IsNullOrEmpty(miris.c_miris_scene_sketch))
            {
                htInsertCase.Add("@c_miris_scene_sketch", miris.c_miris_scene_sketch);
            }
            else
            {
                htInsertCase.Add("@c_miris_scene_sketch", DBNull.Value);
            }
            //extenuating condition
            if (!string.IsNullOrEmpty(miris.c_miris_extenuating_condition))
            {
                htInsertCase.Add("@c_miris_extenuating_condition", miris.c_miris_extenuating_condition);
            }
            else
            {
                htInsertCase.Add("@c_miris_extenuating_condition", DBNull.Value);
            }
            //employee interview
            if (!string.IsNullOrEmpty(miris.c_miris_employee_interview))
            {
                htInsertCase.Add("@c_miris_employee_interview", miris.c_miris_employee_interview);
            }
            else
            {
                htInsertCase.Add("@c_miris_employee_interview", DBNull.Value);
            }
            try
            {
                UpdateCaseType(miris.c_case_id_pk, miris.c_case_type_fk);
                return DataProxy.FetchSPOutput("c_miris_sp_insert_case", htInsertCase);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateCase(ComplianceDAO miris)
        {
            Hashtable htUpdateCase = new Hashtable();
            htUpdateCase.Add("@c_case_id_pk", miris.c_case_id_pk);
            htUpdateCase.Add("@u_user_id_fk", miris.u_user_id_fk);
            htUpdateCase.Add("@c_case_number", miris.c_case_number);
            htUpdateCase.Add("@c_case_title", miris.c_case_title);
            htUpdateCase.Add("@c_case_category_fk", miris.c_case_category_fk);
            htUpdateCase.Add("@c_case_type_fk", miris.c_case_type_fk);
            htUpdateCase.Add("@c_case_status", miris.c_case_status);
            htUpdateCase.Add("@c_employee_name", miris.c_employee_name);
            htUpdateCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htUpdateCase.Add("@c_employee_dob", miris.c_employee_dob);
            htUpdateCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
            htUpdateCase.Add("@c_employee_id", miris.c_employee_id);
            htUpdateCase.Add("@c_ssn", miris.c_ssn);
            htUpdateCase.Add("@c_supervisor", miris.c_supervisor);
            htUpdateCase.Add("@c_incident_location", miris.c_incident_location);
            htUpdateCase.Add("@c_incident_date", miris.c_incident_date);
            htUpdateCase.Add("@c_incident_time", miris.c_incident_time);
            htUpdateCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htUpdateCase.Add("@c_note", miris.c_note);
            htUpdateCase.Add("@c_company_owned", miris.c_company_owned);
            htUpdateCase.Add("@c_root_cause_analysic_info", "");
            htUpdateCase.Add("@c_corrective_action_info", "");
            htUpdateCase.Add("@c_osha_300_case_outcome", DBNull.Value);
            htUpdateCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
            htUpdateCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

            if (miris.c_osha_300_date_of_death != null)
            {
                htUpdateCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
            }
            else
            {
                htUpdateCase.Add("@c_osha_300_date_of_death", DBNull.Value);
            }
            if (miris.c_date_in_title != null)
            {
                htUpdateCase.Add("@c_date_in_title", miris.c_date_in_title);
            }
            else
            {
                htUpdateCase.Add("@c_date_in_title", DBNull.Value);
            }

            htUpdateCase.Add("@c_osha_300_type_of_illness", DBNull.Value);




            htUpdateCase.Add("@c_osha_300_info", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_worker_gender", DBNull.Value);

            if (miris.c_osha_301_work_start_time != null)
            {
                htUpdateCase.Add("@c_osha_301_work_start_time", miris.c_osha_301_work_start_time);
            }
            else
            {
                htUpdateCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }


            htUpdateCase.Add("@c_osha_301_physician", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_emergency_room", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_hospitalized", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address1", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address2", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address3", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_city", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_state", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_zip", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_1", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_2", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_3", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_4", DBNull.Value);
            htUpdateCase.Add("@c_custom_01", miris.c_custom_01);
            htUpdateCase.Add("@c_custom_02", miris.c_custom_02);
            htUpdateCase.Add("@c_custom_03", miris.c_custom_03);
            htUpdateCase.Add("@c_custom_04", miris.c_custom_04);
            htUpdateCase.Add("@c_custom_05", miris.c_custom_05);
            htUpdateCase.Add("@c_custom_06", miris.c_custom_06);
            htUpdateCase.Add("@c_custom_07", miris.c_custom_07);
            htUpdateCase.Add("@c_custom_08", miris.c_custom_08);
            htUpdateCase.Add("@c_custom_09", miris.c_custom_09);
            htUpdateCase.Add("@c_custom_10", miris.c_custom_10);
            htUpdateCase.Add("@c_custom_11", miris.c_custom_11);
            htUpdateCase.Add("@c_custom_12", miris.c_custom_12);
            htUpdateCase.Add("@c_custom_13", miris.c_custom_13);
            htUpdateCase.Add("@c_timezone_id_fk", miris.c_timezoneId);

            try
            {
                UpdateCaseType(miris.c_case_id_pk, miris.c_case_type_fk);
                return DataProxy.FetchSPOutput("c_miris_sp_update_case", htUpdateCase);

            }

            catch (Exception)
            {
                throw;
            }

        }
        public static ComplianceDAO GetCase(string caseId)
        {
            ComplianceDAO miris;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCase = new Hashtable();
                htGetCase.Add("@c_case_id_pk", caseId);
                miris = new ComplianceDAO();
                DataTable dtGetCase = DataProxy.FetchDataTable("c_miris_get_case", htGetCase);
                miris.c_case_number = dtGetCase.Rows[0]["c_case_number"].ToString();
                miris.c_case_title = dtGetCase.Rows[0]["c_case_title"].ToString();
                miris.c_case_category_fk = dtGetCase.Rows[0]["c_case_category_fk"].ToString();
                miris.c_case_type_fk = GetCaseTypes(caseId);// dtGetCase.Rows[0]["c_case_type_fk"].ToString();
                miris.c_case_status = dtGetCase.Rows[0]["c_case_status"].ToString();
                miris.c_employee_name = dtGetCase.Rows[0]["c_employee_name"].ToString();
                miris.c_employee_last_name = dtGetCase.Rows[0]["c_employee_last_name"].ToString();
                if (dtGetCase.Rows[0]["c_date_in_title"] == null || string.IsNullOrEmpty(dtGetCase.Rows[0]["c_date_in_title"].ToString()))
                {
                    miris.c_date_in_title = null;
                }
                else
                {
                    miris.c_date_in_title = Convert.ToDateTime(dtGetCase.Rows[0]["c_date_in_title"], culture);
                }
                miris.c_case_category_value = dtGetCase.Rows[0]["c_case_category_value"].ToString();
                miris.c_case_status_value = dtGetCase.Rows[0]["c_case_status_value"].ToString();
                miris.c_case_type_value = dtGetCase.Rows[0]["c_case_type_value"].ToString();
                miris.c_osha_300_type_of_illness_value = dtGetCase.Rows[0]["c_osha_300_type_of_illness_value"].ToString();
                miris.c_osha_300_case_outcome_value = dtGetCase.Rows[0]["c_osha_300_case_outcome_value"].ToString();



                miris.c_employee_dob = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_dob"], culture);
                miris.c_employee_hire_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_hire_date"], culture);
                miris.c_employee_id = dtGetCase.Rows[0]["c_employee_id"].ToString();
                miris.c_ssn = dtGetCase.Rows[0]["c_ssn"].ToString();
                miris.c_supervisor = dtGetCase.Rows[0]["c_supervisor"].ToString();
                miris.c_incident_location = dtGetCase.Rows[0]["c_incident_location"].ToString();
                miris.c_incident_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_date"], culture);
                miris.incident_HH = Convert.ToInt32(dtGetCase.Rows[0]["incident_HH"].ToString());
                miris.incident_MM = Convert.ToInt32(dtGetCase.Rows[0]["incident_MM"].ToString());
                miris.c_incident_time = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_time"], culture);
                miris.c_employee_report_location = dtGetCase.Rows[0]["c_employee_report_location"].ToString();
                miris.c_note = dtGetCase.Rows[0]["c_note"].ToString();
                miris.c_root_cause_analysic_info = dtGetCase.Rows[0]["c_root_cause_analysic_info"].ToString();
                miris.c_corrective_action_info = dtGetCase.Rows[0]["c_corrective_action_info"].ToString();
                //miris.c_osha_300_case_outcome = dtGetCase.Rows[0]["c_osha_300_case_outcome"].ToString();
                //miris.c_osha_300_days_away_from_work = Convert.ToInt32(dtGetCase.Rows[0]["c_osha_300_days_away_from_work"]);
                //miris.c_osha_300_days_of_restriction = Convert.ToInt32(dtGetCase.Rows[0]["c_osha_300_days_of_restriction"]);

                //if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_osha_300_date_of_death"].ToString()))
                //{
                //    miris.c_osha_300_date_of_death = Convert.ToDateTime(dtGetCase.Rows[0]["c_osha_300_date_of_death"], culture);
                //}


                //miris.c_osha_300_type_of_illness = dtGetCase.Rows[0]["c_osha_300_type_of_illness"].ToString();
                //miris.c_osha_300_info = dtGetCase.Rows[0]["c_osha_300_info"].ToString();
                //miris.c_osha_301_worker_gender = dtGetCase.Rows[0]["c_osha_301_worker_gender"].ToString();

                //if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_osha_301_work_start_time"].ToString()))
                //{
                //    miris.workstart_HH = Convert.ToInt32(dtGetCase.Rows[0]["workstart_HH"].ToString());
                //    miris.workstart_MM = Convert.ToInt32(dtGetCase.Rows[0]["workstart_MM"].ToString());
                //    miris.c_osha_301_work_start_time = Convert.ToDateTime(dtGetCase.Rows[0]["c_osha_301_work_start_time"], culture);
                //}



                //miris.c_osha_301_physician = dtGetCase.Rows[0]["c_osha_301_physician"].ToString();
                //miris.c_osha_301_treatment_facilities = dtGetCase.Rows[0]["c_osha_301_treatment_facilities"].ToString();
                //miris.c_osha_301_emergency_room_text = dtGetCase.Rows[0]["c_osha_301_emergency_room_text"].ToString();
                //miris.c_osha_301_hospitalized_text = dtGetCase.Rows[0]["c_osha_301_hospitalized_text"].ToString();


                //miris.c_osha_301_emergency_room = Convert.ToBoolean(dtGetCase.Rows[0]["c_osha_301_emergency_room"]);
                //miris.c_osha_301_hospitalized = Convert.ToBoolean(dtGetCase.Rows[0]["c_osha_301_hospitalized"]);
                //miris.c_osha_301_address1 = dtGetCase.Rows[0]["c_osha_301_address1"].ToString();
                //miris.c_osha_301_address2 = dtGetCase.Rows[0]["c_osha_301_address2"].ToString();
                //miris.c_osha_301_address3 = dtGetCase.Rows[0]["c_osha_301_address3"].ToString();
                //miris.c_osha_301_city = dtGetCase.Rows[0]["c_osha_301_city"].ToString();
                //miris.c_osha_301_state = dtGetCase.Rows[0]["c_osha_301_state"].ToString();
                //miris.c_osha_301_zip = dtGetCase.Rows[0]["c_osha_301_zip"].ToString();
                //miris.c_osha_301_info_1 = dtGetCase.Rows[0]["c_osha_301_info_1"].ToString();
                //miris.c_osha_301_info_2 = dtGetCase.Rows[0]["c_osha_301_info_2"].ToString();
                //miris.c_osha_301_info_3 = dtGetCase.Rows[0]["c_osha_301_info_3"].ToString();
                //miris.c_osha_301_info_4 = dtGetCase.Rows[0]["c_osha_301_info_4"].ToString();
                miris.c_custom_01 = dtGetCase.Rows[0]["c_custom_01"].ToString();
                miris.c_custom_02 = dtGetCase.Rows[0]["c_custom_02"].ToString();
                miris.c_custom_03 = dtGetCase.Rows[0]["c_custom_03"].ToString();
                miris.c_custom_04 = dtGetCase.Rows[0]["c_custom_04"].ToString();
                miris.c_custom_05 = dtGetCase.Rows[0]["c_custom_05"].ToString();
                miris.c_custom_06 = dtGetCase.Rows[0]["c_custom_06"].ToString();
                miris.c_custom_07 = dtGetCase.Rows[0]["c_custom_07"].ToString();
                miris.c_custom_08 = dtGetCase.Rows[0]["c_custom_08"].ToString();
                miris.c_custom_09 = dtGetCase.Rows[0]["c_custom_09"].ToString();
                miris.c_custom_10 = dtGetCase.Rows[0]["c_custom_10"].ToString();
                miris.c_custom_11 = dtGetCase.Rows[0]["c_custom_11"].ToString();
                miris.c_custom_12 = dtGetCase.Rows[0]["c_custom_12"].ToString();
                miris.c_custom_13 = dtGetCase.Rows[0]["c_custom_13"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(dtGetCase.Rows[0]["c_company_owned"])))
                {
                    miris.c_company_owned = Convert.ToBoolean(dtGetCase.Rows[0]["c_company_owned"]);
                }

                miris.c_case_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_date"], culture);

                miris.c_case_type_text = dtGetCase.Rows[0]["c_case_type_text"].ToString();
                miris.c_status_text = dtGetCase.Rows[0]["c_status_text"].ToString();
                //miris.c_outcome_text = dtGetCase.Rows[0]["c_outcome_text"].ToString();
                //miris.c_illness_type_text = dtGetCase.Rows[0]["c_illness_type_text"].ToString();
                miris.c_timezoneId = dtGetCase.Rows[0]["c_timezone_id_fk"].ToString();
                miris.c_case_category_text = dtGetCase.Rows[0]["c_case_category_text"].ToString();
                //miris.workstart_HH_text = dtGetCase.Rows[0]["workstart_HH_text"].ToString();
                miris.incident_HH_text = dtGetCase.Rows[0]["incident_HH_text"].ToString();
                miris.c_note_text = dtGetCase.Rows[0]["c_note_text"].ToString();
                //miris.c_osha_300_days_away_from_work_text = dtGetCase.Rows[0]["c_osha_300_days_away_from_work_text"].ToString();
                //miris.c_osha_300_days_of_restriction_text = dtGetCase.Rows[0]["c_osha_300_days_of_restriction_text"].ToString();
                //miris.c_osha_300_date_of_death_text = dtGetCase.Rows[0]["c_osha_300_date_of_death_text"].ToString();
                miris.u_time_zone_location = dtGetCase.Rows[0]["u_time_zone_location"].ToString();
                return miris;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable SearchCase(ComplianceDAO miris)
        {
            Hashtable htSearchCase = new Hashtable();
            htSearchCase.Add("@c_case_number", miris.c_case_number);
            htSearchCase.Add("@c_case_title", miris.c_case_title);
            if (!string.IsNullOrEmpty(miris.c_case_date.ToString()))
            {
                htSearchCase.Add("@c_case_date", miris.c_case_date);
            }
            else
            {
                htSearchCase.Add("@c_case_date", DBNull.Value);
            }
            if (miris.c_case_category_fk == "0")
                htSearchCase.Add("@c_case_category_fk", DBNull.Value);
            else
                htSearchCase.Add("@c_case_category_fk", miris.c_case_category_fk);

            if (miris.c_case_type_fk == "0")
                htSearchCase.Add("@c_case_type_fk", DBNull.Value);
            else
                htSearchCase.Add("@c_case_type_fk", miris.c_case_type_fk);

            if (miris.c_case_status == "0")
                htSearchCase.Add("@c_case_status", DBNull.Value);
            else
                htSearchCase.Add("@c_case_status", miris.c_case_status);
            htSearchCase.Add("@c_creation_start_date", DBNull.Value);
            htSearchCase.Add("@c_creation_end_date", DBNull.Value);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_search_case", htSearchCase);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchCase(ComplianceDAO miris, string c_creation_start_date, string c_creation_end_date)
        {
            Hashtable htSearchCase = new Hashtable();
            htSearchCase.Add("@c_case_number", miris.c_case_number);
            htSearchCase.Add("@c_case_title", miris.c_case_title);
            if (!string.IsNullOrEmpty(miris.c_case_date.ToString()))
            {
                htSearchCase.Add("@c_case_date", miris.c_case_date);
            }
            else
            {
                htSearchCase.Add("@c_case_date", DBNull.Value);
            }
            if (miris.c_case_category_fk == "0")
                htSearchCase.Add("@c_case_category_fk", DBNull.Value);
            else
                htSearchCase.Add("@c_case_category_fk", miris.c_case_category_fk);

            if (miris.c_case_type_fk == "0")
                htSearchCase.Add("@c_case_type_fk", DBNull.Value);
            else
                htSearchCase.Add("@c_case_type_fk", miris.c_case_type_fk);

            if (miris.c_case_status == "0")
                htSearchCase.Add("@c_case_status", DBNull.Value);
            else
                htSearchCase.Add("@c_case_status", miris.c_case_status);
            if (string.IsNullOrEmpty(c_creation_start_date))
            {
                htSearchCase.Add("@c_creation_start_date", DBNull.Value);

            }
            else
            {
                htSearchCase.Add("@c_creation_start_date", c_creation_start_date);
            }
            if (string.IsNullOrEmpty(c_creation_end_date))
            {
                htSearchCase.Add("@c_creation_end_date", DBNull.Value);

            }
            else
            {
                htSearchCase.Add("@c_creation_end_date", c_creation_end_date);
            }
            htSearchCase.Add("@c_employee_name", miris.c_employee_name);
            htSearchCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htSearchCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htSearchCase.Add("@c_incident_location", miris.c_incident_location);
            htSearchCase.Add("@c_supervisor", miris.c_supervisor);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_search_case", htSearchCase);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchCaseOSHA(ComplianceDAO miris)
        {
            Hashtable htSearchCase = new Hashtable();
            htSearchCase.Add("@c_case_number", miris.c_case_number);
            htSearchCase.Add("@c_case_title", miris.c_case_title);
            if (!string.IsNullOrEmpty(miris.c_case_date.ToString()))
            {
                htSearchCase.Add("@c_case_date", miris.c_case_date);
            }
            else
            {
                htSearchCase.Add("@c_case_date", DBNull.Value);
            }
            if (miris.c_case_category_fk == "0")
                htSearchCase.Add("@c_case_category_fk", DBNull.Value);
            else
                htSearchCase.Add("@c_case_category_fk", miris.c_case_category_fk);

            if (miris.c_case_type_fk == "0")
                htSearchCase.Add("@c_case_type_fk", DBNull.Value);
            else
                htSearchCase.Add("@c_case_type_fk", miris.c_case_type_fk);

            if (miris.c_case_status == "0")
                htSearchCase.Add("@c_case_status", DBNull.Value);
            else
                htSearchCase.Add("@c_case_status", miris.c_case_status);
            try
            {
                return DataProxy.FetchDataTable("c_miris_osha_sp_search_case", htSearchCase);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchCaseOSHA300A(string condition)
        {
            Hashtable htSearchCase = new Hashtable();
            if (string.IsNullOrEmpty(condition))
            {
                condition = " 1=1 ";
            }
            htSearchCase.Add("@condition", condition.Replace("#", "'"));
            try
            {
                return DataProxy.FetchDataTable("c_miris_osha_300a_sp_search_case", htSearchCase);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchCaseByEmp(string c_employee_name, string c_case_title)
        {
            Hashtable htSearchCase = new Hashtable();
            htSearchCase.Add("@c_employee_name", c_employee_name);
            htSearchCase.Add("@c_case_title", c_case_title);

            try
            {
                return DataProxy.FetchDataTable("c_miris_osha_sp_search_case_emp", htSearchCase);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //witness
        public static int InsertWitness(ComplianceDAO miris)
        {
            Hashtable htInsertWitness = new Hashtable();
            htInsertWitness.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertWitness.Add("@c_file_guid", miris.c_file_guid);
            htInsertWitness.Add("@c_file_name", miris.c_file_name);
            htInsertWitness.Add("@c_name", miris.c_name);
            htInsertWitness.Add("@c_contact_info", miris.c_contact_info);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_witness", htInsertWitness);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetWitness(ComplianceDAO miris)
        {

            Hashtable htGetWitness = new Hashtable();
            htGetWitness.Add("@c_case_id_fk", miris.c_case_id_pk);
            htGetWitness.Add("@s_locale_culture", miris.s_locale_culture);
            //if (!string.IsNullOrEmpty(miris.s_locale_culture))
            //{
            //    htGetWitness.Add("@s_locale_culture", miris.s_locale_culture);
            //}
            //else
            //{
            //    htGetWitness.Add("@s_locale_culture", DBNull.Value);
            //}
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_witness", htGetWitness);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static int DeleteAdditionalInformation(ComplianceDAO miris)
        {
            Hashtable htDeleteAddInfo = new Hashtable();
            htDeleteAddInfo.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_additional_info", htDeleteAddInfo);
            }

            catch (Exception)
            {
                throw;
            }

        }

        //PoliceReport

        public static int InsertPoliceReport(ComplianceDAO miris)
        {
            Hashtable htInsertPoliceReport = new Hashtable();
            htInsertPoliceReport.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertPoliceReport.Add("@c_file_guid", miris.c_file_guid);
            htInsertPoliceReport.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_policereport", htInsertPoliceReport);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPoliceReport(ComplianceDAO miris)
        {

            Hashtable htGetPoliceReport = new Hashtable();
            htGetPoliceReport.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_policereport", htGetPoliceReport);
            }

            catch (Exception)
            {
                throw;
            }


        }


        //Photo

        public static int Insertphoto(ComplianceDAO miris)
        {
            Hashtable htInsertphoto = new Hashtable();
            htInsertphoto.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertphoto.Add("@c_file_guid", miris.c_file_guid);
            htInsertphoto.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_photo", htInsertphoto);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable Getphoto(ComplianceDAO miris)
        {

            Hashtable htGetphoto = new Hashtable();
            htGetphoto.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_photo", htGetphoto);
            }

            catch (Exception)
            {
                throw;
            }
        }



        //SceneSketch

        public static int InsertSceneSketch(ComplianceDAO miris)
        {
            Hashtable htInsertSceneSketch = new Hashtable();
            htInsertSceneSketch.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertSceneSketch.Add("@c_file_guid", miris.c_file_guid);
            htInsertSceneSketch.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_scenesketch", htInsertSceneSketch);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSceneSketch(ComplianceDAO miris)
        {

            Hashtable htGetSceneSketch = new Hashtable();
            htGetSceneSketch.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_scenesketch", htGetSceneSketch);
            }

            catch (Exception)
            {
                throw;
            }


        }


        //ExtenuatingCondition

        public static int InsertExtenuatingCondition(ComplianceDAO miris)
        {
            Hashtable htInsertExtenuatingCondition = new Hashtable();
            htInsertExtenuatingCondition.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertExtenuatingCondition.Add("@c_file_guid", miris.c_file_guid);
            htInsertExtenuatingCondition.Add("@c_file_name", miris.c_file_name);
            htInsertExtenuatingCondition.Add("@c_name", miris.c_name);
            htInsertExtenuatingCondition.Add("@c_contact_info", miris.c_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_extenuating_condition", htInsertExtenuatingCondition);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetExtenuatingCondition(ComplianceDAO miris)
        {

            Hashtable htGetExtenuatingCondition = new Hashtable();
            htGetExtenuatingCondition.Add("@c_case_id_fk", miris.c_case_id_pk);
            htGetExtenuatingCondition.Add("@s_locale_culture", miris.s_locale_culture);
            //if (!string.IsNullOrEmpty(miris.s_locale_culture))
            //{
            //    htGetExtenuatingCondition.Add("@s_locale_culture", miris.s_locale_culture);
            //}
            //else
            //{
            //    htGetExtenuatingCondition.Add("@s_locale_culture", DBNull.Value);
            //}
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_extenuating_condition", htGetExtenuatingCondition);
            }

            catch (Exception)
            {
                throw;
            }


        }

        //EmployeeInterview

        public static int InsertEmployeeInterview(ComplianceDAO miris)
        {
            Hashtable htInsertEmployeeInterview = new Hashtable();
            htInsertEmployeeInterview.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertEmployeeInterview.Add("@c_file_guid", miris.c_file_guid);
            htInsertEmployeeInterview.Add("@c_file_name", miris.c_file_name);
            htInsertEmployeeInterview.Add("@c_name", miris.c_name);
            htInsertEmployeeInterview.Add("@c_contact_info", miris.c_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_employee_interview", htInsertEmployeeInterview);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetEmployeeInterview(ComplianceDAO miris)
        {

            Hashtable htGetEmployeeInterview = new Hashtable();
            htGetEmployeeInterview.Add("@c_case_id_fk", miris.c_case_id_pk);
            htGetEmployeeInterview.Add("@s_locale_culture", miris.s_locale_culture);
            //if (!string.IsNullOrEmpty(miris.s_locale_culture))
            //{
            //    htGetEmployeeInterview.Add("@s_locale_culture", miris.s_locale_culture);
            //}
            //else
            //{
            //    htGetEmployeeInterview.Add("@s_locale_culture", DBNull.Value);
            //}
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_employee_interview", htGetEmployeeInterview);
            }

            catch (Exception)
            {
                throw;
            }


        }

        public static ComplianceDAO GetTimeZoneDateTime(int c_timezoneId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            ComplianceDAO miris;
            try
            {
                Hashtable htGetTimeZoneDateTime = new Hashtable();
                htGetTimeZoneDateTime.Add("@u_time_zone_id_pk", c_timezoneId);
                miris = new ComplianceDAO();
                DataTable dtGetTime = DataProxy.FetchDataTable("c_miris_sp_get_timezone_date_time", htGetTimeZoneDateTime);
                miris.c_incident_date = Convert.ToDateTime(dtGetTime.Rows[0]["c_timezone_datetime"], culture);
                miris.c_osha_301_work_start_time = Convert.ToDateTime(dtGetTime.Rows[0]["c_timezone_datetime"], culture);
                miris.c_temp_case_date = Convert.ToDateTime(dtGetTime.Rows[0]["c_timezone_datetime"], culture);
                miris.u_time_zone_display = dtGetTime.Rows[0]["u_time_zone_display"].ToString();
                return miris;
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateCaseStatus(ComplianceDAO miris)
        {
            Hashtable htUpdateCaseStatus = new Hashtable();
            htUpdateCaseStatus.Add("@c_case_id_pk", miris.c_case_id_pk);
            //htUpdateCaseStatus.Add("@c_case_status", miris.c_case_status);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_case_status", htUpdateCaseStatus);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateWitnessFile(ComplianceDAO miris)
        {
            Hashtable htUpdateFile = new Hashtable();
            htUpdateFile.Add("@c_witness_id_pk", miris.c_file_id);
            htUpdateFile.Add("@c_file_name", miris.c_file_name);
            htUpdateFile.Add("@c_file_guid", miris.c_file_guid);
            htUpdateFile.Add("@c_name", miris.c_name);
            htUpdateFile.Add("@c_contact_info", miris.c_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_witness", htUpdateFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdatePhotoFile(ComplianceDAO miris)
        {
            Hashtable htUpdateFile = new Hashtable();
            htUpdateFile.Add("@c_photo_id_pk", miris.c_file_id);
            htUpdateFile.Add("@c_file_name", miris.c_file_name);
            htUpdateFile.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_photo", htUpdateFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdatePoliceReportFile(ComplianceDAO miris)
        {
            Hashtable htUpdateFile = new Hashtable();
            htUpdateFile.Add("@c_police_report_id_pk", miris.c_file_id);
            htUpdateFile.Add("@c_file_name", miris.c_file_name);
            htUpdateFile.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_police_report", htUpdateFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateExtenautingConditionFile(ComplianceDAO miris)
        {
            Hashtable htUpdateFile = new Hashtable();
            htUpdateFile.Add("@c_extenauting_id_pk", miris.c_file_id);
            htUpdateFile.Add("@c_file_name", miris.c_file_name);
            htUpdateFile.Add("@c_file_guid", miris.c_file_guid);
            htUpdateFile.Add("@c_name", miris.c_name);
            htUpdateFile.Add("@c_contact_info", miris.c_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_extenauting_condition", htUpdateFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateEmployeeInterviewFile(ComplianceDAO miris)
        {
            Hashtable htUpdateFile = new Hashtable();
            htUpdateFile.Add("@c_employee_interivew_id_pk", miris.c_file_id);
            htUpdateFile.Add("@c_file_name", miris.c_file_name);
            htUpdateFile.Add("@c_file_guid", miris.c_file_guid);
            htUpdateFile.Add("@c_name", miris.c_name);
            htUpdateFile.Add("@c_contact_info", miris.c_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_employee_interview", htUpdateFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateSceneSketchFile(ComplianceDAO miris)
        {
            Hashtable htUpdateFile = new Hashtable();
            htUpdateFile.Add("@c_scene_sketch_id_pk", miris.c_file_id);
            htUpdateFile.Add("@c_file_name", miris.c_file_name);
            htUpdateFile.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_scene_sketch", htUpdateFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteWitnessFile(ComplianceDAO miris)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_witness_id_pk", miris.c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_witness_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeletePhotoFile(ComplianceDAO miris)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_photo_id_pk", miris.c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_photo_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeletePoliceReportFile(ComplianceDAO miris)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_police_report_id_pk", miris.c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_police_report_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteSceneSketchFile(ComplianceDAO miris)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_scene_sketch_id_pk", miris.c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_scene_sketch_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteExtenautingConditionFile(ComplianceDAO miris)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_extenauting_id_pk", miris.c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_extenauting_condition_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteEmployeeInterviewFile(ComplianceDAO miris)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_employee_interivew_id_pk", miris.c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_employee_interivew_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet createPDF(ComplianceDAO miris)
        {

            Hashtable htcreatePDF = new Hashtable();
            htcreatePDF.Add("@c_case_id_pk", miris.c_case_id_pk);
            htcreatePDF.Add("@s_locale_culture", miris.s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("c_miris_create_pdf", htcreatePDF);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static ComplianceDAO GetCaseId(string c_category_id, string c_case_id_pk)
        {
            ComplianceDAO miris;
            try
            {
                Hashtable htCaseId = new Hashtable();
                htCaseId.Add("@c_category_id", c_category_id);
                if (!string.IsNullOrEmpty(c_case_id_pk))
                {
                    htCaseId.Add("@c_case_id_pk", c_case_id_pk);
                }
                else
                {
                    htCaseId.Add("@c_case_id_pk", DBNull.Value);
                }
                miris = new ComplianceDAO();
                DataTable dtGetCaseId = DataProxy.FetchDataTable("c_miris_sp_create_case_id", htCaseId);
                miris.c_case_number = dtGetCaseId.Rows[0]["caseId"].ToString();

                return miris;
            }

            catch (Exception)
            {
                throw;
            }

        }



        /********************************** HARM ***************************/

        public static ComplianceDAO GetHarmNumber(string h_category_id)
        {
            ComplianceDAO harm;
            try
            {
                Hashtable htCategoryAbb = new Hashtable();
                htCategoryAbb.Add("@h_category_id", h_category_id);
                harm = new ComplianceDAO();
                DataTable dtHarmNumber = DataProxy.FetchDataTable("c_harm_sp_get_harm_number", htCategoryAbb);
                harm.h_harm_number = dtHarmNumber.Rows[0]["HarmNumber"].ToString();
                return harm;
            }

            catch (Exception)
            {
                throw;
            }

        }
        public static int InsertHarm(ComplianceDAO harm)
        {
            Hashtable htInsertHarm = new Hashtable();
            htInsertHarm.Add("@u_user_id_fk", harm.u_user_id_fk);
            htInsertHarm.Add("@h_harm_id_pk", harm.h_harm_id_pk);
            htInsertHarm.Add("@h_harm_number", harm.h_harm_number);
            htInsertHarm.Add("@h_case_title", harm.h_case_title);
            //htInsertHarm.Add("@h_case_date", harm.h_case_date);


            htInsertHarm.Add("@h_case_date", harm.h_case_date);

            htInsertHarm.Add("@h_case_category_fk", harm.h_case_category_fk);

            htInsertHarm.Add("@h_status", harm.h_status);
            htInsertHarm.Add("@h_employee_report_location", DBNull.Value);

            htInsertHarm.Add("@h_custom_01", harm.h_custom_01);
            htInsertHarm.Add("@h_custom_02", harm.h_custom_02);
            htInsertHarm.Add("@h_custom_03", harm.h_custom_03);
            htInsertHarm.Add("@h_custom_04", harm.h_custom_04);
            htInsertHarm.Add("@h_custom_05", harm.h_custom_05);
            htInsertHarm.Add("@h_custom_06", harm.h_custom_06);
            htInsertHarm.Add("@h_custom_07", harm.h_custom_07);
            htInsertHarm.Add("@h_custom_08", harm.h_custom_08);
            htInsertHarm.Add("@h_custom_09", harm.h_custom_09);
            htInsertHarm.Add("@h_custom_10", harm.h_custom_10);
            htInsertHarm.Add("@h_custom_11", harm.h_custom_11);
            htInsertHarm.Add("@h_custom_12", harm.h_custom_12);
            htInsertHarm.Add("@h_custom_13", harm.h_custom_13);


            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert", htInsertHarm);

            }

            catch (Exception)
            {
                throw;
            }
        }
        //Harm custom customer
        public static int InserHarmCustomCustomer(ComplianceDAO harm)
        {
            Hashtable htInsertHarmCustomCustomer = new Hashtable();
            htInsertHarmCustomCustomer.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htInsertHarmCustomCustomer.Add("@h_file_guid", harm.h_file_guid);
            htInsertHarmCustomCustomer.Add("@h_file_name", harm.h_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_custom_customer", htInsertHarmCustomCustomer);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetHarmCustomCustomer(ComplianceDAO harm)
        {

            Hashtable htGetCustomCustomer = new Hashtable();
            htGetCustomCustomer.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_custom_customer", htGetCustomCustomer);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static int DeleteHarmAdditionalInformation(ComplianceDAO harm)
        {
            Hashtable htDeleteHarmAddInfo = new Hashtable();
            htDeleteHarmAddInfo.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_additional_info", htDeleteHarmAddInfo);
            }

            catch (Exception)
            {
                throw;
            }

        }




        //Photo

        public static int InsertHarmPhoto(ComplianceDAO harm)
        {
            Hashtable htInsertHarmPhoto = new Hashtable();
            htInsertHarmPhoto.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htInsertHarmPhoto.Add("@h_file_guid", harm.h_file_guid);
            htInsertHarmPhoto.Add("@h_file_name", harm.h_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_photo", htInsertHarmPhoto);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetHarmPhoto(ComplianceDAO harm)
        {

            Hashtable htGetHarmPhoto = new Hashtable();
            htGetHarmPhoto.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_photo", htGetHarmPhoto);
            }

            catch (Exception)
            {
                throw;
            }


        }



        //SceneSketch

        public static int InsertHarmSceneSketch(ComplianceDAO harm)
        {
            Hashtable htInsertHarmSceneSketch = new Hashtable();
            htInsertHarmSceneSketch.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htInsertHarmSceneSketch.Add("@h_file_guid", harm.h_file_guid);
            htInsertHarmSceneSketch.Add("@h_file_name", harm.h_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_scenesketch", htInsertHarmSceneSketch);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetHarmSceneSketch(ComplianceDAO harm)
        {

            Hashtable htGetHarmSceneSketch = new Hashtable();
            htGetHarmSceneSketch.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_scenesketch", htGetHarmSceneSketch);
            }

            catch (Exception)
            {
                throw;
            }


        }


        //ExtenuatingCondition

        public static int InsertHarmExtenuatingCondition(ComplianceDAO harm)
        {
            Hashtable htInsertHarmExtenuatingCondition = new Hashtable();
            htInsertHarmExtenuatingCondition.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htInsertHarmExtenuatingCondition.Add("@h_file_guid", harm.h_file_guid);
            htInsertHarmExtenuatingCondition.Add("@h_file_name", harm.h_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_extenuating_condition", htInsertHarmExtenuatingCondition);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetHarmExtenuatingCondition(ComplianceDAO harm)
        {

            Hashtable htGetHarmExtenuatingCondition = new Hashtable();
            htGetHarmExtenuatingCondition.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_extenuating_condition", htGetHarmExtenuatingCondition);
            }

            catch (Exception)
            {
                throw;
            }


        }

        //EmployeeInterview

        public static int InsertHarmEmployeeInterview(ComplianceDAO harm)
        {
            Hashtable htInsertHarmEmployeeInterview = new Hashtable();
            htInsertHarmEmployeeInterview.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htInsertHarmEmployeeInterview.Add("@h_file_guid", harm.h_file_guid);
            htInsertHarmEmployeeInterview.Add("@h_file_name", harm.h_file_name);
            htInsertHarmEmployeeInterview.Add("@h_name", harm.h_name);
            htInsertHarmEmployeeInterview.Add("@h_contact_info", harm.h_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_employee_interview", htInsertHarmEmployeeInterview);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetHarmEmployeeInterview(ComplianceDAO harm)
        {

            Hashtable htGetHarmEmployeeInterview = new Hashtable();
            htGetHarmEmployeeInterview.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            if (!string.IsNullOrEmpty(harm.s_locale_culture))
            {
                htGetHarmEmployeeInterview.Add("@s_locale_culture", harm.s_locale_culture);
            }
            else
            {
                htGetHarmEmployeeInterview.Add("@s_locale_culture", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_employee_interview", htGetHarmEmployeeInterview);
            }

            catch (Exception)
            {
                throw;
            }


        }
        //Delete HARM file
        public static int DeleteHarmCustomCustomerFile(ComplianceDAO harm)
        {
            Hashtable htDeleteHarmFile = new Hashtable();
            htDeleteHarmFile.Add("@h_custom_customer_form_id_pk", harm.h_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_custom_customer_file", htDeleteHarmFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteHarmPhotoFile(ComplianceDAO harm)
        {
            Hashtable htDeleteHarmFile = new Hashtable();
            htDeleteHarmFile.Add("@h_photo_id_pk", harm.h_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_photo_file", htDeleteHarmFile);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteHarmSceneSketchFile(ComplianceDAO harm)
        {
            Hashtable htDeleteHarmFile = new Hashtable();
            htDeleteHarmFile.Add("@h_scene_sketch_id_pk", harm.h_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_scene_sketch_file", htDeleteHarmFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteHarmExtenautingConditionFile(ComplianceDAO harm)
        {
            Hashtable htDeleteHarmFile = new Hashtable();
            htDeleteHarmFile.Add("@h_extenauting_id_pk", harm.h_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_extenauting_condition_file", htDeleteHarmFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteHarmEmployeeInterviewFile(ComplianceDAO harm)
        {
            Hashtable htDeleteHarmFile = new Hashtable();
            htDeleteHarmFile.Add("@h_employee_interivew_id_pk", harm.h_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_employee_interivew_file", htDeleteHarmFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        //update HARM files
        public static int UpdateHarmCustomCustomer(ComplianceDAO harm)
        {
            Hashtable htUpdateHarmFile = new Hashtable();
            htUpdateHarmFile.Add("@h_custom_customer_form_id_pk", harm.h_file_id);
            htUpdateHarmFile.Add("@h_file_name", harm.h_file_name);
            htUpdateHarmFile.Add("@h_file_guid", harm.h_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_custom_customer", htUpdateHarmFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateHarmPhotoFile(ComplianceDAO harm)
        {
            Hashtable htUpdateHarmFile = new Hashtable();
            htUpdateHarmFile.Add("@h_photo_id_pk", harm.h_file_id);
            htUpdateHarmFile.Add("@h_file_name", harm.h_file_name);
            htUpdateHarmFile.Add("@h_file_guid", harm.h_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_photo", htUpdateHarmFile);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateHarmExtenautingConditionFile(ComplianceDAO harm)
        {
            Hashtable htUpdateHarmFile = new Hashtable();
            htUpdateHarmFile.Add("@h_extenauting_id_pk", harm.h_file_id);
            htUpdateHarmFile.Add("@h_file_name", harm.h_file_name);
            htUpdateHarmFile.Add("@h_file_guid", harm.h_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_extenauting_condition", htUpdateHarmFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateHarmEmployeeInterviewFile(ComplianceDAO harm)
        {
            Hashtable htUpdateHarmFile = new Hashtable();
            htUpdateHarmFile.Add("@h_employee_interivew_id_pk", harm.h_file_id);
            htUpdateHarmFile.Add("@h_file_name", harm.h_file_name);
            htUpdateHarmFile.Add("@h_file_guid", harm.h_file_guid);
            htUpdateHarmFile.Add("@h_name", harm.h_name);
            htUpdateHarmFile.Add("@h_contact_info", harm.h_contact_info);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_employee_interview", htUpdateHarmFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateHarmSceneSketchFile(ComplianceDAO harm)
        {
            Hashtable htUpdateHarmFile = new Hashtable();
            htUpdateHarmFile.Add("@h_scene_sketch_id_pk", harm.h_file_id);
            htUpdateHarmFile.Add("@h_file_name", harm.h_file_name);
            htUpdateHarmFile.Add("@h_file_guid", harm.h_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_scene_sketch", htUpdateHarmFile);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static ComplianceDAO GetHarm(string harmId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            ComplianceDAO harm;
            try
            {
                Hashtable htGetHarm = new Hashtable();
                htGetHarm.Add("@h_harm_id_pk", harmId);
                harm = new ComplianceDAO();
                DataTable dtGetHarm = DataProxy.FetchDataTable("c_harm_sp_get_harm", htGetHarm);
                harm.h_harm_number = dtGetHarm.Rows[0]["h_harm_number"].ToString();
                harm.h_case_title = dtGetHarm.Rows[0]["h_case_title"].ToString();
                harm.h_case_category_fk = dtGetHarm.Rows[0]["h_case_category_fk"].ToString();
                harm.h_status = dtGetHarm.Rows[0]["h_status_text"].ToString();
                //string s = Convert.ToDateTime(dtGetHarm.Rows[0]["h_case_date"].ToString()).ToString("MM/dd/yyyy hh:mm tt");
                //Convert.ToDateTime(dtGetHarm.Rows[0]["h_case_date"].ToString()).ToString("MM/dd/yyyy hh:mm tt");
                harm.h_case_date = Convert.ToDateTime(dtGetHarm.Rows[0]["h_case_date"], culture);
                //DateTime.ParseExact(dtGetHarm.Rows[0]["h_case_date"].ToString(), "MM/dd/yyyy hh:mm tt", null);
                //Convert.ToDateTime(Convert.ToDateTime(dtGetHarm.Rows[0]["h_case_date"]).ToString("MM/dd/yyyy hh:mm tt"));
                harm.h_employee_report_location = dtGetHarm.Rows[0]["h_employee_report_location"].ToString();
                harm.h_case_category_text_view = dtGetHarm.Rows[0]["h_case_category_text_view"].ToString();
                harm.h_status_text_view = dtGetHarm.Rows[0]["h_status_text_view"].ToString();
                harm.h_status_id = dtGetHarm.Rows[0]["h_status_id"].ToString();
                harm.h_custom_01 = dtGetHarm.Rows[0]["h_custom_01"].ToString();
                harm.h_custom_02 = dtGetHarm.Rows[0]["h_custom_02"].ToString();
                harm.h_custom_03 = dtGetHarm.Rows[0]["h_custom_03"].ToString();
                harm.h_custom_04 = dtGetHarm.Rows[0]["h_custom_04"].ToString();
                harm.h_custom_05 = dtGetHarm.Rows[0]["h_custom_05"].ToString();
                harm.h_custom_06 = dtGetHarm.Rows[0]["h_custom_06"].ToString();
                harm.h_custom_07 = dtGetHarm.Rows[0]["h_custom_07"].ToString();
                harm.h_custom_08 = dtGetHarm.Rows[0]["h_custom_08"].ToString();
                harm.h_custom_09 = dtGetHarm.Rows[0]["h_custom_09"].ToString();
                harm.h_custom_10 = dtGetHarm.Rows[0]["h_custom_10"].ToString();
                harm.h_custom_11 = dtGetHarm.Rows[0]["h_custom_11"].ToString();
                harm.h_custom_12 = dtGetHarm.Rows[0]["h_custom_12"].ToString();
                harm.h_custom_13 = dtGetHarm.Rows[0]["h_custom_13"].ToString();
                return harm;
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable SearchHarm(ComplianceDAO harm)
        {


            Hashtable htSearchHarm = new Hashtable();
            htSearchHarm.Add("@h_harm_number", harm.h_harm_number);
            htSearchHarm.Add("@h_case_title", harm.h_case_title);
            if (!string.IsNullOrEmpty(harm.h_case_date.ToString()))
            {
                htSearchHarm.Add("@h_case_date", harm.h_case_date);
            }
            else
            {
                htSearchHarm.Add("@h_case_date", DBNull.Value);
            }

            if (harm.h_case_category_fk == "0")
                htSearchHarm.Add("@h_case_category_fk", DBNull.Value);
            else
                htSearchHarm.Add("@h_case_category_fk", harm.h_case_category_fk);
            if (harm.h_status == "0")
                htSearchHarm.Add("@h_status", DBNull.Value);
            else
                htSearchHarm.Add("@h_status", harm.h_status);


            try
            {


                return DataProxy.FetchDataTable("c_harm_sp_search_case", htSearchHarm);


            }

            catch (Exception)
            {
                throw;
            }


        }
        public static int UpdateHarm(ComplianceDAO harm)
        {
            Hashtable htInsertHarm = new Hashtable();
            htInsertHarm.Add("@u_user_id_fk", harm.u_user_id_fk);
            htInsertHarm.Add("@h_harm_id_pk", harm.h_harm_id_pk);
            htInsertHarm.Add("@h_harm_number", harm.h_harm_number);
            htInsertHarm.Add("@h_case_title", harm.h_case_title);
            //htInsertHarm.Add("@h_case_date", harm.h_case_date);


            //htInsertHarm.Add("@h_case_date", harm.h_case_date);

            htInsertHarm.Add("@h_case_category_fk", harm.h_case_category_fk);

            htInsertHarm.Add("@h_status", harm.h_status);
            htInsertHarm.Add("@h_employee_report_location", DBNull.Value);

            htInsertHarm.Add("@h_custom_01", harm.h_custom_01);
            htInsertHarm.Add("@h_custom_02", harm.h_custom_02);
            htInsertHarm.Add("@h_custom_03", harm.h_custom_03);
            htInsertHarm.Add("@h_custom_04", harm.h_custom_04);
            htInsertHarm.Add("@h_custom_05", harm.h_custom_05);
            htInsertHarm.Add("@h_custom_06", harm.h_custom_06);
            htInsertHarm.Add("@h_custom_07", harm.h_custom_07);
            htInsertHarm.Add("@h_custom_08", harm.h_custom_08);
            htInsertHarm.Add("@h_custom_09", harm.h_custom_09);
            htInsertHarm.Add("@h_custom_10", harm.h_custom_10);
            htInsertHarm.Add("@h_custom_11", harm.h_custom_11);
            htInsertHarm.Add("@h_custom_12", harm.h_custom_12);
            htInsertHarm.Add("@h_custom_13", harm.h_custom_13);


            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update", htInsertHarm);

            }

            catch (Exception)
            {
                throw;
            }
        }

        //Hazard and control measure

        public static int InsertHazard(ComplianceDAO harm)
        {
            Hashtable htInsertHazard = new Hashtable();
            htInsertHazard.Add("@h_hazard_id_pk", harm.h_hazard_id_pk);
            htInsertHazard.Add("@h_hazard_description", harm.h_hazard_description);
            htInsertHazard.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            if (harm.h_permit_compliance_value == "")
            {
                htInsertHazard.Add("@h_permit_compliance_value", DBNull.Value);
            }
            else
            {
                htInsertHazard.Add("@h_permit_compliance_value", harm.h_permit_compliance_value);
            }
            if (harm.h_program_compliance_value == "")
            {
                htInsertHazard.Add("@h_program_compliance_value", DBNull.Value);
            }
            else
            {
                htInsertHazard.Add("@h_program_compliance_value", harm.h_program_compliance_value);
            }
            htInsertHazard.Add("@h_job_title", harm.h_job_title);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_hazard", htInsertHazard);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertControlMeasure(ComplianceDAO harm)
        {
            Hashtable htInsertcontrolMeasure = new Hashtable();
            htInsertcontrolMeasure.Add("@h_hazard_control_meausre_id_pk", harm.h_hazard_control_meausre_id_pk);
            htInsertcontrolMeasure.Add("@h_control_measure_summary", harm.h_control_measure_summary);
            htInsertcontrolMeasure.Add("@h_hazard_id_fk", harm.h_hazard_id_pk);
            htInsertcontrolMeasure.Add("@h_control_measure_id_fk", harm.h_control_measure_id_fk);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_insert_control_measure", htInsertcontrolMeasure);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpadateHARMJobTitle(ComplianceDAO harm)
        {
            Hashtable htUpdateJobTitle = new Hashtable();
            htUpdateJobTitle.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htUpdateJobTitle.Add("@h_job_title", harm.h_job_title);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_job_title", htUpdateJobTitle);

            }

            catch (Exception)
            {
                throw;
            }
        }


        public static ComplianceDAO GetHazard(string h_hazard_id_pk)
        {
            ComplianceDAO harm;
            try
            {
                harm = new ComplianceDAO();
                Hashtable htGetHazard = new Hashtable();
                htGetHazard.Add("@h_hazard_id_pk", h_hazard_id_pk);

                DataTable dtGetHazard = DataProxy.FetchDataTable("c_harm_sp_get_hazard", htGetHazard);
                harm.h_hazard_id_pk = dtGetHazard.Rows[0]["h_hazard_id_pk"].ToString();
                harm.h_hazard_description = dtGetHazard.Rows[0]["h_hazard_description"].ToString();
                harm.h_hazard_id_fk = dtGetHazard.Rows[0]["h_harm_id_fk"].ToString();
                return harm;
            }



            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// c_sp_insert_all_control_measure
        /// </summary>
        /// <param name="c_control_measure"></param>
        /// <param name="c_edit_hazard"></param>
        /// <param name="h_hazard_id_fk"></param>
        /// <returns></returns>
        public static int InsertAllControlMeasure(string c_control_measure, bool c_edit_hazard, string h_hazard_id_fk, string h_hazard_control_meausre_id_pk)
        {
            Hashtable htInsertAllControlMeasure = new Hashtable();
            htInsertAllControlMeasure.Add("@c_control_measure", c_control_measure);
            htInsertAllControlMeasure.Add("@c_edit_hazard", c_edit_hazard);
            htInsertAllControlMeasure.Add("@h_hazard_id_fk", h_hazard_id_fk);
            if (!string.IsNullOrEmpty(h_hazard_control_meausre_id_pk))
            {
                htInsertAllControlMeasure.Add("@h_hazard_control_meausre_id_pk", h_hazard_control_meausre_id_pk);
            }
            else
            {
                htInsertAllControlMeasure.Add("@h_hazard_control_meausre_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("c_sp_insert_all_control_measure", htInsertAllControlMeasure);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetControlMeasure(string h_hazard_control_meausre_id_pk)
        {
            Hashtable htGetControlMeasure = new Hashtable();
            htGetControlMeasure.Add("@h_hazard_control_meausre_id_pk", h_hazard_control_meausre_id_pk);
            try
            {

                return DataProxy.FetchDataTable("c_harm_sp_get_control_measure", htGetControlMeasure);
            }

            catch (Exception)
            {
                throw;
            }
            //// ComplianceDAO harm;
            // try
            // {
            //    // harm = new ComplianceDAO();
            //     Hashtable htGetControlMeasure = new Hashtable();
            //     htGetControlMeasure.Add("@h_hazard_control_meausre_id_pk", h_hazard_control_meausre_id_pk);

            //     DataTable dtGetControlMeasure = DataProxy.FetchDataTable("c_harm_sp_get_control_measure", htGetControlMeasure);
            //     //harm.h_hazard_control_meausre_id_pk = dtGetControlMeasure.Rows[0]["h_hazard_control_meausre_id_pk"].ToString();
            //    // harm.h_hazard_id_fk = dtGetControlMeasure.Rows[0]["h_hazard_id_fk"].ToString();
            //    // harm.h_control_measure_summary = dtGetControlMeasure.Rows[0]["h_control_measure_summary"].ToString();
            //    // return harm;
            // }



            // catch (Exception)
            // {
            //     throw;
            // }




        }

        public static DataTable GetAllHazard(ComplianceDAO harm)
        {

            Hashtable htGetHazard = new Hashtable();
            htGetHazard.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_all_hazard", htGetHazard);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetAllControlMeasure(ComplianceDAO harm)
        {

            Hashtable htGetControlMeasure = new Hashtable();
            htGetControlMeasure.Add("@h_hazard_id_fk", harm.h_hazard_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_harm_sp_get_all_control_measure", htGetControlMeasure);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static int UpdateHazard(ComplianceDAO harm)
        {
            Hashtable htInsertHazard = new Hashtable();
            htInsertHazard.Add("@h_hazard_description", harm.h_hazard_description);
            htInsertHazard.Add("@h_hazard_id_pk", harm.h_hazard_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_hazard", htInsertHazard);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateControlMeasure(ComplianceDAO harm)
        {
            Hashtable htInsertHazard = new Hashtable();
            htInsertHazard.Add("@h_control_measure_summary", harm.h_control_measure_summary);
            htInsertHazard.Add("@h_hazard_control_meausre_id_pk", harm.h_hazard_control_meausre_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_control_measure", htInsertHazard);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteHazardControlMeasure(ComplianceDAO harm)
        {
            Hashtable htDeleteHazardControlMeasure = new Hashtable();
            htDeleteHazardControlMeasure.Add("@h_hazard_id_pk", harm.h_hazard_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_hazard_control_measure", htDeleteHazardControlMeasure);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteControlMeasure(ComplianceDAO harm)
        {
            Hashtable htDeleteControlMeasure = new Hashtable();
            htDeleteControlMeasure.Add("@h_hazard_control_meausre_id_pk", harm.h_hazard_control_meausre_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_control_measure", htDeleteControlMeasure);
            }

            catch (Exception)
            {
                throw;
            }
        }


        public static DataTable GetHarmCategory(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetHarmCategory = new Hashtable();
                htGetHarmCategory.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmCategory.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_harm_sp_get_category", htGetHarmCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetHarmAllCategory(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetHarmAllCategory = new Hashtable();
                htGetHarmAllCategory.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmAllCategory.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_harm_sp_get_all_category", htGetHarmAllCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetHarmStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmStatus = new Hashtable();
                htGetHarmStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_harm_sp_get_status", htGetHarmStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetHarmAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetHarmallStatus = new Hashtable();
                htGetHarmallStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmallStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_harm_sp_get_all_status", htGetHarmallStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisCaseCategory(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetMirisCaseCategory = new Hashtable();
                htGetMirisCaseCategory.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisCaseCategory.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_case_category", htGetMirisCaseCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisAllCaseCategory(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetMirisAllCaseCategory = new Hashtable();
                htGetMirisAllCaseCategory.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisAllCaseCategory.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_all_case_category", htGetMirisAllCaseCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisCaseType(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetMirisCaseType = new Hashtable();
                htGetMirisCaseType.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisCaseType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_case_type", htGetMirisCaseType);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisAllCaseType(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetMirisAllCaseType = new Hashtable();
                htGetMirisAllCaseType.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisAllCaseType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_all_case_type", htGetMirisAllCaseType);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisCaseStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetMirisCaseStatus = new Hashtable();
                htGetMirisCaseStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisCaseStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_case_status", htGetMirisCaseStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisCaseAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {


            try
            {
                Hashtable htGetMirisCaseAllStatus = new Hashtable();
                htGetMirisCaseAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisCaseAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_case_all_status", htGetMirisCaseAllStatus);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisCaseOutCome()
        {


            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_case_outcome");
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetMirisCaseIllness()
        {


            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_illness_type");
            }

            catch (Exception)
            {
                throw;
            }


        }

        public static int UpdateHarmStatus(ComplianceDAO harm)
        {
            Hashtable htHarmStatus = new Hashtable();

            htHarmStatus.Add("@h_harm_id_pk", harm.h_harm_id_pk);


            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_status", htHarmStatus);
            }

            catch (Exception)
            {
                throw;
            }

        }

        public static int DeleteAddInfoHazardControlMeasure(ComplianceDAO harm)
        {
            Hashtable htDeleteAddInfoHazardControlMeasure = new Hashtable();
            htDeleteAddInfoHazardControlMeasure.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_delete_additional_info_and_hazard_control_measure", htDeleteAddInfoHazardControlMeasure);
            }

            catch (Exception)
            {
                throw;
            }

        }
        public static DataSet createHARMPDF(ComplianceDAO harm)
        {

            Hashtable htcreatePDF = new Hashtable();
            htcreatePDF.Add("@h_harm_id_pk", harm.h_harm_id_pk);
            htcreatePDF.Add("@s_locale_culture", harm.s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("c_harm_sp_create_pdf", htcreatePDF);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetProgramCompliance(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetProgramCompliance = new Hashtable();
                htGetProgramCompliance.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetProgramCompliance.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_harm_sp_get_program_compliance", htGetProgramCompliance);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable GetPermitCompliance(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetPermitCompliance = new Hashtable();
                htGetPermitCompliance.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetPermitCompliance.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_harm_sp_get_permit_compliance", htGetPermitCompliance);
            }

            catch (Exception)
            {
                throw;
            }


        }

        public static int UpdateProgramCompliance(ComplianceDAO harm)
        {
            Hashtable htUpdateProgramCompliance = new Hashtable();
            htUpdateProgramCompliance.Add("@h_program_compliance_value", harm.h_program_compliance_value);
            htUpdateProgramCompliance.Add("@h_hazard_id_pk", harm.h_hazard_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_program_compliance", htUpdateProgramCompliance);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdatePermitCompliance(ComplianceDAO harm)
        {
            Hashtable htUpdatePermitCompliance = new Hashtable();
            htUpdatePermitCompliance.Add("@h_permit_compliance_value", harm.h_permit_compliance_value);
            htUpdatePermitCompliance.Add("@h_hazard_id_pk", harm.h_hazard_id_pk);

            try
            {
                return DataProxy.FetchSPOutput("c_harm_sp_update_permit_compliance", htUpdatePermitCompliance);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetHazardControlMeasureReport(ComplianceDAO harm)
        {

            Hashtable htHazardControlMeasureReport = new Hashtable();
            htHazardControlMeasureReport.Add("@h_harm_id_fk", harm.h_harm_id_pk);
            htHazardControlMeasureReport.Add("@s_locale_culture", harm.s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("c_harm_sp_report_hazard_control_measure", htHazardControlMeasureReport);
            }

            catch (Exception)
            {
                throw;
            }


        }
        public static DataSet GetControlMeasureReport(string h_hazard_id_fk, string c_current_culture)
        {

            Hashtable htControlMeasureReport = new Hashtable();
            htControlMeasureReport.Add("@h_hazard_id_fk", h_hazard_id_fk);
            htControlMeasureReport.Add("@s_ui_locale_id_fk", c_current_culture);

            try
            {
                return DataProxy.FetchDataSet("c_harm_sp_report_control_measure", htControlMeasureReport);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// create new case on complete existing case
        /// </summary>
        /// <param name="c_case_id_pk"></param>
        /// <param name="c_new_case_id_pk"></param>
        /// <returns></returns>
        public static int CreateCaseOnComplete(string c_case_id_pk, string c_new_case_id_pk)
        {
            Hashtable htCreateCaseComplete = new Hashtable();
            htCreateCaseComplete.Add("@c_case_id_pk", c_case_id_pk);
            htCreateCaseComplete.Add("@c_new_case_id_pk", c_new_case_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_new_case_on_complete", htCreateCaseComplete);
            }

            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetControlMeasure(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetHarmCategory = new Hashtable();
                htGetHarmCategory.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetHarmCategory.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_course_sp_get_control_measures", htGetHarmCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        //Newly Added functions
        //Added 
        public static int InsertCaseOI(ComplianceDAO miris)
        {
            Hashtable htInsertCase = new Hashtable();
            htInsertCase.Add("@c_case_id_pk", miris.c_case_id_pk);
            htInsertCase.Add("@u_user_id_fk", miris.u_user_id_fk);
            htInsertCase.Add("@c_case_number", miris.c_case_number);
            htInsertCase.Add("@c_case_title", miris.c_case_title);
            htInsertCase.Add("@c_case_category_fk", miris.c_case_category_fk);
            htInsertCase.Add("@c_case_type_fk", miris.c_case_type_fk);
            htInsertCase.Add("@c_case_status", miris.c_case_status);
            htInsertCase.Add("@c_employee_name", miris.c_employee_name);
            htInsertCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htInsertCase.Add("@c_employee_dob", miris.c_employee_dob);
            htInsertCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
            htInsertCase.Add("@c_employee_id", miris.c_employee_id);
            htInsertCase.Add("@c_ssn", miris.c_ssn);
            htInsertCase.Add("@c_supervisor", miris.c_supervisor);
            htInsertCase.Add("@c_incident_location", miris.c_incident_location);
            htInsertCase.Add("@c_incident_date", miris.c_incident_date);
            htInsertCase.Add("@c_incident_time", miris.c_incident_time);
            htInsertCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htInsertCase.Add("@c_note", miris.c_note);
            htInsertCase.Add("@c_root_cause_analysic_info", miris.c_root_cause_analysic_info);
            htInsertCase.Add("@c_corrective_action_info", miris.c_corrective_action_info);
            htInsertCase.Add("@c_osha_300_case_outcome", DBNull.Value);
            htInsertCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
            htInsertCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

            if (miris.c_osha_300_date_of_death != null)
            {
                htInsertCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
            }
            else
            {
                htInsertCase.Add("@c_osha_300_date_of_death", DBNull.Value);
            }
            if (miris.c_date_in_title != null)
            {
                htInsertCase.Add("@c_date_in_title", miris.c_date_in_title);
            }
            else
            {
                htInsertCase.Add("@c_date_in_title", DBNull.Value);
            }
            htInsertCase.Add("@c_osha_300_type_of_illness", DBNull.Value);



            htInsertCase.Add("@c_osha_300_info", DBNull.Value);
            htInsertCase.Add("@c_osha_301_worker_gender", DBNull.Value);

            if (miris.c_osha_301_work_start_time != null)
            {
                htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }
            else
            {
                htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }


            htInsertCase.Add("@c_osha_301_physician", DBNull.Value);
            htInsertCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
            htInsertCase.Add("@c_osha_301_emergency_room", DBNull.Value);
            htInsertCase.Add("@c_osha_301_hospitalized", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address1", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address2", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address3", DBNull.Value);
            htInsertCase.Add("@c_osha_301_city", DBNull.Value);
            htInsertCase.Add("@c_osha_301_state", DBNull.Value);
            htInsertCase.Add("@c_osha_301_zip", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_1", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_2", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_3", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_4", DBNull.Value);
            htInsertCase.Add("@c_custom_01", miris.c_custom_01);
            htInsertCase.Add("@c_custom_02", miris.c_custom_02);
            htInsertCase.Add("@c_custom_03", miris.c_custom_03);
            htInsertCase.Add("@c_custom_04", miris.c_custom_04);
            htInsertCase.Add("@c_custom_05", miris.c_custom_05);
            htInsertCase.Add("@c_custom_06", miris.c_custom_06);
            htInsertCase.Add("@c_custom_07", miris.c_custom_07);
            htInsertCase.Add("@c_custom_08", miris.c_custom_08);
            htInsertCase.Add("@c_custom_09", miris.c_custom_09);
            htInsertCase.Add("@c_custom_10", miris.c_custom_10);
            htInsertCase.Add("@c_custom_11", miris.c_custom_11);
            htInsertCase.Add("@c_custom_12", miris.c_custom_12);
            htInsertCase.Add("@c_custom_13", miris.c_custom_13);
            htInsertCase.Add("@c_case_date", miris.c_case_date);
            htInsertCase.Add("@c_timezone_id_fk", miris.c_timezoneId);
            if (miris.c_time_and_date_notified != null)
            {
                htInsertCase.Add("@c_time_and_date_notified", miris.c_time_and_date_notified);
            }
            else
            {
                htInsertCase.Add("@c_time_and_date_notified", DBNull.Value);
            }

            //htInsertCase.Add("@c_time_and_date_notified", miris.c_time_and_date_notified);
            htInsertCase.Add("@c_job_title", miris.c_job_title);
            htInsertCase.Add("@c_department_code", miris.c_department_code);
            htInsertCase.Add("@c_privacy_case", miris.c_privacy_case);
            htInsertCase.Add("@c_company_owned", miris.c_company_owned);
            htInsertCase.Add("@c_location_description", miris.c_location_description);
            htInsertCase.Add("@c_incident_description", miris.c_incident_description);
            htInsertCase.Add("@c_injury_complaint", miris.c_injury_complaint);
            htInsertCase.Add("@c_injury_type_fk", miris.c_injury_type_fk);
            htInsertCase.Add("@c_injury_cause_fk", miris.c_injury_cause_fk);
            htInsertCase.Add("@c_contributing_factors", miris.c_contributing_factors);
            htInsertCase.Add("@c_contributing_objects", miris.c_contributing_objects);
            htInsertCase.Add("@c_severity_fk", miris.c_severity_fk);
            htInsertCase.Add("@c_hospital", miris.c_hospital);
            htInsertCase.Add("@c_treatment_description", miris.c_treatment_description);
            htInsertCase.Add("@c_dart", miris.c_dart);
            htInsertCase.Add("@c_est_lwd", miris.c_est_lwd);
            htInsertCase.Add("@c_actual_lwd_and_osha_lwd", miris.c_actual_lwd_and_osha_lwd);
            htInsertCase.Add("@c_light_duty", miris.c_light_duty);
            htInsertCase.Add("@c_est_ld", miris.c_est_ld);
            htInsertCase.Add("@c_actual_ld_and_osha_restricted", miris.c_actual_ld_and_osha_restricted);
            htInsertCase.Add("@c_restricted_or_transferred", miris.c_restricted_or_transferred);
            htInsertCase.Add("@c_firstday_of_days_away", miris.c_firstday_of_days_away);
            htInsertCase.Add("@c_firstday_of_days_restricted_or_transferred", miris.c_firstday_of_days_restricted_or_transferred);
            htInsertCase.Add("@c_lastday_days_away", miris.c_lastday_days_away);
            htInsertCase.Add("@c_lastday_days_restricted_or_transferred", miris.c_lastday_days_restricted_or_transferred);


            //Witness
            if (!string.IsNullOrEmpty(miris.c_miris_witness))
            {
                htInsertCase.Add("@c_miris_witness", miris.c_miris_witness);
            }
            else
            {
                htInsertCase.Add("@c_miris_witness", DBNull.Value);
            }
            //photo
            if (!string.IsNullOrEmpty(miris.c_miris_photo))
            {
                htInsertCase.Add("@c_miris_photo", miris.c_miris_photo);
            }
            else
            {
                htInsertCase.Add("@c_miris_photo", DBNull.Value);
            }
            //police report
            if (!string.IsNullOrEmpty(miris.c_miris_police_report))
            {
                htInsertCase.Add("@c_miris_police_report", miris.c_miris_police_report);
            }
            else
            {
                htInsertCase.Add("@c_miris_police_report", DBNull.Value);
            }
            //scene sketch
            if (!string.IsNullOrEmpty(miris.c_miris_scene_sketch))
            {
                htInsertCase.Add("@c_miris_scene_sketch", miris.c_miris_scene_sketch);
            }
            else
            {
                htInsertCase.Add("@c_miris_scene_sketch", DBNull.Value);
            }
            //extenuating condition
            if (!string.IsNullOrEmpty(miris.c_miris_extenuating_condition))
            {
                htInsertCase.Add("@c_miris_extenuating_condition", miris.c_miris_extenuating_condition);
            }
            else
            {
                htInsertCase.Add("@c_miris_extenuating_condition", DBNull.Value);
            }
            //employee interview
            if (!string.IsNullOrEmpty(miris.c_miris_employee_interview))
            {
                htInsertCase.Add("@c_miris_employee_interview", miris.c_miris_employee_interview);
            }
            else
            {
                htInsertCase.Add("@c_miris_employee_interview", DBNull.Value);
            }
            //employee statement
            if (!string.IsNullOrEmpty(miris.c_miris_employee_statement))
            {
                htInsertCase.Add("@c_miris_employee_statement", miris.c_miris_employee_statement);
            }
            else
            {
                htInsertCase.Add("@c_miris_employee_statement", DBNull.Value);
            }
            //Policies
            if (!string.IsNullOrEmpty(miris.c_miris_policies))
            {
                htInsertCase.Add("@c_miris_policies", miris.c_miris_policies);
            }
            else
            {
                htInsertCase.Add("@c_miris_policies", DBNull.Value);
            }
            // Training History
            if (!string.IsNullOrEmpty(miris.c_miris_training_history))
            {
                htInsertCase.Add("@c_miris_training_history", miris.c_miris_training_history);
            }
            else
            {
                htInsertCase.Add("@c_miris_training_history", DBNull.Value);
            }
            // Observation
            if (!string.IsNullOrEmpty(miris.c_miris_observation))
            {
                htInsertCase.Add("@c_miris_observation", miris.c_miris_observation);
            }
            else
            {
                htInsertCase.Add("@c_miris_observation", DBNull.Value);
            }
            // Incident History
            if (!string.IsNullOrEmpty(miris.c_miris_incident_history))
            {
                htInsertCase.Add("@c_miris_incident_history", miris.c_miris_incident_history);
            }
            else
            {
                htInsertCase.Add("@c_miris_incident_history", DBNull.Value);
            }
            try
            {
                UpdateCaseType(miris.c_case_id_pk, miris.c_case_type_fk);
                return DataProxy.FetchSPOutput("c_miris_sp_insert_case_oi", htInsertCase);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static ComplianceDAO GetCaseOI(string caseId)
        {
            ComplianceDAO miris;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCase = new Hashtable();
                htGetCase.Add("@c_case_id_pk", caseId);
                miris = new ComplianceDAO();
                DataTable dtGetCase = DataProxy.FetchDataTable("c_miris_get_case_oi", htGetCase);
                miris.c_case_number = dtGetCase.Rows[0]["c_case_number"].ToString();
                miris.c_case_title = dtGetCase.Rows[0]["c_case_title"].ToString();
                miris.c_case_category_fk = dtGetCase.Rows[0]["c_case_category_fk"].ToString();
                miris.c_case_type_fk = GetCaseTypes(caseId);//dtGetCase.Rows[0]["c_case_type_fk"].ToString();
                miris.c_case_status = dtGetCase.Rows[0]["c_case_status"].ToString();
                miris.c_employee_name = dtGetCase.Rows[0]["c_employee_name"].ToString();
                miris.c_employee_last_name = dtGetCase.Rows[0]["c_employee_last_name"].ToString();
                miris.c_case_category_value = dtGetCase.Rows[0]["c_case_category_value"].ToString();
                miris.c_case_status_value = dtGetCase.Rows[0]["c_case_status_value"].ToString();
                miris.c_case_type_value = dtGetCase.Rows[0]["c_case_type_value"].ToString();
                miris.c_osha_300_type_of_illness_value = dtGetCase.Rows[0]["c_osha_300_type_of_illness_value"].ToString();
                miris.c_osha_300_case_outcome_value = dtGetCase.Rows[0]["c_osha_300_case_outcome_value"].ToString();


                if (dtGetCase.Rows[0]["c_date_in_title"] == null || string.IsNullOrEmpty(dtGetCase.Rows[0]["c_date_in_title"].ToString()))
                {
                    miris.c_date_in_title = null;
                }
                else
                {
                    miris.c_date_in_title = Convert.ToDateTime(dtGetCase.Rows[0]["c_date_in_title"], culture);
                }
                miris.c_employee_dob = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_dob"], culture);
                miris.c_employee_hire_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_hire_date"], culture);
                miris.c_employee_id = dtGetCase.Rows[0]["c_employee_id"].ToString();
                miris.c_ssn = dtGetCase.Rows[0]["c_ssn"].ToString();
                miris.c_supervisor = dtGetCase.Rows[0]["c_supervisor"].ToString();
                miris.c_incident_location = dtGetCase.Rows[0]["c_incident_location"].ToString();
                miris.c_incident_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_date"], culture);
                miris.incident_HH = Convert.ToInt32(dtGetCase.Rows[0]["incident_HH"].ToString());
                miris.incident_MM = Convert.ToInt32(dtGetCase.Rows[0]["incident_MM"].ToString());
                miris.c_incident_time = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_time"], culture);
                miris.c_employee_report_location = dtGetCase.Rows[0]["c_employee_report_location"].ToString();
                miris.c_note = dtGetCase.Rows[0]["c_note"].ToString();
                miris.c_root_cause_analysic_info = dtGetCase.Rows[0]["c_root_cause_analysic_info"].ToString();
                miris.c_corrective_action_info = dtGetCase.Rows[0]["c_corrective_action_info"].ToString();
                miris.c_custom_01 = dtGetCase.Rows[0]["c_custom_01"].ToString();
                miris.c_custom_02 = dtGetCase.Rows[0]["c_custom_02"].ToString();
                miris.c_custom_03 = dtGetCase.Rows[0]["c_custom_03"].ToString();
                miris.c_custom_04 = dtGetCase.Rows[0]["c_custom_04"].ToString();
                miris.c_custom_05 = dtGetCase.Rows[0]["c_custom_05"].ToString();
                miris.c_custom_06 = dtGetCase.Rows[0]["c_custom_06"].ToString();
                miris.c_custom_07 = dtGetCase.Rows[0]["c_custom_07"].ToString();
                miris.c_custom_08 = dtGetCase.Rows[0]["c_custom_08"].ToString();
                miris.c_custom_09 = dtGetCase.Rows[0]["c_custom_09"].ToString();
                miris.c_custom_10 = dtGetCase.Rows[0]["c_custom_10"].ToString();
                miris.c_custom_11 = dtGetCase.Rows[0]["c_custom_11"].ToString();
                miris.c_custom_12 = dtGetCase.Rows[0]["c_custom_12"].ToString();
                miris.c_custom_13 = dtGetCase.Rows[0]["c_custom_13"].ToString();

                miris.c_case_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_date"], culture);

                miris.c_case_type_text = dtGetCase.Rows[0]["c_case_type_text"].ToString();
                miris.c_status_text = dtGetCase.Rows[0]["c_status_text"].ToString();

                miris.c_timezoneId = dtGetCase.Rows[0]["c_timezone_id_fk"].ToString();
                miris.c_case_category_text = dtGetCase.Rows[0]["c_case_category_text"].ToString();

                miris.incident_HH_text = dtGetCase.Rows[0]["incident_HH_text"].ToString();
                miris.c_note_text = dtGetCase.Rows[0]["c_note_text"].ToString();

                miris.u_time_zone_location = dtGetCase.Rows[0]["u_time_zone_location"].ToString();

                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_time_and_date_notified"].ToString()))
                {
                    miris.c_time_and_date_notified = Convert.ToDateTime(dtGetCase.Rows[0]["c_time_and_date_notified"], culture);
                }

                //if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_time_and_date_notified"].ToString()))
                //{
                //    miris.c_time_and_date_notified = Convert.ToDateTime(dtGetCase.Rows[0]["c_time_and_date_notified"]);
                //}
                miris.c_job_title = dtGetCase.Rows[0]["c_job_title"].ToString();
                miris.c_department_code = dtGetCase.Rows[0]["c_department_code"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_privacy_case"].ToString()))
                {
                    miris.c_privacy_case = Convert.ToBoolean(dtGetCase.Rows[0]["c_privacy_case"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_company_owned"].ToString()))
                {
                    miris.c_company_owned = Convert.ToBoolean(dtGetCase.Rows[0]["c_company_owned"]);
                }
                miris.c_location_description = dtGetCase.Rows[0]["c_location_description"].ToString();
                miris.c_incident_description = dtGetCase.Rows[0]["c_incident_description"].ToString();
                miris.c_injury_complaint = dtGetCase.Rows[0]["c_injury_complaint"].ToString();
                miris.c_injury_type_fk = dtGetCase.Rows[0]["c_injury_type_fk"].ToString();
                miris.c_injury_cause_fk = dtGetCase.Rows[0]["c_injury_cause_fk"].ToString();
                miris.c_contributing_factors = dtGetCase.Rows[0]["c_contributing_factors"].ToString();
                miris.c_contributing_objects = dtGetCase.Rows[0]["c_contributing_objects"].ToString();
                miris.c_severity_fk = dtGetCase.Rows[0]["c_severity_fk"].ToString();
                miris.c_hospital = dtGetCase.Rows[0]["c_hospital"].ToString();
                miris.c_treatment_description = dtGetCase.Rows[0]["c_treatment_description"].ToString();
                miris.c_dart = dtGetCase.Rows[0]["c_dart"].ToString();
                miris.c_est_lwd = dtGetCase.Rows[0]["c_est_lwd"].ToString();
                miris.c_actual_lwd_and_osha_lwd = dtGetCase.Rows[0]["c_actual_lwd_and_osha_lwd"].ToString();
                miris.c_light_duty = dtGetCase.Rows[0]["c_light_duty"].ToString();
                miris.c_est_ld = dtGetCase.Rows[0]["c_est_ld"].ToString();
                miris.c_actual_ld_and_osha_restricted = dtGetCase.Rows[0]["c_actual_ld_and_osha_restricted"].ToString();
                miris.c_restricted_or_transferred = dtGetCase.Rows[0]["c_restricted_or_transferred"].ToString();
                miris.c_firstday_of_days_away = dtGetCase.Rows[0]["c_firstday_of_days_away"].ToString();
                miris.c_firstday_of_days_restricted_or_transferred = dtGetCase.Rows[0]["c_firstday_of_days_restricted_or_transferred"].ToString();
                miris.c_lastday_days_away = dtGetCase.Rows[0]["c_lastday_days_away"].ToString();
                miris.c_lastday_days_restricted_or_transferred = dtGetCase.Rows[0]["c_lastday_days_restricted_or_transferred"].ToString();


                return miris;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UpdateCaseOI(ComplianceDAO miris)
        {
            Hashtable htUpdateCase = new Hashtable();
            htUpdateCase.Add("@c_case_id_pk", miris.c_case_id_pk);
            htUpdateCase.Add("@u_user_id_fk", miris.u_user_id_fk);
            htUpdateCase.Add("@c_case_number", miris.c_case_number);
            htUpdateCase.Add("@c_case_title", miris.c_case_title);
            htUpdateCase.Add("@c_case_category_fk", miris.c_case_category_fk);
            htUpdateCase.Add("@c_case_type_fk", miris.c_case_type_fk);
            htUpdateCase.Add("@c_case_status", miris.c_case_status);
            htUpdateCase.Add("@c_employee_name", miris.c_employee_name);
            htUpdateCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htUpdateCase.Add("@c_employee_dob", miris.c_employee_dob);
            htUpdateCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
            htUpdateCase.Add("@c_employee_id", miris.c_employee_id);
            htUpdateCase.Add("@c_ssn", miris.c_ssn);
            htUpdateCase.Add("@c_supervisor", miris.c_supervisor);
            htUpdateCase.Add("@c_incident_location", miris.c_incident_location);
            htUpdateCase.Add("@c_incident_date", miris.c_incident_date);
            htUpdateCase.Add("@c_incident_time", miris.c_incident_time);
            htUpdateCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htUpdateCase.Add("@c_note", miris.c_note);
            htUpdateCase.Add("@c_root_cause_analysic_info", miris.c_root_cause_analysic_info);
            htUpdateCase.Add("@c_corrective_action_info", miris.c_corrective_action_info);
            htUpdateCase.Add("@c_osha_300_case_outcome", DBNull.Value);
            htUpdateCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
            htUpdateCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

            if (miris.c_osha_300_date_of_death != null)
            {
                htUpdateCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
            }
            else
            {
                htUpdateCase.Add("@c_osha_300_date_of_death", DBNull.Value);
            }
            if (miris.c_date_in_title != null)
            {
                htUpdateCase.Add("@c_date_in_title", miris.c_date_in_title);
            }
            else
            {
                htUpdateCase.Add("@c_date_in_title", DBNull.Value);
            }
            htUpdateCase.Add("@c_osha_300_type_of_illness", DBNull.Value);




            htUpdateCase.Add("@c_osha_300_info", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_worker_gender", DBNull.Value);

            if (miris.c_osha_301_work_start_time != null)
            {
                htUpdateCase.Add("@c_osha_301_work_start_time", miris.c_osha_301_work_start_time);
            }
            else
            {
                htUpdateCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }


            htUpdateCase.Add("@c_osha_301_physician", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_emergency_room", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_hospitalized", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address1", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address2", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address3", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_city", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_state", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_zip", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_1", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_2", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_3", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_4", DBNull.Value);
            htUpdateCase.Add("@c_custom_01", miris.c_custom_01);
            htUpdateCase.Add("@c_custom_02", miris.c_custom_02);
            htUpdateCase.Add("@c_custom_03", miris.c_custom_03);
            htUpdateCase.Add("@c_custom_04", miris.c_custom_04);
            htUpdateCase.Add("@c_custom_05", miris.c_custom_05);
            htUpdateCase.Add("@c_custom_06", miris.c_custom_06);
            htUpdateCase.Add("@c_custom_07", miris.c_custom_07);
            htUpdateCase.Add("@c_custom_08", miris.c_custom_08);
            htUpdateCase.Add("@c_custom_09", miris.c_custom_09);
            htUpdateCase.Add("@c_custom_10", miris.c_custom_10);
            htUpdateCase.Add("@c_custom_11", miris.c_custom_11);
            htUpdateCase.Add("@c_custom_12", miris.c_custom_12);
            htUpdateCase.Add("@c_custom_13", miris.c_custom_13);
            htUpdateCase.Add("@c_timezone_id_fk", miris.c_timezoneId);

            if (miris.c_time_and_date_notified != null)
            {
                htUpdateCase.Add("@c_time_and_date_notified", miris.c_time_and_date_notified);
            }
            else
            {
                htUpdateCase.Add("@c_time_and_date_notified", DBNull.Value);
            }

            //htUpdateCase.Add("@c_time_and_date_notified", miris.c_time_and_date_notified);
            htUpdateCase.Add("@c_job_title", miris.c_job_title);
            htUpdateCase.Add("@c_department_code", miris.c_department_code);
            htUpdateCase.Add("@c_privacy_case", miris.c_privacy_case);
            htUpdateCase.Add("@c_company_owned", miris.c_company_owned);
            htUpdateCase.Add("@c_location_description", miris.c_location_description);
            htUpdateCase.Add("@c_incident_description", miris.c_incident_description);
            htUpdateCase.Add("@c_injury_complaint", miris.c_injury_complaint);
            htUpdateCase.Add("@c_injury_type_fk", miris.c_injury_type_fk);
            htUpdateCase.Add("@c_injury_cause_fk", miris.c_injury_cause_fk);
            htUpdateCase.Add("@c_contributing_factors", miris.c_contributing_factors);
            htUpdateCase.Add("@c_contributing_objects", miris.c_contributing_objects);
            htUpdateCase.Add("@c_severity_fk", miris.c_severity_fk);
            htUpdateCase.Add("@c_hospital", miris.c_hospital);
            htUpdateCase.Add("@c_treatment_description", miris.c_treatment_description);
            htUpdateCase.Add("@c_dart", miris.c_dart);
            htUpdateCase.Add("@c_est_lwd", miris.c_est_lwd);
            htUpdateCase.Add("@c_actual_lwd_and_osha_lwd", miris.c_actual_lwd_and_osha_lwd);
            htUpdateCase.Add("@c_light_duty", miris.c_light_duty);
            htUpdateCase.Add("@c_est_ld", miris.c_est_ld);
            htUpdateCase.Add("@c_actual_ld_and_osha_restricted", miris.c_actual_ld_and_osha_restricted);
            htUpdateCase.Add("@c_restricted_or_transferred", miris.c_restricted_or_transferred);
            htUpdateCase.Add("@c_firstday_of_days_away", miris.c_firstday_of_days_away);
            htUpdateCase.Add("@c_firstday_of_days_restricted_or_transferred", miris.c_firstday_of_days_restricted_or_transferred);
            htUpdateCase.Add("@c_lastday_days_away", miris.c_lastday_days_away);
            htUpdateCase.Add("@c_lastday_days_restricted_or_transferred", miris.c_lastday_days_restricted_or_transferred);


            try
            {
                UpdateCaseType(miris.c_case_id_pk, miris.c_case_type_fk);
                return DataProxy.FetchSPOutput("c_miris_sp_update_case_oi", htUpdateCase);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateCaseOnCompleteOI(string c_case_id_pk, string c_new_case_id_pk)
        {
            Hashtable htCreateCaseComplete = new Hashtable();
            htCreateCaseComplete.Add("@c_case_id_pk", c_case_id_pk);
            htCreateCaseComplete.Add("@c_new_case_id_pk", c_new_case_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_new_case_on_complete_oi", htCreateCaseComplete);
            }

            catch (Exception)
            {
                throw;
            }

        }

        //MV

        //public static int InsertCaseMV(ComplianceDAO miris)
        //{
        //    Hashtable htInsertCase = new Hashtable();
        //    htInsertCase.Add("@c_case_id_pk", miris.c_case_id_pk);
        //    htInsertCase.Add("@u_user_id_fk", miris.u_user_id_fk);
        //    htInsertCase.Add("@c_case_number", miris.c_case_number);
        //    htInsertCase.Add("@c_case_title", miris.c_case_title);
        //    htInsertCase.Add("@c_case_category_fk", miris.c_case_category_fk);
        //    htInsertCase.Add("@c_case_type_fk", miris.c_case_type_fk);
        //    htInsertCase.Add("@c_case_status", miris.c_case_status);
        //    htInsertCase.Add("@c_employee_name", miris.c_employee_name);
        //    htInsertCase.Add("@c_employee_dob", miris.c_employee_dob);
        //    htInsertCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
        //    htInsertCase.Add("@c_employee_id", miris.c_employee_id);
        //    htInsertCase.Add("@c_ssn", miris.c_ssn);
        //    htInsertCase.Add("@c_supervisor", miris.c_supervisor);
        //    htInsertCase.Add("@c_incident_location", miris.c_incident_location);
        //    htInsertCase.Add("@c_incident_date", miris.c_incident_date);
        //    htInsertCase.Add("@c_incident_time", miris.c_incident_time);
        //    htInsertCase.Add("@c_employee_report_location", miris.c_employee_report_location);
        //    htInsertCase.Add("@c_note", miris.c_note);
        //    htInsertCase.Add("@c_root_cause_analysic_info", miris.c_root_cause_analysic_info);
        //    htInsertCase.Add("@c_corrective_action_info", miris.c_corrective_action_info);
        //    htInsertCase.Add("@c_osha_300_case_outcome", DBNull.Value);
        //    htInsertCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
        //    htInsertCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

        //    if (miris.c_osha_300_date_of_death != null)
        //    {
        //        htInsertCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_osha_300_date_of_death", DBNull.Value);
        //    }

        //    htInsertCase.Add("@c_osha_300_type_of_illness", DBNull.Value);



        //    htInsertCase.Add("@c_osha_300_info", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_worker_gender", DBNull.Value);

        //    if (miris.c_osha_301_work_start_time != null)
        //    {
        //        htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
        //    }


        //    htInsertCase.Add("@c_osha_301_physician", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_emergency_room", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_hospitalized", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_address1", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_address2", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_address3", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_city", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_state", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_zip", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_info_1", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_info_2", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_info_3", DBNull.Value);
        //    htInsertCase.Add("@c_osha_301_info_4", DBNull.Value);
        //    htInsertCase.Add("@c_custom_01", miris.c_custom_01);
        //    htInsertCase.Add("@c_custom_02", miris.c_custom_02);
        //    htInsertCase.Add("@c_custom_03", miris.c_custom_03);
        //    htInsertCase.Add("@c_custom_04", miris.c_custom_04);
        //    htInsertCase.Add("@c_custom_05", miris.c_custom_05);
        //    htInsertCase.Add("@c_custom_06", miris.c_custom_06);
        //    htInsertCase.Add("@c_custom_07", miris.c_custom_07);
        //    htInsertCase.Add("@c_custom_08", miris.c_custom_08);
        //    htInsertCase.Add("@c_custom_09", miris.c_custom_09);
        //    htInsertCase.Add("@c_custom_10", miris.c_custom_10);
        //    htInsertCase.Add("@c_custom_11", miris.c_custom_11);
        //    htInsertCase.Add("@c_custom_12", miris.c_custom_12);
        //    htInsertCase.Add("@c_custom_13", miris.c_custom_13);
        //    htInsertCase.Add("@c_case_date", miris.c_case_date);
        //    htInsertCase.Add("@c_timezone_id_fk", miris.c_timezoneId);


        //    htInsertCase.Add("@c_case_desc_vehicle_01_fk", miris.c_case_desc_vehicle_01_fk);
        //    htInsertCase.Add("@c_case_desc_vehicle_02_fk", miris.c_case_desc_vehicle_02_fk);

        //    htInsertCase.Add("@c_case_desc_vehicle_id", miris.c_case_desc_vehicle_id);
        //    htInsertCase.Add("@c_case_desc_vehicle_vin", miris.c_case_desc_vehicle_vin);
        //    htInsertCase.Add("@c_case_desc_licence_number", miris.c_case_desc_licence_number);
        //    htInsertCase.Add("@c_case_desc_vehicle_make", miris.c_case_desc_vehicle_make);
        //    htInsertCase.Add("@c_case_desc_vehicle_model", miris.c_case_desc_vehicle_model);
        //    htInsertCase.Add("@c_case_desc_vehicle_type_fk", miris.c_case_desc_vehicle_type_fk);
        //    htInsertCase.Add("@c_case_desc_year", miris.c_case_desc_year);
        //    htInsertCase.Add("@c_case_desc_state", miris.c_case_desc_state);
        //    htInsertCase.Add("@c_case_desc_company_vehicle_struck_fk", miris.c_case_desc_company_vehicle_struck_fk);
        //    htInsertCase.Add("@c_case_desc_company_vehicle_struck_by_fk", miris.c_case_desc_company_vehicle_struck_by_fk);
        //    htInsertCase.Add("@c_case_desc_non_collision", miris.c_case_desc_non_collision);
        //    htInsertCase.Add("@c_case_desc_non_collision_text", miris.c_case_desc_non_collision_text);

        //    htInsertCase.Add("@c_case_detail_drivers_lic", miris.c_case_detail_drivers_lic);
        //    htInsertCase.Add("@c_case_detail_state_and_class", miris.c_case_detail_state_and_class);
        //    if (miris.c_case_detail_expire_date != null)
        //    {
        //        htInsertCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_case_detail_expire_date", DBNull.Value);
        //    }

        //    //htInsertCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
        //    htInsertCase.Add("@c_case_detail_address", miris.c_case_detail_address);
        //    htInsertCase.Add("@c_case_detail_city", miris.c_case_detail_city);
        //    htInsertCase.Add("@c_case_detail_state", miris.c_case_detail_state);
        //    htInsertCase.Add("@c_case_detail_nearest_cross_street", miris.c_case_detail_nearest_cross_street);
        //    htInsertCase.Add("@c_case_detail_type_of_roadway", miris.c_case_detail_type_of_roadway);
        //    htInsertCase.Add("@c_case_detail_road_condition_fk", miris.c_case_detail_road_condition_fk);
        //    if (miris.c_case_detail_time_of_day != null)
        //    {
        //        htInsertCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_case_detail_time_of_day", DBNull.Value);
        //    }

        //    //htInsertCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
        //    // here we need to add one column
        //    htInsertCase.Add("@c_case_detail_weather_fk", miris.c_case_detail_weather_fk);
        //    htInsertCase.Add("@c_case_detail_traffic_condition_fk", miris.c_case_detail_traffic_condition_fk);
        //    htInsertCase.Add("@c_case_detail_traffic_controls_fk", miris.c_case_detail_traffic_controls_fk);
        //    htInsertCase.Add("@c_case_detail_oprating_speed", miris.c_case_detail_oprating_speed);    //d
        //    htInsertCase.Add("@c_case_detail_speed_limit", miris.c_case_detail_speed_limit);      //doubt
        //    htInsertCase.Add("@c_case_detail_vehicle_struck_fk", miris.c_case_detail_vehicle_struck_fk);
        //    htInsertCase.Add("@c_case_detail_vehicle_struck_by_fk", miris.c_case_detail_vehicle_struck_by_fk);
        //    htInsertCase.Add("@c_case_detail_collision_type_fk", miris.c_case_detail_collision_type_fk);
        //    htInsertCase.Add("@c_case_detail_collision_location_fk", miris.c_case_detail_collision_location_fk);
        //    htInsertCase.Add("@c_case_detail_collision_direction_fk", miris.c_case_detail_collision_direction_fk);
        //    htInsertCase.Add("@c_case_detail_non_collision_type_fk", miris.c_case_detail_non_collision_type_fk);
        //    htInsertCase.Add("@c_case_detail_number_of_vehicle_involved", miris.c_case_detail_number_of_vehicle_involved);
        //    htInsertCase.Add("@c_case_detail_number_of_vehicle_towed", miris.c_case_detail_number_of_vehicle_towed);
        //    htInsertCase.Add("@c_case_detail_number_of_people_injured", miris.c_case_detail_number_of_people_injured);
        //    htInsertCase.Add("@c_case_detail_number_of_people_killed", miris.c_case_detail_number_of_people_killed);
        //    htInsertCase.Add("@c_case_detail_cituation_issued", miris.c_case_detail_cituation_issued);
        //    htInsertCase.Add("@c_case_detail_at_whom", miris.c_case_detail_at_whom);
        //    htInsertCase.Add("@c_case_detail_at_fault", miris.c_case_detail_at_fault);
        //    htInsertCase.Add("@c_case_detail_contributory", miris.c_case_detail_contributory);
        //    htInsertCase.Add("@c_case_detail_gross_vehicle_weight", miris.c_case_detail_gross_vehicle_weight);
        //    htInsertCase.Add("@c_case_detail_combined_gross_vehicle_weight", miris.c_case_detail_combined_gross_vehicle_weight);
        //    htInsertCase.Add("@c_case_detail_dot_vehicle", miris.c_case_detail_dot_vehicle);
        //    htInsertCase.Add("@c_case_detail_dot_driver", miris.c_case_detail_dot_driver);
        //    htInsertCase.Add("@c_case_detail_seat_belt_used", miris.c_case_detail_seat_belt_used);
        //    htInsertCase.Add("@c_case_detail_air_bag_eqiupped", miris.c_case_detail_air_bag_eqiupped);
        //    htInsertCase.Add("@c_case_detail_air_bag_deployed", miris.c_case_detail_air_bag_deployed);
        //    htInsertCase.Add("@c_case_detail_cellphone_in_use", miris.c_case_detail_cellphone_in_use);
        //    htInsertCase.Add("@c_case_detail_computer_in_use", miris.c_case_detail_computer_in_use);
        //    htInsertCase.Add("@c_case_detail_special_equipment", miris.c_case_detail_special_equipment);
        //    htInsertCase.Add("@c_case_detail_special_equipment_text", miris.c_case_detail_special_equipment_text);
        //    htInsertCase.Add("@c_case_detail_location_of_impact_fk", miris.c_case_detail_location_of_impact_fk);
        //    htInsertCase.Add("@c_case_detail_driver_injured", miris.c_case_detail_driver_injured);//-- need to add some fields
        //    htInsertCase.Add("@c_case_detail_passenger_injured", miris.c_case_detail_passenger_injured); //-- need to add some fields
        //    htInsertCase.Add("@c_case_detail_damage_heavy", miris.c_case_detail_damage_heavy);
        //    htInsertCase.Add("@c_case_detail_damage_moderate", miris.c_case_detail_damage_moderate);
        //    htInsertCase.Add("@c_case_detail_damage_light", miris.c_case_detail_damage_light);


        //    htInsertCase.Add("@c_pub_vehicle_driver_name", miris.c_pub_vehicle_driver_name);
        //    htInsertCase.Add("@c_pub_vehicle_driver_address", miris.c_pub_vehicle_driver_address);
        //    htInsertCase.Add("@c_pub_vehicle_driver_contact", miris.c_pub_vehicle_driver_contact);
        //    htInsertCase.Add("@c_pub_vehicle_owner_name", miris.c_pub_vehicle_owner_name);
        //    htInsertCase.Add("@c_pub_vehicle_owner_address", miris.c_pub_vehicle_owner_address);
        //    htInsertCase.Add("@c_pub_vehicle_owner_contact", miris.c_pub_vehicle_owner_contact);
        //    htInsertCase.Add("@c_pub_vehicle_vehicle_id", miris.c_pub_vehicle_vehicle_id);
        //    htInsertCase.Add("@c_pub_vehicle_vehicle_vin", miris.c_pub_vehicle_vehicle_vin);
        //    htInsertCase.Add("@c_pub_vehicle_licence_number", miris.c_pub_vehicle_licence_number);
        //    htInsertCase.Add("@c_pub_vehicle_vehicle_make", miris.c_pub_vehicle_vehicle_make);
        //    htInsertCase.Add("@c_pub_vehicle_vehicle_model", miris.c_pub_vehicle_vehicle_model);
        //    htInsertCase.Add("@c_pub_vehicle_vehicle_type_fk", miris.c_pub_vehicle_vehicle_type_fk);
        //    htInsertCase.Add("@c_pub_vehicle_year", miris.c_pub_vehicle_year);
        //    htInsertCase.Add("@c_pub_vehicle_state", miris.c_pub_vehicle_state);
        //    htInsertCase.Add("@c_pub_vehicle_gross_vehicle_weight", miris.c_pub_vehicle_gross_vehicle_weight);
        //    htInsertCase.Add("@c_pub_vehicle_combined_gross_vehicle_weight", miris.c_pub_vehicle_combined_gross_vehicle_weight);
        //    htInsertCase.Add("@c_pub_vehicle_dot_vehicle", miris.c_pub_vehicle_dot_vehicle);
        //    htInsertCase.Add("@c_pub_vehicle_dot_driver", miris.c_pub_vehicle_dot_driver);
        //    htInsertCase.Add("@c_pub_vehicle_seat_belt_used", miris.c_pub_vehicle_seat_belt_used);
        //    htInsertCase.Add("@c_pub_vehicle_air_bag_eqiupped", miris.c_pub_vehicle_air_bag_eqiupped);
        //    htInsertCase.Add("@c_pub_vehicle_air_bag_deployed", miris.c_pub_vehicle_air_bag_deployed);
        //    htInsertCase.Add("@c_pub_vehicle_cellphone_in_use", miris.c_pub_vehicle_cellphone_in_use);
        //    htInsertCase.Add("@c_pub_vehicle_computer_in_use", miris.c_pub_vehicle_computer_in_use);
        //    htInsertCase.Add("@c_pub_vehicle_special_equipment", miris.c_pub_vehicle_special_equipment);
        //    htInsertCase.Add("@c_pub_vehicle_special_equipment_text", miris.c_pub_vehicle_special_equipment_text);
        //    htInsertCase.Add("@c_pub_vehicle_location_of_impact_fk", miris.c_pub_vehicle_location_of_impact_fk);
        //    htInsertCase.Add("@c_pub_vehicle_driver_injured", miris.c_pub_vehicle_driver_injured);// need to add some fields
        //    htInsertCase.Add("@c_pub_vehicle_passenger_injured", miris.c_pub_vehicle_passenger_injured); // need to add some fields
        //    htInsertCase.Add("@c_pub_vehicle_driver_injured_text", miris.c_pub_vehicle_driver_injured_text);
        //    htInsertCase.Add("@c_pub_vehicle_passenger_injured_text", miris.c_pub_vehicle_passenger_injured_text);
        //    htInsertCase.Add("@c_pub_vehicle_number_of_total_vehicle_injured", miris.c_pub_vehicle_number_of_total_vehicle_injured);
        //    htInsertCase.Add("@c_pub_vehicle_damage_heavy", miris.c_pub_vehicle_damage_heavy);
        //    htInsertCase.Add("@c_pub_vehicle_damage_moderate", miris.c_pub_vehicle_damage_moderate);
        //    htInsertCase.Add("@c_pub_vehicle_damage_light", miris.c_pub_vehicle_damage_light);
        //    //Pedestrain Incident
        //    htInsertCase.Add("@c_pedestrain_name", miris.c_pedestrain_name);
        //    htInsertCase.Add("@c_pedestrain_address", miris.c_pedestrain_address);
        //    htInsertCase.Add("@c_pedestrain_phone", miris.c_pedestrain_phone);
        //    htInsertCase.Add("@c_pedestrain_sex", miris.c_pedestrain_sex);
        //    htInsertCase.Add("@c_pedestrain_age", miris.c_pedestrain_age);
        //    htInsertCase.Add("@c_pedestrain_collision_type_fk", miris.c_pedestrain_collision_type_fk);
        //    htInsertCase.Add("@c_pedestrain_description", miris.c_pedestrain_description);
        //    //BICycle Incident
        //    htInsertCase.Add("@c_bicycle_person_name", miris.c_bicycle_person_name);
        //    htInsertCase.Add("@c_bicycle_person_address", miris.c_bicycle_person_address);
        //    htInsertCase.Add("@c_bicycle_person_phone", miris.c_bicycle_person_phone);
        //    htInsertCase.Add("@c_bicycle_person_sex", miris.c_bicycle_person_sex);
        //    htInsertCase.Add("@c_bicycle_person_age", miris.c_bicycle_person_age);
        //    htInsertCase.Add("@c_bicycle_person_collision_type_fk", miris.c_bicycle_person_collision_type_fk);
        //    htInsertCase.Add("@c_bicycle_person_description", miris.c_bicycle_person_description);
        //    //Animal Incident
        //    htInsertCase.Add("@c_animal_name", miris.c_animal_name);
        //    htInsertCase.Add("@c_animal_place", miris.c_animal_place);
        //    htInsertCase.Add("@c_animal_collision_type_fk", miris.c_animal_collision_type_fk);
        //    htInsertCase.Add("@c_animal_description", miris.c_animal_description);
        //    //Fixed Object Incident
        //    htInsertCase.Add("@c_fixed_object_property_name", miris.c_fixed_object_property_name);
        //    htInsertCase.Add("@c_fixed_object_address", miris.c_fixed_object_address);
        //    htInsertCase.Add("@c_fixed_object_contact_info", miris.c_fixed_object_contact_info);
        //    htInsertCase.Add("@c_fixed_object_collision_type_fk", miris.c_fixed_object_collision_type_fk);
        //    htInsertCase.Add("@c_fixed_object_description", miris.c_fixed_object_description);
        //    htInsertCase.Add("@c_fixed_object_property_description", miris.c_fixed_object_property_description);

        //    //Witness
        //    if (!string.IsNullOrEmpty(miris.c_miris_witness))
        //    {
        //        htInsertCase.Add("@c_miris_witness", miris.c_miris_witness);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_miris_witness", DBNull.Value);
        //    }
        //    //photo
        //    if (!string.IsNullOrEmpty(miris.c_miris_photo))
        //    {
        //        htInsertCase.Add("@c_miris_photo", miris.c_miris_photo);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_miris_photo", DBNull.Value);
        //    }
        //    //police report
        //    if (!string.IsNullOrEmpty(miris.c_miris_police_report))
        //    {
        //        htInsertCase.Add("@c_miris_police_report", miris.c_miris_police_report);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_miris_police_report", DBNull.Value);
        //    }
        //    //scene sketch
        //    if (!string.IsNullOrEmpty(miris.c_miris_scene_sketch))
        //    {
        //        htInsertCase.Add("@c_miris_scene_sketch", miris.c_miris_scene_sketch);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_miris_scene_sketch", DBNull.Value);
        //    }
        //    //extenuating condition
        //    if (!string.IsNullOrEmpty(miris.c_miris_extenuating_condition))
        //    {
        //        htInsertCase.Add("@c_miris_extenuating_condition", miris.c_miris_extenuating_condition);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_miris_extenuating_condition", DBNull.Value);
        //    }
        //    //employee interview
        //    if (!string.IsNullOrEmpty(miris.c_miris_employee_interview))
        //    {
        //        htInsertCase.Add("@c_miris_employee_interview", miris.c_miris_employee_interview);
        //    }
        //    else
        //    {
        //        htInsertCase.Add("@c_miris_employee_interview", DBNull.Value);
        //    }
        //    try
        //    {
        //        return DataProxy.FetchSPOutput("c_miris_sp_insert_case_mv", htInsertCase);

        //    }

        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static ComplianceDAO GetCaseMV(string caseId)
        //{
        //    ComplianceDAO miris;
        //    try
        //    {
        //        CultureInfo culture = new CultureInfo("en-US");

        //        Hashtable htGetCase = new Hashtable();
        //        htGetCase.Add("@c_case_id_pk", caseId);
        //        miris = new ComplianceDAO();
        //        DataTable dtGetCase = DataProxy.FetchDataTable("c_miris_get_case_mv", htGetCase);
        //        miris.c_case_number = dtGetCase.Rows[0]["c_case_number"].ToString();
        //        miris.c_case_title = dtGetCase.Rows[0]["c_case_title"].ToString();
        //        miris.c_case_category_fk = dtGetCase.Rows[0]["c_case_category_fk"].ToString();
        //        miris.c_case_type_fk = dtGetCase.Rows[0]["c_case_type_fk"].ToString();
        //        miris.c_case_status = dtGetCase.Rows[0]["c_case_status"].ToString();
        //        miris.c_employee_name = dtGetCase.Rows[0]["c_employee_name"].ToString();

        //        miris.c_case_category_value = dtGetCase.Rows[0]["c_case_category_value"].ToString();
        //        miris.c_case_status_value = dtGetCase.Rows[0]["c_case_status_value"].ToString();
        //        miris.c_case_type_value = dtGetCase.Rows[0]["c_case_type_value"].ToString();
        //        miris.c_osha_300_type_of_illness_value = dtGetCase.Rows[0]["c_osha_300_type_of_illness_value"].ToString();
        //        miris.c_osha_300_case_outcome_value = dtGetCase.Rows[0]["c_osha_300_case_outcome_value"].ToString();



        //        miris.c_employee_dob = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_dob"], culture);
        //        miris.c_employee_hire_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_hire_date"], culture);
        //        miris.c_employee_id = dtGetCase.Rows[0]["c_employee_id"].ToString();
        //        miris.c_ssn = dtGetCase.Rows[0]["c_ssn"].ToString();
        //        miris.c_supervisor = dtGetCase.Rows[0]["c_supervisor"].ToString();
        //        miris.c_incident_location = dtGetCase.Rows[0]["c_incident_location"].ToString();
        //        miris.c_incident_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_date"], culture);
        //        miris.incident_HH = Convert.ToInt32(dtGetCase.Rows[0]["incident_HH"].ToString());
        //        miris.incident_MM = Convert.ToInt32(dtGetCase.Rows[0]["incident_MM"].ToString());
        //        miris.c_incident_time = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_time"], culture);
        //        miris.c_employee_report_location = dtGetCase.Rows[0]["c_employee_report_location"].ToString();
        //        miris.c_note = dtGetCase.Rows[0]["c_note"].ToString();
        //        miris.c_root_cause_analysic_info = dtGetCase.Rows[0]["c_root_cause_analysic_info"].ToString();
        //        miris.c_corrective_action_info = dtGetCase.Rows[0]["c_corrective_action_info"].ToString();
        //        miris.c_custom_01 = dtGetCase.Rows[0]["c_custom_01"].ToString();
        //        miris.c_custom_02 = dtGetCase.Rows[0]["c_custom_02"].ToString();
        //        miris.c_custom_03 = dtGetCase.Rows[0]["c_custom_03"].ToString();
        //        miris.c_custom_04 = dtGetCase.Rows[0]["c_custom_04"].ToString();
        //        miris.c_custom_05 = dtGetCase.Rows[0]["c_custom_05"].ToString();
        //        miris.c_custom_06 = dtGetCase.Rows[0]["c_custom_06"].ToString();
        //        miris.c_custom_07 = dtGetCase.Rows[0]["c_custom_07"].ToString();
        //        miris.c_custom_08 = dtGetCase.Rows[0]["c_custom_08"].ToString();
        //        miris.c_custom_09 = dtGetCase.Rows[0]["c_custom_09"].ToString();
        //        miris.c_custom_10 = dtGetCase.Rows[0]["c_custom_10"].ToString();
        //        miris.c_custom_11 = dtGetCase.Rows[0]["c_custom_11"].ToString();
        //        miris.c_custom_12 = dtGetCase.Rows[0]["c_custom_12"].ToString();
        //        miris.c_custom_13 = dtGetCase.Rows[0]["c_custom_13"].ToString();

        //        miris.c_case_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_date"], culture);

        //        miris.c_case_type_text = dtGetCase.Rows[0]["c_case_type_text"].ToString();
        //        miris.c_status_text = dtGetCase.Rows[0]["c_status_text"].ToString();

        //        miris.c_timezoneId = dtGetCase.Rows[0]["c_timezone_id_fk"].ToString();
        //        miris.c_case_category_text = dtGetCase.Rows[0]["c_case_category_text"].ToString();

        //        miris.incident_HH_text = dtGetCase.Rows[0]["incident_HH_text"].ToString();
        //        miris.c_note_text = dtGetCase.Rows[0]["c_note_text"].ToString();

        //        miris.u_time_zone_location = dtGetCase.Rows[0]["u_time_zone_location"].ToString();

        //        miris.c_case_desc_vehicle_01_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_01_fk"].ToString();
        //        miris.c_case_desc_vehicle_02_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_02_fk"].ToString();

        //        miris.c_case_desc_vehicle_id = dtGetCase.Rows[0]["c_case_desc_vehicle_id"].ToString();
        //        miris.c_case_desc_vehicle_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_vin"].ToString();
        //        miris.c_case_desc_licence_number = dtGetCase.Rows[0]["c_case_desc_licence_number"].ToString();
        //        miris.c_case_desc_vehicle_make = dtGetCase.Rows[0]["c_case_desc_vehicle_make"].ToString();
        //        miris.c_case_desc_vehicle_model = dtGetCase.Rows[0]["c_case_desc_vehicle_model"].ToString();
        //        miris.c_case_desc_vehicle_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_type_fk"].ToString();
        //        miris.c_case_desc_year = dtGetCase.Rows[0]["c_case_desc_year"].ToString();
        //        miris.c_case_desc_state = dtGetCase.Rows[0]["c_case_desc_state"].ToString();
        //        miris.c_case_desc_company_vehicle_struck_fk = dtGetCase.Rows[0]["c_case_desc_company_vehicle_struck_fk"].ToString();
        //        miris.c_case_desc_company_vehicle_struck_by_fk = dtGetCase.Rows[0]["c_case_desc_company_vehicle_struck_by_fk"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_desc_non_collision"].ToString()))
        //        {
        //            miris.c_case_desc_non_collision = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_desc_non_collision"]);
        //        }
        //        miris.c_case_desc_non_collision_text = dtGetCase.Rows[0]["c_case_desc_non_collision_text"].ToString();

        //        miris.c_case_detail_drivers_lic = dtGetCase.Rows[0]["c_case_detail_drivers_lic"].ToString();
        //        miris.c_case_detail_state_and_class = dtGetCase.Rows[0]["c_case_detail_state_and_class"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_expire_date"].ToString()))
        //        {
        //            miris.c_case_detail_expire_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_expire_date"], culture);
        //        }
        //        // miris.c_case_detail_expire_date =Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_expire_date"]);
        //        miris.c_case_detail_address = dtGetCase.Rows[0]["c_case_detail_address"].ToString();
        //        miris.c_case_detail_city = dtGetCase.Rows[0]["c_case_detail_city"].ToString();
        //        miris.c_case_detail_state = dtGetCase.Rows[0]["c_case_detail_state"].ToString();
        //        miris.c_case_detail_nearest_cross_street = dtGetCase.Rows[0]["c_case_detail_nearest_cross_street"].ToString();
        //        miris.c_case_detail_type_of_roadway = dtGetCase.Rows[0]["c_case_detail_type_of_roadway"].ToString();
        //        miris.c_case_detail_road_condition_fk = dtGetCase.Rows[0]["c_case_detail_road_condition_fk"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_time_of_day"].ToString()))
        //        {
        //            miris.c_case_detail_time_of_day = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_time_of_day"], culture);
        //        }

        //        //miris.c_case_detail_time_of_day = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_time_of_day"]);
        //        // here we need to add one column
        //        miris.c_case_detail_weather_fk = dtGetCase.Rows[0]["c_case_detail_weather_fk"].ToString();
        //        miris.c_case_detail_traffic_condition_fk = dtGetCase.Rows[0]["c_case_detail_traffic_condition_fk"].ToString();
        //        miris.c_case_detail_traffic_controls_fk = dtGetCase.Rows[0]["c_case_detail_traffic_controls_fk"].ToString();
        //        miris.c_case_detail_oprating_speed = dtGetCase.Rows[0]["c_case_detail_oprating_speed"].ToString();   //doubt= dtGetCase.Rows[0]["u_time_zone_location"].ToString();
        //        miris.c_case_detail_speed_limit = dtGetCase.Rows[0]["c_case_detail_speed_limit"].ToString();   //doubt
        //        miris.c_case_detail_vehicle_struck_fk = dtGetCase.Rows[0]["c_case_detail_vehicle_struck_fk"].ToString();
        //        miris.c_case_detail_vehicle_struck_by_fk = dtGetCase.Rows[0]["c_case_detail_vehicle_struck_by_fk"].ToString();
        //        miris.c_case_detail_collision_type_fk = dtGetCase.Rows[0]["c_case_detail_collision_type_fk"].ToString();
        //        miris.c_case_detail_collision_location_fk = dtGetCase.Rows[0]["c_case_detail_collision_location_fk"].ToString();
        //        miris.c_case_detail_collision_direction_fk = dtGetCase.Rows[0]["c_case_detail_collision_direction_fk"].ToString();
        //        miris.c_case_detail_non_collision_type_fk = dtGetCase.Rows[0]["c_case_detail_non_collision_type_fk"].ToString();
        //        miris.c_case_detail_number_of_vehicle_involved = dtGetCase.Rows[0]["c_case_detail_number_of_vehicle_involved"].ToString();
        //        miris.c_case_detail_number_of_vehicle_towed = dtGetCase.Rows[0]["c_case_detail_number_of_vehicle_towed"].ToString();
        //        miris.c_case_detail_number_of_people_injured = dtGetCase.Rows[0]["c_case_detail_number_of_people_injured"].ToString();
        //        miris.c_case_detail_number_of_people_killed = dtGetCase.Rows[0]["c_case_detail_number_of_people_killed"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_cituation_issued"].ToString()))
        //        {

        //            miris.c_case_detail_cituation_issued = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_cituation_issued"]);
        //        }
        //        miris.c_case_detail_at_whom = dtGetCase.Rows[0]["c_case_detail_at_whom"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_at_fault"].ToString()))
        //        {

        //            miris.c_case_detail_at_fault = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_at_fault"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_contributory"].ToString()))
        //        {

        //            miris.c_case_detail_contributory = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_contributory"]);
        //        }
        //        miris.c_case_detail_gross_vehicle_weight = dtGetCase.Rows[0]["c_case_detail_gross_vehicle_weight"].ToString();
        //        miris.c_case_detail_combined_gross_vehicle_weight = dtGetCase.Rows[0]["c_case_detail_combined_gross_vehicle_weight"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_dot_vehicle"].ToString()))
        //        {

        //            miris.c_case_detail_dot_vehicle = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_dot_vehicle"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_dot_driver"].ToString()))
        //        {

        //            miris.c_case_detail_dot_driver = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_dot_driver"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_seat_belt_used"].ToString()))
        //        {

        //            miris.c_case_detail_seat_belt_used = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_seat_belt_used"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_air_bag_eqiupped"].ToString()))
        //        {

        //            miris.c_case_detail_air_bag_eqiupped = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_air_bag_eqiupped"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_air_bag_deployed"].ToString()))
        //        {

        //            miris.c_case_detail_air_bag_deployed = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_air_bag_deployed"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_cellphone_in_use"].ToString()))
        //        {

        //            miris.c_case_detail_cellphone_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_cellphone_in_use"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_computer_in_use"].ToString()))
        //        {

        //            miris.c_case_detail_computer_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_computer_in_use"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_special_equipment"].ToString()))
        //        {

        //            miris.c_case_detail_special_equipment = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_special_equipment"]);
        //        }
        //        miris.c_case_detail_special_equipment_text = dtGetCase.Rows[0]["c_case_detail_special_equipment_text"].ToString();
        //        miris.c_case_detail_location_of_impact_fk = dtGetCase.Rows[0]["c_case_detail_location_of_impact_fk"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_driver_injured"].ToString()))
        //        {

        //            miris.c_case_detail_driver_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_driver_injured"]);// need to add some fields= dtGetCase.Rows[0]["u_time_zone_location"].ToString();
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_passenger_injured"].ToString()))
        //        {

        //            miris.c_case_detail_passenger_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_passenger_injured"]); // need to add some fields
        //        }
        //        miris.c_case_detail_damage_heavy = dtGetCase.Rows[0]["c_case_detail_damage_heavy"].ToString();
        //        miris.c_case_detail_damage_moderate = dtGetCase.Rows[0]["c_case_detail_damage_moderate"].ToString();
        //        miris.c_case_detail_damage_light = dtGetCase.Rows[0]["c_case_detail_damage_light"].ToString();
        //        miris.c_pub_vehicle_driver_name = dtGetCase.Rows[0]["c_pub_vehicle_driver_name"].ToString();
        //        miris.c_pub_vehicle_driver_address = dtGetCase.Rows[0]["c_pub_vehicle_driver_address"].ToString();
        //        miris.c_pub_vehicle_driver_contact = dtGetCase.Rows[0]["c_pub_vehicle_driver_contact"].ToString();
        //        miris.c_pub_vehicle_owner_name = dtGetCase.Rows[0]["c_pub_vehicle_owner_name"].ToString();
        //        miris.c_pub_vehicle_owner_address = dtGetCase.Rows[0]["c_pub_vehicle_owner_address"].ToString();
        //        miris.c_pub_vehicle_owner_contact = dtGetCase.Rows[0]["c_pub_vehicle_owner_contact"].ToString();
        //        miris.c_pub_vehicle_vehicle_id = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_id"].ToString();
        //        miris.c_pub_vehicle_vehicle_vin = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_vin"].ToString();
        //        miris.c_pub_vehicle_licence_number = dtGetCase.Rows[0]["c_pub_vehicle_licence_number"].ToString();
        //        miris.c_pub_vehicle_vehicle_make = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_make"].ToString();
        //        miris.c_pub_vehicle_vehicle_model = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_model"].ToString();
        //        miris.c_pub_vehicle_vehicle_type_fk = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_type_fk"].ToString();
        //        miris.c_pub_vehicle_year = dtGetCase.Rows[0]["c_pub_vehicle_year"].ToString();
        //        miris.c_pub_vehicle_state = dtGetCase.Rows[0]["c_pub_vehicle_state"].ToString();
        //        miris.c_pub_vehicle_gross_vehicle_weight = dtGetCase.Rows[0]["c_pub_vehicle_gross_vehicle_weight"].ToString();
        //        miris.c_pub_vehicle_combined_gross_vehicle_weight = dtGetCase.Rows[0]["c_pub_vehicle_combined_gross_vehicle_weight"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_dot_vehicle"].ToString()))
        //        {

        //            miris.c_pub_vehicle_dot_vehicle = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_dot_vehicle"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_dot_driver"].ToString()))
        //        {

        //            miris.c_pub_vehicle_dot_driver = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_dot_driver"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_seat_belt_used"].ToString()))
        //        {

        //            miris.c_pub_vehicle_seat_belt_used = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_seat_belt_used"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_eqiupped"].ToString()))
        //        {

        //            miris.c_pub_vehicle_air_bag_eqiupped = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_eqiupped"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_deployed"].ToString()))
        //        {

        //            miris.c_pub_vehicle_air_bag_deployed = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_deployed"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_cellphone_in_use"].ToString()))
        //        {

        //            miris.c_pub_vehicle_cellphone_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_cellphone_in_use"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_computer_in_use"].ToString()))
        //        {

        //            miris.c_pub_vehicle_computer_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_computer_in_use"]);
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_special_equipment"].ToString()))
        //        {

        //            miris.c_pub_vehicle_special_equipment = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_special_equipment"]);
        //        }


        //        miris.c_pub_vehicle_special_equipment_text = dtGetCase.Rows[0]["c_pub_vehicle_special_equipment_text"].ToString();

        //        miris.c_pub_vehicle_location_of_impact_fk = dtGetCase.Rows[0]["c_pub_vehicle_location_of_impact_fk"].ToString();
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_driver_injured"].ToString()))
        //        {

        //            miris.c_pub_vehicle_driver_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_driver_injured"]);// need to add some fields
        //        }
        //        if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_passenger_injured"].ToString()))
        //        {

        //            miris.c_pub_vehicle_passenger_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_passenger_injured"]);// need to add some fields
        //        }

        //        miris.c_pub_vehicle_driver_injured_text = dtGetCase.Rows[0]["c_pub_vehicle_driver_injured_text"].ToString();
        //        miris.c_pub_vehicle_passenger_injured_text = dtGetCase.Rows[0]["c_pub_vehicle_passenger_injured_text"].ToString();


        //        miris.c_pub_vehicle_number_of_total_vehicle_injured = dtGetCase.Rows[0]["c_pub_vehicle_number_of_total_vehicle_injured"].ToString();
        //        miris.c_pub_vehicle_damage_heavy = dtGetCase.Rows[0]["c_pub_vehicle_damage_heavy"].ToString(); //doubt
        //        miris.c_pub_vehicle_damage_moderate = dtGetCase.Rows[0]["c_pub_vehicle_damage_moderate"].ToString();//doubt
        //        miris.c_pub_vehicle_damage_light = dtGetCase.Rows[0]["c_pub_vehicle_damage_light"].ToString();//doubt
        //        //Pedestrain Incident
        //        miris.c_pedestrain_name = dtGetCase.Rows[0]["c_pedestrain_name"].ToString();
        //        miris.c_pedestrain_address = dtGetCase.Rows[0]["c_pedestrain_address"].ToString();
        //        miris.c_pedestrain_phone = dtGetCase.Rows[0]["c_pedestrain_phone"].ToString();
        //        miris.c_pedestrain_sex = dtGetCase.Rows[0]["c_pedestrain_sex"].ToString();
        //        miris.c_pedestrain_age = dtGetCase.Rows[0]["c_pedestrain_age"].ToString();
        //        miris.c_pedestrain_collision_type_fk = dtGetCase.Rows[0]["c_pedestrain_collision_type_fk"].ToString();
        //        miris.c_pedestrain_description = dtGetCase.Rows[0]["c_pedestrain_description"].ToString();
        //        //BICycle Incident
        //        miris.c_bicycle_person_name = dtGetCase.Rows[0]["c_bicycle_person_name"].ToString();
        //        miris.c_bicycle_person_address = dtGetCase.Rows[0]["c_bicycle_person_address"].ToString();
        //        miris.c_bicycle_person_phone = dtGetCase.Rows[0]["c_bicycle_person_phone"].ToString();
        //        miris.c_bicycle_person_sex = dtGetCase.Rows[0]["c_bicycle_person_sex"].ToString();
        //        miris.c_bicycle_person_age = dtGetCase.Rows[0]["c_bicycle_person_age"].ToString();
        //        miris.c_bicycle_person_collision_type_fk = dtGetCase.Rows[0]["c_bicycle_person_collision_type_fk"].ToString();
        //        miris.c_bicycle_person_description = dtGetCase.Rows[0]["c_bicycle_person_description"].ToString();
        //        //Animal Incident
        //        miris.c_animal_name = dtGetCase.Rows[0]["c_animal_name"].ToString();
        //        miris.c_animal_place = dtGetCase.Rows[0]["c_animal_place"].ToString();
        //        miris.c_animal_collision_type_fk = dtGetCase.Rows[0]["c_animal_collision_type_fk"].ToString();
        //        miris.c_animal_description = dtGetCase.Rows[0]["c_animal_description"].ToString();
        //        //Fixed Object Incident
        //        miris.c_fixed_object_property_name = dtGetCase.Rows[0]["c_fixed_object_property_name"].ToString();
        //        miris.c_fixed_object_address = dtGetCase.Rows[0]["c_fixed_object_address"].ToString();
        //        miris.c_fixed_object_contact_info = dtGetCase.Rows[0]["c_fixed_object_contact_info"].ToString();
        //        miris.c_fixed_object_collision_type_fk = dtGetCase.Rows[0]["c_fixed_object_collision_type_fk"].ToString();
        //        miris.c_fixed_object_description = dtGetCase.Rows[0]["c_fixed_object_description"].ToString();
        //        miris.c_fixed_object_property_description = dtGetCase.Rows[0]["c_fixed_object_property_description"].ToString();


        //        return miris;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //public static int UpdateCaseMV(ComplianceDAO miris)
        //{
        //    Hashtable htUpdateCase = new Hashtable();
        //    htUpdateCase.Add("@c_case_id_pk", miris.c_case_id_pk);
        //    htUpdateCase.Add("@u_user_id_fk", miris.u_user_id_fk);
        //    htUpdateCase.Add("@c_case_number", miris.c_case_number);
        //    htUpdateCase.Add("@c_case_title", miris.c_case_title);
        //    htUpdateCase.Add("@c_case_category_fk", miris.c_case_category_fk);
        //    htUpdateCase.Add("@c_case_type_fk", miris.c_case_type_fk);
        //    htUpdateCase.Add("@c_case_status", miris.c_case_status);
        //    htUpdateCase.Add("@c_employee_name", miris.c_employee_name);
        //    htUpdateCase.Add("@c_employee_dob", miris.c_employee_dob);
        //    htUpdateCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
        //    htUpdateCase.Add("@c_employee_id", miris.c_employee_id);
        //    htUpdateCase.Add("@c_ssn", miris.c_ssn);
        //    htUpdateCase.Add("@c_supervisor", miris.c_supervisor);
        //    htUpdateCase.Add("@c_incident_location", miris.c_incident_location);
        //    htUpdateCase.Add("@c_incident_date", miris.c_incident_date);
        //    htUpdateCase.Add("@c_incident_time", miris.c_incident_time);
        //    htUpdateCase.Add("@c_employee_report_location", miris.c_employee_report_location);
        //    htUpdateCase.Add("@c_note", miris.c_note);
        //    htUpdateCase.Add("@c_root_cause_analysic_info", miris.c_root_cause_analysic_info);
        //    htUpdateCase.Add("@c_corrective_action_info", miris.c_corrective_action_info);
        //    htUpdateCase.Add("@c_osha_300_case_outcome", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

        //    if (miris.c_osha_300_date_of_death != null)
        //    {
        //        htUpdateCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
        //    }
        //    else
        //    {
        //        htUpdateCase.Add("@c_osha_300_date_of_death", DBNull.Value);
        //    }

        //    htUpdateCase.Add("@c_osha_300_type_of_illness", DBNull.Value);




        //    htUpdateCase.Add("@c_osha_300_info", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_worker_gender", DBNull.Value);

        //    if (miris.c_osha_301_work_start_time != null)
        //    {
        //        htUpdateCase.Add("@c_osha_301_work_start_time", miris.c_osha_301_work_start_time);
        //    }
        //    else
        //    {
        //        htUpdateCase.Add("@c_osha_301_work_start_time", DBNull.Value);
        //    }


        //    htUpdateCase.Add("@c_osha_301_physician", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_emergency_room", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_hospitalized", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_address1", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_address2", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_address3", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_city", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_state", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_zip", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_info_1", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_info_2", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_info_3", DBNull.Value);
        //    htUpdateCase.Add("@c_osha_301_info_4", DBNull.Value);
        //    htUpdateCase.Add("@c_custom_01", miris.c_custom_01);
        //    htUpdateCase.Add("@c_custom_02", miris.c_custom_02);
        //    htUpdateCase.Add("@c_custom_03", miris.c_custom_03);
        //    htUpdateCase.Add("@c_custom_04", miris.c_custom_04);
        //    htUpdateCase.Add("@c_custom_05", miris.c_custom_05);
        //    htUpdateCase.Add("@c_custom_06", miris.c_custom_06);
        //    htUpdateCase.Add("@c_custom_07", miris.c_custom_07);
        //    htUpdateCase.Add("@c_custom_08", miris.c_custom_08);
        //    htUpdateCase.Add("@c_custom_09", miris.c_custom_09);
        //    htUpdateCase.Add("@c_custom_10", miris.c_custom_10);
        //    htUpdateCase.Add("@c_custom_11", miris.c_custom_11);
        //    htUpdateCase.Add("@c_custom_12", miris.c_custom_12);
        //    htUpdateCase.Add("@c_custom_13", miris.c_custom_13);
        //    htUpdateCase.Add("@c_timezone_id_fk", miris.c_timezoneId);


        //    htUpdateCase.Add("@c_case_desc_vehicle_01_fk", miris.c_case_desc_vehicle_01_fk);
        //    htUpdateCase.Add("@c_case_desc_vehicle_02_fk", miris.c_case_desc_vehicle_02_fk);

        //    htUpdateCase.Add("@c_case_desc_vehicle_id", miris.c_case_desc_vehicle_id);
        //    htUpdateCase.Add("@c_case_desc_vehicle_vin", miris.c_case_desc_vehicle_vin);
        //    htUpdateCase.Add("@c_case_desc_licence_number", miris.c_case_desc_licence_number);
        //    htUpdateCase.Add("@c_case_desc_vehicle_make", miris.c_case_desc_vehicle_make);
        //    htUpdateCase.Add("@c_case_desc_vehicle_model", miris.c_case_desc_vehicle_model);
        //    htUpdateCase.Add("@c_case_desc_vehicle_type_fk", miris.c_case_desc_vehicle_type_fk);
        //    htUpdateCase.Add("@c_case_desc_year", miris.c_case_desc_year);
        //    htUpdateCase.Add("@c_case_desc_state", miris.c_case_desc_state);
        //    htUpdateCase.Add("@c_case_desc_company_vehicle_struck_fk", miris.c_case_desc_company_vehicle_struck_fk);
        //    htUpdateCase.Add("@c_case_desc_company_vehicle_struck_by_fk", miris.c_case_desc_company_vehicle_struck_by_fk);
        //    htUpdateCase.Add("@c_case_desc_non_collision", miris.c_case_desc_non_collision);
        //    htUpdateCase.Add("@c_case_desc_non_collision_text", miris.c_case_desc_non_collision_text);

        //    htUpdateCase.Add("@c_case_detail_drivers_lic", miris.c_case_detail_drivers_lic);
        //    htUpdateCase.Add("@c_case_detail_state_and_class", miris.c_case_detail_state_and_class);
        //    if (miris.c_case_detail_expire_date != null)
        //    {
        //        htUpdateCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
        //    }
        //    else
        //    {
        //        htUpdateCase.Add("@c_case_detail_expire_date", DBNull.Value);
        //    }

        //    //htUpdateCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
        //    htUpdateCase.Add("@c_case_detail_address", miris.c_case_detail_address);
        //    htUpdateCase.Add("@c_case_detail_city", miris.c_case_detail_city);
        //    htUpdateCase.Add("@c_case_detail_state", miris.c_case_detail_state);
        //    htUpdateCase.Add("@c_case_detail_nearest_cross_street", miris.c_case_detail_nearest_cross_street);
        //    htUpdateCase.Add("@c_case_detail_type_of_roadway", miris.c_case_detail_type_of_roadway);
        //    htUpdateCase.Add("@c_case_detail_road_condition_fk", miris.c_case_detail_road_condition_fk);
        //    if (miris.c_case_detail_time_of_day != null)
        //    {
        //        htUpdateCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
        //    }
        //    else
        //    {
        //        htUpdateCase.Add("@c_case_detail_time_of_day", DBNull.Value);
        //    }

        //    //htUpdateCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
        //    // here we need to add one column
        //    htUpdateCase.Add("@c_case_detail_weather_fk", miris.c_case_detail_weather_fk);
        //    htUpdateCase.Add("@c_case_detail_traffic_condition_fk", miris.c_case_detail_traffic_condition_fk);
        //    htUpdateCase.Add("@c_case_detail_traffic_controls_fk", miris.c_case_detail_traffic_controls_fk);
        //    htUpdateCase.Add("@c_case_detail_oprating_speed", miris.c_case_detail_oprating_speed);    //d
        //    htUpdateCase.Add("@c_case_detail_speed_limit", miris.c_case_detail_speed_limit);      //doubt
        //    htUpdateCase.Add("@c_case_detail_vehicle_struck_fk", miris.c_case_detail_vehicle_struck_fk);
        //    htUpdateCase.Add("@c_case_detail_vehicle_struck_by_fk", miris.c_case_detail_vehicle_struck_by_fk);
        //    htUpdateCase.Add("@c_case_detail_collision_type_fk", miris.c_case_detail_collision_type_fk);
        //    htUpdateCase.Add("@c_case_detail_collision_location_fk", miris.c_case_detail_collision_location_fk);
        //    htUpdateCase.Add("@c_case_detail_collision_direction_fk", miris.c_case_detail_collision_direction_fk);
        //    htUpdateCase.Add("@c_case_detail_non_collision_type_fk", miris.c_case_detail_non_collision_type_fk);
        //    htUpdateCase.Add("@c_case_detail_number_of_vehicle_involved", miris.c_case_detail_number_of_vehicle_involved);
        //    htUpdateCase.Add("@c_case_detail_number_of_vehicle_towed", miris.c_case_detail_number_of_vehicle_towed);
        //    htUpdateCase.Add("@c_case_detail_number_of_people_injured", miris.c_case_detail_number_of_people_injured);
        //    htUpdateCase.Add("@c_case_detail_number_of_people_killed", miris.c_case_detail_number_of_people_killed);
        //    htUpdateCase.Add("@c_case_detail_cituation_issued", miris.c_case_detail_cituation_issued);
        //    htUpdateCase.Add("@c_case_detail_at_whom", miris.c_case_detail_at_whom);
        //    htUpdateCase.Add("@c_case_detail_at_fault", miris.c_case_detail_at_fault);
        //    htUpdateCase.Add("@c_case_detail_contributory", miris.c_case_detail_contributory);
        //    htUpdateCase.Add("@c_case_detail_gross_vehicle_weight", miris.c_case_detail_gross_vehicle_weight);
        //    htUpdateCase.Add("@c_case_detail_combined_gross_vehicle_weight", miris.c_case_detail_combined_gross_vehicle_weight);
        //    htUpdateCase.Add("@c_case_detail_dot_vehicle", miris.c_case_detail_dot_vehicle);
        //    htUpdateCase.Add("@c_case_detail_dot_driver", miris.c_case_detail_dot_driver);
        //    htUpdateCase.Add("@c_case_detail_seat_belt_used", miris.c_case_detail_seat_belt_used);
        //    htUpdateCase.Add("@c_case_detail_air_bag_eqiupped", miris.c_case_detail_air_bag_eqiupped);
        //    htUpdateCase.Add("@c_case_detail_air_bag_deployed", miris.c_case_detail_air_bag_deployed);
        //    htUpdateCase.Add("@c_case_detail_cellphone_in_use", miris.c_case_detail_cellphone_in_use);
        //    htUpdateCase.Add("@c_case_detail_computer_in_use", miris.c_case_detail_computer_in_use);
        //    htUpdateCase.Add("@c_case_detail_special_equipment", miris.c_case_detail_special_equipment);
        //    htUpdateCase.Add("@c_case_detail_special_equipment_text", miris.c_case_detail_special_equipment_text);
        //    htUpdateCase.Add("@c_case_detail_location_of_impact_fk", miris.c_case_detail_location_of_impact_fk);
        //    htUpdateCase.Add("@c_case_detail_driver_injured", miris.c_case_detail_driver_injured);//-- need to add some fields
        //    htUpdateCase.Add("@c_case_detail_passenger_injured", miris.c_case_detail_passenger_injured); //-- need to add some fields
        //    htUpdateCase.Add("@c_case_detail_damage_heavy", miris.c_case_detail_damage_heavy);
        //    htUpdateCase.Add("@c_case_detail_damage_moderate", miris.c_case_detail_damage_moderate);
        //    htUpdateCase.Add("@c_case_detail_damage_light", miris.c_case_detail_damage_light);


        //    htUpdateCase.Add("@c_pub_vehicle_driver_name", miris.c_pub_vehicle_driver_name);
        //    htUpdateCase.Add("@c_pub_vehicle_driver_address", miris.c_pub_vehicle_driver_address);
        //    htUpdateCase.Add("@c_pub_vehicle_driver_contact", miris.c_pub_vehicle_driver_contact);
        //    htUpdateCase.Add("@c_pub_vehicle_owner_name", miris.c_pub_vehicle_owner_name);
        //    htUpdateCase.Add("@c_pub_vehicle_owner_address", miris.c_pub_vehicle_owner_address);
        //    htUpdateCase.Add("@c_pub_vehicle_owner_contact", miris.c_pub_vehicle_owner_contact);
        //    htUpdateCase.Add("@c_pub_vehicle_vehicle_id", miris.c_pub_vehicle_vehicle_id);
        //    htUpdateCase.Add("@c_pub_vehicle_vehicle_vin", miris.c_pub_vehicle_vehicle_vin);
        //    htUpdateCase.Add("@c_pub_vehicle_licence_number", miris.c_pub_vehicle_licence_number);
        //    htUpdateCase.Add("@c_pub_vehicle_vehicle_make", miris.c_pub_vehicle_vehicle_make);
        //    htUpdateCase.Add("@c_pub_vehicle_vehicle_model", miris.c_pub_vehicle_vehicle_model);
        //    htUpdateCase.Add("@c_pub_vehicle_vehicle_type_fk", miris.c_pub_vehicle_vehicle_type_fk);
        //    htUpdateCase.Add("@c_pub_vehicle_year", miris.c_pub_vehicle_year);
        //    htUpdateCase.Add("@c_pub_vehicle_state", miris.c_pub_vehicle_state);
        //    htUpdateCase.Add("@c_pub_vehicle_gross_vehicle_weight", miris.c_pub_vehicle_gross_vehicle_weight);
        //    htUpdateCase.Add("@c_pub_vehicle_combined_gross_vehicle_weight", miris.c_pub_vehicle_combined_gross_vehicle_weight);
        //    htUpdateCase.Add("@c_pub_vehicle_dot_vehicle", miris.c_pub_vehicle_dot_vehicle);
        //    htUpdateCase.Add("@c_pub_vehicle_dot_driver", miris.c_pub_vehicle_dot_driver);
        //    htUpdateCase.Add("@c_pub_vehicle_seat_belt_used", miris.c_pub_vehicle_seat_belt_used);
        //    htUpdateCase.Add("@c_pub_vehicle_air_bag_eqiupped", miris.c_pub_vehicle_air_bag_eqiupped);
        //    htUpdateCase.Add("@c_pub_vehicle_air_bag_deployed", miris.c_pub_vehicle_air_bag_deployed);
        //    htUpdateCase.Add("@c_pub_vehicle_cellphone_in_use", miris.c_pub_vehicle_cellphone_in_use);
        //    htUpdateCase.Add("@c_pub_vehicle_computer_in_use", miris.c_pub_vehicle_computer_in_use);
        //    htUpdateCase.Add("@c_pub_vehicle_special_equipment", miris.c_pub_vehicle_special_equipment);
        //    htUpdateCase.Add("@c_pub_vehicle_special_equipment_text", miris.c_pub_vehicle_special_equipment_text);
        //    htUpdateCase.Add("@c_pub_vehicle_location_of_impact_fk", miris.c_pub_vehicle_location_of_impact_fk);
        //    htUpdateCase.Add("@c_pub_vehicle_driver_injured", miris.c_pub_vehicle_driver_injured);// need to add some fields
        //    htUpdateCase.Add("@c_pub_vehicle_passenger_injured", miris.c_pub_vehicle_passenger_injured); // need to add some fields

        //    htUpdateCase.Add("@c_pub_vehicle_driver_injured_text", miris.c_pub_vehicle_driver_injured_text);
        //    htUpdateCase.Add("@c_pub_vehicle_passenger_injured_text", miris.c_pub_vehicle_passenger_injured_text);

        //    htUpdateCase.Add("@c_pub_vehicle_number_of_total_vehicle_injured", miris.c_pub_vehicle_number_of_total_vehicle_injured);
        //    htUpdateCase.Add("@c_pub_vehicle_damage_heavy", miris.c_pub_vehicle_damage_heavy);
        //    htUpdateCase.Add("@c_pub_vehicle_damage_moderate", miris.c_pub_vehicle_damage_moderate);
        //    htUpdateCase.Add("@c_pub_vehicle_damage_light", miris.c_pub_vehicle_damage_light);
        //    //Pedestrain Incident
        //    htUpdateCase.Add("@c_pedestrain_name", miris.c_pedestrain_name);
        //    htUpdateCase.Add("@c_pedestrain_address", miris.c_pedestrain_address);
        //    htUpdateCase.Add("@c_pedestrain_phone", miris.c_pedestrain_phone);
        //    htUpdateCase.Add("@c_pedestrain_sex", miris.c_pedestrain_sex);
        //    htUpdateCase.Add("@c_pedestrain_age", miris.c_pedestrain_age);
        //    htUpdateCase.Add("@c_pedestrain_collision_type_fk", miris.c_pedestrain_collision_type_fk);
        //    htUpdateCase.Add("@c_pedestrain_description", miris.c_pedestrain_description);
        //    //BICycle Incident
        //    htUpdateCase.Add("@c_bicycle_person_name", miris.c_bicycle_person_name);
        //    htUpdateCase.Add("@c_bicycle_person_address", miris.c_bicycle_person_address);
        //    htUpdateCase.Add("@c_bicycle_person_phone", miris.c_bicycle_person_phone);
        //    htUpdateCase.Add("@c_bicycle_person_sex", miris.c_bicycle_person_sex);
        //    htUpdateCase.Add("@c_bicycle_person_age", miris.c_bicycle_person_age);
        //    htUpdateCase.Add("@c_bicycle_person_collision_type_fk", miris.c_bicycle_person_collision_type_fk);
        //    htUpdateCase.Add("@c_bicycle_person_description", miris.c_bicycle_person_description);
        //    //Animal Incident
        //    htUpdateCase.Add("@c_animal_name", miris.c_animal_name);
        //    htUpdateCase.Add("@c_animal_place", miris.c_animal_place);
        //    htUpdateCase.Add("@c_animal_collision_type_fk", miris.c_animal_collision_type_fk);
        //    htUpdateCase.Add("@c_animal_description", miris.c_animal_description);
        //    //Fixed Object Incident
        //    htUpdateCase.Add("@c_fixed_object_property_name", miris.c_fixed_object_property_name);
        //    htUpdateCase.Add("@c_fixed_object_address", miris.c_fixed_object_address);
        //    htUpdateCase.Add("@c_fixed_object_contact_info", miris.c_fixed_object_contact_info);
        //    htUpdateCase.Add("@c_fixed_object_collision_type_fk", miris.c_fixed_object_collision_type_fk);
        //    htUpdateCase.Add("@c_fixed_object_description", miris.c_fixed_object_description);
        //    htUpdateCase.Add("@c_fixed_object_property_description", miris.c_fixed_object_property_description);


        //    try
        //    {
        //        return DataProxy.FetchSPOutput("c_miris_sp_update_case_mv", htUpdateCase);
        //    }

        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public static int CreateCaseOnCompleteMV(string c_case_id_pk, string c_new_case_id_pk)
        {
            Hashtable htCreateCaseComplete = new Hashtable();
            htCreateCaseComplete.Add("@c_case_id_pk", c_case_id_pk);
            htCreateCaseComplete.Add("@c_new_case_id_pk", c_new_case_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_new_case_on_complete_mv", htCreateCaseComplete);
            }

            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetMirisMVCaseType(string s_ui_locale_name, string s_ui_page_name)
        {

            try
            {
                Hashtable htGetMirisCaseCategory = new Hashtable();
                htGetMirisCaseCategory.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetMirisCaseCategory.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("c_miris_sp_get_mv_case_type", htGetMirisCaseCategory);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Create Miris MV PDF
        /// </summary>
        /// <param name="miris"></param>
        /// <returns></returns>
        public static DataSet createMIRISMVPDF(ComplianceDAO miris)
        {

            Hashtable htcreatePDF = new Hashtable();
            htcreatePDF.Add("@c_case_id_pk", miris.c_case_id_pk);
            htcreatePDF.Add("@s_locale_culture", miris.s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("c_miris_mv_sp_create_pdf", htcreatePDF);
            }

            catch (Exception)
            {
                throw;
            }


        }
        /// <summary>
        /// Create Miris OI PDF
        /// </summary>
        /// <param name="miris"></param>
        /// <returns></returns>
        public static DataSet createMIRISOIPDF(ComplianceDAO miris)
        {

            Hashtable htcreatePDF = new Hashtable();
            htcreatePDF.Add("@c_case_id_pk", miris.c_case_id_pk);
            htcreatePDF.Add("@s_locale_culture", miris.s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("c_miris_oi_sp_create_pdf", htcreatePDF);
            }

            catch (Exception)
            {
                throw;
            }


        }

        //MV
        private static int UpdateCaseType(string c_case_id_pk, string c_case_type)
        {
            var dtBuildSql = new DataTable();
            dtBuildSql.Columns.Add("c_case_id_pk");
            dtBuildSql.Columns.Add("c_case_type");
            string[] caseTypes = c_case_type.Split(new char[] { ',' });
            foreach (var caseType in caseTypes)
            {
                DataRow row = dtBuildSql.NewRow();
                row["c_case_id_pk"] = c_case_id_pk;
                row["c_case_type"] = caseType;
                dtBuildSql.Rows.Add(row);
            }
            var dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            Hashtable htUpdateCaseType = new Hashtable();

            htUpdateCaseType.Add("@c_case_id_pk", c_case_id_pk);
            htUpdateCaseType.Add("@c_case_type", dsBuildSql.GetXml().ToString());
            return DataProxy.FetchSPOutput("s_sp_update_miris_case_type", htUpdateCaseType);
        }

        private static string GetCaseTypes(string c_case_id_pk)
        {

            Hashtable htSearchCase = new Hashtable();
            htSearchCase.Add("@c_case_id_pk", c_case_id_pk);

            try
            {
                string returnValue = "";
                DataTable dtCaseType = DataProxy.FetchDataTable("s_sp_get_miris_case_type", htSearchCase);
                foreach (DataRow caseType in dtCaseType.Rows)
                {
                    returnValue += caseType["c_case_type"].ToString() + ",";
                }
                return returnValue.Substring(0, returnValue.Length - 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertCaseMV(ComplianceDAO miris)
        {

            Hashtable htInsertCase = new Hashtable();
            htInsertCase.Add("@c_case_id_pk", miris.c_case_id_pk);
            htInsertCase.Add("@u_user_id_fk", miris.u_user_id_fk);
            htInsertCase.Add("@c_case_number", miris.c_case_number);
            htInsertCase.Add("@c_case_title", miris.c_case_title);
            htInsertCase.Add("@c_case_category_fk", miris.c_case_category_fk);
            htInsertCase.Add("@c_case_type_fk", miris.c_case_type_fk);
            htInsertCase.Add("@c_case_status", miris.c_case_status);
            htInsertCase.Add("@c_employee_name", miris.c_employee_name);
            htInsertCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htInsertCase.Add("@c_employee_dob", miris.c_employee_dob);
            htInsertCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
            htInsertCase.Add("@c_employee_id", miris.c_employee_id);
            if (miris.c_date_in_title != null)
            {
                htInsertCase.Add("@c_date_in_title", miris.c_date_in_title);
            }
            else
            {
                htInsertCase.Add("@c_date_in_title", DBNull.Value);
            }
            htInsertCase.Add("@c_ssn", miris.c_ssn);
            htInsertCase.Add("@c_supervisor", miris.c_supervisor);
            htInsertCase.Add("@c_incident_location", miris.c_incident_location);
            htInsertCase.Add("@c_incident_date", miris.c_incident_date);
            htInsertCase.Add("@c_incident_time", miris.c_incident_time);
            htInsertCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htInsertCase.Add("@c_note", miris.c_note);
            htInsertCase.Add("@c_root_cause_analysic_info", "");
            htInsertCase.Add("@c_corrective_action_info", "");
            htInsertCase.Add("@c_osha_300_case_outcome", DBNull.Value);
            htInsertCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
            htInsertCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

            if (miris.c_osha_300_date_of_death != null)
            {
                htInsertCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
            }
            else
            {
                htInsertCase.Add("@c_osha_300_date_of_death", DBNull.Value);
            }

            htInsertCase.Add("@c_osha_300_type_of_illness", DBNull.Value);



            htInsertCase.Add("@c_osha_300_info", DBNull.Value);
            htInsertCase.Add("@c_osha_301_worker_gender", DBNull.Value);

            if (miris.c_osha_301_work_start_time != null)
            {
                htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }
            else
            {
                htInsertCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }


            htInsertCase.Add("@c_osha_301_physician", DBNull.Value);
            htInsertCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
            htInsertCase.Add("@c_osha_301_emergency_room", DBNull.Value);
            htInsertCase.Add("@c_osha_301_hospitalized", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address1", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address2", DBNull.Value);
            htInsertCase.Add("@c_osha_301_address3", DBNull.Value);
            htInsertCase.Add("@c_osha_301_city", DBNull.Value);
            htInsertCase.Add("@c_osha_301_state", DBNull.Value);
            htInsertCase.Add("@c_osha_301_zip", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_1", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_2", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_3", DBNull.Value);
            htInsertCase.Add("@c_osha_301_info_4", DBNull.Value);
            htInsertCase.Add("@c_custom_01", miris.c_custom_01);
            htInsertCase.Add("@c_custom_02", miris.c_custom_02);
            htInsertCase.Add("@c_custom_03", miris.c_custom_03);
            htInsertCase.Add("@c_custom_04", miris.c_custom_04);
            htInsertCase.Add("@c_custom_05", miris.c_custom_05);
            htInsertCase.Add("@c_custom_06", miris.c_custom_06);
            htInsertCase.Add("@c_custom_07", miris.c_custom_07);
            htInsertCase.Add("@c_custom_08", miris.c_custom_08);
            htInsertCase.Add("@c_custom_09", miris.c_custom_09);
            htInsertCase.Add("@c_custom_10", miris.c_custom_10);
            htInsertCase.Add("@c_custom_11", miris.c_custom_11);
            htInsertCase.Add("@c_custom_12", miris.c_custom_12);
            htInsertCase.Add("@c_custom_13", miris.c_custom_13);
            htInsertCase.Add("@c_case_date", miris.c_case_date);
            htInsertCase.Add("@c_timezone_id_fk", miris.c_timezoneId);

            htInsertCase.Add("@c_company_owned", miris.c_company_owned);

            htInsertCase.Add("@c_case_desc_vehicle_01_fk", miris.c_case_desc_vehicle_01_fk);
            htInsertCase.Add("@c_case_desc_vehicle_02_fk", miris.c_case_desc_vehicle_02_fk);

            htInsertCase.Add("@c_case_desc_vehicle_id", miris.c_case_desc_vehicle_id);
            htInsertCase.Add("@c_case_desc_vehicle_vin", miris.c_case_desc_vehicle_vin);
            htInsertCase.Add("@c_case_desc_licence_number", miris.c_case_desc_licence_number);
            htInsertCase.Add("@c_case_desc_vehicle_make", miris.c_case_desc_vehicle_make);
            htInsertCase.Add("@c_case_desc_vehicle_model", miris.c_case_desc_vehicle_model);
            htInsertCase.Add("@c_case_desc_vehicle_type_fk", miris.c_case_desc_vehicle_type_fk);
            htInsertCase.Add("@c_case_desc_year", miris.c_case_desc_year);
            htInsertCase.Add("@c_case_desc_state", miris.c_case_desc_state);
            //New Vehicle 
            htInsertCase.Add("@c_case_desc_vehicle_02_id", miris.c_case_desc_vehicle_02_id);
            htInsertCase.Add("@c_case_desc_vehicle_02_vin", miris.c_case_desc_vehicle_02_vin);
            htInsertCase.Add("@c_case_desc_licence_02_number", miris.c_case_desc_licence_02_number);
            htInsertCase.Add("@c_case_desc_vehicle_02_make", miris.c_case_desc_vehicle_02_make);
            htInsertCase.Add("@c_case_desc_vehicle_02_model", miris.c_case_desc_vehicle_02_model);
            htInsertCase.Add("@c_case_desc_vehicle_02_type_fk", miris.c_case_desc_vehicle_02_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_02_year", miris.c_case_desc_vehicle_02_year);
            htInsertCase.Add("@c_case_desc_vehicle_02_state", miris.c_case_desc_vehicle_02_state);

            htInsertCase.Add("@c_case_desc_vehicle_03_fk", miris.c_case_desc_vehicle_03_fk);
            htInsertCase.Add("@c_case_desc_vehicle_03_id", miris.c_case_desc_vehicle_03_id);
            htInsertCase.Add("@c_case_desc_vehicle_03_vin", miris.c_case_desc_vehicle_03_vin);
            htInsertCase.Add("@c_case_desc_licence_03_number", miris.c_case_desc_licence_03_number);
            htInsertCase.Add("@c_case_desc_vehicle_03_make", miris.c_case_desc_vehicle_03_make);
            htInsertCase.Add("@c_case_desc_vehicle_03_model", miris.c_case_desc_vehicle_03_model);
            htInsertCase.Add("@c_case_desc_vehicle_03_type_fk", miris.c_case_desc_vehicle_03_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_03_year", miris.c_case_desc_vehicle_03_year);
            htInsertCase.Add("@c_case_desc_vehicle_03_state", miris.c_case_desc_vehicle_03_state);

            htInsertCase.Add("@c_case_desc_vehicle_04_fk", miris.c_case_desc_vehicle_04_fk);
            htInsertCase.Add("@c_case_desc_vehicle_04_id", miris.c_case_desc_vehicle_04_id);
            htInsertCase.Add("@c_case_desc_vehicle_04_vin", miris.c_case_desc_vehicle_04_vin);
            htInsertCase.Add("@c_case_desc_licence_04_number", miris.c_case_desc_licence_04_number);
            htInsertCase.Add("@c_case_desc_vehicle_04_make", miris.c_case_desc_vehicle_04_make);
            htInsertCase.Add("@c_case_desc_vehicle_04_model", miris.c_case_desc_vehicle_04_model);
            htInsertCase.Add("@c_case_desc_vehicle_04_type_fk", miris.c_case_desc_vehicle_04_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_04_year", miris.c_case_desc_vehicle_04_year);
            htInsertCase.Add("@c_case_desc_vehicle_04_state", miris.c_case_desc_vehicle_04_state);

            htInsertCase.Add("@c_case_desc_vehicle_05_fk", miris.c_case_desc_vehicle_05_fk);
            htInsertCase.Add("@c_case_desc_vehicle_05_id", miris.c_case_desc_vehicle_05_id);
            htInsertCase.Add("@c_case_desc_vehicle_05_vin", miris.c_case_desc_vehicle_05_vin);
            htInsertCase.Add("@c_case_desc_licence_05_number", miris.c_case_desc_licence_05_number);
            htInsertCase.Add("@c_case_desc_vehicle_05_make", miris.c_case_desc_vehicle_05_make);
            htInsertCase.Add("@c_case_desc_vehicle_05_model", miris.c_case_desc_vehicle_05_model);
            htInsertCase.Add("@c_case_desc_vehicle_05_type_fk", miris.c_case_desc_vehicle_05_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_05_year", miris.c_case_desc_vehicle_05_year);
            htInsertCase.Add("@c_case_desc_vehicle_05_state", miris.c_case_desc_vehicle_05_state);

            htInsertCase.Add("@c_case_desc_vehicle_06_fk", miris.c_case_desc_vehicle_06_fk);
            htInsertCase.Add("@c_case_desc_vehicle_06_id", miris.c_case_desc_vehicle_06_id);
            htInsertCase.Add("@c_case_desc_vehicle_06_vin", miris.c_case_desc_vehicle_06_vin);
            htInsertCase.Add("@c_case_desc_licence_06_number", miris.c_case_desc_licence_06_number);
            htInsertCase.Add("@c_case_desc_vehicle_06_make", miris.c_case_desc_vehicle_06_make);
            htInsertCase.Add("@c_case_desc_vehicle_06_model", miris.c_case_desc_vehicle_06_model);
            htInsertCase.Add("@c_case_desc_vehicle_06_type_fk", miris.c_case_desc_vehicle_06_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_06_year", miris.c_case_desc_vehicle_06_year);
            htInsertCase.Add("@c_case_desc_vehicle_06_state", miris.c_case_desc_vehicle_06_state);

            htInsertCase.Add("@c_case_desc_vehicle_07_fk", miris.c_case_desc_vehicle_07_fk);
            htInsertCase.Add("@c_case_desc_vehicle_07_id", miris.c_case_desc_vehicle_07_id);
            htInsertCase.Add("@c_case_desc_vehicle_07_vin", miris.c_case_desc_vehicle_07_vin);
            htInsertCase.Add("@c_case_desc_licence_07_number", miris.c_case_desc_licence_07_number);
            htInsertCase.Add("@c_case_desc_vehicle_07_make", miris.c_case_desc_vehicle_07_make);
            htInsertCase.Add("@c_case_desc_vehicle_07_model", miris.c_case_desc_vehicle_07_model);
            htInsertCase.Add("@c_case_desc_vehicle_07_type_fk", miris.c_case_desc_vehicle_07_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_07_year", miris.c_case_desc_vehicle_07_year);
            htInsertCase.Add("@c_case_desc_vehicle_07_state", miris.c_case_desc_vehicle_07_state);

            htInsertCase.Add("@c_case_desc_vehicle_08_fk", miris.c_case_desc_vehicle_08_fk);
            htInsertCase.Add("@c_case_desc_vehicle_08_id", miris.c_case_desc_vehicle_08_id);
            htInsertCase.Add("@c_case_desc_vehicle_08_vin", miris.c_case_desc_vehicle_08_vin);
            htInsertCase.Add("@c_case_desc_licence_08_number", miris.c_case_desc_licence_08_number);
            htInsertCase.Add("@c_case_desc_vehicle_08_make", miris.c_case_desc_vehicle_08_make);
            htInsertCase.Add("@c_case_desc_vehicle_08_model", miris.c_case_desc_vehicle_08_model);
            htInsertCase.Add("@c_case_desc_vehicle_08_type_fk", miris.c_case_desc_vehicle_08_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_08_year", miris.c_case_desc_vehicle_08_year);
            htInsertCase.Add("@c_case_desc_vehicle_08_state", miris.c_case_desc_vehicle_08_state);

            htInsertCase.Add("@c_case_desc_vehicle_09_fk", miris.c_case_desc_vehicle_09_fk);
            htInsertCase.Add("@c_case_desc_vehicle_09_id", miris.c_case_desc_vehicle_09_id);
            htInsertCase.Add("@c_case_desc_vehicle_09_vin", miris.c_case_desc_vehicle_09_vin);
            htInsertCase.Add("@c_case_desc_licence_09_number", miris.c_case_desc_licence_09_number);
            htInsertCase.Add("@c_case_desc_vehicle_09_make", miris.c_case_desc_vehicle_09_make);
            htInsertCase.Add("@c_case_desc_vehicle_09_model", miris.c_case_desc_vehicle_09_model);
            htInsertCase.Add("@c_case_desc_vehicle_09_type_fk", miris.c_case_desc_vehicle_09_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_09_year", miris.c_case_desc_vehicle_09_year);
            htInsertCase.Add("@c_case_desc_vehicle_09_state", miris.c_case_desc_vehicle_09_state);

            htInsertCase.Add("@c_case_desc_vehicle_10_fk", miris.c_case_desc_vehicle_10_fk);
            htInsertCase.Add("@c_case_desc_vehicle_10_id", miris.c_case_desc_vehicle_10_id);
            htInsertCase.Add("@c_case_desc_vehicle_10_vin", miris.c_case_desc_vehicle_10_vin);
            htInsertCase.Add("@c_case_desc_licence_10_number", miris.c_case_desc_licence_10_number);
            htInsertCase.Add("@c_case_desc_vehicle_10_make", miris.c_case_desc_vehicle_10_make);
            htInsertCase.Add("@c_case_desc_vehicle_10_model", miris.c_case_desc_vehicle_10_model);
            htInsertCase.Add("@c_case_desc_vehicle_10_type_fk", miris.c_case_desc_vehicle_10_type_fk);
            htInsertCase.Add("@c_case_desc_vehicle_10_year", miris.c_case_desc_vehicle_10_year);
            htInsertCase.Add("@c_case_desc_vehicle_10_state", miris.c_case_desc_vehicle_10_state);

            htInsertCase.Add("@c_case_desc_company_vehicle_struck_fk", miris.c_case_desc_company_vehicle_struck_fk);
            htInsertCase.Add("@c_case_desc_company_vehicle_struck_by_fk", miris.c_case_desc_company_vehicle_struck_by_fk);
            htInsertCase.Add("@c_case_desc_non_collision", miris.c_case_desc_non_collision);
            htInsertCase.Add("@c_case_desc_non_collision_text", miris.c_case_desc_non_collision_text);

            htInsertCase.Add("@c_case_detail_drivers_lic", miris.c_case_detail_drivers_lic);
            htInsertCase.Add("@c_case_detail_state_and_class", miris.c_case_detail_state_and_class);
            if (miris.c_case_detail_expire_date != null)
            {
                htInsertCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
            }
            else
            {
                htInsertCase.Add("@c_case_detail_expire_date", DBNull.Value);
            }

            //htInsertCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
            htInsertCase.Add("@c_case_detail_address", miris.c_case_detail_address);
            htInsertCase.Add("@c_case_detail_city", miris.c_case_detail_city);
            htInsertCase.Add("@c_case_detail_state", miris.c_case_detail_state);
            htInsertCase.Add("@c_case_detail_nearest_cross_street", miris.c_case_detail_nearest_cross_street);
            htInsertCase.Add("@c_case_detail_type_of_roadway", miris.c_case_detail_type_of_roadway);
            htInsertCase.Add("@c_case_detail_road_condition_fk", miris.c_case_detail_road_condition_fk);
            if (miris.c_case_detail_time_of_day != null)
            {
                htInsertCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
            }
            else
            {
                htInsertCase.Add("@c_case_detail_time_of_day", DBNull.Value);
            }

            //htInsertCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
            // here we need to add one column
            htInsertCase.Add("@c_case_detail_weather_fk", miris.c_case_detail_weather_fk);
            htInsertCase.Add("@c_case_detail_traffic_condition_fk", miris.c_case_detail_traffic_condition_fk);
            htInsertCase.Add("@c_case_detail_traffic_controls_fk", miris.c_case_detail_traffic_controls_fk);
            htInsertCase.Add("@c_case_detail_oprating_speed", miris.c_case_detail_oprating_speed);    //d
            htInsertCase.Add("@c_case_detail_speed_limit", miris.c_case_detail_speed_limit);      //doubt
            htInsertCase.Add("@c_case_detail_vehicle_struck_fk", miris.c_case_detail_vehicle_struck_fk);
            htInsertCase.Add("@c_case_detail_vehicle_struck_by_fk", miris.c_case_detail_vehicle_struck_by_fk);
            htInsertCase.Add("@c_case_detail_collision_type_fk", miris.c_case_detail_collision_type_fk);
            htInsertCase.Add("@c_case_detail_collision_location_fk", miris.c_case_detail_collision_location_fk);
            htInsertCase.Add("@c_case_detail_collision_direction_fk", miris.c_case_detail_collision_direction_fk);
            htInsertCase.Add("@c_case_detail_non_collision_type_fk", miris.c_case_detail_non_collision_type_fk);
            htInsertCase.Add("@c_case_detail_number_of_vehicle_involved", miris.c_case_detail_number_of_vehicle_involved);
            htInsertCase.Add("@c_case_detail_number_of_vehicle_towed", miris.c_case_detail_number_of_vehicle_towed);
            htInsertCase.Add("@c_case_detail_number_of_people_injured", miris.c_case_detail_number_of_people_injured);
            htInsertCase.Add("@c_case_detail_number_of_people_killed", miris.c_case_detail_number_of_people_killed);
            htInsertCase.Add("@c_case_detail_cituation_issued", miris.c_case_detail_cituation_issued);
            htInsertCase.Add("@c_case_detail_at_whom", miris.c_case_detail_at_whom);
            htInsertCase.Add("@c_case_detail_at_fault", miris.c_case_detail_at_fault);
            htInsertCase.Add("@c_case_detail_contributory", miris.c_case_detail_contributory);
            htInsertCase.Add("@c_case_detail_gross_vehicle_weight", miris.c_case_detail_gross_vehicle_weight);
            htInsertCase.Add("@c_case_detail_combined_gross_vehicle_weight", miris.c_case_detail_combined_gross_vehicle_weight);
            htInsertCase.Add("@c_case_detail_dot_vehicle", miris.c_case_detail_dot_vehicle);
            htInsertCase.Add("@c_case_detail_dot_driver", miris.c_case_detail_dot_driver);
            htInsertCase.Add("@c_case_detail_seat_belt_used", miris.c_case_detail_seat_belt_used);
            htInsertCase.Add("@c_case_detail_air_bag_eqiupped", miris.c_case_detail_air_bag_eqiupped);
            htInsertCase.Add("@c_case_detail_air_bag_deployed", miris.c_case_detail_air_bag_deployed);
            htInsertCase.Add("@c_case_detail_cellphone_in_use", miris.c_case_detail_cellphone_in_use);
            htInsertCase.Add("@c_case_detail_computer_in_use", miris.c_case_detail_computer_in_use);
            htInsertCase.Add("@c_case_detail_special_equipment", miris.c_case_detail_special_equipment);
            htInsertCase.Add("@c_case_detail_special_equipment_text", miris.c_case_detail_special_equipment_text);
            htInsertCase.Add("@c_case_detail_location_of_impact_fk", miris.c_case_detail_location_of_impact_fk);
            htInsertCase.Add("@c_case_detail_driver_injured", miris.c_case_detail_driver_injured);//-- need to add some fields
            htInsertCase.Add("@c_case_detail_passenger_injured", miris.c_case_detail_passenger_injured); //-- need to add some fields
            htInsertCase.Add("@c_case_detail_damage_heavy", miris.c_case_detail_damage_heavy);
            htInsertCase.Add("@c_case_detail_damage_moderate", miris.c_case_detail_damage_moderate);
            htInsertCase.Add("@c_case_detail_damage_light", miris.c_case_detail_damage_light);

            htInsertCase.Add("@c_case_desc_was_fatality", miris.c_case_desc_was_fatality);
            htInsertCase.Add("@c_case_desc_public_vehicle_involved", miris.c_case_desc_public_vehicle_involved);


            htInsertCase.Add("@c_pub_vehicle_driver_name", miris.c_pub_vehicle_driver_name);
            htInsertCase.Add("@c_pub_vehicle_driver_address", miris.c_pub_vehicle_driver_address);
            htInsertCase.Add("@c_pub_vehicle_driver_contact", miris.c_pub_vehicle_driver_contact);
            htInsertCase.Add("@c_pub_vehicle_owner_name", miris.c_pub_vehicle_owner_name);
            htInsertCase.Add("@c_pub_vehicle_owner_address", miris.c_pub_vehicle_owner_address);
            htInsertCase.Add("@c_pub_vehicle_owner_contact", miris.c_pub_vehicle_owner_contact);
            htInsertCase.Add("@c_pub_vehicle_vehicle_id", miris.c_pub_vehicle_vehicle_id);
            htInsertCase.Add("@c_pub_vehicle_vehicle_vin", miris.c_pub_vehicle_vehicle_vin);
            htInsertCase.Add("@c_pub_vehicle_licence_number", miris.c_pub_vehicle_licence_number);
            htInsertCase.Add("@c_pub_vehicle_vehicle_make", miris.c_pub_vehicle_vehicle_make);
            htInsertCase.Add("@c_pub_vehicle_vehicle_model", miris.c_pub_vehicle_vehicle_model);
            htInsertCase.Add("@c_pub_vehicle_vehicle_type_fk", miris.c_pub_vehicle_vehicle_type_fk);
            htInsertCase.Add("@c_pub_vehicle_year", miris.c_pub_vehicle_year);
            htInsertCase.Add("@c_pub_vehicle_state", miris.c_pub_vehicle_state);
            htInsertCase.Add("@c_pub_vehicle_gross_vehicle_weight", miris.c_pub_vehicle_gross_vehicle_weight);
            htInsertCase.Add("@c_pub_vehicle_combined_gross_vehicle_weight", miris.c_pub_vehicle_combined_gross_vehicle_weight);
            htInsertCase.Add("@c_pub_vehicle_dot_vehicle", miris.c_pub_vehicle_dot_vehicle);
            htInsertCase.Add("@c_pub_vehicle_dot_driver", miris.c_pub_vehicle_dot_driver);
            htInsertCase.Add("@c_pub_vehicle_seat_belt_used", miris.c_pub_vehicle_seat_belt_used);
            htInsertCase.Add("@c_pub_vehicle_air_bag_eqiupped", miris.c_pub_vehicle_air_bag_eqiupped);
            htInsertCase.Add("@c_pub_vehicle_air_bag_deployed", miris.c_pub_vehicle_air_bag_deployed);
            htInsertCase.Add("@c_pub_vehicle_cellphone_in_use", miris.c_pub_vehicle_cellphone_in_use);
            htInsertCase.Add("@c_pub_vehicle_computer_in_use", miris.c_pub_vehicle_computer_in_use);
            htInsertCase.Add("@c_pub_vehicle_special_equipment", miris.c_pub_vehicle_special_equipment);
            htInsertCase.Add("@c_pub_vehicle_special_equipment_text", miris.c_pub_vehicle_special_equipment_text);
            htInsertCase.Add("@c_pub_vehicle_location_of_impact_fk", miris.c_pub_vehicle_location_of_impact_fk);
            htInsertCase.Add("@c_pub_vehicle_driver_injured", miris.c_pub_vehicle_driver_injured);// need to add some fields
            htInsertCase.Add("@c_pub_vehicle_passenger_injured", miris.c_pub_vehicle_passenger_injured); // need to add some fields
            htInsertCase.Add("@c_pub_vehicle_driver_injured_text", miris.c_pub_vehicle_driver_injured_text);
            htInsertCase.Add("@c_pub_vehicle_passenger_injured_text", miris.c_pub_vehicle_passenger_injured_text);
            htInsertCase.Add("@c_pub_vehicle_number_of_total_vehicle_injured", miris.c_pub_vehicle_number_of_total_vehicle_injured);
            htInsertCase.Add("@c_pub_vehicle_damage_heavy", miris.c_pub_vehicle_damage_heavy);
            htInsertCase.Add("@c_pub_vehicle_damage_moderate", miris.c_pub_vehicle_damage_moderate);
            htInsertCase.Add("@c_pub_vehicle_damage_light", miris.c_pub_vehicle_damage_light);
            //Pedestrain Incident
            htInsertCase.Add("@c_pedestrain_name", miris.c_pedestrain_name);
            htInsertCase.Add("@c_pedestrain_address", miris.c_pedestrain_address);
            htInsertCase.Add("@c_pedestrain_phone", miris.c_pedestrain_phone);
            htInsertCase.Add("@c_pedestrain_sex", miris.c_pedestrain_sex);
            htInsertCase.Add("@c_pedestrain_age", miris.c_pedestrain_age);
            htInsertCase.Add("@c_pedestrain_collision_type_fk", miris.c_pedestrain_collision_type_fk);
            htInsertCase.Add("@c_pedestrain_description", miris.c_pedestrain_description);
            //BICycle Incident
            htInsertCase.Add("@c_bicycle_person_name", miris.c_bicycle_person_name);
            htInsertCase.Add("@c_bicycle_person_address", miris.c_bicycle_person_address);
            htInsertCase.Add("@c_bicycle_person_phone", miris.c_bicycle_person_phone);
            htInsertCase.Add("@c_bicycle_person_sex", miris.c_bicycle_person_sex);
            htInsertCase.Add("@c_bicycle_person_age", miris.c_bicycle_person_age);
            htInsertCase.Add("@c_bicycle_person_collision_type_fk", miris.c_bicycle_person_collision_type_fk);
            htInsertCase.Add("@c_bicycle_person_description", miris.c_bicycle_person_description);
            //Animal Incident
            htInsertCase.Add("@c_animal_name", miris.c_animal_name);
            htInsertCase.Add("@c_animal_place", miris.c_animal_place);
            htInsertCase.Add("@c_animal_collision_type_fk", miris.c_animal_collision_type_fk);
            htInsertCase.Add("@c_animal_description", miris.c_animal_description);
            //Fixed Object Incident
            htInsertCase.Add("@c_fixed_object_property_name", miris.c_fixed_object_property_name);
            htInsertCase.Add("@c_fixed_object_address", miris.c_fixed_object_address);
            htInsertCase.Add("@c_fixed_object_contact_info", miris.c_fixed_object_contact_info);
            htInsertCase.Add("@c_fixed_object_collision_type_fk", miris.c_fixed_object_collision_type_fk);
            htInsertCase.Add("@c_fixed_object_description", miris.c_fixed_object_description);
            htInsertCase.Add("@c_fixed_object_property_description", miris.c_fixed_object_property_description);

            //Witness
            if (!string.IsNullOrEmpty(miris.c_miris_witness))
            {
                htInsertCase.Add("@c_miris_witness", miris.c_miris_witness);
            }
            else
            {
                htInsertCase.Add("@c_miris_witness", DBNull.Value);
            }
            //photo
            if (!string.IsNullOrEmpty(miris.c_miris_photo))
            {
                htInsertCase.Add("@c_miris_photo", miris.c_miris_photo);
            }
            else
            {
                htInsertCase.Add("@c_miris_photo", DBNull.Value);
            }
            //police report
            if (!string.IsNullOrEmpty(miris.c_miris_police_report))
            {
                htInsertCase.Add("@c_miris_police_report", miris.c_miris_police_report);
            }
            else
            {
                htInsertCase.Add("@c_miris_police_report", DBNull.Value);
            }
            //scene sketch
            if (!string.IsNullOrEmpty(miris.c_miris_scene_sketch))
            {
                htInsertCase.Add("@c_miris_scene_sketch", miris.c_miris_scene_sketch);
            }
            else
            {
                htInsertCase.Add("@c_miris_scene_sketch", DBNull.Value);
            }
            //extenuating condition
            if (!string.IsNullOrEmpty(miris.c_miris_extenuating_condition))
            {
                htInsertCase.Add("@c_miris_extenuating_condition", miris.c_miris_extenuating_condition);
            }
            else
            {
                htInsertCase.Add("@c_miris_extenuating_condition", DBNull.Value);
            }
            //employee interview
            if (!string.IsNullOrEmpty(miris.c_miris_employee_interview))
            {
                htInsertCase.Add("@c_miris_employee_interview", miris.c_miris_employee_interview);
            }
            else
            {
                htInsertCase.Add("@c_miris_employee_interview", DBNull.Value);
            }
            try
            {
                DataProxy.FetchSPOutput("c_miris_sp_insert_case_mv", htInsertCase);
                return UpdateCaseType(miris.c_case_id_pk, miris.c_case_type_fk);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static ComplianceDAO GetCaseMV(string caseId)
        {
            ComplianceDAO miris;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCase = new Hashtable();
                htGetCase.Add("@c_case_id_pk", caseId);
                miris = new ComplianceDAO();
                DataTable dtGetCase = DataProxy.FetchDataTable("c_miris_get_case_mv", htGetCase);

                miris.c_case_number = dtGetCase.Rows[0]["c_case_number"].ToString();
                miris.c_case_title = dtGetCase.Rows[0]["c_case_title"].ToString();
                miris.c_case_category_fk = dtGetCase.Rows[0]["c_case_category_fk"].ToString();
                miris.c_case_type_fk = GetCaseTypes(caseId); //dtGetCase.Rows[0]["c_case_type_fk"].ToString();
                miris.c_case_status = dtGetCase.Rows[0]["c_case_status"].ToString();
                miris.c_employee_name = dtGetCase.Rows[0]["c_employee_name"].ToString();
                miris.c_employee_last_name = dtGetCase.Rows[0]["c_employee_last_name"].ToString();
                if (dtGetCase.Rows[0]["c_date_in_title"] == null || string.IsNullOrEmpty(dtGetCase.Rows[0]["c_date_in_title"].ToString()))
                {
                    miris.c_date_in_title = null;
                }
                else
                {
                    miris.c_date_in_title = Convert.ToDateTime(dtGetCase.Rows[0]["c_date_in_title"], culture);
                }
                miris.c_case_category_value = dtGetCase.Rows[0]["c_case_category_value"].ToString();
                miris.c_case_status_value = dtGetCase.Rows[0]["c_case_status_value"].ToString();
                miris.c_case_type_value = dtGetCase.Rows[0]["c_case_type_value"].ToString();
                miris.c_osha_300_type_of_illness_value = dtGetCase.Rows[0]["c_osha_300_type_of_illness_value"].ToString();
                miris.c_osha_300_case_outcome_value = dtGetCase.Rows[0]["c_osha_300_case_outcome_value"].ToString();

                miris.c_establishment = dtGetCase.Rows[0]["c_establishment"].ToString();

                miris.c_employee_dob = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_dob"], culture);
                miris.c_employee_hire_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_employee_hire_date"], culture);
                miris.c_employee_id = dtGetCase.Rows[0]["c_employee_id"].ToString();
                miris.c_ssn = dtGetCase.Rows[0]["c_ssn"].ToString();
                miris.c_supervisor = dtGetCase.Rows[0]["c_supervisor"].ToString();
                miris.c_incident_location = dtGetCase.Rows[0]["c_incident_location"].ToString();
                miris.c_incident_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_date"], culture);
                miris.incident_HH = Convert.ToInt32(dtGetCase.Rows[0]["incident_HH"].ToString());
                miris.incident_MM = Convert.ToInt32(dtGetCase.Rows[0]["incident_MM"].ToString());
                miris.c_incident_time = Convert.ToDateTime(dtGetCase.Rows[0]["c_incident_time"], culture);
                miris.c_employee_report_location = dtGetCase.Rows[0]["c_employee_report_location"].ToString();
                miris.c_note = dtGetCase.Rows[0]["c_note"].ToString();
                miris.c_root_cause_analysic_info = dtGetCase.Rows[0]["c_root_cause_analysic_info"].ToString();
                miris.c_corrective_action_info = dtGetCase.Rows[0]["c_corrective_action_info"].ToString();
                miris.c_custom_01 = dtGetCase.Rows[0]["c_custom_01"].ToString();
                miris.c_custom_02 = dtGetCase.Rows[0]["c_custom_02"].ToString();
                miris.c_custom_03 = dtGetCase.Rows[0]["c_custom_03"].ToString();
                miris.c_custom_04 = dtGetCase.Rows[0]["c_custom_04"].ToString();
                miris.c_custom_05 = dtGetCase.Rows[0]["c_custom_05"].ToString();
                miris.c_custom_06 = dtGetCase.Rows[0]["c_custom_06"].ToString();
                miris.c_custom_07 = dtGetCase.Rows[0]["c_custom_07"].ToString();
                miris.c_custom_08 = dtGetCase.Rows[0]["c_custom_08"].ToString();
                miris.c_custom_09 = dtGetCase.Rows[0]["c_custom_09"].ToString();
                miris.c_custom_10 = dtGetCase.Rows[0]["c_custom_10"].ToString();
                miris.c_custom_11 = dtGetCase.Rows[0]["c_custom_11"].ToString();
                miris.c_custom_12 = dtGetCase.Rows[0]["c_custom_12"].ToString();
                miris.c_custom_13 = dtGetCase.Rows[0]["c_custom_13"].ToString();

                miris.c_case_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_date"], culture);

                miris.c_case_type_text = dtGetCase.Rows[0]["c_case_type_text"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(dtGetCase.Rows[0]["c_company_owned"])))
                {
                    miris.c_company_owned = Convert.ToBoolean(dtGetCase.Rows[0]["c_company_owned"]);
                }

                miris.c_status_text = dtGetCase.Rows[0]["c_status_text"].ToString();

                miris.c_timezoneId = dtGetCase.Rows[0]["c_timezone_id_fk"].ToString();
                miris.c_case_category_text = dtGetCase.Rows[0]["c_case_category_text"].ToString();

                miris.incident_HH_text = dtGetCase.Rows[0]["incident_HH_text"].ToString();
                miris.c_note_text = dtGetCase.Rows[0]["c_note_text"].ToString();

                miris.u_time_zone_location = dtGetCase.Rows[0]["u_time_zone_location"].ToString();

                miris.c_case_desc_vehicle_01_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_01_fk"].ToString();
                miris.c_case_desc_vehicle_02_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_02_fk"].ToString();

                miris.c_case_desc_vehicle_id = dtGetCase.Rows[0]["c_case_desc_vehicle_id"].ToString();
                miris.c_case_desc_vehicle_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_vin"].ToString();
                miris.c_case_desc_licence_number = dtGetCase.Rows[0]["c_case_desc_licence_number"].ToString();
                miris.c_case_desc_vehicle_make = dtGetCase.Rows[0]["c_case_desc_vehicle_make"].ToString();
                miris.c_case_desc_vehicle_model = dtGetCase.Rows[0]["c_case_desc_vehicle_model"].ToString();
                miris.c_case_desc_vehicle_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_type_fk"].ToString();
                miris.c_case_desc_year = dtGetCase.Rows[0]["c_case_desc_year"].ToString();
                miris.c_case_desc_state = dtGetCase.Rows[0]["c_case_desc_state"].ToString();

                miris.c_case_desc_vehicle_02_id = dtGetCase.Rows[0]["c_case_desc_vehicle_02_id"].ToString();
                miris.c_case_desc_vehicle_02_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_02_vin"].ToString();
                miris.c_case_desc_licence_02_number = dtGetCase.Rows[0]["c_case_desc_licence_02_number"].ToString();
                miris.c_case_desc_vehicle_02_make = dtGetCase.Rows[0]["c_case_desc_vehicle_02_make"].ToString();
                miris.c_case_desc_vehicle_02_model = dtGetCase.Rows[0]["c_case_desc_vehicle_02_model"].ToString();
                miris.c_case_desc_vehicle_02_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_02_type_fk"].ToString();
                miris.c_case_desc_vehicle_02_year = dtGetCase.Rows[0]["c_case_desc_vehicle_02_year"].ToString();
                miris.c_case_desc_vehicle_02_state = dtGetCase.Rows[0]["c_case_desc_vehicle_02_state"].ToString();


                miris.c_case_desc_vehicle_03_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_03_fk"].ToString();
                miris.c_case_desc_vehicle_03_id = dtGetCase.Rows[0]["c_case_desc_vehicle_03_id"].ToString();
                miris.c_case_desc_vehicle_03_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_03_vin"].ToString();
                miris.c_case_desc_licence_03_number = dtGetCase.Rows[0]["c_case_desc_licence_03_number"].ToString();
                miris.c_case_desc_vehicle_03_make = dtGetCase.Rows[0]["c_case_desc_vehicle_03_make"].ToString();
                miris.c_case_desc_vehicle_03_model = dtGetCase.Rows[0]["c_case_desc_vehicle_03_model"].ToString();
                miris.c_case_desc_vehicle_03_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_03_type_fk"].ToString();
                miris.c_case_desc_vehicle_03_year = dtGetCase.Rows[0]["c_case_desc_vehicle_03_year"].ToString();
                miris.c_case_desc_vehicle_03_state = dtGetCase.Rows[0]["c_case_desc_vehicle_03_state"].ToString();

                miris.c_case_desc_vehicle_04_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_04_fk"].ToString();
                miris.c_case_desc_vehicle_04_id = dtGetCase.Rows[0]["c_case_desc_vehicle_04_id"].ToString();
                miris.c_case_desc_vehicle_04_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_04_vin"].ToString();
                miris.c_case_desc_licence_04_number = dtGetCase.Rows[0]["c_case_desc_licence_04_number"].ToString();
                miris.c_case_desc_vehicle_04_make = dtGetCase.Rows[0]["c_case_desc_vehicle_04_make"].ToString();
                miris.c_case_desc_vehicle_04_model = dtGetCase.Rows[0]["c_case_desc_vehicle_04_model"].ToString();
                miris.c_case_desc_vehicle_04_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_04_type_fk"].ToString();
                miris.c_case_desc_vehicle_04_year = dtGetCase.Rows[0]["c_case_desc_vehicle_04_year"].ToString();
                miris.c_case_desc_vehicle_04_state = dtGetCase.Rows[0]["c_case_desc_vehicle_04_state"].ToString();


                miris.c_case_desc_vehicle_05_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_05_fk"].ToString();
                miris.c_case_desc_vehicle_05_id = dtGetCase.Rows[0]["c_case_desc_vehicle_05_id"].ToString();
                miris.c_case_desc_vehicle_05_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_05_vin"].ToString();
                miris.c_case_desc_licence_05_number = dtGetCase.Rows[0]["c_case_desc_licence_05_number"].ToString();
                miris.c_case_desc_vehicle_05_make = dtGetCase.Rows[0]["c_case_desc_vehicle_05_make"].ToString();
                miris.c_case_desc_vehicle_05_model = dtGetCase.Rows[0]["c_case_desc_vehicle_05_model"].ToString();
                miris.c_case_desc_vehicle_05_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_05_type_fk"].ToString();
                miris.c_case_desc_vehicle_05_year = dtGetCase.Rows[0]["c_case_desc_vehicle_05_year"].ToString();
                miris.c_case_desc_vehicle_05_state = dtGetCase.Rows[0]["c_case_desc_vehicle_05_state"].ToString();

                miris.c_case_desc_vehicle_06_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_06_fk"].ToString();
                miris.c_case_desc_vehicle_06_id = dtGetCase.Rows[0]["c_case_desc_vehicle_06_id"].ToString();
                miris.c_case_desc_vehicle_06_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_06_vin"].ToString();
                miris.c_case_desc_licence_06_number = dtGetCase.Rows[0]["c_case_desc_licence_06_number"].ToString();
                miris.c_case_desc_vehicle_06_make = dtGetCase.Rows[0]["c_case_desc_vehicle_06_make"].ToString();
                miris.c_case_desc_vehicle_06_model = dtGetCase.Rows[0]["c_case_desc_vehicle_06_model"].ToString();
                miris.c_case_desc_vehicle_06_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_06_type_fk"].ToString();
                miris.c_case_desc_vehicle_06_year = dtGetCase.Rows[0]["c_case_desc_vehicle_06_year"].ToString();
                miris.c_case_desc_vehicle_06_state = dtGetCase.Rows[0]["c_case_desc_vehicle_06_state"].ToString();

                miris.c_case_desc_vehicle_07_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_07_fk"].ToString();
                miris.c_case_desc_vehicle_07_id = dtGetCase.Rows[0]["c_case_desc_vehicle_07_id"].ToString();
                miris.c_case_desc_vehicle_07_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_07_vin"].ToString();
                miris.c_case_desc_licence_07_number = dtGetCase.Rows[0]["c_case_desc_licence_07_number"].ToString();
                miris.c_case_desc_vehicle_07_make = dtGetCase.Rows[0]["c_case_desc_vehicle_07_make"].ToString();
                miris.c_case_desc_vehicle_07_model = dtGetCase.Rows[0]["c_case_desc_vehicle_07_model"].ToString();
                miris.c_case_desc_vehicle_07_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_07_type_fk"].ToString();
                miris.c_case_desc_vehicle_07_year = dtGetCase.Rows[0]["c_case_desc_vehicle_07_year"].ToString();
                miris.c_case_desc_vehicle_07_state = dtGetCase.Rows[0]["c_case_desc_vehicle_07_state"].ToString();


                miris.c_case_desc_vehicle_08_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_08_fk"].ToString();
                miris.c_case_desc_vehicle_08_id = dtGetCase.Rows[0]["c_case_desc_vehicle_08_id"].ToString();
                miris.c_case_desc_vehicle_08_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_08_vin"].ToString();
                miris.c_case_desc_licence_08_number = dtGetCase.Rows[0]["c_case_desc_licence_08_number"].ToString();
                miris.c_case_desc_vehicle_08_make = dtGetCase.Rows[0]["c_case_desc_vehicle_08_make"].ToString();
                miris.c_case_desc_vehicle_08_model = dtGetCase.Rows[0]["c_case_desc_vehicle_08_model"].ToString();
                miris.c_case_desc_vehicle_08_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_08_type_fk"].ToString();
                miris.c_case_desc_vehicle_08_year = dtGetCase.Rows[0]["c_case_desc_vehicle_08_year"].ToString();
                miris.c_case_desc_vehicle_08_state = dtGetCase.Rows[0]["c_case_desc_vehicle_08_state"].ToString();


                miris.c_case_desc_vehicle_09_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_09_fk"].ToString();
                miris.c_case_desc_vehicle_09_id = dtGetCase.Rows[0]["c_case_desc_vehicle_09_id"].ToString();
                miris.c_case_desc_vehicle_09_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_09_vin"].ToString();
                miris.c_case_desc_licence_09_number = dtGetCase.Rows[0]["c_case_desc_licence_09_number"].ToString();
                miris.c_case_desc_vehicle_09_make = dtGetCase.Rows[0]["c_case_desc_vehicle_09_make"].ToString();
                miris.c_case_desc_vehicle_09_model = dtGetCase.Rows[0]["c_case_desc_vehicle_09_model"].ToString();
                miris.c_case_desc_vehicle_09_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_09_type_fk"].ToString();
                miris.c_case_desc_vehicle_09_year = dtGetCase.Rows[0]["c_case_desc_vehicle_09_year"].ToString();
                miris.c_case_desc_vehicle_09_state = dtGetCase.Rows[0]["c_case_desc_vehicle_09_state"].ToString();


                miris.c_case_desc_vehicle_10_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_10_fk"].ToString();
                miris.c_case_desc_vehicle_10_id = dtGetCase.Rows[0]["c_case_desc_vehicle_10_id"].ToString();
                miris.c_case_desc_vehicle_10_vin = dtGetCase.Rows[0]["c_case_desc_vehicle_10_vin"].ToString();
                miris.c_case_desc_licence_10_number = dtGetCase.Rows[0]["c_case_desc_licence_10_number"].ToString();
                miris.c_case_desc_vehicle_10_make = dtGetCase.Rows[0]["c_case_desc_vehicle_10_make"].ToString();
                miris.c_case_desc_vehicle_10_model = dtGetCase.Rows[0]["c_case_desc_vehicle_10_model"].ToString();
                miris.c_case_desc_vehicle_10_type_fk = dtGetCase.Rows[0]["c_case_desc_vehicle_10_type_fk"].ToString();
                miris.c_case_desc_vehicle_10_year = dtGetCase.Rows[0]["c_case_desc_vehicle_10_year"].ToString();
                miris.c_case_desc_vehicle_10_state = dtGetCase.Rows[0]["c_case_desc_vehicle_10_state"].ToString();

                miris.c_case_desc_company_vehicle_struck_fk = dtGetCase.Rows[0]["c_case_desc_company_vehicle_struck_fk"].ToString();
                miris.c_case_desc_company_vehicle_struck_by_fk = dtGetCase.Rows[0]["c_case_desc_company_vehicle_struck_by_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_desc_non_collision"].ToString()))
                {
                    miris.c_case_desc_non_collision = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_desc_non_collision"]);
                }
                miris.c_case_desc_non_collision_text = dtGetCase.Rows[0]["c_case_desc_non_collision_text"].ToString();

                miris.c_case_detail_drivers_lic = dtGetCase.Rows[0]["c_case_detail_drivers_lic"].ToString();
                miris.c_case_detail_state_and_class = dtGetCase.Rows[0]["c_case_detail_state_and_class"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_expire_date"].ToString()))
                {
                    miris.c_case_detail_expire_date = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_expire_date"], culture);
                }
                // miris.c_case_detail_expire_date =Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_expire_date"]);
                miris.c_case_detail_address = dtGetCase.Rows[0]["c_case_detail_address"].ToString();
                miris.c_case_detail_city = dtGetCase.Rows[0]["c_case_detail_city"].ToString();
                miris.c_case_detail_state = dtGetCase.Rows[0]["c_case_detail_state"].ToString();
                miris.c_case_detail_nearest_cross_street = dtGetCase.Rows[0]["c_case_detail_nearest_cross_street"].ToString();
                miris.c_case_detail_type_of_roadway = dtGetCase.Rows[0]["c_case_detail_type_of_roadway"].ToString();
                miris.c_case_detail_road_condition_fk = dtGetCase.Rows[0]["c_case_detail_road_condition_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_time_of_day"].ToString()))
                {
                    miris.c_case_detail_time_of_day = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_time_of_day"], culture);
                }

                //miris.c_case_detail_time_of_day = Convert.ToDateTime(dtGetCase.Rows[0]["c_case_detail_time_of_day"]);
                // here we need to add one column
                miris.c_case_detail_weather_fk = dtGetCase.Rows[0]["c_case_detail_weather_fk"].ToString();
                miris.c_case_detail_traffic_condition_fk = dtGetCase.Rows[0]["c_case_detail_traffic_condition_fk"].ToString();
                miris.c_case_detail_traffic_controls_fk = dtGetCase.Rows[0]["c_case_detail_traffic_controls_fk"].ToString();
                miris.c_case_detail_oprating_speed = dtGetCase.Rows[0]["c_case_detail_oprating_speed"].ToString();   //doubt= dtGetCase.Rows[0]["u_time_zone_location"].ToString();
                miris.c_case_detail_speed_limit = dtGetCase.Rows[0]["c_case_detail_speed_limit"].ToString();   //doubt
                miris.c_case_detail_vehicle_struck_fk = dtGetCase.Rows[0]["c_case_detail_vehicle_struck_fk"].ToString();
                miris.c_case_detail_vehicle_struck_by_fk = dtGetCase.Rows[0]["c_case_detail_vehicle_struck_by_fk"].ToString();
                miris.c_case_detail_collision_type_fk = dtGetCase.Rows[0]["c_case_detail_collision_type_fk"].ToString();
                miris.c_case_detail_collision_location_fk = dtGetCase.Rows[0]["c_case_detail_collision_location_fk"].ToString();
                miris.c_case_detail_collision_direction_fk = dtGetCase.Rows[0]["c_case_detail_collision_direction_fk"].ToString();
                miris.c_case_detail_non_collision_type_fk = dtGetCase.Rows[0]["c_case_detail_non_collision_type_fk"].ToString();
                miris.c_case_detail_number_of_vehicle_involved = dtGetCase.Rows[0]["c_case_detail_number_of_vehicle_involved"].ToString();
                miris.c_case_detail_number_of_vehicle_towed = dtGetCase.Rows[0]["c_case_detail_number_of_vehicle_towed"].ToString();
                miris.c_case_detail_number_of_people_injured = dtGetCase.Rows[0]["c_case_detail_number_of_people_injured"].ToString();
                miris.c_case_detail_number_of_people_killed = dtGetCase.Rows[0]["c_case_detail_number_of_people_killed"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_cituation_issued"].ToString()))
                {

                    miris.c_case_detail_cituation_issued = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_cituation_issued"]);
                }
                miris.c_case_detail_at_whom = dtGetCase.Rows[0]["c_case_detail_at_whom"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_at_fault"].ToString()))
                {

                    miris.c_case_detail_at_fault = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_at_fault"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_contributory"].ToString()))
                {

                    miris.c_case_detail_contributory = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_contributory"]);
                }
                miris.c_case_detail_gross_vehicle_weight = dtGetCase.Rows[0]["c_case_detail_gross_vehicle_weight"].ToString();
                miris.c_case_detail_combined_gross_vehicle_weight = dtGetCase.Rows[0]["c_case_detail_combined_gross_vehicle_weight"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_dot_vehicle"].ToString()))
                {

                    miris.c_case_detail_dot_vehicle = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_dot_vehicle"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_dot_driver"].ToString()))
                {

                    miris.c_case_detail_dot_driver = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_dot_driver"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_seat_belt_used"].ToString()))
                {

                    miris.c_case_detail_seat_belt_used = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_seat_belt_used"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_air_bag_eqiupped"].ToString()))
                {

                    miris.c_case_detail_air_bag_eqiupped = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_air_bag_eqiupped"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_air_bag_deployed"].ToString()))
                {

                    miris.c_case_detail_air_bag_deployed = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_air_bag_deployed"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_cellphone_in_use"].ToString()))
                {

                    miris.c_case_detail_cellphone_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_cellphone_in_use"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_computer_in_use"].ToString()))
                {

                    miris.c_case_detail_computer_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_computer_in_use"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_special_equipment"].ToString()))
                {

                    miris.c_case_detail_special_equipment = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_special_equipment"]);
                }
                miris.c_case_detail_special_equipment_text = dtGetCase.Rows[0]["c_case_detail_special_equipment_text"].ToString();
                miris.c_case_detail_location_of_impact_fk = dtGetCase.Rows[0]["c_case_detail_location_of_impact_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_driver_injured"].ToString()))
                {

                    miris.c_case_detail_driver_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_driver_injured"]);// need to add some fields= dtGetCase.Rows[0]["u_time_zone_location"].ToString();
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_detail_passenger_injured"].ToString()))
                {

                    miris.c_case_detail_passenger_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_detail_passenger_injured"]); // need to add some fields
                }
                miris.c_case_detail_damage_heavy = dtGetCase.Rows[0]["c_case_detail_damage_heavy"].ToString();
                miris.c_case_detail_damage_moderate = dtGetCase.Rows[0]["c_case_detail_damage_moderate"].ToString();
                miris.c_case_detail_damage_light = dtGetCase.Rows[0]["c_case_detail_damage_light"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_desc_was_fatality"].ToString()))
                {

                    miris.c_case_desc_was_fatality = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_desc_was_fatality"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_case_desc_public_vehicle_involved"].ToString()))
                {

                    miris.c_case_desc_public_vehicle_involved = Convert.ToBoolean(dtGetCase.Rows[0]["c_case_desc_public_vehicle_involved"]);
                }


                miris.c_pub_vehicle_driver_name = dtGetCase.Rows[0]["c_pub_vehicle_driver_name"].ToString();
                miris.c_pub_vehicle_driver_address = dtGetCase.Rows[0]["c_pub_vehicle_driver_address"].ToString();
                miris.c_pub_vehicle_driver_contact = dtGetCase.Rows[0]["c_pub_vehicle_driver_contact"].ToString();
                miris.c_pub_vehicle_owner_name = dtGetCase.Rows[0]["c_pub_vehicle_owner_name"].ToString();
                miris.c_pub_vehicle_owner_address = dtGetCase.Rows[0]["c_pub_vehicle_owner_address"].ToString();
                miris.c_pub_vehicle_owner_contact = dtGetCase.Rows[0]["c_pub_vehicle_owner_contact"].ToString();
                miris.c_pub_vehicle_vehicle_id = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_id"].ToString();
                miris.c_pub_vehicle_vehicle_vin = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_vin"].ToString();
                miris.c_pub_vehicle_licence_number = dtGetCase.Rows[0]["c_pub_vehicle_licence_number"].ToString();
                miris.c_pub_vehicle_vehicle_make = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_make"].ToString();
                miris.c_pub_vehicle_vehicle_model = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_model"].ToString();
                miris.c_pub_vehicle_vehicle_type_fk = dtGetCase.Rows[0]["c_pub_vehicle_vehicle_type_fk"].ToString();
                miris.c_pub_vehicle_year = dtGetCase.Rows[0]["c_pub_vehicle_year"].ToString();
                miris.c_pub_vehicle_state = dtGetCase.Rows[0]["c_pub_vehicle_state"].ToString();
                miris.c_pub_vehicle_gross_vehicle_weight = dtGetCase.Rows[0]["c_pub_vehicle_gross_vehicle_weight"].ToString();
                miris.c_pub_vehicle_combined_gross_vehicle_weight = dtGetCase.Rows[0]["c_pub_vehicle_combined_gross_vehicle_weight"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_dot_vehicle"].ToString()))
                {

                    miris.c_pub_vehicle_dot_vehicle = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_dot_vehicle"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_dot_driver"].ToString()))
                {

                    miris.c_pub_vehicle_dot_driver = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_dot_driver"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_seat_belt_used"].ToString()))
                {

                    miris.c_pub_vehicle_seat_belt_used = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_seat_belt_used"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_eqiupped"].ToString()))
                {

                    miris.c_pub_vehicle_air_bag_eqiupped = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_eqiupped"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_deployed"].ToString()))
                {

                    miris.c_pub_vehicle_air_bag_deployed = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_air_bag_deployed"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_cellphone_in_use"].ToString()))
                {

                    miris.c_pub_vehicle_cellphone_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_cellphone_in_use"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_computer_in_use"].ToString()))
                {

                    miris.c_pub_vehicle_computer_in_use = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_computer_in_use"]);
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_special_equipment"].ToString()))
                {

                    miris.c_pub_vehicle_special_equipment = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_special_equipment"]);
                }


                miris.c_pub_vehicle_special_equipment_text = dtGetCase.Rows[0]["c_pub_vehicle_special_equipment_text"].ToString();

                miris.c_pub_vehicle_location_of_impact_fk = dtGetCase.Rows[0]["c_pub_vehicle_location_of_impact_fk"].ToString();
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_driver_injured"].ToString()))
                {

                    miris.c_pub_vehicle_driver_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_driver_injured"]);// need to add some fields
                }
                if (!string.IsNullOrEmpty(dtGetCase.Rows[0]["c_pub_vehicle_passenger_injured"].ToString()))
                {

                    miris.c_pub_vehicle_passenger_injured = Convert.ToBoolean(dtGetCase.Rows[0]["c_pub_vehicle_passenger_injured"]);// need to add some fields
                }

                miris.c_pub_vehicle_driver_injured_text = dtGetCase.Rows[0]["c_pub_vehicle_driver_injured_text"].ToString();
                miris.c_pub_vehicle_passenger_injured_text = dtGetCase.Rows[0]["c_pub_vehicle_passenger_injured_text"].ToString();


                miris.c_pub_vehicle_number_of_total_vehicle_injured = dtGetCase.Rows[0]["c_pub_vehicle_number_of_total_vehicle_injured"].ToString();
                miris.c_pub_vehicle_damage_heavy = dtGetCase.Rows[0]["c_pub_vehicle_damage_heavy"].ToString(); //doubt
                miris.c_pub_vehicle_damage_moderate = dtGetCase.Rows[0]["c_pub_vehicle_damage_moderate"].ToString();//doubt
                miris.c_pub_vehicle_damage_light = dtGetCase.Rows[0]["c_pub_vehicle_damage_light"].ToString();//doubt
                //Pedestrain Incident
                miris.c_pedestrain_name = dtGetCase.Rows[0]["c_pedestrain_name"].ToString();
                miris.c_pedestrain_address = dtGetCase.Rows[0]["c_pedestrain_address"].ToString();
                miris.c_pedestrain_phone = dtGetCase.Rows[0]["c_pedestrain_phone"].ToString();
                miris.c_pedestrain_sex = dtGetCase.Rows[0]["c_pedestrain_sex"].ToString();
                miris.c_pedestrain_age = dtGetCase.Rows[0]["c_pedestrain_age"].ToString();
                miris.c_pedestrain_collision_type_fk = dtGetCase.Rows[0]["c_pedestrain_collision_type_fk"].ToString();
                miris.c_pedestrain_description = dtGetCase.Rows[0]["c_pedestrain_description"].ToString();
                //BICycle Incident
                miris.c_bicycle_person_name = dtGetCase.Rows[0]["c_bicycle_person_name"].ToString();
                miris.c_bicycle_person_address = dtGetCase.Rows[0]["c_bicycle_person_address"].ToString();
                miris.c_bicycle_person_phone = dtGetCase.Rows[0]["c_bicycle_person_phone"].ToString();
                miris.c_bicycle_person_sex = dtGetCase.Rows[0]["c_bicycle_person_sex"].ToString();
                miris.c_bicycle_person_age = dtGetCase.Rows[0]["c_bicycle_person_age"].ToString();
                miris.c_bicycle_person_collision_type_fk = dtGetCase.Rows[0]["c_bicycle_person_collision_type_fk"].ToString();
                miris.c_bicycle_person_description = dtGetCase.Rows[0]["c_bicycle_person_description"].ToString();
                //Animal Incident
                miris.c_animal_name = dtGetCase.Rows[0]["c_animal_name"].ToString();
                miris.c_animal_place = dtGetCase.Rows[0]["c_animal_place"].ToString();
                miris.c_animal_collision_type_fk = dtGetCase.Rows[0]["c_animal_collision_type_fk"].ToString();
                miris.c_animal_description = dtGetCase.Rows[0]["c_animal_description"].ToString();
                //Fixed Object Incident
                miris.c_fixed_object_property_name = dtGetCase.Rows[0]["c_fixed_object_property_name"].ToString();
                miris.c_fixed_object_address = dtGetCase.Rows[0]["c_fixed_object_address"].ToString();
                miris.c_fixed_object_contact_info = dtGetCase.Rows[0]["c_fixed_object_contact_info"].ToString();
                miris.c_fixed_object_collision_type_fk = dtGetCase.Rows[0]["c_fixed_object_collision_type_fk"].ToString();
                miris.c_fixed_object_description = dtGetCase.Rows[0]["c_fixed_object_description"].ToString();
                miris.c_fixed_object_property_description = dtGetCase.Rows[0]["c_fixed_object_property_description"].ToString();


                return miris;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetVehicleValues(string c_case_id_pk)
        {
            try
            {
                Hashtable htGetVehicleValues = new Hashtable();
                htGetVehicleValues.Add("@c_case_id_pk", c_case_id_pk);

                return DataProxy.FetchDataTable("c_sp_get_vehicle_values", htGetVehicleValues);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetVehicleValuesForReset(string c_case_id_pk)
        {
            try
            {
                Hashtable htGetVehicleValues = new Hashtable();
                htGetVehicleValues.Add("@c_case_id_pk", c_case_id_pk);

                return DataProxy.FetchDataTable("c_sp_get_vehicle_value_for_reset", htGetVehicleValues);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetVehicleInfo(string c_case_id_pk, string vehiclexml)
        {
            try
            {
                Hashtable htResetVehicleValues = new Hashtable();
                htResetVehicleValues.Add("@c_case_id_pk", c_case_id_pk);
                htResetVehicleValues.Add("@vehiclexml", vehiclexml);

                return DataProxy.FetchSPOutput("c_sp_reset_vehicle_info", htResetVehicleValues);
            }

            catch (Exception)
            {
                throw;
            }
        }


        public static List<ComplainceVehicle> GetVehicle(string caseId, string vehicle_number)
        {
            ComplainceVehicle miris;
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCase = new Hashtable();
                htGetCase.Add("@c_case_id_pk", caseId);
                htGetCase.Add("@vehicle_number", vehicle_number);
                miris = new ComplainceVehicle();
                DataTable dtGetCase = DataProxy.FetchDataTable("c_miris_get_vehicle", htGetCase);
                List<ComplainceVehicle> vehicle = new List<ComplainceVehicle>();

                vehicle.Add(new ComplainceVehicle
                {
                    vehicle_fk = dtGetCase.Rows[0]["vehicle_fk"].ToString(),
                    vehicle_vin = dtGetCase.Rows[0]["vehicle_vin"].ToString(),
                    vehicle_id = dtGetCase.Rows[0]["vehicle_id"].ToString(),
                    vehicle_licence = dtGetCase.Rows[0]["vehicle_licence"].ToString(),
                    vehicle_make = dtGetCase.Rows[0]["vehicle_make"].ToString(),
                    vehicle_type = dtGetCase.Rows[0]["vehicle_type"].ToString(),
                    vehicle_model = dtGetCase.Rows[0]["vehicle_model"].ToString(),
                    vehicle_year = dtGetCase.Rows[0]["vehicle_year"].ToString(),
                    vehicle_state = dtGetCase.Rows[0]["vehicle_state"].ToString(),
                });

                return vehicle;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateCaseMV(ComplianceDAO miris)
        {
            Hashtable htUpdateCase = new Hashtable();
            htUpdateCase.Add("@c_case_id_pk", miris.c_case_id_pk);
            htUpdateCase.Add("@u_user_id_fk", miris.u_user_id_fk);
            htUpdateCase.Add("@c_case_number", miris.c_case_number);
            htUpdateCase.Add("@c_case_title", miris.c_case_title);
            htUpdateCase.Add("@c_case_category_fk", miris.c_case_category_fk);
            htUpdateCase.Add("@c_case_type_fk", miris.c_case_type_fk);
            htUpdateCase.Add("@c_case_status", miris.c_case_status);
            htUpdateCase.Add("@c_employee_name", miris.c_employee_name);
            htUpdateCase.Add("@c_employee_last_name", miris.c_employee_last_name);
            htUpdateCase.Add("@c_employee_dob", miris.c_employee_dob);
            htUpdateCase.Add("@c_employee_hire_date", miris.c_employee_hire_date);
            htUpdateCase.Add("@c_employee_id", miris.c_employee_id);
            htUpdateCase.Add("@c_ssn", miris.c_ssn);
            htUpdateCase.Add("@c_supervisor", miris.c_supervisor);
            htUpdateCase.Add("@c_incident_location", miris.c_incident_location);
            htUpdateCase.Add("@c_incident_date", miris.c_incident_date);
            htUpdateCase.Add("@c_incident_time", miris.c_incident_time);
            htUpdateCase.Add("@c_employee_report_location", miris.c_employee_report_location);
            htUpdateCase.Add("@c_note", miris.c_note);
            htUpdateCase.Add("@c_root_cause_analysic_info", miris.c_root_cause_analysic_info);
            htUpdateCase.Add("@c_corrective_action_info", miris.c_corrective_action_info);
            htUpdateCase.Add("@c_osha_300_case_outcome", DBNull.Value);
            htUpdateCase.Add("@c_osha_300_days_away_from_work", DBNull.Value);
            htUpdateCase.Add("@c_osha_300_days_of_restriction", DBNull.Value);

            if (miris.c_osha_300_date_of_death != null)
            {
                htUpdateCase.Add("@c_osha_300_date_of_death", miris.c_osha_300_date_of_death);
            }
            else
            {
                htUpdateCase.Add("@c_osha_300_date_of_death", DBNull.Value);
            }

            htUpdateCase.Add("@c_osha_300_type_of_illness", DBNull.Value);




            htUpdateCase.Add("@c_osha_300_info", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_worker_gender", DBNull.Value);

            if (miris.c_osha_301_work_start_time != null)
            {
                htUpdateCase.Add("@c_osha_301_work_start_time", miris.c_osha_301_work_start_time);
            }
            else
            {
                htUpdateCase.Add("@c_osha_301_work_start_time", DBNull.Value);
            }


            htUpdateCase.Add("@c_osha_301_physician", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_treatment_facilities", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_emergency_room", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_hospitalized", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address1", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address2", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_address3", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_city", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_state", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_zip", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_1", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_2", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_3", DBNull.Value);
            htUpdateCase.Add("@c_osha_301_info_4", DBNull.Value);
            htUpdateCase.Add("@c_custom_01", miris.c_custom_01);
            htUpdateCase.Add("@c_custom_02", miris.c_custom_02);
            htUpdateCase.Add("@c_custom_03", miris.c_custom_03);
            htUpdateCase.Add("@c_custom_04", miris.c_custom_04);
            htUpdateCase.Add("@c_custom_05", miris.c_custom_05);
            htUpdateCase.Add("@c_custom_06", miris.c_custom_06);
            htUpdateCase.Add("@c_custom_07", miris.c_custom_07);
            htUpdateCase.Add("@c_custom_08", miris.c_custom_08);
            htUpdateCase.Add("@c_custom_09", miris.c_custom_09);
            htUpdateCase.Add("@c_custom_10", miris.c_custom_10);
            htUpdateCase.Add("@c_custom_11", miris.c_custom_11);
            htUpdateCase.Add("@c_custom_12", miris.c_custom_12);
            htUpdateCase.Add("@c_custom_13", miris.c_custom_13);
            htUpdateCase.Add("@c_timezone_id_fk", miris.c_timezoneId);

            htUpdateCase.Add("@c_company_owned", miris.c_company_owned);


            htUpdateCase.Add("@c_case_desc_vehicle_01_fk", miris.c_case_desc_vehicle_01_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_02_fk", miris.c_case_desc_vehicle_02_fk);

            htUpdateCase.Add("@c_case_desc_vehicle_id", miris.c_case_desc_vehicle_id);
            htUpdateCase.Add("@c_case_desc_vehicle_vin", miris.c_case_desc_vehicle_vin);
            htUpdateCase.Add("@c_case_desc_licence_number", miris.c_case_desc_licence_number);
            htUpdateCase.Add("@c_case_desc_vehicle_make", miris.c_case_desc_vehicle_make);
            htUpdateCase.Add("@c_case_desc_vehicle_model", miris.c_case_desc_vehicle_model);
            htUpdateCase.Add("@c_case_desc_vehicle_type_fk", miris.c_case_desc_vehicle_type_fk);
            htUpdateCase.Add("@c_case_desc_year", miris.c_case_desc_year);
            htUpdateCase.Add("@c_case_desc_state", miris.c_case_desc_state);

            htUpdateCase.Add("@c_case_desc_vehicle_02_id", miris.c_case_desc_vehicle_02_id);
            htUpdateCase.Add("@c_case_desc_vehicle_02_vin", miris.c_case_desc_vehicle_02_vin);
            htUpdateCase.Add("@c_case_desc_licence_02_number", miris.c_case_desc_licence_02_number);
            htUpdateCase.Add("@c_case_desc_vehicle_02_make", miris.c_case_desc_vehicle_02_make);
            htUpdateCase.Add("@c_case_desc_vehicle_02_model", miris.c_case_desc_vehicle_02_model);
            htUpdateCase.Add("@c_case_desc_vehicle_02_type_fk", miris.c_case_desc_vehicle_02_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_02_year", miris.c_case_desc_vehicle_02_year);
            htUpdateCase.Add("@c_case_desc_vehicle_02_state", miris.c_case_desc_vehicle_02_state);

            htUpdateCase.Add("@c_case_desc_vehicle_03_fk", miris.c_case_desc_vehicle_03_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_03_id", miris.c_case_desc_vehicle_03_id);
            htUpdateCase.Add("@c_case_desc_vehicle_03_vin", miris.c_case_desc_vehicle_03_vin);
            htUpdateCase.Add("@c_case_desc_licence_03_number", miris.c_case_desc_licence_03_number);
            htUpdateCase.Add("@c_case_desc_vehicle_03_make", miris.c_case_desc_vehicle_03_make);
            htUpdateCase.Add("@c_case_desc_vehicle_03_model", miris.c_case_desc_vehicle_03_model);
            htUpdateCase.Add("@c_case_desc_vehicle_03_type_fk", miris.c_case_desc_vehicle_03_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_03_year", miris.c_case_desc_vehicle_03_year);
            htUpdateCase.Add("@c_case_desc_vehicle_03_state", miris.c_case_desc_vehicle_03_state);

            htUpdateCase.Add("@c_case_desc_vehicle_04_fk", miris.c_case_desc_vehicle_04_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_04_id", miris.c_case_desc_vehicle_04_id);
            htUpdateCase.Add("@c_case_desc_vehicle_04_vin", miris.c_case_desc_vehicle_04_vin);
            htUpdateCase.Add("@c_case_desc_licence_04_number", miris.c_case_desc_licence_04_number);
            htUpdateCase.Add("@c_case_desc_vehicle_04_make", miris.c_case_desc_vehicle_04_make);
            htUpdateCase.Add("@c_case_desc_vehicle_04_model", miris.c_case_desc_vehicle_04_model);
            htUpdateCase.Add("@c_case_desc_vehicle_04_type_fk", miris.c_case_desc_vehicle_04_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_04_year", miris.c_case_desc_vehicle_04_year);
            htUpdateCase.Add("@c_case_desc_vehicle_04_state", miris.c_case_desc_vehicle_04_state);

            htUpdateCase.Add("@c_case_desc_vehicle_05_fk", miris.c_case_desc_vehicle_05_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_05_id", miris.c_case_desc_vehicle_05_id);
            htUpdateCase.Add("@c_case_desc_vehicle_05_vin", miris.c_case_desc_vehicle_05_vin);
            htUpdateCase.Add("@c_case_desc_licence_05_number", miris.c_case_desc_licence_05_number);
            htUpdateCase.Add("@c_case_desc_vehicle_05_make", miris.c_case_desc_vehicle_05_make);
            htUpdateCase.Add("@c_case_desc_vehicle_05_model", miris.c_case_desc_vehicle_05_model);
            htUpdateCase.Add("@c_case_desc_vehicle_05_type_fk", miris.c_case_desc_vehicle_05_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_05_year", miris.c_case_desc_vehicle_05_year);
            htUpdateCase.Add("@c_case_desc_vehicle_05_state", miris.c_case_desc_vehicle_05_state);

            htUpdateCase.Add("@c_case_desc_vehicle_06_fk", miris.c_case_desc_vehicle_06_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_06_id", miris.c_case_desc_vehicle_06_id);
            htUpdateCase.Add("@c_case_desc_vehicle_06_vin", miris.c_case_desc_vehicle_06_vin);
            htUpdateCase.Add("@c_case_desc_licence_06_number", miris.c_case_desc_licence_06_number);
            htUpdateCase.Add("@c_case_desc_vehicle_06_make", miris.c_case_desc_vehicle_06_make);
            htUpdateCase.Add("@c_case_desc_vehicle_06_model", miris.c_case_desc_vehicle_06_model);
            htUpdateCase.Add("@c_case_desc_vehicle_06_type_fk", miris.c_case_desc_vehicle_06_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_06_year", miris.c_case_desc_vehicle_06_year);
            htUpdateCase.Add("@c_case_desc_vehicle_06_state", miris.c_case_desc_vehicle_06_state);

            htUpdateCase.Add("@c_case_desc_vehicle_07_fk", miris.c_case_desc_vehicle_07_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_07_id", miris.c_case_desc_vehicle_07_id);
            htUpdateCase.Add("@c_case_desc_vehicle_07_vin", miris.c_case_desc_vehicle_07_vin);
            htUpdateCase.Add("@c_case_desc_licence_07_number", miris.c_case_desc_licence_07_number);
            htUpdateCase.Add("@c_case_desc_vehicle_07_make", miris.c_case_desc_vehicle_07_make);
            htUpdateCase.Add("@c_case_desc_vehicle_07_model", miris.c_case_desc_vehicle_07_model);
            htUpdateCase.Add("@c_case_desc_vehicle_07_type_fk", miris.c_case_desc_vehicle_07_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_07_year", miris.c_case_desc_vehicle_07_year);
            htUpdateCase.Add("@c_case_desc_vehicle_07_state", miris.c_case_desc_vehicle_07_state);

            htUpdateCase.Add("@c_case_desc_vehicle_08_fk", miris.c_case_desc_vehicle_08_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_08_id", miris.c_case_desc_vehicle_08_id);
            htUpdateCase.Add("@c_case_desc_vehicle_08_vin", miris.c_case_desc_vehicle_08_vin);
            htUpdateCase.Add("@c_case_desc_licence_08_number", miris.c_case_desc_licence_08_number);
            htUpdateCase.Add("@c_case_desc_vehicle_08_make", miris.c_case_desc_vehicle_08_make);
            htUpdateCase.Add("@c_case_desc_vehicle_08_model", miris.c_case_desc_vehicle_08_model);
            htUpdateCase.Add("@c_case_desc_vehicle_08_type_fk", miris.c_case_desc_vehicle_08_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_08_year", miris.c_case_desc_vehicle_08_year);
            htUpdateCase.Add("@c_case_desc_vehicle_08_state", miris.c_case_desc_vehicle_08_state);

            htUpdateCase.Add("@c_case_desc_vehicle_09_fk", miris.c_case_desc_vehicle_09_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_09_id", miris.c_case_desc_vehicle_09_id);
            htUpdateCase.Add("@c_case_desc_vehicle_09_vin", miris.c_case_desc_vehicle_09_vin);
            htUpdateCase.Add("@c_case_desc_licence_09_number", miris.c_case_desc_licence_09_number);
            htUpdateCase.Add("@c_case_desc_vehicle_09_make", miris.c_case_desc_vehicle_09_make);
            htUpdateCase.Add("@c_case_desc_vehicle_09_model", miris.c_case_desc_vehicle_09_model);
            htUpdateCase.Add("@c_case_desc_vehicle_09_type_fk", miris.c_case_desc_vehicle_09_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_09_year", miris.c_case_desc_vehicle_09_year);
            htUpdateCase.Add("@c_case_desc_vehicle_09_state", miris.c_case_desc_vehicle_09_state);

            htUpdateCase.Add("@c_case_desc_vehicle_10_fk", miris.c_case_desc_vehicle_10_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_10_id", miris.c_case_desc_vehicle_10_id);
            htUpdateCase.Add("@c_case_desc_vehicle_10_vin", miris.c_case_desc_vehicle_10_vin);
            htUpdateCase.Add("@c_case_desc_licence_10_number", miris.c_case_desc_licence_10_number);
            htUpdateCase.Add("@c_case_desc_vehicle_10_make", miris.c_case_desc_vehicle_10_make);
            htUpdateCase.Add("@c_case_desc_vehicle_10_model", miris.c_case_desc_vehicle_10_model);
            htUpdateCase.Add("@c_case_desc_vehicle_10_type_fk", miris.c_case_desc_vehicle_10_type_fk);
            htUpdateCase.Add("@c_case_desc_vehicle_10_year", miris.c_case_desc_vehicle_10_year);
            htUpdateCase.Add("@c_case_desc_vehicle_10_state", miris.c_case_desc_vehicle_10_state);


            htUpdateCase.Add("@c_case_desc_company_vehicle_struck_fk", miris.c_case_desc_company_vehicle_struck_fk);
            htUpdateCase.Add("@c_case_desc_company_vehicle_struck_by_fk", miris.c_case_desc_company_vehicle_struck_by_fk);
            htUpdateCase.Add("@c_case_desc_non_collision", miris.c_case_desc_non_collision);
            htUpdateCase.Add("@c_case_desc_non_collision_text", miris.c_case_desc_non_collision_text);

            htUpdateCase.Add("@c_case_detail_drivers_lic", miris.c_case_detail_drivers_lic);
            htUpdateCase.Add("@c_case_detail_state_and_class", miris.c_case_detail_state_and_class);
            if (miris.c_case_detail_expire_date != null)
            {
                htUpdateCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
            }
            else
            {
                htUpdateCase.Add("@c_case_detail_expire_date", DBNull.Value);
            }
            if (miris.c_date_in_title != null)
            {
                htUpdateCase.Add("@c_date_in_title", miris.c_date_in_title);
            }
            else
            {
                htUpdateCase.Add("@c_date_in_title", DBNull.Value);
            }
            //htUpdateCase.Add("@c_case_detail_expire_date", miris.c_case_detail_expire_date);
            htUpdateCase.Add("@c_case_detail_address", miris.c_case_detail_address);
            htUpdateCase.Add("@c_case_detail_city", miris.c_case_detail_city);
            htUpdateCase.Add("@c_case_detail_state", miris.c_case_detail_state);
            htUpdateCase.Add("@c_case_detail_nearest_cross_street", miris.c_case_detail_nearest_cross_street);
            htUpdateCase.Add("@c_case_detail_type_of_roadway", miris.c_case_detail_type_of_roadway);
            htUpdateCase.Add("@c_case_detail_road_condition_fk", miris.c_case_detail_road_condition_fk);
            if (miris.c_case_detail_time_of_day != null)
            {
                htUpdateCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
            }
            else
            {
                htUpdateCase.Add("@c_case_detail_time_of_day", DBNull.Value);
            }

            //htUpdateCase.Add("@c_case_detail_time_of_day", miris.c_case_detail_time_of_day);
            // here we need to add one column
            htUpdateCase.Add("@c_case_detail_weather_fk", miris.c_case_detail_weather_fk);
            htUpdateCase.Add("@c_case_detail_traffic_condition_fk", miris.c_case_detail_traffic_condition_fk);
            htUpdateCase.Add("@c_case_detail_traffic_controls_fk", miris.c_case_detail_traffic_controls_fk);
            htUpdateCase.Add("@c_case_detail_oprating_speed", miris.c_case_detail_oprating_speed);    //d
            htUpdateCase.Add("@c_case_detail_speed_limit", miris.c_case_detail_speed_limit);      //doubt
            htUpdateCase.Add("@c_case_detail_vehicle_struck_fk", miris.c_case_detail_vehicle_struck_fk);
            htUpdateCase.Add("@c_case_detail_vehicle_struck_by_fk", miris.c_case_detail_vehicle_struck_by_fk);
            htUpdateCase.Add("@c_case_detail_collision_type_fk", miris.c_case_detail_collision_type_fk);
            htUpdateCase.Add("@c_case_detail_collision_location_fk", miris.c_case_detail_collision_location_fk);
            htUpdateCase.Add("@c_case_detail_collision_direction_fk", miris.c_case_detail_collision_direction_fk);
            htUpdateCase.Add("@c_case_detail_non_collision_type_fk", miris.c_case_detail_non_collision_type_fk);
            htUpdateCase.Add("@c_case_detail_number_of_vehicle_involved", miris.c_case_detail_number_of_vehicle_involved);
            htUpdateCase.Add("@c_case_detail_number_of_vehicle_towed", miris.c_case_detail_number_of_vehicle_towed);
            htUpdateCase.Add("@c_case_detail_number_of_people_injured", miris.c_case_detail_number_of_people_injured);
            htUpdateCase.Add("@c_case_detail_number_of_people_killed", miris.c_case_detail_number_of_people_killed);
            htUpdateCase.Add("@c_case_detail_cituation_issued", miris.c_case_detail_cituation_issued);
            htUpdateCase.Add("@c_case_detail_at_whom", miris.c_case_detail_at_whom);
            htUpdateCase.Add("@c_case_detail_at_fault", miris.c_case_detail_at_fault);
            htUpdateCase.Add("@c_case_detail_contributory", miris.c_case_detail_contributory);
            htUpdateCase.Add("@c_case_detail_gross_vehicle_weight", miris.c_case_detail_gross_vehicle_weight);
            htUpdateCase.Add("@c_case_detail_combined_gross_vehicle_weight", miris.c_case_detail_combined_gross_vehicle_weight);
            htUpdateCase.Add("@c_case_detail_dot_vehicle", miris.c_case_detail_dot_vehicle);
            htUpdateCase.Add("@c_case_detail_dot_driver", miris.c_case_detail_dot_driver);
            htUpdateCase.Add("@c_case_detail_seat_belt_used", miris.c_case_detail_seat_belt_used);
            htUpdateCase.Add("@c_case_detail_air_bag_eqiupped", miris.c_case_detail_air_bag_eqiupped);
            htUpdateCase.Add("@c_case_detail_air_bag_deployed", miris.c_case_detail_air_bag_deployed);
            htUpdateCase.Add("@c_case_detail_cellphone_in_use", miris.c_case_detail_cellphone_in_use);
            htUpdateCase.Add("@c_case_detail_computer_in_use", miris.c_case_detail_computer_in_use);
            htUpdateCase.Add("@c_case_detail_special_equipment", miris.c_case_detail_special_equipment);
            htUpdateCase.Add("@c_case_detail_special_equipment_text", miris.c_case_detail_special_equipment_text);
            htUpdateCase.Add("@c_case_detail_location_of_impact_fk", miris.c_case_detail_location_of_impact_fk);
            htUpdateCase.Add("@c_case_detail_driver_injured", miris.c_case_detail_driver_injured);//-- need to add some fields
            htUpdateCase.Add("@c_case_detail_passenger_injured", miris.c_case_detail_passenger_injured); //-- need to add some fields
            htUpdateCase.Add("@c_case_detail_damage_heavy", miris.c_case_detail_damage_heavy);
            htUpdateCase.Add("@c_case_detail_damage_moderate", miris.c_case_detail_damage_moderate);
            htUpdateCase.Add("@c_case_detail_damage_light", miris.c_case_detail_damage_light);

            htUpdateCase.Add("@c_case_desc_was_fatality", miris.c_case_desc_was_fatality);
            htUpdateCase.Add("@c_case_desc_public_vehicle_involved", miris.c_case_desc_public_vehicle_involved);
            htUpdateCase.Add("@c_establishment", miris.c_establishment);

            htUpdateCase.Add("@c_pub_vehicle_driver_name", miris.c_pub_vehicle_driver_name);
            htUpdateCase.Add("@c_pub_vehicle_driver_address", miris.c_pub_vehicle_driver_address);
            htUpdateCase.Add("@c_pub_vehicle_driver_contact", miris.c_pub_vehicle_driver_contact);
            htUpdateCase.Add("@c_pub_vehicle_owner_name", miris.c_pub_vehicle_owner_name);
            htUpdateCase.Add("@c_pub_vehicle_owner_address", miris.c_pub_vehicle_owner_address);
            htUpdateCase.Add("@c_pub_vehicle_owner_contact", miris.c_pub_vehicle_owner_contact);
            htUpdateCase.Add("@c_pub_vehicle_vehicle_id", miris.c_pub_vehicle_vehicle_id);
            htUpdateCase.Add("@c_pub_vehicle_vehicle_vin", miris.c_pub_vehicle_vehicle_vin);
            htUpdateCase.Add("@c_pub_vehicle_licence_number", miris.c_pub_vehicle_licence_number);
            htUpdateCase.Add("@c_pub_vehicle_vehicle_make", miris.c_pub_vehicle_vehicle_make);
            htUpdateCase.Add("@c_pub_vehicle_vehicle_model", miris.c_pub_vehicle_vehicle_model);
            htUpdateCase.Add("@c_pub_vehicle_vehicle_type_fk", miris.c_pub_vehicle_vehicle_type_fk);
            htUpdateCase.Add("@c_pub_vehicle_year", miris.c_pub_vehicle_year);
            htUpdateCase.Add("@c_pub_vehicle_state", miris.c_pub_vehicle_state);
            htUpdateCase.Add("@c_pub_vehicle_gross_vehicle_weight", miris.c_pub_vehicle_gross_vehicle_weight);
            htUpdateCase.Add("@c_pub_vehicle_combined_gross_vehicle_weight", miris.c_pub_vehicle_combined_gross_vehicle_weight);
            htUpdateCase.Add("@c_pub_vehicle_dot_vehicle", miris.c_pub_vehicle_dot_vehicle);
            htUpdateCase.Add("@c_pub_vehicle_dot_driver", miris.c_pub_vehicle_dot_driver);
            htUpdateCase.Add("@c_pub_vehicle_seat_belt_used", miris.c_pub_vehicle_seat_belt_used);
            htUpdateCase.Add("@c_pub_vehicle_air_bag_eqiupped", miris.c_pub_vehicle_air_bag_eqiupped);
            htUpdateCase.Add("@c_pub_vehicle_air_bag_deployed", miris.c_pub_vehicle_air_bag_deployed);
            htUpdateCase.Add("@c_pub_vehicle_cellphone_in_use", miris.c_pub_vehicle_cellphone_in_use);
            htUpdateCase.Add("@c_pub_vehicle_computer_in_use", miris.c_pub_vehicle_computer_in_use);
            htUpdateCase.Add("@c_pub_vehicle_special_equipment", miris.c_pub_vehicle_special_equipment);
            htUpdateCase.Add("@c_pub_vehicle_special_equipment_text", miris.c_pub_vehicle_special_equipment_text);
            htUpdateCase.Add("@c_pub_vehicle_location_of_impact_fk", miris.c_pub_vehicle_location_of_impact_fk);
            htUpdateCase.Add("@c_pub_vehicle_driver_injured", miris.c_pub_vehicle_driver_injured);// need to add some fields
            htUpdateCase.Add("@c_pub_vehicle_passenger_injured", miris.c_pub_vehicle_passenger_injured); // need to add some fields

            htUpdateCase.Add("@c_pub_vehicle_driver_injured_text", miris.c_pub_vehicle_driver_injured_text);
            htUpdateCase.Add("@c_pub_vehicle_passenger_injured_text", miris.c_pub_vehicle_passenger_injured_text);

            htUpdateCase.Add("@c_pub_vehicle_number_of_total_vehicle_injured", miris.c_pub_vehicle_number_of_total_vehicle_injured);
            htUpdateCase.Add("@c_pub_vehicle_damage_heavy", miris.c_pub_vehicle_damage_heavy);
            htUpdateCase.Add("@c_pub_vehicle_damage_moderate", miris.c_pub_vehicle_damage_moderate);
            htUpdateCase.Add("@c_pub_vehicle_damage_light", miris.c_pub_vehicle_damage_light);
            //Pedestrain Incident
            htUpdateCase.Add("@c_pedestrain_name", miris.c_pedestrain_name);
            htUpdateCase.Add("@c_pedestrain_address", miris.c_pedestrain_address);
            htUpdateCase.Add("@c_pedestrain_phone", miris.c_pedestrain_phone);
            htUpdateCase.Add("@c_pedestrain_sex", miris.c_pedestrain_sex);
            htUpdateCase.Add("@c_pedestrain_age", miris.c_pedestrain_age);
            htUpdateCase.Add("@c_pedestrain_collision_type_fk", miris.c_pedestrain_collision_type_fk);
            htUpdateCase.Add("@c_pedestrain_description", miris.c_pedestrain_description);
            //BICycle Incident
            htUpdateCase.Add("@c_bicycle_person_name", miris.c_bicycle_person_name);
            htUpdateCase.Add("@c_bicycle_person_address", miris.c_bicycle_person_address);
            htUpdateCase.Add("@c_bicycle_person_phone", miris.c_bicycle_person_phone);
            htUpdateCase.Add("@c_bicycle_person_sex", miris.c_bicycle_person_sex);
            htUpdateCase.Add("@c_bicycle_person_age", miris.c_bicycle_person_age);
            htUpdateCase.Add("@c_bicycle_person_collision_type_fk", miris.c_bicycle_person_collision_type_fk);
            htUpdateCase.Add("@c_bicycle_person_description", miris.c_bicycle_person_description);
            //Animal Incident
            htUpdateCase.Add("@c_animal_name", miris.c_animal_name);
            htUpdateCase.Add("@c_animal_place", miris.c_animal_place);
            htUpdateCase.Add("@c_animal_collision_type_fk", miris.c_animal_collision_type_fk);
            htUpdateCase.Add("@c_animal_description", miris.c_animal_description);
            //Fixed Object Incident
            htUpdateCase.Add("@c_fixed_object_property_name", miris.c_fixed_object_property_name);
            htUpdateCase.Add("@c_fixed_object_address", miris.c_fixed_object_address);
            htUpdateCase.Add("@c_fixed_object_contact_info", miris.c_fixed_object_contact_info);
            htUpdateCase.Add("@c_fixed_object_collision_type_fk", miris.c_fixed_object_collision_type_fk);
            htUpdateCase.Add("@c_fixed_object_description", miris.c_fixed_object_description);
            htUpdateCase.Add("@c_fixed_object_property_description", miris.c_fixed_object_property_description);


            try
            {
                UpdateCaseType(miris.c_case_id_pk, miris.c_case_type_fk);
                return DataProxy.FetchSPOutput("c_miris_sp_update_case_mv", htUpdateCase);
            }

            catch (Exception)
            {
                throw;
            }
        }

        //OI Newly Added Attachment

        public static DataTable GetEmployeeStatement(ComplianceDAO miris)
        {
            Hashtable htGetEmployeeStatement = new Hashtable();
            htGetEmployeeStatement.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_employee_statement", htGetEmployeeStatement);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPolicies(ComplianceDAO miris)
        {
            Hashtable htGetPolicies = new Hashtable();
            htGetPolicies.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_policies", htGetPolicies);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetTrainingHistory(ComplianceDAO miris)
        {
            Hashtable htGetTrainingHistory = new Hashtable();
            htGetTrainingHistory.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_training_history", htGetTrainingHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetObservation(ComplianceDAO miris)
        {
            Hashtable htGetObservation = new Hashtable();
            htGetObservation.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_observation", htGetObservation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetIncidentHistory(ComplianceDAO miris)
        {
            Hashtable htGetIncidentHistory = new Hashtable();
            htGetIncidentHistory.Add("@c_case_id_fk", miris.c_case_id_pk);
            try
            {
                return DataProxy.FetchDataTable("c_miris_sp_get_incident_history", htGetIncidentHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertEmployeeStatement(ComplianceDAO miris)
        {
            Hashtable htInsertEmployeeStatement = new Hashtable();
            htInsertEmployeeStatement.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertEmployeeStatement.Add("@c_file_guid", miris.c_file_guid);
            htInsertEmployeeStatement.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_employee_statement", htInsertEmployeeStatement);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertPolicies(ComplianceDAO miris)
        {
            Hashtable htInsertPolicies = new Hashtable();
            htInsertPolicies.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertPolicies.Add("@c_file_guid", miris.c_file_guid);
            htInsertPolicies.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_policies", htInsertPolicies);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertTrainingHistory(ComplianceDAO miris)
        {
            Hashtable htInsertTrainingHistory = new Hashtable();
            htInsertTrainingHistory.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertTrainingHistory.Add("@c_file_guid", miris.c_file_guid);
            htInsertTrainingHistory.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_training_history", htInsertTrainingHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertObservation(ComplianceDAO miris)
        {
            Hashtable htInsertObservation = new Hashtable();
            htInsertObservation.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertObservation.Add("@c_file_guid", miris.c_file_guid);
            htInsertObservation.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_observation", htInsertObservation);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertIncidentHistory(ComplianceDAO miris)
        {
            Hashtable htInsertIncidentHistory = new Hashtable();
            htInsertIncidentHistory.Add("@c_case_id_fk", miris.c_case_id_pk);
            htInsertIncidentHistory.Add("@c_file_guid", miris.c_file_guid);
            htInsertIncidentHistory.Add("@c_file_name", miris.c_file_name);

            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_insert_incident_history", htInsertIncidentHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateEmployeeStatement(ComplianceDAO miris)
        {
            Hashtable htEmployeeStatement = new Hashtable();
            htEmployeeStatement.Add("@c_employee_statement_id_pk", miris.c_file_id);
            htEmployeeStatement.Add("@c_file_name", miris.c_file_name);
            htEmployeeStatement.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_employee_statement", htEmployeeStatement);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdatePolicies(ComplianceDAO miris)
        {
            Hashtable htPolicies = new Hashtable();
            htPolicies.Add("@c_policies_id_pk", miris.c_file_id);
            htPolicies.Add("@c_file_name", miris.c_file_name);
            htPolicies.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_policies", htPolicies);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateTrainingHistory(ComplianceDAO miris)
        {
            Hashtable htTrainingHistory = new Hashtable();
            htTrainingHistory.Add("@c_training_history_id_pk", miris.c_file_id);
            htTrainingHistory.Add("@c_file_name", miris.c_file_name);
            htTrainingHistory.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_training_history", htTrainingHistory);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateObservation(ComplianceDAO miris)
        {
            Hashtable htObservation = new Hashtable();
            htObservation.Add("@c_observation_id_pk", miris.c_file_id);
            htObservation.Add("@c_file_name", miris.c_file_name);
            htObservation.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_observation", htObservation);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateIncidentHistory(ComplianceDAO miris)
        {
            Hashtable htIncidentHistory = new Hashtable();
            htIncidentHistory.Add("@c_incident_history_id_pk", miris.c_file_id);
            htIncidentHistory.Add("@c_file_name", miris.c_file_name);
            htIncidentHistory.Add("@c_file_guid", miris.c_file_guid);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_update_incident_history", htIncidentHistory);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteEmployeeStatementFile(string c_file_id)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_employee_statement_id_pk", c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_employee_statement_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeletePoliciesFile(string c_file_id)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_policies_id_pk", c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_policies_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteTrainingHistoryFile(string c_file_id)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_training_history_id_pk", c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_training_history_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteObservationFile(string c_file_id)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_observation_id_pk", c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_observation_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteIncidentHistoryFile(string c_file_id)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@c_incident_history_id_pk", c_file_id);
            try
            {
                return DataProxy.FetchSPOutput("c_miris_sp_delete_incident_history_file", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetTodoHarmGirisReport(string userid_pk)
        {
            Hashtable htDeleteFile = new Hashtable();
            htDeleteFile.Add("@u_user_id_pk", userid_pk);
            try
            {
                return DataProxy.FetchDataSet("c_sp_get_todo_harm_giris_report", htDeleteFile);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateUserProfile_Compliance(User user)
        {
            Hashtable htUpdateUserInfo = new Hashtable();
            htUpdateUserInfo.Add("@u_user_id_pk", user.Userid);
            htUpdateUserInfo.Add("@u_middle_name", user.Middlename);
            htUpdateUserInfo.Add("@u_email_address", user.EmailId);
            htUpdateUserInfo.Add("@u_mobile_type_fk", user.Mobiletype);
            htUpdateUserInfo.Add("@u_mobile_carrier_fk", user.MobileCarrier);
            htUpdateUserInfo.Add("@u_mobile_number", user.MobileNumber);
            htUpdateUserInfo.Add("@u_work_phone", user.WorkPhone);
            htUpdateUserInfo.Add("@u_work_extension", user.Workextension);
            htUpdateUserInfo.Add("@u_address_1", user.Address1);
            htUpdateUserInfo.Add("@u_address_2", user.Address2);
            htUpdateUserInfo.Add("@u_address_3", user.Address3);
            htUpdateUserInfo.Add("@u_city", user.City);
            htUpdateUserInfo.Add("@u_state_province_ddl", user.StateProvince);
            htUpdateUserInfo.Add("@u_zip_postal_code_ddl", user.ZipPostalcode);
            htUpdateUserInfo.Add("@u_country_id_fk", user.Country);
            htUpdateUserInfo.Add("@u_locale_id_fk", user.LocaleId);
            htUpdateUserInfo.Add("@u_timezone_fk", user.TimezoneId);

            htUpdateUserInfo.Add("@u_profile_my_comp_todos_collapse_pref", user.u_profile_my_comp_todos_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_comp_harm_collapse_pref", user.u_profile_my_comp_harm_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_comp_giris_collapse_pref", user.u_profile_my_comp_giris_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_comp_reports_collapse_pref", user.u_profile_my_comp_reports_collapse_pref);

            if (user.u_profile_my_comp_todos_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_todos_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_todos_display_pref", user.u_profile_my_comp_todos_display_pref);
            }
            if (user.u_profile_my_comp_harm_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_harm_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_harm_display_pref", user.u_profile_my_comp_harm_display_pref);
            }
            if (user.u_profile_my_comp_giris_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_giris_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_giris_display_pref", user.u_profile_my_comp_giris_display_pref);
            }
            if (user.u_profile_my_comp_reports_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_reports_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_comp_reports_display_pref", user.u_profile_my_comp_reports_display_pref);
            }

            // 
            htUpdateUserInfo.Add("@u_profile_my_todos_collapse_pref", user.u_profile_my_todos_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_team_collapse_pref", user.u_profile_my_team_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_report_history_collapse_pref", user.u_profile_my_report_history_collapse_pref);
            if (user.u_profile_my_todos_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_todos_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_todos_records_display_pref", user.u_profile_my_todos_records_display_pref);
            }
            if (user.u_profile_my_team_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_team_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_team_records_display_pref", user.u_profile_my_team_records_display_pref);
            }
            if (user.u_profile_my_report_history_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_report_history_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_report_history_records_display_pref", user.u_profile_my_report_history_records_display_pref);
            }
            htUpdateUserInfo.Add("@type", user.type);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_compliance_user_profile", htUpdateUserInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchCompletionofCourses(string e_user_id_fk)
        {
            Hashtable htSearchCase = new Hashtable();

            if (!string.IsNullOrEmpty(e_user_id_fk))
            {
                htSearchCase.Add("@e_user_id_fk", e_user_id_fk);
            }
            else
            {
                htSearchCase.Add("@e_user_id_fk", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchDataTable("e_sp_get_all_completion_courses", htSearchCase);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

