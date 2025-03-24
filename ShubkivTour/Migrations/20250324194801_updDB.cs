using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class updDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourEntertainments_Entertainments_EntertainmentId",
                table: "TourEntertainments");

            migrationBuilder.DropTable(
                name: "TourLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourEntertainments",
                table: "TourEntertainments");

            migrationBuilder.RenameColumn(
                name: "EntertainmentId",
                table: "TourEntertainments",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_TourEntertainments_EntertainmentId",
                table: "TourEntertainments",
                newName: "IX_TourEntertainments_EventId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Locations",
                newName: "Adress");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TourEntertainments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longtitude",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Entertainments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Entertainments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Entertainments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourEntertainments",
                table: "TourEntertainments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourEntertainments_TourId",
                table: "TourEntertainments",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Entertainments_DayId",
                table: "Entertainments",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Entertainments_LocationId",
                table: "Entertainments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_TourId",
                table: "Days",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entertainments_Days_DayId",
                table: "Entertainments",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entertainments_Locations_LocationId",
                table: "Entertainments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourEntertainments_Entertainments_EventId",
                table: "TourEntertainments",
                column: "EventId",
                principalTable: "Entertainments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entertainments_Days_DayId",
                table: "Entertainments");

            migrationBuilder.DropForeignKey(
                name: "FK_Entertainments_Locations_LocationId",
                table: "Entertainments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourEntertainments_Entertainments_EventId",
                table: "TourEntertainments");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourEntertainments",
                table: "TourEntertainments");

            migrationBuilder.DropIndex(
                name: "IX_TourEntertainments_TourId",
                table: "TourEntertainments");

            migrationBuilder.DropIndex(
                name: "IX_Entertainments_DayId",
                table: "Entertainments");

            migrationBuilder.DropIndex(
                name: "IX_Entertainments_LocationId",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TourEntertainments");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Entertainments");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "TourEntertainments",
                newName: "EntertainmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TourEntertainments_EventId",
                table: "TourEntertainments",
                newName: "IX_TourEntertainments_EntertainmentId");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Locations",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourEntertainments",
                table: "TourEntertainments",
                columns: new[] { "TourId", "EntertainmentId" });

            migrationBuilder.CreateTable(
                name: "TourLocations",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourLocations", x => new { x.TourId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_TourLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourLocations_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourLocations_LocationId",
                table: "TourLocations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourEntertainments_Entertainments_EntertainmentId",
                table: "TourEntertainments",
                column: "EntertainmentId",
                principalTable: "Entertainments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
