using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class samamp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a>System</a>" + "&nbsp;>&nbsp;" + "Manage Approvals";
                //Bind status
                ddlStatus.DataSource = SystemApprovalBLL.Getstatus();
                ddlStatus.DataBind();
            }
        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemHome/Catalog/Approvals/samasrp-01.aspx?eid=" + SecurityCenter.EncryptText(txtEmployeeId.Text) +
            "&ename=" + SecurityCenter.EncryptText(txtEmployeeName.Text) + "&status=" + SecurityCenter.EncryptText(ddlStatus.SelectedValue) +
            "&aid=" + SecurityCenter.EncryptText(txtApproverId.Text) + "&aname=" + SecurityCenter.EncryptText(txtApproverName.Text) +
            "&avid=" + SecurityCenter.EncryptText(txtApprovalId.Text));

        }
    }
}