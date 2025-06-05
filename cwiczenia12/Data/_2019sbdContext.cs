using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cwiczenia12.Models;

namespace cwiczenia12.Data;

public partial class _2019sbdContext : DbContext
{
    public _2019sbdContext()
    {
    }

    public _2019sbdContext(DbContextOptions<_2019sbdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cwiczenia12Client> Cwiczenia12Clients { get; set; }

    public virtual DbSet<Cwiczenia12ClientTrip> Cwiczenia12ClientTrips { get; set; }

    public virtual DbSet<Cwiczenia12Country> Cwiczenia12Countries { get; set; }

    public virtual DbSet<Cwiczenia12Trip> Cwiczenia12Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s31771");

        modelBuilder.Entity<Cwiczenia12Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("cwiczenia12_Client_pk");

            entity.ToTable("cwiczenia12_Client");

            entity.Property(e => e.Email).HasMaxLength(120);
            entity.Property(e => e.FirstName).HasMaxLength(120);
            entity.Property(e => e.LastName).HasMaxLength(120);
            entity.Property(e => e.Pesel).HasMaxLength(120);
            entity.Property(e => e.Telephone).HasMaxLength(120);
        });

        modelBuilder.Entity<Cwiczenia12ClientTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdTrip }).HasName("cwiczenia12_Client_Trip_pk");

            entity.ToTable("cwiczenia12_Client_Trip");

            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.RegisteredAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Cwiczenia12ClientTrips)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cwiczenia12_Client_Trip_Client");

            entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.Cwiczenia12ClientTrips)
                .HasForeignKey(d => d.IdTrip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cwiczenia12_Client_Trip_Trip");
        });

        modelBuilder.Entity<Cwiczenia12Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("cwiczenia12_Country_pk");

            entity.ToTable("cwiczenia12_Country");

            entity.Property(e => e.Name).HasMaxLength(120);

            entity.HasMany(d => d.IdTrips).WithMany(p => p.IdCountries)
                .UsingEntity<Dictionary<string, object>>(
                    "Cwiczenia12CountryTrip",
                    r => r.HasOne<Cwiczenia12Trip>().WithMany()
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("cwiczenia12_Country_Trip_Trip"),
                    l => l.HasOne<Cwiczenia12Country>().WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("cwiczenia12_Country_Trip_Country"),
                    j =>
                    {
                        j.HasKey("IdCountry", "IdTrip").HasName("cwiczenia12_Country_Trip_pk");
                        j.ToTable("cwiczenia12_Country_Trip");
                    });
        });

        modelBuilder.Entity<Cwiczenia12Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip).HasName("cwiczenia12_Trip_pk");

            entity.ToTable("cwiczenia12_Trip");

            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(220);
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
