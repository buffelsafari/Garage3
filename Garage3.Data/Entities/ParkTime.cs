using System;

#nullable enable
namespace Garage3.Data.Entities
{
    public class ParkTime : Entity
    {
        public virtual DateTime From { get; set; }
        public virtual DateTime To { get; set; }
        public virtual Receipt Receipt { get; set; }

    }
}