using EMS.Application.Common.Dto.Event;
using FluentValidation;

namespace EMS.Application.Common.Validators.Event;

public class CreateEventDtoValidator : AbstractValidator<CreateEventDto>
{
    public CreateEventDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(dto => dto.StartTime)
            .NotEmpty().WithMessage("Start time is required.")
            .GreaterThan(DateTime.Now).WithMessage("Start time must be in the future.");

        RuleFor(dto => dto.EndTime)
            .NotEmpty().WithMessage("End time is required.")
            .GreaterThan(dto => dto.StartTime).WithMessage("End time must be after start time.");

        RuleFor(dto => dto.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to zero.");

        RuleFor(dto => dto.LocationId)
            .NotEmpty()
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("Location ID is required.");

        RuleFor(dto => dto.CategoryId)
            .NotEmpty()
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("Category ID is required.");
    }
}