using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Event;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Event.Queries.GetEventDetailsListQuery;

public class GetEventDetailsListQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetEventDetailsListQuery, List<EventDetailsDto>>
{
    public async Task<List<EventDetailsDto>> Handle(GetEventDetailsListQuery request, CancellationToken cancellationToken)
    {
        var events = await dbContext.Events.Include(x => x.Category)
            .Include(x => x.Location)
            .Include(x => x.Reservations)
            .Include(x => x.Users).ToListAsync(cancellationToken: cancellationToken);

        return events.ToDetailsList();
    }
}