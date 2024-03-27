using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Event.Commands.DeleteEventCommand;

public class DeleteEventCommandHandler(IEmsDbContext dbContext) : IRequestHandler<DeleteEventCommand, string?>
{
    public async Task<string?> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = await dbContext.Events.Where(x => x.Id.ToString().Equals(request.EventId))
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Event not found");
        
        dbContext.Events.Remove(eventEntity);

        return "Event was deleted successfully";

    }
}