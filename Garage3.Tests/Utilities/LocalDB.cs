using System;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Tests.Utilities
{
    public class LocalDb<TContext> : Database<TContext> where TContext : DbContext
    {
        private DbContextOptions<TContext> _options;

        protected override void Configure()
        {
            _options = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer($@"Server=(localdb)\mssqllocaldb;Database={DbName};ConnectRetryCount=0")
                .Options;
        }

        public override TContext CreateContext()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), _options);
        }
    }
}