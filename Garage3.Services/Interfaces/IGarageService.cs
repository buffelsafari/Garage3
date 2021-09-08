using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IGarageService
    {
        Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival);


        Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(string plateNumber);


        Task<IEnumerable<ParkingLot>> GetParkingLots(string garageName, DateTime pointInTime);
    }
}