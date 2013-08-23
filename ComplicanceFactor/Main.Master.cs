using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Globalization;
using System.IO;
using ComplicanceFactor.Common.Languages;
using System.Net;
using System.Web.UI.HtmlControls;
namespace ComplicanceFactor
{
    public partial class EmployeeHome : System.Web.UI.MasterPage
    {
        #region
        //private string path = "~/Styles/Main.css";
        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {

            
            //string sourcepath = Server.MapPath(path);
            //if (System.IO.File.Exists(sourcepath))
            //{

            //    // Create a file to write to. 
            //    //File.WriteAllText(sourcepath, usercss.css);
            //}
            
            //style.InnerHtml = usercss.css;

            //Page.Header.Controls.Add(style);

            //For Session Expire

            if ((!string.IsNullOrEmpty(SessionWrapper.u_userid)) && (!string.IsNullOrEmpty(SessionWrapper.sessionid)))
            {
                bool isAccess = SessioninfoBLL.ManageSession(SessionWrapper.u_userid, SessionWrapper.sessionid);

                if (isAccess == true)
                {
                    Session.Abandon();
                    SessionWrapper.clearsession();
                    //Session expire. If the user opened in one browser and then open the 
                    //another browser the first opened browser will expired and redirect to Default2.aspx
                    Response.Redirect("~/Default2.aspx?expire=" + SecurityCenter.EncryptText("true") + "&locale=" + SecurityCenter.EncryptText(ddlLanguages.SelectedValue));
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblPreviewTheme.Text))
            {
                // Get dyanamic css color
                if (!string.IsNullOrEmpty(SessionWrapper.u_userid))
                {
                    User usercss = new User();
                    usercss = UserBLL.GetCss(SessionWrapper.u_userid);
                    HtmlGenericControl style = new HtmlGenericControl();
                    style.TagName = "style";
                    style.Attributes.Add("type", "text/css");
                    style.InnerHtml = usercss.css;
                    Page.Header.Controls.Add(style);
                }
            }
            else
            {
                SystemThemes theme = new SystemThemes();
                theme.s_theme_head_logo_file_name = SessionWrapper.defaults_theme_logo.Rows[0]["FileName"].ToString();
                theme.s_theme_report_logo_file_name = SessionWrapper.defaults_theme_logo.Rows[1]["FileName"].ToString();
                theme.s_theme_notification_logo_file_name = SessionWrapper.defaults_theme_logo.Rows[2]["FileName"].ToString();

                theme.s_theme_css_tag_main_background_hex_value = SessionWrapper.defaults_theme_color.Rows[0]["Colorvalue"].ToString();
                theme.s_theme_css_tag_login_background_hex_value = SessionWrapper.defaults_theme_color.Rows[1]["Colorvalue"].ToString();
                theme.s_theme_css_tag_login_button_hex_value = SessionWrapper.defaults_theme_color.Rows[2]["Colorvalue"].ToString();
                theme.s_theme_css_tag_login_text_hex_value = SessionWrapper.defaults_theme_color.Rows[3]["Colorvalue"].ToString();
                theme.s_theme_css_tag_login_link_hex_value = SessionWrapper.defaults_theme_color.Rows[4]["Colorvalue"].ToString();
                theme.s_theme_css_tag_nav_top_line_hex_value = SessionWrapper.defaults_theme_color.Rows[5]["Colorvalue"].ToString();
                theme.s_theme_css_tag_nav_bar_hex_value = SessionWrapper.defaults_theme_color.Rows[6]["Colorvalue"].ToString();
                theme.s_theme_css_tag_nav_bar_text_hex_value = SessionWrapper.defaults_theme_color.Rows[7]["Colorvalue"].ToString();
                theme.s_theme_css_tag_nav_bot_line_hex_value = SessionWrapper.defaults_theme_color.Rows[8]["Colorvalue"].ToString();
                theme.s_theme_css_tag_nav_active_hex_value = SessionWrapper.defaults_theme_color.Rows[9]["Colorvalue"].ToString();
                theme.s_theme_css_tag_nav_active_text_hex_value = SessionWrapper.defaults_theme_color.Rows[10]["Colorvalue"].ToString();
                theme.s_theme_css_tag_foot_top_line_hex_value = SessionWrapper.defaults_theme_color.Rows[11]["Colorvalue"].ToString();
                theme.s_theme_css_tag_foot_bot_line_hex_value = SessionWrapper.defaults_theme_color.Rows[12]["Colorvalue"].ToString();
                theme.s_theme_css_tag_section_head_hex_value = SessionWrapper.defaults_theme_color.Rows[13]["Colorvalue"].ToString();
                theme.s_theme_css_tag_section_head_text_hex_value = SessionWrapper.defaults_theme_color.Rows[14]["Colorvalue"].ToString();
                theme.s_theme_css_tag_section_head_border_hex_value = SessionWrapper.defaults_theme_color.Rows[15]["Colorvalue"].ToString();
                theme.s_theme_css_tag_table_head_hex_value = SessionWrapper.defaults_theme_color.Rows[16]["Colorvalue"].ToString();
                theme.s_theme_css_tag_table_head_text_hex_value = SessionWrapper.defaults_theme_color.Rows[17]["Colorvalue"].ToString();
                theme.s_theme_css_tag_table_border_hex_value = SessionWrapper.defaults_theme_color.Rows[18]["Colorvalue"].ToString();
                theme.s_theme_css_tag_bread_link_hex_value = SessionWrapper.defaults_theme_color.Rows[19]["Colorvalue"].ToString();
                theme.s_theme_css_tag_bread_text_hex_value = SessionWrapper.defaults_theme_color.Rows[20]["Colorvalue"].ToString();
                theme.s_theme_css_tag_body_text_hex_value = SessionWrapper.defaults_theme_color.Rows[21]["Colorvalue"].ToString();
                theme.s_theme_css_tag_body_link_hex_value = SessionWrapper.defaults_theme_color.Rows[22]["Colorvalue"].ToString();
                 HtmlGenericControl style = new HtmlGenericControl();
                style.TagName = "style";
                style.Attributes.Add("type", "text/css");
                style.InnerHtml = "#content /*background and text color*/{float: left;width: 1040px;background-color: #" + theme.s_theme_css_tag_main_background_hex_value + ";color: #" + theme.s_theme_css_tag_body_text_hex_value + ";}.content_button /* login logout button color*/{background-color: #" + theme.s_theme_css_tag_login_button_hex_value + ";color: #" + theme.s_theme_css_tag_login_text_hex_value + ";font-weight: 700;height: 25px;cursor: pointer;}.footer {    color: #000;    border-top: 2px solid #" + theme.s_theme_css_tag_foot_top_line_hex_value + ";    border-bottom: 2px solid #" + theme.s_theme_css_tag_foot_bot_line_hex_value + ";height: 15px;font-size: 12px;font-weight: 700;}#login /*Login background*/{width: 400px;float: right;height: 75px;background-color: #" + theme.s_theme_css_tag_login_background_hex_value + ";border: 1px solid ##" + theme.s_theme_css_tag_login_background_hex_value + ";color: #" + theme.s_theme_css_tag_login_text_hex_value + ";margin: 16px 0 0;padding: 0;}.main_menu /*nav top line and botton line*/{background-color: #" + theme.s_theme_css_tag_nav_bar_hex_value + ";border-bottom-color: #" + theme.s_theme_css_tag_nav_bot_line_hex_value + ";border-bottom-style: solid;  /*nav bottom line*/border-bottom-width: 3px;border-top-color: #" + theme.s_theme_css_tag_nav_top_line_hex_value + ";border-top-style: solid; /*nav top line*/border-top-width: 3px;clear: both;color: #" + theme.s_theme_css_tag_nav_bar_text_hex_value + ";float: left;font-family: Arial,Helvetica,sans-serif;font-size: 14px;font-weight: 700;height: 30px;line-height: 30px;padding-left: 40px;position: relative;width: 76%;}.main_memu_last_column /*nav top line and botton line*/{height: 30px;line-height: 30px;color: #FFF;font-family: Arial, Helvetica, sans-serif;font-size: 14px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_nav_bar_hex_value + ";border-bottom: 3px solid #" + theme.s_theme_css_tag_nav_bot_line_hex_value + ";border-top: 3px solid #" + theme.s_theme_css_tag_nav_top_line_hex_value + ";float: left;width: 19%;}.main_menu a:link{line-height: 30px;color: #" + theme.s_theme_css_tag_nav_bar_text_hex_value + ";text-decoration: none;border: 0;}.main_menu ul li:hover li{float: none;list-style: none;background: #" + theme.s_theme_css_tag_nav_bar_hex_value + "; margin: 0;padding: 0;}a /* breadcrumb link */ {color: #" + theme.s_theme_css_tag_bread_link_hex_value + ";text-decoration: none;list-style: none;}.gv_name_header /* Border color*/{width: 100px;background-color:" + theme.s_theme_css_tag_table_head_hex_value + ";font-size: 11px;font-weight: 700;cursor: pointer;padding: 3px 7px 0 10px;}.gv_middle_name_header {width: 75px;background-color: #" + theme.s_theme_css_tag_table_border_hex_value + "; font-size: 11px;font-weight: 700;cursor: pointer;padding: 3px 7px 0 10px;}.gv_default_header {width: 50px;background-color:" + theme.s_theme_css_tag_table_head_hex_value + ";font-size: 11px;font-weight: 700;cursor: pointer;padding: 3px 7px 0 10px;}table.GridView td, th /* table border  theme.s_theme_css_tag_table_border_hex_value */{color: #" + theme.s_theme_css_tag_table_head_text_hex_value + ";border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; font-weight: 700;font-size: 11px;padding: 3px 7px 0 10px;}table.GridView{font-weight: 700;font-size: 11px;color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; padding: 3px 7px 0 10px;}table.gridview_format{font-weight: 700;font-size: 11px;color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + ";width: 940px;border-spacing: 2px;padding: 3px 7px 0 10px;}.div_header_long /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";width: 1020px;padding: 3px 0 3px 8px;color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";}fieldset{border: 1px solid #" + theme.s_theme_css_tag_table_border_hex_value + "; }table.gvsearchresult_style th {background-color: #" + theme.s_theme_css_tag_table_head_hex_value + ";border: 1px solid #000;font-weight: 700;font-size: 11px;padding: 3px 7px 0 10px;}table.gridview_long{font-weight: 700;font-size: 11px;color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; width: 1020px;border-spacing: 2px;padding: 3px 7px 0 10px;}table.gridview_popup_1{font-weight: 700;font-size: 11px;color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; width: 900px;border-spacing: 2px;padding: 3px 7px 0 10px;}.div_header_popup_1 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 885px;padding: 3px 7px 3px 8px;}.div_header_popup_2 /* div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 617px;padding: 3px 7px 3px 8px;}.div_header_1005 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 1005px;padding: 3px 7px 3px 8px;}.div_header_800 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 787px;padding: 3px 7px 3px 8px;}.div_header_870 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 867px;padding: 3px 7px 3px 8px;}table.gridview_800{font-weight: 700;font-size: 11px;color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; width: 800px;border-spacing: 2px;padding: 3px 7px 0 10px;}.div_header_700 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 700px;padding: 3px 7px 3px 8px;}.div_header_750 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 750px;padding: 3px 7px 3px 8px;}.div_header_600 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 600px;padding: 3px 7px 3px 8px;}.div_header_650 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 650px;padding: 3px 7px 3px 8px;}.div_header_620 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 605px;padding: 8px 7px 8px 8px;}table.table_700{font-weight: 700;font-size: 11px;color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; width: 650px;border-spacing: 2px;padding: 3px 7px 0 0;}.div_header_900 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 900px;padding: 3px 0;}.gridview_long_no_border th /* header background gridview*/{background-color: #" + theme.s_theme_css_tag_table_head_hex_value + ";border-collapse: collapse;padding: 3px 7px 0 10px;}table.gridview_format td, table.gridview_long td, table.gridview_popup_1 td, table.gridview_800 td, table.table_700 td{color: #333;border: solid 1px #" + theme.s_theme_css_tag_table_border_hex_value + "; font-weight: 700;font-size: 11px;border-spacing: 2px;padding: 3px 7px 0 10px;}table.gridview_format th, table.gridview_long th, table.gridview_popup_1 th, table.gridview_800 th, table.table_700 th {background-color: #" + theme.s_theme_css_tag_table_head_hex_value + ";padding: 3px 7px 0 10px;}.main_menu a#lnkhome, .main_menu ul li a:hover, .main_menu ul li a.selected /*selected*/{background-color: #" + theme.s_theme_css_tag_nav_active_hex_value + ";}.main_menu ul li:hover a, .main_menu ul li.hover a, .navwrap .activated, .navwrap .activated li, .navwrap li:hover a, /* hovered text */ .navwrap li:hover span, .navwrap li.AspNet-Menu-Hover a, .navwrap li.AspNet-Menu-Hover span, .navwrap li:hover li:hover a, .navwrap li:hover li:hover span, .navwrap li.AspNet-Menu-Hover li.AspNet-Menu-Hover a, .navwrap li.AspNet-Menu-Hover li.AspNet-Menu-Hover span, .navwrap li:hover li:hover li:hover a, .navwrap li:hover li:hover li:hover span, .navwrap li.AspNet-Menu-Hover li.AspNet-Menu-Hover li.AspNet-Menu-Hover a, .navwrap li.AspNet-Menu-Hover li.AspNet-Menu-Hover li.AspNet-Menu-Hover span{background: #" + theme.s_theme_css_tag_nav_active_hex_value + ";color: #" + theme.s_theme_css_tag_nav_active_text_hex_value + "; /*manin menu */}.main_menu ul li li a:hover, .roundedcorner_heading a, .navwrap li:hover, .navwrap a,  .navwrap span{color: black;}.btngo{background-color: #" + theme.s_theme_css_tag_login_button_hex_value + ";border: #" + theme.s_theme_css_tag_login_button_hex_value + ";color: #" + theme.s_theme_css_tag_login_text_hex_value + ";cursor: pointer;height: 24px;font-weight: 700;width: 55px;margin: 0;padding: 0;}.btngo_language {width: 50px;background-color: #" + theme.s_theme_css_tag_login_button_hex_value + ";color: #" + theme.s_theme_css_tag_login_text_hex_value + ";border: 0;height: 24px;cursor: pointer;}/*.main_menu ul li{float: left;position: relative;left: 50%;display: block;background-color: #" + theme.s_theme_css_tag_nav_bar_hex_value + ";margin: 0;padding: 0;}*/.gridview_small_no_border th {background-color:#" + theme.s_theme_css_tag_table_head_hex_value + ";border-collapse: collapse;padding: 3px 7px 0 10px;}/*for Training manage Training*/ .div_header_1060 /*div header*/{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";color:#" + theme.s_theme_css_tag_section_head_text_hex_value + ";width: 1060px;padding: 3px 7px 3px 8px;}.login_link{color:#" + theme.s_theme_css_tag_login_link_hex_value + "}.bread_text{color:#" + theme.s_theme_css_tag_bread_text_hex_value + "}.body_link{	color:#" + theme.s_theme_css_tag_body_link_hex_value + "}.main_menu ul li {float: left;position: relative;left: 50%;display: block;background: #" + theme.s_theme_css_tag_nav_bar_hex_value + ";margin: 0;padding: 0;}#logo {background-image: url(/SystemHome/Configuration/Themes/Logo/" + theme.s_theme_head_logo_file_name + ");background-repeat: no-repeat;background-size: 600px 100px;float: left;height: 100px;margin-bottom: 0;margin-left: 0;margin-right: 0;margin-top: 0;padding-bottom: 0;padding-left: 0;padding-right: 0;padding-top: 0;width: 600px;}.div_header_grey_950{font-size: 14px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_table_head_hex_value + ";width: 950px;padding: 3px 0 3px 8px;}.manage_user_header, .div_header, .div_header_940{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";width: 940px;padding: 3px 7px 3px 8px;}.fancy-popup-header{font-size: 12px;height: 25px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";width: 520px !important;cursor: move;padding: 7px 0 0 3px;}.uploadpopup_header{font-size: 12px;font-weight: 700;background-color: #" + theme.s_theme_css_tag_section_head_hex_value + ";width: 695px;cursor: move;padding: 3px;}";
                Page.Header.Controls.Add(style);
            }
            //imgLogo.ImageUrl=usercss.head_logo;
            ///<summary>
            ///Store the last visited tab in database
            ///</Summary>
            if (!string.IsNullOrEmpty(SessionWrapper.u_username))
            {              

                try
                {
                    User hmeLastVisisted = new User();

                    if (Path.GetDirectoryName(Request.FilePath) == "\\Employee"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Catalog"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Profile"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Course"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Curricula"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\Home"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Employee\\LearningHistory")
                    {
                        hmeLastVisisted.lastvisited = "/Employee/Home/lhp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Manager"
                             || Path.GetDirectoryName(Request.FilePath) == "\\Manager\\Profile"
                             || Path.GetDirectoryName(Request.FilePath) == "\\Manager\\Home"
                             || Path.GetDirectoryName(Request.FilePath) == "\\Manager\\Catalog")
                    {
                        hmeLastVisisted.lastvisited = "/Manager/Home/mhp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Compliance"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\HARM"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MIRIS"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\IRIS"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MyDashboard"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MyLicenses"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MySurveys"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\MyToDo"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\SiteView"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\SiteView\\FieldNotes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\Compliance\\SiteView\\Ojt")
                    {
                        hmeLastVisisted.lastvisited = "/Compliance/cchp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Instructor")
                    {
                        hmeLastVisisted.lastvisited = "/Instructor/tihp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Training")
                    {
                        hmeLastVisisted.lastvisited = "/Training/tchp-01.aspx";
                    }
                    else if (Path.GetDirectoryName(Request.FilePath) == "\\Administrator")
                    {
                        hmeLastVisisted.lastvisited = "/Administrator/tahp-01.aspx";
                    }

                    else if (Path.GetDirectoryName(Request.FilePath) == "\\SystemHome"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\AuditLog"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\BaseConfiguration"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Domains"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\ECommerce"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\ManageUI"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\MyDashboard"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\MyToDo"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Navigation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Notifications"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Reports"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\SecurityRoles"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\SplashPages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\SystemInformation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Users"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\VLS"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Domains"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\EmployeeTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DeliveryTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\FacilityTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\InstructorTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\MaterialTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\ResourceTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\RoomTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Facilities"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Locations"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Materials"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Resources"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Rooms"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Instructor"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Category"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Course"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Completion"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\UpdateCurriculumStatuses"


                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Approvals"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\AssignmentGroups"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Documents"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\MassCompletions"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\MassEnrollment"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Waitlist"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\AssignmentRules"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Audiences"                       
                       

                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Languages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Navigation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Catalog\\Curriculum"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\ApprovalWorkflows"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\CompletionStatuses"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\CurriculumStatuses"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\CurriculumTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DataExports"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Data Imports"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DeliveryTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Domains"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\EmployeeTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\FacilityTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\GradingSchemes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Holiday Schedules"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\HRISIntegration"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\InstructorTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Languages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\MaterialTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Navigation"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\ResourceTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\RoomTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\UI Texts and Labels"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Weekday Schedules"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Splash Pages"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DocumentTypes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\Themes"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\BackgroundJobs"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\DigitalMediaFiles"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Configuration\\BackgroundJobs"
                        || Path.GetDirectoryName(Request.FilePath) == "\\SystemHome\\Profile")
                    {
                        hmeLastVisisted.lastvisited = "/SystemHome/sahp-01.aspx";
                    }


                    hmeLastVisisted.Userid = SessionWrapper.u_userid;
                    hmeLastVisisted.currentSessionGuid = SessionWrapper.u_sessionguid;
                    UserBLL.InsertLastVisited(hmeLastVisisted);
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("EemployeeHome.Master", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("EemployeeHome.Master", ex.Message);
                        }
                    }
                }


                //btnGo.Text = LocalResources.GetLocaleResourceString("wp_login_button_text");
                // btnLanguages.Text = LocalResources.GetLocaleResourceString("wp_login_button_text");
                // hplHelp.Text = LocalResources.GetLocaleResourceString("app_welcome_text_help");
                ///insert visited tab

                ///access home page/tab based on the security role
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_employee) == true)
                {
                    app_nav_employee.Style.Add("display", "block");

                }
                else
                {
                    app_nav_employee.Style.Add("display", "none");

                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_manager) == true)
                {
                    app_nav_manager.Style.Add("display", "block");

                }
                else
                {
                    app_nav_manager.Style.Add("display", "none");

                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_compliance) == true || Convert.ToBoolean(SessionWrapper.u_sr_is_compliance_approver) == true)
                {
                    app_nav_compliance.Style.Add("display", "block");
                }
                else
                {
                    app_nav_compliance.Style.Add("display", "none");

                }

                if (Convert.ToBoolean(SessionWrapper.u_sr_is_instructor) == true)
                {
                    app_nav_instructor.Style.Add("display", "block");

                }
                else
                {
                    app_nav_instructor.Style.Add("display", "none");

                }

                if (Convert.ToBoolean(SessionWrapper.u_sr_is_training) == true)
                {
                    app_nav_training.Style.Add("display", "block");
                }
                else
                {

                    app_nav_training.Style.Add("display", "none");

                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_administrator) == true)
                {
                    app_nav_admin.Style.Add("display", "block");

                }
                else
                {
                    app_nav_admin.Style.Add("display", "none");


                }
                if (Convert.ToBoolean(SessionWrapper.u_sr_is_system_admin) == true)
                {
                    app_nav_system.Style.Add("display", "block");

                }
                else
                {
                    app_nav_system.Style.Add("display", "none");

                }

                lblUsername.Text = " " + SessionWrapper.u_firstname + "!";
                if (!IsPostBack)
                {

                    try
                    {
                        //splash page content
                        SystemSplashPage splashContent = new SystemSplashPage();
                        //Here we can get the splash content based on the domain Id
                        splashContent = SystemSplashPageBLL.GetSplashContent(SessionWrapper.u_domain,SessionWrapper.CultureName);
                        spalsh.InnerHtml = WebUtility.HtmlDecode(splashContent.u_splash_content);
                        //update last selected language
                        User hmelanguage = new User();
                        hmelanguage.selectedlanguage = SessionWrapper.language;
                        hmelanguage.Userid = SessionWrapper.u_userid;
                        UserBLL.Updatelanguage(hmelanguage);
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("Main.master", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("Main.master", ex.Message);
                            }
                        }

                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["in"]) && SecurityCenter.DecryptText(Request.QueryString["in"]) == "success")
                    {
                        success_login.Style.Add("display", "block");

                    }

                    DateTime currentDt = DateTime.Now.ToUniversalTime();//Current Converted to UTC
                    currentDt = DateTime.SpecifyKind(currentDt, DateTimeKind.Utc);//Say to runtime that this date is UTC date.

                    /*
                    we can convert between timezones with referance to UTC(GMT) time.
                    .Net Provides TimeZoneInfo class which provides Statis functions to make easy conversion between Time Zones.

                    Though It Takes many arguments ,Key point is ConvertTime method and TimeSpan
                    we can specify TimeSpan as diferance between GMT to EST,GMT to PST etc.
                    */
                    // string strDateTime = TimeZoneInfo.ConvertTime(currentDt, TimeZoneInfo.CreateCustomTimeZone("1", new TimeSpan(-4, 0, 0), "EST", "EST", "EDT", new TimeZoneInfo.AdjustmentRule[] { })).ToString("MM/dd/yyyy - hh:mm:tt");
                    lblDateTime.Text = SessionWrapper.converted_datetime;
                    //foreach (CultureInfo culture in LanguageManager.AvailableCultures)
                    //{
                    //    ddlLanguages.Items.Add(new System.Web.UI.WebControls.ListItem(culture.TextInfo.ToTitleCase(culture.NativeName), culture.Name));
                    //}
                    ddlLanguages.DataSource = SystemLocaleBLL.GetLocaleList();
                    ddlLanguages.DataBind();
                    //ddlLanguages.Items.Add(new System.Web.UI.WebControls.ListItem("English (United States)", "en-US"));
                    // ddlLanguages.Items.Add(new System.Web.UI.WebControls.ListItem("Français (France)", "fr-FR"));
                    if (SessionWrapper.CultureName != null)
                    {
                        ddlLanguages.SelectedValue = SessionWrapper.CultureName;
                        if (ddlLanguages.Items.Count > 0) //make sure there is a SelectedValue
                        {
                            //BasePage bp = new BasePage();

                            //bp.ApplyNewLanguageAndRefreshPage(new CultureInfo(ddlLanguages.SelectedValue));
                            SessionWrapper.language = ddlLanguages.SelectedValue;
                            SessionWrapper.CultureName = ddlLanguages.SelectedValue;
                            //Response.Redirect(Request.Url.AbsoluteUri);

                        }

                    }
                    else
                    {
                        ddlLanguages.SelectedValue = "us_english";
                        SessionWrapper.CultureName = "us_english";
                    }

                }

            }
            else
            {
                Response.Redirect("~/session_out.aspx");

                //Response.Redirect("~/glp-01.aspx");
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Get IP address
            string strIPAddress = string.Empty;
            strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIPAddress == "" || strIPAddress == null)
                strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            try
            {
                Sessioninfo sessioninfo = new Sessioninfo();
                // sessioninfo.sessionend_time = DateTime.Now;
                sessioninfo.sessionguid = SessionWrapper.u_sessionguid;
                SessioninfoBLL.InsertSessionEndTime(sessioninfo);

                //insert audio log on logout
                Auditlog auditlog = new Auditlog();
                auditlog.Guid = Guid.NewGuid().ToString();
                auditlog.Auditid = Guid.NewGuid().ToString();
                auditlog.Userid = SessionWrapper.u_userid;
                auditlog.user_type = SessionWrapper.u_user_type;
                auditlog.user_detail = SessionWrapper.u_lastname + ' ' + SessionWrapper.u_firstname + ' ' + SessionWrapper.u_middlename;
                auditlog.action_desc = "Logout";
                //auditlog.u_datetime = DateTime.Now;
                auditlog.ipaddress = strIPAddress;
                auditlog.device = Request.UserAgent;


                AuditlogBLL.InsertAudit(auditlog);


                User userinfo = new User();
                userinfo.u_is_active = false;
                userinfo.Userid = Session["u_userid"].ToString();
                UserBLL.UpdateLock(userinfo);


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("EmployeeHome.master", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("EmployeeHome.master", ex.Message);
                    }
                }
            }

            Session.Abandon();
            SessionWrapper.clearsession();
            SessionWrapper.CultureName = ddlLanguages.SelectedValue;
            Response.Redirect("~/Default2.aspx?out=" + SecurityCenter.EncryptText("success") + "&locale=" + SecurityCenter.EncryptText(ddlLanguages.SelectedValue));

        }
        protected void btnLanguages_Click(object sender, EventArgs e)
        {
            if (ddlLanguages.Items.Count > 0) //make sure there is a SelectedValue
            {
                BasePage bp = new BasePage();

                //bp.ApplyNewLanguageAndRefreshPage(new CultureInfo(ddlLanguages.SelectedValue));
                SessionWrapper.language = ddlLanguages.SelectedValue;
                SessionWrapper.CultureName = ddlLanguages.SelectedValue;
                //try
                //{
                //    User hmelanguage = new User();
                //    hmelanguage.selectedlanguage = SessionWrapper.language;
                //    hmelanguage.Userid = SessionWrapper.u_userid;
                //    UserBLL.Updatelanguage(hmelanguage);
                //}
                //catch (Exception ex)
                //{
                //    if (ConfigurationWrapper.LogErrors == true)
                //    {
                //        if (ex.InnerException != null)
                //        {
                //            Logger.WriteToErrorLog("CFHome.master", ex.Message, ex.InnerException.Message);
                //        }
                //        else
                //        {
                //            Logger.WriteToErrorLog("CFHome.master", ex.Message);
                //        }
                //    }

                //}


                Response.Redirect(Request.Url.ToString());
            }
        }


    }
}