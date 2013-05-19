using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public class InstructorBLL
    {
        public static DataSet GetTodoRoasterReport(string userid_pk)
        {
            Hashtable htGetValues = new Hashtable();
            htGetValues.Add("@u_user_id_pk", userid_pk);
            try
            {
                return DataProxy.FetchDataSet("s_sp_get_todo_roaster_report", htGetValues);
            }

            catch (Exception)
            {
                throw;
            }
        }


        public static int UpdateUserProfile_Instructor(User user)
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
            htUpdateUserInfo.Add("@u_profile_my_inst_todos_collapse_pref", user.u_profile_my_inst_todos_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_inst_rosters_collapse_pref", user.u_profile_my_inst_rosters_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_inst_reports_collapse_pref", user.u_profile_my_inst_reports_collapse_pref);

            if (user.u_profile_my_inst_todos_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_inst_todos_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_inst_todos_display_pref", user.u_profile_my_inst_todos_display_pref);
            }
            if (user.u_profile_my_inst_rosters_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_inst_rosters_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_inst_rosters_display_pref", user.u_profile_my_inst_rosters_display_pref);
            }
            if (user.u_profile_my_inst_reports_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_inst_reports_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_inst_reports_display_pref", user.u_profile_my_inst_reports_display_pref);
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
                return DataProxy.FetchSPOutput("u_sp_update_instructor_user_profile", htUpdateUserInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetRoasterforPdfExcel(string u_user_id_pk, string s_locale_culture)
        {
            Hashtable htGetValues = new Hashtable();
            htGetValues.Add("@u_user_id_pk", u_user_id_pk);
            htGetValues.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("i_sp_get_roasters_pdf", htGetValues);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDeliveries(string u_user_id_pk)
        {
            Hashtable htGetDeliveries = new Hashtable();
            htGetDeliveries.Add("@u_user_id_pk", u_user_id_pk);

            try
            {
                return DataProxy.FetchDataTable("i_sp_get_deliveries", htGetDeliveries);
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static DataSet GetSession_Attachment_Enrollments(string c_delivery_id_fk)
        {
            Hashtable htGetDeliveries = new Hashtable();
            htGetDeliveries.Add("@c_delivery_id_fk", c_delivery_id_fk);

            try
            {
                return DataProxy.FetchDataSet("i_sp_get_delvery_session_attachment_enrolled", htGetDeliveries);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemCatalog GetDelivery(string c_delivery_system_id_pk)
        {
            SystemCatalog courseDelivery;

            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                Hashtable htGetCourseDelivery = new Hashtable();
                htGetCourseDelivery.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);
                courseDelivery = new SystemCatalog();
                DataTable dtGetCourseDelivery = DataProxy.FetchDataTable("i_sp_get_single_delivery", htGetCourseDelivery);

                courseDelivery.c_delivery_id_pk = dtGetCourseDelivery.Rows[0]["c_delivery_id_pk"].ToString();
                courseDelivery.c_delivery_type_id = dtGetCourseDelivery.Rows[0]["deliveryType"].ToString();
                courseDelivery.c_delivery_title = dtGetCourseDelivery.Rows[0]["c_delivery_title"].ToString();
                courseDelivery.c_delivery_desc = dtGetCourseDelivery.Rows[0]["c_delivery_desc"].ToString();
                courseDelivery.c_delivery_abstract = dtGetCourseDelivery.Rows[0]["c_delivery_abstract"].ToString();

                courseDelivery.c_delivery_approval_req_text = dtGetCourseDelivery.Rows[0]["c_delivery_approval_req_text"].ToString();

                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_credit_hours"].ToString()))
                {
                    courseDelivery.c_delivery_credit_hours = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_credit_hours"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_credit_units"].ToString()))
                {
                    courseDelivery.c_delivery_credit_units = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_credit_units"]);
                }
                //courseDelivery.c_delivery_owner_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_owner_id_fk"].ToString();
                //courseDelivery.c_delivery_coordinator_id_fk = dtGetCourseDelivery.Rows[0]["c_delivery_coordinator_id_fk"].ToString();

                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_min_enroll"].ToString()))
                {
                    courseDelivery.c_delivery_min_enroll = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_min_enroll"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourseDelivery.Rows[0]["c_delivery_max_enroll"].ToString()))
                {
                    courseDelivery.c_delivery_max_enroll = Convert.ToInt32(dtGetCourseDelivery.Rows[0]["c_delivery_max_enroll"]);
                }

                courseDelivery.c_delivery_custom_01 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_01"].ToString();
                courseDelivery.c_delivery_custom_02 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_02"].ToString();
                courseDelivery.c_delivery_custom_03 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_03"].ToString();
                courseDelivery.c_delivery_custom_04 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_04"].ToString();
                courseDelivery.c_delivery_custom_05 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_05"].ToString();
                courseDelivery.c_delivery_custom_06 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_06"].ToString();
                courseDelivery.c_delivery_custom_07 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_07"].ToString();
                courseDelivery.c_delivery_custom_08 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_08"].ToString();
                courseDelivery.c_delivery_custom_09 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_09"].ToString();
                courseDelivery.c_delivery_custom_10 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_10"].ToString();
                courseDelivery.c_delivery_custom_11 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_11"].ToString();
                courseDelivery.c_delivery_custom_12 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_12"].ToString();
                courseDelivery.c_delivery_custom_13 = dtGetCourseDelivery.Rows[0]["c_delivery_custom_13"].ToString();
                courseDelivery.c_delivery_owner_name = dtGetCourseDelivery.Rows[0]["c_delivery_owner_name"].ToString();
                courseDelivery.c_delivery_coordinator_name = dtGetCourseDelivery.Rows[0]["c_delivery_coordinator_name"].ToString();
                courseDelivery.c_waitlist_count = dtGetCourseDelivery.Rows[0]["waitlistcount"].ToString();
                courseDelivery.c_enroll_delivery_count = dtGetCourseDelivery.Rows[0]["c_enroll_delivery_count"].ToString();
                courseDelivery.c_session_location_name = dtGetCourseDelivery.Rows[0]["c_location_name"].ToString();
                courseDelivery.c_location_airport_code = dtGetCourseDelivery.Rows[0]["c_location_airport_code"].ToString();
                return courseDelivery;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetSessionForPdf(string c_delivery_id_fk, string s_locale_culture)
        {
            Hashtable htGetSession = new Hashtable();
            htGetSession.Add("@c_delivery_id_fk", c_delivery_id_fk);
            htGetSession.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataTable("i_sp_get_session_pdf", htGetSession);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetEnrolledUserForPdf(string c_delivery_id_fk, string s_locale_culture)
        {
            Hashtable htGetEnrolledUser = new Hashtable();
            htGetEnrolledUser.Add("@c_delivery_id_fk", c_delivery_id_fk);
            htGetEnrolledUser.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataTable("i_sp_enrolled_user_pdf", htGetEnrolledUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetCalendarDetails_pdf(DateTime startdate, string u_user_id_pk)
        {
            Hashtable htGetCalendarDetails = new Hashtable();
            htGetCalendarDetails.Add("@Selected_Start_Date", startdate);
            //htGetCalendarDetails.Add("@EndDate", enddate);
            htGetCalendarDetails.Add("@u_user_id_pk", u_user_id_pk);
            try
            {
                return DataProxy.FetchDataTable("i_sp_get_calendar_pdf", htGetCalendarDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
