using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garage3.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private GarageContext context; 
        public VehicleService(GarageContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Vehicle>> FindVehicles(FindVehicleArgs args, CancellationToken cancellationToken = default)
        {
            //args.Color;
            //args.Model;
            //args.OwnersPersonalNumber;
            //args.PlateNumber;
            //args.VehicleTypeName;
            //args.Wheels;
            //args.Manufacturer;

            bool plateOption = !String.IsNullOrWhiteSpace(args.PlateNumber);

            return await context.Vehicles.Where(v => !plateOption || v.PlateNumber.Contains(args.PlateNumber)).ToListAsync(); //todo rest of the search


        }

        public async Task<Vehicle> RegisterVehicle(RegisterVehicleArgs args, CancellationToken cancellationToken = default)
        {            
            Vehicle vehicle = context.Vehicles.CreateProxy<Vehicle>();
            vehicle.PlateNumber = args.PlateNumber;
            vehicle.Manufacturer = args.Manufacturer;
            vehicle.Model = args.Model;
            vehicle.Color = VehicleColor.Blue;            //todo add color to args
            vehicle.Owner = null;

            context.Vehicles.Add(vehicle);

            await context.SaveChangesAsync();
            return vehicle;
            
        }
    }
}
