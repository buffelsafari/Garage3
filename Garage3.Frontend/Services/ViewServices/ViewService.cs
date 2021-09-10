using Garage3.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Services.ViewServices
{
    public class ViewService:IViewService
    {

        public IEnumerable<SelectListItem> GetVehicleColor()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (VehicleColor t in (VehicleColor[])Enum.GetValues(typeof(VehicleColor)))
            {
                items.Add(new SelectListItem(t.ToString(), t.ToString(), false, false));
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetMembershipTypes()
        {
            //todo inser real
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("fake gold", "1", false, false));
            items.Add(new SelectListItem("fake silver", "2", false, false));
            items.Add(new SelectListItem("fake bronze", "3", false, false));


            return items;
        }

        public IEnumerable<SelectListItem> GetVehicleTypes()
        {
            //todo inser real
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("fake Car", "1", false, false));
            items.Add(new SelectListItem("fake MotorCycle", "2", false, false));
            items.Add(new SelectListItem("fake X-wing", "3", false, false));


            return items;
        }


    }
}
