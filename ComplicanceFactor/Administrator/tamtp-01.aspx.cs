using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.Administrator
{
    public partial class tamtp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionWrapper.navigationText = "app_nav_admin";

            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Administrator/tahp-01.aspx>" + LocalResources.GetGlobalLabel("app_administrator_text") + "</a>&nbsp;" + " >&nbsp;<a href=/Administrator/tahp-01.aspx>" + "Home" + "</a>&nbsp;>&nbsp;" + LocalResources.GetGlobalLabel("app_manage_training_text");
        }
    }
}