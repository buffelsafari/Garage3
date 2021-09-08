using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Services
{
    public interface IGarageService
    {
        Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival, CancellationToken cancellationToken = default);


        Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(string plateNumber, CancellationToken cancellationToken = default);


        Task<IEnumerable<ParkingLot>> GetParkingLots(string garageName, DateTime pointInTime, CancellationToken cancellationToken = default);


        Task<IEnumerable<Garage>> FindGarages(FindGarageArgs args, CancellationToken cancellationToken = default);
    }

    public class GarageService : IGarageService
    {
        private readonly GarageContext _ctx;

        public GarageService(GarageContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(string plateNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParkingLot>> GetParkingLots(string garageName, DateTime pointInTime, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Garage>> FindGarages(FindGarageArgs args, CancellationToken cancellationToken = default)
        {
            IQueryable<Garage> query = _ctx.Garages;

            if (!String.IsNullOrWhiteSpace(args.GarageName))
                query = query.Where(x => x.Name.Contains(args.GarageName));

            if(args.Id is > 0)
                query = query.Where(x => x.Id == args.Id.Value);

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }
    }

    public class FindGarageArgs
    {
        public string GarageName { get; set; }

        public int? Id { get; set; }
    }
}