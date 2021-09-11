using Garage3.Data.Entities;
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
        private IVehicleTypeService vehicleTypeService;
        public GaragesController(IGarageService garageService, IVehicleTypeService vehicleTypeService)
        {
            this.garageService = garageService;
            this.vehicleTypeService = vehicleTypeService;
        }
        

        public async Task<IActionResult> Index()  
        {
            var garages = await garageService.FindGarages(new FindGarageArgs { });

            var model=garages.Select(g => new GaragesModelView 
            { 
                GarageId=g.Id,
                Name=g.Name,
                Description=g.Description,
                HourlyRate=g.BasicFee
            });
            

            return View(model);
        }


        public async Task<IActionResult> GarageOverview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var garages = await garageService.FindGarages(new FindGarageArgs {GarageId=id});
            Garage garage = garages.First();

            GarageOverviewModelView model = new GarageOverviewModelView
            {
                GarageId=(int)id, 
                GarageName=garage.Name,
                TableHead = new string[]{"PlateNumber", "Owner", "Membership", "VehicleType", "ParkedTime" },  //todo make constant
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
                GarageName="-Garage-Name-",  //todo get garage from id
                                
            };

            return JsonConvert.SerializeObject(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public string OnNewVehicleTypeSave(NewVehicleSaveData data)
        {

            vehicleTypeService.RegisterVehicleType(new NewVehicleTypeArgs
            {
                GarageId = data.Id,
                Name = data.Name,
                RequiredParkingLots = data.RequiredParkingLots,
                BasicFee = data.BasicFee,

            });
            
            // todo create a new vehicleType
            Debug.WriteLine("Garage Id:"+data.Id);
            Debug.WriteLine("Garage Item1:" + data.Name);
            Debug.WriteLine("Garage Item2:" + data.RequiredParkingLots);
            Debug.WriteLine("Garage Item2:" + data.BasicFee);


            var result = new
            {
                Success=true,
            };

            return JsonConvert.SerializeObject(result);
        }

      



        public class NewVehicleSaveData  // todo use modelviews
        { 
            public int Id { get; set; }
            public string Name { get; set; }
            public int RequiredParkingLots { get; set; }
            public decimal BasicFee { get; set; }
        }

        

    }
}
