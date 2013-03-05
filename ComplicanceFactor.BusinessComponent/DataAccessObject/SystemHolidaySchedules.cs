using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemHolidaySchedules
    {
        //s_tb_holiday_schedules Table

        public string u_holiday_schedule_system_id_pk { get; set; }
        public string u_holiday_schedule_id { get; set; }
        public string u_holiday_schedule_name { get; set; }
        public string u_holiday_schedule_desc { get; set; }
        public string u_holiday_schedule_status_id_fk { get; set; }

        //For xml to store holiday
        public string u_holiday_dates { get; set; }

        //  s_tb_holiday_dates Table
        public string u_holiday_system_id_pk { get; set; }
        public string u_holiday_schedule_id_fk { get; set; }
        public string u_holiday_name { get; set; }
        public string u_holiday_desc { get; set; }
        public  DateTime u_holiday_date { get; set; }
    }
}
