using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MvcctExample.Data;

namespace MvcctExample.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170609161431_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcctExample.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDiscontinued");

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("SupplierId");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("IsDiscontinued");

                    b.HasIndex("ProductName");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UnitPrice");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("MvcctExample.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(64);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Fax")
                        .HasMaxLength(32);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("MvcctExample.Models.Food", b =>
                {
                    b.HasOne("MvcctExample.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
