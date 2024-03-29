using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Event;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Event.Commands.UpdateEventCommand;

public class UpdateEventCommandHandler(IEmsDbContext dbContext) : IRequestHandler<UpdateEventCommand, EventDetailsDto?>
{
    public async Task<EventDetailsDto?> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity =
            await dbContext.Events.Where(x => x.Id.ToString().Equals(request.Event.EventId))
                .Include(x => x.Category)
                .Include(x => x.Location)
                .Include(x => x.Reservations!).ThenInclude(x => x.Reservation).ThenInclude(x => x.User)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException("Event not found");
        eventEntity.ToEntity(request.Event);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return eventEntity.ToDetailsDto();
    }
}