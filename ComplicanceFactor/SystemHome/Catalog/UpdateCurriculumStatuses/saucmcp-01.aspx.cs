using System;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text;
using ComplicanceFactor.Common.Languages;
using System.Globalization;

namespace ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses
{
    public partial class saucmcp_01 : System.Web.UI.Page
    {
        private static string editCurriculumId;
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divSuccess.Style.Add("display", "none");

                //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/UpdateCurriculumStatuses/saucsp-01.aspx>" + LocalResources.GetGlobalLabel("app_update_curriculum_statuses_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_curricula_details_page_text");

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/UpdateCurriculumStatuses/saucsp-01.aspx>" + LocalResources.GetGlobalLabel("app_update_curriculum_statuses_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_curricula_details_page_text");


                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {                     
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                }

                SessionWrapper.TempEmployeelist = null;
                SessionWrapper.SelectedEmployeelist = SelectedEmployee();
                

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editCurriculumId = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdnCurriculumId.Value = editCurriculumId;
                }
                BindPathDetails(editCurriculumId);

                ddlChangeStatus.DataSource = UpdateCurriculumStatusesBLL.GetStatus(SessionWrapper.CultureName);
                ddlChangeStatus.DataBind();
            }
            //Bind the Employee
            if (hdUpdatevalue.Value!="1")
            {
                gvEmployees.DataSource = SessionWrapper.TempEmployeelist;
                gvEmployees.DataBind();
            }

        }

        private void BindPathDetails(string editCurriculumId)
        {
            SystemCurriculum curriculum = new SystemCurriculum();
            curriculum = SystemCurriculumBLL.GetCurriculum(editCurriculumId, string.Empty);
            lblCurriculumTitle.Text = curriculum.c_curriculum_title + "(" + curriculum.c_curriculum_id_pk + ")";
            lblDescription.Text = curriculum.c_curriculum_desc;
            lblOwner.Text = curriculum.c_curriculum_owner_name;
            lblRevision.Text = curriculum.c_curriculum_version;
            lblCost.Text = curriculum.cost_text;
            lblCEU.Text = curriculum.c_curriculum_credit_hours.ToString();
            //lblRevision.Text = curriculum.
            gvPath.DataSource = SystemCurriculumBLL.GetCurriculumPathOnly(editCurriculumId);
            gvPath.DataBind();
            //GetCurriculumPathOnly
        }
        protected void gvPath_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                GridView gvSection = (GridView)e.Row.FindControl("gvSection");
                BindPathSection(gvSection, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString());
            }
        }

        private void BindPathSection(GridView GridView, string pathId, string curriculumId)
        {
            try
            {
                GridView.DataSource = SystemCurriculumBLL.GetSingleCurriculaPathSection(curriculumId, pathId);
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message);
                    }
                }
            }
        }

        protected void gvSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView GridView1 = (GridView)sender;
                GridView gvCourse = (GridView)e.Row.FindControl("gvCourse");
                BindPathCourse(gvCourse, GridView1.DataKeys[e.Row.RowIndex][0].ToString(), GridView1.DataKeys[e.Row.RowIndex][1].ToString());
            }
        }

        private void BindPathCourse(GridView GridView, string c_curricula_path_system_id_pk, string c_curricula_path_section_id_pk)
        {
            try
            {
                DataTable dtPathCourse = new DataTable();
                dtPathCourse = UpdateCurriculumStatusesBLL.GetCourse(c_curricula_path_system_id_pk, c_curricula_path_section_id_pk);

                ////DataView dvPathCourse = new DataView(SystemCurriculumBLL.GetSingleCurriculaPathCourse(CurriculumId, c_curricula_path_system_id_pk));
                //DataView dvPathCourse = new DataView(EnrollmentBLL.EnrollGetSingleCurriculaPathCourse(editCurriculumId, c_curricula_path_system_id_pk));
                //dvPathCourse.RowFilter = "c_curricula_path_section_id_fk= '" + c_curricula_path_section_id_pk + "'";
                //dvPathCourse.Sort = "c_curricula_path_course_seq_number ASC";
                //dtPathCourse = dvPathCourse.ToTable();
                GridView.DataSource = dtPathCourse;
                GridView.DataBind();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message);
                    }
                }
            }
        }          

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static void DeleteUser(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.TempEmployeelist.Select("u_user_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempEmployeelist.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message);
                    }
                }
            }
        }
        private DataTable SelectedEmployee()
        {
            DataTable dtTempEmployee = new DataTable();
            DataColumn dtTempEmployeeColumn;

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_user_id_pk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_first_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_last_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_hris_employee_id";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "e_enroll_status_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.Int32");
            dtTempEmployeeColumn.ColumnName = "e_curriculum_assign_percent_complete";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.Boolean");
            dtTempEmployeeColumn.ColumnName = "e_is_user_selected";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            return dtTempEmployee;
        }

        private void AddDataToEmployee(string u_user_id_pk, string firstName, string lastName, string employeeId, string status, string percent, DataTable dtTempEmployee)
        {
            DataRow row;
            row = dtTempEmployee.NewRow();
            row["u_user_id_pk"] = u_user_id_pk;
            row["u_first_name"] = firstName;
            row["u_last_name"] = lastName;
            row["u_hris_employee_id"] = employeeId;
            row["e_enroll_status_name"] = status;
            row["e_curriculum_assign_percent_complete"] = Convert.ToInt32(percent);
            row["e_is_user_selected"] = true;
            dtTempEmployee.Rows.Add(row);
        }

        protected void btnUpdateCurriculum_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvEmployees.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect.Checked == true)
                {
                    string u_user_id_pk = gvEmployees.DataKeys[row.RowIndex].Value.ToString();
                    var rows = SessionWrapper.TempEmployeelist.Select("u_user_id_pk= '" + u_user_id_pk + "'");
                    var indexOfRow = SessionWrapper.TempEmployeelist.Rows.IndexOf(rows[0]);
                    SessionWrapper.TempEmployeelist.Rows[indexOfRow]["e_is_user_selected"] = chkSelect.Checked;
                    SessionWrapper.TempEmployeelist.AcceptChanges();
                }
            }

            

            if (SessionWrapper.TempEmployeelist.Rows.Count > 0)
            {
                StringBuilder sbSelectedEmployee = new StringBuilder();
                var rows = SessionWrapper.TempEmployeelist.Select("e_is_user_selected=true");

                foreach (var row in rows)
                {
                    AddDataToEmployee(row["u_user_id_pk"].ToString(), row["u_first_name"].ToString(), row["u_last_name"].ToString(), row["u_hris_employee_id"].ToString(), row["e_enroll_status_name"].ToString(), row["e_curriculum_assign_percent_complete"].ToString(), SessionWrapper.SelectedEmployeelist);
                    sbSelectedEmployee.Append(row["u_first_name"].ToString() + " " + row["u_last_name"].ToString() + "(" + row["e_enroll_status_name"].ToString() + "-" + row["e_curriculum_assign_percent_complete"].ToString() + "%)<br/>");
                }
                selectedEmployee.InnerHtml = sbSelectedEmployee.ToString();
                lblStatus.Text = ddlChangeStatus.SelectedItem.Text;

                mpeCurriculumNotes.Show();
            }
            else
            {
                divError.Style.Add("display", "block");
                divError.InnerHtml = LocalResources.GetText("app_update_staus_for_user_error_empty");
            }

        }

        protected void btnSaveStatus_Click(object sender, EventArgs e)
        {
            //update curriculum status
            Enrollment curriculum = new Enrollment();
            CurriculumStatus statusHistory = new CurriculumStatus();

            //To get status change type id 
            string statustypeId = UpdateCurriculumStatusesBLL.GetStatusTypeId("User Manual Change");

            DataTable dt = new DataTable();
            dt = SessionWrapper.SelectedEmployeelist;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                curriculum = UpdateCurriculumStatusesBLL.GetAssignCourse(editCurriculumId, dt.Rows[i]["u_user_id_pk"].ToString());

                statusHistory.e_curriculum_assign_system_id_pk = Guid.NewGuid().ToString();
                statusHistory.e_curriculum_assign_user_id_fk = dt.Rows[i]["u_user_id_pk"].ToString();
                statusHistory.e_curriculum_assign_curriculum_id_fk = editCurriculumId;
                statusHistory.e_curriculum_assign_date_time = curriculum.e_curriculum_assign_date_time;
                statusHistory.e_curriculum_assign_required_flag = curriculum.e_curriculum_assign_required_flag;
                 DateTime? duedate = null;
                DateTime tempexpiredate;
                if (DateTime.TryParseExact(txtDueDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempexpiredate))
                {
                    duedate = tempexpiredate;
                }
                statusHistory.e_curriculum_assign_original_target_due_date = duedate;
               
                statusHistory.e_curriculum_assign_status_change_date_time = DateTime.UtcNow;
                statusHistory.e_curriculum_assign_after_status_id_fk = ddlChangeStatus.SelectedValue;
                statusHistory.e_curriculum_assign_cert_date = duedate;
                statusHistory.e_curriculum_assign_recert_due_date = duedate;
                statusHistory.e_curriculum_assign_recert_status_change_type_id_fk = statustypeId;
                statusHistory.e_curriculum_assign_recert_status_change_user_id_fk = SessionWrapper.u_userid;
                statusHistory.e_curriculum_before_status_id_fk = string.Empty;
                statusHistory.e_curriculum_assign_percent_complete = curriculum.e_curriculum_assign_percent_complete;
                statusHistory.e_curriculum_assign_active_flag = curriculum.e_curriculum_assign_active_flag;
                statusHistory.e_curriculum_status_change_notes = txtNotes.Text;

                try
                {
                    int resultvalue = UpdateCurriculumStatusesBLL.InsertHistory(statusHistory);
                    int result = UpdateCurriculumStatusesBLL.UpdateCurriculumStatuses(editCurriculumId, dt.Rows[i]["u_user_id_pk"].ToString(), duedate, ddlChangeStatus.SelectedValue, statustypeId, SessionWrapper.u_userid);
                    if (resultvalue == 0 && result == 0)
                    {
                        Response.Redirect("~/SystemHome/Catalog/UpdateCurriculumStatuses/saucmcp-01.aspx?id=" + SecurityCenter.EncryptText(editCurriculumId) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                    }
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saucmcp-01", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saucmcp-01", ex.Message);
                        }
                    }
                }
            }

        }

        //btnSavePin_Click
        protected void btnSavePin_Click(object sender, EventArgs e)
        {
            HashEncryption encHash = new HashEncryption();
            string encHashpwd = encHash.GenerateHashvalue(txtPassword.Text, true);
            string encHasusername = encHash.GenerateHashvalue(txtUserName.Text, true);

            try
            {
                int result = UpdateCurriculumStatusesBLL.UpdateUserPIN(encHasusername, encHashpwd, txtPinNumber.Text);
                if (result == 0)
                {
                    txtPin.Text = txtPinNumber.Text;
                    MpeCreatePin.Hide();
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saucmcp-01", ex.Message);
                    }
                }
            }
            mpeCurriculumNotes.Show();
        }

        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridView GridView1 = (GridView)sender;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string u_user_id_pk = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
            //    bool chk = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "e_is_user_selected"));
            //    Literal ltlcheck = (Literal)e.Row.FindControl("ltlcheck");
            //    if (chk == true)
            //    {
            //        ltlcheck.Text = "<input id=" + u_user_id_pk + " class='userselected cursor_hand' type='checkbox' checked='checked'/>";
            //    }
            //    else
            //    {
            //        ltlcheck.Text = "<input id=" + u_user_id_pk + " class='userselected cursor_hand' type='checkbox'/>";
            //    }
            //}
        }

        //[System.Web.Services.WebMethod]
        //public static void SelectedUser(string args, string args2)
        //{
        //    var rows = SessionWrapper.TempEmployeelist.Select("u_user_id_pk= '" + args.Trim() + "'");
        //    var indexOfRow = SessionWrapper.TempEmployeelist.Rows.IndexOf(rows[0]);
        //    SessionWrapper.TempEmployeelist.Rows[indexOfRow]["e_is_user_selected"] = Convert.ToBoolean(args2.Trim());
        //    SessionWrapper.TempEmployeelist.AcceptChanges();
        //}

        //protected void chkSelect_CheckedChanged1(object sender, EventArgs e)
        //{
        //    CheckBox chk = (CheckBox)sender;
        //    GridViewRow gr = (GridViewRow)chk.Parent.Parent;
        //    string userId = gvEmployees.DataKeys[gr.RowIndex].Value.ToString();

        //    var rows = SessionWrapper.TempEmployeelist.Select("u_user_id_pk= '" + userId + "'");
        //    foreach (var row in rows)
        //    {
        //        row["e_is_user_selected"] = chk.Checked;
        //    }
        //    SessionWrapper.TempEmployeelist.AcceptChanges();
        //}


    }
}