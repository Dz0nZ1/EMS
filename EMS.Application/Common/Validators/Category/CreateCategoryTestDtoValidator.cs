using EMS.Application.Category.Commands.CreateCategoryCommand;
using EMS.Application.Common.Dto.Category;
using EMS.Domain.Common.Extensions;
using FluentValidation;

namespace EMS.Application.Common.Validators.Category;

public class CreateCategoryTestDtoValidator : AbstractValidator<CreateCategoryTestDto>
{
    public CreateCategoryTestDtoValidator()
    {
        RuleFor(x => x.Json)
            .Must(x => x.TryDeserializeJson<CreateCategoryCommand>(out _, SerializerExtensions.SettingsWebOptions))
            .WithMessage(_ => $"Json is not in valid format");
        
    }
}