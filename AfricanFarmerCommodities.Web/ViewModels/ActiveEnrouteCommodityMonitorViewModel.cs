using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class ActiveEnrouteCommodityMonitorViewModel
    {
        public int ActiveEnrouteCommodityMonitorId { get; set; }
        public TransportScheduleViewModel TransportSchedule { get; set; }
        public int TransportScheduleId { get; set; }
    }
}
