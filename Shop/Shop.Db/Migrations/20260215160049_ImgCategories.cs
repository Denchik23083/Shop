using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ImgCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "img/categories/крупы.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "img/categories/мучное.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "img/categories/овощи.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "img/categories/фрукты.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "img/categories/молочные_продукты.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "img/categories/белковые_продукты.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Image", "Name" },
                values: new object[] { "img/categories/алкоголь.jpg", "Алкоголь" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "img/products/гречка.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "img/products/рис.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "img/products/овсянка.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "img/products/хлеб_белый.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "img/products/хлеб_черный.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "img/products/булочки.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "img/products/огурцы.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "img/products/помидоры.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "img/products/картошка.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Count", "Expiration", "Image", "Name", "Price", "PurchasePrice" },
                values: new object[] { 3, 50, new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/лук.jpg", "Лук", 25m, 10m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Expiration", "Image", "Name", "Price", "PurchasePrice" },
                values: new object[,]
                {
                    { 11, 4, 40, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/яблоки.jpg", "Яблоки", 30m, 20m },
                    { 12, 4, 40, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/бананы.jpg", "Бананы", 45m, 25m },
                    { 13, 4, 40, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/бананы.jpg", "Бананы", 45m, 25m },
                    { 14, 4, 50, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/мандарины.jpg", "Мандарины", 70m, 45m },
                    { 15, 4, 50, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/виноград.jpg", "Виноград", 70m, 45m },
                    { 16, 5, 20, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/молоко.jpg", "Молоко", 150m, 70m },
                    { 17, 5, 20, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/творог.jpg", "Творог", 120m, 60m },
                    { 18, 5, 20, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/сметана.jpg", "Сметана", 100m, 50m },
                    { 19, 5, 30, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/сыр.jpg", "Сыр", 150m, 75m },
                    { 20, 6, 15, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/курица.jpg", "Курица", 250m, 150m },
                    { 21, 6, 15, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/свинина.jpg", "Свинина", 300m, 200m },
                    { 22, 6, 15, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/рыба.jpg", "Рыба", 300m, 200m },
                    { 23, 6, 200, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/яйца.jpg", "Яйца", 100m, 50m },
                    { 24, 6, 20, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/вино.jpg", "Вино", 1000m, 500m },
                    { 25, 6, 20, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/шампанское.jpg", "Шампанское", 800m, 400m },
                    { 26, 6, 20, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/products/коньяк.jpg", "Коньяк", 1500m, 700m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

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
                column: "Image",
                value: "");

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
                columns: new[] { "Image", "Name" },
                values: new object[] { "", "Другое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "img/гречка.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "img/рис.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "img/овсянка.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "img/хлеб_белый.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "img/хлеб_черный.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "img/хлеб_черный.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "img/огурцы.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "img/помидоры.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "img/картошка.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Count", "Expiration", "Image", "Name", "Price", "PurchasePrice" },
                values: new object[] { 5, 20, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "img/молоко.jpg", "Молоко", 150m, 70m });
        }
    }
}
