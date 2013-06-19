using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemDigitalMediaFiles
    {
        public string s_digital_media_file_system_id_pk { get; set; }
        public string s_digital_media_file_id_pk { get; set; }
        public string s_digital_media_file_name { get; set; }
        public string s_digital_media_file_description { get; set; }
        public string s_digital_media_file_type_id_fk { get; set; }
        public string s_digital_media_file_date_time { get; set; }
        public string s_digital_media_source_file_name { get; set; }
    }
}
