using FluentValidation;

namespace EMS.Application.Auth.Commands.CompleteLoginCommand;

public class CompleteLoginCommandValidator : AbstractValidator<CompleteLoginCommand>
{
    public CompleteLoginCommandValidator()
    {
        RuleFor(x => x.ValidationToken).NotEmpty();
    }
}