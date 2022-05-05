using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class DriverSchedulesNote
    {
        [Key]
        public int DriveScheduleNoteId { get; set; }
        public string DriverNote { get; set; }
        [ForeignKey("TransportSchedule")]
        public int TransportScheduleId { get; set; }
        public TransportSchedule TransportSchedule { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public bool IsOriginNote { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
