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
    public partial class saedtn_01 : BasePage
    {
        private static string editDeliveryTypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Edit delivery Type Id
            if (!string.IsNullOrEmpty(Request.QueryString["edt"]))
            {
                editDeliveryTypeId = SecurityCenter.DecryptText(Request.QueryString["edt"]);
            }
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;"
                    + "<a href=/SystemHome/Configuration/RootCauseCategory/samdtmp-01.aspx> Manage Root Cause Category</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>Edit Root Cause Category</a>";

                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                ///<summary>
                //Get Delivery type id
                /// </summary>
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editDeliveryTypeId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdDeliveryTypeId.Value = editDeliveryTypeId;

                }
                //Bind status
                ddlStatus.DataSource = SysemDeliveryTypesBLL.GetStatus(SessionWrapper.CultureName,"saedtn-01");
                ddlStatus.DataBind();                

               
                PopulateRca(editDeliveryTypeId);
            }
        }
        private void PopulateRca(string RcaId)
        {
            RcaCategory rcaCategory = new RcaCategory();

            rcaCategory = SystemRcCategoryBLL.GetRcCategory(RcaId);

            txtCategoryId.Text = rcaCategory.c_tb_rc_category_id;
            ddlStatus.SelectedValue = rcaCategory.c_tb_rc_category_status;
            ddlCategoryType.SelectedValue = rcaCategory.c_tb_rc_category_type;


            txtCategoryName.Text = rcaCategory.c_tb_rc_category_title;
            txtDescriptionUS.Value = rcaCategory.c_tb_rc_category_desc;
            
          
        }
        private void UpdateCategory()
        {
            RcaCategory updateRca = new RcaCategory();
            updateRca.c_tb_rc_category_System_id_pk = editDeliveryTypeId;
            updateRca.c_tb_rc_category_id = txtCategoryId.Text;
            updateRca.c_tb_rc_category_status = ddlStatus.SelectedValue;
            updateRca.c_tb_rc_category_type = ddlCategoryType.SelectedValue;

            updateRca.c_tb_rc_category_title = txtCategoryName.Text;
            updateRca.c_tb_rc_category_desc = txtDescriptionUS.Value;
            
           
            int error;

            error = SystemRcCategoryBLL.UpdateRcaCategory(updateRca);
            if (error != -2)
            {
                //Show success message
                divSuccess.Style.Add("display", "block");
                divError.Style.Add("display", "none");
                divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");


            }
            else
            {
                //Show error message 
                divSuccess.Style.Add("display", "none");
                divError.Style.Add("display", "block");
                divError.InnerText = LocalResources.GetText("app_delivery_id_alredy_exists_error_text");

            }
        }

        protected void btnHeaderSaveNewDeliveryType_Click(object sender, EventArgs e)
        {
            UpdateCategory();
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
            UpdateCategory();
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