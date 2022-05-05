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

namespace AfricanFarmerCommodities.Web.Controllers
{
    [AuthorizeIdentity]
    [EnableCors(PolicyName = "CorsPolicy")]
    public class CommodityTrackingController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;

        public CommodityTrackingController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        [Route("~/api/{Controller}/{Action}/{commodityId}")]
        public IActionResult GetCommodityLocation(int commodityId)
        {
            var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            return Ok();
        }

        [HttpGet]
        [Route("~/api/{Controller}/{Action}/{companyId}")]
        public IActionResult GetAllCommodityLocationsByCompanyId(int companyId)
        {
            var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            return Ok();
        }

    }
}
