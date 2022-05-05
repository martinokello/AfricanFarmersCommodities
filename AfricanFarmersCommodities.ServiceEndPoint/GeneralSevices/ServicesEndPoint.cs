using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AfricanFarmerCommodities.Domain;

namespace AfricanFarmersCommodities.ServicesEndPoint.GeneralSevices
{
    public class ServicesEndPoint
    {
        AfricanFarmerCommoditiesUnitOfWork _africanFarmersCommoditiesUnitOfWork;
        IMailService _emailServices;
        public ServicesEndPoint(AfricanFarmerCommoditiesUnitOfWork unitOfWork, IMailService emailServices)
        {
            _africanFarmersCommoditiesUnitOfWork = unitOfWork;
            _emailServices = emailServices;
        }
        public async Task<Location[]> GetAllLocations()
        {
            var location = _africanFarmersCommoditiesUnitOfWork._locationRepository.GetAll().ToArray();
            return await Task.FromResult(location);
        }

        public async Task<Farmer> GetFarmerById(int farmerId)
        {
            try
            {
                var actFarmer = _africanFarmersCommoditiesUnitOfWork._farmerRepository.GetById(farmerId);
                if (actFarmer == null)
                {
                    return null;
                }
                return await Task.FromResult(actFarmer);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            try
            {
                var actComUnit = _africanFarmersCommoditiesUnitOfWork._companyRepository.GetById(companyId);
                if (actComUnit == null)
                {
                    return null;
                }
                return await Task.FromResult(actComUnit);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> PostCreateAddress(Address address)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._addressRepository.Insert(address);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<DriverSchedulesNote[]> GetAllDriverScheduleNotes()
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._driverSchedulesNotesRepository.GetAll().ToArray();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(new DriverSchedulesNote[] { });
            }
        }

        public async Task<TransportSchedule[]> GetDriverTransportSchedules()
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.GetAll().ToArray();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(new TransportSchedule[] { });
            }
        }

