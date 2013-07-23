using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.MaterialTypes
{
    public partial class sammtmp_01 : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_material_types_text") + "</a>";

                //Bind material type status
                ddlStatus.DataSource = SystemMaterialTypeBLL.GetAllStatus(SessionWrapper.CultureName, "samftmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_all_text";
                SearchResult();
                txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
                lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
                txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
                lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            }
        }

        protected void btnAddNewMaterialType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/MaterialTypes/saanmtn-01.aspx");
        }

        private void SearchResult()
        {
            SystemMaterialType material = new SystemMaterialType();
            material.s_material_type_id = txtMaterialId.Text;
            material.s_material_type_name_us_english = txtName.Text;
            if (ddlStatus.SelectedValue == "app_ddl_all_text")
            {
                material.s_material_type_status_id_fk = "0";
            }
            else
            {
                material.s_material_type_status_id_fk = ddlStatus.SelectedValue;
            }
            try
            {
                gvMaterialTypesDetails.DataSource = SystemMaterialTypeBLL.SearchMaterial(material);
                gvMaterialTypesDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sammtmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sammtmp-01", ex.Message);
                    }
                }
            }
            if (gvMaterialTypesDetails.Rows.Count == 0)
            {

                disable_enable(false);

            }
            else
            {
                disable_enable(true);
            }
            if (gvMaterialTypesDetails.Rows.Count > 0)
            {
                gvMaterialTypesDetails.UseAccessibleHeader = true;
                if (gvMaterialTypesDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvMaterialTypesDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        protected void gvMaterialTypesDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("~/SystemHome/Configuration/MaterialTypes/saemtn-01.aspx?id=" + SecurityCenter.EncryptText(gvMaterialTypesDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Copy"))
            {
                Response.Redirect("~/SystemHome/Configuration/MaterialTypes/saanmtn-01.aspx?copy=" + SecurityCenter.EncryptText(gvMaterialTypesDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Archive"))
            {

                string materialId = gvMaterialTypesDetails.DataKeys[rowIndex][0].ToString();
                try
                {   
                    int result = SystemMaterialTypeBLL.UpdateMaterialStatus(materialId);
                    SearchResult();
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("sammtmp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("sammtmp-01", ex.Message);
                        }
                    }
                }

            }
        }

        protected void gvMaterialTypesDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvMaterialTypesDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvMaterialTypesDetails.PageCount;
            if (gvMaterialTypesDetails.PageIndex > 0)
                gvMaterialTypesDetails.PageIndex = gvMaterialTypesDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvMaterialTypesDetails.PageIndex + 1;
            if (i <= gvMaterialTypesDetails.PageCount)
                gvMaterialTypesDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvMaterialTypesDetails.PageIndex = gvMaterialTypesDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvMaterialTypesDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvMaterialTypesDetails.PageCount;
            if (gvMaterialTypesDetails.PageIndex > 0)
                gvMaterialTypesDetails.PageIndex = gvMaterialTypesDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvMaterialTypesDetails.PageIndex + 1;
            if (i <= gvMaterialTypesDetails.PageCount)
                gvMaterialTypesDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvMaterialTypesDetails.PageSize = Convert.ToInt32(gvMaterialTypesDetails.PageCount * gvMaterialTypesDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvMaterialTypesDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvMaterialTypesDetails.PageSize = Convert.ToInt32(gvMaterialTypesDetails.PageCount * gvMaterialTypesDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvMaterialTypesDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvMaterialTypesDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvMaterialTypesDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;
            SearchResult();
            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvMaterialTypesDetails.PageIndex = gvMaterialTypesDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvMaterialTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvMaterialTypesDetails.PageCount).ToString();
        }

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
        private void disable_enable(bool status)
        {
            btnHeaderFirst.Visible = status;
            btnHeaderPrevious.Visible = status;
            btnHeaderNext.Visible = status;
            btnHeaderLast.Visible = status;

            btnFooterFirst.Visible = status;
            btnFooterPrevious.Visible = status;
            btnFooterNext.Visible = status;
            btnFooterLast.Visible = status;

            ddlHeaderResultPerPage.Visible = status;
            ddlFooterResultPerPage.Visible = status;

            txtHeaderPage.Visible = status;
            lblHeaderPage.Visible = status;

            txtFooterPage.Visible = status;
            lblFooterPage.Visible = status;

            btnHeaderGoto.Visible = status;
            btnFooterGoto.Visible = status;


            lblHeaderResultPerPage.Visible = status;
            lblFooterResultPerPage.Visible = status;

            lblFooterPageOf.Visible = status;
            lblHeaderPageOf.Visible = status;

        }
       
    }
}