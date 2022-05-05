using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class resolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AirPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ShipPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirPricing",
                table: "TransportPricings");

            migrationBuilder.DropColumn(
                name: "ShipPricing",
                table: "TransportPricings");
        }
    }
}
