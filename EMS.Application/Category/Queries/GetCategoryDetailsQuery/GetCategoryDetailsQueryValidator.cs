using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Category.Queries.GetCategoryDetailsQuery;

public class GetCategoryDetailsQueryValidator : AbstractValidator<GetCategoryDetailsQuery>
{
    public GetCategoryDetailsQueryValidator()
    {
        RuleFor(x => x.CategoryId)
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("ID is required.");
    }
}