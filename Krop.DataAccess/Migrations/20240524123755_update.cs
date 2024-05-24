using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Suppliers",
                newName: "Addres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "Suppliers",
                newName: "Address");
        }
    }
}
