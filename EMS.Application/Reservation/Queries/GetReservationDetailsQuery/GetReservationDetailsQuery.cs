using EMS.Application.Common.Dto.Reservation;
using MediatR;

namespace EMS.Application.Reservation.Queries.GetReservationDetailsQuery;

public record GetReservationDetailsQuery(string ReservationId) : IRequest<ReservationDetailsDto?>;