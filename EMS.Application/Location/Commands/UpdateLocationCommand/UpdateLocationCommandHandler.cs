using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Location;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Location.Commands.UpdateLocationCommand;

public class UpdateLocationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<UpdateLocationCommand, LocationDetailsDto?>
{
    public async Task<LocationDetailsDto?> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location =
            await dbContext.Locations.Where(x => x.Id.ToString().Equals(request.Location.LocationId))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException("Location not found");
        location.ToEntity(request.Location);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return location.ToDetailsDto();

    }
}