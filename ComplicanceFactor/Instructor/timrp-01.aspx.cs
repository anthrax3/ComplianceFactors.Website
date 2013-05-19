using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Instructor
{
    public partial class timrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.navigationText = "app_nav_instructor";
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_instructor") + "</a>" + " >&nbsp;" + "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_my_reports_text");
                
        }
    }
}