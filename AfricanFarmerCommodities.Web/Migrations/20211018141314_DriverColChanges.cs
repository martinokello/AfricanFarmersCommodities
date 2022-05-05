using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class DriverColChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntermediateSchedule_Drivers_DriverId",
                table: "IntermediateSchedule");

            migrationBuilder.DropIndex(
                name: "IX_IntermediateSchedule_DriverId",
                table: "IntermediateSchedule");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "IntermediateSchedule");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Drivers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_ScheduleId",
                table: "Drivers",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_TransportSchedules_ScheduleId",
                table: "Drivers",
                column: "ScheduleId",
                principalTable: "TransportSchedules",
                principalColumn: "TransportScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_TransportSchedules_ScheduleId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_ScheduleId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "IntermediateSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateSchedule_DriverId",
                table: "IntermediateSchedule",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntermediateSchedule_Drivers_DriverId",
                table: "IntermediateSchedule",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
