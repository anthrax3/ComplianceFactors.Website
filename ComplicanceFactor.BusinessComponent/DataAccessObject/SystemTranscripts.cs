using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemTranscripts
    {
        public string t_transcript_id_pk { get; set; }
        public string t_transcript_user_id_fk { get; set; }

        public string t_transcript_course_id_fk { get; set; }
        public string t_transcript_delivery_id_fk { get; set; }
        public string t_transcript_assign_id_fk { get; set; }
        public string t_transcript_enroll_id_fk { get; set; }

        public string t_transcript_attendance_id_fk { get; set; }
        public string t_transcript_passing_status_id_fk { get; set; }
        public string t_transcript_grade_id_fk { get; set; }
        public int t_transcript_completion_score { get; set; }
        public DateTime t_transcript_completion_date_time { get; set; }
        public string t_transcript_completion_type_id_fk { get; set; }
        public string t_transcript_marked_by_user_id_fk { get; set; }
        public bool t_transcript_required_flag { get; set; }
        public DateTime t_transcript_target_due_date { get; set; }
        public DateTime t_transcript_actual_date { get; set; }
        public string t_transcript_status_id_fk { get; set; }
        public int t_transcript_time_spent { get; set; }
        public int t_transcript_score { get; set; }
        public int t_transcript_credits { get; set; }
        public int t_transcript_hours { get; set; }
        public bool t_transcript_active_flag { get; set; }

        public string t_transcript_status_name { get; set; }


        public string t_transcript_session_id_fk { get; set; }
        // public string t_transcript_id_pk { get; set; }
        public string t_transcript_session_user_id_fk { get; set; }
        public string t_transcript_sessiont_course_id_fk { get; set; }
        public string t_transcript_session_delivery_id_fk { get; set; }
        public string t_transcript_session_roster_id_fk { get; set; }
        public string t_transcript_session_attendance_id_fk { get; set; }
        public string t_transcript_session_passing_status_id_fk { get; set; }
        public string t_transcript_session_grade_id_fk { get; set; }
        public int t_transcript_session_completion_score { get; set; }
        public DateTime t_transcript_session_completion_date_time { get; set; }
        public string t_transcript_session_completion_type_id_fk { get; set; }
        public string t_transcript_session_marked_by_user_id_fk { get; set; }
        public DateTime t_transcript_session_actual_date { get; set; }
        public string t_transcript_session_status_id_fk { get; set; }
        public bool t_transcript_session_active_flag { get; set; }



        //  t_transcript_session_id_fk
        //t_transcript_id_pk
        //t_transcript_session_user_id_fk
        //t_transcript_sessiont_course_id_fk
        //t_transcript_session_delivery_id_fk
        //t_transcript_session_roster_id_fk
        //t_transcript_session_attendance_id_fk
        //t_transcript_session_passing_status_id_fk
        //t_transcript_session_grade_id_fk
        //t_transcript_session_completion_score
        //t_transcript_session_completion_date_time
        //t_transcript_session_completion_type_id_fk
        //t_transcript_session_marked_by_user_id_fk
        //t_transcript_session_actual_date
        //t_transcript_session_status_id_fk
        // t_transcript_session_active_flag

    }
}
