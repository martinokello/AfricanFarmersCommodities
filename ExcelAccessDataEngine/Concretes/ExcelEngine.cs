using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelAccessDataEngine.DomainModel;
using ExcelAccessDataEngine.Interfaces;
using OfficeOpenXml;

namespace ExcelAccessDataEngine.Concretes
{
    public class ExcelEngine : IExcelReader
    {

        public Stream GenerateExcelFile(List<CommodityAndQuantity> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook;
                    var ws = wb.Worksheets.Add("Commodity Grouped By Quantity");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Commodity Grouped By Quantity";
                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Quantity";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.Quantity;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<CommodityAndQuantity> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook;
                    var ws = wb.Worksheets.Add($"Commodity Grouped By Quantity Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")} ");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Commodity Grouped By Quantity";
                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Quantity";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.Quantity;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }

        public Stream GenerateExcelFile(List<CommodityAndGrossReturns> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook;
                    var ws = wb.Worksheets.Add("Commodity Grouped By Quantity");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Commodity Grouped By Quantity";
                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "GrossReturns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<CommodityAndGrossReturns> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook;
                    var ws = wb.Worksheets.Add($"Commodity Grouped By Quantity Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")} ");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Commodity Grouped By Quantity Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "GrossReturns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }

        public Stream GenerateExcelFile(List<FarmerCommodityAndQuantity> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook;
                    var ws = wb.Worksheets.Add("Commodity Grouped By Quantity");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Commodity Grouped By Quantity";
                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Quantity";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.Quantity;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<FarmerCommodityAndQuantity> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Commodity Grouped By Quantity Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")} ");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Commodity Grouped By Farmer Quantity Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Quantity";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.Quantity;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }

        public Stream GenerateExcelFile(List<FarmerCommodityAndGrossReturns> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook;
                    var ws = wb.Worksheets.Add("Commodity Grouped By Farmer & Gross Returns");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Commodity Grouped By Farmer & Gross Returns";
                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Gross Returns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<FarmerCommodityAndGrossReturns> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                { 
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Commodity Grouped By Farmer & Gross Returns Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")} ");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Commodity Grouped By Farmer & Gross Returns Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Commodity Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Gross Returns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.CommodityName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }

        public Stream GenerateExcelFile(List<VehicleNumbersScheduled> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Vehicle Categories Used Over the Year");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Vehicle Categories Used Over the Year";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Number Of Vehicles scheduled";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.NumbersOfSchedules;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<VehicleNumbersScheduled> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Vehicles Categories Used Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Vehicle Categories Used Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")} ";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Number Of Vehicles scheduled";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.NumbersOfSchedules;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }

        public Stream GenerateExcelFile(List<VehicleCostReturnsScheduled> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Vehicles Categories Used with Gross returns Over the Year");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Vehicles Categories Used with Gross returns Over the Year";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Gross Returns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<VehicleCostReturnsScheduled> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Vehicles Categories Used with Gross returns Between date: { dateBegin.ToString("yyyy-MM-dd")}  to date: {dateEnd.ToString("yyyy-MM-dd")}"); 
                   
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Vehicles Categories Used with Gross returns Between date: { dateBegin.ToString("yyyy - MM - dd")}  to date: {dateEnd.ToString("yyyy - MM - dd")}";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Gross Returns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByNumber> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Farmer, Vehicles Categories Used Over the Year");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Farmer, Vehicles Categories Used Over the Year";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Number Of Vehicles";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.NumberOfVehicles;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByNumber> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Farmer against Vehicle Categories Used Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Farmer against Vehicle Categories Used Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Number Of Vehicles";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.NumberOfVehicles;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByCostReturns> rowContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Farmer, Vehicles Categories Used Against Gross returns Over the Year");
                    ws.Cells[string.Format("A{0}", 1)].Value = "Farmer, Vehicles Categories Used Against Gross Returns Over the Year";

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Gross Returns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
        public Stream GenerateExcelFile(List<FarmerVehicleCategoryUsageByCostReturns> rowContent, DateTime dateBegin, DateTime dateEnd)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    var wb = exPackage.Workbook; var ws = wb.Worksheets.Add($"Farmer, Vehicles Categories Used Against Gross returns Between date: {dateBegin.ToString("yyyy-MM-dd")} to date: {dateEnd.ToString("yyyy-MM-dd")}");
                    ws.Cells[string.Format("A{0}", 1)].Value = $"Farmer, Vehicles Categories Used Against Gross Returns Between Between date: {dateBegin.ToString("yyyy - MM - dd")} to date: {dateEnd.ToString("yyyy - MM - dd")}"; 

                    var excelRowNumber = 3;
                    ws.Cells[string.Format("A{0}", 2)].Value = "Farmer Name";
                    ws.Cells[string.Format("B{0}", 2)].Value = "Vehicle Category";
                    ws.Cells[string.Format("C{0}", 2)].Value = "Gross Returns";

                    foreach (var rowQuant in rowContent)
                    {
                        ws.Cells[string.Format("A{0}", excelRowNumber)].Value = rowQuant.FamerName;
                        ws.Cells[string.Format("B{0}", excelRowNumber)].Value = rowQuant.VehicleCategoryName;
                        ws.Cells[string.Format("C{0}", excelRowNumber)].Value = rowQuant.GrossReturns;
                        excelRowNumber++;
                    }
                    return exPackage.Stream;
                }
            }
        }
    }
}
