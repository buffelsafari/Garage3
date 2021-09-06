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
    class ReceiptMap : EntityMap<Receipt>
    {
        public override void Map(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipts");

            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Sum).IsRequired();

            builder.HasOne(p => p.ParkEvent).WithOne(p=>p.Receipt);
        }
    }
}
