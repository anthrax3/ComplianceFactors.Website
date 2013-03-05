using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SiteViewInspection
    {
        //Inspection
        public string sv_inspection_id_pk { get; set; }
        public string sv_inspection_created_by_fk { get; set; }
        public string sv_inspection_title { get; set; }
        public string sv_inspection_description { get; set; }
        public string sv_inspection_creation_date { get; set; }
        public string sv_inspection_last_modify_date { get; set; }
        public string sv_inspection_status_id_fk { get; set; }
        public string sv_mi_questions { get; set; }

        //Question
        public string sv_inspection_question_id_pk { get; set; }
        public string sv_inspection_id_fk { get; set; }
        public string sv_inspection_question { get; set; }
        public int sv_inspection_question_type { get; set; }  //1=Fill in the blanks, 2=yes/no questions, 3=MultiChoice
        public string sv_inspection_question_answer_optionsA { get; set; }  //Answer options save with |symbol
        public string sv_inspection_question_answer_optionsB { get; set; }
        public string sv_inspection_question_answer_optionsC { get; set; }
        public string sv_inspection_question_answer_optionsD { get; set; }
        public int sv_inspection_question_display_order { get; set; }


        //sent_users
        public string sv_inspection_sent_to_id_pk { get; set; }
         
        public string sv_inspection_sent_to_user_fk { get; set; }
        public bool sv_inspection_is_acknowledged { get; set; }
        public bool sv_inspection_acknowledged_status { get; set; }
        public bool sv_inspection_is_completed { get; set; }
        public bool sv_inspection_is_completed_sync { get; set; }
        public bool sv_inspection_is_sync_mobile { get; set; }
        public bool sv_inspection_is_archive { get; set; }


        //Field Notes

        public string sv_fieldnote_created_by_fk { get; set; }
    }
}
