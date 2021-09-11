using Garage3.Data.Entities;
using Garage3.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Services.ViewServices
{
    public class ViewService:IViewService
    {
        IVehicleTypeService vehicleTypeService; 
        public ViewService(IVehicleTypeService vehicleTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
        }

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

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypes()
        {
            
            var typeList=vehicleTypeService.GetVehicleTypes();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in await typeList)
            {
                items.Add(new SelectListItem(item.Name, item.Id.ToString(), false, false));
            }
            
            return items;
        }


    }
}
