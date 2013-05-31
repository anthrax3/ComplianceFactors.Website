using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;
using System.Data;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Web.UI.HtmlControls;

namespace ComplicanceFactor.SystemHome.Catalog.MassCompletions
{
    public partial class samcp_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionWrapper.Compltion_courses = null;
                SessionWrapper.Compltion_employees = null;
                SessionWrapper.Selected_delivery = null;

                SessionWrapper.Selected_delivery = TempSelectedDelivery();

                string navigationText;
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_mass_completions_text");

            }
            if (SessionWrapper.Compltion_courses.Rows.Count > 0 && hdnIsCatalogBind.Value != "1")
            {
                gvCatalog.DataSource = SessionWrapper.Compltion_courses;
                gvCatalog.DataBind();
                hdnIsCatalogBind.Value = "1";
            }
            if (SessionWrapper.Compltion_employees.Rows.Count > 0)
            {
                gvEmployee.DataSource = SessionWrapper.Compltion_employees;
                gvEmployee.DataBind();
            }

        }

        protected void gvCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GridView1 = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string courseId = GridView1.DataKeys[e.Row.RowIndex][0].ToString();
                try
                {
                    DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                    ddlDelivery.DataSource = SystemMassCompletionBLL.GetDelivery(courseId);
                    ddlDelivery.DataBind();
                    ListItem liFirstItem = new ListItem();
                    liFirstItem.Text = "Select a Delivery";
                    ///liFirstItem.Value = "0";
                    ddlDelivery.Items.Insert(0, liFirstItem);
                    ddlDelivery.SelectedIndex = 0;


                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samcp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samcp-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }

        protected void btnProcessMassCompletion_Click(object sender, EventArgs e)
        {
            string attendanceStatus = string.Empty;
            string PassingStatus = string.Empty;
            string grade = string.Empty;    
       
            StringBuilder sbSelectedCourse = new StringBuilder();
            StringBuilder sbSelectedEmployee = new StringBuilder();
            StringBuilder sbSelectedCompletion = new StringBuilder();
            StringBuilder sbSelectedCompletionDate = new StringBuilder();
            //set the seleceted delivery 
            foreach (GridViewRow row in gvCatalog.Rows)
            {
                string c_course_system_id_pk = gvCatalog.DataKeys[row.RowIndex][0].ToString();
                DropDownList ddlDelivery = (DropDownList)row.FindControl("ddlDelivery");
                var rows = SessionWrapper.Compltion_courses.Select("c_course_system_id_pk = '" + c_course_system_id_pk + "'");
                foreach (var r in rows)
                {
                    r["c_delivery_system_id_pk"] = ddlDelivery.SelectedValue;
                    sbSelectedCourse.Append(r["c_course_title"].ToString() + " (" + r["c_course_id_pk"].ToString() + ")<br/>");
                    SessionWrapper.Compltion_courses.AcceptChanges();
                }
            }
            //get the selected employee
            foreach (GridViewRow row in gvEmployee.Rows)
            {
                string u_user_id_pk = gvEmployee.DataKeys[row.RowIndex][0].ToString();
                var rows = SessionWrapper.Compltion_employees.Select("u_user_id_pk ='" + u_user_id_pk + "'");
                foreach (var r in rows)
                {
                    sbSelectedEmployee.Append(r["u_username"].ToString() + r["u_hris_employee_id"].ToString() + "<br/>");
                }
            }
            //To get the completion status for show in popup
            foreach (GridViewRow row in gvCompletionInfo.Rows)
            {
                DropDownList ddlAttendanceStatus = (DropDownList)row.FindControl("ddlAttendanceStatus");
                DropDownList ddlPassignStatus = (DropDownList)row.FindControl("ddlPassignStatus");
                DropDownList ddlGrade = (DropDownList)row.FindControl("ddlGrade");
                TextBox txtCompletionDate = (TextBox)row.FindControl("txtCompletionDate");
                Label lblDelivery = (Label)row.FindControl("lblDeliveryIdName");
                attendanceStatus = ddlAttendanceStatus.SelectedItem.Text;
                PassingStatus = ddlPassignStatus.SelectedItem.Text;
                if (!string.IsNullOrEmpty(ddlGrade.SelectedValue))
                {
                    grade = ddlGrade.SelectedItem.Text;
                }
                sbSelectedCompletionDate.Append(lblDelivery.Text + " : " + txtCompletionDate.Text + "<br/>");
                sbSelectedCompletion.Append(lblDelivery.Text + " : " + attendanceStatus + " - " + PassingStatus + " - " + grade + "<br/>");
            }
            string pinNumber = UserBLL.GetUserPIN(SessionWrapper.u_userid);
            txtPin.Text = pinNumber;
            SelectedCourses.InnerHtml = sbSelectedCourse.ToString();
            selectedEmployee.InnerHtml = sbSelectedEmployee.ToString();
            lblStatus.Text = sbSelectedCompletion.ToString();
            lblCompletionDate.Text = sbSelectedCompletionDate.ToString();
            mpeCurriculumNotes.Show();
        }

        protected void gvCompletionInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DataRowView drheader = (DataRowView)e.Row.DataItem;
                    string Header = Convert.ToString(drheader["Id"]);

                    Label lblDelivery = (Label)e.Row.FindControl("lblDeliveryIdName");
                    lblDelivery.Text = Header;
                  
                    DataRowView drgrade = (DataRowView)e.Row.DataItem;
                    string deliveryId = Convert.ToString(drgrade["c_delivery_id_pk"]);

                    DropDownList ddlGrade = (DropDownList)e.Row.FindControl("ddlGrade");
                    ddlGrade.DataSource = ManageCompletionBLL.GetGrade(deliveryId);
                    ddlGrade.DataBind();

                    DropDownList ddlAttendance = (DropDownList)e.Row.FindControl("ddlAttendanceStatus");
                    ddlAttendance.DataSource = ManageCompletionBLL.GetAttendanceStatus(SessionWrapper.CultureName, "samcsmp-01");
                    ddlAttendance.DataBind();

                    DropDownList ddlPassingStatus = (DropDownList)e.Row.FindControl("ddlPassignStatus");
                    ddlPassingStatus.DataSource = ManageCompletionBLL.GetPassingStatus(SessionWrapper.CultureName, "samcsmp-01");
                    ddlPassingStatus.DataBind();
                }
                catch (Exception ex)
                {
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("samcp-01.aspx", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("samcp-01.aspx", ex.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// It's For When I select the delivery in catalog item,In completion information shows the grade 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="id"></param>
        /// <param name="c_delivery_id_pk"></param>
        /// <param name="dtTempSelectedDeliveries"></param>
        private void AddDataToSelectedDeliveries(int idx, string id, string c_delivery_id_pk, DataTable dtTempSelectedDeliveries)
        {
            DataRow[] getrow = dtTempSelectedDeliveries.Select("RowIndex=" + idx);
            if (getrow.Length > 0)
            {
                foreach (var updaterow in getrow)
                {
                    updaterow["c_delivery_id_pk"] = c_delivery_id_pk;
                    updaterow["Id"] = id;
                }
            }
            else
            {
                DataRow row;
                row = dtTempSelectedDeliveries.NewRow();
                //row["c_instructor_id_fk"] = c_instructor_id_fk;
                row["Id"] = id;
                row["RowIndex"] = idx;
                row["c_delivery_id_pk"] = c_delivery_id_pk;
                dtTempSelectedDeliveries.Rows.Add(row);
            }
        }
        protected void btnSaveStatus_Click(object sender, EventArgs e)
        {
            string deliveryType = string.Empty;
            string deliveryID = string.Empty;
            string passingStatus = string.Empty;
            string grade = string.Empty;

            //For get the completion status and session emplyee/course
            DataTable dtCompletionStatus = TempCompletionStatus();

            // To Calculate the Attendance Passing Status 
            foreach (GridViewRow row in gvCompletionInfo.Rows)
            {
                string c_delivery_id_pk = gvCompletionInfo.DataKeys[row.RowIndex][0].ToString();
                DropDownList ddlAttendance = (DropDownList)row.FindControl("ddlAttendanceStatus");
                DropDownList ddlPassingStatus = (DropDownList)row.FindControl("ddlPassignStatus");
                DropDownList ddlGrade = (DropDownList)row.FindControl("ddlGrade");
                TextBox txtscore = (TextBox)row.FindControl("txtScore");
                TextBox txtCompletionDate = (TextBox)row.FindControl("txtCompletionDate");
                if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                {
                    //do calculation and change the Passing status Grading Scheme
                    SystemGradingSchemes gradevalues = new SystemGradingSchemes();
                    gradevalues = ManageCompletionBLL.GetGradeByScore(c_delivery_id_pk, Convert.ToInt32(txtscore.Text));
                    if (!string.IsNullOrEmpty(gradevalues.s_grading_scheme_value_pass_status_id_fk))
                    {
                        if (gradevalues.s_grading_scheme_value_pass_status_id_fk == "app_ddl_pass_text")
                        {
                            passingStatus = "app_ddl_passed_text";
                        }
                        else
                        {
                            passingStatus = "app_ddl_failed_text";
                        }
                        grade = gradevalues.s_grading_scheme_system_value_id_pk;
                    }
                    else
                    {
                        passingStatus = ddlPassingStatus.SelectedValue;
                        grade = ddlGrade.SelectedValue;
                    }
                }
                else
                {
                    passingStatus = ddlPassingStatus.SelectedValue;
                    grade = ddlGrade.SelectedValue;
                }
                DataRow Completionrow;
                Completionrow = dtCompletionStatus.NewRow();
                Completionrow["c_delivery_id_pk"] = c_delivery_id_pk;
                Completionrow["t_transcript_attendance_id_fk"] = ddlAttendance.SelectedValue;
                Completionrow["t_transcript_passing_status_id_fk"] = passingStatus;
                if (!string.IsNullOrEmpty(grade))
                {
                    Completionrow["t_transcript_grade_id_fk"] = grade;
                }
                else
                {
                    Completionrow["t_transcript_grade_id_fk"] = DBNull.Value;
                }
                if (!string.IsNullOrEmpty(txtscore.Text) && !string.IsNullOrWhiteSpace(txtscore.Text))
                {
                    Completionrow["t_transcript_completion_score"] = txtscore.Text;
                }
                else
                {
                    Completionrow["t_transcript_completion_score"] = 0;
                }
                Completionrow["attendance_value"] = ddlAttendance.SelectedItem.Text;
                Completionrow["passsingstatusValue"] = ddlPassingStatus.SelectedItem.Text;
                Completionrow["gradeValue"] =  ddlGrade.SelectedItem.Text;
                Completionrow["t_transcript_completion_date_time"] = txtCompletionDate.Text;
                dtCompletionStatus.Rows.Add(Completionrow);
            }

            //This datatable was converted to xml so we merge the all session course and session employee and Completion status
            DataTable dtCourseCompletion = TempCourseCompletionDatatable();

            //To merge the two session wrappers in to one
            for (int i = 0; i < SessionWrapper.Compltion_courses.Rows.Count; i++)
            {
                DropDownList ddlDelivery = (DropDownList)gvCatalog.Rows[i].FindControl("ddlDelivery");
                deliveryID = ddlDelivery.SelectedValue;
                deliveryType = SystemWaitListBLL.GetDeliveryType(ddlDelivery.SelectedValue);
                for (int k = 0; SessionWrapper.Compltion_employees.Rows.Count > k; k++)
                {
                    DataRow courserow;
                    courserow = dtCourseCompletion.NewRow();
                    courserow["c_course_id_pk"] = SessionWrapper.Compltion_courses.Rows[i]["c_course_system_id_pk"].ToString();
                    courserow["c_delivery_id_pk"] = ddlDelivery.SelectedValue;
                    courserow["u_user_id_pk"] = SessionWrapper.Compltion_employees.Rows[k]["u_user_id_pk"].ToString();
                    courserow["delivery_type"] = deliveryType;
                    courserow["t_transcript_attendance_id_fk"] = dtCompletionStatus.Rows[i]["t_transcript_attendance_id_fk"].ToString(); //GetAttendance( ddlDelivery.SelectedValue,dtCompletionStatus);
                    courserow["t_transcript_passing_status_id_fk"] = dtCompletionStatus.Rows[i]["t_transcript_passing_status_id_fk"].ToString();
                    courserow["t_transcript_grade_id_fk"] = dtCompletionStatus.Rows[i]["t_transcript_grade_id_fk"].ToString();
                    courserow["t_transcript_completion_score"] = dtCompletionStatus.Rows[i]["t_transcript_completion_score"].ToString();
                    courserow["t_transcript_completion_date_time"] = dtCompletionStatus.Rows[i]["t_transcript_completion_date_time"].ToString();
                    courserow["attendance_value"] = dtCompletionStatus.Rows[i]["attendance_value"].ToString();
                    courserow["passsingstatusValue"] = dtCompletionStatus.Rows[i]["passsingstatusValue"].ToString();
                    courserow["gradeValue"] = dtCompletionStatus.Rows[i]["gradeValue"].ToString();
                    dtCourseCompletion.Rows.Add(courserow);
                }
            }
            //To pass the transcripts to BLL
            SystemTranscripts transcripts = new SystemTranscripts();
            transcripts.t_transcript_id_pk = Guid.NewGuid().ToString();
            transcripts.t_transcript_assign_id_fk = string.Empty;
            transcripts.t_transcript_enroll_id_fk = string.Empty;            
            transcripts.t_transcript_completion_date_time = DateTime.UtcNow;
            transcripts.t_transcript_completion_type_id_fk = "app_ddl_manual_user_mark_completion_text";//doubt
            transcripts.t_transcript_marked_by_user_id_fk = SessionWrapper.u_userid;
            transcripts.t_transcript_required_flag = true;
            transcripts.t_transcript_target_due_date = DateTime.Now; //Target date
            transcripts.t_transcript_actual_date = DateTime.Now; //Actual date  
            transcripts.t_transcript_status_name = "Completed"; 
            transcripts.t_transcript_time_spent = 0;
            transcripts.t_transcript_score = 0;
            transcripts.t_transcript_credits = 0;
            transcripts.t_transcript_hours = 0;
            transcripts.t_transcript_active_flag = true;
            transcripts.mass_completion = ConvertDataTableToXml(dtCourseCompletion);
            //Audit Log
            string strIPAddress = string.Empty;
            strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIPAddress == "" || strIPAddress == null)
                strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            transcripts.Userid = SessionWrapper.u_userid;
            transcripts.user_type = SessionWrapper.u_user_type;
            transcripts.user_detail = SessionWrapper.u_lastname + ' ' + SessionWrapper.u_firstname + ' ' + SessionWrapper.u_middlename;
            transcripts.action_desc = "Marked Completion";       
            transcripts.ipaddress = strIPAddress;
            transcripts.device = Request.UserAgent;

            try
            {
                int result = SystemMassCompletionBLL.MassCompletion(transcripts);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = "Courses Completed Successfully";
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcp-01.aspx", ex.Message);
                    }
                }
            }
        }

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
                        Logger.WriteToErrorLog("samcp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcp-01.aspx", ex.Message);
                    }
                }
            }
            mpeCurriculumNotes.Show();
        }
        //Delete Employee
        [System.Web.Services.WebMethod]
        public static void DeleteEmployee(string args)
        {
            try
            {

                //Delete previous selected course
                var rows = SessionWrapper.Compltion_employees.Select("u_user_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Compltion_employees.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcp-01", ex.Message);
                    }
                }
            }
        }
        //Delete Course
        [System.Web.Services.WebMethod]
        public static void DeleteCourse(string args)
        {
            try
            {
                //Delete previous selected course
                var rows = SessionWrapper.Compltion_courses.Select("c_course_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.Compltion_employees.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("samcp-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("samcp-01", ex.Message);
                    }
                }
            }

        }

        protected void ddlDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCurrentDropDownList = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCurrentDropDownList.Parent.Parent;
            int idx = row.RowIndex;
            AddDataToSelectedDeliveries(idx, ddlCurrentDropDownList.SelectedItem.Text, Convert.ToString(ddlCurrentDropDownList.SelectedValue), SessionWrapper.Selected_delivery);

            DataView dv = new DataView();
            dv = SessionWrapper.Selected_delivery.DefaultView;
            dv.Sort = "RowIndex asc";

            DataTable dt = dv.ToTable();

            gvCompletionInfo.DataSource = dt;
            gvCompletionInfo.DataBind();
        }

        private DataTable TempCompletionStatus()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;
            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "c_delivery_id_pk";
            dt.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_attendance_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_passing_status_id_fk";
            dt.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_grade_id_fk";           
            dt.Columns.Add(dtColumn);
            dt.Columns["t_transcript_grade_id_fk"].AllowDBNull = true;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_completion_score";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.DateTime");
            dtColumn.ColumnName = "t_transcript_completion_date_time";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "attendance_value";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "passsingstatusValue";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "gradeValue";
            dt.Columns.Add(dtColumn);

            return dt;
        }
        private DataTable TempSelectedDelivery()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "Id";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.Int32");
            dtColumn.ColumnName = "RowIndex";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "c_delivery_id_pk";
            dt.Columns.Add(dtColumn);
            return dt;
        }
        private DataTable TempCourseCompletionDatatable()
        {
            DataTable dt = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "c_course_id_pk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "c_delivery_id_pk";
            dt.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "u_user_id_pk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "delivery_type";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_attendance_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_passing_status_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_grade_id_fk";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_completion_score";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "t_transcript_completion_date_time";
            dt.Columns.Add(dtColumn);
            

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "attendance_value";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "passsingstatusValue";
            dt.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "gradeValue";
            dt.Columns.Add(dtColumn);

            return dt;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/samcmp-01.aspx");
        }
    }
}