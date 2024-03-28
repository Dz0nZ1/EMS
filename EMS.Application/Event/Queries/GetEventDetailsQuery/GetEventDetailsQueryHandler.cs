using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Event;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Event.Queries.GetEventDetailsQuery;

public class GetEventDetailsQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetEventDetailsQuery, EventDetailsDto?>
{
    public async Task<EventDetailsDto?> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await dbContext.Events.Where(x => x.Id.ToString().Equals(request.EventId))
            .Include(x => x.Category)
            .Include(x => x.Location)
            .Include(x => x.Reservations)
            .Include(x => x.Users)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Event not found");

        return eventEntity.ToDetailsDto();
    }
}