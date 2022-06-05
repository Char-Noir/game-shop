﻿// <auto-generated />
using System;
using GameShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameShop.Migrations
{
    [DbContext(typeof(GameShopContext))]
    partial class GameShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.4.22229.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameShop.Models.Entity.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Chars")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumOfPlayers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("GameShop.Models.Entity.Product_Type", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("GameShop.Models.Entity.ProductType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long?>("Product_TypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("Product_TypeId");

                    b.ToTable("Product_Type");
                });

            modelBuilder.Entity("GameShop.Models.Entity.WarhouseItem", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WarhouseItem");
                });

            modelBuilder.Entity("GameShop.Models.Entity.ProductType", b =>
                {
                    b.HasOne("GameShop.Models.Entity.Product", "Product")
                        .WithMany("ProductTypes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Models.Entity.Product_Type", "Product_Type")
                        .WithMany()
                        .HasForeignKey("Product_TypeId");

                    b.Navigation("Product");

                    b.Navigation("Product_Type");
                });

            modelBuilder.Entity("GameShop.Models.Entity.WarhouseItem", b =>
                {
                    b.HasOne("GameShop.Models.Entity.Product", "Product")
                        .WithOne("WarhouseItem")
                        .HasForeignKey("GameShop.Models.Entity.WarhouseItem", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GameShop.Models.Entity.Product", b =>
                {
                    b.Navigation("ProductTypes");

                    b.Navigation("WarhouseItem")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
