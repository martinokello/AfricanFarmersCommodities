using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class TransportSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportScheduleId { get; set; } = 0;
        public string TransportScheduleName { get; set; }
        public string Description { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        [ForeignKey("TransportPricing")]
        public int TransportPricingId { get; set; }
        public TransportPricing TransportPricing { get; set; }
        public Location OriginName { get; set; }
        [ForeignKey("OriginName")]
        public int OriginLocationId { get; set; }
        public Location DestinationName { get; set; }
        [ForeignKey("DestinationName")]
        public int DestinationLocationId { get; set; }
        public DateTime DateStartFromOrigin { get; set; }
        public DateTime DateEndAtDestination { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public bool HasIntermediateDrops { get; set; }
    }
}
