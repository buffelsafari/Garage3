using Garage3.Frontend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}
