using MediatR;

namespace EMS.Application.Event.Commands.DeleteEventCommand;

public record DeleteEventCommand(string EventId) : IRequest<string?>;