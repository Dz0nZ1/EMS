using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.interfaces;
using MediatR;


namespace EMS.Application.Event.Commands.CreateEventCommand;

public class CreateEventCommandHandler(IEventService eventService) : IRequestHandler<CreateEventCommand, EventDetailsDto?>
{
    public async Task<EventDetailsDto?> Handle(CreateEventCommand request, CancellationToken cancellationToken) => await eventService.CreateAsync(request.Event, cancellationToken: cancellationToken);
}