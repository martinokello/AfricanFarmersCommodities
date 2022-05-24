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
using System.Reflection;
using System.IO;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [EnableCors(PolicyName = "CorsPolicy")]
    public class TransportController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private Mapper _Mapper;

        public TransportController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, Mapper mapper)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _Mapper = mapper;

        }

        [HttpGet]
        [Route("~/{Controller}/{Action}/{companyId}")]
        public async Task<IActionResult> GetAllCompanyTransportVehiclesByCompanyId(int companyId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Vehicle[] results = await _serviceEndPoint.GetAllCompanyTransportVehiclesByCompanyId(companyId);
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
        public async Task<IActionResult> GetDriverScheduleNotes()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);

                var results = await _serviceEndPoint.GetAllDriverScheduleNotes();
                var actResults = _Mapper.Map<DriverSchedulesNoteViewModle[]>(results);

                return await Task.FromResult(Ok(actResults));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(new { Message = ex.Message }));
            }
        }


        [HttpGet]
        [Route("~/{Controller}/{Action}")]
        public async Task<IActionResult> GetDriverTransportSchedules()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);

                var results = await _serviceEndPoint.GetDriverTransportSchedules();

                var actResults = _Mapper.Map<TransportScheduleViewModel[]>(results);

                if (!actResults.Any())
                {
                    return await Task.FromResult(NotFound(actResults));
                }
                return await Task.FromResult(Ok(actResults));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(new { Message = ex.Message }));
            }
        }

        [HttpGet]
        [Route("~/{Controller}/{Action}/{appType}")]
        public async Task<IActionResult> GetLocationEmitterApp(string appType)
        {
            try
            {
                switch(appType){
                    case "android":
                        return await GetFileAndroid();
                    case "ios":
                        return await GetFileIos();
                    default:
                        return await GetFileAndroid();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message});
            }
        }
        

        private async Task<FileContentResult> GetFileAndroid()
        {
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var filePathInfo = new FileInfo(currentDir.FullName + "\\AndroidPhoneLocationApp\\XamarinForms.locationservice.apk");
            Response.ContentType = "multipart/form-data";
            Response.Headers.Add("Content-Disposition", "attachment; filename=\"XamarinForms.locationservice.apk\"");

            if (filePathInfo.Exists)
            {
                using (var strReader = filePathInfo.OpenRead())
                {

                    var bytes = new byte[strReader.Length];

                    strReader.Read(bytes, 0, bytes.Length);

                    strReader.Flush();
                    strReader.Close();
                    var result = await Task.FromResult(File(bytes, "multipart/form-data", "XamarinForms.locationservice.apk"));

                    return result;
                    /*
                    var maxBytesRead = 4096;
                    var bytesRead = 0;
                    var bytes = new byte[maxBytesRead];

                    while(( bytesRead = strReader.Read(bytes,0,maxBytesRead)) > 0){
                       await contentBodyStream.WriteAsync(bytes, 0, bytesRead);
                    }
                    contentBodyStream.Flush();
                    contentBodyStream.Close();
                    
                    return Ok(new {Message="Downloaded Android App Successfully"});
                    */
                }
            }
            return await Task.FromResult(File(System.Text.Encoding.UTF8.GetBytes("Failed to Download Android App"), "text/plain"));
        }

        private async Task<FileContentResult> GetFileIos()
        {
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var filePathInfo = new FileInfo(currentDir.FullName + "\\AndroidPhoneLocationApp\\XamarinForms.locationservice.ipa");
            Response.ContentType = "multipart/form-data";
            Response.Headers.Add("Content-Disposition", "attachment; filename=\"XamarinForms.locationservice.ipa\"");

            if (filePathInfo.Exists)
            {
                using (var strReader = filePathInfo.OpenRead())
                {
                    var bytes = new byte[strReader.Length];

                    strReader.Read(bytes, 0, bytes.Length);

                    strReader.Flush();
                    strReader.Close();
                    var result = await Task.FromResult(File(bytes, "multipart/form-data", "XamarinForms.locationservice.ipa"));

                    return result;
                    /*
                    var maxBytesRead = 4096;
                    var bytesRead = 0;
                    var bytes = new byte[maxBytesRead];

                    while ((bytesRead = strReader.Read(bytes, 0, maxBytesRead)) > 0)
                    {
                        await contentBody.WriteAsync(bytes, 0, bytesRead);
                    }
                    contentBody.Flush();

                    return Ok(new { Message = "Downloaded IOS App Successfully" });
                    */
                }
            }
            return await Task.FromResult(File(System.Text.Encoding.UTF8.GetBytes("Failed to Download IOS App"), "text/plain"));
        }
       
       [HttpGet]
        [Route("~/{Controller}/{Action}/{companyId}/{vehicleId}")]
        public async Task<IActionResult> GetCompanyTransportVehicleByCompanyId(int companyId, int vehicleId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Vehicle result = await _serviceEndPoint.GetCompanyTransportVehicleByCompanyId(companyId, vehicleId);
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

        //TransportPricing
        [HttpGet]
        public async Task<IActionResult> GetAllTransportPricings()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                TransportPricing[] results = await _serviceEndPoint.GetAllTransportPricings();
                TransportPricingViewModel[] transportPricingViewModels = _Mapper.Map<TransportPricingViewModel[]>(results);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(transportPricingViewModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("~/{Controller}/{Action}/{transportPricingId}")]
        public async Task<IActionResult> GetTransportPricingById(int transportPricingId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                TransportPricing tpresult = await _serviceEndPoint.GetTransportPricingById(transportPricingId);
                TransportPricingViewModel result = _Mapper.Map<TransportPricingViewModel>(tpresult);
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
        public async Task<IActionResult> PostOrCreateTransportPricing([FromBody] TransportPricingViewModel transportPricingViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportPricing = _Mapper.Map<TransportPricing>(transportPricingViewModel);
                bool result = await _serviceEndPoint.PostCreateTransportPricing(transportPricing);
                if (!result)
                {
                    return NotFound(transportPricingViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTransportPricing([FromBody] TransportPricingViewModel transportPricingViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportPricing = _Mapper.Map<TransportPricing>(transportPricingViewModel);
                bool result = await _serviceEndPoint.UpdateTransportPricing(transportPricing);
                if (!result)
                {
                    return NotFound(transportPricingViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTransportPricing([FromBody] TransportPricingViewModel transportPricingViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportPricing = _Mapper.Map<TransportPricing>(transportPricingViewModel);
                bool result = await _serviceEndPoint.DeleteTransportPricing(transportPricing);
                if (!result)
                {
                    return NotFound(transportPricingViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //TransportSchedule:
        [HttpGet]
        public async Task<IActionResult> GetAllTransportSchedules()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                TransportSchedule[] results = await _serviceEndPoint.GetAllTransportSchedules();
                TransportScheduleViewModel[] transportSchedulesViewModels = _Mapper.Map<TransportScheduleViewModel[]>(results);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(transportSchedulesViewModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIntermediateSchedules()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                IntermediateSchedule[] results = await _serviceEndPoint.GetAllIntermediateSchedules();
                IntermediateScheduleViewModel[] intermediateSchedulesViewModels = _Mapper.Map<IntermediateScheduleViewModel[]>(results);
                if (!results.Any())
                {
                    return NotFound(results);
                }
                return Ok(intermediateSchedulesViewModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("~/{Controller}/{Action}/{intermediateSchedulesId}")]
        public async Task<IActionResult> GetIntermediateScheduleById(int intermediateSchedulesId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                IntermediateSchedule tpresult = await _serviceEndPoint.GetIntermediateScheduleById(intermediateSchedulesId);
                IntermediateScheduleViewModel result = _Mapper.Map<IntermediateScheduleViewModel>(tpresult);
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

        [HttpGet]
        [Route("~/{Controller}/{Action}/{transportSchedulesId}")]
        public async Task<IActionResult> GetIntermediateSchedulesByTransportScheduleId(int transportSchedulesId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                IntermediateSchedule[] tpresult = await _serviceEndPoint.GetIntermediateSchedulesByTransportScheduleId(transportSchedulesId);
                IntermediateScheduleViewModel[] result = _Mapper.Map<IntermediateScheduleViewModel[]>(tpresult);
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
        [HttpGet]
        [Route("~/{Controller}/{Action}/{transportSchedulesId}")]
        public async Task<IActionResult> GetTransportScheduleById(int transportSchedulesId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                TransportSchedule tpresult = await _serviceEndPoint.GetTransportScheduleById(transportSchedulesId);
                if (tpresult == null)
                {
                    return NotFound(new {Message = "Transport Schedule Not Found"});
                }
                TransportScheduleViewModel result = _Mapper.Map<TransportScheduleViewModel>(tpresult);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostOrCreateTransportSchedule([FromBody] TransportScheduleViewModel transportScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportSchedule = _Mapper.Map<TransportSchedule>(transportScheduleViewModel);
                bool result = await _serviceEndPoint.PostCreateTransportSchedule(transportSchedule);
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
        public async Task<IActionResult> PostOrCreateIntermediateSchedule([FromBody] IntermediateScheduleViewModel intermediateScheduleViewModel)
        {

            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var intemediateSchedule = _Mapper.Map<IntermediateSchedule>(intermediateScheduleViewModel);
                bool result = await _serviceEndPoint.PostCreateIntermediateSchedule(intemediateSchedule);
                if (!result)
                {
                    return NotFound(intermediateScheduleViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIntermediateSchedule([FromBody] IntermediateScheduleViewModel intermediateScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var intermediateSchedule = _Mapper.Map<IntermediateSchedule>(intermediateScheduleViewModel);
                bool result = await _serviceEndPoint.UpdateIntermediateSchedule(intermediateSchedule);
                if (!result)
                {
                    return NotFound(intermediateScheduleViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTransportSchedule([FromBody] TransportScheduleViewModel transportScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportSchedule = _Mapper.Map<TransportSchedule>(transportScheduleViewModel);
                bool result = await _serviceEndPoint.DeleteTransportSchedule(transportSchedule);
                if (!result)
                {
                    return NotFound(transportScheduleViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIntermediateSchedule([FromBody] IntermediateScheduleViewModel intermediateScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var intermediateSchedule = _Mapper.Map<IntermediateSchedule>(intermediateScheduleViewModel);
                bool result = await _serviceEndPoint.DeleteIntermediateSchedule(intermediateSchedule);
                if (!result)
                {
                    return NotFound(intermediateScheduleViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Vehicle CRUD Operations:
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Vehicle[] vehresults = await _serviceEndPoint.GetAllVehicles();
                VehicleViewModel[] results = _Mapper.Map<VehicleViewModel[]>(vehresults);
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
        [Route("~/{Controller}/{Action}/{vehicleId}")]
        public async Task<IActionResult> GetVehicleById(int vehicleId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                Vehicle tpresult = await _serviceEndPoint.GetVehicleById(vehicleId);
                VehicleViewModel result = _Mapper.Map<VehicleViewModel>(tpresult);
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
        public async Task<IActionResult> PostOrCreateVehicle([FromBody] VehicleInsertViewModel vehicleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicle = _Mapper.Map<Vehicle>(vehicleViewModel);
                bool result = await _serviceEndPoint.PostCreateVehicle(vehicle);
                if (!result)
                {
                    return NotFound(vehicleViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleViewModel vehicleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicle = _Mapper.Map<Vehicle>(vehicleViewModel);
                bool result = await _serviceEndPoint.UpdateVehicle(vehicle);
                if (!result)
                {
                    return NotFound(vehicleViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVehicle([FromBody] VehicleViewModel vehicleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicle = _Mapper.Map<Vehicle>(vehicleViewModel);
                bool result = await _serviceEndPoint.DeleteVehicle(vehicle);
                if (!result)
                {
                    return NotFound(vehicleViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //VehicleCapacity
        [HttpPost]
        public async Task<IActionResult> PostOrCreateVehicleCapacity([FromBody] VehicleCapacityViewModel vehicleCapacityViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicleCapacity = _Mapper.Map<VehicleCapacity>(vehicleCapacityViewModel);
                bool result = await _serviceEndPoint.PostCreateVehicleCapacity(vehicleCapacity);
                if (!result)
                {
                    return NotFound(vehicleCapacityViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleCapacities()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                VehicleCapacity[] vehresults = await _serviceEndPoint.GetAllVehicleCapacities();
                VehicleCapacityViewModel[] results = _Mapper.Map<VehicleCapacityViewModel[]>(vehresults);
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
        [Route("~/{Controller}/{Action}/{vehicleCapacityId}")]
        public async Task<IActionResult> GetVehicleCapacityById(int vehicleCapacityId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                VehicleCapacity tpresult = await _serviceEndPoint.GetVehicleCapacityById(vehicleCapacityId);
                VehicleCapacityViewModel result = _Mapper.Map<VehicleCapacityViewModel>(tpresult);
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
        public async Task<IActionResult> UpdateVehicleCapacity([FromBody] VehicleCapacityViewModel vehicleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                VehicleCapacity vehicle = _Mapper.Map<VehicleCapacity>(vehicleViewModel);
                bool result = await _serviceEndPoint.UpdateVehicleCapacity(vehicle);
                if (!result)
                {
                    return NotFound(vehicleViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCapacity([FromBody] VehicleCapacityViewModel vehicleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                VehicleCapacity vehicleCapacity = _Mapper.Map<VehicleCapacity>(vehicleViewModel);
                bool result = await _serviceEndPoint.DeleteVehicleCapacity(vehicleCapacity);
                if (!result)
                {
                    return NotFound(vehicleViewModel);
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //VehicleCategroy
        [HttpGet]
        public async Task<IActionResult> GetAllVehicleCategories()
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                VehicleCategory[] vehresults = await _serviceEndPoint.GetAllVehicleCategories();
                VehicleCategoryViewModel[] results = _Mapper.Map<VehicleCategoryViewModel[]>(vehresults);
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
        [Route("~/{Controller}/{Action}/{vehicleCategoryId}")]
        public async Task<IActionResult> GetVehicleCategoryById(int vehicleCategoryId)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                VehicleCategory tpresult = await _serviceEndPoint.GetVehicleCategoryById(vehicleCategoryId);
                VehicleCategoryViewModel result = _Mapper.Map<VehicleCategoryViewModel>(tpresult);
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
        public async Task<IActionResult> PostOrCreateVehicleCategory([FromBody] VehicleCategoryViewModel vehicleCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicleCategory = _Mapper.Map<VehicleCategory>(vehicleCategoryViewModel);
                bool result = await _serviceEndPoint.PostCreateVehicleCategory(vehicleCategory);
                if (!result)
                {
                    return NotFound(vehicleCategoryViewModel);
                }
                return Ok(new { message = "Succesfully Created!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVehicleCategory([FromBody] VehicleCategoryViewModel vehicleCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicleCategory = _Mapper.Map<VehicleCategory>(vehicleCategoryViewModel);
                bool result = await _serviceEndPoint.UpdateVehicleCategory(vehicleCategory);
                if (!result)
                {
                    return NotFound(vehicleCategoryViewModel);
                }
                return Ok(new { message = "Succesfully Updated!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTransportSchedule([FromBody] TransportScheduleViewModel transportScheduleViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportSchedule = _Mapper.Map<TransportSchedule>(transportScheduleViewModel);
                bool result = await _serviceEndPoint.UpdateTransportSchedule(transportSchedule);
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
        public async Task<IActionResult> DeleteVehicleCategory([FromBody] VehicleCategoryViewModel vehicleCategoryViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var vehicleCategory = _Mapper.Map<VehicleCategory>(vehicleCategoryViewModel);
                bool result = await _serviceEndPoint.DeleteVehicleCategory(vehicleCategory);
                if (!result)
                {
                    return NotFound(vehicleCategoryViewModel);
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
