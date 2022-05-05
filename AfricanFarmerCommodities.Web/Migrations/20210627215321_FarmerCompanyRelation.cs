using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class FarmerCompanyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Farmers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_CompanyId",
                table: "Farmers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_Companies_CompanyId",
                table: "Farmers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Companies_CompanyId",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_CompanyId",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Farmers");
        }
    }
}
