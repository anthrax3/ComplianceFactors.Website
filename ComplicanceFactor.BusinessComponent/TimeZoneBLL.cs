using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class TimeZoneBLL
    {
        public static TimeZoneDAO GetDateTime(int s_timezoneId)
        {
            TimeZoneDAO tz;
            try
            {
                Hashtable htGetTimeZoneDateTime = new Hashtable();
                htGetTimeZoneDateTime.Add("@s_time_zone_id_pk", s_timezoneId);
                tz = new TimeZoneDAO();
                DataTable dtGetTime = DataProxy.FetchDataTable("s_sp_get_time", htGetTimeZoneDateTime);
                tz.s_date_time = Convert.ToDateTime(dtGetTime.Rows[0]["s_timezone_datetime"]);
                tz.s_time_zone_display = dtGetTime.Rows[0]["s_time_zone_display"].ToString();
                return tz;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
