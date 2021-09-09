using Garage3.Data.Entities;
using Garage3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage3.Frontend.FakeServices
{
    public class FakeGarageService : IGarageService
    {
        public Task<IEnumerable<Garage>> FindGarages(FindGarageArgs args, CancellationToken cancellationToken = default)
        {            
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(string plateNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParkingLot>> GetParkingLots(string garageName, DateTime pointInTime, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
