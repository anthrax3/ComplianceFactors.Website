using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Collections;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.CourseSearch
{
    public partial class p_spcsr_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// <summary>
                /// Search Result
                SearchResult();
                /// <summary>
                //count page of page in search result
                lblFooterPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
                lblHeaderPageOf.Text = "of " + (gvsearchDetails.PageCount).ToString();
            }

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
            try
            {
                ManageCourse course = new ManageCourse();
                if (!string.IsNullOrEmpty((string)ViewState["SearchResult"]))
                {
                    course.c_course_id_pk = txtCourseId.Text;
                    course.c_course_title = txtCourseName.Text;
               
                }
                else
                {
                    course.c_course_id_pk = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    course.c_course_title = SecurityCenter.DecryptText(Request.QueryString["name"]);

                }
                gvsearchDetails.DataSource = SystemCurriculumBLL.SearchSystemCatalog(course);
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
                        Logger.WriteToErrorLog("p_spcsr-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p_spcsr-01.aspx", ex.Message);
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
            btnAddSelected.Visible = false;

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
            btnAddSelected.Visible = true;

        }

        protected void gvsearchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsearchDetails.PageIndex = e.NewPageIndex;

            SearchResult();
        }

        protected void btnAddSelected_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "add" && (Request.QueryString["page"] == "p-sacp-01"))
            {
                //Get paritcular section using path section id to avoid duplicate course in each section.
                string c_curricula_path_section_id_fk = SecurityCenter.DecryptText(Request.QueryString["sec"]);
                DataView dvPathCourse = new DataView(SessionWrapper.TempPathCourse);
                dvPathCourse.RowFilter = "c_curricula_path_section_id_fk= '" + c_curricula_path_section_id_fk + "'";
                DataTable dtPathcourse = new DataTable();
                dtPathcourse = dvPathCourse.ToTable();
                int count = 0;
                foreach (GridViewRow grdCourserRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdCourserRow.Cells[1].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {
                        count = count + 1;
                        AddDataToPathCourse(c_curricula_path_section_id_fk, gvsearchDetails.DataKeys[grdCourserRow.RowIndex].Values[0].ToString(), grdCourserRow.Cells[1].Text, grdCourserRow.Cells[0].Text, count, dtPathcourse);

                    }
                }
                //Delete previous course selected (because we have avoid duplicate course in each and every section)
                var rows = SessionWrapper.TempPathCourse.Select("c_curricula_path_section_id_fk= '" + c_curricula_path_section_id_fk.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempPathCourse.AcceptChanges();
                SessionWrapper.TempPathCourse.Merge(RemoveDuplicateRows(dtPathcourse, "c_curricula_path_course_id_fk"));
                //active popup( because datalist within ispostback property, so each and every pageload that will rebind, to avoid unneccessary rebind of
                //datalist we use active popup session
                SessionWrapper.Active_Popup = "ture";
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
                //Remove duplicate resource
                //dtInstructorCourse = RemoveDuplicateRows(dtInstructorCourse, "s_resource_system_id_pk");
            }
            else if (Request.QueryString["mode"] == "edit" && (Request.QueryString["page"] == "p-secp-01"))
            {
                string c_curricula_id_fk = Request.QueryString["editcurriculumId"];
                string c_curricula_path_id_fk = Request.QueryString["editCurriculumpathId"];
                string c_curricula_path_section_id_fk = SecurityCenter.DecryptText(Request.QueryString["sec"]);
                DataTable dtPathcourse = TempDataTables.TempPathCourse();
                int result = SystemCurriculumBLL.checkPathsectioncourse(c_curricula_path_section_id_fk);
                int count = 0;
                if (result > 0)
                {
                    count = result;
                }
                foreach (GridViewRow grdCourserRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdCourserRow.Cells[1].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {
                        count = count + 1;
                        AddDataToPathCourse(c_curricula_path_section_id_fk, gvsearchDetails.DataKeys[grdCourserRow.RowIndex].Values[0].ToString(), grdCourserRow.Cells[1].Text, grdCourserRow.Cells[0].Text, count, dtPathcourse);

                    }
                }
                //datalist we use active popup session
                SessionWrapper.Active_Popup = "ture";
                SystemCurriculumBLL.InsertCurriculaPathCourse(ConvertDataTableToXml(dtPathcourse), c_curricula_id_fk, c_curricula_path_id_fk, c_curricula_path_section_id_fk);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

            }
            else if (Request.QueryString["mode"] == "add" && (Request.QueryString["page"] == "p-sacrp-01"))
            {
                //Get paritcular section using path section id to avoid duplicate course in each section.
                string c_curricula_recert_path_section_id_fk = SecurityCenter.DecryptText(Request.QueryString["sec"]);
                DataView dvRecertPathCourse = new DataView(SessionWrapper.TempRecertPathCourse);
                dvRecertPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk + "'";
                DataTable dtRecertPathcourse = new DataTable();
                dtRecertPathcourse = dvRecertPathCourse.ToTable();
                int count = 0;
                foreach (GridViewRow grdCourserRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdCourserRow.Cells[1].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {
                        count = count + 1;
                        AddDataToPathCourse(c_curricula_recert_path_section_id_fk, gvsearchDetails.DataKeys[grdCourserRow.RowIndex].Values[0].ToString(), grdCourserRow.Cells[1].Text, grdCourserRow.Cells[0].Text, count, dtRecertPathcourse);

                    }
                }
                //Delete previous course selected (because we have avoid duplicate course in each and every section)
                var rows = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempRecertPathCourse.AcceptChanges();
                SessionWrapper.TempRecertPathCourse.Merge(RemoveDuplicateRows(dtRecertPathcourse, "c_curricula_recert_path_course_id_fk"));
                //active popup( because datalist within ispostback property, so each and every pageload that will rebind, to avoid unneccessary rebind of
                //datalist we use active popup session
                SessionWrapper.Active_Popup = "ture";
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

            }
            else if (Request.QueryString["mode"] == "edit" && (Request.QueryString["page"] == "p-secrp-01"))
            {
                string c_curricula_recert_id_fk = Request.QueryString["editcurriculumId"];
                string c_curricula_recert_path_id_fk = Request.QueryString["editCurriculumpathId"];
                string c_curricula_recert_path_section_id_fk = SecurityCenter.DecryptText(Request.QueryString["sec"]);
                DataTable dtPathcourse = TempDataTables.TempRecertPathCourse();
                int result = SystemCurriculumBLL.checkRecertPathsectioncourse(c_curricula_recert_path_section_id_fk);
                int count = 0;
                if (result > 0)
                {
                    count = result;
                }
                foreach (GridViewRow grdCourserRow in gvsearchDetails.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(grdCourserRow.Cells[1].FindControl("chkSelect"));
                    if (chkSelect.Checked == true)
                    {
                        count = count + 1;
                        AddDataToPathCourse(c_curricula_recert_path_section_id_fk, gvsearchDetails.DataKeys[grdCourserRow.RowIndex].Values[0].ToString(), grdCourserRow.Cells[1].Text, grdCourserRow.Cells[0].Text, count, dtPathcourse);

                    }
                }
                //datalist we use active popup session
                SessionWrapper.Active_Popup = "ture";
                SystemCurriculumBLL.InsertCurriculaRecertPathCourse(ConvertDataTableToXml(dtPathcourse), c_curricula_recert_id_fk, c_curricula_recert_path_id_fk, c_curricula_recert_path_section_id_fk);
                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

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

        private void AddDataToPathCourse(string c_curricula_path_section_id_fk, string c_curricula_path_course_id_fk, string c_course_id, string c_course_name, int c_curricula_path_course_seq_number, DataTable dtTempInstructor)
        {
            if ((Request.QueryString["page"] == "p-sacrp-01") || (Request.QueryString["page"] == "p-secrp-01"))
            {
                DataRow row;
                row = dtTempInstructor.NewRow();
                row["c_curricula_recert_path_section_id_fk"] = c_curricula_path_section_id_fk;
                row["c_curricula_recert_path_course_id_fk"] = c_curricula_path_course_id_fk;
                row["c_course_id"] = c_course_id;
                row["c_course_name"] = c_course_name;
                row["c_curricula_recert_path_course_seq_number"] = c_curricula_path_course_seq_number;
                dtTempInstructor.Rows.Add(row);
            }
            else
            {
                DataRow row;
                row = dtTempInstructor.NewRow();
                row["c_curricula_path_section_id_fk"] = c_curricula_path_section_id_fk;
                row["c_curricula_path_course_id_fk"] = c_curricula_path_course_id_fk;
                row["c_course_id"] = c_course_id;
                row["c_course_name"] = c_course_name;
                row["c_curricula_path_course_seq_number"] = c_curricula_path_course_seq_number;
                dtTempInstructor.Rows.Add(row);
            }
        }
    }
}