using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantHoliday> RestaurantHolidays { get; set; }

    public virtual DbSet<RestaurantOpenDay> RestaurantOpenDays { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAuthProvider> UserAuthProviders { get; set; }

    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F24B9EDEE04");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HiddenFromUser).HasDefaultValue(false);
            entity.Property(e => e.Status).HasDefaultValue((byte)0);

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Reservations).HasConstraintName("FK__Reservati__Resta__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations).HasConstraintName("FK__Reservati__UserI__4D94879B");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454C95A8FACA11");
        });

        modelBuilder.Entity<RestaurantHoliday>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PK__Restaura__2D35D57A8773257F");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantHolidays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Restauran__Resta__30F848ED");
        });

        modelBuilder.Entity<RestaurantOpenDay>(entity =>
        {
            entity.HasKey(e => e.OpenDayId).HasName("PK__Restaura__64C7ED10E86A0350");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantOpenDays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Restauran__Resta__2E1BDC42");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C4E85B694");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserAuthProvider>(entity =>
        {
            entity.HasKey(e => e.AuthId).HasName("PK__UserAuth__12C15DD3DC9BF2AF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.UserAuthProviders).HasConstraintName("FK__UserAuthP__UserI__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
