using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.SystemHome.Configuration.Themes
{
    public partial class saetp_01 : System.Web.UI.Page
    {
        private static string themeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Themes/samtmp-01.aspx>" + "Manage Themes" + "</a>" + " >&nbsp;" + "Edit Theme";

                SessionWrapper.s_theme_edit_color = null;

                //ddlDomain                 
                ddlDomain.DataSource = SystemSplashPageBLL.GetNotCreatedDomain();
                ddlDomain.DataBind();

                //Bind status
                ddlStatus.DataSource = SystemDomainBLL.GetAllDomainStatus(SessionWrapper.CultureName, "samdmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_all_text";

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Theme was successfully insered";
                }

                if (!string.IsNullOrEmpty(Request.QueryString["themeid"]))
                {
                    themeId = SecurityCenter.DecryptText(Request.QueryString["themeid"].ToString());
                    hdThemeId.Value = themeId;
                    PopulateTheme();
                }

                if (!string.IsNullOrEmpty(Request.QueryString["copythemeid"]))
                {
                    themeId = SecurityCenter.DecryptText(Request.QueryString["copythemeid"].ToString());
                    hdThemeId.Value = themeId;
                    PopulateTheme();                    
                }
            }

            lblCoordinator.Text = SessionWrapper.s_theme_coordinator_name;
            lblOwner.Text = SessionWrapper.s_theme_owner_name;

            DataSet dsLogoandColor = new DataSet();
            dsLogoandColor = SystemThemeBLL.GetLogoandColors(themeId);

            gvLogos.DataSource = dsLogoandColor.Tables[0];
            gvLogos.DataBind();
        }
        /// <summary>
        /// Populate Theme
        /// </summary>
        private void PopulateTheme()
        {
            SystemThemes theme = new SystemThemes();

            try
            {
                theme = SystemThemeBLL.GetThemeById(themeId);
                txtThemeId.Text = theme.s_theme_id_pk;
                txtThemeName.Text = theme.s_theme_name;
                txtContent.InnerText = theme.s_theme_description;
                //ddlDomain.SelectedValue = 
                ddlStatus.SelectedValue = theme.s_theme_status_id_fk;
                lblOwner.Text = theme.s_theme_owner_name;
                lblCoordinator.Text = theme.s_theme_coordinator_name;

                SessionWrapper.s_theme_coordinator_id_fk = theme.s_theme_coordinator_id_fk;
                SessionWrapper.s_theme_owner_id_fk = theme.s_theme_owner_id_fk;
                SessionWrapper.s_theme_coordinator_name = theme.s_theme_coordinator_name;
                SessionWrapper.s_theme_owner_name = theme.s_theme_owner_name;


                DataSet dsLogoandColor = new DataSet();
                dsLogoandColor = SystemThemeBLL.GetLogoandColors(themeId);

                gvLogos.DataSource = dsLogoandColor.Tables[0];
                gvLogos.DataBind();

                gvColors.DataSource = dsLogoandColor.Tables[1];
                gvColors.DataBind();

                SessionWrapper.s_theme_edit_color = dsLogoandColor.Tables[1];
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnFooterUpdateTheme_Click(object sender, EventArgs e)
        {
            UpdateTheme();
        }

        protected void btnHeaderUpdateTheme_Click(object sender, EventArgs e)
        {
            UpdateTheme();
        }
        /// <summary>
        /// Update Theme
        /// </summary>
        private void UpdateTheme()
        {
            //Colors
            foreach (GridViewRow row in gvColors.Rows)
            {
                string columnName = gvColors.DataKeys[row.RowIndex][0].ToString();
                TextBox txtscore = (TextBox)row.FindControl("txtHex");

                var rows = SessionWrapper.s_theme_edit_color.Select("keyvalue= '" + columnName + "'");
                foreach (var currentrow in rows)
                    currentrow["Colorvalue"] = txtscore.Text;
                SessionWrapper.s_theme_edit_color.AcceptChanges();
            }

            SystemThemes theme = new SystemThemes();
            theme.s_theme_system_id_pk = themeId;
            theme.s_theme_id_pk = txtThemeId.Text;
            theme.s_theme_name = txtThemeName.Text;
            theme.s_theme_description = txtContent.InnerText;
            theme.s_theme_status_id_fk = ddlStatus.SelectedValue;
            theme.s_theme_owner_id_fk = SessionWrapper.s_theme_owner_id_fk;
            theme.s_theme_coordinator_id_fk = SessionWrapper.s_theme_coordinator_id_fk;
            theme.s_theme_css_tag_main_background_hex_value = SessionWrapper.s_theme_edit_color.Rows[0]["Colorvalue"].ToString();
            theme.s_theme_css_tag_login_background_hex_value = SessionWrapper.s_theme_edit_color.Rows[1]["Colorvalue"].ToString();
            theme.s_theme_css_tag_login_button_hex_value = SessionWrapper.s_theme_edit_color.Rows[2]["Colorvalue"].ToString();
            theme.s_theme_css_tag_login_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[3]["Colorvalue"].ToString();
            theme.s_theme_css_tag_login_link_hex_value = SessionWrapper.s_theme_edit_color.Rows[4]["Colorvalue"].ToString();
            theme.s_theme_css_tag_nav_top_line_hex_value = SessionWrapper.s_theme_edit_color.Rows[5]["Colorvalue"].ToString();
            theme.s_theme_css_tag_nav_bar_hex_value = SessionWrapper.s_theme_edit_color.Rows[6]["Colorvalue"].ToString();
            theme.s_theme_css_tag_nav_bar_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[7]["Colorvalue"].ToString();
            theme.s_theme_css_tag_nav_bot_line_hex_value = SessionWrapper.s_theme_edit_color.Rows[8]["Colorvalue"].ToString();
            theme.s_theme_css_tag_nav_active_hex_value = SessionWrapper.s_theme_edit_color.Rows[9]["Colorvalue"].ToString();
            theme.s_theme_css_tag_nav_active_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[10]["Colorvalue"].ToString();
            theme.s_theme_css_tag_foot_top_line_hex_value = SessionWrapper.s_theme_edit_color.Rows[11]["Colorvalue"].ToString();
            theme.s_theme_css_tag_foot_bot_line_hex_value = SessionWrapper.s_theme_edit_color.Rows[12]["Colorvalue"].ToString();
            theme.s_theme_css_tag_section_head_hex_value = SessionWrapper.s_theme_edit_color.Rows[13]["Colorvalue"].ToString();
            theme.s_theme_css_tag_section_head_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[14]["Colorvalue"].ToString();
            theme.s_theme_css_tag_section_head_border_hex_value = SessionWrapper.s_theme_edit_color.Rows[15]["Colorvalue"].ToString();
            theme.s_theme_css_tag_table_head_hex_value = SessionWrapper.s_theme_edit_color.Rows[16]["Colorvalue"].ToString();
            theme.s_theme_css_tag_table_head_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[17]["Colorvalue"].ToString();
            theme.s_theme_css_tag_table_border_hex_value = SessionWrapper.s_theme_edit_color.Rows[18]["Colorvalue"].ToString();
            theme.s_theme_css_tag_bread_link_hex_value = SessionWrapper.s_theme_edit_color.Rows[19]["Colorvalue"].ToString();
            theme.s_theme_css_tag_bread_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[20]["Colorvalue"].ToString();
            theme.s_theme_css_tag_body_text_hex_value = SessionWrapper.s_theme_edit_color.Rows[21]["Colorvalue"].ToString();
            theme.s_theme_css_tag_body_link_hex_value = SessionWrapper.s_theme_edit_color.Rows[22]["Colorvalue"].ToString();

            try
            {
                //Updation
                int result = SystemThemeBLL.UpdateTheme(theme);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerHtml = "Theme was updated successfully";
                }
                else
                {
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divError.InnerHtml = "Theme was inserted successfully";
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saetp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saetp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void gvColors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string colorValue = Convert.ToString(drv["Colorvalue"]);
                colorValue = "#" + colorValue;
                HtmlGenericControl msgDiv = (HtmlGenericControl)e.Row.FindControl("ColorDiv");
                msgDiv.Style.Add("background-color", colorValue);

            }
        }

        protected void gvLogos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvColors_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvColors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Reset"))
            {
                string color = SystemThemeBLL.GetColorNameById(gvColors.DataKeys[rowIndex].Values[0].ToString(),themeId);
                if (!string.IsNullOrEmpty(color))
                {
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                    TextBox textBox = (TextBox)row.FindControl("txtHex");
                    textBox.Text = color;

                    HtmlGenericControl msgDiv = (HtmlGenericControl)row.FindControl("ColorDiv");
                    msgDiv.Style.Add("background-color", "#" + color);
                }
            }
        }
    }
}