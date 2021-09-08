using System;
using System.Collections.Generic;
using Garage3.Data;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public class GarageService : IGarageService
    {
        private readonly GarageContext _context;

        public GarageService(GarageContext context)
        {
            _context = context;
        }

        public VehicleType RegisterVehicleType()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkingLot> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkingLot> GetLotsForParkedVehicle(string plateNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkingLot> GetParkingLots(string garageName, DateTime pointInTime)
        {
            throw new NotImplementedException();
        }

        public bool Unpark(string plateNumber)
        {
            throw new NotImplementedException();
        }
    }
}