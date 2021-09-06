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
    class MembershipTypeMap : EntityMap<MembershipType>
    {
        public override void Map(EntityTypeBuilder<MembershipType> builder)
        {
            builder.ToTable("MembershipTypes");

            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);

            builder.Property(p => p.Level).IsRequired();

            builder.HasMany(p => p.Memberships).WithOne(p => p.MembershipType);
        }
    }
}
