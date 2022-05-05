using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class addfoodHubtoHubStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodHubId",
                table: "FoodHubStorages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodHubStorages_FoodHubId",
                table: "FoodHubStorages",
                column: "FoodHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodHubStorages_FoodHubs_FoodHubId",
                table: "FoodHubStorages",
                column: "FoodHubId",
                principalTable: "FoodHubs",
                principalColumn: "FoodHubId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodHubStorages_FoodHubs_FoodHubId",
                table: "FoodHubStorages");

            migrationBuilder.DropIndex(
                name: "IX_FoodHubStorages_FoodHubId",
                table: "FoodHubStorages");

            migrationBuilder.DropColumn(
                name: "FoodHubId",
                table: "FoodHubStorages");
        }
    }
}
