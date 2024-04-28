using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Reservation.Queries.GetReservationDetailsQuery;

public class GetReservationDetailsQueryValidator : AbstractValidator<GetReservationDetailsQuery>
{
    public GetReservationDetailsQueryValidator()
    {
        RuleFor(x => x.ReservationId)
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("ID is required.");
    }
}