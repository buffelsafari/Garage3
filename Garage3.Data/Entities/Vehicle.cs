﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garage3.Data.Entities
{
    public class Vehicle : Entity
    {
        public virtual string Model { get; set; }

        public virtual string Manufacturer { get; set; }

        public virtual string PlateNumber { get; set; }

        public virtual int Wheels { get; set; }

        public virtual Member Owner { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public virtual ICollection<Booking> Bookings { get; } = new ObservableHashSet<Booking>();

        public virtual VehicleColor Color { get; set;}
    }
}