using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddingNewSeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4970), new DateTime(2022, 11, 3, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4976), new DateTime(2022, 11, 3, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4981), new DateTime(2022, 11, 3, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4985), new DateTime(2022, 11, 3, 18, 15, 45, 551, DateTimeKind.Local).AddTicks(4983) });
        }
    }
}
