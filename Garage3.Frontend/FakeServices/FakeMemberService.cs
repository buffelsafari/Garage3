using Garage3.Data.Entities;
using Garage3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage3.Frontend.FakeServices
{
    public class FakeMemberService : IMemberService
    {
        public Task<Member> EditMember(EditMemberArgs args, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Member>> FindMembers(FindMemberArgs args, CancellationToken cancellationToken = default)
        {
            

            IEnumerable<Member> memberList = new List<Member>()
            {
                new Member
                {
                    Id=1,
                    FirstName="Andy",
                    Surname="And",
                    PhoneNumber="123345",
                    PersonalNumber="453345345",
                    MembershipType=new MembershipType
                    {
                        Name="Gold",
                        Garage=null,
                    },


                },
                new Member
                {
                    Id=2,
                    FirstName="Kajsa",
                    Surname="Varg",
                    PhoneNumber="233456",
                    PersonalNumber="453345345",
                    MembershipType=new MembershipType
                    {
                        Name="Silver",
                        Garage=null,
                    },


                },
                new Member
                {
                    Id=3,
                    FirstName="Berra",
                    Surname="Björn",
                    PhoneNumber="123345",
                    PersonalNumber="453345345",
                    MembershipType=new MembershipType
                    {
                        Name="Bronze",
                        Garage=null,
                    },


                },
                new Member
                {
                    Id=4,
                    FirstName="Tally",
                    Surname="Ban",
                    PhoneNumber="123345",
                    PersonalNumber="453345345",
                    MembershipType=new MembershipType
                    {
                        Name="Special",
                        Garage=null,
                    },


                },



            };


            return memberList;


        }

        public async Task<Member> RegisterMember(RegisterMemberArgs args, CancellationToken cancellationToken = default)
        {
            return new Member
            {
                Id=1,
                FirstName="Kalle",
                Surname="Anka",
                PhoneNumber="12234",
                PersonalNumber="123444",
                MembershipType=new MembershipType  
                {
                    Name="blue"
                }
            };
            
        }
    }
}
