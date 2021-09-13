using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garage3.Data.Entities
{
    public class Garage : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal BasicFee { get; set; }

        public virtual ICollection<MembershipType> MembershipTypes { get; } = new ObservableHashSet<MembershipType>();

        public virtual ICollection<VehicleType> VehicleTypes { get;} = new ObservableHashSet<VehicleType>();

        public virtual ICollection<ParkingLot> ParkingLots { get; } = new ObservableHashSet<ParkingLot>();
    }
}
