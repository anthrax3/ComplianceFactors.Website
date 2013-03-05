using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class Navigation
    {
        public string s_web_nav_system_id_pk { get; set; }
        public string s_web_nav_label_name { get; set; }
        public string s_web_nav_parent_id { get; set; }
        public string s_web_nav_active_flag { get; set; }
        public string s_web_nav_url { get; set; }
        //Application navigation
        public string app_nav_employee { get; set; }
        public string app_emp_pod_mtraining_title { get; set; }
        public string app_emp_pod_mlhistory_title { get; set; }
        public string app_emp_pod_mcompliance_title { get; set; }
        public string app_emp_pod_mcatalog_title { get; set; }
        public string app_nav_manager { get; set; }
        public string app_manager_pod_home_title { get; set; }
        public string app_manager_pod_mtodo_title { get; set; }
        public string app_manager_pod_mteam_title { get; set; }
        public string app_manager_pod_mreports_title { get; set; }
        public string app_manager_pod_mprofile_title { get; set; }
        public string app_manager_pod_browse_catalog_title { get; set; }
        public string app_manager_pod_search_catalog_title { get; set; }
        public string app_manager_pod_splash_page_title { get; set; }
        public string app_nav_compliance { get; set; }
        public string app_compliance_pod_mtodo_title { get; set; }
        public string app_compliance_pod_mdashboard_title { get; set; }
        public string app_compliance_pod_site_view_title { get; set; }
        public string app_compliance_pod_mhazard_analysis_title { get; set; }
        public string app_compliance_pod_mincident_report_title { get; set; }
        public string app_compliance_pod_certs_title { get; set; }
        public string app_compliance_pod_mreports_title { get; set; }
        public string app_compliance_pod_mark_title { get; set; }
        public string app_nav_instructor { get; set; }
        public string app_instructor_pod_mtodo_title { get; set; }
        public string app_my_dashboard_text { get; set; }
        public string app_instructor_pod_mclassroster_title { get; set; }
        public string app_instructor_pod_mreports_title { get; set; }
        public string app_nav_training { get; set; }
        public string app_training_pod_mtodo_title { get; set; }
        public string app_training_pod_mdashboard_title { get; set; }
        public string app_training_pod_mtraining_title { get; set; }
        public string app_training_pod_mtrainingcatalog_title { get; set; }
        public string app_training_pod_mreports_title { get; set; }
        public string app_nav_admin { get; set; }
        public string app_admin_pod_minstructor_title { get; set; }
        public string app_admin_pod_mtodo_title { get; set; }
        public string app_admin_pod_mdashboard_title { get; set; }
        public string app_admin_pod_mcatalog_title { get; set; }
        public string app_admin_pod_mreports_title { get; set; }
        public string app_admin_pod_mark_title { get; set; }
        public string app_nav_system { get; set; }
        public string app_system_pod_muser_title { get; set; }
        public string app_system_pod_mcatalog_title { get; set; }
        public string app_system_pod_mconfiguration_title { get; set; }

    }
}
