using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class Sessioninfo
    {

        public string sessionguid { get; set; }
        public string userid { get; set; }
        public string sessionid { get; set; }
        public DateTime sessionstart_time { get; set; }
        public DateTime sessionend_time { get; set; }
        public string securityroles { get; set; }
        public string IPaddress { get; set; }
        public string useragent { get; set; }

    }
}
