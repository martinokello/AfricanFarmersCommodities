using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class TransportLog
    {
        [Key]
        public int TransportLogId { set; get; }
        public string TransportLogName { get; set; }
        [ForeignKey("TransportSchedule")]
        public int TransportScheduleId { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
    }
}
