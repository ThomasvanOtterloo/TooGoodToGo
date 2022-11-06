using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addedNewSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackagesId", "ProductsId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4404), "This box contains a surprise", "Suprise Box", new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4367), null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4411), "Half of the box is filled with bread", "Bread Box", new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4408), null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "CanteenId", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4415), 1, "Alot of fresh left over soup ready to be served for dinner!", "Soup Box", new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4413), null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "CanteenId", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4421), 2, " This box contains a gourmet meal", "Gourmet Box", new DateTime(2022, 10, 29, 0, 55, 38, 818, DateTimeKind.Local).AddTicks(4419), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://i0.wp.com/www.vickyvandijk.nl/wp-content/uploads/2020/04/Vicky-van-Dijk-Knapperig-wit-brood-03.jpg?fit=1500%2C2100&ssl=1", "brood" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://familieoverdekook.nl/wp-content/uploads/2020/05/soep-met-courgette-en-tomaat.jpg", "soep" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.lekkerensimpel.com/wp-content/uploads/2022/08/588A2242.jpg", "pasta" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContainsAlcohol", "Image" },
                values: new object[] { true, "https://brouwerijtroost.nl/wp-content/uploads/IMG_9831-1200x1200.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://img.static-rmg.be/a/view/q75/w620/h336/4563344/gettyimages-1317960485-jpg.jpg", "sla" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.oetker.nl/Recipe/Recipes/oetker.nl/nl-nl/miscellaneous/image-thumb__97330__RecipeDetail/pizza-caprese.jpg", "Pizza" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PackageProduct",
                keyColumns: new[] { "PackagesId", "ProductsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackagesId", "ProductsId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableUntil", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6914), "This is a package", "Package 1", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6871), 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableUntil", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6920), "This is a package", "Package 2", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6918), 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableUntil", "CanteenId", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6924), null, "This is a package", "Package 3", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6922), 2 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableUntil", "CanteenId", "Description", "Name", "PickUp", "StudentId" },
                values: new object[] { new DateTime(2022, 10, 27, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6929), null, "This is a package", "Package 4", new DateTime(2022, 10, 24, 23, 34, 17, 194, DateTimeKind.Local).AddTicks(6927), 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContainsAlcohol", "Image" },
                values: new object[] { false, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Image", "Name" },
                values: new object[] { "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi", "Product 6" });
        }
    }
}
