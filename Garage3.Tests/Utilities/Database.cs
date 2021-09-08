using System;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Tests.Utilities
{
    public abstract class Database<TContext> 
        where TContext : DbContext, IDisposable
    {
        public DatabaseName DbName { get; } = new DatabaseName();

        public Database()
        {
            Configure(); 
            CreateDB();
        }

        public virtual void Dispose()
        {
            DropDB();
        }

        public virtual void CreateDB()
        {
            using (var context = CreateContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public virtual void DropDB()
        {
            using (var context = CreateContext())
            {
                context.Database.EnsureDeleted();
            }
        }

        public override string ToString()
        {
            return GetType().Name + " - " + DbName.ToString();
        }

        protected abstract void Configure();

        public abstract TContext CreateContext();
    }
}
