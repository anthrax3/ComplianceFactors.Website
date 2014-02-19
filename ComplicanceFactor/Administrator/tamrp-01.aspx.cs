using System;
using ComplicanceFactor.Common.Languages;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Administrator
{
    public partial class tamrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mrp1.flag = ReportEnum.Administrator;
            SessionWrapper.navigationText = "app_nav_admin";

            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Administrator/tahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_admin") + "</a>&nbsp;" + " >&nbsp;<a href=/Administrator/tahp-01.aspx>" + "Home" + "</a>&nbsp;>&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_reports_text") + "</a>";
        }
    }
}