using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;
using System.Web.UI.HtmlControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.IO;

namespace ComplicanceFactor.SystemHome.Configuration.Themes
{
    public partial class saantp_01 : System.Web.UI.Page
    {
        public static string logoUpload;
        public static string _path = "~/Images/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsDefaultTheme = new DataSet();

                dsDefaultTheme = SystemThemeBLL.GetDefaultTheme();
                SessionWrapper.defaults_theme_color = dsDefaultTheme.Tables[1];
                SessionWrapper.defaults_theme_logo = dsDefaultTheme.Tables[0];

                gvLogos.DataSource = SessionWrapper.defaults_theme_logo;
                gvLogos.DataBind();

                gvColors.DataSource = SessionWrapper.defaults_theme_color;
                gvColors.DataBind();

                ////ddlDomain                 
                //ddlDomain.DataSource = SystemSplashPageBLL.GetNotCreatedDomain();
                //ddlDomain.DataBind();

                //Bind status
                ddlStatus.DataSource = SystemDomainBLL.GetAllDomainStatus(SessionWrapper.CultureName, "samdmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_all_text";

                SessionWrapper.s_theme_owner_id_fk = string.Empty;
                SessionWrapper.s_theme_coordinator_id_fk = string.Empty;
                SessionWrapper.s_theme_coordinator_name = string.Empty;
                SessionWrapper.s_theme_owner_name = string.Empty;

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Themes/samtmp-01.aspx>" + "Manage Themes" + "</a>" + " >&nbsp;" + "Create New Theme";
                
            }

            gvLogos.DataSource = SessionWrapper.defaults_theme_logo;
            gvLogos.DataBind();

            lblCoordinator.Text = SessionWrapper.s_theme_coordinator_name;
            lblOwner.Text = SessionWrapper.s_theme_owner_name;
        }

        protected void gvColors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltlPreviewColor = (Literal)e.Row.FindControl("ltlPreviewColor");
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Colorvalue = Convert.ToString(drv["Colorvalue"]);
                Colorvalue = "#" + Colorvalue;
                ltlPreviewColor.Text = "<input  type='text' readonly='readonly' style='border: 1px solid black; width: 25px; height: 25px; background:" + Colorvalue + "'/>";
                //HtmlGenericControl msgDiv = (HtmlGenericControl)e.Row.FindControl("ColorDiv");
                //msgDiv.Style.Add("background-color", colorValue);
            }
        }

        protected void gvColors_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnFooterSaveTheme_Click(object sender, EventArgs e)
        {
            SaveTheme();
        }

        protected void btnHeaderSaveTheme_Click(object sender, EventArgs e)
        {
            SaveTheme();
        }

        /// <summary>
        /// Save Theme
        /// </summary>
        private void SaveTheme()
        {
            string headerLogo = string.Empty;
            string reportLogo = string.Empty;
            string notificationLogo = string.Empty;

            //Logo
            foreach (GridViewRow logoRow in gvLogos.Rows)
            {
                string logocolumnName = gvLogos.DataKeys[logoRow.RowIndex][0].ToString();
                var rows = SessionWrapper.defaults_theme_logo.Select("keyvalue= '" + logocolumnName + "'");
                foreach (var currentrow in rows)
                    currentrow["FileName"] = logoRow.Cells[1].Text;
                SessionWrapper.defaults_theme_logo.AcceptChanges();
            }

            //Colors
            foreach (GridViewRow row in gvColors.Rows)
            {
            
                string columnName = gvColors.DataKeys[row.RowIndex][0].ToString();
                TextBox txtHex = (TextBox)row.FindControl("txtHex");
                var rows = SessionWrapper.defaults_theme_color.Select("keyvalue= '" + columnName + "'");
                foreach (var currentrow in rows)
                    currentrow["Colorvalue"] = txtHex.Text;
                SessionWrapper.defaults_theme_color.AcceptChanges();
            }

            //ConvertDataTables convertXml = new ConvertDataTables();
            //string colorXml = convertXml.ConvertDataTableToXml(SessionWrapper.defaults_theme_color);

            SystemThemes theme = new SystemThemes();
            theme.s_theme_system_id_pk = Guid.NewGuid().ToString();
            theme.s_theme_id_pk = txtThemeId.Text;
            theme.s_theme_name = txtThemeName.Text;
            theme.s_theme_description = txtContent.InnerText;
            theme.s_theme_status_id_fk = ddlStatus.SelectedValue;
            theme.s_theme_owner_id_fk = SessionWrapper.s_theme_owner_id_fk;
            theme.s_theme_coordinator_id_fk = SessionWrapper.s_theme_coordinator_id_fk;
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

            try
            {
                //Insertion
                int result = SystemThemeBLL.InsertTheme(theme);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/Themes/saetp-01.aspx?copythemeid=" + SecurityCenter.EncryptText(theme.s_theme_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
            }
            catch (Exception ex)
            {

            }


        }

        protected void gvLogos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Upload"))
            {
                logoUpload = gvLogos.DataKeys[rowIndex].Values[0].ToString();
            }
            mpeAddAttachment.Show();
        }

        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string c_file_name = null;
                string c_file_extension = null;
                if (file != null && file.ContentLength > 0)
                {
                    c_file_name = Path.GetFileName(file.FileName);
                    c_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_path + c_file_name));

                    var rows = SessionWrapper.defaults_theme_logo.Select("s_theme_description= '" + logoUpload + "'");
                    foreach (var currentrow in rows)
                        currentrow["FileName"] = c_file_name;
                    SessionWrapper.defaults_theme_logo.AcceptChanges();
                }
            }

            this.gvLogos.DataSource = SessionWrapper.defaults_theme_logo;
            this.gvLogos.DataBind();
        }

        protected void gvColors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Reset"))
            {
                string color = SystemThemeBLL.GetDefaultColorById(gvColors.DataKeys[rowIndex].Values[0].ToString());
                if (!string.IsNullOrEmpty(color))
                {
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                    TextBox textBox = (TextBox)row.FindControl("txtHex");
                    Literal ltlPreviewColor = (Literal)row.FindControl("ltlPreviewColor");
                    textBox.Text = color;

                    //HtmlGenericControl msgDiv = (HtmlGenericControl)row.FindControl("ColorDiv");
                    //msgDiv.Style.Add("background-color", "#" + color);

                    ltlPreviewColor.Text = "<input  type='text' readonly='readonly' style='border: 1px solid black; width: 25px; height: 25px; background:#" + color + "'/>";
                }                 
            }
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Themes/samtmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Themes/samtmp-01.aspx");
        }
    }
}