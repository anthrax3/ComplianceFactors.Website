using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
   public class EmployeeCatalog
    {
       public string c_course_id_pk { get; set; }
       public string c_course_desc { get; set; }
       public string c_course_abstract { get; set; }
       public string c_course_version { get; set; }
       public string c_course_title { get; set; }
       public string c_course_system_id_pk { get; set; }
       public string keyword { get; set; }
       public string categoryName { get; set; }
       public string c_course_recurrences_text { get; set; }
       public string c_type { get; set; }
       public string c_delivery_id_fk{ get; set;}
       public string c_language { get; set; }
       public string c_delivery_type_text { get; set; }
       public bool c_delivery_approval_req { get; set; }
       public int c_delivery_count { get; set; }
       public string c_delivery_waitlist_flag { get; set; }
    }
}
