using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Expiration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Гречка", 100 },
                    { 2, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Молоко", 150 },
                    { 3, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мясо", 300 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
