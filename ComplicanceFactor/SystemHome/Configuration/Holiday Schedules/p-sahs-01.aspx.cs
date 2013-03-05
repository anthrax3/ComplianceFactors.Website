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
    public partial class p_sahs_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // Edit the session (or) datatable values        
        private void EditDataToTempQuestions(int rowIndex, string question_Id, string question_Name, string question_Type, string option1, string option2, string option3, string option4, DataTable dtTempQuestions)
        {
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question"] = question_Name;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_type"] = question_Type;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsA"] = option1;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsB"] = option2;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsC"] = option3;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_answer_optionsD"] = option4;
            dtTempQuestions.Rows[rowIndex]["sv_mi_templete_question_display_order"] = question_Id;

            dtTempQuestions.AcceptChanges();
        }
        // Add  Holidays to the session       
        private void AddDataToTempQuestions(string holidayName, string holidayDes, string date, DataTable dtTempHolidays)
        {
            DataRow row;
            row = dtTempHolidays.NewRow();
            row["u_holiday_system_id_pk"] = Guid.NewGuid().ToString();
            row["u_holiday_name"] = holidayName;
            row["u_holiday_desc"] = holidayDes;
            row["u_holiday_date"] = date;
            dtTempHolidays.Rows.Add(row);
        }

        protected void btnSaveHoliday_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saehdn")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
                {
                    SystemHolidaySchedules holidayDate = new SystemHolidaySchedules();
                    try
                    {
                        //holidayDate = SystemHolidaySchedulesBLL.GetSingleHolidayDate(Request.QueryString["holidayid"]);

                        holidayDate.u_holiday_system_id_pk = Guid.NewGuid().ToString();
                        holidayDate.u_holiday_schedule_id_fk = Request.QueryString["editScheduleId"];
                        holidayDate.u_holiday_name = txtHolidayName.Text;
                        holidayDate.u_holiday_date = Convert.ToDateTime(txtDate.Text);
                        holidayDate.u_holiday_desc = txtDescription.InnerText;

                        int result = SystemHolidaySchedulesBLL.CreateHolidayDates(holidayDate);

                    }
                    catch (Exception ex)
                    {
                        //TODO: Show user friendly error here
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("Add_Holiday.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("Add_Holiday.aspx", ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                AddDataToTempQuestions(txtHolidayName.Text, txtDescription.InnerText, txtDate.Text, SessionWrapper.session_HolidayDates);
            }
            //Close popup
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
    }
}