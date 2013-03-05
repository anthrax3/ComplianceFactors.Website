using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Collections;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class sainssr_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Search result
                SearchResult();



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

            Response.Redirect("~/SystemHome/Catalog/Course/saantc-01.aspx");

        }

        private void SearchResult()
        {
            try
            {

                SystemCatalog catalog = new SystemCatalog();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    catalog.c_session_last_name = txtLastName.Text;
                    catalog.c_session_first_name = txtFirstName.Text;
                    
                }
                else
                {
                    catalog.c_session_last_name = SecurityCenter.DecryptText(Request.QueryString["lastname"]);
                    catalog.c_session_first_name = SecurityCenter.DecryptText(Request.QueryString["firstname"]);

                }
                if (!string.IsNullOrEmpty(SessionWrapper.AuthInstructorCourseId))
                {
                    catalog.c_course_system_id_pk = SessionWrapper.AuthInstructorCourseId;
                    gvsearchDetails.DataSource = SystemCatalogBLL.AuthorizedInstructorSearch(catalog);
                    gvsearchDetails.DataBind();
                   
                }
                else
                {
                    gvsearchDetails.DataSource = SystemCatalogBLL.InstructorSearch(catalog);
                    gvsearchDetails.DataBind();
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
                        Logger.WriteToErrorLog("sainssr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sainssr-01.aspx", ex.Message);
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

        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        private void AddDataToDeliveryInstructor(string c_user_id_fk, string c_instructor_name, string c_session_id_fk, string c_delivery_id_fk, DataTable dtTempDeliveryInstructor)
        {
            // Add Instructor function
            DataRow row;
            row = dtTempDeliveryInstructor.NewRow();
            row["c_instructor_system_id_pk"] = Guid.NewGuid().ToString();
            row["c_user_id_fk"] = c_user_id_fk;
            row["c_instructor_name"] = c_instructor_name;
            row["c_session_id_fk"] = c_session_id_fk;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            row["c_instructor_confirm"] = false;
            dtTempDeliveryInstructor.Rows.Add(row);
        }
        /// <summary>
        /// Remove duplicate rows
        /// </summary>
        /// <param name="dTable"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Selected insturstor stored in session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvsearchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                GridViewRow row = gvsearchDetails.Rows[Convert.ToInt32(e.CommandArgument.ToString())];

                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand")
                {
                    //Add new instrustor while we creating a new delivery on new course
                    InstructorAddEditMode(gvsearchDetails.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["u_user_id_pk"].ToString(), row.Cells[0].Text, "", "", SessionWrapper.TempDeliveryInstructor);
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
                {
                    //Add new instructor while we editing a new delivery on new course
                    DataView dvInstructors = new DataView(SessionWrapper.DeliveryInstructor);
                    dvInstructors.RowFilter = "c_session_id_fk= '" + SessionWrapper.c_session_system_id_pk + "'";
                    DataTable dtInstructors = new DataTable();
                    dtInstructors = InstructorAddEditMode(gvsearchDetails.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["u_user_id_pk"].ToString(), row.Cells[0].Text, SessionWrapper.c_session_system_id_pk, SessionWrapper.c_delivery_system_id_pk, dvInstructors.ToTable());
                    var insRows = SessionWrapper.DeliveryInstructor.Select("c_session_id_fk= '" + SessionWrapper.c_session_system_id_pk + "'");
                    foreach (var dvRow in insRows)
                        dvRow.Delete();
                    SessionWrapper.DeliveryInstructor.Merge(dtInstructors);


                }
                else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed-02" && !string.IsNullOrEmpty(Request.QueryString["editsession"]))
                {
                    //Add new instructor while we editing a existing delivery on edit course
                    InstructorAddEditMode(gvsearchDetails.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["u_user_id_pk"].ToString(), row.Cells[0].Text, Request.QueryString["editsession"], Request.QueryString["editdelivery"], SessionWrapper.TempDeliveryInstructor);
                }
                //Close popup
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }


        }
        /// <summary>
        /// add data to instrustor datatable
        /// </summary>
        /// <param name="u_user_id_fk"></param>
        /// <param name="c_instructor_name"></param>
        /// <param name="c_session_id_fk"></param>
        /// <param name="c_delivery_id_fk"></param>
        /// <param name="dtInstructor"></param>
        /// <returns></returns>

        private DataTable InstructorAddEditMode(string u_user_id_fk, string c_instructor_name, string c_session_id_fk, string c_delivery_id_fk, DataTable dtInstructor)
        {
            AddDataToDeliveryInstructor(u_user_id_fk, c_instructor_name, c_session_id_fk, c_delivery_id_fk, dtInstructor);
            //Remove duplicate instructor
            dtInstructor = RemoveDuplicateRows(dtInstructor, "c_user_id_fk");
            return dtInstructor;
        }


    }
}