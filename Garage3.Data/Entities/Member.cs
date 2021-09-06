using System.Collections;
using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class Member : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string PersonalNumber { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }

}