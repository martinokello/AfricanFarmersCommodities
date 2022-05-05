using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class AddUsedStorageCapacityColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UsedDryStorageCapacity",
                table: "FoodHubStorages",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UsedRefreigeratedStorageCapacity",
                table: "FoodHubStorages",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedDryStorageCapacity",
                table: "FoodHubStorages");

            migrationBuilder.DropColumn(
                name: "UsedRefreigeratedStorageCapacity",
                table: "FoodHubStorages");
        }
    }
}
