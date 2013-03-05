using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemRoom
    {
        public string s_room_system_id_pk { get; set; }
        public string s_room_id_pk { get; set; }
        public string s_room_name { get; set; }
        public string s_room_desc { get; set; }
        public string s_room_status_id_fk { get; set; }
        public string s_room_type_id_fk { get; set; }
        public string s_room_facility_id_fk { get; set; }
        public string s_room_locale { get; set; }
        public string s_room_resource { get; set; }

        public string s_room_locale_system_id_pk { get; set; }
        public string s_room_locale_name { get; set; }
        public string s_room_locale_description { get; set; }
        public string s_locale_text { get; set; }
        public string s_locale_id_fk { get; set; }
        public string s_room_system_id_fk { get; set; }
        public string s_facility_name { get; set; }
    }
}
