using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Net;

namespace ComplicanceFactor.SystemHome
{
    public partial class sahp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SessionWrapper.u_userid))
                {                     
                    User userSplash = new User();
                    try
                    {
                        userSplash = UserBLL.GetUserSplash(SessionWrapper.u_userid);
                        bool result = userSplash.u_splash_display_flag;
                        SystemSplashPage splashContent = new SystemSplashPage();
                        //Here we can get the splash content based on the domain Id
                        splashContent = SystemSplashPageBLL.GetSplashContent(SessionWrapper.u_domain,SessionWrapper.CultureName);
                        spalsh.InnerHtml = WebUtility.HtmlDecode(splashContent.u_splash_content);
                        if (result == false && (!string.IsNullOrEmpty(splashContent.u_splash_content)) && string.IsNullOrEmpty(SessionWrapper.IsClose))
                        {
                            mpSplashPage.Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("sahp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("sahp-01.aspx", ex.Message);
                            }
                        }
                    }
                }

                gvSplashPages.AllowPaging = true;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>";
                if (SessionWrapper.u_profile_my_system_splashes_records_display_pref == 0)
                {
                    gvSplashPages.AllowPaging = false;
                }
                else
                {

                    gvSplashPages.PageSize = SessionWrapper.u_profile_my_system_splashes_records_display_pref;
                }
                if (SessionWrapper.u_profile_my_system_splashes_collapse_pref == "app_ddl_collapsed")
                {
                    div_SplashPages.Style.Add("display", "none");
                    imgSpalshPage.ImageUrl = "~/Images/addplus-sm.gif";
                    imgSpalshPage.AlternateText = "plus";
                }
                else
                {
                    div_SplashPages.Style.Add("display", "block");
                    imgSpalshPage.ImageUrl = "~/Images/addminus-sm.gif";
                    imgSpalshPage.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_system_themes_collapse_pref == "app_ddl_collapsed")
                {
                    div_Themes.Style.Add("display", "none");
                    imgTheme.ImageUrl = "~/Images/addplus-sm.gif";
                    imgTheme.AlternateText = "plus";

                }
                else
                {
                    div_Themes.Style.Add("display", "block");
                    imgTheme.ImageUrl = "~/Images/addminus-sm.gif";
                    imgTheme.AlternateText = "minus";
                }
                if (SessionWrapper.u_profile_my_system_reports_collapse_pref == "app_ddl_collapsed")
                {
                    div_MyReports.Style.Add("display", "none");
                    imgReport.ImageUrl = "~/Images/addplus-sm.gif";
                    imgReport.AlternateText = "plus";

                }
                else
                {
                    div_MyReports.Style.Add("display", "block");
                    imgReport.ImageUrl = "~/Images/addminus-sm.gif";
                    imgReport.AlternateText = "minus";
                }
                SearchResult();

            }
        }

        private void SearchResult()
        {
            gvSplashPages.DataSource = SystemSplashPageBLL.GetSplashPages();
            gvSplashPages.DataBind();

            if (gvSplashPages.Rows.Count > 0)
            {
                gvSplashPages.UseAccessibleHeader = true;
                if (gvSplashPages.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvSplashPages.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

            DataTable dtThemes = new DataTable();
            dtThemes.Columns.Add("ThemeName", Type.GetType("System.String"));
            dtThemes.Columns.Add("Created", Type.GetType("System.String"));
            dtThemes.Columns.Add("Domain", Type.GetType("System.String"));
            DataRow dr;
            for (int i = 0; i < 5; i++)
            {
                dr = dtThemes.NewRow();
                dr["ThemeName"] = "Compliance Factor(Default Theme 00" + i.ToString();
                dr["Created"] = DateTime.Now.AddDays(-i);
                dr["Domain"] = "Test";
                dtThemes.Rows.Add(dr);
            }
            gvThemes.DataSource = dtThemes;
            gvThemes.DataBind();

            if (gvThemes.Rows.Count > 0)
            {
                gvThemes.UseAccessibleHeader = true;
                if (gvThemes.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvThemes.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

            DataTable dtReports = new DataTable();
            dtReports.Columns.Add("ReportName", Type.GetType("System.String"));
            dtReports.Columns.Add("Created", Type.GetType("System.String"));
            dtReports.Columns.Add("Type", Type.GetType("System.String"));
            DataRow drReports;
            for (int i = 0; i < 1; i++)
            {
                drReports = dtReports.NewRow();
                drReports["ReportName"] = "Catalog Lisitng (CF-CAT-LIST)";
                drReports["Created"] = "Yearly (December 31st)";
                drReports["Type"] = "OnDemand";
                dtReports.Rows.Add(drReports);
            }

            gvMyReports.DataSource = dtReports;
            gvMyReports.DataBind();

            if (gvMyReports.Rows.Count > 0)
            {
                gvMyReports.UseAccessibleHeader = true;
                if (gvMyReports.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvMyReports.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        protected void gvSplashPages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("~/SystemHome/Configuration/Splash Pages/saespn-01.aspx?edit=" + SecurityCenter.EncryptText(gvSplashPages.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Detail"))
            {
                Response.Redirect("~/SystemHome/Configuration/Splash Pages/samspmp-01.aspx");
            }
        }

        protected void gvSplashPages_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void lnkManageSplashPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Splash Pages/samspmp-01.aspx");
        }

        protected void btnViewAllReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/samrp-01.aspx");
        }

        protected void btnDonotShow_Click(object sender, EventArgs e)
        {
            //Set the u_splash_display_flag as 1.
            User userSplash = new User();
            userSplash.Userid = SessionWrapper.u_userid;
            userSplash.u_splash_display_flag = true;

            try
            {
                int result = UserBLL.UpdateSplash(userSplash);
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sahp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sahp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnCloseSplashPage_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }
        protected void ibtnCloseSplash_Click(object sender, EventArgs e)
        {
            SessionWrapper.IsClose = "True";
        }
        
    }
}
