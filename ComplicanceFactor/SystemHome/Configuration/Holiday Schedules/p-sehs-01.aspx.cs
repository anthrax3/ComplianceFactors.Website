using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;

namespace ComplicanceFactor.SystemHome.Configuration.Holiday_Schedules
{
    public partial class p_sehs_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanhdn")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            DataView dvHoliday = new DataView(SessionWrapper.session_HolidayDates);
                            dvHoliday.RowFilter = "u_holiday_system_id_pk= '" + Request.QueryString["id"] + "'";
                            //Get Temp Holiday
                            TempGetHoliday(Request.QueryString["id"], dvHoliday.ToTable());
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saehdn")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                    {
                        SystemHolidaySchedules holidayDate = new SystemHolidaySchedules();
                        try
                        {
                            holidayDate = SystemHolidaySchedulesBLL.GetSingleHolidayDate(Request.QueryString["holidayid"]);

                            txtHolidayName.Text = holidayDate.u_holiday_name;
                            txtDate.Text = holidayDate.u_holiday_date.ToShortDateString();
                            txtDescription.InnerText = holidayDate.u_holiday_desc;

                        }
                        catch (Exception ex)
                        {
                            //TODO: Show user friendly error here
                            //Log here
                            if (ConfigurationWrapper.LogErrors == true)
                            {
                                if (ex.InnerException != null)
                                {
                                    Logger.WriteToErrorLog("Edit_Holiday.aspx", ex.Message, ex.InnerException.Message);
                                }
                                else
                                {
                                    Logger.WriteToErrorLog("Edit_Holiday.aspx", ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        ///  Populate values when edit the holiday
        /// </summary>
        /// <param name="u_holiday_system_id_pk"></param>
        /// <param name="dtHoliday"></param>
        private void TempGetHoliday(string u_holiday_system_id_pk, DataTable dtHoliday)
        {
            txtHolidayName.Text = dtHoliday.Rows[0]["u_holiday_name"].ToString();
            txtDate.Text = dtHoliday.Rows[0]["u_holiday_date"].ToString();
            txtDescription.InnerText = dtHoliday.Rows[0]["u_holiday_desc"].ToString();
        }

        protected void btnSaveHoliday_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saanhdn")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    UpdateHoliday();
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saehdn")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemHolidaySchedules holidayDate = new SystemHolidaySchedules();
                    try
                    {
                        holidayDate.u_holiday_system_id_pk = Request.QueryString["holidayid"];
                        holidayDate.u_holiday_name = txtHolidayName.Text;
                        holidayDate.u_holiday_date = Convert.ToDateTime(txtDate.Text);
                        holidayDate.u_holiday_desc = txtDescription.InnerText;
                        int result = SystemHolidaySchedulesBLL.UpdateHolidayDates(holidayDate);

                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("Edit_Holiday.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("Edit_Holiday.aspx", ex.Message);
                            }
                        }
                    }
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }

        /// <summary>
        /// Update the date in session 
        /// </summary>
        private void UpdateHoliday()
        {
            var rows = SessionWrapper.session_HolidayDates.Select("u_holiday_system_id_pk= '" + Request.QueryString["id"] + "'");
            var indexOfRow = SessionWrapper.session_HolidayDates.Rows.IndexOf(rows[0]);
            SessionWrapper.session_HolidayDates.Rows[indexOfRow]["u_holiday_name"] = txtHolidayName.Text;
            SessionWrapper.session_HolidayDates.Rows[indexOfRow]["u_holiday_desc"] = txtDescription.InnerText;
            SessionWrapper.session_HolidayDates.Rows[indexOfRow]["u_holiday_date"] = txtDate.Text;

            SessionWrapper.session_HolidayDates.AcceptChanges();
        }
    }
}