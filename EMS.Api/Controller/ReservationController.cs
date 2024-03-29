using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Reservation.Commands;
using EMS.Application.Reservation.Commands.CreateReservationCommand;
using EMS.Application.Reservation.Commands.DeleteReservationCommand;
using EMS.Application.Reservation.Commands.UpdateReservationCommand;
using EMS.Application.Reservation.Queries;
using EMS.Application.Reservation.Queries.GetReservationDetailsListQuery;
using EMS.Application.Reservation.Queries.GetReservationDetailsQuery;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class ReservationController : ApiControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<List<ReservationDetailsDto>>> GetReservationDetailsList([FromQuery] GetReservationDetailsListQuery query) =>
        Ok(await Mediator.Send(query));

    [HttpGet]
    public async Task<ActionResult<ReservationDetailsDto?>> GetReservationDetails(
        [FromQuery] GetReservationDetailsQuery query) => Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<ActionResult<ReservationDetailsDto?>> CreateReservation(CreateReservationCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut]
    public async Task<ActionResult<ReservationDetailsDto?>> UpdateReservation(UpdateReservationCommand command) =>
        Ok(await Mediator.Send(command));


    [HttpDelete]
    public async Task<ActionResult<string?>> DeleteReservation(DeleteReservationCommand command) =>
        Ok(await Mediator.Send(command));

}