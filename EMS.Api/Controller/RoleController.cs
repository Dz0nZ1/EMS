using EMS.Application.Role.Commands.CreateRoleCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class RoleController : ApiControllerBase
{
   [AllowAnonymous]
   [HttpPost]
   public async Task<ActionResult> CreateRole(CreateRoleCommand command) => Ok(await Mediator.Send(command));
}