using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class AddingMoreVehiclesToTransportPricing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TransportPricings");

            migrationBuilder.AddColumn<decimal>(
                name: "BusPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CarPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MiniBusPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PickupTruckPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxiPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TruckPricing",
                table: "TransportPricings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusPricing",
                table: "TransportPricings");

            migrationBuilder.DropColumn(
                name: "CarPricing",
                table: "TransportPricings");

            migrationBuilder.DropColumn(
                name: "MiniBusPricing",
                table: "TransportPricings");

            migrationBuilder.DropColumn(
                name: "PickupTruckPricing",
                table: "TransportPricings");

            migrationBuilder.DropColumn(
                name: "TaxiPricing",
                table: "TransportPricings");

            migrationBuilder.DropColumn(
                name: "TruckPricing",
                table: "TransportPricings");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "TransportPricings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
