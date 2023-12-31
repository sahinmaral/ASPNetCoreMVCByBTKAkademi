﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.Repositories;

#nullable disable

namespace StoreApp.Web.Migrations
{
    [DbContext(typeof(StoreAppDbContext))]
    [Migration("20230629003231_Added_ImageUrlAndDescriptionToProductEntity")]
    partial class AddedImageUrlAndDescriptionToProductEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Furnitures"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        });
                });

            modelBuilder.Entity("StoreApp.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "4D6163E7-1321-4D07-8B38-9BF8A433A883.png",
                            Name = "Computer",
                            Price = 17000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "EA8FFAB5-7432-4D4C-8A49-C06FD536781C.png",
                            Name = "Keyboard",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "2C2CD168-09B3-47EA-9F20-18CCD53C2A06.png",
                            Name = "Mouse",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "82471C75-0DE9-449B-9D71-58AFA425FD5B.png",
                            Name = "Monitor",
                            Price = 7000m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "ABEB5A52-0337-4A71-9A80-E659B8B589D6.png",
                            Name = "Desk",
                            Price = 1500m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "56122ED3-A48C-43EA-8EEE-F71799E10947.png",
                            Name = "Chair",
                            Price = 2500m
                        });
                });

            modelBuilder.Entity("StoreApp.Entities.Product", b =>
                {
                    b.HasOne("StoreApp.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StoreApp.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
