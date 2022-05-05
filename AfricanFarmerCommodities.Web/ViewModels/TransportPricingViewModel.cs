using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class TransportPricingViewModel
    {
        public int TransportPricingId { get; set; }
        public decimal CarPricing { get; set; }
        public decimal MiniBusPricing { get; set; }
        public decimal TaxiPricing { get; set; }
        public decimal PickupTruckPricing { get; set; }
        public decimal TruckPricing { get; set; }
        public decimal BusPricing { get; set; }
        public decimal TrainPricing { get; set; }
        public decimal TramPricing { get; set; }
        public decimal AirPricing { get; set; }
        public decimal ShipPricing { get; set; }
        public string TransportPricingName { get; set; }
        public string Description { get; set; }
    }
}
