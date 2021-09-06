using System;
using System.Collections;

namespace Garage3.Data.Entities
{
    public class Receipt : Entity
    {
        public virtual DateTime Date { get; set; }
        public virtual decimal Sum { get; set; }
        public virtual ParkEvent ParkEvent { get; set; }
    }
}