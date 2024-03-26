using EMS.Application.Common.Dto.Event;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Event;

[Mapper]
public static partial class EventMapper
{
    public static partial Domain.Entities.Event ToEntity(this CreateEventDto dto);

    public static partial EventDetailsDto ToDetailsDto(this Domain.Entities.Event entity);
}