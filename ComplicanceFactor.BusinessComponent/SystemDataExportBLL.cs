using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemDataExportBLL
    {
        public static int InsertDataExport(SystemHRISIntegration dataExport)
        {
            Hashtable htInsertDataExport = new Hashtable();
            htInsertDataExport.Add("@u_sftp_URI", dataExport.u_sftp_URI);
            htInsertDataExport.Add("@u_sftp_port", dataExport.u_sftp_port);
            htInsertDataExport.Add("@u_sftp_username", dataExport.u_sftp_username);
            htInsertDataExport.Add("@u_sftp_password", dataExport.u_sftp_password);
            htInsertDataExport.Add("@u_sftp_exp_is_hris", dataExport.u_sftp_exp_is_hris);
            htInsertDataExport.Add("@u_sftp_exp_hris_filename", dataExport.u_sftp_exp_hris_filename);
            htInsertDataExport.Add("@u_sftp_exp_is_catalog_offering", dataExport.u_sftp_exp_is_catalog_offering);
            htInsertDataExport.Add("@u_sftp_exp_catalog_offering_filename", dataExport.u_sftp_exp_catalog_offering_filename);
            htInsertDataExport.Add("@u_sftp_exp_is_learning_history", dataExport.u_sftp_exp_is_learning_history);
            htInsertDataExport.Add("@u_sftp_exp_learning_history_filename", dataExport.u_sftp_exp_learning_history_filename);

            htInsertDataExport.Add("@u_sftp_occurs_every", dataExport.u_sftp_occurs_every);
            htInsertDataExport.Add("@u_sftp_time_every", dataExport.u_sftp_time_every);
            htInsertDataExport.Add("@u_sftp_start_date", dataExport.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_data_export", htInsertDataExport);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateDataExport(SystemHRISIntegration dataExport)
        {
            Hashtable htUpdateDataExport = new Hashtable();
            htUpdateDataExport.Add("@u_sftp_id_pk", dataExport.u_sftp_id_pk);
            htUpdateDataExport.Add("@u_sftp_URI", dataExport.u_sftp_URI);
            htUpdateDataExport.Add("@u_sftp_port", dataExport.u_sftp_port);
            htUpdateDataExport.Add("@u_sftp_username", dataExport.u_sftp_username);
            htUpdateDataExport.Add("@u_sftp_password", dataExport.u_sftp_password);

            htUpdateDataExport.Add("@u_sftp_exp_is_hris", dataExport.u_sftp_exp_is_hris);
            htUpdateDataExport.Add("@u_sftp_exp_hris_filename", dataExport.u_sftp_exp_hris_filename);
            htUpdateDataExport.Add("@u_sftp_exp_is_catalog_offering", dataExport.u_sftp_exp_is_catalog_offering);
            htUpdateDataExport.Add("@u_sftp_exp_catalog_offering_filename", dataExport.u_sftp_exp_catalog_offering_filename);
            htUpdateDataExport.Add("@u_sftp_exp_is_learning_history", dataExport.u_sftp_exp_is_learning_history);
            htUpdateDataExport.Add("@u_sftp_exp_learning_history_filename", dataExport.u_sftp_exp_learning_history_filename);

            htUpdateDataExport.Add("@u_sftp_occurs_every", dataExport.u_sftp_occurs_every);
            htUpdateDataExport.Add("@u_sftp_time_every", dataExport.u_sftp_time_every);
            htUpdateDataExport.Add("@u_sftp_start_date", dataExport.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_data_export", htUpdateDataExport);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleDataExport()
        {

            SystemHRISIntegration dataExport = new SystemHRISIntegration();

            DataTable dtSingleDataExport = new DataTable();
            try
            {
                dtSingleDataExport = DataProxy.FetchDataTable("s_sp_get_data_export_details");
                if (dtSingleDataExport.Rows.Count > 0)
                {
                    dataExport.u_sftp_id_pk = dtSingleDataExport.Rows[0]["u_sftp_id_pk"].ToString();
                    dataExport.u_sftp_URI = dtSingleDataExport.Rows[0]["u_sftp_URI"].ToString();
                    dataExport.u_sftp_port = dtSingleDataExport.Rows[0]["u_sftp_port"].ToString();
                    dataExport.u_sftp_username = dtSingleDataExport.Rows[0]["u_sftp_username"].ToString();
                    dataExport.u_sftp_password = dtSingleDataExport.Rows[0]["u_sftp_password"].ToString();

                    dataExport.u_sftp_exp_is_hris = Convert.ToBoolean(dtSingleDataExport.Rows[0]["u_sftp_exp_is_hris"]);
                    dataExport.u_sftp_exp_hris_filename = dtSingleDataExport.Rows[0]["u_sftp_exp_hris_filename"].ToString();
                    dataExport.u_sftp_exp_is_catalog_offering = Convert.ToBoolean(dtSingleDataExport.Rows[0]["u_sftp_exp_is_catalog_offering"]);
                    dataExport.u_sftp_exp_catalog_offering_filename = dtSingleDataExport.Rows[0]["u_sftp_exp_catalog_offering_filename"].ToString();
                    dataExport.u_sftp_exp_is_learning_history = Convert.ToBoolean(dtSingleDataExport.Rows[0]["u_sftp_exp_is_learning_history"]);
                    dataExport.u_sftp_exp_learning_history_filename = dtSingleDataExport.Rows[0]["u_sftp_exp_learning_history_filename"].ToString();

                    dataExport.u_sftp_occurs_every = dtSingleDataExport.Rows[0]["u_sftp_occurs_every"].ToString();
                    dataExport.u_sftp_time_every = dtSingleDataExport.Rows[0]["u_sftp_time_every"].ToString();
                    dataExport.u_sftp_start_date = dtSingleDataExport.Rows[0]["u_sftp_start_date"].ToString();
                }

                return dataExport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get facilitis DataTable
        /// </summary>
        /// <returns></returns>
        /// 
        public static DataTable GetFacilities()
        {
            return DataProxy.FetchDataTable("s_sp_get_facilities_for_csv");
        }

        /// <summary>
        /// Get Hris DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHris()
        {
            return DataProxy.FetchDataTable("s_sp_get_rooms_for_csv");
        }

        /// <summary>
        /// Get Rooms DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRooms()
        {
            return DataProxy.FetchDataTable("s_sp_get_rooms_for_csv");
        }

        /// <summary>
        /// Get Courses DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCourses()
        {
            return DataProxy.FetchDataTable("s_sp_get_course_for_csv");
        }

        /// <summary>
        /// Get Curriculum DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCurriculum()
        {
            return DataProxy.FetchDataTable("s_sp_get_curriculum_for_csv");
        }
        /// <summary>
        /// Get Enrollments DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEnrollments()
        {
            return DataProxy.FetchDataTable("s_sp_get_enrollments_for_csv");
        }
        /// <summary>
        /// Get LearningHistory DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLearningHisory()
        {
            return DataProxy.FetchDataTable("s_sp_get_learning_history_for_csv");
        }
        /// <summary>
        /// Get Log Details
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLogDetails(string u_sftp_run_log_type)
        {
            try
            {
                Hashtable htGetLogDetails = new Hashtable();
                htGetLogDetails.Add("@u_sftp_run_log_type", u_sftp_run_log_type);
                return DataProxy.FetchDataTable("s_sp_get_hris_imp_exp_error_log", htGetLogDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
