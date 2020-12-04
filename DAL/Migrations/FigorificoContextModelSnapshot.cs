﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(FigorificoContext))]
    partial class FigorificoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.CategoryProduct", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdCategory");

                    b.HasIndex("IdType");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("Entity.Client", b =>
                {
                    b.Property<string>("Indentification")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(130)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Indentification");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Entity.Invoice", b =>
                {
                    b.Property<string>("IdInvoice")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("DueDate")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("IdClient")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SaleDate")
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalIva")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdInvoice");

                    b.HasIndex("IdClient");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Entity.InvoiceDetail", b =>
                {
                    b.Property<int>("IdDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("IdInvoice")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("IdProduct")
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<decimal>("TolalDetail")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetail");

                    b.HasIndex("IdInvoice");

                    b.HasIndex("IdProduct");

                    b.ToTable("InvoiceDetail");
                });

            modelBuilder.Entity("Entity.Product", b =>
                {
                    b.Property<string>("IdProduct")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iva")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdProduct");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entity.TypeProduct", b =>
                {
                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdType");

                    b.ToTable("TypeProduct");
                });

            modelBuilder.Entity("Entity.CategoryProduct", b =>
                {
                    b.HasOne("Entity.TypeProduct", "TypeProduct")
                        .WithMany()
                        .HasForeignKey("IdType");
                });

            modelBuilder.Entity("Entity.Invoice", b =>
                {
                    b.HasOne("Entity.Client", null)
                        .WithMany()
                        .HasForeignKey("IdClient");
                });

            modelBuilder.Entity("Entity.InvoiceDetail", b =>
                {
                    b.HasOne("Entity.Invoice", null)
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("IdInvoice");

                    b.HasOne("Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
