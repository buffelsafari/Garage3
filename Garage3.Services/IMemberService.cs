using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IMemberService
    {
        Member RegisterMember(string plateNumber, string personalNumber, string firstName, string lastName, string phoneNumber);

        Member GetMember(string personalNumber);
    }
}