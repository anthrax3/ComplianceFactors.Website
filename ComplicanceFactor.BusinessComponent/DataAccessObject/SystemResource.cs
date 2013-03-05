using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemResource
    {
      public string c_resource_system_id_pk {get ; set;}
      public string c_resource_id_pk {get ; set;}
      public string c_resource_name {get ; set;}
      public string c_resource_description {get ; set;}     
      public string c_resource_serial_number {get ; set;}
      public string c_resource_status_id { get; set; }
      public string c_resource_type_id_fk { get; set; }
      public string s_resource_locale { get; set; }
      public string s_resource_locale_system_id_pk { get; set; }
      public string s_resource_locale_name { get; set; }
      public string s_resource_locale_description { get; set; }
      public string s_locale_text { get; set; }
      public string s_locale_id_fk { get; set; }
      public string s_resource_system_id_fk { get; set; }
    }
}