        public async Task<bool> PostCreateLocation(Location location)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._locationRepository.Insert(location);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._addressRepository.Update(address);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Address> SelectAddress(Address address)
        {
            try
            {
                var actAddress = _africanFarmersCommoditiesUnitOfWork._addressRepository.GetById(address.AddressId);
                if (actAddress == null)
                {
                    return null;
                }
                return await Task.FromResult(actAddress);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Location> SelectLocation(Location location)
        {
            try
            {
                var actlocation = _africanFarmersCommoditiesUnitOfWork._locationRepository.GetById(location.LocationId);
                if (actlocation == null)
                {
                    return null;
                }
                return await Task.FromResult(actlocation);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAddress(Address address)
        {
            try
            {
                var actAddress = _africanFarmersCommoditiesUnitOfWork._addressRepository.GetById(address.AddressId);
                if (actAddress == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._addressRepository.Delete(actAddress);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> PostCreateTransportScheduleLog(TransportLog transportLog)
        {
            try
            {
                _africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.TransportLogs.Add(transportLog);
                _africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch(Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> PostCreateDriverNote(DriverSchedulesNote driverNote)
        {
            try
            {
                var currentNote = _africanFarmersCommoditiesUnitOfWork._driverSchedulesNotesRepository.GetById(driverNote.DriveScheduleNoteId);
                if(currentNote != null)
                {
                    _africanFarmersCommoditiesUnitOfWork._driverSchedulesNotesRepository.Update(driverNote);
                    _africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.SaveChanges();
                    return await Task.FromResult(true);
                }
                else
                {
                    _africanFarmersCommoditiesUnitOfWork._driverSchedulesNotesRepository.Insert(driverNote);
                    _africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.SaveChanges();
                    return await Task.FromResult(true);
                }
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteTransportScheduleLog(TransportLog transportLog)
        {
            try
            {
                var transportLogItem =_africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.TransportLogs.FirstOrDefault(q => q.InvoiceId == transportLog.InvoiceId && q.TransportScheduleId == transportLog.TransportScheduleId); 

                if(transportLogItem != null)
                {
                    _africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.TransportLogs.Remove(transportLogItem);
                    _africanFarmersCommoditiesUnitOfWork.AfricanFarmerCommoditiesDbContext.SaveChanges();
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Address[]> GetAllAddresses()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._addressRepository.GetAll().ToArray());

        }
        public async Task<bool> DeleteLocation(Location location)
        {
            try
            {
                var actlocation = _africanFarmersCommoditiesUnitOfWork._locationRepository.GetById(location.LocationId);
                if (actlocation == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._locationRepository.Delete(actlocation);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Driver[]> GetAllDrivers()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._driverRepository.GetAll()?.Include(q => q.Vehicle).Include(q => q.TransportSchedule).Select(q => q).ToArray());
        }
        public async Task<bool> PostCreateDriver(Driver driver)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._driverRepository.Insert(driver);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Driver> SelectDriver(Driver driver)
        {
            try
            {
                var actComUnit = _africanFarmersCommoditiesUnitOfWork._driverRepository.GetById(driver.DriverId);
                if (actComUnit == null)
                {
                    return null;
                }
                return await Task.FromResult(actComUnit);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Driver> GetDriverByTransportScheduleId(int transportScheduleId)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._driverRepository.GetAll().FirstOrDefault(q=> q.TransportScheduleId == transportScheduleId);
                
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateDriver(Driver driver)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._driverRepository.Update(driver);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<TransportSchedule[]> GetAllTransportSchedules()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.GetAll()?.Include(q => q.Vehicle).Include(q => q.DestinationName).Include(q => q.OriginName).Include(q => q.Vehicle).Select(q => q).ToArray());
        }

        public async Task<IntermediateSchedule[]> GetAllIntermediateSchedules()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.GetAll()?.Include(q => q.Vehicle).Include(q => q.DestinationName).Include(q => q.OriginName).Include(q => q.Vehicle).Select(q => q).ToArray());
        }
        public async Task<bool> DeleteDriver(Driver driver)
        {
            try
            {
                var actcommodity = _africanFarmersCommoditiesUnitOfWork._driverRepository.GetById(driver.DriverId);
                if (actcommodity == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._driverRepository.Delete(actcommodity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<TransportSchedule> GetTransportScheduleById(int transportSchedulesId)
        {
            try
            {
                var actTranShe = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.GetById(transportSchedulesId);
                if (actTranShe == null)
                {
                    return null;
                }
                return await Task.FromResult(actTranShe);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IntermediateSchedule[]> GetIntermediateSchedulesByTransportScheduleId(int transportSchedulesId)
        {
            try
            {
                var actTranShe = _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.GetAll().Where(q=> q.TransportScheduleId == transportSchedulesId)?.Include(q=> q.Vehicle).Include(q=> q.OriginName).Include(q=> q.DestinationName).ToArray();
                if (actTranShe == null || !actTranShe.Any())
                {
                    return null;
                }
                return await Task.FromResult(actTranShe);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IntermediateSchedule> GetIntermediateScheduleById(int intermediateSchedulesId)
        {
            try
            {
                var actTranShe = _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.GetById(intermediateSchedulesId);
                if (actTranShe == null)
                {
                    return null;
                }
                return await Task.FromResult(actTranShe);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> PostCreateTransportSchedule(TransportSchedule transportSchedule)
        {
            try
            {
                transportSchedule.OriginName = null;
                transportSchedule.DestinationName = null;
                transportSchedule.Vehicle = null;
                transportSchedule.TransportPricing = null;
                var result = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.Insert(transportSchedule);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                if (!transportSchedule.HasIntermediateDrops)
                {
                    //Create intemediate Drop as a copy of TransportSchedule:
                    var intTranSche = new IntermediateSchedule
                    {
                        TransportScheduleId = transportSchedule.TransportScheduleId,
                        DestinationLocationId = transportSchedule.DestinationLocationId,
                        OriginLocationId = transportSchedule.OriginLocationId,
                        DateCreated = transportSchedule.DateCreated,
                        DateUpdated = transportSchedule.DateUpdated,
                        DateStartFromOrigin = transportSchedule.DateStartFromOrigin,
                        DateEndAtDestination = transportSchedule.DateEndAtDestination,
                        HasReachedFinalDestination = false,
                        VehicleId = transportSchedule.VehicleId
                    };
                    _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.Insert(intTranSche);
                    _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                }
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> PostCreateIntermediateSchedule(IntermediateSchedule intermediateSchedule)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.Insert(intermediateSchedule);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Driver> GetDriverById(int driverId)
        {
            try
            {
                var actComUnit = _africanFarmersCommoditiesUnitOfWork._driverRepository.GetById(driverId);
                if (actComUnit == null)
                {
                    return null;
                }
                return await Task.FromResult(actComUnit);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateTransportSchedule(TransportSchedule transportSchedule)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.Update(transportSchedule);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> UpdateIntermediateSchedule(IntermediateSchedule intermediateSchedule)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.Update(intermediateSchedule);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteTransportSchedule(TransportSchedule transportSchedule)
        {
            try
            {
                var act = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.GetById(transportSchedule.TransportScheduleId);
                if (act == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.Delete(act);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteIntermediateSchedule(IntermediateSchedule intermediateSchedule)
        {
            try
            {
                var act = _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.GetById(intermediateSchedule.IntermediateScheduleId);
                if (act == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._intermediateScheduleRepository.Delete(act);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Commodity> GetCommodityById(int commodityId)
        {
            try
            {
                var actCom = _africanFarmersCommoditiesUnitOfWork._commodityRepository.GetById(commodityId);
                if (actCom == null)
                {
                    return null;
                }
                return await Task.FromResult(actCom);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> PostCreateCommodityUnit(CommodityUnit commodityUnit)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._commodityUnitRepository.Insert(commodityUnit);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> PostCreateCommodityCategory(CommodityCategory commodityCategory)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.Insert(commodityCategory);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCommodityCategory(CommodityCategory commodityCategory)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.Update(commodityCategory);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<CommodityUnit[]> GetAllCommodityUnits()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._commodityUnitRepository?.GetAll().ToArray());
        }
        public async Task<Commodity[]> GetAllCommodities()
        {
            IQueryable<Commodity> results = _africanFarmersCommoditiesUnitOfWork._commodityRepository?.GetAll();
            return await Task.FromResult(results.Include(q => q.CommodityCategory).Include(q => q.CommodityUnit).Select(q => q).ToArray());

        }
        public async Task<Commodity[]> GetAllCommoditiesByCompanyId(int companyId)
        {
            IQueryable<Commodity> results = _africanFarmersCommoditiesUnitOfWork._commodityRepository.GetAll().Where(q => q.CompanyId == companyId);
            return await Task.FromResult(results.Include(q => q.CommodityCategory).Include(q => q.Company).Include(q => q.CommodityUnit).Select(q => q).ToArray());

        }

        public async Task<CommodityCategory> SelectCommodityCategory(CommodityCategory commodityCategory)
        {
            try
            {
                var actComCat = _africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.GetById(commodityCategory.CommodityCategoryId);
                if (actComCat == null)
                {
                    return null;
                }
                return await Task.FromResult(actComCat);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<VehicleCapacity[]> GetAllVehicleCapacities()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleCapacityRepository.GetAll()?.Select(q => q).ToArray());
        }

        public async Task<CommodityUnit> SelectCommodityUnit(CommodityUnit commodityUnit)
        {
            try
            {
                var actComUnit = _africanFarmersCommoditiesUnitOfWork._commodityUnitRepository.GetById(commodityUnit.CommodityUnitId);
                if (actComUnit == null)
                {
                    return null;
                }
                return await Task.FromResult(actComUnit);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<VehicleCapacity> GetVehicleCapacityById(int vehicleCapacityId)
        {
            try
            {
                var actCom = _africanFarmersCommoditiesUnitOfWork._vehicleCapacityRepository.GetById(vehicleCapacityId);
                if (actCom == null)
                {
                    return null;
                }
                return await Task.FromResult(actCom);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCommodityCategory(CommodityCategory commodityCategory)
        {
            try
            {
                var actcommodity = _africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.GetById(commodityCategory.CommodityCategoryId);
                if (actcommodity == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.Delete(actcommodity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateVehicleCapacity(VehicleCapacity vehicleCapacity)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleCapacityRepository.Update(vehicleCapacity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteVehicleCapacity(VehicleCapacity vehicleCapacity)
        {
            try
            {
                var actcommodity = _africanFarmersCommoditiesUnitOfWork._vehicleCapacityRepository.GetById(vehicleCapacity.VehicleCapacityId);
                if (actcommodity == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleCapacityRepository.Delete(actcommodity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<CommodityCategory> GetCommodityCategoryById(int commodityCategoryId)
        {
            try
            {
                var actCom = _africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.GetById(commodityCategoryId);
                if (actCom == null)
                {
                    return null;
                }
                return await Task.FromResult(actCom);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<CommodityCategory[]> GetAllCommodityCategories()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._commodityCategoryRepository.GetAll().ToArray());
        }

        public async Task<bool> UpdateCommodityUnit(CommodityUnit commodityUnit)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._commodityUnitRepository.Update(commodityUnit);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteCommodityUnit(CommodityUnit commodityUnit)
        {
            try
            {
                var actcommodity = _africanFarmersCommoditiesUnitOfWork._commodityUnitRepository.GetById(commodityUnit.CommodityUnitId);
                if (actcommodity == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._commodityUnitRepository.Delete(actcommodity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<CommodityUnit> GetCommodityUnitById(int commodityUnitId)
        {
            try
            {
                var actComUnit = _africanFarmersCommoditiesUnitOfWork._commodityUnitRepository.GetById(commodityUnitId);
                if (actComUnit == null)
                {
                    return null;
                }
                return await Task.FromResult(actComUnit);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._locationRepository.Update(location);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> PostCreateFarmer(Farmer farmer)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._farmerRepository.Insert(farmer);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateFarmer(Farmer farmer)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._farmerRepository.Update(farmer);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteFarmer(Farmer farmer)
        {
            try
            {
                var actFaremer = _africanFarmersCommoditiesUnitOfWork._farmerRepository.GetById(farmer.FarmerId);
                if (actFaremer == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._farmerRepository.Delete(actFaremer);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteFarmerCommodity(Commodity commodity)
        {
            try
            {
                var actcommodity = _africanFarmersCommoditiesUnitOfWork._commodityRepository.GetById(commodity.CommodityId);
                if (actcommodity == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._commodityRepository.Delete(actcommodity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Farmer> SelectFarmer(Farmer farmer)
        {
            try
            {
                var actFaremer = _africanFarmersCommoditiesUnitOfWork._farmerRepository.GetById(farmer.FarmerId);
                if (actFaremer == null)
                {
                    return null;
                }
                return await Task.FromResult(actFaremer);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> PostCreateCompany(Company company)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._companyRepository.Insert(company);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteFoodHub(FoodHub foodHub)
        {
            try
            {
                var actfoodHub = _africanFarmersCommoditiesUnitOfWork._foodHubRepository.GetById(foodHub.FoodHubId);
                if (actfoodHub == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._foodHubRepository.Delete(actfoodHub);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<FoodHubStorage[]> GetAllFoodHubStorages()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.GetAll().ToArray());

        }

        public async Task<TransportPricing[]> GetAllTransportPricings()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._transportPricingRepository.GetAll().ToArray());

        }

        public async Task<TransportPricing> GetTransportPricingById(int transportPricingId)
        {
            try
            {
                var actCompany = _africanFarmersCommoditiesUnitOfWork._transportPricingRepository.GetById(transportPricingId);
                if (actCompany == null)
                {
                    return null;
                }
                return await Task.FromResult(actCompany);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<FoodHubStorage> GetFoodHubStorageById(int foodHubStorageId)
        {
            try
            {
                var actFoodHubStorage = _africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.GetById(foodHubStorageId);
                if (actFoodHubStorage == null)
                {
                    return null;
                }
                return await Task.FromResult(actFoodHubStorage);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateCompany(Company company)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._companyRepository.Update(company);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> PostCreateTransportPricing(TransportPricing transportPricing)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._transportPricingRepository.Insert(transportPricing);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Vehicle> SelectVehicle(Vehicle vehicle)
        {
            try
            {
                var actVehicle = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.GetById(vehicle.VehicleId);
                if (actVehicle == null)
                {
                    return null;
                }
                return await Task.FromResult(actVehicle);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.Update(vehicle);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
            try
            {
                var actvehicle = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.GetById(vehicle.VehicleId);
                if (actvehicle == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.Delete(actvehicle);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Company> SelectCompany(Company company)
        {
            try
            {
                var actCompany = _africanFarmersCommoditiesUnitOfWork._companyRepository.GetById(company.CompanyId);
                if (actCompany == null)
                {
                    return null;
                }
                return await Task.FromResult(actCompany);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateTransportPricing(TransportPricing transportPricing)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._transportPricingRepository.Update(transportPricing);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteTransportPricing(TransportPricing transportPricing)
        {
            try
            {
                var actPricing = _africanFarmersCommoditiesUnitOfWork._transportPricingRepository.GetById(transportPricing.TransportPricingId);
                if (actPricing == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._transportPricingRepository.Delete(actPricing);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteCompany(Company company)
        {
            try
            {
                var actcompany = _africanFarmersCommoditiesUnitOfWork._companyRepository.GetById(company.CompanyId);
                if (actcompany == null)
                {
                    return await Task.FromResult(false);
                }
                var result = _africanFarmersCommoditiesUnitOfWork._companyRepository.Delete(actcompany);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<FoodHubStorage> SelectFoodHubStorage(FoodHubStorage foodHubStorage)
        {
            try
            {
                var actfhs = _africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.GetById(foodHubStorage.FoodHubStorageId);
                if (actfhs == null)
                {
                    return null;
                }
                return await Task.FromResult(actfhs);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateFoodHubStorage(FoodHubStorage foodHubStorage)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.Update(foodHubStorage);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteFoodHubStorage(FoodHubStorage foodHubStorage)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.GetById(foodHubStorage.FoodHubStorageId);
                if (result == null)
                {
                    return await Task.FromResult(false);
                }
                _africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.Delete(result);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> PostCreateFoodHubStorage(FoodHubStorage foodHubStorage)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._foodHubStorageRepository.Insert(foodHubStorage);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> PostCreateVehicleCapacity(VehicleCapacity vehicleCapacity)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleCapacityRepository.Insert(vehicleCapacity);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<VehicleCategory> SelectVehicleCategory(VehicleCategory vehicleCategory)
        {
            try
            {
                var actVehicleCategory = _africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.GetById(vehicleCategory.VehicleCategoryId);
                if (actVehicleCategory == null)
                {
                    return null;
                }
                return await Task.FromResult(actVehicleCategory);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateVehicleCategory(VehicleCategory vehicleCategory)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.Update(vehicleCategory);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteVehicleCategory(VehicleCategory vehicleCategory)
        {
            try
            {
                var actvehicle = _africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.GetById(vehicleCategory.VehicleCategoryId);
                if (actvehicle == null)
                {
                    return await Task.FromResult(false);
                }
                _africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.Delete(actvehicle);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<Vehicle[]> GetAllVehicles()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleRepository.GetAll()?.Include(q => q.Company).Include(q => q.VehicleCategory).Select(q => q).ToArray());
        }

        public async Task<TransportSchedule[]> GetTransportVehiclesSchedulesByTransportScheduleIdAndVehicleId(int transportScheduleId, int vehicleId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.GetAll()?.Include(q => q.Vehicle).Include(q => q.DestinationName).Include(q => q.OriginName).Include(q => q.Vehicle).Where(q => q.TransportScheduleId == transportScheduleId && q.VehicleId == vehicleId).Select(q => q).ToArray());
        }

        public async Task<Company[]> GetAllCompanies()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._companyRepository.GetAll()?.Include(q => q.Location).ThenInclude(q => q.Address).Select(q => q).ToArray());
        }

        public async Task<Farmer[]> GetAllFarmers()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._farmerRepository.GetAll()?.Include(q => q.Company).Include(q => q.Address).Select(q => q).ToArray());
        }

        public async Task<TransportSchedule[]> GetTransportVehicleSchedulesByVehicleId(int vehicleId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.GetAll()?.Include(q => q.Vehicle).Include(q=> q.Vehicle.VehicleCapacity).Include(q => q.DestinationName).Include(q => q.OriginName).Include(q => q.Vehicle).Where(q => q.VehicleId == vehicleId).Select(q => q).ToArray());
        }

        public async Task<VehicleCategory[]> GetAllVehicleCategories()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.GetAll()?.Select(q => q).ToArray());

        }

        public async Task<Vehicle[]> GetAllCompanyTransportVehiclesByCompanyId(int companyId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleRepository.GetAll()?.Include(q => q.VehicleCategory).Include(q => q.Company).Include(q => q.Company.Location).Include(q => q.Company.Location.Address).Where(q => q.CompanyId == companyId).Select(q => q).ToArray());
        }

        public async Task<Vehicle> GetCompanyTransportVehicleByCompanyId(int companyId, int vehicleId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleRepository.GetAll()?.Include(q=> q.VehicleCapacity).Include(q => q.VehicleCategory).Include(q => q.Company).Include(q => q.Company.Location).Include(q => q.Company.Location.Address).Where(q => q.CompanyId == companyId).FirstOrDefault(q => q.VehicleId == vehicleId && q.CompanyId == companyId));
        }

        public async Task<bool> PostCreateTransportVehicleScheduleBy(TransportSchedule transportSchedule)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.Insert(transportSchedule);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<FoodHub[]> GetAllFoodHubs()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._foodHubRepository.GetAll()?.Include(q => q.Location).Select(q => q).ToArray());
        }

        public async Task<bool> UpdateCreateTransportVehicleSchduleByCompanyId(TransportSchedule transportSchedule)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._transportScheduleRepostiory.Update(transportSchedule);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<bool> PostCreateCompanyVehicleByCompanyId(Vehicle vehicle)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.Update(vehicle);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<FoodHub> GetFoodHubById(int foodHubId)
        {
            return await Task.FromResult(GetAllFoodHubs().Result.FirstOrDefault(f => f.FoodHubId == foodHubId));
        }

        public async Task<Commodity[]> GetAllFarmerCommodities(int farmerId)
        {
            IQueryable<Commodity> results = _africanFarmersCommoditiesUnitOfWork._commodityRepository.GetAll();
            return await Task.FromResult(results.Include(q => q.CommodityCategory).Include(q => q.CommodityUnit).Where(q => q.FarmerId == farmerId).ToArray());
        }
        public async Task<Commodity[]> GetAllFarmerCommodities()
        {
            IQueryable<Commodity> results = _africanFarmersCommoditiesUnitOfWork._commodityRepository.GetAll();
            return await Task.FromResult(results.Include(q => q.CommodityCategory).Include(q => q.CommodityUnit).ToArray());
        }
        public async Task<bool> UpdateCompanyVehicle(Vehicle vehicle)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.Insert(vehicle);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<bool> PostCreateFoodHub(FoodHub foodHub)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._foodHubRepository.Insert(foodHub);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<bool> CreateLocation(Location locationDefault)
        {
            var res = false;
            var location = _africanFarmersCommoditiesUnitOfWork._locationRepository.GetAll()?.FirstOrDefault(q => q.LocationName.ToLower() == locationDefault.LocationName.ToLower());
            if (location == null)
            {
                res = _africanFarmersCommoditiesUnitOfWork._locationRepository.Insert(locationDefault);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            }
            return await Task.FromResult(res);
        }

        public async Task<bool> CreateAddress(Address defaultAddress)
        {
            bool res = false;
            var address = _africanFarmersCommoditiesUnitOfWork._addressRepository.GetAll()?.FirstOrDefault(q => q.AddressLine1.ToLower() == defaultAddress.AddressLine1.ToLower() && q.PostCode.ToLower() == defaultAddress.PostCode.ToLower());
            if (address == null)
            {
                res = _africanFarmersCommoditiesUnitOfWork._addressRepository.Insert(defaultAddress);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            }
            return await Task.FromResult(res);
        }

        public async Task<bool> CreateCompany(Company companyDefault)
        {
            var res = false;
            var company = _africanFarmersCommoditiesUnitOfWork._companyRepository.GetAll()?.FirstOrDefault(q => q.CompanyName.ToLower() == companyDefault.CompanyName.ToLower());
            if (company == null)
            {
                res = _africanFarmersCommoditiesUnitOfWork._companyRepository.Insert(companyDefault);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            }
            return await Task.FromResult(res);
        }

        public async Task<Commodity> GetFarmerCommodityById(int farmerId, int commodityId)
        {
            IQueryable<Commodity> results = _africanFarmersCommoditiesUnitOfWork._commodityRepository.GetAll();
            return await results.Include(q => q.CommodityCategory).Include(q => q.CommodityUnit).Where(q => q.FarmerId == farmerId && q.CommodityId == commodityId).FirstOrDefaultAsync();
        }

        public async Task<bool> PostCreateCommodity(Commodity commodity)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._commodityRepository.Insert(commodity);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateFoodHub(FoodHub foodHub)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._foodHubRepository.Update(foodHub);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateDealPricing(DealsPricing dealsPricing)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._dealsPricingRepository.Update(dealsPricing);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }


        public async Task<bool> UpdateFarmerCommodity(Commodity commodity)
        {
            var result = _africanFarmersCommoditiesUnitOfWork._commodityRepository.Update(commodity);
            _africanFarmersCommoditiesUnitOfWork.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<bool> PostCreateVehicle(Vehicle vehicle)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.Insert(vehicle);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> PostCreateVehicleCategory(VehicleCategory vehicleCategory)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.Insert(vehicleCategory);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<TransportPricing[]> GetTransportPricing()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._transportPricingRepository.GetAll()?.ToList().ToArray());
        }

        public async Task<Address> GetAddressById(int addressId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._addressRepository.GetById(addressId));
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleRepository.GetById(vehicleId));
        }
        public async Task<VehicleCategory> GetVehicleCategoryById(int vehicleCategoryId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._vehicleCategoryRepository.GetById(vehicleCategoryId));
        }

        public async Task<Location> GetLocationById(int locationId)
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._locationRepository.GetById(locationId));
        }

        public async Task<bool> PostVehicle(Vehicle vehicle)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._vehicleRepository.Insert(vehicle);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public User GetUserByEmailAddress(string email)
        {
            return _africanFarmersCommoditiesUnitOfWork._userRepository.GetAll()?.First(q => q.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<bool> PostLocation(Location location)
        {
            try
            {
                _africanFarmersCommoditiesUnitOfWork._addressRepository.Insert(location.Address);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                location.AddressId = location.Address.AddressId;
                _africanFarmersCommoditiesUnitOfWork._locationRepository.Insert(location);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> PostDealPricing(DealsPricing dealsPricing)
        {
            try
            {
                var result = _africanFarmersCommoditiesUnitOfWork._dealsPricingRepository.Insert(dealsPricing);
                _africanFarmersCommoditiesUnitOfWork.SaveChanges();
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }


        public async Task<DealsPricing[]> GetDealsPricing()
        {
            return await Task.FromResult(_africanFarmersCommoditiesUnitOfWork._dealsPricingRepository.GetAll()?.ToArray());
        }
    }
}
