using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Migrations
{
    /// <inheritdoc />
    public partial class reworkservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { "Blue", "Compact sedan", "car1.jpg", "Toyota", 25000m, 2022 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 1, "Red", "Family sedan", "car2.jpg", "Honda", 22000m, 2021 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 2, "Black", "Sporty coupe", "car3.jpg", "Ford", 30000m, 2023 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 2, "Silver", "Coupe with advanced features", "car4.jpg", "Chevrolet", 28000m, 2022 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 3, "White", "Electric SUV", "car5.jpg", "Tesla", 62000m, 2023 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { "Gray", "Luxury SUV", "car6.jpg", "BMW", 45000m, 2021 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { "Blue", "Audi coupe", "car7.jpg", "Audi", 35000m, 2020 });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[,]
                {
                    { 8, 1, "Black", "Elegant sedan", "car8.jpg", "Mercedes-Benz", 50000m, 2023 },
                    { 9, 3, "Silver", "Luxury SUV with hybrid technology", "car9.jpg", "Lexus", 48000m, 2022 },
                    { 10, 1, "Red", "Affordable compact sedan", "car10.jpg", "Hyundai", 23000m, 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { "red", null, null, "Volvo", 10m, 2006 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 2, "red", null, null, "BMW", 10m, 2006 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 1, "red", null, null, "Nissan", 10m, 2006 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 3, "red", null, null, "MAZ", 10m, 2006 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { 2, "Blue", null, null, "Toyota", 15m, 2020 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { "Red", null, null, "Ford", 15m, 2019 });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Description", "ImagePath", "Manufacturer", "Price", "Year" },
                values: new object[] { "Silver", null, null, "Honda", 15m, 2022 });
        }
    }
}
