using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class NavigationBLL
    {
        /// <summary>
        /// get web site navigation all menu item (main menu and sub menu)
        /// </summary>
        /// <param name="s_locale"></param>
        /// <returns>stored in datatable</returns>
        public static DataTable GetWebNavigation(string s_locale)
        {
            Hashtable htWebNavigation = new Hashtable();
            if (!string.IsNullOrEmpty(s_locale))
            {
                htWebNavigation.Add("@s_locale", s_locale);
            }
            else
            {
                htWebNavigation.Add("@s_locale", "us_english");
            }

            try
            {

                return DataProxy.FetchDataTable("s_sp_get_web_navigation", htWebNavigation);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get website navigation main menu
        /// </summary>
        /// <param name="s_locale"></param>
        /// <returns></returns>
        public static DataTable GetWebNavMainMenu(string s_locale)
        {
            Hashtable htWebNavigation = new Hashtable();
            if (!string.IsNullOrEmpty(s_locale))
            {
                htWebNavigation.Add("@s_locale", s_locale);
            }
            else
            {
                htWebNavigation.Add("@s_locale", "us_english");
            }
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_web_nav_main_menu", htWebNavigation);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get website navigation sub menu
        /// </summary>
        /// <param name="s_locale"></param>
        /// <param name="s_web_nav_system_id_pk"></param>
        /// <returns>stored in datatable</returns>
        public static DataTable GetWebNavSubMenu(string s_locale, string s_web_nav_system_id_pk)
        {
            Hashtable htWebNavSubMenu = new Hashtable();
            if (!string.IsNullOrEmpty(s_locale))
            {
                htWebNavSubMenu.Add("@s_locale", s_locale);
            }
            else
            {
                htWebNavSubMenu.Add("@s_locale", "us_english");
            }

            htWebNavSubMenu.Add("@s_web_nav_system_id_pk", s_web_nav_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_web_nav_sub_menu", htWebNavSubMenu);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Navigation GetAppNavigation()
        {
            try
            {
                Navigation nav = new Navigation();
                DataTable dtAppNav = DataProxy.FetchDataTable("s_sp_get_app_nav");
                nav.app_nav_employee = dtAppNav.Rows[0]["s_ui_label_us_english"].ToString();
                nav.app_emp_pod_mtraining_title = dtAppNav.Rows[1]["s_ui_label_us_english"].ToString();
                nav.app_emp_pod_mlhistory_title = dtAppNav.Rows[2]["s_ui_label_us_english"].ToString();
                nav.app_emp_pod_mcompliance_title = dtAppNav.Rows[3]["s_ui_label_us_english"].ToString();
                nav.app_emp_pod_mcatalog_title = dtAppNav.Rows[4]["s_ui_label_us_english"].ToString();
                nav.app_nav_manager = dtAppNav.Rows[5]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_home_title = dtAppNav.Rows[6]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_mtodo_title = dtAppNav.Rows[7]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_mteam_title = dtAppNav.Rows[8]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_mreports_title = dtAppNav.Rows[9]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_mprofile_title = dtAppNav.Rows[10]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_browse_catalog_title = dtAppNav.Rows[11]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_search_catalog_title = dtAppNav.Rows[12]["s_ui_label_us_english"].ToString();
                nav.app_manager_pod_splash_page_title = dtAppNav.Rows[13]["s_ui_label_us_english"].ToString();
                nav.app_nav_compliance = dtAppNav.Rows[14]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_mtodo_title = dtAppNav.Rows[15]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_mdashboard_title = dtAppNav.Rows[16]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_site_view_title = dtAppNav.Rows[17]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_mhazard_analysis_title = dtAppNav.Rows[18]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_mincident_report_title = dtAppNav.Rows[19]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_certs_title = dtAppNav.Rows[20]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_mreports_title = dtAppNav.Rows[21]["s_ui_label_us_english"].ToString();
                nav.app_compliance_pod_mark_title = dtAppNav.Rows[22]["s_ui_label_us_english"].ToString();
                nav.app_nav_instructor = dtAppNav.Rows[23]["s_ui_label_us_english"].ToString();
                nav.app_instructor_pod_mtodo_title = dtAppNav.Rows[24]["s_ui_label_us_english"].ToString();
                nav.app_my_dashboard_text = dtAppNav.Rows[25]["s_ui_label_us_english"].ToString();
                nav.app_instructor_pod_mclassroster_title = dtAppNav.Rows[26]["s_ui_label_us_english"].ToString();
                nav.app_instructor_pod_mreports_title = dtAppNav.Rows[27]["s_ui_label_us_english"].ToString();
                nav.app_nav_training = dtAppNav.Rows[28]["s_ui_label_us_english"].ToString();
                nav.app_training_pod_mtodo_title = dtAppNav.Rows[29]["s_ui_label_us_english"].ToString();
                nav.app_training_pod_mdashboard_title = dtAppNav.Rows[30]["s_ui_label_us_english"].ToString();
                nav.app_training_pod_mtraining_title = dtAppNav.Rows[31]["s_ui_label_us_english"].ToString();
                nav.app_training_pod_mtrainingcatalog_title = dtAppNav.Rows[32]["s_ui_label_us_english"].ToString();
                nav.app_training_pod_mreports_title = dtAppNav.Rows[33]["s_ui_label_us_english"].ToString();
                nav.app_nav_admin = dtAppNav.Rows[34]["s_ui_label_us_english"].ToString();
                nav.app_admin_pod_minstructor_title = dtAppNav.Rows[35]["s_ui_label_us_english"].ToString();
                nav.app_admin_pod_mtodo_title = dtAppNav.Rows[36]["s_ui_label_us_english"].ToString();
                nav.app_admin_pod_mdashboard_title = dtAppNav.Rows[37]["s_ui_label_us_english"].ToString();
                nav.app_admin_pod_mcatalog_title = dtAppNav.Rows[38]["s_ui_label_us_english"].ToString();
                nav.app_admin_pod_mreports_title = dtAppNav.Rows[39]["s_ui_label_us_english"].ToString();
                nav.app_admin_pod_mark_title = dtAppNav.Rows[40]["s_ui_label_us_english"].ToString();
                nav.app_nav_system = dtAppNav.Rows[41]["s_ui_label_us_english"].ToString();
                nav.app_system_pod_muser_title = dtAppNav.Rows[42]["s_ui_label_us_english"].ToString();
                nav.app_system_pod_mcatalog_title = dtAppNav.Rows[43]["s_ui_label_us_english"].ToString();
                nav.app_system_pod_mconfiguration_title = dtAppNav.Rows[44]["s_ui_label_us_english"].ToString();
                return nav;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateWebParentNavigation(bool s_web_nav_active_flag, string s_web_nav_system_id_pk, string s_ui_web_label_us_english)
        {
            Hashtable htUpdateNavigation = new Hashtable();
            htUpdateNavigation.Add("@s_web_nav_active_flag", s_web_nav_active_flag);
            htUpdateNavigation.Add("@s_web_nav_system_id_pk", s_web_nav_system_id_pk);
            htUpdateNavigation.Add("@s_ui_web_label_us_english", s_ui_web_label_us_english);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_web_parent_navigation", htUpdateNavigation);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateWebChildNavigation(bool s_web_nav_active_flag,string s_ui_app_label_us_english, string s_ui_label_name)
        {
            Hashtable htUpdateNavigation = new Hashtable();
            htUpdateNavigation.Add("@s_web_nav_active_flag", s_web_nav_active_flag);
            htUpdateNavigation.Add("@s_ui_app_label_us_english", s_ui_app_label_us_english);
            htUpdateNavigation.Add("@s_ui_label_name", s_ui_label_name);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_web_child_navigation", htUpdateNavigation);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateAppNavigation(Navigation appnav)
        {
           // appnav = new Navigation();
            Hashtable htAppNav = new Hashtable();
            htAppNav.Add("@app_nav_employee", appnav.app_nav_employee);
            htAppNav.Add("@app_emp_pod_mtraining_title", appnav.app_emp_pod_mtraining_title);
            htAppNav.Add("@app_emp_pod_mlhistory_title", appnav.app_emp_pod_mlhistory_title);
            htAppNav.Add("@app_emp_pod_mcompliance_title", appnav.app_emp_pod_mcompliance_title);
            htAppNav.Add("@app_emp_pod_mcatalog_title", appnav.app_emp_pod_mcatalog_title);
            htAppNav.Add("@app_nav_manager", appnav.app_nav_manager);
            htAppNav.Add("@app_manager_pod_home_title", appnav.app_manager_pod_home_title);
            htAppNav.Add("@app_manager_pod_mtodo_title", appnav.app_manager_pod_mtodo_title);
            htAppNav.Add("@app_manager_pod_mteam_title", appnav.app_manager_pod_mteam_title);
            htAppNav.Add("@app_manager_pod_mreports_title", appnav.app_manager_pod_mreports_title);
            htAppNav.Add("@app_manager_pod_mprofile_title", appnav.app_manager_pod_mprofile_title);
            htAppNav.Add("@app_manager_pod_browse_catalog_title", appnav.app_manager_pod_browse_catalog_title);
            htAppNav.Add("@app_manager_pod_search_catalog_title", appnav.app_manager_pod_search_catalog_title);
            htAppNav.Add("@app_manager_pod_splash_page_title", appnav.app_manager_pod_splash_page_title);
            htAppNav.Add("@app_nav_compliance", appnav.app_nav_compliance);
            htAppNav.Add("@app_compliance_pod_mtodo_title", appnav.app_compliance_pod_mtodo_title);
            htAppNav.Add("@app_compliance_pod_mdashboard_title", appnav.app_compliance_pod_mdashboard_title);
            htAppNav.Add("@app_compliance_pod_site_view_title", appnav.app_compliance_pod_site_view_title);
            htAppNav.Add("@app_compliance_pod_mhazard_analysis_title", appnav.app_compliance_pod_mhazard_analysis_title);
            htAppNav.Add("@app_compliance_pod_mincident_report_title", appnav.app_compliance_pod_mincident_report_title);
            htAppNav.Add("@app_compliance_pod_certs_title", appnav.app_compliance_pod_certs_title);
            htAppNav.Add("@app_compliance_pod_mreports_title", appnav.app_compliance_pod_mreports_title);
            htAppNav.Add("@app_compliance_pod_mark_title", appnav.app_compliance_pod_mark_title);
            htAppNav.Add("@app_nav_instructor", appnav.app_nav_instructor);
            htAppNav.Add("@app_instructor_pod_mtodo_title", appnav.app_instructor_pod_mtodo_title);
            htAppNav.Add("@app_my_dashboard_text", appnav.app_my_dashboard_text);
            htAppNav.Add("@app_instructor_pod_mclassroster_title", appnav.app_instructor_pod_mclassroster_title);
            htAppNav.Add("@app_instructor_pod_mreports_title", appnav.app_instructor_pod_mreports_title);
            htAppNav.Add("@app_nav_training", appnav.app_nav_training);
            htAppNav.Add("@app_training_pod_mtodo_title", appnav.app_training_pod_mtodo_title);
            htAppNav.Add("@app_training_pod_mdashboard_title", appnav.app_training_pod_mdashboard_title);
            htAppNav.Add("@app_training_pod_mtraining_title", appnav.app_training_pod_mtraining_title);
            htAppNav.Add("@app_training_pod_mtrainingcatalog_title", appnav.app_training_pod_mtrainingcatalog_title);
            htAppNav.Add("@app_training_pod_mreports_title", appnav.app_training_pod_mreports_title);
            htAppNav.Add("@app_nav_admin", appnav.app_nav_admin);
            htAppNav.Add("@app_admin_pod_minstructor_title", appnav.app_admin_pod_minstructor_title);
            htAppNav.Add("@app_admin_pod_mtodo_title", appnav.app_admin_pod_mtodo_title);
            htAppNav.Add("@app_admin_pod_mdashboard_title", appnav.app_admin_pod_mdashboard_title);
            htAppNav.Add("@app_admin_pod_mcatalog_title", appnav.app_admin_pod_mcatalog_title);
            htAppNav.Add("@app_admin_pod_mreports_title", appnav.app_admin_pod_mreports_title);
            htAppNav.Add("@app_admin_pod_mark_title", appnav.app_admin_pod_mark_title);
            htAppNav.Add("@app_nav_system", appnav.app_nav_system);
            htAppNav.Add("@app_system_pod_muser_title", appnav.app_system_pod_muser_title);
            htAppNav.Add("@app_system_pod_mcatalog_title", appnav.app_system_pod_mcatalog_title);
            htAppNav.Add("@app_system_pod_mconfiguration_title", appnav.app_system_pod_mconfiguration_title);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_app_navigation", htAppNav);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Add new page in website portal
        /// </summary>
        /// <param name="s_web_nav_parent_id"></param>
        /// <param name="s_web_nav_url"></param>
        /// <param name="s_web_nav_label_name"></param>
        /// <param name="s_page_name"></param>
        /// <param name="s_native_label"></param>
        /// <returns></returns>
        public static int InsertWebNewPage(string s_web_nav_parent_id, string s_web_nav_url, string s_web_nav_label_name, string s_page_name, string s_native_label)
        {
            Hashtable htInsertNewPage = new Hashtable();
            htInsertNewPage.Add("@s_web_nav_parent_id", s_web_nav_parent_id);
            htInsertNewPage.Add("@s_web_nav_url", s_web_nav_url);
            htInsertNewPage.Add("@s_web_nav_label_name", s_web_nav_label_name);
            htInsertNewPage.Add("@s_page_name", s_page_name);
            htInsertNewPage.Add("@s_native_label", s_native_label);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_web_navigation", htInsertNewPage);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteWebUIPage(string s_ui_label_name)
        {
            
            Hashtable htDeleteWebUIPage = new Hashtable();
            htDeleteWebUIPage.Add("@s_ui_label_name", s_ui_label_name);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_web_ui_page", htDeleteWebUIPage);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllWebNavigation(string s_web_nav_system_id_pk)
        {
            Hashtable htGetAllWebNav = new Hashtable();
            htGetAllWebNav.Add("@s_web_nav_system_id_pk", s_web_nav_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_all_web_navigation", htGetAllWebNav);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
