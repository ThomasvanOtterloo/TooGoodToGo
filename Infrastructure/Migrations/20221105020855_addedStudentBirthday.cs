using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addedStudentBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedAt",
                table: "ReservedPackage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3068), new DateTime(2022, 11, 6, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3028) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3074), new DateTime(2022, 11, 6, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3072) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3079), 1, new DateTime(2022, 11, 6, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3084), 1, new DateTime(2022, 11, 6, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3082) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedAt",
                table: "ReservedPackage");

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
                columns: new[] { "AvailableUntil", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1042), 0, new DateTime(2022, 11, 4, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1047), 0, new DateTime(2022, 11, 4, 20, 16, 30, 446, DateTimeKind.Local).AddTicks(1044) });
        }
    }
}
