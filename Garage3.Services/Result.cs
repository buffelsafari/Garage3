using System.Collections;
using Microsoft.Extensions.Primitives;

namespace Garage3.Services
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T ObjectResult { get; set; }
    }
}
