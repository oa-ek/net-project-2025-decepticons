using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class updDBEventName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entertainments",
                table: "Entertainments");

            migrationBuilder.RenameTable(
                name: "Entertainments",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Entertainments_LocationId",
                table: "Events",
                newName: "IX_Events_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Entertainments_DayId",
                table: "Events",
                newName: "IX_Events_DayId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Members",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Days_DayId",
                table: "Events",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourEntertainments_Events_EventId",
                table: "TourEntertainments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Days_DayId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_TourEntertainments_Events_EventId",
                table: "TourEntertainments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Members",
                table: "Tours");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Entertainments");

            migrationBuilder.RenameIndex(
                name: "IX_Events_LocationId",
                table: "Entertainments",
                newName: "IX_Entertainments_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_DayId",
                table: "Entertainments",
                newName: "IX_Entertainments_DayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entertainments",
                table: "Entertainments",
                column: "Id");

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
    }
}
