using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Data;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Holiday_Schedules
{
    public partial class saehdn_01 : System.Web.UI.Page
    {
        private static string editHolidaySchedule;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread Crumb
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Holiday%20Schedules/samhdmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_holiday_schedules_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_edit_holiday_schedule_text") + "</a>";
            

                //to bind status
                ddlStatus.DataSource = SystemHolidaySchedulesBLL.GetStatus(SessionWrapper.CultureName, "saehdn-01");
                ddlStatus.DataBind();                 

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editHolidaySchedule = SecurityCenter.DecryptText(Request.QueryString["id"]);
                    hdScheduleId.Value = editHolidaySchedule;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }
                PopulateHolidaySchedule(editHolidaySchedule);
                RevertBack(editHolidaySchedule);
            }
            gvHoliday.DataSource = SystemHolidaySchedulesBLL.GetAllHolidayDates(editHolidaySchedule);
            gvHoliday.DataBind();
        }

        /// <summary>
        /// Populate the holiday Schedule for Edit
        /// </summary>
        /// <param name="editHolidaySchedule"></param>
        private void PopulateHolidaySchedule(string editHolidaySchedule)
        {
            SystemHolidaySchedules holidaySchedules = new SystemHolidaySchedules();
            try
            {
                gvHoliday.DataSource = SystemHolidaySchedulesBLL.GetAllHolidayDates(editHolidaySchedule);
                gvHoliday.DataBind();

                holidaySchedules = SystemHolidaySchedulesBLL.GetHolidayschedule(editHolidaySchedule);

                txtScheduleId.Text = holidaySchedules.u_holiday_schedule_id;
                txtScheduleName.Text = holidaySchedules.u_holiday_schedule_name;
                txtDescription.InnerText = holidaySchedules.u_holiday_schedule_desc;
                ddlStatus.SelectedValue = holidaySchedules.u_holiday_schedule_status_id_fk;

            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterSaveHolidaySchedule_Click(object sender, EventArgs e)
        {
            UpdateHolidaySchedule();
        }

        protected void btnHeaderSaveHolidaySchedule_Click(object sender, EventArgs e)
        {
            UpdateHolidaySchedule();
        }

        /// <summary>
        /// Update Holiday Schdule
        /// </summary>
        private void UpdateHolidaySchedule()
        {
            SystemHolidaySchedules holidaySchedules = new SystemHolidaySchedules();
            holidaySchedules.u_holiday_schedule_system_id_pk = editHolidaySchedule;
            holidaySchedules.u_holiday_schedule_id = txtScheduleId.Text;
            holidaySchedules.u_holiday_schedule_name = txtScheduleName.Text;
            holidaySchedules.u_holiday_schedule_desc = txtDescription.InnerText;
            holidaySchedules.u_holiday_schedule_status_id_fk = ddlStatus.SelectedValue;

            try
            {
                int result = SystemHolidaySchedulesBLL.UpdateHolidaySchedules(holidaySchedules);
                if (result == 0)
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Revert Back for the reset holiday dates
        /// </summary>
        /// <param name="questionId"></param>
        private void RevertBack(string questionId)
        {
            SessionWrapper.session_reset_HolidayDates = TempHoliday();
            try
            {
                SessionWrapper.session_reset_HolidayDates = SystemHolidaySchedulesBLL.GetAllHolidayDates(editHolidaySchedule);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static void DeleteHoliday(string args)
        {
            try
            {
                int result = SystemHolidaySchedulesBLL.DeleteSingleHoliday(args.Trim());
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            ResetHolidaySchedule();
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            ResetHolidaySchedule();
        }
        /// <summary>
        /// Reset Holiday Schedule
        /// </summary>
        private void ResetHolidaySchedule()
        {
            SystemHolidaySchedules resetHoliday = new SystemHolidaySchedules();
            resetHoliday.u_holiday_schedule_system_id_pk = editHolidaySchedule;
            resetHoliday.u_holiday_dates = ConvertDataTableToXml(SessionWrapper.session_reset_HolidayDates);
            try
            {
                int result = SystemHolidaySchedulesBLL.ResetHoliday(resetHoliday);
                if (result == 0)
                {
                    PopulateHolidaySchedule(editHolidaySchedule);
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
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saehdn-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// To convert the datatable to XML
        /// </summary>
        /// <param name="dtBuildSql"></param>
        /// <returns></returns>
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
        /// Temp Holiday
        /// </summary>
        /// <returns></returns>
        private DataTable TempHoliday()
        {
            DataTable dtTempHoliday = new DataTable();
            DataColumn dtTempHolidayColumn;

            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_system_id_pk";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);

            //Holiday Name
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_name";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);
            //Desc
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_desc";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);
            //Date
            dtTempHolidayColumn = new DataColumn();
            dtTempHolidayColumn.DataType = Type.GetType("System.String");
            dtTempHolidayColumn.ColumnName = "u_holiday_date";
            dtTempHoliday.Columns.Add(dtTempHolidayColumn);

            return dtTempHoliday;
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Holiday Schedules/samhdmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Holiday Schedules/samhdmp-01.aspx");
        }
    }
}