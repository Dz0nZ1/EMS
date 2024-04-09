using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Event.Queries.GetEventDetailsQuery;

public class GetEventDetailsQueryValidator : AbstractValidator<GetEventDetailsQuery>
{
    public GetEventDetailsQueryValidator()
    {
        RuleFor(x => x.EventId).SetValidator(new GetDetailsValidator());
    }
}