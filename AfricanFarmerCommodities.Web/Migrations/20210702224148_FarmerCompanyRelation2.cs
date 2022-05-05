using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class FarmerCompanyRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmerCompanyName",
                table: "Farmers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Commodities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_CompanyId",
                table: "Commodities",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Companies_CompanyId",
                table: "Commodities",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Companies_CompanyId",
                table: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Commodities_CompanyId",
                table: "Commodities");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Commodities");

            migrationBuilder.AddColumn<string>(
                name: "FarmerCompanyName",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
