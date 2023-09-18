using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Migrations
{
    /// <inheritdoc />
    public partial class AddPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Car",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                column: "price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2,
                column: "price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3,
                column: "price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4,
                column: "price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5,
                column: "price",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6,
                column: "price",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7,
                column: "price",
                value: 15m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Car");
        }
    }
}
