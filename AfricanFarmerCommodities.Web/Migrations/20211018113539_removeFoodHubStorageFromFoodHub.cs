using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class removeFoodHubStorageFromFoodHub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodHubs_FoodHubStorages_FoodHubStorageId",
                table: "FoodHubs");

            migrationBuilder.DropIndex(
                name: "IX_FoodHubs_FoodHubStorageId",
                table: "FoodHubs");

            migrationBuilder.DropColumn(
                name: "FoodHubStorageId",
                table: "FoodHubs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodHubStorageId",
                table: "FoodHubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodHubs_FoodHubStorageId",
                table: "FoodHubs",
                column: "FoodHubStorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodHubs_FoodHubStorages_FoodHubStorageId",
                table: "FoodHubs",
                column: "FoodHubStorageId",
                principalTable: "FoodHubStorages",
                principalColumn: "FoodHubStorageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
