using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitAddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6137), 1, new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6143), 1, new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6148), 3, new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6153), 3, new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6151) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ContainsAlcohol", "Image", "Name" },
                values: new object[,]
                {
                    { 1, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 1" },
                    { 2, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 2" },
                    { 3, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 3" },
                    { 4, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 4" },
                    { 5, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 5" },
                    { 6, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 6" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6696), 0, new DateTime(2022, 10, 20, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6655) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6703), 0, new DateTime(2022, 10, 20, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6707), 0, new DateTime(2022, 10, 20, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "City", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6712), 0, new DateTime(2022, 10, 20, 12, 51, 14, 646, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: 0);
        }
    }
}
