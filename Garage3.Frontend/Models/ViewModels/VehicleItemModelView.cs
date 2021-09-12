using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Models.ViewModels
{
    public class VehicleItemModelView
    {
        public int VehicleId { get; set; }
        public string Owner { get; set; }
        public string MemberShip { get; set; }
        public string ParkedTime { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }
    }
}
