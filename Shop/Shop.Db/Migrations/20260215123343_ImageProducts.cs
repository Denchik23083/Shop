using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ImageProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Name" },
                values: new object[] { "", "Мучное" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Expiration", "Image", "PurchasePrice" },
                values: new object[] { 40, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/гречка.jpg", 50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Count", "Expiration", "Image", "Name", "Price", "PurchasePrice" },
                values: new object[] { 1, 40, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/рис.jpg", "Рис", 50m, 30m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Count", "Expiration", "Image", "Name", "Price", "PurchasePrice" },
                values: new object[] { 1, 40, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/овсянка.jpg", "Овсяка", 40m, 20m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Expiration", "Image", "Name", "Price", "PurchasePrice" },
                values: new object[,]
                {
                    { 4, 2, 30, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/хлеб_белый.jpg", "Хлеб белый", 40m, 20m },
                    { 5, 2, 30, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/хлеб_черный.jpg", "Хлеб черный", 40m, 20m },
                    { 6, 2, 50, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/хлеб_черный.jpg", "Булочки", 30m, 15m },
                    { 7, 3, 30, new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/огурцы.jpg", "Огурцы", 50m, 20m },
                    { 8, 3, 30, new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/помидоры.jpg", "Помидоры", 70m, 40m },
                    { 9, 3, 50, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/картошка.jpg", "Картошка", 45m, 20m },
                    { 10, 5, 20, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/молоко.jpg", "Молоко", 150m, 70m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Зерновые");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Expiration" },
                values: new object[] { 10, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Count", "Expiration", "Name", "Price" },
                values: new object[] { 5, 20, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Молоко", 150m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Count", "Expiration", "Name", "Price" },
                values: new object[] { 6, 15, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мясо", 300m });
        }
    }
}
