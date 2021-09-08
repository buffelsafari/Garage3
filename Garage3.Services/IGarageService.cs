using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IGarageService
    {
        Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival, CancellationToken cancellationToken = default);


        Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(string plateNumber, CancellationToken cancellationToken = default);


        Task<IEnumerable<ParkingLot>> GetParkingLots(string garageName, DateTime pointInTime, CancellationToken cancellationToken = default);
    }
}