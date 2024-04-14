using EMS.Application.Common.Dto.Location;

namespace EMS.Application.Common.interfaces;

public interface ILocationService
{
    Task<LocationDetailsDto?> CreateAsync(CreateLocationDto locationDto, CancellationToken cancellationToken);
}