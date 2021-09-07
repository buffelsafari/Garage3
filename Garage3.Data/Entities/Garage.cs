using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class Garage : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<MembershipType> MembershipTypes { get; set; }

        public virtual ICollection<VehicleType> VehicleTypes { get; set; }

        public virtual ICollection<ParkingLot> ParkingLots { get; set; }
    }
}
