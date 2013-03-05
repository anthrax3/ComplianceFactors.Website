using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Weekday_Schedules
{
    public partial class saewdn_01 : System.Web.UI.Page
    {
        private static string editWeekdays;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread                 
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Weekday%20Schedules/samwdmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_weekday_schedules_text") + "</a>" + " >&nbsp;" + LocalResources.GetGlobalLabel("app_edit_weekly_schedules_text");

                //ddlstatus
                ddlStatus.DataSource = SystemWeekdaySchedulesBLL.GetStatus(SessionWrapper.CultureName, "saewdn-01");
                ddlStatus.DataBind();

                 

                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    editWeekdays = SecurityCenter.DecryptText(Request.QueryString["edit"]);                    
                }
                if (!string.IsNullOrEmpty(Request.QueryString["succ"]) && SecurityCenter.DecryptText(Request.QueryString["succ"]) == "true")
                {
                    divSuccess.Style.Add("display", "block");
                    divSuccess.InnerHtml = LocalResources.GetText("app_succ_insert_text");
                }

                PopulateWeekDays(editWeekdays);
            }
        }
        /// <summary>
        /// Populate Week days Schedules
        /// </summary>
        /// <param name="editWeekdays"></param>
        private void PopulateWeekDays(string editWeekdays)
        {
            SystemWeekdaySchedules weekDays = new SystemWeekdaySchedules();
            try
            {
                weekDays = SystemWeekdaySchedulesBLL.GetSingleWeekSchedules(editWeekdays);
                txtScheduleId.Text = weekDays.s_weekday_schedule_id_pk;
                txtScheduleName.Text = weekDays.s_weekday_schedule_name;
                txtDescription.InnerText = weekDays.s_weekday_schedule_desc;
                ddlStatus.SelectedValue = weekDays.s_weekday_schedule_status_id_fk;
                if (weekDays.s_weekday_schedule_sunday_flag == true)
                {
                    chkSunday.Checked = true;
                }
                else
                {
                    chkSunday.Checked = false;
                }
                if (weekDays.s_weekday_schedule_monday_flag == true)
                {
                    chkMonday.Checked = true;
                }
                else
                {
                    chkMonday.Checked = false;
                }
                if (weekDays.s_weekday_schedule_tuesday_flag == true)
                {
                    chkTuesday.Checked = true;
                }
                else
                {
                    chkTuesday.Checked = false;
                }
                if (weekDays.s_weekday_schedule_wednesday_flag == true)
                {
                    chkWednesday.Checked = true;
                }
                else
                {
                    chkWednesday.Checked = false;
                }
                if (weekDays.s_weekday_schedule_thursday_flag == true)
                {
                    chkThursday.Checked = true;
                }
                else
                {
                    chkThursday.Checked = false;
                }
                if (weekDays.s_weekday_schedule_friday_flag == true)
                {
                    chkFriday.Checked = true;
                }
                else
                {
                    chkFriday.Checked = false;
                }
                if (weekDays.s_weekday_schedule_saturday_flag == true)
                {
                    chkSaturday.Checked = true;
                }
                else
                {
                    chkSaturday.Checked = false;
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saewdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saewdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderSaveWeekdaySchedule_Click(object sender, EventArgs e)
        {
            UpdateWeekdaySchedule();
        }

        protected void btnFooterSaveWeekdaySchedule_Click(object sender, EventArgs e)
        {
            UpdateWeekdaySchedule();
        }
        /// <summary>
        /// Update Weekday Schedule
        /// </summary>
        private void  UpdateWeekdaySchedule()
        {
            SystemWeekdaySchedules  updateWeekday = new SystemWeekdaySchedules();
            updateWeekday.s_weekday_schedule_system_id_pk = editWeekdays;
            updateWeekday.s_weekday_schedule_id_pk = txtScheduleId.Text;
            updateWeekday.s_weekday_schedule_name = txtScheduleName.Text;
            updateWeekday.s_weekday_schedule_desc = txtDescription.InnerText;
            updateWeekday.s_weekday_schedule_status_id_fk = ddlStatus.SelectedValue;
            if (chkSunday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_sunday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_sunday_flag = false;
            }
            if (chkMonday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_monday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_monday_flag = false;
            }
            if (chkTuesday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_tuesday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_tuesday_flag = false;
            }
            if (chkWednesday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_wednesday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_wednesday_flag = false;
            }
            if (chkThursday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_thursday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_thursday_flag = false;
            }
            if (chkFriday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_friday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_friday_flag = false;
            }
            if (chkSaturday.Checked == true)
            {
                updateWeekday.s_weekday_schedule_saturday_flag = true;
            }
            else
            {
                updateWeekday.s_weekday_schedule_saturday_flag = false;
            }

            try
            {
                int result = SystemWeekdaySchedulesBLL.UpdateWeekdaySchedules(updateWeekday);
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
                        Logger.WriteToErrorLog("saewdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saewdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Weekday%20Schedules/samwdmp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Weekday%20Schedules/samwdmp-01.aspx");
        }
    }
}