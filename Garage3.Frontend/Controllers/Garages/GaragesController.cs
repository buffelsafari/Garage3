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
        private IVehicleService vehicleService;
        public GaragesController(IGarageService garageService, IVehicleTypeService vehicleTypeService, IVehicleService vehicleService)
        {
            this.garageService = garageService;
            this.vehicleTypeService = vehicleTypeService;
            this.vehicleService = vehicleService;
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

            IEnumerable<Vehicle> vehicles = await vehicleService.FindVehicles(
                new FindVehicleArgs
                {
                    
                });






            var garages = await garageService.FindGarages(new FindGarageArgs {GarageId=id});
            Garage garage = garages.First();

            GarageOverviewModelView model = new GarageOverviewModelView
            {
                GarageId=(int)id, 
                GarageName=garage.Name,
                TableHead = new string[]{"PlateNumber", "Owner", "Membership", "VehicleType", "ParkedTime" },  //todo make constant
                
            };
            

            return View(CreateModel(vehicles, model));
        }


        public async Task<IActionResult> Search(GarageOverviewModelView viewModel)
        {
            IEnumerable<Vehicle> vehicles = await vehicleService.FindVehicles(
                new FindVehicleArgs
                {
                    Manufacturer = viewModel.Manufacturer,
                    Model = viewModel.Model,
                    OwnersPersonalNumber = viewModel.OwnersPersonalNumber,
                    PlateNumber = viewModel.PlateNumber,
                    VehicleTypeName = viewModel.VehicleTypeName,
                    Wheels = viewModel.Wheels,
                    Color = viewModel.Color
                });


            return View(nameof(GarageOverview), CreateModel(vehicles, viewModel));
        }

        private GarageOverviewModelView CreateModel(IEnumerable<Vehicle> vehicles, GarageOverviewModelView viewModel)
        {
            List<VehicleItemModelView> vehiclesModel = new List<VehicleItemModelView>();
            foreach (Vehicle v in vehicles)
            {
                vehiclesModel.Add(new VehicleItemModelView
                {
                    VehicleId = v.Id,
                    PlateNumber = v.PlateNumber,
                    Owner = v.Owner != null ? v.Owner.FirstName : "-",
                    ParkedTime = "ph timeSpan",
                    VehicleType = v.VehicleType != null ? v.VehicleType.Name : "-"

                });
            }


            GarageOverviewModelView model = new GarageOverviewModelView
            {
                GarageId = viewModel.GarageId,
                GarageName = viewModel.GarageName,
                TableHead = new string[] { "PlateNumber", "Owner", "Membership", "VehicleType", "ParkedTime" },
                Vehicles = vehiclesModel,
            };


            return model;
        }
          

    

   

        public async Task<string> OnNewVehicleTypeButton(int id)
        {
            var gar = await garageService.FindGarages(new FindGarageArgs { GarageId = id });

            var model=gar.Select(g => new { GarageId = id, GarageName = g.Name }).First();
                       

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
