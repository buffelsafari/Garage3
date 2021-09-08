using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IBookingService
    {
        Task<Booking> CheckinVehicle(MembershipType membershipType, string plateNumber, DateTime timeOfArrival, IEnumerable<string> parkingLotNumbers);

        Task<Receipt> CheckoutVehicle(string plateNumber);
    }
}