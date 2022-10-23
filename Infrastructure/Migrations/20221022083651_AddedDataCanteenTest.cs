using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedDataCanteenTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Id", "City", "Name", "OfferHotMeals" },
                values: new object[,]
                {
                    { 1, 3, "LA", true },
                    { 2, 1, "LD 2", false }
                });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(640), new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(647), new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(651), new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(655), new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(653) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(205), new DateTime(2022, 10, 22, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(167) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(212), new DateTime(2022, 10, 22, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(209) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(216), new DateTime(2022, 10, 22, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(214) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(222), new DateTime(2022, 10, 22, 10, 24, 23, 780, DateTimeKind.Local).AddTicks(220) });
        }
    }
}
