using System.Data;
using EMS.Application.Common.Validators.Event;
using FluentValidation;

namespace EMS.Application.Event.Commands.CreateEventCommand;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.Event).SetValidator(new CreateEventDtoValidator());
    }
}