using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Sweden;
using Garage3.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Garage3.Data
{
    public class SeedData
    {
        private static Faker _faker;

        internal static async Task InitAsync(IServiceProvider services)
        {
            await using var db = services.GetRequiredService<GarageContext>();
            // if (await db..AnyAsync()) return; // FIXME insert correct db-s

            _faker = new Faker("sv");
            
            var events = GetParkEvents();
            await db.AddRangeAsync(events);

            var parkingLots = GetParkingLots(events as IReadOnlyCollection<ParkEvent>);
            await db.AddRangeAsync(parkingLots);
            
            var garages = GetGarages(parkingLots as IReadOnlyCollection<ParkingLot>);
            await db.AddRangeAsync(garages);

            var vehicleTypes = GetVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);

            var vehicles = GetVehicles(parkingLots as IReadOnlyCollection<ParkingLot>, vehicleTypes as IReadOnlyCollection<VehicleType>);
            await db.AddRangeAsync(vehicles);

            var membershipTypes = GetMembershipTypes();
            await db.AddRangeAsync(membershipTypes);
            
            var memberships = GetMemberships(membershipTypes as IReadOnlyCollection<MembershipType>, vehicleTypes as IReadOnlyCollection<VehicleType>);
            await db.AddRangeAsync(memberships);
            
            var members = GetMembers(memberships as IReadOnlyCollection<Membership>, vehicles as IReadOnlyCollection<Vehicle>);
            await db.AddRangeAsync(members);

            await db.SaveChangesAsync();
        }
        
        /// <summary>
        ///          VEHICLE SEED START
        /// </summary>
        
        private static IEnumerable<Vehicle> GetVehicles(IReadOnlyCollection<ParkingLot> parkingLots, IReadOnlyCollection<VehicleType> vehicleTypes)
        {
            var vehicles = new List<Vehicle>();

            for (var i = 0; i < 20; i++)
            {
                var enrollment = new Vehicle()
                {
                    Model = _faker.Vehicle.Model(),
                    Manufacturer = _faker.Vehicle.Manufacturer(),
                    PlateNumber = _faker.Vehicle.Vin(),
                    Wheels = _faker.Random.Int(2, 8),
                    // Owner = members.ElementAt(_faker.Random.Int(0, len)),
                    ParkEvent = new ParkEvent()
                    {
                        ArrivalTime = DateTime.Now,
                        ParkingLots = new[] { parkingLots.ElementAt(i) },
                    },
                    Type = new[] {vehicleTypes.ElementAt(0)}
                };
                vehicles.Add(enrollment);
            }

            return vehicles;
        }

        private static IEnumerable<VehicleType> GetVehicleTypes()
        {
            var types = new List<VehicleType>();

            for (var i = 0; i < 20; i++)
            {
                var category = (VehicleCategory) _faker.Random.Int(0, 3);
                var type = new VehicleType()
                {
                    VehicleCategory = category,
                    AmountPlaces = 100,
                    BasicFee = 100
                };
                types.Add(type);
            }

            return types;
        }
        /// <summary>
        ///          VEHICLE SEED END
        /// </summary>

        
        /// <summary>
        ///          MEMBER SEED START
        /// </summary>
        private static IEnumerable<Member> GetMembers(IReadOnlyCollection<Membership> memberships,
            IReadOnlyCollection<Vehicle> vehicles)
        {
            var members = new List<Member>();

            for (var i = 0; i < 20; i++)
            {
                var member = new Member()
                {
                    Name = _faker.Person.FirstName,
                    Surname = _faker.Person.LastName,
                    PhoneNumber = _faker.Person.Phone,
                    PersonalNumber = _faker.Person.Personnummer(),
                    Memberships = new List<Membership>() { memberships.ElementAt(i) },
                    Vehicles = new List<Vehicle>() { vehicles.ElementAt(i) }
                };

                members.Add(member);
            }

            return members;
        }

        private static IEnumerable<Membership> GetMemberships(IReadOnlyCollection<MembershipType> membershipTypes,
            IReadOnlyCollection<VehicleType> vehicleTypes)
        {
            var memberships = new List<Membership>();

            for (var i = 0; i < 20; i++)
            {
                var memberType = membershipTypes.ElementAt(i);
                var membership = new Membership()
                {
                    MembershipType = memberType,
                };

                var vehicleTypeRate = new VehicleTypeRate()
                {
                    Fee = 50,
                    Membership = membership,
                    VehicleType = vehicleTypes.ElementAt(i)
                };

                membership.VehicleTypes = new List<VehicleTypeRate>() {vehicleTypeRate};

                memberships.Add(membership);
            }

            return memberships;
        }

        private static IEnumerable<MembershipType> GetMembershipTypes()
        {
            var types = new List<MembershipType>();

            for (var i = 0; i < 20; i++)
            {
                var type = i % 2 == 0 ? MembershipType.PRO : MembershipType.BASIC;
                types.Add(type);
            }

            return types;
        }

        /// <summary>
        ///          MEMBER SEED END
        /// </summary>
        ///
        
        
        
        /// <summary>
        ///          PARKING SEED START
        /// </summary>
        /// 
        private static IEnumerable<ParkingLot> GetParkingLots(IReadOnlyCollection<ParkEvent> events)
        {
            var lots = new List<ParkingLot>();

            for (var i = 0; i < 20; i++)
            {
                var lot = new ParkingLot()
                {
                    ParkEvents = new[] {events.ElementAt(i)},
                    Section = _faker.Address.StreetName()[..2],
                    Number = _faker.Random.Int(0, 20)
                };
                lots.Add(lot);
            }

            return lots;
        }
        
        private static IEnumerable<ParkEvent> GetParkEvents()
        {
            var events = new List<ParkEvent>();

            for (var i = 0; i < 20; i++)
            {
                var lot = new ParkEvent()
                {
                    ArrivalTime = DateTime.Now,
                };
                events.Add(lot);
            }

            return events;
        }
        
        /// <summary>
        ///          PARKING SEED END
        /// </summary>
        ///
        ///
        /// 
        private static IEnumerable<Garage> GetGarages(IReadOnlyCollection<ParkingLot> parkingLots)
        {
            var garages = new List<Garage>();

            for (var i = 0; i < 20; i++)
            {
                var garage = new Garage()
                {
                    Description = _faker.Company.CatchPhrase(),
                    HourlyRate = _faker.Random.Int(50),
                    Name = _faker.Company.CompanyName(),
                    ParkingLots = new[] {parkingLots.ElementAt(i)}
                };
                garages.Add(garage);
            }
            return garages;
        }
    }
}