using AfricanFarmerCommodities.Domain;
using AfricanFarmersCommodities.Domain;
using ExcelAccessDataEngine.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.DataAccess
{
    public class AfricanFarmerCommoditiesDBContext : DbContext
    {
        public AfricanFarmerCommoditiesDBContext(DbContextOptions<AfricanFarmerCommoditiesDBContext> dbOptions) : base(dbOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransportLog>()
            .HasIndex(p => new { p.TransportScheduleId, p.InvoiceId }).IsUnique();
            modelBuilder.Entity<User>().HasAlternateKey("Username").HasName("User_Username");
            modelBuilder.Entity<UserRole>().HasKey("UserRoleId");
            modelBuilder.Entity<UserRole>().HasAlternateKey("UserId", "RoleId").HasName("UserRole_UserIdRoleId");
            modelBuilder.Entity<Role>().HasKey("RoleId");
            modelBuilder.Entity<IntermediateSchedule>().HasOne<Vehicle>().WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<IntermediateSchedule>().HasOne<Location>().WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasIndex(e => e.Email)
            .IsUnique()
            .IsClustered(false);
            modelBuilder.Entity<User>().HasIndex(e => e.Username)
            .IsUnique()
            .IsClustered(false);
            modelBuilder.Entity<Role>().HasIndex(e => e.RoleName)
            .IsUnique()
            .IsClustered(false);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<IntermediateSchedule> Schedules { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<IntermediateSchedule> IntermediateSchedules { get; set; }
        public DbSet<DealsPricing> DealsPricings { get; set; }
        public DbSet<TransportPricing> TransportPricings { get; set; }
        public DbSet<ActiveEnrouteCommodityMonitor> ActiveEnrouteCommodityMonitors { get; set; }
        public DbSet<TransportSchedule> TransportSchedules { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<CommodityUnit> CommodityUnits { get; set; }
        public DbSet<CommodityCategory> CommodityCategories { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<FoodHub> FoodHubs { get; set; }
        public DbSet<FoodHubStorage> FoodHubStorages { get; set; }
        public DbSet<VehicleCapacity> VehicleCapacities { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<TransportLog> TransportLogs { get; set; }
        public DbSet<DriverSchedulesNote> DriverSchedulesNotes { get; set; }


        public List<dynamic> GetFoodHubCommoditiesStockStorageUsage()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[AllFoodHubDateAnalysisCommoditiesStockStorageUsage]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new
                {
                    FoodHubId = reader["FoodHubId"] == DBNull.Value ? 0 : (int)reader["FoodHubId"],
                    FoodHubName = reader["FoodHubName"] == DBNull.Value ? "Not Found" : (string)reader["FoodHubName"],
                    FoodHubStorageId = reader["FoodHubStorageId"] == DBNull.Value ? 0 : (int)reader["FoodHubStorageId"],
                    RefreigeratedStorageCapacity = reader["RefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0.00 : (decimal)reader["RefreigeratedStorageCapacity"],
                    DryStorageCapacity = reader["DryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["DryStorageCapacity"],
                    UsedDryStorageCapacity = reader["UsedDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["UsedDryStorageCapacity"],
                    UsedRefreigeratedStorageCapacity = reader["UsedRefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0 : (decimal)reader["UsedRefreigeratedStorageCapacity"]
                });
            }
            return listItems;
        }


        public List<dynamic> FoodHubCommoditiesStockStorageUsageByFoodHubId(int foodHubId)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            var foodHub = cmd.CreateParameter();
            foodHub.ParameterName = "@foodHubId";
            foodHub.Value = foodHubId;
            cmd.Parameters.Add(foodHub);

            cmd.CommandText = "dbo.FoodHubCommoditiesStockStorageUsageByFoodHubId";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new
                {
                    FoodHubId = reader["FoodHubId"] == DBNull.Value ? 0 : (int)reader["FoodHubId"],
                    FoodHubName = reader["FoodHubName"] == DBNull.Value ? "Not Found" : (string)reader["FoodHubName"],
                    FoodHubStorageId = reader["FoodHubStorageId"] == DBNull.Value ? 0 : (int)reader["FoodHubStorageId"],
                    RefreigeratedStorageCapacity = reader["RefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0.00 : (decimal)reader["RefreigeratedStorageCapacity"],
                    DryStorageCapacity = reader["DryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["DryStorageCapacity"],
                    UsedDryStorageCapacity = reader["UsedDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["UsedDryStorageCapacity"],
                    UsedRefreigeratedStorageCapacity = reader["UsedRefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0 : (decimal)reader["UsedRefreigeratedStorageCapacity"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetTop5DryCommoditiesInDemandRatingAccordingToStorageFacilities()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.Top5FoodHubDryStorageUsage";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    CommodityCategoryName = reader["CommodityCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityCategoryName"],
                    TotalUsedDryStorageCapacity = reader["TotalUsedDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalUsedDryStorageCapacity"],
                    TotalDryStorageCapacity = reader["TotalDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalDryStorageCapacity"]
                });
            }
            return listItems;
        }
        public List<dynamic> GetTop5RefreigeratedCommoditiesInDemandRatingAccordingToStorageFacilities()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.Top5FoodHubRefreigeratedStorageUsage";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    CommodityCategoryName = reader["CommodityCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityCategoryName"],
                    TotalUsedRefreigeratedStorageCapacity = reader["TotalUsedReferigeratedCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalUsedReferigeratedCapacity"],
                    TotalRefreigeratedStorageCapacity = reader["TotalRefreigeratedStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalRefreigeratedStorageCapacity"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetTop5FarmerCommoditiesInUnitPricings()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5FarmerHighestPriceOfCommoditiesInStorage]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0 : (int)reader["FarmerId"],
                    FarmerName = reader["FarmerName"] == DBNull.Value ? "Not Found" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    CommodityCategoryName = reader["CommodityCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityCategoryName"],
                    CommodityUnitName = reader["CommodityUnitName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityUnitName"],
                    FarmerCommodityUnitPrice = reader["FarmerCommodityUnitPrice"] == DBNull.Value ? 0 : (decimal)reader["FarmerCommodityUnitPrice"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetFoodHubDateAnalysisCommoditiesStockStorageUsage(DateTime dateFrom, DateTime dateTo)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();

            var from = cmd.CreateParameter();
            from.ParameterName = "@dateFrom";
            from.Value = dateFrom;
            cmd.Parameters.Add(from);

            var to = cmd.CreateParameter();
            to.ParameterName = "@dateTo";
            to.Value = dateTo;
            cmd.Parameters.Add(to);
            cmd.CommandText = "dbo.[FoodHubCommoditiesStockStorageUsageOverDateDuration]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    FoodHubId = reader["FoodHubId"] == DBNull.Value ? 0 : (int)reader["FoodHubId"],
                    FoodHubName = reader["FoodHubName"] == DBNull.Value ? "Not Found" : (string)reader["FoodHubName"],
                    FoodHubStorageId = reader["FoodHubStorageId"] == DBNull.Value ? 0 : (int)reader["FoodHubStorageId"],
                    RefreigeratedStorageCapacity = reader["RefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0.00 : (decimal)reader["RefreigeratedStorageCapacity"],
                    DryStorageCapacity = reader["DryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["DryStorageCapacity"],
                    UsedDryStorageCapacity = reader["UsedDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["UsedDryStorageCapacity"],
                    UsedRefreigeratedStorageCapacity = reader["UsedRefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0 : (decimal)reader["UsedRefreigeratedStorageCapacity"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetAllFoodHubDateAnalysisCommoditiesStockStorageUsage(DateTime dateFrom, DateTime dateTo, int foodHubId)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();

            var from = cmd.CreateParameter();
            from.ParameterName = "@dateFrom";
            from.Value = dateFrom;
            cmd.Parameters.Add(from);

            var to = cmd.CreateParameter();
            to.ParameterName = "@dateTo";
            to.Value = dateTo;
            cmd.Parameters.Add(to);

            var foodHub = cmd.CreateParameter();
            foodHub.ParameterName = "@foodHubId";
            foodHub.Value = foodHubId;
            cmd.Parameters.Add(foodHub);

            cmd.CommandText = "dbo.FoodHubCommoditiesStockStorageUsageByFoodHubIdOverDateDuration";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    FoodHubId = reader["FoodHubId"] == DBNull.Value ? 0 : (int)reader["FoodHubId"],
                    FoodHubName = reader["FoodHubName"] == DBNull.Value ? "Not Found" : (string)reader["FoodHubName"],
                    FoodHubStorageId = reader["FoodHubStorageId"] == DBNull.Value ? 0 : (int)reader["FoodHubStorageId"],
                    RefreigeratedStorageCapacity = reader["RefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0.00 : (decimal)reader["RefreigeratedStorageCapacity"],
                    DryStorageCapacity = reader["DryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["DryStorageCapacity"],
                    UsedDryStorageCapacity = reader["UsedDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["UsedDryStorageCapacity"],
                    UsedRefreigeratedStorageCapacity = reader["UsedRefreigeratedStorageCapacity"] == DBNull.Value ? (decimal)0 : (decimal)reader["UsedRefreigeratedStorageCapacity"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetTop5DryCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilities(DateTime dateFrom, DateTime dateTo)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();

            var from = cmd.CreateParameter();
            from.ParameterName = "@dateFrom";
            from.Value = dateFrom;
            cmd.Parameters.Add(from);

            var to = cmd.CreateParameter();
            to.ParameterName = "@dateTo";
            to.Value = dateTo;
            cmd.Parameters.Add(to);

            cmd.CommandText = "dbo.Top5FarmerHighestDryStoragePriceUsageBtwDates";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    CommodityCategoryName = reader["CommodityCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["CommCommodityCategoryNameodityName"],
                    TotalUsedDryStorageCapacity = reader["TotalUsedDryStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalUsedDryStorageCapacity"],
                    TotalDryStorageCapacity = reader["TotalDryStorageCapacity"] == DBNull.Value ? "Not Found" : (string)reader["FoodHubName"],
                });
            }
            return listItems;
        }

        public List<dynamic> GetTop5RefreigeratedCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilitiess(DateTime dateFrom, DateTime dateTo)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();

            var from = cmd.CreateParameter();
            from.ParameterName = "@dateFrom";
            from.Value = dateFrom;
            cmd.Parameters.Add(from);

            var to = cmd.CreateParameter();
            to.ParameterName = "@dateTo";
            to.Value = dateTo;
            cmd.Parameters.Add(to);
            cmd.CommandText = "dbo.[Top5FarmerHighesRefreigeratedStoragePriceUsageBtwDates]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    CommodityCategoryName = reader["CommodityCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["CommCommodityCategoryNameodityName"],
                    TotalUsedRefreigeratedStorageCapacity = reader["TotalUsedRefreigeratedStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalUsedRefreigeratedStorageCapacity"],
                    TotalRefreigeratedStorageCapacity = reader["TotalRefreigeratedStorageCapacity"] == DBNull.Value ? 0 : (decimal)reader["TotalRefreigeratedStorageCapacity"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetTop5FarmerCommoditiesDateAnalysisInUnitPricingOverDate(DateTime dateFrom, DateTime dateTo)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();

            var from = cmd.CreateParameter();
            from.ParameterName = "@dateFrom";
            from.Value = dateFrom;
            cmd.Parameters.Add(from);

            var to = cmd.CreateParameter();
            to.ParameterName = "@dateTo";
            to.Value = dateTo;
            cmd.Parameters.Add(to);

            cmd.CommandText = "dbo.[Top5FarmerHighestPriceOfCommoditiesInStorageBtnDates]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0 : (int)reader["FarmerId"],
                    FarmerName = reader["FarmerName"] == DBNull.Value ? "Not Found" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    CommodityCategoryName = reader["CommodityCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityCategoryName"],
                    CommodityUnitName = reader["CommodityUnitName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityUnitName"],
                    FarmerCommodityUnitPrice = reader["FarmerCommodityUnitPrice"] == DBNull.Value ? 0 : (decimal)reader["FarmerCommodityUnitPrice"]
                });
            }
            return listItems;
        }

        public List<dynamic> GetAllUnScheduledVehiclesByStorageCapacityLowestPrice()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "[dbo].[AllUnScheduledVehiclesByStorageCapacityLowestPrice]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    VehicleId = reader["VehicleId"] == DBNull.Value ? 0 : (int)reader["VehicleId"],
                    VehicleRegistration = reader["VehicleRegistration"] == DBNull.Value ? "Not Found" : (string)reader["VehicleRegistration"],
                    CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (string)reader["CompanyName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    Description = reader["Description"] == DBNull.Value ? "Not Found" : (string)reader["Description"],
                    Cost = reader["Cost"] == DBNull.Value ? 0 : (decimal)reader["Cost"]
                });
            }
            return listItems;
        }
        public List<dynamic> GetAllScheduledVehiclesByStorageCapacityLowestPrice()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "exec dbo.[spAllScheduledVehiclesByStorageCapacityLowestPrice]";
            cmd.CommandType = System.Data.CommandType.Text;

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    VehicleId = reader["VehicleId"] == DBNull.Value ? 0 : (int)reader["VehicleId"],
                    VehicleRegistration = reader["VehicleRegistration"] == DBNull.Value ? "Not Found" : (string)reader["VehicleRegistration"],
                    CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (string)reader["CompanyName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    Description = reader["Description"] == DBNull.Value ? "Not Found" : (string)reader["Description"],
                    Cost = reader["Cost"] == DBNull.Value ? 0 : (decimal)reader["Cost"]
                });
            }
            return listItems;
        }
        public List<dynamic> GetTop5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<dynamic>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.Top5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add(new
                {
                    VehicleId = reader["VehicleId"] == DBNull.Value ? 0 : (int)reader["VehicleId"],
                    VehicleRegistration = reader["VehicleRegistration"] == DBNull.Value ? "Not Found" : (string)reader["VehicleRegistration"],
                    CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (string)reader["CompanyName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    Description = reader["Description"] == DBNull.Value ? "Not Found" : (string)reader["Description"],
                    Cost = reader["Cost"] == DBNull.Value ? 0 : (decimal)reader["Cost"]
                });
            }
            return listItems;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////New StoredProcedure Access
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<CommodityAndQuantity> GetTop5CommoditiesSoldByCapacityOverAll()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<CommodityAndQuantity>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesSoldByCapacityOverAll]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new CommodityAndQuantity
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0: (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" :(string)reader["CommodityName"],
                    Quantity = reader["Quantity"] == DBNull.Value ? 0 : (int)reader["Quantity"],
                });
            }
            return listItems;
        }

        public List<CommodityAndGrossReturns> GetTop5CommoditiesSoldByCostReturnsOverAll()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<CommodityAndGrossReturns>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesSoldByCostReturnsOverAll]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new CommodityAndGrossReturns
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "" : (string)reader["CommodityName"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"],
                });
            }
            return listItems;
        }

        public List<CommodityAndGrossReturns> GetTop5CommoditiesSoldByCostReturnsOverthePastYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<CommodityAndGrossReturns>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesSoldByCostReturnsOverthePastYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new CommodityAndGrossReturns
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "not found" : (string)reader["CommodityName"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"],
                });
            }
            return listItems;
        }


        public List<FarmerCommodityAndQuantity> GetTop5CommoditiesByFarmerSoldByCapacityOverAll()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerCommodityAndQuantity>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesByFarmerSoldByCapacityOverAll]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerCommodityAndQuantity
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0: (int)reader["FarmerId"],
                    FarmerName = reader["FarmerName"] == DBNull.Value ? "" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "" : (string)reader["CommodityName"],
                    Quantity = reader["Quantity"] == DBNull.Value ? 0 : (int)reader["Quantity"],
                });
            }
            return listItems;
        }
        public List<FarmerCommodityAndGrossReturns> GetTop5CommoditiesByFarmerSoldByCostReturnsOverAll()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerCommodityAndGrossReturns>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesByFarmerSoldByCostReturnsOverAll]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerCommodityAndGrossReturns
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0 : (int)reader["FarmerId"],
                    FarmerName = reader["FarmerName"] == DBNull.Value ? "" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "" : (string)reader["CommodityName"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"],
                });
            }
            return listItems;
        }

        public List<FarmerCommodityAndGrossReturns> GetTop5CommoditiesByFarmerSoldByCostReturnsOverthePastYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerCommodityAndGrossReturns>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerCommodityAndGrossReturns
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0 : (int)reader["FarmerId"],
                    FarmerName = reader["FarmerName"] == DBNull.Value ? "" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "" : (string)reader["CommodityName"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"],
                });
            }
            return listItems;
        }

        public List<CommodityAndQuantity> GetTop5CommoditiesSoldByCapacityOverthePastYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<CommodityAndQuantity>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesSoldByCapacityOverthePastYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new CommodityAndQuantity
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    Quantity = reader["Quantity"] == DBNull.Value ? 0 : (int)reader["Quantity"],
                });
            }
            return listItems;
        }

        public List<FarmerCommodityAndQuantity> GetTop5CommoditiesByFarmerSoldByCapacityOverthePastYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerCommodityAndQuantity>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5CommoditiesByFarmerSoldByCapacityOverthePastYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerCommodityAndQuantity
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0 : (int)reader["FarmerId"],
                    FarmerName = reader["FarmerName"] == DBNull.Value ? "" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "" : (string)reader["CommodityName"],
                    Quantity = reader["Quantity"] == DBNull.Value ? 0 : (int)reader["Quantity"],
                });
            }
            return listItems;
        }

        public List<CommodityAndQuantity> GetTop5CommoditiesSoldByCapacityOverDate(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<CommodityAndQuantity>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5CommoditiesSoldByCapacityOverDate]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new CommodityAndQuantity
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "Not Found" : (string)reader["CommodityName"],
                    Quantity = reader["Quantity"] == DBNull.Value ? 0 : (int)reader["Quantity"],
                });
            }
            return listItems;
        }
        public List<CommodityAndGrossReturns> GetTop5CommoditiesSoldByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<CommodityAndGrossReturns>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new CommodityAndGrossReturns
                {
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "not found" : (string)reader["CommodityName"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"],
                });
            }
            return listItems;
        }

        public List<FarmerCommodityAndQuantity> GetTop5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerCommodityAndQuantity>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerCommodityAndQuantity
                {
                    FarmerId = reader["FarmerId"] == DBNull.Value ? 0 : (int)reader["FarmerId"],
                    FarmerName = reader["FramerName"] == DBNull.Value ? "" : (string)reader["FarmerName"],
                    CommodityId = reader["CommodityId"] == DBNull.Value ? 0 : (int)reader["CommodityId"],
                    CommodityName = reader["CommodityName"] == DBNull.Value ? "" : (string)reader["CommodityName"],
                    Quantity = reader["Quantity"] == DBNull.Value ? 0 : (int)reader["Quantity"],
                });
            }
            return listItems;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////Vehicle Queries
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<VehicleNumbersScheduled> GetTop5VehicleCategoriesUsedByCapacityOvertheyear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<VehicleNumbersScheduled>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5VehicleCategoriesUsedByCapacityOvertheyear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new VehicleNumbersScheduled
                {
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    NumbersOfSchedules = reader["NumbersOfSchedules"] == DBNull.Value ? 0 : (int)reader["NumbersOfSchedules"]
                });
            }
            return listItems;
        }

        public List<VehicleNumbersScheduled> GetTop5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<VehicleNumbersScheduled>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new VehicleNumbersScheduled
                {
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    NumbersOfSchedules = reader["NumbersOfSchedules"] == DBNull.Value ? 0 : (int)reader["NumbersOfSchedules"]
                });
            }
            return listItems;
        }
        public List<VehicleCostReturnsScheduled> GetTop5VehiclesCategoriesUsedByCostReturnsOverYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<VehicleCostReturnsScheduled>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByCostReturnsOverYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new VehicleCostReturnsScheduled
                {
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    GrossReturns = reader["GrossCostReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossCostReturns"]
                });
            }
            return listItems;
        }
        public List<VehicleCostReturnsScheduled> GetTop5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<VehicleCostReturnsScheduled>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new VehicleCostReturnsScheduled
                {
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    GrossReturns = reader["GrossCostReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossCostReturns"]
                });
            }
            return listItems;
        }

        public List<FarmerVehicleCategoryUsageByNumber> GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerVehicleCategoryUsageByNumber>();

            var cmd = con.CreateCommand();

            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerVehicleCategoryUsageByNumber
                {
                    FamerName = reader["FamerName"] == DBNull.Value ? "" : (string)reader["FamerName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    VechicleCapacity = reader["VechicleCapacity"] == DBNull.Value ? 0 : (decimal)reader["VechicleCapacity"],
                    NumberOfVehicles = reader["NumberOfVehicles"] == DBNull.Value ? 0 : (int)reader["NumberOfVehicles"]
                });
            }
            return listItems;
        }

        public List<FarmerVehicleCategoryUsageByNumber> GetTop5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerVehicleCategoryUsageByNumber>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerVehicleCategoryUsageByNumber
                {
                    FamerName = reader["FamerName"] == DBNull.Value ? "" : (string)reader["FamerName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    VechicleCapacity = reader["VechicleCapacity"] == DBNull.Value ? 0 : (decimal)reader["VechicleCapacity"],
                    NumberOfVehicles = reader["NumberOfVehicles"] == DBNull.Value ? 0 : (int)reader["NumberOfVehicles"]
                });
            }
            return listItems;
        }
        public List<FarmerVehicleCategoryUsageByCostReturns> GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear()
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerVehicleCategoryUsageByCostReturns>();

            var cmd = con.CreateCommand();
            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerVehicleCategoryUsageByCostReturns
                {
                    FamerName = reader["FamerName"] == DBNull.Value ? "" : (string)reader["FamerName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    VechicleCapacity = reader["VechicleCapacity"] == DBNull.Value ? 0 : (decimal)reader["VechicleCapacity"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"]
                });
            }
            return listItems;
        }
        public List<FarmerVehicleCategoryUsageByCostReturns> GetTop5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            var con = this.Database.GetDbConnection();

            var listItems = new List<FarmerVehicleCategoryUsageByCostReturns>();

            var cmd = con.CreateCommand();
            var datStParam = cmd.CreateParameter();
            var datEdParam = cmd.CreateParameter();

            datStParam.ParameterName = "@dateBegin";
            datStParam.Value = dateBegin;

            datEdParam.ParameterName = "@dateEnd";
            datEdParam.Value = dateEnd;

            cmd.Parameters.Add(datStParam);
            cmd.Parameters.Add(datEdParam);

            cmd.CommandText = "dbo.[Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listItems.Add(new FarmerVehicleCategoryUsageByCostReturns
                {
                    FamerName = reader["FamerName"] == DBNull.Value ? "" : (string)reader["FamerName"],
                    VehicleCategoryName = reader["VehicleCategoryName"] == DBNull.Value ? "Not Found" : (string)reader["VehicleCategoryName"],
                    VechicleCapacity = reader["VechicleCapacity"] == DBNull.Value ? 0 : (decimal)reader["VechicleCapacity"],
                    GrossReturns = reader["GrossReturns"] == DBNull.Value ? 0 : (decimal)reader["GrossReturns"]
                });
            }
            return listItems;
        }
    }


}
