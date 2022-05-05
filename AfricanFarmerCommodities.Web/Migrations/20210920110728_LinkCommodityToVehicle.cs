using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class LinkCommodityToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntermediateSchedule_TransportPricings_TransportPricingId",
                table: "IntermediateSchedule");

            migrationBuilder.DropIndex(
                name: "IX_IntermediateSchedule_TransportPricingId",
                table: "IntermediateSchedule");

            migrationBuilder.DropColumn(
                name: "TransportPricingId",
                table: "IntermediateSchedule");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEndAtDestination",
                table: "IntermediateSchedule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStartFromOrigin",
                table: "IntermediateSchedule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasReachedFinalDestination",
                table: "IntermediateSchedule",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TransportScheduleId",
                table: "IntermediateSchedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Commodities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_TransportScheduleId",
                table: "IntermediateSchedule",
                column: "TransportScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_VehicleId",
                table: "Commodities",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Vehicles_VehicleId",
                table: "Commodities",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IntermediateSchedule_TransportSchedules_TransportScheduleId",
                table: "IntermediateSchedule",
                column: "TransportScheduleId",
                principalTable: "TransportSchedules",
                principalColumn: "TransportScheduleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Vehicles_VehicleId",
                table: "Commodities");

            migrationBuilder.DropForeignKey(
                name: "FK_IntermediateSchedule_TransportSchedules_TransportScheduleId",
                table: "IntermediateSchedule");

            migrationBuilder.DropIndex(
                name: "IX_IntermediateSchedule_TransportScheduleId",
                table: "IntermediateSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_VehicleId",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "DateEndAtDestination",
                table: "IntermediateSchedule");

            migrationBuilder.DropColumn(
                name: "DateStartFromOrigin",
                table: "IntermediateSchedule");

            migrationBuilder.DropColumn(
                name: "HasReachedFinalDestination",
                table: "IntermediateSchedule");

            migrationBuilder.DropColumn(
                name: "TransportScheduleId",
                table: "IntermediateSchedule");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Commodities");

            migrationBuilder.AddColumn<int>(
                name: "TransportPricingId",
                table: "IntermediateSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_TransportPricingId",
                table: "IntermediateSchedule",
                column: "TransportPricingId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntermediateSchedule_TransportPricings_TransportPricingId",
                table: "IntermediateSchedule",
                column: "TransportPricingId",
                principalTable: "TransportPricings",
                principalColumn: "TransportPricingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
