using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.AssignmentGroups
{
    public partial class saeag_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlStatus.DataSource = SystemAssignmentGroupBLL.GetStatus(SessionWrapper.CultureName, "sasup-01");
                ddlStatus.DataBind();
            }
        }

        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }

        protected void btnFooterSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/AssignmentGroups/samagmp-01.aspx");
        }
    }
}