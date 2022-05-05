using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfricanFarmersCommodities.ServicesEndPoint.GeneralSevices;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.Web.ViewModels;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using AfricanFarmersCommodities.Web.IdentityServices;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [AuthorizeIdentity]
    [EnableCors(PolicyName = "CorsPolicy")]
    public class FarmerController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;

        public FarmerController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{farmerId}")]
        public async Task<IActionResult> GetFarmerById(int farmerId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Farmer res = await _serviceEndPoint.GetFarmerById(farmerId);
                FarmerViewModel results = _Mapper.Map<FarmerViewModel>(res);
                if (results == null)
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostOrCreateFarmer([FromBody] FarmerInsertViewModel farmerViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var farmer = _Mapper.Map<Farmer>(farmerViewModel);
                bool result = await _serviceEndPoint.PostCreateFarmer(farmer);
                if (!result)
                {
                    return NotFound(farmerViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFarmer([FromBody] FarmerViewModel farmerViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var farmer = _Mapper.Map<Farmer>(farmerViewModel);
                bool result = await _serviceEndPoint.UpdateFarmer(farmer);
                if (!result)
                {
                    return NotFound(farmerViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SelectFarmer([FromBody] FarmerViewModel farmerViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var farmer = _Mapper.Map<Farmer>(farmerViewModel);
                var result = await _serviceEndPoint.SelectFarmer(farmer);
                if (result == null)
                {
                    return NotFound(farmerViewModel);
                }
                return Ok(new { message = "Succesfully Selected!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFarmer([FromBody] FarmerViewModel farmerViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var farmer = _Mapper.Map<Farmer>(farmerViewModel);
                bool result = await _serviceEndPoint.DeleteFarmer(farmer);
                if (!result)
                {
                    return NotFound(farmerViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFarmers()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Farmer[] farmers = await _serviceEndPoint.GetAllFarmers();
                FarmerViewModel[] results = _Mapper.Map<FarmerViewModel[]>(farmers);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //Commodity Unit
        [HttpPost]
        public async Task<IActionResult> PostOrCreateCommodityUnit([FromBody] CommodityUnitViewModel commodityUnitViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityUnit = _Mapper.Map<CommodityUnit>(commodityUnitViewModel);
                bool result = await _serviceEndPoint.PostCreateCommodityUnit(commodityUnit);
                if (!result)
                {
                    return NotFound(commodityUnitViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCommodityUnit([FromBody] CommodityUnitViewModel commodityUnitViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityUnit = _Mapper.Map<CommodityUnit>(commodityUnitViewModel);
                bool result = await _serviceEndPoint.UpdateCommodityUnit(commodityUnit);
                if (!result)
                {
                    return NotFound(commodityUnitViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SelectCommodityUnit([FromBody] CommodityUnitViewModel commodityUnitViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityUnit = _Mapper.Map<CommodityUnit>(commodityUnitViewModel);
                CommodityUnit result = await _serviceEndPoint.SelectCommodityUnit(commodityUnit);
                if (result == null)
                {
                    return NotFound(commodityUnitViewModel);
                }
                return Ok(new { message = "Succesfully Selected!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCommodityUnit([FromBody] CommodityUnitViewModel commodityUnitViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityUnit = _Mapper.Map<CommodityUnit>(commodityUnitViewModel);
                bool result = await _serviceEndPoint.DeleteCommodityUnit(commodityUnit);
                if (!result)
                {
                    return NotFound(commodityUnitViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{commodityUnitId}")]
        public async Task<IActionResult> GetCommodityUnitById(int commodityUnitId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                CommodityUnit res = await _serviceEndPoint.GetCommodityUnitById(commodityUnitId);
                CommodityUnitViewModel results = _Mapper.Map<CommodityUnitViewModel>(res);
                if (results == null)
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCommodityUnits()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                CommodityUnit[] comodityUnits = await _serviceEndPoint.GetAllCommodityUnits();
                CommodityUnitViewModel[] results = _Mapper.Map<CommodityUnitViewModel[]>(comodityUnits);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Commodity Category
        [HttpPost]
        public async Task<IActionResult> PostOrCreateCommodityCategory([FromBody] CommodityCategoryViewModel commodityCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityCategory = _Mapper.Map<CommodityCategory>(commodityCategoryViewModel);
                bool result = await _serviceEndPoint.PostCreateCommodityCategory(commodityCategory);
                if (!result)
                {
                    return NotFound(commodityCategoryViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCommodityCategory([FromBody] CommodityCategoryViewModel commodityCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityCategory = _Mapper.Map<CommodityCategory>(commodityCategoryViewModel);
                bool result = await _serviceEndPoint.UpdateCommodityCategory(commodityCategory);
                if (!result)
                {
                    return NotFound(commodityCategoryViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SelectCommodityCategory([FromBody] CommodityCategoryViewModel commodityCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityCategory = _Mapper.Map<CommodityCategory>(commodityCategoryViewModel);
                CommodityCategory result = await _serviceEndPoint.SelectCommodityCategory(commodityCategory);
                if (result == null)
                {
                    return NotFound(commodityCategoryViewModel);
                }
                return Ok(new { message = "Succesfully Selected!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCommodityCategory([FromBody] CommodityCategoryViewModel commodityCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodityCategory = _Mapper.Map<CommodityCategory>(commodityCategoryViewModel);
                bool result = await _serviceEndPoint.DeleteCommodityCategory(commodityCategory);
                if (!result)
                {
                    return NotFound(commodityCategoryViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{commodityCategoryId}")]
        public async Task<IActionResult> GetCommodityCategoryById(int commodityCategoryId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                CommodityCategory res = await _serviceEndPoint.GetCommodityCategoryById(commodityCategoryId);
                CommodityCategoryViewModel results = _Mapper.Map<CommodityCategoryViewModel>(res);
                if (results == null)
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCommodityCategories()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                CommodityCategory[] comodityUnits = await _serviceEndPoint.GetAllCommodityCategories();
                CommodityCategoryViewModel[] results = _Mapper.Map<CommodityCategoryViewModel[]>(comodityUnits);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //Commodities
        [Route("~/{Controller}/{Action}/{commodityId}")]
        public async Task<IActionResult> GetFarmerCommodityById(int commodityId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Commodity res = await _serviceEndPoint.GetCommodityById(commodityId);
                CommodityViewModel results = _Mapper.Map<CommodityViewModel>(res);
                if (results == null)
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFarmerCommodities()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Commodity[] results = await _serviceEndPoint.GetAllFarmerCommodities();
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{companyId}")]
        public async Task<IActionResult> GetAllCommoditiesByCompanyId(int companyId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Commodity[] results = await _serviceEndPoint.GetAllCommoditiesByCompanyId(companyId);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{farmerId}")]
        public async Task<IActionResult> GetAllFarmerCommodities(int farmerId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Commodity[] results = await _serviceEndPoint.GetAllFarmerCommodities(farmerId);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("~/{Controller}/{Action}/{farmerId}/{commodityId}")]
        public async Task<IActionResult> GetFarmerCommodityById(int farmerId, int commodityId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Commodity result = await _serviceEndPoint.GetFarmerCommodityById(farmerId, commodityId);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> PostOrCreateFarmerCommodity([FromBody] CommodityViewModel commodityViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodity = _Mapper.Map<Commodity>(commodityViewModel);
                var result = await _serviceEndPoint.PostCreateCommodity(commodity);
                if (!result)
                {
                    return NotFound(commodity);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFarmerCommodity([FromBody] CommodityViewModel commodityViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodity = _Mapper.Map<Commodity>(commodityViewModel);
                var result = await _serviceEndPoint.UpdateFarmerCommodity(commodity);
                if (!result)
                {
                    return NotFound(commodity);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFarmerCommodity([FromBody] CommodityViewModel commodityViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var commodity = _Mapper.Map<Commodity>(commodityViewModel);
                var result = await _serviceEndPoint.DeleteFarmerCommodity(commodity);
                if (!result)
                {
                    return NotFound(commodity);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
