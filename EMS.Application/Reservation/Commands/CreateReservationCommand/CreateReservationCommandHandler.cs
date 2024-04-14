using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.interfaces;
using MediatR;


namespace EMS.Application.Reservation.Commands.CreateReservationCommand;

public class CreateReservationCommandHandler(IReservationService reservationService) : IRequestHandler<CreateReservationCommand, ReservationDetailsDto?>
{
    public async Task<ReservationDetailsDto?> Handle(Commands.CreateReservationCommand.CreateReservationCommand request, CancellationToken cancellationToken)
    {
        return await reservationService.CreateAsync(request.Reservation, cancellationToken: cancellationToken);

    }
}