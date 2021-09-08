using System.Threading.Tasks;
using Garage3.Data;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public class MemberService : IMemberService
    {
        private readonly GarageContext _context;

        public MemberService(GarageContext context)
        {
            _context = context;
        }

        public async Task<Member> RegisterMember(string plateNumber, string personalNumber, string firstName, string lastName, string phoneNumber)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Member> GetMember(string personalNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}