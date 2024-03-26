using EMS.Application.Common.Validators.Category;
using FluentValidation;

namespace EMS.Application.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Category).SetValidator(new CreateCategoryDtoValidator());
    }
}