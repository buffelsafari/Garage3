﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly GarageContext context;
        public VehicleTypeService(GarageContext context)
        {
            this.context = context;
        }

        public async Task<VehicleType> RegisterVehicleType(NewVehicleTypeArgs args, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("the garage id at register vehicleType service "+args.GarageId);
            IQueryable<Garage> query = context.Garages;

            var garage = query.First(g => g.Id == args.GarageId);
            //Garage garage= context.Garages.Find(new FindGarageArgs { GarageId = args.GarageId });
            //context.Garages.Find(new FindGarageArgs { GarageId = args.GarageId });

            Debug.WriteLine("trying to create VehicleType");
            var vehicleType = context.CreateProxy<VehicleType>();

            vehicleType.Name = args.Name;
            vehicleType.RequiredParkingLots = args.RequiredParkingLots;
            vehicleType.BasicFee = args.BasicFee;
            vehicleType.Garage = garage;
            garage.VehicleTypes.Add(vehicleType);
            
            

            await context.VehicleTypes.AddAsync(vehicleType, cancellationToken);
            
            await context.SaveChangesAsync(cancellationToken);
            return vehicleType;
        }
        public async Task<IEnumerable<VehicleType>> GetVehicleTypes(CancellationToken cancellationToken = default)
        {
            return await context.VehicleTypes.ToListAsync(cancellationToken);           
        }
    }
}