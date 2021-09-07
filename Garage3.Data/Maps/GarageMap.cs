using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage3.Data.Maps
{
    public class GarageMap : EntityMap<Garage>
    {
        public override void Map(EntityTypeBuilder<Garage> builder)
        {
            builder.ToTable("Garages");

            builder
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .HasIndex(p => p.Name)
                .IsUnique();

            builder
                .Property(p => p.Description)
                .HasMaxLength(1024);

            builder
                .HasMany(p => p.VehicleTypes)
                .WithOne(p => p.Garage);

            builder
                .HasMany(p => p.MembershipTypes)
                .WithOne(p => p.Garage);
        }
    }

}
