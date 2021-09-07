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
    class ParkingLotMap : EntityMap<ParkingLot>
    {
        public override void Map(EntityTypeBuilder<ParkingLot> builder)
        {
            builder.ToTable("ParkingLots");

            builder
                .Property(p => p.Number)
                .IsRequired();

            builder
                .Property(p => p.Section)
                .IsRequired();

            builder
                .Property(p => p.Occupied)
                .IsRequired();

            builder
                .HasOne(p => p.Garage)
                .WithMany(p => p.ParkingLots);

            builder
                .HasMany(p => p.Bookings)
                .WithMany(p => p.ParkingLots);

        }
    }
}
