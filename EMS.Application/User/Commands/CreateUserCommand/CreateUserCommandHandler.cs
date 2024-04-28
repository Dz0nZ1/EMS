using EMS.Application.Common.interfaces;
using MediatR;

namespace EMS.Application.User.Commands.CreateUserCommand;

public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand, string>
{
    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await userService.CreateUserAsync(request.EmailAddress, request.Roles);
        return "User was successfully created";
    }
}