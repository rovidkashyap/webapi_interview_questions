﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using paging_sorting_filtering_in_web_api.Models;

#nullable disable

namespace paging_sorting_filtering_in_web_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("paging_sorting_filtering_in_web_api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Category 1",
                            Name = "Product 1",
                            Price = 10.00m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Category 2",
                            Name = "Product 2",
                            Price = 20.00m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Category 1",
                            Name = "Product 3",
                            Price = 30.00m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Category 3",
                            Name = "Product 4",
                            Price = 40.00m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Category 2",
                            Name = "Product 5",
                            Price = 50.00m
                        },
                        new
                        {
                            Id = 6,
                            Category = "Category 3",
                            Name = "Product 6",
                            Price = 60.00m
                        },
                        new
                        {
                            Id = 7,
                            Category = "Category 1",
                            Name = "Product 7",
                            Price = 70.00m
                        },
                        new
                        {
                            Id = 8,
                            Category = "Category 2",
                            Name = "Product 8",
                            Price = 80.00m
                        },
                        new
                        {
                            Id = 9,
                            Category = "Category 3",
                            Name = "Product 9",
                            Price = 90.00m
                        },
                        new
                        {
                            Id = 10,
                            Category = "Category 1",
                            Name = "Product 10",
                            Price = 100.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
