using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "CommodityCategories",
                columns: table => new
                {
                    CommodityCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityCategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityCategories", x => x.CommodityCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CommodityUnits",
                columns: table => new
                {
                    CommodityUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityUnitName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityUnits", x => x.CommodityUnitId);
                });

            migrationBuilder.CreateTable(
                name: "DealsPricings",
                columns: table => new
                {
                    DealsPricingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealsPricings", x => x.DealsPricingId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceName = table.Column<string>(nullable: true),
                    NetCost = table.Column<decimal>(nullable: false),
                    PercentTaxAppliable = table.Column<decimal>(nullable: false),
                    GrossCost = table.Column<decimal>(nullable: false),
                    TourClientId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Itinaries",
                columns: table => new
                {
                    ItinaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinaries", x => x.ItinaryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SchedulesPricings",
                columns: table => new
                {
                    SchedulesPricingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchedulesPricingName = table.Column<string>(nullable: true),
                    SchedulesDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesPricings", x => x.SchedulesPricingId);
                });

            migrationBuilder.CreateTable(
                name: "TransportPricings",
                columns: table => new
                {
                    TransportPricingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(nullable: false),
                    TransportPricingName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportPricings", x => x.TransportPricingId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCapacities",
                columns: table => new
                {
                    VehicleCapacityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VechicleCapacityUnitsName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCapacities", x => x.VehicleCapacityId);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    FarmerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerName = table.Column<string>(nullable: true),
                    FarmerCompanyName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.FarmerId);
                    table.ForeignKey(
                        name: "FK_Farmers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    CommodityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityName = table.Column<string>(nullable: true),
                    CommodityDescription = table.Column<string>(nullable: true),
                    CommodityUnitPrice = table.Column<decimal>(nullable: false),
                    NumberOfUnits = table.Column<decimal>(nullable: false),
                    CommodityUnitId = table.Column<int>(nullable: false),
                    CommodityCategoryId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    FarmerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.CommodityId);
                    table.ForeignKey(
                        name: "FK_Commodities_CommodityCategories_CommodityCategoryId",
                        column: x => x.CommodityCategoryId,
                        principalTable: "CommodityCategories",
                        principalColumn: "CommodityCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commodities_CommodityUnits_CommodityUnitId",
                        column: x => x.CommodityUnitId,
                        principalTable: "CommodityUnits",
                        principalColumn: "CommodityUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodHubStorages",
                columns: table => new
                {
                    FoodHubStorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DryStorageCapacity = table.Column<decimal>(nullable: false),
                    RefreigeratedStorageCapacity = table.Column<decimal>(nullable: false),
                    CommodityUnitId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHubStorages", x => x.FoodHubStorageId);
                    table.ForeignKey(
                        name: "FK_FoodHubStorages_CommodityUnits_CommodityUnitId",
                        column: x => x.CommodityUnitId,
                        principalTable: "CommodityUnits",
                        principalColumn: "CommodityUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ItemCost = table.Column<decimal>(nullable: false),
                    LaguageId = table.Column<int>(nullable: true),
                    MealId = table.Column<int>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategories",
                columns: table => new
                {
                    VehicleCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    VehicleCapacityId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategories", x => x.VehicleCategoryId);
                    table.ForeignKey(
                        name: "FK_VehicleCategories_VehicleCapacities_VehicleCapacityId",
                        column: x => x.VehicleCapacityId,
                        principalTable: "VehicleCapacities",
                        principalColumn: "VehicleCapacityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyPhoneNUmber = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodHubs",
                columns: table => new
                {
                    FoodHubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodHubName = table.Column<string>(nullable: true),
                    Decription = table.Column<string>(nullable: true),
                    FoodHubStorageId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHubs", x => x.FoodHubId);
                    table.ForeignKey(
                        name: "FK_FoodHubs_FoodHubStorages_FoodHubStorageId",
                        column: x => x.FoodHubStorageId,
                        principalTable: "FoodHubStorages",
                        principalColumn: "FoodHubStorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodHubs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastLogInTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsLockedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRegistration = table.Column<string>(nullable: true),
                    MaxNumberOfPassengers = table.Column<int>(nullable: false),
                    ActualNumberOfPassengersAllocated = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    VehicleCategoryId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleCategories_VehicleCategoryId",
                        column: x => x.VehicleCategoryId,
                        principalTable: "VehicleCategories",
                        principalColumn: "VehicleCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserRoleId, x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportSchedules",
                columns: table => new
                {
                    TransportScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportScheduleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false),
                    TransportPricingId = table.Column<int>(nullable: false),
                    OriginNameId = table.Column<int>(nullable: false),
                    DestinationNameId = table.Column<int>(nullable: false),
                    DateStartFromOrigin = table.Column<DateTime>(nullable: false),
                    DateEndAtDestination = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportSchedules", x => x.TransportScheduleId);
                    table.ForeignKey(
                        name: "FK_TransportSchedules_Locations_DestinationNameId",
                        column: x => x.DestinationNameId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportSchedules_Locations_OriginNameId",
                        column: x => x.OriginNameId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportSchedules_TransportPricings_TransportPricingId",
                        column: x => x.TransportPricingId,
                        principalTable: "TransportPricings",
                        principalColumn: "TransportPricingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportSchedules_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(nullable: false),
                    ItinaryId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    TimeFrom = table.Column<DateTime>(nullable: false),
                    TimeTo = table.Column<DateTime>(nullable: false),
                    SchedulesId = table.Column<int>(nullable: true),
                    SchedulesPricingId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DriverId1 = table.Column<int>(nullable: true),
                    DriverId2 = table.Column<int>(nullable: false),
                    ItinaryId1 = table.Column<int>(nullable: true),
                    LocationId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Itinaries_ItinaryId",
                        column: x => x.ItinaryId,
                        principalTable: "Itinaries",
                        principalColumn: "ItinaryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_SchedulesPricings_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "SchedulesPricings",
                        principalColumn: "SchedulesPricingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActiveEnrouteCommodityMonitors",
                columns: table => new
                {
                    ActiveEnrouteCommodityMonitorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportScheduleId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveEnrouteCommodityMonitors", x => x.ActiveEnrouteCommodityMonitorId);
                    table.ForeignKey(
                        name: "FK_ActiveEnrouteCommodityMonitors_TransportSchedules_TransportScheduleId",
                        column: x => x.TransportScheduleId,
                        principalTable: "TransportSchedules",
                        principalColumn: "TransportScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveEnrouteCommodityMonitors_TransportScheduleId",
                table: "ActiveEnrouteCommodityMonitors",
                column: "TransportScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_CommodityCategoryId",
                table: "Commodities",
                column: "CommodityCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_CommodityUnitId",
                table: "Commodities",
                column: "CommodityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LocationId",
                table: "Companies",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VehicleId",
                table: "Drivers",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_AddressId",
                table: "Farmers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHubs_FoodHubStorageId",
                table: "FoodHubs",
                column: "FoodHubStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHubs_LocationId",
                table: "FoodHubs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHubStorages_CommodityUnitId",
                table: "FoodHubStorages",
                column: "CommodityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_InvoiceId",
                table: "Items",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DriverId",
                table: "Schedules",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DriverId1",
                table: "Schedules",
                column: "DriverId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ItinaryId",
                table: "Schedules",
                column: "ItinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ItinaryId1",
                table: "Schedules",
                column: "ItinaryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_LocationId",
                table: "Schedules",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_LocationId1",
                table: "Schedules",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SchedulesId",
                table: "Schedules",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_DestinationNameId",
                table: "TransportSchedules",
                column: "DestinationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_OriginNameId",
                table: "TransportSchedules",
                column: "OriginNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_TransportPricingId",
                table: "TransportSchedules",
                column: "TransportPricingId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_VehicleId",
                table: "TransportSchedules",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCategories_VehicleCapacityId",
                table: "VehicleCategories",
                column: "VehicleCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleCategoryId",
                table: "Vehicles",
                column: "VehicleCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveEnrouteCommodityMonitors");

            migrationBuilder.DropTable(
                name: "Commodities");

            migrationBuilder.DropTable(
                name: "DealsPricings");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropTable(
                name: "FoodHubs");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "TransportSchedules");

            migrationBuilder.DropTable(
                name: "CommodityCategories");

            migrationBuilder.DropTable(
                name: "FoodHubStorages");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Itinaries");

            migrationBuilder.DropTable(
                name: "SchedulesPricings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TransportPricings");

            migrationBuilder.DropTable(
                name: "CommodityUnits");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "VehicleCategories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "VehicleCapacities");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
