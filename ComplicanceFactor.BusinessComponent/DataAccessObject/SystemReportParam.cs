using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemReportParam
    {

        public string s_report_param_system_id_pk { get; set; }
        public string s_report_system_id_fk { get; set; }
        public string s_report_param_id_pk { get; set; }
        public string s_report_param_name { get; set; }
        public string s_report_param_description { get; set; }
        public string s_report_param_type_id_fk { get; set; }
        public bool s_report_param_visible_flag { get; set; }
        public string s_report_param_table_id_pk { get; set; }
        public string s_report_param_field_id_pk { get; set; }
        public string s_report_param_label_name { get; set; }
        public string s_report_param_items { get; set; }
    }
}
