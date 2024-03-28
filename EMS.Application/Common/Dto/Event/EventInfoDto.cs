using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Dto.Users;

namespace EMS.Application.Common.Dto.Event;

public record EventInfoDto(
    CategoryDetailsDto Category,
    LocationDetailsDto Location,
    IEnumerable<ReservationDetailsDto?> Reservations);
    