using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class BirthdateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8469), new DateTime(2022, 11, 6, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8431) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8474), new DateTime(2022, 11, 6, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8479), new DateTime(2022, 11, 6, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8483), new DateTime(2022, 11, 6, 3, 19, 46, 309, DateTimeKind.Local).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");

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
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3079), new DateTime(2022, 11, 6, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3084), new DateTime(2022, 11, 6, 3, 8, 54, 512, DateTimeKind.Local).AddTicks(3082) });
        }
    }
}
