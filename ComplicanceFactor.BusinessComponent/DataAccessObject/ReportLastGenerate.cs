using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class ReportLastGenerate
    {
        public string s_report_users_last_generate_system_id_pk { get; set; }
        public string s_report_users_system_id_fk { get; set; }
        public string s_report_param_system_id_fk { get; set; }
        public string s_report_param_value { get; set; }
        public string s_report_last_generate { get; set; }
     
    }
}
