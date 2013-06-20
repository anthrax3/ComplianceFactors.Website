using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Configuration.Weekday_Schedules
{
    public partial class saanwdn_01 : System.Web.UI.Page
    {
        private static string copyWeekdaySchedule;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label Bread                 
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/Weekday%20Schedules/samwdmp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_weekday_schedules_text") + "</a>" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_schedules_text") + "</a>";

 
                //Status Bind
                ddlStatus.DataSource = SystemWeekdaySchedulesBLL.GetStatus(SessionWrapper.CultureName, "saanwdn-01");
                ddlStatus.DataBind();

                ddlStatus.SelectedValue = "app_ddl_active_text";

                if (!string.IsNullOrEmpty(Request.QueryString["copy"]))
                {
                    copyWeekdaySchedule = SecurityCenter.DecryptText(Request.QueryString["copy"]);
                    PoulateWeekdaySchedule(copyWeekdaySchedule);
                }
            }
        }

        protected void btnHeaderSaveNewWeekdaySchedule_Click(object sender, EventArgs e)
        {
            SaveWeekdaySchedule();
        }

        protected void btnFooterSaveNewWeekdaySchedule_Click(object sender, EventArgs e)
        {
            SaveWeekdaySchedule();
        }
        /// <summary>
        /// Save Weekday Schedules (Create New)
        /// </summary>
        private void SaveWeekdaySchedule()
        {
            SystemWeekdaySchedules createWeekday = new SystemWeekdaySchedules();
            createWeekday.s_weekday_schedule_system_id_pk = Guid.NewGuid().ToString();
            createWeekday.s_weekday_schedule_id_pk = txtScheduleId.Text;
            createWeekday.s_weekday_schedule_name = txtScheduleName.Text;
            createWeekday.s_weekday_schedule_desc = txtDescription.InnerText;
            createWeekday.s_weekday_schedule_status_id_fk = ddlStatus.SelectedValue;
            if (chkSunday.Checked == true)
            {
                createWeekday.s_weekday_schedule_sunday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_sunday_flag = false;
            }
            if (chkMonday.Checked == true)
            {
                createWeekday.s_weekday_schedule_monday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_monday_flag = false;
            }
            if (chkTuesday.Checked == true)
            {
                createWeekday.s_weekday_schedule_tuesday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_tuesday_flag =  false;
            }
            if (chkWednesday.Checked == true)
            {
                createWeekday.s_weekday_schedule_wednesday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_wednesday_flag = false;
            }
            if (chkThursday.Checked == true)
            {
                createWeekday.s_weekday_schedule_thursday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_thursday_flag = false;
            }
            if (chkFriday.Checked == true)
            {
                createWeekday.s_weekday_schedule_friday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_friday_flag = false;
            }
            if (chkSaturday.Checked == true)
            {
                createWeekday.s_weekday_schedule_saturday_flag = true;
            }
            else
            {
                createWeekday.s_weekday_schedule_saturday_flag = false;
            }

            try
            {
                int result = SystemWeekdaySchedulesBLL.CreateWeekdaySchedules(createWeekday);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Configuration/Weekday Schedules/saewdn-01.aspx?edit=" + SecurityCenter.EncryptText(createWeekday.s_weekday_schedule_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanwdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanwdn-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Populate WeekdaySchedule for Copy
        /// </summary>
        /// <param name="copyWeekdaySchedule"></param>
        private void PoulateWeekdaySchedule(string copyWeekdaySchedule)
        {
            SystemWeekdaySchedules weekDays = new SystemWeekdaySchedules();
            try
            {
                weekDays = SystemWeekdaySchedulesBLL.GetSingleWeekSchedules(copyWeekdaySchedule);
                txtScheduleId.Text = weekDays.s_weekday_schedule_id_pk+"_copy";
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
                        Logger.WriteToErrorLog("saanwdn-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanwdn-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Weekday%20Schedules/samwdmp-01.aspx");
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/Weekday%20Schedules/samwdmp-01.aspx");
        }
    }
}