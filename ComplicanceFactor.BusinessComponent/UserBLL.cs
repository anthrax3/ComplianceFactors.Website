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
    public class UserBLL
    {
        public static DataTable Getuser(User home)
        {
            Hashtable htLogin = new Hashtable();
            htLogin.Add("@Username", home.Username);

            try
            {
                return DataProxy.FetchDataTable("app_sp_get_user", htLogin);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertLastVisited(User home)
        {
            Hashtable htInsLastVisited = new Hashtable();
            htInsLastVisited.Add("@u_user_id_pk", home.Userid);
            htInsLastVisited.Add("@u_last_tab_visited", home.lastvisited);
            htInsLastVisited.Add("@session_guid", home.currentSessionGuid);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_insert_last_tab_visited", htInsLastVisited);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Updatelanguage(User home)
        {
            Hashtable htInsLastVisited = new Hashtable();
            htInsLastVisited.Add("@s_locale_culture", home.selectedlanguage);
            htInsLastVisited.Add("@u_user_id_pk", home.Userid);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_last_language_selected", htInsLastVisited);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetUserTypes(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetUserStatusList = new Hashtable();
                htGetUserStatusList.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetUserStatusList.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_user_types", htGetUserStatusList);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllUserTypes(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllUserStatusList = new Hashtable();
                htGetAllUserStatusList.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllUserStatusList.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_user_all_types", htGetAllUserStatusList);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUserDomains()
        {
            try
            {
                return DataProxy.FetchDataTable("u_sp_get_user_domains");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUserTimeZone()
        {
            try
            {
                return DataProxy.FetchDataTable("app_sp_get_timezone");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int insert_new_user(User user)
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
            htInsertNewUser.Add("@u_sr_is_system_admin", user.sr_is_system_admin);
            //newly added
            htInsertNewUser.Add("@u_sr_is_compliance_approver", user.sr_is_compliance_approver);
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
            htInsertNewUser.Add("@u_lastPassword_enc", user.LastPassword_enc);
            htInsertNewUser.Add("@u_hris_is_rehire", user.u_hris_is_rehire);

            try
            {
                return DataProxy.FetchSPOutput("u_sp_insert_add_new_user", htInsertNewUser);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchUser(User user)
        {
            Hashtable htSearchUser = new Hashtable();
            htSearchUser.Add("@u_username_enc", user.Username_enc_ash);
            htSearchUser.Add("@u_first_name", user.Firstname);
            htSearchUser.Add("@u_last_name", user.Lastname);
            if (user.Active_Type == "0")
                htSearchUser.Add("@u_active_type_fk", System.DBNull.Value);
            else
                htSearchUser.Add("@u_active_type_fk", user.Active_Type);
            if (user.Usertype == "0")
                htSearchUser.Add("@u_user_type_fk", System.DBNull.Value);
            else
                htSearchUser.Add("@u_user_type_fk", user.Usertype);
            if (user.DomainId == "0")
                htSearchUser.Add("@u_domain_id_fk", System.DBNull.Value);
            else
                htSearchUser.Add("@u_domain_id_fk", user.DomainId);
            try
            {
                return DataProxy.FetchDataTable("app_sp_search_user", htSearchUser);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable InstructorSearch(User user)
        {
            Hashtable htSearchUser = new Hashtable();
            htSearchUser.Add("@u_username_enc", user.Username_enc_ash);
            htSearchUser.Add("@u_first_name", user.Firstname);
            htSearchUser.Add("@u_last_name", user.Lastname);
            if (user.Active_Type == "0")
                htSearchUser.Add("@u_active_type_fk", System.DBNull.Value);
            else
                htSearchUser.Add("@u_active_type_fk", user.Active_Type);
            if (user.Usertype == "0")
                htSearchUser.Add("@u_user_type_fk", System.DBNull.Value);
            else
                htSearchUser.Add("@u_user_type_fk", user.Usertype);
            if (user.DomainId == "0")
                htSearchUser.Add("@u_domain_id_fk", System.DBNull.Value);
            else
                htSearchUser.Add("@u_domain_id_fk", user.DomainId);
            try
            {
                return DataProxy.FetchDataTable("s_sp_instructor_search", htSearchUser);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SelectedUser(User user)
        {
            Hashtable htCurrentUser = new Hashtable();
            htCurrentUser.Add("@u_user_id_pk", user.Userid);

            try
            {
                return DataProxy.FetchDataTable("app_sp_get_user_by_id", htCurrentUser);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static User GetUserInfo_by_username(string username)
        {
            CultureInfo culture = new CultureInfo("en-US");
            Hashtable htUserInfo = new Hashtable();
            htUserInfo.Add("@Username", username);

            User userInfo;

            try
            {
                userInfo = new User();
                DataTable dtUser = DataProxy.FetchDataTable("app_sp_get_user_by_username", htUserInfo);
                userInfo.Username_enc_ash = dtUser.Rows[0]["u_username_enc"].ToString();
                userInfo.Password_enc_salt = dtUser.Rows[0]["u_password_enc_salt"].ToString();
                userInfo.Password_enc_ash = dtUser.Rows[0]["u_password_enc_ash"].ToString();
                userInfo.Firstname = dtUser.Rows[0]["u_first_name"].ToString();
                userInfo.Middlename = dtUser.Rows[0]["u_middle_name"].ToString();
                userInfo.Lastname = dtUser.Rows[0]["u_last_name"].ToString();
                userInfo.EmailId = dtUser.Rows[0]["u_email_address"].ToString();
                userInfo.Mobiletype = dtUser.Rows[0]["u_mobile_type_fk"].ToString();
                userInfo.MobileCarrier = dtUser.Rows[0]["u_mobile_carrier_fk"].ToString();
                userInfo.MobileNumber = dtUser.Rows[0]["u_mobile_number"].ToString();
                userInfo.WorkPhone = dtUser.Rows[0]["u_work_phone"].ToString();
                userInfo.Workextension = dtUser.Rows[0]["u_work_extension"].ToString();
                userInfo.Address1 = dtUser.Rows[0]["u_address_1"].ToString();
                userInfo.Address2 = dtUser.Rows[0]["u_address_2"].ToString();
                userInfo.Address3 = dtUser.Rows[0]["u_address_3"].ToString();
                userInfo.City = dtUser.Rows[0]["u_city"].ToString();
                userInfo.StateProvince = dtUser.Rows[0]["u_state_province_ddl"].ToString();
                userInfo.ZipPostalcode = dtUser.Rows[0]["u_zip_postal_code_ddl"].ToString();
                userInfo.Country = dtUser.Rows[0]["u_country_id_fk"].ToString();
                userInfo.DomainId = dtUser.Rows[0]["u_domain_id_fk"].ToString();
                userInfo.LocaleId = dtUser.Rows[0]["u_locale_id_fk"].ToString();
                userInfo.TimezoneId = dtUser.Rows[0]["u_timezone_id"].ToString();
                userInfo.Usertype = dtUser.Rows[0]["u_user_type_fk"].ToString();
                userInfo.CultureName = dtUser.Rows[0]["s_locale_short_Name"].ToString();
                //user creation type
                userInfo.creation_type = dtUser.Rows[0]["u_creation_type_fk"].ToString();
                //End
                userInfo.Active_status_flag = dtUser.Rows[0]["u_active_status_flag"].ToString();
                userInfo.Active_Type = dtUser.Rows[0]["u_active_type_fk"].ToString();
                userInfo.Hris_employeid = dtUser.Rows[0]["u_hris_employee_id"].ToString();
                userInfo.Hris_employee_type = dtUser.Rows[0]["u_hris_employee_type_fk"].ToString();

                userInfo.s_locale_culture = dtUser.Rows[0]["s_locale_culture"].ToString();


                if (!string.IsNullOrEmpty(dtUser.Rows[0]["u_hris_hire_date"].ToString()))
                {
                    userInfo.Hris_hire_date = Convert.ToDateTime(dtUser.Rows[0]["u_hris_hire_date"], culture);

                }

                if (!string.IsNullOrEmpty(dtUser.Rows[0]["u_hris_last_rehire_date"].ToString()))
                {
                    userInfo.Hris_last_rehire_date = Convert.ToDateTime(dtUser.Rows[0]["u_hris_last_rehire_date"], culture);

                }

                userInfo.Hris_company = dtUser.Rows[0]["u_hris_company_fk"].ToString();
                userInfo.Hris_region = dtUser.Rows[0]["u_hris_region_fk"].ToString();
                userInfo.Hris_division = dtUser.Rows[0]["u_hris_division_fk"].ToString();
                userInfo.Hris_department = dtUser.Rows[0]["u_hris_department_fk"].ToString();
                userInfo.Hris_cost_center = dtUser.Rows[0]["u_hris_cost_center_fk"].ToString();
                userInfo.Hris_job_group = dtUser.Rows[0]["u_hris_job_group_fk"].ToString();
                userInfo.Hris_job_code = dtUser.Rows[0]["u_hris_job_code_fk"].ToString();
                userInfo.Hris_job_title = dtUser.Rows[0]["u_hris_job_title_fk"].ToString();
                userInfo.Hris_job_position = dtUser.Rows[0]["u_hris_job_position_fk"].ToString();
                userInfo.Hris_pay_grade = dtUser.Rows[0]["u_hris_pay_grade_fk"].ToString();

                //id
                userInfo.Hris_manager_id = dtUser.Rows[0]["u_hris_manager_id_fk"].ToString();
                userInfo.Hris_supervisor_id = dtUser.Rows[0]["u_hris_supervisor_id_fk"].ToString();
                userInfo.Hris_Alternate_manager_id = dtUser.Rows[0]["u_hris_alternate_manager_id_fk"].ToString();
                userInfo.Hris_alternate_supervisor_id = dtUser.Rows[0]["u_hris_alternate_supervisor_id_fk"].ToString();
                userInfo.Hris_mentor_id = dtUser.Rows[0]["u_hris_mentor_id_fk"].ToString();
                userInfo.Alternate_mentor_id = dtUser.Rows[0]["u_hris_alternate_mentor_id_fk"].ToString();

                //text

                userInfo.Hris_manager_text = dtUser.Rows[0]["u_hris_manager"].ToString();
                userInfo.Hris_supervisor_text = dtUser.Rows[0]["u_hris_supervisor"].ToString();
                userInfo.Hris_Alternate_manager_text = dtUser.Rows[0]["u_hris_alternate_manager"].ToString();
                userInfo.Hris_alternate_supervisor_text = dtUser.Rows[0]["u_hris_alternate_supervisor"].ToString();
                userInfo.Hris_mentor_text = dtUser.Rows[0]["u_hris_mentor"].ToString();
                userInfo.Alternate_mentor_text = dtUser.Rows[0]["u_hris_alternate_mentor"].ToString();
                //End

                userInfo.sr_is_employee = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_employee"]);
                userInfo.sr_is_manager = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_manager"]);
                userInfo.sr_is_compliance = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_compliance"]);
                userInfo.sr_is_instructor = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_instructor"]);
                userInfo.sr_is_training = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_training"]);
                userInfo.sr_is_administrator = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_administrator"]);
                userInfo.sr_is_system_admin = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_system_admin"]);
                userInfo.sr_is_compliance_approver = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_compliance_approver"]);

                userInfo.Custom_01 = dtUser.Rows[0]["u_custom_01"].ToString();
                userInfo.Custom_02 = dtUser.Rows[0]["u_custom_02"].ToString();
                userInfo.Custom_03 = dtUser.Rows[0]["u_custom_03"].ToString();
                userInfo.Custom_04 = dtUser.Rows[0]["u_custom_04"].ToString();
                userInfo.Custom_05 = dtUser.Rows[0]["u_custom_05"].ToString();
                userInfo.Custom_06 = dtUser.Rows[0]["u_custom_06"].ToString();
                userInfo.Custom_07 = dtUser.Rows[0]["u_custom_07"].ToString();
                userInfo.Custom_08 = dtUser.Rows[0]["u_custom_08"].ToString();
                userInfo.Custom_09 = dtUser.Rows[0]["u_custom_09"].ToString();
                userInfo.Custom_10 = dtUser.Rows[0]["u_custom_10"].ToString();
                userInfo.Custom_11 = dtUser.Rows[0]["u_custom_11"].ToString();
                userInfo.Custom_12 = dtUser.Rows[0]["u_custom_12"].ToString();
                userInfo.Custom_13 = dtUser.Rows[0]["u_custom_13"].ToString();
                userInfo.u_hris_is_rehire = Convert.ToBoolean(dtUser.Rows[0]["u_hris_is_rehire"]);
                userInfo.Userid = dtUser.Rows[0]["u_user_id_pk"].ToString();
                userInfo.lastvisited = dtUser.Rows[0]["u_last_tab_visited"].ToString();

                userInfo.text_sr_is_employee = dtUser.Rows[0]["role_employee"].ToString();
                userInfo.text_sr_is_manager = dtUser.Rows[0]["role_manager"].ToString();
                userInfo.text_sr_is_compliance = dtUser.Rows[0]["role_compliance"].ToString();
                userInfo.text_sr_is_instructor = dtUser.Rows[0]["role_instructor"].ToString();
                userInfo.text_sr_is_training = dtUser.Rows[0]["role_training"].ToString();
                userInfo.text_sr_is_administrator = dtUser.Rows[0]["role_administrator"].ToString();
                userInfo.text_sr_is_system_admin = dtUser.Rows[0]["role_system"].ToString();
                userInfo.check_last_visited_tab_role = dtUser.Rows[0]["check_last_visited_tab_role"].ToString();

                userInfo.u_timezone_location = dtUser.Rows[0]["u_time_zone_display"].ToString();

                userInfo.u_profile_my_courses_collapse_pref = dtUser.Rows[0]["u_profile_my_courses_collapse_pref"].ToString();
                userInfo.u_profile_my_curricula_collapse_pref = dtUser.Rows[0]["u_profile_my_curricula_collapse_pref"].ToString();
                userInfo.u_profile_my_learning_history_collapse_pref = dtUser.Rows[0]["u_profile_my_learning_history_collapse_pref"].ToString();
                userInfo.u_profile_my_courses_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_courses_records_display_pref"]);
                userInfo.u_profile_my_curricula_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_curricula_records_display_pref"]);
                userInfo.u_profile_my_learning_history_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_learning_history_records_display_pref"]);


                userInfo.u_profile_my_system_splashes_collapse_pref = dtUser.Rows[0]["u_profile_my_system_splashes_collapse_pref"].ToString();
                userInfo.u_profile_my_system_themes_collapse_pref = dtUser.Rows[0]["u_profile_my_system_themes_collapse_pref"].ToString();
                userInfo.u_profile_my_system_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_system_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_system_splashes_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_system_splashes_records_display_pref"]);
                userInfo.u_profile_my_system_themes_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_system_themes_records_display_pref"]);
                userInfo.u_profile_my_system_reports_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_system_reports_records_display_pref"]);


                userInfo.u_profile_my_admin_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_admin_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_amdin_courses_collapse_pref = dtUser.Rows[0]["u_profile_my_amdin_courses_collapse_pref"].ToString();
                userInfo.u_profile_my_admin_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_admin_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_admin_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_admin_todos_display_pref"]);
                userInfo.u_profile_my_admin_courses_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_admin_courses_display_pref"]);
                userInfo.u_profile_my_admin_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_admin_reports_display_pref"]);


                userInfo.u_profile_my_inst_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_inst_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_inst_rosters_collapse_pref = dtUser.Rows[0]["u_profile_my_inst_rosters_collapse_pref"].ToString();
                userInfo.u_profile_my_inst_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_inst_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_inst_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_inst_todos_display_pref"]);
                userInfo.u_profile_my_inst_rosters_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_inst_rosters_display_pref"]);
                userInfo.u_profile_my_inst_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_inst_reports_display_pref"]);

                userInfo.u_profile_my_train_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_train_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_train_deliveries_collapse_pref = dtUser.Rows[0]["u_profile_my_train_deliveries_collapse_pref"].ToString();
                userInfo.u_profile_my_train_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_train_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_train_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_train_todos_display_pref"]);
                userInfo.u_profile_my_train_deliveries_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_train_deliveries_display_pref"]);
                userInfo.u_profile_my_train_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_train_reports_display_pref"]);

                userInfo.u_profile_my_comp_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_comp_harm_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_harm_collapse_pref"].ToString();
                userInfo.u_profile_my_comp_giris_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_giris_collapse_pref"].ToString();
                userInfo.u_profile_my_comp_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_reports_collapse_pref"].ToString();

                userInfo.u_profile_my_comp_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_todos_display_pref"]);
                userInfo.u_profile_my_comp_harm_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_harm_display_pref"]);
                userInfo.u_profile_my_comp_giris_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_giris_display_pref"]);
                userInfo.u_profile_my_comp_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_reports_display_pref"]);

                // userInfo.LastPassword_enc = rijndaelKey.Encrypt(txtPassword_login.Text);

                return userInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateUserInfo(User user)
        {
            Hashtable htUpdateUserInfo = new Hashtable();

            //htUpdateUserInfo.Add("@u_current_username_enc", user.u_current_username);
            htUpdateUserInfo.Add("@u_user_id_pk", user.Userid);
            htUpdateUserInfo.Add("@u_username_enc", user.Username_enc_ash);
            htUpdateUserInfo.Add("@u_password_enc_ash", user.Password_enc_ash);
            htUpdateUserInfo.Add("@u_password_enc_salt", user.Password_enc_salt);
            htUpdateUserInfo.Add("@u_first_name", user.Firstname);
            htUpdateUserInfo.Add("@u_middle_name", user.Middlename);
            htUpdateUserInfo.Add("@u_last_name", user.Lastname);
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
            htUpdateUserInfo.Add("@u_domain_id_fk", user.DomainId);
            htUpdateUserInfo.Add("@u_locale_id_fk", user.LocaleId);
            htUpdateUserInfo.Add("@u_timezone_fk", user.TimezoneId);
            htUpdateUserInfo.Add("@u_user_type_fk", user.Usertype);
            // htInsertNewUser.Add("@u_creation_date_time", user.CreatedDate);
            htUpdateUserInfo.Add("@u_creation_type_fk", user.creation_type);
            htUpdateUserInfo.Add("@u_active_status_flag", user.Active_status_flag == "Active" ? true : false);
            htUpdateUserInfo.Add("@u_active_type_fk", user.Active_Type);
            htUpdateUserInfo.Add("@u_hris_employee_id", user.Hris_employeid);
            htUpdateUserInfo.Add("@u_hris_employee_type_fk", user.Hris_employee_type);

            if (user.Hris_hire_date != null)
            {
                htUpdateUserInfo.Add("@u_hris_hire_date", user.Hris_hire_date);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_hire_date", DBNull.Value);
            }

            if (user.Hris_last_rehire_date != null)
            {

                htUpdateUserInfo.Add("@u_hris_last_rehire_date", user.Hris_last_rehire_date);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_last_rehire_date", DBNull.Value);
            }

            htUpdateUserInfo.Add("@u_hris_company_fk", user.Hris_company);
            htUpdateUserInfo.Add("@u_hris_region_fk", user.Hris_region);
            htUpdateUserInfo.Add("@u_hris_division_fk", user.Hris_division);
            htUpdateUserInfo.Add("@u_hris_department_fk", user.Hris_department);
            htUpdateUserInfo.Add("@u_hris_cost_center_fk", user.Hris_cost_center);
            htUpdateUserInfo.Add("@u_hris_job_group_fk", user.Hris_job_group);
            htUpdateUserInfo.Add("@u_hris_job_code_fk", user.Hris_job_code);
            htUpdateUserInfo.Add("@u_hris_job_title_fk", user.Hris_job_title);
            htUpdateUserInfo.Add("@u_hris_job_position_fk", user.Hris_job_position);
            htUpdateUserInfo.Add("@u_hris_pay_grade_fk", user.Hris_pay_grade);
            if (!string.IsNullOrEmpty(user.Hris_manager_id))
            {
                htUpdateUserInfo.Add("@u_hris_manager_id_fk", user.Hris_manager_id);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_manager_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user.Hris_supervisor_id))
            {
                htUpdateUserInfo.Add("@u_hris_supervisor_id_fk", user.Hris_supervisor_id);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_supervisor_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user.Hris_Alternate_manager_id))
            {
                htUpdateUserInfo.Add("@u_hris_alternate_manager_id_fk", user.Hris_Alternate_manager_id);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_alternate_manager_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user.Hris_alternate_supervisor_id))
            {
                htUpdateUserInfo.Add("@u_hris_alternate_supervisor_id_fk", user.Hris_alternate_supervisor_id);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_alternate_supervisor_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user.Hris_mentor_id))
            {
                htUpdateUserInfo.Add("@u_hris_mentor_id_fk", user.Hris_mentor_id);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_mentor_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user.Alternate_mentor_id))
            {
                htUpdateUserInfo.Add("@u_hris_alternate_mentor_id_fk", user.Alternate_mentor_id);
            }
            else
            {
                htUpdateUserInfo.Add("@u_hris_alternate_mentor_id_fk", DBNull.Value);
            }
            htUpdateUserInfo.Add("@u_sr_is_employee", user.sr_is_employee);
            htUpdateUserInfo.Add("@u_sr_is_manager", user.sr_is_manager);
            htUpdateUserInfo.Add("@u_sr_is_compliance", user.sr_is_compliance);
            htUpdateUserInfo.Add("@u_sr_is_instructor", user.sr_is_instructor);
            htUpdateUserInfo.Add("@u_sr_is_training", user.sr_is_training);
            htUpdateUserInfo.Add("@u_sr_is_administrator", user.sr_is_administrator);
            htUpdateUserInfo.Add("@u_sr_is_system_admin", user.sr_is_system_admin);
            //Newly Added
            htUpdateUserInfo.Add("@u_sr_is_compliance_approver", user.sr_is_compliance_approver);

            htUpdateUserInfo.Add("@u_custom_01", user.Custom_01);
            htUpdateUserInfo.Add("@u_custom_02", user.Custom_02);
            htUpdateUserInfo.Add("@u_custom_03", user.Custom_03);
            htUpdateUserInfo.Add("@u_custom_04", user.Custom_04);
            htUpdateUserInfo.Add("@u_custom_05", user.Custom_05);
            htUpdateUserInfo.Add("@u_custom_06", user.Custom_06);
            htUpdateUserInfo.Add("@u_custom_07", user.Custom_07);
            htUpdateUserInfo.Add("@u_custom_08", user.Custom_08);
            htUpdateUserInfo.Add("@u_custom_09", user.Custom_09);
            htUpdateUserInfo.Add("@u_custom_10", user.Custom_10);
            htUpdateUserInfo.Add("@u_custom_11", user.Custom_11);
            htUpdateUserInfo.Add("@u_custom_12", user.Custom_12);
            htUpdateUserInfo.Add("@u_custom_13", user.Custom_13);
            htUpdateUserInfo.Add("@u_lastPassword_enc", user.LastPassword_enc);
            htUpdateUserInfo.Add("@u_hris_is_rehire", user.u_hris_is_rehire); ;

            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_user_info", htUpdateUserInfo);

            }

            catch (Exception)
            {
                throw;
            }
        }

        public static User GetUserInfo_by_id(string userId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            Hashtable htCopyUserInfo = new Hashtable();
            htCopyUserInfo.Add("@u_user_id_pk", userId);

            User userInfo;

            try
            {
                userInfo = new User();
                DataTable dtUser = DataProxy.FetchDataTable("app_sp_get_user_by_id", htCopyUserInfo);
                userInfo.Username_enc_ash = dtUser.Rows[0]["u_username_enc"].ToString();
                userInfo.Password_enc_salt = dtUser.Rows[0]["u_password_enc_salt"].ToString();
                userInfo.Password_enc_ash = dtUser.Rows[0]["u_password_enc_ash"].ToString();
                userInfo.Firstname = dtUser.Rows[0]["u_first_name"].ToString();
                userInfo.Middlename = dtUser.Rows[0]["u_middle_name"].ToString();
                userInfo.Lastname = dtUser.Rows[0]["u_last_name"].ToString();
                userInfo.EmailId = dtUser.Rows[0]["u_email_address"].ToString();
                userInfo.Mobiletype = dtUser.Rows[0]["u_mobile_type_fk"].ToString();
                userInfo.MobileCarrier = dtUser.Rows[0]["u_mobile_carrier_fk"].ToString();
                userInfo.MobileNumber = dtUser.Rows[0]["u_mobile_number"].ToString();
                userInfo.WorkPhone = dtUser.Rows[0]["u_work_phone"].ToString();
                userInfo.Workextension = dtUser.Rows[0]["u_work_extension"].ToString();
                userInfo.Address1 = dtUser.Rows[0]["u_address_1"].ToString();
                userInfo.Address2 = dtUser.Rows[0]["u_address_2"].ToString();
                userInfo.Address3 = dtUser.Rows[0]["u_address_3"].ToString();
                userInfo.City = dtUser.Rows[0]["u_city"].ToString();
                userInfo.StateProvince = dtUser.Rows[0]["u_state_province_ddl"].ToString();
                userInfo.ZipPostalcode = dtUser.Rows[0]["u_zip_postal_code_ddl"].ToString();
                userInfo.Country = dtUser.Rows[0]["u_country_id_fk"].ToString();
                userInfo.DomainId = dtUser.Rows[0]["u_domain_id_fk"].ToString();
                //userInfo.LocaleId = dtUser.Rows[0]["s_locale_culture"].ToString();
                userInfo.LocaleId = dtUser.Rows[0]["u_locale_id_fk"].ToString();
                userInfo.TimezoneId = dtUser.Rows[0]["u_timezone_id"].ToString();
                userInfo.Usertype = dtUser.Rows[0]["u_user_type_fk"].ToString();

                //user creation type
                userInfo.creation_type = dtUser.Rows[0]["u_creation_type_fk"].ToString();
                //End
                userInfo.Active_status_flag = dtUser.Rows[0]["u_active_status_flag"].ToString();
                userInfo.Active_Type = dtUser.Rows[0]["u_active_type_fk"].ToString();
                userInfo.Hris_employeid = dtUser.Rows[0]["u_hris_employee_id"].ToString();
                userInfo.Hris_employee_type = dtUser.Rows[0]["u_hris_employee_type_fk"].ToString();


                if (!string.IsNullOrEmpty(dtUser.Rows[0]["u_hris_hire_date"].ToString()))
                {
                    userInfo.Hris_hire_date = Convert.ToDateTime(dtUser.Rows[0]["u_hris_hire_date"], culture);

                }

                //userInfo.Hris_hire_date = dtHiredate;
                if (!string.IsNullOrEmpty(dtUser.Rows[0]["u_hris_last_rehire_date"].ToString()))
                {
                    userInfo.Hris_last_rehire_date = Convert.ToDateTime(dtUser.Rows[0]["u_hris_last_rehire_date"], culture);

                }

                userInfo.Hris_company = dtUser.Rows[0]["u_hris_company_fk"].ToString();
                userInfo.Hris_region = dtUser.Rows[0]["u_hris_region_fk"].ToString();
                userInfo.Hris_division = dtUser.Rows[0]["u_hris_division_fk"].ToString();
                userInfo.Hris_department = dtUser.Rows[0]["u_hris_department_fk"].ToString();
                userInfo.Hris_cost_center = dtUser.Rows[0]["u_hris_cost_center_fk"].ToString();
                userInfo.Hris_job_group = dtUser.Rows[0]["u_hris_job_group_fk"].ToString();
                userInfo.Hris_job_code = dtUser.Rows[0]["u_hris_job_code_fk"].ToString();
                userInfo.Hris_job_title = dtUser.Rows[0]["u_hris_job_title_fk"].ToString();
                userInfo.Hris_job_position = dtUser.Rows[0]["u_hris_job_position_fk"].ToString();
                userInfo.Hris_pay_grade = dtUser.Rows[0]["u_hris_pay_grade_fk"].ToString();


                //questions
                //id
                userInfo.Hris_manager_id = dtUser.Rows[0]["u_hris_manager_id_fk"].ToString();
                userInfo.Hris_supervisor_id = dtUser.Rows[0]["u_hris_supervisor_id_fk"].ToString();
                userInfo.Hris_Alternate_manager_id = dtUser.Rows[0]["u_hris_alternate_manager_id_fk"].ToString();
                userInfo.Hris_alternate_supervisor_id = dtUser.Rows[0]["u_hris_alternate_supervisor_id_fk"].ToString();
                userInfo.Hris_mentor_id = dtUser.Rows[0]["u_hris_mentor_id_fk"].ToString();
                userInfo.Alternate_mentor_id = dtUser.Rows[0]["u_hris_alternate_mentor_id_fk"].ToString();

                //text

                userInfo.Hris_manager_text = dtUser.Rows[0]["u_hris_manager"].ToString();
                userInfo.Hris_supervisor_text = dtUser.Rows[0]["u_hris_supervisor"].ToString();
                userInfo.Hris_Alternate_manager_text = dtUser.Rows[0]["u_hris_alternate_manager"].ToString();
                userInfo.Hris_alternate_supervisor_text = dtUser.Rows[0]["u_hris_alternate_supervisor"].ToString();
                userInfo.Hris_mentor_text = dtUser.Rows[0]["u_hris_mentor"].ToString();
                userInfo.Alternate_mentor_text = dtUser.Rows[0]["u_hris_alternate_mentor"].ToString();
                //End

                userInfo.sr_is_employee = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_employee"]);
                userInfo.sr_is_manager = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_manager"]);
                userInfo.sr_is_compliance = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_compliance"]);
                userInfo.sr_is_instructor = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_instructor"]);
                userInfo.sr_is_training = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_training"]);
                userInfo.sr_is_administrator = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_administrator"]);
                userInfo.sr_is_system_admin = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_system_admin"]);
                userInfo.sr_is_compliance_approver = Convert.ToBoolean(dtUser.Rows[0]["u_sr_is_compliance_approver"]);
                userInfo.Custom_01 = dtUser.Rows[0]["u_custom_01"].ToString();
                userInfo.Custom_02 = dtUser.Rows[0]["u_custom_02"].ToString();
                userInfo.Custom_03 = dtUser.Rows[0]["u_custom_03"].ToString();
                userInfo.Custom_04 = dtUser.Rows[0]["u_custom_04"].ToString();
                userInfo.Custom_05 = dtUser.Rows[0]["u_custom_05"].ToString();
                userInfo.Custom_06 = dtUser.Rows[0]["u_custom_06"].ToString();
                userInfo.Custom_07 = dtUser.Rows[0]["u_custom_07"].ToString();
                userInfo.Custom_08 = dtUser.Rows[0]["u_custom_08"].ToString();
                userInfo.Custom_09 = dtUser.Rows[0]["u_custom_09"].ToString();
                userInfo.Custom_10 = dtUser.Rows[0]["u_custom_10"].ToString();
                userInfo.Custom_11 = dtUser.Rows[0]["u_custom_11"].ToString();
                userInfo.Custom_12 = dtUser.Rows[0]["u_custom_12"].ToString();
                userInfo.Custom_13 = dtUser.Rows[0]["u_custom_13"].ToString();
                userInfo.u_hris_is_rehire = Convert.ToBoolean(dtUser.Rows[0]["u_hris_is_rehire"]);
                userInfo.u_profile_my_courses_collapse_pref = dtUser.Rows[0]["u_profile_my_courses_collapse_pref"].ToString();
                userInfo.u_profile_my_curricula_collapse_pref = dtUser.Rows[0]["u_profile_my_curricula_collapse_pref"].ToString();
                userInfo.u_profile_my_learning_history_collapse_pref = dtUser.Rows[0]["u_profile_my_learning_history_collapse_pref"].ToString();
                userInfo.u_profile_my_courses_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_courses_records_display_pref"]);
                userInfo.u_profile_my_curricula_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_curricula_records_display_pref"]);
                userInfo.u_profile_my_learning_history_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_learning_history_records_display_pref"]);

                userInfo.u_profile_my_system_splashes_collapse_pref = dtUser.Rows[0]["u_profile_my_system_splashes_collapse_pref"].ToString();
                userInfo.u_profile_my_system_themes_collapse_pref = dtUser.Rows[0]["u_profile_my_system_themes_collapse_pref"].ToString();
                userInfo.u_profile_my_system_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_system_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_system_splashes_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_system_splashes_records_display_pref"]);
                userInfo.u_profile_my_system_themes_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_system_themes_records_display_pref"]);
                userInfo.u_profile_my_system_reports_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_system_reports_records_display_pref"]);

                userInfo.u_profile_my_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_team_collapse_pref = dtUser.Rows[0]["u_profile_my_team_collapse_pref"].ToString();
                userInfo.u_profile_my_report_history_collapse_pref = dtUser.Rows[0]["u_profile_my_report_history_collapse_pref"].ToString();
                userInfo.u_profile_my_todos_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_todos_records_display_pref"]);
                userInfo.u_profile_my_team_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_team_records_display_pref"]);
                userInfo.u_profile_my_report_history_records_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_report_history_records_display_pref"]);

                userInfo.u_profile_my_admin_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_admin_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_amdin_courses_collapse_pref = dtUser.Rows[0]["u_profile_my_amdin_courses_collapse_pref"].ToString();
                userInfo.u_profile_my_admin_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_admin_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_admin_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_admin_todos_display_pref"]);
                userInfo.u_profile_my_admin_courses_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_admin_courses_display_pref"]);
                userInfo.u_profile_my_admin_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_admin_reports_display_pref"]);

                userInfo.u_profile_my_inst_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_inst_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_inst_rosters_collapse_pref = dtUser.Rows[0]["u_profile_my_inst_rosters_collapse_pref"].ToString();
                userInfo.u_profile_my_inst_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_inst_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_inst_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_inst_todos_display_pref"]);
                userInfo.u_profile_my_inst_rosters_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_inst_rosters_display_pref"]);
                userInfo.u_profile_my_inst_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_inst_reports_display_pref"]);

                userInfo.u_profile_my_train_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_train_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_train_deliveries_collapse_pref = dtUser.Rows[0]["u_profile_my_train_deliveries_collapse_pref"].ToString();
                userInfo.u_profile_my_train_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_train_reports_collapse_pref"].ToString();
                userInfo.u_profile_my_train_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_train_todos_display_pref"]);
                userInfo.u_profile_my_train_deliveries_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_train_deliveries_display_pref"]);
                userInfo.u_profile_my_train_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_train_reports_display_pref"]);

                userInfo.u_profile_my_comp_todos_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_todos_collapse_pref"].ToString();
                userInfo.u_profile_my_comp_harm_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_harm_collapse_pref"].ToString();
                userInfo.u_profile_my_comp_giris_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_giris_collapse_pref"].ToString();
                userInfo.u_profile_my_comp_reports_collapse_pref = dtUser.Rows[0]["u_profile_my_comp_reports_collapse_pref"].ToString();

                userInfo.u_profile_my_comp_todos_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_todos_display_pref"]);
                userInfo.u_profile_my_comp_harm_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_harm_display_pref"]);
                userInfo.u_profile_my_comp_giris_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_giris_display_pref"]);
                userInfo.u_profile_my_comp_reports_display_pref = Convert.ToInt32(dtUser.Rows[0]["u_profile_my_comp_reports_display_pref"]);



                // userInfo.LastPassword_enc = rijndaelKey.Encrypt(txtPassword_login.Text);

                return userInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static User GetUserInfo(string userId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            Hashtable htRetireUserInfo = new Hashtable();
            htRetireUserInfo.Add("@u_user_id_pk", userId);

            User userInfo;

            try
            {
                userInfo = new User();
                DataTable dtUser = DataProxy.FetchDataTable("app_sp_get_user_by_id", htRetireUserInfo);
                userInfo.Username_enc_ash = dtUser.Rows[0]["u_username_enc"].ToString();
                userInfo.Password_enc_salt = dtUser.Rows[0]["u_password_enc_salt"].ToString();
                userInfo.Password_enc_ash = dtUser.Rows[0]["u_password_enc_ash"].ToString();
                userInfo.Firstname = dtUser.Rows[0]["u_first_name"].ToString();
                userInfo.Middlename = dtUser.Rows[0]["u_middle_name"].ToString();
                userInfo.Lastname = dtUser.Rows[0]["u_last_name"].ToString();
                userInfo.EmailId = dtUser.Rows[0]["u_email_address"].ToString();
                userInfo.Mobiletype = dtUser.Rows[0]["mobile_type_name"].ToString();
                userInfo.MobileCarrier = dtUser.Rows[0]["mobile_carrier_type_name"].ToString();
                userInfo.MobileNumber = dtUser.Rows[0]["u_mobile_number"].ToString();
                userInfo.WorkPhone = dtUser.Rows[0]["u_work_phone"].ToString();
                userInfo.Workextension = dtUser.Rows[0]["u_work_extension"].ToString();
                userInfo.Address1 = dtUser.Rows[0]["u_address_1"].ToString();
                userInfo.Address2 = dtUser.Rows[0]["u_address_2"].ToString();
                userInfo.Address3 = dtUser.Rows[0]["u_address_3"].ToString();
                userInfo.City = dtUser.Rows[0]["u_city"].ToString();
                userInfo.StateProvince = dtUser.Rows[0]["u_state_province_ddl"].ToString();
                userInfo.ZipPostalcode = dtUser.Rows[0]["u_zip_postal_code_ddl"].ToString();
                userInfo.Country = dtUser.Rows[0]["u_country_id_fk"].ToString();
                userInfo.DomainId = dtUser.Rows[0]["user_domain_name"].ToString();
                userInfo.LocaleId = dtUser.Rows[0]["s_locale_culture"].ToString();
                userInfo.TimezoneId = dtUser.Rows[0]["u_timezone_id"].ToString();
                userInfo.Usertype = dtUser.Rows[0]["user_type"].ToString();

                userInfo.u_country_name = dtUser.Rows[0]["u_country_name"].ToString();

                //user creation type
                userInfo.creation_type = dtUser.Rows[0]["u_creation_type_fk"].ToString();
                //End
                userInfo.Active_status_flag = dtUser.Rows[0]["u_retire_active_status_flag"].ToString();
                userInfo.Active_Type = dtUser.Rows[0]["u_active_type_fk"].ToString();
                userInfo.Hris_employeid = dtUser.Rows[0]["u_hris_employee_id"].ToString();
                userInfo.Hris_employee_type = dtUser.Rows[0]["employee_type_name"].ToString();
                userInfo.u_locale_descriptoin = dtUser.Rows[0]["s_locale_description"].ToString();
                userInfo.u_timezone_location = dtUser.Rows[0]["u_time_zone_location"].ToString();

                if (!string.IsNullOrEmpty(dtUser.Rows[0]["u_hris_hire_date"].ToString()))
                {
                    userInfo.Hris_hire_date = Convert.ToDateTime(dtUser.Rows[0]["u_hris_hire_date"], culture);

                }
                //DateTime? dtHiredate = null;
                //DateTime tempHireDate;

                //if (DateTime.TryParseExact(dtUser.Rows[0]["u_hris_hire_date"].ToString(), "MM/dd/yyyy", culture, DateTimeStyles.None, out tempHireDate))
                //{
                //    dtHiredate = tempHireDate;
                //}


                //userInfo.Hris_hire_date = dtHiredate;

                if (!string.IsNullOrEmpty(dtUser.Rows[0]["u_hris_last_rehire_date"].ToString()))
                {
                    userInfo.Hris_last_rehire_date = Convert.ToDateTime(dtUser.Rows[0]["u_hris_last_rehire_date"], culture);

                }
                //DateTime? txtLastrehiredate = null;
                //DateTime tempLastRehireDate;

                //if (DateTime.TryParseExact(dtUser.Rows[0]["u_hris_last_rehire_date"].ToString(), "MM/dd/yyyy", culture, DateTimeStyles.None, out tempLastRehireDate))
                //{
                //    txtLastrehiredate = tempLastRehireDate;
                //}


                //userInfo.Hris_last_rehire_date = txtLastrehiredate;

                //DateTime? tskHiredate = null;
                //DateTime tempStartDate;


                //if (DateTime.TryParse(dtUser.Rows[0]["u_hris_hire_date"].ToString(), out tempStartDate))
                //{
                //    tskHiredate = tempStartDate;
                //}
                //if (dtUser.Rows[0]["u_hris_hire_date"].ToString() != string.Empty)
                //{
                //    userInfo.Hris_hire_date = tskHiredate;
                //}

                //DateTime? txtLastrehiredate = null;
                //DateTime tempEndDate;


                //if (DateTime.TryParse(dtUser.Rows[0]["u_hris_last_rehire_date"].ToString(), out tempEndDate))
                //{
                //    txtLastrehiredate = tempEndDate;
                //}

                //userInfo.Hris_last_rehire_date = txtLastrehiredate;


                userInfo.Hris_company = dtUser.Rows[0]["u_hris_company_fk"].ToString();
                userInfo.Hris_region = dtUser.Rows[0]["u_hris_region_fk"].ToString();
                userInfo.Hris_division = dtUser.Rows[0]["u_hris_division_fk"].ToString();
                userInfo.Hris_department = dtUser.Rows[0]["u_hris_department_fk"].ToString();
                userInfo.Hris_cost_center = dtUser.Rows[0]["u_hris_cost_center_fk"].ToString();
                userInfo.Hris_job_group = dtUser.Rows[0]["u_hris_job_group_fk"].ToString();
                userInfo.Hris_job_code = dtUser.Rows[0]["u_hris_job_code_fk"].ToString();
                userInfo.Hris_job_title = dtUser.Rows[0]["u_hris_job_title_fk"].ToString();
                userInfo.Hris_job_position = dtUser.Rows[0]["u_hris_job_position_fk"].ToString();
                userInfo.Hris_pay_grade = dtUser.Rows[0]["u_hris_pay_grade_fk"].ToString();


                //questions
                //id
                userInfo.Hris_manager_id = dtUser.Rows[0]["u_hris_manager_id_fk"].ToString();
                userInfo.Hris_supervisor_id = dtUser.Rows[0]["u_hris_supervisor_id_fk"].ToString();
                userInfo.Hris_Alternate_manager_id = dtUser.Rows[0]["u_hris_alternate_manager_id_fk"].ToString();
                userInfo.Hris_alternate_supervisor_id = dtUser.Rows[0]["u_hris_alternate_supervisor_id_fk"].ToString();
                userInfo.Hris_mentor_id = dtUser.Rows[0]["u_hris_mentor_id_fk"].ToString();
                userInfo.Alternate_mentor_id = dtUser.Rows[0]["u_hris_alternate_mentor_id_fk"].ToString();

                //text

                userInfo.Hris_manager_text = dtUser.Rows[0]["u_hris_manager"].ToString();
                userInfo.Hris_supervisor_text = dtUser.Rows[0]["u_hris_supervisor"].ToString();
                userInfo.Hris_Alternate_manager_text = dtUser.Rows[0]["u_hris_alternate_manager"].ToString();
                userInfo.Hris_alternate_supervisor_text = dtUser.Rows[0]["u_hris_alternate_supervisor"].ToString();
                userInfo.Hris_mentor_text = dtUser.Rows[0]["u_hris_mentor"].ToString();
                userInfo.Alternate_mentor_text = dtUser.Rows[0]["u_hris_alternate_mentor"].ToString();
                //End

                userInfo.text_sr_is_employee = dtUser.Rows[0]["u_retire_sr_is_employee"].ToString();
                userInfo.text_sr_is_manager = dtUser.Rows[0]["u_retire_sr_is_manager"].ToString();
                userInfo.text_sr_is_compliance = dtUser.Rows[0]["u_retire_sr_is_compliance"].ToString();
                userInfo.text_sr_is_instructor = dtUser.Rows[0]["u_retire_sr_is_instructor"].ToString();
                userInfo.text_sr_is_training = dtUser.Rows[0]["u_retire_sr_is_training"].ToString();
                userInfo.text_sr_is_administrator = dtUser.Rows[0]["u_retire_sr_is_administrator"].ToString();
                userInfo.text_sr_is_system_admin = dtUser.Rows[0]["u_retire_sr_is_system_admin"].ToString();
                //userInfo.text_sr_is_compliance_approver_text = Convert.ToBoolean(dtUser.Rows[0]["u_retire_sr_is_compliance_approver"]);

                userInfo.Custom_01 = dtUser.Rows[0]["u_custom_01"].ToString();
                userInfo.Custom_02 = dtUser.Rows[0]["u_custom_02"].ToString();
                userInfo.Custom_03 = dtUser.Rows[0]["u_custom_03"].ToString();
                userInfo.Custom_04 = dtUser.Rows[0]["u_custom_04"].ToString();
                userInfo.Custom_05 = dtUser.Rows[0]["u_custom_05"].ToString();
                userInfo.Custom_06 = dtUser.Rows[0]["u_custom_06"].ToString();
                userInfo.Custom_07 = dtUser.Rows[0]["u_custom_07"].ToString();
                userInfo.Custom_08 = dtUser.Rows[0]["u_custom_08"].ToString();
                userInfo.Custom_09 = dtUser.Rows[0]["u_custom_09"].ToString();
                userInfo.Custom_10 = dtUser.Rows[0]["u_custom_10"].ToString();
                userInfo.Custom_11 = dtUser.Rows[0]["u_custom_11"].ToString();
                userInfo.Custom_12 = dtUser.Rows[0]["u_custom_12"].ToString();
                userInfo.Custom_13 = dtUser.Rows[0]["u_custom_13"].ToString();
                // userInfo.LastPassword_enc = rijndaelKey.Encrypt(txtPassword_login.Text);
                userInfo.u_hris_is_rehire = Convert.ToBoolean(dtUser.Rows[0]["u_hris_is_rehire"]);
                userInfo.u_hris_is_rehire_text = dtUser.Rows[0]["u_hris_is_rehire_text"].ToString();
                return userInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateUserRetire(User retire)
        {
            Hashtable htUpdateUserRetire = new Hashtable();
            htUpdateUserRetire.Add("@u_user_id_pk", retire.Userid);
            htUpdateUserRetire.Add("@u_active_status_flag", retire.Active_status_flag);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_user_to_retire", htUpdateUserRetire);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static User GetDateTime(User datetime)
        {
            Hashtable htDateTime = new Hashtable();
            htDateTime.Add("@UTCDate", datetime.utcdatetime);
            htDateTime.Add("@LocalDate", datetime.localdatetime);
            try
            {
                User userUtcDateTime = new User();
                DataTable dtUserUtcdatetime = DataProxy.FetchDataTable("app_convert_gmt_to_local_time", htDateTime);
                userUtcDateTime.converted_date_time = dtUserUtcdatetime.Rows[0]["Localtime"].ToString();
                return userUtcDateTime;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetMobileType(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetMobileType = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetMobileType.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetMobileType.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetMobileType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_mobile_type", htGetMobileType);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetCarrierType(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetCarrierType = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetCarrierType.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetCarrierType.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetCarrierType.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_mobile_carrier_type", htGetCarrierType);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetEmployeeType(string s_locale)
        {
            try
            {
                Hashtable htGetEmployeeType = new Hashtable();
                if (!string.IsNullOrEmpty(s_locale))
                {
                    htGetEmployeeType.Add("@s_locale", s_locale);
                }
                else
                {
                    htGetEmployeeType.Add("@s_locale", DBNull.Value);
                }
                return DataProxy.FetchDataTable("s_sp_get_all_employee_type", htGetEmployeeType);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetCountrylist()
        {
            try
            {
                return DataProxy.FetchDataTable("u_sp_get_country");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUserStatusList(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetUserStatusList = new Hashtable();
                htGetUserStatusList.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetUserStatusList.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_user_status", htGetUserStatusList);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUserAllStatusList(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetUserAllStatusList = new Hashtable();
                htGetUserAllStatusList.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetUserAllStatusList.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_user_all_status", htGetUserAllStatusList);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetLocalelist()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_locale");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateLock(User user)
        {
            Hashtable htUpdateLock = new Hashtable();
            htUpdateLock.Add("@u_user_id_pk", user.Userid);
            htUpdateLock.Add("@u_is_active", user.u_is_active);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_user_lock", htUpdateLock);

            }

            catch (Exception)
            {
                throw;
            }
        }
        public static User GetUserLock(string u_username_enc)
        {
            Hashtable htGetUserLock = new Hashtable();
            htGetUserLock.Add("@u_username_enc", u_username_enc);

            User userInfo;

            try
            {
                userInfo = new User();
                DataTable dtUserLockStatus = DataProxy.FetchDataTable("u_sp_get_user_lock", htGetUserLock);
                if (dtUserLockStatus.Rows.Count > 0)
                {
                    userInfo.u_is_active = Convert.ToBoolean(dtUserLockStatus.Rows[0]["u_is_active"].ToString());
                    userInfo.Userid = dtUserLockStatus.Rows[0]["u_user_id_pk"].ToString();
                }
                return userInfo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static User GetUserSplash(string Userid)
        {
            Hashtable htGetUserSplash = new Hashtable();
            htGetUserSplash.Add("@u_user_id_pk", Userid);

            User userInfo;

            try
            {
                userInfo = new User();
                DataTable dtUserSplashStatus = DataProxy.FetchDataTable("u_sp_get_user_splash", htGetUserSplash);
                if (dtUserSplashStatus.Rows.Count > 0)
                {
                    userInfo.u_splash_display_flag = Convert.ToBoolean(dtUserSplashStatus.Rows[0]["u_splash_display_flag"].ToString());
                }
                return userInfo;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UpdateSplash(User user)
        {
            Hashtable htUpdateSplash = new Hashtable();
            htUpdateSplash.Add("@u_user_id_pk", user.Userid);
            htUpdateSplash.Add("@u_splash_display_flag", user.u_splash_display_flag);
            try
            {
                return DataProxy.FetchSPOutput("u_sp_update_user_splash", htUpdateSplash);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateUserProfile(User user)
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
            htUpdateUserInfo.Add("@u_profile_my_courses_collapse_pref", user.u_profile_my_courses_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_curricula_collapse_pref", user.u_profile_my_curricula_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_learning_history_collapse_pref", user.u_profile_my_learning_history_collapse_pref);
            if (user.u_profile_my_courses_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_courses_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_courses_records_display_pref", user.u_profile_my_courses_records_display_pref);
            }
            if (user.u_profile_my_curricula_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_curricula_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_curricula_records_display_pref", user.u_profile_my_curricula_records_display_pref);
            }
            if (user.u_profile_my_learning_history_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_learning_history_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_learning_history_records_display_pref", user.u_profile_my_learning_history_records_display_pref);
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
                return DataProxy.FetchSPOutput("u_sp_update_user_profile", htUpdateUserInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetExpandCollapse(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetExpandCollapse = new Hashtable();
                if (string.IsNullOrEmpty(s_ui_locale_name))
                {
                    htGetExpandCollapse.Add("@s_ui_locale_name", "us_english");
                }
                else
                {
                    htGetExpandCollapse.Add("@s_ui_locale_name", s_ui_locale_name);
                }
                htGetExpandCollapse.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("u_sp_get_expanded_collapsed", htGetExpandCollapse);
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static int ResetPassword(string u_user_id_pk, string u_password_enc_ash, string u_password_enc_salt)
        {
            try
            {
                Hashtable htResetPassword = new Hashtable();
                htResetPassword.Add("@u_user_id_pk", u_user_id_pk);
                htResetPassword.Add("@u_password_enc_ash", u_password_enc_ash);
                htResetPassword.Add("@u_password_enc_salt", u_password_enc_salt);
                return DataProxy.FetchSPOutput("u_sp_reset_password", htResetPassword);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //newly added functions 01 Feb

        public static DataTable GetComplianceApproverList()
        {
            try
            {
                return DataProxy.FetchDataTable("u_sp_get_compliance_approver");
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static User GetApprovalNameandEmail(string Userid)
        {
            Hashtable htGetApproverEmail = new Hashtable();
            htGetApproverEmail.Add("@u_user_id_pk", Userid);

            User approverInfo;

            try
            {
                approverInfo = new User();
                DataTable dtApproverInfo = DataProxy.FetchDataTable("u_sp_get_name_and_email", htGetApproverEmail);
                if (dtApproverInfo.Rows.Count > 0)
                {
                    approverInfo.Username = dtApproverInfo.Rows[0]["ApproverName"].ToString();
                    approverInfo.EmailId = dtApproverInfo.Rows[0]["u_email_address"].ToString();
                }
                return approverInfo;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UpdateUserProfile_System(User user)
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
            htUpdateUserInfo.Add("@u_profile_my_system_splashes_collapse_pref", user.u_profile_my_system_splashes_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_system_themes_collapse_pref", user.u_profile_my_system_themes_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_system_reports_collapse_pref", user.u_profile_my_system_reports_collapse_pref);

            if (user.u_profile_my_system_splashes_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_system_splashes_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_system_splashes_records_display_pref", user.u_profile_my_system_splashes_records_display_pref);
            }
            if (user.u_profile_my_system_themes_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_system_themes_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_system_themes_records_display_pref", user.u_profile_my_system_themes_records_display_pref);
            }
            if (user.u_profile_my_system_reports_records_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_system_reports_records_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_system_reports_records_display_pref", user.u_profile_my_system_reports_records_display_pref);
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
                return DataProxy.FetchSPOutput("u_sp_update_system_user_profile", htUpdateUserInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetUserPIN(string u_user_id_pk)
        {
            Hashtable htGetUserPIN = new Hashtable();
            htGetUserPIN.Add("@u_user_id_pk", u_user_id_pk);
            DataTable dtGetUserPIN = new DataTable();
            string user_pinNumber;
            try
            {
                dtGetUserPIN = DataProxy.FetchDataTable("s_sp_get_user_pin_number", htGetUserPIN);
                if (!string.IsNullOrEmpty(dtGetUserPIN.Rows[0]["u_user_esig_pin"].ToString()))
                {
                    user_pinNumber = dtGetUserPIN.Rows[0]["u_user_esig_pin"].ToString();
                    return user_pinNumber;
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Dynamic css 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static User GetCss(string user_id)
        {
            User usercss = new User();

            try
            {
                Hashtable htGetCss = new Hashtable();
                htGetCss.Add("@user_id", user_id);
                DataTable dt = DataProxy.FetchDataTable("app_sp_get_css",htGetCss);
                usercss.css = dt.Rows[0]["css"].ToString();
                usercss.popup_background = dt.Rows[0]["popup_background"].ToString();
                return usercss;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int MergeUser(string user1, string user2)
        {
            Hashtable htMergeUser = new Hashtable();
            htMergeUser.Add("@user1", user1);
            htMergeUser.Add("@user2", user2);
            try
            {
                return DataProxy.FetchSPOutput("", htMergeUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
