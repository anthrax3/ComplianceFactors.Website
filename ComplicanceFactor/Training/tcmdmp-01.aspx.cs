using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Training
{
    public partial class tcmdmp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/Training/tchp-01.aspx>" + LocalResources.GetGlobalLabel("app_training_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_deliveries_text") + "</a>";
                try
                {
                    ddlStatus.DataSource = SystemCatalogBLL.GetCourseAllStatus(SessionWrapper.CultureName, "sastcp-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_all_text";

                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here;
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("tcmdmp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("tcmdmp-01", ex.Message);
                        }
                    }
                }
            }

        }


        protected void btnGoSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Training/tcmdsrp-01.aspx?id=" + SecurityCenter.EncryptText(txtCourseId.Text) + "&tlt=" + SecurityCenter.EncryptText(txtTitle.Text) + "&ver=" + SecurityCenter.EncryptText(txtVersion.Text) + "&sts=" + SecurityCenter.EncryptText(ddlStatus.SelectedValue) + "&own=" + SecurityCenter.EncryptText(txtOwner.Text) + "&cown=" + SecurityCenter.EncryptText(txtCoordinator.Text), false);
        }

    }
}