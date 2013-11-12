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
    public class MyReportBLL
    {
         /// <summary>
        /// Create the Report
        /// </summary>
        /// <param name="createMaterial"></param>
        /// <returns></returns>
        public static int CreateNewReport(MyReport report)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_users_system_id_pk", report.s_report_users_system_id_pk);
            htReport.Add("@u_user_id_fk", report.u_user_id_fk);
            htReport.Add("@s_report_id_fk", report.s_report_id_fk);
            htReport.Add("@s_report_users_report_name", report.s_report_users_report_name);
            htReport.Add("@s_report_users_when_to_run", report.s_report_users_when_to_run);

            if (!string.IsNullOrEmpty(report.s_report_users_mailto))
            {
                htReport.Add("@s_report_users_mailto", report.s_report_users_mailto);
            }
            else
            {
                htReport.Add("@s_report_users_mailto", DBNull.Value);
            }
           
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_my_report", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateReport(MyReport report)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_users_system_id_pk", report.s_report_users_system_id_pk);
         
            htReport.Add("@s_report_users_report_name", report.s_report_users_report_name);
            htReport.Add("@s_report_users_when_to_run", report.s_report_users_when_to_run);

            if (!string.IsNullOrEmpty(report.s_report_users_mailto))
            {
                htReport.Add("@s_report_users_mailto", report.s_report_users_mailto);
            }
            else
            {
                htReport.Add("@s_report_users_mailto", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_my_report", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchReport(string u_user_id_fk)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@u_user_id_fk", u_user_id_fk);
          
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_my_report", htReport);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static MyReport SearchReportById(string s_report_users_system_id_pk,out DataTable dtMailUsers)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_users_system_id_pk", s_report_users_system_id_pk);

            try
            {
                DataSet dsMyReport =  DataProxy.FetchDataSet("s_sp_search_my_report_by_id", htReport);
                DataTable dtMyReport = dsMyReport.Tables[0];
                dtMailUsers = dsMyReport.Tables[1];
                MyReport myReport = new MyReport()
                {
                    s_report_id_fk = dtMyReport.Rows[0]["s_report_id_fk"].ToString(),
                    s_report_users_report_name = dtMyReport.Rows[0]["s_report_users_report_name"].ToString(),
                    s_report_users_system_id_pk = dtMyReport.Rows[0]["s_report_users_system_id_pk"].ToString(),
                    s_report_users_when_to_run = dtMyReport.Rows[0]["s_report_users_when_to_run"].ToString(),
                    u_user_id_fk = dtMyReport.Rows[0]["u_user_id_fk"].ToString()
                };
                return myReport;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteById(string s_report_users_mailto_system_id_pk)
        {
            Hashtable htReport = new Hashtable();
            htReport.Add("@s_report_users_mailto_system_id_pk", s_report_users_mailto_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_report_users_mailto", htReport);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int ManageLastGenerate(string s_report_users_system_id_fk,string s_report_system_id_fk,string s_report_last_generate)
        {
            Hashtable htReport = new Hashtable();
            if (!string.IsNullOrEmpty(s_report_users_system_id_fk))
            {
                htReport.Add("@s_report_users_system_id_fk", s_report_users_system_id_fk);
            }
            else
            {
                htReport.Add("@s_report_users_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_report_system_id_fk))
            {
                htReport.Add("@s_report_system_id_fk", s_report_system_id_fk);
            }
            else
            {
                htReport.Add("@s_report_system_id_fk", DBNull.Value);
            }
            htReport.Add("@s_report_last_generate", s_report_last_generate);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_manage_reports_users_last_generate", htReport);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable SearchLastGenerate(string s_report_users_system_id_fk, string s_report_system_id_fk)
        {
            Hashtable htReport = new Hashtable();
            if (!string.IsNullOrEmpty(s_report_users_system_id_fk))
            {
                htReport.Add("@s_report_users_system_id_fk", s_report_users_system_id_fk);
            }
            else
            {
                htReport.Add("@s_report_users_system_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_report_system_id_fk))
            {
                htReport.Add("@s_report_system_id_fk", s_report_system_id_fk);
            }
            else
            {
                htReport.Add("@s_report_system_id_fk", DBNull.Value);
            }
        
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_reports_users_last_generate", htReport);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
