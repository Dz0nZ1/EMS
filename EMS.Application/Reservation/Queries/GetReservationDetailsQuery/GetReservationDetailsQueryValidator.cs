using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Reservation.Queries.GetReservationDetailsQuery;

public class GetReservationDetailsQueryValidator : AbstractValidator<GetReservationDetailsQuery>
{
    // public GetReservationDetailsQueryValidator()
    // {
    //     RuleFor(x => x.ReservationId).SetValidator(new GetDetailsValidator());
    // }
}