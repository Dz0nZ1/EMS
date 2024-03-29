using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Location.Commands.DeleteLocationCommand;

public class DeleteLocationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<DeleteLocationCommand, string?>
{
    public async Task<string?> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await dbContext.Locations.Where(x => x.Id.ToString().Equals(request.LocationId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Location not found");
        dbContext.Locations.Remove(location);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return "Location was deleted successfully";
    }
}