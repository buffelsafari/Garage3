using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IBookingService
    {
        Task<Booking> CheckinVehicle(CheckinVehicleArgs args, CancellationToken cancellationToken = default);

        Task<Receipt> CheckoutVehicle(string plateNumber, CancellationToken cancellationToken = default);
    }

    public class CheckinVehicleArgs
    {
        public string PlateNumber { get; set; }

        public string OwnersPersonalNumber { get; set; }

        public List<string> ParkingLotNumbers { get; set; } = new List<string>();
    }
}