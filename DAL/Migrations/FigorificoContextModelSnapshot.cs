﻿// <auto-generated />
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

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("real");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<string>("SalePrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("SuggestedPrice")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdProduct");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}