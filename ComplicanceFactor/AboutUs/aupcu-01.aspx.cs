using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Web.Security;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.AboutUs
{
    public partial class aupcu_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/glp-01.aspx>" + LocalResources.GetGlobalLabel("wp_nav_home") + "</a>&nbsp; " + ">" + "&nbsp;<a href=../AboutUs/aup-01.aspx>" + LocalResources.GetGlobalLabel("wp_nav_about_us") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("wp_nav_au_pod_contact_us");


        }
    }
}