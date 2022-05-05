using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class refresdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "TransportScheduleId",
                table: "Drivers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TransportScheduleId",
                table: "Drivers",
                column: "TransportScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_TransportSchedules_TransportScheduleId",
                table: "Drivers",
                column: "TransportScheduleId",
                principalTable: "TransportSchedules",
                principalColumn: "TransportScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_TransportSchedules_TransportScheduleId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_TransportScheduleId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "TransportScheduleId",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Drivers",
                type: "int",
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
    }
}
