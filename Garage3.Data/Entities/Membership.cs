using System.Collections;
using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class Membership
    {
        public virtual MembershipType MembershipType { get; set; }
        
        public virtual ICollection<VehicleTypeRate> VehicleTypes { get; set; }

    }
}