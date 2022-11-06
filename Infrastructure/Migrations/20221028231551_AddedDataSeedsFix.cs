using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedDataSeedsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackagesId", "ProductsId" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3536), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3545), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3549), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3554), new DateTime(2022, 10, 29, 1, 15, 50, 918, DateTimeKind.Local).AddTicks(3552) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4404), new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4367) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4411), new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4408) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4415), new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4421), new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4419) });
        }
    }
}
