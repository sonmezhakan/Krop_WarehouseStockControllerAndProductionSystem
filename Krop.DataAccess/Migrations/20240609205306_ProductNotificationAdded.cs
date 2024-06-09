using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductNotificationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderEmployeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentEmployeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SenderNotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataStatu = table.Column<int>(type: "int", nullable: false),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductNotifications_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductNotifications_Employees_SenderEmployeId",
                        column: x => x.SenderEmployeId,
                        principalTable: "Employees",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductNotifications_Employees_SentEmployeId",
                        column: x => x.SentEmployeId,
                        principalTable: "Employees",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductNotifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotifications_BranchId",
                table: "ProductNotifications",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotifications_ProductId",
                table: "ProductNotifications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotifications_SenderEmployeId",
                table: "ProductNotifications",
                column: "SenderEmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotifications_SentEmployeId",
                table: "ProductNotifications",
                column: "SentEmployeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNotifications");
        }
    }
}
