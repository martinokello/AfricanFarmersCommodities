using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class FarmerViewModel
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }
        public CompanyViewModel Company { get; set; }
        public int CompanyId { get; set; }
    } 

    public class FarmerInsertViewModel
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }
    }
}
