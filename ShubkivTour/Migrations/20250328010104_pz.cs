using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class pz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Tours_TourId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPrograms_Tours_TourId",
                table: "TourPrograms");

            migrationBuilder.DropIndex(
                name: "IX_TourPrograms_TourId",
                table: "TourPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Days_TourId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "TourPrograms");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "TourProgramId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayNumber",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TourProgramId",
                table: "Tours",
                column: "TourProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourPrograms_TourProgramId",
                table: "Tours",
                column: "TourProgramId",
                principalTable: "TourPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourPrograms_TourProgramId",
                table: "Tours");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropIndex(
                name: "IX_Tours_TourProgramId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourProgramId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "DayNumber",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "TourPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Days",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourPrograms_TourId",
                table: "TourPrograms",
                column: "TourId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Days_TourId",
                table: "Days",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Tours_TourId",
                table: "Days",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPrograms_Tours_TourId",
                table: "TourPrograms",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
