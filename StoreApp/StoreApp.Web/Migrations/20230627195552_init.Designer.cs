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
    [Migration("20230627195552_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Computer",
                            Price = 17000m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Keyboard",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mouse",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Monitor",
                            Price = 7000m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Desk",
                            Price = 1500m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
