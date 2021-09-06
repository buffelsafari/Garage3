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
    class MemberMap : EntityMap<Member>
    {
        public override void Map(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(64);
            builder.Property(p => p.PersonalNumber).IsRequired().HasMaxLength(64);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(64);

            builder.HasMany(p => p.Vehicles).WithOne(p => p.Owner);

            builder.HasMany(p => p.Memberships).WithOne(p=>p.Member);


        }
    }
}
