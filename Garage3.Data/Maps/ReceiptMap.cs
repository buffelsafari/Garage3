using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage3.Data.Maps
{
    public class ReceiptMap : EntityMap<Receipt>
    {
        public override void Map(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipts");

            builder
                .Property(p => p.Sum)
                .IsRequired()
                .HasPrecision(18,2);

            builder
                .HasOne(p => p.Booking)
                .WithOne(p => p.Receipt);
        }
    }
}