using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class PaymentViewModel
    {
        public CommodityViewModel[] Contents { get; set; }
        public string Username { get; set; }
        public decimal AmountPayable { get; set; }
    }
}
