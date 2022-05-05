using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfricanFarmerCommodities.Web.Migrations
{
    public partial class addDriverNotesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverSchedulesNotes",
                columns: table => new
                {
                    DriveScheduleNoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverNotes = table.Column<string>(nullable: true),
                    TransportScheduleId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    IsOriginNote = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverSchedulesNotes", x => x.DriveScheduleNoteId);
                    table.ForeignKey(
                        name: "FK_DriverSchedulesNotes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverSchedulesNotes_TransportSchedules_TransportScheduleId",
                        column: x => x.TransportScheduleId,
                        principalTable: "TransportSchedules",
                        principalColumn: "TransportScheduleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverSchedulesNotes_DriverId",
                table: "DriverSchedulesNotes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverSchedulesNotes_TransportScheduleId",
                table: "DriverSchedulesNotes",
                column: "TransportScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverSchedulesNotes");
        }
    }
}
