using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class updateForCommodityCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Commodities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Commodities");
        }
    }
}
