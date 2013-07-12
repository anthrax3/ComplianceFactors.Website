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

        public static SystemHRISIntegration GetSingleDataImport(string u_sftp_id_pk)
        {
            Hashtable htGetSingleDataImport = new Hashtable();
            htGetSingleDataImport.Add("@u_sftp_id_pk", u_sftp_id_pk);

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            DataTable dtSingleDataImport = new DataTable();
            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_single_data_import", htGetSingleDataImport);
                if (dtSingleDataImport.Rows.Count > 0)
                {                    
                    dataImport.u_sftp_URI = dtSingleDataImport.Rows[0]["u_sftp_URI"].ToString();
                    dataImport.u_sftp_port = dtSingleDataImport.Rows[0]["u_sftp_port"].ToString();
                    dataImport.u_sftp_username = dtSingleDataImport.Rows[0]["u_sftp_username"].ToString();
                    dataImport.u_sftp_password = dtSingleDataImport.Rows[0]["u_sftp_password"].ToString();
                    dataImport.u_sftp_imp_is_enrollment = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_imp_is_enrollment"]);
                    dataImport.u_sftp_imp_enrollment_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_enrollment_filename"].ToString();
                    dataImport.u_sftp_imp_is_learning_history = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_imp_is_learning_history"]);
                    dataImport.u_sftp_imp_learning_history_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_learning_history_filename"].ToString();
                    dataImport.u_sftp_imp_facility_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_facility_filename"].ToString();
                    dataImport.u_sftp_imp_room_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_room_filename"].ToString();
                    dataImport.u_sftp_imp_course_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_course_filename"].ToString();
                    dataImport.u_sftp_imp_base_curricula_filename = dtSingleDataImport.Rows[0]["u_sftp_imp_base_curricula_filename"].ToString();
                    dataImport.u_sftp_occurs_every = dtSingleDataImport.Rows[0]["u_sftp_occurs_every"].ToString();
                    dataImport.u_sftp_time_every = dtSingleDataImport.Rows[0]["u_sftp_time_every"].ToString();
                    dataImport.u_sftp_start_date = dtSingleDataImport.Rows[0]["u_sftp_start_date"].ToString();
                }

                return dataImport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemHRISIntegration GetSingleDataExport(string u_sftp_id_pk)
        {
            Hashtable htGetSingleDataExport = new Hashtable();
            htGetSingleDataExport.Add("@u_sftp_id_pk", u_sftp_id_pk);

            SystemHRISIntegration dataImport = new SystemHRISIntegration();

            DataTable dtSingleDataImport = new DataTable();
            try
            {
                dtSingleDataImport = DataProxy.FetchDataTable("s_sp_get_single_data_export", htGetSingleDataExport);
                if (dtSingleDataImport.Rows.Count > 0)
                {
                     
                    dataImport.u_sftp_URI = dtSingleDataImport.Rows[0]["u_sftp_URI"].ToString();
                    dataImport.u_sftp_port = dtSingleDataImport.Rows[0]["u_sftp_port"].ToString();
                    dataImport.u_sftp_username = dtSingleDataImport.Rows[0]["u_sftp_username"].ToString();
                    dataImport.u_sftp_password = dtSingleDataImport.Rows[0]["u_sftp_password"].ToString();

                    dataImport.u_sftp_exp_is_hris = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_hris"]);
                    dataImport.u_sftp_exp_hris_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_hris_filename"].ToString();
                    dataImport.u_sftp_exp_is_catalog_offering = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_catalog_offering"]);
                    dataImport.u_sftp_exp_catalog_offering_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_catalog_offering_filename"].ToString();
                    dataImport.u_sftp_exp_is_learning_history = Convert.ToBoolean(dtSingleDataImport.Rows[0]["u_sftp_exp_is_learning_history"]);
                    dataImport.u_sftp_exp_learning_history_filename = dtSingleDataImport.Rows[0]["u_sftp_exp_learning_history_filename"].ToString();

                    dataImport.u_sftp_occurs_every = dtSingleDataImport.Rows[0]["u_sftp_occurs_every"].ToString();
                    dataImport.u_sftp_time_every = dtSingleDataImport.Rows[0]["u_sftp_time_every"].ToString();
                    dataImport.u_sftp_start_date = dtSingleDataImport.Rows[0]["u_sftp_start_date"].ToString();
                }

                return dataImport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBackgroundInformation(string currntTime, string currentDate)
        {
            Hashtable htGetBackground = new Hashtable();
            htGetBackground.Add("@u_sftp_time_every", currntTime);
            htGetBackground.Add("@u_sftp_start_date", currentDate);

            try
            {
                return DataProxy.FetchDataTable("s_sp_get_for_background_information", htGetBackground);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateNewFacility(SystemFacility createFacility)
        {
            Hashtable htcreateFacility = new Hashtable();            
            htcreateFacility.Add("@c_facility_id_pk", createFacility.s_facility_id_pk);
            htcreateFacility.Add("@c_facility_name", createFacility.s_facility_name);
            htcreateFacility.Add("@c_facility_desc", createFacility.s_facility_desc);
            htcreateFacility.Add("@c_facility_status_id_fk", createFacility.s_facility_status_id_fk);
            htcreateFacility.Add("@c_facility_type_id_fk", createFacility.s_facility_type_id_fk);
            htcreateFacility.Add("@c_facility_contact", createFacility.s_facility_contact);
            htcreateFacility.Add("@c_facility_email_address", createFacility.s_facility_email_address);
            htcreateFacility.Add("@c_facility_phone", createFacility.s_facility_phone);
            htcreateFacility.Add("@c_facility_address", createFacility.s_facility_address);
            htcreateFacility.Add("@c_facility_address1", createFacility.s_facility_address1);
            htcreateFacility.Add("@c_facility_address2", createFacility.s_facility_address2);
            htcreateFacility.Add("@c_facility_city", createFacility.s_facility_city);
            htcreateFacility.Add("@c_facility_state", createFacility.s_facility_state);
            htcreateFacility.Add("@c_facility_zip_code", createFacility.s_facility_zip_code);
            //htcreateFacility.Add("@c_facility_country_id_fk", createFacility.s_facility_country_id_fk);
            //htcreateFacility.Add("@c_facility_locale_id_fk", createFacility.s_facility_locale_id_fk);
            htcreateFacility.Add("@c_facility_time_zone_id_fk", createFacility.s_facility_time_zone_id_fk);
            
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_facility_background", htcreateFacility);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
