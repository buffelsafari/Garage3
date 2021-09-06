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
    class MembershipMap : EntityMap<Membership>
    {
        public override void Map(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("Membership");

            builder.HasMany(p => p.VehicleTypesRates)
               .WithMany(p => p.VehicleTypeRates)
               .UsingEntity<VehicleTypeRate>(
                   e => e.HasOne(e => e.VehicleType).WithMany(),
                   e => e.HasOne(e => e.Membership).WithMany());

            builder.HasOne(p => p.MembershipType).WithMany(p=>p.Memberships);

            builder.HasOne(p => p.Garage).WithMany(p => p.Memberships);

            

        }
    }
}
