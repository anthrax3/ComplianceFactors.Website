using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemDomain
    {
        public string u_domain_id_pk { get; set; }
        public string u_domain_name { get; set; }
        public string u_domain_desc { get; set; }
        public string u_domain_branding_id_fk { get; set; }
        public string u_domain_parent_id_fk { get; set; }
        public string u_domain_status_id_fk { get; set; }
        public string u_domain_owner_id_fk { get; set; }
        public string u_domain_coordinator_id_fk { get; set; }
        public string u_domain_theme_id_fk { get; set; }
        public string u_domain_system_id_pk { get; set; }
        public string u_domain_owner_text { get; set; }
        public string u_domain_coordinator_text { get; set; }

    }
}
