using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> RegisterVehicle(string plateNumber, string modelName, VehicleType vehicleType, string personalNumber, CancellationToken cancellationToken = default);

        Task<Vehicle> GetVehicle(string plateNumber, CancellationToken cancellationToken = default);
    }
}