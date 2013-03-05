using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class ComplainceVehicle
    {
        public string vehicle_fk { get; set; }
        public string vehicle_vin { get; set; }
        public string vehicle_id { get; set; }
        public string vehicle_licence { get; set; }
        public string vehicle_make { get; set; }
        public string vehicle_type { get; set; }
        public string vehicle_model { get; set; }
        public string vehicle_year { get; set; }
        public string vehicle_state { get; set; }

    }
}
