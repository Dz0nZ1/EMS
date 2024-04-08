using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Location.Queries.GetLocationDetailsQuery;

public class GetLocationDetailsQueryValidator : AbstractValidator<GetLocationDetailsQuery>
{
    public GetLocationDetailsQueryValidator()
    {
        RuleFor(x => x.LocationId).SetValidator(new GetDetailsValidator());
    }
}