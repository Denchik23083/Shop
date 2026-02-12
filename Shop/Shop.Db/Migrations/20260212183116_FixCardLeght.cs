using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Db.Migrations
{
    /// <inheritdoc />
    public partial class FixCardLeght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_CardNumber_Length",
                table: "Cards",
                sql: "LEN(CardNumber) = 16");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Cvv_Length",
                table: "Cards",
                sql: "LEN(Cvv) = 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CardNumber_Length",
                table: "Cards");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Cvv_Length",
                table: "Cards");
        }
    }
}
