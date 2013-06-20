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

namespace ComplicanceFactor.SystemHome.Configuration.InstructorTypes
{
    public partial class samitmp_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Instructor type bread crumbS
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_instructor_types_text") + "</a>";
                    //Bind instructor type status
                    ddlStatus.DataSource = SystemInstructorTypeBLL.GetAllStatus(SessionWrapper.CultureName, "samitmp-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_all_text";
                    SearchResults();
                    //count page of page in search result
                    lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
                    lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();

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
                        Logger.WriteToErrorLog("samitmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samitmp-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnAddNewInstructorType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/InstructorTypes/saanitn-01.aspx");
        }

        protected void gvInstructorTypesDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());             
            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("~/SystemHome/Configuration/InstructorTypes/saeitn-01.aspx?id=" + SecurityCenter.EncryptText(gvInstructorTypesDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Copy"))
            {
                Response.Redirect("~/SystemHome/Configuration/InstructorTypes/saanitn-01.aspx?copy=" + SecurityCenter.EncryptText(gvInstructorTypesDetails.DataKeys[rowIndex].Values[0].ToString()), false);
            }
            else if (e.CommandName.Equals("Archive"))
            {
                string instructorId = gvInstructorTypesDetails.DataKeys[rowIndex][0].ToString();
                try
                {
                    SystemInstructorType instructor = new SystemInstructorType();
                    instructor.s_instructor_type_system_id_pk = instructorId;
                    int result = SystemInstructorTypeBLL.UpdateInstructorStatus(instructor);
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
                            Logger.WriteToErrorLog("samitmp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samitmp-01", ex.Message);
                        }
                    }
                }
            }

        }

        protected void gvInstructorTypesDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvInstructorTypesDetails.PageSize = Convert.ToInt32(gvInstructorTypesDetails.PageCount * gvInstructorTypesDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvInstructorTypesDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResults();

            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvInstructorTypesDetails.PageSize = Convert.ToInt32(gvInstructorTypesDetails.PageCount * gvInstructorTypesDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvInstructorTypesDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResults();

            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

         

        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = 0;
            SearchResults();

            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = 0;
            SearchResults();

            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = 0;
            SearchResults();

            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvInstructorTypesDetails.PageCount;
            if (gvInstructorTypesDetails.PageIndex > 0)
                gvInstructorTypesDetails.PageIndex = gvInstructorTypesDetails.PageIndex - 1;

            SearchResults();
            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvInstructorTypesDetails.PageCount;
            if (gvInstructorTypesDetails.PageIndex > 0)
                gvInstructorTypesDetails.PageIndex = gvInstructorTypesDetails.PageIndex - 1;

            SearchResults();
            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvInstructorTypesDetails.PageIndex + 1;
            if (i <= gvInstructorTypesDetails.PageCount)
                gvInstructorTypesDetails.PageIndex = i;


            SearchResults();
            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvInstructorTypesDetails.PageIndex + 1;
            if (i <= gvInstructorTypesDetails.PageCount)
                gvInstructorTypesDetails.PageIndex = i;


            SearchResults();
            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = gvInstructorTypesDetails.PageCount;

            SearchResults();
            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = gvInstructorTypesDetails.PageCount;

            SearchResults();
            txtFooterPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvInstructorTypesDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvInstructorTypesDetails.PageCount).ToString();
        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResults();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResults();

            txtFooterPage.Text = txtHeaderPage.Text;

        }
        /// <summary>
        /// Search Results
        /// </summary>
        private void SearchResults()
        {
            SystemInstructorType instructor = new SystemInstructorType();
            instructor.s_instructor_type_id = txtInstructorId.Text;
            instructor.s_instructor_type_name_us_english = txtName.Text;
            if (ddlStatus.SelectedValue == "app_ddl_all_text")
            {
                instructor.s_instructor_type_status_id_fk = "0";
            }
            else
            {
                instructor.s_instructor_type_status_id_fk = ddlStatus.SelectedValue;
            }
            try
            {
                gvInstructorTypesDetails.DataSource = SystemInstructorTypeBLL.GetInstructorType(instructor);
                gvInstructorTypesDetails.DataBind();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samitmp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samitmp-01", ex.Message);
                    }
                }
            }
            if (gvInstructorTypesDetails.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
            } 

            if (gvInstructorTypesDetails.Rows.Count > 0)
            {
                gvInstructorTypesDetails.UseAccessibleHeader = true;
                if (gvInstructorTypesDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvInstructorTypesDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void gvInstructorTypesDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInstructorTypesDetails.PageIndex = e.NewPageIndex;

            SearchResults();
        }
    }
}