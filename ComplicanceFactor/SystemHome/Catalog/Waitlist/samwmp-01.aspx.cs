using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class samwmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "Manage Waitlist";

            }
        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Waitlist/samwsrp-01.aspx?EmployeeId=" + SecurityCenter.EncryptText(txtEmployeeId.Text) + "&EmployeeName=" + SecurityCenter.EncryptText(txtEmployeeName.Text) + "&CourseId=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&courseTitle=" + SecurityCenter.EncryptText(txtCourseName.Text) + "&deliveryId="+SecurityCenter.EncryptText(txtDeliveryId.Text)
                + "&deliveryTitle=" + SecurityCenter.EncryptText(txtDeliveryName.Text) + "&coowner=" + SecurityCenter.EncryptText(txtCoordinator.Text) + "&startdate="+ SecurityCenter.EncryptText(txtDeliveryStartDate.Text)+"&enddate="+SecurityCenter.EncryptText(txtDeliveryEndDate.Text));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}