using EMS.Application.Common.Validators;
using FluentValidation;

namespace EMS.Application.Category.Queries.GetCategoryDetailsQuery;

public class GetCategoryDetailsQueryValidator : AbstractValidator<GetCategoryDetailsQuery>
{
    public GetCategoryDetailsQueryValidator()
    {
        RuleFor(x => x.CategoryId).SetValidator(new GetDetailsValidator());
    }
}