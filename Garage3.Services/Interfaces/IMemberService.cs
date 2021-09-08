using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IMemberService
    {
        Task<Member> RegisterMember(string plateNumber, string personalNumber, string firstName, string lastName, string phoneNumber, CancellationToken cancellationToken = default);

        Task<Member> GetMember(string personalNumber, CancellationToken cancellationToken = default);
    }
}