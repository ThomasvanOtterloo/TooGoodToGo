using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    OfferHotMeals = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    CanteenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainsAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CanteenId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: false),
                    PickUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    AvailableUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Canteens_CanteenId",
                        column: x => x.CanteenId,
                        principalTable: "Canteens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Packages_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => new { x.PackagesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PackageProduct_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProduct_Products_ProductsId",
                        column: x => x.ProductsId,
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
                table: "Canteens",
                columns: new[] { "Id", "City", "Name", "OfferHotMeals" },
                values: new object[,]
                {
                    { 1, 0, "LA", true },
                    { 2, 2, "LD 2", false }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CanteenId", "Email", "EmployeeNumber", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Employee1@gmail.com", 13242321, "Employee 1" },
                    { 2, 2, "Employee2@gmail.com", 1223334, "Employee 2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ContainsAlcohol", "Image", "Name" },
                values: new object[,]
                {
                    { 1, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 1" },
                    { 2, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 2" },
                    { 3, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 3" },
                    { 4, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 4" },
                    { 5, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 5" },
                    { 6, false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 6" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 2, "Student1@gmail.com", "Student 1", "0612345678" },
                    { 2, 0, "Student2@gmail.com", "Student 2", "0612345678" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "AvailableUntil", "CanteenId", "City", "Description", "Meal", "Name", "PickUp", "Price", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6914), 1, 0, "This is a package", 1, "Package 1", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6871), 10m, 1 },
                    { 2, new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6920), 1, 0, "This is a package", 1, "Package 2", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6918), 10m, 1 },
                    { 3, new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6924), null, 2, "This is a package", 1, "Package 3", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6922), 10m, 2 },
                    { 4, new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6929), null, 2, "This is a package", 1, "Package 4", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6927), 10m, 2 }
                });

            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackagesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ReservedPackage",
                columns: new[] { "PackageId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductsId",
                table: "PackageProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CanteenId",
                table: "Packages",
                column: "CanteenId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StudentId",
                table: "Packages",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedPackage_StudentId",
                table: "ReservedPackage",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "ReservedPackage");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Canteens");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
