using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class testingSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9588), new DateTime(2022, 10, 22, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9594), new DateTime(2022, 10, 22, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9599), new DateTime(2022, 10, 22, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9604), new DateTime(2022, 10, 22, 11, 2, 19, 937, DateTimeKind.Local).AddTicks(9602) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6912), new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6920), new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6926), new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 25, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6938), new DateTime(2022, 10, 22, 10, 38, 37, 230, DateTimeKind.Local).AddTicks(6936) });
        }
    }
}
