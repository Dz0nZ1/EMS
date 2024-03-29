using EMS.Application.Common.Dto.Reservation;
using MediatR;

namespace EMS.Application.Reservation.Queries.GetReservationDetailsListQuery;

public record GetReservationDetailsListQuery() : IRequest<List<ReservationDetailsDto>>;