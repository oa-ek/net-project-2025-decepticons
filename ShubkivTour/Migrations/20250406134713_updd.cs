using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class updd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventImages_Events_EventID",
                table: "EventImages");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "EventImages",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventImages_EventID",
                table: "EventImages",
                newName: "IX_EventImages_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventImages_Events_EventId",
                table: "EventImages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventImages_Events_EventId",
                table: "EventImages");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventImages",
                newName: "EventID");

            migrationBuilder.RenameIndex(
                name: "IX_EventImages_EventId",
                table: "EventImages",
                newName: "IX_EventImages_EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventImages_Events_EventID",
                table: "EventImages",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
