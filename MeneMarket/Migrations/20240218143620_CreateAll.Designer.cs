﻿// <auto-generated />
using System;
using MeneMarket.Brokers.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeneMarket.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20240218143620_CreateAll")]
    partial class CreateAll
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("MeneMarket.Models.Foundations.BalanceHistorys.BalanceHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BalanceHistorys");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Clients.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OfferLinkId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusType")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientId");

                    b.HasIndex("OfferLinkId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.DonationBoxes.DonationBox", b =>
                {
                    b.Property<Guid>("DonationBoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.HasKey("DonationBoxId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ImageMetadatas.ImageMetadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("Format")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<float>("Size")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageMetadatas");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.OfferLinks.OfferLink", b =>
                {
                    b.Property<Guid>("OfferLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AllowDonation")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DonationPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("OfferLinkId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("OfferLinks");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductAttributes.ProductAttribute", b =>
                {
                    b.Property<Guid>("ProductAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Belong")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Size")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductAttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductRequests.ProductRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserRegion")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRequests");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Products.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AdvertisingPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<short>("NumberSold")
                        .HasColumnType("INTEGER");

                    b.Property<short>("NumberStars")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductOwner")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ScidPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Users.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DonationBoxId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("DonationBoxId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.BalanceHistorys.BalanceHistory", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Users.User", "User")
                        .WithMany("BalanceHistorys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Clients.Client", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.OfferLinks.OfferLink", "OfferLink")
                        .WithMany("Clients")
                        .HasForeignKey("OfferLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfferLink");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ImageMetadatas.ImageMetadata", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany("ImageMetadatas")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.OfferLinks.OfferLink", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany("OfferLinks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeneMarket.Models.Foundations.Users.User", "User")
                        .WithMany("OfferLinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductAttributes.ProductAttribute", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductRequests.ProductRequest", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Users.User", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.DonationBoxes.DonationBox", "DonationBox")
                        .WithMany("DonatedUsers")
                        .HasForeignKey("DonationBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonationBox");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.DonationBoxes.DonationBox", b =>
                {
                    b.Navigation("DonatedUsers");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.OfferLinks.OfferLink", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Products.Product", b =>
                {
                    b.Navigation("ImageMetadatas");

                    b.Navigation("OfferLinks");

                    b.Navigation("ProductAttributes");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Users.User", b =>
                {
                    b.Navigation("BalanceHistorys");

                    b.Navigation("OfferLinks");
                });
#pragma warning restore 612, 618
        }
    }
}