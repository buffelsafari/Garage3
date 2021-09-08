using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IVehicleTypeService
    {
        Task<VehicleType> RegisterVehicleType(NewVehicleTypeArgs args, CancellationToken cancellationToken = default);
    }

    public class NewVehicleTypeArgs
    {
        public string Name { get; set; }

        public int RequiredParkingLots { get; set; }

        public decimal BasicFee { get; set; }

        public int GarageId { get; set; }
    }
}