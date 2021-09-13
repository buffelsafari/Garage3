using System;
using System.Collections.Generic;
using System.Linq;
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
        private static GarageContext _context;

        public static async Task InitAsync(IServiceProvider services)
        {
            using (var context = services.GetRequiredService<GarageContext>())
            {
                _context = context;
                _faker = new Faker(locale: "sv");

                if (context.Bookings.Any() || context.VehicleTypes.Any() || context.Garages.Any()
                    || context.Members.Any() || context.Receipts.Any() || context.Vehicles.Any() ||
                    context.ParkingLots.Any())
                {
                    // DROP TABLE
                }
                var memberships = InitMembershipTypes();

                var vehicleTypes = InitVehicleTypes().Result.ToList();
                var members = InitMembers(memberships).ToList();

                var receipts = InitReceipts().Result.ToList();
                var bookings = InitBookings(receipts).Result.ToList();
                var parkingLots = InitParkingLots(bookings).Result.ToList();
                var garages = InitGarages(parkingLots, memberships);
                var vehicles = InitVehicles(members, bookings, vehicleTypes);

                await _context.SaveChangesAsync();
            }
        }
        
        private static async Task<IEnumerable<Receipt>> InitReceipts()
        {
            var receipts = new List<Receipt>();

            for (var i = 0; i < 20; i++)
            {
                var receipt = _context.Receipts.CreateProxy();
                receipt.Sum = 100;

                receipts.Add(receipt);
                await _context.Receipts.AddAsync(receipt);
            }

            await _context.SaveChangesAsync();

            return receipts;
        }

        private static async Task<IEnumerable<Booking>> InitBookings(ICollection<Receipt> receipts)
        {
            var bookings = new List<Booking>();

            for (var i = 0; i < 20; i++)
            {
                var booking = _context.Bookings.CreateProxy();
                booking.CheckinTime = DateTime.Now;
                booking.CheckedIn = true;
                booking.CheckedOut = false;
                booking.CheckoutTime = null;
                booking.Receipt = receipts.ElementAt(i);

                bookings.Add(booking);
                await _context.Bookings.AddAsync(booking);
            }

            await _context.SaveChangesAsync();

            return bookings;
        }

        private static IEnumerable<Member> InitMembers(ICollection<MembershipType> types)
        {
            var members = new List<Member>();

            for (var i = 0; i < 20; i++)
            {
                var member = _context.Members.CreateProxy();
                member.FirstName = _faker.Name.FirstName();
                member.Surname = _faker.Name.LastName();
                member.MembershipType = types.ElementAt(_faker.Random.Int(0, 1)); // Basic or Pro
                var personNummer = GeneratePersonnummer();
                while (_context.Members.Any(m => m.PersonalNumber == personNummer))
                {
                    personNummer = GeneratePersonnummer();
                }

                member.PersonalNumber = personNummer;

                member.PhoneNumber = _faker.Person.Phone;
                members.Add(member);
                _context.Members.Add(member);
            }

            return members;
        }

        private static string GeneratePersonnummer()
        {
            var year = _faker.Random.Int(1940, 2010);
            var month = _faker.Random.Int(1, 12);
            var day = _faker.Random.Int(1, 30);

            var number = _faker.Random.Int(0, 9999);

            return year + month.ToString() + day + number;
        }


        private static async Task<IEnumerable<Garage>> InitGarages(ICollection<ParkingLot> parkingLots,
            ICollection<MembershipType> membershipTypes)
        {
            var garages = new List<Garage>();
            for (var i = 0; i < 4; i++)
            {
                var garage = _context.Garages.CreateProxy();
                garage.Name = _faker.Company.CompanyName();
                garage.Description = _faker.Company.CatchPhrase();
                garage.BasicFee = 10 * (i + 1);
                garage.ParkingLots = parkingLots;
                garage.MembershipTypes = membershipTypes;

                garages.Add(garage);
                await _context.Garages.AddAsync(garage);
            }

            await _context.SaveChangesAsync();

            return garages;
        }

        private static async Task<IEnumerable<Vehicle>> InitVehicles(ICollection<Member> owners,
            IEnumerable<Booking> bookings,
            IEnumerable<VehicleType> type)
        {
            var vehicles = new List<Vehicle>();
            for (var i = 0; i < 20; i++)
            {
                var vehicle = _context.Vehicles.CreateProxy();
                vehicle.Model = _faker.Vehicle.Model();
                vehicle.Manufacturer = _faker.Vehicle.Manufacturer();
                vehicle.PlateNumber = _faker.Vehicle.Vin();
                vehicle.Wheels = _faker.Random.Int(2, 8);
                vehicle.Color = VehicleColor.Blue;
                vehicle.Bookings = bookings.ToList();
                vehicle.Owner = owners.ElementAt(i);
                vehicle.VehicleType = type.ElementAt(i);

                vehicles.Add(vehicle);

                await _context.Vehicles.AddAsync(vehicle);
            }

            await _context.SaveChangesAsync();

            return vehicles;
        }

        private static async Task<ICollection<VehicleType>> InitVehicleTypes()
        {
            var types = new List<VehicleType>();
            var car = _context.VehicleTypes.CreateProxy();
            car.Name = "Car";
            car.BasicFee = 10;
            car.RequiredParkingLots = 1;

            var truck = _context.VehicleTypes.CreateProxy();
            truck.Name = "Truck";
            truck.BasicFee = 20;
            truck.RequiredParkingLots = 4;

            await _context.VehicleTypes.AddAsync(car);
            await _context.VehicleTypes.AddAsync(truck);
            await _context.SaveChangesAsync();

            types.Add(car);
            types.Add(truck);

            return types;
        }

        private static ICollection<MembershipType> InitMembershipTypes()
        {
            var basic = _context.MembershipTypes.CreateProxy();
            basic.Name = "Basic";

            var pro = _context.MembershipTypes.CreateProxy();
            pro.Name = "Pro";

            _context.Add(basic);
            _context.Add(pro);
            _context.SaveChanges();

            var list = new List<MembershipType> {basic, pro};

            return list;
        }

        private static async Task<IEnumerable<ParkingLot>> InitParkingLots(ICollection<Booking> bookings)
        {
            var parkingLots = new List<ParkingLot>();
            for (var i = 0; i < 20; i++)
            {
                var lot = _context.ParkingLots.CreateProxy();
                lot.Bookings = bookings;
                lot.Number = i;
                lot.Section = _faker.Company.CompanyName()[..2].ToUpper();
                parkingLots.Add(lot);
                await _context.ParkingLots.AddAsync(lot);
            }

            await _context.SaveChangesAsync();

            return parkingLots;
        }
    }
}