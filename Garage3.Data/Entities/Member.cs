using System.Collections;
using System.Collections.Generic;

namespace Garage3.Data.Entities
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }


        public ICollection<Membership> Memberships { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }

}