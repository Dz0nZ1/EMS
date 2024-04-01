using System.Data;
using EMS.Application.Common.Validators.Category;
using FluentValidation;

namespace EMS.Application.Category.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Category).SetValidator(new UpdateCategoryDtoValidator());
    }
}