using EMS.Api.Auth.Constants;
using EMS.Application.Reservation.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Webhooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class ReservationWebhook : BaseWebhook
{
    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateReservationCommand command) =>
        Ok(await Mediator.Send(command));
}