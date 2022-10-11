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
    [Migration("20221007132030_guestAllergy")]
    partial class guestAllergy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventAPIMySQL.Models.Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AllergyType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AllergyType")
                        .IsUnique();

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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("EventName")
                        .IsUnique();

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.EventGuest", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "GuestId");

                    b.HasIndex("GuestId");

                    b.ToTable("GuestEvents");
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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.GuestAllergy", b =>
                {
                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.HasKey("GuestId", "AllergyId");

                    b.HasIndex("AllergyId");

                    b.ToTable("GuestAllergies");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.EventGuest", b =>
                {
                    b.HasOne("EventAPIMySQL.Models.Event", "Event")
                        .WithMany("EventGuests")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAPIMySQL.Models.Guest", "Guest")
                        .WithMany("EventGuests")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.GuestAllergy", b =>
                {
                    b.HasOne("EventAPIMySQL.Models.Allergy", "Allergy")
                        .WithMany("GuestAllergies")
                        .HasForeignKey("AllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAPIMySQL.Models.Guest", "Guest")
                        .WithMany("GuestAllergies")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.Allergy", b =>
                {
                    b.Navigation("GuestAllergies");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.Event", b =>
                {
                    b.Navigation("EventGuests");
                });

            modelBuilder.Entity("EventAPIMySQL.Models.Guest", b =>
                {
                    b.Navigation("EventGuests");

                    b.Navigation("GuestAllergies");
                });
#pragma warning restore 612, 618
        }
    }
}
