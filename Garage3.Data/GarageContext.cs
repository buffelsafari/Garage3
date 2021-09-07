using System;
using Garage3.Data.Entities;
using Garage3.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Garage3.Data
{
    public class GarageContext : DbContext
    {
        public virtual DbSet<Garage> Garages { get; set; }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        
        public virtual DbSet<Receipt> Receipts { get; set; }

        public virtual DbSet<ParkingLot> ParkingLots { get; set; }

        public GarageContext(DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseChangeTrackingProxies()
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Garage3");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageMap).Assembly);
        }
    }
}