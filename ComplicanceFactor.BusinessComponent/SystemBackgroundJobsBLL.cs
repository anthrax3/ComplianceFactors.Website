using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public  class SystemBackgroundJobsBLL
    {
        public static DataTable GetBackgroundJobs()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_background_jobs");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleHRIS(string hrisId)
        {
            Hashtable htGetSingleHris = new Hashtable();
            htGetSingleHris.Add("@u_sftp_id_pk", hrisId);

            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            DataTable dtSingleHris = new DataTable();
            try
            {
                dtSingleHris = DataProxy.FetchDataTable("s_sp_get_single_HRIS", htGetSingleHris);
                if (dtSingleHris.Rows.Count > 0)
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

                return hrisIntegration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateHRIS(SystemHRISIntegration createHRIS)
        {

            Hashtable htUpdateHRIS = new Hashtable();
            htUpdateHRIS.Add("@u_sftp_id_pk", createHRIS.u_sftp_id_pk);
            htUpdateHRIS.Add("@u_sftp_URI", createHRIS.u_sftp_URI);
            htUpdateHRIS.Add("@u_sftp_port", createHRIS.u_sftp_port);
            htUpdateHRIS.Add("@u_sftp_username", createHRIS.u_sftp_username);
            htUpdateHRIS.Add("@u_sftp_password", createHRIS.u_sftp_password);
            htUpdateHRIS.Add("@u_sftp_hris_filename", createHRIS.u_sftp_hris_filename);
            htUpdateHRIS.Add("@u_sftp_occurs_every", createHRIS.u_sftp_occurs_every);
            htUpdateHRIS.Add("@u_sftp_time_every", createHRIS.u_sftp_time_every);
            htUpdateHRIS.Add("@u_sftp_start_date", createHRIS.u_sftp_start_date);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_sftp_info", htUpdateHRIS);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleDataImport(string u_sftp_id_pk)
        {
            Hashtable htGetSingleDataImport = new Hashtable();
            htGetSingleDataImport.Add("@u_sftp_id_pk", u_sftp_id_pk);

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            DataTable dtSingleDataImport = new DataTable();
            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_single_data_import", htGetSingleDataImport);
                if (dtSingleDataImport.Rows.Count > 0)
                {                    
                    dataImport.u_sftp_URI = dtSingleDataImport.Rows[0]["u_sftp_URI"].ToString();
                    dataImport.u_sftp_port = dtSingleDataImport.Rows[0]["u_sftp_port"].ToString();
                    dataImport.u_sftp_username = dtSingleDataImport.Rows[0]["u_sftp_username"].ToString();
                    dataImport.u_sftp_password = dtSingleDataImport.Rows[0]["u_sftp_password"].ToString();
                    dataImport.u_sftp_imp_is_enrollment = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_imp_is_enrollment"]);
                    dataImport.u_sftp_imp_enrollment_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_enrollment_filename"].ToString();
                    dataImport.u_sftp_imp_is_learning_history = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_imp_is_learning_history"]);
                    dataImport.u_sftp_imp_learning_history_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_learning_history_filename"].ToString();
                    dataImport.u_sftp_imp_facility_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_facility_filename"].ToString();
                    dataImport.u_sftp_imp_room_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_room_filename"].ToString();
                    dataImport.u_sftp_imp_course_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_course_filename"].ToString();
                    dataImport.u_sftp_imp_base_curricula_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_base_curricula_filename"].ToString();
                    dataImport.u_sftp_occurs_every = dtSingleDataImport.Rows[0]["u_sftp_occurs_every"].ToString();
                    dataImport.u_sftp_time_every = dtSingleDataImport.Rows[0]["u_sftp_time_every"].ToString();
                    dataImport.u_sftp_start_date = dtSingleDataImport.Rows[0]["u_sftp_start_date"].ToString();
                }

                return dataImport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleDataExport(string u_sftp_id_pk)
        {
            Hashtable htGetSingleDataExport = new Hashtable();
            htGetSingleDataExport.Add("@u_sftp_id_pk", u_sftp_id_pk);

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            DataTable dtSingleDataImport = new DataTable();
            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_single_data_export", htGetSingleDataExport);
                if (dtSingleDataImport.Rows.Count > 0)
                {
                     
                    dataImport.u_sftp_URI = dtSingleDataImport.Rows[0]["u_sftp_URI"].ToString();
                    dataImport.u_sftp_port = dtSingleDataImport.Rows[0]["u_sftp_port"].ToString();
                    dataImport.u_sftp_username = dtSingleDataImport.Rows[0]["u_sftp_username"].ToString();
                    dataImport.u_sftp_password = dtSingleDataImport.Rows[0]["u_sftp_password"].ToString();

                    dataImport.u_sftp_exp_is_hris = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_hris"]);
                    dataImport.u_sftp_exp_hris_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_hris_filename"].ToString();
                    dataImport.u_sftp_exp_is_catalog_offering = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_catalog_offering"]);
                    dataImport.u_sftp_exp_catalog_offering_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_catalog_offering_filename"].ToString();
                    dataImport.u_sftp_exp_is_learning_history = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_learning_history"]);
                    dataImport.u_sftp_exp_learning_history_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_learning_history_filename"].ToString();

                    dataImport.u_sftp_occurs_every = dtSingleDataImport.Rows[0]["u_sftp_occurs_every"].ToString();
                    dataImport.u_sftp_time_every = dtSingleDataImport.Rows[0]["u_sftp_time_every"].ToString();
                    dataImport.u_sftp_start_date = dtSingleDataImport.Rows[0]["u_sftp_start_date"].ToString();
                }

                return dataImport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBackgroundInformation(string currntTime, string currentDate)
        {
            Hashtable htGetBackground = new Hashtable();
            htGetBackground.Add("@u_sftp_time_every", currntTime);
            htGetBackground.Add("@u_sftp_start_date", currentDate);

            try
            {
                return DataProxy.FetchDataTable("s_sp_get_for_background_information", htGetBackground);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateNewFacility(SystemFacility createFacility)
        {
            Hashtable htcreateFacility = new Hashtable();            
            htcreateFacility.Add("@c_facility_id_pk", createFacility.s_facility_id_pk);
            htcreateFacility.Add("@c_facility_name", createFacility.s_facility_name);
            htcreateFacility.Add("@c_facility_desc", createFacility.s_facility_desc);
            htcreateFacility.Add("@c_facility_status_id_fk", createFacility.s_facility_status_id_fk);
            htcreateFacility.Add("@c_facility_type_id_fk", createFacility.s_facility_type_id_fk);
            htcreateFacility.Add("@c_facility_contact", createFacility.s_facility_contact);
            htcreateFacility.Add("@c_facility_email_address", createFacility.s_facility_email_address);
            htcreateFacility.Add("@c_facility_phone", createFacility.s_facility_phone);
            htcreateFacility.Add("@c_facility_address", createFacility.s_facility_address);
            htcreateFacility.Add("@c_facility_address1", createFacility.s_facility_address1);
            htcreateFacility.Add("@c_facility_address2", createFacility.s_facility_address2);
            htcreateFacility.Add("@c_facility_city", createFacility.s_facility_city);
            htcreateFacility.Add("@c_facility_state", createFacility.s_facility_state);
            htcreateFacility.Add("@c_facility_zip_code", createFacility.s_facility_zip_code);
            htcreateFacility.Add("@c_facility_country_id_fk", createFacility.s_facility_country_id_fk);
            htcreateFacility.Add("@c_facility_locale_id_fk", createFacility.s_facility_locale_id_fk);
            htcreateFacility.Add("@c_facility_time_zone_id_fk", createFacility.s_facility_time_zone_id_fk);
            
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_facility_background", htcreateFacility);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateNewRoom(SystemRoom createRoom)
        {
            Hashtable htcreateRoom = new Hashtable();
            
            htcreateRoom.Add("@c_room_id_pk", createRoom.s_room_id_pk);
            htcreateRoom.Add("@c_room_name", createRoom.s_room_name);
            htcreateRoom.Add("@c_room_desc", createRoom.s_room_desc);
            htcreateRoom.Add("@c_room_status_id_fk", createRoom.s_room_status_id_fk);
            htcreateRoom.Add("@c_room_type_id_fk", createRoom.s_room_type_id_fk);
            htcreateRoom.Add("@c_room_facility_id_fk", createRoom.s_room_facility_id_fk);             
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_room_for_background", htcreateRoom);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateCourse(SystemCatalog course)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Hashtable htNewCourse = new Hashtable();
            htNewCourse.Add("@c_course_id_pk", course.c_course_id_pk);
            htNewCourse.Add("@c_course_desc", course.c_course_desc);
            htNewCourse.Add("@c_course_abstract", course.c_course_abstract);
            htNewCourse.Add("@c_course_icon_uri", course.c_course_icon_uri);
            htNewCourse.Add("@c_course_version", course.c_course_version);
            htNewCourse.Add("@c_course_approval_req", course.c_course_approval_req);

            if (!string.IsNullOrEmpty(course.c_course_approval_id_fk))
            {
                htNewCourse.Add("@c_course_approval_id_fk", course.c_course_approval_id_fk);
            }
            else
            {
                htNewCourse.Add("@c_course_approval_id_fk", DBNull.Value);
            }
            if (course.c_course_credit_hours != null)
            {
                htNewCourse.Add("@c_course_credit_hours", course.c_course_credit_hours);
            }
            else
            {
                htNewCourse.Add("@c_course_credit_hours", DBNull.Value);
            }
            if (course.c_course_credit_units != null)
            {
                htNewCourse.Add("@c_course_credit_units", course.c_course_credit_units);
            }
            else
            {
                htNewCourse.Add("@c_course_credit_units", DBNull.Value);
            }

            htNewCourse.Add("@c_course_cert_flag", course.c_course_cert_flag);

            //if (course.c_course_cert_cycle_days != null)
            //{
            //    htNewCourse.Add("@c_course_cert_cycle_days", course.c_course_cert_cycle_days);
            //}
            //else
            //{
            //    htNewCourse.Add("@c_course_cert_cycle_days", DBNull.Value);
            //}
            if (course.c_course_recurrence_grace_days != null)
            {
                htNewCourse.Add("@c_course_recurrence_grace_days", course.c_course_recurrence_grace_days);
            }
            else
            {
                htNewCourse.Add("@c_course_recurrence_grace_days", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(course.c_course_owner_id_fk))
            {
                htNewCourse.Add("@c_course_owner_id_fk", course.c_course_owner_id_fk);
            }
            else
            {
                htNewCourse.Add("@c_course_owner_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(course.c_course_coordinator_id_fk))
            {
                htNewCourse.Add("@c_course_coordinator_id_fk", course.c_course_coordinator_id_fk);
            }
            else
            {
                htNewCourse.Add("@c_course_coordinator_id_fk", DBNull.Value);
            }
            htNewCourse.Add("@c_course_active_flag", course.c_course_active_flag);
            //htNewCourse.Add("@c_course_active_type_id_fk", course.c_course_active_type_id_fk);
            htNewCourse.Add("@c_course_visible_flag", course.c_course_visible_flag);
            htNewCourse.Add("@c_course_custom_01", course.c_course_custom_01);
            htNewCourse.Add("@c_course_custom_02", course.c_course_custom_02);
            htNewCourse.Add("@c_course_custom_03", course.c_course_custom_03);
            htNewCourse.Add("@c_course_custom_04", course.c_course_custom_04);
            htNewCourse.Add("@c_course_custom_05", course.c_course_custom_05);
            htNewCourse.Add("@c_course_custom_06", course.c_course_custom_06);
            htNewCourse.Add("@c_course_custom_07", course.c_course_custom_07);
            htNewCourse.Add("@c_course_custom_08", course.c_course_custom_08);
            htNewCourse.Add("@c_course_custom_09", course.c_course_custom_09);
            htNewCourse.Add("@c_course_custom_10", course.c_course_custom_10);
            htNewCourse.Add("@c_course_custom_11", course.c_course_custom_11);
            htNewCourse.Add("@c_course_custom_12", course.c_course_custom_12);
            htNewCourse.Add("@c_course_custom_13", course.c_course_custom_13);
            htNewCourse.Add("@c_course_title", course.c_course_title);
            //htNewCourse.Add("@c_course_system_id_pk", course.c_course_system_id_pk);

            //htNewCourse.Add("@c_cource_prerequisite", course.c_course_Prerequistist);
            //htNewCourse.Add("@c_cource_equivalencies", course.c_course_Equivalencies);
            //htNewCourse.Add("@c_cource_fulfillments", course.c_course_Fulfillments);
            //htNewCourse.Add("@c_cource_domains", course.c_course_domains);
            //htNewCourse.Add("@c_course_category", course.c_course_category);
            if (course.c_course_recurrence_every != null)
            {
                htNewCourse.Add("@c_course_recurrence_every", course.c_course_recurrence_every);
            }
            else
            {
                htNewCourse.Add("@c_course_recurrence_every", DBNull.Value);
            }
            htNewCourse.Add("@c_course_recurrence_period", course.c_course_recurrence_period);
            htNewCourse.Add("@c_course_recurrence_date_option", course.c_course_recurrence_date_option);
            //htNewCourse.Add("@c_course_icon_uri_file_name", course.c_course_icon_uri_file_name);

            if (course.c_course_recurrence_date != null)
            {
                htNewCourse.Add("@c_course_recurrence_date", course.c_course_recurrence_date);
            }
            else
            {
                htNewCourse.Add("@c_course_recurrence_date", DBNull.Value);
            }
            //if (course.c_course_cert_date != null)
            //{
            //    htNewCourse.Add("@c_course_cert_date", course.c_course_cert_date);
            //}
            //else
            //{
            //    htNewCourse.Add("@c_course_cert_date", DBNull.Value);
            //}
            if (course.c_course_cost != null)
            {
                htNewCourse.Add("@c_course_cost", course.c_course_cost);
            }
            else
            {
                htNewCourse.Add("@c_course_cost", DBNull.Value);
            }
            //htNewCourse.Add("@c_course_created_by_id_fk", course.c_course_created_by_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("c_insert_course_for_background", htNewCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateCurriculum(SystemCurriculum curriculum)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Hashtable htNewCurriculum = new Hashtable();
            //htNewCurriculum.Add("@c_curriculum_system_id_pk", curriculum.c_curriculum_system_id_pk);
            htNewCurriculum.Add("@c_curriculum_id_pk", curriculum.c_curriculum_id_pk);
            htNewCurriculum.Add("@c_curriculum_title", curriculum.c_curriculum_title);
            htNewCurriculum.Add("@c_curriculum_desc", curriculum.c_curriculum_desc);
            htNewCurriculum.Add("@c_curriculum_abstract", curriculum.c_curriculum_abstract);
            htNewCurriculum.Add("@c_curriculum_icon_uri", curriculum.c_curriculum_icon_uri);
            //htNewCurriculum.Add("@c_curriculum_icon_uri_file_name", curriculum.c_curriculum_icon_uri_file_name);
            htNewCurriculum.Add("@c_curriculum_version", curriculum.c_curriculum_version);
            htNewCurriculum.Add("@c_curriculum_approval_req", curriculum.c_curriculum_approval_req);

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_approval_id_fk))
            {
                htNewCurriculum.Add("@c_curriculum_approval_id_fk", curriculum.c_curriculum_approval_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_approval_id_fk", DBNull.Value);
            }
            if (curriculum.c_curriculum_credit_hours != null)
            {
                htNewCurriculum.Add("@c_curriculum_credit_hours", curriculum.c_curriculum_credit_hours);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_credit_hours", DBNull.Value);
            }
            if (curriculum.c_curriculum_credit_units != null)
            {
                htNewCurriculum.Add("@c_curriculum_credit_units", curriculum.c_curriculum_credit_units);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_credit_units", DBNull.Value);
            }
            //htNewCurriculum.Add("@c_curriculum_created_by_id_fk", curriculum.c_curriculum_created_by_id_fk);
            htNewCurriculum.Add("@c_curriculum_cert_flag", curriculum.c_curriculum_cert_flag);

            if (curriculum.c_curriculum_recurrance_grace_days != null)
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_grace_days", curriculum.c_curriculum_recurrance_grace_days);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_grace_days", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_owner_id_fk))
            {
                htNewCurriculum.Add("@c_curriculum_owner_id_fk", curriculum.c_curriculum_owner_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_owner_id_fk", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(curriculum.c_curriculum_coordinator_id_fk))
            {
                htNewCurriculum.Add("@c_curriculum_coordinator_id_fk", curriculum.c_curriculum_coordinator_id_fk);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_coordinator_id_fk", DBNull.Value);
            }

            htNewCurriculum.Add("@c_curriculum_active_flag", curriculum.c_curriculum_active_flag);
            //htNewCurriculum.Add("@c_curriculum_active_type_id_fk", curriculum.c_curriculum_active_type_id_fk);
            htNewCurriculum.Add("@c_curriculum_visible_flag", curriculum.c_curriculum_visible_flag);
            htNewCurriculum.Add("@c_curriculum_custom_01", curriculum.c_curriculum_custom_01);
            htNewCurriculum.Add("@c_curriculum_custom_02", curriculum.c_curriculum_custom_02);
            htNewCurriculum.Add("@c_curriculum_custom_03", curriculum.c_curriculum_custom_03);
            htNewCurriculum.Add("@c_curriculum_custom_04", curriculum.c_curriculum_custom_04);
            htNewCurriculum.Add("@c_curriculum_custom_05", curriculum.c_curriculum_custom_05);
            htNewCurriculum.Add("@c_curriculum_custom_06", curriculum.c_curriculum_custom_06);
            htNewCurriculum.Add("@c_curriculum_custom_07", curriculum.c_curriculum_custom_07);
            htNewCurriculum.Add("@c_curriculum_custom_08", curriculum.c_curriculum_custom_08);
            htNewCurriculum.Add("@c_curriculum_custom_09", curriculum.c_curriculum_custom_09);
            htNewCurriculum.Add("@c_curriculum_custom_10", curriculum.c_curriculum_custom_10);
            htNewCurriculum.Add("@c_curriculum_custom_11", curriculum.c_curriculum_custom_11);
            htNewCurriculum.Add("@c_curriculum_custom_12", curriculum.c_curriculum_custom_12);
            htNewCurriculum.Add("@c_curriculum_custom_13", curriculum.c_curriculum_custom_13);

            //htNewCurriculum.Add("@c_curriculum_prerequisite", curriculum.c_curriculum_Prerequistist);
            //htNewCurriculum.Add("@c_curriculum_equivalencies", curriculum.c_curriculum_Equivalencies);
            //htNewCurriculum.Add("@c_curriculum_fulfillments", curriculum.c_curriculum_Fulfillments);
            //htNewCurriculum.Add("@c_curriculum_domain", curriculum.c_curriculum_domain);
            //htNewCurriculum.Add("@c_curriculum_category", curriculum.c_curriculum_category);
            //htNewCurriculum.Add("@c_curriculum_attachment", curriculum.c_curriculum_attachment);          
            
            if (curriculum.c_curriculum_recurrance_every != null)
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_every", curriculum.c_curriculum_recurrance_every);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_recurrance_every", DBNull.Value);
            }
            htNewCurriculum.Add("@c_curriculum_recurrance_period", curriculum.c_curriculum_recurrance_period);
            htNewCurriculum.Add("@c_curriculum_recurance_date_option", curriculum.c_curriculum_recurance_date_option);


            if (curriculum.c_curriculum_recurance_date != null)
            {
                htNewCurriculum.Add("@c_curriculum_recurance_date", curriculum.c_curriculum_recurance_date);
            }
            else
            {
                htNewCurriculum.Add("@c_curriculum_recurance_date", DBNull.Value);
            }
            
            //if (curriculum.c_curriculum_cost != null)
            //{
            //    htNewCurriculum.Add("@c_curriculum_cost", curriculum.c_curriculum_cost);
            //}
            //else
            //{
            //    htNewCurriculum.Add("@c_curriculum_cost", DBNull.Value);
            //}
            try
            {
                return DataProxy.FetchSPOutput("c_sp_insert_curriculum_for_background", htNewCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
