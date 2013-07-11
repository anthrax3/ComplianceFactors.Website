using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SiteViewOnJobTraining
    {
        public string sv_ojt_id_pk{get;set;}
	    public string sv_ojt_created_by_fk{get;set;}
        public string sv_ojt_number { get; set; }
	    public string sv_ojt_title{get;set;}
	    public string sv_ojt_description{get;set;}
	    public string sv_ojt_location{get;set;}
	    public string sv_ojt_Trainer{get;set;}
	    public DateTime sv_ojt_date{get;set;}
        public string sv_ojt_start_time { get; set; }
	    public string sv_ojt_end_time{get;set;}

        public int start_HH { get; set; }
        public int start_MM { get; set; }
        public string start_HH_text { get; set; }

        public int end_HH { get; set; }
        public int end_MM { get; set; }
        public string end_HH_text { get; set; }

	    public string sv_ojt_duration{get;set;}
	    public string sv_ojt_type{get;set;}	    
	    public string sv_ojt_frequency{get;set;}
        public bool sv_ojt_issafty_brief { get; set; }
	    public bool sv_ojt_isharm_related{get;set;}
        public bool sv_ojt_iscertification_related { get; set; }
	    public string sv_ojt_harm_title{get;set;}
	    public string sv_ojt_harm_number{get;set;}	    
	    public string sv_ojt_other{get;set;}
	    public string sv_ojt_creation_date_time{get;set;}
	    public string sv_ojt_last_modify_date_time{get;set;}
	    public string sv_ojt_is_completed{get;set;}
        public string sv_ojt_status { get; set; }
        public bool sv_ojt_is_acknowledge { get; set; }
        public string sv_ojt_harm_id_fk { get; set; }
        public string sv_ojt_certify_filepath { get; set; }
        public string harmTitle { get; set; }
        //Attachments
        public string sv_ojt_attachments_id_pk{get;set;}
	    public string sv_ojt_id_fk{get;set;}
	    public string sv_file_path{get;set;}
        public string sv_file_type { get; set; }
        public string sv_file_name { get; set; }
        public bool sv_ojt_is_save_sync { get; set; }

        //Sent to user
        public string sv_ojt_sent_to_id_pk{get;set;}
	    public string sv_ojt_sent_to_user_fk{get;set;}
	    public string sv_ojt_is_acknowledged{get;set;}
	    public string sv_ojt_acknowledged_status{get;set;}
	    public string sv_ojt_is_sync_mobile{get;set;}
        public string sv_ojt_is_archive { get; set; }

        //For xml
        public string sv_ojt_attachment { get; set; }
        public string sv_mi_ojt_sent_to_user { get; set; }
    }
}
