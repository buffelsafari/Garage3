using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Garage3.Services
{
    public interface IGarageService
    {
        Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(GetAvailableParkingLotsArgs args, CancellationToken cancellationToken = default);


        Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(GetLotsForParkedVehicleArgs args, CancellationToken cancellationToken = default);


        Task<IEnumerable<ParkingLot>> GetParkingLots(GetParkingLotsArgs args, CancellationToken cancellationToken = default);


        Task<IEnumerable<Garage>> FindGarages(FindGarageArgs args, CancellationToken cancellationToken = default);
    }

    public class GarageService : IGarageService
    {
        private readonly GarageContext _ctx;

        public GarageService(GarageContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ParkingLot>> GetAvailableParkingLots(GetAvailableParkingLotsArgs args, CancellationToken cancellationToken = default)
        {
            DateTime pointInTime = DateTime.Now;

            if (args.PointInTime.HasValue && args.PointInTime.Value != default)
                pointInTime = args.PointInTime.Value;

            IQueryable<ParkingLot> query =
                from lot in _ctx.ParkingLots.Include(g => g.Garage)
                from booking in lot.Bookings
                where lot.Garage.Id == args.GarageId
                where !String.IsNullOrWhiteSpace(args.PlateNumber) && booking.Vehicle.PlateNumber == args.PlateNumber
                where args.VehicleId.HasValue && args.VehicleId > 0 && booking.Vehicle.Id == args.VehicleId
                where booking.CheckinTime >= pointInTime && (booking.CheckoutTime == null || booking.CheckoutTime <= args.PointInTime)
                select lot;


            // TODO finish up. Should really consider DTOs
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParkingLot>> GetLotsForParkedVehicle(GetLotsForParkedVehicleArgs args, CancellationToken cancellationToken = default)
        {
            DateTime pointInTime = DateTime.Now;

            if (args.PointInTime.HasValue && args.PointInTime.Value != default)
                pointInTime = args.PointInTime.Value;

            IQueryable<ParkingLot> query = 
                from lot in _ctx.ParkingLots.Include(g => g.Garage)
                from booking in lot.Bookings
                where !String.IsNullOrWhiteSpace(args.PlateNumber) && booking.Vehicle.PlateNumber == args.PlateNumber
                where args.VehicleId.HasValue && args.VehicleId > 0 && booking.Vehicle.Id == args.VehicleId
                where booking.CheckinTime >= pointInTime && (booking.CheckoutTime == null || booking.CheckoutTime <= args.PointInTime)
                select lot;

            List<ParkingLot> result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<ParkingLot>> GetParkingLots(GetParkingLotsArgs args, CancellationToken cancellationToken = default)
        {
            IQueryable<ParkingLot> query = _ctx.ParkingLots.Where(x => x.Garage.Id == args.GarageId);

            List<ParkingLot> result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Garage>> FindGarages(FindGarageArgs args, CancellationToken cancellationToken = default)
        {
            IQueryable<Garage> query = _ctx.Garages;

            if (!String.IsNullOrWhiteSpace(args.GarageName))
                query = query.Where(x => x.Name.Contains(args.GarageName));

            if(args.GarageId is > 0)
                query = query.Where(x => x.Id == args.GarageId.Value);

            List<Garage> result = await query.ToListAsync(cancellationToken);

            return result;
        }
    }

    public class FindGarageArgs
    {
        /// <summary>
        /// Optional free text search by garage name
        /// </summary>
        public string GarageName { get; set; }

        /// <summary>
        /// Optional. If you want a garage with a specific Id
        /// </summary>
        public int? GarageId { get; set; }
    }

    public class GetParkingLotsArgs
    {
        /// <summary>
        /// GarageId
        /// </summary>
        public int GarageId { get; set; }
    }

    public class GetLotsForParkedVehicleArgs
    {
        /// <summary>
        /// Optional vehicle plate number. must match exactly but not case sensitive
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Optional. If you want lots for where the vehicle with the specific id is parked
        /// </summary>
        public int? VehicleId { get; set; }

        /// <summary>
        /// Optional. To get where the lot is parked. Current time is assumed if omitted
        /// </summary>
        public DateTime? PointInTime { get; set; }
    }

    public class GetAvailableParkingLotsArgs
    {
        /// <summary>
        /// The garage Id of the garage you want available lots for
        /// </summary>
        public int GarageId { get; set; }

        /// <summary>
        /// Optional. Vehicle plate number. must match exactly but not case sensitive
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Optional. If you want lots for where the vehicle with the specific id will fit
        /// </summary>
        public int? VehicleId { get; set; }

        /// <summary>
        /// Optional. Current time is assumed if omitted
        /// </summary>
        public DateTime? PointInTime { get; set; }
    }
}