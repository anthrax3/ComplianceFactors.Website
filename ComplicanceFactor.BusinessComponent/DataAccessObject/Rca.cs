using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class Rca
    {
        public string c_case_id_pk { get; set; }
        public string c_rca_summary { get; set; }
        public bool c_rca_have_sufficient_information { get; set; }
        public string c_rca_category_people { get; set; }
        public string c_rca_category_procedure { get; set; }
        public string c_rca_category_hardware { get; set; }
        public string c_rca_category_environment { get; set; }
        public string c_rca_eternal { get; set; }
        public string c_rca_corrective_action_solutions { get; set; }
        public string c_rca_activators { get; set; }
        public string c_rca_consequences { get; set; }
    }
}
