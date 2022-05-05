using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmersCommodities.Domain
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Vehicle Vehicle { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        [ForeignKey("TransportSchedule")]
        public int TransportScheduleId{ get; set; }
        public TransportSchedule TransportSchedule { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
