using EMS.Application.Common.Dto.Event;
using MediatR;

namespace EMS.Application.Event.Queries.GetEventDetailsListQuery;

public record GetEventDetailsListQuery() : IRequest<List<EventDetailsDto>>;