using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class renameColInFoodHub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decription",
                table: "FoodHubs");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FoodHubs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FoodHubs");

            migrationBuilder.AddColumn<string>(
                name: "Decription",
                table: "FoodHubs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
