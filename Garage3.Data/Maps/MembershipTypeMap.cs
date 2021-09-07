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
    public class MembershipTypeMap : EntityMap<MembershipType>
    {
        public override void Map(EntityTypeBuilder<MembershipType> builder)
        {
            builder.ToTable("MembershipTypes");

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .HasIndex(p => p.Name)
                .IsUnique();

            builder
                .HasOne(p => p.Garage)
                .WithMany(p => p.MembershipTypes);

            builder
                .HasMany(p => p.Members)
                .WithOne(p => p.MembershipType);
        }
    }
}
