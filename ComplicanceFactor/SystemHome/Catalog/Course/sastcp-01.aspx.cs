using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog
{
    public partial class sastcp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_training_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_manage_training_text");
                try
                {
                    ddlStatus.DataSource = SystemCatalogBLL.GetCourseAllStatus(SessionWrapper.CultureName,"sastcp-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_all_text";

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sastcp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sastcp-01", ex.Message);
                        }
                    }
                }
            }

        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Course/sastcr-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseID.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&ver=" + SecurityCenter.EncryptText(txtVersion.Text) + "&sts=" + SecurityCenter.EncryptText(ddlStatus.SelectedValue) + "&own=" + SecurityCenter.EncryptText(txtOwner.Text) + "&cown=" + SecurityCenter.EncryptText(txtCoordinator.Text),false);

        }

        protected void btnAddNewCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Course/saantc-01.aspx", false);
        }
    }
}