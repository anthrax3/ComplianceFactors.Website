using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using ComplicanceFactor.DataAccessLayer;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemWeekdaySchedulesBLL
    {
        public static int CreateWeekdaySchedules(SystemWeekdaySchedules weekdays)
        {
            Hashtable htCreateWeekDays = new Hashtable();
            htCreateWeekDays.Add("@s_weekday_schedule_system_id_pk", weekdays.s_weekday_schedule_system_id_pk);
            htCreateWeekDays.Add("@s_weekday_schedule_id_pk", weekdays.s_weekday_schedule_id_pk);
            htCreateWeekDays.Add("@s_weekday_schedule_name", weekdays.s_weekday_schedule_name);
            htCreateWeekDays.Add("@s_weekday_schedule_desc", weekdays.s_weekday_schedule_desc);
            htCreateWeekDays.Add("@s_weekday_schedule_status_id_fk", weekdays.s_weekday_schedule_status_id_fk);
            htCreateWeekDays.Add("@s_weekday_schedule_sunday_flag", weekdays.s_weekday_schedule_sunday_flag);
            htCreateWeekDays.Add("@s_weekday_schedule_monday_flag", weekdays.s_weekday_schedule_monday_flag);
            htCreateWeekDays.Add("@s_weekday_schedule_tuesday_flag", weekdays.s_weekday_schedule_tuesday_flag);
            htCreateWeekDays.Add("@s_weekday_schedule_wednesday_flag", weekdays.s_weekday_schedule_wednesday_flag);
            htCreateWeekDays.Add("@s_weekday_schedule_thursday_flag", weekdays.s_weekday_schedule_thursday_flag);
            htCreateWeekDays.Add("@s_weekday_schedule_friday_flag", weekdays.s_weekday_schedule_friday_flag);
            htCreateWeekDays.Add("@s_weekday_schedule_saturday_flag", weekdays.s_weekday_schedule_saturday_flag);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_weekday_schedules", htCreateWeekDays);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateWeekdaySchedules(SystemWeekdaySchedules updateWeekdays)
        {
            Hashtable htUpdateWeekDays = new Hashtable();
            htUpdateWeekDays.Add("@s_weekday_schedule_system_id_pk", updateWeekdays.s_weekday_schedule_system_id_pk);
            htUpdateWeekDays.Add("@s_weekday_schedule_id_pk", updateWeekdays.s_weekday_schedule_id_pk);
            htUpdateWeekDays.Add("@s_weekday_schedule_name", updateWeekdays.s_weekday_schedule_name);
            htUpdateWeekDays.Add("@s_weekday_schedule_desc", updateWeekdays.s_weekday_schedule_desc);
            htUpdateWeekDays.Add("@s_weekday_schedule_status_id_fk", updateWeekdays.s_weekday_schedule_status_id_fk);
            htUpdateWeekDays.Add("@s_weekday_schedule_sunday_flag", updateWeekdays.s_weekday_schedule_sunday_flag);
            htUpdateWeekDays.Add("@s_weekday_schedule_monday_flag", updateWeekdays.s_weekday_schedule_monday_flag);
            htUpdateWeekDays.Add("@s_weekday_schedule_tuesday_flag", updateWeekdays.s_weekday_schedule_tuesday_flag);
            htUpdateWeekDays.Add("@s_weekday_schedule_wednesday_flag", updateWeekdays.s_weekday_schedule_wednesday_flag);
            htUpdateWeekDays.Add("@s_weekday_schedule_thursday_flag", updateWeekdays.s_weekday_schedule_thursday_flag);
            htUpdateWeekDays.Add("@s_weekday_schedule_friday_flag", updateWeekdays.s_weekday_schedule_friday_flag);
            htUpdateWeekDays.Add("@s_weekday_schedule_saturday_flag", updateWeekdays.s_weekday_schedule_saturday_flag);


            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_weekly_schedules", htUpdateWeekDays);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetStatus);
            }

            catch (Exception)
            {
                throw;
            }
        }


        public static SystemWeekdaySchedules GetSingleWeekSchedules(string s_weekday_schedule_system_id_pk)
        {
            SystemWeekdaySchedules  weekdays;
            try
            {
                Hashtable htGetWeekdays = new Hashtable();
                htGetWeekdays.Add("@s_weekday_schedule_system_id_pk", s_weekday_schedule_system_id_pk);
                weekdays = new SystemWeekdaySchedules();
                DataTable dtGetWeekdays = DataProxy.FetchDataTable("s_sp_get_single_weekday_schedules", htGetWeekdays);

                weekdays.s_weekday_schedule_system_id_pk = dtGetWeekdays.Rows[0]["s_weekday_schedule_system_id_pk"].ToString();
                weekdays.s_weekday_schedule_id_pk = dtGetWeekdays.Rows[0]["s_weekday_schedule_id_pk"].ToString();
                weekdays.s_weekday_schedule_name = dtGetWeekdays.Rows[0]["s_weekday_schedule_name"].ToString();
                weekdays.s_weekday_schedule_desc = dtGetWeekdays.Rows[0]["s_weekday_schedule_desc"].ToString();
                weekdays.s_weekday_schedule_status_id_fk = dtGetWeekdays.Rows[0]["s_weekday_schedule_status_id_fk"].ToString();
                weekdays.s_weekday_schedule_sunday_flag =Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_sunday_flag"]);
                weekdays.s_weekday_schedule_monday_flag = Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_monday_flag"]);
                weekdays.s_weekday_schedule_tuesday_flag = Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_tuesday_flag"]);
                weekdays.s_weekday_schedule_wednesday_flag = Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_wednesday_flag"]);
                weekdays.s_weekday_schedule_thursday_flag = Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_thursday_flag"]);
                weekdays.s_weekday_schedule_friday_flag = Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_friday_flag"]);
                weekdays.s_weekday_schedule_saturday_flag = Convert.ToBoolean(dtGetWeekdays.Rows[0]["s_weekday_schedule_saturday_flag"]);


                return weekdays;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetWeeklySchedules()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_weekly_schedules");
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateWeekdaySchedulesStatus(string s_weekday_schedule_system_id_pk)
        {
            Hashtable htUpdateWeekday = new Hashtable();
            htUpdateWeekday.Add("@s_weekday_schedule_system_id_pk", s_weekday_schedule_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_weekday_schedules_status", htUpdateWeekday);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
