using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Event;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Services;

public class EventService(IEmsDbContext dbContext) : IEventService
{
    public async Task<EventDetailsDto?> CreateAsync(CreateEventDto eventDto, CancellationToken cancellationToken )
    {
        var category = await dbContext.Categories.Where(x => x.Id.ToString().Equals(eventDto.CategoryId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Category not found");
        
        var location = await dbContext.Locations.Where(x => x.Id.ToString().Equals(eventDto.LocationId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Location not found");
        
        var eventEntity = eventDto.ToEntity().AddCategory(category).AddLocation(location);

        await dbContext.Events.AddAsync(eventEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return eventEntity.ToDetailsDto();
    }
}