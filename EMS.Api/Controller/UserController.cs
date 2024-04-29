using EMS.Application.Common.Constants;
using EMS.Application.User.Commands.CreateUserCommand;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;


public class UserController : ApiControllerBase
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AuthorizationConstants.Administrator)]
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserCommand command) => Ok(await Mediator.Send(command));
}