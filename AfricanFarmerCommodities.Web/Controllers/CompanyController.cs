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
using AfricanFarmerCommodities.Domain;
using Microsoft.AspNetCore.Cors;
using AfricanFarmersCommodities.Web.IdentityServices;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [AuthorizeIdentity]
    [EnableCors(PolicyName = "CorsPolicy")]
    public class CompanyController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;

        public CompanyController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{companyId}")]
        public async Task<IActionResult> GetCompanyById(int companyId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Company res = await _serviceEndPoint.GetCompanyById(companyId);
                CompanyViewModel results = _Mapper.Map<CompanyViewModel>(res);
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
        public async Task<IActionResult> PostOrCreateCompany([FromBody] CompanyViewModel companyViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var company = _Mapper.Map<Company>(companyViewModel);
                bool result = await _serviceEndPoint.PostCreateCompany(company);
                if (!result)
                {
                    return NotFound(companyViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyViewModel companyViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var farmer = _Mapper.Map<Company>(companyViewModel);
                bool result = await _serviceEndPoint.UpdateCompany(farmer);
                if (!result)
                {
                    return NotFound(companyViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SelectCompany([FromBody] FarmerViewModel companyViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var company = _Mapper.Map<Company>(companyViewModel);
                var result = await _serviceEndPoint.SelectCompany(company);
                if (result == null)
                {
                    return NotFound(companyViewModel);
                }
                return Ok(new { message = "Succesfully Selected!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCompany([FromBody] CompanyViewModel companyViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var company = _Mapper.Map<Company>(companyViewModel);
                bool result = await _serviceEndPoint.DeleteCompany(company);
                if (!result)
                {
                    return NotFound(companyViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Company[] companies = await _serviceEndPoint.GetAllCompanies();
                CompanyViewModel[] results = _Mapper.Map<CompanyViewModel[]>(companies);
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

        //Driver
        [HttpGet]
        [Route("~/{Controller}/{Action}/{driverId}")]
        public async Task<IActionResult> GetDriverById(int driverId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Driver res = await _serviceEndPoint.GetDriverById(driverId);
                DriverViewModel results = _Mapper.Map<DriverViewModel>(res);
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
        public async Task<IActionResult> CreateDriverNote([FromBody] DriverSchedulesNoteViewModle driverNoteViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var driver = _Mapper.Map<DriverSchedulesNote>(driverNoteViewModel);

                bool result = await _serviceEndPoint.PostCreateDriverNote(driver);
                if (!result)
                {
                    return await Task.FromResult(NotFound(new { Message = "Driver Note Not found" }));
                }
                return await Task.FromResult(Ok(new { Message = "Driver Note Succesfully Created", Result = result, StatusCode = 200 }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(new { Message = ex.Message }));
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostOrCreateDriver([FromBody] DriverViewModel driverViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var driver = _Mapper.Map<Driver>(driverViewModel);
                bool result = await _serviceEndPoint.PostCreateDriver(driver);
                if (!result)
                {
                    return NotFound(driverViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDriver([FromBody] DriverViewModel driverViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var driver = _Mapper.Map<Driver>(driverViewModel);
                bool result = await _serviceEndPoint.UpdateDriver(driver);
                if (!result)
                {
                    return NotFound(driverViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SelectDriver([FromBody] DriverViewModel driverViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var driver = _Mapper.Map<Driver>(driverViewModel);
                Driver result = await _serviceEndPoint.SelectDriver(driver);
                if (result == null)
                {
                    return NotFound(driverViewModel);
                }
                return Ok(new { message = "Succesfully Selected!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDriver([FromBody] DriverViewModel driverViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var driver = _Mapper.Map<Driver>(driverViewModel);
                bool result = await _serviceEndPoint.DeleteDriver(driver);
                if (!result)
                {
                    return NotFound(driverViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("~/{Controller}/{Action}/{transportScheduleId}")]

        public async Task<IActionResult> GetDriverByTransportScheduleId(int transportScheduleId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Driver driver = await _serviceEndPoint.GetDriverByTransportScheduleId(transportScheduleId);
                DriverViewModel result = _Mapper.Map<DriverViewModel>(driver);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Driver[] drivers = await _serviceEndPoint.GetAllDrivers();
                DriverViewModel[] results = _Mapper.Map<DriverViewModel[]>(drivers);
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
    }
}
