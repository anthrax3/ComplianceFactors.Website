using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class samwsrp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "System" + "&nbsp;>&nbsp;" + "Manage Waitlists";


                SearchResult();
            }
        }

        private void SearchResult()
        {
            try
            {
                gvsearchDetails.DataSource = SystemWaitListBLL.GetWaitList();
                gvsearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samwsrp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samwsrp-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Select"))
            {
                Response.Redirect("~/SystemHome/Catalog/Waitlist/saews-01.aspx?deliveryId=" + SecurityCenter.EncryptText(gvsearchDetails.DataKeys[rowIndex].Values[0].ToString()) + "&courseId=" + SecurityCenter.EncryptText(gvsearchDetails.DataKeys[rowIndex].Values[1].ToString()), false);
            }
        }
    }
}