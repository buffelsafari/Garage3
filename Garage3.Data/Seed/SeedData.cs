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
                var memberships = await InitMembershipTypes();

                var vehicleTypes = await InitVehicleTypes();
                var members = await InitMembers(memberships);

                //
                
                var bookings = await InitBookings();
                var receipts = await InitReceipts(bookings);

                var parkingLots = await InitParkingLots(bookings);
                var garages = await InitGarages(parkingLots, memberships);
                var vehicles = await InitVehicles(members, bookings, vehicleTypes);

                await _context.SaveChangesAsync();
            }
        }
        
        private static async Task<IEnumerable<Receipt>> InitReceipts(IEnumerable<Booking> bookings)
        {
            var receipts = new List<Receipt>();

            for (var i = 0; i < 20; i++)
            {
                var receipt = _context.Receipts.CreateProxy();
                receipt.Sum = 100;
                receipt.Booking = bookings.ElementAt(i);
                receipts.Add(receipt);
                await _context.Receipts.AddAsync(receipt);
            }

            await _context.SaveChangesAsync();

            return await Task.FromResult(receipts);
        }

        private static async Task<IEnumerable<Booking>> InitBookings()
        {
            var bookings = new List<Booking>();

            for (var i = 0; i < 20; i++)
            {
                var booking = _context.Bookings.CreateProxy();
                booking.CheckinTime = DateTime.Now;
                booking.CheckedIn = true;
                booking.CheckedOut = false;
                booking.CheckoutTime = null;
                

                bookings.Add(booking);
                await _context.Bookings.AddAsync(booking);
            }

            await _context.SaveChangesAsync();

            return await Task.FromResult(bookings);
        }

        private static async Task<IEnumerable<Member>> InitMembers(ICollection<MembershipType> types)
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

                await _context.Members.AddAsync(member);
            }

            return await Task.FromResult(members);
        }

        private static string GeneratePersonnummer()
        {
            var year = _faker.Random.Int(1940, 2010);
            var month = _faker.Random.Int(1, 12);
            var day = _faker.Random.Int(1, 30);

            var number = _faker.Random.Int(0, 9999);

            return year + month.ToString() + day + number;
        }


        private static async Task<IEnumerable<Garage>> InitGarages(IEnumerable<ParkingLot> parkingLots,
            ICollection<MembershipType> membershipTypes)
        {
            var garages = new List<Garage>();
            
            var garage = _context.Garages.CreateProxy();
            garage.Name = _faker.Company.CompanyName();
            garage.Description = _faker.Company.CatchPhrase();
            garage.BasicFee = 10;

            foreach (var parkingLot in parkingLots)
            {
                garage.ParkingLots.Add(parkingLot);
            }

            foreach (var mType in membershipTypes)
            {
                garage.MembershipTypes.Add(mType);
            }
            

            garages.Add(garage);
            await _context.Garages.AddAsync(garage);
            

            await _context.SaveChangesAsync();

            return await Task.FromResult(garages);
        }

        private static async Task<IEnumerable<Vehicle>> InitVehicles(IEnumerable<Member> owners,
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

                foreach (var booking in bookings)
                {
                    vehicle.Bookings.Add(booking);
                }
                
                vehicle.Owner = owners.ElementAt(i);
                vehicle.VehicleType = type.ElementAt(_faker.Random.Int(0,1));

                vehicles.Add(vehicle);

                await _context.Vehicles.AddAsync(vehicle);
            }

            await _context.SaveChangesAsync();

            return await Task.FromResult(vehicles);
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

            return await Task.FromResult(types);
        }

        private static async Task<ICollection<MembershipType>> InitMembershipTypes()
        {
            var basic = _context.MembershipTypes.CreateProxy();
            basic.Name = "Basic";

            var pro = _context.MembershipTypes.CreateProxy();
            pro.Name = "Pro";

            _context.Add(basic);
            _context.Add(pro);
            await _context.SaveChangesAsync();

            var list = new List<MembershipType> {basic, pro};

            return await Task.FromResult(list);
        }

        private static async Task<IEnumerable<ParkingLot>> InitParkingLots(IEnumerable<Booking> bookings)
        {
            var parkingLots = new List<ParkingLot>();
            for (var i = 0; i < 20; i++)
            {
                var lot = _context.ParkingLots.CreateProxy();
                foreach (var booking in bookings)
                {
                    lot.Bookings.Add(booking);
                }
                
                lot.Number = i;
                lot.Section = _faker.Company.CompanyName()[..2].ToUpper();
                parkingLots.Add(lot);
                await _context.ParkingLots.AddAsync(lot);
            }

            await _context.SaveChangesAsync();

            return await Task.FromResult(parkingLots);
        }
    }
}