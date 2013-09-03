using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.AboutUs
{
    public partial class auppl_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/glp-01.aspx>" + LocalResources.GetGlobalLabel("wp_nav_home") + "</a>&nbsp; " + ">" + "&nbsp;<a href=../AboutUs/aup-01.aspx>" + LocalResources.GetGlobalLabel("wp_nav_about_us") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("wp_nav_au_pod_partners");


        }
    }
}