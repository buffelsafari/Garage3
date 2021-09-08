using System;
using System.Collections.Generic;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IBookingService
    {
        Result<Booking> CheckinVehicle(MembershipType membershipType, string plateNumber, DateTime timeOfArrival,
            IEnumerable<string> parkingLotNumbers);

        Result<Receipt> CheckoutVehicle(string plateNumber);
    }
}