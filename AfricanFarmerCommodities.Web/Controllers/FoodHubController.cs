using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfricanFarmersCommodities.ServicesEndPoint.GeneralSevices;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using AfricanFarmerCommodities.Web.ViewModels;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using AfricanFarmersCommodities.Web.IdentityServices;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [AuthorizeIdentity]
    [EnableCors(PolicyName = "CorsPolicy")]
    public class FoodHubController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;

        public FoodHubController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        // GET: api/FoodHub
        [HttpGet]
        public async Task<IActionResult> GetAllFoodHubs()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHub[] results = await _serviceEndPoint.GetAllFoodHubs();
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
        [Route("~/{Controller}/{Action}/{foodHubId}")]
        public async Task<IActionResult> GetFoodHubById(int foodHubId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHub result = await _serviceEndPoint.GetFoodHubById(foodHubId);
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
        public async Task<IActionResult> PostOrCreateFoodHub([FromBody] FoodHubViewModel foodHubViewModel)
        {
            try
            {
                foodHubViewModel.Location = null;
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var foodHub = _Mapper.Map<FoodHub>(foodHubViewModel);
                bool result = await _serviceEndPoint.PostCreateFoodHub(foodHub);
                if (!result)
                {
                    return NotFound(foodHub);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFoodHub([FromBody] FoodHubViewModel foodHubViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var foodHub = _Mapper.Map<FoodHub>(foodHubViewModel);
                bool result = await _serviceEndPoint.UpdateFoodHub(foodHub);
                if (!result)
                {
                    return NotFound(foodHub);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodHub([FromBody] FoodHubViewModel foodHubViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var foodHub = _Mapper.Map<FoodHub>(foodHubViewModel);
                bool result = await _serviceEndPoint.DeleteFoodHub(foodHub);
                if (!result)
                {
                    return NotFound(foodHubViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //FoodHub Storage:
        [HttpGet]
        public async Task<IActionResult> GetAllFoodHubStorages()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHubStorage[] results = await _serviceEndPoint.GetAllFoodHubStorages();
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
        [Route("~/{Controller}/{Action}/{foodHubStorageId}")]
        public async Task<IActionResult> GetFoodHubStorageById(int foodHubStorageId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHubStorage result = await _serviceEndPoint.GetFoodHubStorageById(foodHubStorageId);
                FoodHubStorageViewModel resultVmodel = _Mapper.Map<FoodHubStorageViewModel>(result);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(resultVmodel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateFoodHubStorage([FromBody] FoodHubStorageViewModel foodHubStorageViewModel)
        {
            try
            {
                foodHubStorageViewModel.CommodityUnit = null;
                foodHubStorageViewModel.FoodHubViewModel = null;
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHubStorage foodHubStorage = _Mapper.Map<FoodHubStorage>(foodHubStorageViewModel);
                bool result = await _serviceEndPoint.PostCreateFoodHubStorage(foodHubStorage);
                if (!result)
                {
                    return NotFound(foodHubStorageViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFoodHubStorage([FromBody] FoodHubStorageViewModel foodHubStorageViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHubStorage foodHubStorage = _Mapper.Map<FoodHubStorage>(foodHubStorageViewModel);
                bool result = await _serviceEndPoint.UpdateFoodHubStorage(foodHubStorage);
                if (!result)
                {
                    return NotFound(foodHubStorageViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodHubStorage([FromBody] FoodHubStorageViewModel foodHubStorageViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                FoodHubStorage foodHubStorage = _Mapper.Map<FoodHubStorage>(foodHubStorageViewModel);
                bool result = await _serviceEndPoint.DeleteFoodHubStorage(foodHubStorage);
                if (!result)
                {
                    return NotFound(foodHubStorageViewModel);
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
