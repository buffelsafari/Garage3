using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garage3.Services
{
    public interface IMembershipTypeService
    {
        Task<MembershipType> CreateNewMembershipType(NewMemberShipTypeArgs args, CancellationToken cancellationToken = default);

        Task<IEnumerable<MembershipType>> FindMembershipTypes(FindMembershipTypeArgs args, CancellationToken cancellationToken = default);

        Task<IEnumerable<MembershipType>> GetMembershipTypes(CancellationToken cancellationToken = default);

        
    }

    public class NewMemberShipTypeArgs
    {
        public string Name { get; set; }

        public int GarageId { get; set; }
    }

    public class FindMembershipTypeArgs
    {
        public string Name { get; set; }

        public int GarageId { get; set; }
    }

    public class MembershipTypeService : IMembershipTypeService
    {
        GarageContext context;
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
           
            var mType = await context.MembershipTypes.ToListAsync();  //todo seaches

            return mType;
            //throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypes(CancellationToken cancellationToken = default)
        {
            return await context.MembershipTypes.ToListAsync(cancellationToken);

        }


    }

}