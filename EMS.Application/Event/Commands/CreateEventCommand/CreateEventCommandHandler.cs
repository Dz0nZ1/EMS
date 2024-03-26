using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Event;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Event.Commands.CreateEventCommand;

public class CreateEventCommandHandler(IEmsDbContext dbContext) : IRequestHandler<CreateEventCommand, EventDetailsDto?>
{
    public async Task<EventDetailsDto?> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.Where(x => x.Id.ToString().Equals(request.Event.CategoryId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Category not found");
        
        var location = await dbContext.Locations.Where(x => x.Id.ToString().Equals(request.Event.LocationId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Location not found");
        
        var eventEntity = request.Event.ToEntity().AddCategory(category).AddLocation(location);

        await dbContext.Events.AddAsync(eventEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return eventEntity.ToDetailsDto();
    }
}