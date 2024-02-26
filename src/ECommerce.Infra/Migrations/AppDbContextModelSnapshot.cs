﻿// <auto-generated />
using System;
using ECommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("ECommerce.Domain.Models.Exchange", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExchangeDate")
                        .HasColumnType("TEXT");

                    b.Property<uint>("OriginalSaleId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PriceDifference")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OriginalSaleId");

                    b.ToTable("Exchange");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Product", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<uint>("QuantityRemaining")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.ProductExchange", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ExchangeId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductExchange");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.ProductSale", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("SaleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("ProductSale");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Refund", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("OriginalSaleId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("RefundAmount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RefundDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OriginalSaleId");

                    b.ToTable("Refund");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Sale", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Exchange", b =>
                {
                    b.HasOne("ECommerce.Domain.Models.Sale", "OriginalSale")
                        .WithMany()
                        .HasForeignKey("OriginalSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OriginalSale");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.ProductExchange", b =>
                {
                    b.HasOne("ECommerce.Domain.Models.Exchange", "Exchange")
                        .WithMany("ProductExchanges")
                        .HasForeignKey("ExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.ProductSale", b =>
                {
                    b.HasOne("ECommerce.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Domain.Models.Sale", "Sale")
                        .WithMany("SaleProducts")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Refund", b =>
                {
                    b.HasOne("ECommerce.Domain.Models.Sale", "OriginalSale")
                        .WithMany()
                        .HasForeignKey("OriginalSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OriginalSale");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Exchange", b =>
                {
                    b.Navigation("ProductExchanges");
                });

            modelBuilder.Entity("ECommerce.Domain.Models.Sale", b =>
                {
                    b.Navigation("SaleProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
