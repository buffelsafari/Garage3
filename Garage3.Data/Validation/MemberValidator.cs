using FluentValidation;
using Garage3.Data.Entities;

namespace Garage3.Data.Validation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(mem => mem.FirstName).Length(2, 30).NotEmpty().WithMessage("Firstname cannot be empty"); // nåt annat här? regex?
            RuleFor(mem => mem.Surname).Length(1, 40).NotEmpty().WithMessage("Lastname cannot be empty"); // nåt annat här? regex?
            RuleFor(mem => mem.Surname).NotEqual(mem => mem.FirstName).WithMessage("Lastname and Firstname cannot be equal");
            RuleFor(mem => mem.PhoneNumber).Length(10).Matches(@"[0-9]").NotEmpty().WithMessage("Phone number cannot be empty");
            RuleFor(mem => mem.PersonalNumber).Length(12).Matches(@"[]"); // MaximumLength
        }
    }
}