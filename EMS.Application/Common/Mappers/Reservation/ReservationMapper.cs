using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Dto.Users;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Reservation;

[Mapper]
public static partial class ReservationMapper
{
    public static partial Domain.Entities.Reservation ToEntity(this CreateReservationDto dto);

    public static ReservationDetailsDto ToReservationDetailsDto(this Domain.Entities.Reservation entity)
    {
        return new ReservationDetailsDto(entity.ReservationDate, entity.Price, entity.HasCoupon, new UserDetailsDto(entity.User.FirstName, entity.User.LastName));
    }

    public static List<ReservationDetailsDto> ToReservationDetailsList(
        this List<Domain.Entities.Reservation> reservations)
    {
        var newDtoList = new List<ReservationDetailsDto>();
        foreach (var reservation in reservations)
        {
            newDtoList.Add(reservation.ToReservationDetailsDto());
        }

        return newDtoList;
    }

    public static partial List<ReservationDetailsDto> ToListDto(this List<Domain.Entities.Reservation> reservations);
}