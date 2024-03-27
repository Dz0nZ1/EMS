using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Reservation.Commands;
using EMS.Application.Reservation.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class ReservationController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ReservationDetailsDto?>> CreateReservation(CreateReservationCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet]
    public async Task<ActionResult<ReservationDetailsDto?>> GetReservationDetailsList(GetReservationDetailsListQuery query) =>
        Ok(await Mediator.Send(query));
}