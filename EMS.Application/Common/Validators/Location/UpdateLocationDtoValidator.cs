using EMS.Application.Common.Dto.Location;
using FluentValidation;

namespace EMS.Application.Common.Validators.Location;

public class UpdateLocationDtoValidator : AbstractValidator<UpdateLocationDto>
{
    public UpdateLocationDtoValidator()
    {
        RuleFor(dto => dto.LocationId)
            .NotEmpty().WithMessage("Location ID is required.");

        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(dto => dto.Country)
            .MaximumLength(100).WithMessage("Country must not exceed 100 characters.");

        RuleFor(dto => dto.City)
            .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

        RuleFor(dto => dto.Address)
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
    }
}