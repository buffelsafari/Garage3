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
        private readonly IVehicleTypeService vehicleTypeService;
        private readonly IMembershipTypeService membershipTypeService;
        public ViewService(IVehicleTypeService vehicleTypeService, IMembershipTypeService membershipTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
            this.membershipTypeService = membershipTypeService;
        }

        public IEnumerable<SelectListItem> GetVehicleColor()
        {
            return (from t in (VehicleColor[]) Enum.GetValues(typeof(VehicleColor)) select new SelectListItem(t.ToString(), t.ToString(), false, false)).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetMembershipTypes()
        {
            var typeList = membershipTypeService.GetMembershipTypes();

            return (from item in await typeList select new SelectListItem(item.Name, item.Name, false, false)).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypes()
        {

            var typeList = vehicleTypeService.GetVehicleTypes();

            return (from item in await typeList select new SelectListItem(item.Name, item.Name, false, false)).ToList();
        }
    }
}
