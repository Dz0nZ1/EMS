using EMS.Application.Common.Validators.Reservation;
using FluentValidation;

namespace EMS.Application.Reservation.Commands.CreateReservationCommand;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.Reservation).SetValidator(new CreateReservationDtoValidator());
    }
}