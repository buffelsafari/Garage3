using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Garage3.Data.Entities
{
    public class Vehicle : Entity
    {
            public virtual string Model { get; set; }

            public virtual string Manufacturer { get; set; }

            public virtual string PlateNumber { get; set; }

            public virtual int Wheels { get; set; }
            
            public virtual ParkTime ParkTime { get; set; }
            
            public virtual ICollection<VehicleType> Type { get; set; }
    }
}