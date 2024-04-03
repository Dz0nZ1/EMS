using EMS.Application.Common.Dto.Reservation;
using FluentValidation;

namespace EMS.Application.Common.Validators.Reservation;

public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
{
    public UpdateReservationDtoValidator()
    {
        RuleFor(dto => dto.ReservationId)
            .NotEmpty()
            .WithMessage("Reservation ID is required.")
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("Category ID is required.");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}