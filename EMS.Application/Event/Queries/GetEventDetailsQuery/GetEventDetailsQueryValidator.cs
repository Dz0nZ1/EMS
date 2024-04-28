using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Event.Queries.GetEventDetailsQuery;

public class GetEventDetailsQueryValidator : AbstractValidator<GetEventDetailsQuery>
{
    public GetEventDetailsQueryValidator()
    {
        RuleFor(x => x.EventId)
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("ID is required.");
    }
}