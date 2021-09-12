using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Models.ViewModels
{
    public class GarageOverviewModelView
    {
        public int GarageId { get; set; }

        public string GarageName { get; set; }


        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string OwnersPersonalNumber { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleTypeName { get; set; }
        public int Wheels { get; set; }
        public string Color { get; set; }



        public IEnumerable<string> TableHead { get; set; }
        public IEnumerable<VehicleItemModelView> Vehicles { get; set; }

    }
}
