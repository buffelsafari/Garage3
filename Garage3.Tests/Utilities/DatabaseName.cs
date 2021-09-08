using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Garage3.Tests.Utilities
{
    public class DatabaseName
    {
        private static int _counter = 0;

        private static readonly Regex Rgx = new Regex("[^a-zA-Z0-9]");

        public int Id { get; }

        public int ProcessId { get; }

        public string CurrentUser { get; }

        public DateTime Created { get; }

        public DatabaseName()
        {
            Id = Interlocked.Increment(ref _counter);
            ProcessId = Math.Abs(Environment.ProcessId);
            CurrentUser = Rgx.Replace(Environment.UserName, "_");
            Created = DateTime.Now;
        }

        public override string ToString()
        {
            var time = Created.ToString("ddd_dd_MMM_yyyyTHHmmss_fff", new CultureInfo("en-US"));
            return $"{CurrentUser}_{time}_{ProcessId}_{Id}";
        }
    }
}
