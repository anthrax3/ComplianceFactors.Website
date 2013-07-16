using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Compliance
{
    public partial class ccmrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.navigationText = "app_nav_compliance";
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_compliance") + "</a>" + " > " + "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetGlobalLabel("app_my_reports_text") + "</a>";

        }
    }
}