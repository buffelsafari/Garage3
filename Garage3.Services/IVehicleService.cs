using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> RegisterVehicle(RegisterVehicleArgs args, CancellationToken cancellationToken = default);

        Task<IEnumerable<Vehicle>> FindVehicles(FindVehicleArgs args, CancellationToken cancellationToken = default);
    }

    

    public class RegisterVehicleArgs
    {
        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string PlateNumber { get; set; }

        public int Wheels { get; set; }

        public string VehicleTypeName { get; set; }
        public string Color { get; set; }
    }

    public class FindVehicleArgs
    {
        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string PlateNumber { get; set; }

        public int? Wheels { get; set; }

        public string OwnersPersonalNumber { get; set; }

        public string VehicleTypeName { get; set; }

        public string Color { get; set; }
    }
}