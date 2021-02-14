﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleOrganizer.Persistence;

namespace SaleOrganizer.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("SaleOrganizer.Domain.Cloth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("SaleOrganizer.Domain.Offering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClothId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OfferingDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("OrderedDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferenceLink")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SendDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TradeType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.ToTable("Offerings");
                });

            modelBuilder.Entity("SaleOrganizer.Domain.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClothId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferenceLink")
                        .HasColumnType("TEXT");

                    b.Property<int>("TradeType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("SaleOrganizer.Domain.Offering", b =>
                {
                    b.HasOne("SaleOrganizer.Domain.Cloth", "Cloth")
                        .WithMany("Offerings")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaleOrganizer.Domain.Purchase", b =>
                {
                    b.HasOne("SaleOrganizer.Domain.Cloth", "Cloth")
                        .WithMany("Purchases")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
