using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class TrainingBLL
    {
        /// <summary>
        /// Get Todo, Deliveries,Report.
        /// </summary>
        /// <param name="s_user_id_fk"></param>
        /// <returns></returns>
        public static DataSet GetTodoDeliveriesReport(string s_user_id_fk)
        {
            try
            {
                Hashtable htGetTodoDeliveriesReport = new Hashtable();
                htGetTodoDeliveriesReport.Add("@s_user_id_fk", s_user_id_fk);
                return DataProxy.FetchDataSet("t_sp_get_todo_deliveries_report", htGetTodoDeliveriesReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateUserProfile_Trainng(User user)
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

            htUpdateUserInfo.Add("@u_profile_my_train_todos_collapse_pref", user.u_profile_my_train_todos_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_train_deliveries_collapse_pref", user.u_profile_my_train_deliveries_collapse_pref);
            htUpdateUserInfo.Add("@u_profile_my_train_reports_collapse_pref", user.u_profile_my_train_reports_collapse_pref);


            if (user.u_profile_my_train_todos_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_train_todos_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_train_todos_display_pref", user.u_profile_my_train_todos_display_pref);
            }
            if (user.u_profile_my_train_deliveries_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_train_deliveries_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_train_deliveries_display_pref", user.u_profile_my_train_deliveries_display_pref);
            }
            if (user.u_profile_my_train_reports_display_pref == 0)
            {
                htUpdateUserInfo.Add("@u_profile_my_train_reports_display_pref", DBNull.Value);
            }
            else
            {
                htUpdateUserInfo.Add("@u_profile_my_train_reports_display_pref", user.u_profile_my_train_reports_display_pref);
            }

            //htUpdateUserInfo.Add("@type", user.type);
            try
            {
                return DataProxy.FetchSPOutput("t_sp_update_training_user_profile", htUpdateUserInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static DataTable GetDeliveriesByCourseid(string c_course_id_fk)
        {
            try
            {
                Hashtable htGetDeliveriesByCourseid = new Hashtable();
                htGetDeliveriesByCourseid.Add("@c_course_id_fk", c_course_id_fk);
                return DataProxy.FetchDataTable("t_sp_get_deliveries_by_course_id", htGetDeliveriesByCourseid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int CopyDelivery(string c_delivery_system_id_pk, string c_course_id_fk, string newDeliveryId)
        {
            try
            {
                Hashtable htCopyDelivery = new Hashtable();
                htCopyDelivery.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);
                htCopyDelivery.Add("@c_course_id_fk", c_course_id_fk);
                htCopyDelivery.Add("@newDeliveryId", newDeliveryId);
                return DataProxy.FetchSPOutput("t_sp_copy_delivery", htCopyDelivery);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetDeliveriesPdf(string c_course_id_fk, string s_locale_culture)
        {

            Hashtable htGetDeliveriesPdf = new Hashtable();
            htGetDeliveriesPdf.Add("@c_course_id_fk", c_course_id_fk);
            htGetDeliveriesPdf.Add("@s_locale_culture", s_locale_culture);
            try
            {
                return DataProxy.FetchDataSet("t_sp_create_deliveries_pdf", htGetDeliveriesPdf);
            }
            catch (Exception)
            {
                throw;
            }

        }
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

        public static DataTable SearchMyCourse(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@u_user_id_pk", catalog.c_course_coordinator_id_fk);

            htSearchCourse.Add("@c_course_title", catalog.c_course_title);

            htSearchCourse.Add("@c_delivery_id_pk", catalog.c_delivery_id_pk);

            if (!string.IsNullOrEmpty(catalog.c_session_start_date.ToString()))
            {
                htSearchCourse.Add("@c_session_start_date", catalog.c_session_start_date);
            }
            else
            {
                htSearchCourse.Add("@c_session_start_date", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(catalog.c_session_end_date.ToString()))
            {
                htSearchCourse.Add("@c_session_end_date", catalog.c_session_end_date);
            }
            else
            {
                htSearchCourse.Add("@c_session_end_date", DBNull.Value);
            }

            if (catalog.c_delivery_type_id_fk == "app_ddl_all_text")
                htSearchCourse.Add("@c_delivery_type_id_fk", DBNull.Value);
            else
                htSearchCourse.Add("@c_delivery_type_id_fk", catalog.c_delivery_type_id_fk);

            try
            {
                return DataProxy.FetchDataTable("t_sp_search_course_delivery", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchSystemCatalog(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            htSearchCourse.Add("@c_course_version", catalog.c_course_version);
            htSearchCourse.Add("@c_course_coordinator_id_fk", catalog.c_course_coordinator_id_fk);

            if (catalog.c_course_active_type_id_fk == "0")
                htSearchCourse.Add("@c_course_active_type_id_fk", DBNull.Value);
            else
                htSearchCourse.Add("@c_course_active_type_id_fk", catalog.c_course_active_type_id_fk);

            htSearchCourse.Add("@c_course_owner_name", catalog.c_course_owner_name);
            htSearchCourse.Add("@c_course_coordinator_name", catalog.c_course_coordinator_name);
            try
            {
                return DataProxy.FetchDataTable("c_sp_search_training_course", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet GetCoursePdf(SystemCatalog catalog,string PdfExcel)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@u_user_id_pk", catalog.c_course_coordinator_id_fk);

            htSearchCourse.Add("@c_course_title", catalog.c_course_title);

            htSearchCourse.Add("@c_delivery_id_pk", catalog.c_delivery_id_pk);

            if (!string.IsNullOrEmpty(catalog.c_session_start_date.ToString()))
            {
                htSearchCourse.Add("@c_session_start_date", catalog.c_session_start_date);
            }
            else
            {
                htSearchCourse.Add("@c_session_start_date", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(catalog.c_session_end_date.ToString()))
            {
                htSearchCourse.Add("@c_session_end_date", catalog.c_session_end_date);
            }
            else
            {
                htSearchCourse.Add("@c_session_end_date", DBNull.Value);
            }

            if (catalog.c_delivery_type_id_fk == "app_ddl_all_text")
            {
                htSearchCourse.Add("@c_delivery_type_id_fk", DBNull.Value);
            }
            else
            {
                htSearchCourse.Add("@c_delivery_type_id_fk", catalog.c_delivery_type_id_fk);
            }
            htSearchCourse.Add("@s_locale_culture", catalog.s_locale_culture);
            if (PdfExcel == "pdf")
            {

                try
                {
                    return DataProxy.FetchDataSet("t_sp_search_course_pdf", htSearchCourse);
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    return DataProxy.FetchDataSet("t_sp_search_course_excel", htSearchCourse);
                }

                catch (Exception)
                {
                    throw;
                }
            }


        }
        
    }
    
}
