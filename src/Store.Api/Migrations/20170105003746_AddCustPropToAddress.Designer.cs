using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Store.Api.Entities;

namespace Store.Api.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20170105003746_AddCustPropToAddress")]
    partial class AddCustPropToAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store.Api.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("StreetLine1");

                    b.Property<string>("StreetLine2");

                    b.Property<int?>("customerId");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Store.Api.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Store.Api.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<int>("ShippingAddressId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductCode");

                    b.Property<string>("ProductName");

                    b.Property<DateTime?>("ReleaseDate");

                    b.Property<decimal>("StarRating");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Store.Api.Entities.Address", b =>
                {
                    b.HasOne("Store.Api.Entities.Customer", "customer")
                        .WithMany("Addresses")
                        .HasForeignKey("customerId");
                });

            modelBuilder.Entity("Store.Api.Entities.Order", b =>
                {
                    b.HasOne("Store.Api.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Store.Api.Entities.Address", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Store.Api.Entities.Product", b =>
                {
                    b.HasOne("Store.Api.Entities.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });
        }
    }
}
