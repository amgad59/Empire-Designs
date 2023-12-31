﻿// <auto-generated />
using Empire.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empire.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230625012618_manytomanyRelationship")]
    partial class manytomanyRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Empire.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Hoodie"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("Empire.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A white hoodie with butterflies on it",
                            Discount = 0,
                            ImageUrl = "",
                            ListPrice = 350
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "A black hoodie with butterflies on it",
                            Discount = 0,
                            ImageUrl = "",
                            ListPrice = 450
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "A white hoodie with Sinatraa on it",
                            Discount = 0,
                            ImageUrl = "",
                            ListPrice = 400
                        });
                });

            modelBuilder.Entity("Empire.Models.productSizeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("productSizeModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "S",
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "M",
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "L",
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("ProductproductSizeModel", b =>
                {
                    b.Property<int>("ProductSizesId")
                        .HasColumnType("int");

                    b.Property<int>("productsId")
                        .HasColumnType("int");

                    b.HasKey("ProductSizesId", "productsId");

                    b.HasIndex("productsId");

                    b.ToTable("ProductproductSizeModel");
                });

            modelBuilder.Entity("Empire.Models.Product", b =>
                {
                    b.HasOne("Empire.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductproductSizeModel", b =>
                {
                    b.HasOne("Empire.Models.productSizeModel", null)
                        .WithMany()
                        .HasForeignKey("ProductSizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Empire.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("productsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
