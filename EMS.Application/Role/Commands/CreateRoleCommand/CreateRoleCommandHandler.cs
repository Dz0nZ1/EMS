using EMS.Application.Common.interfaces;
using MediatR;

namespace EMS.Application.Role.Commands.CreateRoleCommand;

public class CreateRoleCommandHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommand, string>
{
    public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await roleService.CreateRoleAsync(request.RoleName);
        return "Role was successfully created";
    }
}