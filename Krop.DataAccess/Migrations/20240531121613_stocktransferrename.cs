using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class stocktransferrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransfers_AspNetUsers_SenderAppUserId",
                table: "StockTransfers");

            migrationBuilder.RenameColumn(
                name: "SenderAppUserId",
                table: "StockTransfers",
                newName: "TransactorAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransfers_SenderAppUserId",
                table: "StockTransfers",
                newName: "IX_StockTransfers_TransactorAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransfers_AspNetUsers_TransactorAppUserId",
                table: "StockTransfers",
                column: "TransactorAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransfers_AspNetUsers_TransactorAppUserId",
                table: "StockTransfers");

            migrationBuilder.RenameColumn(
                name: "TransactorAppUserId",
                table: "StockTransfers",
                newName: "SenderAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransfers_TransactorAppUserId",
                table: "StockTransfers",
                newName: "IX_StockTransfers_SenderAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransfers_AspNetUsers_SenderAppUserId",
                table: "StockTransfers",
                column: "SenderAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
