﻿using System;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage3.Data.Maps
{
    public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Created)
                .IsRequired()
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Local));

            builder
                .Property(p => p.Timestamp)
                .IsRowVersion();

            Map(builder);
        }

        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }

}
