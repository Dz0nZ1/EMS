namespace EMS.Application.Common.Dto.Reservation;

public record UpdateReservationDto(string ReservationId, decimal Price, bool HasCoupon);