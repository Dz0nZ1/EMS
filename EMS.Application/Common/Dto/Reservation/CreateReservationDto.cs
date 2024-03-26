namespace EMS.Application.Common.Dto.Reservation;

public record CreateReservationDto(DateTime ReservationDate, decimal Price, bool hasCupon, Guid EventId, string UserId);