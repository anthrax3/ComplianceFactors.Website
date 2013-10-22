using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemReport
    {
        public string s_report_id_pk { get; set; }
        public string s_report_system_id_pk { get; set; }
        public string s_report_name { get; set; }
        public string s_report_description { get; set; }
        public string s_report_type_id_fk { get; set; }
        public bool? s_report_on_off_flag { get; set; }
        public bool s_report_manager_flag { get; set; }
        public bool s_report_compliance_flag { get; set; }
        public bool s_report_instructor_flag { get; set; }
        public bool s_report_coordinator_flag { get; set; }
        public bool s_report_admin_flag { get; set; }
        public string s_report_source_file_name { get; set; }
        public string s_report_locale { get; set; }
        public string s_report_param { get; set; }
        public string s_report_column { get; set; }
        public string s_report_label_locale { get; set; }
    }
}
