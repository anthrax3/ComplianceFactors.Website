using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Collections;
using System.Text;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum
{
    public partial class p_sacsr_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc") || (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec"))
                {
                    /// <summary>
                    //Bind column in prerequisite session
                    SessionWrapper.Curriculum_Prerequisite = Prerequisites();
                    SessionWrapper.Curriculum_Equivalencies = Equivalencies();
                    SessionWrapper.Curriculum_Fulfillments = Fulfillments();
                    /// <summary>
                    /// New temp curriculum id 

                    if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                    {
                        ///<summary>
                        //Store Prerequisites in dataset and sessoin(Edit mode)
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]) && !string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
                        {
                            DataSet dsprerequisiteEquivalenciesFullfillments = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(Request.QueryString["editCurriculumId"]);
                            SessionWrapper.PrerequisiteCurriculumSelected = dsprerequisiteEquivalenciesFullfillments.Tables[0];


                        }

                        ///<summary>
                        //Edit prerequisities
                        ///</summary>
                        if (!string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
                        {

                            SessionWrapper.TempPrerequisitteCurriculumGuid = Request.QueryString["editprerequisities"].ToString();

                            ///<summary>
                            //Filter Prerequisite using c_related_curriculum_group_id
                            ///</summary>

                            DataTable dtFilterPrerequisite = new DataTable();
                            dtFilterPrerequisite = SessionWrapper.PrerequisiteCurriculumSelected;
                            DataView dvPrerequisite = new DataView(dtFilterPrerequisite);
                            dvPrerequisite.RowFilter = "c_related_curriculum_group_id= '" + SessionWrapper.TempPrerequisitteCurriculumGuid + "'";

                            ///<summary>
                            //copy filter data to SessionWrapper.Prerequisite
                            ///</summary>
                            foreach (DataRowView drView in dvPrerequisite)
                            {
                                AddDataToPrerequisites(drView["c_related_curriculum_id_fk"].ToString(), drView["c_curriculum_text"].ToString(), SessionWrapper.Curriculum_Prerequisite);

                            }


                            ///<summary>
                            //Bind prerequisite
                            ///</summary>
                            dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Prerequisite;
                            dlstCurriculumSelected.DataBind();
                        }
                        else
                        {
                            SessionWrapper.TempPrerequisitteCurriculumGuid = Guid.NewGuid().ToString();

                        }
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
                        {
                            ///<summary>
                            //Store Equivalencie in dataset and sessoin(Edit mode)
                            ///</summary>
                            if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]) && !string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
                            {
                                DataSet dsprerequisiteEquivalenciesFullfillments = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(Request.QueryString["editCurriculumId"]);

                                SessionWrapper.EquivalenciesCurriculumSelected = dsprerequisiteEquivalenciesFullfillments.Tables[1];

                            }

                            SessionWrapper.TempEquivalenciesCurriculumGuid = Request.QueryString["editEquivalencies"].ToString();

                            ///<summary>
                            //Filter Equivalencies using c_related_curriculum_group_id
                            ///</summary>

                            DataTable dtFilterEquivalencies = new DataTable();
                            dtFilterEquivalencies = SessionWrapper.EquivalenciesCurriculumSelected;
                            DataView dvEquivalencies = new DataView(dtFilterEquivalencies);
                            dvEquivalencies.RowFilter = "c_related_curriculum_group_id= '" + SessionWrapper.TempEquivalenciesCurriculumGuid + "'";

                            ///<summary>
                            //copy filter data to SessionWrapper.Equivalencies
                            ///</summary>

                            foreach (DataRowView drView in dvEquivalencies)
                            {
                                AddDataToEquivalencies(drView["c_related_curriculum_id_fk"].ToString(), drView["c_curriculum_text"].ToString(), SessionWrapper.Curriculum_Equivalencies);

                            }

                            ///<summary>
                            //Bind Equivalencies
                            ///</summary>
                            dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Equivalencies;
                            dlstCurriculumSelected.DataBind();
                        }
                        else
                        {
                            SessionWrapper.TempEquivalenciesCurriculumGuid = Guid.NewGuid().ToString();

                        }


                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
                        {

                            ///<summary>
                            //Store Fulfillments in dataset and sessoin(Edit mode)
                            ///</summary>
                            if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]) && !string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
                            {
                                DataSet dsprerequisiteEquivalenciesFullfillments = SystemCurriculumBLL.GetprerequisiteEquivalenciesFullfillments(Request.QueryString["editCurriculumId"]);

                                SessionWrapper.FulfillmentsCurriculumSelected = dsprerequisiteEquivalenciesFullfillments.Tables[2];

                            }

                            SessionWrapper.TempFulfillmentsCurriculumGuid = Request.QueryString["editFulfillments"].ToString();
                            ///<summary>
                            //Filter Fulfillments using c_related_curriculum_group_id
                            ///</summary>

                            DataTable dtFilterFulfillments = new DataTable();
                            dtFilterFulfillments = SessionWrapper.FulfillmentsCurriculumSelected;
                            DataView dvFulfillments = new DataView(dtFilterFulfillments);
                            dvFulfillments.RowFilter = "c_related_curriculum_group_id= '" + SessionWrapper.TempFulfillmentsCurriculumGuid + "'";

                            ///<summary>
                            //copy filter data to SessionWrapper.Fulfillments
                            ///</summary>

                            foreach (DataRowView drView in dvFulfillments)
                            {
                                AddDataToFulfillments(drView["c_related_curriculum_id_fk"].ToString(), drView["c_curriculum_text"].ToString(), SessionWrapper.Curriculum_Fulfillments);

                            }

                            ///<summary>
                            //Bind Fulfillments
                            ///</summary>
                            dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Fulfillments;
                            dlstCurriculumSelected.DataBind();
                        }
                        else
                        {
                            SessionWrapper.TempFulfillmentsCurriculumGuid = Guid.NewGuid().ToString();

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
                    /// Show and hide curriculum selected section
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

            Response.Redirect("~/SystemHome/Catalog/Curriculum/saanc-01.aspx");

        }

        private void SearchResult()
        {
            try
            {
                SystemCurriculum curriculum = new SystemCurriculum();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    curriculum.c_curriculum_id_pk = txtCurriculumId.Text;
                    curriculum.c_curriculum_title = txtTitle.Text;
                    curriculum.c_curriculum_version = "";
                    curriculum.c_curriculum_active_type_id_fk = "0";
                    curriculum.c_curriculum_owner_name = "";
                    curriculum.c_curriculum_coordinator_name = "";

                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["tlt"]) && !string.IsNullOrEmpty(Request.QueryString["tlt"]))
                    {
                        curriculum.c_curriculum_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                        curriculum.c_curriculum_title = SecurityCenter.DecryptText(Request.QueryString["tlt"]);
                    }
                    else
                    {
                        curriculum.c_curriculum_id_pk = "";
                        curriculum.c_curriculum_title = "";
                    }

                    curriculum.c_curriculum_version = "";
                    curriculum.c_curriculum_active_type_id_fk = "0";
                    curriculum.c_curriculum_owner_name = "";
                    curriculum.c_curriculum_coordinator_name = "";

                }

                gvsearchDetails.DataSource = SystemCurriculumBLL.SearchSystemCurriculum(curriculum);
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
                        Logger.WriteToErrorLog("p_sacsr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p_sacsr-01.aspx", ex.Message);
                    }
                }
            }
            if (gvsearchDetails.Rows.Count == 0)
            {

                disable_enable(false);

            }
            else
            {
                disable_enable(true);
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
            btnAddSelected.Visible = status;

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
            /// temp curriculum id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated curriculum id
            /// <value>Related curriculum id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate curriculum title and curriculum id
            /// <value>concatenate curriculum title and curriculum column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_curriculum_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Equivalencies table
        private DataTable Equivalencies()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp curriculum id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated curriculum id
            /// <value>Related curriculum id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate curriculum title and curriculum id
            /// <value>concatenate curriculum title and curriculum column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_curriculum_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        // Fulfillments table
        private DataTable Fulfillments()
        {
            DataTable dtTempPrerequisites = new DataTable();
            DataColumn dtTempPrerequisitesColumn;

            /// <summary>
            /// temp curriculum id 
            /// <value>auto generate guid.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_group_id";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// Releated curriculum id
            /// <value>Related curriculum id column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_related_curriculum_id_fk";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);

            /// <summary>
            /// concatenate curriculum title and curriculum id
            /// <value>concatenate curriculum title and curriculum column.</value>

            dtTempPrerequisitesColumn = new DataColumn();
            dtTempPrerequisitesColumn.DataType = Type.GetType("System.String");
            dtTempPrerequisitesColumn.ColumnName = "c_curriculum_text";
            dtTempPrerequisites.Columns.Add(dtTempPrerequisitesColumn);
            return dtTempPrerequisites;

        }
        private void AddDataToPrerequisites(string c_related_curriculum_id_fk, string c_curriculum_text, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Add prerequisites function

            DataRow row;
            row = dtTempPrerequisites.NewRow();
            row["c_related_curriculum_group_id"] = SessionWrapper.TempPrerequisitteCurriculumGuid;
            row["c_related_curriculum_id_fk"] = c_related_curriculum_id_fk;
            row["c_curriculum_text"] = c_curriculum_text;
            dtTempPrerequisites.Rows.Add(row);
        }
        private void AddDataToEquivalencies(string c_related_curriculum_id_fk, string c_curriculum_text, DataTable dtTempEquivalencies)
        {
            /// <summary>
            /// Add Equivalencies function

            DataRow row;
            row = dtTempEquivalencies.NewRow();
            row["c_related_curriculum_group_id"] = SessionWrapper.TempEquivalenciesCurriculumGuid;
            row["c_related_curriculum_id_fk"] = c_related_curriculum_id_fk;
            row["c_curriculum_text"] = c_curriculum_text;
            dtTempEquivalencies.Rows.Add(row);
        }
        private void AddDataToFulfillments(string c_related_curriculum_id_fk, string c_curriculum_text, DataTable dtTempFulfillments)
        {
            /// <summary>
            /// Add Equivalencies function

            DataRow row;
            row = dtTempFulfillments.NewRow();
            row["c_related_curriculum_group_id"] = SessionWrapper.TempFulfillmentsCurriculumGuid;
            row["c_related_curriculum_id_fk"] = c_related_curriculum_id_fk;
            row["c_curriculum_text"] = c_curriculum_text;
            dtTempFulfillments.Rows.Add(row);
        }

        private void DeleteDataToPrerequisites(int rowIndex, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Delete prerequisites function

            dtTempPrerequisites.Rows[rowIndex].Delete();
            dtTempPrerequisites.AcceptChanges();

            /// <summary>
            //Bind selected curriculum in Course(s) selected section popup

            dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Prerequisite.DefaultView;
            dlstCurriculumSelected.DataBind();
            /// <summary>
            /// Show and hide curriculum selected section
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
            //Bind selected curriculum in Course(s) selected section popup

            dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Equivalencies.DefaultView;
            dlstCurriculumSelected.DataBind();
            /// <summary>
            /// Show and hide curriculum selected section
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
            //Bind selected curriculum in Course(s) selected section popup

            dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Fulfillments.DefaultView;
            dlstCurriculumSelected.DataBind();

            /// <summary>
            /// Show and hide curriculum selected section
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
                //Add new related curriculum
                foreach (GridViewRow grdPrerequisitesRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdPrerequisitesRow.Cells[2].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {

                        AddDataToPrerequisites(gvsearchDetails.DataKeys[grdPrerequisitesRow.RowIndex].Values[2].ToString(), grdPrerequisitesRow.Cells[1].Text + " (" + grdPrerequisitesRow.Cells[0].Text + ") ", SessionWrapper.Curriculum_Prerequisite);
                        //AddDataToPrerequisites(gvsearchDetails.DataKeys[grdPrerequisitesRow.RowIndex].Values[0].ToString(), grdPrerequisitesRow.Cells[1].Text + " (" + gvsearchDetails.DataKeys[grdPrerequisitesRow.RowIndex].Values[1].ToString() + ") ", SessionWrapper.PrerequisiteCourseSelected);

                    }
                }

                /// <summary>
                //Remove duplicate curriculum
                SessionWrapper.Curriculum_Prerequisite = RemoveDuplicateRows(SessionWrapper.Curriculum_Prerequisite, "c_related_curriculum_id_fk");

                /// <summary>
                //Bind selected curriculum in Course(s) selected section popup
                dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Prerequisite.DefaultView;
                dlstCurriculumSelected.DataBind();

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
            {
                /// <summary>
                //Add new related curriculum
                foreach (GridViewRow grdEquivalenciesRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdEquivalenciesRow.Cells[2].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {

                        AddDataToEquivalencies(gvsearchDetails.DataKeys[grdEquivalenciesRow.RowIndex].Values[2].ToString(), grdEquivalenciesRow.Cells[1].Text + " (" + grdEquivalenciesRow.Cells[0].Text + ") ", SessionWrapper.Curriculum_Equivalencies);


                    }
                }

                /// <summary>
                //Remove duplicate curriculum
                SessionWrapper.Equivalencies = RemoveDuplicateRows(SessionWrapper.Curriculum_Equivalencies, "c_related_curriculum_id_fk");

                /// <summary>
                //Bind selected curriculum in Course(s) selected section popup
                dlstCurriculumSelected.DataSource = SessionWrapper.Equivalencies.DefaultView;
                dlstCurriculumSelected.DataBind();



            }
            else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
            {
                /// <summary>
                //Add new related curriculum
                foreach (GridViewRow grdFulfillmentssRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdFulfillmentssRow.Cells[2].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {

                        AddDataToFulfillments(gvsearchDetails.DataKeys[grdFulfillmentssRow.RowIndex].Values[2].ToString(), grdFulfillmentssRow.Cells[1].Text + " (" + grdFulfillmentssRow.Cells[0].Text + ") ", SessionWrapper.Curriculum_Fulfillments);


                    }
                }

                /// <summary>
                //Remove duplicate curriculum
                SessionWrapper.Curriculum_Fulfillments = RemoveDuplicateRows(SessionWrapper.Curriculum_Fulfillments, "c_related_curriculum_id_fk");

                /// <summary>
                //Bind selected curriculum in Course(s) selected section popup
                dlstCurriculumSelected.DataSource = SessionWrapper.Curriculum_Fulfillments.DefaultView;
                dlstCurriculumSelected.DataBind();
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



        protected void dlstCurriculumSelected_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("Remove"))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                {
                    DeleteDataToPrerequisites(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.Curriculum_Prerequisite);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                {
                    DeleteDataToEquivalencies(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.Curriculum_Equivalencies);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                {
                    DeleteDataToFulfillments(Convert.ToInt32(e.CommandArgument.ToString()), SessionWrapper.Curriculum_Fulfillments);
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
        //Remove duplicate curriculum function

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
        private void AddDataToTempPrerequisites(string c_curriculum_text, DataTable dtTempPrerequisites)
        {
            /// <summary>
            /// Add temp prerequisites function
            if (c_curriculum_text != "")
            {
                DataRow row;
                row = dtTempPrerequisites.NewRow();
                row["c_related_curriculum_group_id"] = SessionWrapper.TempPrerequisitteCurriculumGuid;
                row["c_curriculum_text"] = c_curriculum_text;
                dtTempPrerequisites.Rows.Add(row);
            }
        }
        private void AddDataToTempEquivalencies(string c_curriculum_text, DataTable dtTempEquivalencies)
        {
            /// <summary>
            /// Add temp Equivalencies function
            if (c_curriculum_text != "")
            {
                DataRow row;
                row = dtTempEquivalencies.NewRow();
                row["c_related_curriculum_group_id"] = SessionWrapper.TempEquivalenciesCurriculumGuid;
                row["c_curriculum_text"] = c_curriculum_text;
                dtTempEquivalencies.Rows.Add(row);
            }
        }
        private void AddDataToTempFulfillments(string c_curriculum_text, DataTable dtTempFulfillments)
        {
            /// <summary>
            /// Add temp dtTempFulfillments function
            if (c_curriculum_text != "")
            {
                DataRow row;
                row = dtTempFulfillments.NewRow();
                row["c_related_curriculum_group_id"] = SessionWrapper.TempFulfillmentsCurriculumGuid;
                row["c_curriculum_text"] = c_curriculum_text;
                dtTempFulfillments.Rows.Add(row);
            }
        }

        protected void btnSaveandExit_Click(object sender, EventArgs e)
        {

            //using jquery hide the '*and*' in last row
            Page.ClientScript.RegisterStartupScript(this.GetType(), "And", "DeleteAnd();", true);

            try
            {
                ///<summary>
                ///Edit selected curriculum
                ///</summary>
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saec")
                {

                    SystemCurriculum curriculum = new SystemCurriculum();
                    if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                    {





                        curriculum.c_curriculum_system_id_pk = Request.QueryString["editCurriculumId"];
                        curriculum.c_curriculum_Prerequistist = ConvertDataTableToXml(SessionWrapper.Curriculum_Prerequisite);

                        /// <summary>
                        //Check c_related_curriculum_group_id if exist or not
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editprerequisities"]))
                        {
                            curriculum.c_related_curriculum_group_id = Request.QueryString["editprerequisities"];
                        }
                        else
                        {
                            curriculum.c_related_curriculum_group_id = SessionWrapper.TempPrerequisitteCurriculumGuid;
                        }

                        /// <summary>
                        //update SessionWrapper.Prerequisite value into the database
                        ///</summary>
                        SystemCurriculumBLL.UpdateSystemCurriculumPrerequistist(curriculum);



                        ///</summary>

                        /// <summary>
                        //Clear session
                        SessionWrapper.Curriculum_Prerequisite = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                    {




                        curriculum.c_curriculum_system_id_pk = Request.QueryString["editCurriculumId"];
                        curriculum.c_curriculum_Equivalencies = ConvertDataTableToXml(SessionWrapper.Curriculum_Equivalencies);

                        /// <summary>
                        //Check c_related_curriculum_group_id if exist or not
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editEquivalencies"]))
                        {
                            curriculum.c_related_curriculum_group_id = Request.QueryString["editEquivalencies"];
                        }
                        else
                        {
                            curriculum.c_related_curriculum_group_id = SessionWrapper.TempEquivalenciesCurriculumGuid;
                        }

                        /// <summary>
                        //update SessionWrapper.Equivalencies value into the database
                        ///</summary>

                        SystemCurriculumBLL.UpdateSystemCurriculumEquivalencies(curriculum);
                        ///</summary>

                        /// <summary>
                        //Clear session
                        SessionWrapper.Curriculum_Equivalencies = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                    {



                        curriculum.c_curriculum_system_id_pk = Request.QueryString["editCurriculumId"];
                        curriculum.c_curriculum_Fulfillments = ConvertDataTableToXml(SessionWrapper.Curriculum_Fulfillments);


                        /// <summary>
                        //Check c_related_curriculum_group_id if exist or not
                        ///</summary>

                        if (!string.IsNullOrEmpty(Request.QueryString["editFulfillments"]))
                        {
                            curriculum.c_related_curriculum_group_id = Request.QueryString["editFulfillments"];
                        }
                        else
                        {
                            curriculum.c_related_curriculum_group_id = SessionWrapper.TempFulfillmentsCurriculumGuid;
                        }

                        /// <summary>
                        //update SessionWrapper.Fulfillments value into the  database
                        ///</summary>
                        ///

                        SystemCurriculumBLL.UpdateSystemCurriculumFulfillments(curriculum);
                        ///</summary>


                        /// <summary>
                        //Clear session
                        SessionWrapper.Curriculum_Fulfillments = null;


                    }

                }
                ///<summary>
                ///Add selected curriculum
                ///</summary>
                else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanc")
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "prerequisites")
                    {
                        //Delete previous selected curriculum
                        var rows = SessionWrapper.PrerequisiteCurriculumSelected.Select("c_related_curriculum_group_id= '" + SessionWrapper.TempPrerequisitteCurriculumGuid + "'");
                        foreach (var row in rows)
                            row.Delete();

                        SessionWrapper.PrerequisiteCurriculumSelected.AcceptChanges();

                        //Merger current and previous curriculum selected

                        SessionWrapper.PrerequisiteCurriculumSelected.Merge(SessionWrapper.Curriculum_Prerequisite, true, MissingSchemaAction.Ignore);



                        /// <summary>
                        //Remove duplicate curriculum
                        ///SessionWrapper.PrerequisiteCourseSelected = RemoveDuplicateRows(SessionWrapper.PrerequisiteCourseSelected, "c_related_curriculum_id_fk");
                        ///

                        /// <summary>
                        //Filter curriculum
                        DataTable dtConcatenatePrerequisites = new DataTable();
                        dtConcatenatePrerequisites = SessionWrapper.PrerequisiteCurriculumSelected;
                        DataView dvPrerequisite = new DataView(dtConcatenatePrerequisites);
                        dvPrerequisite.RowFilter = "c_related_curriculum_group_id= '" + SessionWrapper.TempPrerequisitteCurriculumGuid + "'";
                        StringBuilder sbPrerequisites = new StringBuilder();

                        foreach (DataRowView drView in dvPrerequisite)
                        {
                            sbPrerequisites.Append(drView["c_curriculum_text"].ToString() + " *and* ");
                        }

                        /// <summary>
                        //Add column to Tempprerequisite if no rows already added
                        if (SessionWrapper.TempCurriculumPrerequisite.Rows.Count == 0)
                        {
                            SessionWrapper.TempCurriculumPrerequisite = Prerequisites();
                        }

                        /// <summary>
                        //Delete temp previous selected curriculum
                        var tempPreq = SessionWrapper.TempCurriculumPrerequisite.Select("c_related_curriculum_group_id= '" + SessionWrapper.TempPrerequisitteCurriculumGuid + "'");
                        foreach (var row in tempPreq)
                            row.Delete();
                        SessionWrapper.TempCurriculumPrerequisite.AcceptChanges();

                        /// <summary>
                        //Remove last " *and* "
                        string strPrerequisites = sbPrerequisites.ToString();
                        if (!string.IsNullOrEmpty(strPrerequisites))
                        {
                            strPrerequisites = strPrerequisites.Substring(0, strPrerequisites.Length - 6);
                        }
                        /// <summary>
                        //Add data to temp prerequisite
                        AddDataToTempPrerequisites(strPrerequisites, SessionWrapper.TempCurriculumPrerequisite);
                        SessionWrapper.Curriculum_Prerequisite = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Equivalencies")
                    {
                        //Delete previous selected curriculum
                        var rows = SessionWrapper.EquivalenciesCurriculumSelected.Select("c_related_curriculum_group_id= '" + SessionWrapper.TempEquivalenciesCurriculumGuid + "'");
                        foreach (var row in rows)
                            row.Delete();

                        SessionWrapper.EquivalenciesCurriculumSelected.AcceptChanges();


                        //Merger current and previous curriculum selected
                        SessionWrapper.EquivalenciesCurriculumSelected.Merge(SessionWrapper.Curriculum_Equivalencies, true, MissingSchemaAction.Ignore);


                        /// <summary>
                        //Remove duplicate curriculum
                        ///SessionWrapper.EquivalenciesCourseSelected = RemoveDuplicateRows(SessionWrapper.EquivalenciesCourseSelected, "c_related_curriculum_id_fk");
                        ///

                        /// <summary>
                        //Filter curriculum
                        DataTable dtConcatenateEquivalenciess = new DataTable();
                        dtConcatenateEquivalenciess = SessionWrapper.EquivalenciesCurriculumSelected;
                        DataView dvEquivalencies = new DataView(dtConcatenateEquivalenciess);
                        dvEquivalencies.RowFilter = "c_related_curriculum_group_id= '" + SessionWrapper.TempEquivalenciesCurriculumGuid + "'";
                        StringBuilder sbEquivalenciess = new StringBuilder();


                        foreach (DataRowView drView in dvEquivalencies)
                        {
                            sbEquivalenciess.Append(drView["c_curriculum_text"].ToString() + " *and* ");
                        }

                        /// <summary>
                        //Add column to TempEquivalencies if no rows already added
                        if (SessionWrapper.TempCurriculumEquivalencies.Rows.Count == 0)
                        {
                            SessionWrapper.TempCurriculumEquivalencies = Equivalencies();
                        }

                        /// <summary>
                        //Delete temp previous selected curriculum
                        var tempPreq = SessionWrapper.TempCurriculumEquivalencies.Select("c_related_curriculum_group_id= '" + SessionWrapper.TempEquivalenciesCurriculumGuid + "'");
                        foreach (var row in tempPreq)
                            row.Delete();
                        SessionWrapper.TempCurriculumEquivalencies.AcceptChanges();
                        /// <summary>
                        //Remove last " *and* "
                        string strEquivalencies = sbEquivalenciess.ToString();
                        if (!string.IsNullOrEmpty(strEquivalencies))
                        {
                            strEquivalencies = strEquivalencies.Substring(0, strEquivalencies.Length - 6);
                        }
                        /// <summary>
                        //Add data to temp Equivalencies
                        AddDataToTempEquivalencies(strEquivalencies, SessionWrapper.TempCurriculumEquivalencies);
                        SessionWrapper.Curriculum_Equivalencies = null;
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["select"]) && Request.QueryString["select"] == "Fulfillments")
                    {
                        //Delete previous selected curriculum
                        var rows = SessionWrapper.FulfillmentsCurriculumSelected.Select("c_related_curriculum_group_id= '" + SessionWrapper.TempFulfillmentsCurriculumGuid + "'");
                        foreach (var row in rows)
                            row.Delete();

                        SessionWrapper.FulfillmentsCurriculumSelected.AcceptChanges();


                        //Merger current and previous curriculum selected
                        SessionWrapper.FulfillmentsCurriculumSelected.Merge(SessionWrapper.Curriculum_Fulfillments, true, MissingSchemaAction.Ignore);


                        /// <summary>
                        //Remove duplicate curriculum
                        /// SessionWrapper.FulfillmentsCourseSelected = RemoveDuplicateRows(SessionWrapper.FulfillmentsCourseSelected, "c_related_curriculum_id_fk");
                        ///

                        /// <summary>
                        //Filter curriculum
                        DataTable dtConcatenateFulfillmentss = new DataTable();

                        /// <summary>
                        //dtConcatenateFulfillmentss = SessionWrapper.Fulfillments;
                        dtConcatenateFulfillmentss = SessionWrapper.FulfillmentsCurriculumSelected;
                        DataView dvFulfillments = new DataView(dtConcatenateFulfillmentss);
                        dvFulfillments.RowFilter = "c_related_curriculum_group_id= '" + SessionWrapper.TempFulfillmentsCurriculumGuid + "'";
                        StringBuilder sbFulfillmentss = new StringBuilder();

                        foreach (DataRowView drView in dvFulfillments)
                        {

                            sbFulfillmentss.Append(drView["c_curriculum_text"].ToString() + " *and* ");
                        }

                        /// <summary>
                        //Add column to TempFulfillments if no rows already added
                        if (SessionWrapper.TempCurriculumFulfillments.Rows.Count == 0)
                        {
                            SessionWrapper.TempCurriculumFulfillments = Fulfillments();
                        }

                        /// <summary>
                        //Delete temp previous selected curriculum
                        var tempPreq = SessionWrapper.TempCurriculumFulfillments.Select("c_related_curriculum_group_id= '" + SessionWrapper.TempFulfillmentsCurriculumGuid + "'");
                        foreach (var row in tempPreq)
                            row.Delete();
                        SessionWrapper.TempCurriculumFulfillments.AcceptChanges();

                        //Remove last " *and* "
                        string strFulfillments = sbFulfillmentss.ToString();
                        if (!string.IsNullOrEmpty(strFulfillments))
                        {
                            strFulfillments = strFulfillments.Substring(0, strFulfillments.Length - 6);
                        }

                        /// <summary>
                        //Add data to temp Fulfillments

                        AddDataToTempFulfillments(strFulfillments, SessionWrapper.TempCurriculumFulfillments);
                        SessionWrapper.Curriculum_Fulfillments = null;
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
                        Logger.WriteToErrorLog("p_sacsr-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p_sacsr-01", ex.Message);
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

            if (dlstCurriculumSelected.Items.Count > 0)
            {
                curriculumselected.Style.Add("display", "block");
            }
            else
            {
                curriculumselected.Style.Add("display", "none");
            }
        }

    }
}