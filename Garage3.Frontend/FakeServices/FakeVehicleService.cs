using Garage3.Data.Entities;
using Garage3.Services;
using System;
using System.Collections.Generic;
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
                    Owner=null,
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
                    Owner=null,
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
                    Owner=null,
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

        public Task<Vehicle> RegisterVehicle(RegisterVehicleArgs args, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
