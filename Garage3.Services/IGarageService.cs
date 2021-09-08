using System;
using System.Collections.Generic;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IGarageService
    {
        VehicleType RegisterVehicleType();

        IEnumerable<ParkingLot> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival);
        
        IEnumerable<ParkingLot> GetLotsForParkedVehicle(string plateNumber);

        IEnumerable<ParkingLot> GetParkingLots(string garageName, DateTime pointInTime);

        bool Unpark(string plateNumber);
    }
}