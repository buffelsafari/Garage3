using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Tests.Utilities
{
    public class SqliteInMemoryDb<TContext> : Database<TContext> where TContext : DbContext
    {
        private DbContextOptions<TContext> _options;

        public DbConnection Connection { get; private set; }

        protected override void Configure()
        {
            Connection = new SqliteConnection("Filename=:memory:");

            _options = new DbContextOptionsBuilder<TContext>()
                .UseSqlite(Connection)
                .Options;
        }

        public override void CreateDB()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();

            base.CreateDB();
        }

        public override void Dispose()
        {
            Connection.Dispose();
        }

        public override TContext CreateContext()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), _options);
        }
    }
}