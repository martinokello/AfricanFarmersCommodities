using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class removecapacityToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCategories_VehicleCapacities_VehicleCapacityId",
                table: "VehicleCategories");

            migrationBuilder.DropIndex(
                name: "IX_VehicleCategories_VehicleCapacityId",
                table: "VehicleCategories");

            migrationBuilder.DropColumn(
                name: "VehicleCapacityId",
                table: "VehicleCategories");

            migrationBuilder.AddColumn<int>(
                name: "VehicleCapacityId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleCapacityId",
                table: "Vehicles",
                column: "VehicleCapacityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleCapacities_VehicleCapacityId",
                table: "Vehicles",
                column: "VehicleCapacityId",
                principalTable: "VehicleCapacities",
                principalColumn: "VehicleCapacityId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleCapacities_VehicleCapacityId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleCapacityId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleCapacityId",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "VehicleCapacityId",
                table: "VehicleCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCategories_VehicleCapacityId",
                table: "VehicleCategories",
                column: "VehicleCapacityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCategories_VehicleCapacities_VehicleCapacityId",
                table: "VehicleCategories",
                column: "VehicleCapacityId",
                principalTable: "VehicleCapacities",
                principalColumn: "VehicleCapacityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
