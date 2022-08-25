using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class cartquntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartQauntity",
                table: "cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartQauntity",
                table: "cart");
        }
    }
}
