using EMS.Application.Common.Dto.Event;
using MediatR;

namespace EMS.Application.Event.Queries.GetEventDetailsQuery;

public record GetEventDetailsQuery(string EventId) : IRequest<EventDetailsDto?>;