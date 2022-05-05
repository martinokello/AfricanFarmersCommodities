using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmersCommodities.Domain
{
    public class IntermediateSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntermediateScheduleId { get; set; } = 0;
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public string Operation { get; set; }
        [ForeignKey("OriginName")]
        public int OriginLocationId { get; set; }
        public Location OriginName { get; set; }
        [ForeignKey("DestinationName")]
        public int DestinationLocationId { get; set; }
        public Location DestinationName { get; set; }
        [ForeignKey("TransportSchedule")]
        public int TransportScheduleId { get; set; }
        public string IntermediateTransportScheduleName { get; set; }
        public TransportSchedule TransportSchedule { get; set; }
        public bool HasReachedFinalDestination {get;set;}
        public DateTime DateStartFromOrigin { get; set; } = DateTime.Now;
        public DateTime DateEndAtDestination { get; set; } = DateTime.Now;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
