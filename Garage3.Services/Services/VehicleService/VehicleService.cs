using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            bool manufacturerOption = !String.IsNullOrWhiteSpace(args.Manufacturer);
            bool modelOption = !String.IsNullOrWhiteSpace(args.Model);
            bool wheelsOption = args.Wheels>0;
            bool vehicleTypeOption = !String.IsNullOrWhiteSpace(args.VehicleTypeName);
            //bool colorOption = !String.IsNullOrWhiteSpace(args.Color);
            bool personalNumberOption = !String.IsNullOrWhiteSpace(args.OwnersPersonalNumber);

            VehicleColor color=0;
            bool colorOption = Enum.TryParse<VehicleColor>(args.Color, out color);

            
            
            Debug.WriteLine("the color is"+args.Color);



            return await context.Vehicles.Where(v =>(
                (!plateOption || v.PlateNumber.Contains(args.PlateNumber)))&&
                (!manufacturerOption || v.Manufacturer.Contains(args.Manufacturer))&&
                (!modelOption || v.Model.Contains(args.Model))&&
                (!wheelsOption || v.Wheels==args.Wheels)&&
                (!colorOption || v.Color==color)&&
                (!personalNumberOption || v.Owner.PersonalNumber.Contains(args.OwnersPersonalNumber)))

                .ToListAsync(); 
            
            
            //todo rest of the search


        }

        public async Task<Vehicle> RegisterVehicle(RegisterVehicleArgs args, CancellationToken cancellationToken = default)
        {
            
            var vType=context.VehicleTypes.Where(t=>t.Name==args.VehicleTypeName).First();


            Vehicle vehicle = context.Vehicles.CreateProxy<Vehicle>();
            vehicle.PlateNumber = args.PlateNumber;
            vehicle.Manufacturer = args.Manufacturer;
            vehicle.Model = args.Model;
            vehicle.Color = Enum.Parse<VehicleColor>(args.Color);          
            vehicle.Owner = null;
            vehicle.VehicleType = vType;
            vehicle.Wheels = args.Wheels;

            vType.Vehicles.Add(vehicle);

            context.Vehicles.Add(vehicle);

            await context.SaveChangesAsync();
            return vehicle;
            
        }

        public async Task<Vehicle> EditVehicle(EditVehicleArgs args, CancellationToken cancellationToken = default)
        {
            var vehicle = context.Vehicles.Where(v=>v.Id==args.Id).First();

            vehicle.Manufacturer = args.Manufacturer;
            vehicle.Model = args.Model;
            vehicle.PlateNumber = args.PlateNumber;
            vehicle.Color= Enum.Parse<VehicleColor>(args.Color);
            vehicle.Wheels = args.Wheels;            
            vehicle.VehicleType = context.VehicleTypes.Where(t => t.Name == args.VehicleTypeName).First();

            await context.SaveChangesAsync();
            return vehicle;

        }
    }
}
