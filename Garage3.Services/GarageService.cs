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
    public class GarageService : IGarageService
    {
        private readonly GarageContext _ctx;

        public GarageService(GarageContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(GetAvailableParkingLotsArgs args,
            CancellationToken cancellationToken = default)
        {
            var pointInTime = DateTime.Now;

            if (args.PointInTime.HasValue && args.PointInTime.Value != default)
                pointInTime = args.PointInTime.Value;

            var query =
                from lot in _ctx.ParkingLots.Include(g => g.Garage)
                from booking in lot.Bookings
                where lot.Garage.Id == args.GarageId
                where !string.IsNullOrWhiteSpace(args.PlateNumber) && booking.Vehicle.PlateNumber == args.PlateNumber
                where args.VehicleId.HasValue && args.VehicleId > 0 && booking.Vehicle.Id == args.VehicleId
                where booking.CheckinTime >= pointInTime && (booking.CheckoutTime == null || booking.CheckoutTime <= args.PointInTime)
                select lot;

            var result = await query.ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(GetLotsForParkedVehicleArgs args, CancellationToken cancellationToken = default)
        {
            var pointInTime = DateTime.Now;

            if (args.PointInTime.HasValue && args.PointInTime.Value != default)
                pointInTime = args.PointInTime.Value;

            var query = _ctx.ParkingLots.Include(g => g.Garage)
                .SelectMany(lot => lot.Bookings, (lot, booking) => new {lot, booking})
                .Where(t =>
                    !string.IsNullOrWhiteSpace(args.PlateNumber) && t.booking.Vehicle.PlateNumber == args.PlateNumber)
                .Where(t => args.VehicleId.HasValue && args.VehicleId > 0 && t.booking.Vehicle.Id == args.VehicleId)
                .Where(t =>
                    t.booking.CheckinTime >= pointInTime && (t.booking.CheckoutTime == null ||
                                                              t.booking.CheckoutTime <= args.PointInTime))
                .Select(t => t.lot);

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<ParkingLot>> GetParkingLots(GetParkingLotsArgs args, CancellationToken cancellationToken = default)
        {
            var query = _ctx.ParkingLots.Where(x => x.Garage.Id == args.GarageId);

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Garage>> FindGarages(FindGarageArgs args, CancellationToken cancellationToken = default)
        {
            IQueryable<Garage> query = _ctx.Garages;

            if (!string.IsNullOrWhiteSpace(args.GarageName))
                query = query.Where(x => x.Name.Contains(args.GarageName));

            if(args.GarageId is > 0)
                query = query.Where(x => x.Id == args.GarageId.Value);

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }
    }
}