using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class introduceInvoiceTransScheToTransportLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Drivers");

            migrationBuilder.CreateIndex(
                name: "IX_TransportLogs_InvoiceId",
                table: "TransportLogs",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportLogs_Invoices_InvoiceId",
                table: "TransportLogs",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportLogs_TransportSchedules_TransportScheduleId",
                table: "TransportLogs",
                column: "TransportScheduleId",
                principalTable: "TransportSchedules",
                principalColumn: "TransportScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportLogs_Invoices_InvoiceId",
                table: "TransportLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportLogs_TransportSchedules_TransportScheduleId",
                table: "TransportLogs");

            migrationBuilder.DropIndex(
                name: "IX_TransportLogs_InvoiceId",
                table: "TransportLogs");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VehicleId",
                table: "Drivers",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
