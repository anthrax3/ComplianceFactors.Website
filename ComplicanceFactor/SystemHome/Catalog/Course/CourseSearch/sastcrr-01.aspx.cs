using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Collections;
using System.Text;

namespace ComplicanceFactor.SystemHome.Catalog.Popup
{
    public partial class sastcrr_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc") || (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc"))
                {
                    /// <summary>
                    //Bind column in prerequisite session
                    SessionWrapper.Prerequisite = Prerequisites();
                    SessionWrapper.Equivalencies = Equivalencies();
                    SessionWrapper.Fulfillments = Fulfillments();
                    /// <summary>
                    /// New temp course id 

                    if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                    {
                        ///<summary>
                        //Store Prerequisites in dataset and sessoin(Edit mode)
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editCourseId"]) && !string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
                        {
                            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(Request.QueryString["editCourseId"]);
                            SessionWrapper.PrerequisiteCourseSelected = dsprerequisiteEquivalenciesFullfillments.Tables[0];


                        }

                        ///<summary>
                        //Edit prerequisities
                        ///</summary>
                        if (!string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
                        {

                            SessionWrapper.TempPrerequisiteCourseGuid = Request.QueryString["editprerequisities"].ToString();

                            ///<summary>
                            //Filter Prerequisite using c_related_course_group_id
                            ///</summary>

                            DataTable dtFilterPrerequisite = new DataTable();
                            dtFilterPrerequisite = SessionWrapper.PrerequisiteCourseSelected;
                            DataView dvPrerequisite = new DataView(dtFilterPrerequisite);
                            dvPrerequisite.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'";

                            ///<summary>
                            //copy filter data to SessionWrapper.Prerequisite
                            ///</summary>
                            foreach (DataRowView drView in dvPrerequisite)
                            {
                                AddDataToPrerequisites(drView["c_related_course_id_fk"].ToString(), drView["c_course_text"].ToString(), SessionWrapper.Prerequisite);

                            }


                            ///<summary>
                            //Bind prerequisite
                            ///</summary>
                            dlstCourseSelected.DataSource = SessionWrapper.Prerequisite;
                            dlstCourseSelected.DataBind();
                        }
                        else
                        {
                            SessionWrapper.TempPrerequisiteCourseGuid = Guid.NewGuid().ToString();

                        }
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
                        {
                            ///<summary>
                            //Store Equivalencie in dataset and sessoin(Edit mode)
                            ///</summary>
                            if (!string.IsNullOrEmpty(Request.QueryString["editCourseId"]) && !string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
                            {
                                DataSet dsprerequisiteEquivalenciesFullfillments = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(Request.QueryString["editCourseId"]);

                                SessionWrapper.EquivalenciesCourseSelected = dsprerequisiteEquivalenciesFullfillments.Tables[1];

                            }

                            SessionWrapper.TempEquivalenciesCourseGuid = Request.QueryString["editEquivalencies"].ToString();

                            ///<summary>
                            //Filter Equivalencies using c_related_course_group_id
                            ///</summary>

                            DataTable dtFilterEquivalencies = new DataTable();
                            dtFilterEquivalencies = SessionWrapper.EquivalenciesCourseSelected;
                            DataView dvEquivalencies = new DataView(dtFilterEquivalencies);
                            dvEquivalencies.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'";

                            ///<summary>
                            //copy filter data to SessionWrapper.Equivalencies
                            ///</summary>

                            foreach (DataRowView drView in dvEquivalencies)
                            {
                                AddDataToEquivalencies(drView["c_related_course_id_fk"].ToString(), drView["c_course_text"].ToString(), SessionWrapper.Equivalencies);

                            }

                            ///<summary>
                            //Bind Equivalencies
                            ///</summary>
                            dlstCourseSelected.DataSource = SessionWrapper.Equivalencies;
                            dlstCourseSelected.DataBind();
                        }
                        else
                        {
                            SessionWrapper.TempEquivalenciesCourseGuid = Guid.NewGuid().ToString();

                        }


                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
                        {

                            ///<summary>
                            //Store Fulfillments in dataset and sessoin(Edit mode)
                            ///</summary>
                            if (!string.IsNullOrEmpty(Request.QueryString["editCourseId"]) && !string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
                            {
                                DataSet dsprerequisiteEquivalenciesFullfillments = SystemCatalogBLL.GetprerequisiteEquivalenciesFullfillments(Request.QueryString["editCourseId"]);

                                SessionWrapper.FulfillmentsCourseSelected = dsprerequisiteEquivalenciesFullfillments.Tables[2];

                            }

                            SessionWrapper.TempFulfillmentsCourseGuid = Request.QueryString["editFulfillments"].ToString();
                            ///<summary>
                            //Filter Fulfillments using c_related_course_group_id
                            ///</summary>

                            DataTable dtFilterFulfillments = new DataTable();
                            dtFilterFulfillments = SessionWrapper.FulfillmentsCourseSelected;
                            DataView dvFulfillments = new DataView(dtFilterFulfillments);
                            dvFulfillments.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'";

                            ///<summary>
                            //copy filter data to SessionWrapper.Fulfillments
                            ///</summary>

                            foreach (DataRowView drView in dvFulfillments)
                            {
                                AddDataToFulfillments(drView["c_related_course_id_fk"].ToString(), drView["c_course_text"].ToString(), SessionWrapper.Fulfillments);

                            }

                            ///<summary>
                            //Bind Fulfillments
                            ///</summary>
                            dlstCourseSelected.DataSource = SessionWrapper.Fulfillments;
                            dlstCourseSelected.DataBind();
                        }
                        else
                        {
                            SessionWrapper.TempFulfillmentsCourseGuid = Guid.NewGuid().ToString();

                        }
                    }
                    /// <summary>
                    /// Bind search result
                    SearchResult();

                    /// <summary>
                    //count page of page in search result
                    lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                    lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

                    /// <summary>
                    //using jquery hide the '*and*' in last row

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);

                    /// <summary>
                    /// show and hide couse selected section

                    /// <summary>
                    /// Show and hide course selected section
                    ShowHideCourseSelectedSection();
                }
            }

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            //search

            ViewState["SearchResult"] = "true";
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            ddlFooterResultPerPage.SelectedIndex = 0;
            ddlHeaderResultPerPage.SelectedIndex = 0;
        }
        protected void gvsearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {



        }

        protected void btnHeaderFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnHeaderLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }

        protected void ddlHeaderResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeaderResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlHeaderResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlFooterResultPerPage.SelectedValue = ddlHeaderResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }

        protected void btnHeaderGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtHeaderPage.Text) - 1;

            SearchResult();

            txtFooterPage.Text = txtHeaderPage.Text;
        }

        protected void btnFooterFirst_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = 0;
            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterPrevious_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageCount;
            if (gvsearchDetails.PageIndex > 0)
                gvsearchDetails.PageIndex = gvsearchDetails.PageIndex - 1;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterNext_Click(object sender, EventArgs e)
        {
            int i = gvsearchDetails.PageIndex + 1;
            if (i <= gvsearchDetails.PageCount)
                gvsearchDetails.PageIndex = i;


            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterLast_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = gvsearchDetails.PageCount;

            SearchResult();
            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();

        }

        protected void ddlFooterResultPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFooterResultPerPage.SelectedValue == "Show All")
            {
                gvsearchDetails.PageSize = Convert.ToInt32(gvsearchDetails.PageCount * gvsearchDetails.PageSize);
            }
            else
            {
                int selectedValue;
                selectedValue = Convert.ToInt16(ddlFooterResultPerPage.Text);
                gvsearchDetails.PageSize = selectedValue;
            }

            ddlHeaderResultPerPage.SelectedValue = ddlFooterResultPerPage.SelectedValue;

            SearchResult();

            txtFooterPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            txtHeaderPage.Text = (gvsearchDetails.PageIndex + 1).ToString();
            lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
        }

        protected void btnFooterGoto_Click(object sender, EventArgs e)
        {
            gvsearchDetails.PageIndex = Int32.Parse(txtFooterPage.Text) - 1;

            SearchResult();

            txtHeaderPage.Text = txtFooterPage.Text;
        }

        protected void btnAddNewCourse_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SystemHome/Catalog/saantc-01.aspx");

        }

        private void SearchResult()
        {
            try
            {

                SystemCatalog catalog = new SystemCatalog();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    catalog.c_course_id_pk = txtCourseID.Text;
                    catalog.c_course_title = txtTitle.Text;
                    catalog.c_course_version = "";
                    catalog.c_course_active_type_id_fk = "0";
                    catalog.c_course_owner_name = "";
                    catalog.c_course_coordinator_name = "";

                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["tlt"]) && !string.IsNullOrEmpty(Request.QueryString["tlt"]))
                    {
                        catalog.c_course_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        catalog.c_course_title = SecurityCenter.DecryptText(Request.QueryString["tlt"]);
                    }
                    else
                    {
                        catalog.c_course_id_pk = "";
                        catalog.c_course_title = "";
                    }

                    catalog.c_course_version = "";
                    catalog.c_course_active_type_id_fk = "0";
                    catalog.c_course_owner_name = "";
                    catalog.c_course_coordinator_name = "";

                }

                gvsearchDetails.DataSource = SystemCatalogBLL.SearchSystemCatalog(catalog);
                gvsearchDetails.DataBind();


            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sastcrr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sastcrr-01.aspx", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable();

            }
            else
            {
                enable();
            }
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row
                    //using instead of the simple <tr>
                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }

        // Prerequisites table
        private DataTable Prerequisites()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp course id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated course id
            /// <value>Related course id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate course title and course id
            /// <value>concatenate course title and course column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_course_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Equivalencies table
        private DataTable Equivalencies()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp course id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated course id
            /// <value>Related course id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate course title and course id
            /// <value>concatenate course title and course column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_course_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Fulfillments table
        private DataTable Fulfillments()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp course id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated course id
            /// <value>Related course id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_course_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate course title and course id
            /// <value>concatenate course title and course column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_course_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        private void AddDataToPrerequisites(string c_related_course_id_fk, string c_course_text, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Add prerequisites function

            DataRow row;
            row = dtTempPrerequisites.NewRow();
            row["c_related_course_group_id"] = SessionWrapper.TempPrerequisiteCourseGuid;
            row["c_related_course_id_fk"] = c_related_course_id_fk;
            row["c_course_text"] = c_course_text;
            dtTempPrerequisites.Rows.Add(row);
        }
        private void AddDataToEquivalencies(string c_related_course_id_fk, string c_course_text, DataTable dtTempEquivalencies)
        {
            /// <summary>
            /// Add Equivalencies function

            DataRow row;
            row = dtTempEquivalencies.NewRow();
            row["c_related_course_group_id"] = SessionWrapper.TempEquivalenciesCourseGuid;
            row["c_related_course_id_fk"] = c_related_course_id_fk;
            row["c_course_text"] = c_course_text;
            dtTempEquivalencies.Rows.Add(row);
        }
        private void AddDataToFulfillments(string c_related_course_id_fk, string c_course_text, DataTable dtTempFulfillments)
        {
            /// <summary>
            /// Add Equivalencies function

            DataRow row;
            row = dtTempFulfillments.NewRow();
            row["c_related_course_group_id"] = SessionWrapper.TempFulfillmentsCourseGuid;
            row["c_related_course_id_fk"] = c_related_course_id_fk;
            row["c_course_text"] = c_course_text;
            dtTempFulfillments.Rows.Add(row);
        }

        private void DeleteDataToPrerequisites(int rowIndex, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Delete prerequisites function

            dtTempPrerequisites.Rows[rowIndex].Delete();
            dtTempPrerequisites.AcceptChanges();

            /// <summary>
            //Bind selected course in Course(s) selected section popup

            dlstCourseSelected.DataSource = SessionWrapper.Prerequisite.DefaultView;
            dlstCourseSelected.DataBind();
            /// <summary>
            /// Show and hide course selected section
            ShowHideCourseSelectedSection();

            /// <summary>
            //using jquery hide the '*and*' in last row

            Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);

        }
        private void DeleteDataToEquivalencies(int rowIndex, DataTable dtTempEquivalencies)
        {
            /// <summary>
            /// Delete Equivalencies function

            dtTempEquivalencies.Rows[rowIndex].Delete();
            dtTempEquivalencies.AcceptChanges();

            /// <summary>
            //Bind selected course in Course(s) selected section popup

            dlstCourseSelected.DataSource = SessionWrapper.Equivalencies.DefaultView;
            dlstCourseSelected.DataBind();
            /// <summary>
            /// Show and hide course selected section
            ShowHideCourseSelectedSection();

            /// <summary>
            //using jquery hide the '*and*' in last row

            Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);
        }
        private void DeleteDataToFulfillments(int rowIndex, DataTable dtTempFulfillments)
        {
            /// <summary>
            /// Delete Equivalencies function

            dtTempFulfillments.Rows[rowIndex].Delete();
            dtTempFulfillments.AcceptChanges();

            /// <summary>
            //Bind selected course in Course(s) selected section popup

            dlstCourseSelected.DataSource = SessionWrapper.Fulfillments.DefaultView;
            dlstCourseSelected.DataBind();

            /// <summary>
            /// Show and hide course selected section
            ShowHideCourseSelectedSection();

            /// <summary>
            //using jquery hide the '*and*' in last row

            Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);
        }

        protected void btnAddSelected_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
            {
                /// <summary>
                //Add new related course
                foreach (GridViewRow grdPrerequisitesRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdPrerequisitesRow.Cells[2].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {

                        AddDataToPrerequisites(gvsearchDetails.DataKeys[grdPrerequisitesRow.RowIndex].Values[2].ToString(), grdPrerequisitesRow.Cells[1].Text + " (" + grdPrerequisitesRow.Cells[0].Text + ") ", SessionWrapper.Prerequisite);
                        //AddDataToPrerequisites(gvsearchDetails.DataKeys[grdPrerequisitesRow.RowIndex].Values[0].ToString(), grdPrerequisitesRow.Cells[1].Text + " (" + gvsearchDetails.DataKeys[grdPrerequisitesRow.RowIndex].Values[1].ToString() + ") ", SessionWrapper.PrerequisiteCourseSelected);

                    }
                }

                /// <summary>
                //Remove duplicate course
                SessionWrapper.Prerequisite = RemoveDuplicateRows(SessionWrapper.Prerequisite, "c_related_course_id_fk");

                /// <summary>
                //Bind selected course in Course(s) selected section popup
                dlstCourseSelected.DataSource = SessionWrapper.Prerequisite.DefaultView;
                dlstCourseSelected.DataBind();

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
            {
                /// <summary>
                //Add new related course
                foreach (GridViewRow grdEquivalenciesRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdEquivalenciesRow.Cells[2].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {

                        AddDataToEquivalencies(gvsearchDetails.DataKeys[grdEquivalenciesRow.RowIndex].Values[2].ToString(), grdEquivalenciesRow.Cells[1].Text + " (" + grdEquivalenciesRow.Cells[0].Text + ") ", SessionWrapper.Equivalencies);


                    }
                }

                /// <summary>
                //Remove duplicate course
                SessionWrapper.Equivalencies = RemoveDuplicateRows(SessionWrapper.Equivalencies, "c_related_course_id_fk");

                /// <summary>
                //Bind selected course in Course(s) selected section popup
                dlstCourseSelected.DataSource = SessionWrapper.Equivalencies.DefaultView;
                dlstCourseSelected.DataBind();



            }
            else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
            {
                /// <summary>
                //Add new related course
                foreach (GridViewRow grdFulfillmentssRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdFulfillmentssRow.Cells[2].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {

                        AddDataToFulfillments(gvsearchDetails.DataKeys[grdFulfillmentssRow.RowIndex].Values[2].ToString(), grdFulfillmentssRow.Cells[1].Text + " (" + grdFulfillmentssRow.Cells[0].Text + ") ", SessionWrapper.Fulfillments);


                    }
                }

                /// <summary>
                //Remove duplicate course
                SessionWrapper.Fulfillments = RemoveDuplicateRows(SessionWrapper.Fulfillments, "c_related_course_id_fk");

                /// <summary>
                //Bind selected course in Course(s) selected section popup
                dlstCourseSelected.DataSource = SessionWrapper.Fulfillments.DefaultView;
                dlstCourseSelected.DataBind();
            }

            /// <summary>
            //using jquery hide the '*and*' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);

            /// <summary>
            /// show and hide couse selected section

            ShowHideCourseSelectedSection();

            /// <summary>
            //This will tell ASP.NET to render the <thead> for the header row
            //using instead of the simple <tr>
            if (gvsearchDetails.Rows.Count > 0)
            {
                gvsearchDetails.UseAccessibleHeader = true;
                if (gvsearchDetails.HeaderRow != null)
                {

                    gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }



        protected void dlstCourseSelected_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("Remove"))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                {
                    DeleteDataToPrerequisites(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.Prerequisite);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                {
                    DeleteDataToEquivalencies(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.Equivalencies);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                {
                    DeleteDataToFulfillments(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.Fulfillments);
                }
                /// <summary>
                //This will tell ASP.NET to render the <thead> for the header row
                //using instead of the simple <tr>
                if (gvsearchDetails.Rows.Count > 0)
                {
                    gvsearchDetails.UseAccessibleHeader = true;
                    if (gvsearchDetails.HeaderRow != null)
                    {

                        gvsearchDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }

            }

        }

        /// <summary>
        //Remove duplicate course function

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }
        private void AddDataToTempPrerequisites(string c_course_text, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Add temp prerequisites function
            if (c_course_text != "")
            {
                DataRow row;
                row = dtTempPrerequisites.NewRow();
                row["c_related_course_group_id"] = SessionWrapper.TempPrerequisiteCourseGuid;
                row["c_course_text"] = c_course_text;
                dtTempPrerequisites.Rows.Add(row);
            }
        }
        private void AddDataToTempEquivalencies(string c_course_text, DataTable dtTempEquivalencies)
        {
            /// <summary>
            /// Add temp Equivalencies function
            if (c_course_text != "")
            {
                DataRow row;
                row = dtTempEquivalencies.NewRow();
                row["c_related_course_group_id"] = SessionWrapper.TempEquivalenciesCourseGuid;
                row["c_course_text"] = c_course_text;
                dtTempEquivalencies.Rows.Add(row);
            }
        }
        private void AddDataToTempFulfillments(string c_course_text, DataTable dtTempFulfillments)
        {
            /// <summary>
            /// Add temp dtTempFulfillments function
            if (c_course_text != "")
            {
                DataRow row;
                row = dtTempFulfillments.NewRow();
                row["c_related_course_group_id"] = SessionWrapper.TempFulfillmentsCourseGuid;
                row["c_course_text"] = c_course_text;
                dtTempFulfillments.Rows.Add(row);
            }
        }
        //protected void btnSaveandExit_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
        //    {
        //        SystemCatalog course = new SystemCatalog();
        //        if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
        //        {





        //            course.c_course_system_id_pk = Request.QueryString["editCourseId"];
        //            course.c_course_Prerequistist = ConvertDataTableToXml(SessionWrapper.Prerequisite);

        //            /// <summary>
        //            //Check c_related_course_group_id if exist or not
        //            ///</summary>

        //            if (!string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
        //            {
        //                course.c_related_course_group_id = Request.QueryString["editprerequisities"];
        //            }
        //            else
        //            {
        //                course.c_related_course_group_id = SessionWrapper.TempPrerequisiteCourseGuid;
        //            }

        //            /// <summary>
        //            //update SessionWrapper.Prerequisite value into the database
        //            ///</summary>
        //            SystemCatalogBLL.UpdateSystemCatalogPrerequistist(course);


        //            ///</summary>

        //            /// <summary>
        //            //Clear session
        //            SessionWrapper.Prerequisite = null;
        //        }
        //        else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
        //        {




        //            course.c_course_system_id_pk = Request.QueryString["editCourseId"];
        //            course.c_course_Equivalencies = ConvertDataTableToXml(SessionWrapper.Equivalencies);

        //            /// <summary>
        //            //Check c_related_course_group_id if exist or not
        //            ///</summary>

        //            if (!string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
        //            {
        //                course.c_related_course_group_id = Request.QueryString["editEquivalencies"];
        //            }
        //            else
        //            {
        //                course.c_related_course_group_id = SessionWrapper.TempEquivalenciesCourseGuid;
        //            }

        //            /// <summary>
        //            //update SessionWrapper.Equivalencies value into the database
        //            ///</summary>

        //            SystemCatalogBLL.UpdateSystemCatalogEquivalencies(course);
        //            ///</summary>

        //            /// <summary>
        //            //Clear session
        //            SessionWrapper.Equivalencies = null;
        //        }
        //        else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
        //        {



        //            course.c_course_system_id_pk = Request.QueryString["editCourseId"];
        //            course.c_course_Fulfillments = ConvertDataTableToXml(SessionWrapper.Fulfillments);


        //            /// <summary>
        //            //Check c_related_course_group_id if exist or not
        //            ///</summary>

        //            if (!string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
        //            {
        //                course.c_related_course_group_id = Request.QueryString["editFulfillments"];
        //            }
        //            else
        //            {
        //                course.c_related_course_group_id = SessionWrapper.TempFulfillmentsCourseGuid;
        //            }

        //            /// <summary>
        //            //update SessionWrapper.Fulfillments value into the  database
        //            ///</summary>
        //            ///

        //            SystemCatalogBLL.UpdateSystemCatalogFulfillments(course);
        //            ///</summary>


        //            /// <summary>
        //            //Clear session
        //            SessionWrapper.Fulfillments = null;


        //        }

        //    }
        //    else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
        //    {

        //        if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
        //        {
        //            //Delete previous selected course
        //            var rows = SessionWrapper.PrerequisiteCourseSelected.Select("c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'");
        //            foreach (var row in rows)
        //                row.Delete();

        //            SessionWrapper.PrerequisiteCourseSelected.AcceptChanges();

        //            //Merger current and previous course selected
        //            SessionWrapper.PrerequisiteCourseSelected.Merge(SessionWrapper.Prerequisite);


        //            /// <summary>
        //            //Remove duplicate course
        //            SessionWrapper.PrerequisiteCourseSelected = RemoveDuplicateRows(SessionWrapper.PrerequisiteCourseSelected, "c_related_course_id_fk");
        //            ///

        //            /// <summary>
        //            //Filter course
        //            DataTable dtConcatenatePrerequisites = new DataTable();
        //            dtConcatenatePrerequisites = SessionWrapper.PrerequisiteCourseSelected;
        //            DataView dvPrerequisite = new DataView(dtConcatenatePrerequisites);
        //            dvPrerequisite.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'";
        //            StringBuilder sbPrerequisites = new StringBuilder();

        //            foreach (DataRowView drView in dvPrerequisite)
        //            {
        //                sbPrerequisites.Append(drView["c_course_text"].ToString() + " *and* ");
        //            }

        //            /// <summary>
        //            //Add column to Tempprerequisite if no rows already added
        //            if (SessionWrapper.TempPrerequisite.Rows.Count == 0)
        //            {
        //                SessionWrapper.TempPrerequisite = Prerequisites();
        //            }

        //            /// <summary>
        //            //Delete temp previous selected course
        //            var tempPreq = SessionWrapper.TempPrerequisite.Select("c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'");
        //            foreach (var row in tempPreq)
        //                row.Delete();
        //            SessionWrapper.TempPrerequisite.AcceptChanges();

        //            /// <summary>
        //            //Remove last " *and* "
        //            string strPrerequisites = sbPrerequisites.ToString();
        //            strPrerequisites = strPrerequisites.Substring(0, strPrerequisites.Length - 6);
        //            /// <summary>
        //            //Add data to temp prerequisite
        //            AddDataToTempPrerequisites(strPrerequisites, SessionWrapper.TempPrerequisite);
        //            SessionWrapper.Prerequisite = null;
        //        }
        //        else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
        //        {
        //            //Delete previous selected course
        //            var rows = SessionWrapper.EquivalenciesCourseSelected.Select("c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'");
        //            foreach (var row in rows)
        //                row.Delete();

        //            SessionWrapper.EquivalenciesCourseSelected.AcceptChanges();


        //            //Merger current and previous course selected
        //            SessionWrapper.EquivalenciesCourseSelected.Merge(SessionWrapper.Equivalencies);


        //            /// <summary>
        //            //Remove duplicate course
        //            SessionWrapper.EquivalenciesCourseSelected = RemoveDuplicateRows(SessionWrapper.EquivalenciesCourseSelected, "c_related_course_id_fk");
        //            ///

        //            /// <summary>
        //            //Filter course
        //            DataTable dtConcatenateEquivalenciess = new DataTable();

        //            /// <summary>
        //            //dtConcatenateEquivalenciess = SessionWrapper.Equivalencies;
        //            dtConcatenateEquivalenciess = SessionWrapper.EquivalenciesCourseSelected;
        //            DataView dvEquivalencies = new DataView(dtConcatenateEquivalenciess);
        //            dvEquivalencies.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'";
        //            StringBuilder sbEquivalenciess = new StringBuilder();

        //            foreach (DataRowView drView in dvEquivalencies)
        //            {
        //                sbEquivalenciess.Append(drView["c_course_text"].ToString() + " *and* ");
        //            }

        //            /// <summary>
        //            //Add column to TempEquivalencies if no rows already added
        //            if (SessionWrapper.TempEquivalencies.Rows.Count == 0)
        //            {
        //                SessionWrapper.TempEquivalencies = Equivalencies();
        //            }

        //            /// <summary>
        //            //Delete temp previous selected course
        //            var tempPreq = SessionWrapper.TempEquivalencies.Select("c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'");
        //            foreach (var row in tempPreq)
        //                row.Delete();
        //            SessionWrapper.TempEquivalencies.AcceptChanges();
        //            /// <summary>
        //            //Remove last " *and* "
        //            string strEquivalencies = sbEquivalenciess.ToString();
        //            strEquivalencies = strEquivalencies.Substring(0, strEquivalencies.Length - 6);
        //            /// <summary>
        //            //Add data to temp Equivalencies
        //            AddDataToTempEquivalencies(strEquivalencies, SessionWrapper.TempEquivalencies);
        //            SessionWrapper.Equivalencies = null;
        //        }
        //        else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
        //        {
        //            //Delete previous selected course
        //            var rows = SessionWrapper.FulfillmentsCourseSelected.Select("c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'");
        //            foreach (var row in rows)
        //                row.Delete();

        //            SessionWrapper.FulfillmentsCourseSelected.AcceptChanges();


        //            //Merger current and previous course selected
        //            SessionWrapper.FulfillmentsCourseSelected.Merge(SessionWrapper.Fulfillments);


        //            /// <summary>
        //            //Remove duplicate course
        //            SessionWrapper.FulfillmentsCourseSelected = RemoveDuplicateRows(SessionWrapper.FulfillmentsCourseSelected, "c_related_course_id_fk");
        //            ///

        //            /// <summary>
        //            //Filter course
        //            DataTable dtConcatenateFulfillmentss = new DataTable();

        //            /// <summary>
        //            //dtConcatenateFulfillmentss = SessionWrapper.Fulfillments;
        //            dtConcatenateFulfillmentss = SessionWrapper.FulfillmentsCourseSelected;
        //            DataView dvFulfillments = new DataView(dtConcatenateFulfillmentss);
        //            dvFulfillments.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'";
        //            StringBuilder sbFulfillmentss = new StringBuilder();

        //            foreach (DataRowView drView in dvFulfillments)
        //            {

        //                sbFulfillmentss.Append(drView["c_course_text"].ToString() + " *and* ");
        //            }

        //            /// <summary>
        //            //Add column to TempFulfillments if no rows already added
        //            if (SessionWrapper.TempFulfillments.Rows.Count == 0)
        //            {
        //                SessionWrapper.TempFulfillments = Fulfillments();
        //            }

        //            /// <summary>
        //            //Delete temp previous selected course
        //            var tempPreq = SessionWrapper.TempFulfillments.Select("c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'");
        //            foreach (var row in tempPreq)
        //                row.Delete();
        //            SessionWrapper.TempFulfillments.AcceptChanges();

        //            //Remove last " *and* "
        //            string strFulfillments = sbFulfillmentss.ToString();
        //            strFulfillments = strFulfillments.Substring(0, strFulfillments.Length - 6);

        //            /// <summary>
        //            //Add data to temp Fulfillments

        //            AddDataToTempFulfillments(strFulfillments, SessionWrapper.TempFulfillments);
        //            SessionWrapper.Fulfillments = null;
        //        }
        //    }

        //    /// <summary>
        //    //Close popup
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        //}
        protected void btnSaveandExit_Click(object sender, EventArgs e)
        {
           
            //using jquery hide the '*and*' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);

            try
            {
                ///<summary>
                ///Edit selected course
                ///</summary>
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saetc")
                {
                    SystemCatalog course = new SystemCatalog();
                    if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                    {





                        course.c_course_system_id_pk = Request.QueryString["editCourseId"];
                        course.c_course_Prerequistist = ConvertDataTableToXml(SessionWrapper.Prerequisite);

                        /// <summary>
                        //Check c_related_course_group_id if exist or not
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
                        {
                            course.c_related_course_group_id = Request.QueryString["editprerequisities"];
                        }
                        else
                        {
                            course.c_related_course_group_id = SessionWrapper.TempPrerequisiteCourseGuid;
                        }

                        /// <summary>
                        //update SessionWrapper.Prerequisite value into the database
                        ///</summary>
                        SystemCatalogBLL.UpdateSystemCatalogPrerequistist(course);


                        ///</summary>

                        /// <summary>
                        //Clear session
                        SessionWrapper.Prerequisite = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                    {




                        course.c_course_system_id_pk = Request.QueryString["editCourseId"];
                        course.c_course_Equivalencies = ConvertDataTableToXml(SessionWrapper.Equivalencies);

                        /// <summary>
                        //Check c_related_course_group_id if exist or not
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
                        {
                            course.c_related_course_group_id = Request.QueryString["editEquivalencies"];
                        }
                        else
                        {
                            course.c_related_course_group_id = SessionWrapper.TempEquivalenciesCourseGuid;
                        }

                        /// <summary>
                        //update SessionWrapper.Equivalencies value into the database
                        ///</summary>

                        SystemCatalogBLL.UpdateSystemCatalogEquivalencies(course);
                        ///</summary>

                        /// <summary>
                        //Clear session
                        SessionWrapper.Equivalencies = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                    {



                        course.c_course_system_id_pk = Request.QueryString["editCourseId"];
                        course.c_course_Fulfillments = ConvertDataTableToXml(SessionWrapper.Fulfillments);


                        /// <summary>
                        //Check c_related_course_group_id if exist or not
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
                        {
                            course.c_related_course_group_id = Request.QueryString["editFulfillments"];
                        }
                        else
                        {
                            course.c_related_course_group_id = SessionWrapper.TempFulfillmentsCourseGuid;
                        }

                        /// <summary>
                        //update SessionWrapper.Fulfillments value into the  database
                        ///</summary>
                        ///

                        SystemCatalogBLL.UpdateSystemCatalogFulfillments(course);
                        ///</summary>


                        /// <summary>
                        //Clear session
                        SessionWrapper.Fulfillments = null;


                    }

                }
                ///<summary>
                ///Add selected course
                ///</summary>
                else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saantc")
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                    {
                        //Delete previous selected course
                        var rows = SessionWrapper.PrerequisiteCourseSelected.Select("c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'");
                        foreach (var row in rows)
                            row.Delete();

                        SessionWrapper.PrerequisiteCourseSelected.AcceptChanges();

                        //Merger current and previous course selected

                        SessionWrapper.PrerequisiteCourseSelected.Merge(SessionWrapper.Prerequisite, true, MissingSchemaAction.Ignore);



                        /// <summary>
                        //Remove duplicate course
                        ///SessionWrapper.PrerequisiteCourseSelected = RemoveDuplicateRows(SessionWrapper.PrerequisiteCourseSelected, "c_related_course_id_fk");
                        ///

                        /// <summary>
                        //Filter course
                        DataTable dtConcatenatePrerequisites = new DataTable();
                        dtConcatenatePrerequisites = SessionWrapper.PrerequisiteCourseSelected;
                        DataView dvPrerequisite = new DataView(dtConcatenatePrerequisites);
                        dvPrerequisite.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'";
                        StringBuilder sbPrerequisites = new StringBuilder();

                        foreach (DataRowView drView in dvPrerequisite)
                        {
                            sbPrerequisites.Append(drView["c_course_text"].ToString() + " *and* ");
                        }

                        /// <summary>
                        //Add column to Tempprerequisite if no rows already added
                        if (SessionWrapper.TempPrerequisite.Rows.Count == 0)
                        {
                            SessionWrapper.TempPrerequisite = Prerequisites();
                        }

                        /// <summary>
                        //Delete temp previous selected course
                        var tempPreq = SessionWrapper.TempPrerequisite.Select("c_related_course_group_id= '" + SessionWrapper.TempPrerequisiteCourseGuid + "'");
                        foreach (var row in tempPreq)
                            row.Delete();
                        SessionWrapper.TempPrerequisite.AcceptChanges();

                        /// <summary>
                        //Remove last " *and* "
                        string strPrerequisites = sbPrerequisites.ToString();
                        if (!string.IsNullOrEmpty(strPrerequisites))
                        {
                            strPrerequisites = strPrerequisites.Substring(0, strPrerequisites.Length - 6);
                        }
                        /// <summary>
                        //Add data to temp prerequisite
                        AddDataToTempPrerequisites(strPrerequisites, SessionWrapper.TempPrerequisite);
                        SessionWrapper.Prerequisite = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                    {
                        //Delete previous selected course
                        var rows = SessionWrapper.EquivalenciesCourseSelected.Select("c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'");
                        foreach (var row in rows)
                            row.Delete();

                        SessionWrapper.EquivalenciesCourseSelected.AcceptChanges();


                        //Merger current and previous course selected
                        SessionWrapper.EquivalenciesCourseSelected.Merge(SessionWrapper.Equivalencies, true, MissingSchemaAction.Ignore);


                        /// <summary>
                        //Remove duplicate course
                        ///SessionWrapper.EquivalenciesCourseSelected = RemoveDuplicateRows(SessionWrapper.EquivalenciesCourseSelected, "c_related_course_id_fk");
                        ///

                        /// <summary>
                        //Filter course
                        DataTable dtConcatenateEquivalenciess = new DataTable();

                        /// <summary>
                        //dtConcatenateEquivalenciess = SessionWrapper.Equivalencies;
                        dtConcatenateEquivalenciess = SessionWrapper.EquivalenciesCourseSelected;
                        DataView dvEquivalencies = new DataView(dtConcatenateEquivalenciess);
                        dvEquivalencies.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'";
                        StringBuilder sbEquivalenciess = new StringBuilder();

                        foreach (DataRowView drView in dvEquivalencies)
                        {
                            sbEquivalenciess.Append(drView["c_course_text"].ToString() + " *and* ");
                        }

                        /// <summary>
                        //Add column to TempEquivalencies if no rows already added
                        if (SessionWrapper.TempEquivalencies.Rows.Count == 0)
                        {
                            SessionWrapper.TempEquivalencies = Equivalencies();
                        }

                        /// <summary>
                        //Delete temp previous selected course
                        var tempPreq = SessionWrapper.TempEquivalencies.Select("c_related_course_group_id= '" + SessionWrapper.TempEquivalenciesCourseGuid + "'");
                        foreach (var row in tempPreq)
                            row.Delete();
                        SessionWrapper.TempEquivalencies.AcceptChanges();
                        /// <summary>
                        //Remove last " *and* "
                        string strEquivalencies = sbEquivalenciess.ToString();
                        if (!string.IsNullOrEmpty(strEquivalencies))
                        {
                            strEquivalencies = strEquivalencies.Substring(0, strEquivalencies.Length - 6);
                        }
                        /// <summary>
                        //Add data to temp Equivalencies
                        AddDataToTempEquivalencies(strEquivalencies, SessionWrapper.TempEquivalencies);
                        SessionWrapper.Equivalencies = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                    {
                        //Delete previous selected course
                        var rows = SessionWrapper.FulfillmentsCourseSelected.Select("c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'");
                        foreach (var row in rows)
                            row.Delete();

                        SessionWrapper.FulfillmentsCourseSelected.AcceptChanges();


                        //Merger current and previous course selected
                        SessionWrapper.FulfillmentsCourseSelected.Merge(SessionWrapper.Fulfillments, true, MissingSchemaAction.Ignore);


                        /// <summary>
                        //Remove duplicate course
                       /// SessionWrapper.FulfillmentsCourseSelected = RemoveDuplicateRows(SessionWrapper.FulfillmentsCourseSelected, "c_related_course_id_fk");
                        ///

                        /// <summary>
                        //Filter course
                        DataTable dtConcatenateFulfillmentss = new DataTable();

                        /// <summary>
                        //dtConcatenateFulfillmentss = SessionWrapper.Fulfillments;
                        dtConcatenateFulfillmentss = SessionWrapper.FulfillmentsCourseSelected;
                        DataView dvFulfillments = new DataView(dtConcatenateFulfillmentss);
                        dvFulfillments.RowFilter = "c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'";
                        StringBuilder sbFulfillmentss = new StringBuilder();

                        foreach (DataRowView drView in dvFulfillments)
                        {

                            sbFulfillmentss.Append(drView["c_course_text"].ToString() + " *and* ");
                        }

                        /// <summary>
                        //Add column to TempFulfillments if no rows already added
                        if (SessionWrapper.TempFulfillments.Rows.Count == 0)
                        {
                            SessionWrapper.TempFulfillments = Fulfillments();
                        }

                        /// <summary>
                        //Delete temp previous selected course
                        var tempPreq = SessionWrapper.TempFulfillments.Select("c_related_course_group_id= '" + SessionWrapper.TempFulfillmentsCourseGuid + "'");
                        foreach (var row in tempPreq)
                            row.Delete();
                        SessionWrapper.TempFulfillments.AcceptChanges();

                        //Remove last " *and* "
                        string strFulfillments = sbFulfillmentss.ToString();
                        if (!string.IsNullOrEmpty(strFulfillments))
                        {
                            strFulfillments = strFulfillments.Substring(0, strFulfillments.Length - 6);
                        }

                        /// <summary>
                        //Add data to temp Fulfillments

                        AddDataToTempFulfillments(strFulfillments, SessionWrapper.TempFulfillments);
                        SessionWrapper.Fulfillments = null;
                    }
                }

                /// <summary>
                //Close popup
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sastcrr-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sastcrr-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// convert Data table to XML to insert prerequisite,equivalence and fulfillments
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {


            DataSet dsBuildSql = new DataSet("DataSet");
            if (dsBuildSql.Tables.Equals("Table"))
            {
                dsBuildSql.Tables.Remove("Table");
            }

            dsBuildSql.Tables.Add(dtBuildSql);
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();

        }
        private void ShowHideCourseSelectedSection()
        {
            /// <summary>
            /// show and hide couse selected section

            if (dlstCourseSelected.Items.Count > 0)
            {
                courseselected.Style.Add("display", "block");
            }
            else
            {
                courseselected.Style.Add("display", "none");
            }
        }
    }
}