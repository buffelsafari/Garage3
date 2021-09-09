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
           
            return View(CreateModel(vehicles));
        }


        public async Task<IActionResult> Search(VehicleOverviewModelView viewModel)
        {
            IEnumerable<Vehicle> vehicles = await vehicleService.FindVehicles(
                new FindVehicleArgs 
                {
                    Manufacturer=viewModel.Manufacturer,
                    Model=viewModel.Model,                    
                    OwnersPersonalNumber=viewModel.OwnersPersonalNumber,
                    PlateNumber=viewModel.PlateNumber,
                    VehicleTypeName=viewModel.VehicleTypeName,
                    Wheels=viewModel.Wheels,
                    Color=viewModel.Color
                });
          
            return View(nameof(Index), CreateModel(vehicles));
        }


        private VehicleOverviewModelView CreateModel(IEnumerable<Vehicle> vehicles)
        { 
            return new VehicleOverviewModelView  
            {
                TableHead = new string[] { "PlateNumber", "Manufacturer", "VehicleType" },
                Vehicles = vehicles.Select(v => new VehicleItemModelView { VehicleId = v.Id, PlateNumber = v.PlateNumber, Manufacturer = v.Manufacturer, VehicleType = v.VehicleType.Name })
            };
        }

        private async Task<Vehicle> GetVehicleFromId(int id)
        {
            IEnumerable<Vehicle> vehicles = await vehicleService.FindVehicles(
                new FindVehicleArgs
                {

                });
            return vehicles.Where(v => v.Id == id).First();
        }




        /// <summary>
        /// triggers when details button is clicked
        /// </summary>
        /// <param name="id">the Vehicle id</param>
        /// <returns>json with vehicle data</returns>
        public async Task<string> OnVehicleDetailsButton(int id)  // todo move to vehicle controller
        {
            

            

            Vehicle vehicle = await GetVehicleFromId(id);

            // todo exeptions
            VehicleDetailModelView model = new VehicleDetailModelView
            {
                PlateNumber=vehicle.PlateNumber,
                Model=vehicle.Model,
                Manufacturer=vehicle.Manufacturer,
                Color=vehicle.Color.ToString(),
                Wheels=vehicle.Wheels,
                Type=vehicle.VehicleType.Name,

                       
       
            };

            
            if (vehicle.Owner != null)
            {
                model.OwnerId = vehicle.Owner.Id;
                model.FirstName = vehicle.Owner.FirstName;
                model.Surname = vehicle.Owner.Surname;
                model.PhoneNumber = vehicle.Owner.PhoneNumber;
                model.PersonalNumber = vehicle.Owner.PersonalNumber; 
                
                if (vehicle.Owner.MembershipType != null)
                {
                    model.MembershipType = vehicle.Owner.MembershipType.Name;
                }

            }

            



            return JsonConvert.SerializeObject(model);
        }

        public async Task<string> OnVehicleEditButton(int id)  // todo maybe refactor with above
        {

            Vehicle vehicle = await GetVehicleFromId(id);



            VehicleEditModelView model = new VehicleEditModelView 
            {
                
                PlateNumber = vehicle.PlateNumber,
                Model = vehicle.Model,
                Manufacturer = vehicle.Manufacturer,
                Color=vehicle.Color.ToString(),
                Wheels = vehicle.Wheels,
                Type = vehicle.VehicleType.Name,
                                
            };

            return JsonConvert.SerializeObject(model);
        }


        public string OnVehicleCheckoutButton(int id)
        {
            // todo find vehicle from id
            var model = new
            {
                VehicleId = id,
                item1 = 1,
                item2 = 2,
                item3 = 3
            };

            return JsonConvert.SerializeObject(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public string OnEditSave(EditSaveData data)
        {
            //this.#vehicleId, plateNumber: plateNumber, model: model, manufacturer: manufacturer, color:color, wheels:wheels, type:type

            // edit the vehicle
            Debug.WriteLine("Vehicle Id:" + data.Id);
            Debug.WriteLine("PlateNumber:" + data.PlateNumber);
            Debug.WriteLine("Manufacturer:" + data.Manufacturer);
            Debug.WriteLine("Color:" + data.Color);
            Debug.WriteLine("Wheels:" + data.Wheels);
            Debug.WriteLine("Type:" + data.Type);


            


            var result = new
            {
                Success = true,
                Message = "Message from controller"
            };

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string OnCheckout(CheckoutData data)
        {
            // edit the vehicle
            Debug.WriteLine("Garage Id:" + data.Id);
            Debug.WriteLine("Garage Item1:" + data.Item1);
            Debug.WriteLine("Garage Item2:" + data.Item2);


            var result = new
            {
                Success = true,
            };

            return JsonConvert.SerializeObject(result);
        }




        public class NewVehicleSaveData  // todo use modelviews
        {
            public int Id { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
        }

        
        public class EditSaveData
        {
            public int Id { get; set; }
            public string PlateNumber { get; set; }
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string Color { get; set; }
            public int Wheels { get; set; }
            public string Type { get; set; }

        }

        public class CheckoutData
        {
            public int Id { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
        }


    }


}

