using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garage3.Data.Entities
{
    public class Garage : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal BasicFee { get; set; }

        public virtual ICollection<MembershipType> MembershipTypes { get; set; } = new ObservableHashSet<MembershipType>();

        public virtual ICollection<VehicleType> VehicleTypes { get; set; } = new ObservableHashSet<VehicleType>();

        public virtual ICollection<ParkingLot> ParkingLots { get; set; } = new ObservableHashSet<ParkingLot>();
    }
}
