using System;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class FoodHubStorageViewModel
    {
        public int FoodHubStorageId { get; set; }
        public int FoodHubId { get; set; }
        public string FoodHubStorageName { get; set; }
        //public FoodHubViewModel FoodHubViewModel{ get;set;}
        public decimal DryStorageCapacity { get; set; }
        public decimal RefreigeratedStorageCapacity { get; set; }
        public decimal UsedDryStorageCapacity { get; set; }
        public decimal UsedRefreigeratedStorageCapacity { get; set; }
        //public CommodityUnitViewModel CommodityUnit { get; set; }
        public int CommodityUnitId { get; set; }
    }
}