using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.Data.Migrations
{
    /// <inheritdoc />
    public partial class LapTimePrimaryKeyMappingInAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LapTimes",
                table: "LapTimes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LapTimes",
                newName: "LapTimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LapTimes",
                table: "LapTimes",
                column: "LapTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_LapTimes_RaceId",
                table: "LapTimes",
                column: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LapTimes",
                table: "LapTimes");

            migrationBuilder.DropIndex(
                name: "IX_LapTimes_RaceId",
                table: "LapTimes");

            migrationBuilder.RenameColumn(
                name: "LapTimeId",
                table: "LapTimes",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LapTimes",
                table: "LapTimes",
                columns: new[] { "RaceId", "DriverId", "Lap" });
        }
    }
}
