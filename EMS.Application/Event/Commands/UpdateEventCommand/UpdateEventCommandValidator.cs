using EMS.Application.Common.Validators.Event;
using FluentValidation;

namespace EMS.Application.Event.Commands.UpdateEventCommand;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.Event).SetValidator(new UpdateEventDtoValidator());
    }
}