using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class VehicleType : Entity
    {
        public virtual int AmountPlaces { get; set; }
        public virtual decimal BasicFee { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Membership> VehicleTypeRates { get; set; }
    }
}