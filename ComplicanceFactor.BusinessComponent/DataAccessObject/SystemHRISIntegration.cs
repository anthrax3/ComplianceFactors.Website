using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemHRISIntegration
    {
        public string u_sftp_id_pk { get; set; }
        public string u_sftp_URI { get; set; }
        public string u_sftp_port { get; set; }
        public string u_sftp_username { get; set; }
        public string u_sftp_password { get; set; }
        public string u_sftp_hris_filename { get; set; }
        public string u_sftp_occurs_every { get; set; }
        public string u_sftp_time_every { get; set; }
        public string u_sftp_start_date { get; set; }
    }
}
