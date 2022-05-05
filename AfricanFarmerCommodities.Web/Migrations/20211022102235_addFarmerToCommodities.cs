using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class addFarmerToCommodities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Commodities_FarmerId",
                table: "Commodities",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Farmers_FarmerId",
                table: "Commodities",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Farmers_FarmerId",
                table: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_FarmerId",
                table: "Commodities");
        }
    }
}
