using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserAppUserRole",
                columns: table => new
                {
                    AppUserRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAppUserRole", x => new { x.AppUserRolesId, x.AppUsersId });
                    table.ForeignKey(
                        name: "FK_AppUserAppUserRole_AspNetRoles_AppUserRolesId",
                        column: x => x.AppUserRolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAppUserRole_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppUserRole_AppUsersId",
                table: "AppUserAppUserRole",
                column: "AppUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAppUserRole");
        }
    }
}
