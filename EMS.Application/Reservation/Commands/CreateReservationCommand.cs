using EMS.Application.Common.Dto.Reservation;
using MediatR;

namespace EMS.Application.Reservation.Commands;

public record CreateReservationCommand(CreateReservationDto Reservation) : IRequest<ReservationDetailsDto?>;