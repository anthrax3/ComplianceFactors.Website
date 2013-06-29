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


        //Hris run log

        public string u_sftp_run_id_pk { get; set; }
        public string u_sftp_run_date_time_start { get; set; }
        public string u_sftp_run_date_time_end { get; set; }
        public string u_sftp_run_result { get; set; }
        public string u_sftp_run_log_file_transfer { get; set; }
        public string u_sftp_run_errors_details_filename { get; set; }
        public string u_sftp_run_errors_log { get; set; }
        public int u_sftp_run_records_processes { get; set; }
        public int u_sftp_run_records_loaded { get; set; }
        public int u_sftp_run_records_rejected { get; set; }

     
    }
}
