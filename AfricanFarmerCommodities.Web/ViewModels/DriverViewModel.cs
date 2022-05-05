using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class DriverViewModel
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public int VehicleId { get; set; }
        public int TransportScheduleId { get; set; }
        public TransportScheduleViewModel TransportSchedule { get; set; }
    }
}
