using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.Data.Migrations
{
    /// <inheritdoc />
    public partial class PitStopIdPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PitStops",
                table: "PitStops");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PitStops",
                newName: "PitstopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PitStops",
                table: "PitStops",
                column: "PitstopId");

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_RaceId",
                table: "PitStops",
                column: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PitStops",
                table: "PitStops");

            migrationBuilder.DropIndex(
                name: "IX_PitStops_RaceId",
                table: "PitStops");

            migrationBuilder.RenameColumn(
                name: "PitstopId",
                table: "PitStops",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PitStops",
                table: "PitStops",
                columns: new[] { "RaceId", "DriverId", "Stop" });
        }
    }
}
