using EMS.Application.Common.Dto.Event;
using MediatR;

namespace EMS.Application.Event.Commands.UpdateEventCommand;

public record UpdateEventCommand(UpdateEventDto Event) : IRequest<EventDetailsDto?>;