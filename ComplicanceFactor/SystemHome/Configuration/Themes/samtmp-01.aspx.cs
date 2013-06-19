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
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Themes
{
    public partial class samtmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_themes_text");
                
                ddlStatus.DataSource = SystemDomainBLL.GetAllDomainStatus(SessionWrapper.CultureName, "samdmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_all_text";

                ddlDomain.DataSource = SystemThemeBLL.GetAllDomain(SessionWrapper.CultureName,"samtmp-01");
                ddlDomain.DataBind();
                ddlDomain.SelectedValue = "app_ddl_all_text";
                SearchResult();
            }
        }
        /// <summary>
        /// Search results
        /// </summary>
        private void SearchResult()
        {
            SystemThemes theme = new SystemThemes();
            theme.s_theme_id_pk = txtThemeId.Text;
            theme.s_theme_name = txtThemeName.Text;
            theme.s_theme_status_id_fk = ddlStatus.SelectedValue;
            theme.s_theme_domain_id_fk = ddlDomain.SelectedValue;
            theme.s_theme_owner_name = txtOwner.Text;
            theme.s_theme_coordinator_name = txtCoordinator.Text;

            try
            {
                gvsearchDetails.DataSource = SystemThemeBLL.SearchTheme(theme);
                gvsearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samtmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samtmp-01", ex.Message);
                    }
                }
            }

            if (gvsearchDetails.Rows.Count == 0)
            {
                disable();
            }
            else
            {
                enable();
            }
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }

        protected void btnAddNewTheme_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Themes/saantp-01.aspx");
        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }

        private void disable()
        {
            btnHeaderFirst.Visible = false;
            btnHeaderPrevious.Visible = false;
            btnHeaderNext.Visible = false;
            btnHeaderLast.Visible = false;

            btnFooterFirst.Visible = false;
            btnFooterPrevious.Visible = false;
            btnFooterNext.Visible = false;
            btnFooterLast.Visible = false;

            ddlHeaderResultPerPage.Visible = false;
            ddlFooterResultPerPage.Visible = false;

            txtHeaderPage.Visible = false;
            lblHeaderPage.Visible = false;

            txtFooterPage.Visible = false;
            lblFooterPage.Visible = false;

            btnHeaderGoto.Visible = false;
            btnFooterGoto.Visible = false;

            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;

            lblFooterPageOf.Visible = false;
            lblHeaderPageOf.Visible = false;
        }
        private void enable()
        {
            btnHeaderFirst.Visible = true;
            btnHeaderPrevious.Visible = true;
            btnHeaderNext.Visible = true;
            btnHeaderLast.Visible = true;

            btnFooterFirst.Visible = true;
            btnFooterPrevious.Visible = true;
            btnFooterNext.Visible = true;
            btnFooterLast.Visible = true;

            ddlHeaderResultPerPage.Visible = true;
            ddlFooterResultPerPage.Visible = true;

            txtHeaderPage.Visible = true;
            lblHeaderPage.Visible = true;

            txtFooterPage.Visible = true;
            lblFooterPage.Visible = true;

            btnHeaderGoto.Visible = true;
            btnFooterGoto.Visible = true;

            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;

            lblFooterPageOf.Visible = true;
            lblHeaderPageOf.Visible = true;
        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("~/SystemHome/Configuration/Themes/saetp-01.aspx?themeid=" + SecurityCenter.EncryptText(gvsearchDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Copy"))
            {
                DataTable dtDomain = new DataTable();
                string u_splash_system_id_pk = string.Empty;
                try
                {
                    dtDomain = SystemSplashPageBLL.GetNotCreatedDomain();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samtmp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samtmp-01.aspx", ex.Message);
                        }
                    }
                }

                if (dtDomain.Rows.Count > 0)
                {
                    SystemThemes theme = new SystemThemes();
                    try
                    {
                        theme = SystemThemeBLL.GetThemeById(gvsearchDetails.DataKeys[rowIndex].Values[0].ToString());

                        SystemThemes copyTheme = new SystemThemes();
                        copyTheme.s_theme_system_id_pk = Guid.NewGuid().ToString();
                        copyTheme.s_theme_id_pk = theme.s_theme_id_pk +"_copy";
                        copyTheme.s_theme_name = theme.s_theme_name;
                        copyTheme.s_theme_description = theme.s_theme_description;
                        copyTheme.s_theme_status_id_fk = theme.s_theme_status_id_fk;
                        copyTheme.s_theme_owner_id_fk = theme.s_theme_owner_id_fk;
                        copyTheme.s_theme_coordinator_id_fk = theme.s_theme_coordinator_id_fk;
                        copyTheme.s_theme_head_logo_file_name = theme.s_theme_head_logo_file_name;
                        copyTheme.s_theme_report_logo_file_name = theme.s_theme_report_logo_file_name;
                        copyTheme.s_theme_notification_logo_file_name = theme.s_theme_notification_logo_file_name;
                        copyTheme.s_theme_css_tag_main_background_hex_value = theme.s_theme_css_tag_main_background_hex_value;
                        copyTheme.s_theme_css_tag_login_background_hex_value = theme.s_theme_css_tag_login_background_hex_value;
                        copyTheme.s_theme_css_tag_login_button_hex_value = theme.s_theme_css_tag_login_button_hex_value;
                        copyTheme.s_theme_css_tag_login_text_hex_value = theme.s_theme_css_tag_login_text_hex_value;
                        copyTheme.s_theme_css_tag_login_link_hex_value = theme.s_theme_css_tag_login_link_hex_value;
                        copyTheme.s_theme_css_tag_nav_top_line_hex_value = theme.s_theme_css_tag_nav_top_line_hex_value;
                        copyTheme.s_theme_css_tag_nav_bar_hex_value = theme.s_theme_css_tag_nav_bar_hex_value;
                        copyTheme.s_theme_css_tag_nav_bar_text_hex_value = theme.s_theme_css_tag_nav_bar_text_hex_value;
                        copyTheme.s_theme_css_tag_nav_bot_line_hex_value = theme.s_theme_css_tag_nav_bot_line_hex_value;
                        copyTheme.s_theme_css_tag_nav_active_hex_value = theme.s_theme_css_tag_nav_active_hex_value;
                        copyTheme.s_theme_css_tag_nav_active_text_hex_value = theme.s_theme_css_tag_nav_active_text_hex_value;
                        copyTheme.s_theme_css_tag_foot_top_line_hex_value = theme.s_theme_css_tag_foot_top_line_hex_value;
                        copyTheme.s_theme_css_tag_foot_bot_line_hex_value = theme.s_theme_css_tag_foot_bot_line_hex_value;
                        copyTheme.s_theme_css_tag_section_head_hex_value = theme.s_theme_css_tag_section_head_hex_value;
                        copyTheme.s_theme_css_tag_section_head_text_hex_value = theme.s_theme_css_tag_section_head_text_hex_value;
                        copyTheme.s_theme_css_tag_section_head_border_hex_value = theme.s_theme_css_tag_section_head_border_hex_value;
                        copyTheme.s_theme_css_tag_table_head_hex_value = theme.s_theme_css_tag_table_head_hex_value;
                        copyTheme.s_theme_css_tag_table_head_text_hex_value = theme.s_theme_css_tag_table_head_text_hex_value;
                        copyTheme.s_theme_css_tag_table_border_hex_value = theme.s_theme_css_tag_table_border_hex_value;
                        copyTheme.s_theme_css_tag_bread_link_hex_value = theme.s_theme_css_tag_bread_link_hex_value;
                        copyTheme.s_theme_css_tag_bread_text_hex_value = theme.s_theme_css_tag_bread_text_hex_value;
                        copyTheme.s_theme_css_tag_body_text_hex_value = theme.s_theme_css_tag_body_text_hex_value;
                        copyTheme.s_theme_css_tag_body_link_hex_value = theme.s_theme_css_tag_body_link_hex_value;                         
               
                        int result = SystemThemeBLL.InsertTheme(copyTheme);
                        if (result == 0)
                        {
                            Response.Redirect("~/SystemHome/Configuration/Themes/saetp-01.aspx?copythemeid=" + SecurityCenter.EncryptText(copyTheme.s_theme_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                        }
            
                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("samtmp-01.aspx (Copy)", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("samtmp-01.aspx (Copy)", ex.Message);
                            }
                        }
                    }

                }

            }
            else if (e.CommandName.Equals("Archive"))
            {
                try
                {
                    SystemThemeBLL.UpdateThemeStatus(gvsearchDetails.DataKeys[rowIndex].Values[0].ToString());
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samtmp-01.aspx (Archive)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samtmp-01.aspx (Archive)", ex.Message);
                        }
                    }
                }
                SearchResult();
            }
        }

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }

        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}