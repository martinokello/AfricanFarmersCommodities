using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmersCommodities.Domain
{
    public class TransportPricing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportPricingId { get; set; } = 0;
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
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
