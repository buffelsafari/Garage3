using System;
using System.Collections;
using System.Collections.Generic;
using Garage3.Data.Entities;
using Microsoft.Extensions.Primitives;

namespace Garage3.Services
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T ObjectResult { get; set; }
    }

    public interface IMemberService
    {
        Member RegisterMember(string plateNumber, string personalNumber, string firstName, string lastName, string phoneNumber);

        Member GetMember(string personalNumber);
    }


    public interface IVehicleService
    {
        Vehicle RegisterVehicle(string plateNumber, string modelName, VehicleType vehicleType, string personalNumber);

        Vehicle GetVehicle(string plateNumber);
    }


    public interface IBookingService
    {
        Result<Booking> CheckinVehicle(MembershipType membershipType, string plateNumber, DateTime timeOfArrival,
            IEnumerable<string> parkingLotNumbers);

        Result<Receipt> CheckoutVehicle(string plateNumber);
    }
    
    public interface IGarageService
    {
        VehicleType RegisterVehicleType();

        IEnumerable<ParkingLot> GetAvailableParkingLots(string plateNumber, DateTime timeOfArrival);
        
        IEnumerable<ParkingLot> GetLotsForParkedVehicle(string plateNumber);

        IEnumerable<ParkingLot> GetParkingLots(string garageName, DateTime pointInTime);


        bool Unpark(string plateNumber);
    }
}
