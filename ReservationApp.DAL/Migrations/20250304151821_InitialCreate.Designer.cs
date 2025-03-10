﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservationApp.DAL.Models;

#nullable disable

namespace ReservationApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250304151821_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReservationApp.DAL.Models.Reservation", b =>
                {
                    b.Property<long>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ReservationId"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .IsUnicode(false)
                        .HasColumnType("varchar(320)");

                    b.Property<bool?>("HiddenFromUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<byte?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)0);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ReservationId")
                        .HasName("PK__Reservat__B7EE5F24B9EDEE04");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("RestaurantId")
                        .HasName("PK__Restaura__87454C95A8FACA11");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.RestaurantHoliday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HolidayId"));

                    b.Property<DateOnly>("HolidayDate")
                        .HasColumnType("date");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("HolidayId")
                        .HasName("PK__Restaura__2D35D57A8773257F");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantHolidays");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.RestaurantOpenDay", b =>
                {
                    b.Property<int>("OpenDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpenDayId"));

                    b.Property<TimeOnly>("ClosingTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("OpeningTime")
                        .HasColumnType("time");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<byte>("WeekDay")
                        .HasColumnType("tinyint");

                    b.HasKey("OpenDayId")
                        .HasName("PK__Restaura__64C7ED10E86A0350");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantOpenDays");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<DateOnly?>("Birthdate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .IsUnicode(false)
                        .HasColumnType("varchar(320)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("PasswordHash")
                        .HasMaxLength(64)
                        .HasColumnType("varbinary(64)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CC4C4E85B694");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534E20A3016")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.UserAuthProvider", b =>
                {
                    b.Property<long>("AuthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AuthId"));

                    b.Property<string>("AuthProvider")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("AuthId")
                        .HasName("PK__UserAuth__12C15DD3DC9BF2AF");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuthProvider");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.Reservation", b =>
                {
                    b.HasOne("ReservationApp.DAL.Models.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Reservati__Resta__4E88ABD4");

                    b.HasOne("ReservationApp.DAL.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Reservati__UserI__4D94879B");

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.RestaurantHoliday", b =>
                {
                    b.HasOne("ReservationApp.DAL.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantHolidays")
                        .HasForeignKey("RestaurantId")
                        .IsRequired()
                        .HasConstraintName("FK__Restauran__Resta__30F848ED");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.RestaurantOpenDay", b =>
                {
                    b.HasOne("ReservationApp.DAL.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantOpenDays")
                        .HasForeignKey("RestaurantId")
                        .IsRequired()
                        .HasConstraintName("FK__Restauran__Resta__2E1BDC42");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.UserAuthProvider", b =>
                {
                    b.HasOne("ReservationApp.DAL.Models.User", "User")
                        .WithMany("UserAuthProviders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__UserAuthP__UserI__29572725");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.Restaurant", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("RestaurantHolidays");

                    b.Navigation("RestaurantOpenDays");
                });

            modelBuilder.Entity("ReservationApp.DAL.Models.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("UserAuthProviders");
                });
#pragma warning restore 612, 618
        }
    }
}
