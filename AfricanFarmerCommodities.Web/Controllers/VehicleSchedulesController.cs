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
using AfricanFarmerCommodities.Web.IdentityServices;
using System.Text.Json; 
using System.Net.Http;
using AfricanFarmersCommodities.Models;
using AfricanFarmersCommodities.Web.IdentityServices;
using System.Net.Http.Headers;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [EnableCors(PolicyName = "CorsPolicy")]
    public class VehicleSchedulesController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;

        public static List<VehicleDriverlocation> _vehicleDriverlocations = new List<VehicleDriverlocation>();

        public VehicleSchedulesController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        [HttpGet]
        [AuthorizeIdentity]
        [Route("~/{Controller}/{Action}/{transportScheduleId}/{vehicleId}")]
        public async Task<IActionResult> GetTransportVehiclesSchedulesByTransportScheduleIdAndVehicleId(int transportScheduleId, int vehicleId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                TransportSchedule[] results = await _serviceEndPoint.GetTransportVehiclesSchedulesByTransportScheduleIdAndVehicleId(transportScheduleId, vehicleId);

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
        [AuthorizeIdentity]
        [Route("~/{Controller}/{Action}/{vehicleId}")]
        public async Task<IActionResult> GetTransportScheduleByVehicleId(int vehicleId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                TransportSchedule[] results = await _serviceEndPoint.GetTransportVehicleSchedulesByVehicleId(vehicleId);

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

        [HttpPost]
        [AuthorizeIdentity]
        public async Task<IActionResult> PostOrCreateTransportSchedule([FromBody] TransportScheduleViewModel transportScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportSchedule = _Mapper.Map<TransportSchedule>(transportScheduleViewModel);
                var result = await _serviceEndPoint.PostCreateTransportVehicleScheduleBy(transportSchedule);
                if (!result)
                {
                    return NotFound(transportScheduleViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [AuthorizeIdentity]
        public async Task<IActionResult> UpdateTransportSchedule([FromBody] TransportScheduleViewModel transportScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportSchedule = _Mapper.Map<TransportSchedule>(transportScheduleViewModel);
                var result = await _serviceEndPoint.UpdateCreateTransportVehicleSchduleByCompanyId(transportSchedule);
                if (!result)
                {
                    return NotFound(transportScheduleViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [AuthorizeIdentity]
        public async Task<IActionResult> RemoveVehicleFromMonitor([FromBody] VehicleDriverlocation vehicleDriverlocation)
        {
            try
            {
                _vehicleDriverlocations.Remove(vehicleDriverlocation);
                return  await Task.FromResult(Ok(new { message = "Removed Vehicle From Monitor" }));
            }
            catch(Exception ex)
            {
                return await Task.FromResult(Ok(new { message = "Failed removing Vehicle From Monitor" }));
            }
        }
        [HttpPost]
        public async Task<IActionResult> MonitorAndPlotVehicleOnMap([FromBody] VehicleDriverlocation vehicleDriverlocation)
        {
            try
            {
                if (vehicleDriverlocation.UpdatePhoneNumber)
                {
                    var httpClient = new HttpClient();
                    var content = new BasicUserToken { authToken = Request.Headers["authToken"], emailAddress=string.Empty, username=string.Empty};
                    //var jsonString = JsonSerializer.Serialize(content);

                    Request.Headers.Add("Content-Type", "application/json");
                    
                    HttpResponseMessage respContent = await httpClient.PostAsJsonAsync("https://africanfarmerscommodities.martinlayooinc.com/Account/UserCredentialsAuthenticate", content);

                    var jsonStr = await respContent.Content.ReadAsStringAsync();

                    var userCredential = JsonSerializer.Deserialize<UserCredential>(jsonStr);
                     
                    if(userCredential != null && !string.IsNullOrEmpty(userCredential.username))
                    {
                        var actualUser = _unitOfWork._userRepository.GetAll().FirstOrDefault(u => u.Email.ToLower().Equals(userCredential.emailAddress.ToLower()));
                        if(actualUser != null)
                        {
                            actualUser.MobileNumber = vehicleDriverlocation.DriverPhoneNumber;
                            _unitOfWork.SaveChanges();
                        }
                    }
                }
                if (!_vehicleDriverlocations.Contains(vehicleDriverlocation))
                {
                    _vehicleDriverlocations.Add(vehicleDriverlocation);
                }
                else
                {
                   var actLocations = _vehicleDriverlocations.FirstOrDefault(q=> q.VehicleRegistration.ToLower().Equals(vehicleDriverlocation.VehicleRegistration.ToLower()));
                    actLocations.Lattitude = vehicleDriverlocation.Lattitude;
                    actLocations.Longitude = vehicleDriverlocation.Longitude;
                    actLocations.DriverName = vehicleDriverlocation.DriverName;
                    actLocations.DriverPhoneNumber = vehicleDriverlocation.DriverPhoneNumber;
                    actLocations.VehicleRegistration = vehicleDriverlocation.VehicleRegistration;
                }
                return await Task.FromResult(Ok(new {Result=true, Message= "Added Vehicle Tracking" }));
            }
            catch(Exception ex)
            {
                return await Task.FromResult(BadRequest(new { result = false, message = "Failed To Add Tracking" }));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleLocations()
        {
            try
            {
                return await Task.FromResult(Ok(_vehicleDriverlocations.ToArray()));
            }
            catch(Exception ex)
            {
                return await Task.FromResult(BadRequest(new { result = false,message = "Failed To Get Vehicles" }));
            }
        }
    }
}
