using Garage3.Frontend.Models.ViewModels;
using Garage3.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Controllers.Garages
{
    public class GaragesController : Controller
    {
        private IGarageService garageService;
        public GaragesController(IGarageService garageService)
        {
            this.garageService = garageService;
        }
        

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
                TableHead = new string[]{"PlateNumber", "Owner","Membership", "VehicleType", "ParkedTime" },  //todo make constant
                Vehicles=new VehicleItemModelView[] 
                {
                    new VehicleItemModelView
                    { 
                        VehicleId=1,
                        PlateNumber="ABC080",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=2,
                        PlateNumber="VIC0020",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=3,
                        PlateNumber="CMD064",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=4,
                        PlateNumber="FYI076",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
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
                TableHead = new string[] { "PlateNumber", "Owner","Membership", "VehicleType", "ParkedTime" },
                Vehicles = new VehicleItemModelView[]
                {
                    new VehicleItemModelView
                    {
                        VehicleId=1,
                        PlateNumber="ABC080",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=2,
                        PlateNumber="VIC0020",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=3,
                        PlateNumber="CMD064",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
                        VehicleType="Car"
                    },
                    new VehicleItemModelView
                    {
                        VehicleId=4,
                        PlateNumber="FYI076",
                        Owner="kalle Anka",
                        ParkedTime="12days,4hours,6min",                        
                        VehicleType="MotorCycle"
                    }
                }
            };



            return View(nameof(GarageOverview), model);
        }


          

    

   

        public string OnNewVehicleTypeButton(int id)
        {
            
            var model = new
            {
                GarageId = id,
                item1 = 1,
                item2 = 2,
                item3 = 3
            };

            return JsonConvert.SerializeObject(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public string OnNewVehicleTypeSave(NewVehicleSaveData data)
        {
            // todo create a new vehicleType
            Debug.WriteLine("Garage Id:"+data.Id);
            Debug.WriteLine("Garage Item1:" + data.Item1);
            Debug.WriteLine("Garage Item2:" + data.Item2);


            var result = new
            {
                Success=true,
            };

            return JsonConvert.SerializeObject(result);
        }

      



        public class NewVehicleSaveData  // todo use modelviews
        { 
            public int Id { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
        }

   


    }
}
