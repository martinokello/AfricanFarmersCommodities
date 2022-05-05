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

        public UserBadgeTo[] ReadExcel(string FilePath)
        {
            List<UserBadgeTo> dataRows = new List<UserBadgeTo>();
            //Title Row:
            var excelRowNumber = 1;
            var fileInfo = new FileInfo(FilePath);

            

            using (var memoryStream = new MemoryStream())
            {
                using (var stream = fileInfo.OpenRead())
                {
                    byte[] buf = new byte[4096];
                    int bytesRead = -1;
                    while ((bytesRead = stream.Read(buf, 0, buf.Length)) > 0)
                    {
                        memoryStream.Write(buf, 0, bytesRead);
                    }
                    stream.Flush();
                    stream.Close();
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var exPackage = new ExcelPackage(memoryStream))
                {
                    ExcelWorksheet wsht = null;

                    if (exPackage.Workbook.Worksheets.Any())
                        wsht = exPackage.Workbook.Worksheets.First();
                    if (wsht == null)
                    {

                        throw (new Exception("Excel File Missing WorkSheet!"));
                    }
                    if (excelRowNumber == 1)
                    {
                        //Consume Title Header
                        excelRowNumber++;
                    }
                    while (true)
                    {
                        if (string.IsNullOrEmpty(wsht.Cells[string.Format("A{0}", excelRowNumber)].Value as string)) break;

                        dataRows.Add(new UserBadgeTo
                        {
                            EmailAddress = wsht.Cells[string.Format("A{0}", excelRowNumber)].Value as string,
                            CandidateFullName = wsht.Cells[string.Format("B{0}", excelRowNumber)].Value as string,
                            CellPhoneNumber = wsht.Cells[string.Format("C{0}", excelRowNumber)].Value as string,
                            ProvinceDelimitedByComma = wsht.Cells[string.Format("D{0}", excelRowNumber)].Value as string,
                            BadgeType = wsht.Cells[string.Format("E{0}", excelRowNumber)].Value as string
                        });

                        excelRowNumber++;
                    }

                }
            }
            return dataRows.ToArray();
        }
    }
}
