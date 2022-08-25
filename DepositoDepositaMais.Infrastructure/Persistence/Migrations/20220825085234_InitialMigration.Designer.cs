﻿// <auto-generated />
using System;
using DepositoDepositaMais.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DepositoDepositaMais.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DepositoDepositaMaisDbContext))]
    [Migration("20220825085234_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepositName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJCarrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPFCarrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPFCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierStateRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodeResponsibility")
                        .HasColumnType("int");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyStateRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReceivedIn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfVolume")
                        .HasColumnType("int");

                    b.Property<int>("WeightOfTheCargo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IncomingInvoices");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedDeliveryIn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IncomingInvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RepresentativeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepositId");

                    b.HasIndex("IncomingInvoiceId");

                    b.HasIndex("RepresentativeId");

                    b.ToTable("IncomingOrders");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingOrderProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IncomingOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncomingOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("IncomingOrderProducts");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StoragePlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmittedIn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("OutgoingInvoices");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutgoingInvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RepresentativeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SendIn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StoragePlaceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepositId");

                    b.HasIndex("OutgoingInvoiceId");

                    b.HasIndex("RepresentativeId");

                    b.ToTable("OutgoingOrders");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingOrderProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OutgoingOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OutgoingOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OutgoingOrderProducts");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackagingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("QuantityPackaging")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StoragePlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StoragePlaceId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderType")
                        .HasColumnType("int");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepositId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.ProvidersProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProvidersProducts");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Representative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("RepresentativeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Representatives");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.StoragePlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<int>("MaximumQuantity")
                        .HasColumnType("int");

                    b.Property<int>("MinimumQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepositId");

                    b.ToTable("StoragePlace");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepositId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.UserSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingOrder", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Deposit", "Deposit")
                        .WithMany("IncomingOrders")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.IncomingInvoice", null)
                        .WithMany("IncomingOrders")
                        .HasForeignKey("IncomingInvoiceId");

                    b.HasOne("DepositoDepositaMais.Core.Entities.Representative", "Representative")
                        .WithMany("IncomingOrders")
                        .HasForeignKey("RepresentativeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deposit");

                    b.Navigation("Representative");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingOrderProducts", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.IncomingOrder", "IncomingOrder")
                        .WithMany("IncomingOrderProducts")
                        .HasForeignKey("IncomingOrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.Product", "Product")
                        .WithMany("IncomingOrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("IncomingOrder");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingOrder", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Deposit", "Deposit")
                        .WithMany("OutgoingOrders")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.OutgoingInvoice", "OutgoingInvoice")
                        .WithMany("OutgoingOrders")
                        .HasForeignKey("OutgoingInvoiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.Representative", "Representative")
                        .WithMany("OutgoingOrders")
                        .HasForeignKey("RepresentativeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deposit");

                    b.Navigation("OutgoingInvoice");

                    b.Navigation("Representative");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingOrderProducts", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.OutgoingOrder", "OutgoingOrder")
                        .WithMany("OutgoingOrderProducts")
                        .HasForeignKey("OutgoingOrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.Product", "Product")
                        .WithMany("OutgoingOrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OutgoingOrder");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Product", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.StoragePlace", "StoragePlace")
                        .WithMany("Products")
                        .HasForeignKey("StoragePlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("StoragePlace");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Provider", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Deposit", "Deposit")
                        .WithMany("Providers")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.ProvidersProducts", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Product", "Product")
                        .WithMany("ProvidersProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.Provider", "Provider")
                        .WithMany("ProvidersProducts")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Representative", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Provider", "Provider")
                        .WithMany("Representatives")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.StoragePlace", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Deposit", "Deposit")
                        .WithMany("StoragePlaces")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.User", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Deposit", "Deposit")
                        .WithMany("Users")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.UserSkill", b =>
                {
                    b.HasOne("DepositoDepositaMais.Core.Entities.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DepositoDepositaMais.Core.Entities.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Deposit", b =>
                {
                    b.Navigation("IncomingOrders");

                    b.Navigation("OutgoingOrders");

                    b.Navigation("Providers");

                    b.Navigation("StoragePlaces");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingInvoice", b =>
                {
                    b.Navigation("IncomingOrders");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.IncomingOrder", b =>
                {
                    b.Navigation("IncomingOrderProducts");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingInvoice", b =>
                {
                    b.Navigation("OutgoingOrders");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.OutgoingOrder", b =>
                {
                    b.Navigation("OutgoingOrderProducts");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Product", b =>
                {
                    b.Navigation("IncomingOrderProducts");

                    b.Navigation("OutgoingOrderProducts");

                    b.Navigation("ProvidersProducts");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Provider", b =>
                {
                    b.Navigation("ProvidersProducts");

                    b.Navigation("Representatives");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Representative", b =>
                {
                    b.Navigation("IncomingOrders");

                    b.Navigation("OutgoingOrders");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.Skill", b =>
                {
                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.StoragePlace", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DepositoDepositaMais.Core.Entities.User", b =>
                {
                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
