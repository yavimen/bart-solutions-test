﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230308210426_DataSeed")]
    partial class DataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IncidentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AccountId");

                    b.HasAlternateKey("Name");

                    b.HasIndex("IncidentId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("6c8f59d1-b4d9-4888-b2af-3823c1584b22"),
                            IncidentId = new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"),
                            Name = "mystery007"
                        },
                        new
                        {
                            AccountId = new Guid("d72e2fc0-12f9-4c00-9ad5-1e3b1965c360"),
                            IncidentId = new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"),
                            Name = "fastestgun"
                        },
                        new
                        {
                            AccountId = new Guid("1c836356-3c0b-4478-a3c7-cd178c393bb1"),
                            IncidentId = new Guid("f5883015-4874-47d9-aa12-61cd4a1b1c04"),
                            Name = "intellectual"
                        });
                });

            modelBuilder.Entity("Entities.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ContactId");

                    b.HasAlternateKey("Email");

                    b.HasIndex("AccountId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = new Guid("75803ca4-79cf-43ab-953a-3c33f931d47d"),
                            AccountId = new Guid("6c8f59d1-b4d9-4888-b2af-3823c1584b22"),
                            Email = "emailam@gmail.com",
                            FirstName = "Alek",
                            LastName = "Markovych"
                        },
                        new
                        {
                            ContactId = new Guid("06a28087-17dc-4eaa-957d-a73761b953c2"),
                            AccountId = new Guid("d72e2fc0-12f9-4c00-9ad5-1e3b1965c360"),
                            Email = "vinve@gmail.com",
                            FirstName = "Vinsent",
                            LastName = "Vega"
                        },
                        new
                        {
                            ContactId = new Guid("f555ddc5-2839-4445-b8af-6df2ecb1c529"),
                            AccountId = new Guid("1c836356-3c0b-4478-a3c7-cd178c393bb1"),
                            Email = "ruco@gmail.com",
                            FirstName = "Rust",
                            LastName = "Cohle"
                        });
                });

            modelBuilder.Entity("Entities.Models.Incident", b =>
                {
                    b.Property<Guid>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("IncidentId");

                    b.HasAlternateKey("Name");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"),
                            Description = "Some descr.",
                            Name = "Incident1"
                        },
                        new
                        {
                            IncidentId = new Guid("f5883015-4874-47d9-aa12-61cd4a1b1c04"),
                            Description = "Some special descr.",
                            Name = "Incident2"
                        });
                });

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.HasOne("Entities.Models.Incident", "Incident")
                        .WithMany("Accounts")
                        .HasForeignKey("IncidentId");

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("Entities.Models.Contact", b =>
                {
                    b.HasOne("Entities.Models.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Entities.Models.Incident", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
