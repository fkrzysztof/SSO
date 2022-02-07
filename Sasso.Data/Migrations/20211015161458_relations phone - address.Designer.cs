﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sasso.Data.Data;

namespace Sasso.Data.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20211015161458_relations phone - address")]
    partial class relationsphoneaddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sasso.Data.Data.Data.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIPCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.HasIndex("ContactID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KRS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REGON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Email", b =>
                {
                    b.Property<int>("EmailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailID");

                    b.HasIndex("ContactID");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Offer", b =>
                {
                    b.Property<int>("OfferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MediaItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Phone", b =>
                {
                    b.Property<int>("PhoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("NamePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneID");

                    b.HasIndex("AddressID");

                    b.HasIndex("ContactID");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Projects", b =>
                {
                    b.Property<int>("ProjectsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfPublication")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndProject")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormOfSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("News")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Participants")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recruitment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartProject")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectsID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Address", b =>
                {
                    b.HasOne("Sasso.Data.Data.Data.Contact", "Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactID");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Email", b =>
                {
                    b.HasOne("Sasso.Data.Data.Data.Contact", "Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactID");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Phone", b =>
                {
                    b.HasOne("Sasso.Data.Data.Data.Address", "Address")
                        .WithMany("Phones")
                        .HasForeignKey("AddressID");

                    b.HasOne("Sasso.Data.Data.Data.Contact", "Contact")
                        .WithMany("Phones")
                        .HasForeignKey("ContactID");

                    b.Navigation("Address");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Address", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Sasso.Data.Data.Data.Contact", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Emails");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
