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
    public class SystemHolidaySchedulesBLL
    {
        /// <summary>
        /// Create holiday Schedule with holiday dates
        /// </summary>
        /// <param name="holidays"></param>
        /// <returns></returns>
        public static int CreateHolidaySchedules(SystemHolidaySchedules holidays)
        {
            Hashtable htCreateHoliDays = new Hashtable();
            htCreateHoliDays.Add("@u_holiday_schedule_system_id_pk", holidays.u_holiday_schedule_system_id_pk);
            htCreateHoliDays.Add("@u_holiday_schedule_id", holidays.u_holiday_schedule_id);
            htCreateHoliDays.Add("@u_holiday_schedule_name", holidays.u_holiday_schedule_name);
            htCreateHoliDays.Add("@u_holiday_schedule_desc", holidays.u_holiday_schedule_desc);
            htCreateHoliDays.Add("@u_holiday_schedule_status_id_fk", holidays.u_holiday_schedule_status_id_fk);
            htCreateHoliDays.Add("@u_holiday_dates", holidays.u_holiday_dates);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_holiday_schedules", htCreateHoliDays);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Holiday Schedule
        /// </summary>
        /// <param name="holidaySchedule"></param>
        /// <returns></returns>
        public static int  UpdateHolidaySchedules(SystemHolidaySchedules holidaySchedule)
        {
            Hashtable htHolidaySchedules = new Hashtable();
            htHolidaySchedules.Add("@u_holiday_schedule_system_id_pk", holidaySchedule.u_holiday_schedule_system_id_pk);
            htHolidaySchedules.Add("@u_holiday_schedule_id", holidaySchedule.u_holiday_schedule_id);
            htHolidaySchedules.Add("@u_holiday_schedule_name", holidaySchedule.u_holiday_schedule_name);
            htHolidaySchedules.Add("@u_holiday_schedule_desc", holidaySchedule.u_holiday_schedule_desc);
            htHolidaySchedules.Add("@u_holiday_schedule_status_id_fk", holidaySchedule.u_holiday_schedule_status_id_fk);
            //htCreateHoliDays.Add("@u_holiday_dates", holidays.u_holiday_dates);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_holiday_schedules", htHolidaySchedules);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create Holiday Dates
        /// </summary>
        /// <param name="holidayDate"></param>
        /// <returns></returns>
        public static int CreateHolidayDates(SystemHolidaySchedules holidayDate)
        {
            Hashtable htUpdateHolidayDates = new Hashtable();
            htUpdateHolidayDates.Add("@u_holiday_system_id_pk", holidayDate.u_holiday_system_id_pk);
            htUpdateHolidayDates.Add("@u_holiday_name", holidayDate.u_holiday_name);
            htUpdateHolidayDates.Add("@u_holiday_schedule_id_fk", holidayDate.u_holiday_schedule_id_fk);
            htUpdateHolidayDates.Add("@u_holiday_desc", holidayDate.u_holiday_desc);
            htUpdateHolidayDates.Add("@u_holiday_date", holidayDate.u_holiday_date);        
          
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_holiday_dates", htUpdateHolidayDates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Uodate Holiday Dates
        /// </summary>
        /// <param name="holidayDate"></param>
        /// <returns></returns>
        public static int UpdateHolidayDates(SystemHolidaySchedules holidayDate)
        {
            Hashtable htUpdateHolidayDates = new Hashtable();
            htUpdateHolidayDates.Add("@u_holiday_system_id_pk", holidayDate.u_holiday_system_id_pk);
            htUpdateHolidayDates.Add("@u_holiday_name", holidayDate.u_holiday_name);
            htUpdateHolidayDates.Add("@u_holiday_desc", holidayDate.u_holiday_desc);
            htUpdateHolidayDates.Add("@u_holiday_date", holidayDate.u_holiday_date);        
          
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_holiday_dates", htUpdateHolidayDates);
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


        /// <summary>
        /// Select all the holidays for schedule
        /// </summary>
        /// <param name="u_holiday_schedule_id_fk"></param>
        /// <returns></returns>
        public static DataTable GetAllHolidayDates(string u_holiday_schedule_id_fk)
        {
            Hashtable htgetHolidayDates = new Hashtable();
            htgetHolidayDates.Add("@u_holiday_schedule_id_fk", u_holiday_schedule_id_fk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_holiday_dates", htgetHolidayDates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Search Holiday schedule
        /// </summary>
        /// <returns></returns>
        public static DataTable SearchHolidaySchedule()
        {
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_holiday_schedule");
            }

            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To get Holiday Schedules
        /// </summary>
        /// <param name="u_holiday_schedule_system_id_pk"></param>
        /// <returns></returns>
        public static SystemHolidaySchedules GetHolidayschedule(string u_holiday_schedule_system_id_pk)
        {
            SystemHolidaySchedules holidays;
            try
            {
                Hashtable htgetHolidayDates = new Hashtable();
                htgetHolidayDates.Add("@u_holiday_schedule_system_id_pk", u_holiday_schedule_system_id_pk);
                holidays = new SystemHolidaySchedules();
                DataTable dtGetHolidaydays = DataProxy.FetchDataTable("s_sp_get_holiday_schedule", htgetHolidayDates);

                holidays.u_holiday_schedule_id = dtGetHolidaydays.Rows[0]["u_holiday_schedule_id"].ToString();
                holidays.u_holiday_schedule_name = dtGetHolidaydays.Rows[0]["u_holiday_schedule_name"].ToString();
                holidays.u_holiday_schedule_desc = dtGetHolidaydays.Rows[0]["u_holiday_schedule_desc"].ToString();
                holidays.u_holiday_schedule_status_id_fk = dtGetHolidaydays.Rows[0]["u_holiday_schedule_status_id_fk"].ToString();
                

                return holidays;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get single holiday dates for edit
        /// </summary>
        /// <param name="u_holiday_system_id_pk"></param>
        /// <returns></returns>
        public static SystemHolidaySchedules GetSingleHolidayDate(string u_holiday_system_id_pk)
        {
            SystemHolidaySchedules holidays;
            try
            {
                Hashtable htgetHolidayDate = new Hashtable();
                htgetHolidayDate.Add("@u_holiday_system_id_pk", u_holiday_system_id_pk);
                holidays = new SystemHolidaySchedules();
                DataTable dtGetHoliday = DataProxy.FetchDataTable("s_sp_get_single_holiday_date", htgetHolidayDate);

                holidays.u_holiday_name = dtGetHoliday.Rows[0]["u_holiday_name"].ToString();
                holidays.u_holiday_desc = dtGetHoliday.Rows[0]["u_holiday_desc"].ToString();
                holidays.u_holiday_date =Convert.ToDateTime(dtGetHoliday.Rows[0]["u_holiday_date"]);
                //holidays.u_holiday_schedule_status_id_fk = dtGetHoliday.Rows[0]["u_holiday_schedule_status_id_fk"].ToString();


                return holidays;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete the single Holiday dates
        /// </summary>
        /// <param name="u_holiday_system_id_pk"></param>
        /// <returns></returns>
        public static int DeleteSingleHoliday(string u_holiday_system_id_pk)
        {
            Hashtable htdeleteHoliday = new Hashtable();
            htdeleteHoliday.Add("@u_holiday_system_id_pk", u_holiday_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_holiday_dates", htdeleteHoliday);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reset Holiday dates 
        /// </summary>
        /// <param name="resetHolidayDate"></param>
        /// <returns></returns>
        public static int ResetHoliday(SystemHolidaySchedules resetHolidayDate)
        {
            Hashtable htresetHoliday = new Hashtable();
            htresetHoliday.Add("@u_holiday_schedule_system_id_pk", resetHolidayDate.u_holiday_schedule_system_id_pk);
            htresetHoliday.Add("@u_holiday_dates", resetHolidayDate.u_holiday_dates);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_holiday_dates", htresetHoliday);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update the Status to Inactive
        /// </summary>
        /// <param name="u_holiday_schedule_system_id_pk"></param>
        /// <returns></returns>
        public static int UpdateHolidayStatus(string u_holiday_schedule_system_id_pk)
        {
            Hashtable htUpdateHolidayStatus = new Hashtable();
            htUpdateHolidayStatus.Add("@u_holiday_schedule_system_id_pk", u_holiday_schedule_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_holiday_schedule_status", htUpdateHolidayStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
