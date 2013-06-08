using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Globalization;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class saes_01 : BasePage
    {
        #region
        private string editSession;
        private static bool result;
        #endregion
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Hide validation summary on other popup appear
                vs_sand.Style.Add("display", "none");
                //Get session id
                editSession = Request.QueryString["editSession"];
                if (!IsPostBack)
                {
                    //clear session 
                    ClearSession();
                    //Check the edit session come from create(sand-01) or edit(saes-01) mode 
                    if (Request.QueryString["page"] == "sand")
                    {
                        //Get particular session using c_session_system_id_pk
                        DataView dvSessions = new DataView(SessionWrapper.TempDeliverySessions);
                        dvSessions.RowFilter = "c_session_system_id_pk= '" + editSession + "'";
                        //Get Temp session
                        GetTempSessions(dvSessions.ToTable());
                    }
                    else if (Request.QueryString["page"] == "saes")
                    {
                        //Get particular session using c_session_system_id_pk
                        DataView dvSessions = new DataView(SessionWrapper.DeliverySessions);
                        dvSessions.RowFilter = "c_session_system_id_pk= '" + editSession + "'";
                        //Get Temp session
                        GetTempSessions(dvSessions.ToTable());
                    }

                    //Delete if confirm instructor is false
                    //var rows = SessionWrapper.DeliveryInstructor.Select("c_instructor_confirm= '" + false + "'");
                    //foreach (var row in rows)
                    //    row.Delete();
                    //SessionWrapper.DeliveryInstructor.AcceptChanges();

                }
                //Set id for c_session_system_id_pk
                SessionWrapper.c_session_system_id_pk = editSession;
                //Get location
                lblLocation.Text = SessionWrapper.c_location_name;
                //Get facility
                lblFacility.Text = SessionWrapper.c_facility_name;
                //Get room
                lblRoom.Text = SessionWrapper.c_room_name;
                //Get Instructors
                GetTempInstructor(SessionWrapper.DeliveryInstructor);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saes-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saes-01.aspx", ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// GetTempInstructor
        /// </summary>
        /// <param name="dtInstructor"></param>
        private void GetTempInstructor(DataTable dtInstructor)
        {
            DataView dvInstructors = new DataView(dtInstructor);
            dvInstructors.RowFilter = "c_session_id_fk= '" + editSession + "'";
            if (hdValue.Value == "1" || string.IsNullOrEmpty(hdValue.Value))
            {
                gvInstructor.DataSource = dvInstructors.ToTable();
                gvInstructor.DataBind();
                hdValue.Value = null;
            }
        }
        /// <summary>
        /// GetTempSessions
        /// </summary>
        private void GetTempSessions(DataTable dtSessions)
        {
            CultureInfo culture = new CultureInfo("en-US");
            SystemCatalog getSession = new SystemCatalog();
            getSession = SystemCatalogBLL.TempGetCourseSession(editSession, dtSessions);
            txtId.Text = getSession.c_session_id_pk;
            txtTitle.Text = getSession.c_session_title;
            txtDescription.InnerText = getSession.c_sessions_desc;
            txtStartDate.Text = Convert.ToDateTime(getSession.c_session_start_date).ToShortDateString();
            txtEndDate.Text = Convert.ToDateTime(getSession.c_session_end_date).ToShortDateString();
            txtStartTime.Text = Convert.ToDateTime(getSession.c_session_start_time).ToString("h:mm tt");
            txtEndTime.Text = Convert.ToDateTime(getSession.c_sessions_end_time).ToString("h:mm tt");
            txtDuration.Text = Convert.ToDateTime(getSession.c_session_duration).ToString("h:mm");
            SessionWrapper.c_location_name = getSession.c_session_location_name;
            SessionWrapper.c_facility_name = getSession.c_session_facility_name;
            SessionWrapper.c_room_name = getSession.c_session_room_name;
            SessionWrapper.c_session_location_id_fk = getSession.c_session_location_id_fk;
            SessionWrapper.c_session_facility_id_fk = getSession.c_session_facility_id_fk;
            SessionWrapper.c_session_room_id_fk = getSession.c_session_room_id_fk;
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
                //Delete select instructor
                var rows = SessionWrapper.DeliveryInstructor.Select("c_instructor_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.DeliveryInstructor.AcceptChanges();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saes-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saes-01.aspx", ex.Message);
                    }
                }
            }


        }
        protected void btnSaveSessionInformation_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = TempDataTables.TempDeliveryInstructors();
            foreach (GridViewRow row in gvInstructor.Rows)
            {
                string c_user_id_fk = gvInstructor.DataKeys[row.RowIndex].Value.ToString();
                DropDownList ddlInstrcdtorType = (DropDownList)row.FindControl("ddlInstrcdtorType");
                DataView dvDeliveryInstructor = new DataView(SessionWrapper.DeliveryInstructor);

                dvDeliveryInstructor.RowFilter = "c_session_id_fk='" + editSession + "'";
                dtTemp = dvDeliveryInstructor.ToTable();
                var rows = dtTemp.Select("c_user_id_fk='" + c_user_id_fk + "'");
                var indexOfRow = dtTemp.Rows.IndexOf(rows[0]);
                dtTemp.Rows[indexOfRow]["c_instructor_type_id_fk"] = ddlInstrcdtorType.SelectedValue;
                dtTemp.AcceptChanges();
                //SessionWrapper.TempAddDeliveryInstructor.Merge(dtInstructor, true, MissingSchemaAction.Ignore);
            }

            var instructorRows = SessionWrapper.DeliveryInstructor.Select("c_session_id_fk='" + editSession + "'");
            foreach (var item in instructorRows)
            {
                item.Delete();
            }
            SessionWrapper.DeliveryInstructor.AcceptChanges();

            SessionWrapper.DeliveryInstructor.Merge(dtTemp);
            SessionWrapper.DeliveryInstructor.AcceptChanges();

            SessionWrapper.TempDeliveryInstructor = SessionWrapper.DeliveryInstructor;

            ConvertDataTables convertToXml = new ConvertDataTables();
            result = SystemCatalogBLL.checkMaximumOnePrimaryInstructors(convertToXml.ConvertDataTableToXml((dtTemp)));
            if (!result)
            {
                divError.Style.Add("display", "Block");
                divError.InnerHtml = LocalResources.GetText("app_instructor_type_in_session_error_wrong"); 
            }
            else
            {
                //Check the edit session come from create(sand) or edit(saes) mode 
                if (Request.QueryString["page"] == "sand")
                {
                    UpdateSession(SessionWrapper.TempDeliverySessions);
                }
                else if (Request.QueryString["page"] == "saes")
                {
                    UpdateSession(SessionWrapper.DeliverySessions);
                }
                DataRow[] results = SessionWrapper.DeliveryInstructor.Select("c_session_id_fk= '" + editSession + "' and c_instructor_confirm=false");
                //populate new destination table
                foreach (DataRow row in results)
                {
                    row["c_instructor_confirm"] = true;
                    SessionWrapper.DeliveryInstructor.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// Save Session information
        /// </summary>
        private void UpdateSession(DataTable dtSessions)
        {

            var rows = dtSessions.Select("c_session_system_id_pk= '" + editSession + "'");
            var indexOfRow = dtSessions.Rows.IndexOf(rows[0]);
            dtSessions.Rows[indexOfRow]["c_session_id_pk"] = txtId.Text;
            dtSessions.Rows[indexOfRow]["c_delivery_id_fk"] = SessionWrapper.c_delivery_system_id_pk;
            dtSessions.Rows[indexOfRow]["c_session_title"] = txtTitle.Text;
            dtSessions.Rows[indexOfRow]["c_sessions_desc"] = txtDescription.Value;
            dtSessions.Rows[indexOfRow]["c_session_start_date"] = txtStartDate.Text;
            dtSessions.Rows[indexOfRow]["c_session_end_date"] = txtEndDate.Text;
            dtSessions.Rows[indexOfRow]["c_session_start_time"] = Convert.ToDateTime(txtStartTime.Text);
            dtSessions.Rows[indexOfRow]["c_sessions_end_time"] = Convert.ToDateTime(txtEndTime.Text);
            dtSessions.Rows[indexOfRow]["c_session_duration"] = Convert.ToDateTime(txtDuration.Text);
            if (!string.IsNullOrEmpty(SessionWrapper.c_session_location_id_fk))
            {
                dtSessions.Rows[indexOfRow]["c_session_location_id_fk"] = SessionWrapper.c_session_location_id_fk;
            }
            else
            {
                dtSessions.Rows[indexOfRow]["c_session_location_id_fk"] = DBNull.Value;
            }
            if (!string.IsNullOrEmpty(SessionWrapper.c_session_facility_id_fk))
            {
                dtSessions.Rows[indexOfRow]["c_session_facility_id_fk"] = SessionWrapper.c_session_facility_id_fk;
            }
            else
            {
                dtSessions.Rows[indexOfRow]["c_session_facility_id_fk"] = DBNull.Value;
            }
            if (!string.IsNullOrEmpty(SessionWrapper.c_session_room_id_fk))
            {
                dtSessions.Rows[indexOfRow]["c_sessions_room_id_fk"] = SessionWrapper.c_session_room_id_fk;
            }
            else
            {
                dtSessions.Rows[indexOfRow]["c_sessions_room_id_fk"] = DBNull.Value;
            }
            dtSessions.Rows[indexOfRow]["c_location_name"] = lblLocation.Text;
            dtSessions.Rows[indexOfRow]["c_facility_name"] = lblFacility.Text;
            dtSessions.Rows[indexOfRow]["c_room_name"] = lblRoom.Text;
            string strSessionDateTime = Convert.ToDateTime(txtStartDate.Text).ToShortDateString() + " - " + txtStartTime.Text + " to " + Convert.ToDateTime(txtEndDate.Text).ToShortDateString() + " - " + txtEndTime.Text;
            dtSessions.Rows[indexOfRow]["c_session_date"] = strSessionDateTime;
            dtSessions.AcceptChanges();



            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        protected void gvInstructor_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlInstrcdtorType = (DropDownList)e.Row.FindControl("ddlInstrcdtorType");
                ddlInstrcdtorType.DataSource = SystemCatalogBLL.GetInstructorType(SessionWrapper.CultureName);
                ddlInstrcdtorType.DataBind();
                ddlInstrcdtorType.SelectedValue = (DataBinder.Eval(e.Row.DataItem, "c_instructor_type_id_fk")).ToString();
            }
        }

    }
}