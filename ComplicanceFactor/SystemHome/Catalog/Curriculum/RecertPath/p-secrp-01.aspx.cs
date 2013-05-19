using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.RecertPath
{
    public partial class p_secrp_01 : System.Web.UI.Page
    {

        private DataSet dsGetPath;
        private static string editCurriculumPath;
        private static string editCurriculumId;
        private static string lastsectionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumPathId"]))
            {
                editCurriculumPath = Request.QueryString["editCurriculumPathId"];
                hdEditCurriculumPathId.Value = editCurriculumPath;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]))
            {
                editCurriculumId = Request.QueryString["editCurriculumId"];
                hdEditCurriculumId.Value = editCurriculumId;
            }
            if (!string.IsNullOrEmpty(SessionWrapper.Active_Popup))
            {
                GetRecertPathSection();
                BindRecertPathandSection();
                SessionWrapper.Active_Popup = string.Empty;
            }
            if (!IsPostBack)
            {
                PopulateRecertPath(editCurriculumPath);
            }

        }
        protected void dlSection_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblSectionNumber = e.Item.FindControl("lblSectionNumber") as Label;
            int seqHazard = Convert.ToInt32(e.Item.ItemIndex) + 1;
            lblSectionNumber.Text = LocalResources.GetLabel("app_section_text") + seqHazard + ":";
            if (e.Item.ItemType == ListItemType.Item)
            {
                string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[e.Item.ItemIndex].ToString();
                if (string.IsNullOrEmpty(c_curricula_recert_path_section_id_fk))
                {
                    e.Item.Style.Add("display", "none");
                }
                string c_curricula_recert_path_section_enforce_seq_flag = DataBinder.Eval(e.Item.DataItem, "c_curricula_recert_path_section_enforce_seq_flag").ToString();
                Literal ltlcheckSection = (Literal)e.Item.FindControl("ltlcheckSection");
                if (c_curricula_recert_path_section_enforce_seq_flag == "True")
                {

                    ltlcheckSection.Text = "<input id=" + editCurriculumId + ',' + c_curricula_recert_path_section_id_fk + " class='sectionrequired cursor_hand' type='checkbox' checked='checked'/>";
                }
                else
                {

                    ltlcheckSection.Text = "<input id=" + editCurriculumId + ',' + c_curricula_recert_path_section_id_fk + " class='sectionnotrequired cursor_hand' type='checkbox' />";
                }

            }
            GridView gvCourse = (GridView)e.Item.FindControl("gvCourse");
            BindPathCourse(gvCourse, dlSection.DataKeys[e.Item.ItemIndex].ToString());
        }
        private void PopulateRecertPath(string editCurriculumPathId)
        {
            SystemCurriculum path = new SystemCurriculum();
            path = SystemCurriculumBLL.GetCurriculumRecertPath(string.Empty, editCurriculumPathId);
            txtPathName.Text = path.c_curricula_recert_path_name;
            txtDescription.Value = path.c_curricula_recert_path_Description;
            txtAbstract.Value = path.c_curricula_recert_path_abstract;
            chkHeaderEnforceSectionsSequence.Checked = path.c_curricula_recert_path_enforce_section_seq_flag;
            txtComplete.Text = Convert.ToString(path.c_curricula_recert_path_complete);
            lblSectionCount.Text = Convert.ToString(path.c_curricula_recert_path_sections);
            BindRecertPathandSection();
        }
        public void BindRecertPathandSection()
        {
            //Get all section 
            GetRecertPathSection();
            //Bind curriculum path section
            int count = dsGetPath.Tables[1].Rows.Count;
            if (count > 0)
            {
                lastsectionId = dsGetPath.Tables[1].Rows[count - 1]["c_curricula_recert_path_section_id_pk"].ToString();
            }
            dlSection.DataSource = dsGetPath.Tables[1];
            dlSection.DataBind();
            txtComplete.Text = Convert.ToString(dlSection.Items.Count);
            lblSectionCount.Text = Convert.ToString(dlSection.Items.Count);
            for (int i = 0; i < dlSection.Items.Count; i++)
            {

                DataListItem dlItems = dlSection.Items[i];
                GridView gvCourse = (GridView)dlSection.Items[i].FindControl("gvCourse");
                string c_curricula_recert_path_course_seq_number = gvCourse.DataKeys[0].Values[1].ToString();

                if (!string.IsNullOrEmpty(c_curricula_recert_path_course_seq_number))
                {

                    TextBox txtCourseComplete = (TextBox)dlSection.Items[i].FindControl("txtCourseComplete");
                    Label lblCourse = (Label)dlSection.Items[i].FindControl("lblCourse");
                    CheckBox chkEnforceSectionsSequence = (CheckBox)dlSection.Items[i].FindControl("chkEnforceSectionsSequence");
                    //txtCourseComplete.Text = dsGetPath.Tables[1].Rows[i]["c_curricula_recert_path_section_complete"].ToString();
                    //lblCourse.Text = dsGetPath.Tables[1].Rows[i]["c_curricula_recert_path_section_courses"].ToString();
                    txtCourseComplete.Text = Convert.ToString(gvCourse.Rows.Count);
                    lblCourse.Text = Convert.ToString(gvCourse.Rows.Count);
                    GridViewRow FirstRow = gvCourse.Rows[0];
                    Button btnUp = (Button)FirstRow.FindControl("btnUp");
                    btnUp.Enabled = false;
                    GridViewRow LastRow = gvCourse.Rows[gvCourse.Rows.Count - 1];
                    Button btnDown = (Button)LastRow.FindControl("btnDown");
                    btnDown.Enabled = false;
                }
                else
                {
                    Label lblCourse = (Label)dlSection.Items[i].FindControl("lblCourse");
                    lblCourse.Text = "0";
                    TextBox txtCourse = (TextBox)dlSection.Items[i].FindControl("txtCourse");
                    txtCourse.Text = "0";
                }

            }

        }
        //bind curriculum path course
        private void BindPathCourse(GridView GridView, string c_curricula_recert_path_section_id_pk)
        {
            try
            {
                // Update section complete and course
                //SystemCurriculumBLL.UpdateRecertSectionCompleteAndCourse(c_curricula_recert_path_section_id_pk, editCurriculumId);
                DataTable dtPathCourse = new DataTable();
                //Get particular course from section
                GetRecertPathSection();
                DataView dvPathCourse = new DataView(dsGetPath.Tables[2]);
                dvPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_pk + "'";
                dvPathCourse.Sort = "c_curricula_recert_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                if (dtPathCourse.Rows.Count == 0)
                {
                    DataRow row;
                    row = dtPathCourse.NewRow();
                    row["c_curricula_recert_path_section_id_fk"] = c_curricula_recert_path_section_id_pk;
                    row["c_curricula_recert_path_required"] = 0;
                    dtPathCourse.Rows.Add(row);
                }
                GridView.DataSource = dtPathCourse;
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-secp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-secp-01.aspx", ex.Message);
                    }
                }
            }

        }
        protected void gvCourse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            DataListItem dlItem = (DataListItem)GridView1.Parent;
            DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string c_curricula_recert_path_course_id_fk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                string c_curricula_recert_path_section_id_fk = DataBinder.Eval(e.Row.DataItem, "c_curricula_recert_path_section_id_fk").ToString();
                if (string.IsNullOrEmpty(c_curricula_recert_path_course_id_fk))
                {
                    e.Row.Style.Add("display", "none");
                }
                string c_curricula_recert_path_required = DataBinder.Eval(e.Row.DataItem, "c_curricula_recert_path_required").ToString();
                CheckBox chkRequired = e.Row.FindControl("chkRequired") as CheckBox;
                Literal ltlcheck = (Literal)e.Row.FindControl("ltlcheck");
                if (c_curricula_recert_path_required == "1")
                {

                    ltlcheck.Text = "<input id=" + c_curricula_recert_path_course_id_fk + ',' + c_curricula_recert_path_section_id_fk + " class='couserequired cursor_hand' type='checkbox' checked='checked'/>";
                }
                else
                {

                    ltlcheck.Text = "<input id=" + c_curricula_recert_path_course_id_fk + ',' + c_curricula_recert_path_section_id_fk + " class='cousenotrequired cursor_hand' type='checkbox' />";
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string c_curricula_recert_path_section_id_pk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();

                e.Row.Cells[0].Text = "<input id=" + c_curricula_recert_path_section_id_pk + " class='newcourse cursor_hand' type='button' value='" + LocalResources.GetLabel("app_add_course_button_text") + "'/>";

            }
        }
        protected void gvCourse_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Remove"))
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string c_curricula_recert_path_course_id_fk = GridView1.DataKeys[rowIndex][0].ToString();
                SystemCurriculumBLL.DeleteSingleRecertPathcourse(c_curricula_recert_path_course_id_fk, c_curricula_recert_path_section_id_fk);

            }
            else if (e.CommandName.Equals("Up"))
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();
                int gvRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvrow = GridView1.Rows[gvRowIndex];
                GridViewRow previousRow = GridView1.Rows[gvRowIndex - 1];
                string c_current_curricula_recert_path_course_id_fk = GridView1.DataKeys[gvRowIndex][0].ToString();//Current Course id
                string c_previous_curricula_recert_path_course_id_fk = GridView1.DataKeys[gvRowIndex - 1][0].ToString();//Previous course id
                string current_course_system_id_pk = GridView1.DataKeys[gvRowIndex][2].ToString();//current path system id
                string previous_course_system_id_pk = GridView1.DataKeys[gvRowIndex - 1][2].ToString();//Previous id
                SystemCurriculumBLL.UpdateCurriculaRecertPathCourseSeqNumberforUp(c_current_curricula_recert_path_course_id_fk, c_previous_curricula_recert_path_course_id_fk, current_course_system_id_pk, previous_course_system_id_pk, c_curricula_recert_path_section_id_fk);
            }
            else if (e.CommandName.Equals("Down"))
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();
                int gvRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow currentrow = GridView1.Rows[gvRowIndex];
                GridViewRow nextRow = GridView1.Rows[gvRowIndex + 1];
                string c_current_curricula_recert_path_course_id_fk = GridView1.DataKeys[gvRowIndex][0].ToString();//Current Course id
                string c_next_curricula_recert_path_course_id_fk = GridView1.DataKeys[gvRowIndex + 1][0].ToString();//Next course id
                string current_course_system_id_pk = GridView1.DataKeys[gvRowIndex][2].ToString();//current path system id
                string next_course_system_id_pk = GridView1.DataKeys[gvRowIndex + 1][2].ToString();//Next id
                SystemCurriculumBLL.UpdateCurriculaRecertPathCourseSeqNumberforDown(c_current_curricula_recert_path_course_id_fk, c_next_curricula_recert_path_course_id_fk, current_course_system_id_pk, next_course_system_id_pk, c_curricula_recert_path_section_id_fk);
            }
            BindRecertPathandSection();
        }
        protected void btnAddSection_Click(object sender, System.EventArgs e)
        {
            int result = SystemCurriculumBLL.checkRecertPathsectioncourse(lastsectionId);

            if (result > 0)
            {
                //Add Empth Path Section
                dsGetPath = SystemCurriculumBLL.GetCurriculumRecertPathCourseSection(editCurriculumId, editCurriculumPath);
                int c_curricula_recert_path_section_seq_number = dsGetPath.Tables[1].Rows.Count;
                SystemCurriculumBLL.InsertCurrriculaRecertPathSection(editCurriculumId, editCurriculumPath, c_curricula_recert_path_section_seq_number + 1);
                BindRecertPathandSection();
            }
            else
            {
                string str = "<script>alert(\"Please add atleast one course in above section.\");</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
            }
        }
        protected void btnSavePath_Click(object sender, System.EventArgs e)
        {
            UpdatePathCourse();

        }
        private void UpdatePathCourse()
        {

            try
            {
                //Add Empth Path Section
                dsGetPath = SystemCurriculumBLL.GetCurriculumRecertPathCourseSection(editCurriculumId, editCurriculumPath);

                SystemCurriculum path = new SystemCurriculum();
                path.c_curricula_recert_path_system_id_pk = editCurriculumPath;
                path.c_curricula_recert_id_fk = editCurriculumId;
                path.c_curricula_recert_path_name = txtPathName.Text;
                path.c_curricula_recert_path_Description = txtDescription.Value;
                path.c_curricula_recert_path_abstract = txtAbstract.Value;
                path.c_curricula_recert_path_enforce_section_seq_flag = chkHeaderEnforceSectionsSequence.Checked;
                path.c_curricula_recert_path_complete = Convert.ToInt32(txtComplete.Text);
                path.c_curricula_recert_path_sections = Convert.ToInt32(lblSectionCount.Text);
                int result = SystemCurriculumBLL.UpdateCurriculaRecertPath(path);
                //Close fancybox
                if (result != -1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
                }

            }
            catch (Exception ex)
            {

                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-secp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-secp-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Updare checked required field
        /// </summary>
        [System.Web.Services.WebMethod]
        public static void CourseRequired(string args, string args1, string args2)
        {
            string c_curricula_recert_path_section_id_fk = args1.Trim();
            string c_curricula_recert_path_course_id_fk = args.Trim();
            SystemCurriculumBLL.UpdateCheckedRecertPathCourseRequiredField(c_curricula_recert_path_section_id_fk, c_curricula_recert_path_course_id_fk);

        }
        [System.Web.Services.WebMethod]
        public static void CourseNotRequired(string args, string args1, string args2)
        {

            string c_curricula_recert_path_section_id_fk = args1.Trim();
            string c_curricula_recert_path_course_id_fk = args.Trim();
            SystemCurriculumBLL.UpdateUnCheckedRecertPathCourseRequiredField(c_curricula_recert_path_section_id_fk, c_curricula_recert_path_course_id_fk);

        }
        /// <summary>
        /// update checked section
        /// </summary>
        [System.Web.Services.WebMethod]
        public static void SectionRequired(string args, string args1)
        {
            string c_curricula_recert_id_fk = args.Trim();
            string c_curricula_recert_path_section_id_pk = args1.Trim();
            SystemCurriculumBLL.UpdateRecertCheckedEnforceCourse(c_curricula_recert_id_fk, c_curricula_recert_path_section_id_pk);
        }
        /// <summary>
        /// Update Unchecked sections
        /// </summary>
        [System.Web.Services.WebMethod]
        public static void sectionnotrequired(string args, string args1)
        {
            string c_curricula_recert_id_fk = args.Trim();
            string c_curricula_recert_path_section_id_pk = args1.Trim();
            SystemCurriculumBLL.UpdateRecertUnCheckedEnforceCourse(c_curricula_recert_id_fk, c_curricula_recert_path_section_id_pk);

        }
        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
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
        //Get Path Section
        private void GetRecertPathSection()
        {
            dsGetPath = SystemCurriculumBLL.GetCurriculumRecertPathCourseSection(editCurriculumId, editCurriculumPath);

        }
        protected void chkRequired_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}