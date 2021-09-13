using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garage3.Data.Entities
{
    public class Member : Entity
    {
        public virtual string FirstName { get; set; }

        public virtual string Surname { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string PersonalNumber { get; set; }

        public virtual MembershipType MembershipType { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; } = new ObservableHashSet<Vehicle>();
    }

}