using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Migrations
{
    /// <inheritdoc />
    public partial class View3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "None", "Cedan" },
                    { 2, "None", "Coupe" },
                    { 3, "None", "SVC" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CategoryId", "Color", "Manufacturer", "Year" },
                values: new object[,]
                {
                    { 1, 1, "red", "Volvo", 2006 },
                    { 2, 2, "red", "BMW", 2006 },
                    { 3, 1, "red", "Nissan", 2006 },
                    { 4, 3, "red", "MAZ", 2006 },
                    { 5, 2, "Blue", "Toyota", 2020 },
                    { 6, 3, "Red", "Ford", 2019 },
                    { 7, 2, "Silver", "Honda", 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
