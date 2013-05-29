using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class Enrollment
    {
        public string e_enroll_system_id_pk { get; set; }
        public string e_enroll_user_id_fk { get; set; }
        public string e_enroll_course_id_fk { get; set; }
        public string e_enroll_delivery_id_fk { get; set; }
        public DateTime e_enroll_enroll_date_time { get; set; }
        public DateTime e_enroll_expire_date { get; set; }
        public string e_enroll_enroll_type_id_fk { get; set; }
        public bool e_enroll_required_flag { get; set; }
        public bool e_enroll_approval_required_flag { get; set; }
        public string e_enroll_approval_status_id_fk { get; set; }
        public DateTime e_enroll_approval_date { get; set; }
        public DateTime? e_enroll_target_due_date { get; set; }
        public string e_enroll_status_id_fk { get; set; }
        public DateTime e_enroll_assign_recert_due_date { get; set; }
        public string e_enroll_assign_recert_status_id_fk { get; set; }
        public int e_enroll_time_spent { get; set; }
        public string e_enroll_lesson_location { get; set; }
        public string e_enroll_suspend_data { get; set; }
        public int e_enroll_score { get; set; }
        public bool e_enroll_active_flag { get; set; }
        public string e_enroll_type_name { get; set; }
        public string e_enroll_approval_status_name { get; set; }
        public string e_enroll_status_name { get; set; }
        public string e_tb_enrollment_type_name { get; set; }
        public int e_enroll_waitlist_count { get; set; }
        //assign curricula
        public string e_curriculum_assign_system_id_pk { get; set; }
        public string e_curriculum_assign_user_id_fk { get; set; }
        public string e_curriculum_assign_curriculum_id_fk { get; set; }
        public DateTime e_curriculum_assign_date_time { get; set; }
        public bool e_curriculum_assign_required_flag { get; set; }
        public DateTime? e_curriculum_assign_target_due_date { get; set; }
        public DateTime? e_curriculum_assign_recert_due_date { get; set; }
        public string e_curriculum_assign_recert_status_id_fk { get; set; }
        public string e_curriculum_assign_status_id_fk { get; set; }
        public int e_curriculum_assign_percent_complete { get; set; }
        public bool e_curriculum_assign_active_flag { get; set; }        
        //waitlist
        public string e_enroll_waitlist_system_id_pk { get; set; }
        public string e_enroll_waitlist_course_id_fk { get; set; }
        public string e_enroll_waitlist_course_delivery_id_fk { get; set; }
        public string e_enroll_waitlist_user_id_fk { get; set; }

        public string e_enroll_approval_system_id_pk { get; set; }
        public DateTime e_enroll_request_date { get; set; }
        public string e_enroll_id_fk { get; set; }
        public bool e_enroll_level_1_req_flag { get; set; }
        public bool e_enroll_approver_1_type { get; set; }
        public string e_enroll_approver_1_id_fk { get; set; }
        public bool e_enroll_approver_1_decision_flag { get; set; }
        public DateTime? e_enroll_approver_1_decision_date { get; set; }
        public bool e_enroll_level_2_req_flag { get; set; }
        public bool e_enroll_approver_2_type { get; set; }
        public string e_enroll_approver_2_id_fk { get; set; }
        public bool e_enroll_approver_2_decision_flag { get; set; }
        public DateTime? e_enroll_approver_2_decision_date { get; set; }
        public bool e_enroll_level_3_req_flag { get; set; }
        public bool e_enroll_approver_3_type { get; set; }
        public string e_enroll_approver_3_id_fk { get; set; }
        public bool e_enroll_approver_3_decision_flag { get; set; }
        public DateTime? e_enroll_approver_3_decision_date { get; set; }
        public string e_enroll_enroll_approval_status_id_fk { get; set; }
        public DateTime? e_enroll_approval_final_decision_date { get; set; }
        public bool e_check_course_approval { get; set; }
        public bool e_check_delivery_approval { get; set; }
        //Couse assign
        public string e_course_assign_system_id_pk { get; set; }
        public string e_course_assign_user_id_fk { get; set; }
        public string e_course_assign_course_id_fk { get; set; }
        public string e_course_assign_type_id_fk { get; set; }
        public string e_course_assign_by_id_fk { get; set; }
        public DateTime e_course_assign_date_time { get; set; }
        public bool e_course_assign_required_flag { get; set; }
        public DateTime? e_course_assign_target_due_date { get; set; }
        public DateTime? e_course_assign_recert_due_date { get; set; }
        public string e_course_assign_recert_status_id_fk { get; set; }
        public string e_course_assign_status_id_fk { get; set; }
        public int e_course_assign_percent_complete { get; set; }
        public bool e_course_assign_active_flag { get; set; }
        public string e_assign_course { get; set; }
        public string e_enroll_manger_id_fk { get; set; }
        public int e_approval_count { get; set; }
        
        //Learning History

        public DateTime? e_learning_from_date { get; set; }
        public DateTime? e_learning_to_date { get; set; }
        public string e_learning_keyword { get; set; }
        public string e_learning_status { get; set; }
        public string e_learning_deliveryType { get; set; }
        public bool e_re_enroll { get; set; }

        //Waitlist - for move roaster
        public string e_course_waitlist_system_id_pk { get; set; }

    }
}
