using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Location;

namespace EMS.Infrastructure.Services;

public class LocationService(IEmsDbContext dbContext) : ILocationService
{
    public async Task<LocationDetailsDto?> CreateAsync(CreateLocationDto locationDto, CancellationToken cancellationToken)
    {
        var location = locationDto.ToEntity();
        await dbContext.Locations.AddAsync(location, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return location.ToDetailsDto();
    }
}