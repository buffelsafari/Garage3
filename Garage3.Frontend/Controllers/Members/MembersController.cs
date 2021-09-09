using Garage3.Data.Entities;
using Garage3.Frontend.Models.ViewModels;
using Garage3.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Controllers.Members
{
    public class MembersController:Controller
    {
        private IMemberService memberService;
        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Member> members = await memberService.FindMembers(new FindMemberArgs { });

            return View(CreateModel(members));
        }


        public async Task<IActionResult> Search(MembersOverviewModelView viewModel)
        {
            
            
            IEnumerable<Member> vehicles = await memberService.FindMembers(
                new FindMemberArgs
                {
                    PersonalNumber = viewModel.PersonalNumber,
                    FirstName=viewModel.FirstName,
                    Surname=viewModel.Surname,
                    PhoneNumber=viewModel.PhoneNumber
                });

            return View(nameof(Index), CreateModel(vehicles));
        }

        private MembersOverviewModelView CreateModel(IEnumerable<Member> members)
        {
            return new MembersOverviewModelView
            {
                TableHead = new string[] { "PersonalNumber", "Name", "MembershipType" },
                Members = members.Select(m => new MemberItemModelView { Id = m.Id, Name = $"{m.FirstName} {m.Surname}", PersonalNumber=m.PersonalNumber,MembershipType=m.MembershipType.Name })
            };
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public string OnRegisterSave(RegisterSaveData data)
        {
            // !!color and type is missing in args def

            memberService.RegisterMember(new RegisterMemberArgs
            {
                FirstName = data.FirstName,
                Surname = data.Surname,
                PhoneNumber = data.PhoneNumber,
                PersonalNumber = data.PersonalNumber
            });


            Debug.WriteLine("FirstName:" + data.FirstName);
            Debug.WriteLine("Surname:" + data.Surname);
            Debug.WriteLine("PhoneNumber:" + data.PhoneNumber);
            Debug.WriteLine("PersonalNumber:" + data.PersonalNumber);
            


            var result = new
            {
                Success = true,
                Message = "Message from controller"
            };

            return JsonConvert.SerializeObject(result);
        }

        public class RegisterSaveData
        {
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber{ get; set; }
            public string PersonalNumber { get; set; }
            public string Membership { get; set; }

        
        }




    }

}
