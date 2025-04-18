using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class udpCntx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Days_DayId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Days_DayId",
                table: "Events",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Days_DayId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Days_DayId",
                table: "Events",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");
        }
    }
}
