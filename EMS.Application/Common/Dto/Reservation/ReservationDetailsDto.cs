using EMS.Application.Common.Dto.Users;

namespace EMS.Application.Common.Dto.Reservation;

public record ReservationDetailsDto(DateTime ReservationDate, decimal Price, bool HasCoupon, UserDetailsDto ReservedBy);