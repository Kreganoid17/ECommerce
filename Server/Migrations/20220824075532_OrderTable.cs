using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class OrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 6"),
                    UseridID = table.Column<int>(type: "int", nullable: false),
                    Products = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prices = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_orders_Users_UseridID",
                        column: x => x.UseridID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_UseridID",
                table: "orders",
                column: "UseridID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
