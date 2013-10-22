using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemReportColumn
    {
        public string s_report_column_system_id_pk { get; set; }
        public string s_report_system_id_fk { get; set; }
        public string s_report_column_id_pk { get; set; }
        public string s_report_column_name { get; set; }
        public string s_report_column_description { get; set; }
        public string s_report_column_type_id_fk { get; set; }
        public bool s_report_column_visible_flag { get; set; }
        public string s_report_column_table_id_pk { get; set; }
        public string s_report_column_field_id_pk { get; set; }
        public string s_report_column_label_name { get; set; }
    }
}
