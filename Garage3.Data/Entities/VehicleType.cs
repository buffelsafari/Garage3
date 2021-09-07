using System;
using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class VehicleType : Entity
    {
        public virtual string Name { get; set; }

        public virtual int RequiredParkingLots { get; set; }

        public virtual decimal BasicFee { get; set; }

        public virtual Garage Garage { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }

}