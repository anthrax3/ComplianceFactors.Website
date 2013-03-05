using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemHRISIntegrationBLL
    {
        public static int CreateHRIS(SystemHRISIntegration createHRIS)
        {

            Hashtable htCreateHRIS = new Hashtable();
            htCreateHRIS.Add("@u_sftp_URI", createHRIS.u_sftp_URI);
            htCreateHRIS.Add("@u_sftp_port", createHRIS.u_sftp_port);
            htCreateHRIS.Add("@u_sftp_username", createHRIS.u_sftp_username);
            htCreateHRIS.Add("@u_sftp_password", createHRIS.u_sftp_password);
            htCreateHRIS.Add("@u_sftp_hris_filename", createHRIS.u_sftp_hris_filename);
            htCreateHRIS.Add("@u_sftp_occurs_every", createHRIS.u_sftp_occurs_every);
            htCreateHRIS.Add("@u_sftp_time_every", createHRIS.u_sftp_time_every);
            htCreateHRIS.Add("@u_sftp_start_date", createHRIS.u_sftp_start_date);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_sftp_info", htCreateHRIS);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
