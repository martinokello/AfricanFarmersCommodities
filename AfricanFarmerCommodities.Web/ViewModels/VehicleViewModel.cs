using System;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public int VehicleCategoryId { get; set; }
        public int VehicleCapacityId { get; set; }
        public bool InGoodCondition { get; set; }
        public int CompanyId { get; set; }
        public string VehicleRegistration { get; set; }
        public CompanyViewModel Company { get; set; }
        public VehicleCategoryViewModel VehicleCategory { get; set; }
        public VehicleCapacityViewModel VehicleCapacity { get; set; }
    }

    public class VehicleInsertViewModel
    {
        public int VehicleId { get; set; }
        public int VehicleCategoryId { get; set; }
        public int CompanyId { get; set; }
        public string VehicleRegistration { get; set; }
        public int VehicleCapacityId { get; set; }
    }
}