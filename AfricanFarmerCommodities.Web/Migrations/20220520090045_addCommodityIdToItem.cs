using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class addCommodityIdToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommodityId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CommodityId",
                table: "Items",
                column: "CommodityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Commodities_CommodityId",
                table: "Items",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "CommodityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Commodities_CommodityId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CommodityId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CommodityId",
                table: "Items");
        }
    }
}
