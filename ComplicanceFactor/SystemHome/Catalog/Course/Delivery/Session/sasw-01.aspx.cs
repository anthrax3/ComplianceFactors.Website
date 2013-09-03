using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Globalization;
using System.Data;
using System.Collections;
using ComplicanceFactor.BusinessComponent;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Popup
{
    public partial class sasw_01 : BasePage
    {
        #region
        private static bool result;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //Hide validation summary on other popup appear
                vs_sasw.Style.Add("display", "none"); 
                if (!IsPostBack)
                {
                    //clear session 
                    ClearSession();
                    //Add column in SessionWrapper.TempDeliveryInstructor datatable
                    SessionWrapper.TempDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                    SessionWrapper.TempAddDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                    SessionWrapper.TempDeliverySessions = TempDataTables.TempDeliverySessions();
                    //Set unique id for c_session_system_id_pk
                    SessionWrapper.c_session_system_id_pk = Guid.NewGuid().ToString();
                    //Respect Hoilidays Schedule
                    ddlRespectHolidays.DataSource = SystemCatalogBLL.GetAllHolidaySchedule();
                    ddlRespectHolidays.DataBind();
                    //Respect Weekdays Schedule
                    ddlRespectWeekDays.DataSource = SystemCatalogBLL.GetAllWeekdaySchedule();
                    ddlRespectWeekDays.DataBind();
                }
                //Get location
                lblLocation.Text = SessionWrapper.c_location_name;
                //Get facility
                lblFacility.Text = SessionWrapper.c_facility_name;
                //Get room
                lblRoom.Text = SessionWrapper.c_room_name;
                //Bind instructor
                if (Request.QueryString["page"].ToString() == "sasw")
                {
                    if (hdValue.Value != "0" || string.IsNullOrEmpty(hdValue.Value))
                    {
                        gvInstructor.DataSource = SessionWrapper.TempDeliveryInstructor;
                        gvInstructor.DataBind();
                        hdValue.Value = string.Empty;
                    }
                }
                //else
                //{
                //    if (hdValue.Value == "1" || string.IsNullOrEmpty(hdValue.Value) && !string.IsNullOrEmpty(Request.QueryString["editcourseid"].ToString()))
                //    {
                //        gvInstructor.DataSource = SessionWrapper.TempDeliveryInstructor;
                //        gvInstructor.DataBind();
                //        hdValue.Value = null;
                //    }
                //}

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasw-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasw-01.aspx", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Delete instructor
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteInstructor(string args)
        {

            try
            {

                //Delete select instructor
                var rows = SessionWrapper.TempDeliveryInstructor.Select("c_instructor_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.TempDeliveryInstructor.AcceptChanges();



            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasw-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasw-01.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// clear session
        /// </summary>
        private void ClearSession()
        {
            SessionWrapper.c_session_facility_id_fk = string.Empty;
            SessionWrapper.c_session_location_id_fk = string.Empty;
            SessionWrapper.c_session_room_id_fk = string.Empty;
            SessionWrapper.c_location_name = "";
            SessionWrapper.c_location_system_id_pk = "";
            SessionWrapper.c_facility_system_id_pk = "";
            SessionWrapper.c_facility_name = "";
            SessionWrapper.c_room_system_id_pk = "";
            SessionWrapper.c_room_name = "";
            SessionWrapper.c_session_system_id_pk = "";
            SessionWrapper.TempDeliveryInstructor = null;
            SessionWrapper.TempAddDeliveryInstructor = null;
            SessionWrapper.TempDeliverySessions = null;
            // SessionWrapper.TempDeliverySessions = null;
        }
        /// <summary>
        /// Generate session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerateSession_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvInstructor.Rows)
            {

                DropDownList ddlInstrcdtorType = (DropDownList)row.FindControl("ddlInstrcdtorType");
                string c_user_id_fk = gvInstructor.DataKeys[row.RowIndex].Value.ToString();
                var rows = SessionWrapper.TempDeliveryInstructor.Select("c_user_id_fk='" + c_user_id_fk + "'");
                var indexOfRow = SessionWrapper.TempDeliveryInstructor.Rows.IndexOf(rows[0]);
                SessionWrapper.TempDeliveryInstructor.Rows[indexOfRow]["c_instructor_type_id_fk"] = ddlInstrcdtorType.SelectedValue;
                SessionWrapper.TempDeliveryInstructor.AcceptChanges();
            }

            result = SystemCatalogBLL.checkMaximumOnePrimaryInstructors(ConvertDataTableToXml(SessionWrapper.TempDeliveryInstructor));
            if (!result)
            {
                divError.Style.Add("display", "Block");
                divError.InnerHtml = LocalResources.GetText("app_instructor_type_in_session_error_wrong");
            }
            else
            {
                //var row1 = SessionWrapper.TempDeliveryInstructor.Select("c_instructor_type_id_fk);
                //var getrow = SessionWrapper.TempDeliveryInstructor.Select("c_instructor_type_id_fk='" + nnn + "'");
                CultureInfo culture = new CultureInfo("en-US");
                //Create session without recurrance parameter
                CreateSession(txtStartDate.Text, txtEndDate.Text);

                //Close fancybox
                Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
            }
        }
        /// <summary>
        /// CreateSession
        /// </summary>
        /// <param name="strStartDate,strStartEndDate"></param>
        /// <returns></returns>
        private void CreateSession(string strStartDate, string strEndDate)
        {
            CultureInfo culture = new CultureInfo("en-US");
            //Aug 31,2012 
            SessionRecurrance recurrance = new SessionRecurrance();
            DataTable dtSessionRecurrance = new DataTable();
            if (rbtnRecurrancePattern.SelectedItem.Value == "daily")
            {
                dtSessionRecurrance = recurrance.Daily(txtStartDate.Text, txtEndDate.Text, txtStartFrom.Text, txtRecurranceEveryDaily.Text, txtBreakOccurencesCount.Text, txtBreakOccurranceDate.Text, chkRespectWeekDays.Checked, chkRespectHolidays.Checked, ddlRespectHolidays.SelectedValue, ddlRespectWeekDays.SelectedValue);

            }
            else if (rbtnRecurrancePattern.SelectedItem.Value == "weekly")
            {
                dtSessionRecurrance = recurrance.Weekly(txtStartDate.Text, txtEndDate.Text, txtStartFrom.Text, txtRecurranceEveryWeekly.Text, txtBreakOccurencesCount.Text, txtBreakOccurranceDate.Text, chkWeeklyLst.Items[0].Selected, chkWeeklyLst.Items[1].Selected, chkWeeklyLst.Items[2].Selected, chkWeeklyLst.Items[3].Selected, chkWeeklyLst.Items[4].Selected, chkWeeklyLst.Items[5].Selected, chkWeeklyLst.Items[6].Selected);
            }
            else if (rbtnRecurrancePattern.SelectedItem.Value == "monthly")
            {
                dtSessionRecurrance = recurrance.Monthly(txtStartDate.Text, txtEndDate.Text, txtStartFrom.Text, txtRecurranceEveryMonthly.Text, txtBreakOccurencesCount.Text, txtBreakOccurranceDate.Text, ddlMonths.SelectedItem.Text, ddlDays.SelectedItem.Text);
            }
            else if (rbtnRecurrancePattern.SelectedItem.Value == "yearly")
            {
                dtSessionRecurrance = recurrance.Yearly(txtStartDate.Text, txtEndDate.Text, txtStartFrom.Text, txtRecurranceEveryYearly.Text, txtBreakOccurencesCount.Text, txtBreakOccurranceDate.Text, txtYearly.Text);
            }

            //End

            if (SessionWrapper.TempDeliveryInstructor.Rows.Count > 0)
            {
                SessionWrapper.TempAddDeliveryInstructor = SessionWrapper.TempDeliveryInstructor;
                SessionWrapper.TempDeliveryInstructor = null;
                SessionWrapper.TempDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
            }
            int count = 1;
            foreach (DataRow drDates in dtSessionRecurrance.Rows)
            {
                string strSessionDateTime = Convert.ToDateTime(drDates["Dates"], culture).ToString("MM/dd/yyyy", culture) + " - " + txtStartTime.Text + " to " + Convert.ToDateTime(drDates["Dates"], culture).ToString("MM/dd/yyyy", culture) + " - " + txtEndTime.Text;
                AddDataToDeliverySessions(MakeIntoSequence(count, txtId.Text), SessionWrapper.c_delivery_system_id_pk, txtTitle.Text, txtDescription.Value, drDates["Dates"].ToString(), drDates["Dates"].ToString(), ConvertStringToTimeFormat(txtStartTime.Text), ConvertStringToTimeFormat(txtEndTime.Text), txtDuration.Text, SessionWrapper.c_session_location_id_fk, SessionWrapper.c_session_facility_id_fk, SessionWrapper.c_session_room_id_fk, SessionWrapper.c_location_name, SessionWrapper.c_facility_name, SessionWrapper.c_room_name, strSessionDateTime, SessionWrapper.TempDeliverySessions);
                count++;
            }
            //clear rows in SessionWrapper.TempAddDeliveryInstructor
            SessionWrapper.TempAddDeliveryInstructor = null;

            ////For every 1 days
            //CultureInfo culture = new CultureInfo("en-US");
            //string daily = string.Empty;
            //DateTime? dtSessionStartDate = null;
            //DateTime tempSessionStartDate;
            //DateTime? dtSessionEndDate = null;
            //DateTime tempSessionEndDate;
            //if (DateTime.TryParseExact(strStartDate, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempSessionStartDate) && DateTime.TryParseExact(strEndDate, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempSessionEndDate))
            //{
            //    dtSessionStartDate = tempSessionStartDate;
            //    dtSessionEndDate = tempSessionEndDate;
            //    int count = 1;
            //    for (DateTime startdate = Convert.ToDateTime(strStartDate, culture); startdate <= Convert.ToDateTime(strEndDate, culture); startdate = startdate.AddDays(1))
            //    {
            //        string strSessionDateTime = startdate.ToString("MM/dd/yyyy") + " - " + txtStartTime.Text + " to " + startdate.ToString("MM/dd/yyyy") + " - " + txtEndTime.Text;
            //        AddDataToDeliverySessions(MakeIntoSequence(count, txtId.Text), SessionWrapper.c_delivery_system_id_pk, txtTitle.Text, txtDescription.Value, startdate, startdate, ConvertStringToTimeFormat(txtStartTime.Text), ConvertStringToTimeFormat(txtEndTime.Text), txtDuration.Text, SessionWrapper.c_session_location_id_fk, SessionWrapper.c_session_facility_id_fk, SessionWrapper.c_session_room_id_fk, SessionWrapper.c_location_name, SessionWrapper.c_facility_name, SessionWrapper.c_room_name, strSessionDateTime, SessionWrapper.TempDeliverySessions);
            //        count++;
            //    }
            //    //clear rows in SessionWrapper.TempAddDeliveryInstructor
            //    SessionWrapper.TempAddDeliveryInstructor = null;
            //}




            //Merge into DeliveryInstructor datatable
            SessionWrapper.DeliveryInstructor.Merge(SessionWrapper.TempDeliveryInstructor);
            //while creating new course on edit delivery user can add new session
            if (Request.QueryString["page"] == "saes")
            {
                SessionWrapper.DeliverySessions.Merge(SessionWrapper.TempDeliverySessions);
            }
            //While editing new course on edit delivery user can add new session
            else if (Request.QueryString["mode"] == "addsession")
            {
                //Store session and instructor in database,i.e while editing a course
                try
                {
                    SystemCatalogBLL.InsertSessionInstructors(ConvertDataTableToXml(SessionWrapper.TempDeliverySessions), ConvertDataTableToXml(SessionWrapper.TempDeliveryInstructor), Request.QueryString["editcourseid"], false);

                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("sasw-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("sasw-01.aspx", ex.Message);
                    }
                }
            }
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
        /// MakeIntoSequence
        /// </summary>
        /// <param name="i"></param>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string MakeIntoSequence(int i, string strId)
        {
            string output = i.ToString();

            while (output.Length <= 1)
                output = "0" + output;
            return strId + "-" + output;
        }
        /// <summary>
        /// Add session id for each and every instructor
        /// </summary>
        /// <param name="c_user_id_fk"></param>
        /// <param name="c_instructor_name"></param>
        /// <param name="c_delivery_id_fk"></param>
        /// <param name="dtTempDeliveryInstructor"></param>
        private void AddDataToDeliveryInstructor(string c_user_id_fk, string c_instructor_name, string c_session_id_fk, string c_delivery_id_fk, string c_instructor_type_id_fk, DataTable dtTempDeliveryInstructor)
        {
            // Add Instructor function
            DataRow row;
            row = dtTempDeliveryInstructor.NewRow();
            row["c_instructor_system_id_pk"] = Guid.NewGuid().ToString();
            row["c_user_id_fk"] = c_user_id_fk;
            row["c_instructor_name"] = c_instructor_name;
            row["c_session_id_fk"] = c_session_id_fk;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            row["c_instructor_confirm"] = true;
            row["c_instructor_type_id_fk"] = c_instructor_type_id_fk;
            dtTempDeliveryInstructor.Rows.Add(row);
        }
        /// <summary>
        /// convert String into Time format used for Time Range
        /// </summary>
        /// <param name="strHoursMinutes"></param>
        /// <returns></returns>
        private string ConvertStringToTimeFormat(string strHoursMinutes)
        {
            if (!string.IsNullOrEmpty(strHoursMinutes))
            {
                String timeText = strHoursMinutes;

                DateTime time = Convert.ToDateTime(timeText); // Converts only the time
                return time.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private void AddDataToDeliverySessions(string c_session_id_pk, string c_delivery_id_fk, string c_session_title, string c_session_desc, string c_session_start_date, string c_session_end_date, string c_session_start_time, string c_sessions_end_time, string c_session_duration, string c_session_location_id_fk, string c_session_facility_id_fk, string c_sessions_room_id_fk, string c_location_name, string c_facility_name, string c_room_name, string c_session_date, DataTable dtTempDeliverySessions)
        {
            CultureInfo culture = new CultureInfo("en-US");
            // Add Session function
            DataRow row;
            row = dtTempDeliverySessions.NewRow();
            row["c_session_system_id_pk"] = Guid.NewGuid().ToString();
            row["c_session_id_pk"] = c_session_id_pk;
            row["c_delivery_id_fk"] = c_delivery_id_fk;
            row["c_session_title"] = c_session_title;
            row["c_sessions_desc"] = c_session_desc;
            row["c_session_start_date"] = c_session_start_date;
            row["c_session_end_date"] = c_session_end_date;
            row["c_session_start_time"] = c_session_start_time;
            row["c_sessions_end_time"] = c_sessions_end_time;
            row["c_session_duration"] = c_session_duration;
            row["c_session_location_id_fk"] = c_session_location_id_fk;
            row["c_session_facility_id_fk"] = c_session_facility_id_fk;
            row["c_sessions_room_id_fk"] = c_sessions_room_id_fk;

            row["c_location_name"] = c_location_name;
            row["c_facility_name"] = c_facility_name;
            row["c_room_name"] = c_room_name;
            row["c_session_date"] = c_session_date;
            dtTempDeliverySessions.Rows.Add(row);

            //add session id existing instructor
            if (SessionWrapper.TempAddDeliveryInstructor.Rows.Count > 0)
            {
                foreach (DataRow drInstructor in SessionWrapper.TempAddDeliveryInstructor.Rows)
                {
                    AddDataToDeliveryInstructor(drInstructor["c_user_id_fk"].ToString(), drInstructor["c_instructor_name"].ToString(), row["c_session_system_id_pk"].ToString(), row["c_delivery_id_fk"].ToString(), drInstructor["c_instructor_type_id_fk"].ToString(), SessionWrapper.TempDeliveryInstructor);

                }
            }
        }
        ///<summary>
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
        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
            {

            }
            else
            {
                ClearSession();
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearSession();
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);

        }
        public DataTable GetHolidays(DataTable dTable, string colName)
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

        protected void gvInstructor_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlInstrcdtorType = (DropDownList)e.Row.FindControl("ddlInstrcdtorType");
                ddlInstrcdtorType.DataSource = SystemCatalogBLL.GetInstructorType(SessionWrapper.CultureName);
                ddlInstrcdtorType.DataBind();
            }
        }
        //public DataTable CheckHoliday(DateTime dtDate)
        //{
        //    string u_holiday_schedule_system_id_pk = ddlRespectHolidays.SelectedValue;
        //    DataTable dtHoliday = new DataTable();
        //    dtHoliday = SystemCatalogBLL.GetHolidays(dtDate, u_holiday_schedule_system_id_pk);
        //    return dtHoliday;
        //}
    }
}