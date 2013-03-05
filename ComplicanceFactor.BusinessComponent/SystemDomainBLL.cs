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
    public class SystemDomainBLL
    {
        /// <summary>
        /// Get domain status
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDomainStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetDomainStatus = new Hashtable();
                htGetDomainStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetDomainStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_domain_sp_get_status",htGetDomainStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get all domain status
        /// </summary>
        /// <param name="s_ui_locale_name"></param>
        /// <param name="s_ui_page_name"></param>
        /// <returns></returns>
        public static DataTable GetAllDomainStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htAllGetDomainStatus = new Hashtable();
                htAllGetDomainStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htAllGetDomainStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_domain_sp_get_all_status", htAllGetDomainStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get domain themes
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDomainThemes()
        {
            try
            {
                return DataProxy.FetchDataTable("s_domain_sp_get_theme");
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Create new domain
        /// </summary>
        /// <param name="createDomain"></param>
        /// <returns></returns>
        public static int CreateNewDomain(SystemDomain createDomain)
        {
            Hashtable htCreateDomain = new Hashtable();
            htCreateDomain.Add("@u_domain_system_id_pk", createDomain.u_domain_system_id_pk);
            htCreateDomain.Add("@u_domain_id_pk", createDomain.u_domain_id_pk);
            htCreateDomain.Add("@u_domain_name", createDomain.u_domain_name);
            htCreateDomain.Add("@u_domain_desc", createDomain.u_domain_desc);
            htCreateDomain.Add("@u_domain_status_id_fk", createDomain.u_domain_status_id_fk);
            if (!string.IsNullOrEmpty(createDomain.u_domain_owner_id_fk))
            {
                htCreateDomain.Add("@u_domain_owner_id_fk", createDomain.u_domain_owner_id_fk);
            }
            else
            {
                htCreateDomain.Add("@u_domain_owner_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createDomain.u_domain_coordinator_id_fk))
            {
                htCreateDomain.Add("@u_domain_coordinator_id_fk", createDomain.u_domain_coordinator_id_fk);
            }
            else
            {
                htCreateDomain.Add("@u_domain_coordinator_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(createDomain.u_domain_theme_id_fk))
            {
                htCreateDomain.Add("@u_domain_theme_id_fk", createDomain.u_domain_theme_id_fk);
            }
            else
            {
                htCreateDomain.Add("@u_domain_theme_id_fk", DBNull.Value);
            }


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_domain", htCreateDomain);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// update domain
        /// </summary>
        /// <param name="updateDomain"></param>
        /// <returns></returns>
        public static int UpdateDomain(SystemDomain updateDomain)
        {
            Hashtable htUpdateDomain = new Hashtable();
            htUpdateDomain.Add("@u_domain_system_id_pk", updateDomain.u_domain_system_id_pk);
            htUpdateDomain.Add("@u_domain_id_pk", updateDomain.u_domain_id_pk);
            htUpdateDomain.Add("@u_domain_name", updateDomain.u_domain_name);
            htUpdateDomain.Add("@u_domain_desc", updateDomain.u_domain_desc);
            htUpdateDomain.Add("@u_domain_status_id_fk", updateDomain.u_domain_status_id_fk);
            if (!string.IsNullOrEmpty(updateDomain.u_domain_owner_id_fk))
            {
                htUpdateDomain.Add("@u_domain_owner_id_fk", updateDomain.u_domain_owner_id_fk);
            }
            else
            {
                htUpdateDomain.Add("@u_domain_owner_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(updateDomain.u_domain_coordinator_id_fk))
            {
                htUpdateDomain.Add("@u_domain_coordinator_id_fk", updateDomain.u_domain_coordinator_id_fk);
            }
            else
            {
                htUpdateDomain.Add("@u_domain_coordinator_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(updateDomain.u_domain_theme_id_fk))
            {
                htUpdateDomain.Add("@u_domain_theme_id_fk", updateDomain.u_domain_theme_id_fk);
            }
            else
            {
                htUpdateDomain.Add("@u_domain_theme_id_fk", DBNull.Value);
            }


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_domain", htUpdateDomain);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Single Domain
        /// </summary>
        /// <param name="u_domain_system_id_pk"></param>
        /// <returns></returns>
        public static SystemDomain GetSingleDomain(string u_domain_system_id_pk)
        {
              SystemDomain getDomain= new SystemDomain();
              try
              {
                  Hashtable htGetDomain = new Hashtable();
                  htGetDomain.Add("@u_domain_system_id_pk", u_domain_system_id_pk);
                  DataTable dtSingleDomain = DataProxy.FetchDataTable("s_sp_get_single_domain", htGetDomain);
                  getDomain.u_domain_id_pk = dtSingleDomain.Rows[0]["u_domain_id_pk"].ToString();
                  getDomain.u_domain_name = dtSingleDomain.Rows[0]["u_domain_name"].ToString();
                  getDomain.u_domain_desc = dtSingleDomain.Rows[0]["u_domain_desc"].ToString();
                  getDomain.u_domain_owner_id_fk = dtSingleDomain.Rows[0]["u_domain_owner_id_fk"].ToString();
                  getDomain.u_domain_coordinator_id_fk = dtSingleDomain.Rows[0]["u_domain_coordinator_id_fk"].ToString();
                  getDomain.u_domain_status_id_fk = dtSingleDomain.Rows[0]["u_domain_status_id_fk"].ToString();
                  getDomain.u_domain_theme_id_fk = dtSingleDomain.Rows[0]["u_domain_theme_id_fk"].ToString();
                  getDomain.u_domain_owner_text = dtSingleDomain.Rows[0]["u_domain_owner_text"].ToString();
                  getDomain.u_domain_coordinator_text = dtSingleDomain.Rows[0]["u_domain_coordinator_text"].ToString();
                  return getDomain;
              }
              catch (Exception)
              {
                  throw;
              }
        }
        /// <summary>
        /// search domain
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static DataTable SearchDomains(SystemDomain domain)
        {
            Hashtable htSearchDomain = new Hashtable();
            htSearchDomain.Add("@u_domain_id_pk", domain.u_domain_id_pk);
            htSearchDomain.Add("@u_domain_name", domain.u_domain_name);
            if (domain.u_domain_theme_id_fk == "0")
                htSearchDomain.Add("@u_domain_theme_id_fk", DBNull.Value);
            else
                htSearchDomain.Add("@u_domain_theme_id_fk",domain.u_domain_theme_id_fk);

            if (domain.u_domain_status_id_fk == "0")
                htSearchDomain.Add("@u_domain_status_id_fk", DBNull.Value);
            else
                htSearchDomain.Add("@u_domain_status_id_fk", domain.u_domain_status_id_fk);

            htSearchDomain.Add("@u_domain_owner_name", domain.u_domain_owner_text);
            htSearchDomain.Add("@u_domain_coordinator_name", domain.u_domain_coordinator_text);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_domain", htSearchDomain);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update domain status
        /// </summary>
        /// <param name="u_domain_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateDomainStatus(string u_domain_system_id_pk)
        {
            Hashtable htUpdateDomainStatus = new  Hashtable ();
            htUpdateDomainStatus.Add("@u_domain_system_id_pk",u_domain_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_domain_status", htUpdateDomainStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


       
        
       
        
    }
}
