﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CocovoitAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Localisation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Localisations");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Reservation", b =>
                {
                    b.Property<long>("UtilisateurId")
                        .HasColumnType("bigint");

                    b.Property<long>("TrajetId")
                        .HasColumnType("bigint");

                    b.HasKey("UtilisateurId", "TrajetId");

                    b.HasIndex("TrajetId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Trajet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ConducteurId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateHeure")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("LocalisationArriveeId")
                        .HasColumnType("bigint");

                    b.Property<long>("LocalisationDepartId")
                        .HasColumnType("bigint");

                    b.Property<int>("NombrePlaces")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConducteurId");

                    b.HasIndex("LocalisationArriveeId");

                    b.HasIndex("LocalisationDepartId");

                    b.ToTable("Trajets");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Utilisateur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("LocalisationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LocalisationId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Reservation", b =>
                {
                    b.HasOne("CocovoitAPI.Business.Entity.Trajet", "Trajet")
                        .WithMany("Reservations")
                        .HasForeignKey("TrajetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocovoitAPI.Business.Entity.Utilisateur", "Utilisateur")
                        .WithMany("Reservations")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trajet");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Trajet", b =>
                {
                    b.HasOne("CocovoitAPI.Business.Entity.Utilisateur", "Conducteur")
                        .WithMany("TrajetsEnTantQueConducteur")
                        .HasForeignKey("ConducteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocovoitAPI.Business.Entity.Localisation", "LocalisationArrivee")
                        .WithMany()
                        .HasForeignKey("LocalisationArriveeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocovoitAPI.Business.Entity.Localisation", "LocalisationDepart")
                        .WithMany()
                        .HasForeignKey("LocalisationDepartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conducteur");

                    b.Navigation("LocalisationArrivee");

                    b.Navigation("LocalisationDepart");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Utilisateur", b =>
                {
                    b.HasOne("CocovoitAPI.Business.Entity.Localisation", "Localisation")
                        .WithMany()
                        .HasForeignKey("LocalisationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Localisation");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Trajet", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CocovoitAPI.Business.Entity.Utilisateur", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("TrajetsEnTantQueConducteur");
                });
#pragma warning restore 612, 618
        }
    }
}
