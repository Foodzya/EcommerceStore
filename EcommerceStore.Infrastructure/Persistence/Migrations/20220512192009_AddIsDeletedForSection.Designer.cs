﻿// <auto-generated />
using System;
using EcommerceStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EcommerceStore.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    [Migration("20220512192009_AddIsDeletedForSection")]
    partial class AddIsDeletedForSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ecommerce")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<int>("PostCode")
                        .HasColumnType("integer")
                        .HasColumnName("postcode");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("text")
                        .HasColumnName("streetaddress");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_addresses");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_addresses_userid");

                    b.ToTable("addresses", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FoundationYear")
                        .HasColumnType("integer")
                        .HasColumnName("foundationyear");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_brands");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_brands_name");

                    b.ToTable("brands", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifieddate");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_userid");

                    b.ToTable("orders", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer")
                        .HasColumnName("brandid");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("productcategoryid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("BrandId")
                        .HasDatabaseName("ix_products_brandid");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_products_name");

                    b.HasIndex("ProductCategoryId")
                        .HasDatabaseName("ix_products_productcategoryid");

                    b.ToTable("products", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("parentcategoryid");

                    b.HasKey("Id")
                        .HasName("pk_productcategories");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_productcategories_name");

                    b.HasIndex("ParentCategoryId")
                        .HasDatabaseName("ix_productcategories_parentcategoryid");

                    b.ToTable("productcategories", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductCategorySection", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("integer")
                        .HasColumnName("sectionid");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("productcategoryid");

                    b.HasKey("SectionId", "ProductCategoryId")
                        .HasName("pk_productcategorysections");

                    b.HasIndex("ProductCategoryId")
                        .HasDatabaseName("ix_productcategorysections_productcategoryid");

                    b.ToTable("productcategorysections", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("orderid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_productorders");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_productorders_orderid");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_productorders_productid");

                    b.ToTable("productorders", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_reviews_productid");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_userid");

                    b.ToTable("reviews", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_roles_name");

                    b.ToTable("roles", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_sections");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_sections_name");

                    b.ToTable("sections", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("roleid");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_users_roleid");

                    b.ToTable("users", "ecommerce");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Address", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_addresses_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Order", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Product", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_brands_brandid");

                    b.HasOne("EcommerceStore.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_productcategories_productcategoryid");

                    b.Navigation("Brand");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.ProductCategory", "ParentCategory")
                        .WithMany("ChildrenCategory")
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("fk_productcategories_productcategories_parentcategoryid");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductCategorySection", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany("ProductCategorySections")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_productcategorysections_productcategories_productcategoryid");

                    b.HasOne("EcommerceStore.Domain.Entities.Section", "Section")
                        .WithMany("ProductCategorySections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_productcategorysections_sections_sectionid");

                    b.Navigation("ProductCategory");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductOrder", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_productorders_orders_orderid");

                    b.HasOne("EcommerceStore.Domain.Entities.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_productorders_products_productid");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Review", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_products_productid");

                    b.HasOne("EcommerceStore.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_users_userid");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.User", b =>
                {
                    b.HasOne("EcommerceStore.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_roles_roleid");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Order", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductOrders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("ChildrenCategory");

                    b.Navigation("ProductCategorySections");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.Section", b =>
                {
                    b.Navigation("ProductCategorySections");
                });

            modelBuilder.Entity("EcommerceStore.Domain.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
