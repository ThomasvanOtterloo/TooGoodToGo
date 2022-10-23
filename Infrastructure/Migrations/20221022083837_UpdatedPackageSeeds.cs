using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedPackageSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6912), 1, new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6920), 1, new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6926), new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6923), 2 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6938), new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6936), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(640), null, new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(647), null, new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(651), new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(649), null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(655), new DateTime(2022, 10, 22, 10, 36, 51, 312, DateTimeKind.Local).AddTicks(653), null });
        }
    }
}
