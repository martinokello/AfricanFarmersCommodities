using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class RenameColumnsScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportSchedules_Locations_DestinationNameId",
                table: "TransportSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportSchedules_Locations_OriginNameId",
                table: "TransportSchedules");

            migrationBuilder.DropIndex(
                name: "IX_TransportSchedules_DestinationNameId",
                table: "TransportSchedules");

            migrationBuilder.DropIndex(
                name: "IX_TransportSchedules_OriginNameId",
                table: "TransportSchedules");

            migrationBuilder.DropColumn(
                name: "DestinationNameId",
                table: "TransportSchedules");

            migrationBuilder.DropColumn(
                name: "OriginNameId",
                table: "TransportSchedules");

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationId",
                table: "TransportSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginLocationId",
                table: "TransportSchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_DestinationLocationId",
                table: "TransportSchedules",
                column: "DestinationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_OriginLocationId",
                table: "TransportSchedules",
                column: "OriginLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportSchedules_Locations_DestinationLocationId",
                table: "TransportSchedules",
                column: "DestinationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportSchedules_Locations_OriginLocationId",
                table: "TransportSchedules",
                column: "OriginLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportSchedules_Locations_DestinationLocationId",
                table: "TransportSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportSchedules_Locations_OriginLocationId",
                table: "TransportSchedules");

            migrationBuilder.DropIndex(
                name: "IX_TransportSchedules_DestinationLocationId",
                table: "TransportSchedules");

            migrationBuilder.DropIndex(
                name: "IX_TransportSchedules_OriginLocationId",
                table: "TransportSchedules");

            migrationBuilder.DropColumn(
                name: "DestinationLocationId",
                table: "TransportSchedules");

            migrationBuilder.DropColumn(
                name: "OriginLocationId",
                table: "TransportSchedules");

            migrationBuilder.AddColumn<int>(
                name: "DestinationNameId",
                table: "TransportSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginNameId",
                table: "TransportSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_DestinationNameId",
                table: "TransportSchedules",
                column: "DestinationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_OriginNameId",
                table: "TransportSchedules",
                column: "OriginNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportSchedules_Locations_DestinationNameId",
                table: "TransportSchedules",
                column: "DestinationNameId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportSchedules_Locations_OriginNameId",
                table: "TransportSchedules",
                column: "OriginNameId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
