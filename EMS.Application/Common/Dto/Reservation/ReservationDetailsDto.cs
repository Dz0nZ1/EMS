namespace EMS.Application.Common.Dto.Reservation;

public record ReservationDetailsDto(DateTime ReservationDate, decimal Price, bool hasCupon);