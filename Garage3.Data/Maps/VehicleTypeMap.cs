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
    class VehicleTypeMap : EntityMap<VehicleType>
    {
        public override void Map(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable("VehicleTypes");

            builder
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .HasIndex(p => p.Name)
                .IsUnique();

            builder
                .Property(p => p.BasicFee)
                .HasPrecision(18, 2)
                .IsRequired();

            builder
                .Property(p => p.RequiredParkingLots)
                .IsRequired();

            builder
                .HasMany(p => p.Vehicles)
                .WithOne(p => p.VehicleType);

            builder
                .HasOne(p => p.Garage)
                .WithMany(p => p.VehicleTypes);
        }
    }
}
