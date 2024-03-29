using EMS.Application.Common.Dto.Location;
using EMS.Application.Location.Commands.CreateLocationCommand;
using EMS.Application.Location.Queries.GetLocationDetailsListQuery;
using EMS.Application.Location.Queries.GetLocationDetailsQuery;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class LocationController : ApiControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<LocationDetailsDto>> GetLocationDetails([FromQuery] GetLocationDetailsQuery query) =>
        Ok(await Mediator.Send(query));


    [HttpGet]
    public async Task<ActionResult<List<LocationDetailsDto>>> GetLocationDetailsList(
        [FromQuery] GetLocationDetailsListQuery query) => Ok(await Mediator.Send(query));
    
    
    [HttpPost]
    public async Task<ActionResult<LocationDetailsDto>> CreateLocation(CreateLocationCommand command) =>
        Ok(await Mediator.Send(command));
    
}