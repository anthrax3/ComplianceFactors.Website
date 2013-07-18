using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Training
{
    public partial class tcmrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.navigationText = "app_nav_training";

                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_training") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_home_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_my_reports_text") + "</a>";
            }
        }
    }
}