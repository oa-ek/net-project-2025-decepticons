using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class upd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TourPrograms_TourId",
                table: "TourPrograms");

            migrationBuilder.CreateIndex(
                name: "IX_TourPrograms_TourId",
                table: "TourPrograms",
                column: "TourId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TourPrograms_TourId",
                table: "TourPrograms");

            migrationBuilder.CreateIndex(
                name: "IX_TourPrograms_TourId",
                table: "TourPrograms",
                column: "TourId");
        }
    }
}
