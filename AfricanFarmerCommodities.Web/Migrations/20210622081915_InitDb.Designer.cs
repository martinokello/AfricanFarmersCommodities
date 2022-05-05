﻿// <auto-generated />
using System;
using AfricanFarmerCommodities.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AfricanFarmerCommodities.Web.Migrations
{
    [DbContext(typeof(AfricanFarmerCommoditiesDBContext))]
    [Migration("20210622081915_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AfricanFarmerCommodities.Domain.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPhoneNUmber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId");

                    b.HasIndex("LocationId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.ActiveEnrouteCommodityMonitor", b =>
                {
                    b.Property<int>("ActiveEnrouteCommodityMonitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransportScheduleId")
                        .HasColumnType("int");

                    b.HasKey("ActiveEnrouteCommodityMonitorId");

                    b.HasIndex("TransportScheduleId");

                    b.ToTable("ActiveEnrouteCommodityMonitors");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Commodity", b =>
                {
                    b.Property<int>("CommodityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommodityCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CommodityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommodityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommodityUnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("CommodityUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<decimal>("NumberOfUnits")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CommodityId");

                    b.HasIndex("CommodityCategoryId");

                    b.HasIndex("CommodityUnitId");

                    b.ToTable("Commodities");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.CommodityCategory", b =>
                {
                    b.Property<int>("CommodityCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommodityCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommodityCategoryId");

                    b.ToTable("CommodityCategories");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.CommodityUnit", b =>
                {
                    b.Property<int>("CommodityUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommodityUnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommodityUnitId");

                    b.ToTable("CommodityUnits");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.DealsPricing", b =>
                {
                    b.Property<int>("DealsPricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DealsPricingId");

                    b.ToTable("DealsPricings");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FarmerCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FarmerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmerId");

                    b.HasIndex("AddressId");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.FoodHub", b =>
                {
                    b.Property<int>("FoodHubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Decription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodHubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodHubStorageId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("FoodHubId");

                    b.HasIndex("FoodHubStorageId");

                    b.HasIndex("LocationId");

                    b.ToTable("FoodHubs");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.FoodHubStorage", b =>
                {
                    b.Property<int>("FoodHubStorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommodityUnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DryStorageCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RefreigeratedStorageCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FoodHubStorageId");

                    b.HasIndex("CommodityUnitId");

                    b.ToTable("FoodHubStorages");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GrossCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InvoiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NetCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentTaxAppliable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TourClientId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<int?>("LaguageId")
                        .HasColumnType("int");

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Itinary", b =>
                {
                    b.Property<int>("ItinaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ItinaryId");

                    b.ToTable("Itinaries");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("AddressId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId");

                    b.HasIndex("RoleName")
                        .IsUnique()
                        .HasFilter("[RoleName] IS NOT NULL")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int?>("DriverId1")
                        .HasColumnType("int");

                    b.Property<int>("DriverId2")
                        .HasColumnType("int");

                    b.Property<int>("ItinaryId")
                        .HasColumnType("int");

                    b.Property<int?>("ItinaryId1")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId1")
                        .HasColumnType("int");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchedulesId")
                        .HasColumnType("int");

                    b.Property<int>("SchedulesPricingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeTo")
                        .HasColumnType("datetime2");

                    b.HasKey("ScheduleId");

                    b.HasIndex("DriverId");

                    b.HasIndex("DriverId1");

                    b.HasIndex("ItinaryId");

                    b.HasIndex("ItinaryId1");

                    b.HasIndex("LocationId");

                    b.HasIndex("LocationId1");

                    b.HasIndex("SchedulesId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.SchedulesPricing", b =>
                {
                    b.Property<int>("SchedulesPricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SchedulesDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchedulesPricingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchedulesPricingId");

                    b.ToTable("SchedulesPricings");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.TransportPricing", b =>
                {
                    b.Property<int>("TransportPricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportPricingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransportPricingId");

                    b.ToTable("TransportPricings");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.TransportSchedule", b =>
                {
                    b.Property<int>("TransportScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEndAtDestination")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStartFromOrigin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinationNameId")
                        .HasColumnType("int");

                    b.Property<int>("OriginNameId")
                        .HasColumnType("int");

                    b.Property<int>("TransportPricingId")
                        .HasColumnType("int");

                    b.Property<string>("TransportScheduleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("TransportScheduleId");

                    b.HasIndex("DestinationNameId");

                    b.HasIndex("OriginNameId");

                    b.HasIndex("TransportPricingId");

                    b.HasIndex("VehicleId");

                    b.ToTable("TransportSchedules");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLockedOut")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogInTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoleId", "UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActualNumberOfPassengersAllocated")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxNumberOfPassengers")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("VehicleCategoryId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.VehicleCapacity", b =>
                {
                    b.Property<int>("VehicleCapacityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VechicleCapacityUnitsName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleCapacityId");

                    b.ToTable("VehicleCapacities");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.VehicleCategory", b =>
                {
                    b.Property<int>("VehicleCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleCapacityId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleCategoryId");

                    b.HasIndex("VehicleCapacityId");

                    b.ToTable("VehicleCategories");
                });

            modelBuilder.Entity("AfricanFarmerCommodities.Domain.Company", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.ActiveEnrouteCommodityMonitor", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.TransportSchedule", "TransportSchedule")
                        .WithMany()
                        .HasForeignKey("TransportScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Commodity", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.CommodityCategory", "CommodityCategory")
                        .WithMany()
                        .HasForeignKey("CommodityCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.CommodityUnit", "CommodityUnit")
                        .WithMany()
                        .HasForeignKey("CommodityUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Driver", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Farmer", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.FoodHub", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.FoodHubStorage", "FoodHubStorage")
                        .WithMany()
                        .HasForeignKey("FoodHubStorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.FoodHubStorage", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.CommodityUnit", "CommodityUnit")
                        .WithMany()
                        .HasForeignKey("CommodityUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Item", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Invoice", "Invoice")
                        .WithMany("InvoicedItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Location", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Schedule", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.Driver", null)
                        .WithMany("Schedules")
                        .HasForeignKey("DriverId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AfricanFarmersCommodities.Domain.Itinary", "Itinary")
                        .WithMany("Schedules")
                        .HasForeignKey("ItinaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.Itinary", null)
                        .WithMany()
                        .HasForeignKey("ItinaryId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AfricanFarmersCommodities.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AfricanFarmersCommodities.Domain.SchedulesPricing", "SchedulesPricing")
                        .WithMany()
                        .HasForeignKey("SchedulesId");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.TransportSchedule", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Location", "DestinationName")
                        .WithMany()
                        .HasForeignKey("DestinationNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.Location", "OriginName")
                        .WithMany()
                        .HasForeignKey("OriginNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.TransportPricing", "TransportPricing")
                        .WithMany()
                        .HasForeignKey("TransportPricingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.User", b =>
                {
                    b.HasOne("AfricanFarmerCommodities.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.UserRole", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.Vehicle", b =>
                {
                    b.HasOne("AfricanFarmerCommodities.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AfricanFarmersCommodities.Domain.VehicleCategory", "VehicleCategory")
                        .WithMany()
                        .HasForeignKey("VehicleCategoryId");
                });

            modelBuilder.Entity("AfricanFarmersCommodities.Domain.VehicleCategory", b =>
                {
                    b.HasOne("AfricanFarmersCommodities.Domain.VehicleCapacity", "VehicleCapacity")
                        .WithMany()
                        .HasForeignKey("VehicleCapacityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
