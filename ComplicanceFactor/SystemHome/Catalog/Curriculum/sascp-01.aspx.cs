using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum
{
    public partial class sascp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + "System" + "</a>&nbsp;" + " >&nbsp;" + "Manage Curriculum";

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_manage_curriculam_text");

                try
                {
                    ddlStatus.DataSource = SystemCurriculumBLL.GetCurriculumAllStatus(SessionWrapper.CultureName,"sascp-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_all_text";
                    ddlCurriculumType.DataSource = SystemCurriculumBLL.GetCurriculumType(SessionWrapper.CultureName);
                    ddlCurriculumType.DataBind();

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sascp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sascp-01", ex.Message);
                        }
                    }
                }
            }

        }

        protected void btnAddNewCurriculum_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/saanc-01.aspx", false);
        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Curriculum/sascr-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculumId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&ver=" + SecurityCenter.EncryptText(txtVersion.Text) + "&sts=" + SecurityCenter.EncryptText(ddlStatus.SelectedValue) + "&own=" + SecurityCenter.EncryptText(txtOwner.Text) + "&cown=" + SecurityCenter.EncryptText(txtCoordinator.Text), false);
        }
    }
}