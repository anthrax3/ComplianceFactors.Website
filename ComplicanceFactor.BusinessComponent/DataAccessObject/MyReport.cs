using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class MyReport
    {
        public string s_report_users_system_id_pk { get; set; }
        public string u_user_id_fk { get; set; }
        public string s_report_id_fk { get; set; }
        public string s_report_users_report_name { get; set; }
        public string s_report_users_when_to_run { get; set; }
        public string s_report_users_when_to_run_from { get; set; }
        public string s_report_users_when_to_run_to { get; set; }
        public string s_report_users_mails { get; set; }
        public string s_report_users_mailto { get; set; }
        public string s_report_users_params { get; set; }
    }
}
