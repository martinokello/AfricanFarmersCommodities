﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfricanFarmersCommodities.ServicesEndPoint.GeneralSevices;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using AfricanFarmersCommodities.Web.IdentityServices;
using ExcelAccessDataEngine.Concretes;
using ExcelAccessDataEngine.DomainModel;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [EnableCors(PolicyName = "CorsPolicy")]
    public class AdhocReportingController : Controller
    {
        private ExcelEngine _excelEngine;
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;

        public AdhocReportingController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, ExcelEngine excelEngine)
        {
            _excelEngine = excelEngine;
            _emailService = emailService;
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetAllUnScheduledVehiclesByStorageCapacityLowestPrice()
        {
            try
            {
                var allUnscheduledVehiclesAvailable = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetAllUnScheduledVehiclesByStorageCapacityLowestPrice();
                return Ok(await Task.FromResult(allUnscheduledVehiclesAvailable));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }

        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetAllScheduledVehiclesByStorageCapacityLowestPrice()
        {
            try
            {
                var vehiclesAvailableLowestPriceByStorageCapacity = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetAllScheduledVehiclesByStorageCapacityLowestPrice();
                return await Task.FromResult(Ok(vehiclesAvailableLowestPriceByStorageCapacity));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }
        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetFoodHubCommoditiesStockStorageUsage()
        {
            try
            {
                var foodHubCommoditiesStorageUsageByFoodHubId = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetFoodHubCommoditiesStockStorageUsage();
                return await Task.FromResult(Ok(foodHubCommoditiesStorageUsageByFoodHubId));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }

        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetAllFoodHubCommoditiesStockStorageUsage()
        {
            try
            {
                var allFoodHubCommoditiesStorage = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetFoodHubCommoditiesStockStorageUsage();
                return await Task.FromResult(Ok(allFoodHubCommoditiesStorage));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }
        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities()
        {
            try
            {
                var result = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities();
                return await Task.FromResult(Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest("You have used some bad arguments. Check and Try Again");
            }
        }

        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities()
        {
            try
            {
                var top5RefreigeratedCommoditiesInDemandAccordingToStorageRating = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities();
                return await Task.FromResult(Ok(top5RefreigeratedCommoditiesInDemandAccordingToStorageRating));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }


        [HttpGet]
        [AuthorizeIdentity]
        public async Task<IActionResult> GetFoodHubDateAnalysisCommoditiesStockStorageUsage()
        {
            try
            {
                var foodHubCommoditiesStorageUsage = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetFoodHubDateAnalysisCommoditiesStockStorageUsage(DateTime.Now.AddYears(-1), DateTime.Now);
                return await Task.FromResult(Ok(foodHubCommoditiesStorageUsage));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }

        [AuthorizeIdentity]
        public async Task<IActionResult> GetAllFoodHubDateAnalysisCommoditiesStockStorageUsage()
        {
            try
            {
                var allFoodHubCommoditiesStorageUsage = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetFoodHubDateAnalysisCommoditiesStockStorageUsage(DateTime.Now.AddYears(-1), DateTime.Now);
                return await Task.FromResult(Ok(allFoodHubCommoditiesStorageUsage));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }

        [AuthorizeIdentity]
        public async Task<IActionResult> GetTop5DryCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilities()
        {
            try
            {
                var top5DryStorageCommoditisInDemand = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5DryCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilities(DateTime.Now.AddYears(-1), DateTime.Now);
                return await Task.FromResult(Ok(top5DryStorageCommoditisInDemand));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }

        public async Task<IActionResult> GetTop5RefreigeratedCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilitiess()
        {
            try
            {
                var top5RefreigeratedCommoditisInDemand = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5RefreigeratedCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilitiess(DateTime.Now.AddYears(-1), DateTime.Now);
                return await Task.FromResult(Ok(top5RefreigeratedCommoditisInDemand));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }

        public async Task<IActionResult> GetTop5FarmerCommoditiesDateAnalysisInUnitPricingOverDate()
        {
            try
            {
                var top5FarmersCommoditiesByUnitPrice = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5FarmerCommoditiesDateAnalysisInUnitPricingOverDate(DateTime.Now.AddYears(-1), DateTime.Now);
                return await Task.FromResult(Ok(top5FarmersCommoditiesByUnitPrice));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }
        public async Task<IActionResult> GetTop5FarmerCommoditiesDateAnalysisInUnitPricing()
        {
            try
            {
                var top5FarmersCommoditiesByUnitPrice = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5FarmerCommoditiesInUnitPricings();
                return await Task.FromResult(Ok(top5FarmersCommoditiesByUnitPrice));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }
        public async Task<IActionResult> GetTop5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest("You have used some bad arguments. Check and Try Again"));
            }
        }
        //////////////////////////////////////////
        ////New Content
        ////////////////////////////////////////// 
        public async Task<IActionResult> GetTop5CommoditiesSoldByCapacityOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCapacityOverAll();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetReportTop5CommoditiesSoldByCapacityOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCapacityOverAll();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);
                
                return await Task.FromResult(new FileStreamResult(stream,"application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesSoldByCostReturnsOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCostReturnsOverAll();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetReportTop5CommoditiesSoldByCostReturnsOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCostReturnsOverAll();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesSoldByCostReturnsOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCostReturnsOverthePastYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesSoldByCostReturnsOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCostReturnsOverAll();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesByFarmerSoldByCapacityOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCapacityOverAll();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesByFarmerSoldByCapacityOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCapacityOverAll();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesByFarmerSoldByCostReturnsOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCostReturnsOverAll();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesByFarmerSoldByCostReturnsOverAll()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCostReturnsOverAll();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));

            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesByFarmerSoldByCostReturnsOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCostReturnsOverthePastYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesByFarmerSoldByCostReturnsOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCostReturnsOverthePastYear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesSoldByCapacityOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCapacityOverthePastYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesSoldByCapacityOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCapacityOverthePastYear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesByFarmerSoldByCapacityOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCapacityOverthePastYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesByFarmerSoldByCapacityOverthePastYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCapacityOverthePastYear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesSoldByCapacityOverDate(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCapacityOverDate(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5CommoditiesSoldByCapacityOverDate(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCapacityOverDate(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesSoldByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCostReturnsOverDateBeginDateEnd(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5CommoditiesSoldByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesSoldByCostReturnsOverDateBeginDateEnd(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        //////////////////////////////////////////////////////////////
        ////Vehicle Queries
        ///////////////////////////////////////////////////////////////

        public async Task<IActionResult> GetTop5VehicleCategoriesUsedByCapacityOvertheyear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehicleCategoriesUsedByCapacityOvertheyear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehicleCategoriesUsedByCapacityOvertheyear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehicleCategoriesUsedByCapacityOvertheyear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByCostReturnsOverYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByCostReturnsOverYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByCostReturnsOverYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByCostReturnsOverYear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByFarmerByCapacityOverYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverYear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear();
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear()
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear();
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }

        public async Task<IActionResult> GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd(dateBegin, dateEnd);
                return await Task.FromResult(Ok(top5PricingsUncheduledVehicles));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
        public async Task<IActionResult> ReportTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                var top5PricingsUncheduledVehicles = _unitOfWork.AfricanFarmerCommoditiesDbContext.GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd(dateBegin, dateEnd);
                var stream = _excelEngine.GenerateExcelFile(top5PricingsUncheduledVehicles);

                return await Task.FromResult(new FileStreamResult(stream, "application/xlsx"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(new { Message = "You have used some bad arguments. Check and Try Again" }));
            }
        }
    }
}
