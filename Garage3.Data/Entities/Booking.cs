using System;
using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class Booking : Entity
    {
        public virtual DateTime? CheckinTime { get; set; }

        public virtual DateTime? CheckoutTime { get; set; }

        public virtual bool CheckedIn { get; set; }

        public virtual bool CheckedOut { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual Receipt Receipt { get; set; }

        public virtual ICollection<ParkingLot> ParkingLots { get; set; }
    }
}