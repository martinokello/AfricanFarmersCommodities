using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class includeTransportLogEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TransportLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "TransportLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TransportLogs_TransportScheduleId_InvoiceId",
                table: "TransportLogs",
                columns: new[] { "TransportScheduleId", "InvoiceId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransportLogs_TransportScheduleId_InvoiceId",
                table: "TransportLogs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TransportLogs");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "TransportLogs");
        }
    }
}
