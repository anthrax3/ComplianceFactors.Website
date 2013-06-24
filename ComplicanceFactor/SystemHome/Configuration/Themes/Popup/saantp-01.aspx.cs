using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Themes.Popup
{
    public partial class saantp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
            {
                Label lblPreviewTheme = (Label)Master.FindControl("lblPreviewTheme");
                lblPreviewTheme.Text = "Preview";
                

                //DataSet dsDefaultTheme = new DataSet();

                //dsDefaultTheme = SystemThemeBLL.GetDefaultTheme();
                //SessionWrapper.defaults_theme_color = dsDefaultTheme.Tables[1];
                //SessionWrapper.defaults_theme_logo = dsDefaultTheme.Tables[0];

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

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                //hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Themes/samtmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_themes_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_theme_text") + "</a>";
                
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
 
    }
}