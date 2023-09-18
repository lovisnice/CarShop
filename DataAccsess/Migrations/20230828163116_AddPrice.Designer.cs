﻿// <auto-generated />
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShop.Migrations
{
    [DbContext(typeof(CarShopContext))]
    [Migration("20230828163116_AddPrice")]
    partial class AddPrice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarShop.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2023);

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Color = "red",
                            Manufacturer = "Volvo",
                            Year = 2006,
                            price = 10m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Color = "red",
                            Manufacturer = "BMW",
                            Year = 2006,
                            price = 10m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Color = "red",
                            Manufacturer = "Nissan",
                            Year = 2006,
                            price = 10m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Color = "red",
                            Manufacturer = "MAZ",
                            Year = 2006,
                            price = 10m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Color = "Blue",
                            Manufacturer = "Toyota",
                            Year = 2020,
                            price = 15m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Color = "Red",
                            Manufacturer = "Ford",
                            Year = 2019,
                            price = 15m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Color = "Silver",
                            Manufacturer = "Honda",
                            Year = 2022,
                            price = 15m
                        });
                });

            modelBuilder.Entity("CarShop.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "None",
                            Name = "Cedan"
                        },
                        new
                        {
                            Id = 2,
                            Description = "None",
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 3,
                            Description = "None",
                            Name = "SVC"
                        });
                });

            modelBuilder.Entity("CarShop.Entities.Car", b =>
                {
                    b.HasOne("CarShop.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CarShop.Entities.Category", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}