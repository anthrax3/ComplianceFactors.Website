using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemWeekdaySchedules
    {
        public string s_weekday_schedule_system_id_pk { get; set; }
        public string s_weekday_schedule_id_pk { get; set; }
        public string s_weekday_schedule_name { get; set; }
        public string s_weekday_schedule_desc { get; set; }
        public string s_weekday_schedule_status_id_fk { get; set; }
        public bool s_weekday_schedule_sunday_flag { get; set; }
        public bool s_weekday_schedule_monday_flag { get; set; }
        public bool s_weekday_schedule_tuesday_flag { get; set; }
        public bool s_weekday_schedule_wednesday_flag { get; set; }
        public bool s_weekday_schedule_thursday_flag { get; set; }
        public bool s_weekday_schedule_friday_flag { get; set; }
        public bool s_weekday_schedule_saturday_flag { get; set; }
    }
}
