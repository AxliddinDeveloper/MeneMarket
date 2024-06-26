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
    [Migration("20240513130146_CreateAllTables")]
    partial class CreateAllTables
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

            modelBuilder.Entity("MeneMarket.Models.Foundations.Comments.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.DonatedUsers.DonatedUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DonationBoxId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DonationPrice")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DonationBoxId");

                    b.HasIndex("UserId");

                    b.ToTable("DonatedUsers");
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

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageMetadatas");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.News.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("imageFilePath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("News");
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

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductRequests.ProductRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserRegion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRequests");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductTypes.ProductType", b =>
                {
                    b.Property<Guid>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTypes");
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

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<short>("NumberSold")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ScidPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Reports.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReportType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Users.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

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

            modelBuilder.Entity("MeneMarket.Models.Foundations.Comments.Comment", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.DonatedUsers.DonatedUser", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.DonationBoxes.DonationBox", "DonationBox")
                        .WithMany("Users")
                        .HasForeignKey("DonationBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeneMarket.Models.Foundations.Users.User", "User")
                        .WithMany("DonatedUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonationBox");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ImageMetadatas.ImageMetadata", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany("ImageMetadatas")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductRequests.ProductRequest", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.ProductTypes.ProductType", b =>
                {
                    b.HasOne("MeneMarket.Models.Foundations.Products.Product", "Product")
                        .WithMany("ProductTypes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.DonationBoxes.DonationBox", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.OfferLinks.OfferLink", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Products.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ImageMetadatas");

                    b.Navigation("OfferLinks");

                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("MeneMarket.Models.Foundations.Users.User", b =>
                {
                    b.Navigation("BalanceHistorys");

                    b.Navigation("DonatedUsers");

                    b.Navigation("OfferLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
