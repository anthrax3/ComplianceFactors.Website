using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemHRISIntegrationBLL
    {
        public static int CreateHRIS(SystemHRISIntegration createHRIS)
        {

            Hashtable htCreateHRIS = new Hashtable();
            //htCreateHRIS.Add("@u_sftp_id_pk", createHRIS.u_sftp_id_pk);
            htCreateHRIS.Add("@u_sftp_URI", createHRIS.u_sftp_URI);
            htCreateHRIS.Add("@u_sftp_port", createHRIS.u_sftp_port);
            htCreateHRIS.Add("@u_sftp_username", createHRIS.u_sftp_username);
            htCreateHRIS.Add("@u_sftp_password", createHRIS.u_sftp_password);
            htCreateHRIS.Add("@u_sftp_hris_filename", createHRIS.u_sftp_hris_filename);
            htCreateHRIS.Add("@u_sftp_occurs_every", createHRIS.u_sftp_occurs_every);
            htCreateHRIS.Add("@u_sftp_time_every", createHRIS.u_sftp_time_every);
            htCreateHRIS.Add("@u_sftp_start_date", createHRIS.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_sftp_info", htCreateHRIS);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int insert_update_user(User user)
        {
            Hashtable htInsertNewUser = new Hashtable();
            htInsertNewUser.Add("@u_user_id_pk", user.Userid);
            htInsertNewUser.Add("@u_username_enc", user.Username_enc_ash);
            htInsertNewUser.Add("@u_password_enc_ash", user.Password_enc_ash);
            htInsertNewUser.Add("@u_password_enc_salt", user.Password_enc_salt);
            htInsertNewUser.Add("@u_first_name", user.Firstname);
            htInsertNewUser.Add("@u_middle_name", user.Middlename);
            htInsertNewUser.Add("@u_last_name", user.Lastname);
            htInsertNewUser.Add("@u_email_address", user.EmailId);
            htInsertNewUser.Add("@u_mobile_type_fk", user.Mobiletype);
            htInsertNewUser.Add("@u_mobile_carrier_fk", user.MobileCarrier);
            htInsertNewUser.Add("@u_mobile_number", user.MobileNumber);
            htInsertNewUser.Add("@u_work_phone", user.WorkPhone);
            htInsertNewUser.Add("@u_work_extension", user.Workextension);
            htInsertNewUser.Add("@u_address_1", user.Address1);
            htInsertNewUser.Add("@u_address_2", user.Address2);
            htInsertNewUser.Add("@u_address_3", user.Address3);
            htInsertNewUser.Add("@u_city", user.City);
            htInsertNewUser.Add("@u_state_province_ddl", user.StateProvince);
            htInsertNewUser.Add("@u_zip_postal_code_ddl", user.ZipPostalcode);
            htInsertNewUser.Add("@u_country_id_fk", user.Country);
            htInsertNewUser.Add("@u_domain_id_fk", user.DomainId);
            htInsertNewUser.Add("@u_locale_id_fk", user.LocaleId);
            htInsertNewUser.Add("@u_timezone_fk", user.TimezoneId);
            htInsertNewUser.Add("@u_user_type_fk", user.Usertype);
            // htInsertNewUser.Add("@u_creation_date_time", user.CreatedDate);
            htInsertNewUser.Add("@u_creation_type_fk", user.creation_type);
            htInsertNewUser.Add("@u_active_status_flag", user.Active_status_flag == "Active" ? true : false);
            htInsertNewUser.Add("@u_active_type_fk", user.Active_Type);
            htInsertNewUser.Add("@u_hris_employee_id", user.Hris_employeid);
            htInsertNewUser.Add("@u_hris_employee_type_fk", user.Hris_employee_type);

            if (user.Hris_hire_date != null)
            {
                htInsertNewUser.Add("@u_hris_hire_date", user.Hris_hire_date);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_hire_date", DBNull.Value);
            }

            if (user.Hris_last_rehire_date != null)
            {

                htInsertNewUser.Add("@u_hris_last_rehire_date", user.Hris_last_rehire_date);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_last_rehire_date", DBNull.Value);
            }

            htInsertNewUser.Add("@u_hris_company_fk", user.Hris_company);
            htInsertNewUser.Add("@u_hris_region_fk", user.Hris_region);
            htInsertNewUser.Add("@u_hris_division_fk", user.Hris_division);
            htInsertNewUser.Add("@u_hris_department_fk", user.Hris_department);
            htInsertNewUser.Add("@u_hris_cost_center_fk", user.Hris_cost_center);
            htInsertNewUser.Add("@u_hris_job_group_fk", user.Hris_job_group);
            htInsertNewUser.Add("@u_hris_job_code_fk", user.Hris_job_code);
            htInsertNewUser.Add("@u_hris_job_title_fk", user.Hris_job_title);
            htInsertNewUser.Add("@u_hris_job_position_fk", user.Hris_job_position);
            htInsertNewUser.Add("@u_hris_pay_grade_fk", user.Hris_pay_grade);

            if (string.IsNullOrEmpty(user.Hris_manager_id))
            {
                htInsertNewUser.Add("@u_hris_manager_id_fk", DBNull.Value);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_manager_id_fk", user.Hris_manager_id);
            }
            if (string.IsNullOrEmpty(user.Hris_supervisor_id))
            {
                htInsertNewUser.Add("@u_hris_supervisor_id_fk", DBNull.Value);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_supervisor_id_fk", user.Hris_supervisor_id);
            }
            if (string.IsNullOrEmpty(user.Hris_Alternate_manager_id))
            {
                htInsertNewUser.Add("@u_hris_alternate_manager_id_fk", DBNull.Value);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_alternate_manager_id_fk", user.Hris_Alternate_manager_id);
            }
            if (string.IsNullOrEmpty(user.Hris_alternate_supervisor_id))
            {
                htInsertNewUser.Add("@u_hris_alternate_supervisor_id_fk", DBNull.Value);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_alternate_supervisor_id_fk", user.Hris_alternate_supervisor_id);
            }
            if (string.IsNullOrEmpty(user.Hris_mentor_id))
            {
                htInsertNewUser.Add("@u_hris_mentor_id_fk", DBNull.Value);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_mentor_id_fk", user.Hris_mentor_id);
            }
            if (string.IsNullOrEmpty(user.Alternate_mentor_id))
            {
                htInsertNewUser.Add("@u_hris_alternate_mentor_id_fk", DBNull.Value);
            }
            else
            {
                htInsertNewUser.Add("@u_hris_alternate_mentor_id_fk", user.Alternate_mentor_id);
            }
            htInsertNewUser.Add("@u_sr_is_employee", user.sr_is_employee);
            htInsertNewUser.Add("@u_sr_is_manager", user.sr_is_manager);
            htInsertNewUser.Add("@u_sr_is_compliance", user.sr_is_compliance);
            htInsertNewUser.Add("@u_sr_is_instructor", user.sr_is_instructor);
            htInsertNewUser.Add("@u_sr_is_training", user.sr_is_training);
            htInsertNewUser.Add("@u_sr_is_administrator", user.sr_is_administrator);
            //htInsertNewUser.Add("@u_sr_is_system_admin", user.sr_is_system_admin);
            //newly added
            //htInsertNewUser.Add("@u_sr_is_compliance_approver", user.sr_is_compliance_approver);
            htInsertNewUser.Add("@u_custom_01", user.Custom_01);
            htInsertNewUser.Add("@u_custom_02", user.Custom_02);
            htInsertNewUser.Add("@u_custom_03", user.Custom_03);
            htInsertNewUser.Add("@u_custom_04", user.Custom_04);
            htInsertNewUser.Add("@u_custom_05", user.Custom_05);
            htInsertNewUser.Add("@u_custom_06", user.Custom_06);
            htInsertNewUser.Add("@u_custom_07", user.Custom_07);
            htInsertNewUser.Add("@u_custom_08", user.Custom_08);
            htInsertNewUser.Add("@u_custom_09", user.Custom_09);
            htInsertNewUser.Add("@u_custom_10", user.Custom_10);
            htInsertNewUser.Add("@u_custom_11", user.Custom_11);
            htInsertNewUser.Add("@u_custom_12", user.Custom_12);
            htInsertNewUser.Add("@u_custom_13", user.Custom_13);
            //htInsertNewUser.Add("@u_lastPassword_enc", user.LastPassword_enc);
            //htInsertNewUser.Add("@u_hris_is_rehire", user.u_hris_is_rehire);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_user_masters_from_hris", htInsertNewUser);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertHRISRunLog(SystemHRISIntegration hrisRunLog)
        {
            Hashtable htRunLog = new Hashtable();
            htRunLog.Add("@u_sftp_run_date_time_start", hrisRunLog.u_sftp_run_date_time_start);
            htRunLog.Add("@u_sftp_run_date_time_end", hrisRunLog.u_sftp_run_date_time_end);
            htRunLog.Add("@u_sftp_run_result", hrisRunLog.u_sftp_run_result);
            htRunLog.Add("@u_sftp_run_log_file_transfer", hrisRunLog.u_sftp_run_log_file_transfer);
            htRunLog.Add("@u_sftp_run_errors_details_filename", hrisRunLog.u_sftp_run_errors_details_filename);
            htRunLog.Add("@u_sftp_run_errors_log", hrisRunLog.u_sftp_run_errors_log);
            htRunLog.Add("@u_sftp_run_records_processes", hrisRunLog.u_sftp_run_records_processes);
            htRunLog.Add("@u_sftp_run_records_loaded", hrisRunLog.u_sftp_run_records_loaded);
            htRunLog.Add("@u_sftp_run_records_rejected", hrisRunLog.u_sftp_run_records_rejected);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_sftp_run_log", htRunLog);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetLogDetails()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_hris_error_log");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleErrorLog(string u_sftp_run_id_pk)
        {
            Hashtable htGetSingleErrorLog = new Hashtable();
            htGetSingleErrorLog.Add("@u_sftp_run_id_pk", u_sftp_run_id_pk);
            DataTable dtGetErrorLog = new DataTable();

            SystemHRISIntegration hrisErrorLog = new SystemHRISIntegration();

            try
            {
                dtGetErrorLog = DataProxy.FetchDataTable("s_sp_get_single_run_log", htGetSingleErrorLog);
                if (dtGetErrorLog.Rows.Count > 0)
                {
                    hrisErrorLog.u_sftp_run_date_time_end = dtGetErrorLog.Rows[0]["u_sftp_run_date_time_end"].ToString();
                    hrisErrorLog.u_sftp_run_date_time_start = dtGetErrorLog.Rows[0]["u_sftp_run_date_time_start"].ToString();
                    hrisErrorLog.u_sftp_run_errors_details_filename = dtGetErrorLog.Rows[0]["u_sftp_run_errors_details_filename"].ToString();
                    hrisErrorLog.u_sftp_run_errors_log = dtGetErrorLog.Rows[0]["u_sftp_run_errors_log"].ToString();
                    hrisErrorLog.u_sftp_run_records_loaded = Convert.ToInt32(dtGetErrorLog.Rows[0]["u_sftp_run_records_loaded"]);
                    hrisErrorLog.u_sftp_run_records_processes = Convert.ToInt32(dtGetErrorLog.Rows[0]["u_sftp_run_records_processes"]);
                    hrisErrorLog.u_sftp_run_records_rejected = Convert.ToInt32(dtGetErrorLog.Rows[0]["u_sftp_run_records_rejected"]);
                    hrisErrorLog.u_sftp_run_log_file_transfer = dtGetErrorLog.Rows[0]["u_sftp_run_log_file_transfer"].ToString();
                    hrisErrorLog.u_sftp_run_result = dtGetErrorLog.Rows[0]["u_sftp_run_result"].ToString();
                }

                return hrisErrorLog;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static SystemHRISIntegration GetHRISDetailsForBackground(string currntTime, string currentDate)
        {
            Hashtable htGetHRISDetailsForBackground = new Hashtable();
            htGetHRISDetailsForBackground.Add("@u_sftp_time_every",currntTime);
            htGetHRISDetailsForBackground.Add("@u_sftp_start_date", currentDate);

            DataTable dtSingleHris = new DataTable();

            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            try
            {
                dtSingleHris = DataProxy.FetchDataTable("s_sp_get_hris_details_for_background", htGetHRISDetailsForBackground);
                if (dtSingleHris.Rows.Count > 0)
                {
                    if (dtSingleHris.Rows[0]["u_sftp_URI"].ToString()!="-2")
                    {
                        hrisIntegration.u_sftp_URI = dtSingleHris.Rows[0]["u_sftp_URI"].ToString();
                        hrisIntegration.u_sftp_port = dtSingleHris.Rows[0]["u_sftp_port"].ToString();
                        hrisIntegration.u_sftp_username = dtSingleHris.Rows[0]["u_sftp_username"].ToString();
                        hrisIntegration.u_sftp_password = dtSingleHris.Rows[0]["u_sftp_password"].ToString();
                        hrisIntegration.u_sftp_hris_filename = dtSingleHris.Rows[0]["u_sftp_hris_filename"].ToString();
                        hrisIntegration.u_sftp_occurs_every = dtSingleHris.Rows[0]["u_sftp_occurs_every"].ToString();
                        hrisIntegration.u_sftp_time_every = dtSingleHris.Rows[0]["u_sftp_time_every"].ToString();
                        hrisIntegration.u_sftp_start_date = dtSingleHris.Rows[0]["u_sftp_start_date"].ToString();
                    }
                }

                return hrisIntegration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetHRIS( )
        {           
            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();
            DataTable dtSingleHris = new DataTable();
            try
            {
                dtSingleHris = DataProxy.FetchDataTable("s_sp_get_hris_details");
                if (dtSingleHris.Rows.Count > 0)
                {
                    hrisIntegration.u_sftp_id_pk = dtSingleHris.Rows[0]["u_sftp_id_pk"].ToString();
                    hrisIntegration.u_sftp_URI = dtSingleHris.Rows[0]["u_sftp_URI"].ToString();
                    hrisIntegration.u_sftp_port = dtSingleHris.Rows[0]["u_sftp_port"].ToString();
                    hrisIntegration.u_sftp_username = dtSingleHris.Rows[0]["u_sftp_username"].ToString();
                    hrisIntegration.u_sftp_password = dtSingleHris.Rows[0]["u_sftp_password"].ToString();
                    hrisIntegration.u_sftp_hris_filename = dtSingleHris.Rows[0]["u_sftp_hris_filename"].ToString();
                    hrisIntegration.u_sftp_occurs_every = dtSingleHris.Rows[0]["u_sftp_occurs_every"].ToString();
                    hrisIntegration.u_sftp_time_every = dtSingleHris.Rows[0]["u_sftp_time_every"].ToString();
                    hrisIntegration.u_sftp_start_date = dtSingleHris.Rows[0]["u_sftp_start_date"].ToString();
                }

                return hrisIntegration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet CreatePDF(string LogId,string s_locale_culture)
        {
            Hashtable htCreatePdf = new Hashtable();
            htCreatePdf.Add("@u_sftp_run_id_pk",LogId);
            htCreatePdf.Add("@s_locale_culture", s_locale_culture);

            try
            {
                return DataProxy.FetchDataSet("s_sp_get_error_log_pdf", htCreatePdf);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
