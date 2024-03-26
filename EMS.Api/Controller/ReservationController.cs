using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Reservation.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class ReservationController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateReservationCommand command) =>
        Ok(await Mediator.Send(command));
}