using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class deleteFKCommodityVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Vehicles_VehicleId",
                table: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_VehicleId",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Commodities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Commodities",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
