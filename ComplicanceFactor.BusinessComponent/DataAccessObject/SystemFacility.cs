using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemFacility
    {
        public string s_facility_system_id_pk { get; set; }
        public string s_facility_id_pk { get; set; }
        public string s_facility_name { get; set; }
        public string s_facility_desc { get; set; }
        public string s_facility_status_id_fk { get; set; }
        public string s_facility_type_id_fk { get; set; }
        public string s_facility_contact { get; set; }
        public string s_facility_email_address { get; set; }
        public string s_facility_phone { get; set; }
        public string s_facility_address { get; set; }
        public string s_facility_address1 { get; set; }
        public string s_facility_address2 { get; set; }
        public string s_facility_city { get; set; }
        public string s_facility_state { get; set; }
        public string s_facility_zip_code { get; set; }
        public int s_facility_country_id_fk { get; set; }
        public string s_facility_locale_id_fk { get; set; }
        public int s_facility_time_zone_id_fk { get; set; }
        //locale
        public string s_facility_locale { get; set; }
        public string s_facility_locale_system_id_pk { get; set; }
        public string s_facility_locale_name { get; set; }
        public string s_facility_locale_description { get; set; }
        public string s_locale_text { get; set; }
        public string s_locale_id_fk { get; set; }
        public string s_facility_system_id_fk { get; set; }
        //room
        public string s_room { get; set; }
        //resource
        public string s_room_resource { get; set; }
        public string s_room_system_id_pk { get; set; }
    }
}
