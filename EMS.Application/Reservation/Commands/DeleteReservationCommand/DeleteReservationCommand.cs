using MediatR;

namespace EMS.Application.Reservation.Commands.DeleteReservationCommand;

public record DeleteReservationCommand(string ReservationId) : IRequest<string?> ;