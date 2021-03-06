﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.RecertPath
{
    public partial class p_sacrp_01 : System.Web.UI.Page
    {
        private string editCurriculumId;
        private string lastsectionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //clear curriculum path recertification and course session
                clearCurriculum();
                //bind temp recert path section
                SessionWrapper.TempRecertPathSection = TempDataTables.TempRecertPathSection();
                //bind temp recert path course
                SessionWrapper.TempRecertPathCourse = TempDataTables.TempRecertPathCourse();
                if (SessionWrapper.TempRecertPathSection.Rows.Count == 0)
                {
                    AddEmptyPathSection(SessionWrapper.TempRecertPathSection);
                    SessionWrapper.Active_Popup = "true";
                }


            }
            if (!string.IsNullOrEmpty(SessionWrapper.Active_Popup))
            {
                BindRecertPathandSection();
                SessionWrapper.Active_Popup = string.Empty;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["editCurriculumId"]))
            {
                editCurriculumId = Request.QueryString["editCurriculumId"];


            }
        }
        private void BindRecertPathandSection()
        {
            //Bind curriculum path section
            dlSection.DataSource = SessionWrapper.TempRecertPathSection;
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
        private void clearCurriculum()
        {
            SessionWrapper.TempRecertPathCourse.Clear();
            SessionWrapper.TempRecertPathSection.Clear();

        }
        //bind curriculum path course
        private void BindPathCourse(GridView GridView, string c_curricula_recert_path_section_id_fk)
        {
            try
            {
                DataTable dtPathCourse = new DataTable();
                //Get particular course from section
                DataView dvPathCourse = new DataView(SessionWrapper.TempRecertPathCourse);
                dvPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk + "'";
                dvPathCourse.Sort = "c_curricula_recert_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                if (dtPathCourse.Rows.Count == 0)
                {
                    DataRow row;
                    row = dtPathCourse.NewRow();
                    row["c_curricula_recert_path_section_id_fk"] = c_curricula_recert_path_section_id_fk;
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
                        Logger.WriteToErrorLog("p-sacrp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sacrp-01.aspx", ex.Message);
                    }
                }
            }

        }
        protected void dlSection_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            Label lblSectionNumber = e.Item.FindControl("lblSectionNumber") as Label;
            int seqHazard = Convert.ToInt32(e.Item.ItemIndex) + 1;
            lblSectionNumber.Text = LocalResources.GetLabel("app_section_text") + seqHazard + ":";
            GridView gvCourse = (GridView)e.Item.FindControl("gvCourse");
            BindPathCourse(gvCourse, dlSection.DataKeys[e.Item.ItemIndex].ToString());


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
                Literal ltlcheck = (Literal)e.Row.FindControl("ltlcheck");
                if (c_curricula_recert_path_required == "1")
                {
                    ltlcheck.Text = "<input id=" + c_curricula_recert_path_course_id_fk + ',' + c_curricula_recert_path_section_id_fk + " class='couserequired cursor_hand' type='checkbox' checked='checked'/>";
                }
                else
                {
                    ltlcheck.Text = "<input id=" + c_curricula_recert_path_course_id_fk + ',' + c_curricula_recert_path_section_id_fk + " class='couserequired cursor_hand' type='checkbox'/>";
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string c_curricula_recert_path_section_id_pk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();

                e.Row.Cells[0].Text = "<input id=" + c_curricula_recert_path_section_id_pk + " class='newcourse cursor_hand' type='button' value='" + LocalResources.GetLabel("app_add_course_button_text") + "'/>";

            }
        }
        /// <summary>
        /// Show Add course button if path section is empty
        /// </summary>
        /// <param name="dtEmptyPathSection"></param>
        private void AddEmptyPathSection(DataTable dtEmptyPathSection)
        {
            DataRow drEmptyPathSection;
            drEmptyPathSection = dtEmptyPathSection.NewRow();
            drEmptyPathSection["c_curricula_recert_path_section_id_pk"] = Guid.NewGuid().ToString();
            dtEmptyPathSection.Rows.Add(drEmptyPathSection);
            dtEmptyPathSection.AcceptChanges();

        }
        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            int count = SessionWrapper.TempRecertPathSection.Rows.Count;
            if (count > 0)
            {
                lastsectionId = SessionWrapper.TempRecertPathSection.Rows[count - 1]["c_curricula_recert_path_section_id_pk"].ToString();
            }
            DataTable dtPathsection = new DataTable();
            DataView dvPathCourse = new DataView(SessionWrapper.TempRecertPathCourse);
            dvPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + lastsectionId.Trim() + "'";
            dtPathsection = dvPathCourse.ToTable();

            if (dtPathsection.Rows.Count > 0)
            {
                AddEmptyPathSection(SessionWrapper.TempRecertPathSection);
                BindRecertPathandSection();
            }
            else
            {
                string str = "<script>alert(\"Please add atleast one course in above section\");</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
            }

            //AddEmptyPathSection(SessionWrapper.TempRecertPathSection);
            //Bind curriculum path section
            //BindRecertPathandSection();
        }
        /// <summary>
        /// Down course
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DownCourse(string args, string args1)
        {
            try
            {
                var rows = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_course_id_fk= '" + args + "'");
                var indexOfRow = SessionWrapper.TempRecertPathCourse.Rows.IndexOf(rows[0]);
                SessionWrapper.TempRecertPathCourse.Rows[indexOfRow]["c_curricula_recert_path_course_seq_number"] = Convert.ToInt32(args1) + 1;
                SessionWrapper.TempRecertPathCourse.Rows[indexOfRow + 1]["c_curricula_recert_path_course_seq_number"] = args1;
                SessionWrapper.TempRecertPathCourse.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("p-sacrp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sacrp-01.aspx", ex.Message);
                    }
                }
            }


        }
        [System.Web.Services.WebMethod]
        public static void UpCourse(string args, string args1)
        {
            try
            {
                var rows = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_course_id_fk= '" + args + "'");
                var indexOfRow = SessionWrapper.TempRecertPathCourse.Rows.IndexOf(rows[0]);
                if (indexOfRow > 0)
                {
                    SessionWrapper.TempRecertPathCourse.Rows[indexOfRow]["c_curricula_recert_path_course_seq_number"] = Convert.ToInt32(args1) - 1;
                    SessionWrapper.TempRecertPathCourse.Rows[indexOfRow - 1]["c_curricula_recert_path_course_seq_number"] = args1;
                    SessionWrapper.TempRecertPathCourse.AcceptChanges();
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
                        Logger.WriteToErrorLog("p-sacrp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sacrp-01.aspx", ex.Message);
                    }
                }
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
                var rows = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_course_id_fk= '" + c_curricula_recert_path_course_id_fk.Trim() + "' and c_curricula_recert_path_section_id_fk='" + c_curricula_recert_path_section_id_fk.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempRecertPathCourse.AcceptChanges();

            }
            else if (e.CommandName.Equals("Up"))
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();
                int gvRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string c_curricula_recert_path_course_id_fk = GridView1.DataKeys[gvRowIndex][0].ToString();
                string c_curricula_recert_path_course_seq_number = GridView1.DataKeys[gvRowIndex][1].ToString();
                //sort the course then get the index of the course
                DataTable dtPathCourse = new DataTable();
                //Get particular course from section
                DataView dvPathCourse = new DataView(SessionWrapper.TempRecertPathCourse);
                dvPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk + "'";
                dvPathCourse.Sort = "c_curricula_recert_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                //get current index
                var rows = dtPathCourse.Select("c_curricula_recert_path_section_id_fk='" + c_curricula_recert_path_section_id_fk + "' and c_curricula_recert_path_course_id_fk= '" + c_curricula_recert_path_course_id_fk.Trim() + "'", "c_curricula_recert_path_course_seq_number ASC");
                var indexOfRow = dtPathCourse.Rows.IndexOf(rows[0]);
                if (indexOfRow > 0)
                {
                    //update
                    dtPathCourse.Rows[indexOfRow]["c_curricula_recert_path_course_seq_number"] = Convert.ToInt32(c_curricula_recert_path_course_seq_number) - 1;
                    dtPathCourse.Rows[indexOfRow - 1]["c_curricula_recert_path_course_seq_number"] = c_curricula_recert_path_course_seq_number;
                    dtPathCourse.AcceptChanges();

                    var rows1 = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk.Trim() + "'");
                    foreach (var row in rows1)
                        row.Delete();
                    SessionWrapper.TempRecertPathCourse.AcceptChanges();
                    SessionWrapper.TempRecertPathCourse.Merge(dtPathCourse);

                }

            }
            else if (e.CommandName.Equals("Down"))
            {
                GridView GridView1 = (GridView)sender;
                DataListItem dlItem = (DataListItem)GridView1.Parent;
                DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();
                int gvRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string c_curricula_recert_path_course_id_fk = GridView1.DataKeys[gvRowIndex][0].ToString();
                string c_curricula_recert_path_course_seq_number = GridView1.DataKeys[gvRowIndex][1].ToString();
                //sort the course then get the index of the course
                DataTable dtPathCourse = new DataTable();
                //Get particular course from section
                DataView dvPathCourse = new DataView(SessionWrapper.TempRecertPathCourse);
                dvPathCourse.RowFilter = "c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk + "'";
                dvPathCourse.Sort = "c_curricula_recert_path_course_seq_number ASC";
                dtPathCourse = dvPathCourse.ToTable();
                //get current index
                var rows = dtPathCourse.Select("c_curricula_recert_path_section_id_fk='" + c_curricula_recert_path_section_id_fk + "' and c_curricula_recert_path_course_id_fk= '" + c_curricula_recert_path_course_id_fk + "'", "c_curricula_recert_path_course_seq_number ASC");
                var indexOfRow = dtPathCourse.Rows.IndexOf(rows[0]);
                //updtae
                dtPathCourse.Rows[indexOfRow]["c_curricula_recert_path_course_seq_number"] = Convert.ToInt32(c_curricula_recert_path_course_seq_number) + 1;
                dtPathCourse.Rows[indexOfRow + 1]["c_curricula_recert_path_course_seq_number"] = c_curricula_recert_path_course_seq_number;
                dtPathCourse.AcceptChanges();
                //delete
                var rows1 = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_section_id_fk= '" + c_curricula_recert_path_section_id_fk.Trim() + "'");
                foreach (var row in rows1)
                    row.Delete();
                SessionWrapper.TempRecertPathCourse.AcceptChanges();
                SessionWrapper.TempRecertPathCourse.Merge(dtPathCourse);
            }
            BindRecertPathandSection();
        }
        protected void btnSavePath_Click(object sender, EventArgs e)
        {
            try
            {
                SystemCurriculum recertPath = new SystemCurriculum();
                recertPath.c_curricula_recert_path_system_id_pk = Guid.NewGuid().ToString();
                recertPath.c_curricula_recert_id_fk = editCurriculumId;
                recertPath.c_curricula_recert_path_name = txtPathName.Text;
                recertPath.c_curricula_recert_path_Description = txtDescription.Value;
                recertPath.c_curricula_recert_path_abstract = txtAbstract.Value;
                recertPath.c_curricula_recert_path_enforce_section_seq_flag = chkHeaderEnforceSectionsSequence.Checked;
                recertPath.c_curricula_recert_path_complete = Convert.ToInt32(txtComplete.Text);
                recertPath.c_curricula_recert_path_sections = Convert.ToInt32(lblSectionCount.Text);

                for (int i = 0; i < dlSection.Items.Count; i++)
                {
                    TextBox txtCourseComplete = (TextBox)dlSection.Items[i].FindControl("txtCourseComplete");
                    Label lblCourse = (Label)dlSection.Items[i].FindControl("lblCourse");
                    CheckBox chkEnforceSectionsSequence = (CheckBox)dlSection.Items[i].FindControl("chkEnforceSectionsSequence");
                    SessionWrapper.TempRecertPathSection.Rows[i]["c_curricula_recert_path_section_complete"] = txtCourseComplete.Text;
                    SessionWrapper.TempRecertPathSection.Rows[i]["c_curricula_recert_path_section_courses"] = lblCourse.Text;
                    SessionWrapper.TempRecertPathSection.Rows[i]["c_curricula_recert_path_section_enforce_seq_flag"] = chkEnforceSectionsSequence.Checked;
                    SessionWrapper.TempRecertPathSection.AcceptChanges();
                }
                recertPath.c_curricula_recert_path_section = ConvertDataTableToXml(SessionWrapper.TempRecertPathSection);
                recertPath.c_curricula_recert_path_courses = ConvertDataTableToXml(SessionWrapper.TempRecertPathCourse);
                int result = SystemCurriculumBLL.InsertCurriculaRecertPath(recertPath);
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
                        Logger.WriteToErrorLog("p-sacrp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("p-sacrp-01", ex.Message);
                    }
                }
            }
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
        [System.Web.Services.WebMethod]
        public static void CourseRequired(string args, string args1, string args2)
        {
            var rows = SessionWrapper.TempRecertPathCourse.Select("c_curricula_recert_path_section_id_fk='" + args1.Trim() + "' and c_curricula_recert_path_course_id_fk= '" + args.Trim() + "'");
            var indexOfRow = SessionWrapper.TempRecertPathCourse.Rows.IndexOf(rows[0]);
            SessionWrapper.TempRecertPathCourse.Rows[indexOfRow]["c_curricula_recert_path_required"] = Convert.ToBoolean(args2.Trim());
            SessionWrapper.TempRecertPathCourse.AcceptChanges();
        }
        protected void chkRequired_CheckChanged(object sender, EventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            DataListItem dlItem = (DataListItem)GridView1.Parent;
            DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
            string c_curricula_recert_path_section_id_fk = dlSection.DataKeys[dle.Item.ItemIndex].ToString();
            string c_curricula_recert_path_course_id_fk = GridView1.DataKeys[1][0].ToString();



        }

    }
}