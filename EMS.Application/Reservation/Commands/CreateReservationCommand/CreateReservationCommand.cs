using EMS.Application.Common.Dto.Reservation;
using MediatR;

namespace EMS.Application.Reservation.Commands.CreateReservationCommand;

public record CreateReservationCommand(CreateReservationDto Reservation) : IRequest<ReservationDetailsDto?>;