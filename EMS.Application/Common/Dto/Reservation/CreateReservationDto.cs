namespace EMS.Application.Common.Dto.Reservation;

public record CreateReservationDto(DateTime ReservationDate, decimal Price, bool HasCoupon, List<string> EventIds, string UserId);