using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class CommodityViewModel
    {
        public int CommodityId { get; set; }

        public string CommodityName { get; set; }

        public string CommodityDescription { get; set; }

        public decimal CommodityUnitPrice { get; set; }
        public CompanyViewModel Company { get; set; }
        public string Username { get; set; }
        public int FarmerId { get; set; }
        public FarmerViewModel Farmer { get; set; }
        public int CompanyId { get; set; }
        public decimal NumberOfUnits { get; set; }
        public CommodityUnitViewModel CommodityUnit { get; set; }
        public int CommodityUnitId { get; set; }
        public CommodityCategoryViewModel CommodityCategory { get; set; }
        public int CommodityCategoryId { get; set; }
    }
}
