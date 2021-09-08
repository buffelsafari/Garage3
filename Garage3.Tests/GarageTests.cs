using System.IO;
using System.Reflection.Metadata;
using System.Reflection;
using NUnit.Framework;
using System.Linq;
using System;
using Garage3.Data;
using Garage3.Tests.Utilities;

namespace Garage3.Tests
{
    [TestFixture]
    public abstract class GarageTests : SetupFixture
    {
        protected override Database<GarageContext> ContextManager { get; set; }
    }

    [TestFixture]
    [Category("InMemory")]
    public class GarageInMemoryTests : GarageTests
    {
        protected override void Configure()
        {
            ContextManager = new SqliteInMemoryDb<GarageContext>();
        }
    }

    [TestFixture]
    [Category("LocalDB")]
    public class GarageLocalDbTests : GarageTests
    {
        protected override void Configure()
        {
            ContextManager = new LocalDb<GarageContext>();
        }
    }
}