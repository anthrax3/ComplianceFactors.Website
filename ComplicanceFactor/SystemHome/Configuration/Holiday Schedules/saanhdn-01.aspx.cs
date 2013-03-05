using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Holiday_Schedules
{
    public partial class saanhdn_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread Crumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Holiday%20Schedules/samhdmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_holiday_schedules_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_create_new_holiday_schedule_text");

                SessionWrapper.session_HolidayDates = TempHolidayDate();

                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    CopyHolidaySchedules(SecurityCenter.DecryptText(Request.QueryString["copy"]));
                }
                //ddlStatus Bind
                ddlStatus.DataSource = SystemHolidaySchedulesBLL.GetStatus(SessionWrapper.CultureName, "saanhdn-01");
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = "app_ddl_active_text";
            }
            if (SessionWrapper.session_HolidayDates.Rows.Count > 0)
            {
                gvHoliday.DataSource = SessionWrapper.session_HolidayDates;
                gvHoliday.DataBind();
            }
        }

        private DataTable TempHolidayDate()
        {
            DataTable dtTempHoliday = new DataTable();
            DataColumn dtTempHolidayColumn;
            //u_holiday_system_id_pk
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_system_id_pk";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);

            ////u_holiday_schedule_id_fk
            //dtTempHolidayColumn = new DataColumn();
            //dtTempHolidayColumn.DataType = Type.GetType("System.String");
            //dtTempHolidayColumn.ColumnName = "u_holiday_schedule_id_fk";
            //dtTempHoliday.Columns.Add(dtTempHolidayColumn);

            //u_holiday_name
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_name";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);
            //u_holiday_desc
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_desc";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);
            //u_holiday_date
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_date";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);

            return dtTempHoliday;
        }

        protected void btnHeaderSaveNewHolidaySchedule_Click(object sender, EventArgs e)
        {
            SaveNewHolidaySchedules();
        }
        protected void btnFooterSaveNewHolidaySchedule_Click(object sender, EventArgs e)
        {
            SaveNewHolidaySchedules();
        }


        private void SaveNewHolidaySchedules()
        {
            SystemHolidaySchedules createHoliday = new SystemHolidaySchedules();

            createHoliday.u_holiday_schedule_system_id_pk = Guid.NewGuid().ToString();
            createHoliday.u_holiday_schedule_id = txtScheduleId.Text;
            createHoliday.u_holiday_schedule_name = txtScheduleName.Text;
            createHoliday.u_holiday_schedule_desc = txtDescription.InnerText;
            createHoliday.u_holiday_schedule_status_id_fk = ddlStatus.SelectedValue;
            createHoliday.u_holiday_dates = ConvertDataTableToXml(SessionWrapper.session_HolidayDates);

            try
            {
                int result = SystemHolidaySchedulesBLL.CreateHolidaySchedules(createHoliday);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/Holiday Schedules/saehdn-01.aspx?id=" + SecurityCenter.EncryptText(createHoliday.u_holiday_schedule_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanhdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanhdn-01.aspx", ex.Message);
                    }
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
        /// <summary>
        /// Web Method for delete
        /// </summary>
        /// <param name="args"></param>
        [System.Web.Services.WebMethod]
        public static void DeleteHoliday(string args)
        {
            //SessionWrapper.session_Add_Questions
            try
            {

                //Delete previous selected  question
                var rows = SessionWrapper.session_HolidayDates.Select("u_holiday_system_id_pk= '" + args.Trim() + "'");
                foreach (var row in rows)
                    row.Delete();
                SessionWrapper.session_HolidayDates.AcceptChanges();

            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanhdn-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanhdn-01", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Copy  Holiday Schedule
        /// </summary>
        /// <param name="holidayScheduleId"></param>
        private void CopyHolidaySchedules(string holidayScheduleId)
        {
            SystemHolidaySchedules holidaySchedules = new SystemHolidaySchedules();
            try
            {
                //clear the seession value
                SessionWrapper.session_HolidayDates = null;


                holidaySchedules = SystemHolidaySchedulesBLL.GetHolidayschedule(holidayScheduleId);

                txtScheduleId.Text = holidaySchedules.u_holiday_schedule_id + "_copy";
                txtScheduleName.Text = holidaySchedules.u_holiday_schedule_name;
                txtDescription.InnerText = holidaySchedules.u_holiday_schedule_desc;
                ddlStatus.SelectedValue = holidaySchedules.u_holiday_schedule_status_id_fk;
                //assign value for session

                SessionWrapper.session_HolidayDates = SystemHolidaySchedulesBLL.GetAllHolidayDates(holidayScheduleId);

                gvHoliday.DataSource = SystemHolidaySchedulesBLL.GetAllHolidayDates(holidayScheduleId);
                gvHoliday.DataBind();

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanhdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanhdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Holiday Schedules/samhdmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Holiday Schedules/samhdmp-01.aspx");
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}