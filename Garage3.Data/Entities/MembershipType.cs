using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class MembershipType:Entity
    {
        public virtual string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual Garage Garage { get; set; }
    }

}