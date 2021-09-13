using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Services
{
    public class MembershipTypeService : IMembershipTypeService
    {
        private readonly GarageContext context;
        public MembershipTypeService(GarageContext context)
        {
            this.context = context;
        }

        public Task<MembershipType> CreateNewMembershipType(NewMemberShipTypeArgs args, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MembershipType>> FindMembershipTypes(FindMembershipTypeArgs args, CancellationToken cancellationToken = default)
        {
            var mType = await context.MembershipTypes.ToListAsync(cancellationToken);  //todo seaches
            return mType;
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypes(CancellationToken cancellationToken = default)
        {
            return await context.MembershipTypes.ToListAsync(cancellationToken);
        }
    }
}