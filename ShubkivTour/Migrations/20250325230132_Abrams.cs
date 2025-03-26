using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class Abrams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourEntertainments_Events_EventId",
                table: "TourEntertainments");

            migrationBuilder.DropForeignKey(
                name: "FK_TourEntertainments_Tours_TourId",
                table: "TourEntertainments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourEntertainments",
                table: "TourEntertainments");

            migrationBuilder.RenameTable(
                name: "TourEntertainments",
                newName: "TourEvents");

            migrationBuilder.RenameIndex(
                name: "IX_TourEntertainments_TourId",
                table: "TourEvents",
                newName: "IX_TourEvents_TourId");

            migrationBuilder.RenameIndex(
                name: "IX_TourEntertainments_EventId",
                table: "TourEvents",
                newName: "IX_TourEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourEvents",
                table: "TourEvents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClientId",
                table: "Review",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_TourId",
                table: "Review",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourEvents_Events_EventId",
                table: "TourEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourEvents_Tours_TourId",
                table: "TourEvents",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourEvents_Events_EventId",
                table: "TourEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TourEvents_Tours_TourId",
                table: "TourEvents");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourEvents",
                table: "TourEvents");

            migrationBuilder.RenameTable(
                name: "TourEvents",
                newName: "TourEntertainments");

            migrationBuilder.RenameIndex(
                name: "IX_TourEvents_TourId",
                table: "TourEntertainments",
                newName: "IX_TourEntertainments_TourId");

            migrationBuilder.RenameIndex(
                name: "IX_TourEvents_EventId",
                table: "TourEntertainments",
                newName: "IX_TourEntertainments_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourEntertainments",
                table: "TourEntertainments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourEntertainments_Events_EventId",
                table: "TourEntertainments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourEntertainments_Tours_TourId",
                table: "TourEntertainments",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
