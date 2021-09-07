using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage3.Data.Maps
{
    public class MemberMap : EntityMap<Member>
    {
        public override void Map(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(p => p.PersonalNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasIndex(p => p.PersonalNumber)
                .IsUnique();


            builder
                .HasOne(p => p.MembershipType)
                .WithMany(p => p.Members);

            builder
                .HasMany(p => p.Vehicles)
                .WithOne(p => p.Owner);
        }
    }
}