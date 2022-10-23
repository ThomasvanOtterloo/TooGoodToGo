using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ReservedPackage",
                columns: new[] { "PackageId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservedPackage",
                keyColumns: new[] { "PackageId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ReservedPackage",
                keyColumns: new[] { "PackageId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(689), new DateTime(2022, 10, 22, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(696), new DateTime(2022, 10, 22, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(694) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(701), new DateTime(2022, 10, 22, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(699) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(705), new DateTime(2022, 10, 22, 10, 21, 36, 897, DateTimeKind.Local).AddTicks(703) });
        }
    }
}
