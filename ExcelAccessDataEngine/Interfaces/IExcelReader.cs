using ExcelAccessDataEngine.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAccessDataEngine.Interfaces
{
    public interface IExcelReader
    {
        //UserBadgeTo[] ReadExcel(string filePath);
  
        Stream GenerateExcelFile(List<CommodityAndQuantity> rowContent);
        Stream GenerateExcelFile(List<CommodityAndQuantity> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<CommodityAndGrossReturns> rowContent);
        Stream GenerateExcelFile(List<CommodityAndGrossReturns> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<FarmerCommodityAndQuantity> rowContent);
        Stream GenerateExcelFile(List<FarmerCommodityAndQuantity> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<FarmerCommodityAndGrossReturns> rowContent);
        Stream GenerateExcelFile(List<FarmerCommodityAndGrossReturns> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<VehicleNumbersScheduled> rowContent);
        Stream GenerateExcelFile(List<VehicleNumbersScheduled> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<VehicleCostReturnsScheduled> rowContent);
        Stream GenerateExcelFile(List<VehicleCostReturnsScheduled> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByNumber> rowContent);
        Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByNumber> rowContent, DateTime dateBegin, DateTime dateEnd);
        Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByCostReturns> rowContent);
        Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByCostReturns> rowContent, DateTime dateBegin, DateTime dateEnd);
        }

}
