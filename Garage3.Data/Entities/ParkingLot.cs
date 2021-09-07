﻿using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class ParkingLot : Entity
    {
        public virtual int Number { get; set; }

        public virtual string Section { get; set; }

        public virtual bool Occupied { get; set; }

        public virtual Garage Garage { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}