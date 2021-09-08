using System.Threading;
using System.Threading.Tasks;
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

        public async Task<Vehicle> RegisterVehicle(string plateNumber, string modelName, VehicleType vehicleType, string personalNumber, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Vehicle> GetVehicle(string plateNumber, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}