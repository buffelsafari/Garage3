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
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Vehicle>(v =>
            {

                v.HasOne(veh => veh.VehicleType)
                    .WithMany(c => c.Vehicles)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                v.HasOne(e => e.Owner)
                    .WithMany(o => o.Vehicles)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                v.HasMany<Booking>()
                    .WithOne(b => b.Vehicle)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            
            modelBuilder.Entity<Member>(m =>
            {
                m.HasOne(mem => mem.MembershipType)
                    .WithMany(t => t.Members)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                m.HasMany<Vehicle>()
                    .WithOne(v => v.Owner);
            });
            
            modelBuilder.Entity<Garage>(g =>
            {
                g.HasMany<MembershipType>()
                    .WithOne(t => t.Garage);
                
                g.HasMany<VehicleType>()
                    .WithOne(t => t.Garage);
                
                g.HasMany<ParkingLot>()
                    .WithOne(t => t.Garage);
            });
            
            modelBuilder.Entity<Booking>(b =>
            {
                b.HasMany<ParkingLot>()
                    .WithMany(p => p.Bookings);
                
                b.HasOne(book => book.Receipt)
                    .WithOne(r => r.Booking);
                
                b.HasOne(book => book.Vehicle)
                    .WithMany(r => r.Bookings);
            });
            

            modelBuilder.HasDefaultSchema("Garage3");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageMap).Assembly);
        }
    }
}