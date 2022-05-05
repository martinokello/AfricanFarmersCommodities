using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class AddIntemediateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Itinaries");

            migrationBuilder.DropTable(
                name: "SchedulesPricings");

            migrationBuilder.CreateTable(
                name: "IntermediateSchedule",
                columns: table => new
                {
                    IntermediateScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    OriginLocationId = table.Column<int>(nullable: false),
                    DestinationLocationId = table.Column<int>(nullable: false),
                    TransportPricingId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DriverId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    VehicleId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateSchedule", x => x.IntermediateScheduleId);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_Locations_DestinationLocationId",
                        column: x => x.DestinationLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_Locations_OriginLocationId",
                        column: x => x.OriginLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_TransportPricings_TransportPricingId",
                        column: x => x.TransportPricingId,
                        principalTable: "TransportPricings",
                        principalColumn: "TransportPricingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateSchedule_Vehicles_VehicleId1",
                        column: x => x.VehicleId1,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_DestinationLocationId",
                table: "IntermediateSchedule",
                column: "DestinationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_DriverId",
                table: "IntermediateSchedule",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_LocationId",
                table: "IntermediateSchedule",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_OriginLocationId",
                table: "IntermediateSchedule",
                column: "OriginLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_TransportPricingId",
                table: "IntermediateSchedule",
                column: "TransportPricingId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_VehicleId",
                table: "IntermediateSchedule",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_VehicleId1",
                table: "IntermediateSchedule",
                column: "VehicleId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntermediateSchedule");

            migrationBuilder.CreateTable(
                name: "Itinaries",
                columns: table => new
                {
                    ItinaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinaries", x => x.ItinaryId);
                });

            migrationBuilder.CreateTable(
                name: "SchedulesPricings",
                columns: table => new
                {
                    SchedulesPricingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchedulesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchedulesPricingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesPricings", x => x.SchedulesPricingId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DriverId1 = table.Column<int>(type: "int", nullable: true),
                    DriverId2 = table.Column<int>(type: "int", nullable: false),
                    ItinaryId = table.Column<int>(type: "int", nullable: false),
                    ItinaryId1 = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationId1 = table.Column<int>(type: "int", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchedulesId = table.Column<int>(type: "int", nullable: true),
                    SchedulesPricingId = table.Column<int>(type: "int", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Drivers_DriverId1",
                        column: x => x.DriverId1,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Itinaries_ItinaryId",
                        column: x => x.ItinaryId,
                        principalTable: "Itinaries",
                        principalColumn: "ItinaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Itinaries_ItinaryId1",
                        column: x => x.ItinaryId1,
                        principalTable: "Itinaries",
                        principalColumn: "ItinaryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Locations_LocationId1",
                        column: x => x.LocationId1,
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
        }
    }
}
