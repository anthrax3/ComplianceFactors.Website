using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemLocation
    {
        public string c_location_system_id_pk { get; set; }
        public string c_location_id_pk { get; set; }
        public string c_location_name { get; set; }
        public string c_location_desc { get; set; }
        public string c_location_airport_code { get; set; }
        public string c_location_status_id_fk { get; set; }
        public string s_location_locale { get; set; }
        public string s_location_locale_system_id_pk { get; set; }
        public string s_location_locale_name { get; set; }
        public string s_location_locale_description { get; set; }
        public string s_locale_text { get; set; }
        public string s_locale_id_fk { get; set; }
        public string s_location_system_id_fk { get; set; }
        public string s_location_airport_code { get; set; }
    }
}
