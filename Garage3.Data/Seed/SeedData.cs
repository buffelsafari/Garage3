using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Sweden;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Garage3.Data.Seed
{
    public class SeedData
    {
        private static Faker _faker;

        public static async Task InitAsync(IServiceProvider services)
        {
            await using var db = services.GetRequiredService<GarageContext>();
            if (await db.Garages.AnyAsync()) return;

            _faker = new Faker("sv");

            var vehicles = InitVehicles();
            await db.AddRangeAsync(vehicles);

            var bookings = InitBookings();
            await db.AddRangeAsync(bookings);
                
            var members = InitMembers();
            await db.AddRangeAsync(members);
                
            var vehicleTypes = InitVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);
                
            var membershipTypes = InitMembershipTypes();
            await db.AddRangeAsync(membershipTypes);
                
            var parkingLots = InitParkingLots();
            await db.AddRangeAsync(parkingLots);
                
            var garages = InitGarages();
            await db.AddRangeAsync(garages);

            await db.SaveChangesAsync();
        }

        private static IEnumerable<Booking> InitBookings()
        {
            var bookings = new List<Booking>();

            for (var i = 0; i < 20; i++)
            {
                var booking = new Booking()
                {
                    CheckinTime = DateTime.Now,
                    CheckedIn = true,
                    CheckedOut = false,
                };
                bookings.Add(booking);
            }

            return bookings;
        }

        private static IEnumerable<Member> InitMembers()
        {
            var members = new List<Member>();

            for (var i = 0; i < 20; i++)
            {
                var member = new Member()
                {
                    FirstName = _faker.Person.FirstName,
                    Surname = _faker.Person.LastName,
                    PhoneNumber = _faker.Person.Phone,
                    PersonalNumber = _faker.Person.Personnummer()
                    
                };
                members.Add(member);
            }

            return members;
        }

        private static IEnumerable<Garage> InitGarages()
        {
            var garages = new List<Garage>();

            for (var i = 0; i < 4; i++)
            {
                var garage = new Garage()
                {
                    Name = _faker.Company.CompanyName(),
                    Description = _faker.Company.CatchPhrase()
                };
                garages.Add(garage);
            }

            return garages;
        }

        private static IEnumerable<Vehicle> InitVehicles()
        {
            var vehicles = new List<Vehicle>();

            for (var i = 0; i < 20; i++)
            {
                var vehicle = new Vehicle()
                {
                    Model = _faker.Vehicle.Model(),
                    Manufacturer = _faker.Vehicle.Manufacturer(),
                    PlateNumber = _faker.Vehicle.Vin(),
                    Wheels = _faker.Random.Int(2, 8),
                    
                };
                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        private static IEnumerable<VehicleType> InitVehicleTypes()
        {
            var car = new VehicleType()
            {
                Id = 1,
                Name = "Car",
                RequiredParkingLots = 1,
                BasicFee = 10
            };
            var truck = new VehicleType()
            {
                Id = 2,
                Name = "Truck",
                RequiredParkingLots = 4,
                BasicFee = 20
            };

            return new List<VehicleType> {car, truck};
        }

        private static IEnumerable<MembershipType> InitMembershipTypes()
        {
            var basic = new MembershipType()
            {
                Id = 1,
                Name = "Basic"
            };

            var pro = new MembershipType()
            {
                Id = 2,
                Name = "Pro"
            };

            return new List<MembershipType> {basic, pro};
        }

        private static IEnumerable<ParkingLot> InitParkingLots()
        {
            var lots = new List<ParkingLot>();
            for (var i = 0; i < 20; i++)
            {
                var lot = new ParkingLot()
                {
                    Number = i,
                    Section = _faker.Company.CompanyName()[..2]
                };
                lots.Add(lot);
            }

            return lots;
        }
    }
}