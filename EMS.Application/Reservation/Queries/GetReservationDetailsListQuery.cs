using EMS.Application.Common.Dto.Reservation;
using MediatR;

namespace EMS.Application.Reservation.Queries;

public record GetReservationDetailsListQuery() : IRequest<List<ReservationDetailsDto>>;