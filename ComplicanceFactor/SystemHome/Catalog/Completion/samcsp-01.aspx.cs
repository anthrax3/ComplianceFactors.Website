using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Completion
{
    public partial class samcsp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;<a href=/SystemHome/sahp-01.aspx>" + "Home" + "</a>&nbsp;" + LocalResources.GetGlobalLabel("app_manage_completion_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_completion_text") + "</a>&nbsp;>&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_completion_text") + "</a>";

                ddlDeliveryType.DataSource = SystemCatalogBLL.GetDeliveryType(SessionWrapper.CultureName);
                ddlDeliveryType.DataBind();
                ddlDeliveryType.SelectedValue = "app_ddl_all_text";

                ddlStatus.DataSource = SystemCatalogBLL.GetCourseStatus(SessionWrapper.CultureName, "saantc-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";
            }
        }

        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Completion/samcsrp-01.aspx?CourseId=" +SecurityCenter.EncryptText( txtCourseId.Text)+ "&courseTitle=" + SecurityCenter.EncryptText(txtCourseTitle.Text) + "&version=" + SecurityCenter.EncryptText(txtVersion.Text)
                + "&deliveryId=" + SecurityCenter.EncryptText(txtDeliveryId.Text) + "&deliveryTitle=" + SecurityCenter.EncryptText(txtDeliveryTitle.Text) + "&deliveryType=" + SecurityCenter.EncryptText(ddlDeliveryType.SelectedValue)
                + "&InstructorName=" + SecurityCenter.EncryptText(txtInstructor.Text) + "&status=" + SecurityCenter.EncryptText(ddlStatus.SelectedValue) + "&Owner=" + SecurityCenter.EncryptText(txtOwner.Text) + "&coowner=" + SecurityCenter.EncryptText(txtCoordinator.Text) 
                +"&locationName="+SecurityCenter.EncryptText(txtLocation.Text) + "&facilityName="+SecurityCenter.EncryptText(txtFacility.Text)+"&roomName="+SecurityCenter.EncryptText(txtRoom.Text)
                + "&startdate=" + SecurityCenter.EncryptText(txtDateFrom.Text) + "&enddate=" + SecurityCenter.EncryptText(txtDateTo.Text), false);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}