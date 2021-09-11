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

            modelBuilder.HasDefaultSchema("Garage3");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageMap).Assembly);


            modelBuilder.Entity<Garage>().HasData(
                new Garage
                {
                    Id = 1,
                    Name = "SouthPark",
                    Description = "nice garage",
                    BasicFee = 10,

                },
                new Garage
                {
                    Id = 2,
                    Name = "NorthPark",
                    Description = "also nice garage",
                    BasicFee=20,
                },
                new Garage
                {
                    Id = 3,
                    Name = "WestPark",
                    Description = "Nice view",
                    BasicFee=30,
                },
                new Garage
                {
                    Id = 4,
                    Name = "EastPark",
                    Description = "Close to trainstation",
                    BasicFee=40
                }
                );
            
                       

             
            

        }
    }
}