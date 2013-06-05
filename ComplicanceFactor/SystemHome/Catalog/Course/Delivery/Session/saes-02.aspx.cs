using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Data;
using System.Globalization;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Collections;
using System.Web.UI.WebControls;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class saes_02 : BasePage
    {
        private string editSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Hide validation summary on other popup appear
                vs_sand.Style.Add("display", "none");
                //Get session id
                editSession = Request.QueryString["editsession"];
                if (!IsPostBack)
                {
                    //clear session 
                    ClearSession();
                    //add temp instructor datatable
                    SessionWrapper.TempDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                    //Get session
                    GetDeliverySessions(editSession, SystemCatalogBLL.GetSessions(editSession));
                    RevertBack();
                }
                //Get instructor


                if (SessionWrapper.TempDeliveryInstructor.Rows.Count > 0)
                {
                    SessionWrapper.TempAddDeliveryInstructor = SessionWrapper.TempDeliveryInstructor;
                    SessionWrapper.TempDeliveryInstructor = null;
                    SessionWrapper.TempDeliveryInstructor = TempDataTables.TempDeliveryInstructors();
                }


                //DataTable dtTempInstructor = SessionWrapper.TempDeliveryInstructor;
                DataTable dtInstructor = SystemCatalogBLL.GetSessionInstructor(editSession);
                if (dtInstructor.Rows.Count > 0 && SessionWrapper.TempAddDeliveryInstructor.Rows.Count > 0)
                {
                    SessionWrapper.TempAddDeliveryInstructor.Merge(dtInstructor, true, MissingSchemaAction.Ignore);
                }
                else if (dtInstructor.Rows.Count == 0 && SessionWrapper.TempAddDeliveryInstructor.Rows.Count > 0)
                {
                   //SessionWrapper.TempAddDeliveryInstructor;
                }
                else
                {
                    SessionWrapper.TempAddDeliveryInstructor = SystemCatalogBLL.GetSessionInstructor(editSession);
                }
                SessionWrapper.TempAddDeliveryInstructor = RemoveDuplicateRows(SessionWrapper.TempAddDeliveryInstructor, "c_user_id_fk");
                if (hdValue.Value == "1" || string.IsNullOrEmpty(hdValue.Value))
                {
                    gvInstructor.DataSource = SessionWrapper.TempAddDeliveryInstructor;
                    gvInstructor.DataBind();
                }
                //Set id for c_session_system_id_pk
                SessionWrapper.c_session_system_id_pk = editSession;
                //Get location
                lblLocation.Text = SessionWrapper.c_location_name;
                //Get facility
                lblFacility.Text = SessionWrapper.c_facility_name;
                //Get room
                lblRoom.Text = SessionWrapper.c_room_name;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saes-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saes-02.aspx", ex.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Clear session
        /// </summary>
        private void ClearSession()
        {
            SessionWrapper.c_location_name = "";
            SessionWrapper.c_location_system_id_pk = "";
            SessionWrapper.c_facility_system_id_pk = "";
            SessionWrapper.c_facility_name = "";
            SessionWrapper.c_room_system_id_pk = "";
            SessionWrapper.c_room_name = "";
            SessionWrapper.c_session_system_id_pk = "";
            SessionWrapper.TempDeliveryInstructor = null;
            SessionWrapper.TempAddDeliveryInstructor = null;
            // SessionWrapper.TempDeliverySessions = null;
        }
        /// <summary>
        /// DeleteInstructor
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteInstructor(string args)
        {
            try
            {
                //Delete selected instructor in database
                SystemCatalogBLL.DeleteSessionInstructor(args.Trim());
                //Delete selected instructor in session
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
                        Logger.WriteToErrorLog("saes-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saes-02.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// GetTempSessions
        /// </summary>
        private void GetDeliverySessions(string editSession, DataTable dtSessions)
        {
            CultureInfo culture = new CultureInfo("en-US");
            //CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog getSession = new SystemCatalog();
            getSession = SystemCatalogBLL.GetCourseDeliverySession(editSession, dtSessions);
            txtId.Text = getSession.c_session_id_pk;
            txtTitle.Text = getSession.c_session_title;
            txtDescription.InnerText = getSession.c_sessions_desc;
            txtStartDate.Text = Convert.ToDateTime(getSession.c_session_start_date, culture).ToString("MM/dd/yyyy", culture);
            txtEndDate.Text = Convert.ToDateTime(getSession.c_session_end_date, culture).ToString("MM/dd/yyyy", culture);
            txtStartTime.Text = Convert.ToDateTime(getSession.c_session_start_time, culture).ToString("h:mm tt", culture);
            txtEndTime.Text = Convert.ToDateTime(getSession.c_sessions_end_time, culture).ToString("h:mm tt", culture);
            txtDuration.Text = Convert.ToDateTime(getSession.c_session_duration, culture).ToString("h:mm", culture);
            SessionWrapper.c_location_name = getSession.c_session_location_name;
            SessionWrapper.c_facility_name = getSession.c_session_facility_name;
            SessionWrapper.c_room_name = getSession.c_session_room_name;
            lblLocation.Text = getSession.c_session_location_name;
            lblFacility.Text = getSession.c_session_facility_name;
            lblRoom.Text = getSession.c_session_room_name;
            SessionWrapper.c_session_location_id_fk = getSession.c_session_location_id_fk;
            SessionWrapper.c_session_facility_id_fk = getSession.c_session_facility_id_fk;
            SessionWrapper.c_session_room_id_fk = getSession.c_session_room_id_fk;
        }
        /// <summary>
        /// convert String into Time format used for Time Range
        /// </summary>
        /// <param name="strHoursMinutes"></param>
        /// <returns></returns>
        private string ConvertStringToTimeFormat(string strHoursMinutes)
        {


            CultureInfo culture = new CultureInfo("en-US");
            if (!string.IsNullOrEmpty(strHoursMinutes))
            {
                String timeText = strHoursMinutes;

                string time = Convert.ToDateTime(timeText, culture).ToString("MM/dd/yyyy h:mm:ss", culture); // Converts only the time
                return time;
            }
            else
            {
                return string.Empty;
            }
        }
        protected void btnSaveSessionInformation_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            //string[] formats = { "M/d/yyyy", "MM/dd/yyyy", "M/dd/yyyy","M-d-yyyy","MM-d-yyyy","MM-dd-yyyy" };


            foreach (GridViewRow row in gvInstructor.Rows)
            {

                DropDownList ddlInstrcdtorType = (DropDownList)row.FindControl("ddlInstrcdtorType");
                string c_user_id_fk = gvInstructor.DataKeys[row.RowIndex].Value.ToString();
                var rows = SessionWrapper.TempAddDeliveryInstructor.Select("c_user_id_fk='" + c_user_id_fk + "'");
                var indexOfRow = SessionWrapper.TempAddDeliveryInstructor.Rows.IndexOf(rows[0]);
                SessionWrapper.TempAddDeliveryInstructor.Rows[indexOfRow]["c_instructor_type_id_fk"] = ddlInstrcdtorType.SelectedValue;
                SessionWrapper.TempAddDeliveryInstructor.AcceptChanges();
            }

            string strStartDate = Convert.ToDateTime(txtStartDate.Text, culture).ToString("MM/dd/yyyy", culture);
            txtStartDate.Text = strStartDate;
            string strEndDate = Convert.ToDateTime(txtEndDate.Text, culture).ToString("MM/dd/yyyy", culture);
            txtEndDate.Text = strEndDate;
            SystemCatalog updateSession = new SystemCatalog();
            updateSession.c_session_system_id_pk = editSession;
            updateSession.c_session_id_pk = txtId.Text;
            updateSession.c_session_title = txtTitle.Text;
            updateSession.c_sessions_desc = txtDescription.Value;
            DateTime? startDate = null;
            DateTime tempStartDate;
            if (DateTime.TryParseExact(txtStartDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempStartDate))
            {
                startDate = DateTime.Parse(strStartDate, culture);

            }

            updateSession.c_session_start_date = startDate;
            DateTime? EndDate = null;
            DateTime tempEndDate;
            if (DateTime.TryParseExact(txtEndDate.Text, "MM/dd/yyyy", culture, DateTimeStyles.None, out tempEndDate))
            {
                EndDate = tempEndDate;

            }
            updateSession.c_session_end_date = EndDate;

            DateTime? startTime = null;
            DateTime tempStartTime;
            if (DateTime.TryParseExact(ConvertStringToTimeFormat(txtStartTime.Text), "MM/dd/yyyy h:mm:ss", culture, DateTimeStyles.None, out tempStartTime))
            {
                startTime = tempStartTime;

            }
            updateSession.c_session_start_time = startTime;
            DateTime? endTime = null;
            DateTime tempEndTime;
            if (DateTime.TryParseExact(ConvertStringToTimeFormat(txtEndTime.Text), "MM/dd/yyyy h:mm:ss", culture, DateTimeStyles.None, out tempEndTime))
            {
                endTime = tempEndTime;
            }

            updateSession.c_sessions_end_time = endTime;
            DateTime? duration = null;
            DateTime tempduration;
            if (DateTime.TryParseExact(ConvertStringToTimeFormat(txtDuration.Text), "MM/dd/yyyy h:mm:ss", culture, DateTimeStyles.None, out tempduration))
            {
                duration = tempduration;
            }
            updateSession.c_session_duration = duration;
            updateSession.c_session_location_id_fk = SessionWrapper.c_session_location_id_fk;
            updateSession.c_session_facility_id_fk = SessionWrapper.c_session_facility_id_fk;
            updateSession.c_session_room_id_fk = SessionWrapper.c_session_room_id_fk;
            updateSession.c_session_instructor = ConvertDataTableToXml(SessionWrapper.TempAddDeliveryInstructor);
            updateSession.c_course_id_fk = Request.QueryString["editcourseid"];
            try
            {
                //update session
                SystemCatalogBLL.UpdateDeliverySession(updateSession);
                SessionWrapper.TempAddDeliveryInstructor = null;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saes-02.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saes-02.aspx", ex.Message);
                    }
                }
            }

            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
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
        protected void btnReset_Click(object sender, EventArgs e)
        {

            try
            {
                SystemCatalogBLL.InsertSessionInstructors("", ConvertDataTableToXml(SessionWrapper.Reset_Edit_DeliveryInstructor), Request.QueryString["editcourseid"], true);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Logger.WriteToErrorLog("saes-02.aspx", ex.Message, ex.InnerException.Message);
                }
                else
                {
                    Logger.WriteToErrorLog("saes-02.aspx", ex.Message);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        ///<summary>
        /// RevertBack instructor
        ///</summary>
        private void RevertBack()
        {
            SessionWrapper.Reset_Edit_DeliveryInstructor = SystemCatalogBLL.GetSessionInstructor(editSession);

        }

        protected void gvInstructor_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string c_instructor_type_id_fk = (DataBinder.Eval(e.Row.DataItem, "c_instructor_type_id_fk")).ToString();
                DropDownList ddlInstrcdtorType = (DropDownList)e.Row.FindControl("ddlInstrcdtorType");
                ddlInstrcdtorType.DataSource = SystemCatalogBLL.GetInstructorType(SessionWrapper.CultureName);
                ddlInstrcdtorType.DataBind();
                ddlInstrcdtorType.SelectedValue = c_instructor_type_id_fk;
            }
        }
    }
}