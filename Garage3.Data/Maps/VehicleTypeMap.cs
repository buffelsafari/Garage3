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

            builder.Property(p => p.BasicFee).HasPrecision(18, 2).IsRequired();

            builder.Property(p => p.AmountPlaces).IsRequired();

            builder.HasMany(p => p.Vehicles).WithOne(p=>p.Type);

            //builder.HasMany(p => p.VehicleTypeRates).WithMany(p => p.VehicleTypesRates);
        }
    }
}
