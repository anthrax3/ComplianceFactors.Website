using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles
{
    public partial class samdmmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string navigationText;
            Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
            navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
            hdNav_selected.Value = "#" + SessionWrapper.navigationText;
            lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "Manage Digital Media Files";
        }

        protected void btnAddNewMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/DigitalMediaFiles/saandmp-01.aspx");
        }
    }
}