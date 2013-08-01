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
    public class SystemMassCompletionBLL
    {
        public static DataTable GetDelivery(string courseId)
        {
            Hashtable htGetDelivery = new Hashtable();
            htGetDelivery.Add("@c_course_id_fk", courseId);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_delivery_by_course", htGetDelivery);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchCourse(ManageCourse catalog)
        {
            Hashtable htSearchCourse = new Hashtable();
            htSearchCourse.Add("@c_course_id_pk", catalog.c_course_id_pk);
            htSearchCourse.Add("@c_course_title", catalog.c_course_title);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_course_mass_completion", htSearchCourse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchUser(User user)
        {
            Hashtable htSearchUser = new Hashtable();
            htSearchUser.Add("@EmployeeName", user.Firstname);
            htSearchUser.Add("@EmployeeId", user.Hris_employeid);            
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_user_for_mass_completion", htSearchUser);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet MassCompletion(SystemTranscripts transcripts)
        {
            try
            {
                Hashtable htInsertTranscripts = new Hashtable();                            
                if (!string.IsNullOrEmpty(transcripts.t_transcript_assign_id_fk))
                {
                    htInsertTranscripts.Add("@t_transcript_assign_id_fk", transcripts.t_transcript_assign_id_fk);
                }
                else
                {
                    htInsertTranscripts.Add("@t_transcript_assign_id_fk", DBNull.Value);
                }                 
                //htInsertTranscripts.Add("@t_transcript_completion_date_time", transcripts.t_transcript_completion_date_time);
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

                htInsertTranscripts.Add("@audit_Userid", transcripts.Userid);
                htInsertTranscripts.Add("@audit_user_type", transcripts.user_type);
                htInsertTranscripts.Add("@audit_user_detail", transcripts.user_detail);
                htInsertTranscripts.Add("@audit_action_desc", transcripts.action_desc);
                htInsertTranscripts.Add("@audit_ipaddress", transcripts.ipaddress);
                htInsertTranscripts.Add("@audit_device", transcripts.device);

                htInsertTranscripts.Add("@mass_completion", transcripts.mass_completion);



                return DataProxy.FetchDataSet("s_sp_mass_completion", htInsertTranscripts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CheckCourseCompleted(string u_user_id_pk, string c_course_system_id_pk)
        {
            Hashtable htCourseCompleted = new Hashtable();
            htCourseCompleted.Add("@u_user_id_pk",u_user_id_pk);
            htCourseCompleted.Add("@c_course_system_id_pk", c_course_system_id_pk);
            try
            {
                DataTable dt = new DataTable();
                int res = DataProxy.FetchSPOutput("s_sp_get_course_completed",htCourseCompleted);
                return res == 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
