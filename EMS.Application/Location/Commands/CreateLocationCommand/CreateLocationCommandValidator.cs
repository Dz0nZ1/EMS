using EMS.Application.Common.Validators.Location;
using FluentValidation;

namespace EMS.Application.Location.Commands.CreateLocationCommand;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(x => x.Location).SetValidator(new CreateLocationDtoValidator());
    }
}