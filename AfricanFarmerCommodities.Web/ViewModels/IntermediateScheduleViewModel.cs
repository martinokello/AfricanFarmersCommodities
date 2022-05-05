using System;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class IntermediateScheduleViewModel
    {    
        public int IntermediateScheduleId { get; set; } = 0;
        public VehicleViewModel Vehicle { get; set; }
        public string IntermediateTransportScheduleName { get; set; }
        public int VehicleId { get; set; }
        public string Operation { get; set; }
        public int OriginLocationId { get; set; }
        public LocationViewModel OriginName { get; set; }
        public int DestinationLocationId { get; set; }
        public LocationViewModel DestinationName { get; set; }
        public int TransportScheduleId { get; set; }
        public bool HasReachedFinalDestination { get; set; }
        public DateTime DateStartFromOrigin { get; set; } = DateTime.Now;
        public DateTime DateEndAtDestination { get; set; } = DateTime.Now;
    }
}