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
        public int Wheels { get; set; }        
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public int OwnerId { get; set; }

        // todo show bookings?
    }
}
