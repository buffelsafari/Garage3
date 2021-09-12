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
        IMembershipTypeService membershipTypeService;
        public ViewService(IVehicleTypeService vehicleTypeService, IMembershipTypeService membershipTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
            this.membershipTypeService = membershipTypeService;
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

        public async Task<IEnumerable<SelectListItem>> GetMembershipTypes()
        {
            


            var typeList = membershipTypeService.GetMembershipTypes();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in await typeList)
            {
                items.Add(new SelectListItem(item.Name, item.Name, false, false));
            }


            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypes()
        {

            var typeList = vehicleTypeService.GetVehicleTypes();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in await typeList)
            {
                items.Add(new SelectListItem(item.Name, item.Name, false, false));
            }

                       

            return items;
        }


    }
}
