using AfricanFarmerCommodities.DataAccess;
using AfricanFarmerCommodities.Domain;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.RepositoryServices.Concretes;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using SimbaToursEastAfrica.Services.RepositoryServices.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.UnitOfWork.Concretes
{
    public class AfricanFarmerCommoditiesUnitOfWork : IUnitOfWork
    {
        public AddressRepository _addressRepository;
        public DriverRepository _driverRepository;
        public InvoiceRepository _invoiceRepository;
        public ItemRepository _itemRepository;
        public LocationRepository _locationRepository;
        public IntermediateScheduleRepository _intermediateScheduleRepository;
        public VehicleRepository _vehicleRepository;
        public DealsPricingRepository _dealsPricingRepository;
        public TransportPricingRepository _transportPricingRepository;
        public UserRepository _userRepository;
        public RolesRepository _rolesRepository;
        public UserInRolesRepository _userInRolesRepository;
        public ActiveEnrouteCommodityMonitorRepository _activeEnrouteCommodityMonitorRepository;
        public CommodityCategoryRepository _commodityCategoryRepository;
        public CommodityRepository _commodityRepository;
        public CommodityUnitRepository _commodityUnitRepository;
        public FarmerRepository _farmerRepository;
        public FoodHubRepository _foodHubRepository;
        public FoodHubStorageRepository _foodHubStorageRepository;
        public VehicleCapacityRepository _vehicleCapacityRepository;
        public VehicleCategoryRepository _vehicleCategoryRepository;
        public TransportScheduleRepository _transportScheduleRepostiory;
        public CompanyRepository _companyRepository;
        public DriverSchedulesNotesRepository _driverSchedulesNotesRepository;
        public TransportLogRepository _transportLogRepository;
        public AfricanFarmerCommoditiesDBContext AfricanFarmerCommoditiesDbContext { get; set; }
        public AfricanFarmerCommoditiesUnitOfWork(
            AbstractRepository<Address> addressRepository,
            AbstractRepository<Driver> driverRepository,
            AbstractRepository<Invoice> invoiceRepository,
            AbstractRepository<Item> itemRepository,
            AbstractRepository<IntermediateSchedule> intermediateScheduleRepository,
            AbstractRepository<Location> locationRepository,
            AbstractRepository<Vehicle> vehicleRepository,
            AbstractRepository<DealsPricing> dealsPricingRepository,
            AbstractRepository<TransportPricing> transportPricingRepository,
            AbstractRepository<User> userRepository,
            AbstractRepository<Role> rolesRepository,
            AbstractRepository<UserRole> userInRolesRepository,
            AbstractRepository<VehicleCategory> vehicleCategoryRepository,
            AbstractRepository<FoodHubStorage> foodHubStorageRepository,
            AbstractRepository<VehicleCapacity> vehicleCapacityRepository,
            AbstractRepository<FoodHub> foodHubRepository,
            AbstractRepository<CommodityUnit> commodityUnitRepository,
            AbstractRepository<Commodity> commodityRepository,
            AbstractRepository<CommodityCategory> commodityCategoryRepository,
            AbstractRepository<ActiveEnrouteCommodityMonitor> activeEnrouteCommodityMonitorRepository,
            AbstractRepository<TransportSchedule> transportScheduleRepository,
            AbstractRepository<Company> companyRepository,
            AbstractRepository<Farmer> farmerRepository,
            AbstractRepository<DriverSchedulesNote> driverSchedulesNotesRepository,
            AbstractRepository<TransportLog> transportLogRepository,
            AfricanFarmerCommoditiesDBContext africanFarmerCommoditiesDbContext)
        {
            AfricanFarmerCommoditiesDbContext = africanFarmerCommoditiesDbContext as AfricanFarmerCommoditiesDBContext;
            _addressRepository = addressRepository as AddressRepository;
            _addressRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _driverRepository = driverRepository as DriverRepository;
            _driverRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _invoiceRepository = invoiceRepository as InvoiceRepository;
            _invoiceRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _itemRepository = itemRepository as ItemRepository;
            _itemRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _intermediateScheduleRepository = intermediateScheduleRepository as IntermediateScheduleRepository;
            _intermediateScheduleRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _locationRepository = locationRepository as LocationRepository;
            _locationRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _vehicleRepository = vehicleRepository as VehicleRepository;
            _vehicleRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _dealsPricingRepository = dealsPricingRepository as DealsPricingRepository;
            _dealsPricingRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _userRepository = userRepository as UserRepository;
            _userRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _rolesRepository = rolesRepository as RolesRepository;
            _rolesRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _userInRolesRepository = userInRolesRepository as UserInRolesRepository;
            _userInRolesRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _transportPricingRepository = transportPricingRepository as TransportPricingRepository;
            _transportPricingRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _vehicleCategoryRepository = vehicleCategoryRepository as VehicleCategoryRepository;
            _vehicleCategoryRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _foodHubStorageRepository = foodHubStorageRepository as FoodHubStorageRepository;
            _foodHubStorageRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _foodHubRepository = foodHubRepository as FoodHubRepository;
            _foodHubRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _vehicleCapacityRepository = vehicleCapacityRepository as VehicleCapacityRepository;
            _vehicleCapacityRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _commodityUnitRepository = commodityUnitRepository as CommodityUnitRepository;
            _commodityUnitRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _commodityRepository = commodityRepository as CommodityRepository;
            _commodityRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _commodityCategoryRepository = commodityCategoryRepository as CommodityCategoryRepository;
            _commodityCategoryRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _activeEnrouteCommodityMonitorRepository = activeEnrouteCommodityMonitorRepository as ActiveEnrouteCommodityMonitorRepository;
            _activeEnrouteCommodityMonitorRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _transportScheduleRepostiory = transportScheduleRepository as TransportScheduleRepository;
            _transportScheduleRepostiory.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _companyRepository = companyRepository as CompanyRepository;
            _companyRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _farmerRepository = farmerRepository as FarmerRepository;
            _farmerRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _driverSchedulesNotesRepository = driverSchedulesNotesRepository as DriverSchedulesNotesRepository;
            _driverSchedulesNotesRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;
            _transportLogRepository = transportLogRepository as TransportLogRepository;
            _transportLogRepository.AfricanFarmerCommoditiesDBContext = africanFarmerCommoditiesDbContext;


        }
        public void SaveChanges()
        {
            AfricanFarmerCommoditiesDbContext.SaveChanges();
        }
    }
}
