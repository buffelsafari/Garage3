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

            builder.HasMany(p => p.ParkEvents)
                .WithMany(p => p.ParkingLots)
                .UsingEntity<ParkingStatus>(
                    e => e.HasOne(e => e.ParkEvent).WithMany(),
                    e => e.HasOne(e => e.ParkingLot).WithMany());



            // .HasMany(s => s.Courses)
            //         .WithMany(c => c.Students)
            //         .UsingEntity<Enrollment>(
            //              e => e.HasOne(e => e.Course).WithMany(c => c.Enrollments),
            //              e => e.HasOne(e => e.Student).WithMany(s => s.Enrollments));

        }
    }
}
