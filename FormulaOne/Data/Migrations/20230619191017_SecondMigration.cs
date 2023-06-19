using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Results_ResultId1",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_ResultId1",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ResultId1",
                table: "Results");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultId1",
                table: "Results",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_ResultId1",
                table: "Results",
                column: "ResultId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Results_ResultId1",
                table: "Results",
                column: "ResultId1",
                principalTable: "Results",
                principalColumn: "ResultId");
        }
    }
}
