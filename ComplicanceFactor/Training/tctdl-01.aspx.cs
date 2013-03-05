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
namespace ComplicanceFactor.Training
{
    public partial class tctdl_01 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            lblBreadCrumb.Text = "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_training") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_training_pod_mtodo_title");

        }
    }
}