using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemDocuments
    {
        public string s_document_system_id_pk{get;set;}
	    public string s_document_id_pk{get;set;}
	    public string s_document_name{get;set;}
	    public string s_document_description{get;set;}
	    public string s_document_status_id_fk{get;set;}
	    public string s_document_type_fk{get;set;}
	    public string s_document_version{get;set;}
	    public string s_documnet_attachment_file_guid{get;set;}
        public string s_document_attachment_file_name { get; set; }
        public string s_document_locale { get; set; }

        public string s_document_locale_system_id_pk{get;set;}
	    public string s_document_id_fk{get;set;}
	    public string s_document_locale_id_fk{get;set;}
	    public string s_document_locale_name{get;set;}
	    public string s_document_locale_description{get;set;}
	    public string s_document_locale_file_path{get;set;}
        public string s_document_locale_file_name { get; set; }
        public string s_locale_text { get; set; }

        public bool s_copy_document { get; set; }
        public bool s_copy_locale { get; set; }
        public string s_new_document_system_id_pk { get; set; }

        public string s_document_category { get; set; }

    }
}
