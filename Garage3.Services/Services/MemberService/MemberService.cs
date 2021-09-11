using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garage3.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private GarageContext context;
        public MemberService(GarageContext context)
        {
            this.context = context;

            
        }

        public async Task<IEnumerable<Member>> FindMembers(FindMemberArgs args, CancellationToken cancellationToken = default)
        {

            return await context.Members.ToListAsync();//todo add search

        }

        public async Task<Member> RegisterMember(RegisterMemberArgs args, CancellationToken cancellationToken = default)
        {
            Member member = context.Members.CreateProxy<Member>();
            member.FirstName = args.FirstName;
            member.Surname = args.Surname;
            member.PersonalNumber = args.PersonalNumber;
            member.PhoneNumber = args.PhoneNumber;
            member.MembershipType = null;

            context.Members.Add(member);
            await context.SaveChangesAsync();
            return member;
        }









    }


    
}
