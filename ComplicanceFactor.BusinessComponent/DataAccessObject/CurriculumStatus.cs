using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class CurriculumStatus
    {
        public string e_curriculum_assign_system_id_pk { get; set; }
        public string e_curriculum_assign_user_id_fk { get; set; }
        public string e_curriculum_assign_curriculum_id_fk { get; set; }
        public DateTime e_curriculum_assign_date_time { get; set; }
        public bool e_curriculum_assign_required_flag { get; set; }
        public DateTime? e_curriculum_assign_original_target_due_date { get; set; }
        public DateTime e_curriculum_assign_status_change_date_time { get; set; }
        public string e_curriculum_assign_after_status_id_fk { get; set; }
        public DateTime? e_curriculum_assign_cert_date { get; set; }
        public DateTime? e_curriculum_assign_recert_due_date { get; set; }
        public string e_curriculum_assign_recert_status_change_type_id_fk { get; set; }
        public string e_curriculum_assign_recert_status_change_user_id_fk { get; set; }
        public string e_curriculum_before_status_id_fk { get; set; }
        public int e_curriculum_assign_percent_complete { get; set; }
        public bool e_curriculum_assign_active_flag { get; set; }
        public string e_curriculum_status_change_notes { get; set; }
    }
}
