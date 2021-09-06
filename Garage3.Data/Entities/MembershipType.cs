using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class MembershipType:Entity
    {
        public virtual string Name { get; set; }

        public virtual MembershipTypeLevel Level { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }


    public enum MembershipTypeLevel
    {
        basic=0,
        pro=1
    }
}


