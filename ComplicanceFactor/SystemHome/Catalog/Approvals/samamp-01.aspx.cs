using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
namespace ComplicanceFactor.SystemHome.Catalog.Approvals
{
    public partial class samamp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_approvals_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_approvals_text");

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