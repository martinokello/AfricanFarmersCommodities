using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAccessDataEngine.DomainModel
{
    public class CommodityAndQuantity
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public int Quantity { get; set; }
    }

    public class CommodityAndGrossReturns
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public decimal GrossReturns { get; set; }
    }

    public class FarmerCommodityAndQuantity
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string CommodityName { get; set; }
        public int CommodityId { get; set; }
        public int Quantity { get; set; }
    }
    public class FarmerCommodityAndGrossReturns
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string CommodityName { get; set; }
        public int CommodityId { get; set; }
        public decimal GrossReturns { get; set; }
    }

    public class VehicleNumbersScheduled
    {
        public int NumbersOfSchedules { get; set; }
        public string VehicleCategoryName { get; set; }
    }
    public class VehicleCostReturnsScheduled
    {
        public decimal GrossReturns { get; set; }
        public string VehicleCategoryName { get; set; }
    }

    public class FarmerVehicleCategoryUsageByNumber
    {
        public string FarmerName { get; set; }
        public string VehicleCategoryName { get; set; }
        public decimal VechicleCapacity { get; set; }
        public int NumberOfVehicles { get; set; }
    }

    public class FarmerVehicleCategoryUsageByCostReturns
    {
        public string FarmerName { get; set; }
        public string VehicleCategoryName { get; set; }
        public decimal VechicleCapacity { get; set; }
        public decimal GrossReturns { get; set; }
    }
}
