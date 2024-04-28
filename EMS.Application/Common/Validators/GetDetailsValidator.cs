using FluentValidation;

namespace EMS.Application.Common.Validators;

// public class GetDetailsValidator : AbstractValidator<string>
// {
//     public GetDetailsValidator()
//     {
//         RuleFor(x => x)
//             .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
//             .WithMessage("ID is required.");
//     }
// }