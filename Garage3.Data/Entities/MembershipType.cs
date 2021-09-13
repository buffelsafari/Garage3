using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garage3.Data.Entities
{
    public class MembershipType : Entity
    {
        public virtual string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new ObservableHashSet<Member>();

        public virtual Garage Garage { get; set; }
    }

}