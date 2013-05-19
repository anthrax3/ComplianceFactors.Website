using System;
using System.Data;
using System.Globalization;
using ComplicanceFactor.BusinessComponent;
using System.Threading;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.SystemHome.Catalog
{
    public class SessionRecurrance
    {
        CultureInfo culture = new CultureInfo("en-US");

        string[] formats = {"M/d/yyyy", "M/d/yyyy", 
                         "MM/dd/yyyy", "M/d/yyyy", 
                         "M/d/yyyy", "M/d/yyyy", 
                         "M/d/yyyy", "M/d/yyyy ", 
                         "MM/dd/yyyy", "M/dd/yyyy","MM-dd-yyyy","M-d-yyyy","MM.dd.yyyy","M.d.yyyy"};
        public DataTable Daily(string startDate, string endDate, string startFrom, string recurrenceEvery, string breakOccuranceCount, string breakOccranceDate, bool isWeekendChecked, bool isHolidayChecked, string u_holiday_schedule_system_id_pk, string s_weekday_schedule_system_id_pk)
        {

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            string strStartDate = Convert.ToDateTime(startDate, culture).ToString("MM/dd/yyyy", culture);
            string strEndDate = Convert.ToDateTime(endDate, culture).ToString("MM/dd/yyyy", culture);

            DateTime? dtStartDate;
            int temprecurrenceEvery;
            int tempbreakOccuranceCount;
            DateTime? dtpBreakOccuranceDate;
            DateTime dtFromDate = Convert.ToDateTime(strStartDate, culture);
            DateTime dtEndDate = Convert.ToDateTime(strEndDate);
            if (string.IsNullOrEmpty(startFrom))
               dtStartDate = null;
            else
                dtStartDate = Convert.ToDateTime(startFrom);
            if (int.TryParse(recurrenceEvery, out temprecurrenceEvery)) { }
            if (int.TryParse(breakOccuranceCount, out tempbreakOccuranceCount)) { }
            if (string.IsNullOrEmpty(breakOccranceDate))
                dtpBreakOccuranceDate = dtEndDate;
            else
                dtpBreakOccuranceDate = Convert.ToDateTime(breakOccranceDate);
            DataTable dtResult = GetSessionDatesDaily(dtFromDate, dtEndDate, dtStartDate, temprecurrenceEvery, tempbreakOccuranceCount, dtpBreakOccuranceDate, isWeekendChecked, isHolidayChecked, u_holiday_schedule_system_id_pk, s_weekday_schedule_system_id_pk);
            return dtResult;


        }
        #region daily
        //Daily Scenario 1 ,2, 3
        private DataTable GetSessionDatesDaily(DateTime dtFromDate, DateTime dtpEndDate, DateTime? dtpStartDate, int recurrenceEvery, int breakOccuranceCount, DateTime? dtpBreakOccuranceDate, bool isWeekendChecked, bool isHolidayChecked, string u_holiday_schedule_system_id_pk, string s_weekday_schedule_system_id_pk)
        {

            DataTable dtSession = new DataTable();
            dtSession.Columns.Add("Dates");
            if (dtpStartDate != null && dtpStartDate >= dtFromDate && dtpStartDate <= dtpEndDate)
                dtFromDate = Convert.ToDateTime(dtpStartDate);
            if (recurrenceEvery == 0)
                recurrenceEvery = 1;
            DateTime dtpTemp = dtFromDate;
            SystemCatalog GetAllHolidayAndWeekday = new SystemCatalog();
            GetAllHolidayAndWeekday.dtFromDate = dtFromDate;
            GetAllHolidayAndWeekday.dtpEndDate = dtpEndDate;
            GetAllHolidayAndWeekday.dtpStartDate = dtpStartDate;
            GetAllHolidayAndWeekday.recurrenceEvery = recurrenceEvery;
            GetAllHolidayAndWeekday.breakOccuranceCount = breakOccuranceCount;
            GetAllHolidayAndWeekday.dtpBreakOccuranceDate = dtpBreakOccuranceDate;
            GetAllHolidayAndWeekday.u_holiday_schedule_system_id_pk = u_holiday_schedule_system_id_pk;
            GetAllHolidayAndWeekday.s_weekday_schedule_system_id_pk = s_weekday_schedule_system_id_pk;



            if (isWeekendChecked == true && isHolidayChecked == true)
            {
                dtSession = SystemCatalogBLL.GetAllWeekdaysAndHolidays(GetAllHolidayAndWeekday);
            }
            else if (isWeekendChecked == true && isHolidayChecked == false)
            {
                dtSession = SystemCatalogBLL.GetWeekdays(GetAllHolidayAndWeekday);    
            }
            else if (isHolidayChecked == true && isWeekendChecked == false)
            {
                dtSession = SystemCatalogBLL.GetHolidays(GetAllHolidayAndWeekday);
            }
            else if (isWeekendChecked == false && isHolidayChecked == false)
            {
                GetAllHolidayAndWeekday.u_holiday_schedule_system_id_pk = null;
                GetAllHolidayAndWeekday.s_weekday_schedule_system_id_pk = null; 
                dtSession = SystemCatalogBLL.GetAllWeekdaysAndHolidays(GetAllHolidayAndWeekday);
            }
                //while (dtpTemp <= dtpEndDate)
                //{
                //    //if (isWeekendChecked)
                //    //{


                //    ///if (dtpTemp.DayOfWeek == DayOfWeek.Sunday || dtpTemp.DayOfWeek == DayOfWeek.Saturday)
                //    // isWeekendDate = true;
                //    //}


                //    //if (isWeekendChecked)
                //    //    if (isHolidayChecked)
                //    //        isHolidayDate = CheckIsHoliday(dtpTemp, u_holiday_schedule_system_id_pk);
                //    ////if (!isWeekendDate || !isHolidayDate)
                //    //if (!isWeekendDate && !isHolidayDate)
                //    //{
                //    //    DataRow dr;
                //    //    dr = dtSession.NewRow();
                //    //    dr["Dates"] = dtpTemp.ToShortDateString();
                //    //    dtSession.Rows.Add(dr);
                //    //    dtSession.AcceptChanges();

                //    //}

                //    //if (!isWeekendDate)
                //    //{
                //    //    DataRow dr;
                //    //    dr = dtSession.NewRow();
                //    //    dr["Dates"] = dtpTemp.ToShortDateString();
                //    //    dtSession.Rows.Add(dr);
                //    //    dtSession.AcceptChanges();
                //    //} 

                //    dtpTemp = dtpTemp.AddDays(recurrenceEvery);
                //    //dtpTemp.Date.AddDays(recurrenceEvery);
                //    isWeekendDate = false;
                //    isHolidayDate = false;
                //    //if (dtSession.Rows.Count == breakOccuranceCount)
                //    //{
                //    //    break;
                //    //}
                //    //else if (dtpTemp > dtpBreakOccuranceDate)
                //    //{
                //    //    break;
                //    //}
                //    if (breakOccuranceCount > 0 || dtpTemp > dtpBreakOccuranceDate)
                //    {
                //        if (dtSession.Rows.Count == breakOccuranceCount || dtpTemp > dtpBreakOccuranceDate)
                //            break;
                //    }

                //}
           

            return dtSession;
        }
        #endregion
        #region Weekly
        //Weekly Scenario 1 ,2, 3
        public DataTable Weekly(string startDate, string endDate, string startFrom, string recurrenceEvery, string breakOccurranceCount, string breakOccuranceDate, bool isChkSunday, bool ischkMonday, bool isChkTuesday, bool isChkWednesday, bool isChkThursday, bool isChkFriday, bool isChkSaturday)
        {

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            string strStartDate = Convert.ToDateTime(startDate, culture).ToString("MM/dd/yyyy", culture);
            string strEndDate = Convert.ToDateTime(endDate, culture).ToString("MM/dd/yyyy", culture);

            DateTime? dtStartDate;
            int temprecurrenceEvery;
            int tempbreakOccuranceCount;
            DateTime? dtpBreakOccuranceDate;
            DateTime dtFromDate = DateTime.ParseExact(strStartDate, formats, culture, DateTimeStyles.None);
            //Convert.ToDateTime(startDate);
            DateTime dtEndDate = DateTime.ParseExact(strEndDate, formats, culture, DateTimeStyles.None);
            if (string.IsNullOrEmpty(startFrom))
                dtStartDate = null;
            else
                dtStartDate = Convert.ToDateTime(startFrom);
            if (int.TryParse(recurrenceEvery, out temprecurrenceEvery)) { }
            if (int.TryParse(breakOccurranceCount, out tempbreakOccuranceCount)) { }
            if (string.IsNullOrEmpty(breakOccuranceDate))
                dtpBreakOccuranceDate = null;
            else
                dtpBreakOccuranceDate = Convert.ToDateTime(breakOccuranceDate);
            DataTable dtResult = GetSessionDatesWeekly(dtFromDate, dtEndDate, dtStartDate, temprecurrenceEvery, tempbreakOccuranceCount, dtpBreakOccuranceDate, isChkSunday, ischkMonday, isChkTuesday, isChkWednesday, isChkThursday, isChkFriday, isChkSaturday);
            return dtResult;
        }

        private DataTable GetSessionDatesWeekly(DateTime dtFromDate, DateTime dtpEndDate, DateTime? dtpStartDate, int recurrenceEvery, int breakOccuranceCount, DateTime? dtpBreakOccuranceDate, bool isChkSunday, bool isChkMonday, bool isChkTuesday, bool isChkWednesday, bool isChkThursday, bool isChkFriday, bool isChkSaturday)
        {
            DataTable dtSession = new DataTable();
            dtSession.Columns.Add("Dates");
            DataRow dr;
            if (dtpStartDate != null && dtpStartDate >= dtFromDate && dtpStartDate <= dtpEndDate)
                dtFromDate = Convert.ToDateTime(dtpStartDate);
            if (recurrenceEvery == 0)
                recurrenceEvery = 7;
            else
                recurrenceEvery = recurrenceEvery * 7;

            DateTime dtpTemp = dtFromDate;
            bool isFirst = true;
            bool isFinished = false;
            while (dtpTemp <= dtpEndDate)
            {
                DateTime dtpWeekfirstDate;
                if (isFirst)
                {
                    dtpWeekfirstDate = dtpTemp;
                    isFirst = false;
                }
                else
                    dtpWeekfirstDate = GetFirstDateOfWeek(dtpTemp, DayOfWeek.Monday);

                DateTime dtpWeeklastDate = GetLastDateOfWeek(dtpTemp, DayOfWeek.Sunday);

                for (DateTime counter = dtpWeekfirstDate; counter <= dtpWeeklastDate; counter = counter.AddDays(1))
                {
                    if (breakOccuranceCount != 0)
                    {
                        if (dtSession.Rows.Count == breakOccuranceCount || counter > dtpBreakOccuranceDate)
                            break;
                    }
                    if (isChkSunday && counter.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                        continue;
                    }
                    if (isChkMonday && counter.DayOfWeek == DayOfWeek.Monday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                        continue;
                    }
                    if (isChkTuesday && counter.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                        continue;
                    }
                    if (isChkWednesday && counter.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                    }
                    if (isChkThursday && counter.DayOfWeek == DayOfWeek.Thursday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                        continue;
                    }
                    if (isChkFriday && counter.DayOfWeek == DayOfWeek.Friday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                        continue;
                    }
                    if (isChkSaturday && counter.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dr = dtSession.NewRow();
                        dr["Dates"] = Convert.ToDateTime(counter, culture).ToString("MM/dd/yyyy", culture);
                        dtSession.Rows.Add(dr);
                        dtSession.AcceptChanges();
                        continue;
                    }
                }

                if (isFinished)
                    break;
                dtpTemp = dtpTemp.Date.AddDays(recurrenceEvery);
            }
            return dtSession;
        }

        public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
        public static DateTime GetLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime lastDayInWeek = dayInWeek.Date;
            while (lastDayInWeek.DayOfWeek != firstDay)
                lastDayInWeek = lastDayInWeek.AddDays(1);

            return lastDayInWeek;
        }
        #endregion
        #region Monthly
        //Monthly Scenario 1 ,2, 3
        public DataTable Monthly(string startDate, string endDate, string startFrom, string recurrenceEvery, string breakOccurranceCount, string breakOccuranceDate, string monthOccurance, string days)
        {

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            string strStartDate = Convert.ToDateTime(startDate, culture).ToString("MM/dd/yyyy", culture);
            string strEndDate = Convert.ToDateTime(endDate, culture).ToString("MM/dd/yyyy", culture);

            DateTime? dtStartDate;
            int tempRecurrenceEvery = 0;
            int tempBreakOccuranceCount = 0;
            DateTime? dtpBreakOccuranceDate;
            DateTime dtFromDate = DateTime.ParseExact(strStartDate, formats, culture, DateTimeStyles.None);
            //Convert.ToDateTime(startDate);
            DateTime dtEndDate = DateTime.ParseExact(strEndDate, formats, culture, DateTimeStyles.None);
            if (string.IsNullOrEmpty(startFrom))
                dtStartDate = null;
            else
                dtStartDate = Convert.ToDateTime(startFrom);
            if (int.TryParse(recurrenceEvery, out tempRecurrenceEvery)) { }
            if (int.TryParse(breakOccurranceCount, out tempBreakOccuranceCount)) { }
            if (string.IsNullOrEmpty(breakOccuranceDate))
                dtpBreakOccuranceDate = null;
            else
                dtpBreakOccuranceDate = Convert.ToDateTime(breakOccuranceDate);

            SessionDayofWeek enMonthOccurance = SessionDayofWeek.First;
            if (monthOccurance == "First")
                enMonthOccurance = SessionDayofWeek.First;
            if (monthOccurance == "Second")
                enMonthOccurance = SessionDayofWeek.Second;
            if (monthOccurance == "Third")
                enMonthOccurance = SessionDayofWeek.Third;
            if (monthOccurance == "Forth")
                enMonthOccurance = SessionDayofWeek.Forth;
            if (monthOccurance == "Last")
                enMonthOccurance = SessionDayofWeek.Last;

            DayOfWeek dayofWeek = DayOfWeek.Sunday;
            if (days == "Monday")
                dayofWeek = DayOfWeek.Monday;
            if (days == "Tuesday")
                dayofWeek = DayOfWeek.Tuesday;
            if (days == "Wednesday")
                dayofWeek = DayOfWeek.Wednesday;
            if (days == "Thursday")
                dayofWeek = DayOfWeek.Thursday;
            if (days == "Friday")
                dayofWeek = DayOfWeek.Friday;
            if (days == "Saturday")
                dayofWeek = DayOfWeek.Saturday;
            if (days == "Sanday")
                dayofWeek = DayOfWeek.Sunday;

            DataTable dtResult = GetSessionDatesMonthly(dtFromDate, dtEndDate, dtStartDate, tempRecurrenceEvery, tempBreakOccuranceCount, dtpBreakOccuranceDate, enMonthOccurance, dayofWeek);
            return dtResult;
        }

        private DataTable GetSessionDatesMonthly(DateTime dtFromDate, DateTime dtpEndDate, DateTime? dtpStartDate, int recurrenceEvery, int breakOccuranceCount, DateTime? dtpBreakOccuranceDate, SessionDayofWeek enMonthOccurance, DayOfWeek dayofWeek)
        {
            DataTable dtSession = new DataTable();
            dtSession.Columns.Add("Dates");
            if (dtpStartDate != null && dtpStartDate >= dtFromDate && dtpStartDate <= dtpEndDate)
                dtFromDate = Convert.ToDateTime(dtpStartDate);
            if (recurrenceEvery == 0)
                recurrenceEvery = 1;

            DateTime dtpMonthDate = dtFromDate;

            //Check Date is nth day
            DateTime dtpResult = GetDateForWeekDay(dayofWeek, (int)enMonthOccurance, dtpMonthDate.Month, dtpMonthDate.Year);
            if (dtpResult < dtFromDate)
                dtpMonthDate = dtpMonthDate.AddMonths(1);

            while (dtpMonthDate <= dtpEndDate)
            {
                dtpMonthDate = FindTheSpecificWeekday(dtpMonthDate, (int)enMonthOccurance, dayofWeek);
                if (dtpMonthDate > dtpBreakOccuranceDate)
                    break;

                DataRow dr;
                dr = dtSession.NewRow();
                dr["Dates"] = Convert.ToDateTime(dtpMonthDate, culture).ToString("MM/dd/yyyy", culture);
                dtSession.Rows.Add(dr);
                dtSession.AcceptChanges();

                dtpMonthDate = dtpMonthDate.AddMonths(recurrenceEvery);
                if (dtSession.Rows.Count == breakOccuranceCount)
                    break;
            }
            return dtSession;
        }

        private DateTime GetDateForWeekDay(DayOfWeek DesiredDay, int Occurrence, int Month, int Year)
        {
            DateTime dtSat = new DateTime(Year, Month, 1);
            int j = 0;
            if (Convert.ToInt32(DesiredDay) - Convert.ToInt32(dtSat.DayOfWeek) >= 0)
                j = Convert.ToInt32(DesiredDay) - Convert.ToInt32(dtSat.DayOfWeek) + 1;
            else
                j = (7 - Convert.ToInt32(dtSat.DayOfWeek)) + (Convert.ToInt32(DesiredDay) + 1);

            int date = j + (Occurrence - 1) * 7;
            DateTime dtpResult = new DateTime(Year, Month, date);
            return dtpResult;
        }

        public DateTime FindTheSpecificWeekday(DateTime dtDate, int nth, System.DayOfWeek day_of_the_week)
        {
            // start from the first day of the month
            int year;
            int month;
            DateTime dt;
            year = dtDate.Year;
            month = dtDate.Month;
            dt = new DateTime(year, month, 1);

            while (dt.DayOfWeek != day_of_the_week)
            {
                dt = dt.AddDays(1);
            }

            if (dt.Month != month)
            {
                // we skip to the next month, we throw an exception
                throw new ArgumentOutOfRangeException("The given month has less than " + nth.ToString() + " " + day_of_the_week.ToString() + "s");
            }

            // Complete the gap to the nth week
            dt = dt.AddDays((nth - 1) * 7);
            return dt;
        }


        enum SessionDayofWeek
        {
            First = 1,
            Second,
            Third,
            Forth,
            Last
        }
        #endregion
        #region Yearly
        public DataTable Yearly(string startDate, string endDate, string startFrom, string recurrenceEvery, string breakOccurranceCount, string breakOccuranceDate, string occuranceDate)
        {

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            string strStartDate = Convert.ToDateTime(startDate, culture).ToString("MM/dd/yyyy", culture);
            string strEndDate = Convert.ToDateTime(endDate, culture).ToString("MM/dd/yyyy", culture);

            DateTime? dtStartDate;
            int tempRecurrenceEvery;
            int tempBreakOccuranceCount;
            DateTime? dtpBreakOccuranceDate;
            DateTime dtpOccuranceDateOn;
            DateTime dtFromDate = DateTime.ParseExact(strStartDate, formats, culture, DateTimeStyles.None);
            //Convert.ToDateTime(startDate);
            DateTime dtEndDate = DateTime.ParseExact(strEndDate, formats, culture, DateTimeStyles.None);

            if (string.IsNullOrEmpty(startFrom))
                dtStartDate = null;
            else
                dtStartDate = Convert.ToDateTime(startFrom);

            if (int.TryParse(recurrenceEvery, out tempRecurrenceEvery)) { }
            if (int.TryParse(breakOccurranceCount, out tempBreakOccuranceCount)) { }

            if (string.IsNullOrEmpty(breakOccuranceDate))
                dtpBreakOccuranceDate = dtEndDate;
            else
                dtpBreakOccuranceDate = Convert.ToDateTime(breakOccuranceDate);

            if (!string.IsNullOrEmpty(occuranceDate))
                dtpOccuranceDateOn = Convert.ToDateTime(occuranceDate);
            else
                dtpOccuranceDateOn = dtFromDate;

            DataTable dtResult = GetSessionDatesYearly(dtFromDate, dtEndDate, dtStartDate, tempRecurrenceEvery, tempBreakOccuranceCount, dtpBreakOccuranceDate, dtpOccuranceDateOn);
            return dtResult;

        }
        private DataTable GetSessionDatesYearly(DateTime dtFromDate, DateTime dtpEndDate, DateTime? dtpStartDate, int recurrenceEvery, int breakOccuranceCount, DateTime? dtpBreakOccuranceDate, DateTime dtpOccuranceDateOn)
        {
            DataTable dtSession = new DataTable();
            dtSession.Columns.Add("Dates");
            if (dtpStartDate != null && dtpStartDate >= dtFromDate && dtpStartDate <= dtpEndDate)
                dtFromDate = Convert.ToDateTime(dtpStartDate);
            if (recurrenceEvery == 0)
                recurrenceEvery = 1;

            DateTime dtpTemp = new DateTime(dtFromDate.Year, dtpOccuranceDateOn.Month, dtpOccuranceDateOn.Day);
            //DateTime dtpTemp = dtFromDate;
            while (dtpTemp <= dtpEndDate)
            {
                DataRow dr;
                dr = dtSession.NewRow();
                dr["Dates"] = Convert.ToDateTime(dtpTemp, culture).ToString("MM/dd/yyyy", culture);
                dtSession.Rows.Add(dr);
                dtSession.AcceptChanges();

                dtpTemp = dtpTemp.AddYears(recurrenceEvery);
                if (dtSession.Rows.Count == breakOccuranceCount || dtpTemp > dtpBreakOccuranceDate)
                    break;
            }
            return dtSession;
        }
        #endregion
        //bool CheckIsHoliday(DateTime dtDate, string u_holiday_schedule_system_id_pk)
        //{

        //    DataTable dtHoliday = new DataTable();
        //    dtHoliday = SystemCatalogBLL.GetHolidays(dtFromDate, dtpEndDate, u_holiday_schedule_system_id_pk);
        //    if (dtHoliday.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        //bool CheckIsHoliday(DateTime dtDate)
        //{
        //    return false;
        //}
    }
}