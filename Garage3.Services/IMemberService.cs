using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Garage3.Data.Entities;

namespace Garage3.Services
{
    public interface IMemberService
    {
        Task<Member> RegisterMember(RegisterMemberArgs args, CancellationToken cancellationToken = default);

        Task<IEnumerable<Member>> FindMembers(FindMemberArgs args, CancellationToken cancellationToken = default);
    }

    public class RegisterMemberArgs
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonalNumber { get; set; }

        public string MembershipTypeName { get; set; }
    }

    public class FindMemberArgs
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonalNumber { get; set; }
    }
}