using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShubkivTour.Migrations
{
    /// <inheritdoc />
    public partial class upd1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_TourPrograms_TourProgramId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Tours_TourId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "TourProgramId",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_TourPrograms_TourProgramId",
                table: "Days",
                column: "TourProgramId",
                principalTable: "TourPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Tours_TourId",
                table: "Days",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_TourPrograms_TourProgramId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Tours_TourId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "TourProgramId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_TourPrograms_TourProgramId",
                table: "Days",
                column: "TourProgramId",
                principalTable: "TourPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Tours_TourId",
                table: "Days",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");
        }
    }
}
