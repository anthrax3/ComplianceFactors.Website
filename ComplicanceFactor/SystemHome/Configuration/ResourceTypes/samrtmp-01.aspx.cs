using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.ResourceTypes
{
    public partial class samrtmp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //resource type bread crumbS
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_manage_resource_type_text");

                //Bind resource type status
                ddlStatus.DataSource = SystemResourceTypeBLL.GetAllStatus(SessionWrapper.CultureName, "samrtmp-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_all_text";
                //Resource status default selected item
                //ListItem lstStatus = new ListItem();
                //lstStatus.Text = "All";
                //lstStatus.Value = "0";

                //ddlStatus.Items.Insert(0, lstStatus);
                //ddlStatus.SelectedIndex = 0;

                SearchResults();

                //count page of page in search result
                lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
                lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();

            }
        }

        protected void btnAddNewResourceType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/ResourceTypes/saanrtn-01.aspx");
        }
        /// <summary>
        /// Search Results For ResourceType
        /// </summary>

        private void SearchResults()
        {
            try
            {
                SystemResourceType resource = new SystemResourceType();
                resource.s_resource_type_id = txtResourceID.Text;
                resource.s_resource_type_name_us_english = txtName.Text;
                if (ddlStatus.SelectedValue == "app_ddl_all_text")
                {
                    resource.s_resource_type_status_id_fk = "0";
                }
                else
                {
                    resource.s_resource_type_status_id_fk = ddlStatus.SelectedValue;
                }
                gvResourceTypesDetails.DataSource = SystemResourceTypeBLL.GetResourceType(resource);
                gvResourceTypesDetails.DataBind();
                if (gvResourceTypesDetails.Rows.Count == 0)
                {

                    disable();

                }
                else
                {
                    enable();
                }
                if (gvResourceTypesDetails.Rows.Count > 0)
                {
                    gvResourceTypesDetails.UseAccessibleHeader = true;
                    if (gvResourceTypesDetails.HeaderRow != null)
                    {
                        //This will tell ASP.NET to render the <thead> for the header row
                        //using instead of the simple <tr>
                        gvResourceTypesDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samrtmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samrtmp-01", ex.Message);
                    }
                }
            }
       
        }
        private void disable()
        {
            btnHeaderFirst.Visible = false;
            btnHeaderPrevious.Visible = false;
            btnHeaderNext.Visible = false;
            btnHeaderLast.Visible = false;

            btnFooterFirst.Visible = false;
            btnFooterPrevious.Visible = false;
            btnFooterNext.Visible = false;
            btnFooterLast.Visible = false;

            ddlHeaderResultPerPage.Visible = false;
            ddlFooterResultPerPage.Visible = false;

            txtHeaderPage.Visible = false;
            lblHeaderPage.Visible = false;

            txtFooterPage.Visible = false;
            lblFooterPage.Visible = false;

            btnHeaderGoto.Visible = false;
            btnFooterGoto.Visible = false;


            lblHeaderResultPerPage.Visible = false;
            lblFooterResultPerPage.Visible = false;

            lblFooterPageOf.Visible = false;
            lblHeaderPageOf.Visible = false;

        }
        private void enable()
        {
            btnHeaderFirst.Visible = true;
            btnHeaderPrevious.Visible = true;
            btnHeaderNext.Visible = true;
            btnHeaderLast.Visible = true;

            btnFooterFirst.Visible = true;
            btnFooterPrevious.Visible = true;
            btnFooterNext.Visible = true;
            btnFooterLast.Visible = true;

            ddlHeaderResultPerPage.Visible = true;
            ddlFooterResultPerPage.Visible = true;

            txtHeaderPage.Visible = true;
            lblHeaderPage.Visible = true;

            txtFooterPage.Visible = true;
            lblFooterPage.Visible = true;

            btnHeaderGoto.Visible = true;
            btnFooterGoto.Visible = true;


            lblHeaderResultPerPage.Visible = true;
            lblFooterResultPerPage.Visible = true;

            lblFooterPageOf.Visible = true;
            lblHeaderPageOf.Visible = true;

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {

            SearchResults();
        }

        protected void gvResourceTypesDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            //string sample = gvResourceTypesDetails.DataKeys[rowIndex].Values[0].ToString();
            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("~/SystemHome/Configuration/ResourceTypes/saertn-01.aspx?id=" + SecurityCenter.EncryptText(gvResourceTypesDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Copy"))
            {
                Response.Redirect("~/SystemHome/Configuration/ResourceTypes/saanrtn-01.aspx?copy=" + SecurityCenter.EncryptText(gvResourceTypesDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Archive"))
            {
                string resourceId = gvResourceTypesDetails.DataKeys[rowIndex][0].ToString();
                try
                {
                   
                    int result = SystemResourceTypeBLL.UpdateResourceStatus(resourceId);
                    SearchResults();
                }
                catch (Exception ex)
                {
                    //TODO: Show user friendly error here
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samrtmp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samrtmp-01", ex.Message);
                        }
                    }
                }
            }

        }

        protected void gvResourceTypesDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvResourceTypesDetails.PageSize = Convert.ToInt32(gvResourceTypesDetails.PageCount * gvResourceTypesDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvResourceTypesDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResults();

            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvResourceTypesDetails.PageSize = Convert.ToInt32(gvResourceTypesDetails.PageCount * gvResourceTypesDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvResourceTypesDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResults();

            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvResourceTypesDetails.PageIndex = 0;
            SearchResults();

            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvResourceTypesDetails.PageCount;
            if (gvResourceTypesDetails.PageIndex > 0)
                gvResourceTypesDetails.PageIndex = gvResourceTypesDetails.PageIndex - 1;

            SearchResults();
            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvResourceTypesDetails.PageIndex + 1;
            if (i <= gvResourceTypesDetails.PageCount)
                gvResourceTypesDetails.PageIndex = i;


            SearchResults();
            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvResourceTypesDetails.PageIndex = gvResourceTypesDetails.PageCount;

            SearchResults();
            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvResourceTypesDetails.PageIndex = 0;
            SearchResults();

            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvResourceTypesDetails.PageCount;
            if (gvResourceTypesDetails.PageIndex > 0)
                gvResourceTypesDetails.PageIndex = gvResourceTypesDetails.PageIndex - 1;

            SearchResults();
            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvResourceTypesDetails.PageIndex + 1;
            if (i <= gvResourceTypesDetails.PageCount)
                gvResourceTypesDetails.PageIndex = i;


            SearchResults();
            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvResourceTypesDetails.PageIndex = gvResourceTypesDetails.PageCount;

            SearchResults();
            txtFooterPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvResourceTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvResourceTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvResourceTypesDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResults();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvResourceTypesDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResults();

            txtHeaderPage.Text = txtFooterPage.Text;
        }
    }
}