using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemSplashPage
    {
        public string u_splash_system_id_pk { get; set; }
        public string u_splash_id_pk { get; set; }
        public string u_splash_name { get; set; }
        public string u_splash_content { get; set; }
        public string u_splash_status_id_fk { get; set; }
        public string u_splash_owner_id_fk { get; set; }
        public string u_splash_coordinator_id_fk { get; set; }
        public string u_splash_domain_id_fk { get; set; }

        //for copy
        public string u_splash_locales_xml { get; set; }

        //search
        public string u_splash_coordinator_name { get; set; }
        public string u_splash_owner_name { get; set; }

        //locale

        public string u_splash_locale_system_id_pk { get; set; }
        public string u_splash_locale_id_fk { get; set; }
        public string u_splash_system_id_fk { get; set; }
        public string u_splash_locale_content { get; set; }
    }
}
