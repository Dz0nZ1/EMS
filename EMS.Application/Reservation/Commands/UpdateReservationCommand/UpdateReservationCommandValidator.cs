using EMS.Application.Common.Validators.Reservation;
using FluentValidation;

namespace EMS.Application.Reservation.Commands.UpdateReservationCommand;

public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(x => x.Reservation).SetValidator(new UpdateReservationDtoValidator());
    }
}