using EMS.Application.Common.Dto.Reservation;

namespace EMS.Application.Common.interfaces;

public interface IReservationService
{
    Task<ReservationDetailsDto?> CreateAsync(CreateReservationDto reservationDto, CancellationToken cancellationToken);
}