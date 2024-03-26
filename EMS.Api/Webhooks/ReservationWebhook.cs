using EMS.Application.Reservation.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Webhooks;

public class ReservationWebhook : BaseWebhook
{
    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateReservationCommand command) =>
        Ok(await Mediator.Send(command));
}