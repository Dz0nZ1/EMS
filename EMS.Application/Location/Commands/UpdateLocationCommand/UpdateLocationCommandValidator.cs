using EMS.Application.Common.Validators.Location;
using FluentValidation;

namespace EMS.Application.Location.Commands.UpdateLocationCommand;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(x => x.Location).SetValidator(new UpdateLocationDtoValidator());
    }
}