﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(Vet4Context))]
    [Migration("20231031225101_InitialCreated")]
    partial class InitialCreated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdPet")
                        .HasColumnType("int");

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdPet");

                    b.HasIndex("IdService");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Breed", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartament")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartament");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CustomerPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.ToTable("CustomerPhone", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.ToTable("Departament", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.LocationPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bis")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("CardinalPrimary")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CardinalSecondary")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Complement")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("MainLetter")
                        .HasColumnType("longtext");

                    b.Property<int>("MainNumber")
                        .HasColumnType("int");

                    b.Property<int>("SecondNumber")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryLetter")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("TertaryLetter")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TertaryNumber")
                        .HasColumnType("int");

                    b.Property<string>("TypeRoad")
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudad")
                        .IsUnique();

                    b.HasIndex("IdClient")
                        .IsUnique();

                    b.ToTable("LocationPerson", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int>("IdBreed")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Specie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdBreed");

                    b.HasIndex("IdClient");

                    b.ToTable("Pet", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("rolName");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("IdClient")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdRol");

                    b.HasIndex("IdRol");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Clients")
                        .WithMany("Appointments")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pet", "Pets")
                        .WithMany("Appointments")
                        .HasForeignKey("IdPet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Service", "Services")
                        .WithMany("Appointments")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");

                    b.Navigation("Pets");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.HasOne("Domain.Entities.Departament", "Departaments")
                        .WithMany("Cities")
                        .HasForeignKey("IdDepartament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departaments");
                });

            modelBuilder.Entity("Domain.Entities.CustomerPhone", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Clients")
                        .WithMany("CustomerPhones")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Entities.Departament", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Countries")
                        .WithMany("Departaments")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("Domain.Entities.LocationPerson", b =>
                {
                    b.HasOne("Domain.Entities.City", "Cities")
                        .WithOne("LocationPerson")
                        .HasForeignKey("Domain.Entities.LocationPerson", "IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Client", "Clients")
                        .WithOne("LocationPerson")
                        .HasForeignKey("Domain.Entities.LocationPerson", "IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.HasOne("Domain.Entities.Breed", "Breeds")
                        .WithMany("Pets")
                        .HasForeignKey("IdBreed")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Client", "Clients")
                        .WithMany("Pets")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breeds");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.User", "IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("UserRols")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UsersRols")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Navigation("LocationPerson");
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("CustomerPhones");

                    b.Navigation("LocationPerson");

                    b.Navigation("Pets");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("Departaments");
                });

            modelBuilder.Entity("Domain.Entities.Departament", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRols");
                });
#pragma warning restore 612, 618
        }
    }
}
