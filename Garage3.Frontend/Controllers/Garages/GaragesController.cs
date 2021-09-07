using Garage3.Frontend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Controllers.Garages
{
    public class GaragesController : Controller
    {
        

        public async Task<IActionResult> Index()  
        {


            List<GaragesModelView> modelList = new List<GaragesModelView>{

                new GaragesModelView
                {
                    GarageId=1,
                    Name = "SouthPark",
                    Description = "The Greatest garage ever",
                    HourlyRate = 12
                },
                new GaragesModelView
                {
                    GarageId=2,
                    Name = "NorthPark",
                    Description = "The lesser evil",
                    HourlyRate = 8
                },
                new GaragesModelView
                {
                    GarageId=3,
                    Name = "WestPark",
                    Description = "Not the best",
                    HourlyRate = 4
                }, 
                new GaragesModelView
                {
                    GarageId=4,
                    Name = "EastPark",
                    Description = "Cheapest ever",
                    HourlyRate = 2
                }
            };


            return View(modelList);
        }


        public async Task<IActionResult> GarageOverview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GarageOverviewModelView model = new GarageOverviewModelView
            {
                GarageId=(int)id, 
                GarageName="Name of the garage",
                TableHead = new string[]{"PlateNumber", "Manufacturer", "VehicleType" },
                Vehicles=new VehicleItemModelView[] 
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


        public async Task<IActionResult> Search(GarageOverviewModelView viewModel)
        {

            // todo search and sort
            Debug.WriteLine("hello from filtered search");

            GarageOverviewModelView model = new GarageOverviewModelView
            {
                GarageId = viewModel.GarageId,
                GarageName=viewModel.GarageName,
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



            return View(nameof(GarageOverview), model);
        }


    }
}
