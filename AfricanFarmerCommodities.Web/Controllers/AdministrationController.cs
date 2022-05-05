using System;
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

namespace AfricanFarmerCommodities.Web.ControllersControllers
{
    [AuthorizeIdentity]
    [EnableCors(PolicyName = "CorsPolicy")]
    [Produces("application/json")]
    public class AdministrationController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private ServicesEndPoint _serviceEndPoint;

        public AdministrationController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        [Route("GetDealsPricingById/{dealPricingId}")]
        public async Task<IActionResult> GetDealsPricingById(int dealPricingId)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            var result =  (await _serviceEndPoint.GetDealsPricing()).FirstOrDefault(p => p.DealsPricingId == dealPricingId);

            return Ok(result);
        }
        [HttpGet]
        [HttpPost]
        [Authorize(Roles = ("Administrator"))]
        [Route("PostDealPricing")]
        public async Task<IActionResult> PostDealPricing([FromBody] DealsPricing dealsPricing)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            bool result = await _serviceEndPoint.PostDealPricing(dealsPricing);
            if(result) return Ok(result);
            return BadRequest();
        }
        [HttpPost]
        [Route("UpdateDealPricing")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> UpdateDealPricing([FromBody] DealsPricing dealsPricing)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            bool result = await _serviceEndPoint.UpdateDealPricing(dealsPricing);
            if (result) return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("PostLocation")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> PostLocation([FromBody] Location location)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            bool result = await _serviceEndPoint.PostLocation(location);
            if (result) return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("PostLocation")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> UpdateLocation([FromBody] Location location)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            bool result = await _serviceEndPoint.UpdateLocation(location);
            if (result) return Ok(result);
            return BadRequest();
        }
        [HttpPost]
        [Route("PostVehicle")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> PostVehicle([FromBody] Vehicle vehicle)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            bool result = await _serviceEndPoint.PostVehicle(vehicle);
            if (result) return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateVehicle")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> UpdateVehicle([FromBody] Vehicle vehicle)
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            bool result = await _serviceEndPoint.UpdateVehicle(vehicle);
            if (result) return Ok(result);
            return BadRequest();
        }

        // POST: api/Administration
        [HttpPost]
        [Route("PostEmail")]
        public void PostEmail(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

    }
}
