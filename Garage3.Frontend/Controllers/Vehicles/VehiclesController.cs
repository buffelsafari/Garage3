using Garage3.Frontend.Models.ViewModels;
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

        public async Task<IActionResult> Index()
        {
            

            VehicleOverviewModelView model = new VehicleOverviewModelView
            {
                
                TableHead = new string[] { "PlateNumber", "Manufacturer", "VehicleType" },
                Vehicles = new VehicleItemModelView[]
                {
                    new VehicleItemModelView
                    {
                        VehicleId=1,
                        PlateNumber="ABC080",
                        Manufacturer="Porsche",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=2,
                        PlateNumber="VIC0020",
                        Manufacturer="Skoda",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=3,
                        PlateNumber="CMD064",
                        Manufacturer="BMW",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=4,
                        PlateNumber="FYI076",
                        Manufacturer="Honda",
                        VehicleType="MotorCycle"
                    }
                }
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
