﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResourceManagementSystem.Data;

#nullable disable

namespace ResourceManagementSystem.Migrations
{
    [DbContext(typeof(ResourceManagementContext))]
    [Migration("20240708113523_BookingDB")]
    partial class BookingDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResourceManagementSystem.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("class_dept")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("collectionDate")
                        .HasColumnType("date");

                    b.Property<double>("contactNumber")
                        .HasColumnType("float");

                    b.Property<string>("personName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("returnDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ResourceManagementSystem.Entities.BookingResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("ResourceId");

                    b.ToTable("BookingResources");
                });

            modelBuilder.Entity("ResourceManagementSystem.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Compartment No 14"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Compartment No 15"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Compartment No 16"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Compartment No 17"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Compartment No 18"
                        });
                });

            modelBuilder.Entity("ResourceManagementSystem.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("ResourceManagementSystem.Entities.BookingResource", b =>
                {
                    b.HasOne("ResourceManagementSystem.Entities.Booking", "booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceManagementSystem.Entities.Resource", "resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking");

                    b.Navigation("resource");
                });

            modelBuilder.Entity("ResourceManagementSystem.Entities.Resource", b =>
                {
                    b.HasOne("ResourceManagementSystem.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}