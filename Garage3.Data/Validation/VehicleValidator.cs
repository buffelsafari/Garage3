using FluentValidation;
using Garage3.Data.Entities;

namespace Garage3.Data.Validation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(veh => veh.Model).NotEmpty().WithMessage("Model cannot be empty");
            RuleFor(veh => veh.Manufacturer).NotEmpty().WithMessage("Manufacturer cannot be empty");
            RuleFor(veh => veh.Wheels).Must(c => c is <= 6 and >= 2).WithMessage("Cannot be less than 2 or more than 6 wheels"); // 2 ? eller 4
            // RuleFor(veh => veh.Wheels).LessThan(2).GreaterThan(6)
            RuleFor(veh => veh.PlateNumber).Matches(@"[]"); // regex 0-6
        }
    }
}