using System.Collections;
using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class Membership:Entity
    {
        public virtual MembershipType MembershipType { get; set; }
        
        public virtual ICollection<VehicleType> VehicleTypesRates { get; set; }

        public virtual Garage Garage { get; set; }

    }
}