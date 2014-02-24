using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemDataImportBLL
    {
        public static int InsertDataImport(SystemHRISIntegration dataImport)
        {
            Hashtable htInsertDataImport = new Hashtable();
            htInsertDataImport.Add("@u_sftp_URI", dataImport.u_sftp_URI);
            htInsertDataImport.Add("@u_sftp_port", dataImport.u_sftp_port);
            htInsertDataImport.Add("@u_sftp_username", dataImport.u_sftp_username);
            htInsertDataImport.Add("@u_sftp_password", dataImport.u_sftp_password);
            htInsertDataImport.Add("@u_sftp_imp_is_enrollment", dataImport.u_sftp_imp_is_enrollment);
            htInsertDataImport.Add("@u_sftp_imp_enrollment_filename", dataImport.u_sftp_imp_enrollment_filename);
            htInsertDataImport.Add("@u_sftp_imp_is_learning_history", dataImport.u_sftp_imp_is_learning_history);
            htInsertDataImport.Add("@u_sftp_imp_learning_history_filename", dataImport.u_sftp_imp_learning_history_filename);
            if (!string.IsNullOrEmpty(dataImport.u_sftp_imp_facility_filename))
            {
                htInsertDataImport.Add("@u_sftp_imp_facility_filename", dataImport.u_sftp_imp_facility_filename);
            }
            else
            {
                htInsertDataImport.Add("@u_sftp_imp_facility_filename", string.Empty);
            }
            if (!string.IsNullOrEmpty(dataImport.u_sftp_imp_room_filename))
            {
                htInsertDataImport.Add("@u_sftp_imp_room_filename", dataImport.u_sftp_imp_room_filename);
            }
            else
            {
                htInsertDataImport.Add("@u_sftp_imp_room_filename", string.Empty);
            }
            if (!string.IsNullOrEmpty(dataImport.u_sftp_imp_course_filename))
            {
                htInsertDataImport.Add("@u_sftp_imp_course_filename", dataImport.u_sftp_imp_course_filename);
            }
            else
            {
                htInsertDataImport.Add("@u_sftp_imp_course_filename", string.Empty);
            }
            if (!string.IsNullOrEmpty(dataImport.u_sftp_imp_course_filename))
            {
                htInsertDataImport.Add("@u_sftp_imp_base_curricula_filename", dataImport.u_sftp_imp_base_curricula_filename);
            }
            else
            {
                htInsertDataImport.Add("@u_sftp_imp_base_curricula_filename", string.Empty);
            }
            htInsertDataImport.Add("@u_sftp_occurs_every", dataImport.u_sftp_occurs_every);
            htInsertDataImport.Add("@u_sftp_time_every", dataImport.u_sftp_time_every);
            htInsertDataImport.Add("@u_sftp_start_date", dataImport.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_data_import", htInsertDataImport);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int UpdateDataImport(SystemHRISIntegration dataImport)
        {
            Hashtable htUpdateDataImport = new Hashtable();
            htUpdateDataImport.Add("@u_sftp_id_pk", dataImport.u_sftp_id_pk);
            htUpdateDataImport.Add("@u_sftp_URI", dataImport.u_sftp_URI);
            htUpdateDataImport.Add("@u_sftp_port", dataImport.u_sftp_port);
            htUpdateDataImport.Add("@u_sftp_username", dataImport.u_sftp_username);
            htUpdateDataImport.Add("@u_sftp_password", dataImport.u_sftp_password);
            htUpdateDataImport.Add("@u_sftp_imp_is_enrollment", dataImport.u_sftp_imp_is_enrollment);
            htUpdateDataImport.Add("@u_sftp_imp_enrollment_filename", dataImport.u_sftp_imp_enrollment_filename);
            htUpdateDataImport.Add("@u_sftp_imp_is_learning_history", dataImport.u_sftp_imp_is_learning_history);
            htUpdateDataImport.Add("@u_sftp_imp_learning_history_filename", dataImport.u_sftp_imp_learning_history_filename);
            htUpdateDataImport.Add("@u_sftp_imp_facility_filename", dataImport.u_sftp_imp_facility_filename);
            htUpdateDataImport.Add("@u_sftp_imp_room_filename", dataImport.u_sftp_imp_room_filename);
            htUpdateDataImport.Add("@u_sftp_imp_course_filename", dataImport.u_sftp_imp_course_filename);
            htUpdateDataImport.Add("@u_sftp_imp_base_curricula_filename", dataImport.u_sftp_imp_base_curricula_filename);
            htUpdateDataImport.Add("@u_sftp_occurs_every", dataImport.u_sftp_occurs_every);
            htUpdateDataImport.Add("@u_sftp_time_every", dataImport.u_sftp_time_every);
            htUpdateDataImport.Add("@u_sftp_start_date", dataImport.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_data_import", htUpdateDataImport);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleDataImport()
        {

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            DataTable dtSingleDataImport = new DataTable();
            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_data_import_details");
                if (dtSingleDataImport.Rows.Count > 0)
                {
                    dataImport.u_sftp_id_pk = dtSingleDataImport.Rows[0]["u_sftp_id_pk"].ToString();
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
        public static SystemHRISIntegration GetDataImportForBackground(string currntTime, string currentDate)
        {
            Hashtable htGetDataImportForBackground = new Hashtable();
            htGetDataImportForBackground.Add("@u_sftp_time_every", currntTime);
            htGetDataImportForBackground.Add("@u_sftp_start_date", currentDate);

            DataTable dtSingleDataImport = new DataTable();

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_data_import_for_background", htGetDataImportForBackground);
                if (dtSingleDataImport.Rows.Count > 0)
                {
                    if (dtSingleDataImport.Rows[0]["u_sftp_URI"].ToString() != "-2")
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
                }

                return dataImport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet AssignCourseCurriculum(string CourseAssign,string Curriculum, string course_assign_by_id)
        {
            Hashtable htCourseCurriculum = new Hashtable();
            if (!string.IsNullOrEmpty(CourseAssign))
            {
                htCourseCurriculum.Add("@CourseAssign", CourseAssign);
            }
            else
            {
                htCourseCurriculum.Add("@CourseAssign", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Curriculum))
            {
                htCourseCurriculum.Add("@Curriculum", Curriculum);
            }
            else
            {
                htCourseCurriculum.Add("@Curriculum", DBNull.Value);
            }
            htCourseCurriculum.Add("@course_assign_by_id", course_assign_by_id);
            
            try
            {
                return DataProxy.FetchDataSet("s_sp_course_curriculum_assign_from_data_import", htCourseCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllCourse_Id()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_all_course_id");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DropCourseCurriculum(string coursexml, string curriculumxml)
        {
            Hashtable htdropCourseCurriculum = new Hashtable();
            if (!string.IsNullOrEmpty(coursexml))
            {
                htdropCourseCurriculum.Add("@s_drop_course", coursexml);
            }
            else
            {
                htdropCourseCurriculum.Add("@s_drop_course", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(curriculumxml))
            {
                htdropCourseCurriculum.Add("@s_drop_curriculum_details", curriculumxml);
            }
            else
            {
                htdropCourseCurriculum.Add("@s_drop_curriculum_details", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_drop_course_curriculum_from_data_import", htdropCourseCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
