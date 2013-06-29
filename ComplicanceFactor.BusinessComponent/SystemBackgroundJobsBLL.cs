using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;

namespace ComplicanceFactor.BusinessComponent
{
    public  class SystemBackgroundJobsBLL
    {
        public static DataTable GetBackgroundJobs()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_background_jobs");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleHRIS(string hrisId)
        {
            Hashtable htGetSingleHris = new Hashtable();
            htGetSingleHris.Add("@u_sftp_id_pk", hrisId);

            SystemHRISIntegration hrisIntegration = new SystemHRISIntegration();

            DataTable dtSingleHris = new DataTable();
            try
            {
                dtSingleHris = DataProxy.FetchDataTable("s_sp_get_single_HRIS", htGetSingleHris);
                if (dtSingleHris.Rows.Count > 0)
                {
                    hrisIntegration.u_sftp_URI = dtSingleHris.Rows[0]["u_sftp_URI"].ToString();
                    hrisIntegration.u_sftp_port = dtSingleHris.Rows[0]["u_sftp_port"].ToString();
                    hrisIntegration.u_sftp_username = dtSingleHris.Rows[0]["u_sftp_username"].ToString();
                    hrisIntegration.u_sftp_password = dtSingleHris.Rows[0]["u_sftp_password"].ToString();
                    hrisIntegration.u_sftp_hris_filename = dtSingleHris.Rows[0]["u_sftp_hris_filename"].ToString();
                    hrisIntegration.u_sftp_occurs_every = dtSingleHris.Rows[0]["u_sftp_occurs_every"].ToString();
                    hrisIntegration.u_sftp_time_every = dtSingleHris.Rows[0]["u_sftp_time_every"].ToString();
                    hrisIntegration.u_sftp_start_date = dtSingleHris.Rows[0]["u_sftp_start_date"].ToString();
                }

                return hrisIntegration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateHRIS(SystemHRISIntegration createHRIS)
        {

            Hashtable htUpdateHRIS = new Hashtable();
            htUpdateHRIS.Add("@u_sftp_id_pk", createHRIS.u_sftp_id_pk);
            htUpdateHRIS.Add("@u_sftp_URI", createHRIS.u_sftp_URI);
            htUpdateHRIS.Add("@u_sftp_port", createHRIS.u_sftp_port);
            htUpdateHRIS.Add("@u_sftp_username", createHRIS.u_sftp_username);
            htUpdateHRIS.Add("@u_sftp_password", createHRIS.u_sftp_password);
            htUpdateHRIS.Add("@u_sftp_hris_filename", createHRIS.u_sftp_hris_filename);
            htUpdateHRIS.Add("@u_sftp_occurs_every", createHRIS.u_sftp_occurs_every);
            htUpdateHRIS.Add("@u_sftp_time_every", createHRIS.u_sftp_time_every);
            htUpdateHRIS.Add("@u_sftp_start_date", createHRIS.u_sftp_start_date);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_sftp_info", htUpdateHRIS);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
