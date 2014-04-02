using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.RootCauseCategory
{
    public partial class saandtn_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" +
                    "<a href=/SystemHome/Configuration/RootCauseCategory/samdtmp-01.aspx>Root Cause Category</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>Creat New Category</a>";
                try
                {
                    //Bind Status
                    ddlStatus.DataSource = SysemDeliveryTypesBLL.GetStatus(SessionWrapper.CultureName,"saandtn-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                  
                  
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saandtn-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saandtn-01", ex.Message);
                        }
                    }

                }
            }
        }
        private void SaveCategory()
        {
            RcaCategory createRca = new RcaCategory();
            createRca.c_tb_rc_category_System_id_pk = Guid.NewGuid().ToString();
            createRca.c_tb_rc_category_id = txtCategoryId.Text;
            
            createRca.c_tb_rc_category_status = ddlStatus.SelectedValue;
            createRca.c_tb_rc_category_type = ddlCategoryType.SelectedValue;


            createRca.c_tb_rc_category_title = txtCategoryName.Text;
            createRca.c_tb_rc_category_desc = txtDescriptionUS.Value;

         

            int error;

            error = SystemRcCategoryBLL.CreateRcCategory(createRca);
            if (error != -2)
            {
                Response.Redirect("~/SystemHome/Configuration/RootCauseCategory/saedtn-01.aspx?id=" + SecurityCenter.EncryptText(createRca.c_tb_rc_category_System_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
            }
            else
            {
                ///<summary>
                ///Show error message 
                ///</summary>
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_delivery_id_alredy_exists_error_text");
            }


        }

        protected void btnHeaderSaveNewDeliveryType_Click(object sender, EventArgs e)
        {
            SaveCategory();
        }

        

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/RootCauseCategory/samdtmp-01.aspx", false);
        }

        protected void btnFooterSaveNewDeliveryType_Click(object sender, EventArgs e)
        {
            SaveCategory();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/RootCauseCategory/samdtmp-01.aspx", false);
        }
    }
}