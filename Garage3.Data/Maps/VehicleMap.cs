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
    class VehicleMap : EntityMap<Vehicle>
    {
        public override void Map(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.Property(p => p.Wheels).IsRequired();
            builder.Property(p => p.Model).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Manufacturer).IsRequired().HasMaxLength(64);
            builder.Property(p => p.PlateNumber).IsRequired().HasMaxLength(64);

            builder.HasOne(p => p.Type).WithMany(p=>p.Vehicles);

        }
    }
}
