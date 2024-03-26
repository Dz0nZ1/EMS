using EMS.Application.Common.Dto.Event;
using MediatR;

namespace EMS.Application.Event.Commands.CreateEventCommand;

public record CreateEventCommand(CreateEventDto Event) : IRequest<EventDetailsDto?>;