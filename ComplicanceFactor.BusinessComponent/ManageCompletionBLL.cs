using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;

namespace ComplicanceFactor.BusinessComponent
{
    public class ManageCompletionBLL
    {
        public static DataTable SearchSystemCatalog(SystemCatalog catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            htSearchCourse.Add("@c_course_version", catalog.c_course_version);

            if (catalog.c_course_active_type_id_fk == "0")
                htSearchCourse.Add("@c_course_active_type_id_fk", DBNull.Value);
            else
                htSearchCourse.Add("@c_course_active_type_id_fk", catalog.c_course_active_type_id_fk);

            htSearchCourse.Add("@c_delivery_id_pk", catalog.c_delivery_id_pk);
            htSearchCourse.Add("@c_delivery_title", catalog.c_delivery_title);

            if (catalog.c_delivery_type_id_fk == "app_ddl_all_text")
                htSearchCourse.Add("@c_delivery_type_id_fk", DBNull.Value);
            else
                htSearchCourse.Add("@c_delivery_type_id_fk", catalog.c_delivery_type_id_fk);



            htSearchCourse.Add("@c_course_owner_name", catalog.c_course_owner_name);
            htSearchCourse.Add("@c_course_coordinator_name", catalog.c_course_coordinator_name);
            htSearchCourse.Add("@c_course_instructor_name", catalog.c_instructor_name);

            htSearchCourse.Add("@c_session_location_names", catalog.c_session_location_names);
            htSearchCourse.Add("@c_session_facility_names", catalog.c_session_facility_names);
            htSearchCourse.Add("@c_session_room_names", catalog.c_session_room_names);

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

            //htSearchCourse.Add("@c_session_start_date", catalog.c_session_start_date);
            //htSearchCourse.Add("@c_session_end_date", catalog.c_session_end_date);


            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course_delivery", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static SystemCatalog GetCourseDelivery(string c_course_system_id_pk)
        {
            SystemCatalog course;
            try
            {
                Hashtable htGetCourse = new Hashtable();
                htGetCourse.Add("@c_delivery_system_id_pk", c_course_system_id_pk);
                course = new SystemCatalog();
                DataTable dtGetCourse = DataProxy.FetchDataTable("s_sp_get_course_delivery_by_id", htGetCourse);
                course.c_course_id_pk = dtGetCourse.Rows[0]["c_course_id_pk"].ToString();
                course.c_course_title = dtGetCourse.Rows[0]["c_course_title"].ToString();
                course.c_course_desc = dtGetCourse.Rows[0]["c_course_desc"].ToString();
                course.c_course_version = dtGetCourse.Rows[0]["c_course_version"].ToString();
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_cost"].ToString()))
                {
                    course.c_course_cost = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_cost"]);
                }
                if (!string.IsNullOrEmpty(dtGetCourse.Rows[0]["c_course_credit_hours"].ToString()))
                {
                    course.c_course_credit_hours = Convert.ToInt32(dtGetCourse.Rows[0]["c_course_credit_hours"]);
                }

                course.c_delivery_id_pk = dtGetCourse.Rows[0]["c_delivery_id_pk"].ToString();
                course.c_delivery_title = dtGetCourse.Rows[0]["c_delivery_title"].ToString();
                course.c_delivery_desc = dtGetCourse.Rows[0]["c_delivery_desc"].ToString();
                course.c_delivery_type_id = dtGetCourse.Rows[0]["DeliveryType"].ToString();

                course.c_course_approval_req = Convert.ToBoolean(dtGetCourse.Rows[0]["c_course_approval_req"]) ;
                course.c_delivery_approval_req = Convert.ToBoolean(dtGetCourse.Rows[0]["c_delivery_approval_req"]);

                course.c_course_owner_name = dtGetCourse.Rows[0]["course_ownername"].ToString();
                course.c_course_coordinator_name = dtGetCourse.Rows[0]["course_coordinatorname"].ToString();
                course.c_delivery_owner_name = dtGetCourse.Rows[0]["delivery_ownername"].ToString();
                course.c_delivery_coordinator_name = dtGetCourse.Rows[0]["delivery_coordinatorname"].ToString();

                return course;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchDeliverySession(string c_delivery_system_id_pk)
        {
            Hashtable htSearchSession = new Hashtable();
            htSearchSession.Add("@c_delivery_system_id_pk", c_delivery_system_id_pk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_get_delivery_session", htSearchSession);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //c_sp_search_delivery_employee
        public static DataTable GetDeliveryEmployee(string u_first_name, string u_hris_employee_id, string c_delivery_system_id_pk)
        {
            try
            {
                Hashtable htGetEmployee = new Hashtable();
                htGetEmployee.Add("@u_first_name", u_first_name);
                htGetEmployee.Add("@u_hris_employee_id", u_hris_employee_id);
                htGetEmployee.Add("@delivery_id", c_delivery_system_id_pk);

                return DataProxy.FetchDataTable("c_sp_search_delivery_olt_employee", htGetEmployee);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDeliveryEmployeeOLT(string c_delivery_system_id_pk)
        {
            try
            {
                Hashtable htGetEmployee = new Hashtable();
                htGetEmployee.Add("@e_enroll_delivery_id_fk", c_delivery_system_id_pk);

                return DataProxy.FetchDataTable("s_sp_get_employee_for_completion", htGetEmployee);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static DataTable GetAttendanceStatus(string localeName, string pageName)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", localeName);
                htGetStatus.Add("@s_ui_page_name", pageName);

                return DataProxy.FetchDataTable("s_sp_get_attendance_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPassingStatus(string localeName, string pageName)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", localeName);
                htGetStatus.Add("@s_ui_page_name", pageName);

                return DataProxy.FetchDataTable("s_sp_get_passing_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateEnrollmentActive(string userId, string courseId, string deliveryId)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@e_enroll_user_id_fk", userId);
                htGetStatus.Add("@e_enroll_course_id_fk", courseId);
                htGetStatus.Add("@e_enroll_delivery_id_fk", deliveryId);


                return DataProxy.FetchSPOutput("e_sp_update_enrollment_active", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int UpdateEnrollment(string userId, string courseId, string deliveryId, string transcript_id)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@e_enroll_user_id_fk", userId);
                htGetStatus.Add("@e_enroll_course_id_fk", courseId);
                htGetStatus.Add("@e_enroll_delivery_id_fk", deliveryId);
                htGetStatus.Add("@e_transcript_id_fk", transcript_id);


                return DataProxy.FetchSPOutput("e_sp_update_enrollment", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertTranscripts(SystemTranscripts transcripts)
        {
            try
            {
                Hashtable htInsertTranscripts = new Hashtable();
                htInsertTranscripts.Add("@t_transcript_id_pk", transcripts.t_transcript_id_pk);
                htInsertTranscripts.Add("@t_transcript_user_id_fk", transcripts.t_transcript_user_id_fk);
                htInsertTranscripts.Add("@t_transcript_course_id_fk", transcripts.t_transcript_course_id_fk);
                htInsertTranscripts.Add("@t_transcript_delivery_id_fk", transcripts.t_transcript_delivery_id_fk);
                if (!string.IsNullOrEmpty(transcripts.t_transcript_assign_id_fk))
                {
                    htInsertTranscripts.Add("@t_transcript_assign_id_fk", transcripts.t_transcript_assign_id_fk);
                }
                else
                {
                    htInsertTranscripts.Add("@t_transcript_assign_id_fk", DBNull.Value);
                }
                //htInsertTranscripts.Add("@t_transcript_assign_id_fk", transcripts.t_transcript_assign_id_fk);
                if (!string.IsNullOrEmpty(transcripts.t_transcript_enroll_id_fk))
                {
                    htInsertTranscripts.Add("@t_transcript_enroll_id_fk", transcripts.t_transcript_enroll_id_fk);
                }
                else
                {
                    htInsertTranscripts.Add("@t_transcript_enroll_id_fk", DBNull.Value);
                }
                //htInsertTranscripts.Add("@t_transcript_enroll_id_fk", transcripts.t_transcript_enroll_id_fk);
                htInsertTranscripts.Add("@t_transcript_attendance_id_fk", transcripts.t_transcript_attendance_id_fk);
                htInsertTranscripts.Add("@t_transcript_passing_status_id_fk", transcripts.t_transcript_passing_status_id_fk);
                if (!string.IsNullOrEmpty(transcripts.t_transcript_grade_id_fk))
                {
                    htInsertTranscripts.Add("@t_transcript_grade_id_fk", transcripts.t_transcript_grade_id_fk);
                }
                else
                {
                    htInsertTranscripts.Add("@t_transcript_grade_id_fk", DBNull.Value);
                }
                htInsertTranscripts.Add("@t_transcript_completion_score", transcripts.t_transcript_completion_score);
                htInsertTranscripts.Add("@t_transcript_completion_date_time", transcripts.t_transcript_completion_date_time);
                if (!string.IsNullOrEmpty(transcripts.t_transcript_completion_type_id_fk))
                {
                    htInsertTranscripts.Add("@t_transcript_completion_type_id_fk", transcripts.t_transcript_completion_type_id_fk);
                }
                else
                {
                    htInsertTranscripts.Add("@t_transcript_completion_type_id_fk", DBNull.Value);
                }
                //htInsertTranscripts.Add("@t_transcript_completion_type_id_fk", transcripts.t_transcript_completion_type_id_fk);
                htInsertTranscripts.Add("@t_transcript_marked_by_user_id_fk", transcripts.t_transcript_marked_by_user_id_fk);
                htInsertTranscripts.Add("@t_transcript_required_flag", transcripts.t_transcript_required_flag);
                htInsertTranscripts.Add("@t_transcript_target_due_date", transcripts.t_transcript_target_due_date);
                htInsertTranscripts.Add("@t_transcript_actual_date", transcripts.t_transcript_actual_date);
                htInsertTranscripts.Add("@t_transcript_status_name", transcripts.t_transcript_status_name);
                htInsertTranscripts.Add("@t_transcript_time_spent", transcripts.t_transcript_time_spent);
                htInsertTranscripts.Add("@t_transcript_score", transcripts.t_transcript_score);
                htInsertTranscripts.Add("@t_transcript_credits", transcripts.t_transcript_credits);
                htInsertTranscripts.Add("@t_transcript_hours", transcripts.t_transcript_hours);
                htInsertTranscripts.Add("@t_transcript_active_flag", transcripts.t_transcript_active_flag);


                return DataProxy.FetchSPOutput("s_sp_insert_transcripts", htInsertTranscripts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertSessionTranscripts(SystemTranscripts sessionTrans)
        {
            try
            {
                Hashtable htInsertSession = new Hashtable();
                htInsertSession.Add("@t_transcript_session_id_fk", sessionTrans.t_transcript_session_id_fk);
                htInsertSession.Add("@t_transcript_id_pk", sessionTrans.t_transcript_id_pk);
                htInsertSession.Add("@t_transcript_session_user_id_fk", sessionTrans.t_transcript_session_user_id_fk);
                htInsertSession.Add("@t_transcript_sessiont_course_id_fk", sessionTrans.t_transcript_sessiont_course_id_fk);
                htInsertSession.Add("@t_transcript_session_delivery_id_fk", sessionTrans.t_transcript_session_delivery_id_fk);
                if (sessionTrans.t_transcript_session_roster_id_fk == string.Empty)
                {
                    htInsertSession.Add("@t_transcript_session_roster_id_fk", DBNull.Value);
                }
                else
                {
                    htInsertSession.Add("@t_transcript_session_roster_id_fk", sessionTrans.t_transcript_session_roster_id_fk);
                }
                htInsertSession.Add("@t_transcript_session_attendance_id_fk", sessionTrans.t_transcript_session_attendance_id_fk);
                htInsertSession.Add("@t_transcript_session_passing_status_id_fk", sessionTrans.t_transcript_session_passing_status_id_fk);
                htInsertSession.Add("@t_transcript_session_grade_id_fk", sessionTrans.t_transcript_session_grade_id_fk);
                htInsertSession.Add("@t_transcript_session_completion_score", sessionTrans.t_transcript_session_completion_score);
                htInsertSession.Add("@t_transcript_session_completion_date_time", sessionTrans.t_transcript_session_completion_date_time);
                if (sessionTrans.t_transcript_session_completion_type_id_fk == string.Empty)
                {
                    htInsertSession.Add("@t_transcript_session_completion_type_id_fk", DBNull.Value);
                }
                else
                {
                    htInsertSession.Add("@t_transcript_session_completion_type_id_fk", sessionTrans.t_transcript_session_completion_type_id_fk);
                }
                //htInsertSession.Add("@t_transcript_session_completion_type_id_fk", sessionTrans.t_transcript_session_completion_type_id_fk);
                htInsertSession.Add("@t_transcript_session_marked_by_user_id_fk", sessionTrans.t_transcript_session_marked_by_user_id_fk);
                htInsertSession.Add("@t_transcript_session_actual_date", sessionTrans.t_transcript_session_actual_date);

                htInsertSession.Add("@t_transcript_status_name", sessionTrans.t_transcript_status_name);

                htInsertSession.Add("@t_transcript_session_active_flag", sessionTrans.t_transcript_session_active_flag);


                return DataProxy.FetchSPOutput("s_sp_insert_session_transcripts", htInsertSession);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Enrollment GetEnrollmentId(string userId, string courseId, string deliveryId)
        {
            Enrollment enroll = new Enrollment();
            try
            {
                DataTable dtEnrollment = new DataTable();
                Hashtable htGetEnrollment = new Hashtable();
                htGetEnrollment.Add("@e_enroll_user_id_fk", userId);
                htGetEnrollment.Add("@e_enroll_course_id_fk", courseId);
                htGetEnrollment.Add("@e_enroll_delivery_id_fk", deliveryId);
                dtEnrollment = DataProxy.FetchDataTable("s_sp_get_enrollment_id", htGetEnrollment);
                if (dtEnrollment.Rows.Count > 0)
                {
                    enroll.e_enroll_system_id_pk = dtEnrollment.Rows[0]["e_enroll_system_id_pk"].ToString();
                }
                else
                {
                    enroll.e_enroll_system_id_pk = null;
                }
                return enroll;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSessionTranscripts(string userId, string courseId, string deliveryId)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@c_user_id_pk", userId);
                htGetStatus.Add("@course_id_pk", courseId);
                htGetStatus.Add("@c_delivery_system_id_pk", deliveryId);
                return DataProxy.FetchDataTable("s_sp_get_session_transcripts", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateSessionTranscripts(SystemTranscripts sessionTrans)
        {
            try
            {
                Hashtable htUpdateSession = new Hashtable();

                htUpdateSession.Add("@t_transcript_id_pk", sessionTrans.t_transcript_id_pk);

                htUpdateSession.Add("@t_transcript_session_attendance_id_fk", sessionTrans.t_transcript_session_attendance_id_fk);
                htUpdateSession.Add("@t_transcript_session_passing_status_id_fk", sessionTrans.t_transcript_session_passing_status_id_fk);
                if (string.IsNullOrEmpty(sessionTrans.t_transcript_session_grade_id_fk))
                {
                    htUpdateSession.Add("@t_transcript_session_grade_id_fk", DBNull.Value);
                }
                else
                {
                    htUpdateSession.Add("@t_transcript_session_grade_id_fk", sessionTrans.t_transcript_session_grade_id_fk);
                }
                //htUpdateSession.Add("@t_transcript_session_grade_id_fk", sessionTrans.t_transcript_session_grade_id_fk);
                htUpdateSession.Add("@t_transcript_session_completion_score", sessionTrans.t_transcript_session_completion_score);

                return DataProxy.FetchSPOutput("s_sp_update_session_transcripts", htUpdateSession);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int AssignCourse(Enrollment assign)
        {
            try
            {
                Hashtable htAssignCourse = new Hashtable();
                htAssignCourse.Add("@e_course_assign_user_id_fk", assign.e_course_assign_user_id_fk);
                htAssignCourse.Add("@e_course_assign_course_id_fk", assign.e_course_assign_course_id_fk);
                htAssignCourse.Add("@e_course_assign_by_id_fk", assign.e_course_assign_by_id_fk);
                htAssignCourse.Add("@e_course_assign_required_flag", assign.e_course_assign_required_flag);
                if (assign.e_course_assign_target_due_date == null)
                {
                    htAssignCourse.Add("@e_course_assign_target_due_date", DBNull.Value);
                }
                else
                {
                    htAssignCourse.Add("@e_course_assign_target_due_date", assign.e_course_assign_target_due_date);
                }
                htAssignCourse.Add("@e_course_assign_recert_due_date", DBNull.Value);
                htAssignCourse.Add("@e_course_assign_active_flag", assign.e_course_assign_active_flag);
                return DataProxy.FetchSPOutput("s_sp_assign_course_in_completion", htAssignCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetGrade(string deliveryId)
        {
            try
            {
                Hashtable htGetGrade = new Hashtable();
                htGetGrade.Add("@c_delivery_system_id_pk", deliveryId);
                return DataProxy.FetchDataTable("s_sp_get_grade_value", htGetGrade);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemGradingSchemes GetGradeByScore(string deliveryId, int score)
        {
            SystemGradingSchemes gradevalues = new SystemGradingSchemes();
            try
            {
                DataTable grade = new DataTable();
                Hashtable htGetGrade = new Hashtable();
                htGetGrade.Add("@c_delivery_system_id_pk", deliveryId);
                htGetGrade.Add("@score", score);

                grade = DataProxy.FetchDataTable("s_sp_get_grade_value_by_score", htGetGrade);
                if (grade.Rows.Count > 0)
                {
                    gradevalues.s_grading_scheme_value_grade = grade.Rows[0]["s_grading_scheme_value_grade"].ToString();
                    gradevalues.s_grading_scheme_value_pass_status_id_fk = grade.Rows[0]["s_grading_scheme_value_pass_status_id_fk"].ToString();
                    gradevalues.s_grading_scheme_system_value_id_pk = grade.Rows[0]["s_grading_scheme_system_value_id_pk"].ToString();
                }

                return gradevalues;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetCurriculumByCourse(string courseId, string userId)
        {
            try
            {
                Hashtable htGetCurriculum = new Hashtable();
                htGetCurriculum.Add("@c_course_id_pk", courseId);
                htGetCurriculum.Add("@user_id", userId);
                return DataProxy.FetchDataTable("s_sp_get_curriculum_by_course", htGetCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertAudit(Auditlog auditlog)
        {

            Hashtable htInsertAudit = new Hashtable();
            htInsertAudit.Add("@GUID", auditlog.Guid);
            htInsertAudit.Add("@a_audit_log_id_pk", auditlog.Auditid);
            htInsertAudit.Add("@a_user_id_fk", auditlog.Userid);
            htInsertAudit.Add("@a_user_type_fk", auditlog.user_type);
            htInsertAudit.Add("@a_user_details", auditlog.user_detail);
            htInsertAudit.Add("@a_action_desc", auditlog.action_desc);
            // htInsertAudit.Add("@a_date_time", auditlog.u_datetime);
            htInsertAudit.Add("@a_ip_address ", auditlog.ipaddress);
            htInsertAudit.Add("@a_device_used", auditlog.device);
            htInsertAudit.Add("@a_values", auditlog.a_values);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_audit_insert_log", htInsertAudit);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public static int UpdateCurriculumPercentage(string curriculumId, string userId)
        {
            try
            {
                Hashtable htupdateCurriculum = new Hashtable();
                htupdateCurriculum.Add("@c_curriculum_id_fk", curriculumId);
                htupdateCurriculum.Add("@c_curriculum_user_id_pk", userId);
                return DataProxy.FetchSPOutput("s_sp_update_curriculum_percentage", htupdateCurriculum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int SingleEnroll(Enrollment Enroll)
        {
            try
            {
                Hashtable htConfirmEnroll = new Hashtable();
                htConfirmEnroll.Add("@e_enroll_user_id_fk", Enroll.e_enroll_user_id_fk);
                htConfirmEnroll.Add("@e_enroll_course_id_fk", Enroll.e_enroll_course_id_fk);
                htConfirmEnroll.Add("@e_enroll_delivery_id_fk", Enroll.e_enroll_delivery_id_fk);
                htConfirmEnroll.Add("@e_enroll_required_flag", Enroll.e_enroll_required_flag);                
                htConfirmEnroll.Add("@e_enroll_type_name", Enroll.e_enroll_type_name);
                if (Enroll.e_enroll_target_due_date != null)
                {
                    htConfirmEnroll.Add("@e_enroll_target_due_date", Enroll.e_enroll_target_due_date);
                }
                else
                {
                    htConfirmEnroll.Add("@e_enroll_target_due_date", DBNull.Value);
                }                 
                htConfirmEnroll.Add("@e_enroll_status_name", Enroll.e_enroll_status_name);

                return DataProxy.FetchSPOutput("e_sp_insert_enrollment_for_completion", htConfirmEnroll);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsertedOLT(string t_transcript_course_id_fk, string t_transcript_delivery_id_fk,string selecteduser)
        {
            try
            {
                Hashtable htGetOLT = new Hashtable();
                htGetOLT.Add("@t_transcript_course_id_fk", t_transcript_course_id_fk);
                htGetOLT.Add("@t_transcript_delivery_id_fk", t_transcript_delivery_id_fk);
                //htGetOLT.Add("@selecteduser", selecteduser);
                return DataProxy.FetchDataTable("s_sp_get_inserted_transcript_olt", htGetOLT);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsertedRecords(string t_transcript_course_id_fk, string t_transcript_delivery_id_fk, string t_transcript_user_id_fk, string t_transcript_id_pk)
        {
            try
            {
                Hashtable htGetInsertedRecords = new Hashtable();
                htGetInsertedRecords.Add("@t_transcript_course_id_fk", t_transcript_course_id_fk);
                htGetInsertedRecords.Add("@t_transcript_delivery_id_fk", t_transcript_delivery_id_fk);
                htGetInsertedRecords.Add("@t_transcript_user_id_fk", t_transcript_user_id_fk);
                htGetInsertedRecords.Add("@t_transcript_id_pk", t_transcript_id_pk);
                
                return DataProxy.FetchDataTable("s_sp_get_inserted_course", htGetInsertedRecords);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateTranscriptsandSession(SystemTranscripts transcripts)
        {
            try
            {
                Hashtable htUpdateTranscripts = new Hashtable();
                htUpdateTranscripts.Add("@t_transcript_user_id_fk", transcripts.t_transcript_user_id_fk);
                htUpdateTranscripts.Add("@t_transcript_course_id_fk", transcripts.t_transcript_course_id_fk);
                htUpdateTranscripts.Add("@t_transcript_delivery_id_fk", transcripts.t_transcript_delivery_id_fk);


                htUpdateTranscripts.Add("@t_transcript_attendance_id_fk", transcripts.t_transcript_attendance_id_fk);
                htUpdateTranscripts.Add("@t_transcript_passing_status_id_fk", transcripts.t_transcript_passing_status_id_fk);
                if (!string.IsNullOrEmpty(transcripts.t_transcript_grade_id_fk))
                {
                    htUpdateTranscripts.Add("@t_transcript_grade_id_fk", transcripts.t_transcript_grade_id_fk);
                }
                else
                {
                    htUpdateTranscripts.Add("@t_transcript_grade_id_fk", DBNull.Value);
                }
                htUpdateTranscripts.Add("@t_transcript_score", transcripts.t_transcript_completion_score);


                return DataProxy.FetchSPOutput("s_sp_update_transcripts_and_session", htUpdateTranscripts);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
