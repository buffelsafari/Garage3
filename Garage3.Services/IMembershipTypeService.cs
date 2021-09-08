using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IMembershipTypeService
    {
        Task<MembershipType> CreateNewMembershipType(NewMemberShipTypeArgs args, CancellationToken cancellationToken = default);
    }

    public class NewMemberShipTypeArgs
    {
        public string Name { get; set; }

        public int GarageId { get; set; }
    }
}