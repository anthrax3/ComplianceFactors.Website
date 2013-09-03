using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.Administrator
{
    public partial class tamdd_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Administrator/tahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_admin") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_admin_pod_mdashboard_title") + "</a>";
        }
    }
}