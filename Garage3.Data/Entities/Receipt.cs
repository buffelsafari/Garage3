using System;
using System.Collections;

namespace Garage3.Data.Entities
{
    public class Receipt : Entity
    {
        public virtual decimal Sum { get; set; }

        public virtual Booking Booking { get; set; }
    }
}