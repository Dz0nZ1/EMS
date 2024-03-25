using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Location;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Location.Queries.GetLocationDetailsQuery;

public class GetLocationDetailsQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetLocationDetailsQuery, LocationDetailsDto?>
{
    public async Task<LocationDetailsDto?> Handle(GetLocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var location = await dbContext.Locations.Where(x => x.Id.ToString().Equals(request.LocationId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Location not found");

        return location.ToDetailsDto();
    }
}