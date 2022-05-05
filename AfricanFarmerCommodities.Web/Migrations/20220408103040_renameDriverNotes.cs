using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class renameDriverNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverNotes",
                table: "DriverSchedulesNotes");

            migrationBuilder.AddColumn<string>(
                name: "DriverNote",
                table: "DriverSchedulesNotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverNote",
                table: "DriverSchedulesNotes");

            migrationBuilder.AddColumn<string>(
                name: "DriverNotes",
                table: "DriverSchedulesNotes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
