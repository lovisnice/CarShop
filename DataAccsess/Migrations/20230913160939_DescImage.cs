using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Migrations
{
    /// <inheritdoc />
    public partial class DescImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Car");
        }
    }
}
