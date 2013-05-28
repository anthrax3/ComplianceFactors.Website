using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SiteViewFieldNotes
    {

        public string sv_fieldnote_id_pk { get; set; }
        public string sv_fieldnote_created_by_fk { get; set; }
        public string sv_fieldnote_title { get; set; }
        public string sv_fieldnote_description { get; set; }
        public string sv_fieldnote_location { get; set; }
        public string sv_fieldnote_creation_date { get; set; }
        public bool sv_fieldnote_is_save_sync { get; set; }
        //public bool sv_fieldnote_status { get; set; }
        public string sv_fieldnote_id { get; set; }
        public string sv_fieldnote_created_by { get; set; }

        public string sv_fieldnote_attachment { get; set; }
        public bool sv_fieldnote_is_acknowledge { get; set; }

        //FieldNotes Attachments

        public string sv_fieldnotes_attachments_id_pk { get; set; }
        public string sv_fieldnotes_id_fk { get; set; }
        public string sv_file_path { get; set; }
        public string sv_file_type { get; set; }
        public string sv_file_name { get; set; }
         

        //Sent to Users
        public string sv_fieldnote_sent_to_id_pk { get; set; }
        public string sv_fieldnote_id_fk { get; set; }
        public string sv_fieldnote_sent_to_user_fk { get; set; }
        public bool sv_fieldnote_is_need_acknowledged { get; set; }
        public bool sv_fieldnote_acknowledged_status { get; set; }
        public bool sv_fieldnote_is_sync_mobile { get; set; }

        public string sv_mi_fieldnote_sent_to_user { get; set; }


        //User Archive
        public string sv_fieldnote_user_archive_id_pk { get; set; }
        //public string sv_fieldnote_id_fk { get; set; }
        public string sv_fieldnote_user_id { get; set; }
        public bool sv_fieldnote_is_sento_archive { get; set; }
        public bool sv_fieldnote_is_saved_archive { get; set; }
        public bool sv_fieldnote_is_received_archive { get; set; }
    }
}
