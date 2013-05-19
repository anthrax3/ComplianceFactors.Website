using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class saeas_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "System" + "&nbsp;>&nbsp;" + "Manage Approval Workflow" + "&nbsp;>&nbsp;" + "Edit Approval Workflow Information";

            }
        }
    }
}