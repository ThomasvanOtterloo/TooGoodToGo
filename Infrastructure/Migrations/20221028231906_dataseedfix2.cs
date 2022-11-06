using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class dataseedfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1665), new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1670), new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1675), new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1673) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bread");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Soup");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Beer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3536), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3545), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3549), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3554), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3552) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "brood");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "soep");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Product 4");
        }
    }
}
