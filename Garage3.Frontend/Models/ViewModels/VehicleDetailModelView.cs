using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Models.ViewModels
{
    public class VehicleDetailModelView
    {

        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public string Type { get; set; }

        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string MembershipType { get; set; }
        
    }
}


