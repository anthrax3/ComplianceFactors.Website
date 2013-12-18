using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemEstablishment
    {
        public string s_establishment_system_id_pk { get; set; }
        public string s_establishment_id_pk { get; set; }
        public string s_establishment_name { get; set; }
        public string s_establishment_desc { get; set; }
        public string s_establishment_status_id_fk { get; set; }
    
      
        public string s_establishment_city { get; set; }
        public string s_establishment_state { get; set; }
        public string s_establishment_zip_code { get; set; }
        public int s_establishment_country_id_fk { get; set; }
        public string s_establishment_locale_id_fk { get; set; }
        public int s_establishment_time_zone_id_fk { get; set; }
        //locale
        public string s_establishment_locale { get; set; }
        public string s_establishment_locale_system_id_pk { get; set; }
        public string s_establishment_locale_name { get; set; }
        public string s_establishment_locale_description { get; set; }
        public string s_locale_text { get; set; }
        public string s_locale_id_fk { get; set; }
        public string s_establishment_system_id_fk { get; set; }
        //room
        public string s_room { get; set; }
        //resource
        public string s_room_resource { get; set; }
        public string s_room_system_id_pk { get; set; }
    }
}
