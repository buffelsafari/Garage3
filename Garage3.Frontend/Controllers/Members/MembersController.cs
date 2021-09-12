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
                    PhoneNumber=viewModel.PhoneNumber,
                    MembershipTypeName=viewModel.MembershipType
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
        public async Task<string> OnRegisterSave(RegisterSaveData data)
        {
            //todo exeptions and validation
            var member=await memberService.RegisterMember(new RegisterMemberArgs
            {
                FirstName = data.FirstName,
                Surname = data.Surname,
                PhoneNumber = data.PhoneNumber,
                PersonalNumber = data.PersonalNumber,
                MembershipTypeName=data.Membership,
            });

            
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


        private async Task<Member> GetMemberFromId(int id)
        {
            IEnumerable<Member> members = await memberService.FindMembers(
                new FindMemberArgs
                {

                });
            return members.Where(v => v.Id == id).First();
        }


        public async Task<string> OnMemberDetailsButton(int id)  // todo move to vehicle controller
        {

            Member member = await GetMemberFromId(id);

            // todo exeptions
            MemberDetailModelView model = new MemberDetailModelView
            {
                FirstName=member.FirstName,
                Surname=member.Surname,
                PhoneNumber=member.PhoneNumber,
                PersonalNumber=member.PersonalNumber,
                MembershipType=member.MembershipType.Name

            };


            return JsonConvert.SerializeObject(model);
        }



        public async Task<string> OnVehicleEditButton(int id)  // todo maybe refactor with above
        {
            
            Member member = await GetMemberFromId(id);

            // todo exeptions
            MemberDetailModelView model = new MemberDetailModelView
            {
                FirstName = member.FirstName,
                Surname = member.Surname,
                PhoneNumber = member.PhoneNumber,
                PersonalNumber = member.PersonalNumber,
                MembershipType = member.MembershipType.Name

            };

            return JsonConvert.SerializeObject(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> OnEditSave(EditSaveData data)
        {
            await memberService.EditMember(new EditMemberArgs
            {
                Id=data.Id,
                PersonalNumber=data.PersonalNumber,
                PhoneNumber=data.PhoneNumber,
                FirstName=data.FirstName,
                Surname=data.Surname,
                MembershipTypeName=data.MembershipType                
            });

                        

            // edit the vehicle
            Debug.WriteLine("member Id:" + data.Id);
            Debug.WriteLine("FirstName:" + data.FirstName);
            Debug.WriteLine("Surname:" + data.Surname);
            Debug.WriteLine("PhoneNumber:" + data.PhoneNumber);
            Debug.WriteLine("PersonalNumber:" + data.PersonalNumber);
            Debug.WriteLine("MembershipType:" + data.MembershipType);


            var result = new
            {
                Success = true,
                Message = "Message from controller"
            };

            return JsonConvert.SerializeObject(result);
        }


        public class EditSaveData
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public string PersonalNumber { get; set; }            
            public string MembershipType { get; set; }

        }




        public async Task<string> OnVehicleAddButton(int id)  // todo maybe refactor with above
        {
            Member member = await GetMemberFromId(id);
            // todo exeptions
            AddVehicleMemberView model = new AddVehicleMemberView
            {
                Name = $"{member.FirstName} {member.Surname}"                
            };

            return JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> OnAddVehicleSave(AddVehicleSaveData data)
        {
            //await memberService.EditMember(new EditMemberArgs
            //{
            //    Id = data.Id,
            //    PersonalNumber = data.PersonalNumber,
            //    PhoneNumber = data.PhoneNumber,
            //    FirstName = data.FirstName,
            //    Surname = data.Surname,
            //    MembershipTypeName = data.MembershipType
            //});
            // todo add vehicle to member service


            // edit the vehicle
            Debug.WriteLine("member Id:" + data.Id);
            Debug.WriteLine("Platenumber:" + data.PlateNumber);
            


            var result = new
            {
                Success = true,
                Message = "Message from controller"
            };

            return JsonConvert.SerializeObject(result);
        }


        public class AddVehicleMemberView
        {
            public string Name { get; set; }
        }

        public class AddVehicleSaveData
        { 
            public int Id { get; set; }
            public string PlateNumber { get; set; }
        }

    }

}
