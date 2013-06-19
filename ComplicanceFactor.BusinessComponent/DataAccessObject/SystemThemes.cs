using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemThemes
    {
        public string s_theme_system_id_pk { get; set; }
        public string s_theme_id_pk { get; set; }
        public string s_theme_name { get; set; }
        public string s_theme_description { get; set; }
        public string s_theme_status_id_fk { get; set; }
        public string s_theme_owner_id_fk { get; set; }
        public string s_theme_coordinator_id_fk { get; set; }
        public string s_theme_domain_id_fk { get; set; }
        public string s_theme_head_logo_file_name { get; set; }
        public string s_theme_report_logo_file_name { get; set; }
        public string s_theme_notification_logo_file_name { get; set; }
        public string s_theme_css_tag_main_background_hex_value { get; set; }
        public string s_theme_css_tag_login_background_hex_value { get; set; }
        public string s_theme_css_tag_login_button_hex_value { get; set; }
        public string s_theme_css_tag_login_text_hex_value { get; set; }
        public string s_theme_css_tag_login_link_hex_value { get; set; }
        public string s_theme_css_tag_nav_top_line_hex_value { get; set; }
        public string s_theme_css_tag_nav_bar_hex_value { get; set; }
        public string s_theme_css_tag_nav_bar_text_hex_value { get; set; }
        public string s_theme_css_tag_nav_bot_line_hex_value { get; set; }
        public string s_theme_css_tag_nav_active_hex_value { get; set; }
        public string s_theme_css_tag_nav_active_text_hex_value { get; set; }
        public string s_theme_css_tag_foot_top_line_hex_value { get; set; }
        public string s_theme_css_tag_foot_bot_line_hex_value { get; set; }
        public string s_theme_css_tag_section_head_hex_value { get; set; }
        public string s_theme_css_tag_section_head_text_hex_value { get; set; }
        public string s_theme_css_tag_section_head_border_hex_value { get; set; }
        public string s_theme_css_tag_table_head_hex_value { get; set; }
        public string s_theme_css_tag_table_head_text_hex_value { get; set; }
        public string s_theme_css_tag_table_border_hex_value { get; set; }
        public string s_theme_css_tag_bread_link_hex_value { get; set; }
        public string s_theme_css_tag_bread_text_hex_value { get; set; }
        public string s_theme_css_tag_body_text_hex_value { get; set; }
        public string s_theme_css_tag_body_link_hex_value { get; set; }


        public string s_theme_owner_name { get; set; }
        public string s_theme_coordinator_name { get; set; }
    }
}
