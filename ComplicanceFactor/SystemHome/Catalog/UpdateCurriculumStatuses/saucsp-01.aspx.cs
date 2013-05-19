using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses
{
    public partial class saucsp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_update_curriculum_statuses_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_update_curriculum_statuses_text");


                try
                {
                    ddlStatus.DataSource = SystemCurriculumBLL.GetCurriculumAllStatus(SessionWrapper.CultureName, string.Empty);
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_all_text";

                    ddlCurriculumType.DataSource = SystemCurriculumBLL.GetCurriculumType();
                    ddlCurriculumType.DataBind();

                    ListItem liFirstItem = new ListItem();
                    liFirstItem.Text = "All";
                    liFirstItem.Value = "0";
                    ddlCurriculumType.Items.Insert(0, liFirstItem);
                    ddlCurriculumType.SelectedIndex = 0;
 
                     

                    //ddlCurriculumType.DataSource = SystemCurriculumBLL.Getcurriculumtype(SessionWrapper.CultureName);
                    //ddlCurriculumType.DataBind();

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saucsp(update Curriculum Status)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saucsp(update Curriculum Status)", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/UpdateCurriculumStatuses/saucsrp-01.aspx?id=" + SecurityCenter.EncryptText(txtCurriculumId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtCurriculumTitle.Text) + "&sts=" + SecurityCenter.EncryptText(ddlStatus.SelectedValue) + "&own=" + SecurityCenter.EncryptText(txtOwner.Text) + "&cown=" + SecurityCenter.EncryptText(txtCoordinator.Text), false);

        }
    }
}