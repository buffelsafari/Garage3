using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IVehicleTypeService
    {
        Task<VehicleType> RegisterVehicleType(CancellationToken cancellationToken = default);
    }
}