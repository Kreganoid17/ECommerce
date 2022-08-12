using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class username : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");



            migrationBuilder.UpdateData(
                 table: "Users",
                 keyColumn: "ID",
                 keyValue: 1,
                 column: "Username",
                 value: "Kreganoid17");
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");
        }
    }
}
