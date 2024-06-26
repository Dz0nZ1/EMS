﻿using EMS.Application.Common.Dto.Event;
using EMS.Application.Event.Commands.CreateEventCommand;
using EMS.Application.Event.Commands.DeleteEventCommand;
using EMS.Application.Event.Commands.UpdateEventCommand;
using EMS.Application.Event.Queries.GetEventDetailsListQuery;
using EMS.Application.Event.Queries.GetEventDetailsQuery;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class EventController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<EventDetailsDto>> GetEventDetails([FromQuery] GetEventDetailsQuery query) =>
        Ok(await Mediator.Send(query));

    [HttpGet]
    public async Task<ActionResult<EventDetailsDto?>> GetEventDetailsList([FromQuery] GetEventDetailsListQuery query) =>
        Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<ActionResult<EventDetailsDto>> CreateEvent(CreateEventCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut]
    public async Task<ActionResult<EventDetailsDto?>> UpdateEvent(UpdateEventCommand command) =>
        Ok(await Mediator.Send(command));


    [HttpDelete]
    public async Task<ActionResult<string?>> DeleteEvent(DeleteEventCommand command) =>
        Ok(await Mediator.Send(command));
}