using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangedDBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Meal",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Canteens",
                newName: "LocationName");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Canteens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "EmployeeId", "LocationName" },
                values: new object[] { 1, 2, "LB" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Admin@gmail.com", "John Lee" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "James Lee");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "CanteenId", "EmployeeId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8826), null, 1, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8694) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "EmployeeId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8832), 1, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "EmployeeId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8836), 1, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "EmployeeId", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 6, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8841), 2, new DateTime(2022, 11, 3, 5, 42, 11, 521, DateTimeKind.Local).AddTicks(8839) });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_EmployeeId",
                table: "Packages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CanteenId",
                table: "Employee",
                column: "CanteenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Canteens_CanteenId",
                table: "Employee",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Employee_EmployeeId",
                table: "Packages",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Canteens_CanteenId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Employee_EmployeeId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_EmployeeId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CanteenId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Canteens");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Canteens",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Meal",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name" },
                values: new object[] { 2, "LD 2" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Employee1@gmail.com", "Employee 1" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Employee 2");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "CanteenId", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1659), 1, 1, new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1665), 1, new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "City", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1670), 2, 1, new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "City", "Meal", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1675), 2, 1, new DateTime(2022, 10, 29, 1, 19, 5, 661, DateTimeKind.Local).AddTicks(1673) });
        }
    }
}
