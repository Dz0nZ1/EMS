using MediatR;

namespace EMS.Application.Role.Commands.CreateRoleCommand;

public record CreateRoleCommand(string RoleName) : IRequest<string>;