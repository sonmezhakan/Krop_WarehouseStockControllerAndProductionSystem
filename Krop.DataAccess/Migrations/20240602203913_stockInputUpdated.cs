using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class stockInputUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockInputs_ProductionId",
                table: "StockInputs");

            migrationBuilder.CreateIndex(
                name: "IX_StockInputs_ProductionId",
                table: "StockInputs",
                column: "ProductionId",
                unique: true,
                filter: "[ProductionId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockInputs_ProductionId",
                table: "StockInputs");

            migrationBuilder.CreateIndex(
                name: "IX_StockInputs_ProductionId",
                table: "StockInputs",
                column: "ProductionId");
        }
    }
}
