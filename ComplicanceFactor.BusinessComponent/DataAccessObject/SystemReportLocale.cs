using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemReportLocale
    {
        public string s_locale_system_id_pk { get; set; }
        public string s_locale_id_pk { get; set; }
        public string s_locale_title { get; set; }
        public string s_locale_description { get; set; }
        public string s_locale_text { get; set; }
        public string s_report_system_id_fk { get; set; }
    }
}
