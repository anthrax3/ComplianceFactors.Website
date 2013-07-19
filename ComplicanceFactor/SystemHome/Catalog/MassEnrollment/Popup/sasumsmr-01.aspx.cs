using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Catalog.MassEnrollment.Popup
{
    public partial class sasumsmr_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SearchResult();
                //count page of page in search result
                lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
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
        private void SearchResult()
        {
            User userSearch = new User();
            if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
            {
                userSearch.Firstname = txtEmployeeName.Text;
                userSearch.Hris_employeid = txtEmployeeId.Text;

            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["employeeName"]))
                {
                    userSearch.Firstname = SecurityCenter.DecryptText(Request.QueryString["employeeName"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["employeeId"]))
                {
                    userSearch.Hris_employeid = SecurityCenter.DecryptText(Request.QueryString["employeeId"]);
                }
            }
            try
            {
                gvsearchDetails.DataSource = SystemMassCompletionBLL.SearchUser(userSearch);
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
                        Logger.WriteToErrorLog("sacsr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sacsr-01.aspx", ex.Message);
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
            btnSaveSelected.Visible = status;
            btnSaveSelected.Visible = status;

        }
        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }
        protected void gvsearchDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void btnSaveSelected_Click(object sender, EventArgs e)
        {
            //DataTable dtInstructorCourse = new DataTable();
            SessionWrapper.MassEnrollment_employees = TempDataTables.TempCompletionEmployee();
            foreach (GridViewRow grdResourceRow in gvsearchDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)(grdResourceRow.Cells[1].FindControl("chkSelect"));
                if (chkSelect.Checked == true)
                {
                    AddDataToCompletionEmployee(gvsearchDetails.DataKeys[grdResourceRow.RowIndex].Values[0].ToString(), gvsearchDetails.DataKeys[grdResourceRow.RowIndex].Values[1].ToString(), gvsearchDetails.DataKeys[grdResourceRow.RowIndex].Values[2].ToString(), SessionWrapper.MassEnrollment_employees);
                }
            }
            //SystemInstructorBLL.InsertInstructorCourse(ConvertDataTableToXml(dtInstructorCourse));

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            //Remove duplicate resource
            //dtInstructorCourse = RemoveDuplicateRows(dtInstructorCourse, "s_resource_system_id_pk");

        }
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
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
        /// Add data to instructor course
        /// </summary>
        /// <param name="c_instructor_id_fk"></param>
        /// <param name="c_course_id_fk"></param>
        /// <param name="dtTempInstructor"></param>
        private void AddDataToCompletionEmployee(string u_user_id_pk, string u_username, string u_hris_employee_id, DataTable dtTempEmployee)
        {
            DataRow row;
            row = dtTempEmployee.NewRow();
            //row["c_instructor_id_fk"] = c_instructor_id_fk;
            row["u_user_id_pk"] = u_user_id_pk;
            row["u_username"] = u_username;
            row["u_hris_employee_id"] = u_hris_employee_id;
            //row["c_delivery_system_id_pk"] = c_delivery_type_name;
            dtTempEmployee.Rows.Add(row);

        }

    }
}