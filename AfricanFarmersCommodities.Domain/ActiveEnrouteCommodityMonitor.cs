using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class ActiveEnrouteCommodityMonitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActiveEnrouteCommodityMonitorId { get; set; } = 0;
        public TransportSchedule TransportSchedule { get; set; }
        [ForeignKey("TransportSchedule")]
        public int TransportScheduleId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
