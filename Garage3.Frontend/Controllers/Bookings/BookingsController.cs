using Garage3.Data.Entities;
using Garage3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Controllers.Bookings
{
    public class BookingsController : Controller
    {
        private IBookingService bookingService;
        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        public async Task<IActionResult> Index()
        {
            CheckinVehicleArgs args = new CheckinVehicleArgs();

            return View();
        }

    }    
}
