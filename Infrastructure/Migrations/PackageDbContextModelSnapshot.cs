﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PackageDbContext))]
    partial class PackageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Domain.Canteen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OfferHotMeals")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Canteens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = 0,
                            EmployeeId = 1,
                            LocationName = "LA",
                            OfferHotMeals = true
                        },
                        new
                        {
                            Id = 2,
                            City = 1,
                            EmployeeId = 2,
                            LocationName = "LB",
                            OfferHotMeals = false
                        });
                });

            modelBuilder.Entity("Core.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CanteenId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId")
                        .IsUnique();

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanteenId = 1,
                            Email = "Admin@gmail.com",
                            EmployeeNumber = 13242321,
                            Name = "John Lee"
                        },
                        new
                        {
                            Id = 2,
                            CanteenId = 2,
                            Email = "Employee2@gmail.com",
                            EmployeeNumber = 1223334,
                            Name = "James Lee"
                        });
                });

            modelBuilder.Entity("Core.Domain.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AvailableUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Meal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickUp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableUntil = new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1318),
                            Description = "This box contains a surprise",
                            EmployeeId = 1,
                            Meal = 0,
                            Name = "Suprise Box",
                            PickUp = new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1271),
                            Price = 10m
                        },
                        new
                        {
                            Id = 2,
                            AvailableUntil = new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1324),
                            Description = "Half of the box is filled with bread",
                            EmployeeId = 1,
                            Meal = 0,
                            Name = "Bread Box",
                            PickUp = new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1321),
                            Price = 10m
                        },
                        new
                        {
                            Id = 3,
                            AvailableUntil = new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1329),
                            Description = "Alot of fresh left over soup ready to be served for dinner!",
                            EmployeeId = 1,
                            Meal = 1,
                            Name = "Soup Box",
                            PickUp = new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1326),
                            Price = 10m
                        },
                        new
                        {
                            Id = 4,
                            AvailableUntil = new DateTime(2023, 1, 22, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1333),
                            Description = " This box contains a gourmet meal",
                            EmployeeId = 2,
                            Meal = 1,
                            Name = "Gourmet Box",
                            PickUp = new DateTime(2023, 1, 20, 2, 46, 6, 509, DateTimeKind.Local).AddTicks(1331),
                            Price = 10m
                        });
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ContainsAlcohol")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContainsAlcohol = false,
                            Image = "https://i0.wp.com/www.vickyvandijk.nl/wp-content/uploads/2020/04/Vicky-van-Dijk-Knapperig-wit-brood-03.jpg?fit=1500%2C2100&ssl=1",
                            Name = "Bread"
                        },
                        new
                        {
                            Id = 2,
                            ContainsAlcohol = false,
                            Image = "https://familieoverdekook.nl/wp-content/uploads/2020/05/soep-met-courgette-en-tomaat.jpg",
                            Name = "Soup"
                        },
                        new
                        {
                            Id = 3,
                            ContainsAlcohol = false,
                            Image = "https://www.lekkerensimpel.com/wp-content/uploads/2022/08/588A2242.jpg",
                            Name = "pasta"
                        },
                        new
                        {
                            Id = 4,
                            ContainsAlcohol = true,
                            Image = "https://brouwerijtroost.nl/wp-content/uploads/IMG_9831-1200x1200.jpg",
                            Name = "Beer"
                        },
                        new
                        {
                            Id = 5,
                            ContainsAlcohol = false,
                            Image = "https://img.static-rmg.be/a/view/q75/w620/h336/4563344/gettyimages-1317960485-jpg.jpg",
                            Name = "sla"
                        },
                        new
                        {
                            Id = 6,
                            ContainsAlcohol = false,
                            Image = "https://www.oetker.nl/Recipe/Recipes/oetker.nl/nl-nl/miscellaneous/image-thumb__97330__RecipeDetail/pizza-caprese.jpg",
                            Name = "Pizza"
                        });
                });

            modelBuilder.Entity("Core.Domain.ReservedPackage", b =>
                {
                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PackageId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("ReservedPackage");

                    b.HasData(
                        new
                        {
                            PackageId = 1,
                            StudentId = 1,
                            Id = 0,
                            ReservedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PackageId = 2,
                            StudentId = 1,
                            Id = 0,
                            ReservedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = 2,
                            Email = "Student1@gmail.com",
                            Name = "Student 1",
                            PhoneNumber = "0612345678"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = 0,
                            Email = "Thomas@gmail.com",
                            Name = "",
                            PhoneNumber = "0612345678"
                        });
                });

            modelBuilder.Entity("PackageProduct", b =>
                {
                    b.Property<int>("PackagesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("PackagesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("PackageProduct");

                    b.HasData(
                        new
                        {
                            PackagesId = 1,
                            ProductsId = 1
                        },
                        new
                        {
                            PackagesId = 1,
                            ProductsId = 2
                        },
                        new
                        {
                            PackagesId = 2,
                            ProductsId = 3
                        },
                        new
                        {
                            PackagesId = 2,
                            ProductsId = 4
                        },
                        new
                        {
                            PackagesId = 3,
                            ProductsId = 5
                        },
                        new
                        {
                            PackagesId = 3,
                            ProductsId = 6
                        },
                        new
                        {
                            PackagesId = 4,
                            ProductsId = 1
                        },
                        new
                        {
                            PackagesId = 4,
                            ProductsId = 2
                        },
                        new
                        {
                            PackagesId = 4,
                            ProductsId = 3
                        },
                        new
                        {
                            PackagesId = 4,
                            ProductsId = 4
                        });
                });

            modelBuilder.Entity("Core.Domain.Employee", b =>
                {
                    b.HasOne("Core.Domain.Canteen", "Canteen")
                        .WithOne("Employee")
                        .HasForeignKey("Core.Domain.Employee", "CanteenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canteen");
                });

            modelBuilder.Entity("Core.Domain.Package", b =>
                {
                    b.HasOne("Core.Domain.Employee", "Employee")
                        .WithMany("Packages")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Core.Domain.Student", "Student")
                        .WithMany("Packages")
                        .HasForeignKey("StudentId");

                    b.Navigation("Employee");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Core.Domain.ReservedPackage", b =>
                {
                    b.HasOne("Core.Domain.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PackageProduct", b =>
                {
                    b.HasOne("Core.Domain.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Canteen", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Core.Domain.Employee", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Core.Domain.Student", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
