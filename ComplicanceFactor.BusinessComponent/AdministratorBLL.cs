using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class AdministratorBLL
    {
        public static DataSet GetCourseTeamReport(string s_user_id_fk)
        {
            try
            {
                Hashtable htGetCourseTeamReport = new Hashtable();
                htGetCourseTeamReport.Add("@s_user_id_fk", s_user_id_fk);
                return DataProxy.FetchDataSet("a_sp_get_course_todo_report", htGetCourseTeamReport);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateUserProfile_Admin(User user)
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
            htUpdateUserInfo.Add("@u_profile_my_admin_todos_collapse_pref", user.u_profile_my_admin_todos_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_amdin_courses_collapse_pref", user.u_profile_my_amdin_courses_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_admin_reports_collapse_pref", user.u_profile_my_admin_reports_collapse_pref);


            if (user.u_profile_my_admin_todos_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_admin_todos_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_admin_todos_display_pref", user.u_profile_my_admin_todos_display_pref);
            }
            if (user.u_profile_my_admin_courses_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_admin_courses_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_admin_courses_display_pref", user.u_profile_my_admin_courses_display_pref);
            }
            if (user.u_profile_my_admin_reports_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_admin_reports_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_admin_reports_display_pref", user.u_profile_my_system_reports_records_display_pref);
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
                return DataProxy.FetchSPOutput("u_sp_update_admin_user_profile", htUpdateUserInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetDelivery(string u_user_id_pk, string s_locale_culture)
        {
            Hashtable htGetDelivery = new Hashtable();
            htGetDelivery.Add("@u_user_id_pk", u_user_id_pk);
            htGetDelivery.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("s_sp_get_delivery_for_admin", htGetDelivery);
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static DataTable SearchMyCourseAdmin(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@s_user_id_fk", catalog.c_course_coordinator_id_fk);

            htSearchCourse.Add("@c_course_title", catalog.c_course_title);

            //htSearchCourse.Add("@c_delivery_id_pk", catalog.c_delivery_id_pk);

            if (!string.IsNullOrEmpty(catalog.c_session_start_date.ToString()))
            {
                htSearchCourse.Add("@c_from_date", catalog.c_session_start_date);
            }
            else
            {
                htSearchCourse.Add("@c_from_date", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(catalog.c_session_end_date.ToString()))
            {
                htSearchCourse.Add("@c_to_date", catalog.c_session_end_date);
            }
            else
            {
                htSearchCourse.Add("@c_to_date", DBNull.Value);
            }

            if (catalog.c_delivery_type_id_fk == "app_ddl_all_text")
                htSearchCourse.Add("@c_delivery_type", DBNull.Value);
            else
                htSearchCourse.Add("@c_delivery_type", catalog.c_delivery_type_id_fk);

            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);

            try
            {
                return DataProxy.FetchDataTable("a_sp_search_course", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetCoursePdf(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();

            htSearchCourse.Add("@s_user_id_fk", catalog.c_course_coordinator_id_fk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            htSearchCourse.Add("@s_locale_culture", catalog.s_locale_culture);
            //htSearchCourse.Add("@c_delivery_id_pk", catalog.c_delivery_id_pk);
            if (!string.IsNullOrEmpty(catalog.c_session_start_date.ToString()))
            {
                htSearchCourse.Add("@c_from_date", catalog.c_session_start_date);
            }
            else
            {
                htSearchCourse.Add("@c_from_date", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(catalog.c_session_end_date.ToString()))
            {
                htSearchCourse.Add("@c_to_date", catalog.c_session_end_date);
            }
            else
            {
                htSearchCourse.Add("@c_to_date", DBNull.Value);
            }
            if (catalog.c_delivery_type_id_fk == "app_ddl_all_text")
                htSearchCourse.Add("@c_delivery_type", DBNull.Value);
            else
                htSearchCourse.Add("@c_delivery_type", catalog.c_delivery_type_id_fk);
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            try
            {
                return DataProxy.FetchDataSet("a_sp_search_course_pdf", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public static DataSet GetCourseExcel(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();

            htSearchCourse.Add("@s_user_id_fk", catalog.c_course_coordinator_id_fk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            htSearchCourse.Add("@s_locale_culture", catalog.s_locale_culture);
            //htSearchCourse.Add("@c_delivery_id_pk", catalog.c_delivery_id_pk);
            if (!string.IsNullOrEmpty(catalog.c_session_start_date.ToString()))
            {
                htSearchCourse.Add("@c_from_date", catalog.c_session_start_date);
            }
            else
            {
                htSearchCourse.Add("@c_from_date", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(catalog.c_session_end_date.ToString()))
            {
                htSearchCourse.Add("@c_to_date", catalog.c_session_end_date);
            }
            else
            {
                htSearchCourse.Add("@c_to_date", DBNull.Value);
            }
            if (catalog.c_delivery_type_id_fk == "app_ddl_all_text")
                htSearchCourse.Add("@c_delivery_type", DBNull.Value);
            else
                htSearchCourse.Add("@c_delivery_type", catalog.c_delivery_type_id_fk);
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            try
            {
                return DataProxy.FetchDataSet("a_sp_search_course_excel", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
