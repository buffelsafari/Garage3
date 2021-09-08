using Garage3.Frontend.Models.ViewModels;
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




        /// <summary>
        /// triggers when details button is clicked
        /// </summary>
        /// <param name="id">the Vehicle id</param>
        /// <returns>json with vehicle data</returns>
        public string OnVehicleDetailsButton(int id)  // todo move to vehicle controller
        {
            // todo find vehicle from id

            VehicleDetailModelView model = new VehicleDetailModelView
            {
                PlateNumber = "EFG123",
                Model = "911",
                Manufacturer = "Porsche",
                Wheels = 4,
                Type = "Car",
                OwnerName = "Stig",
                OwnerId = 1
            };

            return JsonConvert.SerializeObject(model);
        }

        public string OnVehicleEditButton(int id)  // todo maybe refactor with above
        {
            // todo find vehicle from id

            VehicleDetailModelView model = new VehicleDetailModelView
            {
                PlateNumber = "EFG123",
                Model = "911",
                Manufacturer = "Porsche",
                Wheels = 4,
                Type = "Car",
                OwnerName = "Stig",
                OwnerId = 1
            };

            return JsonConvert.SerializeObject(model);
        }


        public string OnVehicleCheckoutButton(int id)   
        {
            // todo find vehicle from id
            var model = new
            {
                VehicleId=id,
                item1 = 1,
                item2 = 2,
                item3 = 3
            };            

            return JsonConvert.SerializeObject(model);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string OnEditSave(EditSaveData data)
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
            public string Item1 { get; set; }
            public string Item2 { get; set; }
        }

        public class CheckoutData
        {
            public int Id { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
        }


    }
}
