using Garage3.Data;
using Garage3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            

            bool personalNumberOption = !String.IsNullOrWhiteSpace(args.PersonalNumber);
            bool phoneNumberOption = !String.IsNullOrWhiteSpace(args.PhoneNumber);
            bool firstNameOption = !String.IsNullOrWhiteSpace(args.FirstName);
            bool surnameOption = !String.IsNullOrWhiteSpace(args.Surname);
            bool membershipTypeOption = !String.IsNullOrWhiteSpace(args.MembershipTypeName);

            

            var qu = context.Members.Where(m => 
                (!personalNumberOption || m.PersonalNumber.Contains(args.PersonalNumber))&&
                (!phoneNumberOption || m.PhoneNumber.Contains(args.PhoneNumber)) &&
                (!firstNameOption || m.FirstName.Contains(args.FirstName)) &&
                (!surnameOption || m.Surname.Contains(args.Surname)) &&
                
                ((!membershipTypeOption && m.MembershipType!=null) ||  m.MembershipType.Name.Equals(args.MembershipTypeName)) 
                
            );


            return await qu.ToListAsync();




           

        }

        public async Task<Member> RegisterMember(RegisterMemberArgs args, CancellationToken cancellationToken = default)
        {
            var type=context.MembershipTypes.Where(t => t.Name == args.MembershipTypeName).First();

            Member member = context.Members.CreateProxy<Member>();
            member.FirstName = args.FirstName;
            member.Surname = args.Surname;
            member.PersonalNumber = args.PersonalNumber;
            member.PhoneNumber = args.PhoneNumber;
            member.MembershipType = type;

            context.Members.Add(member);
            await context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> EditMember(EditMemberArgs args, CancellationToken cancellationToken = default)
        {
            var member = context.Members.Where(v => v.Id == args.Id).First();
            member.PersonalNumber = args.PersonalNumber;
            member.PhoneNumber = args.PhoneNumber;
            member.FirstName = args.FirstName;
            member.Surname = args.Surname;
            member.MembershipType = context.MembershipTypes.Where(t => t.Name == args.MembershipTypeName).First();
                       
            

            await context.SaveChangesAsync();
            return member;

        }

        public async Task<Vehicle> AddVehicleToMember(AddVehicleArgs args, CancellationToken cancellationToken = default)
        {
            Member member = context.Members.Where(m => m.Id == args.MemberId).First();
            Vehicle vehicle = context.Vehicles.Where(m => m.PlateNumber == args.PlateNumber).First();

            member.Vehicles.Add(vehicle);
            vehicle.Owner = member;

            await context.SaveChangesAsync();
            return vehicle;  
        }







    }


    
    
}
