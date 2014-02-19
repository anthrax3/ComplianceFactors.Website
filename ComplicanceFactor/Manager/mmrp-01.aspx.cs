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

namespace ComplicanceFactor.Manager
{
    public partial class mmrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mrp1.flag = ReportEnum.Manager;
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>" + " >&nbsp;" + "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_reports_text") + "</a>";
        }
    }
}