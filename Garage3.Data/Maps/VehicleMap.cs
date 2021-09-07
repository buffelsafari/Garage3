using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Data.Maps
{
    public class VehicleMap : EntityMap<Vehicle>
    {
        public override void Map(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.Property(p => p.Wheels)
                .IsRequired();

            builder
                .Property(p => p.Model)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(p => p.Manufacturer)
                .IsRequired()
                .HasMaxLength(128);


            builder
                .Property(p => p.PlateNumber)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .HasIndex(p => p.PlateNumber)
                .IsUnique();

            builder
                .HasOne(p => p.VehicleType)
                .WithMany(p => p.Vehicles);


            builder
                .HasMany(p => p.Bookings)
                .WithOne(p => p.Vehicle);

            builder
                .HasOne(p => p.Owner)
                .WithMany(p => p.Vehicles);
        }
    }
}
