using Garage3.Data.Entities;
using Garage3.Frontend.Models.ViewModels;
using Garage3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Controllers.Vehicles
{
    public class VehiclesController:Controller
    {
        private IVehicleService vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Vehicle> vehicles = await vehicleService.FindVehicles(new FindVehicleArgs { });


            VehicleOverviewModelView model = new VehicleOverviewModelView
            {


                TableHead = new string[] { "PlateNumber", "Manufacturer", "VehicleType" },
                Vehicles = vehicles.Select(v => new VehicleItemModelView{ VehicleId = v.Id, PlateNumber=v.PlateNumber, Manufacturer=v.Manufacturer, VehicleType=v.VehicleType.Name })
            };


            return View(model);
        }


        public async Task<IActionResult> Search(VehicleOverviewModelView viewModel)
        {


            

            // todo search and sort
            Debug.WriteLine("hello from filtered search");

            VehicleOverviewModelView model = new VehicleOverviewModelView
            {
                
                TableHead = new string[] { "PlateNumber", "Manufacturer", "VehicleType" },
                Vehicles = new VehicleItemModelView[]
                {
                    new VehicleItemModelView
                    {
                        VehicleId=1,
                        PlateNumber="ABC080",
                        Manufacturer="Porsche2",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=2,
                        PlateNumber="VIC0020",
                        Manufacturer="Skoda2",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=3,
                        PlateNumber="CMD064",
                        Manufacturer="BMW2",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=4,
                        PlateNumber="FYI076",
                        Manufacturer="Honda2",
                        VehicleType="MotorCycle"
                    }
                }
            };



            return View(nameof(Index), model);
        }




    }
}
