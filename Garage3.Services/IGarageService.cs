using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;
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