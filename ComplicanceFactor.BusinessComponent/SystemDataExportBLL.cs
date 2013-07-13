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
        public static int InsertDataExport(SystemHRISIntegration dataImport)
        {
            Hashtable htInsertDataImport = new Hashtable();
            htInsertDataImport.Add("@u_sftp_URI", dataImport.u_sftp_URI);
            htInsertDataImport.Add("@u_sftp_port", dataImport.u_sftp_port);
            htInsertDataImport.Add("@u_sftp_username", dataImport.u_sftp_username);
            htInsertDataImport.Add("@u_sftp_password", dataImport.u_sftp_password);
            htInsertDataImport.Add("@u_sftp_exp_is_hris", dataImport.u_sftp_exp_is_hris);
            htInsertDataImport.Add("@u_sftp_exp_hris_filename", dataImport.u_sftp_exp_hris_filename);
            htInsertDataImport.Add("@u_sftp_exp_is_catalog_offering", dataImport.u_sftp_exp_is_catalog_offering);
            htInsertDataImport.Add("@u_sftp_exp_catalog_offering_filename", dataImport.u_sftp_exp_catalog_offering_filename);
            htInsertDataImport.Add("@u_sftp_exp_is_learning_history", dataImport.u_sftp_exp_is_learning_history);
            htInsertDataImport.Add("@u_sftp_exp_learning_history_filename", dataImport.u_sftp_exp_learning_history_filename);

            htInsertDataImport.Add("@u_sftp_occurs_every", dataImport.u_sftp_occurs_every);
            htInsertDataImport.Add("@u_sftp_time_every", dataImport.u_sftp_time_every);
            htInsertDataImport.Add("@u_sftp_start_date", dataImport.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_data_export", htInsertDataImport);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateDataExport(SystemHRISIntegration dataImport)
        {
            Hashtable htUpdateDataImport = new Hashtable();
            htUpdateDataImport.Add("@u_sftp_id_pk", dataImport.u_sftp_id_pk);
            htUpdateDataImport.Add("@u_sftp_URI", dataImport.u_sftp_URI);
            htUpdateDataImport.Add("@u_sftp_port", dataImport.u_sftp_port);
            htUpdateDataImport.Add("@u_sftp_username", dataImport.u_sftp_username);
            htUpdateDataImport.Add("@u_sftp_password", dataImport.u_sftp_password);

            htUpdateDataImport.Add("@u_sftp_exp_is_hris", dataImport.u_sftp_exp_is_hris);
            htUpdateDataImport.Add("@u_sftp_exp_hris_filename", dataImport.u_sftp_exp_hris_filename);
            htUpdateDataImport.Add("@u_sftp_exp_is_catalog_offering", dataImport.u_sftp_exp_is_catalog_offering);
            htUpdateDataImport.Add("@u_sftp_exp_catalog_offering_filename", dataImport.u_sftp_exp_catalog_offering_filename);
            htUpdateDataImport.Add("@u_sftp_exp_is_learning_history", dataImport.u_sftp_exp_is_learning_history);
            htUpdateDataImport.Add("@u_sftp_exp_learning_history_filename", dataImport.u_sftp_exp_learning_history_filename);

            htUpdateDataImport.Add("@u_sftp_occurs_every", dataImport.u_sftp_occurs_every);
            htUpdateDataImport.Add("@u_sftp_time_every", dataImport.u_sftp_time_every);
            htUpdateDataImport.Add("@u_sftp_start_date", dataImport.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_data_export", htUpdateDataImport);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleDataExport()
        {

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            DataTable dtSingleDataImport = new DataTable();
            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_data_export_details");
                if (dtSingleDataImport.Rows.Count > 0)
                {
                    dataImport.u_sftp_id_pk = dtSingleDataImport.Rows[0]["u_sftp_id_pk"].ToString();
                    dataImport.u_sftp_URI = dtSingleDataImport.Rows[0]["u_sftp_URI"].ToString();
                    dataImport.u_sftp_port = dtSingleDataImport.Rows[0]["u_sftp_port"].ToString();
                    dataImport.u_sftp_username = dtSingleDataImport.Rows[0]["u_sftp_username"].ToString();
                    dataImport.u_sftp_password = dtSingleDataImport.Rows[0]["u_sftp_password"].ToString();

                    dataImport.u_sftp_exp_is_hris = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_hris"]);
                    dataImport.u_sftp_exp_hris_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_hris_filename"].ToString();
                    dataImport.u_sftp_exp_is_catalog_offering = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_catalog_offering"]);
                    dataImport.u_sftp_exp_catalog_offering_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_catalog_offering_filename"].ToString();
                    dataImport.u_sftp_exp_is_learning_history =Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_learning_history"]);
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

        /// <summary>
        /// Get facilitis DataTable
        /// </summary>
        /// <returns></returns>
        /// 
        public static DataTable GetFacilities()
        {
            return DataProxy.FetchDataTable("s_sp_get_facilities");
        }

        /// <summary>
        /// Get Hris DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHris()
        {
            return DataProxy.FetchDataTable("s_sp_get_rooms");
        }

        /// <summary>
        /// Get Rooms DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRooms()
        {
            return DataProxy.FetchDataTable("s_sp_get_rooms");
        }

        /// <summary>
        /// Get Courses DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCourses()
        {
            return DataProxy.FetchDataTable("s_sp_get_course");
        }

        /// <summary>
        /// Get Curriculum DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCurriculum()
        {
            return DataProxy.FetchDataTable("s_sp_get_curriculum");
        }
        /// <summary>
        /// Get Enrollments DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEnrollments()
        {
            return DataProxy.FetchDataTable("s_sp_get_enrollments");
        }
        /// <summary>
        /// Get LearningHistory DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLearningHisory()
        {
            return DataProxy.FetchDataTable("s_sp_get_learning_history");
        }

    }
}
