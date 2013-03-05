using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemInstructor
    {
        public string c_instructor_course { get; set; }
        public string c_instructor_course_system_id_pk { get; set; }
        public string c_instructor_id_fk { get; set; }
        public string c_course_id_fk { get; set; }
    }
}
