using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemSplashPageBLL
    {
        public static int CreateSplashPage(SystemSplashPage spalshpage)
        {
            Hashtable htCreateSplashPage = new Hashtable();
            htCreateSplashPage.Add("@u_splash_system_id_pk", spalshpage.u_splash_system_id_pk);
            htCreateSplashPage.Add("@u_splash_id_pk", spalshpage.u_splash_id_pk);
            htCreateSplashPage.Add("@u_splash_name", spalshpage.u_splash_name);
            htCreateSplashPage.Add("@u_splash_content", spalshpage.u_splash_content);
            htCreateSplashPage.Add("@u_splash_status_id_fk", spalshpage.u_splash_status_id_fk);

            if (!string.IsNullOrEmpty(spalshpage.u_splash_owner_id_fk))
            {
                htCreateSplashPage.Add("@u_splash_owner_id_fk", spalshpage.u_splash_owner_id_fk);
            }
            else
            {
                htCreateSplashPage.Add("@u_splash_owner_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(spalshpage.u_splash_coordinator_id_fk))
            {
                htCreateSplashPage.Add("@u_splash_coordinator_id_fk", spalshpage.u_splash_coordinator_id_fk);
            }
            else
            {
                htCreateSplashPage.Add("@u_splash_coordinator_id_fk", DBNull.Value);
            }

            if (spalshpage.u_splash_domain_id_fk == "0")
                htCreateSplashPage.Add("@u_splash_domain_id_fk", DBNull.Value);
            else
                htCreateSplashPage.Add("@u_splash_domain_id_fk", spalshpage.u_splash_domain_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_splash_page", htCreateSplashPage);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateSplashPage(SystemSplashPage updateSplash)
        {
            Hashtable htUpdateSplashPage = new Hashtable();
            htUpdateSplashPage.Add("@u_splash_system_id_pk", updateSplash.u_splash_system_id_pk);
            htUpdateSplashPage.Add("@u_splash_id_pk", updateSplash.u_splash_id_pk);
            htUpdateSplashPage.Add("@u_splash_name", updateSplash.u_splash_name);
            htUpdateSplashPage.Add("@u_splash_content", updateSplash.u_splash_content);
            htUpdateSplashPage.Add("@u_splash_status_id_fk", updateSplash.u_splash_status_id_fk);

            if (!string.IsNullOrEmpty(updateSplash.u_splash_owner_id_fk))
            {
                htUpdateSplashPage.Add("@u_splash_owner_id_fk", updateSplash.u_splash_owner_id_fk);
            }
            else
            {
                htUpdateSplashPage.Add("@u_splash_owner_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(updateSplash.u_splash_coordinator_id_fk))
            {
                htUpdateSplashPage.Add("@u_splash_coordinator_id_fk", updateSplash.u_splash_coordinator_id_fk);
            }
            else
            {
                htUpdateSplashPage.Add("@u_splash_coordinator_id_fk", DBNull.Value);
            }

            if (updateSplash.u_splash_domain_id_fk == "0")
                htUpdateSplashPage.Add("@u_splash_domain_id_fk", DBNull.Value);
            else
                htUpdateSplashPage.Add("@u_splash_domain_id_fk", updateSplash.u_splash_domain_id_fk);



            //htUpdateSplashPage.Add("@s_splash_owner_id_fk", updateSplash.s_splash_owner_id_fk);
            //htUpdateSplashPage.Add("@s_splash_coordinator_id_fk", updateSplash.s_splash_coordinator_id_fk);
            //htUpdateSplashPage.Add("@s_splash_domain_id_fk", updateSplash.s_splash_domain_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_splash_page", htUpdateSplashPage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateSplashPageWithLocale(SystemSplashPage spalshpage)
        {
            Hashtable htCreateSplashPage = new Hashtable();
            htCreateSplashPage.Add("@u_splash_system_id_pk", spalshpage.u_splash_system_id_pk);
            htCreateSplashPage.Add("@u_splash_id_pk", spalshpage.u_splash_id_pk);
            htCreateSplashPage.Add("@u_splash_name", spalshpage.u_splash_name);
            htCreateSplashPage.Add("@u_splash_content", spalshpage.u_splash_content);
            htCreateSplashPage.Add("@u_splash_status_id_fk", spalshpage.u_splash_status_id_fk);

            if (!string.IsNullOrEmpty(spalshpage.u_splash_owner_id_fk))
            {
                htCreateSplashPage.Add("@u_splash_owner_id_fk", spalshpage.u_splash_owner_id_fk);
            }
            else
            {
                htCreateSplashPage.Add("@u_splash_owner_id_fk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(spalshpage.u_splash_coordinator_id_fk))
            {
                htCreateSplashPage.Add("@u_splash_coordinator_id_fk", spalshpage.u_splash_coordinator_id_fk);
            }
            else
            {
                htCreateSplashPage.Add("@u_splash_coordinator_id_fk", DBNull.Value);
            }

            if (spalshpage.u_splash_domain_id_fk == "0")
                htCreateSplashPage.Add("@u_splash_domain_id_fk", DBNull.Value);
            else
                htCreateSplashPage.Add("@u_splash_domain_id_fk", spalshpage.u_splash_domain_id_fk);

            //htCreateSplashPage.Add("@s_splash_owner_id_fk", spalshpage.s_splash_owner_id_fk);
            //htCreateSplashPage.Add("@s_splash_coordinator_id_fk", spalshpage.s_splash_coordinator_id_fk);
            //htCreateSplashPage.Add("@s_splash_domain_id_fk", spalshpage.s_splash_domain_id_fk);
            htCreateSplashPage.Add("@u_splash_locales_xml", spalshpage.u_splash_locales_xml);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_splash_page_with_locales", htCreateSplashPage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDomain()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_splash_domain_name");
            }

            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetNotCreatedDomain()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_not_created_domain");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSplashDomain(string u_splash_system_id_pk)
        {
            Hashtable htGetSplashDomain = new Hashtable();
            if (!string.IsNullOrEmpty(u_splash_system_id_pk))
            {
                htGetSplashDomain.Add("@u_splash_system_id_pk", u_splash_system_id_pk);
            }
            else
            {
                htGetSplashDomain.Add("@u_splash_system_id_pk", DBNull.Value);
            }            
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_splash_domain", htGetSplashDomain);
            }

            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all status
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllStatus = new Hashtable();
                htGetAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetAllStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchSplashPage(SystemSplashPage spalshpage)
        {
            Hashtable htSplash = new Hashtable();
            htSplash.Add("@u_splash_id_pk", spalshpage.u_splash_id_pk);
            htSplash.Add("@u_splash_name", spalshpage.u_splash_name);
            htSplash.Add("@u_splash_coordinator_name", spalshpage.u_splash_coordinator_name);
            htSplash.Add("@u_splash_owner_name", spalshpage.u_splash_owner_name);

            if (spalshpage.u_splash_status_id_fk == "app_ddl_all_text")
                htSplash.Add("@u_splash_status_id_fk", DBNull.Value);
            else
                htSplash.Add("@u_splash_status_id_fk", spalshpage.u_splash_status_id_fk);

            if (spalshpage.u_splash_domain_id_fk == "0")
                htSplash.Add("@u_splash_domain_id_fk", DBNull.Value);
            else
                htSplash.Add("@u_splash_domain_id_fk", spalshpage.u_splash_domain_id_fk);

            try
            {
                return DataProxy.FetchDataTable("s_sp_search_splash_page", htSplash);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemSplashPage GetSingleSplashPage(string u_splash_system_id_pk)
        {
            SystemSplashPage splashPage;
            try
            {
                Hashtable htGetSplashPage = new Hashtable();
                htGetSplashPage.Add("@u_splash_system_id_pk", u_splash_system_id_pk);
                splashPage = new SystemSplashPage();
                DataTable dtGetSplashPage = DataProxy.FetchDataTable("s_sp_get_single_splash_page", htGetSplashPage);

                splashPage.u_splash_system_id_pk = dtGetSplashPage.Rows[0]["u_splash_system_id_pk"].ToString();
                splashPage.u_splash_id_pk = dtGetSplashPage.Rows[0]["u_splash_id_pk"].ToString();
                splashPage.u_splash_name = dtGetSplashPage.Rows[0]["u_splash_name"].ToString();
                splashPage.u_splash_content = dtGetSplashPage.Rows[0]["u_splash_content"].ToString();
                splashPage.u_splash_coordinator_id_fk = dtGetSplashPage.Rows[0]["u_splash_coordinator_id_fk"].ToString();
                splashPage.u_splash_owner_id_fk = dtGetSplashPage.Rows[0]["u_splash_owner_id_fk"].ToString();
                splashPage.u_splash_status_id_fk = dtGetSplashPage.Rows[0]["u_splash_status_id_fk"].ToString();
                splashPage.u_splash_domain_id_fk = dtGetSplashPage.Rows[0]["u_splash_domain_id_fk"].ToString();
                splashPage.u_splash_owner_name = dtGetSplashPage.Rows[0]["ownername"].ToString();
                splashPage.u_splash_coordinator_name = dtGetSplashPage.Rows[0]["coordinatorname"].ToString();


                return splashPage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateSplashStatus(string u_splash_system_id_pk)
        {
            Hashtable htUpdateSplashStatus = new Hashtable();
            htUpdateSplashStatus.Add("@u_splash_system_id_pk", u_splash_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_splash_pages_status", htUpdateSplashStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Locale


        public static int CreateSplashLocale(SystemSplashPage spalshLocale)
        {
            Hashtable htCreateSplashLocale = new Hashtable();
            htCreateSplashLocale.Add("@u_splash_locale_system_id_pk", spalshLocale.u_splash_locale_system_id_pk);
            htCreateSplashLocale.Add("@u_splash_locale_id_fk", spalshLocale.u_splash_locale_id_fk);
            htCreateSplashLocale.Add("@u_splash_system_id_fk", spalshLocale.u_splash_system_id_fk);
            htCreateSplashLocale.Add("@u_splash_locale_content", spalshLocale.u_splash_locale_content);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_splash_locales", htCreateSplashLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSplashLocale(string u_splash_system_id_fk)
        {
            Hashtable htSplash = new Hashtable();
            htSplash.Add("@u_splash_system_id_fk", u_splash_system_id_fk);


            try
            {
                return DataProxy.FetchDataTable("s_sp_get_splash_locales", htSplash);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static SystemSplashPage GetSingleLocale(string u_splash_locale_system_id_pk)
        {
            Hashtable htSplash = new Hashtable();
            htSplash.Add("@u_splash_locale_system_id_pk", u_splash_locale_system_id_pk);
            SystemSplashPage splashPage = new SystemSplashPage();

            try
            {
                DataTable dtGetSingleSplash = DataProxy.FetchDataTable("s_sp_get_single_locale", htSplash);
                splashPage.u_splash_locale_system_id_pk = dtGetSingleSplash.Rows[0]["u_splash_locale_system_id_pk"].ToString();
                splashPage.u_splash_locale_id_fk = dtGetSingleSplash.Rows[0]["u_splash_locale_id_fk"].ToString();
                splashPage.u_splash_system_id_fk = dtGetSingleSplash.Rows[0]["u_splash_system_id_fk"].ToString();
                splashPage.u_splash_locale_content = dtGetSingleSplash.Rows[0]["u_splash_locale_content"].ToString();

                return splashPage;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Locale
        public static int UpdateSplashLocale(SystemSplashPage spalshLocale)
        {
            Hashtable htUpdateSplashLocale = new Hashtable();
            htUpdateSplashLocale.Add("@u_splash_locale_system_id_pk", spalshLocale.u_splash_locale_system_id_pk);
            htUpdateSplashLocale.Add("@u_splash_locale_content", spalshLocale.u_splash_locale_content);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_splash_locales", htUpdateSplashLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteSplashLocale(string u_splash_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            htDeleteLocale.Add("@u_splash_locale_system_id_pk", u_splash_locale_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_splash_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetLocale(SystemSplashPage spalshLocale)
        {
            Hashtable htResetLocale = new Hashtable();
            htResetLocale.Add("@u_splash_system_id_pk", spalshLocale.u_splash_system_id_pk);
            htResetLocale.Add("@u_splash_locales_xml", spalshLocale.u_splash_locales_xml);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_splash_locale", htResetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemSplashPage GetSplashContent(string u_splash_domain_id_fk, string selected_language)
        {
            Hashtable htGetSplashContent = new Hashtable();
            htGetSplashContent.Add("@u_splash_domain_id", u_splash_domain_id_fk);
            htGetSplashContent.Add("@selected_language", selected_language);
            SystemSplashPage splashPage = new SystemSplashPage();
            try
            {
                DataTable dtGetSplashContent = DataProxy.FetchDataTable("s_sp_get_splash_content_info", htGetSplashContent);
                if (dtGetSplashContent.Rows.Count > 0)
                {
                    splashPage.u_splash_content = dtGetSplashContent.Rows[0]["u_splash_content"].ToString();
                }

                return splashPage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSplashPages()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_splash_pages");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
