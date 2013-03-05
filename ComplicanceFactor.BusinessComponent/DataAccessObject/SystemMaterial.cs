using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemMaterial
    {
        public string c_material_system_id_pk { get; set; }
        public string c_material_id_pk { get; set; }
        public string c_material_name { get; set; }
        public string c_material_description { get; set; }
        public string c_material_status_id { get; set; }
        public string c_material_type_id_fk { get; set; }
        public string c_material_file_guid { get; set; }
        public string c_material_file_name { get; set; }

        public string s_material_locale { get; set; }
        public string s_material_locale_system_id_pk { get; set; }
        public string s_material_locale_name { get; set; }
        public string s_material_locale_description { get; set; }
        public string s_locale_text { get; set; }
        public string s_locale_id_fk { get; set; }
        public string s_material_system_id_fk { get; set; }
        public string s_material_locale_file_guid { get; set; }
        public string s_material_locale_file_name { get; set; }

    }
}
