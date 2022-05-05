using AfricanFarmersCommodities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class TransportScheduleViewModel
    {
        public int TransportScheduleId { get; set; }

        public int OriginLocationId { get; set; }
        public int DestinationLocationId { get; set; }
        public string TransportScheduleName { get; set; }
        public string Description { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public int VehicleId { get; set; }
        public TransportPricingViewModel TransportPricing { get; set; }
        public int TransportPricingId { get; set; }
        public LocationViewModel OriginName { get; set; }
        public LocationViewModel DestinationName { get; set; }
        public DateTime DateStartFromOrigin { get; set; }
        public DateTime DateEndAtDestination { get; set; }
        public bool HasIntermediateDrops { get; set; }
    }
}
