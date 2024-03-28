namespace EMS.Application.Common.Dto.Reservation;

public record CreateReservationDto(DateTime ReservationDate, decimal Price, bool HasCoupon, List<Guid> EventIds, string UserId);