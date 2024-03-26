using EMS.Application.Common.Dto.Reservation;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Reservation;

[Mapper]
public static partial class ReservationMapper
{
    public static partial Domain.Entities.Reservation ToEntity(this CreateReservationDto dto);
    
    public static partial ReservationDetailsDto ToDetailsDto(this Domain.Entities.Reservation entity);
}