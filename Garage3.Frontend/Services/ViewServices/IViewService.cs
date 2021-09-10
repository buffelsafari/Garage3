﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Services.ViewServices
{
    public interface IViewService
    {
        IEnumerable<SelectListItem> GetVehicleColor();
        IEnumerable<SelectListItem> GetMembershipTypes();
        IEnumerable<SelectListItem> GetVehicleTypes();
    }
}
