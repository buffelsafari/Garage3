using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(string plateNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParkingLot>> GetParkingLots(string garageName, DateTime pointInTime)
        {
            throw new NotImplementedException();
        }
    }
}