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
    class ParkEventMap : EntityMap<ParkEvent>
    {
        public override void Map(EntityTypeBuilder<ParkEvent> builder)
        {
            builder.ToTable("ParkEvents");

            builder.Property(p => p.ArrivalTime).IsRequired();
            builder.Property(p => p.DepartureTime); // not set until departure
            
            builder.HasOne(p=>p.Receipt).WithOne(p=>p.ParkEvent);

            //builder.HasMany(p => p.ParkingLots).WithOne(p=>p.ParkEvent);

            builder.HasMany(p => p.ParkingLots)
                .WithMany(p => p.ParkEvents)
                .UsingEntity<ParkingStatus>(
                    e => e.HasOne(e => e.ParkingLot).WithMany(),
                    e => e.HasOne(e => e.ParkEvent).WithMany());



            builder.HasOne(p => p.Membership).WithMany(p => p.ParkEvents);
        }
    }
}
