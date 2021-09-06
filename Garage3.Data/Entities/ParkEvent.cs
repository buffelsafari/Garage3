using System;
using System.Collections.Generic;

#nullable enable
namespace Garage3.Data.Entities
{
    public class ParkEvent : Entity
    {
        public virtual DateTime ArrivalTime { get; set; }
        public virtual DateTime DepartureTime { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual ICollection<ParkingLot> ParkingLots { get; set; }
    }
}