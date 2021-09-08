using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IVehicleService
    {
        Vehicle RegisterVehicle(string plateNumber, string modelName, VehicleType vehicleType, string personalNumber);

        Vehicle GetVehicle(string plateNumber);
    }
}