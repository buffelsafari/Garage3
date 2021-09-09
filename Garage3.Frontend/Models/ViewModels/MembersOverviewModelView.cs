using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Models.ViewModels
{
    public class MembersOverviewModelView
    {
        
        public string PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MembershipType { get; set; }

        // vehicleCollection

        public IEnumerable<string> TableHead { get; set; }
        public IEnumerable<MemberItemModelView> Members { get; set; }

    }
}
