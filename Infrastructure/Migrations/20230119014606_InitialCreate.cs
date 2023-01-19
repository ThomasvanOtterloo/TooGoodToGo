using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    OfferHotMeals = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteens", x => x.Id);
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
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Employee_Canteens_CanteenId",
                        column: x => x.CanteenId,
                        principalTable: "Canteens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PickUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    AvailableUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    ReservedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                columns: new[] { "Id", "City", "EmployeeId", "LocationName", "OfferHotMeals" },
                values: new object[,]
                {
                    { 1, 0, 1, "LA", true },
                    { 2, 1, 2, "LB", false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ContainsAlcohol", "Image", "Name" },
                values: new object[,]
                {
                    { 1, false, "https://i0.wp.com/www.vickyvandijk.nl/wp-content/uploads/2020/04/Vicky-van-Dijk-Knapperig-wit-brood-03.jpg?fit=1500%2C2100&ssl=1", "Bread" },
                    { 2, false, "https://familieoverdekook.nl/wp-content/uploads/2020/05/soep-met-courgette-en-tomaat.jpg", "Soup" },
                    { 3, false, "https://www.lekkerensimpel.com/wp-content/uploads/2022/08/588A2242.jpg", "pasta" },
                    { 4, true, "https://brouwerijtroost.nl/wp-content/uploads/IMG_9831-1200x1200.jpg", "Beer" },
                    { 5, false, "https://img.static-rmg.be/a/view/q75/w620/h336/4563344/gettyimages-1317960485-jpg.jpg", "sla" },
                    { 6, false, "https://www.oetker.nl/Recipe/Recipes/oetker.nl/nl-nl/miscellaneous/image-thumb__97330__RecipeDetail/pizza-caprese.jpg", "Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Student1@gmail.com", "Student 1", "0612345678" },
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Thomas@gmail.com", "", "0612345678" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CanteenId", "Email", "EmployeeNumber", "Name" },
                values: new object[] { 1, 1, "Admin@gmail.com", 13242321, "John Lee" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CanteenId", "Email", "EmployeeNumber", "Name" },
                values: new object[] { 2, 2, "Employee2@gmail.com", 1223334, "James Lee" });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "AvailableUntil", "Description", "EmployeeId", "Meal", "Name", "PickUp", "Price", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1318), "This box contains a surprise", 1, 0, "Suprise Box", new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1271), 10m, null },
                    { 2, new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1324), "Half of the box is filled with bread", 1, 0, "Bread Box", new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1321), 10m, null },
                    { 3, new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1329), "Alot of fresh left over soup ready to be served for dinner!", 1, 1, "Soup Box", new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1326), 10m, null },
                    { 4, new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1333), " This box contains a gourmet meal", 2, 1, "Gourmet Box", new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1331), 10m, null }
                });

            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackagesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "ReservedPackage",
                columns: new[] { "PackageId", "StudentId", "Id", "ReservedAt" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CanteenId",
                table: "Employee",
                column: "CanteenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductsId",
                table: "PackageProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_EmployeeId",
                table: "Packages",
                column: "EmployeeId");

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
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "ReservedPackage");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Canteens");
        }
    }
}
