using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FikretMungan.Migrations
{
    /// <inheritdoc />
    public partial class orderinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "Documents",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Documents");
        }
    }
}
