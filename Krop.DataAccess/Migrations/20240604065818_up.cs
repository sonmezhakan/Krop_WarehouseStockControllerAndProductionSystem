using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionStockExits_AspNetUsers_AppUserId",
                table: "ProductionStockExits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionStockExits_Branches_BranchId",
                table: "ProductionStockExits");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "ProductionStockExits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "ProductionStockExits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionStockExits_AspNetUsers_AppUserId",
                table: "ProductionStockExits",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionStockExits_Branches_BranchId",
                table: "ProductionStockExits",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionStockExits_AspNetUsers_AppUserId",
                table: "ProductionStockExits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionStockExits_Branches_BranchId",
                table: "ProductionStockExits");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "ProductionStockExits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "ProductionStockExits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionStockExits_AspNetUsers_AppUserId",
                table: "ProductionStockExits",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionStockExits_Branches_BranchId",
                table: "ProductionStockExits",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
