using EMS.Application.Common.Dto.Location;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Location;

[Mapper]
public static partial class LocationMapper
{
    public static partial Domain.Entities.Location ToEntity(this CreateLocationDto dto);
    
    public static partial LocationDetailsDto ToDetailsDto(this Domain.Entities.Location entity);
}