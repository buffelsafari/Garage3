using Garage3.Data;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly GarageContext _context;

        public VehicleService(GarageContext context)
        {
            _context = context;
        }

        public Vehicle RegisterVehicle(string plateNumber, string modelName, VehicleType vehicleType, string personalNumber)
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetVehicle(string plateNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}