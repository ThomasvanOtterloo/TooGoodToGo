using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedMealAttPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Meal",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1028), new DateTime(2022, 11, 4, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1036), new DateTime(2022, 11, 4, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1042), new DateTime(2022, 11, 4, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1047), new DateTime(2022, 11, 4, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1044) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meal",
                table: "Packages");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8957), new DateTime(2022, 11, 4, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8962), new DateTime(2022, 11, 4, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 11, 4, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8972), new DateTime(2022, 11, 4, 18, 26, 31, 852, DateTimeKind.Local).AddTicks(8969) });
        }
    }
}
