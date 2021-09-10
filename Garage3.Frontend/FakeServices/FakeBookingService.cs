using Garage3.Data.Entities;
using Garage3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage3.Frontend.FakeServices
{
    public class FakeBookingService : IBookingService
    {
        public Task<Booking> CheckinVehicle(CheckinVehicleArgs args, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Receipt> CheckoutVehicle(string plateNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
