using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Db.Migrations
{
    /// <inheritdoc />
    public partial class BalanceOrderCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "Balances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCount",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Balances");
        }
    }
}
