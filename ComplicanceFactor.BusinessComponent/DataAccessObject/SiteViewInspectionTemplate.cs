using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SiteViewInspectionTemplate
    {
        public string sv_mi_templete_id_pk { get; set; }
        public string sv_mi_templete_id { get; set; }
        public string sv_mi_templete_title { get; set; }
        public string sv_mi_templete_description { get; set; }
        public string sv_mi_templete_created_by_fk { get; set; }
        public DateTime sv_mi_templete_created_date { get; set; }
        public DateTime sv_mi_templete_last_modify_date { get; set; }
        public bool sv_mi_templete_is_default { get; set; }
        public string sv_mi_templete_status { get; set; }
        public string sv_mi_questions { get; set; }
        

        //Site View Question

        public string sv_mi_templete_question_id_pk { get; set; }
        public string sv_mi_templete_id_fk { get; set; }
        public string sv_mi_templete_question { get; set; }
        public int sv_mi_templete_question_type { get; set; }
        public string sv_mi_templete_question_answer_optionsA { get; set; }
        public string sv_mi_templete_question_answer_optionsB { get; set; }
        public string sv_mi_templete_question_answer_optionsC { get; set; }
        public string sv_mi_templete_question_answer_optionsD { get; set; }
        public int sv_mi_templete_question_display_order { get; set; }
        public string sv_mi_templete_question_answer { get; set; }
    }
}
