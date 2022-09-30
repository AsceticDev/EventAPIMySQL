﻿// <auto-generated />
using System;
using EventAPIMySQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventAPIMySQL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220929004805_test2")]
    partial class test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AllergyGuest", b =>
                {
                    b.Property<int>("AllergiesId")
                        .HasColumnType("int");

                    b.Property<int>("GuestsId")
                        .HasColumnType("int");

                    b.HasKey("AllergiesId", "GuestsId");

                    b.HasIndex("GuestsId");

                    b.ToTable("AllergyGuest");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AllergyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("EventGuest", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("GuestsId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "GuestsId");

                    b.HasIndex("GuestsId");

                    b.ToTable("EventGuest");
                });

            modelBuilder.Entity("AllergyGuest", b =>
                {
                    b.HasOne("EventAPIMySQL.Models.Allergy", null)
                        .WithMany()
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAPIMySQL.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventGuest", b =>
                {
                    b.HasOne("EventAPIMySQL.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAPIMySQL.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}