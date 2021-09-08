using Garage3.Data;
using NUnit.Framework;

namespace Garage3.Tests.Utilities
{
    [TestFixture]
    public abstract class SetupFixture
    {
        protected abstract Database<GarageContext> ContextManager { get; set; }

        protected abstract void Configure();

        /// <summary>
        /// Runs (ones) before all testcases executes
        /// </summary>
        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            // Configure db provider to either use sqlite(inmemory) or localdb
            // and set ContextManager
            Configure();

            ContextManager.CreateDB();
        }

        /// <summary>
        /// Runs (ones) after all testcases have finished executing 
        /// </summary>
        [OneTimeTearDown]
        public virtual void OneTimeTearDown() 
        {
            // Cleanup DB
            ContextManager.Dispose();
        }

        /// <summary>
        /// Runs before each testcase
        /// </summary>
        [SetUp]
        public virtual void Setup()
        {

        }

        /// <summary>
        /// Runs after each test case
        /// </summary>
        [TearDown]
        public virtual void TearDown()
        {

        }
    }
}