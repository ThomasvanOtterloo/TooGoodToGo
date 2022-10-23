using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedLinkedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageProducts",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProducts", x => new { x.PackageId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PackageProducts_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservedPackage",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedPackage", x => new { x.PackageId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ReservedPackage_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedPackage_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PackageProducts",
                columns: new[] { "PackageId", "ProductId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 2, 0 },
                    { 1, 3, 0 },
                    { 1, 4, 0 },
                    { 2, 1, 0 },
                    { 2, 2, 0 },
                    { 2, 3, 0 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PackageProducts_ProductId",
                table: "PackageProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedPackage_StudentId",
                table: "ReservedPackage",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageProducts");

            migrationBuilder.DropTable(
                name: "ReservedPackage");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6137), new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6143), new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6148), new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "PickUp" },
                values: new object[] { new DateTime(2022, 10, 23, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6153), new DateTime(2022, 10, 20, 14, 27, 6, 11, DateTimeKind.Local).AddTicks(6151) });
        }
    }
}
