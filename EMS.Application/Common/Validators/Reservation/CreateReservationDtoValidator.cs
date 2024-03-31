using EMS.Application.Common.Dto.Reservation;
using FluentValidation;

namespace EMS.Application.Common.Validators.Reservation;

public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
{
    public CreateReservationDtoValidator()
    {
        RuleFor(dto => dto.ReservationDate)
            .NotEmpty().WithMessage("Reservation date is required.")
            .GreaterThan(DateTime.Now).WithMessage("Reservation date must be in the future.");

        RuleFor(dto => dto.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than zero.");

        RuleFor(dto => dto.EventIds)
            .NotEmpty()
            .WithMessage("At least one event must be selected.");

        RuleFor(dto => dto.UserId)
            .NotEmpty()
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("User ID is required.");
    }
}