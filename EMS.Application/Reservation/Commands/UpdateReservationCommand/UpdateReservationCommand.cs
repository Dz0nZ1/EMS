using EMS.Application.Common.Dto.Reservation;
using MediatR;

namespace EMS.Application.Reservation.Commands.UpdateReservationCommand;

public record UpdateReservationCommand(UpdateReservationDto Reservation) : IRequest<ReservationDetailsDto?>;