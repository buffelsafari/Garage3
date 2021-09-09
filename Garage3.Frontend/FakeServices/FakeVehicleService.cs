using Garage3.Data.Entities;
using Garage3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage3.Frontend.FakeServices
{
    public class FakeVehicleService : IVehicleService
    {
        public async Task<IEnumerable<Vehicle>> FindVehicles(FindVehicleArgs args, CancellationToken cancellationToken = default)
        {

            IEnumerable<Vehicle> vehicleList = new List<Vehicle>()
            {
                new Vehicle
                {
                    Id=1,
                    Model="skrot",
                    Manufacturer="nisse",
                    PlateNumber="ABC123",
                    Wheels=4,
                    Owner=new Member
                    {
                        FirstName="Olle",
                        Surname="Berg",
                        PhoneNumber="123889977",
                        PersonalNumber="199912241234",
                        MembershipType=new MembershipType
                        { 
                            Name="Gold"
                        },
                        Vehicles=null
                    },
                    VehicleType=new VehicleType
                    {
                        Name="Car",
                        RequiredParkingLots=1,
                        BasicFee=(decimal)12.5,
                        Garage=null
                    },
                    Bookings=null,
                    Color=VehicleColor.Red                   
                
                },
                new Vehicle
                {
                    Id=2,
                    Model="skrot",
                    Manufacturer="anka",
                    PlateNumber="ABC123",
                    Wheels=4,
                    Owner=new Member
                    {
                        FirstName="Olle",
                        Surname="Berg",
                        PhoneNumber="123889977",
                        PersonalNumber="199912241234",
                        MembershipType=new MembershipType
                        {
                            Name="Gold"
                        },
                        Vehicles=null
                    },
                    VehicleType=new VehicleType
                    {
                        Name="Car",
                        RequiredParkingLots=1,
                        BasicFee=(decimal)8.5,
                        Garage=null
                    },
                    Bookings=null,
                    Color=VehicleColor.Green

                },
                new Vehicle
                {
                    Id=3,
                    Model="skrot",
                    Manufacturer="kalle",
                    PlateNumber="EFG345",
                    Wheels=4,
                    Owner=new Member
                    {
                        FirstName="Olle",
                        Surname="Berg",
                        PhoneNumber="123889977",
                        PersonalNumber="199912241234",
                        MembershipType=new MembershipType
                        {
                            Name="Gold"
                        },
                        Vehicles=null
                    },
                    VehicleType=new VehicleType
                    {
                        Name="Car",
                        RequiredParkingLots=1,
                        BasicFee=(decimal)13.5,
                        Garage=null
                    },
                    Bookings=null,
                    Color=VehicleColor.Blue

                }


            };
            

            return vehicleList;
        }

        public async Task<Vehicle> RegisterVehicle(RegisterVehicleArgs args, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("fake register of vehicle" + args);

            Vehicle v = new Vehicle
            {
                Id = 4,
                Model = "Wesla",
                Manufacturer = "Egon",
                PlateNumber = "EBI654",
                Wheels = 4,                
                Color = VehicleColor.Blue

            };

            return v;

        }
    }
}
