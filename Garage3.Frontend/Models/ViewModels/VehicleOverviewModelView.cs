﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Models.ViewModels
{
    public class VehicleOverviewModelView
    {
                

        public IEnumerable<string> TableHead { get; set; }
        public IEnumerable<VehicleItemModelView> Vehicles { get; set; }

    }
}
