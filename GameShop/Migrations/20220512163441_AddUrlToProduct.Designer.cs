﻿// <auto-generated />
using GameShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameShop.Migrations
{
    [DbContext(typeof(GameShopContext))]
    [Migration("20220512163441_AddUrlToProduct")]
    partial class AddUrlToProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
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

                    b.Property<string>("Game_duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Num_of_players")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Package_list")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Product_price")
                        .HasColumnType("float");

                    b.Property<string>("URL")
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

                    b.Property<long>("Product_TypeId")
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

                    b.Property<int>("Product_amount")
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
                        .HasForeignKey("Product_TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
