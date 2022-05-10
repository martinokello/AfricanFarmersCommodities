using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class TransportLogViewModel
    {
        public int TransportLogId { set; get; }
        public string TransportLogName { get; set; }
        public int TransportScheduleId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
