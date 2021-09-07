using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage3.Data.Maps
{
    public class BookingMap : EntityMap<Booking>
    {
        public override void Map(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder
                .Property(p => p.CheckedIn)
                .IsRequired();

            builder
                .Property(p => p.CheckedOut)
                .IsRequired();

            builder
                .Property(p => p.CheckinTime);

            builder
                .Property(p => p.CheckoutTime);

            builder
                .HasOne(p => p.Vehicle)
                .WithMany(p => p.Bookings);

            builder
                .HasMany(p => p.ParkingLots)
                .WithMany(p => p.Bookings);
        }
    }
}