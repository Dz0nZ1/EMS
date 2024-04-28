using MediatR;

namespace EMS.Application.User.Commands.CreateUserCommand;

public record CreateUserCommand(string EmailAddress, List<string> Roles) : IRequest<string>;