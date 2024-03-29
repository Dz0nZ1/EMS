using EMS.Application.Common.Dto.Location;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Location;

[Mapper]
public static partial class LocationMapper
{
    public static partial Domain.Entities.Location ToEntity(this CreateLocationDto dto);
    
    public static partial LocationDetailsDto ToDetailsDto(this Domain.Entities.Location entity);

    public static partial List<LocationDetailsDto> ToDetailsList(this List<Domain.Entities.Location> entities);

    public static void ToEntity(this Domain.Entities.Location entity, UpdateLocationDto dto)
    {
        entity.UpdateLocation(dto.Name, dto.Country, dto.City, dto.Address);
    }

 
}