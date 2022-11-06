using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class smallfixOnCanteenOb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Canteens_CanteenId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CanteenId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CanteenId",
                table: "Packages");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CanteenId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8826), new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8694) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8832), 1, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8836), 1, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "CanteenId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8841), 2, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8839) });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CanteenId",
                table: "Packages",
                column: "CanteenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Canteens_CanteenId",
                table: "Packages",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id");
        }
    }
}
